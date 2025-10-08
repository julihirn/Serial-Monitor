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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Terminal));
            Output = new ODModules.ConsoleInterface();
            cmTerminal = new ODModules.ContextMenu();
            clearTerminalToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator11 = new ToolStripSeparator();
            copyToolStripMenuItem1 = new ToolStripMenuItem();
            pasteToolStripMenuItem1 = new ToolStripMenuItem();
            deleteToolStripMenuItem1 = new ToolStripMenuItem();
            tsMain = new ODModules.ToolStrip();
            ddbDisplayTime = new ToolStripDropDownButton();
            dataOnlyToolStripMenuItem = new ToolStripMenuItem();
            timeStampsToolStripMenuItem = new ToolStripMenuItem();
            dateStampsToolStripMenuItem = new ToolStripMenuItem();
            dateTimeStampsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            btnStartLogging = new ToolStripButton();
            btnStopLogging = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            btnClearTerminal = new ToolStripButton();
            btnTopMost = new ToolStripButton();
            msMain = new ODModules.MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            btnOpenLog = new ToolStripMenuItem();
            btnOpenLogLocation = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            btnSaveLog = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            btnMenuDispDataOnly = new ToolStripMenuItem();
            btnMenuDispTime = new ToolStripMenuItem();
            btnMenuDispDate = new ToolStripMenuItem();
            btnMenuDispDateTime = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            btnMenuClearTerminal = new ToolStripMenuItem();
            zoomToolStripMenuItem = new ToolStripMenuItem();
            btnMenuZoom050 = new ToolStripMenuItem();
            btnMenuZoom075 = new ToolStripMenuItem();
            btnMenuZoom100 = new ToolStripMenuItem();
            btnMenuZoom110 = new ToolStripMenuItem();
            btnMenuZoom120 = new ToolStripMenuItem();
            btnMenuZoom150 = new ToolStripMenuItem();
            btnMenuZoom200 = new ToolStripMenuItem();
            btnMenuZoom300 = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            btnMenuTopMost = new ToolStripMenuItem();
            channelToolStripMenuItem = new ToolStripMenuItem();
            outputInMasterTerminalToolStripMenuItem = new ToolStripMenuItem();
            modbusMasterToolStripMenuItem = new ToolStripMenuItem();
            allowEscapeCharToolStripMenuItem = new ToolStripMenuItem();
            btnMenuTextFormat = new ToolStripMenuItem();
            btnOptFrmLineNone = new ToolStripMenuItem();
            btnOptFrmLineLF = new ToolStripMenuItem();
            btnOptFrmLineCRLF = new ToolStripMenuItem();
            btnOptFrmLineCR = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            connectToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            propertiesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            btnChannelPort = new ToolStripMenuItem();
            btnChannelBaudVals = new ToolStripMenuItem();
            btnChannelDataBits = new ToolStripMenuItem();
            btnChanDB5 = new ToolStripMenuItem();
            btnChanDB6 = new ToolStripMenuItem();
            btnChanDB7 = new ToolStripMenuItem();
            btnChanDB8 = new ToolStripMenuItem();
            btnChannelParity = new ToolStripMenuItem();
            btnChannelNoParity = new ToolStripMenuItem();
            btnChannelEvenParity = new ToolStripMenuItem();
            btnChannelOddParity = new ToolStripMenuItem();
            btnChannelSpaceParity = new ToolStripMenuItem();
            btnChannelMarkParity = new ToolStripMenuItem();
            btnChannelStopBits = new ToolStripMenuItem();
            btnChannelStopBits1 = new ToolStripMenuItem();
            btnChannelStopBits15 = new ToolStripMenuItem();
            btnChannelStopBits2 = new ToolStripMenuItem();
            btnChannelFlowCtrl = new ToolStripMenuItem();
            btnChannelFlowNone = new ToolStripMenuItem();
            btnChannelFlowXONXOFF = new ToolStripMenuItem();
            btnChannelFlowRTSCTS = new ToolStripMenuItem();
            btnChannelFlowDSRDTR = new ToolStripMenuItem();
            toolStripSeparator10 = new ToolStripSeparator();
            btnChannelInputFormat = new ToolStripMenuItem();
            btnChannelOutputFormat = new ToolStripMenuItem();
            loggingToolStripMenuItem = new ToolStripMenuItem();
            btnStartLog = new ToolStripMenuItem();
            btnStopLog = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            windowToolStripMenuItem = new ToolStripMenuItem();
            windowManagerToolStripMenuItem = new ToolStripMenuItem();
            LogUpdater = new System.Windows.Forms.Timer(components);
            cmTerminal.SuspendLayout();
            tsMain.SuspendLayout();
            msMain.SuspendLayout();
            SuspendLayout();
            // 
            // Output
            // 
            Output.AlignEntryWithOutput = true;
            Output.AllowCommandEntry = true;
            Output.AllowMouseSelection = false;
            Output.AllowMouseWheelZoom = false;
            Output.BufferLength = 10000;
            Output.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            Output.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            Output.ContextMenuStrip = cmTerminal;
            Output.CursorFlashSpeed = 0.5F;
            Output.Dock = DockStyle.Fill;
            Output.ExtraLineAfterCommandEntered = false;
            Output.FlashCursor = false;
            Output.Font = new Font("Consolas", 9F);
            Output.ForeColor = Color.FromArgb(255, 255, 192);
            Output.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            Output.LineFormatting = true;
            Output.Location = new Point(0, 86);
            Output.Margin = new Padding(6);
            Output.MaximumLength = 100;
            Output.Name = "Output";
            Output.OriginBackColor = Color.FromArgb(20, 20, 20);
            Output.OriginForeColor = Color.Silver;
            Output.OriginLength = 5;
            Output.OriginLineColor = Color.FromArgb(64, 64, 64);
            Output.Padding = new Padding(9, 11, 0, 0);
            Output.PegEntryToBottom = true;
            Output.PrintOnEntry = true;
            Output.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            Output.ScrollBarNorth = Color.FromArgb(64, 64, 64);
            Output.ScrollBarSouth = Color.FromArgb(64, 64, 64);
            Output.SecondaryFont = new Font("Segoe UI", 9F);
            Output.SelectionColor = Color.FromArgb(47, 47, 74);
            Output.ShowOrigin = false;
            Output.Size = new Size(799, 605);
            Output.TabIndex = 1;
            Output.TimeStampForeColor = Color.Gray;
            Output.TimeStamps = ODModules.ConsoleInterface.TimeStampFormat.NoTimeStamps;
            Output.VerScroll = 0;
            Output.Zoom = 100;
            Output.CommandEntered += Output_CommandEntered;
            // 
            // cmTerminal
            // 
            cmTerminal.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmTerminal.BorderColor = Color.Black;
            cmTerminal.DropShadowEnabled = false;
            cmTerminal.ForeColor = Color.White;
            cmTerminal.ImageScalingSize = new Size(32, 32);
            cmTerminal.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmTerminal.Items.AddRange(new ToolStripItem[] { clearTerminalToolStripMenuItem, toolStripSeparator11, copyToolStripMenuItem1, pasteToolStripMenuItem1, deleteToolStripMenuItem1 });
            cmTerminal.MenuBackColorNorth = Color.DodgerBlue;
            cmTerminal.MenuBackColorSouth = Color.DodgerBlue;
            cmTerminal.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmTerminal.Name = "cmTerminal";
            cmTerminal.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmTerminal.ShowInsetShadow = false;
            cmTerminal.ShowItemInsetShadow = true;
            cmTerminal.Size = new Size(301, 206);
            // 
            // clearTerminalToolStripMenuItem
            // 
            clearTerminalToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            clearTerminalToolStripMenuItem.Name = "clearTerminalToolStripMenuItem";
            clearTerminalToolStripMenuItem.Size = new Size(300, 38);
            clearTerminalToolStripMenuItem.Text = "C&lear Terminal";
            clearTerminalToolStripMenuItem.Click += clearTerminalToolStripMenuItem_Click;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(297, 6);
            // 
            // copyToolStripMenuItem1
            // 
            copyToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            copyToolStripMenuItem1.Size = new Size(300, 38);
            copyToolStripMenuItem1.Text = "&Copy";
            copyToolStripMenuItem1.Click += copyToolStripMenuItem1_Click;
            // 
            // pasteToolStripMenuItem1
            // 
            pasteToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            pasteToolStripMenuItem1.Size = new Size(300, 38);
            pasteToolStripMenuItem1.Text = "&Paste";
            pasteToolStripMenuItem1.Click += pasteToolStripMenuItem1_Click;
            // 
            // deleteToolStripMenuItem1
            // 
            deleteToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            deleteToolStripMenuItem1.Size = new Size(300, 38);
            deleteToolStripMenuItem1.Text = "&Delete";
            deleteToolStripMenuItem1.Click += deleteToolStripMenuItem1_Click;
            // 
            // tsMain
            // 
            tsMain.BackColorNorth = Color.FromArgb(31, 31, 31);
            tsMain.BackColorSouth = Color.FromArgb(31, 31, 31);
            tsMain.BorderColor = Color.WhiteSmoke;
            tsMain.ImageScalingSize = new Size(32, 32);
            tsMain.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemForeColor = Color.White;
            tsMain.Items.AddRange(new ToolStripItem[] { ddbDisplayTime, toolStripSeparator1, btnStartLogging, btnStopLogging, toolStripSeparator6, btnClearTerminal, btnTopMost });
            tsMain.ItemSelectedBackColorNorth = Color.White;
            tsMain.ItemSelectedBackColorSouth = Color.White;
            tsMain.ItemSelectedForeColor = Color.Black;
            tsMain.Location = new Point(0, 44);
            tsMain.MenuBackColorNorth = Color.FromArgb(31, 31, 31);
            tsMain.MenuBackColorSouth = Color.FromArgb(31, 31, 31);
            tsMain.MenuBorderColor = Color.WhiteSmoke;
            tsMain.MenuSeparatorColor = Color.WhiteSmoke;
            tsMain.MenuSymbolColor = Color.WhiteSmoke;
            tsMain.Name = "tsMain";
            tsMain.Padding = new Padding(0, 0, 4, 0);
            tsMain.RoundedToolStrip = false;
            tsMain.ShowBorder = false;
            tsMain.Size = new Size(799, 42);
            tsMain.StripItemSelectedBackColorNorth = Color.White;
            tsMain.StripItemSelectedBackColorSouth = Color.White;
            tsMain.TabIndex = 2;
            tsMain.Text = "toolStrip1";
            // 
            // ddbDisplayTime
            // 
            ddbDisplayTime.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ddbDisplayTime.DropDownItems.AddRange(new ToolStripItem[] { dataOnlyToolStripMenuItem, timeStampsToolStripMenuItem, dateStampsToolStripMenuItem, dateTimeStampsToolStripMenuItem });
            ddbDisplayTime.ForeColor = Color.White;
            ddbDisplayTime.Image = (Image)resources.GetObject("ddbDisplayTime.Image");
            ddbDisplayTime.ImageScaling = ToolStripItemImageScaling.None;
            ddbDisplayTime.ImageTransparentColor = Color.Magenta;
            ddbDisplayTime.Name = "ddbDisplayTime";
            ddbDisplayTime.Size = new Size(142, 36);
            ddbDisplayTime.Tag = "0";
            ddbDisplayTime.Text = "Data Only";
            // 
            // dataOnlyToolStripMenuItem
            // 
            dataOnlyToolStripMenuItem.Checked = true;
            dataOnlyToolStripMenuItem.CheckOnClick = true;
            dataOnlyToolStripMenuItem.CheckState = CheckState.Checked;
            dataOnlyToolStripMenuItem.ForeColor = Color.White;
            dataOnlyToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            dataOnlyToolStripMenuItem.Name = "dataOnlyToolStripMenuItem";
            dataOnlyToolStripMenuItem.Size = new Size(343, 44);
            dataOnlyToolStripMenuItem.Tag = "0";
            dataOnlyToolStripMenuItem.Text = "Data Only";
            dataOnlyToolStripMenuItem.Click += dataOnlyToolStripMenuItem_Click;
            // 
            // timeStampsToolStripMenuItem
            // 
            timeStampsToolStripMenuItem.CheckOnClick = true;
            timeStampsToolStripMenuItem.ForeColor = Color.White;
            timeStampsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            timeStampsToolStripMenuItem.Name = "timeStampsToolStripMenuItem";
            timeStampsToolStripMenuItem.Size = new Size(343, 44);
            timeStampsToolStripMenuItem.Tag = "1";
            timeStampsToolStripMenuItem.Text = "Time Stamps";
            timeStampsToolStripMenuItem.Click += timeStampsToolStripMenuItem_Click;
            // 
            // dateStampsToolStripMenuItem
            // 
            dateStampsToolStripMenuItem.CheckOnClick = true;
            dateStampsToolStripMenuItem.ForeColor = Color.White;
            dateStampsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            dateStampsToolStripMenuItem.Name = "dateStampsToolStripMenuItem";
            dateStampsToolStripMenuItem.Size = new Size(343, 44);
            dateStampsToolStripMenuItem.Tag = "3";
            dateStampsToolStripMenuItem.Text = "Date Stamps";
            dateStampsToolStripMenuItem.Click += dateStampsToolStripMenuItem_Click;
            // 
            // dateTimeStampsToolStripMenuItem
            // 
            dateTimeStampsToolStripMenuItem.CheckOnClick = true;
            dateTimeStampsToolStripMenuItem.ForeColor = Color.White;
            dateTimeStampsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            dateTimeStampsToolStripMenuItem.Name = "dateTimeStampsToolStripMenuItem";
            dateTimeStampsToolStripMenuItem.Size = new Size(343, 44);
            dateTimeStampsToolStripMenuItem.Tag = "4";
            dateTimeStampsToolStripMenuItem.Text = "Date/Time Stamps";
            dateTimeStampsToolStripMenuItem.Click += dateTimeStampsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 42);
            // 
            // btnStartLogging
            // 
            btnStartLogging.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStartLogging.Enabled = false;
            btnStartLogging.Image = (Image)resources.GetObject("btnStartLogging.Image");
            btnStartLogging.ImageScaling = ToolStripItemImageScaling.None;
            btnStartLogging.ImageTransparentColor = Color.Magenta;
            btnStartLogging.Name = "btnStartLogging";
            btnStartLogging.Size = new Size(46, 36);
            btnStartLogging.Text = "Start Logging";
            btnStartLogging.Click += btnStartLogging_Click;
            // 
            // btnStopLogging
            // 
            btnStopLogging.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStopLogging.Enabled = false;
            btnStopLogging.Image = (Image)resources.GetObject("btnStopLogging.Image");
            btnStopLogging.ImageScaling = ToolStripItemImageScaling.None;
            btnStopLogging.ImageTransparentColor = Color.Magenta;
            btnStopLogging.Name = "btnStopLogging";
            btnStopLogging.Size = new Size(46, 36);
            btnStopLogging.Text = "Stop Logging";
            btnStopLogging.Click += btnStopLogging_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 42);
            // 
            // btnClearTerminal
            // 
            btnClearTerminal.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnClearTerminal.Image = (Image)resources.GetObject("btnClearTerminal.Image");
            btnClearTerminal.ImageScaling = ToolStripItemImageScaling.None;
            btnClearTerminal.ImageTransparentColor = Color.Magenta;
            btnClearTerminal.Name = "btnClearTerminal";
            btnClearTerminal.Size = new Size(46, 36);
            btnClearTerminal.Text = "Clear Terminal";
            btnClearTerminal.Click += btnClearTerminal_Click;
            // 
            // btnTopMost
            // 
            btnTopMost.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnTopMost.Image = (Image)resources.GetObject("btnTopMost.Image");
            btnTopMost.ImageScaling = ToolStripItemImageScaling.None;
            btnTopMost.ImageTransparentColor = Color.Magenta;
            btnTopMost.Name = "btnTopMost";
            btnTopMost.Size = new Size(46, 36);
            btnTopMost.Text = "Window Top Most";
            btnTopMost.Click += toolStripButton2_Click;
            // 
            // msMain
            // 
            msMain.BackColorNorth = Color.FromArgb(31, 31, 31);
            msMain.BackColorNorthFadeIn = Color.FromArgb(31, 31, 31);
            msMain.BackColorSouth = Color.FromArgb(31, 31, 31);
            msMain.Fade = true;
            msMain.ImageScalingSize = new Size(32, 32);
            msMain.ItemForeColor = Color.White;
            msMain.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem, channelToolStripMenuItem, loggingToolStripMenuItem, toolsToolStripMenuItem, windowToolStripMenuItem });
            msMain.ItemSelectedBackColorNorth = Color.White;
            msMain.ItemSelectedBackColorSouth = Color.White;
            msMain.ItemSelectedForeColor = Color.Black;
            msMain.Location = new Point(0, 0);
            msMain.MenuBackColorNorth = Color.FromArgb(31, 31, 31);
            msMain.MenuBackColorSouth = Color.FromArgb(31, 31, 31);
            msMain.MenuBorderColor = Color.WhiteSmoke;
            msMain.MenuSeparatorColor = Color.WhiteSmoke;
            msMain.MenuSymbolColor = Color.WhiteSmoke;
            msMain.Name = "msMain";
            msMain.Padding = new Padding(11, 4, 0, 4);
            msMain.Size = new Size(799, 44);
            msMain.StripItemSelectedBackColorNorth = Color.White;
            msMain.StripItemSelectedBackColorSouth = Color.White;
            msMain.TabIndex = 3;
            msMain.Text = "menuStrip1";
            msMain.UseNorthFadeIn = false;
            msMain.ItemClicked += msMain_ItemClicked;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnOpenLog, btnOpenLogLocation, toolStripSeparator5, btnSaveLog, toolStripSeparator3, exitToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = Color.White;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 36);
            fileToolStripMenuItem.Text = "&File";
            // 
            // btnOpenLog
            // 
            btnOpenLog.ForeColor = Color.White;
            btnOpenLog.Image = (Image)resources.GetObject("btnOpenLog.Image");
            btnOpenLog.ImageScaling = ToolStripItemImageScaling.None;
            btnOpenLog.ImageTransparentColor = Color.Magenta;
            btnOpenLog.Name = "btnOpenLog";
            btnOpenLog.ShortcutKeys = Keys.Control | Keys.O;
            btnOpenLog.Size = new Size(381, 44);
            btnOpenLog.Text = "&Open Log File";
            btnOpenLog.Click += openToolStripMenuItem_Click;
            // 
            // btnOpenLogLocation
            // 
            btnOpenLogLocation.Enabled = false;
            btnOpenLogLocation.ForeColor = Color.White;
            btnOpenLogLocation.ImageScaling = ToolStripItemImageScaling.None;
            btnOpenLogLocation.Name = "btnOpenLogLocation";
            btnOpenLogLocation.Size = new Size(381, 44);
            btnOpenLogLocation.Text = "Open &Log Location";
            btnOpenLogLocation.Click += btnOpenLogLocation_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(378, 6);
            // 
            // btnSaveLog
            // 
            btnSaveLog.ForeColor = Color.White;
            btnSaveLog.Image = (Image)resources.GetObject("btnSaveLog.Image");
            btnSaveLog.ImageScaling = ToolStripItemImageScaling.None;
            btnSaveLog.ImageTransparentColor = Color.Magenta;
            btnSaveLog.Name = "btnSaveLog";
            btnSaveLog.ShortcutKeys = Keys.Control | Keys.S;
            btnSaveLog.Size = new Size(381, 44);
            btnSaveLog.Text = "&Save Log File";
            btnSaveLog.Click += btnSaveLog_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(378, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.ForeColor = Color.White;
            exitToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(381, 44);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem });
            editToolStripMenuItem.ForeColor = Color.White;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(74, 36);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ForeColor = Color.White;
            copyToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(284, 44);
            copyToolStripMenuItem.Text = "&Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ForeColor = Color.White;
            pasteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(284, 44);
            pasteToolStripMenuItem.Text = "&Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.ForeColor = Color.White;
            deleteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteToolStripMenuItem.Size = new Size(284, 44);
            deleteToolStripMenuItem.Text = "&Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnMenuDispDataOnly, btnMenuDispTime, btnMenuDispDate, btnMenuDispDateTime, toolStripSeparator2, btnMenuClearTerminal, zoomToolStripMenuItem, toolStripSeparator4, btnMenuTopMost });
            viewToolStripMenuItem.ForeColor = Color.White;
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(85, 36);
            viewToolStripMenuItem.Text = "&View";
            // 
            // btnMenuDispDataOnly
            // 
            btnMenuDispDataOnly.Checked = true;
            btnMenuDispDataOnly.CheckState = CheckState.Checked;
            btnMenuDispDataOnly.ForeColor = Color.White;
            btnMenuDispDataOnly.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuDispDataOnly.Name = "btnMenuDispDataOnly";
            btnMenuDispDataOnly.ShortcutKeys = Keys.Alt | Keys.D1;
            btnMenuDispDataOnly.Size = new Size(415, 44);
            btnMenuDispDataOnly.Tag = "0";
            btnMenuDispDataOnly.Text = "Data &Only";
            btnMenuDispDataOnly.Click += dataOnlyToolStripMenuItem1_Click;
            // 
            // btnMenuDispTime
            // 
            btnMenuDispTime.ForeColor = Color.White;
            btnMenuDispTime.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuDispTime.Name = "btnMenuDispTime";
            btnMenuDispTime.ShortcutKeys = Keys.Alt | Keys.D2;
            btnMenuDispTime.Size = new Size(415, 44);
            btnMenuDispTime.Tag = "1";
            btnMenuDispTime.Text = "&Time Stamps";
            btnMenuDispTime.Click += btnMenuDispTime_Click;
            // 
            // btnMenuDispDate
            // 
            btnMenuDispDate.ForeColor = Color.White;
            btnMenuDispDate.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuDispDate.Name = "btnMenuDispDate";
            btnMenuDispDate.ShortcutKeys = Keys.Alt | Keys.D3;
            btnMenuDispDate.Size = new Size(415, 44);
            btnMenuDispDate.Tag = "3";
            btnMenuDispDate.Text = "&Date Stamps";
            btnMenuDispDate.Click += btnMenuDispDate_Click;
            // 
            // btnMenuDispDateTime
            // 
            btnMenuDispDateTime.ForeColor = Color.White;
            btnMenuDispDateTime.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuDispDateTime.Name = "btnMenuDispDateTime";
            btnMenuDispDateTime.ShortcutKeys = Keys.Alt | Keys.D4;
            btnMenuDispDateTime.Size = new Size(415, 44);
            btnMenuDispDateTime.Tag = "4";
            btnMenuDispDateTime.Text = "Date/Time &Stamps";
            btnMenuDispDateTime.Click += btnMenuDispDateTime_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(412, 6);
            // 
            // btnMenuClearTerminal
            // 
            btnMenuClearTerminal.ForeColor = Color.White;
            btnMenuClearTerminal.Name = "btnMenuClearTerminal";
            btnMenuClearTerminal.ShortcutKeys = Keys.Alt | Keys.Delete;
            btnMenuClearTerminal.Size = new Size(415, 44);
            btnMenuClearTerminal.Text = "Clear Terminal";
            btnMenuClearTerminal.Click += btnMenuClearTerminal_Click;
            // 
            // zoomToolStripMenuItem
            // 
            zoomToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnMenuZoom050, btnMenuZoom075, btnMenuZoom100, btnMenuZoom110, btnMenuZoom120, btnMenuZoom150, btnMenuZoom200, btnMenuZoom300 });
            zoomToolStripMenuItem.ForeColor = Color.White;
            zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            zoomToolStripMenuItem.Size = new Size(415, 44);
            zoomToolStripMenuItem.Text = "&Zoom";
            // 
            // btnMenuZoom050
            // 
            btnMenuZoom050.ForeColor = Color.White;
            btnMenuZoom050.Name = "btnMenuZoom050";
            btnMenuZoom050.Size = new Size(206, 44);
            btnMenuZoom050.Text = "50%";
            btnMenuZoom050.Click += btnMenuZoom050_Click;
            // 
            // btnMenuZoom075
            // 
            btnMenuZoom075.ForeColor = Color.White;
            btnMenuZoom075.Name = "btnMenuZoom075";
            btnMenuZoom075.Size = new Size(206, 44);
            btnMenuZoom075.Text = "75%";
            btnMenuZoom075.Click += btnMenuZoom075_Click;
            // 
            // btnMenuZoom100
            // 
            btnMenuZoom100.ForeColor = Color.White;
            btnMenuZoom100.Name = "btnMenuZoom100";
            btnMenuZoom100.Size = new Size(206, 44);
            btnMenuZoom100.Text = "100%";
            btnMenuZoom100.Click += btnMenuZoom100_Click;
            // 
            // btnMenuZoom110
            // 
            btnMenuZoom110.ForeColor = Color.White;
            btnMenuZoom110.Name = "btnMenuZoom110";
            btnMenuZoom110.Size = new Size(206, 44);
            btnMenuZoom110.Text = "110%";
            btnMenuZoom110.Click += btnMenuZoom110_Click;
            // 
            // btnMenuZoom120
            // 
            btnMenuZoom120.ForeColor = Color.White;
            btnMenuZoom120.Name = "btnMenuZoom120";
            btnMenuZoom120.Size = new Size(206, 44);
            btnMenuZoom120.Text = "120%";
            btnMenuZoom120.Click += btnMenuZoom120_Click;
            // 
            // btnMenuZoom150
            // 
            btnMenuZoom150.ForeColor = Color.White;
            btnMenuZoom150.Name = "btnMenuZoom150";
            btnMenuZoom150.Size = new Size(206, 44);
            btnMenuZoom150.Text = "150%";
            btnMenuZoom150.Click += btnMenuZoom150_Click;
            // 
            // btnMenuZoom200
            // 
            btnMenuZoom200.ForeColor = Color.White;
            btnMenuZoom200.Name = "btnMenuZoom200";
            btnMenuZoom200.Size = new Size(206, 44);
            btnMenuZoom200.Text = "200%";
            btnMenuZoom200.Click += btnMenuZoom200_Click;
            // 
            // btnMenuZoom300
            // 
            btnMenuZoom300.ForeColor = Color.White;
            btnMenuZoom300.Name = "btnMenuZoom300";
            btnMenuZoom300.Size = new Size(206, 44);
            btnMenuZoom300.Text = "300%";
            btnMenuZoom300.Click += btnMenuZoom300_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(412, 6);
            // 
            // btnMenuTopMost
            // 
            btnMenuTopMost.ForeColor = Color.White;
            btnMenuTopMost.Name = "btnMenuTopMost";
            btnMenuTopMost.Size = new Size(415, 44);
            btnMenuTopMost.Text = "Top Most";
            btnMenuTopMost.Click += topMostToolStripMenuItem_Click;
            // 
            // channelToolStripMenuItem
            // 
            channelToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { outputInMasterTerminalToolStripMenuItem, modbusMasterToolStripMenuItem, allowEscapeCharToolStripMenuItem, btnMenuTextFormat, toolStripSeparator7, connectToolStripMenuItem, disconnectToolStripMenuItem, toolStripSeparator8, propertiesToolStripMenuItem, toolStripSeparator9, btnChannelPort, btnChannelBaudVals, btnChannelDataBits, btnChannelParity, btnChannelStopBits, btnChannelFlowCtrl, toolStripSeparator10, btnChannelInputFormat, btnChannelOutputFormat });
            channelToolStripMenuItem.ForeColor = Color.White;
            channelToolStripMenuItem.Name = "channelToolStripMenuItem";
            channelToolStripMenuItem.Size = new Size(122, 36);
            channelToolStripMenuItem.Text = "&Channel";
            // 
            // outputInMasterTerminalToolStripMenuItem
            // 
            outputInMasterTerminalToolStripMenuItem.Checked = true;
            outputInMasterTerminalToolStripMenuItem.CheckState = CheckState.Checked;
            outputInMasterTerminalToolStripMenuItem.ForeColor = Color.White;
            outputInMasterTerminalToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            outputInMasterTerminalToolStripMenuItem.Name = "outputInMasterTerminalToolStripMenuItem";
            outputInMasterTerminalToolStripMenuItem.Size = new Size(428, 44);
            outputInMasterTerminalToolStripMenuItem.Text = "Output in Master Termina&l";
            outputInMasterTerminalToolStripMenuItem.Click += outputInMasterTerminalToolStripMenuItem_Click;
            // 
            // modbusMasterToolStripMenuItem
            // 
            modbusMasterToolStripMenuItem.ForeColor = Color.White;
            modbusMasterToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            modbusMasterToolStripMenuItem.Name = "modbusMasterToolStripMenuItem";
            modbusMasterToolStripMenuItem.Size = new Size(428, 44);
            modbusMasterToolStripMenuItem.Text = "&Modbus Master";
            modbusMasterToolStripMenuItem.Click += modbusMasterToolStripMenuItem_Click;
            // 
            // allowEscapeCharToolStripMenuItem
            // 
            allowEscapeCharToolStripMenuItem.Checked = true;
            allowEscapeCharToolStripMenuItem.CheckState = CheckState.Checked;
            allowEscapeCharToolStripMenuItem.ForeColor = Color.White;
            allowEscapeCharToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            allowEscapeCharToolStripMenuItem.Name = "allowEscapeCharToolStripMenuItem";
            allowEscapeCharToolStripMenuItem.Size = new Size(428, 44);
            allowEscapeCharToolStripMenuItem.Text = "Allow Escape Characters";
            allowEscapeCharToolStripMenuItem.Click += allowEscapeCharToolStripMenuItem_Click;
            // 
            // btnMenuTextFormat
            // 
            btnMenuTextFormat.DropDownItems.AddRange(new ToolStripItem[] { btnOptFrmLineNone, btnOptFrmLineLF, btnOptFrmLineCRLF, btnOptFrmLineCR });
            btnMenuTextFormat.ForeColor = Color.White;
            btnMenuTextFormat.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuTextFormat.Name = "btnMenuTextFormat";
            btnMenuTextFormat.Size = new Size(428, 44);
            btnMenuTextFormat.Text = "&Text Formatting";
            // 
            // btnOptFrmLineNone
            // 
            btnOptFrmLineNone.Checked = true;
            btnOptFrmLineNone.CheckState = CheckState.Checked;
            btnOptFrmLineNone.ForeColor = Color.White;
            btnOptFrmLineNone.ImageScaling = ToolStripItemImageScaling.None;
            btnOptFrmLineNone.Name = "btnOptFrmLineNone";
            btnOptFrmLineNone.Size = new Size(206, 44);
            btnOptFrmLineNone.Tag = "frmLineNone";
            btnOptFrmLineNone.Text = "&None";
            btnOptFrmLineNone.Click += btnOptFrmLineNone_Click;
            // 
            // btnOptFrmLineLF
            // 
            btnOptFrmLineLF.ForeColor = Color.White;
            btnOptFrmLineLF.ImageScaling = ToolStripItemImageScaling.None;
            btnOptFrmLineLF.Name = "btnOptFrmLineLF";
            btnOptFrmLineLF.Size = new Size(206, 44);
            btnOptFrmLineLF.Tag = "frmLineLF";
            btnOptFrmLineLF.Text = "&LF";
            btnOptFrmLineLF.Click += btnOptFrmLineLF_Click;
            // 
            // btnOptFrmLineCRLF
            // 
            btnOptFrmLineCRLF.ForeColor = Color.White;
            btnOptFrmLineCRLF.ImageScaling = ToolStripItemImageScaling.None;
            btnOptFrmLineCRLF.Name = "btnOptFrmLineCRLF";
            btnOptFrmLineCRLF.Size = new Size(206, 44);
            btnOptFrmLineCRLF.Tag = "frmLineCRLF";
            btnOptFrmLineCRLF.Text = "C&R LF";
            btnOptFrmLineCRLF.Click += btnOptFrmLineCRLF_Click;
            // 
            // btnOptFrmLineCR
            // 
            btnOptFrmLineCR.ForeColor = Color.White;
            btnOptFrmLineCR.ImageScaling = ToolStripItemImageScaling.None;
            btnOptFrmLineCR.Name = "btnOptFrmLineCR";
            btnOptFrmLineCR.Size = new Size(206, 44);
            btnOptFrmLineCR.Tag = "frmLineCR";
            btnOptFrmLineCR.Text = "&CR";
            btnOptFrmLineCR.Click += btnOptFrmLineCR_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(425, 6);
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.ForeColor = Color.White;
            connectToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D1;
            connectToolStripMenuItem.Size = new Size(428, 44);
            connectToolStripMenuItem.Text = "&Connect";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Enabled = false;
            disconnectToolStripMenuItem.ForeColor = Color.White;
            disconnectToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D2;
            disconnectToolStripMenuItem.Size = new Size(428, 44);
            disconnectToolStripMenuItem.Text = "Disc&onnect";
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(425, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            propertiesToolStripMenuItem.ForeColor = Color.White;
            propertiesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            propertiesToolStripMenuItem.Size = new Size(428, 44);
            propertiesToolStripMenuItem.Text = "Properties";
            propertiesToolStripMenuItem.Click += propertiesToolStripMenuItem_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(425, 6);
            // 
            // btnChannelPort
            // 
            btnChannelPort.ForeColor = Color.White;
            btnChannelPort.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelPort.Name = "btnChannelPort";
            btnChannelPort.Size = new Size(428, 44);
            btnChannelPort.Text = "&Port";
            btnChannelPort.DropDownOpening += btnChannelPort_DropDownOpening;
            // 
            // btnChannelBaudVals
            // 
            btnChannelBaudVals.ForeColor = Color.White;
            btnChannelBaudVals.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelBaudVals.Name = "btnChannelBaudVals";
            btnChannelBaudVals.Size = new Size(428, 44);
            btnChannelBaudVals.Text = "&Baud Rate";
            // 
            // btnChannelDataBits
            // 
            btnChannelDataBits.DropDownItems.AddRange(new ToolStripItem[] { btnChanDB5, btnChanDB6, btnChanDB7, btnChanDB8 });
            btnChannelDataBits.ForeColor = Color.White;
            btnChannelDataBits.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelDataBits.Name = "btnChannelDataBits";
            btnChannelDataBits.Size = new Size(428, 44);
            btnChannelDataBits.Text = "&Data Bits";
            // 
            // btnChanDB5
            // 
            btnChanDB5.ForeColor = Color.White;
            btnChanDB5.ImageScaling = ToolStripItemImageScaling.None;
            btnChanDB5.Name = "btnChanDB5";
            btnChanDB5.Size = new Size(205, 44);
            btnChanDB5.Tag = "5";
            btnChanDB5.Text = "&5 Bits";
            btnChanDB5.Click += btnChanDB5_Click;
            // 
            // btnChanDB6
            // 
            btnChanDB6.ForeColor = Color.White;
            btnChanDB6.ImageScaling = ToolStripItemImageScaling.None;
            btnChanDB6.Name = "btnChanDB6";
            btnChanDB6.Size = new Size(205, 44);
            btnChanDB6.Tag = "6";
            btnChanDB6.Text = "&6 Bits";
            btnChanDB6.Click += btnChanDB6_Click;
            // 
            // btnChanDB7
            // 
            btnChanDB7.ForeColor = Color.White;
            btnChanDB7.ImageScaling = ToolStripItemImageScaling.None;
            btnChanDB7.Name = "btnChanDB7";
            btnChanDB7.Size = new Size(205, 44);
            btnChanDB7.Tag = "7";
            btnChanDB7.Text = "&7 Bits";
            btnChanDB7.Click += btnChanDB7_Click;
            // 
            // btnChanDB8
            // 
            btnChanDB8.Checked = true;
            btnChanDB8.CheckState = CheckState.Checked;
            btnChanDB8.ForeColor = Color.White;
            btnChanDB8.ImageScaling = ToolStripItemImageScaling.None;
            btnChanDB8.Name = "btnChanDB8";
            btnChanDB8.Size = new Size(205, 44);
            btnChanDB8.Tag = "8";
            btnChanDB8.Text = "&8 Bits";
            btnChanDB8.Click += btnChanDB8_Click;
            // 
            // btnChannelParity
            // 
            btnChannelParity.DropDownItems.AddRange(new ToolStripItem[] { btnChannelNoParity, btnChannelEvenParity, btnChannelOddParity, btnChannelSpaceParity, btnChannelMarkParity });
            btnChannelParity.ForeColor = Color.White;
            btnChannelParity.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelParity.Name = "btnChannelParity";
            btnChannelParity.Size = new Size(428, 44);
            btnChannelParity.Text = "P&arity";
            // 
            // btnChannelNoParity
            // 
            btnChannelNoParity.Checked = true;
            btnChannelNoParity.CheckState = CheckState.Checked;
            btnChannelNoParity.ForeColor = Color.White;
            btnChannelNoParity.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelNoParity.Name = "btnChannelNoParity";
            btnChannelNoParity.Size = new Size(275, 44);
            btnChannelNoParity.Tag = "N";
            btnChannelNoParity.Text = "&No Parity";
            btnChannelNoParity.Click += btnChannelNoParity_Click;
            // 
            // btnChannelEvenParity
            // 
            btnChannelEvenParity.ForeColor = Color.White;
            btnChannelEvenParity.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelEvenParity.Name = "btnChannelEvenParity";
            btnChannelEvenParity.Size = new Size(275, 44);
            btnChannelEvenParity.Tag = "E";
            btnChannelEvenParity.Text = "&Even Parity";
            btnChannelEvenParity.Click += btnChannelEvenParity_Click;
            // 
            // btnChannelOddParity
            // 
            btnChannelOddParity.ForeColor = Color.White;
            btnChannelOddParity.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelOddParity.Name = "btnChannelOddParity";
            btnChannelOddParity.Size = new Size(275, 44);
            btnChannelOddParity.Tag = "O";
            btnChannelOddParity.Text = "&Odd Parity";
            btnChannelOddParity.Click += btnChannelOddParity_Click;
            // 
            // btnChannelSpaceParity
            // 
            btnChannelSpaceParity.ForeColor = Color.White;
            btnChannelSpaceParity.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelSpaceParity.Name = "btnChannelSpaceParity";
            btnChannelSpaceParity.Size = new Size(275, 44);
            btnChannelSpaceParity.Tag = "S";
            btnChannelSpaceParity.Text = "&Space Parity";
            btnChannelSpaceParity.Click += btnChannelSpaceParity_Click;
            // 
            // btnChannelMarkParity
            // 
            btnChannelMarkParity.ForeColor = Color.White;
            btnChannelMarkParity.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelMarkParity.Name = "btnChannelMarkParity";
            btnChannelMarkParity.Size = new Size(275, 44);
            btnChannelMarkParity.Tag = "M";
            btnChannelMarkParity.Text = "&Mark Parity";
            btnChannelMarkParity.Click += btnChannelMarkParity_Click;
            // 
            // btnChannelStopBits
            // 
            btnChannelStopBits.DropDownItems.AddRange(new ToolStripItem[] { btnChannelStopBits1, btnChannelStopBits15, btnChannelStopBits2 });
            btnChannelStopBits.ForeColor = Color.White;
            btnChannelStopBits.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelStopBits.Name = "btnChannelStopBits";
            btnChannelStopBits.Size = new Size(428, 44);
            btnChannelStopBits.Text = "S&top Bits";
            // 
            // btnChannelStopBits1
            // 
            btnChannelStopBits1.Checked = true;
            btnChannelStopBits1.CheckState = CheckState.Checked;
            btnChannelStopBits1.ForeColor = Color.White;
            btnChannelStopBits1.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelStopBits1.Name = "btnChannelStopBits1";
            btnChannelStopBits1.Size = new Size(278, 44);
            btnChannelStopBits1.Tag = "1";
            btnChannelStopBits1.Text = "&1 Stop Bit";
            btnChannelStopBits1.Click += btnChannelStopBits1_Click;
            // 
            // btnChannelStopBits15
            // 
            btnChannelStopBits15.ForeColor = Color.White;
            btnChannelStopBits15.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelStopBits15.Name = "btnChannelStopBits15";
            btnChannelStopBits15.Size = new Size(278, 44);
            btnChannelStopBits15.Tag = "1.5";
            btnChannelStopBits15.Text = "1.&5 Stop Bits";
            btnChannelStopBits15.Click += btnChannelStopBits15_Click;
            // 
            // btnChannelStopBits2
            // 
            btnChannelStopBits2.ForeColor = Color.White;
            btnChannelStopBits2.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelStopBits2.Name = "btnChannelStopBits2";
            btnChannelStopBits2.Size = new Size(278, 44);
            btnChannelStopBits2.Tag = "2";
            btnChannelStopBits2.Text = "&2 Stop Bits";
            btnChannelStopBits2.Click += btnChannelStopBits2_Click;
            // 
            // btnChannelFlowCtrl
            // 
            btnChannelFlowCtrl.DropDownItems.AddRange(new ToolStripItem[] { btnChannelFlowNone, btnChannelFlowXONXOFF, btnChannelFlowRTSCTS, btnChannelFlowDSRDTR });
            btnChannelFlowCtrl.ForeColor = Color.White;
            btnChannelFlowCtrl.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelFlowCtrl.Name = "btnChannelFlowCtrl";
            btnChannelFlowCtrl.Size = new Size(428, 44);
            btnChannelFlowCtrl.Text = "&Flow Control";
            // 
            // btnChannelFlowNone
            // 
            btnChannelFlowNone.Checked = true;
            btnChannelFlowNone.CheckState = CheckState.Checked;
            btnChannelFlowNone.ForeColor = Color.White;
            btnChannelFlowNone.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelFlowNone.Name = "btnChannelFlowNone";
            btnChannelFlowNone.Size = new Size(262, 44);
            btnChannelFlowNone.Tag = "cfNone";
            btnChannelFlowNone.Text = "&None";
            btnChannelFlowNone.Click += btnChannelFlowNone_Click;
            // 
            // btnChannelFlowXONXOFF
            // 
            btnChannelFlowXONXOFF.ForeColor = Color.White;
            btnChannelFlowXONXOFF.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelFlowXONXOFF.Name = "btnChannelFlowXONXOFF";
            btnChannelFlowXONXOFF.Size = new Size(262, 44);
            btnChannelFlowXONXOFF.Tag = "cfXONXOFF";
            btnChannelFlowXONXOFF.Text = "&XON/XOFF";
            btnChannelFlowXONXOFF.Click += btnChannelFlowXONXOFF_Click;
            // 
            // btnChannelFlowRTSCTS
            // 
            btnChannelFlowRTSCTS.ForeColor = Color.White;
            btnChannelFlowRTSCTS.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelFlowRTSCTS.Name = "btnChannelFlowRTSCTS";
            btnChannelFlowRTSCTS.Size = new Size(262, 44);
            btnChannelFlowRTSCTS.Tag = "cfRTSCTS";
            btnChannelFlowRTSCTS.Text = "&RTS/CTS";
            btnChannelFlowRTSCTS.Click += btnChannelFlowRTSCTS_Click;
            // 
            // btnChannelFlowDSRDTR
            // 
            btnChannelFlowDSRDTR.ForeColor = Color.White;
            btnChannelFlowDSRDTR.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelFlowDSRDTR.Name = "btnChannelFlowDSRDTR";
            btnChannelFlowDSRDTR.Size = new Size(262, 44);
            btnChannelFlowDSRDTR.Tag = "cfDSRSTR";
            btnChannelFlowDSRDTR.Text = "&DSR/DTR";
            btnChannelFlowDSRDTR.Click += btnChannelFlowDSRDTR_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(425, 6);
            // 
            // btnChannelInputFormat
            // 
            btnChannelInputFormat.ForeColor = Color.White;
            btnChannelInputFormat.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelInputFormat.Name = "btnChannelInputFormat";
            btnChannelInputFormat.Size = new Size(428, 44);
            btnChannelInputFormat.Text = "&Input Format";
            // 
            // btnChannelOutputFormat
            // 
            btnChannelOutputFormat.ForeColor = Color.White;
            btnChannelOutputFormat.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelOutputFormat.Name = "btnChannelOutputFormat";
            btnChannelOutputFormat.Size = new Size(428, 44);
            btnChannelOutputFormat.Text = "&Output Format";
            // 
            // loggingToolStripMenuItem
            // 
            loggingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnStartLog, btnStopLog });
            loggingToolStripMenuItem.ForeColor = Color.White;
            loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            loggingToolStripMenuItem.Size = new Size(121, 36);
            loggingToolStripMenuItem.Text = "&Logging";
            // 
            // btnStartLog
            // 
            btnStartLog.Enabled = false;
            btnStartLog.ForeColor = Color.White;
            btnStartLog.ImageScaling = ToolStripItemImageScaling.None;
            btnStartLog.Name = "btnStartLog";
            btnStartLog.ShortcutKeys = Keys.Control | Keys.Space;
            btnStartLog.Size = new Size(419, 44);
            btnStartLog.Text = "&Start Logging";
            btnStartLog.Click += btnStartLog_Click;
            // 
            // btnStopLog
            // 
            btnStopLog.Enabled = false;
            btnStopLog.ForeColor = Color.White;
            btnStopLog.ImageScaling = ToolStripItemImageScaling.None;
            btnStopLog.Name = "btnStopLog";
            btnStopLog.ShortcutKeys = Keys.Control | Keys.End;
            btnStopLog.Size = new Size(419, 44);
            btnStopLog.Text = "Stop &Logging";
            btnStopLog.Click += btnStopLog_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { optionsToolStripMenuItem });
            toolsToolStripMenuItem.ForeColor = Color.White;
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(89, 36);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.ForeColor = Color.White;
            optionsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(231, 44);
            optionsToolStripMenuItem.Text = "&Options";
            optionsToolStripMenuItem.Click += optionsToolStripMenuItem_Click;
            // 
            // windowToolStripMenuItem
            // 
            windowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { windowManagerToolStripMenuItem });
            windowToolStripMenuItem.ForeColor = Color.White;
            windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            windowToolStripMenuItem.Size = new Size(121, 36);
            windowToolStripMenuItem.Text = "&Window";
            // 
            // windowManagerToolStripMenuItem
            // 
            windowManagerToolStripMenuItem.ForeColor = Color.White;
            windowManagerToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            windowManagerToolStripMenuItem.Name = "windowManagerToolStripMenuItem";
            windowManagerToolStripMenuItem.Size = new Size(336, 44);
            windowManagerToolStripMenuItem.Text = "&Window Manager";
            windowManagerToolStripMenuItem.Click += windowManagerToolStripMenuItem_Click;
            // 
            // LogUpdater
            // 
            LogUpdater.Enabled = true;
            LogUpdater.Interval = 1000;
            LogUpdater.Tick += LogUpdater_Tick;
            // 
            // Terminal
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(799, 691);
            Controls.Add(Output);
            Controls.Add(tsMain);
            Controls.Add(msMain);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(0, 0);
            MainMenuStrip = msMain;
            Margin = new Padding(6);
            Name = "Terminal";
            Text = "Terminal";
            FormClosing += Terminal_FormClosing;
            FormClosed += Terminal_FormClosed;
            Load += Terminal_Load;
            SizeChanged += Terminal_SizeChanged;
            VisibleChanged += Terminal_VisibleChanged;
            KeyPress += Terminal_KeyPress;
            cmTerminal.ResumeLayout(false);
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem windowManagerToolStripMenuItem;
        private ToolStripMenuItem channelToolStripMenuItem;
        private ToolStripMenuItem btnMenuTextFormat;
        private ToolStripMenuItem btnOptFrmLineNone;
        private ToolStripMenuItem btnOptFrmLineLF;
        private ToolStripMenuItem btnOptFrmLineCRLF;
        private ToolStripMenuItem btnOptFrmLineCR;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ToolStripMenuItem modbusMasterToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem propertiesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem btnChannelPort;
        private ToolStripMenuItem btnChannelBaudVals;
        private ToolStripMenuItem btnChannelDataBits;
        private ToolStripMenuItem btnChannelParity;
        private ToolStripMenuItem btnChannelStopBits;
        private ToolStripMenuItem btnChannelFlowCtrl;
        private ToolStripMenuItem btnChanDB5;
        private ToolStripMenuItem btnChanDB6;
        private ToolStripMenuItem btnChanDB7;
        private ToolStripMenuItem btnChanDB8;
        private ToolStripMenuItem btnChannelNoParity;
        private ToolStripMenuItem btnChannelEvenParity;
        private ToolStripMenuItem btnChannelOddParity;
        private ToolStripMenuItem btnChannelSpaceParity;
        private ToolStripMenuItem btnChannelMarkParity;
        private ToolStripMenuItem btnChannelStopBits1;
        private ToolStripMenuItem btnChannelStopBits15;
        private ToolStripMenuItem btnChannelStopBits2;
        private ToolStripMenuItem btnChannelFlowNone;
        private ToolStripMenuItem btnChannelFlowXONXOFF;
        private ToolStripMenuItem btnChannelFlowRTSCTS;
        private ToolStripMenuItem btnChannelFlowDSRDTR;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem btnChannelInputFormat;
        private ToolStripMenuItem btnChannelOutputFormat;
        private ToolStripMenuItem outputInMasterTerminalToolStripMenuItem;
        private ToolStripMenuItem allowEscapeCharToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ODModules.ContextMenu cmTerminal;
        private ToolStripMenuItem clearTerminalToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem copyToolStripMenuItem1;
        private ToolStripMenuItem pasteToolStripMenuItem1;
        private ToolStripMenuItem deleteToolStripMenuItem1;
    }
}