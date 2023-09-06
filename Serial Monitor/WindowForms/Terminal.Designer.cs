namespace Serial_Monitor.WindowForms {
    partial class Terminal {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Terminal));
            this.Output = new ODModules.ConsoleInterface();
            this.tsMain = new ODModules.ToolStrip();
            this.ddbDisplayTime = new System.Windows.Forms.ToolStripDropDownButton();
            this.dataOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeStampsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateStampsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimeStampsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStartLogging = new System.Windows.Forms.ToolStripButton();
            this.btnStopLogging = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClearTerminal = new System.Windows.Forms.ToolStripButton();
            this.btnTopMost = new System.Windows.Forms.ToolStripButton();
            this.msMain = new ODModules.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenLog = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenLogLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuDispDataOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuDispTime = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuDispDate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuDispDateTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMenuClearTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom050 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom075 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom110 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom120 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom150 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom300 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMenuTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.loggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStartLog = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStopLog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogUpdater = new System.Windows.Forms.Timer(this.components);
            this.tsMain.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Output
            // 
            this.Output.AllowCommandEntry = true;
            this.Output.AllowMouseSelection = false;
            this.Output.AllowMouseWheelZoom = false;
            this.Output.BufferLength = 10000;
            this.Output.CursorFlashSpeed = 0.5F;
            this.Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Output.ExtraLineAfterCommandEntered = false;
            this.Output.FlashCursor = false;
            this.Output.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Output.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Output.HorScroll = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Output.LineFormatting = true;
            this.Output.Location = new System.Drawing.Point(0, 49);
            this.Output.MaximumLength = 100;
            this.Output.Name = "Output";
            this.Output.OriginForeColor = System.Drawing.Color.Silver;
            this.Output.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.Output.PrintOnEntry = true;
            this.Output.ScrollBarMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Output.ScrollBarNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Output.ScrollBarSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Output.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Output.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(74)))));
            this.Output.ShowOrigin = false;
            this.Output.Size = new System.Drawing.Size(430, 275);
            this.Output.TabIndex = 1;
            this.Output.TimeStampForeColor = System.Drawing.Color.Gray;
            this.Output.TimeStamps = ODModules.ConsoleInterface.TimeStampFormat.NoTimeStamps;
            this.Output.VerScroll = 0;
            this.Output.Zoom = 100;
            this.Output.CommandEntered += new ODModules.ConsoleInterface.CommandEnteredEventHandler(this.Output_CommandEntered);
            // 
            // tsMain
            // 
            this.tsMain.BackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.BackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.ItemCheckedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMain.ItemCheckedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMain.ItemForeColor = System.Drawing.Color.White;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddbDisplayTime,
            this.toolStripSeparator1,
            this.btnStartLogging,
            this.btnStopLogging,
            this.toolStripSeparator6,
            this.btnClearTerminal,
            this.btnTopMost});
            this.tsMain.ItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.tsMain.ItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.tsMain.ItemSelectedForeColor = System.Drawing.Color.Black;
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.MenuBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.MenuBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.MenuBorderColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.MenuSeparatorColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.MenuSymbolColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(430, 25);
            this.tsMain.StripItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.tsMain.StripItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "toolStrip1";
            // 
            // ddbDisplayTime
            // 
            this.ddbDisplayTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddbDisplayTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataOnlyToolStripMenuItem,
            this.timeStampsToolStripMenuItem,
            this.dateStampsToolStripMenuItem,
            this.dateTimeStampsToolStripMenuItem});
            this.ddbDisplayTime.ForeColor = System.Drawing.Color.White;
            this.ddbDisplayTime.Image = ((System.Drawing.Image)(resources.GetObject("ddbDisplayTime.Image")));
            this.ddbDisplayTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ddbDisplayTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbDisplayTime.Name = "ddbDisplayTime";
            this.ddbDisplayTime.Size = new System.Drawing.Size(72, 22);
            this.ddbDisplayTime.Tag = "0";
            this.ddbDisplayTime.Text = "Data Only";
            // 
            // dataOnlyToolStripMenuItem
            // 
            this.dataOnlyToolStripMenuItem.Checked = true;
            this.dataOnlyToolStripMenuItem.CheckOnClick = true;
            this.dataOnlyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dataOnlyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.dataOnlyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dataOnlyToolStripMenuItem.Name = "dataOnlyToolStripMenuItem";
            this.dataOnlyToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.dataOnlyToolStripMenuItem.Tag = "0";
            this.dataOnlyToolStripMenuItem.Text = "Data Only";
            this.dataOnlyToolStripMenuItem.Click += new System.EventHandler(this.dataOnlyToolStripMenuItem_Click);
            // 
            // timeStampsToolStripMenuItem
            // 
            this.timeStampsToolStripMenuItem.CheckOnClick = true;
            this.timeStampsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.timeStampsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.timeStampsToolStripMenuItem.Name = "timeStampsToolStripMenuItem";
            this.timeStampsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.timeStampsToolStripMenuItem.Tag = "1";
            this.timeStampsToolStripMenuItem.Text = "Time Stamps";
            this.timeStampsToolStripMenuItem.Click += new System.EventHandler(this.timeStampsToolStripMenuItem_Click);
            // 
            // dateStampsToolStripMenuItem
            // 
            this.dateStampsToolStripMenuItem.CheckOnClick = true;
            this.dateStampsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.dateStampsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dateStampsToolStripMenuItem.Name = "dateStampsToolStripMenuItem";
            this.dateStampsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.dateStampsToolStripMenuItem.Tag = "3";
            this.dateStampsToolStripMenuItem.Text = "Date Stamps";
            this.dateStampsToolStripMenuItem.Click += new System.EventHandler(this.dateStampsToolStripMenuItem_Click);
            // 
            // dateTimeStampsToolStripMenuItem
            // 
            this.dateTimeStampsToolStripMenuItem.CheckOnClick = true;
            this.dateTimeStampsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.dateTimeStampsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dateTimeStampsToolStripMenuItem.Name = "dateTimeStampsToolStripMenuItem";
            this.dateTimeStampsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.dateTimeStampsToolStripMenuItem.Tag = "4";
            this.dateTimeStampsToolStripMenuItem.Text = "Date/Time Stamps";
            this.dateTimeStampsToolStripMenuItem.Click += new System.EventHandler(this.dateTimeStampsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnStartLogging
            // 
            this.btnStartLogging.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStartLogging.Enabled = false;
            this.btnStartLogging.Image = ((System.Drawing.Image)(resources.GetObject("btnStartLogging.Image")));
            this.btnStartLogging.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStartLogging.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartLogging.Name = "btnStartLogging";
            this.btnStartLogging.Size = new System.Drawing.Size(23, 22);
            this.btnStartLogging.Text = "Start Logging";
            this.btnStartLogging.Click += new System.EventHandler(this.btnStartLogging_Click);
            // 
            // btnStopLogging
            // 
            this.btnStopLogging.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopLogging.Enabled = false;
            this.btnStopLogging.Image = ((System.Drawing.Image)(resources.GetObject("btnStopLogging.Image")));
            this.btnStopLogging.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStopLogging.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopLogging.Name = "btnStopLogging";
            this.btnStopLogging.Size = new System.Drawing.Size(23, 22);
            this.btnStopLogging.Text = "Stop Logging";
            this.btnStopLogging.Click += new System.EventHandler(this.btnStopLogging_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClearTerminal
            // 
            this.btnClearTerminal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClearTerminal.Image = ((System.Drawing.Image)(resources.GetObject("btnClearTerminal.Image")));
            this.btnClearTerminal.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClearTerminal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearTerminal.Name = "btnClearTerminal";
            this.btnClearTerminal.Size = new System.Drawing.Size(23, 22);
            this.btnClearTerminal.Text = "Clear Terminal";
            this.btnClearTerminal.Click += new System.EventHandler(this.btnClearTerminal_Click);
            // 
            // btnTopMost
            // 
            this.btnTopMost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTopMost.Image = ((System.Drawing.Image)(resources.GetObject("btnTopMost.Image")));
            this.btnTopMost.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTopMost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTopMost.Name = "btnTopMost";
            this.btnTopMost.Size = new System.Drawing.Size(23, 22);
            this.btnTopMost.Text = "Window Top Most";
            this.btnTopMost.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // msMain
            // 
            this.msMain.BackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.BackColorNorthFadeIn = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.BackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.ItemForeColor = System.Drawing.Color.White;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.loggingToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.msMain.ItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.msMain.ItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.msMain.ItemSelectedForeColor = System.Drawing.Color.Black;
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.MenuBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.MenuBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.MenuBorderColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.MenuSeparatorColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.MenuSymbolColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(430, 24);
            this.msMain.StripItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.msMain.StripItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.msMain.TabIndex = 3;
            this.msMain.Text = "menuStrip1";
            this.msMain.UseNorthFadeIn = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenLog,
            this.btnOpenLogLocation,
            this.toolStripSeparator5,
            this.btnSaveLog,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.ForeColor = System.Drawing.Color.White;
            this.btnOpenLog.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenLog.Image")));
            this.btnOpenLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpenLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.btnOpenLog.Size = new System.Drawing.Size(190, 22);
            this.btnOpenLog.Text = "&Open Log File";
            this.btnOpenLog.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // btnOpenLogLocation
            // 
            this.btnOpenLogLocation.Enabled = false;
            this.btnOpenLogLocation.ForeColor = System.Drawing.Color.White;
            this.btnOpenLogLocation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpenLogLocation.Name = "btnOpenLogLocation";
            this.btnOpenLogLocation.Size = new System.Drawing.Size(190, 22);
            this.btnOpenLogLocation.Text = "Open &Log Location";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(187, 6);
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.ForeColor = System.Drawing.Color.White;
            this.btnSaveLog.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLog.Image")));
            this.btnSaveLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSaveLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.btnSaveLog.Size = new System.Drawing.Size(190, 22);
            this.btnSaveLog.Text = "&Save Log File";
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(187, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMenuDispDataOnly,
            this.btnMenuDispTime,
            this.btnMenuDispDate,
            this.btnMenuDispDateTime,
            this.toolStripSeparator2,
            this.btnMenuClearTerminal,
            this.zoomToolStripMenuItem,
            this.toolStripSeparator4,
            this.btnMenuTopMost});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // btnMenuDispDataOnly
            // 
            this.btnMenuDispDataOnly.Checked = true;
            this.btnMenuDispDataOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnMenuDispDataOnly.ForeColor = System.Drawing.Color.White;
            this.btnMenuDispDataOnly.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMenuDispDataOnly.Name = "btnMenuDispDataOnly";
            this.btnMenuDispDataOnly.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.btnMenuDispDataOnly.Size = new System.Drawing.Size(207, 22);
            this.btnMenuDispDataOnly.Tag = "0";
            this.btnMenuDispDataOnly.Text = "Data &Only";
            this.btnMenuDispDataOnly.Click += new System.EventHandler(this.dataOnlyToolStripMenuItem1_Click);
            // 
            // btnMenuDispTime
            // 
            this.btnMenuDispTime.ForeColor = System.Drawing.Color.White;
            this.btnMenuDispTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMenuDispTime.Name = "btnMenuDispTime";
            this.btnMenuDispTime.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.btnMenuDispTime.Size = new System.Drawing.Size(207, 22);
            this.btnMenuDispTime.Tag = "1";
            this.btnMenuDispTime.Text = "&Time Stamps";
            this.btnMenuDispTime.Click += new System.EventHandler(this.btnMenuDispTime_Click);
            // 
            // btnMenuDispDate
            // 
            this.btnMenuDispDate.ForeColor = System.Drawing.Color.White;
            this.btnMenuDispDate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMenuDispDate.Name = "btnMenuDispDate";
            this.btnMenuDispDate.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.btnMenuDispDate.Size = new System.Drawing.Size(207, 22);
            this.btnMenuDispDate.Tag = "3";
            this.btnMenuDispDate.Text = "&Date Stamps";
            this.btnMenuDispDate.Click += new System.EventHandler(this.btnMenuDispDate_Click);
            // 
            // btnMenuDispDateTime
            // 
            this.btnMenuDispDateTime.ForeColor = System.Drawing.Color.White;
            this.btnMenuDispDateTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMenuDispDateTime.Name = "btnMenuDispDateTime";
            this.btnMenuDispDateTime.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
            this.btnMenuDispDateTime.Size = new System.Drawing.Size(207, 22);
            this.btnMenuDispDateTime.Tag = "4";
            this.btnMenuDispDateTime.Text = "Date/Time &Stamps";
            this.btnMenuDispDateTime.Click += new System.EventHandler(this.btnMenuDispDateTime_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(204, 6);
            // 
            // btnMenuClearTerminal
            // 
            this.btnMenuClearTerminal.ForeColor = System.Drawing.Color.White;
            this.btnMenuClearTerminal.Name = "btnMenuClearTerminal";
            this.btnMenuClearTerminal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.btnMenuClearTerminal.Size = new System.Drawing.Size(207, 22);
            this.btnMenuClearTerminal.Text = "Clear Terminal";
            this.btnMenuClearTerminal.Click += new System.EventHandler(this.btnMenuClearTerminal_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMenuZoom050,
            this.btnMenuZoom075,
            this.btnMenuZoom100,
            this.btnMenuZoom110,
            this.btnMenuZoom120,
            this.btnMenuZoom150,
            this.btnMenuZoom200,
            this.btnMenuZoom300});
            this.zoomToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.zoomToolStripMenuItem.Text = "&Zoom";
            // 
            // btnMenuZoom050
            // 
            this.btnMenuZoom050.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom050.Name = "btnMenuZoom050";
            this.btnMenuZoom050.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom050.Text = "50%";
            this.btnMenuZoom050.Click += new System.EventHandler(this.btnMenuZoom050_Click);
            // 
            // btnMenuZoom075
            // 
            this.btnMenuZoom075.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom075.Name = "btnMenuZoom075";
            this.btnMenuZoom075.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom075.Text = "75%";
            this.btnMenuZoom075.Click += new System.EventHandler(this.btnMenuZoom075_Click);
            // 
            // btnMenuZoom100
            // 
            this.btnMenuZoom100.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom100.Name = "btnMenuZoom100";
            this.btnMenuZoom100.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom100.Text = "100%";
            this.btnMenuZoom100.Click += new System.EventHandler(this.btnMenuZoom100_Click);
            // 
            // btnMenuZoom110
            // 
            this.btnMenuZoom110.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom110.Name = "btnMenuZoom110";
            this.btnMenuZoom110.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom110.Text = "110%";
            this.btnMenuZoom110.Click += new System.EventHandler(this.btnMenuZoom110_Click);
            // 
            // btnMenuZoom120
            // 
            this.btnMenuZoom120.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom120.Name = "btnMenuZoom120";
            this.btnMenuZoom120.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom120.Text = "120%";
            this.btnMenuZoom120.Click += new System.EventHandler(this.btnMenuZoom120_Click);
            // 
            // btnMenuZoom150
            // 
            this.btnMenuZoom150.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom150.Name = "btnMenuZoom150";
            this.btnMenuZoom150.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom150.Text = "150%";
            this.btnMenuZoom150.Click += new System.EventHandler(this.btnMenuZoom150_Click);
            // 
            // btnMenuZoom200
            // 
            this.btnMenuZoom200.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom200.Name = "btnMenuZoom200";
            this.btnMenuZoom200.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom200.Text = "200%";
            this.btnMenuZoom200.Click += new System.EventHandler(this.btnMenuZoom200_Click);
            // 
            // btnMenuZoom300
            // 
            this.btnMenuZoom300.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom300.Name = "btnMenuZoom300";
            this.btnMenuZoom300.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom300.Text = "300%";
            this.btnMenuZoom300.Click += new System.EventHandler(this.btnMenuZoom300_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(204, 6);
            // 
            // btnMenuTopMost
            // 
            this.btnMenuTopMost.ForeColor = System.Drawing.Color.White;
            this.btnMenuTopMost.Name = "btnMenuTopMost";
            this.btnMenuTopMost.Size = new System.Drawing.Size(207, 22);
            this.btnMenuTopMost.Text = "Top Most";
            this.btnMenuTopMost.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
            // 
            // loggingToolStripMenuItem
            // 
            this.loggingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartLog,
            this.btnStopLog});
            this.loggingToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            this.loggingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.loggingToolStripMenuItem.Text = "&Logging";
            // 
            // btnStartLog
            // 
            this.btnStartLog.Enabled = false;
            this.btnStartLog.ForeColor = System.Drawing.Color.White;
            this.btnStartLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStartLog.Name = "btnStartLog";
            this.btnStartLog.Size = new System.Drawing.Size(145, 22);
            this.btnStartLog.Text = "Start Logging";
            this.btnStartLog.Click += new System.EventHandler(this.btnStartLog_Click);
            // 
            // btnStopLog
            // 
            this.btnStopLog.Enabled = false;
            this.btnStopLog.ForeColor = System.Drawing.Color.White;
            this.btnStopLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStopLog.Name = "btnStopLog";
            this.btnStopLog.Size = new System.Drawing.Size(145, 22);
            this.btnStopLog.Text = "Stop Logging";
            this.btnStopLog.Click += new System.EventHandler(this.btnStopLog_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.optionsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // LogUpdater
            // 
            this.LogUpdater.Enabled = true;
            this.LogUpdater.Interval = 1000;
            this.LogUpdater.Tick += new System.EventHandler(this.LogUpdater_Tick);
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(430, 324);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.msMain);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "Terminal";
            this.Text = "Terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Terminal_FormClosing);
            this.Load += new System.EventHandler(this.Terminal_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Terminal_KeyPress);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ODModules.ConsoleInterface Output;
        private ODModules.ToolStrip tsMain;
        private ToolStripDropDownButton ddbDisplayTime;
        private ToolStripMenuItem dataOnlyToolStripMenuItem;
        private ToolStripMenuItem timeStampsToolStripMenuItem;
        private ToolStripMenuItem dateStampsToolStripMenuItem;
        private ToolStripMenuItem dateTimeStampsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnClearTerminal;
        private ToolStripButton btnTopMost;
        private ODModules.MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem btnOpenLog;
        private ToolStripMenuItem btnSaveLog;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem btnMenuDispDataOnly;
        private ToolStripMenuItem btnMenuDispTime;
        private ToolStripMenuItem btnMenuDispDate;
        private ToolStripMenuItem btnMenuDispDateTime;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem btnMenuClearTerminal;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem btnMenuTopMost;
        private ToolStripMenuItem loggingToolStripMenuItem;
        private ToolStripMenuItem zoomToolStripMenuItem;
        private ToolStripMenuItem btnMenuZoom050;
        private ToolStripMenuItem btnMenuZoom075;
        private ToolStripMenuItem btnMenuZoom100;
        private ToolStripMenuItem btnMenuZoom110;
        private ToolStripMenuItem btnMenuZoom120;
        private ToolStripMenuItem btnMenuZoom150;
        private ToolStripMenuItem btnMenuZoom200;
        private ToolStripMenuItem btnMenuZoom300;
        private ToolStripMenuItem btnStartLog;
        private ToolStripMenuItem btnStopLog;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnStartLogging;
        private ToolStripButton btnStopLogging;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem btnOpenLogLocation;
        private System.Windows.Forms.Timer LogUpdater;
    }
}