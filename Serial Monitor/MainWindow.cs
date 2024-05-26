
using System.IO.Ports;
using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using Svg;
using static System.Windows.Forms.LinkLabel;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Interfaces;
using System.Management;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using Serial_Monitor.WindowForms;
using static Serial_Monitor.Classes.Enums.FormatEnums;
using Serial_Monitor.Classes.Structures;
using Serial_Monitor.Plugin;
using System.Linq.Expressions;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Text;

namespace Serial_Monitor {
    public partial class MainWindow : Form, Interfaces.ITheme, IMessageFilter, IMouseHandler {
        public event CCommandProcessedHandler? CommandProcessed;
        public delegate void CCommandProcessedHandler(object? sender, string Data);

        protected override CreateParams CreateParams {
            get {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        SerialManager? currentManager = null;
        SerialManager? CurrentManager {
            get { return currentManager; }
            set {
                currentManager = value;
                SystemManager.InvokeChannelSelectedChanged(currentManager);
                InvokePropertyChange();
            }
        }
        private void InvokePropertyChange() {
            if (currentManager != null) {
                ddbBAUDRate.Text = currentManager.BaudRate.ToString();
                ddbBAUDRate.Tag = currentManager.BaudRate;
                SystemManager.CheckFormatOption(currentManager.BaudRate, ddbBAUDRate);
                SystemManager.CheckFormatOption(currentManager.BaudRate, btnChannelBaud);
                ddbBits.Text = currentManager.DataBits.ToString();
                ddbBits.Tag = currentManager.DataBits.ToString();
                CheckBits(ddbBits.Text ?? "");
                string StopBits = EnumManager.StopBitsToString(currentManager.StopBits);
                ddbStopBits.Text = StopBits;
                ddbStopBits.Tag = StopBits;
                CheckStopBits(ddbStopBits.Text);
                string Parity = EnumManager.ParityToString(currentManager.Parity);
                ddbParity.Text = Parity;
                ddbParity.Tag = Parity;
                SystemManager.CheckFormatOption(ddbParity.Text, ddbParity);
                SystemManager.CheckFormatOption(ddbParity.Text, btnChannelParity);
                StringPair SelectIn = EnumManager.InputFormatToString(currentManager.InputFormat, false);
                StringPair SelectOut = EnumManager.OutputFormatToString(currentManager.OutputFormat, false);
                ddbInputFormat.Text = SelectIn.A;
                ddbInputFormat.Tag = SelectIn.B;
                SystemManager.CheckFormatOption(SelectIn.B, ddbInputFormat);
                SystemManager.CheckFormatOption(SelectIn.B, btnChannelInputFormat);
                ddbOutputFormat.Text = SelectOut.A;
                ddbOutputFormat.Tag = SelectOut.B;
                SystemManager.CheckFormatOption(SelectOut.B, ddbOutputFormat);
                SystemManager.CheckFormatOption(SelectOut.B, btnChannelOutputFormat);
                ddbPorts.Text = currentManager.PortName;
                SystemRunning(currentManager.Connected);
                btnMenuModbusMaster.Checked = currentManager.IsMaster;
                SystemManager.CheckFormatOption(EnumManager.HandshakeToString(currentManager.Handshake), btnChannelFlowCtrl);
                CheckLineFormat();
            }
        }
        private void Setup() {
            InitializeComponent();
            LoadEventHandlers();
            SystemManager.MainInstance = this;
            thPrograms.Tabs.Clear();
            NewProgram("Main");
            lstStepProgram.ExternalItems = ProgramManager.Programs[0].Program;
            lstStepProgram.Tag = ProgramManager.Programs[0];
            ProgramManager.CurrentEditingProgram = ProgramManager.Programs[0];
            ProgramManager.CurrentProgram = ProgramManager.Programs[0];

            ProgramManager.ProgramSettingChanged += ProgramManager_ProgramSettingChanged;
            ProgramManager.ProgramNameChanged += ProgramManager_ProgramNameChanged;
            SystemManager.ChannelRemoved += SystemManager_ChannelRemoved;
            SystemManager.ChannelAdded += SystemManager_ChannelAdded;
            SystemManager.PortStatusChanged += SystemManager_PortStatusChanged;
            SystemManager.ProjectEdited += SystemManager_ProjectEdited;

            SystemManager.AddChannel("", SerManager_CommandProcessed, SerMan_DataReceived);
            currentManager = SystemManager.SerialManagers[0];
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            ProgramManager.LaunchThread();
            LoadRecentItems();
            ApplyLocalisation();
            DocumentEdited = false;
        }

        private void SystemManager_ProjectEdited() {
            MarkDocumentChanged();
        }

        public void ApplyLocalisation() {
            //LocalisationManager.GetLanguage(new CultureInfo("pl-PL"));

            ApplyLocalisation_File();
            ApplyLocalisation_Edit();
            ApplyLocalisation_View();
            ApplyLocalisation_Channels();
            ApplyLocalisation_Program();

            //-- Program


            LocalisationManager.ApplyText(extensionsToolStripMenuItem, "extensions");
            LocalisationManager.ApplyText(toolsToolStripMenuItem, "tools");
            LocalisationManager.ApplyText(windowToolStripMenuItem, "window");

        }
        private void ApplyLocalisation_File() {
            //-- File
            LocalisationManager.ApplyText(fileToolStripMenuItem, "file");
            LocalisationManager.ApplyText(btnNewStep, "new");
            LocalisationManager.ApplyText(btnOpenStep, "open");
            LocalisationManager.ApplyText(btnOpenLocation, "openFileLocation");
            LocalisationManager.ApplyText(btnSaveStep, "save");
            LocalisationManager.ApplyText(btnSaveAsStep, "saveAs");
            LocalisationManager.ApplyText(btnPrint, "print");
            LocalisationManager.ApplyText(btnPrintPreview, "printPreview");
            LocalisationManager.ApplyText(btnRecentProjects, "recentProjects");
            LocalisationManager.ApplyText(btnMenuExit, "exit");
        }
        private void ApplyLocalisation_Edit() {
            //-- Edit
            LocalisationManager.ApplyText(editToolStripMenuItem, "edit");
            LocalisationManager.ApplyText(undoToolStripMenuItem, "undo");
            LocalisationManager.ApplyText(redoToolStripMenuItem, "redo");
            LocalisationManager.ApplyText(cutToolStripMenuItem, "cut");
            LocalisationManager.ApplyText(cutToolStripMenuItem1, "cut");
            LocalisationManager.ApplyText(copyToolStripMenuItem, "copy");
            LocalisationManager.ApplyText(copyToolStripMenuItem1, "copy");
            LocalisationManager.ApplyText(pasteToolStripMenuItem, "paste");
            LocalisationManager.ApplyText(pasteToolStripMenuItem1, "paste");
            LocalisationManager.ApplyText(deleteToolStripMenuItem, "delete");
            LocalisationManager.ApplyText(selectAllToolStripMenuItem, "selectAll");
        }
        private void ApplyLocalisation_View() {
            //-- View
            LocalisationManager.ApplyText(viewToolStripMenuItem, "view");
            LocalisationManager.ApplyText(btnOptViewDataOnly, "viewDataOnly");
            LocalisationManager.ApplyText(btnOptViewTime, "viewTimeStamps");
            LocalisationManager.ApplyText(btnOptViewDate, "viewDateStamps");
            LocalisationManager.ApplyText(btnOptViewDateTime, "viewDateTimeStamps");
            LocalisationManager.ApplyText(btnOptViewSource, "showSource");
            LocalisationManager.ApplyText(channelsToolStripMenuItem, "channels");
            LocalisationManager.ApplyText(btnClearTerminal, "clearTerminal");
            LocalisationManager.ApplyText(btnMenuClearTerminal, "clearTerminal");
            LocalisationManager.ApplyText(zoomToolStripMenuItem, "zoom");
            LocalisationManager.ApplyText(btnMenuTopMost, "topMost");
            LocalisationManager.ApplyText(btnTopMost, "topMost");
            LocalisationManager.ApplyText(btnMenuFullScreen, "fullScreen");
        }
        private void ApplyLocalisation_Channels() {
            //-- Channel
            LocalisationManager.ApplyText(mitChannel, "channel");
            LocalisationManager.ApplyText(newChannelToolStripMenuItem, "newChannel");
            LocalisationManager.ApplyText(btnNewChannel, "newChannel");
            LocalisationManager.ApplyText(removeChannelToolStripMenuItem, "removeChannel");
            LocalisationManager.ApplyText(btnRemoveChannel, "removeChannel");
            LocalisationManager.ApplyText(ddbChannels, "switchChannel");
            LocalisationManager.ApplyText(renameChannelToolStripMenuItem, "renameChannel");
            LocalisationManager.ApplyText(btnRenameChannel, "renameChannel");
            LocalisationManager.ApplyText(outputInTerminalToolStripMenuItem, "outputInTerminal");
            LocalisationManager.ApplyText(btnMenuOutputMaster, "outputInTerminal");
            LocalisationManager.ApplyText(modbusMasterToolStripMenuItem, "modbusMaster");
            LocalisationManager.ApplyText(btnMenuModbusMaster, "modbusMaster");
            LocalisationManager.ApplyText(btnMenuTextFormat, "textFormatting");
            LocalisationManager.ApplyText(btnMenuOpenNewTerminal, "openInTerminal");
            LocalisationManager.ApplyText(connectToolStripMenuItem, "connect");
            LocalisationManager.ApplyText(btnMenuConnect, "connect");
            LocalisationManager.ApplyText(btnConnect, "connect");
            LocalisationManager.ApplyText(disconnectToolStripMenuItem, "disconnect");
            LocalisationManager.ApplyText(btnMenuDisconnect, "disconnect");
            LocalisationManager.ApplyText(btnDisconnect, "disconnect");
            LocalisationManager.ApplyText(propertiesToolStripMenuItem, "properties");
            LocalisationManager.ApplyText(propertiesToolStripMenuItem1, "properties");
            LocalisationManager.ApplyText(ddbPorts, "port");
            LocalisationManager.ApplyText(btnChannelPort, "port");
            LocalisationManager.ApplyText(ddbPorts, "port", LocalisationManager.StringApplication.ToolTips);
            LocalisationManager.ApplyText(btnChannelBaud, "baudRate");
            LocalisationManager.ApplyText(ddbBAUDRate, "baudRate", LocalisationManager.StringApplication.ToolTips);
            LocalisationManager.ApplyText(btnChannelDataBits, "dataBits");
            LocalisationManager.ApplyText(ddbBits, "dataBits", LocalisationManager.StringApplication.ToolTips);
            LocalisationManager.ApplyText(ddbParity, "parity", LocalisationManager.StringApplication.ToolTips);
            LocalisationManager.ApplyText(btnChannelParity, "parity");
            LocalisationManager.ApplyText(btnChannelStopBits, "stopBits");
            LocalisationManager.ApplyText(ddbStopBits, "stopBits", LocalisationManager.StringApplication.ToolTips);
            LocalisationManager.ApplyText(btnChannelFlowCtrl, "flowControl");
            LocalisationManager.ApplyText(ddbInputFormat, "inputFormat", LocalisationManager.StringApplication.ToolTips);
            LocalisationManager.ApplyText(btnChannelInputFormat, "inputFormat");
            LocalisationManager.ApplyText(ddbOutputFormat, "outputFormat", LocalisationManager.StringApplication.ToolTips);
            LocalisationManager.ApplyText(btnChannelOutputFormat, "outputFormat");
            LocalisationManager.ApplyText(resetCountersToolStripMenuItem, "resetCounters");
        }
        private void ApplyLocalisation_Program() {
            LocalisationManager.ApplyText(programToolStripMenuItem, "program");
            LocalisationManager.ApplyText(addCommandToolStripMenuItem, "addCommand");
            LocalisationManager.ApplyText(addCommandToolStripMenuItem1, "addCommand");
            LocalisationManager.ApplyText(removeSelectedToolStripMenuItem, "removeSelected");
            LocalisationManager.ApplyText(btnPrgRemoveStepLines, "removeSelected");
            LocalisationManager.ApplyText(btnPrgMoveDown, "moveDown");
            LocalisationManager.ApplyText(btnPrgMoveUp, "moveUp");
            LocalisationManager.ApplyText(btnEnableSelected, "enableSelected");
            LocalisationManager.ApplyText(enableSelectedToolStripMenuItem1, "enableSelected");
            LocalisationManager.ApplyText(btnDisableSelected, "disableSelected");
            LocalisationManager.ApplyText(disableSelectedToolStripMenuItem1, "disableSelected");
            LocalisationManager.ApplyText(btnToggleSelected, "toggleSelected");
            LocalisationManager.ApplyText(setStepCursorToolStripMenuItem, "setStepCursor");
            LocalisationManager.ApplyText(runFromStartToolStripMenuItem, "runProgramStart");
            LocalisationManager.ApplyText(runToolStripMenuItem, "runProgram");
            LocalisationManager.ApplyText(cmRunProgram, "runProgram");
            LocalisationManager.ApplyText(btnRunCursor, "runProgram");
            LocalisationManager.ApplyText(runProgramToolStripMenuItem, "runProgram");
            LocalisationManager.ApplyText(btnRunPrg, "runProgramStart");
            LocalisationManager.ApplyText(btnRun, "runProgram");
            LocalisationManager.ApplyText(btnPause, "pauseProgram");
            LocalisationManager.ApplyText(pauseToolStripMenuItem, "pauseProgram");
            LocalisationManager.ApplyText(btnPausePrg, "pauseProgram");
            LocalisationManager.ApplyText(btnStop, "stopProgram");
            LocalisationManager.ApplyText(stopToolStripMenuItem, "stopProgram");
            LocalisationManager.ApplyText(btnStopPrg, "stopProgram");
            LocalisationManager.ApplyText(newProgramToolStripMenuItem, "newProgram");
            LocalisationManager.ApplyText(cmbtnNewProgram, "newProgram");
            LocalisationManager.ApplyText(removeProgramToolStripMenuItem, "removeProgram");
            LocalisationManager.ApplyText(cmCloseProgram, "removeProgram");
        }

        private void LoadEventHandlers() {
            ddbPorts.DropDownOpening += ddbPorts_DropDownOpening;
            ddbPorts.Click += ddbPorts_Click;
            btnBits5.Click += btnBits5_Click;
            btnBits6.Click += btnBits6_Click;
            btnBits7.Click += btnBits7_Click;
            btnBits8.Click += btnBits8_Click;
            btnParityNone.Click += btnParityNone_Click;
            btnParityEven.Click += btnParityEven_Click;
            btnParityOdd.Click += btnParityOdd_Click;
            btnParitySpace.Click += btnParitySpace_Click;
            btnParityMark.Click += btnParityMark_Click;
            btnStopBitsNone.Click += btnStopBitsNone_Click;
            btnStopBits1.Click += btnStopBits1_Click;
            btnStopBits15.Click += btnStopBits15_Click;
            btnStopBits2.Click += btnStopBits2_Click;
            btnConnect.Click += btnConnect_Click;
            btnDisconnect.Click += btnDisconnect_Click;
            btnRun.ButtonClick += btnRun_ButtonClick;
            btnRun.DropDownOpening += btnRun_DropDownOpening;
            btnRun.Click += btnRun_Click;
            runFromStartToolStripMenuItem.Click += runFromStartToolStripMenuItem_Click;
            btnRunCursor.Click += btnRunCursor_Click;
            btnPause.Click += btnPause_Click;
            btnStop.Click += btnStop_Click;
            btnClearTerminal.Click += toolStripButton1_Click;
            btnTopMost.Click += toolStripButton1_Click_1;
            pnlRenamePanel.Paint += pnlRenamePanel_Paint;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            button1.ButtonClicked += button1_ButtonClicked;
            navigator1.SelectedIndexChanged += navigator1_SelectedIndexChanged;
            navigator1.TabRightClicked += navigator1_TabRightClicked;
            navigator1.MouseClick += navigator1_MouseClick;
            newChannelToolStripMenuItem.Click += newChannelToolStripMenuItem_Click;
            removeChannelToolStripMenuItem.Click += removeChannelToolStripMenuItem_Click;
            renameChannelToolStripMenuItem.Click += renameChannelToolStripMenuItem_Click_1;
            outputInTerminalToolStripMenuItem.Click += outputInTerminalToolStripMenuItem_Click_1;
            modbusMasterToolStripMenuItem.Click += modbusMasterToolStripMenuItem_Click;
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            lstStepProgram.DropDownClicked += lstStepProgram_DropDownClicked;
            lstStepProgram.ItemMiddleClicked += lstStepProgram_ItemMiddleClicked;
            lstStepProgram.Load += lstStepProgram_Load;
            lstStepProgram.Click += lstStepProgram_MouseClick;
            lstStepProgram.KeyDown += lstStepProgram_KeyDown;
            lstStepProgram.ItemCheckedChanged += LstStepProgram_ItemCheckedChanged;
            addCommandToolStripMenuItem1.Click += addCommandToolStripMenuItem1_Click;
            addCommandAfterToolStripMenuItem.Click += addCommandAfterToolStripMenuItem_Click;
            removeSelectedToolStripMenuItem.Click += removeSelectedToolStripMenuItem_Click;
            cutToolStripMenuItem1.Click += cutToolStripMenuItem1_Click;
            copyToolStripMenuItem1.Click += copyToolStripMenuItem1_Click;
            pasteToolStripMenuItem1.Click += pasteToolStripMenuItem1_Click;
            enableSelectedToolStripMenuItem1.Click += enableSelectedToolStripMenuItem1_Click;
            disableSelectedToolStripMenuItem1.Click += disableSelectedToolStripMenuItem1_Click;
            runToolStripMenuItem.Click += runToolStripMenuItem_Click;
            pauseToolStripMenuItem.Click += pauseToolStripMenuItem_Click;
            stopToolStripMenuItem.Click += stopToolStripMenuItem_Click;
            fileToolStripMenuItem.Click += fileToolStripMenuItem_Click;
            btnNewStep.Click += btnNewStep_Click;
            btnOpenStep.Click += btnOpenStep_Click;
            btnOpenLocation.Click += btnOpenLocation_Click;
            btnSaveStep.Click += btnSaveStep_Click;
            btnSaveAsStep.Click += btnSaveAsStep_Click;
            btnRecentProjects.DropDownOpening += btnRecentProjects_DropDownOpening;
            btnMenuExit.Click += btnMenuExit_Click;
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            btnOptViewDataOnly.Click += btnOptViewDataOnly_Click;
            btnOptViewTime.Click += btnOptViewTime_Click;
            btnOptViewDate.Click += btnOptViewData_Click;
            btnOptViewDateTime.Click += btnOptViewDateTime_Click;
            btnOptViewSource.Click += btnOptViewSource_Click;
            channelsToolStripMenuItem.Click += channelsToolStripMenuItem_Click;
            btnMenuShowStepPrg.Click += btnMenuShowStepPrg_Click;
            btnMenuClearTerminal.Click += btnMenuClearTerminal_Click;
            btnZoom50.Click += btnZoom50_Click;
            btnZoom75.Click += btnZoom75_Click;
            btnZoom100.Click += btnZoom100_Click;
            btnZoom110.Click += btnZoom110_Click;
            btnZoom120.Click += btnZoom120_Click;
            btnZoom150.Click += toolStripMenuItem2_Click_1;
            btnZoom175.Click += toolStripMenuItem3_Click_1;
            btnZoom200.Click += toolStripMenuItem4_Click;
            btnZoom300.Click += btnZoom300_Click;
            btnMenuTopMost.Click += btnMenuTopMost_Click;
            btnMenuFullScreen.Click += btnMenuFullScreen_Click;
            mitChannel.DropDownOpening += mitChannel_DropDownOpening;
            btnNewChannel.Click += btnNewChannel_Click;
            btnRemoveChannel.Click += btnRemoveChannel_Click;
            ddbChannels.DropDownOpening += ddbChannels_DropDownOpening;
            btnRenameChannel.Click += renameChannelToolStripMenuItem1_Click;
            btnMenuOutputMaster.Click += outputInTerminalToolStripMenuItem_Click;
            btnMenuModbusMaster.Click += toolStripMenuItem1_Click;
            btnOptFrmLineNone.Click += btnOptFrmLineNone_Click;
            btnOptFrmLineLF.Click += btnOptFrmLineLF_Click;
            btnOptFrmLineCRLF.Click += btnOptFrmLineCRLF_Click;
            btnOptFrmLineCR.Click += btnOptFrmLineCR_Click;
            btnMenuOpenNewTerminal.Click += btnMenuOpenNewTerminal_Click;
            btnMenuConnect.Click += btnMenuConnect_Click;
            btnMenuDisconnect.Click += btnMenuDisconnect_Click;
            propertiesToolStripMenuItem1.Click += propertiesToolStripMenuItem1_Click;
            btnChanDB5.Click += toolStripMenuItem2_Click;
            btnChanDB6.Click += btnChanDB6_Click;
            btnChanDB7.Click += btnChanDB7_Click;
            btnChanDB.Click += btnChanDB_Click;
            btnChannelNoParity.Click += btnChannelNoParity_Click;
            btnChannelEvenParity.Click += btnChannelEvenParity_Click;
            btnChannelOddParity.Click += btnChannelOddParity_Click;
            btnChannelSpaceParity.Click += btnChannelSpaceParity_Click;
            btnChannelMarkParity.Click += btnChannelMarkParity_Click;
            btnChannelStopBits0.Click += btnChannelStopBits0_Click;
            btnChannelStopBits1.Click += btnChannelStopBits1_Click;
            btnChannelStopBits15.Click += btnChannelStopBits15_Click;
            btnChannelStopBits2.Click += btnChannelStopBits2_Click;
            btnChannelFlowNone.Click += noneToolStripMenuItem_Click;
            btnChannelFlowXONXOFF.Click += xONXOFFToolStripMenuItem_Click;
            btnChannelFlowRTSCTS.Click += btnChannelFlowRTSCTS_Click;
            btnChannelFlowDSRDTR.Click += btnChannelFlowDSRDTR_Click;
            resetCountersToolStripMenuItem.Click += resetCountersToolStripMenuItem_Click;
            addCommandToolStripMenuItem.Click += addCommandToolStripMenuItem_Click;
            btnPrgRemoveStepLines.Click += btnPrgRemoveStepLines_Click;
            btnPrgMoveUp.Click += btnPrgMoveUp_Click;
            btnPrgMoveDown.Click += btnPrgMoveDown_Click;
            btnEnableSelected.Click += enableSelectedToolStripMenuItem_Click;
            btnToggleSelected.Click += toggleEnableToolStripMenuItem_Click;
            btnDisableSelected.Click += disableSelectedToolStripMenuItem_Click;
            setStepCursorToolStripMenuItem.Click += setStepCursorToolStripMenuItem_Click;
            activeProgramToolStripMenuItem.DropDownOpening += activeProgramToolStripMenuItem_DropDownOpening;
            activeProgramToolStripMenuItem.Click += activeProgramToolStripMenuItem_Click;
            commandPalletToolStripMenuItem.Click += commandPalletToolStripMenuItem_Click;
            variablesToolStripMenuItem.Click += variablesToolStripMenuItem_Click;
            propertiesToolStripMenuItem.Click += propertiesToolStripMenuItem_Click;
            btnRunPrg.Click += btnRunPrg_Click;
            runProgramToolStripMenuItem.Click += runProgramToolStripMenuItem_Click;
            btnPausePrg.Click += btnPausePrg_Click;
            btnStopPrg.Click += btnStopPrg_Click;
            newProgramToolStripMenuItem.Click += newProgramToolStripMenuItem_Click;
            removeProgramToolStripMenuItem.Click += removeProgramToolStripMenuItem_Click;
            keyPadToolStripMenuItem.Click += keyPadToolStripMenuItem_Click;
            btnMonitor.Click += btnMonitor_Click;
            modbusRegistersToolStripMenuItem.Click += modbusRegistersToolStripMenuItem_Click;
            oscilloscopeToolStripMenuItem.Click += oscilloscopeToolStripMenuItem_Click;
            textComparatorToolStripMenuItem.Click += textComparatorToolStripMenuItem_Click;
            deviceManagerToolStripMenuItem.Click += deviceManagerToolStripMenuItem_Click;
            optionsToolStripMenuItem.Click += optionsToolStripMenuItem_Click;
            btnWinWindowManager.Click += btnWinWindowManager_Click;
            btnWinCloseAll.Click += btnWinCloseAll_Click;
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            tmrProg.Tick += tmrProg_Tick;
            pnlStepProgram.CloseButtonClicked += pnlStepProgram_CloseButtonClicked;
            thPrograms.AddButtonClicked += tabHeader1_AddButtonClicked;
            thPrograms.CloseButtonClicked += tabHeader1_CloseButtonClicked;
            thPrograms.TabDoubleClicked += ThPrograms_TabDoubleClicked;
            thPrograms.TabRightClicked += thPrograms_TabRightClicked;
            thPrograms.SelectedIndexChanged += tabHeader1_SelectedIndexChanged;
            thPrograms.Load += tabHeader1_Load;
            Output.CommandEntered += Output_CommandEntered;
            Output.Click += Output_Click;
            Output.Enter += Output_Enter;
            Output.MouseClick += Output_MouseClick;
            Output.Validated += Output_Validated;
            cmRunProgram.Click += cmRunProgram_Click;
            cmbtnSetAsActive.Click += cmbtnSetAsActive_Click;
            renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
            cmbtnProperties.Click += cmbtnProperties_Click;
            cmbtnNewProgram.Click += cmbtnNewProgram_Click;
            cmCloseProgram.Click += cmCloseProgram_Click;
            Activated += Form1_Activated;
            Deactivate += Form1_Deactivate;
            Load += Form1_Load;
            KeyPress += Form1_KeyPress;
        }
        public MainWindow() {
            Setup();
        }
        public MainWindow(string File) {
            Setup();
            Open(File);
        }

        private void Form1_Load(object? sender, EventArgs e) {
            AdjustUserInterface();
            ProjectManager.LoadGenericKeypadButtons();
            RecolorAll();
            AddIcons();
            ProgramEditing.LoadProgramOperations(cmStepPrg, StepOperationBtn_Click);
            RefreshPorts();
            SelectFirstPort();
            LoadPlugins();
            LoadDefaults();
            Output.FlashCursor = true;
            navigator1.LinkedList = SystemManager.SerialManagers;
            lstStepProgram.Items.Clear();
            Color FadeInColor = Color.FromArgb(100, DesignerSetup.GetAccentColor());
            msMain.BackColorNorthFadeIn = FadeInColor;
            RefreshChannels();
            ProgramManager.ProgramListingChanged += ProgramManager_ProgramListingChanged;
            SystemManager.ChannelPropertyChanged += SystemManager_ChannelPropertyChanged;
            SystemManager.ChannelRenamed += SystemManager_ChannelRenamed;
            SystemManager.ErrorInvoked += SystemManager_ErrorInvoked;
            SetTitle(LocalisationManager.GetLocalisedText("untitled", "Untitled"));
            //DetermineTabs();
            DocumentEdited = false;
        }
        private void LoadPlugins() {
            SystemManager.PluginsLoaded += SystemManager_PluginsLoaded;
            //Thread PlugInLoaderThread = new Thread(SystemManager.LoadPlugins);
            //PlugInLoaderThread.IsBackground = true;
            //PlugInLoaderThread.Start();
            SystemManager.LoadPlugins();
        }

        private void SystemManager_PluginsLoaded() {
            this.BeginInvoke(new MethodInvoker(delegate {
                SystemManager.ApplyPlugins(extensionsToolStripMenuItem, ExtensionClicked);
                SystemManager.PluginsLoaded -= SystemManager_PluginsLoaded;
            }));
        }
        private void ExtensionClicked(object? sender, EventArgs e) {
            try {
                if (sender == null) { return; }
                if (sender.GetType() != typeof(ToolStripMenuItem)) { return; }
                ToolStripMenuItem Tsi = (ToolStripMenuItem)sender;
                if (Tsi.Tag == null) { return; }
                PlugIn Temp = (PlugIn)Tsi.Tag;
                Form? Frm = Temp.LoadWindow();
                if (Frm == null) { return; }
                Frm.Show();
            }
            catch { }
        }

        private void SystemManager_ErrorInvoked(ErrorType Type, string Sender, string Message) {
            this.BeginInvoke(new MethodInvoker(delegate {
                this.Print(ErrorType.M_Error, "COM_PSTART", "Could not open the port");
            }));
        }
        private void SystemManager_ChannelRenamed(SerialManager sender) {
            if (currentManager == null) { return; }
            if (sender.ID == currentManager.ID) {
                InvokePropertyChange();

            }
            navigator1.Invalidate();
        }
        private void SystemManager_ChannelPropertyChanged(SerialManager sender) {
            if (currentManager == null) { return; }
            if (sender.ID == currentManager.ID) {
                InvokePropertyChange();
            }
            DocumentEdited = true;
        }

        private void LoadDefaults() {
            EnumManager.LoadInputFormats(ddbInputFormat, InputFormat_Click, true);
            EnumManager.LoadInputFormats(btnChannelInputFormat, InputFormat_Click, false);
            EnumManager.LoadOutputFormats(ddbOutputFormat, OutputFormat_Click, true);
            EnumManager.LoadOutputFormats(btnChannelOutputFormat, OutputFormat_Click, false);
            if (currentManager != null) {
                try {
                    currentManager.DataBits = Properties.Settings.Default.DEF_INT_DataBits;
                    ddbBits.Text = Properties.Settings.Default.DEF_INT_DataBits.ToString();
                }
                catch {
                    currentManager.DataBits = 8;
                    ddbBits.Text = "8";
                }
                currentManager.Parity = EnumManager.StringToParity(Properties.Settings.Default.DEF_STR_ParityBit);
                ddbParity.Text = EnumManager.ParityToString(currentManager.Parity);
                currentManager.StopBits = EnumManager.StringToStopBits(Properties.Settings.Default.DEF_STR_StopBits);
                ddbStopBits.Text = EnumManager.StopBitsToString(currentManager.StopBits);
                currentManager.InputFormat = EnumManager.StringToInputFormat(Properties.Settings.Default.DEF_STR_InputFormat);
                ddbInputFormat.Text = EnumManager.InputFormatToString(currentManager.InputFormat, false).A;
                currentManager.OutputFormat = EnumManager.StringToOutputFormat(Properties.Settings.Default.DEF_STR_OutputFormat);
                ddbOutputFormat.Text = EnumManager.OutputFormatToString(currentManager.OutputFormat, false).A;
                string InFrmt = EnumManager.InputFormatToString(currentManager.InputFormat, false).B;
                string OutFrmt = EnumManager.OutputFormatToString(currentManager.OutputFormat, false).B;

                SystemManager.CheckFormatOption(InFrmt, ddbInputFormat);
                SystemManager.CheckFormatOption(InFrmt, btnChannelInputFormat);

                SystemManager.CheckFormatOption(OutFrmt, ddbOutputFormat);
                SystemManager.CheckFormatOption(OutFrmt, btnChannelOutputFormat);
            }
            LoadAllBauds();
            SystemManager.CheckFormatOption(ddbParity.Text ?? "", ddbParity);
            SystemManager.CheckFormatOption(ddbParity.Text ?? "", btnChannelParity);
            CheckBits(ddbBits.Text ?? "");
            CheckStopBits(ddbStopBits.Text ?? "");
            SystemRunning(false);

            SetDefaultStyleValues();
        }
        #region Theming and Icons
        public void ApplyTheme() {

            RecolorAll();
            AddIcons();
        }
        private void RecolorAll() {
            ApplicationManager.IsDark = Properties.Settings.Default.THM_SET_IsDark;
            // this.SuspendLayout();
            BackColor = Properties.Settings.Default.THM_COL_Editor;

            Classes.Theming.ThemeManager.ThemeControl(msMain);
            Classes.Theming.ThemeManager.ThemeControl(tsMain);
            Classes.Theming.ThemeManager.ThemeControl(smMain);
            Classes.Theming.ThemeManager.ThemeControl(lstStepProgram);
            Classes.Theming.ThemeManager.ThemeControl(thPrograms);
            Classes.Theming.ThemeManager.ThemeControl(Output);
            Classes.Theming.ThemeManager.ThemeControl(navigator1);

            pnlStepProgram.ArrowColor = Properties.Settings.Default.THM_COL_ForeColor;
            pnlStepProgram.CloseColor = Properties.Settings.Default.THM_COL_ForeColor;
            pnlStepProgram.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            pnlStepProgram.LabelBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            pnlStepProgram.BackColor = Properties.Settings.Default.THM_COL_Editor;

            Classes.Theming.ThemeManager.ThemeControl(cmStepEditor);
            Classes.Theming.ThemeManager.ThemeControl(cmStepPrg);
            Classes.Theming.ThemeManager.ThemeControl(cmPrograms);
            Classes.Theming.ThemeManager.ThemeControl(cmChannels);

            lblRxBytes.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            lblTxBytes.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            pnlRenamePanel.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox1.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            textBox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            Classes.Theming.ThemeManager.ThemeControl(button1);
            pnlRenamePanel.BackColor = Properties.Settings.Default.THM_COL_BorderColor;

            toolStripStatusLabel1.ForeColor = Properties.Settings.Default.THM_COL_SecondaryForeColor;
            toolStripStatusLabel3.ForeColor = Properties.Settings.Default.THM_COL_SecondaryForeColor;
            //this.ResumeLayout();
            ProgramManager.ApplySyntaxColouring(lstStepProgram, -1, true);
        }
        private void AddIcons() {
            DesignerSetup.SetImageSizes(RenderHandler.DPI());

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Grid, keyPadToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Memory, ddbPorts, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Connect_16x, btnConnect, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Disconnect_16x, btnDisconnect, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Connect_16x, btnMenuConnect, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Disconnect_16x, btnMenuDisconnect, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Connect_16x, connectToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Disconnect_16x, disconnectToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.UndoNoColor, undoToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Redo, redoToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.SelectAll, selectAllToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.SelectAll, setStepCursorToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Input, ddbInputFormat, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Output1, ddbOutputFormat, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Input, btnChannelInputFormat, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Output1, btnChannelOutputFormat, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Property, propertiesToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Settings_16x, optionsToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.RunStart_16x, runFromStartToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.RunStart_16x, btnRun, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, btnRunCursor, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Pause_16x, btnPause, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, btnStop, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Cut, cutToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Copy, copyToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Paste, pasteToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Cut, cutToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Copy, copyToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Paste, pasteToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.de, deleteToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, runProgramToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.RunStart_16x, btnRunPrg, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.RunStart_16x, cmRunProgram, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.RunStart_16x, runToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Pause_16x, btnPausePrg, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, btnStopPrg, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Pause_16x, pauseToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, stopToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.ClearWindowContent, btnClearTerminal, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.BringForward, btnTopMost, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Counter_16x, btnMonitor, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.NewDeploymentPackage_16x, btnNewStep, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.OpenFile_16x, btnOpenStep, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Save_16x, btnSaveStep, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));


            DesignerSetup.LinkSVGtoControl(Properties.Resources.ClearWindowContent, btnMenuClearTerminal, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.FullScreen, btnMenuFullScreen, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.PropertyGridEditorPart, propertiesToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.PropertyGridEditorPart, cmbtnProperties, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Rename, renameToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.COM, commandPalletToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveUp, btnPrgMoveUp, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveDown, btnPrgMoveDown, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.AddItem, btnNewChannel, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.AddItem, newChannelToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.NewRow, newProgramToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.NewRow, cmbtnNewProgram, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Add, addCommandToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, btnPrgRemoveStepLines, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Add, addCommandToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, removeSelectedToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
        }

        private void AdjustUserInterface() {
            msMain.Padding = DesignerSetup.ScalePadding(msMain.Padding);
            tsMain.Padding = DesignerSetup.ScalePadding(tsMain.Padding);
            cmChannels.Padding = DesignerSetup.ScalePadding(cmChannels.Padding);
            cmPrograms.Padding = DesignerSetup.ScalePadding(cmPrograms.Padding);
            cmStepEditor.Padding = DesignerSetup.ScalePadding(cmStepEditor.Padding);
            cmStepPrg.Padding = DesignerSetup.ScalePadding(cmStepPrg.Padding);
            lstStepProgram.ScaleColumnWidths();
            //navigator1.Width = DesignerSetup.ScaleInteger(navigator1.Width);
        }
        private void Form1_Deactivate(object? sender, EventArgs e) {
            Color FadeInColor = Color.FromArgb(100, DesignerSetup.GetAccentColor());
            msMain.BackColorNorthFadeIn = FadeInColor;
            msMain.UseNorthFadeIn = false;
        }
        private void Form1_Activated(object? sender, EventArgs e) {
            Color FadeInColor = Color.FromArgb(100, DesignerSetup.GetAccentColor());
            msMain.BackColorNorthFadeIn = FadeInColor;
            msMain.UseNorthFadeIn = true;
        }
        #endregion
        #region Receiving Data
        private void SerMan_DataReceived(object? sender, bool PrintLine, string Data) {
            if (sender == null) { return; }
            string SourceName = "";
            bool PostOutput = true;
            if (sender.GetType() == typeof(SerialManager)) {
                SerialManager SM = (SerialManager)sender;
                SourceName = SM.PortName;
                PostOutput = SM.OutputToMasterTerminal;
            }
            if (PostOutput == true) {
                if (PrintLine == true) {
                    Output.Print(SourceName, Data);
                }
                else {
                    Output.AttendToLastLine(SourceName, Data, true);
                }
            }
        }
        private void SerManager_CommandProcessed(object? sender, string Data) {
            if (sender == null) { return; }
            string SourceName = "";
            bool PostOutput = true;
            if (sender.GetType() == typeof(SerialManager)) {
                SerialManager SM = (SerialManager)sender;
                SourceName = SM.PortName;
                PostOutput = SM.OutputToMasterTerminal;
            }
            CommandProcessed?.Invoke(sender, Data);
            if (PostOutput == true) {
                Output.Print(SourceName, Data);
            }
        }
        #endregion
        #region Channel Settings
        private void textBox1_TextChanged(object? sender, EventArgs e) {
            DocumentEdited = true;
        }
        private void ddbChannels_DropDownOpening(object? sender, EventArgs e) {
            RefreshChannels();
        }
        private void CleanChannelHandlers() {
            for (int i = ddbChannels.DropDownItems.Count - 1; i >= 0; i--) {
                object Itms = ddbChannels.DropDownItems[i];
                if (Itms.GetType() == typeof(ToolStripMenuItem)) {
                    if (((ToolStripMenuItem)Itms).Tag != null) {
                        ((ToolStripMenuItem)Itms).Click -= Itm_Click;
                        ddbChannels.DropDownItems.RemoveAt(i);
                    }
                }
            }
        }
        private void RefreshChannels() {
            CleanChannelHandlers();
            int i = 0;
            foreach (SerialManager SM in SystemManager.SerialManagers) {
                ToolStripMenuItem Itm = new ToolStripMenuItem();
                Itm.Text = SM.StateName;
                Itm.Tag = i;
                Itm.ImageScaling = ToolStripItemImageScaling.None;
                Itm.CheckOnClick = true;
                if (navigator1.SelectedItem == i) {
                    Itm.Checked = true;
                }
                Itm.Click += Itm_Channel; ;
                ddbChannels.DropDownItems.Add(Itm);
                i++;
            }
        }
        private void Itm_Channel(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem MenuItem = (ToolStripMenuItem)sender;
                if (MenuItem.Tag == null) { return; };
                if (CurrentManager != null) {
                    int Temp = (int)MenuItem.Tag;
                    navigator1.SelectedItem = Temp;
                }
                navigator1.Invalidate();
            }
        }
        #endregion
        #region Connection Settings
        private void btnMenuConnect_Click(object? sender, EventArgs e) {
            Connect(CurrentManager);
        }
        private void btnMenuDisconnect_Click(object? sender, EventArgs e) {
            Disconnect(CurrentManager);
        }
        private void btnConnect_Click(object? sender, EventArgs e) {
            Connect(CurrentManager);
        }
        private void Connect(SerialManager? SerMan) {
            if (SerMan != null) {
                SerMan.Connect();
                if (CurrentManager != null) {
                    SystemRunning(CurrentManager.Connected);
                }
            }
            else {
                SystemRunning(false);
            }
        }
        private void btnDisconnect_Click(object? sender, EventArgs e) {
            Disconnect(CurrentManager);
        }
        private void Disconnect(SerialManager? SerMan) {
            if (SerMan != null) {
                SerMan.Disconnect();
                if (CurrentManager != null) {
                    SystemRunning(CurrentManager.Connected);
                }
            }
            else {
                SystemRunning(false);
            }
        }
        private void SystemManager_PortStatusChanged(SerialManager sender) {
            this.BeginInvoke(new MethodInvoker(delegate {
                if (CurrentManager != null) {
                    SystemRunning(CurrentManager.Connected);
                }
            }));
        }
        private void Print(ErrorType Severity, string ErrorCode, string Msg) {
            if (Severity == ErrorType.M_Error) {
                Output.Print("ERROR: " + ErrorCode + " " + Msg, 1);
            }
            else if (Severity == ErrorType.M_CriticalError) {
                Output.Print("STOP: " + ErrorCode + " " + Msg, 1);
            }
            else if (Severity == ErrorType.M_Warning) {
                Output.Print("WARNING: " + ErrorCode + " " + Msg, 0);
            }
            else if (Severity == ErrorType.M_Notification) {
                Output.Print(Msg);
            }
        }
        private void SystemRunning(bool Running) {
            if (CurrentManager != null) {
                if (Running == true) {
                    btnConnect.Enabled = false;
                    btnMenuConnect.Enabled = false;
                    btnMenuDisconnect.Enabled = true;
                    btnDisconnect.Enabled = true;
                    ddbPorts.Enabled = false;
                    ddbBAUDRate.Enabled = false;
                    ddbParity.Enabled = false;
                    ddbBits.Enabled = false;
                    ddbStopBits.Enabled = false;
                    btnChannelPort.Enabled = false;
                    btnChannelBaud.Enabled = false;
                    btnChannelDataBits.Enabled = false;
                    btnChannelParity.Enabled = false;
                    btnChannelStopBits.Enabled = false;
                    btnChannelFlowCtrl.Enabled = false;
                    sendFileToolStripMenuItem.Enabled = CurrentManager.Connected;
                }
                else {
                    btnConnect.Enabled = CurrentManager.SystemEnabled;
                    btnDisconnect.Enabled = false;
                    btnMenuConnect.Enabled = CurrentManager.SystemEnabled;
                    btnMenuDisconnect.Enabled = false;
                    ddbPorts.Enabled = true;
                    ddbBAUDRate.Enabled = CurrentManager.SystemEnabled;
                    ddbParity.Enabled = CurrentManager.SystemEnabled;
                    ddbBits.Enabled = CurrentManager.SystemEnabled;
                    ddbStopBits.Enabled = CurrentManager.SystemEnabled;
                    btnChannelPort.Enabled = CurrentManager.SystemEnabled;
                    btnChannelBaud.Enabled = CurrentManager.SystemEnabled;
                    btnChannelDataBits.Enabled = CurrentManager.SystemEnabled;
                    btnChannelParity.Enabled = CurrentManager.SystemEnabled;
                    btnChannelStopBits.Enabled = CurrentManager.SystemEnabled;
                    btnChannelFlowCtrl.Enabled = CurrentManager.SystemEnabled;
                    sendFileToolStripMenuItem.Enabled = false;
                }
            }
            else {
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = false;
                btnMenuConnect.Enabled = false;
                btnMenuDisconnect.Enabled = false;
                ddbPorts.Enabled = true;
                ddbBAUDRate.Enabled = false;
                ddbParity.Enabled = false;
                ddbBits.Enabled = false;
                ddbStopBits.Enabled = false;
                btnChannelPort.Enabled = false;
                btnChannelBaud.Enabled = false;
                btnChannelDataBits.Enabled = false;
                btnChannelParity.Enabled = false;
                btnChannelStopBits.Enabled = false;
                btnChannelFlowCtrl.Enabled = false;
                sendFileToolStripMenuItem.Enabled = false;
            }

        }
        #endregion
        #region Port Settings
        private void CleanHandlers() {
            for (int i = ddbPorts.DropDownItems.Count - 1; i >= 0; i--) {
                object Itms = ddbPorts.DropDownItems[i];
                if (Itms.GetType() == typeof(ToolStripMenuItem)) {
                    if (((ToolStripMenuItem)Itms).Tag != null) {
                        ((ToolStripMenuItem)Itms).Click -= Itm_Click;
                        ddbPorts.DropDownItems.RemoveAt(i);
                    }
                }
            }
            for (int i = btnChannelPort.DropDownItems.Count - 1; i >= 0; i--) {
                object Itms = btnChannelPort.DropDownItems[i];
                if (Itms.GetType() == typeof(ToolStripMenuItem)) {
                    if (((ToolStripMenuItem)Itms).Tag != null) {
                        ((ToolStripMenuItem)Itms).Click -= Itm_Click;
                        btnChannelPort.DropDownItems.RemoveAt(i);
                    }
                }
            }
        }

        private void RefreshPorts() {
            CleanHandlers();
            List<Port> Ports = SystemManager.GetSerialPortSettingBased();
            foreach (Port port in Ports) {
                if (ItemExists(port.PortName) == false) {
                    ToolStripMenuItem Itm = new ToolStripMenuItem();
                    Itm.Text = port.DisplayName;
                    Itm.Tag = port.PortName;
                    Itm.ToolTipText = port.ToolTip;
                    Itm.ImageScaling = ToolStripItemImageScaling.None;
                    Itm.CheckOnClick = true;
                    Itm.Click += Itm_Click;
                    ddbPorts.DropDownItems.Add(Itm);
                    ToolStripMenuItem Itm2 = new ToolStripMenuItem();
                    Itm2.Text = port.DisplayName;
                    Itm2.Tag = port.PortName;
                    Itm2.ToolTipText = port.ToolTip;
                    Itm2.ImageScaling = ToolStripItemImageScaling.None;
                    Itm2.CheckOnClick = true;
                    Itm2.Click += Itm_Click;
                    btnChannelPort.DropDownItems.Add(Itm2);
                }
            }
            if (ddbPorts.DropDownItems.Count <= 0) {
                ddbPorts.Text = "No ports found";
                foreach (SerialManager SerMan in SystemManager.SerialManagers) {
                    SerMan.SystemEnabled = false;
                }
                SystemRunning(false);
            }
            else {
                foreach (SerialManager SerMan in SystemManager.SerialManagers) {
                    SerMan.SystemEnabled = true;
                }
                CheckPort(ddbPorts.Text ?? "");
            }
        }
        private bool ItemExists(string Name) {
            foreach (object Item in ddbPorts.DropDownItems) {
                if (Item.GetType() == typeof(ToolStripMenuItem)) {
                    ToolStripMenuItem Tsmi = ((ToolStripMenuItem)Item);
                    if (Tsmi.Tag != null) {
                        if (Tsmi.Tag.ToString() == Name) {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void Itm_Click(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(ToolStripMenuItem)) {
                string SelectedPort = "COM1";
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
                if (Tsmi.Tag == null) { return; }
                if (CurrentManager != null) {
                    ddbPorts.Text = Tsmi.Tag.ToString() ?? "COM1";
                    SelectedPort = Tsmi.Tag.ToString() ?? "COM1";
                    CurrentManager.PortName = SelectedPort;
                }
                CheckPort(SelectedPort);
                navigator1.Invalidate();
                DocumentEdited = true;
            }
        }
        private void ddbPorts_DropDownOpening(object? sender, EventArgs e) {
            RefreshPorts();
        }
        private void SelectFirstPort() {
            if (ddbPorts.DropDownItems.Count > 0) {
                string TempPort = "COM1";
                if (CurrentManager != null) {
                    object? Tag = ddbPorts.DropDownItems[0].Tag;
                    if (Tag != null) {
                        TempPort = Tag.ToString() ?? "COM1";
                    }
                    ddbPorts.Text = TempPort;
                    CurrentManager.PortName = TempPort;
                }
                CheckPort(TempPort);
            }
        }
        private void CheckPort(string Type) {
            foreach (ToolStripMenuItem Item in ddbPorts.DropDownItems) {
                if (Item.Tag == null) { continue; }
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
            foreach (ToolStripMenuItem Item in btnChannelPort.DropDownItems) {
                if (Item.Tag == null) { continue; }
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
        }
        #endregion
        #region BAUD Rate Settings
        private void LoadAllBauds() {
            SystemManager.LoadDefaultBauds();
            foreach (int i in SystemManager.DefaultBauds) {
                LoadBAUDRate(i);
            }
            SystemManager.CheckFormatOption(Properties.Settings.Default.DEF_INT_BaudRate, ddbBAUDRate);
            SystemManager.CheckFormatOption(Properties.Settings.Default.DEF_INT_BaudRate, btnChannelBaud);
            if (currentManager != null) {
                currentManager.BaudRate = Properties.Settings.Default.DEF_INT_BaudRate;
                ddbBAUDRate.Text = Properties.Settings.Default.DEF_INT_BaudRate.ToString();
            }
        }
        private void LoadBAUDRate(int Rate) {
            ToolStripMenuItem BaudRateBtn = new ToolStripMenuItem();
            BaudRateBtn.Text = Rate.ToString();
            BaudRateBtn.Tag = Rate;
            BaudRateBtn.ImageScaling = ToolStripItemImageScaling.None;
            BaudRateBtn.Click += BaudRateBtn_Click;
            ToolStripMenuItem BaudRateBtn2 = new ToolStripMenuItem();
            BaudRateBtn2.Text = Rate.ToString();
            BaudRateBtn2.Tag = Rate;
            BaudRateBtn2.ImageScaling = ToolStripItemImageScaling.None;
            BaudRateBtn2.Click += BaudRateBtn_Click;
            ddbBAUDRate.DropDownItems.Add(BaudRateBtn);
            btnChannelBaud.DropDownItems.Add(BaudRateBtn2);
        }
        private void BaudRateBtn_Click(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(ToolStripMenuItem)) {
                ddbBAUDRate.Text = ((ToolStripMenuItem)sender).Text;
                ddbBAUDRate.Tag = ((ToolStripMenuItem)sender).Tag;
                if (ddbBAUDRate.Tag != null) {
                    if (CurrentManager != null) {
                        CurrentManager.BaudRate = int.Parse(ddbBAUDRate.Tag.ToString() ?? "9600");
                    }
                }
            }
            SystemManager.CheckFormatOption(ddbBAUDRate.Text ?? "", ddbParity);
            SystemManager.CheckFormatOption(ddbBAUDRate.Text ?? "", btnChannelParity);
            navigator1.Invalidate();
            DocumentEdited = true;
        }
        #endregion
        #region Parity Settings
        private void SetPortParityBits(Parity PBits) {
            if (CurrentManager != null) {
                CurrentManager.Parity = PBits;
                ddbParity.Text = EnumManager.ParityToString(PBits);
            }
            SystemManager.CheckFormatOption(ddbParity.Text ?? "", ddbParity);
            SystemManager.CheckFormatOption(ddbParity.Text ?? "", btnChannelParity);
            navigator1.Invalidate();
            DocumentEdited = true;
        }
        private void btnParityNone_Click(object? sender, EventArgs e) {
            SetPortParityBits(Parity.None);
        }
        private void btnParityEven_Click(object? sender, EventArgs e) {
            SetPortParityBits(Parity.Even);
        }
        private void btnParityOdd_Click(object? sender, EventArgs e) {
            SetPortParityBits(Parity.Odd);
        }
        private void btnParitySpace_Click(object? sender, EventArgs e) {
            SetPortParityBits(Parity.Space);
        }
        private void btnParityMark_Click(object? sender, EventArgs e) {
            SetPortParityBits(Parity.Mark);
        }
        private void btnChannelNoParity_Click(object? sender, EventArgs e) {
            SetPortParityBits(Parity.None);
        }
        private void btnChannelEvenParity_Click(object? sender, EventArgs e) {
            SetPortParityBits(Parity.Even);
        }
        private void btnChannelOddParity_Click(object? sender, EventArgs e) {
            SetPortParityBits(Parity.Odd);
        }
        private void btnChannelSpaceParity_Click(object? sender, EventArgs e) {
            SetPortParityBits(Parity.Space);
        }
        private void btnChannelMarkParity_Click(object? sender, EventArgs e) {
            SetPortParityBits(Parity.Mark);
        }
        #endregion
        #region Bit Settings
        private void SetPortBits(int Bits) {
            if (CurrentManager != null) {
                CurrentManager.DataBits = Bits;
                ddbBits.Text = Bits.ToString();
            }
            CheckBits(Bits.ToString());
            navigator1.Invalidate();
            DocumentEdited = true;
        }
        private void toolStripMenuItem2_Click(object? sender, EventArgs e) {
            SetPortBits(5);
        }
        private void btnChanDB_Click(object? sender, EventArgs e) {
            SetPortBits(8);
        }
        private void btnChanDB7_Click(object? sender, EventArgs e) {
            SetPortBits(7);
        }
        private void btnChanDB6_Click(object? sender, EventArgs e) {
            SetPortBits(6);
        }
        private void btnBits5_Click(object? sender, EventArgs e) {
            SetPortBits(5);
        }
        private void btnBits6_Click(object? sender, EventArgs e) {
            SetPortBits(6);
        }
        private void btnBits7_Click(object? sender, EventArgs e) {
            SetPortBits(7);
        }
        private void btnBits8_Click(object? sender, EventArgs e) {
            SetPortBits(8);
        }
        private void CheckBits(string Type) {
            foreach (ToolStripMenuItem Item in ddbBits.DropDownItems) {
                if (Item.Tag == null) { continue; }
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
            foreach (ToolStripMenuItem Item in btnChannelDataBits.DropDownItems) {
                if (Item.Tag == null) { continue; }
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
        }
        #endregion
        #region Stop Bit Settings
        private void SetPortStopBits(StopBits StopBts) {
            if (CurrentManager != null) {
                CurrentManager.StopBits = StopBts;
                ddbStopBits.Text = EnumManager.StopBitsToString(StopBts);
            }
            CheckStopBits(ddbStopBits.Text ?? "");
            navigator1.Invalidate();
            DocumentEdited = true;
        }
        private void btnStopBitsNone_Click(object? sender, EventArgs e) {
            SetPortStopBits(StopBits.None);
        }
        private void btnStopBits1_Click(object? sender, EventArgs e) {
            SetPortStopBits(StopBits.One);
        }
        private void btnStopBits15_Click(object? sender, EventArgs e) {
            SetPortStopBits(StopBits.OnePointFive);
        }
        private void btnStopBits2_Click(object? sender, EventArgs e) {
            SetPortStopBits(StopBits.Two);
        }
        private void btnChannelStopBits0_Click(object? sender, EventArgs e) {
            SetPortStopBits(StopBits.None);
        }
        private void btnChannelStopBits1_Click(object? sender, EventArgs e) {
            SetPortStopBits(StopBits.One);
        }
        private void btnChannelStopBits15_Click(object? sender, EventArgs e) {
            SetPortStopBits(StopBits.OnePointFive);
        }
        private void btnChannelStopBits2_Click(object? sender, EventArgs e) {
            SetPortStopBits(StopBits.Two);
        }
        private void CheckStopBits(string Type) {
            foreach (ToolStripMenuItem Item in ddbStopBits.DropDownItems) {
                if (Item.Tag == null) { continue; }
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
            foreach (ToolStripMenuItem Item in btnChannelStopBits.DropDownItems) {
                if (Item.Tag == null) { continue; }
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
        }

        #endregion
        #region Control Flow Settings
        private void SetControlFlow(Handshake HandShake) {
            if (CurrentManager != null) {
                CurrentManager.Handshake = HandShake;
            }
            SystemManager.CheckFormatOption(EnumManager.HandshakeToString(HandShake), btnChannelFlowCtrl);
            DocumentEdited = true;
        }
        private void noneToolStripMenuItem_Click(object? sender, EventArgs e) {
            SetControlFlow(Handshake.None);
        }
        private void xONXOFFToolStripMenuItem_Click(object? sender, EventArgs e) {
            SetControlFlow(Handshake.XOnXOff);
        }
        private void btnChannelFlowRTSCTS_Click(object? sender, EventArgs e) {
            SetControlFlow(Handshake.RequestToSend);
        }
        private void btnChannelFlowDSRDTR_Click(object? sender, EventArgs e) {
            SetControlFlow(Handshake.RequestToSendXOnXOff);
        }
        #endregion

        private void Output_CommandEntered(object? sender, CommandEnteredEventArgs e) {
            try {
                if (CurrentManager != null) {
                    CurrentManager.Post(e.Command);
                }
            }
            catch {

            }
        }
        #region Format Settings
        private void InputFormatChange(string ControlText) {
            StreamInputFormat FormatPair = EnumManager.StringToInputFormat(ControlText);
            StringPair TextualPair = EnumManager.InputFormatToString(FormatPair, false);
            if (CurrentManager != null) {
                CurrentManager.InputFormat = FormatPair;
                ddbInputFormat.Text = TextualPair.A;
            }
            SystemManager.CheckFormatOption(ControlText, ddbInputFormat);
            SystemManager.CheckFormatOption(ControlText, btnChannelInputFormat);
        }
        private void OutputFormatChange(string ControlText) {
            StreamOutputFormat FormatPair = EnumManager.StringToOutputFormat(ControlText);
            StringPair TextualPair = EnumManager.OutputFormatToString(FormatPair, false);
            if (CurrentManager != null) {
                CurrentManager.OutputFormat = FormatPair;
                ddbOutputFormat.Text = TextualPair.A;
            }
            //CheckOutputFormat(ControlText);
            SystemManager.CheckFormatOption(ControlText, ddbOutputFormat);
            SystemManager.CheckFormatOption(ControlText, btnChannelOutputFormat);
        }
        private void InputFormat_Click(object? sender, EventArgs e) {
            if (sender == null) { return; }
            ToolStripItem toolStripItem = (ToolStripItem)sender;
            if (toolStripItem.Tag == null) { return; }
            InputFormatChange(toolStripItem.Tag.ToString() ?? "");
        }
        private void OutputFormat_Click(object? sender, EventArgs e) {
            if (sender == null) { return; }
            ToolStripItem toolStripItem = (ToolStripItem)sender;
            if (toolStripItem.Tag == null) { return; }
            OutputFormatChange(toolStripItem.Tag.ToString() ?? "");
        }
        private void btnOptFrmLineNone_Click(object? sender, EventArgs e) {
            SetLineFormat(LineFormatting.None);
        }
        private void btnOptFrmLineLF_Click(object? sender, EventArgs e) {
            SetLineFormat(LineFormatting.LF);
        }
        private void btnOptFrmLineCRLF_Click(object? sender, EventArgs e) {
            SetLineFormat(LineFormatting.CRLF);
        }
        private void btnOptFrmLineCR_Click(object? sender, EventArgs e) {
            SetLineFormat(LineFormatting.CR);
        }
        private void SetLineFormat(LineFormatting Format) {
            if (currentManager != null) {
                currentManager.LineFormat = Format;
                CheckLineFormat(EnumManager.LineFormattingToString(currentManager.LineFormat));
            }
        }
        private void CheckLineFormat() {
            if (currentManager != null) {
                CheckLineFormat(EnumManager.LineFormattingToString(currentManager.LineFormat));
            }
        }
        private void CheckLineFormat(string FormatString) {
            foreach (ToolStripMenuItem Tmi in btnMenuTextFormat.DropDownItems) {
                if (Tmi.Tag != null) {
                    if (Tmi.Tag.ToString() == FormatString) {
                        Tmi.Checked = true;
                    }
                    else { Tmi.Checked = false; }
                }
                else { Tmi.Checked = false; }
            }
        }
        #endregion
        #region View Settings
        private void toolStripButton1_Click(object? sender, EventArgs e) {
            Output.Clear();
        }
        private void btnMenuClearTerminal_Click(object? sender, EventArgs e) {
            Output.Clear();
        }
        private void TopMostSetting() {
            btnTopMost.Checked = !btnTopMost.Checked;
            btnMenuTopMost.Checked = !btnMenuTopMost.Checked;
            this.TopMost = !this.TopMost;
        }
        private void toolStripButton1_Click_1(object? sender, EventArgs e) {
            TopMostSetting();
        }
        private void btnMenuTopMost_Click(object? sender, EventArgs e) {
            TopMostSetting();
        }

        private void btnZoom50_Click(object? sender, EventArgs e) {
            Output.Zoom = 50;
        }
        private void btnZoom75_Click(object? sender, EventArgs e) {
            Output.Zoom = 75;
        }
        private void btnZoom100_Click(object? sender, EventArgs e) {
            Output.Zoom = 100;
        }
        private void btnZoom110_Click(object? sender, EventArgs e) {
            Output.Zoom = 110;
        }
        private void btnZoom120_Click(object? sender, EventArgs e) {
            Output.Zoom = 120;
        }
        private void toolStripMenuItem2_Click_1(object? sender, EventArgs e) {
            Output.Zoom = 150;
        }
        private void toolStripMenuItem3_Click_1(object? sender, EventArgs e) {
            Output.Zoom = 175;
        }
        private void toolStripMenuItem4_Click(object? sender, EventArgs e) {
            Output.Zoom = 200;
        }
        private void btnZoom300_Click(object? sender, EventArgs e) {
            Output.Zoom = 300;
        }
        private void btnOptViewDataOnly_Click(object? sender, EventArgs e) {
            SetStampView(ConsoleInterface.TimeStampFormat.NoTimeStamps);
        }
        private void btnOptViewTime_Click(object? sender, EventArgs e) {
            SetStampView(ConsoleInterface.TimeStampFormat.Time);
        }
        private void btnOptViewData_Click(object? sender, EventArgs e) {
            SetStampView(ConsoleInterface.TimeStampFormat.Date);
        }
        private void btnOptViewDateTime_Click(object? sender, EventArgs e) {
            SetStampView(ConsoleInterface.TimeStampFormat.DateTime);
        }
        private void SetStampView(ConsoleInterface.TimeStampFormat Frmt) {
            Output.TimeStamps = Frmt;
            if (Frmt == ConsoleInterface.TimeStampFormat.NoTimeStamps) {
                btnOptViewDataOnly.Checked = true;
                btnOptViewDate.Checked = false;
                btnOptViewTime.Checked = false;
                btnOptViewDateTime.Checked = false;
            }
            else if (Frmt == ConsoleInterface.TimeStampFormat.Time) {
                btnOptViewDataOnly.Checked = false;
                btnOptViewTime.Checked = true;
                btnOptViewDate.Checked = false;
                btnOptViewDateTime.Checked = false;
            }
            else if (Frmt == ConsoleInterface.TimeStampFormat.Date) {
                btnOptViewDataOnly.Checked = false;
                btnOptViewTime.Checked = false;
                btnOptViewDate.Checked = true;
                btnOptViewDateTime.Checked = false;
            }
            else if (Frmt == ConsoleInterface.TimeStampFormat.DateTime) {
                btnOptViewDataOnly.Checked = false;
                btnOptViewTime.Checked = false;
                btnOptViewDate.Checked = false;
                btnOptViewDateTime.Checked = true;
            }
        }

        private void btnMenuFullScreen_Click(object? sender, EventArgs e) {
            if (PreviousStyle != null) {
                SetFullScreen(!PreviousStyle.IsFullScreen);
            }
        }
        FullScreenStyle PreviousStyle = new FullScreenStyle();
        private void SetDefaultStyleValues() {
            PreviousStyle.WindowState = this.WindowState;
            PreviousStyle.BorderStyle = this.FormBorderStyle;
            PreviousStyle.WindowPosition = this.Location;
            PreviousStyle.WindowSize = this.Size;
        }
        public void SetFullScreen(bool FullScreen) {
            if (PreviousStyle.IsFullScreen != FullScreen) {
                PreviousStyle.IsFullScreen = FullScreen;
                if (FullScreen == true) {
                    SetDefaultStyleValues();
                    this.SuspendLayout();
                    this.WindowState = FormWindowState.Normal;
                    this.TopMost = true;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    this.ResumeLayout();
                    this.TopMost = false;
                }
                else {
                    this.SuspendLayout();
                    this.TopMost = false;
                    this.WindowState = PreviousStyle.WindowState;
                    this.FormBorderStyle = PreviousStyle.BorderStyle;
                    this.ResumeLayout();
                }
            }
        }
        #endregion
        #region Channel Settings
        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog OpenDia = new OpenFileDialog();
            OpenDia.Filter = @"Intel HEX Files (*.hex)|*.hex|Comma Separated Value Files (*.csv)|*.csv|Tab Separated Value Files (*.tsv)|*.csv|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (OpenDia.ShowDialog() == DialogResult.OK) {
                if (File.Exists(OpenDia.FileName)) {
                    SystemManager.SendTextFile(currentManager, OpenDia.FileName);
                }
            }
        }
        private void resetCountersToolStripMenuItem_Click(object? sender, EventArgs e) {
            if (currentManager == null) { return; }
            currentManager.ResetCounters();
        }
        private void btnMenuOpenNewTerminal_Click(object? sender, EventArgs e) {
            ApplicationManager.OpenSerialTerminal(currentManager, true);
        }
        private void renameChannelToolStripMenuItem_Click_1(object? sender, EventArgs e) {
            TabClickedEventArgs? TagData = GetClickedArgs(cmChannels.Tag);
            if (TagData == null) { return; }
            if (TagData.SelectedTab.GetType() != typeof(SerialManager)) { return; }
            ShowChannelRenameBox(TagData);
        }
        private void textBox1_KeyDown(object? sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (CurrentManager != null) {
                    CurrentManager.Name = textBox1.Text;
                }
                pnlRenamePanel.Hide();
                navigator1.Invalidate();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void ShowChannelRenameBox(TabClickedEventArgs EventData) {
            Rectangle TabRectangle = EventData.TextArea;
            SerialManager SerMan = ((SerialManager)EventData.SelectedTab);
            string CurrentText = SerMan.Name;
            System.Windows.Forms.TextBox RenameBox = new System.Windows.Forms.TextBox();
            RenameBox.Text = CurrentText;
            RenameBox.Font = thPrograms.Font;
            // RenameBox.BorderStyle = BorderStyle.None;
            RenameBox.Multiline = false;
            int CentreHeight = 0;
            RenameBox.Show();
            if (TabRectangle.Height > RenameBox.ClientSize.Height) {
                CentreHeight = ((TabRectangle.Height - RenameBox.ClientSize.Height) / 2) + TabRectangle.Y;
            }
            else {
                CentreHeight = ((RenameBox.ClientSize.Height - TabRectangle.Height) / 2) + TabRectangle.Y;
            }
            RenameBox.Location = new Point(TabRectangle.X, CentreHeight);
            RenameBox.Size = TabRectangle.Size;
            RenameBox.BringToFront();
            RenameBox.Tag = EventData;
            InRenameMode = true;
            navigator1.Controls.Add(RenameBox);
            RenameBox.Focus();
            RenameBox.Leave += RenameBox_Leave;
            RenameBox.LostFocus += RenameBox_LostFocus;
            RenameBox.KeyDown += RenameBox_KeyDown; ; ;
            RenameBox.TextChanged += RenameBox_TextChanged;
        }
        private void mitChannel_DropDownOpening(object? sender, EventArgs e) {
            //SerialManager? SerMan = SystemManager.GetChannel(navigator1.SelectedItem);
            if (currentManager != null) {
                btnMenuModbusMaster.Checked = currentManager.IsMaster;
                btnMenuOutputMaster.Checked = currentManager.OutputToMasterTerminal;
            }
            CheckLineFormat();
        }
        private void modbusMasterToolStripMenuItem_Click(object? sender, EventArgs e) {
            TabClickedEventArgs? TagData = GetClickedArgs(cmChannels.Tag);
            if (TagData != null) {
                if (TagData.SelectedTab.GetType() == typeof(SerialManager)) {
                    ((SerialManager)TagData.SelectedTab).IsMaster = !((SerialManager)TagData.SelectedTab).IsMaster;
                }
            }
        }
        private void navigator1_TabRightClicked(object? sender, TabClickedEventArgs Tab) {
            if (sender == null) { return; }
            cmChannels.Tag = Tab;
            if (Tab.SelectedTab.GetType() == typeof(SerialManager)) {
                SerialManager SerMan = (SerialManager)Tab.SelectedTab;
                modbusMasterToolStripMenuItem.Checked = SerMan.IsMaster;
                outputInTerminalToolStripMenuItem.Checked = SerMan.OutputToMasterTerminal;
                if (SerMan.Connected == true) {
                    connectToolStripMenuItem.Enabled = false;
                    disconnectToolStripMenuItem.Enabled = true;
                }
                else {
                    connectToolStripMenuItem.Enabled = true;
                    disconnectToolStripMenuItem.Enabled = false;
                }
            }
            cmChannels.Show(Tab.ScreenLocation);
        }
        private void outputInTerminalToolStripMenuItem_Click_1(object? sender, EventArgs e) {
            TabClickedEventArgs? TagData = GetClickedArgs(cmChannels.Tag);
            if (TagData != null) {
                if (TagData.SelectedTab.GetType() == typeof(SerialManager)) {
                    ((SerialManager)TagData.SelectedTab).OutputToMasterTerminal = outputInTerminalToolStripMenuItem.Checked;
                }
            }
        }
        private void button1_ButtonClicked(object? sender) {
            if (CurrentManager != null) {
                CurrentManager.Name = textBox1.Text;
            }
            pnlRenamePanel.Hide();
            navigator1.Invalidate();
        }
        private void renameChannelToolStripMenuItem1_Click(object? sender, EventArgs e) {
            pnlRenamePanel.Visible = !pnlRenamePanel.Visible;
        }
        private void btnNewChannel_Click(object? sender, EventArgs e) {
            SystemManager.AddChannel("", SerManager_CommandProcessed, SerMan_DataReceived);
        }
        private void btnRemoveChannel_Click(object? sender, EventArgs e) {
            RemoveChannel(navigator1.SelectedItem);
        }
        private void newChannelToolStripMenuItem_Click(object? sender, EventArgs e) {
            SystemManager.AddChannel("", SerManager_CommandProcessed, SerMan_DataReceived);
        }
        private void connectToolStripMenuItem_Click(object? sender, EventArgs e) {
            TabClickedEventArgs? TagData = GetClickedArgs(cmChannels.Tag);
            if (TagData != null) {
                if (TagData.SelectedTab.GetType() == typeof(SerialManager)) {
                    Connect((SerialManager)TagData.SelectedTab);
                }
            }
        }
        private void disconnectToolStripMenuItem_Click(object? sender, EventArgs e) {
            TabClickedEventArgs? TagData = GetClickedArgs(cmChannels.Tag);
            if (TagData != null) {
                if (TagData.SelectedTab.GetType() == typeof(SerialManager)) {
                    Disconnect((SerialManager)TagData.SelectedTab);
                }
            }
        }
        private void removeChannelToolStripMenuItem_Click(object? sender, EventArgs e) {
            TabClickedEventArgs? TagData = GetClickedArgs(cmChannels.Tag);
            if (TagData != null) {
                RemoveChannel(TagData.Index);
            }
        }
        private TabClickedEventArgs? GetClickedArgs(object? TagData) {
            if (TagData != null) {
                if (TagData.GetType() == typeof(TabClickedEventArgs)) {
                    TabClickedEventArgs Tb = (TabClickedEventArgs)TagData;
                    return Tb;
                }
            }
            return null;
        }
        private void RemoveChannel(int Index) {
            SystemManager.RemoveChannel(Index, SerManager_CommandProcessed, SerMan_DataReceived);
            navigator1.Invalidate();
            DocumentEdited = true;
        }
        private void SelectChannel(int SelectedIndex) {
            if (SystemManager.SerialManagers.Count > 0) {
                if ((SelectedIndex >= 0) && (SelectedIndex < SystemManager.SerialManagers.Count)) {
                    CurrentManager = SystemManager.SerialManagers[SelectedIndex];
                }
            }
        }
        private void navigator1_SelectedIndexChanged(object? sender, int SelectedIndex) {
            SelectChannel(SelectedIndex);
        }
        private void SystemManager_ChannelAdded(int RemovedIndex) {
            DocumentEdited = true;
            navigator1.Invalidate();
            ChannelEditingContexts();
        }
        private void SystemManager_ChannelRemoved(int RemovedIndex) {
            if (navigator1.SelectedItem >= navigator1.ItemCount) {
                navigator1.SelectedItem -= 1;
            }
            ChannelEditingContexts();
        }
        private void ChannelEditingContexts() {
            if (SystemManager.SerialManagers.Count > 1) {
                btnRemoveChannel.Enabled = true;
                removeChannelToolStripMenuItem.Enabled = true;
            }
            else {
                btnRemoveChannel.Enabled = false;
                removeChannelToolStripMenuItem.Enabled = false;
            }
        }
        #endregion
        #region Clipboard
        object? LastEntered = null;
        private void copyToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramEditing.CopyStepProgram(lstStepProgram);
        }
        private void pasteToolStripMenuItem_Click(object? sender, EventArgs e) {
            if (Clipboard.ContainsData(ProgramEditing.Clipboard_ProgramDataType)) {
                ProgramEditing.PasteStepProgram(lstStepProgram);
            }
            else {
                Output.Paste();
            }
        }
        private void cutToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramEditing.CopyStepProgram(lstStepProgram, true);
        }
        private void cutToolStripMenuItem1_Click(object? sender, EventArgs e) {
            ProgramEditing.CopyStepProgram(lstStepProgram, true);
        }
        private void copyToolStripMenuItem1_Click(object? sender, EventArgs e) {
            ProgramEditing.CopyStepProgram(lstStepProgram, false);
        }
        private void pasteToolStripMenuItem1_Click(object? sender, EventArgs e) {
            ProgramEditing.PasteStepProgram(lstStepProgram, true);
        }
        #endregion
        #region Program UI
        private void LoadRecentItems() {
            for (int i = btnRecentProjects.DropDownItems.Count - 1; i >= 0; i--) {
                if (btnRecentProjects.DropDownItems[i].Tag != null) {
                    btnRecentProjects.DropDownItems[i].Click -= BtnRecentItem_Click;
                    btnRecentProjects.DropDownItems.RemoveAt(i);
                }
            }
            if (Properties.Settings.Default.DOC_PRJ_RecentFiles != null) {
                int j = 1;
                for (int i = Properties.Settings.Default.DOC_PRJ_RecentFiles.Count - 1; i >= 0; i--) {
                    string? FileName = Properties.Settings.Default.DOC_PRJ_RecentFiles[i];
                    if ((FileName != null) && (j <= 10)) {
                        if (FileName != "") {
                            ToolStripMenuItem btnRecentItem = new ToolStripMenuItem();
                            btnRecentItem.Text = j.ToString() + "  " + Path.GetFileNameWithoutExtension(FileName);
                            btnRecentItem.Tag = FileName;
                            btnRecentItem.Click += BtnRecentItem_Click;
                            btnRecentProjects.DropDownItems.Add(btnRecentItem);
                            j++;
                        }
                    }
                }
                if (j > 1) {
                    btnRecentProjects.Enabled = true;
                }
                else {
                    btnRecentProjects.Enabled = false;
                }
            }
            else {
                btnRecentProjects.Enabled = false;
            }
        }
        private void btnRecentProjects_DropDownOpening(object? sender, EventArgs e) {
            LoadRecentItems();
        }
        private void AddFiletoRecentFiles(string FileName) {
            if (Properties.Settings.Default.DOC_PRJ_RecentFiles == null) {
                Properties.Settings.Default.DOC_PRJ_RecentFiles = new System.Collections.Specialized.StringCollection();
            }
            int ContainsRecentFile = -1;
            for (int i = 0; i < Properties.Settings.Default.DOC_PRJ_RecentFiles.Count; i++) {
                if (Properties.Settings.Default.DOC_PRJ_RecentFiles[i] != null) {
                    if (FileName == Properties.Settings.Default.DOC_PRJ_RecentFiles[i]) {
                        ContainsRecentFile = i;
                        break;
                    }
                }
            }
            if (ContainsRecentFile >= 0) {
                Properties.Settings.Default.DOC_PRJ_RecentFiles.RemoveAt(ContainsRecentFile);
            }
            Properties.Settings.Default.DOC_PRJ_RecentFiles.Add(FileName);
            Properties.Settings.Default.Save();
        }
        private void BtnRecentItem_Click(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                if (item.Tag == null) { return; }
                string FileName = item.Tag.ToString() ?? "";
                if (FileName == "") { return; }
                SystemManager.CloseAll();
                Open(FileName);
                AddFiletoRecentFiles(FileName);
            }
        }
        private void channelsToolStripMenuItem_Click(object? sender, EventArgs e) {
            navigator1.Visible = channelsToolStripMenuItem.Checked;
        }
        private void btnMenuShowStepPrg_Click(object? sender, EventArgs e) {
            pnlStepProgram.Visible = btnMenuShowStepPrg.Checked;
        }
        private void pnlStepProgram_CloseButtonClicked(object? sender, Point HitPoint) {
            btnMenuShowStepPrg.Checked = false;
            pnlStepProgram.Visible = false;
        }
        #endregion
        #region Program Settings
        private void ProgramManager_ProgramSettingChanged() {
            ProgramManager.ApplySyntaxColouring(lstStepProgram, -1, true);
            ProgramManager.ApplyIndentation(lstStepProgram);
        }
        private void variablesToolStripMenuItem_Click(object? sender, EventArgs e) {
            if (lstStepProgram.Tag == null) { return; }
            if (lstStepProgram.Tag.GetType() == typeof(ProgramObject)) {
                if (ApplicationManager.IsInternalApplicationOpen("Variables")) {
                    Form? Temp = ApplicationManager.GetFormByName("Variables");
                    if (Temp != null) {
                        if (Temp.GetType() == typeof(ToolWindows.Variables)) {
                            ((ToolWindows.Variables)Temp).SelectedProgram = (ProgramObject)lstStepProgram.Tag;
                        }
                    }
                }
                else {
                    ToolWindows.Variables PrgVars = new ToolWindows.Variables();
                    ApplicationManager.OpenInternalApplicationOnce(PrgVars);
                    PrgVars.SelectedProgram = (ProgramObject)lstStepProgram.Tag;
                }
            }
        }
        private void propertiesToolStripMenuItem_Click(object? sender, EventArgs e) {
            if (lstStepProgram.Tag == null) { return; }
            if (lstStepProgram.Tag.GetType() == typeof(ProgramObject)) {
                ProgramProperties PrgProp = new ProgramProperties();
                PrgProp.SelectedProgram = (ProgramObject)lstStepProgram.Tag;
                ApplicationManager.OpenInternalApplicationAsDialog(PrgProp, this);
            }
        }
        private void StepOperationBtn_Click(object? sender, EventArgs e) {
            ProgramEditing.ChangeStepCommand(lstStepProgram, cmStepPrg, sender);
        }
        bool inEditingMode = false;
        bool InEditingMode {
            get { return inEditingMode; }
            set { inEditingMode = value; }
        }
        private void lstStepProgram_DropDownClicked(object? sender, DropDownClickedEventArgs e) {
            ProgramEditing.DropDownClicked(lstStepProgram, cmStepPrg, e, ref inEditingMode);
        }
        private const int WM_LBUTTONDOWN = 0x0201;
        public event EventHandler<MouseDownEventArgs>? MouseEvent;
        public bool PreFilterMessage(ref Message m) {
            if (m.Msg == WM_LBUTTONDOWN) {
                var pos = MousePosition;
                MouseEvent?.Invoke(this, new MouseDownEventArgs(m.HWnd, pos));
            }
            return false;
        }
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            if (!DesignMode) Application.AddMessageFilter(this);
        }
        protected override void OnHandleDestroyed(EventArgs e) {
            base.OnHandleDestroyed(e);
            if (!DesignMode) Application.RemoveMessageFilter(this);
        }
        #endregion
        #region Program Editing

        private void LstStepProgram_ItemCheckedChanged(object sender, ItemCheckedChangeEventArgs e) {
            LastEntered = lstStepProgram;
            ProgramManager.ApplyIndentation(lstStepProgram);
            ProgramManager.ApplySyntaxColouring(lstStepProgram, e.Item);

        }
        private void addCommandToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramEditing.NewLine(lstStepProgram);
        }
        private void addCommandAfterToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramEditing.NewLine(lstStepProgram, true);
        }
        private void deleteToolStripMenuItem_Click(object? sender, EventArgs e) {
            if (LastEntered != null) {
                if (LastEntered.GetType() == typeof(ODModules.ListControl)) {
                    ProgramEditing.RemoveSelected(lstStepProgram);
                }
                else {
                    Output.ClearEntered();
                }
            }
            else {
                Output.ClearEntered();
            }
        }
        private void addCommandToolStripMenuItem1_Click(object? sender, EventArgs e) {
            ProgramEditing.NewLine(lstStepProgram);
        }
        private void removeSelectedToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramEditing.RemoveSelected(lstStepProgram);
        }
        private void btnPrgRemoveStepLines_Click(object? sender, EventArgs e) {
            ProgramEditing.RemoveSelected(lstStepProgram);
        }
        private void MarkDocumentChanged() {
            //if (lstStepProgram.SelectionCount > 0) {
            DocumentEdited = true;
            //}
        }
        private void btnPrgMoveUp_Click(object? sender, EventArgs e) {
            ProgramEditing.MoveSelected(lstStepProgram, false);
        }
        private void btnPrgMoveDown_Click(object? sender, EventArgs e) {
            ProgramEditing.MoveSelected(lstStepProgram, true);
        }
        private void enableSelectedToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramEditing.ChangeEnable(lstStepProgram, ProgramManager.EnableChanged.EnableSelected);
        }
        private void toggleEnableToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramEditing.ChangeEnable(lstStepProgram, ProgramManager.EnableChanged.ToggleSelected);
        }
        private void disableSelectedToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramEditing.ChangeEnable(lstStepProgram, ProgramManager.EnableChanged.DisableSelected);
        }
        private void enableSelectedToolStripMenuItem1_Click(object? sender, EventArgs e) {
            ProgramEditing.ChangeEnable(lstStepProgram, ProgramManager.EnableChanged.EnableSelected);
        }
        private void disableSelectedToolStripMenuItem1_Click(object? sender, EventArgs e) {
            ProgramEditing.ChangeEnable(lstStepProgram, ProgramManager.EnableChanged.DisableSelected);
        }
        #endregion 
        #region Program Control
        //StepEnumerations.StepState LastProgramState = StepEnumerations.StepState.Stopped;
        DateTime LastUpdate = DateTime.UtcNow;
        DateTime LastStateCheckUpdate = DateTime.UtcNow;
        private void tmrProg_Tick(object? sender, EventArgs e) {

            //if (LastProgramState != ProgramManager.ProgramState) {
            if (ConversionHandler.DateIntervalDifference(LastUpdate, DateTime.UtcNow, ConversionHandler.Interval.Millisecond) > 10) {
                if (ProgramManager.ProgramState == StepEnumerations.StepState.Running) {
                    btnRun.Enabled = false;
                    btnPause.Enabled = true;
                    btnStop.Enabled = true;
                    btnRunPrg.Enabled = false;
                    btnPausePrg.Enabled = true;
                    btnStopPrg.Enabled = true;
                    runToolStripMenuItem.Enabled = false;
                    pauseToolStripMenuItem.Enabled = true;
                    stopToolStripMenuItem.Enabled = true;
                    runProgramToolStripMenuItem.Enabled = false;
                    btnRunCursor.Enabled = false;
                }
                else {
                    btnRun.Enabled = true;
                    btnPause.Enabled = false;
                    btnStop.Enabled = false;
                    btnRunPrg.Enabled = true;
                    btnPausePrg.Enabled = false;
                    btnStopPrg.Enabled = false;
                    runToolStripMenuItem.Enabled = true;
                    pauseToolStripMenuItem.Enabled = false;
                    stopToolStripMenuItem.Enabled = false;
                    runProgramToolStripMenuItem.Enabled = true;
                    btnRunCursor.Enabled = true;
                }
                LastUpdate = DateTime.UtcNow;
                // LastProgramState = ProgramManager.ProgramState;
            }
            if (ProgramManager.LastProgramStep != ProgramManager.ProgramStep) {
                if (Properties.Settings.Default.PRG_BOL_AnimateCursor) {
                    if (ProgramManager.CurrentProgram == lstStepProgram.Tag) {
                        lstStepProgram.LineMarkerIndex = ProgramManager.ProgramStep;
                    }
                    if (ProgramManager.CurrentProgram != null) {
                        ProgramManager.CurrentProgram.ProgramMarker = ProgramManager.ProgramStep;
                    }
                }
                ProgramManager.LastProgramStep = ProgramManager.ProgramStep;
            }
            if (currentManager != null) {
                string RxCount = currentManager.BytesReceived.ToString();
                string TxCount = currentManager.BytesSent.ToString();
                if (lblRxBytes.Text != RxCount) { lblRxBytes.Text = RxCount; }
                if (lblTxBytes.Text != TxCount) { lblTxBytes.Text = TxCount; }
            }
            if (ConversionHandler.DateIntervalDifference(LastStateCheckUpdate, DateTime.UtcNow, ConversionHandler.Interval.Second) > 1) {
                navigator1.Invalidate();
                LastStateCheckUpdate = DateTime.UtcNow;
            }
        }
        private void ProgramManager_ProgramNameChanged(object? sender) {
            ProgramManager.DetermineName(thPrograms, btnRun);
        }
        private void TsMi_Click(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem TsMi = (ToolStripMenuItem)sender;
                if (TsMi.Tag == null) { return; }
                if (TsMi.Tag.GetType() == typeof(ProgramObject)) {
                    ProgramObject ProgramObject = (ProgramObject)TsMi.Tag;
                    ProgramManager.CurrentProgram = ProgramObject;
                    btnRun.Text = TsMi.Text;
                }
            }
        }
        private void btnRun_Click(object? sender, EventArgs e) {

        }
        private void btnRun_ButtonClick(object? sender, EventArgs e) {
            ProgramManager.RunProgramFromStart();
        }
        private void runFromStartToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramManager.RunProgramFromStart();
        }
        private void btnPause_Click(object? sender, EventArgs e) {
            ProgramManager.PauseProgram();
        }
        private void btnStop_Click(object? sender, EventArgs e) {
            ProgramManager.StopProgram();
        }
        private void btnRunPrg_Click(object? sender, EventArgs e) {
            ProgramManager.RunProgramFromStart();
        }
        private void btnPausePrg_Click(object? sender, EventArgs e) {
            ProgramManager.PauseProgram();
        }
        private void btnStopPrg_Click(object? sender, EventArgs e) {
            ProgramManager.StopProgram();
        }
        private void runToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramManager.RunProgramFromStart();
        }
        private void runProgramToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramManager.Run(lstStepProgram);
        }
        private void pauseToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramManager.PauseProgram();
        }
        private void stopToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramManager.StopProgram();
        }
        private void btnRunCursor_Click(object? sender, EventArgs e) {
            ProgramManager.Run(lstStepProgram);
        }
        private void setStepCursorToolStripMenuItem_Click(object? sender, EventArgs e) {
            ProgramManager.SetCursorAtSelected(lstStepProgram);
        }
        private void lstStepProgram_KeyDown(object? sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                ProgramManager.SetCursorAtSelected(lstStepProgram);
            }
            e.Handled = true;
        }
        private void lstStepProgram_ItemMiddleClicked(object? sender, ListItem Item, int Index, Rectangle ItemBounds) {
            LastEntered = lstStepProgram;
            ProgramManager.SetCursorAtIndex(lstStepProgram, Index);
        }

        #endregion
        #region Program
        public void MethodCopying(string Input) {
            if (Input.Length <= 0) { return; }
            this.BeginInvoke(new MethodInvoker(delegate {
                Clipboard.SetText(Input);
            }));
        }
        public void MethodSetRunText(string Input) {
            this.BeginInvoke(new MethodInvoker(delegate {
                this.btnRun.Text = Input;
            }));
        }
        public void MethodPrinting(string Input) {
            this.BeginInvoke(new MethodInvoker(delegate {
                this.Output.Print(Input);
            }));
        }
        public void MethodPrinting(string Input, Color DisplayColor) {
            this.BeginInvoke(new MethodInvoker(delegate {
                this.Output.Print(Input, DisplayColor);
            }));
        }
        public void MethodPrinting(string Input, int DisplayColorIndex) {
            this.BeginInvoke(new MethodInvoker(delegate {
                this.Output.Print(Input, DisplayColorIndex);
            }));
        }
        public void MethodClearing() {
            this.BeginInvoke(new MethodInvoker(delegate {
                this.Output.Clear();
            }));
        }
        public void MethodSendKeys(string Input) {
            this.BeginInvoke(new MethodInvoker(delegate {
                SendKeys.Send(Input);
            }));
        }
        public void ProgramSerialManagement(StepEnumerations.StepExecutable StepEx, string Arguments) {
            if (ProgramManager.Program_CurrentManager >= 0) {
                if (SystemManager.SerialManagers.Count == 0) { return; }
                if (ProgramManager.Program_CurrentManager >= SystemManager.SerialManagers.Count) { return; }
                if (StepEx == StepEnumerations.StepExecutable.Open) {
                    this.BeginInvoke(new MethodInvoker(delegate {
                        this.SetPort(SystemManager.SerialManagers[ProgramManager.Program_CurrentManager], Arguments);
                        this.Connect(SystemManager.SerialManagers[ProgramManager.Program_CurrentManager]);
                    }));
                }
                else if (StepEx == StepEnumerations.StepExecutable.Close) {
                    this.BeginInvoke(new MethodInvoker(delegate {
                        this.Disconnect(SystemManager.SerialManagers[ProgramManager.Program_CurrentManager]);
                    }));
                }
                else if (StepEx == StepEnumerations.StepExecutable.SelectChannel) {
                    int Index = -1;
                    int i = 0;
                    foreach (SerialManager SerMan in SystemManager.SerialManagers) {
                        if (SerMan.StateName == Arguments.Trim()) {
                            Index = i; break;
                        }
                        i++;
                    }
                    if (i > 0) {
                        try {
                            this.BeginInvoke(new MethodInvoker(delegate {
                                this.navigator1.SelectedItem = i;
                            }));
                        }
                        catch { }
                    }

                }
            }
        }

        private void SetPort(SerialManager? SerMan, string Arguments) {
            try {
                SystemManager.SerialManagers[ProgramManager.Program_CurrentManager].PortName = Arguments;
            }
            catch {
                Print(ErrorType.M_Error, "COM_PSET", "'" + Arguments + "' is already in use or is an unrecognized port name");
            }
        }
        #endregion
        #region MultiProgram Editing
        private void tabHeader1_SelectedIndexChanged(object? sender, int CurrentIndex, int PreviousIndex) {
            if (thPrograms.Tabs.Count > 0) {
                if (CurrentIndex < thPrograms.Tabs.Count) {
                    object? TagData = thPrograms.Tabs[CurrentIndex].Tag;
                    if (TagData != null) {
                        if (TagData.GetType() == typeof(ProgramObject)) {
                            lstStepProgram.Tag = TagData;
                            ProgramManager.CurrentEditingProgram = (ProgramObject)TagData;
                            lstStepProgram.ExternalItems = ((ProgramObject)TagData).Program;
                            lstStepProgram.LineMarkerIndex = ((ProgramObject)TagData).ProgramMarker;
                            ProgramManager.ApplyIndentation(lstStepProgram, false);
                            ProgramManager.ApplySyntaxColouring(lstStepProgram, -1, true);
                        }
                    }
                }
            }
        }
        private void commandPalletToolStripMenuItem_Click(object? sender, EventArgs e) {
            CommandPalette CmdPalette = new CommandPalette();
            Classes.ApplicationManager.OpenInternalApplicationOnce(CmdPalette, true);
        }
        private void thPrograms_TabRightClicked(object? sender, TabClickedEventArgs Tab) {
            if (sender == null) { return; }
            if (sender.GetType() != typeof(ODModules.TabHeader)) { return; }
            cmPrograms.Tag = Tab;
            cmPrograms.Show(Tab.ScreenLocation);
        }
        private void cmRunProgram_Click(object? sender, EventArgs e) {
            ProgramObject? PrgObj = SystemManager.GetProgramObjectFromTab((TabClickedEventArgs?)cmPrograms.Tag);
            if (PrgObj == null) { return; }
            ProgramManager.CurrentProgram = PrgObj;
            btnRun.Text = GetTextFromTab((TabClickedEventArgs?)cmPrograms.Tag);
            ProgramManager.RunProgramFromStart();
        }
        private void cmCloseProgram_Click(object? sender, EventArgs e) {
            if (cmPrograms.Tag == null) { return; }
            if (cmPrograms.Tag.GetType() == typeof(TabClickedEventArgs)) {
                RemoveProgram(((TabClickedEventArgs)cmPrograms.Tag).Index);
            }
        }
        private void cmbtnSetAsActive_Click(object? sender, EventArgs e) {
            ProgramObject? PrgObj = SystemManager.GetProgramObjectFromTab((TabClickedEventArgs?)cmPrograms.Tag);
            if (PrgObj == null) { return; }
            ProgramManager.CurrentProgram = PrgObj;
            btnRun.Text = GetTextFromTab((TabClickedEventArgs?)cmPrograms.Tag);
        }
        private void cmbtnProperties_Click(object? sender, EventArgs e) {
            ProgramObject? PrgObj = SystemManager.GetProgramObjectFromTab((TabClickedEventArgs?)cmPrograms.Tag);
            if (PrgObj == null) { return; }
            ProgramProperties PrgProp = new ProgramProperties();
            if (lstStepProgram.Tag == null) { return; }
            PrgProp.SelectedProgram = (ProgramObject)lstStepProgram.Tag;
            ApplicationManager.OpenInternalApplicationAsDialog(PrgProp, this);
        }
        private void tabHeader1_AddButtonClicked(object? sender) {
            NewProgram();
        }
        private void tabHeader1_CloseButtonClicked(object? sender, int Index) {
            RemoveProgram(Index);
        }
        private void removeProgramToolStripMenuItem_Click(object? sender, EventArgs e) {
            RemoveProgram(thPrograms.SelectedIndex);
        }
        private void newProgramToolStripMenuItem_Click(object? sender, EventArgs e) {
            NewProgram();
        }
        private void cmbtnNewProgram_Click(object? sender, EventArgs e) {
            NewProgram();
        }
        private string GetTextFromTab(TabClickedEventArgs? Args) {
            //if (cmPrograms.Tag == null) { return ""; }
            // if (cmPrograms.Tag.GetType() == typeof(TabClickedEventArgs)) {
            // TabClickedEventArgs Args = (TabClickedEventArgs)cmPrograms.Tag;
            if (Args == null) { return ""; }
            if (Args.SelectedTab.GetType() == typeof(Tab)) {
                Tab TabData = (Tab)Args.SelectedTab;
                return TabData.Text;
            }
            //}
            return "";
        }
        bool InRenameMode = false;
        private void ThPrograms_TabDoubleClicked(object sender, TabClickedEventArgs Tab) {
            ShowProgramRenameBox(Tab);
        }
        private void renameToolStripMenuItem_Click(object? sender, EventArgs e) {
            ShowProgramRenameBox((TabClickedEventArgs?)cmPrograms.Tag);
        }
        private void ShowProgramRenameBox(TabClickedEventArgs? EventData, bool PushEventData = false) {
            if (EventData == null) { return; }
            Rectangle TabRectangle = UserInterfaceManager.GetRectangleFromTab(EventData, true);
            ProgramObject? PrgObj = SystemManager.GetProgramObjectFromTab(EventData);
            if (PrgObj == null) { return; }
            string CurrentText = GetTextFromTab(EventData);
            System.Windows.Forms.TextBox RenameBox = new System.Windows.Forms.TextBox();
            RenameBox.Text = CurrentText;
            RenameBox.Font = thPrograms.Font;
            // RenameBox.BorderStyle = BorderStyle.None;
            RenameBox.Multiline = false;
            int CentreHeight = 0;
            RenameBox.Show();
            if (TabRectangle.Height > RenameBox.ClientSize.Height) {
                CentreHeight = ((TabRectangle.Height - RenameBox.ClientSize.Height) / 2) + TabRectangle.Y;
            }
            else {
                CentreHeight = ((RenameBox.ClientSize.Height - TabRectangle.Height) / 2) + TabRectangle.Y;
            }
            RenameBox.Location = new Point(TabRectangle.X, CentreHeight);
            RenameBox.Size = TabRectangle.Size;
            RenameBox.BringToFront();
            RenameBox.Tag = EventData;
            InRenameMode = true;
            thPrograms.Controls.Add(RenameBox);
            RenameBox.Focus();
            RenameBox.Leave += RenameBox_Leave;
            RenameBox.LostFocus += RenameBox_LostFocus;
            RenameBox.KeyDown += RenameBox_KeyDown; ; ;
            RenameBox.TextChanged += RenameBox_TextChanged;
        }
        private void RenameBox_Leave(object? sender, EventArgs e) {
            if (sender == null) { return; }
            //if (sender.GetType() == typeof(TextBox)) {
            //    DeregisterTextbox((TextBox)sender);
            //    thPrograms.Controls.Remove((TextBox)sender);
            //}
            RemoveFromControl(sender);
        }
        private void RenameBox_KeyDown(object? sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.Enter) {
                if (sender == null) { return; }
                //if (sender.GetType() == typeof(TextBox)) {
                //    DeregisterTextbox((TextBox)sender);
                //    thPrograms.Controls.Remove((TextBox)sender);
                //}
                RemoveFromControl(sender);
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
        }
        private void RemoveFromControl(object Ctrl) {
            if (Ctrl.GetType() == typeof(System.Windows.Forms.TextBox)) {
                System.Windows.Forms.TextBox TxBx = (System.Windows.Forms.TextBox)Ctrl;
                if (TxBx.Tag == null) { return; }
                if (TxBx.Tag.GetType() == typeof(TabClickedEventArgs)) {
                    TabClickedEventArgs TCEA = (TabClickedEventArgs)TxBx.Tag;
                    if (TCEA.SelectedTab == null) { return; }
                    if (TCEA.SelectedTab.GetType() == typeof(Tab)) {
                        thPrograms.Controls.Remove(TxBx);
                    }
                    else if (TCEA.SelectedTab.GetType() == typeof(SerialManager)) {
                        navigator1.Controls.Remove(TxBx);
                    }
                }
                DeregisterTextbox((System.Windows.Forms.TextBox)Ctrl);
            }
        }
        private void RenameBox_TextChanged(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(System.Windows.Forms.TextBox)) {
                System.Windows.Forms.TextBox TxBx = (System.Windows.Forms.TextBox)sender;
                if (TxBx.Tag == null) {
                    //DeregisterTextbox(TxBx);
                    //thPrograms.Controls.Remove(TxBx);
                    RemoveFromControl(sender);
                }
                else {
                    if (TxBx.Tag.GetType() == typeof(TabClickedEventArgs)) {
                        TabClickedEventArgs TCEA = (TabClickedEventArgs)TxBx.Tag;
                        object? Data = TCEA.SelectedTab;
                        if (Data == null) { return; }
                        if (Data.GetType() == typeof(Tab)) {
                            Tab TabData = (Tab)Data;
                            if (TabData.Tag != null) {
                                if (TabData.Tag.GetType() == typeof(ProgramObject)) {
                                    TabData.Text = TxBx.Text;
                                    ((ProgramObject)TabData.Tag).Name = TxBx.Text;
                                }
                            }
                        }
                        else if (Data.GetType() == typeof(SerialManager)) {
                            SystemManager.SerialManagers[TCEA.Index].Name = TxBx.Text;
                            navigator1.Invalidate();
                        }
                        DocumentEdited = true;
                    }
                }
            }
        }
        private void RenameBox_LostFocus(object? sender, EventArgs e) {
            if (sender == null) { return; }
            //if (sender.GetType() == typeof(TextBox)) {
            //    DeregisterTextbox((TextBox)sender);
            //    thPrograms.Controls.Remove((TextBox)sender);
            //}
            RemoveFromControl(sender);
        }
        private void DeregisterTextbox(System.Windows.Forms.TextBox Tb) {
            Tb.Tag = null;
            Tb.Leave -= RenameBox_Leave;
            Tb.LostFocus -= RenameBox_LostFocus;
            Tb.TextChanged -= RenameBox_TextChanged;
            Tb.KeyDown -= RenameBox_KeyDown;
            InRenameMode = false;
        }
        #endregion
        #region Tools
        private void btnMonitor_Click(object? sender, EventArgs e) {
            Monitor NewMonitor = new Monitor();
            NewMonitor.Attached = this;
            Classes.ApplicationManager.OpenInternalApplicationOnce(NewMonitor);
        }
        private void optionsToolStripMenuItem_Click(object? sender, EventArgs e) {
            Settings ConfigApp = new Settings();
            ApplicationManager.OpenInternalApplicationOnce(ConfigApp, true);
        }
        private void keyPadToolStripMenuItem_Click(object? sender, EventArgs e) {
            Keypad KeypadApp = new Keypad();
            ApplicationManager.OpenInternalApplicationOnce(KeypadApp, true);
        }
        private void aboutToolStripMenuItem_Click(object? sender, EventArgs e) {
            About AboutWin = new About();
            ApplicationManager.OpenInternalApplicationOnce(AboutWin, true);
        }
        private void textComparatorToolStripMenuItem_Click(object? sender, EventArgs e) {
            WindowForms.TextComparator TxtCompare = new WindowForms.TextComparator();
            ApplicationManager.OpenInternalApplicationOnce(TxtCompare, true);
        }
        private void modbusRegistersToolStripMenuItem_Click(object? sender, EventArgs e) {
            ModbusRegisters MbRegs = new ModbusRegisters();
            ApplicationManager.OpenInternalApplicationOnce(MbRegs);
        }
        #endregion
        #region Document Handling
        bool documentEdited = false;
        private bool DocumentEdited {
            get { return documentEdited; }
            set {
                documentEdited = value;
                if (CurrentDocument.Trim(' ') == "") {
                    SetTitle(LocalisationManager.GetLocalisedText("untitled", "Untitled"));
                }
                else {
                    SetTitle(Path.GetFileNameWithoutExtension(CurrentDocument));
                }
            }
        }
        public void New() {
            bool ProceedNew = true;
            if (DocumentEdited == true) {

            }
            if (ProceedNew == true) {
                DocumentEdited = false;
                CleanProjectData();
                NewProgram("Main");
                SystemManager.AddChannel("", SerManager_CommandProcessed, SerMan_DataReceived);
                navigator1.SelectedItem = 0;
                SelectChannel(0);
                lstStepProgram.ExternalItems = ProgramManager.Programs[0].Program;
                lstStepProgram.Tag = ProgramManager.Programs[0];
                ProgramManager.CurrentEditingProgram = ProgramManager.Programs[0];
                ProgramManager.CurrentProgram = ProgramManager.Programs[0];

                thPrograms.SelectedIndex = 0;
                ProgramManager.UpdateProgramNames(thPrograms);
                thPrograms.Invalidate();
                navigator1.Invalidate();
                btnRun.Text = "Main";
                CurrentDocument = "";
                documentEdited = false;
                if (CurrentDocument.Trim(' ') == "") {
                    btnOpenLocation.Enabled = false;
                }
                else {
                    btnOpenLocation.Enabled = true;
                }
                SetTitle(LocalisationManager.GetLocalisedText("untitled", "Untitled"));
                ProjectManager.InvokeProjectLoaded();
            }
        }

        string CurrentDocument = "";
        private void btnNewStep_Click(object? sender, EventArgs e) {
            New();
        }
        private void btnSaveStep_Click(object? sender, EventArgs e) {
            Save();
        }
        private void btnSaveAsStep_Click(object? sender, EventArgs e) {
            Save(true);
        }
        private void btnOpenLocation_Click(object? sender, EventArgs e) {
            if (!File.Exists(CurrentDocument)) {
                return;
            }
            string argument = "/select, \"" + CurrentDocument + "\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }
        private void btnOpenStep_Click(object? sender, EventArgs e) {
            OpenFileViaDialog();
        }
        public void OpenFileViaDialog() {
            OpenFileDialog OpenDia = new OpenFileDialog();
            OpenDia.Filter = @"Serial Monitor Project (*.smp)|*.smp|Legacy Step File (*.cms)|*.cms";
            if (OpenDia.ShowDialog() == DialogResult.OK) {
                if (File.Exists(OpenDia.FileName)) {
                    Open(OpenDia.FileName);
                    AddFiletoRecentFiles(OpenDia.FileName);
                }
            }
        }
        public void Save(bool SaveAs = false) {
            bool IsExistingFile = false;
            if (CurrentDocument.Trim(' ') != "") {
                if (File.Exists(CurrentDocument)) {
                    IsExistingFile = true;
                }
            }
            ProgramManager.ArrangeProgramOrderings(thPrograms);
            if (SaveAs == true) { IsExistingFile = false; }

            if (IsExistingFile == false) {
                SaveFileDialog Save = new SaveFileDialog();
                Save.Filter = @"Serial Monitor Project (*.smp)|*.smp";
                Save.ShowDialog();
                if (Save.FileName != "") {
                    SetTitle(Path.GetFileNameWithoutExtension(Save.FileName));
                    ProjectManager.WriteFile(Save.FileName);
                    CurrentDocument = Save.FileName;
                }
            }
            else {
                ProjectManager.WriteFile(CurrentDocument);
                DocumentEdited = false;
            }
            if (CurrentDocument.Trim(' ') == "") {
                btnOpenLocation.Enabled = false;
            }
            else {
                btnOpenLocation.Enabled = true;
            }
            AddFiletoRecentFiles(CurrentDocument);
        }
        private void SetTitle(string DocumentName) {
            if (documentEdited == true) {
                this.Text = "*" + DocumentName + " - " + Application.ProductName;
            }
            else {
                this.Text = DocumentName + " - " + Application.ProductName;
            }
        }
        private void ClearPrograms() {
            thPrograms.ClearTabs();
            for (int i = ProgramManager.Programs.Count - 1; i >= 0; i--) {
                ProgramManager.RemoveProgram(i);
            }
        }
        private void CleanProjectData() {
            SystemManager.CloseAll();
            ProjectManager.ClearKeypadButtons();
            SystemManager.ClearChannels(SerManager_CommandProcessed, SerMan_DataReceived);
            ClearPrograms();
            lstStepProgram.LineRemoveAll();
            GC.Collect();
            DocumentEdited = false;
        }
        public void Open(string FileAddress) {
            if (!File.Exists(FileAddress)) { return; }
            string Extension = Path.GetExtension(FileAddress).ToLower();
            if (Extension == ".smp") {
                DocumentHandler.Open(FileAddress);
            }
            CleanProjectData();
            //
            if (Extension == ".smp") {
                ProjectManager.ReadSMPFile(FileAddress, SerManager_CommandProcessed, SerMan_DataReceived);
            }
            else if (Extension == ".cms") {
                ProjectManager.ReadCMSLFile(FileAddress, SerManager_CommandProcessed, SerMan_DataReceived);
            }
            if (ProgramManager.Programs.Count == 0) {
                ProgramManager.Programs.Add(new ProgramObject());
            }
            if (SystemManager.SerialManagers.Count > 0) {
                navigator1.SelectedItem = 0;
                CurrentManager = SystemManager.SerialManagers[0];
            }
            lstStepProgram.ExternalItems = ProgramManager.Programs[0].Program;
            lstStepProgram.Tag = ProgramManager.Programs[0];
            ProgramManager.CurrentProgram = ProgramManager.Programs[0];

            lstStepProgram.Invalidate();
            CurrentDocument = FileAddress;
            if (CurrentDocument.Trim(' ') == "") {
                btnOpenLocation.Enabled = false;
            }
            else {
                btnOpenLocation.Enabled = true;
            }
            ProgramManager.DetermineName(thPrograms, btnRun);
            ProgramManager.DetermineTabs(thPrograms);
            btnRun.Text = thPrograms.Tabs[0].Text;
            thPrograms.SelectedIndex = 0;
            thPrograms.Invalidate();
            SetTitle(Path.GetFileNameWithoutExtension(CurrentDocument));
            ProgramManager.ApplyIndentation(lstStepProgram, false);
            ProgramManager.ApplySyntaxColouring(lstStepProgram, -1, true);
            DocumentEdited = false;
        }
        private void NewProgram(string Name = "") {
            ProgramObject PrgObj = new ProgramObject(Name);
            ProgramManager.Programs.Add(PrgObj);
            Tab Tb = new Tab();
            Tb.Text = Name;
            Tb.Tag = PrgObj;
            thPrograms.Tabs.Add(Tb);
            ProgramManager.UpdateProgramNames(thPrograms);
            thPrograms.Invalidate();
            DocumentEdited = true;
        }
        private void RemoveProgram(int Index) {
            bool ChangeActiveProgram = false;
            bool ChangeEditingProgram = false;
            if (Index >= thPrograms.Tabs.Count) { return; }
            object? DataTag = thPrograms.Tabs[Index].Tag;
            if (DataTag == null) { return; }
            if (DataTag.GetType() == typeof(ProgramObject)) {
                ProgramObject PrgObj = (ProgramObject)DataTag;

                if (PrgObj == ProgramManager.CurrentProgram) {
                    ProgramManager.CurrentProgram = null;
                    ChangeActiveProgram = true;
                }
                if (lstStepProgram.Tag == PrgObj) {
                    lstStepProgram.Tag = null;
                    ChangeEditingProgram = true;
                }
                try {
                    thPrograms.Tabs.RemoveAt(Index);
                    ProgramManager.RemoveProgram(PrgObj);
                }
                catch { }
            }
            if (ProgramManager.Programs.Count == 0) {
                NewProgram();
                lstStepProgram.Tag = ProgramManager.Programs[0];
                lstStepProgram.ExternalItems = ProgramManager.Programs[0].Program;
                ProgramManager.CurrentProgram = ProgramManager.Programs[0];
                thPrograms.SelectedIndex = 0;
                btnRun.Text = thPrograms.Tabs[0].Text;
            }
            else {
                if (ChangeActiveProgram == true) {
                    ProgramManager.CurrentProgram = ProgramManager.Programs[0];
                    btnRun.Text = thPrograms.Tabs[0].Text;
                }
                if (ChangeEditingProgram == true) {
                    thPrograms.SelectedIndex = ProgramManager.Programs.Count - 1;
                    lstStepProgram.Tag = ProgramManager.Programs[ProgramManager.Programs.Count - 1];
                    lstStepProgram.ExternalItems = ProgramManager.Programs[ProgramManager.Programs.Count - 1].Program;
                }
            }
            thPrograms.Invalidate();
            DocumentEdited = true;
            ProgramManager.DetermineName(thPrograms, btnRun);
        }
        #endregion
        #region Window Management
        private void btnWinWindowManager_Click(object? sender, EventArgs e) {
            WindowForms.WindowManager WindowMan = new WindowForms.WindowManager();
            Classes.ApplicationManager.OpenInternalApplicationOnce(WindowMan, true);
        }
        private void btnWinCloseAll_Click(object? sender, EventArgs e) {
            FormCollection fc = Application.OpenForms;
            for (int i = fc.Count - 1; i >= 0; i--) {
                object? Frm = fc[i];
                if (Frm == null) { continue; }
                if ((Frm.GetType() != typeof(MainWindow))) {
                    ((Form)Frm).Close();
                }
            }
        }
        #endregion
        private void Form1_KeyPress(object? sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)27) {
                if (ProgramManager.ProgramState != StepEnumerations.StepState.Stopped) {
                    ProgramManager.ProgramState = StepEnumerations.StepState.Stopped;
                    ProgramManager.ProgramStep = 0;
                }
            }
            if (InRenameMode == false) {
                if (pnlRenamePanel.Visible == false) {
                    Output.Focus();
                }
            }
        }
        private void btnOptViewSource_Click(object? sender, EventArgs e) {
            Output.ShowOrigin = btnOptViewSource.Checked;
        }
        private void Output_Click(object? sender, EventArgs e) {
            LastEntered = sender;
            Output.Focus();
        }

        private void lstStepProgram_MouseClick(object? sender, MouseEventArgs e) {
            LastEntered = sender;
        }
        private void navigator1_MouseClick(object? sender, MouseEventArgs e) {
            LastEntered = sender;
        }
        private void selectAllToolStripMenuItem_Click(object? sender, EventArgs e) {
            lstStepProgram.LineSelectAll();
        }
        private void fileToolStripMenuItem_Click(object? sender, EventArgs e) {
            LoadRecentItems();
        }
        private void btnMenuExit_Click(object? sender, EventArgs e) {
            this.Close();
        }


        private void toolStripMenuItem1_Click(object? sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.IsMaster = btnMenuModbusMaster.Checked;
            }
        }
        private void outputInTerminalToolStripMenuItem_Click(object? sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.OutputToMasterTerminal = btnMenuOutputMaster.Checked;
            }
        }




        private void btnRun_DropDownOpening(object? sender, EventArgs e) {
            ProgramEditing.ListPrograms(sender, TsMi_Click);
        }
        private void activeProgramToolStripMenuItem_DropDownOpening(object? sender, EventArgs e) {
            ProgramEditing.ListPrograms(sender, TsMi_Click);
        }

        #region Not Used Events
        private void editToolStripMenuItem_Click(object? sender, EventArgs e) {

        }
        private void Output_Enter(object? sender, EventArgs e) {

        }
        private void Output_Validated(object? sender, EventArgs e) {

        }
        private void Output_MouseClick(object? sender, MouseEventArgs e) {

        }
        private void toolStripSeparator27_Click(object? sender, EventArgs e) {

        }
        private void tabHeader1_Load(object? sender, EventArgs e) {

        }
        private void activeProgramToolStripMenuItem_Click(object? sender, EventArgs e) {

        }
        private void ddbPorts_Click(object? sender, EventArgs e) {

        }
        private void lstStepProgram_Load(object? sender, EventArgs e) {

        }
        private void renameChannelToolStripMenuItem_Click(object? sender, EventArgs e) {

        }
        private void pnlRenamePanel_Paint(object? sender, PaintEventArgs e) {

        }
        #endregion
        private void ProgramManager_ProgramListingChanged() {
            DocumentEdited = true;
            lstStepProgram.Invalidate();
        }

        private void deviceManagerToolStripMenuItem_Click(object? sender, EventArgs e) {
            try {
                Process proc = new Process();
                proc.StartInfo.FileName = "mmc.exe";
                proc.StartInfo.Arguments = "devmgmt.msc";
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.Start();
            }
            catch { }
        }

        private void propertiesToolStripMenuItem1_Click(object? sender, EventArgs e) {
            ApplicationManager.OpenSerialProperties(currentManager, false, true);
        }

        private void oscilloscopeToolStripMenuItem_Click(object? sender, EventArgs e) {
            Oscilloscope Scope = new Oscilloscope();
            ApplicationManager.OpenInternalApplicationOnce(Scope, true);
        }

        private void resetToolStripMenuItem_Click(object? sender, EventArgs e) {

        }

        private void lstStepProgram_MouseClick(object? sender, EventArgs e) {
            LastEntered = sender;
        }


    }


    public class FullScreenStyle {
        public bool IsFullScreen = false;
        public FormWindowState WindowState = FormWindowState.Normal;
        public FormBorderStyle BorderStyle = FormBorderStyle.Sizable;
        public Point WindowPosition;
        public Size WindowSize;
    }
}