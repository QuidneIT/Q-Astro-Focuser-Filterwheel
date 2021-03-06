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
            this.btnTestPrt = new MetroFramework.Controls.MetroButton();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnOK = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.toolQASetupStatus = new MetroFramework.Controls.MetroLabel();
//            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.setupTabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabComPort = new MetroFramework.Controls.MetroTabPage();
            this.ComPortComboBox = new MetroFramework.Controls.MetroComboBox();
            this.chkTrace = new MetroFramework.Controls.MetroToggle();
            this.tabFilterWheel = new MetroFramework.Controls.MetroTabPage();
            this.filterDataGrid = new System.Windows.Forms.DataGridView();
            this.FilterNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilterOffset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.setupTabControl.SuspendLayout();
            this.tabComPort.SuspendLayout();
            this.tabFilterWheel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.CustomBackground = false;
            this.lblHeader.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblHeader.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblHeader.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.lblHeader.Location = new System.Drawing.Point(63, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(207, 56);
            this.lblHeader.Style = MetroFramework.MetroColorStyle.Lime;
//            this.lblHeader.StyleManager = null;
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "Q-Astro Controller \n Setup";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeader.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.lblHeader.UseStyleColors = true;
            // 
            // btnTestPrt
            // 
            this.btnTestPrt.Highlight = false;
            this.btnTestPrt.Location = new System.Drawing.Point(51, 128);
            this.btnTestPrt.Margin = new System.Windows.Forms.Padding(2);
            this.btnTestPrt.Name = "btnTestPrt";
            this.btnTestPrt.Size = new System.Drawing.Size(207, 30);
            this.btnTestPrt.Style = MetroFramework.MetroColorStyle.Lime;
//            this.btnTestPrt.StyleManager = null;
            this.btnTestPrt.TabIndex = 8;
            this.btnTestPrt.Text = "Test port";
            this.btnTestPrt.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnTestPrt.Click += new System.EventHandler(this.btnTestPrt_Click);
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
            this.picASCOM.Location = new System.Drawing.Point(276, 9);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
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
            this.picLogo.Location = new System.Drawing.Point(6, 9);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(51, 56);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 23;
            this.picLogo.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Highlight = false;
            this.btnOK.Location = new System.Drawing.Point(63, 285);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 30);
            this.btnOK.Style = MetroFramework.MetroColorStyle.Lime;
            //this.btnOK.StyleManager = null;
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "OK";
            this.btnOK.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Highlight = false;
            this.btnCancel.Location = new System.Drawing.Point(191, 284);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 31);
            this.btnCancel.Style = MetroFramework.MetroColorStyle.Lime;
//            this.btnCancel.StyleManager = null;
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.CustomBackground = false;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel1.Location = new System.Drawing.Point(51, 85);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(69, 24);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Lime;
 //           this.metroLabel1.StyleManager = null;
            this.metroLabel1.TabIndex = 26;
            this.metroLabel1.Text = "Trace:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = true;
            // 
            // toolQASetupStatus
            // 
            this.toolQASetupStatus.CustomBackground = false;
            this.toolQASetupStatus.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.toolQASetupStatus.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.toolQASetupStatus.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.toolQASetupStatus.Location = new System.Drawing.Point(9, 327);
            this.toolQASetupStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toolQASetupStatus.Name = "toolQASetupStatus";
            this.toolQASetupStatus.Size = new System.Drawing.Size(315, 22);
            this.toolQASetupStatus.Style = MetroFramework.MetroColorStyle.Lime;
 //           this.toolQASetupStatus.StyleManager = null;
            this.toolQASetupStatus.TabIndex = 27;
            this.toolQASetupStatus.Text = "Quidne IT - Astronomy";
            this.toolQASetupStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolQASetupStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toolQASetupStatus.UseStyleColors = true;
            // 
            // metroStyleManager1
            // 
//            this.metroStyleManager1.Owner = null;
//            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Lime;
//            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // setupTabControl
            // 
            this.setupTabControl.Controls.Add(this.tabComPort);
            this.setupTabControl.Controls.Add(this.tabFilterWheel);
            this.setupTabControl.CustomBackground = false;
            this.setupTabControl.FontSize = MetroFramework.MetroTabControlSize.Medium;
            this.setupTabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.setupTabControl.Location = new System.Drawing.Point(9, 76);
            this.setupTabControl.Name = "setupTabControl";
            this.setupTabControl.SelectedIndex = 0;
            this.setupTabControl.Size = new System.Drawing.Size(315, 195);
            this.setupTabControl.Style = MetroFramework.MetroColorStyle.Lime;
 //           this.setupTabControl.StyleManager = null;
            this.setupTabControl.TabIndex = 28;
            this.setupTabControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.setupTabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.setupTabControl.UseStyleColors = false;
            // 
            // tabComPort
            // 
            this.tabComPort.Controls.Add(this.metroLabel1);
            this.tabComPort.Controls.Add(this.ComPortComboBox);
            this.tabComPort.Controls.Add(this.chkTrace);
            this.tabComPort.Controls.Add(this.btnTestPrt);
            this.tabComPort.CustomBackground = false;
            this.tabComPort.HorizontalScrollbar = false;
            this.tabComPort.HorizontalScrollbarBarColor = true;
            this.tabComPort.HorizontalScrollbarHighlightOnWheel = false;
            this.tabComPort.HorizontalScrollbarSize = 10;
            this.tabComPort.Location = new System.Drawing.Point(4, 35);
            this.tabComPort.Name = "tabComPort";
            this.tabComPort.Size = new System.Drawing.Size(307, 156);
            this.tabComPort.Style = MetroFramework.MetroColorStyle.Lime;
//            this.tabComPort.StyleManager = null;
            this.tabComPort.TabIndex = 0;
            this.tabComPort.Text = "Com Port";
            this.tabComPort.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabComPort.VerticalScrollbar = false;
            this.tabComPort.VerticalScrollbarBarColor = true;
            this.tabComPort.VerticalScrollbarHighlightOnWheel = false;
            this.tabComPort.VerticalScrollbarSize = 10;
            // 
            // ComPortComboBox
            // 
            this.ComPortComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ASCOM.QAstroFF.Properties.Settings.Default, "COMPort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ComPortComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComPortComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComPortComboBox.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.ComPortComboBox.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.ComPortComboBox.FormattingEnabled = true;
            this.ComPortComboBox.ItemHeight = 23;
            this.ComPortComboBox.Location = new System.Drawing.Point(51, 31);
            this.ComPortComboBox.Name = "ComPortComboBox";
            this.ComPortComboBox.Size = new System.Drawing.Size(208, 29);
            this.ComPortComboBox.Style = MetroFramework.MetroColorStyle.Lime;
 //           this.ComPortComboBox.StyleManager = null;
            this.ComPortComboBox.TabIndex = 12;
            this.ComPortComboBox.Text = global::ASCOM.QAstroFF.Properties.Settings.Default.COMPort;
            this.ComPortComboBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ComPortComboBox.SelectedIndexChanged += new System.EventHandler(this.ComPortComboBox_SelectedIndexChanged);
            // 
            // chkTrace
            // 
            this.chkTrace.Checked = global::ASCOM.QAstroFF.Properties.Settings.Default.trace;
            this.chkTrace.CustomBackground = false;
            this.chkTrace.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ASCOM.QAstroFF.Properties.Settings.Default, "trace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkTrace.DisplayStatus = true;
            this.chkTrace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkTrace.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.chkTrace.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.chkTrace.Location = new System.Drawing.Point(196, 85);
            this.chkTrace.Name = "chkTrace";
            this.chkTrace.Size = new System.Drawing.Size(62, 24);
            this.chkTrace.Style = MetroFramework.MetroColorStyle.Lime;
 //           this.chkTrace.StyleManager = null;
            this.chkTrace.TabIndex = 16;
            this.chkTrace.Text = "Off";
            this.chkTrace.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.chkTrace.UseStyleColors = true;
            // 
            // tabFilterWheel
            // 
            this.tabFilterWheel.Controls.Add(this.filterDataGrid);
            this.tabFilterWheel.CustomBackground = false;
            this.tabFilterWheel.HorizontalScrollbar = false;
            this.tabFilterWheel.HorizontalScrollbarBarColor = true;
            this.tabFilterWheel.HorizontalScrollbarHighlightOnWheel = false;
            this.tabFilterWheel.HorizontalScrollbarSize = 10;
            this.tabFilterWheel.Location = new System.Drawing.Point(4, 35);
            this.tabFilterWheel.Margin = new System.Windows.Forms.Padding(2);
            this.tabFilterWheel.Name = "tabFilterWheel";
            this.tabFilterWheel.Size = new System.Drawing.Size(307, 156);
            this.tabFilterWheel.Style = MetroFramework.MetroColorStyle.Lime;
//            this.tabFilterWheel.StyleManager = null;
            this.tabFilterWheel.TabIndex = 1;
            this.tabFilterWheel.Text = "Filter Wheel";
            this.tabFilterWheel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabFilterWheel.VerticalScrollbar = false;
            this.tabFilterWheel.VerticalScrollbarBarColor = true;
            this.tabFilterWheel.VerticalScrollbarHighlightOnWheel = false;
            this.tabFilterWheel.VerticalScrollbarSize = 10;
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
            this.filterDataGrid.Location = new System.Drawing.Point(9, 3);
            this.filterDataGrid.Name = "filterDataGrid";
            this.filterDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.filterDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.filterDataGrid.Size = new System.Drawing.Size(297, 154);
            this.filterDataGrid.TabIndex = 2;
            // 
            // FilterNr
            // 
            this.FilterNr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FilterNr.HeaderText = "Number";
            this.FilterNr.Name = "FilterNr";
            // 
            // FilterName
            // 
            this.FilterName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FilterName.HeaderText = "Name";
            this.FilterName.Name = "FilterName";
            // 
            // FilterOffset
            // 
            this.FilterOffset.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FilterOffset.HeaderText = "Offset";
            this.FilterOffset.Name = "FilterOffset";
            // 
            // ServerSetupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(333, 356);
            this.Controls.Add(this.setupTabControl);
            this.Controls.Add(this.toolQASetupStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerSetupDialog";
            this.Text = "Q-Astro Controller Setup";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.setupTabControl.ResumeLayout(false);
            this.tabComPort.ResumeLayout(false);
            this.tabFilterWheel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filterDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox ComPortComboBox;
        private MetroFramework.Controls.MetroLabel lblHeader;
        private MetroFramework.Controls.MetroButton btnTestPrt;
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
    }
}