/* ---------------------------------------------------------------------------------------------------------------------------- */
/* Start of filter EEPROM Commands */

struct w_config {
  int filterPos;
  byte Saved;
} filterConfig;

void filterEEPROMLoad() {
  EEPROM_readAnything(FILTER_MEMORY, filterConfig);
  if (filterConfig.Saved != 111)
  {
    filterPos = FILTER_DEF_STARTPOSITION;
    return;
  }
  filterPos = filterConfig.filterPos;
 }

void filterEEPROMSave() {
  filterConfig.filterPos = filterPos;
  filterConfig.Saved = 111;
  EEPROM_writeAnything(FILTER_MEMORY, filterConfig);
}

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of filter EEPROM Commands */
