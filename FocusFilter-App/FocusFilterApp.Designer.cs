namespace ASCOM.QAstroFF.FocusFilterApp
{
    partial class FocusFilterApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FocusFilterApp));
            this.btnConnectDisconnect = new MetroFramework.Controls.MetroButton();
            this.btnSetup = new MetroFramework.Controls.MetroButton();
            this.btnFocusReset = new MetroFramework.Controls.MetroButton();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSelectedFilterName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbltxtAstroStatus = new MetroFramework.Controls.MetroLabel();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timerUI = new System.Windows.Forms.Timer(this.components);
            this.lblMinimize = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblCaption = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.pnlFocus = new System.Windows.Forms.Panel();
            this.lblFocusPos = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.pnlSetup = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAbout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.pnlFocus.SuspendLayout();
            this.pnlSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnectDisconnect
            // 
            this.btnConnectDisconnect.Highlight = true;
            this.btnConnectDisconnect.Location = new System.Drawing.Point(179, 45);
            this.btnConnectDisconnect.Name = "btnConnectDisconnect";
            this.btnConnectDisconnect.Size = new System.Drawing.Size(96, 35);
            this.btnConnectDisconnect.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnConnectDisconnect.TabIndex = 3;
            this.btnConnectDisconnect.Text = "Connect";
            this.btnConnectDisconnect.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnConnectDisconnect.Click += new System.EventHandler(this.BtnConnectDisconnect_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.Highlight = true;
            this.btnSetup.Location = new System.Drawing.Point(65, 45);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(99, 35);
            this.btnSetup.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnSetup.TabIndex = 4;
            this.btnSetup.Text = "Setup";
            this.btnSetup.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnSetup.Click += new System.EventHandler(this.BtnSetup_Click);
            // 
            // btnFocusReset
            // 
            this.btnFocusReset.Highlight = true;
            this.btnFocusReset.Location = new System.Drawing.Point(113, 40);
            this.btnFocusReset.Name = "btnFocusReset";
            this.btnFocusReset.Size = new System.Drawing.Size(96, 35);
            this.btnFocusReset.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnFocusReset.TabIndex = 8;
            this.btnFocusReset.Text = "Reset to 0";
            this.btnFocusReset.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnFocusReset.Click += new System.EventHandler(this.BtnFocusReset_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.YellowGreen;
            this.label4.Location = new System.Drawing.Point(10, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "Focus Position:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSelectedFilterName
            // 
            this.lblSelectedFilterName.BackColor = System.Drawing.Color.Black;
            this.lblSelectedFilterName.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedFilterName.ForeColor = System.Drawing.Color.Red;
            this.lblSelectedFilterName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectedFilterName.Location = new System.Drawing.Point(39, 40);
            this.lblSelectedFilterName.Name = "lblSelectedFilterName";
            this.lblSelectedFilterName.Size = new System.Drawing.Size(104, 27);
            this.lblSelectedFilterName.TabIndex = 6;
            this.lblSelectedFilterName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.YellowGreen;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(3, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "Filter:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbltxtAstroStatus
            // 
            this.lbltxtAstroStatus.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lbltxtAstroStatus.Location = new System.Drawing.Point(3, 230);
            this.lbltxtAstroStatus.Name = "lbltxtAstroStatus";
            this.lbltxtAstroStatus.Size = new System.Drawing.Size(198, 23);
            this.lbltxtAstroStatus.Style = MetroFramework.MetroColorStyle.Lime;
            this.lbltxtAstroStatus.TabIndex = 1;
            this.lbltxtAstroStatus.Text = "Q-Astro Focuser and Filter: ";
            this.lbltxtAstroStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltxtAstroStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lbltxtAstroStatus.UseStyleColors = true;
            // 
            // lblStatus
            // 
            this.lblStatus.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblStatus.Location = new System.Drawing.Point(188, 231);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(311, 22);
            this.lblStatus.Style = MetroFramework.MetroColorStyle.Lime;
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Disconnected";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblStatus.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(67, 35);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(39, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "5.5.0";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseStyleColors = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(4, 4);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(187, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Q-Astro Controller";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 50);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(454, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 66);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // timerUI
            // 
            this.timerUI.Interval = 5000;
            this.timerUI.Tick += new System.EventHandler(this.TimerUI_Tick);
            // 
            // lblMinimize
            // 
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.Location = new System.Drawing.Point(439, 6);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(12, 13);
            this.lblMinimize.TabIndex = 21;
            this.lblMinimize.Text = "-";
            this.lblMinimize.Click += new System.EventHandler(this.LblMinimize_Click);
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Location = new System.Drawing.Point(481, 9);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(15, 13);
            this.lblClose.TabIndex = 22;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.LblClose_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(0, 6);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(250, 13);
            this.lblCaption.TabIndex = 24;
            this.lblCaption.Text = "Q-Astro Focuser and Filter Control Panel - ";
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Black;
            this.label23.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.YellowGreen;
            this.label23.Location = new System.Drawing.Point(169, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(15, 27);
            this.label23.TabIndex = 35;
            this.label23.Text = ":";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.lblSelectedFilterName);
            this.pnlFilter.Location = new System.Drawing.Point(332, 139);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(167, 88);
            this.pnlFilter.TabIndex = 50;
            // 
            // pnlFocus
            // 
            this.pnlFocus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFocus.Controls.Add(this.lblFocusPos);
            this.pnlFocus.Controls.Add(this.btnFocusReset);
            this.pnlFocus.Controls.Add(this.label4);
            this.pnlFocus.Location = new System.Drawing.Point(9, 139);
            this.pnlFocus.Name = "pnlFocus";
            this.pnlFocus.Size = new System.Drawing.Size(317, 88);
            this.pnlFocus.TabIndex = 51;
            // 
            // lblFocusPos
            // 
            this.lblFocusPos.BackColor = System.Drawing.Color.Black;
            this.lblFocusPos.ForeColor = System.Drawing.Color.Red;
            this.lblFocusPos.Format = "000000";
            this.lblFocusPos.Location = new System.Drawing.Point(178, 4);
            this.lblFocusPos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblFocusPos.Name = "lblFocusPos";
            this.lblFocusPos.Renderer = null;
            this.lblFocusPos.Signed = false;
            this.lblFocusPos.Size = new System.Drawing.Size(122, 28);
            this.lblFocusPos.TabIndex = 35;
            this.lblFocusPos.Value = 0D;
            // 
            // pnlSetup
            // 
            this.pnlSetup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSetup.Controls.Add(this.label1);
            this.pnlSetup.Controls.Add(this.btnSetup);
            this.pnlSetup.Controls.Add(this.btnConnectDisconnect);
            this.pnlSetup.Location = new System.Drawing.Point(69, 35);
            this.pnlSetup.Name = "pnlSetup";
            this.pnlSetup.Size = new System.Drawing.Size(376, 98);
            this.pnlSetup.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(-1, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Q-ASTRO Focuser and Filter\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Location = new System.Drawing.Point(417, 6);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(13, 13);
            this.lblAbout.TabIndex = 57;
            this.lblAbout.Text = "?";
            this.lblAbout.Click += new System.EventHandler(this.LblAbout_Click);
            // 
            // FocusFilterApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(511, 261);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.lblMinimize);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lbltxtAstroStatus);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlSetup);
            this.Controls.Add(this.pnlFocus);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FocusFilterApp";
            this.Text = "Q-Astro Focuser & Filter App";
            this.TransparencyKey = System.Drawing.Color.Pink;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFocus.ResumeLayout(false);
            this.pnlSetup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel lbltxtAstroStatus;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnConnectDisconnect;
        private MetroFramework.Controls.MetroButton btnSetup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timerUI;
        private System.Windows.Forms.Label lblSelectedFilterName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroButton btnFocusReset;
        private System.Windows.Forms.Label lblMinimize;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlFocus;
        private System.Windows.Forms.Panel pnlSetup;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lblFocusPos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAbout;
    }
}

