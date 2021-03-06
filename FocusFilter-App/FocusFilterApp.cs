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

namespace ASCOM.QAstroFF.FocusFilterApp
{
    public partial class FocusFilterApp : Form
    {
        private DataManager QAData = new DataManager();

        public FocusFilterApp()
        {
            InitializeComponent();
            InitialiseUI();
            UpdateUI();
            timerUI.Start();
        }

        private void TimerUI_Tick(Object source, EventArgs e)
        {
            UpdateUI();
        }

        private void InitialiseUI()
        {
            lblCaption.Text += Application.ProductVersion;
            btnFocusReset.Enabled = false;
        }

        private void UpdateUI()
        {

            if (QAData.QAConnected)
            {
                lblSelectedFilterName.Text = QAData.FilterName;
                lblFocusPos.Value = QAData.FocusPosition;
            }

            lblQAStatus.Text = (QAData.QAConnected) ? "Connected" : "Disconnected";
            lblQAStatus.Style = (QAData.QAConnected) ? MetroFramework.MetroColorStyle.Lime : MetroFramework.MetroColorStyle.Red;
        }

        private void btnQASetup_Click(object sender, EventArgs e)
        {
            QAData.QAstro_Setup();
        }
        
        private void btnQAConnect_Click(object sender, EventArgs e)
        {
            btnQAConnect.Text = QAData.QAstro_Connect();
            btnFocusReset.Enabled = QAData.QAConnected;
        }

        private void btnFocusReset_Click(object sender, EventArgs e)
        {
            QAData.ResetFocus();
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

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

        private void lblAbout_Click(object sender, EventArgs e)
        {
            using (About about = new About())
                about.ShowDialog();
        }
    }
}
