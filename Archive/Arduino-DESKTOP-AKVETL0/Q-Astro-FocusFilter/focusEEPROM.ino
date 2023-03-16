/* ---------------------------------------------------------------------------------------------------------------------------- */
/* Start of focuser EEPROM Commands */

struct f_config {
  long focusPos;
  long stepSize;
  int stepMode;
  int maxStep;
  long maxPos;
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
    return;
  }
  focusPos = focusConfig.focusPos;
  stepSize = focusConfig.stepSize;
  stepMode = focusConfig.stepMode;
  maxPosition = focusConfig.maxPos;
  maxStep = focusConfig.maxStep;   
}

void focusEEPROMSave() {
  focusConfig.focusPos = focusPos;
  focusConfig.stepSize = stepSize;
  focusConfig.stepMode = stepMode;
  focusConfig.maxPos = maxPosition;
  focusConfig.maxStep = maxStep;
  focusConfig.Saved = 111;
  EEPROM_writeAnything(FOCUS_MEMORY, focusConfig);
}

void focusEEPROMReset()
{
  focusPos = FOCUS_DEF_STARTPOSITION;
  stepSize = FOCUS_DEF_STEPSIZE;
  stepMode = FOCUS_DEF_STEPMODE;
  maxStep = FOCUS_DEF_MAXSTEP;
  maxPosition = FOCUS_DEF_MAXPOSITION;
  focusEEPROMSave();
  focusEEPROMLoad();
}


/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of focus EEPROM Commands */