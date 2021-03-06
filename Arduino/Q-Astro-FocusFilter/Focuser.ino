/*  Motor2 Controls the Focuser
 * ---------------------------------------------------------------------------------------------------------------------------- */

#define fSTARTPOSITION 0    // Define the Start Position of the Focuser when the system is started.
#define fMOTORFREQ 200      // Motor steps per revolution. Most steppers are 200 steps or 1.8 degrees/step
#define fMOTOR_SPEED 50     // Set the motor speed. 150 gives a smooth rotation.
#define fMaxStep 5000       // Set the Max single focus adjustment before a delay needs to be added. This is added as the motor starts to stutter otherwise
#define fMaxPosition 32000  // Define the Max Focuser position. This is defined in steps of the motor. 
#define fMinPosition 0      // Define the Min Focuser position.
#define fEEPROMStart 100    // The starting address for reading and writing the Focuser Position to/from EEPROM
#define fSTEPSTYLE SINGLE
#define fMICROSTEPS 8

// All the wires needed for full functionality
#define fDIR 3
#define fSTEP 2
#define fENABLE 5

// Wiring done in such a way that direction is reversed. Wiring mistake but can be fixed in code. Set -1 for reverse wiring or 1 for normal wiring. 
// In my case for the DRV8825 it was reverse but for TMC2209 is correct.
// This value will be used in the SetFocuserPosition function to make sure the motor rotates in the correct direction.
#define fDIRECTION 1

/* Microstep control for DRV8825

    MODE0 MODE1 MODE2 Microstep Resolution
    Low   Low   Low   Full step   = 1
    High  Low   Low   Half step   = 2
    Low   High  Low   1/4 step    = 4
    High  High  Low   1/8 step    = 8
    Low   Low   High  1/16 step   = 16
    High  Low   High  1/32 step   
    Low   High  High  1/32 step
    High  High  High  1/32 step   = 32

    Since microstepping is set externally, make sure this matches the selected mode
    If it doesn't, the motor will move at a different RPM than chosen
    1=full step, 2=half step etc.
*/

#define fMODE0 6     //Can be changed if you want but works well for both DRV8825 & TMC2209
#define fMODE1 7     //Can be changed if you want but works well for both DRV8825 & TMC2209
#define fMODE2 4     //For TMC2209 this is not needed. But is required for DRV8825. If not needed, leave default value of 11.

DRV8825 focuser(fMOTORFREQ, fDIR, fSTEP, fENABLE, fMODE0, fMODE1, fMODE2);

// This sets the Current Focusser Wheel Position. Always starts in position 1.
int fCurrentPosition;

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of Motor2 Definitions */

void InitFocuser()
{
  int memFocuserPos = EEPROMReadInt(fEEPROMStart);
  if (memFocuserPos > 0)
    {fCurrentPosition = memFocuserPos;}
  else
    fCurrentPosition = fSTARTPOSITION;

    focuser.begin(fMOTOR_SPEED);
    // if using enable/disable on ENABLE pin (active LOW) instead of SLEEP uncomment next line
    focuser.setEnableActiveState(LOW);
    focuser.disable();
}

/* Start of Focuser functions */
/* ---------------------------------------------------------------------------------------------------------------------------- */

void DoFocuserAction(String ASCOMcmd)
{
    int steps = 0;
    
    switch((char)ASCOMcmd[0]) {
      case 'p':     //Get current position
          SendSerialCommand(focuserId,fCurrentPosition);
        break;
      case 'm':  //Move x #steps - relative focusing
          steps = ASCOMcmd.substring(1).toInt();
          MoveFocuserAndReduce(steps); 
        break;
      case 'f':  //Move to position f - absolute focusing
          steps = ASCOMcmd.substring(1).toInt();
          MoveFocusertoAbsolutePosition(steps);   //Steps should be read as absolute position
        break;
      case 'x':  //Get Max Position
          SendSerialCommand(focuserId,fMaxPosition);
        break;
      case 's':  //Get Max Step
          SendSerialCommand(focuserId,fMaxStep);
        break;
      case 'd':  //Debug function to set current position
          steps = ASCOMcmd.substring(1).toInt();
          fCurrentPosition = steps;
          EEPROMWriteInt(fEEPROMStart,fCurrentPosition);
          SendSerialCommand(focuserId,fCurrentPosition);          
        break;
      case 'r': //Reset focusser position to 0
          fCurrentPosition = 0;
          EEPROMWriteInt(fEEPROMStart,fCurrentPosition);
          SendSerialCommand(focuserId,fCurrentPosition);          
        break;
    }
}

void MoveFocuserAndReduce(int steps)
{
  int mxStep = fMaxStep;
  int nextPos = fCurrentPosition + steps;

  if(nextPos != fCurrentPosition) {
    if(nextPos < 0 || nextPos > fMaxPosition) {
      SendSerialCommand(focuserId,"-1");
      return;
    }
    else
    {
      if (steps < 0)
        {mxStep = -fMaxStep;}
  
      while (abs(steps) > fMaxStep)
      {
        SetFocuserPosition(mxStep,false);
        steps = steps - mxStep;
        delay(1000);                  // Set a delay a single move is bigger than the 
      }
      SetFocuserPosition(steps,true);
    }
  }
}

void SetFocuserPosition(int steps, bool reportBack)
{
  focuser.enable();
  focuser.setMicrostep(fMICROSTEPS);   // Set microstep mode to 1:8

  focuser.move(fMICROSTEPS*steps*fDIRECTION);
  
  focuser.disable();

  fCurrentPosition = fCurrentPosition + steps;
  EEPROMWriteInt(fEEPROMStart,fCurrentPosition);

  if (reportBack)
    {SendSerialCommand(focuserId, fCurrentPosition);}
}

void MoveFocusertoAbsolutePosition(int absPosition)
{
  int stepstoNewPosition = absPosition - fCurrentPosition;
  MoveFocuserAndReduce(stepstoNewPosition);
}

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of Focuser functions */
