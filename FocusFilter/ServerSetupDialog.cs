using ASCOM.DeviceInterface;
using ASCOM.DriverAccess;
using ASCOM.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ASCOM.QAstroFF
{ 
    public partial class ServerSetupDialog : Form
    {
        internal List<COMPortInfo> comPorts;
        internal COMPortInfo comPort;

        public ServerSetupDialog()
        {
            InitializeComponent();
            InitUI();
        }      

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            Close();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            int i = 0;

            foreach (DataGridViewRow row in filterDataGrid.Rows)
            {
                Properties.Settings.Default.FilterNames[i] = row.Cells["FilterName"].Value.ToString();
                Properties.Settings.Default.FocuserOffsets[i] = row.Cells["FilterOffset"].Value.ToString();
                i++;
            }

            Properties.Settings.Default.Save();
        }

        private void SettingsChanged()
        {
            SettingsChanged(true);
        }

        private void SettingsChanged(bool changed)
        {
            Properties.Settings.Default.ConfigChanged = changed;
        }

        private void InitUI()
        {
            this.Text = this.Text + " - " + Application.ProductVersion;
            comPort = new COMPortInfo();
            comPorts = new List<COMPortInfo>();

            comPorts = COMPortInfo.GetCOMPortsInfo();
            
            // set the list of com ports to those that are currently available
            ComPortComboBox.Items.Clear();

            foreach (COMPortInfo cport in comPorts)
                ComPortComboBox.Items.Add(cport.Name);

            // select the current port if possible
            if (comPort != null)
            {
                if (ComPortComboBox.Items.Contains(Properties.Settings.Default.COMPort))
                    ComPortComboBox.SelectedItem = Properties.Settings.Default.COMPort;
            }

            switch(Properties.Settings.Default.FocuserStepMode)
            {
                case 1:
                    StepResolutionCombo.SelectedItem = "1";
                    break;
                case 2:
                    StepResolutionCombo.SelectedItem = "1/2";
                    break;
                case 4:
                    StepResolutionCombo.SelectedItem = "1/4";
                    break;
                case 8:
                    StepResolutionCombo.SelectedItem = "1/8";
                    break;
                case 16:
                    StepResolutionCombo.SelectedItem = "1/16";
                    break;
            }

            txtMaxPosition.Text = Properties.Settings.Default.FocuserMaxPos.ToString();
            txtMaxStep.Text = Properties.Settings.Default.FocuserMaxStep.ToString();
            txtStepSize.Text = Properties.Settings.Default.FocuserStepSize.ToString();

            if (Properties.Settings.Default.FocuserMotorEnabled == 1)
                chkMotorEnabled.Checked = true;
            else
                chkMotorEnabled.Checked = false;

            for (int i=0; i < Properties.Settings.Default.FilterSlots; i++)
            {
                string filterName = Properties.Settings.Default.FilterNames[i];
                string filterOffset = Properties.Settings.Default.FocuserOffsets[i];
                filterDataGrid.Rows.Add((i+1), filterName, filterOffset);
            }
            SettingsChanged(false);

            setupTabControl.SelectedTab = tabComPort;
        }

        private void ComPortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.COMPort = ComPortComboBox.GetItemText(this.ComPortComboBox.SelectedItem);
        }

        private void StepResolutionCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            String stepRes = StepResolutionCombo.GetItemText(this.StepResolutionCombo.SelectedItem);
            int res = 1;

            switch(stepRes)
            {
                case "1":
                    res = 1;
                    break;
                case "1/2":
                    res = 2;
                    break;
                case "1/4":
                    res = 4;
                    break;
                case "1/8":
                    res = 8;
                    break;
                case "1/16":
                    res = 16;
                    break;                
            }

            Properties.Settings.Default.FocuserStepMode = res;
            SettingsChanged();

        }

        private void TxtStepSize_TextChanged(object sender, EventArgs e)
        {
            bool canConvert = long.TryParse(txtStepSize.Text, out long stepSize);
            if (!canConvert)
            {
                stepSize = 10;
                txtStepSize.Text = stepSize.ToString();
            }
            Properties.Settings.Default.FocuserStepSize = stepSize;
            SettingsChanged();
        }

        private void TxtMaxStep_TextChanged(object sender, EventArgs e)
        {
            bool canConvert = int.TryParse(txtStepSize.Text, out int maxStep);
            if (!canConvert)
            {
                maxStep = 5000;
                txtMaxStep.Text = maxStep.ToString();
            }
            Properties.Settings.Default.FocuserMaxStep = maxStep;
            SettingsChanged();
        }

        private void TxtMaxPosition_TextChanged(object sender, EventArgs e)
        {
            bool canConvert = int.TryParse(txtStepSize.Text, out int maxPos);

            if(!canConvert)
            {
                maxPos = 99999;
                txtMaxPosition.Text = maxPos.ToString();
            }
            Properties.Settings.Default.FocuserMaxPos = maxPos;
            SettingsChanged();
        }

        private void ChkMotorEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMotorEnabled.Checked)
                Properties.Settings.Default.FocuserMotorEnabled = 1;
            else
                Properties.Settings.Default.FocuserMotorEnabled = 0;

            SettingsChanged();
        }

        private void BtnFocuserInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you use TMC2208 Drivers, you can not select Step Mode 1!!!", "BE AWARE!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
