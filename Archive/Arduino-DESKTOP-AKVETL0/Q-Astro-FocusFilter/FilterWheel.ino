/*  Motor1 Controls the FilterWheel
 * ---------------------------------------------------------------------------------------------------------------------------- */

#define FILTER_MOTOR_FREQ 200       
#define FILTER_MOTOR_SPEED 150      // Set the motor speed.

// All the wires needed for full functionality
#define FILTER_DIR_PIN 13  
#define FILTER_STEP_PIN 12 
#define FILTER_ENABLE_PIN 8  

#define FILTER_MS0_PIN 9 
#define FILTER_MS1_PIN 10
#define FILTER_MS2_PIN 11

#define FILTER_MEMORY 300

// Wiring done in such a way that direction is reversed. Wiring mistake but can be fixed in code. Set -1 for reverse wiring or 1 for normal wiring. 
// In my case for the DRV8825 it was reverse but for TMC2209 is correct.
// This value will be used in the MoveFilter function to make sure the motor rotates in the correct direction.
#define FILTER_DIRECTION 1

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

#define FILTER_TMC2208 1 // If you use a TMC2208 instead of a DRV8825, set this value to 1 otherwise make sure it is set to 0.
    
#define FILTER_STEPMODE 8

DRV8825 filterwheel(FILTER_MOTOR_FREQ, FILTER_DIR_PIN, FILTER_STEP_PIN, FILTER_ENABLE_PIN, FILTER_MS0_PIN, FILTER_MS1_PIN, FILTER_MS2_PIN);

#define FILTER_DEF_STARTPOSITION 1     // Define the Start Position of the Filter Wheel when the system is started.
#define FILTER_DEF_NRFILTERS 5         // Define the Number of Filters on your Filter Wheel

int filterPos = 0;    // This sets the Current Filter Wheel Position. This will be read from EEPROM but initial value will be position 1.

int FILTER_MOTOR_ROTSTEPS = 218;                  //Nr of steps between 2 filter positions. This differ per Filterwheel and setup.
int FILTER_MOTOR_COMPENSATION = 2;   //Nr of steps for drift compensation.
int MaxMoveSteps = (int)round(FILTER_DEF_NRFILTERS/2);    //Max Steps for any filter wheel is a round down of the number of filters devided by 2. e.g. For 5 filters the max steps is 2.

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End Motor1 Definitions */

void SetStepModeTMC2208Filter(int stepMode)
{
  switch (stepMode)
  {
    case 2:
      digitalWrite(FILTER_MS0_PIN, 1);
      digitalWrite(FILTER_MS1_PIN, 0);
      break;
    case 4:
      digitalWrite(FILTER_MS0_PIN, 0);
      digitalWrite(FILTER_MS1_PIN, 1);
      break;
    case 8:
      digitalWrite(FILTER_MS0_PIN, 0);
      digitalWrite(FILTER_MS1_PIN, 0);
      break;
    case 16:
      digitalWrite(FILTER_MS0_PIN, 1);
      digitalWrite(FILTER_MS1_PIN, 1);
      break;
    default:    // half stepping
      digitalWrite(FILTER_MS0_PIN, 1);
      digitalWrite(FILTER_MS1_PIN, 0);
      break;
  }
}

void SetStepModeFilter()
{
  if (FILTER_TMC2208 == 1)
    SetStepModeTMC2208Filter(FILTER_STEPMODE);
  else
    filterwheel.setMicrostep(FILTER_STEPMODE);
}


/* Start of FilterWheel functions */
/* ---------------------------------------------------------------------------------------------------------------------------- */

void InitFilterWheel()
{
  Serial.println("Init Filter Wheel..");

  Serial.println("Init EEPROM data..");
  filterEEPROMLoad();

  SetStepModeFilter();

  filterwheel.begin(FILTER_MOTOR_SPEED);
  filterwheel.setEnableActiveState(LOW);
  filterwheel.disable();
}

int DoFilterWheelAction(String ASCOMcmd)
{
  int nFilter = -1;
  
  switch((char)ASCOMcmd[0]) {
    case 'g':     //Case the function is for the FilterWheel
        SendSerialCommand(filterWheelId,filterPos); 
        break;

    case 's':  //Case the function is for the FilterWheel
        if (ASCOMcmd.substring(1,ASCOMcmd.length()-1).toInt() > nFilter) 
        {    //Only do something if the new position is different from the current position.
           nFilter = ASCOMcmd.substring(1,ASCOMcmd.length()-1).toInt();
           MoveFilter(nFilter);
        }
        break;

    case 'p':
        if ((char)ASCOMcmd[1] != '#')
          FILTER_MOTOR_ROTSTEPS = ASCOMcmd.substring(1,ASCOMcmd.length()-1).toInt();
        SendSerialCommand(filterWheelId,FILTER_MOTOR_ROTSTEPS);
        break;              

    case 'o':
        if ((char)ASCOMcmd[1] != '#')
          FILTER_MOTOR_COMPENSATION = ASCOMcmd.substring(1,ASCOMcmd.length()-1).toInt();
        SendSerialCommand(filterWheelId,FILTER_MOTOR_COMPENSATION);
        break; 
    }
}

//Move FilterWheel to the Next Position requested.
void MoveFilter(int wNextPosition) 
{
  int direction = 1;
  int steps = 0;
  // direction = getShortestPathToNextFilterPosition(wNextPosition, &steps);
  moveToNextPositionOneDirection(wNextPosition, &steps, &direction);

  if (steps != 0)
  {
    for (int i = 1; i < (abs(steps)+1); i++)
      MoveFilterWheel((direction * FILTER_MOTOR_ROTSTEPS));
  
    filterPos = wNextPosition;
    filterEEPROMSave();
  }
  SendSerialCommand(filterWheelId,filterPos); 
}

void MoveFilterWheel(int filterMove)
{
  filterwheel.enable();
  SetStepModeFilter();
  filterwheel.move(FILTER_STEPMODE * filterMove * FILTER_DIRECTION);
  filterwheel.disable();
  delay(1000);
}

// We would like to get to the new filter position as quickly as possible. This means moving the filter wheel either clockwise or counter clockwise.
// This function will determine the shortest path and return either positive rotation or negative rotation.
int getShortestPathToNextFilterPosition(int wNextPosition, int* steps)
{
    *steps = wNextPosition - filterPos;
    int tsteps = *steps;
    int direction = 1;

    if (abs(tsteps) > MaxMoveSteps)
    {
      *steps = FILTER_DEF_NRFILTERS - abs(tsteps);

      if ((wNextPosition - filterPos) > 0)
        direction = -1;
    }
    return direction;
}

// Move the filter wheel always in one direction. 
void moveToNextPositionOneDirection(int wNextPosition, int* steps, int* direction)
{
  *direction = 1;

  *steps = (wNextPosition - filterPos);

  if (*steps < 0)
    *steps = *steps + FILTER_DEF_NRFILTERS;
}

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of FilterWheel functions */
