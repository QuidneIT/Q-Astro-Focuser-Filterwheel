/*  Motor1 Controls the FilterWheel
 * ---------------------------------------------------------------------------------------------------------------------------- */

#define wSTARTPOSITION 1     // Define the Start Position of the Filter Wheel when the system is started.
#define wNRFILTERS 5         // Define the Number of Filters on your Filter Wheel
#define wMOTORFREQ 200       
#define wMOTOR 1             // Which Motor to use connected to the Arduino.
#define wMOTOR_SPEED 50      // Set the motor speed.
#define wEEPROMStart 200     // The starting address for reading and writing the FilterWheel Position to/from EEPROM
#define wSTEPSTYLE DOUBLE
#define wMICROSTEPS 8

int wCurrentPosition = 0;    // This sets the Current Filter Wheel Position. This will be read from EEPROM but initial value will be position 1.

// All the wires needed for full functionality
#define wDIR 13  
#define wSTEP 12 
#define wENABLE 8  

// Wiring done in such a way that direction is reversed. Wiring mistake but can be fixed in code. Set -1 for reverse wiring or 1 for normal wiring. 
// In my case for the DRV8825 it was reverse but for TMC2209 is correct.
// This value will be used in the MoveFilter function to make sure the motor rotates in the correct direction.
#define wDIRECTION 1

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

#define wMODE0 9        //Can be changed if you want but works well for both DRV8825 & TMC2209
#define wMODE1 10       //Can be changed if you want but works well for both DRV8825 & TMC2209
#define wMODE2 11       //For TMC2209 this is not needed. But is required for DRV8825. If not needed, leave default value of 11.
DRV8825 filterwheel(wMOTORFREQ, wDIR, wSTEP, wENABLE, wMODE0, wMODE1, wMODE2);

int wMOTOR_ROTSTEPS = 450;                      //Nr of steps between 2 filter positions. This differ per Filterwheel and setup.
int MaxMoveSteps = (int)round(wNRFILTERS/2);    //Max Steps for any filter wheel is a round down of the number of filters devided by 2. e.g. For 5 filters the max steps is 2.

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End Motor1 Definitions */

/* Start of FilterWheel functions */
/* ---------------------------------------------------------------------------------------------------------------------------- */

void InitFilterWheel()
{
  long memFilterPos = EEPROMReadInt(wEEPROMStart);
  if (memFilterPos > -1)
    {wCurrentPosition = memFilterPos;}
  else
    wCurrentPosition = wSTARTPOSITION;

  filterwheel.begin(wMOTOR_SPEED);
  filterwheel.setEnableActiveState(LOW);
  filterwheel.disable();
}

int DoFilterWheelAction(String ASCOMcmd)
{
  int nFilter = -1;
  
  switch((char)ASCOMcmd[0]) {
    case 'g':     //Case the function is for the FilterWheel
        SendSerialCommand(filterWheelId,wCurrentPosition); 
        break;

    case 's':  //Case the function is for the FilterWheel
        if (ASCOMcmd.substring(1,ASCOMcmd.length()-1).toInt() > nFilter) {    //Only do something if the new position is different from the current position.
          nFilter = ASCOMcmd.substring(1,ASCOMcmd.length()-1).toInt();
//          if (nFilter > 0)
            MoveFilter(nFilter);
        }
        break;
    case 'p':
        if ((char)ASCOMcmd[1] != '#')
          wMOTOR_ROTSTEPS = ASCOMcmd.substring(1,ASCOMcmd.length()-1).toInt();

        SendSerialCommand(filterWheelId,wMOTOR_ROTSTEPS);
        break;              
    }
}

//Move FilterWheel to the Next Position requested.
void MoveFilter(int wNextPosition) 
{
  int wRotateSteps = getShortestPathToNextFilterPosition(wNextPosition);
    
  if (wRotateSteps != 0)
  {
    for (int i = 1; i < (abs(wRotateSteps)+1); i++)
    {
      if (wRotateSteps < 0)
        MoveFilterWheel((-1 * wMOTOR_ROTSTEPS));
      else
        MoveFilterWheel(wMOTOR_ROTSTEPS);
    }
  
    wCurrentPosition = wNextPosition;
    EEPROMWriteInt(wEEPROMStart,wCurrentPosition);
  }
  SendSerialCommand(filterWheelId,wCurrentPosition); 
}

void MoveFilterWheel(int wMove)
{
  filterwheel.enable();
  filterwheel.setMicrostep(wMICROSTEPS);   // Set microstep mode to 1:8
  filterwheel.move(wMICROSTEPS * wMove * wDIRECTION);
  filterwheel.disable();
  delay(1000);
}

// We would like to get to the new filter position as quickly as possible. This means moving the filter wheel either clockwise or counter clockwise.
// This function will determine the shortest path and return either positive rotation or negative rotation.
int getShortestPathToNextFilterPosition(int wNextPosition)
{
    int steps = wNextPosition - wCurrentPosition;

    if (abs(steps) > MaxMoveSteps)
    {
      steps = wNRFILTERS - abs(steps);
       
      if ((wNextPosition - wCurrentPosition) > 0)
        steps = -1 * steps;
    }
    return steps;
}

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of FilterWheel functions */
