namespace ASCOM.QAstroFF
{
    partial class ServerSetupDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerSetupDialog));
            this.lblHeader = new MetroFramework.Controls.MetroLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnOK = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.toolQASetupStatus = new MetroFramework.Controls.MetroLabel();
            this.setupTabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabComPort = new MetroFramework.Controls.MetroTabPage();
            this.ComPortComboBox = new MetroFramework.Controls.MetroComboBox();
            this.chkTrace = new MetroFramework.Controls.MetroToggle();
            this.tabFocuser = new MetroFramework.Controls.MetroTabPage();
            this.btnFocuserInfo = new MetroFramework.Controls.MetroButton();
            this.chkMotorEnabled = new MetroFramework.Controls.MetroCheckBox();
            this.txtMaxPosition = new System.Windows.Forms.TextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.txtMaxStep = new System.Windows.Forms.TextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.StepResolutionCombo = new System.Windows.Forms.ComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtStepSize = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.tabFilterWheel = new MetroFramework.Controls.MetroTabPage();
            this.filterDataGrid = new System.Windows.Forms.DataGridView();
            this.FilterNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilterOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.setupTabControl.SuspendLayout();
            this.tabComPort.SuspendLayout();
            this.tabFocuser.SuspendLayout();
            this.tabFilterWheel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblHeader.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblHeader.Location = new System.Drawing.Point(84, 11);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(276, 69);
            this.lblHeader.Style = MetroFramework.MetroColorStyle.Lime;
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "Focuser - Filterwheel\n Setup";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeader.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblHeader.UseStyleColors = true;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(102, 17);
            this.StatusLabel.Text = "ASCOM QA Setup";
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = ((System.Drawing.Image)(resources.GetObject("picASCOM.Image")));
            this.picASCOM.Location = new System.Drawing.Point(368, 11);
            this.picASCOM.Margin = new System.Windows.Forms.Padding(4);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(64, 69);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picASCOM.TabIndex = 13;
            this.picASCOM.TabStop = false;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Image = global::ASCOM.QAstroFF.Properties.Resources.QuidneIT_SQR;
            this.picLogo.InitialImage = global::ASCOM.QAstroFF.Properties.Resources.QuidneIT_SQR;
            this.picLogo.Location = new System.Drawing.Point(8, 11);
            this.picLogo.Margin = new System.Windows.Forms.Padding(4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(68, 69);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 23;
            this.picLogo.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(84, 351);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 37);
            this.btnOK.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "OK";
            this.btnOK.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(255, 350);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 38);
            this.btnCancel.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(120, 105);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(78, 30);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel1.TabIndex = 26;
            this.metroLabel1.Text = "Trace:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = true;
            // 
            // toolQASetupStatus
            // 
            this.toolQASetupStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.toolQASetupStatus.Location = new System.Drawing.Point(12, 402);
            this.toolQASetupStatus.Name = "toolQASetupStatus";
            this.toolQASetupStatus.Size = new System.Drawing.Size(420, 27);
            this.toolQASetupStatus.Style = MetroFramework.MetroColorStyle.Lime;
            this.toolQASetupStatus.TabIndex = 27;
            this.toolQASetupStatus.Text = "Q-Astro";
            this.toolQASetupStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolQASetupStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolQASetupStatus.UseStyleColors = true;
            // 
            // setupTabControl
            // 
            this.setupTabControl.Controls.Add(this.tabComPort);
            this.setupTabControl.Controls.Add(this.tabFocuser);
            this.setupTabControl.Controls.Add(this.tabFilterWheel);
            this.setupTabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.setupTabControl.Location = new System.Drawing.Point(12, 94);
            this.setupTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.setupTabControl.Name = "setupTabControl";
            this.setupTabControl.SelectedIndex = 0;
            this.setupTabControl.Size = new System.Drawing.Size(420, 240);
            this.setupTabControl.Style = MetroFramework.MetroColorStyle.Lime;
            this.setupTabControl.TabIndex = 28;
            this.setupTabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tabComPort
            // 
            this.tabComPort.Controls.Add(this.metroLabel1);
            this.tabComPort.Controls.Add(this.ComPortComboBox);
            this.tabComPort.Controls.Add(this.chkTrace);
            this.tabComPort.HorizontalScrollbarBarColor = true;
            this.tabComPort.HorizontalScrollbarSize = 12;
            this.tabComPort.Location = new System.Drawing.Point(4, 39);
            this.tabComPort.Margin = new System.Windows.Forms.Padding(4);
            this.tabComPort.Name = "tabComPort";
            this.tabComPort.Size = new System.Drawing.Size(412, 197);
            this.tabComPort.Style = MetroFramework.MetroColorStyle.Lime;
            this.tabComPort.TabIndex = 0;
            this.tabComPort.Text = "Com Port";
            this.tabComPort.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabComPort.VerticalScrollbarBarColor = true;
            this.tabComPort.VerticalScrollbarSize = 13;
            // 
            // ComPortComboBox
            // 
            this.ComPortComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ASCOM.QAstroFF.Properties.Settings.Default, "COMPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ComPortComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComPortComboBox.FormattingEnabled = true;
            this.ComPortComboBox.ItemHeight = 23;
            this.ComPortComboBox.Location = new System.Drawing.Point(68, 38);
            this.ComPortComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.ComPortComboBox.Name = "ComPortComboBox";
            this.ComPortComboBox.Size = new System.Drawing.Size(276, 29);
            this.ComPortComboBox.Style = MetroFramework.MetroColorStyle.Lime;
            this.ComPortComboBox.TabIndex = 12;
            this.ComPortComboBox.Text = global::ASCOM.QAstroFF.Properties.Settings.Default.COMPort;
            this.ComPortComboBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ComPortComboBox.SelectedIndexChanged += new System.EventHandler(this.ComPortComboBox_SelectedIndexChanged);
            // 
            // chkTrace
            // 
            this.chkTrace.Checked = global::ASCOM.QAstroFF.Properties.Settings.Default.trace;
            this.chkTrace.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ASCOM.QAstroFF.Properties.Settings.Default, "trace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkTrace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkTrace.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.chkTrace.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.chkTrace.Location = new System.Drawing.Point(205, 105);
            this.chkTrace.Margin = new System.Windows.Forms.Padding(4);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(83, 30);
            this.chkTrace.Style = MetroFramework.MetroColorStyle.Lime;
            this.chkTrace.TabIndex = 16;
            this.chkTrace.Text = "Off";
            this.chkTrace.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkTrace.UseStyleColors = true;
            // 
            // tabFocuser
            // 
            this.tabFocuser.Controls.Add(this.btnFocuserInfo);
            this.tabFocuser.Controls.Add(this.chkMotorEnabled);
            this.tabFocuser.Controls.Add(this.txtMaxPosition);
            this.tabFocuser.Controls.Add(this.metroLabel5);
            this.tabFocuser.Controls.Add(this.txtMaxStep);
            this.tabFocuser.Controls.Add(this.metroLabel4);
            this.tabFocuser.Controls.Add(this.StepResolutionCombo);
            this.tabFocuser.Controls.Add(this.metroLabel3);
            this.tabFocuser.Controls.Add(this.txtStepSize);
            this.tabFocuser.Controls.Add(this.metroLabel2);
            this.tabFocuser.HorizontalScrollbarBarColor = true;
            this.tabFocuser.Location = new System.Drawing.Point(4, 39);
            this.tabFocuser.Name = "tabFocuser";
            this.tabFocuser.Size = new System.Drawing.Size(412, 197);
            this.tabFocuser.Style = MetroFramework.MetroColorStyle.Lime;
            this.tabFocuser.TabIndex = 2;
            this.tabFocuser.Text = "Focuser";
            this.tabFocuser.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabFocuser.VerticalScrollbarBarColor = true;
            // 
            // btnFocuserInfo
            // 
            this.btnFocuserInfo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFocuserInfo.Location = new System.Drawing.Point(335, 48);
            this.btnFocuserInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFocuserInfo.Name = "btnFocuserInfo";
            this.btnFocuserInfo.Size = new System.Drawing.Size(39, 26);
            this.btnFocuserInfo.Style = MetroFramework.MetroColorStyle.Lime;
            this.btnFocuserInfo.TabIndex = 29;
            this.btnFocuserInfo.Text = "Info";
            this.btnFocuserInfo.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnFocuserInfo.Click += new System.EventHandler(this.BtnFocuserInfo_Click);
            // 
            // chkMotorEnabled
            // 
            this.chkMotorEnabled.AutoSize = true;
            this.chkMotorEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMotorEnabled.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.chkMotorEnabled.Location = new System.Drawing.Point(93, 166);
            this.chkMotorEnabled.Name = "chkMotorEnabled";
            this.chkMotorEnabled.Size = new System.Drawing.Size(215, 19);
            this.chkMotorEnabled.TabIndex = 36;
            this.chkMotorEnabled.Text = "Motor stay enabled after move";
            this.chkMotorEnabled.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkMotorEnabled.CheckedChanged += new System.EventHandler(this.ChkMotorEnabled_CheckedChanged);
            // 
            // txtMaxPosition
            // 
            this.txtMaxPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxPosition.Location = new System.Drawing.Point(208, 127);
            this.txtMaxPosition.Name = "txtMaxPosition";
            this.txtMaxPosition.Size = new System.Drawing.Size(100, 24);
            this.txtMaxPosition.TabIndex = 34;
            this.txtMaxPosition.TextChanged += new System.EventHandler(this.TxtMaxPosition_TextChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(3, 120);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(199, 30);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel5.TabIndex = 33;
            this.metroLabel5.Text = "Max Position:";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel5.UseStyleColors = true;
            // 
            // txtMaxStep
            // 
            this.txtMaxStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxStep.Location = new System.Drawing.Point(208, 88);
            this.txtMaxStep.Name = "txtMaxStep";
            this.txtMaxStep.Size = new System.Drawing.Size(100, 24);
            this.txtMaxStep.TabIndex = 32;
            this.txtMaxStep.TextChanged += new System.EventHandler(this.TxtMaxStep_TextChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(3, 81);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(199, 30);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel4.TabIndex = 31;
            this.metroLabel4.Text = "Max Step Size:";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel4.UseStyleColors = true;
            // 
            // StepResolutionCombo
            // 
            this.StepResolutionCombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StepResolutionCombo.FormattingEnabled = true;
            this.StepResolutionCombo.Items.AddRange(new object[] {
            "1",
            "1/2",
            "1/4",
            "1/8",
            "1/16"});
            this.StepResolutionCombo.Location = new System.Drawing.Point(208, 48);
            this.StepResolutionCombo.Name = "StepResolutionCombo";
            this.StepResolutionCombo.Size = new System.Drawing.Size(121, 26);
            this.StepResolutionCombo.TabIndex = 30;
            this.StepResolutionCombo.SelectedIndexChanged += new System.EventHandler(this.StepResolutionCombo_SelectedIndexChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(3, 43);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(199, 30);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel3.TabIndex = 29;
            this.metroLabel3.Text = "Step Resolution:";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseStyleColors = true;
            // 
            // txtStepSize
            // 
            this.txtStepSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStepSize.Location = new System.Drawing.Point(208, 11);
            this.txtStepSize.Name = "txtStepSize";
            this.txtStepSize.Size = new System.Drawing.Size(100, 24);
            this.txtStepSize.TabIndex = 28;
            this.txtStepSize.TextChanged += new System.EventHandler(this.TxtStepSize_TextChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(3, 6);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(199, 30);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Lime;
            this.metroLabel2.TabIndex = 27;
            this.metroLabel2.Text = "Stepsize (microns):";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel2.UseStyleColors = true;
            // 
            // tabFilterWheel
            // 
            this.tabFilterWheel.Controls.Add(this.filterDataGrid);
            this.tabFilterWheel.HorizontalScrollbarBarColor = true;
            this.tabFilterWheel.HorizontalScrollbarSize = 12;
            this.tabFilterWheel.Location = new System.Drawing.Point(4, 39);
            this.tabFilterWheel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFilterWheel.Name = "tabFilterWheel";
            this.tabFilterWheel.Size = new System.Drawing.Size(412, 197);
            this.tabFilterWheel.Style = MetroFramework.MetroColorStyle.Lime;
            this.tabFilterWheel.TabIndex = 1;
            this.tabFilterWheel.Text = "Filter Wheel";
            this.tabFilterWheel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabFilterWheel.VerticalScrollbarBarColor = true;
            this.tabFilterWheel.VerticalScrollbarSize = 13;
            // 
            // filterDataGrid
            // 
            this.filterDataGrid.AllowUserToAddRows = false;
            this.filterDataGrid.AllowUserToDeleteRows = false;
            this.filterDataGrid.AllowUserToResizeColumns = false;
            this.filterDataGrid.AllowUserToResizeRows = false;
            this.filterDataGrid.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.filterDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filterDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FilterNr,
            this.FilterName,
            this.FilterOffset});
            this.filterDataGrid.Location = new System.Drawing.Point(12, 4);
            this.filterDataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.filterDataGrid.Name = "filterDataGrid";
            this.filterDataGrid.RowHeadersWidth = 51;
            this.filterDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.filterDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filterDataGrid.Size = new System.Drawing.Size(396, 190);
            this.filterDataGrid.TabIndex = 2;
            // 
            // FilterNr
            // 
            this.FilterNr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FilterNr.HeaderText = "Number";
            this.FilterNr.MinimumWidth = 6;
            this.FilterNr.Name = "FilterNr";
            // 
            // FilterName
            // 
            this.FilterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FilterName.HeaderText = "Name";
            this.FilterName.MinimumWidth = 6;
            this.FilterName.Name = "FilterName";
            // 
            // FilterOffset
            // 
            this.FilterOffset.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FilterOffset.HeaderText = "Offset";
            this.FilterOffset.MinimumWidth = 6;
            this.FilterOffset.Name = "FilterOffset";
            // 
            // ServerSetupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(444, 438);
            this.Controls.Add(this.setupTabControl);
            this.Controls.Add(this.toolQASetupStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerSetupDialog";
            this.Text = "Q-Astro Focuser - Filterwheel Setup";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.setupTabControl.ResumeLayout(false);
            this.tabComPort.ResumeLayout(false);
            this.tabFocuser.ResumeLayout(false);
            this.tabFocuser.PerformLayout();
            this.tabFilterWheel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filterDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox ComPortComboBox;
        private MetroFramework.Controls.MetroLabel lblHeader;
        private MetroFramework.Controls.MetroToggle chkTrace;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.PictureBox picLogo;
        private MetroFramework.Controls.MetroButton btnOK;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel toolQASetupStatus;
//        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTabControl setupTabControl;
        private MetroFramework.Controls.MetroTabPage tabComPort;
        private MetroFramework.Controls.MetroTabPage tabFilterWheel;
        private System.Windows.Forms.DataGridView filterDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilterNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilterOffset;
        private MetroFramework.Controls.MetroTabPage tabFocuser;
        private System.Windows.Forms.ComboBox StepResolutionCombo;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.TextBox txtStepSize;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.TextBox txtMaxStep;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.TextBox txtMaxPosition;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroCheckBox chkMotorEnabled;
        private MetroFramework.Controls.MetroButton btnFocuserInfo;
    }
}