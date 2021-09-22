/* ---------------------------------------------------------------------------------------------------------------------------- */
/* Start of EEPROM Commands */


//This function will write a 2 byte integer to the eeprom at the specified address and address + 1
void EEPROMWriteInt(int p_address, long p_value)
{
//  byte lowByte = ((p_value >> 0) & 0xFF);
//  byte highByte = ((p_value >> 8) & 0xFF);
  byte four = (p_value & 0xFF);
  byte three = ((p_value >> 8) & 0xFF);
  byte two = ((p_value >> 16) & 0xFF);
  byte one = ((p_value >> 24) & 0xFF);

  EEPROM.write(p_address, four);
  EEPROM.write(p_address + 1, three);
  EEPROM.write(p_address + 2, two);
  EEPROM.write(p_address + 3, one);
}

//This function will read a 2 byte integer from the eeprom at the specified address and address + 1
unsigned long EEPROMReadInt(long p_address)
{
  long four = EEPROM.read(p_address);
  long three = EEPROM.read(p_address + 1);
  long two = EEPROM.read(p_address + 2);
  long one = EEPROM.read(p_address + 3);
  
  return ((four << 0) & 0xFF) + ((three << 8) & 0xFFFF) + ((two << 16) & 0xFFFFFF) + ((one << 24) & 0xFFFFFFFF);
}

/* ---------------------------------------------------------------------------------------------------------------------------- */
/* End of EEPROM Commands */
