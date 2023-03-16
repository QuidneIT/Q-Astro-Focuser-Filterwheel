/* ---------------------------------------------------------------------------------------------------------------------------- */
/* Start of focuser EEPROM Commands */

struct f_config {
  long focusPos;
  long stepSize;
  int stepMode;
  int maxStep;
  long maxPos;
  int motorenable;
  byte Saved;
} focusConfig;

void focusEEPROMLoad() {
  EEPROM_readAnything(FOCUS_MEMORY, focusConfig);
  if (focusConfig.Saved != 111)
  {
    focusPos = FOCUS_DEF_STARTPOSITION;
    stepSize = FOCUS_DEF_STEPSIZE;
    stepMode = FOCUS_DEF_STEPMODE;
    maxStep = FOCUS_DEF_MAXSTEP;
    maxPosition = FOCUS_DEF_MAXPOSITION;
    motorenable = FOCUS_DEF_MOTORENABLE;
    return;
  }
  focusPos = focusConfig.focusPos;
  stepSize = focusConfig.stepSize;
  stepMode = focusConfig.stepMode;
  maxPosition = focusConfig.maxPos;
  maxStep = focusConfig.maxStep;
  motorenable = focusConfig.motorenable;   
}

void focusEEPROMSave() {
  focusConfig.focusPos = focusPos;
  focusConfig.stepSize = stepSize;
  focusConfig.stepMode = stepMode;
  focusConfig.maxPos = maxPosition;
  focusConfig.maxStep = maxStep;
  focusConfig.motorenable = motorenable;
  focusConfig.Saved = 111;
  EEPROM_writeAnything(FOCUS_MEMORY, focusConfig);
}

void UpdateFocuserEEPROMData()
{
  focusEEPROMSave();
  focusEEPROMLoad();
}


void focusEEPROMReset()
{
  focusPos = FOCUS_DEF_STARTPOSITION;
  stepSize = FOCUS_DEF_STEPSIZE;
  stepMode = FOCUS_DEF_STEPMODE;
  maxStep = FOCUS_DEF_MAXSTEP;
  maxPosition = FOCUS_DEF_MAXPOSITION;
  motorenable = FOCUS_DEF_MOTORENABLE;
  UpdateFocuserEEPROMData();
}


/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of focus EEPROM Commands */