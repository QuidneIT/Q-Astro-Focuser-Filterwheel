// This is used to define code in the template that is specific to one class implementation
// unused code canbe deleted and this definition removed.
#define FilterWheel

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
using System.Threading;
using System.IO;
using System.Configuration;
using ASCOM.QAstroFF;
using System.Security.Cryptography;

namespace ASCOM.QAstroFF.Filterwheel
{
    /// <summary>
    /// ASCOM FilterWheel Driver for QAFW.
    /// </summary>
    /// 
    [Guid("3d123d47-8771-4287-9ea4-d74b4636017a")]
    [ProgId("ASCOM.QAstroFF.FilterWheel")]
    [ServedClassName("Q-Astro FilterWheel")]
    [ClassInterface(ClassInterfaceType.None)]
    public class FilterWheel : ReferenceCountedObjectBase, IFilterWheelV2
    {
        private string driverDescription = "ASCOM FilterWheel Driver for Q-Astro.";
        private string driverID = "ASCOM.QAstroFF.FilterWheel";

        private static string driverShortName = "Q-Astro FilterWheel";
        private static int interfaceVersion = 2;

        private int iWaitAfterSet = 3000;

        private short wPosition = 0; // class level variable to retain the current filterwheel position
        private string ASCOMfunction = "w";     //Define that we communicate Filterwheel to Arduino

        /// <summary>
        /// Private variable to hold the connected state
        /// </summary>
        private bool connectedState;


        /// <summary>
        /// Initializes a new instance of the <see cref="QA"/> class.
        /// Must be public for COM registration.
        /// </summary>
        public FilterWheel()
        {
            SharedResources.tl.LogMessage(driverShortName, "Starting initialisation");
            driverID = Marshal.GenerateProgIdForType(this.GetType());
            connectedState = false; // Initialise connected to false
            SharedResources.tl.LogMessage(driverShortName, "Completed initialisation");
        }

        //
        // PUBLIC COM INTERFACE IFilterWheelV2 IMPLEMENTATION
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
            get { return new ArrayList();}
        }

        public string Action(string actionName, string actionParameters)
        {
            throw new ASCOM.ActionNotImplementedException(driverShortName + " Action " + actionName + " is not implemented by this driver");
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

                        SharedResources.tl.LogMessage(driverShortName + "Connected Set", "Connecting to port " + SharedResources.SharedSerial.PortName);

                        SharedResources.Connected = true;
                        connectedState = SharedResources.Connected;

                        if (IsConnected)
                            Properties.Settings.Default.FilterPosition = Position;
                    }
                    else
                    {
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

        #region IFilerWheel Implementation

        public int[] FocusOffsets
        {
            get {
                string[] filtOffSets = new string[Properties.Settings.Default.FilterSlots];
                int[] offsets = new int[Properties.Settings.Default.FilterSlots];

                Properties.Settings.Default.FocuserOffsets.CopyTo(filtOffSets, 0);
                for (int i = 0; i < Properties.Settings.Default.FilterSlots; i++)
                    offsets[i] = Convert.ToInt32(filtOffSets[i]);

                return offsets; }
        }

        public string[] Names
        {
            get { 
                string[] filtNames = new string[Properties.Settings.Default.FilterSlots];
                Properties.Settings.Default.FilterNames.CopyTo(filtNames,0);

                return filtNames;
            }
        }

        public short Position
        {
            get
            {
                CheckConnected("Get Position");
                
                string strReceive = SharedResources.SendMessage(ASCOMfunction,"g");
                if (strReceive.Length > 0)
                {
                    wPosition = Convert.ToInt16(strReceive);
                    SharedResources.tl.LogMessage(driverShortName + " Position", strReceive);
                    Properties.Settings.Default.FilterPosition = wPosition;
                    Properties.Settings.Default.Save();
                    return wPosition;
                }
                else
                    return wPosition;
            }
            set
            {
                CheckConnected("Set Position");
                
                if ((value < 0) | (value > Properties.Settings.Default.FilterSlots - 1))
                {
                    throw new InvalidValueException("Position", value.ToString(), "0 to " + (Properties.Settings.Default.FilterSlots - 1).ToString());
                }
                wPosition = value;
                string strReceive = SharedResources.SendMessage(ASCOMfunction,"s" + wPosition.ToString());
                Thread.Sleep(iWaitAfterSet);
                Properties.Settings.Default.FilterPosition = wPosition;
                Properties.Settings.Default.Save();
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
            get
            {
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
