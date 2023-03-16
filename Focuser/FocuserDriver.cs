//For version history see: QA-Server/VersionHistory.txt

// This is used to define code in the template that is specific to one class implementation
// unused code canbe deleted and this definition removed.
#define Focuser

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;

using ASCOM;
using ASCOM.Astrometry;
using ASCOM.Astrometry.AstroUtils;
using ASCOM.Utilities;
using ASCOM.DeviceInterface;
using System.Globalization;
using System.Collections;
using ASCOM.QAstroFF;

namespace ASCOM.QAstroFF.Focuser
{
    //
    // Your driver's DeviceID is ASCOM.QA.Focuser
    //
    // The Guid attribute sets the CLSID for ASCOM.QA.Focuser
    // The ClassInterface/None addribute prevents an empty interface called
    // _QA Focuser from being created and used as the [default] interface
    
    /// <summary>
    /// ASCOM Focuser Driver for QA Focuser.
    /// </summary>
    [Guid("79f69766-b7e0-4f8d-a816-d6432ac0746c")]
    [ProgId("ASCOM.QAstroFF.Focuser")]
    [ServedClassName("Q-Astro Focuser")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Focuser : ReferenceCountedObjectBase, IFocuserV2
    {
        private static string driverDescription = "ASCOM Focuser Driver for Q-Astro.";
        private string driverID = "ASCOM.QAstroFF.Focuser";

        private static string driverShortName = "Q-Astro Focuser";
        private static int interfaceVersion = 2;

        internal static int focuserCurPos;

        /// <summary>
        /// Private variable to hold the connected state
        /// </summary>
        private bool connectedState;

        private string ASCOMfunction = "f";     //Define that we communicate Filterwheel to Arduino

        /// <summary>
        /// Initializes a new instance of the <see cref="QAF"/> class.
        /// Must be public for COM registration.
        /// </summary>
        public Focuser()
        {
            SharedResources.tl.LogMessage(driverShortName, "Starting initialisation");
            driverID = Marshal.GenerateProgIdForType(this.GetType());
            connectedState = false; // Initialise connected to false
            SharedResources.tl.LogMessage(driverShortName, "Completed initialisation");

            focuserCurPos = 0;
        }

        //
        // PUBLIC COM INTERFACE IFocuserV2 IMPLEMENTATION
        //

        #region Common properties and methods.

        /// <summary>
        /// Displays the Setup Dialog form.
        /// If the user clicks the OK button to dismiss the form, then
        /// the new settings are saved, otherwise the old values are reloaded.
        /// THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
        /// </summary>
        public void SetupDialog()
        {
            // consider only showing the setup dialog if not connected
            // or call a different dialog if connected
            if (SharedResources.SharedSerial.Connected)
                System.Windows.Forms.MessageBox.Show("Already connected, just press OK");
            else
            {
                using (ServerSetupDialog setupSerial = new ServerSetupDialog())
                    setupSerial.ShowDialog();
            }
        }

        public ArrayList SupportedActions
        {
            get
            {
                var CustomActions = new ArrayList();
                CustomActions.Add("ResetFocus");
                CustomActions.Add("SetStepMode");
                CustomActions.Add("GetStepMode");
                CustomActions.Add("SetStepSize");
                CustomActions.Add("GetMotorEnable");
                CustomActions.Add("SetMotorEnable");
                CustomActions.Add("DisableMotor");
                CustomActions.Add("SetMaxStep");

                string msgForLog = "";
                foreach (String act in CustomActions)
                    msgForLog = msgForLog + act + ",";

                SharedResources.tl.LogMessage(driverShortName + " SupportedActions Get", msgForLog);
                return CustomActions;
            }
        }

        public string Action(string actionName, string actionParameters)
        {
            String returnVal = "";
            String action = "";

            SharedResources.tl.LogMessage(driverShortName + "Action", actionName + "-" + actionParameters);

            CheckConnected("Action");

            switch (actionName)
            {
                case "SetMaxStep":
                    action = "A";
                    break;
                case "GetMotorEnable":
                    action = "d";
                    actionParameters = "";
                    break;
                case "SetMotorEnable":
                    action = "D";
                    break;
                case "ResetFocus":
                    action = "r";
                    actionParameters = "";
                    break;
                case "GetStepMode":
                    action = "n";
                    actionParameters = "";
                    break;
                case "SetStepMode":
                    action = "N";
                    break;
                case "SetStepSize":
                    action = "S";
                    break;
                case "GetMaxPosition":
                    action = "x";
                    actionParameters = "";
                    break;
                case "SetMaxPosition":
                    action = "X";
                    break;
                case "DisableMotor":
                    action = "y";
                    break;
                default:
                    throw new ASCOM.ActionNotImplementedException(driverShortName + " Action " + actionName + " is not implemented by this driver");
            }

            returnVal = SharedResources.SendMessage(ASCOMfunction, action + actionParameters);

            return returnVal;
        }


        public void CommandBlind(string command, bool raw)
        {
            CheckConnected("CommandBlind");
            this.CommandString(command, raw);
        }

        public bool CommandBool(string command, bool raw)
        {
            CheckConnected("CommandBool");
            return !this.CommandString(command, raw).Equals("0");
        }

        public string CommandString(string command, bool raw)
        {
            CheckConnected("CommandString");
            return SharedResources.rawCommand(ASCOMfunction, command, raw);
        }
        
        public void Dispose()
        {
        }

        public bool Connected
        {
            get { return IsConnected; }
            set
            {
                {
                    SharedResources.tl.LogMessage(driverShortName + " Connected Set", value.ToString());

                    if (value == IsConnected)
                        return;

                    if (value)
                    {
                        if (IsConnected) return;

                        SharedResources.tl.LogMessage(driverShortName + "Connected Set", "Connecting to port " + QAstroFF.Properties.Settings.Default.COMPort);
                        SharedResources.Connected = true;
                        connectedState = SharedResources.Connected;

                        if (IsConnected)
                        {
                            if (Properties.Settings.Default.ConfigChanged)
                            {
                                Action("SetMaxStep", Properties.Settings.Default.FocuserMaxStep.ToString());
                                Action("SetStepSize", Properties.Settings.Default.FocuserStepSize.ToString());
                                Action("SetMotorEnable", Properties.Settings.Default.FocuserMotorEnabled.ToString());
                                Action("SetMaxPosition", Properties.Settings.Default.FocuserMaxPos.ToString());
                                Action("SetStepMode", Properties.Settings.Default.FocuserStepMode.ToString());

                                Properties.Settings.Default.ConfigChanged = false;
                                Properties.Settings.Default.Save();
                            }

                            Properties.Settings.Default.FocuserMaxStep = MaxIncrement;
                            Properties.Settings.Default.FocuserStepSize = StepSize;
                            Properties.Settings.Default.FocuserMotorEnabled = Convert.ToInt16(Action("GetMotorEnable", ""));
                            Properties.Settings.Default.FocuserMaxPos = Convert.ToInt32(Action("GetMaxPosition", ""));
                            Properties.Settings.Default.FocuserStepMode = Convert.ToInt32(Action("GetStepMode", ""));

                            Properties.Settings.Default.Save();

                            focuserCurPos = Position;
                        }
                    }
                    else
                    {
                        Action("DisableMotor","");
                        connectedState = false;
                        SharedResources.Connected = false;
                        SharedResources.tl.LogMessage(driverShortName + " Switch Connected Set", "Disconnected, " + SharedResources.connections + " connections left");
                    }
                }
            }
        }

        public string Description
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " Description Get", driverDescription);
                return driverDescription;
            }
        }

        public string DriverInfo
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string driverInfo = "Information about the driver itself. Version: " + String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
                SharedResources.tl.LogMessage(driverShortName + " DriverInfo Get", driverInfo);
                return driverInfo;
            }
        }

        public string DriverVersion
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string driverVersion = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
                SharedResources.tl.LogMessage(driverShortName + " DriverVersion Get", driverVersion);
                return driverVersion;
            }
        }

        public short InterfaceVersion
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " InterfaceVersion Get", interfaceVersion.ToString());
                return Convert.ToInt16(interfaceVersion);
            }
        }

        public string Name
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " Name Get", driverShortName);
                return driverShortName;
            }
        }

        #endregion

        #region IFocuser Implementation

        public bool Absolute
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " Absolute Get", true.ToString());
                return true;
            } // This is an absolute focuser
        }

        public void Halt()
        {
            SharedResources.tl.LogMessage(driverShortName + " Halt", "Not Implemented");
            throw new ASCOM.MethodNotImplementedException("Halt");
        }

        public bool IsMoving
        {
            get
            {
                string recIsMoving = SharedResources.SendMessage(ASCOMfunction, "b");

                bool isMoving = false;
                if (recIsMoving == "1")
                    isMoving = true;

                SharedResources.tl.LogMessage(driverShortName + " IsMoving Get", isMoving.ToString());

                return isMoving;  // This focuser always moves instantaneously so no need for IsMoving ever to be True
            }
        }

        public bool Link
        {
            get { return this.Connected; } // Direct function to the connected method, the Link method is just here for backwards compatibility
            set { this.Connected = value;}
        }

        public int MaxIncrement
        {
            get
            {
                string recMaxStep = SharedResources.SendMessage(ASCOMfunction,"a");
                int focuserMaxStep = Convert.ToInt32(recMaxStep);

                SharedResources.tl.LogMessage(driverShortName + " MaxIncrement Get", focuserMaxStep.ToString());
                return Convert.ToInt32(focuserMaxStep); // Maximum change in one move
            }
        }

        public int MaxStep
        {
            get
            {
                string recMaxPosition = SharedResources.SendMessage(ASCOMfunction,"x");
                int focuserMaxPos = Convert.ToInt32(recMaxPosition);

                SharedResources.tl.LogMessage(driverShortName + " MaxStep Get", focuserMaxPos.ToString());
                return Convert.ToInt32(focuserMaxPos); // Maximum extent of the focuser, so position range is 0 to 10,000
            }
        }

        public void Move(int nextPosition)         //Move to Next Position as this is an absolute Focuser.
        {
            if (IsMoving) return;

            if ((nextPosition != focuserCurPos) && (nextPosition > 0) && (nextPosition < (Properties.Settings.Default.FocuserMaxPos + 1)))
            {
                SharedResources.tl.LogMessage(driverShortName + " Next Position", nextPosition.ToString());
                int recPosition = Convert.ToInt32(SharedResources.SendMessage(ASCOMfunction, "f" + nextPosition));

                if (recPosition < 0)
                {
                    SharedResources.tl.LogMessage(driverShortName + " Next Position Error received from Controller", "Next Position: " + nextPosition.ToString() + " CurPos: " + focuserCurPos.ToString());
                    throw new ASCOM.InvalidValueException(driverShortName + " Next Position Error Received from Controller");
                }
                else
                {
                    focuserCurPos = recPosition;
                    SharedResources.tl.LogMessage(driverShortName + " New Current Position", focuserCurPos.ToString());
                }
            }
        }

        public int Position
        {
            get
            {
                CheckConnected("Get Position");

                string recPosition = SharedResources.SendMessage(ASCOMfunction,"p");
                if (recPosition == "")
                    recPosition = "0";
                SharedResources.tl.LogMessage(driverShortName + " Position", recPosition);
                return Convert.ToInt32(recPosition);
            }
        }

        public double StepSize
        {
            get
            {
                string recStepSize = SharedResources.SendMessage(ASCOMfunction, "s");
                double focuserStepSize = Convert.ToDouble(recStepSize);

                SharedResources.tl.LogMessage(driverShortName + " StepSize Get", focuserStepSize.ToString());
                return Convert.ToInt32(focuserStepSize); // Step Size in microns
            }
        }

        public bool TempComp
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " TempComp Get", false.ToString());
                return false;
            }
            set { throw new ASCOM.PropertyNotImplementedException(driverShortName + " TempComp", false);}
        }

        public bool TempCompAvailable
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " TempCompAvailable Get", false.ToString());
                return false; // Temperature compensation is not available in this driver
            }
        }

        public double Temperature
        {
            get
            {
                SharedResources.tl.LogMessage(driverShortName + " Temperature Get", false.ToString());
                throw new ASCOM.PropertyNotImplementedException(driverShortName + " Temperature", false);
            }
        }

        #endregion

        #region Private properties and methods
        // here are some useful properties and methods that can be used as required
        // to help with driver development

        /// <summary>
        /// Returns true if there is a valid connection to the driver hardware
        /// </summary>
        private bool IsConnected
        {
            get {
                if (connectedState)
                    return SharedResources.IsConnected();
                else
                    return connectedState; 
            }
        }

        /// <summary>
        /// Use this function to throw an exception if we aren't connected to the hardware
        /// </summary>
        /// <param name="message"></param>
        private void CheckConnected(string message)
        {
            if (!IsConnected)
                throw new ASCOM.NotConnectedException(message);
        }

        #endregion
    }
}
