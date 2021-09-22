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
        internal ASCOM.Utilities.Serial serPort;

        public ServerSetupDialog()
        {
            InitializeComponent();
            InitUI();
        }      

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int i = 0;

            foreach (DataGridViewRow row in filterDataGrid.Rows)
            {
                Properties.Settings.Default.FilterNames[i] = row.Cells["FilterName"].Value.ToString();
                Properties.Settings.Default.FocusOffsets[i] = row.Cells["FilterOffset"].Value.ToString();
                i++;
            }

            Properties.Settings.Default.Save();
        }

        private void btnTestPrt_Click(object sender, EventArgs e)
        {
            try
            {
                serPort = new Serial();
                serPort.PortName = Properties.Settings.Default.COMPort;
                serPort.ReceiveTimeoutMs = 2000;
                serPort.Speed = ASCOM.Utilities.SerialSpeed.ps9600;

                StatusLabel.Text = "Opening port " + serPort.PortName + " ...";
                serPort.Connected = true;
                toolQASetupStatus.Text = "Port " + serPort.PortName + " opened";
                System.Threading.Thread.Sleep(1000);
                toolQASetupStatus.Text = "Detecting Q-Astro Controller at port " + serPort.PortName + " ... ";
                Refresh();
                System.Threading.Thread.Sleep(2000);
                serPort.ClearBuffers();
                serPort.Transmit("i#");
                string answer = serPort.ReceiveTerminated("#");

//                if ((answer != null) && answer.Contains("Q-Astro Arduino"))
                if ((answer != null) && (answer.Length>0))
                    toolQASetupStatus.Text = "Q-Astro Controller detected";
                else
                { 
                    toolQASetupStatus.Text = "Q-Astro Controller not detected";
                    MessageBox.Show("Q-Astro Controller has not been detected.", "QuidneArduino Controller not detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.IO.IOException ioe)
            {
                MessageBox.Show("IO Exception has been thrown: " + ioe.Message, "Port not opened", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.UnauthorizedAccessException uae)
            {
                MessageBox.Show("Unauthorized access exception has been thrown: " + uae.Message, "Port not opened", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SystemException se)
            {
                MessageBox.Show("System exception has been thrown: " + se.Message, "Port not opened", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (serPort.Connected) serPort.Connected = false;

                serPort.Dispose();
            }
        }

        private void InitUI()
        {
            this.Text = Application.ProductName + " - " + Application.ProductVersion;
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

            for (int i=0; i < Properties.Settings.Default.Slots; i++)
            {
                string filterName = Properties.Settings.Default.FilterNames[i];
                string filterOffset = Properties.Settings.Default.FocusOffsets[i];
                filterDataGrid.Rows.Add((i+1), filterName, filterOffset);
            }
            tabComPort.Show();
        }

        private void ComPortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.COMPort = ComPortComboBox.GetItemText(this.ComPortComboBox.SelectedItem);
        }
    }
}
