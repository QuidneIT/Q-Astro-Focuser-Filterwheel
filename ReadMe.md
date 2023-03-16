# Q-Astro Focuser-Filter

Q-Astro Focuser Filterwheel enables you to use a single Arduino nano to control both your Focuser & Filterwheel

Version 2.5.0 is released. For this release you need to update the Arduino code as well.

You can find details about this Focusser & Filterwheel on my website: https://www.q-astro.com/#/ascom-filterwheel-focuser
For a version history you can have a look at the VersionHistory.txt file.

The ASCOM drivers communicate with the Arduino (either focuser or filterwheel) via a serial connection over USB.

You can communicate directly with the Focuser on the Arduino on the board (e.g. using puTTY) use the following commands:
* i#	- This return what it is and its version number.
* fa#	- Returns the Max Step size.
* fAx#	- Sets the Max Step size x
* fb#	- Returns if the focuser is moving.
* fd#	- Returns if the motor is enabled or disabled after a move.
* fDx#	- Sets if the motor is enabled or disabled after a move x = 1 or 0.
* ffx#	- Move the focuser to position x. Absolute focusing.
* fmx#	- Move the focuser x number of steps. Relative focusing
* fn#	- Returns the step mode.
* fNx#	- Set the step mode (1,2,4,8,16)
* fp#	- Returns the current position.
* fr#	- Reset the focuser to 0. This is only in code, the focuser will not actually move.
* fs#	- Returns the step size.
* fSx#	- Sets the step size to x.
* fx#	- Returns max focuser position.
* fXx#	- Sets the max focuser posistion to x.

All the settings you can set will be stored in the EEPROM of the Arduino.
To reset the EEPROM to the default values you can the send the command:
* fz#

You can communicate directly with the Filterwheel on the Arduino on the board (e.g. using puTTY) use the following commands:
* i#	- This return what it is and its version number.
* wg#	- Returns the current Filterwheel position.
* wsx#	- Sets the Filterwheel to position x.
* wPx#	- Sets the step size between Filterwheel positions to x steps.



