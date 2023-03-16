/*
 * Q-Astro FocusFilter
 *
 * This file may be redistributed under the terms of the MIT license.
 * A copy of this license has been included with this distribution in the file LICENSE.
 * 
 * Q-Astro FocusFilter Code for Focuser & FilterWheel.
 * Version: 2.5.0
 * 
 * Copyright (c)2023 Quidne IT Ltd.
 * 
 */

#include <Arduino.h>

#include <EEPROM.h>
#include "qEEPROM.h"

#include <DRV8825.h>
#include <math.h>

#define DEVICE_RESPONSE "Q-Astro FocusFilter"
#define VERSION "v2.5.0"

#define filterWheelId 'w'
#define focuserId 'f'

String ASCOMcmd;
bool ASCOMcmdComplete;

void setup() 
{
  InitSerial();
  InitFilterWheel();
  InitFocuser();

  Serial.println("Ready..");
}

void loop() {

  if (ASCOMcmdComplete) {

    switch((char)ASCOMcmd[0]) {
      case 'i':
        SendSerialCommand(String(DEVICE_RESPONSE) + " " + String(VERSION));
        break;

      case focuserId:  //Case the function is for the Focuser
        DoFocuserAction(ASCOMcmd.substring(1)); //Remove first char from string as this is the function type.
        break;
      
      case filterWheelId:     //Case the function is for the FilterWheel
        DoFilterWheelAction(ASCOMcmd.substring(1)); //Remove first char from string as this is the function type.
        break;
    }
    
    ASCOMcmdComplete = false;
    ASCOMcmd = "";
  }
}
