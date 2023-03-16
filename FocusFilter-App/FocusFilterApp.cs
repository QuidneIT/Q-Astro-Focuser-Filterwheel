using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Collections;
using ASCOM.Utilities;
using System.Runtime.Remoting.Contexts;
using Microsoft.SqlServer.Server;

namespace ASCOM.QAstroFF.FocusFilterApp
{
    public partial class FocusFilterApp : Form
    {
        private ASCOM.DriverAccess.Focuser aFocuser;
        private ASCOM.DriverAccess.FilterWheel aFilter;

        private readonly string aFocuserID = "ASCOM.QAstroFF.Focuser";
        private readonly string aFilterID = "ASCOM.QAstroFF.FilterWheel";

        private static TraceLogger dataLogger;
        private static readonly string logName = "Q-Astro FocusFilter";

        private const string initFilterName = "UNDEFINED";
        private const short initFilterPos = -1;
        private const int initFocusPos = 0; 

        private string filterName = initFilterName;
        private short filterPosition = initFilterPos;
        private int focusPosition = initFocusPos;
        private bool isFocusConnected = false;
        private bool isFilterConnected = false;

        enum Status
        {
            CONNECTED,
            CONNECTING,
            DISCONNECTED,
            DISCONNECTING,
            TIMEOUT,
            AWAITINGDATA,
            SETUP,
            ERROR
        }

        private const string cConnected = "Connected - Receiving Frequent Updates...";
        private const string cConnecting = "Connecting...";
        private const string cDisconnected = "Disconnected!";
        private const string cDisconnecting = "Disconnecting";
        private const string cAwaitingData = "Connected - Awaiting Data...";
        private const string cSetup = "Setting up Dew Monitor...";
        private const string cError = "Error!!!!";
        private const string cTimeout = "Disconnected! - Connection Failure...";

        #region Focuser Actions

        private bool FocuserConnected
        {
            get {return isFocusConnected; }
            set 
            {
                StatusMessage(value ? Status.CONNECTING : Status.DISCONNECTING);

                aFocuser.Connected = value;
                if (aFocuser.Connected)
                {
                    Read_FocuserPosition();
                    isFocusConnected = true;    
                }
                else
                    isFocusConnected = false;

                StatusMessage(value ? Status.CONNECTED : Status.DISCONNECTED);
            }
        }

        private bool Read_FocuserPosition()
        {
            bool success = false;

            if (FocuserConnected)
            {
                StatusMessage(Status.AWAITINGDATA);
                try
                {
                    focusPosition = aFocuser.Position;
                    success = true;
                }
                catch
                {
                    StatusMessage(Status.ERROR);
                }
            }
            else
                focusPosition = initFocusPos;

            return success;
        }

        public void ResetFocus()
        {
            if (FocuserConnected)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to reset the focus position to 0 (this will not move the focusser!!", "Focus Position Reset", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                    aFocuser.Action("ResetFocus", "");
            }
        }

        #endregion

        #region Filter Actions

        private bool FilterConnected
        {
            get { return isFilterConnected; }
            set
            {
                StatusMessage(value ? Status.CONNECTING : Status.DISCONNECTING);

                aFilter.Connected = value;
                if (aFilter.Connected)
                {
                    Read_FilterPosition();
                    isFilterConnected = true;   
                }
                else
                    isFilterConnected = false;

                StatusMessage(value ? Status.CONNECTED : Status.DISCONNECTED);
            }
        }

        private bool Read_FilterPosition()
        {
            bool success = false;

            if (FilterConnected)
            {
                StatusMessage(Status.AWAITINGDATA);
                try
                {
                    filterPosition = aFilter.Position;
                    if (aFilter.Position > -1)
                        filterName = aFilter.Names[aFilter.Position];
                    else
                        filterName = initFilterName;

                    success = true;
                }
                catch
                {
                    StatusMessage(Status.ERROR);
                }
            }
            else
                filterPosition = initFilterPos;

            return success;
        }

        #endregion

        public FocusFilterApp()
        {
            InitializeComponent();
            InitialiseUI();
            InitialiseLog();
            ResetData();
        }

        private void InitialiseUI()
        {
            lblCaption.Text += Application.ProductVersion;
            btnFocusReset.Enabled = false;
        }

        #region Logging
        private void InitialiseLog()
        {
            DLogger.LogMessage(logName, "DateTime,FocusPosition,FilterName");
        }

        private static TraceLogger DLogger
        {
            get
            {
                if (dataLogger == null)
                {
                    dataLogger = new TraceLogger("", logName)
                    {
                        Enabled = true
                    };
                }
                return dataLogger;
            }
        }

        #endregion


        private void StatusMessage(Status eStatus)
        {
            switch (eStatus)
            {
                case Status.CONNECTED:
                    UpdateStatusText(cConnected,MetroFramework.MetroColorStyle.Lime);
                    btnConnectDisconnect.Text = "Disconnect";
                    btnSetup.Enabled = false;
                    btnFocusReset.Enabled = true;
                    break;
                case Status.CONNECTING:
                    UpdateStatusText(cConnecting,MetroFramework.MetroColorStyle.Orange);
                    break;
                case Status.AWAITINGDATA:
                    UpdateStatusText(cAwaitingData,MetroFramework.MetroColorStyle.Yellow);
                    break;
                case Status.SETUP:
                    UpdateStatusText(cSetup,MetroFramework.MetroColorStyle.Orange);
                    break;
                case Status.DISCONNECTING:
                    UpdateStatusText(cDisconnecting,MetroFramework.MetroColorStyle.Orange);
                    StatusMessage(Status.DISCONNECTED);
                    break;
                case Status.DISCONNECTED:
                    DisconnectStatus(cDisconnected);
                    break;
                case Status.ERROR:
                    DisconnectStatus(cError);
                    break;
                case Status.TIMEOUT:
                    DisconnectStatus(cTimeout);
                    break;
            }
        }

        private void UpdateStatusText(string statusMessage, MetroFramework.MetroColorStyle statusColour)
        {
            lblStatus.Text = statusMessage;
            lblStatus.Style = statusColour;
            Application.DoEvents();
        }

        private void DisconnectStatus(String statusText)
        {
            timerUI?.Stop();

            btnConnectDisconnect.Text = "Connect";
            btnSetup.Enabled = true;
            btnFocusReset.Enabled = false;
            ResetData();

            UpdateStatusText(statusText, MetroFramework.MetroColorStyle.Red);
        }

        private void ResetData()
        {
            filterName = initFilterName; 
            filterPosition = initFilterPos;
            focusPosition = initFocusPos;

            lblFocusPos.Value = focusPosition;
            lblSelectedFilterName.Text = filterName;

            ResetASCOMObject();
        }

        private void ResetASCOMObject()
        {
            isFilterConnected = false;
            isFocusConnected = false;

            aFocuser?.Dispose();
            aFilter?.Dispose();

            System.Threading.Thread.Sleep(100);

            aFocuser = new ASCOM.DriverAccess.Focuser(aFocuserID);
            aFilter = new ASCOM.DriverAccess.FilterWheel(aFilterID);

            System.Threading.Thread.Sleep(500);
        }

        private bool GetData()
        {
            bool receivedData = false;

            if (FocuserConnected && FilterConnected)        //Update time Sensor Time UI and check if Sensor Update Timeout has been exceeded
            {
                try { receivedData = (Read_FocuserPosition() && Read_FilterPosition()); }
                catch { StatusMessage(Status.ERROR); }
            }

            return receivedData;
        }

        private void UpdateUI()
        {
            timerUI.Stop();

            try
            {
                if (GetData())
                {
                    lblSelectedFilterName.Text = filterName;
                    lblFocusPos.Value = focusPosition;

                    pnlFilter.Update();
                    pnlFocus.Update();

                    String logMsg = DateTime.Now.ToString();
                    logMsg = logMsg + "," + focusPosition.ToString() + "," + filterName;
                    DLogger.LogMessage(logName, logMsg);
                    StatusMessage(Status.CONNECTED);

                    timerUI.Start();
                }
                else
                    StatusMessage(Status.DISCONNECTED);
            }
            catch
            {
                StatusMessage(Status.ERROR);
            }
        }

        #region Form Button Actions

        private void BtnSetup_Click(object sender, EventArgs e)
        {
            if (FocuserConnected && FilterConnected)
                System.Windows.Forms.MessageBox.Show("Already connected, just press Connect");
            else
                try
                {
                    StatusMessage(Status.SETUP);
                    aFocuser.SetupDialog();
                    StatusMessage(Status.DISCONNECTED);
                }
                catch
                {
                    StatusMessage(Status.ERROR);
                    System.Windows.Forms.MessageBox.Show("Error!!  Please make sure the Focuser/Filter Unit is connected via USB and try again.");
                }
        }

        private void BtnConnectDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if ((!FocuserConnected) && (!FilterConnected))
                {
                    StatusMessage(Status.CONNECTING);

                    FocuserConnected = true;
                    FilterConnected = true;

                    if (FocuserConnected && FilterConnected)
                    {
                        StatusMessage(Status.AWAITINGDATA);
                        timerUI.Start();
                    }
                }
                else
                {
                    timerUI?.Stop();

                    StatusMessage(Status.DISCONNECTING);
                    FocuserConnected = false;
                    FilterConnected = false;
                }
            }
            catch
            {
                StatusMessage(Status.ERROR);
            }
        }

        private void BtnFocusReset_Click(object sender, EventArgs e)
        {
            ResetFocus();
        }

        private void LblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LblClose_Click(object sender, EventArgs e)
        {
            if (FocuserConnected)
                FocuserConnected = false;
            if (FilterConnected)
                FilterConnected = false;

            Environment.Exit(0);
        }

        #endregion

        #region Form Actions

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void LblAbout_Click(object sender, EventArgs e)
        {
            using (About about = new About())
                about.ShowDialog();
        }

        #endregion

        #region Timer Functions

        private void TimerUI_Tick(Object source, EventArgs e)
        {
            try
            {
                if (FocuserConnected && FilterConnected)
                    UpdateUI();
            }
            catch (Exception error)
            {
                StatusMessage(Status.ERROR);
                MessageBox.Show("Focuser/Filter - Error", error.Message);
            }
        }

        #endregion
    }
}
