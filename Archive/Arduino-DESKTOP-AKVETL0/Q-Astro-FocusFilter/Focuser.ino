/*  Motor2 Controls the Focuser
 * ---------------------------------------------------------------------------------------------------------------------------- */

#include <math.h>

#define FOCUS_MOTOR_FREQ 200      // Motor steps per revolution. Most steppers are 200 steps or 1.8 degrees/step
#define FOCUS_MOTOR_SPEED 150    // Set the motor speed. 150 gives a smooth rotation.

// All the wires needed for full functionality
#define FOCUS_DIR_PIN 3
#define FOCUS_STEP_PIN 2
#define FOCUS_ENABLE_PIN 5

#define FOCUS_MS0_PIN 6 
#define FOCUS_MS1_PIN 7 
#define FOCUS_MS2_PIN 4 

#define FOCUS_MEMORY 100

// Wiring done in such a way that direction is reversed. Wiring mistake but can be fixed in code. Set -1 for reverse wiring or 1 for normal wiring. 
// In my case for the DRV8825 it was reverse but for TMC2209 is correct.
// This value will be used in the SetFocuserPosition function to make sure the motor rotates in the correct direction.
#define FOCUS_DIRECTION 1

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

  Microstep control for TMC2208 v3.0

    MODE0 MODE1 Microstep Resolution
    High  Low   Half step   = 2
    Low   High  1/4 step    = 4
    Low   Low   1/8 step    = 8
    High  High  1/16 step   = 16
   
    Since microstepping is set externally, make sure this matches the selected mode
    If it doesn't, the motor will move at a different RPM than chosen
    1=full step, 2=half step etc.
*/

#define FOCUS_TMC2208 1 // If you use a TMC2208 instead of a DRV8825, set this value to 1 otherwise make sure it is set to 0.

#define FOCUS_DEF_STEPMODE 2

#define FOCUS_DEF_MAXSTEP 5000       // Set the Max single focus adjustment before a delay needs to be added. This is added as the motor starts to stutter otherwise
#define FOCUS_DEF_MAXPOSITION 99999  // Define the Max Focuser position. This is defined in steps of the motor. 
#define FOCUS_DEF_STEPSIZE 10
#define FOCUS_DEF_STARTPOSITION 0    // Define the Start Position of the Focuser when the system is started.

DRV8825 focuser(FOCUS_MOTOR_FREQ, FOCUS_DIR_PIN, FOCUS_STEP_PIN, FOCUS_ENABLE_PIN, FOCUS_MS0_PIN, FOCUS_MS1_PIN, FOCUS_MS2_PIN);

long focusPos;
long stepSize;
int  stepMode;
int  maxStep;
long maxPosition;

int isMoving = 0;

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of Motor2 Definitions */

void SetStepModeTMC2208Focuser(int stepMode)
{
  switch (stepMode)
  {
    case 2:
      digitalWrite(FOCUS_MS0_PIN, 1);
      digitalWrite(FOCUS_MS1_PIN, 0);
      break;
    case 4:
      digitalWrite(FOCUS_MS0_PIN, 0);
      digitalWrite(FOCUS_MS1_PIN, 1);
      break;
    case 8:
      digitalWrite(FOCUS_MS0_PIN, 0);
      digitalWrite(FOCUS_MS1_PIN, 0);
      break;
    case 16:
      digitalWrite(FOCUS_MS0_PIN, 1);
      digitalWrite(FOCUS_MS1_PIN, 1);
      break;
    default:    // half stepping
      digitalWrite(FOCUS_MS0_PIN, 1);
      digitalWrite(FOCUS_MS1_PIN, 0);
      break;
  }
}

void SetStepModeFocuser()
{
  if (FOCUS_TMC2208 == 1)
    SetStepModeTMC2208Focuser(stepMode);
  else
    focuser.setMicrostep(stepMode);
}

void InitFocuser()
{
  Serial.println("Init Focuser..");
  
  Serial.println("Init EEPROM data..");
  focusEEPROMLoad();
  
  SetStepModeFocuser();

  focuser.begin(FOCUS_MOTOR_SPEED);
  // if using enable/disable on ENABLE pin (active LOW) instead of SLEEP uncomment next line
  focuser.setEnableActiveState(LOW);
  focuser.disable();
}

/* Start of Focuser functions */
/* ---------------------------------------------------------------------------------------------------------------------------- */

void DoFocuserAction(String ASCOMcmd)
{
    long xSteps = 0;

    switch((char)ASCOMcmd[0]) 
    {
      case 'a':  //Get Max Step
        SendSerialCommand(focuserId,maxStep);
        break;
      case 'A':   //Set Max Step
        maxStep = ASCOMcmd.substring(1).toInt();
        focusEEPROMSave(); 
        focusEEPROMLoad();         
        SendSerialCommand(focuserId,maxStep);
        break;
      case 'b':  //Is the focuser moving
        SendSerialCommand(focuserId,isMoving);
        break;
      case 'f':  //Move to position f absolute focusing
        xSteps = ASCOMcmd.substring(1).toInt();
        MoveFocusertoAbsolutePosition(xSteps);   //Steps should be read as absolute position
        break;
      case 'm':  //Move nr of steps relative focusing
        xSteps = ASCOMcmd.substring(1).toInt();
        MoveFocuserAndReduce(xSteps); 
        break;
      case 'n':  //Get Step Resolution
        SendSerialCommand(focuserId,stepMode);  
        break;
      case 'N':  //Set Step Mode
        stepMode = ASCOMcmd.substring(1).toInt();
        focusEEPROMSave();
        focusEEPROMLoad();
        SetStepModeFocuser();
        SendSerialCommand(focuserId,stepMode);          
        break;
      case 'p':     //Get current position
        SendSerialCommand(focuserId,focusPos);
        break;
      case 'r': //Reset focusser position to 0
        focusPos = 0;
        focusEEPROMSave();
        focusEEPROMLoad();
        SendSerialCommand(focuserId,focusPos);          
        break;
      case 's':  //Get Stepsize
        SendSerialCommand(focuserId,stepSize);      
        break;
      case 'S':  //Set StepSize
        stepSize = ASCOMcmd.substring(1).toInt();
        focusEEPROMSave();
        focusEEPROMLoad();
        SendSerialCommand(focuserId, stepSize);          
        break;
      case 'x':  //Get Max Position
        SendSerialCommand(focuserId,maxPosition);
        break;
      case 'X':  //Set Max Position
        maxPosition = ASCOMcmd.substring(1).toInt();
        focusEEPROMSave();
        focusEEPROMLoad();
        SendSerialCommand(focuserId,maxPosition);
        break;
      case 'z':
        focusEEPROMReset();
        SendSerialCommand(focuserId,"EEPROM Reset");
        break;
    }
}

void MoveFocuserAndReduce(long steps)
{
  long nextPos = focusPos + steps;
  long mxStep = maxStep;
  
  if(nextPos < 0 || nextPos > maxPosition || nextPos == focusPos)
  {
    SendSerialCommand(focuserId,focusPos);
    return;
  }

  if(nextPos != focusPos) 
  {
    isMoving = 1;

    if (steps < 0)
      {mxStep = -maxStep;}         // If focusser is reduced make sure to use the neg nr of Max Step Size.
  
    while (abs(steps) > maxStep)
    {
      SetFocuserPosition(mxStep,false);
      steps = steps - mxStep;
      delay(1000);                  // Set a delay a single move is bigger than the max step size.
    }
    SetFocuserPosition(steps,true);

    isMoving = 0;
  }
}

void SetFocuserPosition(long steps, bool reportBack)
{

  focuser.enable();

  SetStepModeFocuser();
  focuser.move(stepMode * steps * FOCUS_DIRECTION);  
  
  focuser.disable();

  focusPos = focusPos + steps;
  focusEEPROMSave();

  if (reportBack)
    SendSerialCommand(focuserId, focusPos);
}

void MoveFocusertoAbsolutePosition(long absPosition)
{
  long stepstoNewPosition = absPosition - focusPos;
  MoveFocuserAndReduce(stepstoNewPosition);
}

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of Focuser functions */
