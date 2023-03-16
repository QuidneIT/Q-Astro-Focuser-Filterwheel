using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ASCOM.DeviceInterface;
using ASCOM.DriverAccess;
using ASCOM.Utilities;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace ASCOM.QAstroFF
{
    class DataManager
    {
        #region Q-Astro System Variables

        private ASCOM.DriverAccess.Focuser aFocuser;
        private ASCOM.DriverAccess.FilterWheel aFilter;

        private String aFocuserID = "ASCOM.QAstroFF.Focuser";
        private String aFilterID = "ASCOM.QAstroFF.FilterWheel";

        private String sLogFile = string.Format("Astro-Q-{0:yyyy-MM-dd_hh-mm-ss-tt}.log", DateTime.Now);
        private String sLogFileLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private int iLogInterval = 30; //30seconds
        private int iIntervalCounter = 0;

        private static System.Timers.Timer timerAstro;
        private int iTimerInterval = 2000;

        #endregion

        #region Private Displayable Items

        private bool bPrivateQAConnect = false;

        private double dFilterNumber = 0;
        private string sFilterName = "";

        private double dFocusPosition = 0;
        private double dMaxFocusPosition = 6000;

        #endregion

        #region Public Display Items

        public double FilterNumber
        { get { return dFilterNumber; } }

        public string FilterName
        { get { return sFilterName; } }

        public double FocusPosition
        { get { return dFocusPosition; } }

        public double MaxFocusPosition
        { get { return dMaxFocusPosition; } }

        public bool QAConnected
        { get { return bQAConnected; } }

        #endregion

        public DataManager()
        {
            InitialiseTimer();
            aFocuser = new ASCOM.DriverAccess.Focuser(aFocuserID);
            aFilter = new ASCOM.DriverAccess.FilterWheel(aFilterID);
            bQAConnected = false;
        }

        #region Initialise Q-Astro Values

        private void InitialiseTimer()
        {
            timerAstro = new System.Timers.Timer(iTimerInterval);
            timerAstro.Elapsed += timerAstro_Tick;
            timerAstro.AutoReset = true;
            timerAstro.Enabled = true;
        }

        private void InitialiseFilter()
        {
            try
            {
                aFilter.Connected = true;
                if (aFilter.Connected)
                    Read_FilterPosition();
            }
            catch (Exception ex)
            {
                aFilter.Connected = false;
            }
        }

        private void InitialiseFocuser()
        {
            try
            {
                aFocuser.Connected = true;
                if (aFocuser.Connected)
                {
                    dMaxFocusPosition = aFocuser.MaxStep;
                    Read_FilterPosition();
                }
            }
            catch(Exception ex)
            {
                aFocuser.Connected = false;
                dMaxFocusPosition = 0;
            }
        }

        private void InitialiseLogging()
        {
            if (!Directory.Exists(sLogFileLocation))
                Directory.CreateDirectory(sLogFileLocation);
        }

        #endregion

        #region Read Q-Astro Data

        private void Read_FocuserPosition()
        {
            if (aFocuser.Connected)
            {
                try
                {
                    dFocusPosition = aFocuser.Position;
                }
                catch (Exception error)
                {
                    bQAConnected = false;
                    QAShowErrorMsg(error);
                }
            }
            else
                dFocusPosition = 0;
        }

        private void Read_FilterPosition()
        {
            if (aFilter.Connected)
            {
                try
                {
                    if (aFilter.Position > -1)
                    {
                        dFilterNumber = aFilter.Position;
                        sFilterName = aFilter.Names[aFilter.Position];
                    }
                    else
                    {
                        dFilterNumber = 0;
                        sFilterName = "Undefined";
                    }
                }
                catch (Exception error)
                {
                    bQAConnected = false;
                    QAShowErrorMsg(error);
                }
            }
        }

        #endregion

        #region Public Setup Connections to Q-Astro & Mount

        public void QAstro_Setup()
        {
            try
            {
                if (aFocuser.Connected)
                    System.Windows.Forms.MessageBox.Show("Already connected, just press OK");
                else
                    aFocuser.SetupDialog();
            }
            catch (Exception error)
            {
                QAShowErrorMsg(error);
            }
        }

        public string QAstro_Connect()
        {
            string Text = "Connect";

            bQAConnected = !bQAConnected;

            if (bQAConnected)
                Text = "Disconnect";

            return Text;
        }

        #endregion

        #region Focus Reset
 
        public void ResetFocus()
        {
            if (bQAConnected)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to reset the focus position to 0 (this will not move the focusser!!", "Focus Position Reset", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    string strReceive = aFocuser.CommandString("r", true);

                    if (strReceive.Substring(0, 1) == "f")
                    {
                        int iPos = strReceive.IndexOf('#');
                        strReceive = strReceive.Substring(1, iPos - 1); //Start at 1 as 0 contains the Function which will be w.
                    }
                }
            }
        }

        #endregion

        #region Q-Astro Connect Functions

        private bool bQAConnected
        {
            get { return bPrivateQAConnect; }
            set
            {
                try
                {
                    if (value)
                    {
                        InitialiseFilter();

                        if (aFilter.Connected)
                            InitialiseFocuser();

                        if (!timerAstro.Enabled && aFilter.Connected && aFocuser.Connected)
                        {
                            timerAstro.Start();
                            bPrivateQAConnect = value;
                        }
                    }
                    else
                    {
                        bPrivateQAConnect = value;
                        aFocuser.Connected = value;
                        aFilter.Connected = value;
                    }
                }
                catch (Exception error)
                {
                    aFocuser.Connected = false;
                    aFilter.Connected = false;
                    bPrivateQAConnect = false;
                }
            }
        }

        #endregion

        #region Timer Functions

        private void timerAstro_Tick(Object source, ElapsedEventArgs e)
        {
            if (bQAConnected)
            {
                try
                {
                    if (aFocuser.Connected)
                        Read_FocuserPosition();

                    if (aFilter.Connected)
                        Read_FilterPosition();
                }
                catch (Exception error)
                {
                    bQAConnected = false;
                    QAShowErrorMsg(error);
                }
            }

            if (iIntervalCounter == iLogInterval)
            {
                LogStats();
                iIntervalCounter = 0;
            }
            else
                iIntervalCounter++;
        }

        #endregion

        #region Data Logging

        private void LogStats()
        {
            bool bLogData = true;
            String sLogData = DateTime.Now.ToString();

            if (bLogData)
            {
                try
                {
                    if (aFocuser.Connected)
                        sLogData = sLogData + " - " + dFocusPosition.ToString();

                    if (aFilter.Connected)
                        sLogData = sLogData + " - " + sFilterName;
                }
                catch (Exception error)
                {
                    QAShowErrorMsg(error);
                }
                     
                File.AppendAllLines(sLogFileLocation + "\\" + sLogFile, new string[] { sLogData });
            }
        }

        #endregion

        #region Error Handling

        private void QAShowErrorMsg(Exception error)
        {
            bQAConnected = false;

            MessageBox.Show(error.ToString(), "Q-Astro Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
