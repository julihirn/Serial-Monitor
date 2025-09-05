namespace Serial_Monitor {
    partial class MainWindow {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            ODModules.Column column1 = new ODModules.Column();
            ODModules.Column column2 = new ODModules.Column();
            ODModules.Column column3 = new ODModules.Column();
            ODModules.Column column4 = new ODModules.Column();
            ODModules.ListItem listItem1 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem1 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem2 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem3 = new ODModules.ListSubItem();
            ODModules.Tab tab1 = new ODModules.Tab();
            tsMain = new ODModules.ToolStrip();
            ddbPorts = new ToolStripDropDownButton();
            toolStripSeparator1 = new ToolStripSeparator();
            ddbBAUDRate = new ToolStripDropDownButton();
            ddbBits = new ToolStripDropDownButton();
            btnBits5 = new ToolStripMenuItem();
            btnBits6 = new ToolStripMenuItem();
            btnBits7 = new ToolStripMenuItem();
            btnBits8 = new ToolStripMenuItem();
            ddbParity = new ToolStripDropDownButton();
            btnParityNone = new ToolStripMenuItem();
            btnParityEven = new ToolStripMenuItem();
            btnParityOdd = new ToolStripMenuItem();
            btnParitySpace = new ToolStripMenuItem();
            btnParityMark = new ToolStripMenuItem();
            ddbStopBits = new ToolStripDropDownButton();
            btnStopBitsNone = new ToolStripMenuItem();
            btnStopBits1 = new ToolStripMenuItem();
            btnStopBits15 = new ToolStripMenuItem();
            btnStopBits2 = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            btnConnect = new ToolStripButton();
            btnDisconnect = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            ddbInputFormat = new ToolStripDropDownButton();
            ddbOutputFormat = new ToolStripDropDownButton();
            toolStripSeparator4 = new ToolStripSeparator();
            btnRun = new ToolStripSplitButton();
            runFromStartToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator25 = new ToolStripSeparator();
            btnRunCursor = new ToolStripButton();
            btnPause = new ToolStripButton();
            btnStop = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            btnClearTerminal = new ToolStripButton();
            btnTopMost = new ToolStripButton();
            pnlRenamePanel = new Panel();
            textBox1 = new TextBox();
            panel2 = new Panel();
            button1 = new ODModules.Button();
            navigator1 = new ODModules.Navigator();
            cmChannels = new ODModules.ContextMenu();
            newChannelToolStripMenuItem = new ToolStripMenuItem();
            removeChannelToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator35 = new ToolStripSeparator();
            renameChannelToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator36 = new ToolStripSeparator();
            outputInTerminalToolStripMenuItem = new ToolStripMenuItem();
            modbusMasterToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator37 = new ToolStripSeparator();
            connectToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            lstStepProgram = new ODModules.ListControl();
            cmStepEditor = new ODModules.ContextMenu();
            addCommandToolStripMenuItem1 = new ToolStripMenuItem();
            removeSelectedToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator20 = new ToolStripSeparator();
            cutToolStripMenuItem1 = new ToolStripMenuItem();
            copyToolStripMenuItem1 = new ToolStripMenuItem();
            pasteToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator33 = new ToolStripSeparator();
            enableSelectedToolStripMenuItem1 = new ToolStripMenuItem();
            disableSelectedToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator21 = new ToolStripSeparator();
            runToolStripMenuItem = new ToolStripMenuItem();
            pauseToolStripMenuItem = new ToolStripMenuItem();
            stopToolStripMenuItem = new ToolStripMenuItem();
            msMain = new ODModules.MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            btnNewStep = new ToolStripMenuItem();
            btnOpenStep = new ToolStripMenuItem();
            btnOpenLocation = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            btnSaveStep = new ToolStripMenuItem();
            btnSaveAsStep = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            btnPrint = new ToolStripMenuItem();
            btnPrintPreview = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            btnRecentProjects = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            btnMenuExit = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator15 = new ToolStripSeparator();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            btnOptViewDataOnly = new ToolStripMenuItem();
            btnOptViewTime = new ToolStripMenuItem();
            btnOptViewDate = new ToolStripMenuItem();
            btnOptViewDateTime = new ToolStripMenuItem();
            toolStripSeparator16 = new ToolStripSeparator();
            btnOptViewSource = new ToolStripMenuItem();
            toolStripSeparator13 = new ToolStripSeparator();
            channelsToolStripMenuItem = new ToolStripMenuItem();
            btnMenuShowStepPrg = new ToolStripMenuItem();
            toolStripSeparator11 = new ToolStripSeparator();
            btnMenuClearTerminal = new ToolStripMenuItem();
            zoomToolStripMenuItem = new ToolStripMenuItem();
            btnZoom50 = new ToolStripMenuItem();
            btnZoom75 = new ToolStripMenuItem();
            btnZoom100 = new ToolStripMenuItem();
            btnZoom110 = new ToolStripMenuItem();
            btnZoom120 = new ToolStripMenuItem();
            btnZoom150 = new ToolStripMenuItem();
            btnZoom175 = new ToolStripMenuItem();
            btnZoom200 = new ToolStripMenuItem();
            btnZoom300 = new ToolStripMenuItem();
            toolStripSeparator12 = new ToolStripSeparator();
            btnMenuTopMost = new ToolStripMenuItem();
            btnMenuFullScreen = new ToolStripMenuItem();
            mitChannel = new ToolStripMenuItem();
            btnNewChannel = new ToolStripMenuItem();
            btnRemoveChannel = new ToolStripMenuItem();
            toolStripSeparator24 = new ToolStripSeparator();
            ddbChannels = new ToolStripMenuItem();
            btnRenameChannel = new ToolStripMenuItem();
            toolStripSeparator28 = new ToolStripSeparator();
            btnMenuOutputMaster = new ToolStripMenuItem();
            btnMenuModbusMaster = new ToolStripMenuItem();
            btnallowEscapeCharacters = new ToolStripMenuItem();
            btnMenuTextFormat = new ToolStripMenuItem();
            btnOptFrmLineNone = new ToolStripMenuItem();
            btnOptFrmLineLF = new ToolStripMenuItem();
            btnOptFrmLineCRLF = new ToolStripMenuItem();
            btnOptFrmLineCR = new ToolStripMenuItem();
            toolStripSeparator38 = new ToolStripSeparator();
            btnMenuOpenNewTerminal = new ToolStripMenuItem();
            toolStripSeparator23 = new ToolStripSeparator();
            scanPortsToolStripMenuItem = new ToolStripMenuItem();
            btnMenuConnect = new ToolStripMenuItem();
            btnMenuDisconnect = new ToolStripMenuItem();
            toolStripSeparator34 = new ToolStripSeparator();
            propertiesToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator43 = new ToolStripSeparator();
            btnChannelPort = new ToolStripMenuItem();
            btnChannelBaud = new ToolStripMenuItem();
            btnChannelDataBits = new ToolStripMenuItem();
            btnChanDB5 = new ToolStripMenuItem();
            btnChanDB6 = new ToolStripMenuItem();
            btnChanDB7 = new ToolStripMenuItem();
            btnChanDB = new ToolStripMenuItem();
            btnChannelParity = new ToolStripMenuItem();
            btnChannelNoParity = new ToolStripMenuItem();
            btnChannelEvenParity = new ToolStripMenuItem();
            btnChannelOddParity = new ToolStripMenuItem();
            btnChannelSpaceParity = new ToolStripMenuItem();
            btnChannelMarkParity = new ToolStripMenuItem();
            btnChannelStopBits = new ToolStripMenuItem();
            btnChannelStopBits0 = new ToolStripMenuItem();
            btnChannelStopBits1 = new ToolStripMenuItem();
            btnChannelStopBits15 = new ToolStripMenuItem();
            btnChannelStopBits2 = new ToolStripMenuItem();
            btnChannelFlowCtrl = new ToolStripMenuItem();
            btnChannelFlowNone = new ToolStripMenuItem();
            btnChannelFlowXONXOFF = new ToolStripMenuItem();
            btnChannelFlowRTSCTS = new ToolStripMenuItem();
            btnChannelFlowDSRDTR = new ToolStripMenuItem();
            toolStripSeparator32 = new ToolStripSeparator();
            btnChannelInputFormat = new ToolStripMenuItem();
            btnChannelOutputFormat = new ToolStripMenuItem();
            toolStripSeparator39 = new ToolStripSeparator();
            sendFileToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator41 = new ToolStripSeparator();
            resetCountersToolStripMenuItem = new ToolStripMenuItem();
            programToolStripMenuItem = new ToolStripMenuItem();
            addCommandToolStripMenuItem = new ToolStripMenuItem();
            addCommandAfterToolStripMenuItem = new ToolStripMenuItem();
            btnPrgRemoveStepLines = new ToolStripMenuItem();
            toolStripSeparator17 = new ToolStripSeparator();
            btnPrgMoveUp = new ToolStripMenuItem();
            btnPrgMoveDown = new ToolStripMenuItem();
            toolStripSeparator18 = new ToolStripSeparator();
            btnEnableSelected = new ToolStripMenuItem();
            btnToggleSelected = new ToolStripMenuItem();
            btnDisableSelected = new ToolStripMenuItem();
            toolStripSeparator19 = new ToolStripSeparator();
            setStepCursorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator22 = new ToolStripSeparator();
            activeProgramToolStripMenuItem = new ToolStripMenuItem();
            commandPalletToolStripMenuItem = new ToolStripMenuItem();
            variablesToolStripMenuItem = new ToolStripMenuItem();
            propertiesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator26 = new ToolStripSeparator();
            btnRunPrg = new ToolStripMenuItem();
            runProgramToolStripMenuItem = new ToolStripMenuItem();
            btnPausePrg = new ToolStripMenuItem();
            btnStopPrg = new ToolStripMenuItem();
            toolStripSeparator27 = new ToolStripSeparator();
            newProgramToolStripMenuItem = new ToolStripMenuItem();
            removeProgramToolStripMenuItem = new ToolStripMenuItem();
            extensionsToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            keyPadToolStripMenuItem = new ToolStripMenuItem();
            btnMonitor = new ToolStripMenuItem();
            modbusRegistersToolStripMenuItem = new ToolStripMenuItem();
            modbusQueryEditorToolStripMenuItem = new ToolStripMenuItem();
            oscilloscopeToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator14 = new ToolStripSeparator();
            textComparatorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator31 = new ToolStripSeparator();
            deviceManagerToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator40 = new ToolStripSeparator();
            customizeToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            windowToolStripMenuItem = new ToolStripMenuItem();
            btnWinWindowManager = new ToolStripMenuItem();
            btnWinCloseAll = new ToolStripMenuItem();
            toolStripSeparator42 = new ToolStripSeparator();
            helpToolStripMenuItem = new ToolStripMenuItem();
            contentsToolStripMenuItem = new ToolStripMenuItem();
            indexToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator10 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            cmStepPrg = new ODModules.ContextMenu();
            tmrProg = new System.Windows.Forms.Timer(components);
            pnlStepProgram = new ODModules.LabelPanel();
            thPrograms = new ODModules.TabHeader();
            pnlMainConsole = new Panel();
            Output = new ODModules.ConsoleInterface();
            smMain = new ODModules.StatusMenu();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblTxBytes = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            lblRxBytes = new ToolStripStatusLabel();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            noneToolStripMenuItem = new ToolStripMenuItem();
            lFToolStripMenuItem = new ToolStripMenuItem();
            cRLFToolStripMenuItem = new ToolStripMenuItem();
            cRToolStripMenuItem = new ToolStripMenuItem();
            cmPrograms = new ODModules.ContextMenu();
            cmRunProgram = new ToolStripMenuItem();
            cmbtnSetAsActive = new ToolStripMenuItem();
            toolStripSeparator29 = new ToolStripSeparator();
            renameToolStripMenuItem = new ToolStripMenuItem();
            cmbtnProperties = new ToolStripMenuItem();
            toolStripSeparator30 = new ToolStripSeparator();
            cmbtnNewProgram = new ToolStripMenuItem();
            cmCloseProgram = new ToolStripMenuItem();
            tsMain.SuspendLayout();
            pnlRenamePanel.SuspendLayout();
            panel2.SuspendLayout();
            cmChannels.SuspendLayout();
            cmStepEditor.SuspendLayout();
            msMain.SuspendLayout();
            pnlStepProgram.SuspendLayout();
            pnlMainConsole.SuspendLayout();
            smMain.SuspendLayout();
            cmPrograms.SuspendLayout();
            SuspendLayout();
            // 
            // tsMain
            // 
            tsMain.BackColorNorth = Color.FromArgb(31, 31, 31);
            tsMain.BackColorSouth = Color.FromArgb(31, 31, 31);
            tsMain.BorderColor = Color.WhiteSmoke;
            tsMain.ImageScalingSize = new Size(32, 32);
            tsMain.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemForeColor = Color.WhiteSmoke;
            tsMain.Items.AddRange(new ToolStripItem[] { ddbPorts, toolStripSeparator1, ddbBAUDRate, ddbBits, ddbParity, ddbStopBits, toolStripSeparator2, btnConnect, btnDisconnect, toolStripSeparator3, ddbInputFormat, ddbOutputFormat, toolStripSeparator4, btnRun, btnRunCursor, btnPause, btnStop, toolStripSeparator5, btnClearTerminal, btnTopMost });
            tsMain.ItemSelectedBackColorNorth = Color.FromArgb(64, 64, 64);
            tsMain.ItemSelectedBackColorSouth = Color.FromArgb(64, 64, 64);
            tsMain.ItemSelectedForeColor = Color.WhiteSmoke;
            tsMain.Location = new Point(0, 40);
            tsMain.MenuBackColorNorth = Color.FromArgb(31, 31, 31);
            tsMain.MenuBackColorSouth = Color.FromArgb(31, 31, 31);
            tsMain.MenuBorderColor = Color.DimGray;
            tsMain.MenuSeparatorColor = Color.FromArgb(55, 55, 55);
            tsMain.MenuSymbolColor = Color.LightGray;
            tsMain.Name = "tsMain";
            tsMain.Padding = new Padding(0, 0, 4, 0);
            tsMain.RoundedToolStrip = false;
            tsMain.ShowBorder = false;
            tsMain.Size = new Size(1177, 42);
            tsMain.StripItemSelectedBackColorNorth = Color.FromArgb(64, 64, 64);
            tsMain.StripItemSelectedBackColorSouth = Color.FromArgb(64, 64, 64);
            tsMain.TabIndex = 0;
            tsMain.Text = "Main Tools";
            // 
            // ddbPorts
            // 
            ddbPorts.ForeColor = Color.White;
            ddbPorts.Image = (Image)resources.GetObject("ddbPorts.Image");
            ddbPorts.ImageScaling = ToolStripItemImageScaling.None;
            ddbPorts.ImageTransparentColor = Color.Magenta;
            ddbPorts.Name = "ddbPorts";
            ddbPorts.Size = new Size(216, 36);
            ddbPorts.Text = "No ports found";
            ddbPorts.ToolTipText = "Port";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 42);
            // 
            // ddbBAUDRate
            // 
            ddbBAUDRate.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ddbBAUDRate.ForeColor = Color.White;
            ddbBAUDRate.Image = (Image)resources.GetObject("ddbBAUDRate.Image");
            ddbBAUDRate.ImageScaling = ToolStripItemImageScaling.None;
            ddbBAUDRate.ImageTransparentColor = Color.Magenta;
            ddbBAUDRate.Name = "ddbBAUDRate";
            ddbBAUDRate.Size = new Size(88, 36);
            ddbBAUDRate.Text = "9600";
            ddbBAUDRate.ToolTipText = "Baud Rate";
            // 
            // ddbBits
            // 
            ddbBits.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ddbBits.DropDownItems.AddRange(new ToolStripItem[] { btnBits5, btnBits6, btnBits7, btnBits8 });
            ddbBits.ForeColor = Color.White;
            ddbBits.Image = (Image)resources.GetObject("ddbBits.Image");
            ddbBits.ImageScaling = ToolStripItemImageScaling.None;
            ddbBits.ImageTransparentColor = Color.Magenta;
            ddbBits.Name = "ddbBits";
            ddbBits.Size = new Size(49, 36);
            ddbBits.Text = "8";
            ddbBits.ToolTipText = "Bits";
            // 
            // btnBits5
            // 
            btnBits5.ForeColor = Color.WhiteSmoke;
            btnBits5.ImageScaling = ToolStripItemImageScaling.None;
            btnBits5.Name = "btnBits5";
            btnBits5.Size = new Size(205, 44);
            btnBits5.Tag = "5";
            btnBits5.Text = "5 bits";
            // 
            // btnBits6
            // 
            btnBits6.ForeColor = Color.WhiteSmoke;
            btnBits6.ImageScaling = ToolStripItemImageScaling.None;
            btnBits6.Name = "btnBits6";
            btnBits6.Size = new Size(205, 44);
            btnBits6.Tag = "6";
            btnBits6.Text = "6 bits";
            // 
            // btnBits7
            // 
            btnBits7.ForeColor = Color.WhiteSmoke;
            btnBits7.ImageScaling = ToolStripItemImageScaling.None;
            btnBits7.Name = "btnBits7";
            btnBits7.Size = new Size(205, 44);
            btnBits7.Tag = "7";
            btnBits7.Text = "7 bits";
            // 
            // btnBits8
            // 
            btnBits8.ForeColor = Color.WhiteSmoke;
            btnBits8.ImageScaling = ToolStripItemImageScaling.None;
            btnBits8.Name = "btnBits8";
            btnBits8.Size = new Size(205, 44);
            btnBits8.Tag = "8";
            btnBits8.Text = "8 bits";
            // 
            // ddbParity
            // 
            ddbParity.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ddbParity.DropDownItems.AddRange(new ToolStripItem[] { btnParityNone, btnParityEven, btnParityOdd, btnParitySpace, btnParityMark });
            ddbParity.ForeColor = Color.White;
            ddbParity.Image = (Image)resources.GetObject("ddbParity.Image");
            ddbParity.ImageScaling = ToolStripItemImageScaling.None;
            ddbParity.ImageTransparentColor = Color.Magenta;
            ddbParity.Name = "ddbParity";
            ddbParity.Size = new Size(54, 36);
            ddbParity.Text = "N";
            ddbParity.ToolTipText = "Parity";
            // 
            // btnParityNone
            // 
            btnParityNone.ForeColor = Color.WhiteSmoke;
            btnParityNone.ImageScaling = ToolStripItemImageScaling.None;
            btnParityNone.Name = "btnParityNone";
            btnParityNone.Size = new Size(275, 44);
            btnParityNone.Tag = "N";
            btnParityNone.Text = "No Parity";
            // 
            // btnParityEven
            // 
            btnParityEven.ForeColor = Color.WhiteSmoke;
            btnParityEven.ImageScaling = ToolStripItemImageScaling.None;
            btnParityEven.Name = "btnParityEven";
            btnParityEven.Size = new Size(275, 44);
            btnParityEven.Tag = "E";
            btnParityEven.Text = "Even Parity";
            // 
            // btnParityOdd
            // 
            btnParityOdd.ForeColor = Color.WhiteSmoke;
            btnParityOdd.ImageScaling = ToolStripItemImageScaling.None;
            btnParityOdd.Name = "btnParityOdd";
            btnParityOdd.Size = new Size(275, 44);
            btnParityOdd.Tag = "O";
            btnParityOdd.Text = "Odd Parity";
            // 
            // btnParitySpace
            // 
            btnParitySpace.ForeColor = Color.WhiteSmoke;
            btnParitySpace.ImageScaling = ToolStripItemImageScaling.None;
            btnParitySpace.Name = "btnParitySpace";
            btnParitySpace.Size = new Size(275, 44);
            btnParitySpace.Tag = "S";
            btnParitySpace.Text = "Space Parity";
            // 
            // btnParityMark
            // 
            btnParityMark.ForeColor = Color.WhiteSmoke;
            btnParityMark.ImageScaling = ToolStripItemImageScaling.None;
            btnParityMark.Name = "btnParityMark";
            btnParityMark.Size = new Size(275, 44);
            btnParityMark.Tag = "M";
            btnParityMark.Text = "Mark Parity";
            // 
            // ddbStopBits
            // 
            ddbStopBits.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ddbStopBits.DropDownItems.AddRange(new ToolStripItem[] { btnStopBitsNone, btnStopBits1, btnStopBits15, btnStopBits2 });
            ddbStopBits.ForeColor = Color.White;
            ddbStopBits.Image = (Image)resources.GetObject("ddbStopBits.Image");
            ddbStopBits.ImageScaling = ToolStripItemImageScaling.None;
            ddbStopBits.ImageTransparentColor = Color.Magenta;
            ddbStopBits.Name = "ddbStopBits";
            ddbStopBits.Size = new Size(49, 36);
            ddbStopBits.Text = "1";
            ddbStopBits.ToolTipText = "Stop Bits";
            // 
            // btnStopBitsNone
            // 
            btnStopBitsNone.ForeColor = Color.WhiteSmoke;
            btnStopBitsNone.ImageScaling = ToolStripItemImageScaling.None;
            btnStopBitsNone.Name = "btnStopBitsNone";
            btnStopBitsNone.Size = new Size(278, 44);
            btnStopBitsNone.Tag = "0";
            btnStopBitsNone.Text = "0 Stop Bits";
            btnStopBitsNone.Visible = false;
            // 
            // btnStopBits1
            // 
            btnStopBits1.ForeColor = Color.WhiteSmoke;
            btnStopBits1.ImageScaling = ToolStripItemImageScaling.None;
            btnStopBits1.Name = "btnStopBits1";
            btnStopBits1.Size = new Size(278, 44);
            btnStopBits1.Tag = "1";
            btnStopBits1.Text = "1 Stop Bit";
            // 
            // btnStopBits15
            // 
            btnStopBits15.ForeColor = Color.WhiteSmoke;
            btnStopBits15.ImageScaling = ToolStripItemImageScaling.None;
            btnStopBits15.Name = "btnStopBits15";
            btnStopBits15.Size = new Size(278, 44);
            btnStopBits15.Tag = "1.5";
            btnStopBits15.Text = "1.5 Stop Bits";
            // 
            // btnStopBits2
            // 
            btnStopBits2.ForeColor = Color.WhiteSmoke;
            btnStopBits2.ImageScaling = ToolStripItemImageScaling.None;
            btnStopBits2.Name = "btnStopBits2";
            btnStopBits2.Size = new Size(278, 44);
            btnStopBits2.Tag = "2";
            btnStopBits2.Text = "2 Stop Bits";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 42);
            // 
            // btnConnect
            // 
            btnConnect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnConnect.Image = (Image)resources.GetObject("btnConnect.Image");
            btnConnect.ImageScaling = ToolStripItemImageScaling.None;
            btnConnect.ImageTransparentColor = Color.Magenta;
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(46, 36);
            btnConnect.Text = "Connect";
            // 
            // btnDisconnect
            // 
            btnDisconnect.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDisconnect.Image = (Image)resources.GetObject("btnDisconnect.Image");
            btnDisconnect.ImageScaling = ToolStripItemImageScaling.None;
            btnDisconnect.ImageTransparentColor = Color.Magenta;
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(46, 36);
            btnDisconnect.Text = "Disconnect";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 42);
            // 
            // ddbInputFormat
            // 
            ddbInputFormat.ForeColor = Color.White;
            ddbInputFormat.Image = (Image)resources.GetObject("ddbInputFormat.Image");
            ddbInputFormat.ImageScaling = ToolStripItemImageScaling.None;
            ddbInputFormat.ImageTransparentColor = Color.Magenta;
            ddbInputFormat.Name = "ddbInputFormat";
            ddbInputFormat.Size = new Size(95, 36);
            ddbInputFormat.Text = "Text";
            ddbInputFormat.ToolTipText = "Input Format";
            // 
            // ddbOutputFormat
            // 
            ddbOutputFormat.ForeColor = Color.White;
            ddbOutputFormat.Image = (Image)resources.GetObject("ddbOutputFormat.Image");
            ddbOutputFormat.ImageScaling = ToolStripItemImageScaling.None;
            ddbOutputFormat.ImageTransparentColor = Color.Magenta;
            ddbOutputFormat.Name = "ddbOutputFormat";
            ddbOutputFormat.Size = new Size(95, 36);
            ddbOutputFormat.Tag = "frmTxt";
            ddbOutputFormat.Text = "Text";
            ddbOutputFormat.ToolTipText = "Output Format";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 42);
            // 
            // btnRun
            // 
            btnRun.DropDownItems.AddRange(new ToolStripItem[] { runFromStartToolStripMenuItem, toolStripSeparator25 });
            btnRun.ForeColor = Color.White;
            btnRun.Image = (Image)resources.GetObject("btnRun.Image");
            btnRun.ImageScaling = ToolStripItemImageScaling.None;
            btnRun.ImageTransparentColor = Color.Magenta;
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(111, 36);
            btnRun.Text = "Main";
            // 
            // runFromStartToolStripMenuItem
            // 
            runFromStartToolStripMenuItem.ForeColor = Color.WhiteSmoke;
            runFromStartToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            runFromStartToolStripMenuItem.Name = "runFromStartToolStripMenuItem";
            runFromStartToolStripMenuItem.Size = new Size(302, 44);
            runFromStartToolStripMenuItem.Text = "Run from Start";
            // 
            // toolStripSeparator25
            // 
            toolStripSeparator25.Name = "toolStripSeparator25";
            toolStripSeparator25.Size = new Size(299, 6);
            // 
            // btnRunCursor
            // 
            btnRunCursor.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRunCursor.ImageScaling = ToolStripItemImageScaling.None;
            btnRunCursor.ImageTransparentColor = Color.Magenta;
            btnRunCursor.Name = "btnRunCursor";
            btnRunCursor.Size = new Size(46, 36);
            btnRunCursor.Text = "Run";
            // 
            // btnPause
            // 
            btnPause.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPause.Enabled = false;
            btnPause.Image = (Image)resources.GetObject("btnPause.Image");
            btnPause.ImageScaling = ToolStripItemImageScaling.None;
            btnPause.ImageTransparentColor = Color.Magenta;
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(46, 36);
            btnPause.Text = "Pause";
            // 
            // btnStop
            // 
            btnStop.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStop.Enabled = false;
            btnStop.Image = (Image)resources.GetObject("btnStop.Image");
            btnStop.ImageScaling = ToolStripItemImageScaling.None;
            btnStop.ImageTransparentColor = Color.Magenta;
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(46, 36);
            btnStop.Text = "Stop";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 42);
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
            // 
            // pnlRenamePanel
            // 
            pnlRenamePanel.AutoSize = true;
            pnlRenamePanel.Controls.Add(textBox1);
            pnlRenamePanel.Controls.Add(panel2);
            pnlRenamePanel.Dock = DockStyle.Top;
            pnlRenamePanel.Location = new Point(150, 0);
            pnlRenamePanel.Margin = new Padding(4, 2, 4, 2);
            pnlRenamePanel.Name = "pnlRenamePanel";
            pnlRenamePanel.Padding = new Padding(2);
            pnlRenamePanel.Size = new Size(1027, 40);
            pnlRenamePanel.TabIndex = 3;
            pnlRenamePanel.Visible = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(30, 30, 30);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Dock = DockStyle.Top;
            textBox1.Font = new Font("Segoe UI", 10.125F);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(2, 2);
            textBox1.Margin = new Padding(4, 2, 4, 2);
            textBox1.MaxLength = 20;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Rename Channel";
            textBox1.Size = new Size(847, 36);
            textBox1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(849, 2);
            panel2.Margin = new Padding(6);
            panel2.Name = "panel2";
            panel2.Size = new Size(176, 36);
            panel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.AllowGroupUnchecking = false;
            button1.BackColorCheckedNorth = Color.Orange;
            button1.BackColorCheckedSouth = Color.Orange;
            button1.BackColorDownNorth = Color.DimGray;
            button1.BackColorDownSouth = Color.DimGray;
            button1.BackColorHoverNorth = Color.SkyBlue;
            button1.BackColorHoverSouth = Color.SkyBlue;
            button1.BackColorNorth = Color.FromArgb(60, 60, 60);
            button1.BackColorSouth = Color.FromArgb(40, 40, 40);
            button1.BorderColorCheckedNorth = Color.Black;
            button1.BorderColorCheckedSouth = Color.Black;
            button1.BorderColorDownNorth = Color.Black;
            button1.BorderColorDownSouth = Color.Black;
            button1.BorderColorHoverNorth = Color.Black;
            button1.BorderColorHoverSouth = Color.Black;
            button1.BorderColorNorth = Color.Black;
            button1.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            button1.BorderColorSouth = Color.Black;
            button1.BorderRadius = 5;
            button1.Checked = false;
            button1.Dock = DockStyle.Fill;
            button1.ForeColor = Color.FromArgb(224, 224, 224);
            button1.GroupMaximumChecked = 2;
            button1.Location = new Point(0, 0);
            button1.Margin = new Padding(4, 2, 4, 2);
            button1.Name = "button1";
            button1.RadioButtonGroup = "";
            button1.SecondaryFont = new Font("Segoe UI", 9F);
            button1.SecondaryText = "";
            button1.Size = new Size(176, 36);
            button1.Style = ODModules.ButtonStyle.Square;
            button1.TabIndex = 0;
            button1.Text = "Rename";
            button1.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            button1.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            button1.Type = ODModules.ButtonType.Button;
            // 
            // navigator1
            // 
            navigator1.ArrowColor = Color.Black;
            navigator1.ArrowMouseOverColor = Color.DodgerBlue;
            navigator1.BackColor = Color.FromArgb(40, 40, 40);
            navigator1.BorderColor = SystemColors.ScrollBar;
            navigator1.Borders = ODModules.Borders.None;
            navigator1.DisplayStyle = ODModules.Navigator.Style.Right;
            navigator1.DisplayText = "StateName";
            navigator1.DividerBorderColor = Color.FromArgb(0, 0, 0);
            navigator1.Dock = DockStyle.Left;
            navigator1.ForeColor = Color.White;
            navigator1.LinkedList = null;
            navigator1.Location = new Point(0, 0);
            navigator1.Margin = new Padding(6);
            navigator1.MidColor = Color.FromArgb(16, 16, 16);
            navigator1.Name = "navigator1";
            navigator1.SelectedColor = Color.FromArgb(60, 0, 0, 0);
            navigator1.SelectedItem = -1;
            navigator1.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            navigator1.ShowAnimations = true;
            navigator1.ShowBorder = true;
            navigator1.ShowStatuses = false;
            navigator1.SideShadowColor = Color.FromArgb(20, 0, 0, 0);
            navigator1.Size = new Size(150, 416);
            navigator1.Status1 = (ODModules.StatusCondition)resources.GetObject("navigator1.Status1");
            navigator1.Status2 = (ODModules.StatusCondition)resources.GetObject("navigator1.Status2");
            navigator1.Status3 = (ODModules.StatusCondition)resources.GetObject("navigator1.Status3");
            navigator1.StatusData = "Connected";
            navigator1.TabIndex = 1;
            // 
            // cmChannels
            // 
            cmChannels.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmChannels.BorderColor = Color.Black;
            cmChannels.DropShadowEnabled = false;
            cmChannels.ForeColor = Color.White;
            cmChannels.ImageScalingSize = new Size(32, 32);
            cmChannels.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmChannels.Items.AddRange(new ToolStripItem[] { newChannelToolStripMenuItem, removeChannelToolStripMenuItem, toolStripSeparator35, renameChannelToolStripMenuItem, toolStripSeparator36, outputInTerminalToolStripMenuItem, modbusMasterToolStripMenuItem, toolStripSeparator37, connectToolStripMenuItem, disconnectToolStripMenuItem });
            cmChannels.MenuBackColorNorth = Color.DodgerBlue;
            cmChannels.MenuBackColorSouth = Color.DodgerBlue;
            cmChannels.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmChannels.Name = "cmChannels";
            cmChannels.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmChannels.ShowInsetShadow = false;
            cmChannels.ShowItemInsetShadow = false;
            cmChannels.Size = new Size(290, 302);
            // 
            // newChannelToolStripMenuItem
            // 
            newChannelToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            newChannelToolStripMenuItem.Name = "newChannelToolStripMenuItem";
            newChannelToolStripMenuItem.Size = new Size(289, 40);
            newChannelToolStripMenuItem.Text = "New Channel";
            // 
            // removeChannelToolStripMenuItem
            // 
            removeChannelToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            removeChannelToolStripMenuItem.Name = "removeChannelToolStripMenuItem";
            removeChannelToolStripMenuItem.Size = new Size(289, 40);
            removeChannelToolStripMenuItem.Text = "Remove Channel";
            // 
            // toolStripSeparator35
            // 
            toolStripSeparator35.Name = "toolStripSeparator35";
            toolStripSeparator35.Size = new Size(286, 6);
            // 
            // renameChannelToolStripMenuItem
            // 
            renameChannelToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            renameChannelToolStripMenuItem.Name = "renameChannelToolStripMenuItem";
            renameChannelToolStripMenuItem.Size = new Size(289, 40);
            renameChannelToolStripMenuItem.Text = "Rename Channel";
            // 
            // toolStripSeparator36
            // 
            toolStripSeparator36.Name = "toolStripSeparator36";
            toolStripSeparator36.Size = new Size(286, 6);
            // 
            // outputInTerminalToolStripMenuItem
            // 
            outputInTerminalToolStripMenuItem.Checked = true;
            outputInTerminalToolStripMenuItem.CheckOnClick = true;
            outputInTerminalToolStripMenuItem.CheckState = CheckState.Checked;
            outputInTerminalToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            outputInTerminalToolStripMenuItem.Name = "outputInTerminalToolStripMenuItem";
            outputInTerminalToolStripMenuItem.Size = new Size(289, 40);
            outputInTerminalToolStripMenuItem.Text = "Output in Terminal";
            // 
            // modbusMasterToolStripMenuItem
            // 
            modbusMasterToolStripMenuItem.CheckOnClick = true;
            modbusMasterToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            modbusMasterToolStripMenuItem.Name = "modbusMasterToolStripMenuItem";
            modbusMasterToolStripMenuItem.Size = new Size(289, 40);
            modbusMasterToolStripMenuItem.Text = "Modbus Master";
            // 
            // toolStripSeparator37
            // 
            toolStripSeparator37.Name = "toolStripSeparator37";
            toolStripSeparator37.Size = new Size(286, 6);
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(289, 40);
            connectToolStripMenuItem.Text = "Connect";
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Enabled = false;
            disconnectToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(289, 40);
            disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // lstStepProgram
            // 
            lstStepProgram.AllowArrowKeyCellSelect = false;
            lstStepProgram.AllowColumnSpanning = true;
            lstStepProgram.AllowMouseWheel = true;
            lstStepProgram.BackColor = Color.FromArgb(16, 16, 16);
            lstStepProgram.BorderColor = Color.Gray;
            lstStepProgram.Borders = ODModules.Borders.None;
            lstStepProgram.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            lstStepProgram.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            lstStepProgram.CellPixelFit = true;
            lstStepProgram.CellSelectEditableOnly = true;
            lstStepProgram.CellSelectionBorderColor = Color.Blue;
            lstStepProgram.ColumnColor = Color.FromArgb(31, 31, 31);
            lstStepProgram.ColumnForeColor = Color.WhiteSmoke;
            lstStepProgram.ColumnLineColor = Color.FromArgb(64, 64, 64);
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column1.CountOffset = 0;
            column1.DataFormat = ODModules.ColumnDataFormat.None;
            column1.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column1.DropDownRight = false;
            column1.DropDownVisible = true;
            column1.Exportable = false;
            column1.ExportName = "";
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column1.Text = "Step";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 50;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DataFormat = ODModules.ColumnDataFormat.None;
            column2.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column2.DropDownRight = false;
            column2.DropDownVisible = true;
            column2.Exportable = false;
            column2.ExportName = "";
            column2.FixedWidth = true;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column2.Text = "";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 40;
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column3.CountOffset = 0;
            column3.DataFormat = ODModules.ColumnDataFormat.None;
            column3.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column3.DropDownRight = false;
            column3.DropDownVisible = true;
            column3.Exportable = false;
            column3.ExportName = "";
            column3.FixedWidth = false;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column3.Text = "Command";
            column3.UseItemBackColor = false;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 100;
            column4.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column4.CountOffset = 0;
            column4.DataFormat = ODModules.ColumnDataFormat.None;
            column4.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column4.DropDownRight = false;
            column4.DropDownVisible = true;
            column4.Exportable = false;
            column4.ExportName = "";
            column4.FixedWidth = false;
            column4.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column4.Text = "Arguments";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 398;
            lstStepProgram.Columns.Add(column1);
            lstStepProgram.Columns.Add(column2);
            lstStepProgram.Columns.Add(column3);
            lstStepProgram.Columns.Add(column4);
            lstStepProgram.ContextMenuStrip = cmStepEditor;
            lstStepProgram.Dock = DockStyle.Fill;
            lstStepProgram.DropDownMouseDown = Color.DimGray;
            lstStepProgram.DropDownMouseOver = Color.LightGray;
            lstStepProgram.ExternalItems = null;
            lstStepProgram.Filter = null;
            lstStepProgram.FilterColumn = 0;
            lstStepProgram.FilterSearchType = ODModules.ListControl.FilterSearch.Contains;
            lstStepProgram.ForeColor = Color.White;
            lstStepProgram.GridlineColor = Color.FromArgb(30, 30, 30);
            lstStepProgram.HighlightStrength = 128;
            lstStepProgram.HorizontalScrollStep = 3;
            lstStepProgram.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            listItem1.BackColor = Color.Transparent;
            listItem1.Checked = false;
            listItem1.ForeColor = Color.Black;
            listItem1.Indentation = 0U;
            listItem1.LineBackColor = Color.Transparent;
            listItem1.LineForeColor = Color.Black;
            listItem1.MaximumValue = 0;
            listItem1.MinimumValue = 0;
            listItem1.Name = "";
            listItem1.Selected = false;
            listSubItem1.BackColor = Color.Transparent;
            listSubItem1.Checked = true;
            listSubItem1.ForeColor = Color.Black;
            listSubItem1.Indentation = 0U;
            listSubItem1.MaximumValue = 0;
            listSubItem1.MinimumValue = 0;
            listSubItem1.Name = "";
            listSubItem1.Tag = null;
            listSubItem1.Text = "";
            listSubItem1.Value = 0;
            listSubItem2.BackColor = Color.Transparent;
            listSubItem2.Checked = false;
            listSubItem2.ForeColor = Color.Black;
            listSubItem2.Indentation = 0U;
            listSubItem2.MaximumValue = 0;
            listSubItem2.MinimumValue = 0;
            listSubItem2.Name = "";
            listSubItem2.Tag = null;
            listSubItem2.Text = "No Operation";
            listSubItem2.Value = 0;
            listSubItem3.BackColor = Color.Transparent;
            listSubItem3.Checked = false;
            listSubItem3.ForeColor = Color.Black;
            listSubItem3.Indentation = 0U;
            listSubItem3.MaximumValue = 0;
            listSubItem3.MinimumValue = 0;
            listSubItem3.Name = "";
            listSubItem3.Tag = null;
            listSubItem3.Text = "";
            listSubItem3.Value = 0;
            listItem1.SubItems.Add(listSubItem1);
            listItem1.SubItems.Add(listSubItem2);
            listItem1.SubItems.Add(listSubItem3);
            listItem1.Tag = null;
            listItem1.Text = "";
            listItem1.UseLineBackColor = false;
            listItem1.UseLineForeColor = false;
            listItem1.Value = 0;
            lstStepProgram.Items.Add(listItem1);
            lstStepProgram.LineMarkerIndex = 0;
            lstStepProgram.Location = new Point(0, 99);
            lstStepProgram.Margin = new Padding(6);
            lstStepProgram.MarkerBorderColor = Color.LimeGreen;
            lstStepProgram.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstStepProgram.MarkerStyle = ODModules.MarkerStyleType.PointerWithBox;
            lstStepProgram.MoveControlOnCellChange = true;
            lstStepProgram.Name = "lstStepProgram";
            lstStepProgram.RowColor = Color.FromArgb(23, 23, 23);
            lstStepProgram.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstStepProgram.ScrollBarNorth = Color.FromArgb(64, 64, 64);
            lstStepProgram.ScrollBarSouth = Color.FromArgb(64, 64, 64);
            lstStepProgram.ScrollItems = 3;
            lstStepProgram.SelectedColor = Color.SteelBlue;
            lstStepProgram.SelectionColor = Color.Gray;
            lstStepProgram.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstStepProgram.ShowCellSelection = false;
            lstStepProgram.ShowGrid = true;
            lstStepProgram.ShowItemIndentation = true;
            lstStepProgram.ShowMarker = true;
            lstStepProgram.ShowRowColors = true;
            lstStepProgram.Size = new Size(1177, 238);
            lstStepProgram.SpanColumn = 3;
            lstStepProgram.TabIndex = 0;
            lstStepProgram.UseLocalList = false;
            lstStepProgram.VerScroll = 0;
            lstStepProgram.Zoom = 100;
            // 
            // cmStepEditor
            // 
            cmStepEditor.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmStepEditor.BorderColor = Color.Black;
            cmStepEditor.DropShadowEnabled = false;
            cmStepEditor.ForeColor = Color.White;
            cmStepEditor.ImageScalingSize = new Size(32, 32);
            cmStepEditor.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmStepEditor.Items.AddRange(new ToolStripItem[] { addCommandToolStripMenuItem1, removeSelectedToolStripMenuItem, toolStripSeparator20, cutToolStripMenuItem1, copyToolStripMenuItem1, pasteToolStripMenuItem1, toolStripSeparator33, enableSelectedToolStripMenuItem1, disableSelectedToolStripMenuItem1, toolStripSeparator21, runToolStripMenuItem, pauseToolStripMenuItem, stopToolStripMenuItem });
            cmStepEditor.MenuBackColorNorth = Color.FromArgb(20, 20, 20);
            cmStepEditor.MenuBackColorSouth = Color.FromArgb(20, 20, 20);
            cmStepEditor.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmStepEditor.Name = "cmStepEditor";
            cmStepEditor.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmStepEditor.ShowInsetShadow = false;
            cmStepEditor.ShowItemInsetShadow = false;
            cmStepEditor.Size = new Size(273, 402);
            // 
            // addCommandToolStripMenuItem1
            // 
            addCommandToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            addCommandToolStripMenuItem1.Name = "addCommandToolStripMenuItem1";
            addCommandToolStripMenuItem1.Size = new Size(272, 38);
            addCommandToolStripMenuItem1.Text = "Add Command";
            // 
            // removeSelectedToolStripMenuItem
            // 
            removeSelectedToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            removeSelectedToolStripMenuItem.Size = new Size(272, 38);
            removeSelectedToolStripMenuItem.Text = "Remove Selected";
            // 
            // toolStripSeparator20
            // 
            toolStripSeparator20.Name = "toolStripSeparator20";
            toolStripSeparator20.Size = new Size(269, 6);
            // 
            // cutToolStripMenuItem1
            // 
            cutToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            cutToolStripMenuItem1.Size = new Size(272, 38);
            cutToolStripMenuItem1.Text = "Cut";
            // 
            // copyToolStripMenuItem1
            // 
            copyToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            copyToolStripMenuItem1.Size = new Size(272, 38);
            copyToolStripMenuItem1.Text = "Copy";
            // 
            // pasteToolStripMenuItem1
            // 
            pasteToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            pasteToolStripMenuItem1.Size = new Size(272, 38);
            pasteToolStripMenuItem1.Text = "Paste";
            // 
            // toolStripSeparator33
            // 
            toolStripSeparator33.Name = "toolStripSeparator33";
            toolStripSeparator33.Size = new Size(269, 6);
            // 
            // enableSelectedToolStripMenuItem1
            // 
            enableSelectedToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            enableSelectedToolStripMenuItem1.Name = "enableSelectedToolStripMenuItem1";
            enableSelectedToolStripMenuItem1.Size = new Size(272, 38);
            enableSelectedToolStripMenuItem1.Text = "Enable Selected";
            // 
            // disableSelectedToolStripMenuItem1
            // 
            disableSelectedToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            disableSelectedToolStripMenuItem1.Name = "disableSelectedToolStripMenuItem1";
            disableSelectedToolStripMenuItem1.Size = new Size(272, 38);
            disableSelectedToolStripMenuItem1.Text = "Disable Selected";
            // 
            // toolStripSeparator21
            // 
            toolStripSeparator21.Name = "toolStripSeparator21";
            toolStripSeparator21.Size = new Size(269, 6);
            // 
            // runToolStripMenuItem
            // 
            runToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            runToolStripMenuItem.Name = "runToolStripMenuItem";
            runToolStripMenuItem.Size = new Size(272, 38);
            runToolStripMenuItem.Text = "Run";
            // 
            // pauseToolStripMenuItem
            // 
            pauseToolStripMenuItem.Enabled = false;
            pauseToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            pauseToolStripMenuItem.Size = new Size(272, 38);
            pauseToolStripMenuItem.Text = "Pause";
            // 
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new Size(272, 38);
            stopToolStripMenuItem.Text = "Stop";
            // 
            // msMain
            // 
            msMain.BackColor = Color.FromArgb(16, 16, 16);
            msMain.BackColorNorth = Color.FromArgb(31, 31, 31);
            msMain.BackColorNorthFadeIn = Color.FromArgb(10, 10, 10);
            msMain.BackColorSouth = Color.FromArgb(31, 31, 31);
            msMain.Fade = true;
            msMain.ImageScalingSize = new Size(32, 32);
            msMain.ItemForeColor = Color.White;
            msMain.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem, mitChannel, programToolStripMenuItem, extensionsToolStripMenuItem, toolsToolStripMenuItem, windowToolStripMenuItem, helpToolStripMenuItem });
            msMain.ItemSelectedBackColorNorth = Color.FromArgb(64, 64, 64);
            msMain.ItemSelectedBackColorSouth = Color.FromArgb(64, 64, 64);
            msMain.ItemSelectedForeColor = Color.White;
            msMain.Location = new Point(0, 0);
            msMain.MenuBackColorNorth = Color.FromArgb(31, 31, 31);
            msMain.MenuBackColorSouth = Color.FromArgb(31, 31, 31);
            msMain.MenuBorderColor = Color.DimGray;
            msMain.MenuSeparatorColor = Color.FromArgb(55, 55, 55);
            msMain.MenuSymbolColor = Color.White;
            msMain.Name = "msMain";
            msMain.Size = new Size(1177, 40);
            msMain.StripItemSelectedBackColorNorth = Color.FromArgb(64, 64, 64);
            msMain.StripItemSelectedBackColorSouth = Color.FromArgb(64, 64, 64);
            msMain.TabIndex = 2;
            msMain.Text = "Main Menu";
            msMain.UseNorthFadeIn = false;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnNewStep, btnOpenStep, btnOpenLocation, toolStripSeparator, btnSaveStep, btnSaveAsStep, toolStripSeparator6, btnPrint, btnPrintPreview, toolStripSeparator7, btnRecentProjects, toolStripSeparator8, btnMenuExit });
            fileToolStripMenuItem.ForeColor = Color.White;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 36);
            fileToolStripMenuItem.Text = "&File";
            // 
            // btnNewStep
            // 
            btnNewStep.ForeColor = Color.White;
            btnNewStep.Image = (Image)resources.GetObject("btnNewStep.Image");
            btnNewStep.ImageScaling = ToolStripItemImageScaling.None;
            btnNewStep.ImageTransparentColor = Color.Magenta;
            btnNewStep.Name = "btnNewStep";
            btnNewStep.ShortcutKeys = Keys.Control | Keys.N;
            btnNewStep.Size = new Size(347, 44);
            btnNewStep.Text = "&New";
            // 
            // btnOpenStep
            // 
            btnOpenStep.ForeColor = Color.White;
            btnOpenStep.Image = (Image)resources.GetObject("btnOpenStep.Image");
            btnOpenStep.ImageScaling = ToolStripItemImageScaling.None;
            btnOpenStep.ImageTransparentColor = Color.Magenta;
            btnOpenStep.Name = "btnOpenStep";
            btnOpenStep.ShortcutKeys = Keys.Control | Keys.O;
            btnOpenStep.Size = new Size(347, 44);
            btnOpenStep.Text = "&Open";
            // 
            // btnOpenLocation
            // 
            btnOpenLocation.Enabled = false;
            btnOpenLocation.ForeColor = Color.White;
            btnOpenLocation.ImageScaling = ToolStripItemImageScaling.None;
            btnOpenLocation.Name = "btnOpenLocation";
            btnOpenLocation.Size = new Size(347, 44);
            btnOpenLocation.Text = "Open File &Location";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(344, 6);
            // 
            // btnSaveStep
            // 
            btnSaveStep.ForeColor = Color.White;
            btnSaveStep.Image = (Image)resources.GetObject("btnSaveStep.Image");
            btnSaveStep.ImageScaling = ToolStripItemImageScaling.None;
            btnSaveStep.ImageTransparentColor = Color.Magenta;
            btnSaveStep.Name = "btnSaveStep";
            btnSaveStep.ShortcutKeys = Keys.Control | Keys.S;
            btnSaveStep.Size = new Size(347, 44);
            btnSaveStep.Text = "&Save";
            // 
            // btnSaveAsStep
            // 
            btnSaveAsStep.ForeColor = Color.White;
            btnSaveAsStep.ImageScaling = ToolStripItemImageScaling.None;
            btnSaveAsStep.Name = "btnSaveAsStep";
            btnSaveAsStep.Size = new Size(347, 44);
            btnSaveAsStep.Text = "Save &As";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(344, 6);
            toolStripSeparator6.Visible = false;
            // 
            // btnPrint
            // 
            btnPrint.ForeColor = Color.White;
            btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            btnPrint.ImageScaling = ToolStripItemImageScaling.None;
            btnPrint.ImageTransparentColor = Color.Magenta;
            btnPrint.Name = "btnPrint";
            btnPrint.ShortcutKeys = Keys.Control | Keys.P;
            btnPrint.Size = new Size(347, 44);
            btnPrint.Text = "&Print";
            btnPrint.Visible = false;
            // 
            // btnPrintPreview
            // 
            btnPrintPreview.ForeColor = Color.White;
            btnPrintPreview.Image = (Image)resources.GetObject("btnPrintPreview.Image");
            btnPrintPreview.ImageScaling = ToolStripItemImageScaling.None;
            btnPrintPreview.ImageTransparentColor = Color.Magenta;
            btnPrintPreview.Name = "btnPrintPreview";
            btnPrintPreview.Size = new Size(347, 44);
            btnPrintPreview.Text = "Print Pre&view";
            btnPrintPreview.Visible = false;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(344, 6);
            // 
            // btnRecentProjects
            // 
            btnRecentProjects.ForeColor = Color.White;
            btnRecentProjects.Name = "btnRecentProjects";
            btnRecentProjects.Size = new Size(347, 44);
            btnRecentProjects.Text = "Recent Projects";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(344, 6);
            // 
            // btnMenuExit
            // 
            btnMenuExit.ForeColor = Color.White;
            btnMenuExit.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuExit.Name = "btnMenuExit";
            btnMenuExit.ShortcutKeys = Keys.Alt | Keys.F4;
            btnMenuExit.Size = new Size(347, 44);
            btnMenuExit.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator15, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem, toolStripSeparator9, selectAllToolStripMenuItem });
            editToolStripMenuItem.ForeColor = Color.White;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(74, 36);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.ForeColor = Color.White;
            undoToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(327, 44);
            undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.ForeColor = Color.White;
            redoToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(327, 44);
            redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator15
            // 
            toolStripSeparator15.Name = "toolStripSeparator15";
            toolStripSeparator15.Size = new Size(324, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.ForeColor = Color.White;
            cutToolStripMenuItem.Image = (Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            cutToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(327, 44);
            cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ForeColor = Color.White;
            copyToolStripMenuItem.Image = (Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            copyToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(327, 44);
            copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ForeColor = Color.White;
            pasteToolStripMenuItem.Image = (Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            pasteToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(327, 44);
            pasteToolStripMenuItem.Text = "&Paste";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.ForeColor = Color.White;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteToolStripMenuItem.Size = new Size(327, 44);
            deleteToolStripMenuItem.Text = "Delete";
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(324, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.ForeColor = Color.White;
            selectAllToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllToolStripMenuItem.Size = new Size(327, 44);
            selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnOptViewDataOnly, btnOptViewTime, btnOptViewDate, btnOptViewDateTime, toolStripSeparator16, btnOptViewSource, toolStripSeparator13, channelsToolStripMenuItem, btnMenuShowStepPrg, toolStripSeparator11, btnMenuClearTerminal, zoomToolStripMenuItem, toolStripSeparator12, btnMenuTopMost, btnMenuFullScreen });
            viewToolStripMenuItem.ForeColor = Color.White;
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(85, 36);
            viewToolStripMenuItem.Text = "&View";
            // 
            // btnOptViewDataOnly
            // 
            btnOptViewDataOnly.Checked = true;
            btnOptViewDataOnly.CheckState = CheckState.Checked;
            btnOptViewDataOnly.ForeColor = Color.White;
            btnOptViewDataOnly.ImageScaling = ToolStripItemImageScaling.None;
            btnOptViewDataOnly.Name = "btnOptViewDataOnly";
            btnOptViewDataOnly.ShortcutKeys = Keys.Alt | Keys.D1;
            btnOptViewDataOnly.Size = new Size(415, 44);
            btnOptViewDataOnly.Text = "Data &Only";
            // 
            // btnOptViewTime
            // 
            btnOptViewTime.ForeColor = Color.White;
            btnOptViewTime.ImageScaling = ToolStripItemImageScaling.None;
            btnOptViewTime.Name = "btnOptViewTime";
            btnOptViewTime.ShortcutKeys = Keys.Alt | Keys.D2;
            btnOptViewTime.Size = new Size(415, 44);
            btnOptViewTime.Text = "&Time Stamps";
            // 
            // btnOptViewDate
            // 
            btnOptViewDate.ForeColor = Color.White;
            btnOptViewDate.ImageScaling = ToolStripItemImageScaling.None;
            btnOptViewDate.Name = "btnOptViewDate";
            btnOptViewDate.ShortcutKeys = Keys.Alt | Keys.D3;
            btnOptViewDate.Size = new Size(415, 44);
            btnOptViewDate.Text = "&Date Stamps";
            // 
            // btnOptViewDateTime
            // 
            btnOptViewDateTime.ForeColor = Color.White;
            btnOptViewDateTime.ImageScaling = ToolStripItemImageScaling.None;
            btnOptViewDateTime.Name = "btnOptViewDateTime";
            btnOptViewDateTime.ShortcutKeyDisplayString = "";
            btnOptViewDateTime.ShortcutKeys = Keys.Alt | Keys.D4;
            btnOptViewDateTime.Size = new Size(415, 44);
            btnOptViewDateTime.Text = "Date/Time &Stamps";
            // 
            // toolStripSeparator16
            // 
            toolStripSeparator16.Name = "toolStripSeparator16";
            toolStripSeparator16.Size = new Size(412, 6);
            // 
            // btnOptViewSource
            // 
            btnOptViewSource.Checked = true;
            btnOptViewSource.CheckOnClick = true;
            btnOptViewSource.CheckState = CheckState.Checked;
            btnOptViewSource.ForeColor = Color.White;
            btnOptViewSource.ImageScaling = ToolStripItemImageScaling.None;
            btnOptViewSource.Name = "btnOptViewSource";
            btnOptViewSource.ShortcutKeys = Keys.Alt | Keys.D0;
            btnOptViewSource.Size = new Size(415, 44);
            btnOptViewSource.Text = "Show Source";
            // 
            // toolStripSeparator13
            // 
            toolStripSeparator13.Name = "toolStripSeparator13";
            toolStripSeparator13.Size = new Size(412, 6);
            // 
            // channelsToolStripMenuItem
            // 
            channelsToolStripMenuItem.Checked = true;
            channelsToolStripMenuItem.CheckOnClick = true;
            channelsToolStripMenuItem.CheckState = CheckState.Checked;
            channelsToolStripMenuItem.ForeColor = Color.White;
            channelsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            channelsToolStripMenuItem.Name = "channelsToolStripMenuItem";
            channelsToolStripMenuItem.Size = new Size(415, 44);
            channelsToolStripMenuItem.Text = "Channels";
            // 
            // btnMenuShowStepPrg
            // 
            btnMenuShowStepPrg.Checked = true;
            btnMenuShowStepPrg.CheckOnClick = true;
            btnMenuShowStepPrg.CheckState = CheckState.Checked;
            btnMenuShowStepPrg.ForeColor = Color.White;
            btnMenuShowStepPrg.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuShowStepPrg.Name = "btnMenuShowStepPrg";
            btnMenuShowStepPrg.Size = new Size(415, 44);
            btnMenuShowStepPrg.Text = "Step Program";
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(412, 6);
            // 
            // btnMenuClearTerminal
            // 
            btnMenuClearTerminal.ForeColor = Color.White;
            btnMenuClearTerminal.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuClearTerminal.Name = "btnMenuClearTerminal";
            btnMenuClearTerminal.ShortcutKeys = Keys.Alt | Keys.Delete;
            btnMenuClearTerminal.Size = new Size(415, 44);
            btnMenuClearTerminal.Text = "&Clear Terminal";
            // 
            // zoomToolStripMenuItem
            // 
            zoomToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnZoom50, btnZoom75, btnZoom100, btnZoom110, btnZoom120, btnZoom150, btnZoom175, btnZoom200, btnZoom300 });
            zoomToolStripMenuItem.ForeColor = Color.White;
            zoomToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            zoomToolStripMenuItem.Size = new Size(415, 44);
            zoomToolStripMenuItem.Text = "&Zoom";
            // 
            // btnZoom50
            // 
            btnZoom50.ForeColor = Color.White;
            btnZoom50.Name = "btnZoom50";
            btnZoom50.Size = new Size(206, 44);
            btnZoom50.Text = "50%";
            // 
            // btnZoom75
            // 
            btnZoom75.ForeColor = Color.White;
            btnZoom75.Name = "btnZoom75";
            btnZoom75.Size = new Size(206, 44);
            btnZoom75.Text = "75%";
            // 
            // btnZoom100
            // 
            btnZoom100.ForeColor = Color.White;
            btnZoom100.Name = "btnZoom100";
            btnZoom100.Size = new Size(206, 44);
            btnZoom100.Text = "100%";
            // 
            // btnZoom110
            // 
            btnZoom110.ForeColor = Color.White;
            btnZoom110.Name = "btnZoom110";
            btnZoom110.Size = new Size(206, 44);
            btnZoom110.Text = "110%";
            // 
            // btnZoom120
            // 
            btnZoom120.ForeColor = Color.White;
            btnZoom120.Name = "btnZoom120";
            btnZoom120.Size = new Size(206, 44);
            btnZoom120.Text = "120%";
            // 
            // btnZoom150
            // 
            btnZoom150.ForeColor = Color.White;
            btnZoom150.Name = "btnZoom150";
            btnZoom150.Size = new Size(206, 44);
            btnZoom150.Text = "150%";
            // 
            // btnZoom175
            // 
            btnZoom175.ForeColor = Color.White;
            btnZoom175.Name = "btnZoom175";
            btnZoom175.Size = new Size(206, 44);
            btnZoom175.Text = "175%";
            // 
            // btnZoom200
            // 
            btnZoom200.ForeColor = Color.White;
            btnZoom200.Name = "btnZoom200";
            btnZoom200.Size = new Size(206, 44);
            btnZoom200.Text = "200%";
            // 
            // btnZoom300
            // 
            btnZoom300.ForeColor = Color.White;
            btnZoom300.Name = "btnZoom300";
            btnZoom300.Size = new Size(206, 44);
            btnZoom300.Text = "300%";
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new Size(412, 6);
            // 
            // btnMenuTopMost
            // 
            btnMenuTopMost.ForeColor = Color.White;
            btnMenuTopMost.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuTopMost.Name = "btnMenuTopMost";
            btnMenuTopMost.Size = new Size(415, 44);
            btnMenuTopMost.Text = "&Top Most";
            // 
            // btnMenuFullScreen
            // 
            btnMenuFullScreen.ForeColor = Color.White;
            btnMenuFullScreen.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuFullScreen.Name = "btnMenuFullScreen";
            btnMenuFullScreen.ShortcutKeys = Keys.F11;
            btnMenuFullScreen.Size = new Size(415, 44);
            btnMenuFullScreen.Text = "&Full Screen";
            // 
            // mitChannel
            // 
            mitChannel.DropDownItems.AddRange(new ToolStripItem[] { btnNewChannel, btnRemoveChannel, toolStripSeparator24, ddbChannels, btnRenameChannel, toolStripSeparator28, btnMenuOutputMaster, btnMenuModbusMaster, btnallowEscapeCharacters, btnMenuTextFormat, toolStripSeparator38, btnMenuOpenNewTerminal, toolStripSeparator23, scanPortsToolStripMenuItem, btnMenuConnect, btnMenuDisconnect, toolStripSeparator34, propertiesToolStripMenuItem1, toolStripSeparator43, btnChannelPort, btnChannelBaud, btnChannelDataBits, btnChannelParity, btnChannelStopBits, btnChannelFlowCtrl, toolStripSeparator32, btnChannelInputFormat, btnChannelOutputFormat, toolStripSeparator39, sendFileToolStripMenuItem, toolStripSeparator41, resetCountersToolStripMenuItem });
            mitChannel.ForeColor = Color.White;
            mitChannel.Name = "mitChannel";
            mitChannel.Size = new Size(122, 36);
            mitChannel.Text = "&Channel";
            // 
            // btnNewChannel
            // 
            btnNewChannel.ForeColor = Color.White;
            btnNewChannel.ImageScaling = ToolStripItemImageScaling.None;
            btnNewChannel.Name = "btnNewChannel";
            btnNewChannel.ShortcutKeys = Keys.Control | Keys.Shift | Keys.G;
            btnNewChannel.Size = new Size(477, 44);
            btnNewChannel.Text = "&New Channel";
            // 
            // btnRemoveChannel
            // 
            btnRemoveChannel.ForeColor = Color.White;
            btnRemoveChannel.ImageScaling = ToolStripItemImageScaling.None;
            btnRemoveChannel.Name = "btnRemoveChannel";
            btnRemoveChannel.ShortcutKeys = Keys.Control | Keys.Shift | Keys.H;
            btnRemoveChannel.Size = new Size(477, 44);
            btnRemoveChannel.Text = "&Remove Channel";
            // 
            // toolStripSeparator24
            // 
            toolStripSeparator24.Name = "toolStripSeparator24";
            toolStripSeparator24.Size = new Size(474, 6);
            // 
            // ddbChannels
            // 
            ddbChannels.ForeColor = Color.White;
            ddbChannels.ImageScaling = ToolStripItemImageScaling.None;
            ddbChannels.Name = "ddbChannels";
            ddbChannels.Size = new Size(477, 44);
            ddbChannels.Text = "&Switch Channel";
            // 
            // btnRenameChannel
            // 
            btnRenameChannel.ForeColor = Color.White;
            btnRenameChannel.ImageScaling = ToolStripItemImageScaling.None;
            btnRenameChannel.Name = "btnRenameChannel";
            btnRenameChannel.Size = new Size(477, 44);
            btnRenameChannel.Text = "R&ename Channel";
            // 
            // toolStripSeparator28
            // 
            toolStripSeparator28.Name = "toolStripSeparator28";
            toolStripSeparator28.Size = new Size(474, 6);
            // 
            // btnMenuOutputMaster
            // 
            btnMenuOutputMaster.Checked = true;
            btnMenuOutputMaster.CheckOnClick = true;
            btnMenuOutputMaster.CheckState = CheckState.Checked;
            btnMenuOutputMaster.ForeColor = Color.White;
            btnMenuOutputMaster.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuOutputMaster.Name = "btnMenuOutputMaster";
            btnMenuOutputMaster.Size = new Size(477, 44);
            btnMenuOutputMaster.Text = "Output in Termina&l";
            // 
            // btnMenuModbusMaster
            // 
            btnMenuModbusMaster.CheckOnClick = true;
            btnMenuModbusMaster.ForeColor = Color.White;
            btnMenuModbusMaster.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuModbusMaster.Name = "btnMenuModbusMaster";
            btnMenuModbusMaster.Size = new Size(477, 44);
            btnMenuModbusMaster.Text = "&Modbus Master";
            // 
            // btnallowEscapeCharacters
            // 
            btnallowEscapeCharacters.Checked = true;
            btnallowEscapeCharacters.CheckOnClick = true;
            btnallowEscapeCharacters.CheckState = CheckState.Checked;
            btnallowEscapeCharacters.ForeColor = Color.White;
            btnallowEscapeCharacters.ImageScaling = ToolStripItemImageScaling.None;
            btnallowEscapeCharacters.Name = "btnallowEscapeCharacters";
            btnallowEscapeCharacters.Size = new Size(477, 44);
            btnallowEscapeCharacters.Text = "Allow Escape Characters";
            // 
            // btnMenuTextFormat
            // 
            btnMenuTextFormat.DropDownItems.AddRange(new ToolStripItem[] { btnOptFrmLineNone, btnOptFrmLineLF, btnOptFrmLineCRLF, btnOptFrmLineCR });
            btnMenuTextFormat.ForeColor = Color.White;
            btnMenuTextFormat.Name = "btnMenuTextFormat";
            btnMenuTextFormat.Size = new Size(477, 44);
            btnMenuTextFormat.Text = "Text Formatting";
            // 
            // btnOptFrmLineNone
            // 
            btnOptFrmLineNone.AutoToolTip = true;
            btnOptFrmLineNone.Checked = true;
            btnOptFrmLineNone.CheckState = CheckState.Checked;
            btnOptFrmLineNone.ForeColor = Color.White;
            btnOptFrmLineNone.ImageScaling = ToolStripItemImageScaling.None;
            btnOptFrmLineNone.Name = "btnOptFrmLineNone";
            btnOptFrmLineNone.Size = new Size(206, 44);
            btnOptFrmLineNone.Tag = "frmLineNone";
            btnOptFrmLineNone.Text = "&None";
            // 
            // btnOptFrmLineLF
            // 
            btnOptFrmLineLF.ForeColor = Color.White;
            btnOptFrmLineLF.ImageScaling = ToolStripItemImageScaling.None;
            btnOptFrmLineLF.Name = "btnOptFrmLineLF";
            btnOptFrmLineLF.Size = new Size(206, 44);
            btnOptFrmLineLF.Tag = "frmLineLF";
            btnOptFrmLineLF.Text = "&LF";
            // 
            // btnOptFrmLineCRLF
            // 
            btnOptFrmLineCRLF.ForeColor = Color.White;
            btnOptFrmLineCRLF.ImageScaling = ToolStripItemImageScaling.None;
            btnOptFrmLineCRLF.Name = "btnOptFrmLineCRLF";
            btnOptFrmLineCRLF.Size = new Size(206, 44);
            btnOptFrmLineCRLF.Tag = "frmLineCRLF";
            btnOptFrmLineCRLF.Text = "C&R LF";
            // 
            // btnOptFrmLineCR
            // 
            btnOptFrmLineCR.ForeColor = Color.White;
            btnOptFrmLineCR.ImageScaling = ToolStripItemImageScaling.None;
            btnOptFrmLineCR.Name = "btnOptFrmLineCR";
            btnOptFrmLineCR.Size = new Size(206, 44);
            btnOptFrmLineCR.Tag = "frmLineCR";
            btnOptFrmLineCR.Text = "&CR";
            // 
            // toolStripSeparator38
            // 
            toolStripSeparator38.Name = "toolStripSeparator38";
            toolStripSeparator38.Size = new Size(474, 6);
            // 
            // btnMenuOpenNewTerminal
            // 
            btnMenuOpenNewTerminal.ForeColor = Color.White;
            btnMenuOpenNewTerminal.Name = "btnMenuOpenNewTerminal";
            btnMenuOpenNewTerminal.ShortcutKeys = Keys.Control | Keys.T;
            btnMenuOpenNewTerminal.Size = new Size(477, 44);
            btnMenuOpenNewTerminal.Text = "Open in New Terminal";
            // 
            // toolStripSeparator23
            // 
            toolStripSeparator23.Name = "toolStripSeparator23";
            toolStripSeparator23.Size = new Size(474, 6);
            // 
            // scanPortsToolStripMenuItem
            // 
            scanPortsToolStripMenuItem.ForeColor = Color.White;
            scanPortsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            scanPortsToolStripMenuItem.Name = "scanPortsToolStripMenuItem";
            scanPortsToolStripMenuItem.Size = new Size(477, 44);
            scanPortsToolStripMenuItem.Text = "Scan Ports";
            // 
            // btnMenuConnect
            // 
            btnMenuConnect.ForeColor = Color.White;
            btnMenuConnect.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuConnect.Name = "btnMenuConnect";
            btnMenuConnect.ShortcutKeys = Keys.Control | Keys.D1;
            btnMenuConnect.Size = new Size(477, 44);
            btnMenuConnect.Text = "&Connect";
            // 
            // btnMenuDisconnect
            // 
            btnMenuDisconnect.Enabled = false;
            btnMenuDisconnect.ForeColor = Color.White;
            btnMenuDisconnect.ImageScaling = ToolStripItemImageScaling.None;
            btnMenuDisconnect.Name = "btnMenuDisconnect";
            btnMenuDisconnect.ShortcutKeys = Keys.Control | Keys.D2;
            btnMenuDisconnect.Size = new Size(477, 44);
            btnMenuDisconnect.Text = "Disc&onnect";
            // 
            // toolStripSeparator34
            // 
            toolStripSeparator34.Name = "toolStripSeparator34";
            toolStripSeparator34.Size = new Size(474, 6);
            // 
            // propertiesToolStripMenuItem1
            // 
            propertiesToolStripMenuItem1.ForeColor = Color.White;
            propertiesToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
            propertiesToolStripMenuItem1.Size = new Size(477, 44);
            propertiesToolStripMenuItem1.Text = "Properties";
            // 
            // toolStripSeparator43
            // 
            toolStripSeparator43.Name = "toolStripSeparator43";
            toolStripSeparator43.Size = new Size(474, 6);
            // 
            // btnChannelPort
            // 
            btnChannelPort.ForeColor = Color.White;
            btnChannelPort.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelPort.Name = "btnChannelPort";
            btnChannelPort.Size = new Size(477, 44);
            btnChannelPort.Text = "&Port";
            // 
            // btnChannelBaud
            // 
            btnChannelBaud.ForeColor = Color.White;
            btnChannelBaud.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelBaud.Name = "btnChannelBaud";
            btnChannelBaud.Size = new Size(477, 44);
            btnChannelBaud.Text = "&Baud Rate";
            // 
            // btnChannelDataBits
            // 
            btnChannelDataBits.DropDownItems.AddRange(new ToolStripItem[] { btnChanDB5, btnChanDB6, btnChanDB7, btnChanDB });
            btnChannelDataBits.ForeColor = Color.White;
            btnChannelDataBits.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelDataBits.Name = "btnChannelDataBits";
            btnChannelDataBits.Size = new Size(477, 44);
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
            // 
            // btnChanDB6
            // 
            btnChanDB6.ForeColor = Color.White;
            btnChanDB6.ImageScaling = ToolStripItemImageScaling.None;
            btnChanDB6.Name = "btnChanDB6";
            btnChanDB6.Size = new Size(205, 44);
            btnChanDB6.Tag = "6";
            btnChanDB6.Text = "&6 Bits";
            // 
            // btnChanDB7
            // 
            btnChanDB7.ForeColor = Color.White;
            btnChanDB7.ImageScaling = ToolStripItemImageScaling.None;
            btnChanDB7.Name = "btnChanDB7";
            btnChanDB7.Size = new Size(205, 44);
            btnChanDB7.Tag = "7";
            btnChanDB7.Text = "&7 Bits";
            // 
            // btnChanDB
            // 
            btnChanDB.ForeColor = Color.White;
            btnChanDB.ImageScaling = ToolStripItemImageScaling.None;
            btnChanDB.Name = "btnChanDB";
            btnChanDB.Size = new Size(205, 44);
            btnChanDB.Tag = "8";
            btnChanDB.Text = "&8 Bits";
            // 
            // btnChannelParity
            // 
            btnChannelParity.DropDownItems.AddRange(new ToolStripItem[] { btnChannelNoParity, btnChannelEvenParity, btnChannelOddParity, btnChannelSpaceParity, btnChannelMarkParity });
            btnChannelParity.ForeColor = Color.White;
            btnChannelParity.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelParity.Name = "btnChannelParity";
            btnChannelParity.Size = new Size(477, 44);
            btnChannelParity.Text = "P&arity";
            // 
            // btnChannelNoParity
            // 
            btnChannelNoParity.ForeColor = Color.White;
            btnChannelNoParity.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelNoParity.Name = "btnChannelNoParity";
            btnChannelNoParity.Size = new Size(275, 44);
            btnChannelNoParity.Tag = "N";
            btnChannelNoParity.Text = "&No Parity";
            // 
            // btnChannelEvenParity
            // 
            btnChannelEvenParity.ForeColor = Color.White;
            btnChannelEvenParity.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelEvenParity.Name = "btnChannelEvenParity";
            btnChannelEvenParity.Size = new Size(275, 44);
            btnChannelEvenParity.Tag = "E";
            btnChannelEvenParity.Text = "&Even Parity";
            // 
            // btnChannelOddParity
            // 
            btnChannelOddParity.ForeColor = Color.White;
            btnChannelOddParity.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelOddParity.Name = "btnChannelOddParity";
            btnChannelOddParity.Size = new Size(275, 44);
            btnChannelOddParity.Tag = "O";
            btnChannelOddParity.Text = "&Odd Parity";
            // 
            // btnChannelSpaceParity
            // 
            btnChannelSpaceParity.ForeColor = Color.White;
            btnChannelSpaceParity.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelSpaceParity.Name = "btnChannelSpaceParity";
            btnChannelSpaceParity.Size = new Size(275, 44);
            btnChannelSpaceParity.Tag = "S";
            btnChannelSpaceParity.Text = "&Space Parity";
            // 
            // btnChannelMarkParity
            // 
            btnChannelMarkParity.ForeColor = Color.White;
            btnChannelMarkParity.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelMarkParity.Name = "btnChannelMarkParity";
            btnChannelMarkParity.Size = new Size(275, 44);
            btnChannelMarkParity.Tag = "M";
            btnChannelMarkParity.Text = "&Mark Parity";
            // 
            // btnChannelStopBits
            // 
            btnChannelStopBits.DropDownItems.AddRange(new ToolStripItem[] { btnChannelStopBits0, btnChannelStopBits1, btnChannelStopBits15, btnChannelStopBits2 });
            btnChannelStopBits.ForeColor = Color.White;
            btnChannelStopBits.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelStopBits.Name = "btnChannelStopBits";
            btnChannelStopBits.Size = new Size(477, 44);
            btnChannelStopBits.Text = "S&top Bits";
            // 
            // btnChannelStopBits0
            // 
            btnChannelStopBits0.ForeColor = Color.White;
            btnChannelStopBits0.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelStopBits0.Name = "btnChannelStopBits0";
            btnChannelStopBits0.Size = new Size(278, 44);
            btnChannelStopBits0.Tag = "0";
            btnChannelStopBits0.Text = "&0 Stop Bits";
            btnChannelStopBits0.Visible = false;
            // 
            // btnChannelStopBits1
            // 
            btnChannelStopBits1.ForeColor = Color.White;
            btnChannelStopBits1.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelStopBits1.Name = "btnChannelStopBits1";
            btnChannelStopBits1.Size = new Size(278, 44);
            btnChannelStopBits1.Tag = "1";
            btnChannelStopBits1.Text = "&1 Stop Bits";
            // 
            // btnChannelStopBits15
            // 
            btnChannelStopBits15.ForeColor = Color.White;
            btnChannelStopBits15.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelStopBits15.Name = "btnChannelStopBits15";
            btnChannelStopBits15.Size = new Size(278, 44);
            btnChannelStopBits15.Tag = "1.5";
            btnChannelStopBits15.Text = "1.&5 Stop Bits";
            // 
            // btnChannelStopBits2
            // 
            btnChannelStopBits2.ForeColor = Color.White;
            btnChannelStopBits2.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelStopBits2.Name = "btnChannelStopBits2";
            btnChannelStopBits2.Size = new Size(278, 44);
            btnChannelStopBits2.Tag = "2";
            btnChannelStopBits2.Text = "&2 Stop Bits";
            // 
            // btnChannelFlowCtrl
            // 
            btnChannelFlowCtrl.DropDownItems.AddRange(new ToolStripItem[] { btnChannelFlowNone, btnChannelFlowXONXOFF, btnChannelFlowRTSCTS, btnChannelFlowDSRDTR });
            btnChannelFlowCtrl.ForeColor = Color.White;
            btnChannelFlowCtrl.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelFlowCtrl.Name = "btnChannelFlowCtrl";
            btnChannelFlowCtrl.Size = new Size(477, 44);
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
            // 
            // btnChannelFlowXONXOFF
            // 
            btnChannelFlowXONXOFF.ForeColor = Color.White;
            btnChannelFlowXONXOFF.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelFlowXONXOFF.Name = "btnChannelFlowXONXOFF";
            btnChannelFlowXONXOFF.Size = new Size(262, 44);
            btnChannelFlowXONXOFF.Tag = "cfXONXOFF";
            btnChannelFlowXONXOFF.Text = "&XON/XOFF";
            // 
            // btnChannelFlowRTSCTS
            // 
            btnChannelFlowRTSCTS.ForeColor = Color.White;
            btnChannelFlowRTSCTS.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelFlowRTSCTS.Name = "btnChannelFlowRTSCTS";
            btnChannelFlowRTSCTS.Size = new Size(262, 44);
            btnChannelFlowRTSCTS.Tag = "cfRTSCTS";
            btnChannelFlowRTSCTS.Text = "&RTS/CTS";
            // 
            // btnChannelFlowDSRDTR
            // 
            btnChannelFlowDSRDTR.ForeColor = Color.White;
            btnChannelFlowDSRDTR.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelFlowDSRDTR.Name = "btnChannelFlowDSRDTR";
            btnChannelFlowDSRDTR.Size = new Size(262, 44);
            btnChannelFlowDSRDTR.Tag = "cfDSRSTR";
            btnChannelFlowDSRDTR.Text = "&DSR/DTR";
            // 
            // toolStripSeparator32
            // 
            toolStripSeparator32.Name = "toolStripSeparator32";
            toolStripSeparator32.Size = new Size(474, 6);
            // 
            // btnChannelInputFormat
            // 
            btnChannelInputFormat.ForeColor = Color.White;
            btnChannelInputFormat.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelInputFormat.Name = "btnChannelInputFormat";
            btnChannelInputFormat.Size = new Size(477, 44);
            btnChannelInputFormat.Text = "&Input Format";
            // 
            // btnChannelOutputFormat
            // 
            btnChannelOutputFormat.ForeColor = Color.White;
            btnChannelOutputFormat.ImageScaling = ToolStripItemImageScaling.None;
            btnChannelOutputFormat.Name = "btnChannelOutputFormat";
            btnChannelOutputFormat.Size = new Size(477, 44);
            btnChannelOutputFormat.Text = "&Output Format";
            // 
            // toolStripSeparator39
            // 
            toolStripSeparator39.Name = "toolStripSeparator39";
            toolStripSeparator39.Size = new Size(474, 6);
            // 
            // sendFileToolStripMenuItem
            // 
            sendFileToolStripMenuItem.Enabled = false;
            sendFileToolStripMenuItem.ForeColor = Color.White;
            sendFileToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sendFileToolStripMenuItem.Name = "sendFileToolStripMenuItem";
            sendFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.O;
            sendFileToolStripMenuItem.Size = new Size(477, 44);
            sendFileToolStripMenuItem.Text = "Send File";
            sendFileToolStripMenuItem.Click += sendFileToolStripMenuItem_Click;
            // 
            // toolStripSeparator41
            // 
            toolStripSeparator41.Name = "toolStripSeparator41";
            toolStripSeparator41.Size = new Size(474, 6);
            // 
            // resetCountersToolStripMenuItem
            // 
            resetCountersToolStripMenuItem.ForeColor = Color.White;
            resetCountersToolStripMenuItem.Name = "resetCountersToolStripMenuItem";
            resetCountersToolStripMenuItem.Size = new Size(477, 44);
            resetCountersToolStripMenuItem.Text = "Reset Counters";
            // 
            // programToolStripMenuItem
            // 
            programToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addCommandToolStripMenuItem, addCommandAfterToolStripMenuItem, btnPrgRemoveStepLines, toolStripSeparator17, btnPrgMoveUp, btnPrgMoveDown, toolStripSeparator18, btnEnableSelected, btnToggleSelected, btnDisableSelected, toolStripSeparator19, setStepCursorToolStripMenuItem, toolStripSeparator22, activeProgramToolStripMenuItem, commandPalletToolStripMenuItem, variablesToolStripMenuItem, propertiesToolStripMenuItem, toolStripSeparator26, btnRunPrg, runProgramToolStripMenuItem, btnPausePrg, btnStopPrg, toolStripSeparator27, newProgramToolStripMenuItem, removeProgramToolStripMenuItem });
            programToolStripMenuItem.ForeColor = Color.White;
            programToolStripMenuItem.Name = "programToolStripMenuItem";
            programToolStripMenuItem.Size = new Size(124, 36);
            programToolStripMenuItem.Text = "&Program";
            // 
            // addCommandToolStripMenuItem
            // 
            addCommandToolStripMenuItem.ForeColor = Color.White;
            addCommandToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            addCommandToolStripMenuItem.Name = "addCommandToolStripMenuItem";
            addCommandToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            addCommandToolStripMenuItem.Size = new Size(529, 44);
            addCommandToolStripMenuItem.Text = "&Add Command";
            // 
            // addCommandAfterToolStripMenuItem
            // 
            addCommandAfterToolStripMenuItem.ForeColor = Color.White;
            addCommandAfterToolStripMenuItem.Name = "addCommandAfterToolStripMenuItem";
            addCommandAfterToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Q;
            addCommandAfterToolStripMenuItem.Size = new Size(529, 44);
            addCommandAfterToolStripMenuItem.Text = "Add Command After";
            addCommandAfterToolStripMenuItem.Visible = false;
            // 
            // btnPrgRemoveStepLines
            // 
            btnPrgRemoveStepLines.ForeColor = Color.White;
            btnPrgRemoveStepLines.ImageScaling = ToolStripItemImageScaling.None;
            btnPrgRemoveStepLines.Name = "btnPrgRemoveStepLines";
            btnPrgRemoveStepLines.ShortcutKeys = Keys.Control | Keys.Delete;
            btnPrgRemoveStepLines.Size = new Size(529, 44);
            btnPrgRemoveStepLines.Text = "&Remove Selected";
            // 
            // toolStripSeparator17
            // 
            toolStripSeparator17.Name = "toolStripSeparator17";
            toolStripSeparator17.Size = new Size(526, 6);
            // 
            // btnPrgMoveUp
            // 
            btnPrgMoveUp.ForeColor = Color.White;
            btnPrgMoveUp.ImageScaling = ToolStripItemImageScaling.None;
            btnPrgMoveUp.Name = "btnPrgMoveUp";
            btnPrgMoveUp.ShortcutKeys = Keys.Control | Keys.Up;
            btnPrgMoveUp.Size = new Size(529, 44);
            btnPrgMoveUp.Text = "Move &Up";
            // 
            // btnPrgMoveDown
            // 
            btnPrgMoveDown.ForeColor = Color.White;
            btnPrgMoveDown.ImageScaling = ToolStripItemImageScaling.None;
            btnPrgMoveDown.Name = "btnPrgMoveDown";
            btnPrgMoveDown.ShortcutKeys = Keys.Control | Keys.Down;
            btnPrgMoveDown.Size = new Size(529, 44);
            btnPrgMoveDown.Text = "Move &Down";
            // 
            // toolStripSeparator18
            // 
            toolStripSeparator18.Name = "toolStripSeparator18";
            toolStripSeparator18.Size = new Size(526, 6);
            // 
            // btnEnableSelected
            // 
            btnEnableSelected.ForeColor = Color.White;
            btnEnableSelected.ImageScaling = ToolStripItemImageScaling.None;
            btnEnableSelected.Name = "btnEnableSelected";
            btnEnableSelected.ShortcutKeys = Keys.Control | Keys.W;
            btnEnableSelected.Size = new Size(529, 44);
            btnEnableSelected.Text = "&Enable Selected";
            // 
            // btnToggleSelected
            // 
            btnToggleSelected.ForeColor = Color.White;
            btnToggleSelected.ImageScaling = ToolStripItemImageScaling.None;
            btnToggleSelected.Name = "btnToggleSelected";
            btnToggleSelected.Size = new Size(529, 44);
            btnToggleSelected.Text = "&Toggle Selected";
            // 
            // btnDisableSelected
            // 
            btnDisableSelected.ForeColor = Color.White;
            btnDisableSelected.ImageScaling = ToolStripItemImageScaling.None;
            btnDisableSelected.Name = "btnDisableSelected";
            btnDisableSelected.ShortcutKeys = Keys.Control | Keys.E;
            btnDisableSelected.Size = new Size(529, 44);
            btnDisableSelected.Text = "D&isable Selected";
            // 
            // toolStripSeparator19
            // 
            toolStripSeparator19.Name = "toolStripSeparator19";
            toolStripSeparator19.Size = new Size(526, 6);
            // 
            // setStepCursorToolStripMenuItem
            // 
            setStepCursorToolStripMenuItem.ForeColor = Color.White;
            setStepCursorToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            setStepCursorToolStripMenuItem.Name = "setStepCursorToolStripMenuItem";
            setStepCursorToolStripMenuItem.Size = new Size(529, 44);
            setStepCursorToolStripMenuItem.Text = "&Set Step Cursor";
            // 
            // toolStripSeparator22
            // 
            toolStripSeparator22.Name = "toolStripSeparator22";
            toolStripSeparator22.Size = new Size(526, 6);
            // 
            // activeProgramToolStripMenuItem
            // 
            activeProgramToolStripMenuItem.ForeColor = Color.White;
            activeProgramToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            activeProgramToolStripMenuItem.Name = "activeProgramToolStripMenuItem";
            activeProgramToolStripMenuItem.Size = new Size(529, 44);
            activeProgramToolStripMenuItem.Text = "Active Pr&ogram";
            // 
            // commandPalletToolStripMenuItem
            // 
            commandPalletToolStripMenuItem.ForeColor = Color.White;
            commandPalletToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            commandPalletToolStripMenuItem.Name = "commandPalletToolStripMenuItem";
            commandPalletToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.P;
            commandPalletToolStripMenuItem.Size = new Size(529, 44);
            commandPalletToolStripMenuItem.Text = "&Command Palette";
            // 
            // variablesToolStripMenuItem
            // 
            variablesToolStripMenuItem.ForeColor = Color.White;
            variablesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            variablesToolStripMenuItem.Name = "variablesToolStripMenuItem";
            variablesToolStripMenuItem.Size = new Size(529, 44);
            variablesToolStripMenuItem.Text = "&Variables";
            // 
            // propertiesToolStripMenuItem
            // 
            propertiesToolStripMenuItem.ForeColor = Color.White;
            propertiesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            propertiesToolStripMenuItem.Size = new Size(529, 44);
            propertiesToolStripMenuItem.Text = "&Program Properties";
            // 
            // toolStripSeparator26
            // 
            toolStripSeparator26.Name = "toolStripSeparator26";
            toolStripSeparator26.Size = new Size(526, 6);
            // 
            // btnRunPrg
            // 
            btnRunPrg.ForeColor = Color.White;
            btnRunPrg.ImageScaling = ToolStripItemImageScaling.None;
            btnRunPrg.Name = "btnRunPrg";
            btnRunPrg.ShortcutKeys = Keys.Control | Keys.Space;
            btnRunPrg.Size = new Size(529, 44);
            btnRunPrg.Text = "R&un Program from Start";
            // 
            // runProgramToolStripMenuItem
            // 
            runProgramToolStripMenuItem.ForeColor = Color.White;
            runProgramToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            runProgramToolStripMenuItem.Name = "runProgramToolStripMenuItem";
            runProgramToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Space;
            runProgramToolStripMenuItem.Size = new Size(529, 44);
            runProgramToolStripMenuItem.Text = "Run Progra&m";
            // 
            // btnPausePrg
            // 
            btnPausePrg.Enabled = false;
            btnPausePrg.ForeColor = Color.White;
            btnPausePrg.ImageScaling = ToolStripItemImageScaling.None;
            btnPausePrg.Name = "btnPausePrg";
            btnPausePrg.Size = new Size(529, 44);
            btnPausePrg.Text = "Pause Pro&gram";
            // 
            // btnStopPrg
            // 
            btnStopPrg.Enabled = false;
            btnStopPrg.ForeColor = Color.White;
            btnStopPrg.ImageScaling = ToolStripItemImageScaling.None;
            btnStopPrg.Name = "btnStopPrg";
            btnStopPrg.ShortcutKeys = Keys.Control | Keys.End;
            btnStopPrg.Size = new Size(529, 44);
            btnStopPrg.Text = "S&top Program";
            // 
            // toolStripSeparator27
            // 
            toolStripSeparator27.Name = "toolStripSeparator27";
            toolStripSeparator27.Size = new Size(526, 6);
            // 
            // newProgramToolStripMenuItem
            // 
            newProgramToolStripMenuItem.ForeColor = Color.White;
            newProgramToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            newProgramToolStripMenuItem.Name = "newProgramToolStripMenuItem";
            newProgramToolStripMenuItem.Size = new Size(529, 44);
            newProgramToolStripMenuItem.Text = "&New Program";
            // 
            // removeProgramToolStripMenuItem
            // 
            removeProgramToolStripMenuItem.ForeColor = Color.White;
            removeProgramToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            removeProgramToolStripMenuItem.Name = "removeProgramToolStripMenuItem";
            removeProgramToolStripMenuItem.Size = new Size(529, 44);
            removeProgramToolStripMenuItem.Text = "Remo&ve Program";
            // 
            // extensionsToolStripMenuItem
            // 
            extensionsToolStripMenuItem.ForeColor = Color.White;
            extensionsToolStripMenuItem.Name = "extensionsToolStripMenuItem";
            extensionsToolStripMenuItem.Size = new Size(146, 36);
            extensionsToolStripMenuItem.Text = "E&xtensions";
            extensionsToolStripMenuItem.Visible = false;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { keyPadToolStripMenuItem, btnMonitor, modbusRegistersToolStripMenuItem, modbusQueryEditorToolStripMenuItem, oscilloscopeToolStripMenuItem, toolStripSeparator14, textComparatorToolStripMenuItem, toolStripSeparator31, deviceManagerToolStripMenuItem, toolStripSeparator40, customizeToolStripMenuItem, optionsToolStripMenuItem });
            toolsToolStripMenuItem.ForeColor = Color.White;
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(89, 36);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // keyPadToolStripMenuItem
            // 
            keyPadToolStripMenuItem.ForeColor = Color.White;
            keyPadToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            keyPadToolStripMenuItem.Name = "keyPadToolStripMenuItem";
            keyPadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.K;
            keyPadToolStripMenuItem.Size = new Size(491, 44);
            keyPadToolStripMenuItem.Text = "&Keypad";
            // 
            // btnMonitor
            // 
            btnMonitor.ForeColor = Color.White;
            btnMonitor.ImageScaling = ToolStripItemImageScaling.None;
            btnMonitor.Name = "btnMonitor";
            btnMonitor.ShortcutKeys = Keys.Control | Keys.M;
            btnMonitor.Size = new Size(491, 44);
            btnMonitor.Text = "&Monitor";
            // 
            // modbusRegistersToolStripMenuItem
            // 
            modbusRegistersToolStripMenuItem.ForeColor = Color.White;
            modbusRegistersToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            modbusRegistersToolStripMenuItem.Name = "modbusRegistersToolStripMenuItem";
            modbusRegistersToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.M;
            modbusRegistersToolStripMenuItem.Size = new Size(491, 44);
            modbusRegistersToolStripMenuItem.Text = "Modbus &Registers";
            // 
            // modbusQueryEditorToolStripMenuItem
            // 
            modbusQueryEditorToolStripMenuItem.ForeColor = Color.White;
            modbusQueryEditorToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            modbusQueryEditorToolStripMenuItem.Name = "modbusQueryEditorToolStripMenuItem";
            modbusQueryEditorToolStripMenuItem.Size = new Size(491, 44);
            modbusQueryEditorToolStripMenuItem.Text = "Modbus &Query Editor";
            modbusQueryEditorToolStripMenuItem.Click += modbusQueryEditorToolStripMenuItem_Click;
            // 
            // oscilloscopeToolStripMenuItem
            // 
            oscilloscopeToolStripMenuItem.ForeColor = Color.White;
            oscilloscopeToolStripMenuItem.Name = "oscilloscopeToolStripMenuItem";
            oscilloscopeToolStripMenuItem.Size = new Size(491, 44);
            oscilloscopeToolStripMenuItem.Text = "O&scilloscope";
            oscilloscopeToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator14
            // 
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new Size(488, 6);
            // 
            // textComparatorToolStripMenuItem
            // 
            textComparatorToolStripMenuItem.ForeColor = Color.White;
            textComparatorToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            textComparatorToolStripMenuItem.Name = "textComparatorToolStripMenuItem";
            textComparatorToolStripMenuItem.Size = new Size(491, 44);
            textComparatorToolStripMenuItem.Text = "&Text Comparator";
            // 
            // toolStripSeparator31
            // 
            toolStripSeparator31.Name = "toolStripSeparator31";
            toolStripSeparator31.Size = new Size(488, 6);
            // 
            // deviceManagerToolStripMenuItem
            // 
            deviceManagerToolStripMenuItem.ForeColor = Color.White;
            deviceManagerToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deviceManagerToolStripMenuItem.Name = "deviceManagerToolStripMenuItem";
            deviceManagerToolStripMenuItem.Size = new Size(491, 44);
            deviceManagerToolStripMenuItem.Text = "Device Manager";
            // 
            // toolStripSeparator40
            // 
            toolStripSeparator40.Name = "toolStripSeparator40";
            toolStripSeparator40.Size = new Size(488, 6);
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.ForeColor = Color.White;
            customizeToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new Size(491, 44);
            customizeToolStripMenuItem.Text = "&Customize";
            customizeToolStripMenuItem.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.ForeColor = Color.White;
            optionsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            optionsToolStripMenuItem.Size = new Size(491, 44);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // windowToolStripMenuItem
            // 
            windowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnWinWindowManager, btnWinCloseAll, toolStripSeparator42 });
            windowToolStripMenuItem.ForeColor = Color.White;
            windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            windowToolStripMenuItem.Size = new Size(121, 36);
            windowToolStripMenuItem.Text = "&Window";
            // 
            // btnWinWindowManager
            // 
            btnWinWindowManager.ForeColor = Color.White;
            btnWinWindowManager.ImageScaling = ToolStripItemImageScaling.None;
            btnWinWindowManager.Name = "btnWinWindowManager";
            btnWinWindowManager.Size = new Size(336, 44);
            btnWinWindowManager.Text = "&Window Manager";
            // 
            // btnWinCloseAll
            // 
            btnWinCloseAll.ForeColor = Color.White;
            btnWinCloseAll.ImageScaling = ToolStripItemImageScaling.None;
            btnWinCloseAll.Name = "btnWinCloseAll";
            btnWinCloseAll.Size = new Size(336, 44);
            btnWinCloseAll.Text = "&Close All";
            // 
            // toolStripSeparator42
            // 
            toolStripSeparator42.Name = "toolStripSeparator42";
            toolStripSeparator42.Size = new Size(333, 6);
            toolStripSeparator42.Visible = false;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { contentsToolStripMenuItem, indexToolStripMenuItem, searchToolStripMenuItem, toolStripSeparator10, aboutToolStripMenuItem });
            helpToolStripMenuItem.ForeColor = Color.White;
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(84, 36);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.Enabled = false;
            contentsToolStripMenuItem.ForeColor = Color.White;
            contentsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.Size = new Size(370, 44);
            contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.Enabled = false;
            indexToolStripMenuItem.ForeColor = Color.White;
            indexToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new Size(370, 44);
            indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.Enabled = false;
            searchToolStripMenuItem.ForeColor = Color.White;
            searchToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(370, 44);
            searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(367, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.ForeColor = Color.White;
            aboutToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(370, 44);
            aboutToolStripMenuItem.Text = "&About Serial Monitor";
            // 
            // cmStepPrg
            // 
            cmStepPrg.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmStepPrg.BorderColor = Color.Black;
            cmStepPrg.DropShadowEnabled = false;
            cmStepPrg.ForeColor = Color.White;
            cmStepPrg.ImageScalingSize = new Size(32, 32);
            cmStepPrg.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmStepPrg.MenuBackColorNorth = Color.FromArgb(20, 20, 20);
            cmStepPrg.MenuBackColorSouth = Color.FromArgb(20, 20, 20);
            cmStepPrg.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmStepPrg.Name = "cmStepPrg";
            cmStepPrg.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmStepPrg.ShowInsetShadow = false;
            cmStepPrg.ShowItemInsetShadow = false;
            cmStepPrg.Size = new Size(61, 4);
            // 
            // tmrProg
            // 
            tmrProg.Enabled = true;
            tmrProg.Interval = 1;
            // 
            // pnlStepProgram
            // 
            pnlStepProgram.ArrowColor = Color.DarkGray;
            pnlStepProgram.ArrowMouseOverColor = Color.DodgerBlue;
            pnlStepProgram.CloseColor = Color.DarkGray;
            pnlStepProgram.CloseMouseOverColor = Color.Brown;
            pnlStepProgram.Collapsed = false;
            pnlStepProgram.Controls.Add(lstStepProgram);
            pnlStepProgram.Controls.Add(thPrograms);
            pnlStepProgram.Dock = DockStyle.Bottom;
            pnlStepProgram.DropShadow = false;
            pnlStepProgram.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            pnlStepProgram.FixedInlineWidth = false;
            pnlStepProgram.Inlinelabel = false;
            pnlStepProgram.InlineWidth = 100;
            pnlStepProgram.LabelBackColor = Color.FromArgb(31, 31, 31);
            pnlStepProgram.LabelFont = new Font("Segoe UI", 8F);
            pnlStepProgram.LabelForeColor = Color.WhiteSmoke;
            pnlStepProgram.Location = new Point(0, 498);
            pnlStepProgram.Margin = new Padding(6);
            pnlStepProgram.Name = "pnlStepProgram";
            pnlStepProgram.OverrideCollapseControl = true;
            pnlStepProgram.Padding = new Padding(0, 41, 0, 0);
            pnlStepProgram.PanelCollapsible = true;
            pnlStepProgram.ResizeControl = ODModules.LabelPanel.ResizeDirection.Top;
            pnlStepProgram.SeparatorColor = Color.Gray;
            pnlStepProgram.ShowCloseButton = true;
            pnlStepProgram.ShowSeparator = false;
            pnlStepProgram.Size = new Size(1177, 337);
            pnlStepProgram.TabIndex = 3;
            pnlStepProgram.Text = "Step Program";
            // 
            // thPrograms
            // 
            thPrograms.AddHoverColor = Color.LimeGreen;
            thPrograms.AllowDragReordering = true;
            thPrograms.AllowTabResize = true;
            thPrograms.ArrowColor = Color.DarkGray;
            thPrograms.ArrowDisabledColor = Color.FromArgb(128, 0, 0, 0);
            thPrograms.ArrowHoverColor = Color.SteelBlue;
            thPrograms.BackColor = Color.FromArgb(31, 31, 31);
            thPrograms.BindedTabControl = null;
            thPrograms.BorderColor = Color.Gray;
            thPrograms.Borders = ODModules.Borders.None;
            thPrograms.CloseHoverColor = Color.Brown;
            thPrograms.Dock = DockStyle.Top;
            thPrograms.ForeColor = Color.White;
            thPrograms.HeaderDownForeColor = Color.Gray;
            thPrograms.HeaderForeColor = Color.Black;
            thPrograms.HeaderHoverForeColor = Color.Blue;
            thPrograms.Location = new Point(0, 41);
            thPrograms.Margin = new Padding(6);
            thPrograms.Name = "thPrograms";
            thPrograms.Padding = new Padding(9, 0, 0, 0);
            thPrograms.SelectedIndex = 0;
            thPrograms.ShowAddButton = true;
            thPrograms.ShowHeader = false;
            thPrograms.ShowTabDividers = true;
            thPrograms.ShowTabs = true;
            thPrograms.Size = new Size(1177, 58);
            thPrograms.TabBackColor = Color.Transparent;
            thPrograms.TabBorderColor = Color.Transparent;
            thPrograms.TabClickedBackColor = Color.DarkGray;
            thPrograms.TabDividerColor = Color.White;
            thPrograms.TabHoverBackColor = Color.LightGray;
            thPrograms.TabIndex = 2;
            thPrograms.TabRuleColor = Color.FromArgb(100, 128, 128, 128);
            tab1.Selected = true;
            tab1.Tag = null;
            tab1.Text = "Main";
            thPrograms.Tabs.Add(tab1);
            thPrograms.TabSelectedBackColor = Color.FromArgb(100, 128, 128, 128);
            thPrograms.TabSelectedBorderColor = Color.FromArgb(100, 128, 128, 128);
            thPrograms.TabSelectedForeColor = Color.WhiteSmoke;
            thPrograms.TabSelectedShadowColor = Color.Black;
            thPrograms.TabStyle = ODModules.TabHeader.TabStyles.Normal;
            thPrograms.UseBindingTabControl = false;
            // 
            // pnlMainConsole
            // 
            pnlMainConsole.Controls.Add(Output);
            pnlMainConsole.Controls.Add(pnlRenamePanel);
            pnlMainConsole.Controls.Add(navigator1);
            pnlMainConsole.Dock = DockStyle.Fill;
            pnlMainConsole.Location = new Point(0, 82);
            pnlMainConsole.Margin = new Padding(6);
            pnlMainConsole.Name = "pnlMainConsole";
            pnlMainConsole.Size = new Size(1177, 416);
            pnlMainConsole.TabIndex = 3;
            // 
            // Output
            // 
            Output.AllowCommandEntry = true;
            Output.AllowMouseSelection = false;
            Output.AllowMouseWheelZoom = false;
            Output.BufferLength = 10000;
            Output.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            Output.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            Output.CursorFlashSpeed = 0.5F;
            Output.Dock = DockStyle.Fill;
            Output.ExtraLineAfterCommandEntered = false;
            Output.FlashCursor = false;
            Output.Font = new Font("Consolas", 9F);
            Output.ForeColor = Color.FromArgb(255, 255, 192);
            Output.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            Output.LineFormatting = true;
            Output.Location = new Point(150, 40);
            Output.Margin = new Padding(6);
            Output.MaximumLength = 100;
            Output.Name = "Output";
            Output.OriginForeColor = Color.Silver;
            Output.Padding = new Padding(9, 11, 0, 0);
            Output.PrintOnEntry = true;
            Output.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            Output.ScrollBarNorth = Color.FromArgb(64, 64, 64);
            Output.ScrollBarSouth = Color.FromArgb(64, 64, 64);
            Output.SecondaryFont = new Font("Segoe UI", 9F);
            Output.SelectionColor = Color.FromArgb(47, 47, 74);
            Output.ShowOrigin = true;
            Output.Size = new Size(1027, 376);
            Output.TabIndex = 0;
            Output.TimeStampForeColor = Color.Gray;
            Output.TimeStamps = ODModules.ConsoleInterface.TimeStampFormat.NoTimeStamps;
            Output.VerScroll = 0;
            Output.Zoom = 100;
            // 
            // smMain
            // 
            smMain.BackColorNorth = Color.DodgerBlue;
            smMain.BackColorNorthFadeIn = Color.DodgerBlue;
            smMain.BackColorSouth = Color.DodgerBlue;
            smMain.ImageScalingSize = new Size(32, 32);
            smMain.ItemForeColor = Color.Black;
            smMain.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, lblTxBytes, toolStripStatusLabel3, lblRxBytes, toolStripDropDownButton1 });
            smMain.ItemSelectedBackColorNorth = Color.White;
            smMain.ItemSelectedBackColorSouth = Color.White;
            smMain.ItemSelectedForeColor = Color.Black;
            smMain.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            smMain.Location = new Point(0, 835);
            smMain.MenuBackColorNorth = Color.Gray;
            smMain.MenuBackColorSouth = Color.Silver;
            smMain.MenuBorderColor = Color.WhiteSmoke;
            smMain.MenuSeparatorColor = Color.WhiteSmoke;
            smMain.MenuSymbolColor = Color.WhiteSmoke;
            smMain.Name = "smMain";
            smMain.Padding = new Padding(2, 0, 26, 0);
            smMain.Size = new Size(1177, 42);
            smMain.SizingGrip = false;
            smMain.StripItemSelectedBackColorNorth = Color.White;
            smMain.StripItemSelectedBackColorSouth = Color.White;
            smMain.TabIndex = 4;
            smMain.Text = "Status Menu";
            smMain.UseNorthFadeIn = false;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.ForeColor = Color.Silver;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(46, 32);
            toolStripStatusLabel1.Text = "TX:";
            // 
            // lblTxBytes
            // 
            lblTxBytes.ForeColor = Color.White;
            lblTxBytes.Name = "lblTxBytes";
            lblTxBytes.Size = new Size(27, 32);
            lblTxBytes.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.ForeColor = Color.Silver;
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(47, 32);
            toolStripStatusLabel3.Text = "RX:";
            // 
            // lblRxBytes
            // 
            lblRxBytes.ForeColor = Color.White;
            lblRxBytes.Name = "lblRxBytes";
            lblRxBytes.Size = new Size(27, 32);
            lblRxBytes.Text = "0";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { noneToolStripMenuItem, lFToolStripMenuItem, cRLFToolStripMenuItem, cRToolStripMenuItem });
            toolStripDropDownButton1.ForeColor = Color.White;
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageScaling = ToolStripItemImageScaling.None;
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(95, 38);
            toolStripDropDownButton1.Text = "None";
            toolStripDropDownButton1.Visible = false;
            // 
            // noneToolStripMenuItem
            // 
            noneToolStripMenuItem.ForeColor = Color.Black;
            noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            noneToolStripMenuItem.Size = new Size(206, 44);
            noneToolStripMenuItem.Text = "None";
            // 
            // lFToolStripMenuItem
            // 
            lFToolStripMenuItem.ForeColor = Color.Black;
            lFToolStripMenuItem.Name = "lFToolStripMenuItem";
            lFToolStripMenuItem.Size = new Size(206, 44);
            lFToolStripMenuItem.Text = "LF";
            // 
            // cRLFToolStripMenuItem
            // 
            cRLFToolStripMenuItem.ForeColor = Color.Black;
            cRLFToolStripMenuItem.Name = "cRLFToolStripMenuItem";
            cRLFToolStripMenuItem.Size = new Size(206, 44);
            cRLFToolStripMenuItem.Text = "CR LF";
            // 
            // cRToolStripMenuItem
            // 
            cRToolStripMenuItem.ForeColor = Color.Black;
            cRToolStripMenuItem.Name = "cRToolStripMenuItem";
            cRToolStripMenuItem.Size = new Size(206, 44);
            cRToolStripMenuItem.Text = "CR";
            // 
            // cmPrograms
            // 
            cmPrograms.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmPrograms.BorderColor = Color.Black;
            cmPrograms.DropShadowEnabled = false;
            cmPrograms.ForeColor = Color.White;
            cmPrograms.ImageScalingSize = new Size(32, 32);
            cmPrograms.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmPrograms.Items.AddRange(new ToolStripItem[] { cmRunProgram, cmbtnSetAsActive, toolStripSeparator29, renameToolStripMenuItem, cmbtnProperties, toolStripSeparator30, cmbtnNewProgram, cmCloseProgram });
            cmPrograms.MenuBackColorNorth = Color.DodgerBlue;
            cmPrograms.MenuBackColorSouth = Color.DodgerBlue;
            cmPrograms.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmPrograms.Name = "cmPrograms";
            cmPrograms.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmPrograms.ShowInsetShadow = false;
            cmPrograms.ShowItemInsetShadow = false;
            cmPrograms.Size = new Size(321, 244);
            // 
            // cmRunProgram
            // 
            cmRunProgram.ImageScaling = ToolStripItemImageScaling.None;
            cmRunProgram.Name = "cmRunProgram";
            cmRunProgram.Size = new Size(320, 38);
            cmRunProgram.Text = "Run Program";
            // 
            // cmbtnSetAsActive
            // 
            cmbtnSetAsActive.ImageScaling = ToolStripItemImageScaling.None;
            cmbtnSetAsActive.Name = "cmbtnSetAsActive";
            cmbtnSetAsActive.Size = new Size(320, 38);
            cmbtnSetAsActive.Text = "Set as Active Program";
            // 
            // toolStripSeparator29
            // 
            toolStripSeparator29.Name = "toolStripSeparator29";
            toolStripSeparator29.Size = new Size(317, 6);
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.Size = new Size(320, 38);
            renameToolStripMenuItem.Text = "Rename";
            // 
            // cmbtnProperties
            // 
            cmbtnProperties.ImageScaling = ToolStripItemImageScaling.None;
            cmbtnProperties.Name = "cmbtnProperties";
            cmbtnProperties.Size = new Size(320, 38);
            cmbtnProperties.Text = "Properties";
            // 
            // toolStripSeparator30
            // 
            toolStripSeparator30.Name = "toolStripSeparator30";
            toolStripSeparator30.Size = new Size(317, 6);
            // 
            // cmbtnNewProgram
            // 
            cmbtnNewProgram.ImageScaling = ToolStripItemImageScaling.None;
            cmbtnNewProgram.Name = "cmbtnNewProgram";
            cmbtnNewProgram.Size = new Size(320, 38);
            cmbtnNewProgram.Text = "New Program";
            // 
            // cmCloseProgram
            // 
            cmCloseProgram.ImageScaling = ToolStripItemImageScaling.None;
            cmCloseProgram.Name = "cmCloseProgram";
            cmCloseProgram.Size = new Size(320, 38);
            cmCloseProgram.Text = "Close Program";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1177, 877);
            Controls.Add(pnlMainConsole);
            Controls.Add(pnlStepProgram);
            Controls.Add(tsMain);
            Controls.Add(msMain);
            Controls.Add(smMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(0, 0);
            MainMenuStrip = msMain;
            Margin = new Padding(6);
            Name = "MainWindow";
            Text = "Untitled - Serial Monitor";
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            pnlRenamePanel.ResumeLayout(false);
            pnlRenamePanel.PerformLayout();
            panel2.ResumeLayout(false);
            cmChannels.ResumeLayout(false);
            cmStepEditor.ResumeLayout(false);
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            pnlStepProgram.ResumeLayout(false);
            pnlMainConsole.ResumeLayout(false);
            pnlMainConsole.PerformLayout();
            smMain.ResumeLayout(false);
            smMain.PerformLayout();
            cmPrograms.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.ToolStrip tsMain;
        private ToolStripDropDownButton ddbPorts;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton ddbBAUDRate;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnConnect;
        private ToolStripButton btnDisconnect;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripDropDownButton ddbOutputFormat;
        private ToolStripDropDownButton ddbParity;
        private ToolStripDropDownButton ddbStopBits;
        private ToolStripMenuItem btnStopBitsNone;
        private ToolStripMenuItem btnStopBits1;
        private ToolStripMenuItem btnStopBits15;
        private ToolStripMenuItem btnStopBits2;
        private ToolStripDropDownButton ddbBits;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem btnParityNone;
        private ToolStripMenuItem btnParityEven;
        private ToolStripMenuItem btnParityOdd;
        private ToolStripMenuItem btnParitySpace;
        private ToolStripMenuItem btnParityMark;
        private ToolStripMenuItem btnBits5;
        private ToolStripMenuItem btnBits6;
        private ToolStripMenuItem btnBits7;
        private ToolStripMenuItem btnBits8;
        private ToolStripDropDownButton ddbInputFormat;
        private ToolStripButton btnStop;
        private ToolStripButton btnPause;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnClearTerminal;
        private ToolStripButton btnTopMost;
        private ODModules.MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem btnNewStep;
        private ToolStripMenuItem btnOpenStep;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem btnSaveStep;
        private ToolStripMenuItem btnSaveAsStep;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem btnPrint;
        private ToolStripMenuItem btnPrintPreview;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem btnMenuExit;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem contentsToolStripMenuItem;
        private ToolStripMenuItem indexToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem btnMenuClearTerminal;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem zoomToolStripMenuItem;
        private ToolStripMenuItem btnZoom50;
        private ToolStripMenuItem btnZoom75;
        private ToolStripMenuItem btnZoom100;
        private ToolStripMenuItem btnZoom110;
        private ToolStripMenuItem btnZoom120;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem btnMenuTopMost;
        private ToolStripMenuItem btnMenuFullScreen;
        private ToolStripMenuItem btnOptViewDataOnly;
        private ToolStripMenuItem btnOptViewTime;
        private ToolStripMenuItem btnOptViewDate;
        private ToolStripMenuItem btnOptViewDateTime;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem btnMenuShowStepPrg;
        private ODModules.Navigator navigator1;
        //private ToolStripMenuItem monitorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem btnMonitor;
        private ToolStripSeparator toolStripSeparator15;
        private Panel pnlRenamePanel;
        private TextBox textBox1;
        private Panel panel2;
        private ODModules.Button button1;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripMenuItem btnOptViewSource;
        private ODModules.ContextMenu cmStepPrg;
        private ToolStripMenuItem programToolStripMenuItem;
        private ToolStripMenuItem addCommandToolStripMenuItem;
        private ToolStripMenuItem btnPrgRemoveStepLines;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripMenuItem btnPrgMoveUp;
        private ToolStripMenuItem btnPrgMoveDown;
        private System.Windows.Forms.Timer tmrProg;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripMenuItem btnRunPrg;
        private ToolStripMenuItem btnPausePrg;
        private ToolStripMenuItem btnStopPrg;
        private ODModules.ContextMenu cmStepEditor;
        private ToolStripMenuItem addCommandToolStripMenuItem1;
        private ToolStripMenuItem removeSelectedToolStripMenuItem;
        private ToolStripMenuItem btnEnableSelected;
        private ToolStripMenuItem btnToggleSelected;
        private ToolStripMenuItem btnDisableSelected;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripSeparator toolStripSeparator20;
        private ToolStripMenuItem enableSelectedToolStripMenuItem1;
        private ToolStripMenuItem disableSelectedToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator21;
        private ToolStripMenuItem runToolStripMenuItem;
        private ToolStripMenuItem pauseToolStripMenuItem;
        private ToolStripMenuItem stopToolStripMenuItem;
        private ODModules.LabelPanel pnlStepProgram;
        private Panel pnlMainConsole;
        private ToolStripMenuItem setStepCursorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator22;
        private ToolStripMenuItem runProgramToolStripMenuItem;
        //private ToolStripButton toolStripButton1;
        private ToolStripButton btnRunCursor;
        private ToolStripMenuItem mitChannel;
        private ToolStripMenuItem btnNewChannel;
        private ToolStripMenuItem btnRemoveChannel;
        private ToolStripSeparator toolStripSeparator23;
        private ToolStripMenuItem btnRenameChannel;
        private ToolStripMenuItem btnRecentProjects;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem channelsToolStripMenuItem;
        private ODModules.StatusMenu smMain;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel lblTxBytes;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel lblRxBytes;
        private ToolStripMenuItem keyPadToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator24;
        private ToolStripMenuItem btnMenuModbusMaster;
        private ToolStripMenuItem modbusRegistersToolStripMenuItem;
        private ToolStripSplitButton btnRun;
        private ToolStripMenuItem runFromStartToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator25;
        private ToolStripMenuItem activeProgramToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator26;
        private ToolStripMenuItem propertiesToolStripMenuItem;
        private ODModules.TabHeader thPrograms;
        private ToolStripSeparator toolStripSeparator27;
        private ToolStripMenuItem newProgramToolStripMenuItem;
        private ToolStripMenuItem removeProgramToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator28;
        private ToolStripMenuItem btnChannelPort;
        private ToolStripMenuItem btnChannelBaud;
        private ToolStripMenuItem btnChannelDataBits;
        private ToolStripMenuItem btnChannelParity;
        private ToolStripMenuItem btnChannelStopBits;
        private ToolStripMenuItem btnChanDB5;
        private ToolStripMenuItem btnChanDB6;
        private ToolStripMenuItem btnChanDB7;
        private ToolStripMenuItem btnChanDB;
        private ToolStripMenuItem btnChannelNoParity;
        private ToolStripMenuItem btnChannelEvenParity;
        private ToolStripMenuItem btnChannelOddParity;
        private ToolStripMenuItem btnChannelSpaceParity;
        private ToolStripMenuItem btnChannelMarkParity;
        private ToolStripMenuItem btnChannelStopBits0;
        private ToolStripMenuItem btnChannelStopBits1;
        private ToolStripMenuItem btnChannelStopBits15;
        private ToolStripMenuItem btnChannelStopBits2;
        private ToolStripMenuItem ddbChannels;
        private ToolStripMenuItem commandPalletToolStripMenuItem;
        private ODModules.ContextMenu cmPrograms;
        private ToolStripMenuItem cmRunProgram;
        private ToolStripMenuItem cmCloseProgram;
        private ToolStripMenuItem cmbtnSetAsActive;
        private ToolStripSeparator toolStripSeparator29;
        private ToolStripMenuItem cmbtnProperties;
        private ToolStripSeparator toolStripSeparator30;
        private ToolStripMenuItem cmbtnNewProgram;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStripMenuItem textComparatorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator31;
        public ODModules.ConsoleInterface Output;
        private ToolStripSeparator toolStripSeparator32;
        private ToolStripMenuItem btnChannelInputFormat;
        private ToolStripMenuItem btnChannelOutputFormat;
        private ToolStripMenuItem cutToolStripMenuItem1;
        private ToolStripMenuItem copyToolStripMenuItem1;
        private ToolStripMenuItem pasteToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator33;
        private ToolStripMenuItem btnMenuConnect;
        private ToolStripMenuItem btnMenuDisconnect;
        private ToolStripSeparator toolStripSeparator34;
        private ToolStripMenuItem btnZoom150;
        private ToolStripMenuItem btnZoom175;
        private ToolStripMenuItem btnZoom200;
        private ToolStripMenuItem btnZoom300;
        private ODModules.ContextMenu cmChannels;
        private ToolStripMenuItem newChannelToolStripMenuItem;
        private ToolStripMenuItem removeChannelToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator35;
        private ToolStripMenuItem renameChannelToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator36;
        private ToolStripMenuItem connectToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ToolStripMenuItem modbusMasterToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator37;
        private ToolStripMenuItem btnMenuOutputMaster;
        private ToolStripMenuItem outputInTerminalToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator38;
        private ToolStripMenuItem btnMenuOpenNewTerminal;
        private ToolStripSeparator toolStripSeparator39;
        private ToolStripMenuItem resetCountersToolStripMenuItem;
        private ToolStripMenuItem btnChannelFlowCtrl;
        private ToolStripMenuItem btnChannelFlowNone;
        private ToolStripMenuItem btnChannelFlowXONXOFF;
        private ToolStripMenuItem btnChannelFlowRTSCTS;
        private ToolStripMenuItem btnChannelFlowDSRDTR;
        private ToolStripMenuItem deviceManagerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator40;
        private ToolStripMenuItem btnMenuTextFormat;
        private ToolStripMenuItem btnOptFrmLineNone;
        private ToolStripMenuItem btnOptFrmLineLF;
        private ToolStripMenuItem btnOptFrmLineCRLF;
        private ToolStripMenuItem btnOptFrmLineCR;
        private ToolStripMenuItem propertiesToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator41;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem noneToolStripMenuItem;
        private ToolStripMenuItem lFToolStripMenuItem;
        private ToolStripMenuItem cRLFToolStripMenuItem;
        private ToolStripMenuItem cRToolStripMenuItem;
        private ToolStripMenuItem btnOpenLocation;
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem btnWinWindowManager;
        private ToolStripMenuItem btnWinCloseAll;
        private ToolStripSeparator toolStripSeparator42;
        private ToolStripMenuItem oscilloscopeToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem variablesToolStripMenuItem;
        private ToolStripMenuItem extensionsToolStripMenuItem;
        public ODModules.ListControl lstStepProgram;
        private ToolStripMenuItem addCommandAfterToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator43;
        private ToolStripMenuItem sendFileToolStripMenuItem;
        private ToolStripMenuItem btnallowEscapeCharacters;
        private ToolStripMenuItem modbusQueryEditorToolStripMenuItem;
        private ToolStripMenuItem scanPortsToolStripMenuItem;
    }
}