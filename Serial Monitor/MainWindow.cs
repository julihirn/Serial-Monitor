using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using Svg;
using static System.Windows.Forms.LinkLabel;
using Serial_Monitor.Classes.Step_Programs;

namespace Serial_Monitor {
    public partial class MainWindow : Form, Interfaces.ITheme {
        public event CCommandProcessedHandler? CommandProcessed;
        public delegate void CCommandProcessedHandler(object sender, string Data);
        //SerialPort Port = new SerialPort();
        //bool SystemEnabled = true;

        //StreamInputFormat InputFormat = StreamInputFormat.Text;
        //StreamOutputFormat OutputFormat = StreamOutputFormat.Text;
        //SerialManager SerManager = new SerialManager();

        Thread ThreadStepExecutable;

        SerialManager? currentManager = null;
        SerialManager? CurrentManager {
            get { return currentManager; }
            set {
                currentManager = value;
                if (value != null) {
                    ddbBAUDRate.Text = value.Port.BaudRate.ToString();
                    ddbBAUDRate.Tag = value.Port.BaudRate;
                    CheckBaudRate(value.Port.BaudRate);
                    ddbBits.Text = value.Port.DataBits.ToString();
                    ddbBits.Tag = value.Port.DataBits.ToString();
                    string StopBits = EnumManager.StopBitsToString(value.Port.StopBits);
                    ddbStopBits.Text = StopBits;
                    ddbStopBits.Tag = StopBits;
                    CheckStopBits(ddbStopBits.Text);
                    string Parity = EnumManager.ParityToString(value.Port.Parity);
                    ddbParity.Text = Parity;
                    ddbParity.Tag = Parity;
                    CheckParity(ddbParity.Text);
                    StringPair SelectIn = EnumManager.InputFormatToString(value.InputFormat, false);
                    StringPair SelectOut = EnumManager.OutputFormatToString(value.OutputFormat, false);
                    ddbInputFormat.Text = SelectIn.A;
                    ddbInputFormat.Tag = SelectIn.B;
                    CheckInputFormat(SelectIn.B);
                    ddbOutputFormat.Text = SelectOut.A;
                    ddbOutputFormat.Tag = SelectOut.B;
                    CheckOutputFormat(SelectOut.B);
                    ddbPorts.Text = value.Port.PortName;
                    SystemRunning(value.Port.IsOpen);
                    btnMenuModbusMaster.Checked = value.IsMaster;
                }
            }
        }
        
        
        public MainWindow() {
            InitializeComponent();
            ProgramManager.MainInstance = this;
            //ProgramManager.Programs.Add(new ProgramObject("Main"));
            thPrograms.Tabs.Clear();
            NewProgram("Main");
            lstStepProgram.ExternalItems = ProgramManager.Programs[0].Program;
            lstStepProgram.Tag = ProgramManager.Programs[0];
            ProgramManager.CurrentEditingProgram = ProgramManager.Programs[0];
            ProgramManager.CurrentProgram = ProgramManager.Programs[0];

            ProgramManager.ProgramNameChanged += ProgramManager_ProgramNameChanged;


            AddManager("");
            currentManager = SystemManager.SerialManagers[0];
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            ThreadStepExecutable = new Thread(ProgramManager.StepProgram);
            ThreadStepExecutable.IsBackground = true;
            ThreadStepExecutable.Start();
            LoadRecentItems();
        }



        private void toolStripMenuItem3_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.DataBits = 2;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            AdjustUserInterface();
            RecolorAll();
            AddIcons();
            LoadProgramOperations();
            RefreshPorts();
            SelectFirstPort();
            LoadAllBauds();
            CheckParity(ddbParity.Text);
            CheckBits(ddbBits.Text);
            CheckStopBits(ddbStopBits.Text);
            SystemRunning(false);
            CheckInputFormat("frmTxt");
            CheckOutputFormat("frmTxt");
            SetDefaultStyleValues();
            Output.FlashCursor = true;
            navigator1.LinkedList = SystemManager.SerialManagers;
            lstStepProgram.Items.Clear();
            Color FadeInColor = Color.FromArgb(100, DesignerSetup.GetAccentColor());
            msMain.BackColorNorthFadeIn = FadeInColor;
            RefreshChannels();
            ProgramManager.ProgramListingChanged += ProgramManager_ProgramListingChanged;
            //DetermineTabs();
        }
        public void ApplyTheme() {

            RecolorAll();
            AddIcons();
        }
        private void RecolorAll() {
            ApplicationManager.IsDark = Properties.Settings.Default.THM_SET_IsDark;
            this.SuspendLayout();
            if (ApplicationManager.IsDark == true) {
                navigator1.ShadowColor = Color.FromArgb(80, 0, 0, 0);
                navigator1.SelectedColor = Color.FromArgb(60, 0, 0, 0);
                navigator1.SideShadowColor = Color.FromArgb(60, 0, 0, 0);
                thPrograms.TabSelectedShadowColor = Color.FromArgb(255, 0, 0, 0);
            }
            else {
                navigator1.ShadowColor = Color.FromArgb(40, 0, 0, 0);
                navigator1.SelectedColor = Color.FromArgb(20, 0, 0, 0);
                navigator1.SideShadowColor = Color.FromArgb(20, 0, 0, 0);
                thPrograms.TabSelectedShadowColor = Color.FromArgb(125, 0, 0, 0);
            }
            BackColor = Properties.Settings.Default.THM_COL_Editor;

            msMain.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            msMain.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            msMain.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            msMain.MenuBackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            msMain.MenuBackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.MenuBackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.MenuBackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;

            msMain.ItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            msMain.ItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            tsMain.ItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            tsMain.ItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            msMain.StripItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            msMain.StripItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            tsMain.StripItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            tsMain.StripItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            thPrograms.TabHoverBackColor = Properties.Settings.Default.THM_COL_ButtonSelected;

            msMain.MenuBorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            tsMain.MenuBorderColor = Properties.Settings.Default.THM_COL_BorderColor;

            msMain.MenuSeparatorColor = Properties.Settings.Default.THM_COL_SeperatorColor;
            tsMain.MenuSeparatorColor = Properties.Settings.Default.THM_COL_SeperatorColor;
            thPrograms.TabDividerColor = Properties.Settings.Default.THM_COL_SeperatorColor;

            msMain.MenuSymbolColor = Properties.Settings.Default.THM_COL_SymbolColor;
            tsMain.MenuSymbolColor = Properties.Settings.Default.THM_COL_SymbolColor;

            tsMain.ItemCheckedBackColorNorth = Properties.Settings.Default.THM_COL_SymbolColor;
            tsMain.ItemCheckedBackColorNorth = Properties.Settings.Default.THM_COL_SymbolColor;

            tsMain.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            msMain.ItemForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            tsMain.ItemForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            pnlStepProgram.ArrowColor = Properties.Settings.Default.THM_COL_ForeColor;
            pnlStepProgram.CloseColor = Properties.Settings.Default.THM_COL_ForeColor;
            navigator1.ArrowColor = Properties.Settings.Default.THM_COL_ForeColor;

            msMain.ItemSelectedForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            tsMain.ItemSelectedForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            pnlStepProgram.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            thPrograms.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            thPrograms.TabSelectedForeColor = Properties.Settings.Default.THM_COL_ForeColor;


            lstStepProgram.ColumnForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            Output.ForeColor = Properties.Settings.Default.THM_COL_TerminalForeColor;

            Output.BackColor = Properties.Settings.Default.THM_COL_Editor;
            lstStepProgram.BackColor = Properties.Settings.Default.THM_COL_Editor;

            navigator1.BackColor = Properties.Settings.Default.THM_COL_SeconaryBackColor;
            navigator1.MidColor = Properties.Settings.Default.THM_COL_Editor;
            navigator1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            navigator1.ArrowColor = Properties.Settings.Default.THM_COL_ForeColor;

            lstStepProgram.RowColor = Properties.Settings.Default.THM_COL_RowColor;
            lstStepProgram.GridlineColor = Properties.Settings.Default.THM_COL_GridLineColor;

            pnlStepProgram.LabelBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            pnlStepProgram.BackColor = Properties.Settings.Default.THM_COL_Editor;

            thPrograms.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            lstStepProgram.ColumnColor = Properties.Settings.Default.THM_COL_MenuBack;

            Output.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
            Output.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;

            lstStepProgram.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
            lstStepProgram.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;

            lstStepProgram.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            foreach (object obj in tsMain.Items) {
                if (obj.GetType() == typeof(ToolStripSplitButton)) {
                    ((ToolStripSplitButton)obj).ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                }
                else if (obj.GetType() == typeof(ToolStripButton)) {
                    ((ToolStripButton)obj).ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                }
                else if (obj.GetType() == typeof(ToolStripDropDownButton)) {
                    ((ToolStripDropDownButton)obj).ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                }
                else if (obj.GetType() == typeof(ToolStripLabel)) {
                    ((ToolStripLabel)obj).ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                }
            }

            ColorForeColorContextMenu(cmStepEditor);
            ColorForeColorContextMenu(cmStepPrg);
            ColorForeColorContextMenu(cmPrograms);

            lblRxBytes.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            lblTxBytes.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            this.ResumeLayout();
        }
        private void ColorForeColorContextMenu(ODModules.ContextMenu Cm) {
            Cm.MenuBackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            Cm.MenuBackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            Cm.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            Cm.MouseOverColor = Properties.Settings.Default.THM_COL_ButtonSelected;
            Cm.BorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            Cm.SeparatorColor = Properties.Settings.Default.THM_COL_SeperatorColor;
            foreach (ToolStripItem CmI in Cm.Items) {
                CmI.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            }
        }
        private void AddManager(string ManagerName) {
            SerialManager SerMan = new SerialManager();
            SystemManager.SerialManagers.Add(SerMan);
            SerMan.Name = ManagerName;
            SerMan.CommandProcessed += SerManager_CommandProcessed;
            SerMan.DataReceived += SerMan_DataReceived;
        }
        private void ClearManagers() {
            for (int i = SystemManager.SerialManagers.Count - 1; i >= 0; i--) {
                SystemManager.SerialManagers[i].CleanUp();
                SystemManager.SerialManagers[i].CommandProcessed -= SerManager_CommandProcessed;
                SystemManager.SerialManagers[i].DataReceived -= SerMan_DataReceived;
                SystemManager.SerialManagers.RemoveAt(i);
            }

        }


        #region Form Border


        #endregion

        #region Receiving Data
        private void SerMan_DataReceived(object sender, bool PrintLine, string Data) {
            string SourceName = "";
            if (sender.GetType() == typeof(SerialManager)) {
                SerialManager SM = (SerialManager)sender;
                SourceName = SM.Port.PortName;
            }
            if (PrintLine == true) {
                Output.Print(SourceName, Data);
            }
            else {
                Output.AttendToLastLine(SourceName, Data, true);
            }
        }
        private void SerManager_CommandProcessed(object sender, string Data) {
            string SourceName = "";
            if (sender.GetType() == typeof(SerialManager)) {
                SerialManager SM = (SerialManager)sender;
                SourceName = SM.Port.PortName;
            }
            CommandProcessed?.Invoke(sender, Data);
            // Debug.Print(Data);
            Output.Print(SourceName, Data);
        }
        #endregion
        private void AdjustUserInterface() {
            msMain.Padding = DesignerSetup.ScalePadding(msMain.Padding);
            tsMain.Padding = DesignerSetup.ScalePadding(tsMain.Padding);
            lstStepProgram.ScaleColumnWidths();
            //navigator1.Width = DesignerSetup.ScaleInteger(navigator1.Width);
        }
        private void AddIcons() {
            DesignerSetup.SetImageSizes(RenderHandler.DPI());

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Grid, keyPadToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Memory, ddbPorts, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Connect_16x, btnConnect, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Disconnect_16x, btnDisconnect, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Input, ddbInputFormat, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Output1, ddbOutputFormat, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Input, btnChannelInputFormat, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Output1, btnChannelOutputFormat, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

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

            DesignerSetup.LinkSVGtoControl(Properties.Resources.NewRow, newProgramToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Add, addCommandToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, btnPrgRemoveStepLines, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Add, addCommandToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, removeSelectedToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
        }
        #region Channel Settings
        private void ddbChannels_DropDownOpening(object sender, EventArgs e) {
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
                if (CurrentManager != null) {
                    int Temp = (int)((ToolStripMenuItem)sender).Tag;
                    navigator1.SelectedItem = Temp;
                }
                navigator1.Invalidate();
            }
        }
        #endregion 
        #region Connection Settings
        private void btnConnect_Click(object sender, EventArgs e) {
            Connect(CurrentManager);
        }
        private void Connect(SerialManager? SerMan) {
            if (SerMan != null) {
                try {
                    SerMan.Port.Open();
                }
                catch {
                    Print(ErrorType.M_Error, "COM_PSTART", "Could not open the port");
                }
                if (CurrentManager != null) {
                    SystemRunning(CurrentManager.Port.IsOpen);
                }
            }
            else {
                SystemRunning(false);
            }
        }
        private void btnDisconnect_Click(object sender, EventArgs e) {
            Disconnect(CurrentManager);
        }
        private void Disconnect(SerialManager? SerMan) {
            if (SerMan != null) {
                try {
                    SerMan.Port.Close();
                }
                catch {
                    Print(ErrorType.M_Error, "COM_PEND", "Could not close the port");
                }
                if (CurrentManager != null) {
                    SystemRunning(CurrentManager.Port.IsOpen);
                }
            }
            else {
                SystemRunning(false);
            }

        }
        private void Print(ErrorType Severity, string ErrorCode, string Msg) {
            if (Severity == ErrorType.M_Error) {
                Output.Print("ERROR: " + ErrorCode + " " + Msg, Color.FromArgb(207, 137, 87));
            }
            else if (Severity == ErrorType.M_CriticalError) {
                Output.Print("STOP: " + ErrorCode + " " + Msg, Color.FromArgb(207, 137, 87));
            }
            else if (Severity == ErrorType.M_Warning) {
                Output.Print("WARNING: " + ErrorCode + " " + Msg, Color.FromArgb(215, 191, 107));
            }
            else if (Severity == ErrorType.M_Notification) {
                Output.Print(Msg);
            }
        }
        private void SystemRunning(bool Running) {
            if (CurrentManager != null) {
                if (Running == true) {
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    ddbPorts.Enabled = false;
                    ddbBAUDRate.Enabled = false;
                    ddbParity.Enabled = false;
                    ddbBits.Enabled = false;
                    ddbStopBits.Enabled = false;
                }
                else {
                    btnConnect.Enabled = CurrentManager.SystemEnabled;
                    btnDisconnect.Enabled = false;
                    ddbPorts.Enabled = true;
                    ddbBAUDRate.Enabled = CurrentManager.SystemEnabled;
                    ddbParity.Enabled = CurrentManager.SystemEnabled;
                    ddbBits.Enabled = CurrentManager.SystemEnabled;
                    ddbStopBits.Enabled = CurrentManager.SystemEnabled;
                }
            }
            else {
                btnConnect.Enabled = false;
                btnDisconnect.Enabled = false;
                ddbPorts.Enabled = true;
                ddbBAUDRate.Enabled = false;
                ddbParity.Enabled = false;
                ddbBits.Enabled = false;
                ddbStopBits.Enabled = false;
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
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports, StringComparer.CurrentCultureIgnoreCase);
            foreach (string port in ports) {
                if (ItemExists(port) == false) {
                    ToolStripMenuItem Itm = new ToolStripMenuItem();
                    Itm.Text = port;
                    Itm.Tag = port;
                    Itm.ImageScaling = ToolStripItemImageScaling.None;
                    Itm.CheckOnClick = true;
                    Itm.Click += Itm_Click;
                    ddbPorts.DropDownItems.Add(Itm);
                    ToolStripMenuItem Itm2 = new ToolStripMenuItem();
                    Itm2.Text = port;
                    Itm2.Tag = port;
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
                CheckPort(ddbPorts.Text);
            }
        }
        private bool ItemExists(string Name) {
            foreach (object Item in ddbPorts.DropDownItems) {
                if (Item.GetType() == typeof(ToolStripMenuItem)) {
                    if (((ToolStripMenuItem)Item).Tag != null) {
                        if (((ToolStripMenuItem)Item).Text == Name) {
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
                if (CurrentManager != null) {
                    ddbPorts.Text = ((ToolStripMenuItem)sender).Text;
                    CurrentManager.Port.PortName = ddbPorts.Text;
                }
                CheckPort(ddbPorts.Text);
                navigator1.Invalidate();
            }
        }
        private void ddbPorts_DropDownOpening(object sender, EventArgs e) {
            RefreshPorts();
        }
        private void SelectFirstPort() {
            if (ddbPorts.DropDownItems.Count > 0) {
                if (CurrentManager != null) {
                    ddbPorts.Text = ddbPorts.DropDownItems[0].Text;
                    CurrentManager.Port.PortName = ddbPorts.Text;
                }
                CheckPort(ddbPorts.Text);
            }
        }
        private void CheckPort(string Type) {
            foreach (ToolStripMenuItem Item in ddbPorts.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
            foreach (ToolStripMenuItem Item in btnChannelPort.DropDownItems) {
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
            LoadBAUDRate(50);
            LoadBAUDRate(75);
            LoadBAUDRate(110);
            LoadBAUDRate(134);
            LoadBAUDRate(150);
            LoadBAUDRate(200);
            LoadBAUDRate(300);
            LoadBAUDRate(600);
            LoadBAUDRate(1200);
            LoadBAUDRate(1800);
            LoadBAUDRate(2400);
            LoadBAUDRate(4800);
            LoadBAUDRate(9600);
            LoadBAUDRate(19200);
            LoadBAUDRate(28800);
            LoadBAUDRate(38400);
            LoadBAUDRate(57600);
            LoadBAUDRate(76800);
            LoadBAUDRate(115200);
            LoadBAUDRate(230400);
            LoadBAUDRate(460800);
            LoadBAUDRate(576000);
            LoadBAUDRate(921600);
            CheckBaudRate(9600);
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
                if (CurrentManager != null) {
                    CurrentManager.BaudRate = int.Parse(ddbBAUDRate.Tag.ToString() ?? "9600");
                }
            }
            CheckBaudRate(int.Parse(ddbBAUDRate.Text));
            navigator1.Invalidate();
        }
        private void CheckBaudRate(int Rate) {
            foreach (ToolStripMenuItem Item in ddbBAUDRate.DropDownItems) {
                if (Item.Text == Rate.ToString()) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
            foreach (ToolStripMenuItem Item in btnChannelBaud.DropDownItems) {
                if (Item.Text == Rate.ToString()) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
        }
        #endregion
        #region Parity Settings
        private void btnParityNone_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.Parity = Parity.None;
                ddbParity.Text = EnumManager.ParityToString(CurrentManager.Port.Parity);
            }
            CheckParity(ddbParity.Text);
            navigator1.Invalidate();
        }
        private void btnParityEven_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.Parity = Parity.Even;
                ddbParity.Text = EnumManager.ParityToString(CurrentManager.Port.Parity);
            }
            CheckParity(ddbParity.Text);
            navigator1.Invalidate();
        }
        private void btnParityOdd_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.Parity = Parity.Odd;
                ddbParity.Text = EnumManager.ParityToString(CurrentManager.Port.Parity);
            }
            CheckParity(ddbParity.Text);
            navigator1.Invalidate();
        }
        private void btnParitySpace_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.Parity = Parity.Space;
                ddbParity.Text = EnumManager.ParityToString(CurrentManager.Port.Parity);
            }
            CheckParity(ddbParity.Text);
            navigator1.Invalidate();
        }
        private void btnParityMark_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.Parity = Parity.Mark;
                ddbParity.Text = EnumManager.ParityToString(CurrentManager.Port.Parity);
            }
            CheckParity(ddbParity.Text);
            navigator1.Invalidate();
        }
        private void btnChannelNoParity_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.Parity = Parity.None;
                ddbParity.Text = EnumManager.ParityToString(CurrentManager.Port.Parity);
            }
            CheckParity(ddbParity.Text);
            navigator1.Invalidate();
        }
        private void btnChannelEvenParity_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.Parity = Parity.Even;
                ddbParity.Text = EnumManager.ParityToString(CurrentManager.Port.Parity);
            }
            CheckParity(ddbParity.Text);
            navigator1.Invalidate();
        }
        private void btnChannelOddParity_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.Parity = Parity.Odd;
                ddbParity.Text = EnumManager.ParityToString(CurrentManager.Port.Parity);
            }
            CheckParity(ddbParity.Text);
            navigator1.Invalidate();
        }
        private void btnChannelSpaceParity_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.Parity = Parity.Space;
                ddbParity.Text = EnumManager.ParityToString(CurrentManager.Port.Parity);
            }
            CheckParity(ddbParity.Text);
            navigator1.Invalidate();
        }
        private void btnChannelMarkParity_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.Parity = Parity.Mark;
                ddbParity.Text = EnumManager.ParityToString(CurrentManager.Port.Parity);
            }
            CheckParity(ddbParity.Text);
            navigator1.Invalidate();
        }
        private void CheckParity(string Type) {
            foreach (ToolStripMenuItem Item in ddbParity.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
            foreach (ToolStripMenuItem Item in btnChannelParity.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
        }
        #endregion
        #region Bit Settings
        private void toolStripMenuItem2_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.DataBits = 5;
                ddbBits.Text = "5";
            }
            CheckBits(ddbBits.Text);
            navigator1.Invalidate();
        }

        private void btnChanDB_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.DataBits = 8;
                ddbBits.Text = "8";
            }
            CheckBits(ddbBits.Text);
            navigator1.Invalidate();
        }

        private void btnChanDB7_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.DataBits = 7;
                ddbBits.Text = "7";
            }
            CheckBits(ddbBits.Text);
            navigator1.Invalidate();
        }

        private void btnChanDB6_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.DataBits = 6;
                ddbBits.Text = "6";
            }
            CheckBits(ddbBits.Text);
            navigator1.Invalidate();
        }
        private void btnBits5_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.DataBits = 5;
                ddbBits.Text = "5";
            }
            CheckBits(ddbBits.Text);
            navigator1.Invalidate();
        }
        private void btnBits6_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.DataBits = 6;
                ddbBits.Text = "6";
            }
            CheckBits(ddbBits.Text);
            navigator1.Invalidate();
        }
        private void btnBits7_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.DataBits = 7;
                ddbBits.Text = "7";
            }
            CheckBits(ddbBits.Text);
            navigator1.Invalidate();
        }
        private void btnBits8_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.DataBits = 8;
                ddbBits.Text = "8";
            }
            CheckBits(ddbBits.Text);
            navigator1.Invalidate();
        }
        private void CheckBits(string Type) {
            foreach (ToolStripMenuItem Item in ddbBits.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
            foreach (ToolStripMenuItem Item in btnChannelDataBits.DropDownItems) {
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
        private void btnStopBitsNone_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.StopBits = StopBits.None;
                ddbStopBits.Text = EnumManager.StopBitsToString(CurrentManager.Port.StopBits);
            }
            CheckStopBits(ddbStopBits.Text);
            navigator1.Invalidate();
        }
        private void btnStopBits1_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.StopBits = StopBits.One;
                ddbStopBits.Text = EnumManager.StopBitsToString(CurrentManager.Port.StopBits);
            }
            CheckStopBits(ddbStopBits.Text);
            navigator1.Invalidate();
        }
        private void btnStopBits15_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.StopBits = StopBits.OnePointFive;
                ddbStopBits.Text = EnumManager.StopBitsToString(CurrentManager.Port.StopBits);
            }
            CheckStopBits(ddbStopBits.Text);
            navigator1.Invalidate();
        }
        private void btnStopBits2_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.StopBits = StopBits.Two;
                ddbStopBits.Text = EnumManager.StopBitsToString(CurrentManager.Port.StopBits);
            }
            CheckStopBits(ddbStopBits.Text);
            navigator1.Invalidate();
        }
        private void btnChannelStopBits0_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.StopBits = StopBits.None;
                ddbStopBits.Text = EnumManager.StopBitsToString(CurrentManager.Port.StopBits);
            }
            CheckStopBits(ddbStopBits.Text);
            navigator1.Invalidate();
        }
        private void btnChannelStopBits1_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.StopBits = StopBits.One;
                ddbStopBits.Text = EnumManager.StopBitsToString(CurrentManager.Port.StopBits);
            }
            CheckStopBits(ddbStopBits.Text);
            navigator1.Invalidate();
        }
        private void btnChannelStopBits15_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.StopBits = StopBits.OnePointFive;
                ddbStopBits.Text = EnumManager.StopBitsToString(CurrentManager.Port.StopBits);
            }
            CheckStopBits(ddbStopBits.Text);
            navigator1.Invalidate();
        }
        private void btnChannelStopBits2_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.Port.StopBits = StopBits.Two;
                ddbStopBits.Text = EnumManager.StopBitsToString(CurrentManager.Port.StopBits);
            }
            CheckStopBits(ddbStopBits.Text);
            navigator1.Invalidate();
        }
        private void CheckStopBits(string Type) {
            foreach (ToolStripMenuItem Item in ddbStopBits.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
            foreach (ToolStripMenuItem Item in btnChannelStopBits.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
        }

        #endregion
        private void Output_CommandEntered(object sender, CommandEnteredEventArgs e) {
            try {
                if (CurrentManager != null) {
                    CurrentManager.Post(e.Command, false);
                }
            }
            catch {

            }
        }
        #region Format Settings
        private void CheckInputFormat(string Type) {
            foreach (ToolStripMenuItem Item in ddbInputFormat.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
            foreach (ToolStripMenuItem Item in btnChannelInputFormat.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
        }
        private void CheckOutputFormat(string Type) {
            foreach (ToolStripMenuItem Item in ddbOutputFormat.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
            foreach (ToolStripMenuItem Item in btnChannelOutputFormat.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
        }
        private void InputFormatChange(string ControlText) {
            StreamInputFormat FormatPair = EnumManager.StringToInputFormat(ControlText);
            StringPair TextualPair = EnumManager.InputFormatToString(FormatPair, false);
            if (CurrentManager != null) {
                CurrentManager.InputFormat = FormatPair;
                ddbInputFormat.Text = TextualPair.A;
            }
            CheckInputFormat(ControlText);
        }
        private void OutputFormatChange(string ControlText) {
            StreamOutputFormat FormatPair = EnumManager.StringToOutputFormat(ControlText);
            StringPair TextualPair = EnumManager.OutputFormatToString(FormatPair, false);
            if (CurrentManager != null) {
                CurrentManager.OutputFormat = FormatPair;
                ddbOutputFormat.Text = TextualPair.A;
            }
            CheckOutputFormat(ControlText);
        }
        private void btnInFormText_Click(object sender, EventArgs e) {
            InputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnInFormStream_Click(object sender, EventArgs e) {
            InputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnInFormCCommand_Click(object sender, EventArgs e) {
            InputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnInFormModbusRTU_Click(object sender, EventArgs e) {
            InputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnselInputTextFrmt_Click(object sender, EventArgs e) {
            InputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnselInputBinary_Click(object sender, EventArgs e) {
            InputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnselInputCommand_Click(object sender, EventArgs e) {
            InputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnselInputModbus_Click(object sender, EventArgs e) {
            InputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnselOutputTextFrmt_Click(object sender, EventArgs e) {
            OutputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnselOutputCommandFrmt_Click(object sender, EventArgs e) {
            OutputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnselOutputModbusRTUFrmt_Click(object sender, EventArgs e) {
            OutputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnOutFormText_Click(object sender, EventArgs e) {
            OutputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnOutFormCCommand_Click(object sender, EventArgs e) {
            OutputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        private void btnOutFormModbusRTU_Click(object sender, EventArgs e) {
            OutputFormatChange(((ToolStripItem)sender).Tag.ToString() ?? "");
        }
        #endregion
        #region View Settings
        private void toolStripButton1_Click(object sender, EventArgs e) {
            Output.Clear();
        }
        private void btnMenuClearTerminal_Click(object sender, EventArgs e) {
            Output.Clear();
        }
        private void TopMostSetting() {
            btnTopMost.Checked = !btnTopMost.Checked;
            btnMenuTopMost.Checked = !btnMenuTopMost.Checked;
            this.TopMost = !this.TopMost;
        }
        private void toolStripButton1_Click_1(object sender, EventArgs e) {
            TopMostSetting();
        }
        private void btnMenuTopMost_Click(object sender, EventArgs e) {
            TopMostSetting();
        }

        private void btnZoom50_Click(object sender, EventArgs e) {
            Output.Zoom = 50;
        }
        private void btnZoom75_Click(object sender, EventArgs e) {
            Output.Zoom = 75;
        }
        private void btnZoom100_Click(object sender, EventArgs e) {
            Output.Zoom = 100;
        }
        private void btnZoom110_Click(object sender, EventArgs e) {
            Output.Zoom = 110;
        }
        private void btnZoom120_Click(object sender, EventArgs e) {
            Output.Zoom = 120;
        }
        private void btnOptViewDataOnly_Click(object sender, EventArgs e) {
            SetStampView(ConsoleInterface.TimeStampFormat.NoTimeStamps);
        }
        private void btnOptViewTime_Click(object sender, EventArgs e) {
            SetStampView(ConsoleInterface.TimeStampFormat.Time);
        }
        private void btnOptViewData_Click(object sender, EventArgs e) {
            SetStampView(ConsoleInterface.TimeStampFormat.Date);
        }
        private void btnOptViewDateTime_Click(object sender, EventArgs e) {
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

        private void btnMenuFullScreen_Click(object sender, EventArgs e) {
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
        private void renameChannelToolStripMenuItem1_Click(object sender, EventArgs e) {
            pnlRenamePanel.Visible = !pnlRenamePanel.Visible;
        }
        private void btnNewChannel_Click(object sender, EventArgs e) {
            AddManager("");
            navigator1.Invalidate();
        }
        private void btnRemoveChannel_Click(object sender, EventArgs e) {
            RemoveChannel(navigator1.SelectedItem);
            navigator1.Invalidate();
        }
        private void RemoveChannel(int ChannelIndex) {
            if (SystemManager.SerialManagers.Count > 1) {
                if ((ChannelIndex < SystemManager.SerialManagers.Count) && (ChannelIndex != -1)) {
                    SystemManager.SerialManagers[ChannelIndex].CommandProcessed -= SerManager_CommandProcessed;
                    SystemManager.SerialManagers[ChannelIndex].DataReceived -= SerMan_DataReceived;
                    SystemManager.SerialManagers.RemoveAt(ChannelIndex);
                }
            }
        }
        #endregion 
        #region Clipboard
        object? LastEntered = null;
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            CopyStepProgram();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
            if (Clipboard.ContainsData(Clipboard_ProgramDataType)) {
                PasteStepProgram();
            }
            else {
                Output.Paste();
            }
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e) {
            CopyStepProgram(true);
        }
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e) {
            CopyStepProgram(true);
        }
        private void copyToolStripMenuItem1_Click(object sender, EventArgs e) {
            CopyStepProgram(false);
        }
        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e) {
            PasteStepProgram(true);
        }
        #endregion
        #region Program UI
        private void LoadProgramOperations() {
            StepEnumerations.StepExecutable[] Steps = (StepEnumerations.StepExecutable[])StepEnumerations.StepExecutable.GetValues(typeof(StepEnumerations.StepExecutable));
            int Index = 0;
            int LastValue = 0;
            foreach (StepEnumerations.StepExecutable StepEx in Steps) {
                int Value = (int)StepEx & 0xFF0000;
                if (Index != 0) {
                    if (LastValue != Value) {
                        cmStepPrg.Items.Add(new ToolStripSeparator());
                    }
                }
                LoadProgramOperation(StepEx);
                Index++;
                LastValue = Value;
            }
        }
        private void LoadProgramOperation(StepEnumerations.StepExecutable StepEx) {
            ToolStripMenuItem StepOperationBtn = new ToolStripMenuItem();
            StepOperationBtn.Text = ProgramManager.StepExecutableToString(StepEx); //StepEx.ToString();
            StepOperationBtn.Tag = StepEx;
            StepOperationBtn.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            StepOperationBtn.ImageScaling = ToolStripItemImageScaling.None;
            StepOperationBtn.Click += StepOperationBtn_Click; ;
            cmStepPrg.Items.Add(StepOperationBtn);
        }
        #endregion
        #region Program Settings
        private void StepOperationBtn_Click(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (cmStepPrg.Tag == null) { return; }
            if (sender.GetType() == typeof(ToolStripMenuItem)) {

                try {
                    if (cmStepPrg.Tag.GetType() == typeof(DropDownClickedEventArgs)) {
                        ListItem? LstItem = ((DropDownClickedEventArgs)cmStepPrg.Tag).ParentItem;
                        if (LstItem == null) { return; }
                        int Column = ((DropDownClickedEventArgs)cmStepPrg.Tag).Column;
                        int Item = ((DropDownClickedEventArgs)cmStepPrg.Tag).Item;
                        StepEnumerations.StepExecutable StepExe = StepEnumerations.StepExecutable.NoOperation;
                        object? objExe = ((ToolStripMenuItem)sender).Tag;
                        if (objExe != null) {
                            if (objExe.GetType() == typeof(StepEnumerations.StepExecutable)) {
                                StepExe = (StepEnumerations.StepExecutable)objExe;
                            }
                        }
                        if (Column == 0) {
                            LstItem.Tag = StepExe;
                            LstItem.Text = ((ToolStripMenuItem)sender).Text;
                        }
                        else {
                            LstItem.SubItems[Column - 1].Tag = StepExe;
                            LstItem.SubItems[Column - 1].Text = ((ToolStripMenuItem)sender).Text;
                        }
                        SetDefault(LstItem, StepExe);
                        lstStepProgram.Invalidate();
                    }
                }
                catch { }
            }
        }
        private void SetDefault(ListItem Li, StepEnumerations.StepExecutable StepEx) {
            if (Li.SubItems.Count != 3) { return; }
            string DefaultText = "";
            if (StepEx == StepEnumerations.StepExecutable.Delay) {
                DefaultText = "1000";
            }
            else if (StepEx == StepEnumerations.StepExecutable.Open) {
                DefaultText = "COM1";
            }
            //else if (StepEx == StepEnumerations.StepExecutable.Close) {
            //    DefaultText = "COM1";
            //}
            Li.SubItems[2].Text = DefaultText;
        }
        private void lstStepProgram_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            if (e.Column == 2) {
                cmStepPrg.Tag = e;
                cmStepPrg.Show(e.ScreenLocation);
            }
            else if (e.Column == 3) {
                if (e.ParentItem == null) { return; }
                if (e.ParentItem.SubItems == null) { return; }
                object? objTag = e.ParentItem.SubItems[1].Tag;
                StepEnumerations.StepExecutable StepExe = StepEnumerations.StepExecutable.NoOperation;
                if (objTag != null) {
                    if (objTag.GetType() == typeof(StepEnumerations.StepExecutable)) {
                        StepExe = (StepEnumerations.StepExecutable)objTag;
                    }
                }
                if (ProgramManager.AcceptsArguments(StepExe) == false) { return; }
                if (StepExe == StepEnumerations.StepExecutable.SendText) {
                    OpenFileDialog OpenDia = new OpenFileDialog();
                    OpenDia.Filter = @"Plain Text Doccument (*.txt)|*.txt";
                    OpenDia.ShowDialog();
                    if (File.Exists(OpenDia.FileName)) {
                        e.ParentItem.SubItems[2].Text = OpenDia.FileName;
                        lstStepProgram.Invalidate();
                    }
                }
                else {
                    EditValue EdVal = new EditValue(StepExe, e.ParentItem.SubItems[2].Text, lstStepProgram, e.ParentItem);
                    EdVal.Sz = e.ItemSize;
                    EdVal.Location = e.ScreenLocation;
                    EdVal.Show();

                    //if (EdVal.DialogResult == DialogResult.OK) {
                    //e.ParentItem.SubItems[2].Text = EdVal.Output;
                    // lstStepProgram.Invalidate();
                    //}
                }

            }
        }
       
        #endregion
        #region Program Editing
        private void addCommandToolStripMenuItem_Click(object sender, EventArgs e) {
            Program_NewLine();
        }
        private void Program_NewLine() {
            ListItem LiPar = new ListItem();
            ListSubItem LiChk = new ListSubItem(true); LiPar.SubItems.Add(LiChk);
            ListSubItem LiCmd = new ListSubItem(); LiPar.SubItems.Add(LiCmd);
            ListSubItem LiArgs = new ListSubItem(); LiPar.SubItems.Add(LiArgs);
            LiCmd.Text = ProgramManager.StepExecutableToString(StepEnumerations.StepExecutable.NoOperation);
            LiCmd.Tag = StepEnumerations.StepExecutable.NoOperation;
            if (lstStepProgram.ExternalItems != null) {
                lstStepProgram.ExternalItems.Add(LiPar);
            }
            lstStepProgram.Invalidate();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            if (LastEntered != null) {
                if (LastEntered.GetType() == typeof(ODModules.ListControl)) {
                    Program_RemoveSelected();
                }
                else {
                    Output.ClearEntered();
                }
            }
            else {
                Output.ClearEntered();
            }
        }
        private void addCommandToolStripMenuItem1_Click(object sender, EventArgs e) {
            Program_NewLine();
        }
        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e) {
            Program_RemoveSelected();
        }
        private void btnPrgRemoveStepLines_Click(object sender, EventArgs e) {
            Program_RemoveSelected();
        }
        private void Program_RemoveSelected() {
            ProgramManager.ProgramState = StepEnumerations.StepState.Stopped;
            lstStepProgram.LineRemoveSelected();
        }
        private void btnPrgMoveUp_Click(object sender, EventArgs e) {
            lstStepProgram.LineMove(false);
        }
        private void btnPrgMoveDown_Click(object sender, EventArgs e) {
            lstStepProgram.LineMove(true);
        }
        private void enableSelectedToolStripMenuItem_Click(object sender, EventArgs e) {
            ChangeEnable(EnableChanged.EnableSelected);
        }
        private void toggleEnableToolStripMenuItem_Click(object sender, EventArgs e) {
            ChangeEnable(EnableChanged.ToggleSelected);
        }
        private void disableSelectedToolStripMenuItem_Click(object sender, EventArgs e) {
            ChangeEnable(EnableChanged.DisableSelected);
        }
        private void enableSelectedToolStripMenuItem1_Click(object sender, EventArgs e) {
            ChangeEnable(EnableChanged.EnableSelected);
        }
        private void disableSelectedToolStripMenuItem1_Click(object sender, EventArgs e) {
            ChangeEnable(EnableChanged.DisableSelected);
        }
        private void ChangeEnable(EnableChanged TypeOfChange) {
            if (lstStepProgram.ExternalItems == null) { return; }
            foreach (ListItem Li in lstStepProgram.ExternalItems) {
                if (Li.SubItems.Count == 3) {
                    if (Li.Selected == true) {
                        switch (TypeOfChange) {
                            case EnableChanged.EnableSelected:
                                Li.SubItems[0].Checked = true;
                                break;
                            case EnableChanged.DisableSelected:
                                Li.SubItems[0].Checked = false;
                                break;

                            case EnableChanged.ToggleSelected:
                                Li.SubItems[0].Checked = !Li.SubItems[0].Checked;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            lstStepProgram.Invalidate();
        }
        const string Clipboard_ProgramDataType = "SERMAN:PRG_EVEDAT";
        public void CopyStepProgram(bool DeleteCopy = false, bool ClearSelection = true) {
            if (lstStepProgram.ExternalItems == null) { return; }
            List<ProgramDataObject> list = new List<ProgramDataObject>();
            for (int i = lstStepProgram.ExternalItems.Count - 1; i >= 0; i--) {
                if (lstStepProgram.ExternalItems[i].Selected == true) {
                    if (lstStepProgram.ExternalItems[i].SubItems.Count == 3) {
                        ProgramDataObject ProgramItem = new ProgramDataObject();
                        ProgramItem.Enabled = lstStepProgram.ExternalItems[i].SubItems[0].Checked;
                        object? objCmd = lstStepProgram.ExternalItems[i].SubItems[1].Tag;
                        if (objCmd != null) {
                            if (objCmd.GetType() == typeof(StepEnumerations.StepExecutable)) {
                                ProgramItem.Command = (StepEnumerations.StepExecutable)objCmd;
                            }
                            else { ProgramItem.Command = StepEnumerations.StepExecutable.NoOperation; }
                        }
                        else { ProgramItem.Command = StepEnumerations.StepExecutable.NoOperation; }


                        ProgramItem.Arguments = lstStepProgram.ExternalItems[i].SubItems[2].Text;
                        list.Add(ProgramItem);
                        if (DeleteCopy == true) {
                            lstStepProgram.LineRemove(i, false);
                        }
                        else {
                            if (ClearSelection == true) {
                                lstStepProgram.ExternalItems[i].Selected = false;
                            }
                        }
                    }
                }
            }
            lstStepProgram.Invalidate();
            if (list.Count > 0) {
                Clipboard.SetData(Clipboard_ProgramDataType, list);
            }
            //Clipboard.SetDataObject(null);
        }
        public void PasteStepProgram(bool ClearSelection = true) {
            object? Data = Clipboard.GetDataObject();
            if (!Clipboard.ContainsData(Clipboard_ProgramDataType)) { return; }
            try {
                if (lstStepProgram.ExternalItems == null) { return; }
                List<ProgramDataObject>? CopiedItems = (List<ProgramDataObject>)Clipboard.GetData(Clipboard_ProgramDataType);
                if (CopiedItems == null) { return; }
                if (CopiedItems.Count > 0) {
                    if (lstStepProgram.SelectionCount > 0) {
                        int CountBuffer = lstStepProgram.ExternalItems.Count - 1;
                        for (int i = CountBuffer; i >= 0; i--) {
                            if (lstStepProgram.ExternalItems[i].Selected == true) {
                                InsertAtPoint(CopiedItems, i, false);
                            }
                        }
                    }
                    else {
                        InsertAtPoint(CopiedItems, -1, true);
                    }
                }
                lstStepProgram.Invalidate();
            }
            catch { }
            //}
        }
        private void InsertAtPoint(List<ProgramDataObject>? CopiedItems, int Index, bool ReverseInsert) {
            if (CopiedItems == null) { return; }
            if (CopiedItems.Count == 0) { return; }
            if (ReverseInsert == true) {
                for (int j = CopiedItems.Count - 1; j >= 0; j--) {
                    ListItem itPar = new ListItem();
                    ListSubItem itEnb = new ListSubItem(CopiedItems[j].Enabled);
                    StepEnumerations.StepExecutable StCmd = CopiedItems[j].Command;
                    ListSubItem itCmd = new ListSubItem(ProgramManager.StepExecutableToString(StCmd));
                    itCmd.Tag = StCmd;
                    ListSubItem itArg = new ListSubItem(CopiedItems[j].Arguments);
                    itPar.SubItems.Add(itEnb);
                    itPar.SubItems.Add(itCmd);
                    itPar.SubItems.Add(itArg);
                    lstStepProgram.LineInsert(Index, itPar, false);
                }
            }
            else {
                for (int j = 0; j < CopiedItems.Count; j++) {
                    ListItem itPar = new ListItem();
                    ListSubItem itEnb = new ListSubItem(CopiedItems[j].Enabled);
                    StepEnumerations.StepExecutable StCmd = CopiedItems[j].Command;
                    ListSubItem itCmd = new ListSubItem(ProgramManager.StepExecutableToString(StCmd));
                    itCmd.Tag = StCmd;
                    ListSubItem itArg = new ListSubItem(CopiedItems[j].Arguments);
                    itPar.SubItems.Add(itEnb);
                    itPar.SubItems.Add(itCmd);
                    itPar.SubItems.Add(itArg);
                    lstStepProgram.LineInsert(Index, itPar, false);
                }
            }

        }
        private enum EnableChanged {
            EnableSelected = 0x01,
            DisableSelected = 0x00,
            ToggleSelected = 0x02
        }
        #endregion 
        #region Program Control
        StepEnumerations.StepState LastProgramState = StepEnumerations.StepState.Stopped;
        DateTime LastUpdate = DateTime.Now;
        private void tmrProg_Tick(object sender, EventArgs e) {
            if (ProgramManager.LastProgramStep != ProgramManager.ProgramStep) {
                if (ProgramManager.CurrentProgram == lstStepProgram.Tag) {
                    lstStepProgram.LineMarkerIndex = ProgramManager.ProgramStep;
                }
                if (ProgramManager.CurrentProgram != null) {
                    ProgramManager.CurrentProgram.ProgramMarker = ProgramManager.ProgramStep;
                }
                ProgramManager.LastProgramStep = ProgramManager.ProgramStep;
            }
            //if (LastProgramState != ProgramManager.ProgramState) {
            if(ConversionHandler.DateIntervalDifference(LastUpdate, DateTime.Now, ConversionHandler.Interval.Millisecond) > 10) { 
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
                LastUpdate = DateTime.Now;
               // LastProgramState = ProgramManager.ProgramState;
            }
            if (currentManager != null) {
                string RxCount = currentManager.BytesReceived.ToString();
                string TxCount = currentManager.BytesSent.ToString();
                if (lblRxBytes.Text != RxCount) { lblRxBytes.Text = RxCount; }
                if (lblTxBytes.Text != TxCount) { lblTxBytes.Text = TxCount; }
            }
        }
        private void Run() {
            if (ProgramManager.CurrentProgram == null) { return; }
            if (ProgramManager.CurrentProgram == lstStepProgram.Tag) {
                if (ProgramManager.CurrentProgram.ProgramMarker >= ProgramManager.CurrentProgram.Program.Count) {
                    ProgramManager.RunFromStart();
                }
            }
            else {
                ProgramManager.SetupProgram();
                ProgramManager.ProgramStep = ProgramManager.CurrentProgram.ProgramMarker;
                ProgramManager.ProgramState = StepEnumerations.StepState.Running;
            }
        }
        private void ProgramManager_ProgramNameChanged(object sender) {
            DetermineName();
        }
        private void DetermineName() {
            int j = 0;
            string Name = "";
            string StoredName = "";
            bool Resulted = false;
            int Index = -1;
            foreach (ProgramObject Prg in ProgramManager.Programs) {
                Index++;
                if (Prg.Name.Trim().Length == 0) {
                    if (j > 0) {
                        Name = "Untitled Program " + j.ToString();
                    }
                    else {
                        Name = "Untitled Program";
                    }
                    j++;
                }
                else {
                    Name = Prg.Name;
                }
                if (thPrograms.Tabs.Count > 0) {
                    if ((Index >= 0) && (Index < thPrograms.Tabs.Count)) {
                        thPrograms.Tabs[Index].Text = Name;
                    }
                }
                if (Prg == ProgramManager.CurrentProgram) {
                    StoredName = Name;
                    Resulted = true;
                    // break;
                }

            }
            if (Resulted == true) {
                btnRun.Text = StoredName;
            }
            thPrograms.Invalidate();
        }
        private void DetermineTabs() {
            int j = 0;
            string Name = "";
            foreach (ProgramObject Prg in ProgramManager.Programs) {
                if (Prg.Name.Trim().Length == 0) {
                    if (j > 0) {
                        Name = "Untitled Program " + j.ToString();
                    }
                    else {
                        Name = "Untitled Program";
                    }
                    j++;
                }
                else {
                    Name = Prg.Name;
                }
                Tab Tb = new Tab();
                Tb.Text = Name;
                Tb.Tag = Prg;
                thPrograms.Tabs.Add(Tb);
            }
            thPrograms.Invalidate();
        }
        private void ListPrograms(object MenuList) {
            if (MenuList.GetType() == typeof(ToolStripSplitButton)) {
                ToolStripSplitButton menu = (ToolStripSplitButton)MenuList;
                for (int i = menu.DropDownItems.Count - 1; i >= 0; i--) {
                    if (menu.DropDownItems[i].Tag != null) {
                        menu.Click -= TsMi_Click;
                        menu.DropDownItems.RemoveAt(i);
                    }
                }
            }
            else if (MenuList.GetType() == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem menu = (ToolStripMenuItem)MenuList;
                for (int i = menu.DropDownItems.Count - 1; i >= 0; i--) {
                    if (menu.DropDownItems[i].Tag != null) {
                        menu.Click -= TsMi_Click;
                        menu.DropDownItems.RemoveAt(i);
                    }
                }
            }

            int j = 0;
            foreach (ProgramObject Prg in ProgramManager.Programs) {
                ToolStripMenuItem TsMi = new ToolStripMenuItem();
                if (Prg.Name.Trim().Length == 0) {
                    if (j > 0) {
                        TsMi.Text = "Untitled Program " + j.ToString();
                    }
                    else {
                        TsMi.Text = "Untitled Program";
                    }
                    j++;
                }
                else {
                    TsMi.Text = Prg.Name;
                }
                TsMi.ImageScaling = ToolStripItemImageScaling.None;
                TsMi.Tag = Prg;
                if (ProgramManager.CurrentProgram == Prg) {
                    TsMi.Checked = true;
                }
                TsMi.Click += TsMi_Click;
                if (MenuList.GetType() == typeof(ToolStripSplitButton)) {
                    ToolStripSplitButton menu = (ToolStripSplitButton)MenuList;
                    menu.DropDownItems.Add(TsMi);
                }
                else if (MenuList.GetType() == typeof(ToolStripMenuItem)) {
                    ToolStripMenuItem menu = (ToolStripMenuItem)MenuList;
                    menu.DropDownItems.Add(TsMi);
                }
            }
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

        private void btnRun_Click(object sender, EventArgs e) {

        }
        private void btnRun_ButtonClick(object sender, EventArgs e) {
            ProgramManager.RunFromStart();
        }
        private void runFromStartToolStripMenuItem_Click(object sender, EventArgs e) {
            ProgramManager.RunFromStart();
        }
        private void btnPause_Click(object sender, EventArgs e) {
            ProgramManager.ProgramState = StepEnumerations.StepState.Paused;
        }
        private void btnStop_Click(object sender, EventArgs e) {
            ProgramManager.ProgramState = StepEnumerations.StepState.Stopped;
            ProgramManager.ProgramStep = 0;
        }
        private void btnRunPrg_Click(object sender, EventArgs e) {
            ProgramManager.RunFromStart();
        }
        private void btnPausePrg_Click(object sender, EventArgs e) {
            ProgramManager.ProgramState = StepEnumerations.StepState.Paused;
        }
        private void btnStopPrg_Click(object sender, EventArgs e) {
            ProgramManager.ProgramState = StepEnumerations.StepState.Stopped;
            ProgramManager.ProgramStep = 0;
        }
        private void runToolStripMenuItem_Click(object sender, EventArgs e) {
            ProgramManager.RunFromStart();
        }
        private void runProgramToolStripMenuItem_Click(object sender, EventArgs e) {
            Run();
        }
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e) {
            ProgramManager.ProgramState = StepEnumerations.StepState.Paused;
        }
        private void stopToolStripMenuItem_Click(object sender, EventArgs e) {
            ProgramManager.ProgramState = StepEnumerations.StepState.Stopped;
            ProgramManager.ProgramStep = 0;
        }
        private void btnRunCursor_Click(object sender, EventArgs e) {
            Run();
        }
        #endregion
        #region Program
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

            }
        }
       
        private void SetPort(SerialManager? SerMan, string Arguments) {
            try {
                SystemManager.SerialManagers[ProgramManager.Program_CurrentManager].Port.PortName = Arguments;
            }
            catch {
                Print(ErrorType.M_Error, "COM_PSET", "'" + Arguments + "' is already in use or is an unrecognized port name");
            }
        }
        #endregion
        #region MultiProgram Editing
        private void commandPalletToolStripMenuItem_Click(object sender, EventArgs e) {
            CommandPalette CmdPalette = new CommandPalette();
            Classes.ApplicationManager.OpenInternalApplicationOnce(CmdPalette, true);
        }
        private void thPrograms_TabRightClicked(object sender, TabClickedEventArgs Tab) {
            if (sender == null) { return; }
            if (sender.GetType() != typeof(ODModules.TabHeader)) { return; }
            cmPrograms.Tag = Tab;
            cmPrograms.Show(Tab.ScreenLocation);
        }
        private void cmRunProgram_Click(object sender, EventArgs e) {
            ProgramObject? PrgObj = GetProgramObjectFromTab();
            if (PrgObj == null) { return; }
            ProgramManager.CurrentProgram = PrgObj;
            btnRun.Text = GetTextFromTab();
            ProgramManager.RunFromStart();
        }
        private void cmCloseProgram_Click(object sender, EventArgs e) {
            if (cmPrograms.Tag == null) { return; }
            if (cmPrograms.Tag.GetType() == typeof(TabClickedEventArgs)) {
                RemoveProgram(((TabClickedEventArgs)cmPrograms.Tag).Index);
            }
        }
        private void cmbtnSetAsActive_Click(object sender, EventArgs e) {

            ProgramObject? PrgObj = GetProgramObjectFromTab();
            if (PrgObj == null) { return; }
            ProgramManager.CurrentProgram = PrgObj;
            btnRun.Text = GetTextFromTab();
        }
        private void cmbtnProperties_Click(object sender, EventArgs e) {
            ProgramObject? PrgObj = GetProgramObjectFromTab();
            if (PrgObj == null) { return; }
            ProgramProperties PrgProp = new ProgramProperties();
            PrgProp.SelectedProgram = PrgObj;
            PrgProp.StartPosition = FormStartPosition.CenterParent;
            PrgProp.Owner = this;
            ApplicationManager.OpenInternalApplicationOnce(PrgProp, true);
        }
        private void tabHeader1_AddButtonClicked(object sender) {
            NewProgram();
        }
        private void tabHeader1_CloseButtonClicked(object sender, int Index) {
            RemoveProgram(Index);
        }
        private void removeProgramToolStripMenuItem_Click(object sender, EventArgs e) {
            RemoveProgram(thPrograms.SelectedIndex);
        }
        private void newProgramToolStripMenuItem_Click(object sender, EventArgs e) {
            NewProgram();
        }
        private void cmbtnNewProgram_Click(object sender, EventArgs e) {
            NewProgram();
        }
        private Rectangle GetRectangleFromTab(bool IncludeTextOffset = false) {
            if (cmPrograms.Tag == null) { return Rectangle.Empty; }
            if (cmPrograms.Tag.GetType() == typeof(TabClickedEventArgs)) {
                TabClickedEventArgs Args = (TabClickedEventArgs)cmPrograms.Tag;
                if(IncludeTextOffset == false) {
                    return Args.TextArea;
                }
                else {
                    return new Rectangle(Args.TextArea.X + Args.TextOffset, Args.TextArea.Y, Args.TextArea.Width - Args.TextOffset, Args.TextArea.Height); ;
                }
               
            }
            return Rectangle.Empty;
        }
        private ProgramObject? GetProgramObjectFromTab() {
            if (cmPrograms.Tag == null) { return null; }
            if (cmPrograms.Tag.GetType() == typeof(TabClickedEventArgs)) {
                TabClickedEventArgs Args = (TabClickedEventArgs)cmPrograms.Tag;
                if (Args.SelectedTab.GetType() == typeof(Tab)) {
                    Tab TabData = (Tab)Args.SelectedTab;
                    if (TabData.Tag == null) { return null; }
                    if (TabData.Tag.GetType() == typeof(ProgramObject)) {
                        return (ProgramObject)TabData.Tag;
                    }
                }
            }
            return null;
        }
        private string GetTextFromTab() {
            if (cmPrograms.Tag == null) { return ""; }
            if (cmPrograms.Tag.GetType() == typeof(TabClickedEventArgs)) {
                TabClickedEventArgs Args = (TabClickedEventArgs)cmPrograms.Tag;
                if (Args.SelectedTab.GetType() == typeof(Tab)) {
                    Tab TabData = (Tab)Args.SelectedTab;
                    return TabData.Text;
                }
            }
            return "";
        }
        bool InRenameMode = false;
        private void renameToolStripMenuItem_Click(object sender, EventArgs e) {
            Rectangle TabRectangle = GetRectangleFromTab(true);
            ProgramObject? PrgObj = GetProgramObjectFromTab();
            if (PrgObj == null) { return; }
            string CurrentText = GetTextFromTab();
            TextBox RenameBox = new TextBox();
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
            RenameBox.Tag = cmPrograms.Tag;
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
            if (sender.GetType() == typeof(TextBox)) {
                DeregisterTextbox((TextBox)sender);
                thPrograms.Controls.Remove((TextBox)sender);
            }
        }
        private void RenameBox_KeyDown(object? sender, KeyEventArgs e) {
           
            if (e.KeyCode == Keys.Enter) {
                if (sender == null) { return; }
                if (sender.GetType() == typeof(TextBox)) {
                    DeregisterTextbox((TextBox)sender);
                    thPrograms.Controls.Remove((TextBox)sender);
                }
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
        }
        private void RenameBox_TextChanged(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(TextBox)) {
               TextBox TxBx = (TextBox)sender;
                if(TxBx.Tag == null) {

                    DeregisterTextbox(TxBx);
                    thPrograms.Controls.Remove(TxBx);
                }
                else {
                    if (TxBx.Tag.GetType() == typeof(TabClickedEventArgs)) {
                        TabClickedEventArgs TCEA = (TabClickedEventArgs)TxBx.Tag;
                        ProgramManager.Programs[TCEA.Index].Name = TxBx.Text;
                        thPrograms.Tabs[TCEA.Index].Text = TxBx.Text;
                    }
                }
            }
        }
        private void RenameBox_LostFocus(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(TextBox)) {
                DeregisterTextbox((TextBox)sender);
                thPrograms.Controls.Remove((TextBox)sender);
            }
        }
        private void DeregisterTextbox(TextBox Tb) {
            Tb.Tag = null;
            Tb.Leave -= RenameBox_Leave;
            Tb.LostFocus -= RenameBox_LostFocus;
            Tb.TextChanged -= RenameBox_TextChanged;
            Tb.KeyDown -= RenameBox_KeyDown;
            InRenameMode = false;
        }
        #endregion
        private void btnMonitor_Click(object sender, EventArgs e) {
            Monitor NewMonitor = new Monitor();
            NewMonitor.Attached = this;
            Classes.ApplicationManager.OpenInternalApplicationOnce(NewMonitor);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e) {
            if (InRenameMode == false) {
                if (pnlRenamePanel.Visible == false) {
                    Output.Focus();
                }
            }
        }
        private void navigator1_SelectedIndexChanged(object sender, int SelectedIndex) {
            if (SystemManager.SerialManagers.Count > 0) {
                if ((SelectedIndex >= 0) && (SelectedIndex < SystemManager.SerialManagers.Count)) {
                    CurrentManager = SystemManager.SerialManagers[SelectedIndex];
                }
            }
        }

        private void renameChannelToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void pnlRenamePanel_Paint(object sender, PaintEventArgs e) {

        }

        private void button1_ButtonClicked(object sender) {
            if (CurrentManager != null) {
                CurrentManager.Name = textBox1.Text;
            }
            pnlRenamePanel.Hide();
            navigator1.Invalidate();
        }
        private void btnOptViewSource_Click(object sender, EventArgs e) {
            Output.ShowOrigin = btnOptViewSource.Checked;
        }
        #region Document Handling
        private void CloseAll() {
            foreach (SerialManager SerMan in SystemManager.SerialManagers) {
                if (SerMan.Port.IsOpen == true) {
                    SerMan.Port.Close();
                }
            }
        }
        string CurrentDocument = "";
        private void btnSaveStep_Click(object sender, EventArgs e) {
            Save();
        }
        private void btnSaveAsStep_Click(object sender, EventArgs e) {
            Save(true);
        }
        private void btnOpenStep_Click(object sender, EventArgs e) {
            OpenFileDialog OpenDia = new OpenFileDialog();
            OpenDia.Filter = @"Serial Monitor Program (*.smp)|*.smp";
            if (OpenDia.ShowDialog() == DialogResult.OK) {
                if (File.Exists(OpenDia.FileName)) {
                    CloseAll();
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

            if (SaveAs == true) { IsExistingFile = false; }

            if (IsExistingFile == false) {
                SaveFileDialog Save = new SaveFileDialog();
                Save.Filter = @"Serial Monitor Program (*.smp)|*.smp";
                Save.ShowDialog();
                if (Save.FileName != "") {
                    this.Text = Path.GetFileNameWithoutExtension(Save.FileName) + " - Serial Monitor";
                    ProjectManager.WriteFile(Save.FileName);
                    CurrentDocument = Save.FileName;
                }
            }
            else {
                ProjectManager.WriteFile(CurrentDocument);
            }
            AddFiletoRecentFiles(CurrentDocument);
        }
        private void ClearPrograms() {
            thPrograms.ClearTabs();
            for (int i = ProgramManager.Programs.Count - 1; i >= 0; i--) {
                ProgramManager.Programs[i].Clear();
                ProgramManager.Programs.RemoveAt(i);
            }
        }
        public void Open(string FileAddress) {
            DocumentHandler.Open(FileAddress);
            ClearManagers();
            ClearPrograms();
            ProjectManager.ClearKeypad();
            lstStepProgram.LineRemoveAll();
            GC.Collect();
            ProgramManager.Programs.Add(new ProgramObject());
            ProjectManager.ReadFile(FileAddress, SerManager_CommandProcessed, SerMan_DataReceived);
            if (SystemManager.SerialManagers.Count > 0) {
                navigator1.SelectedItem = 0;
                CurrentManager = SystemManager.SerialManagers[0];
            }
            lstStepProgram.ExternalItems = ProgramManager.Programs[0].Program;
            lstStepProgram.Tag = ProgramManager.Programs[0];
            ProgramManager.CurrentProgram = ProgramManager.Programs[0];
            lstStepProgram.Invalidate();
            CurrentDocument = FileAddress;
            DetermineName();
            DetermineTabs();
            this.Text = Path.GetFileNameWithoutExtension(CurrentDocument) + " - Serial Monitor";
        }
        private void NewProgram(string Name = "") {
            ProgramObject PrgObj = new ProgramObject(Name);
            ProgramManager.Programs.Add(PrgObj);
            Tab Tb = new Tab();
            Tb.Text = Name;
            Tb.Tag = PrgObj;
            thPrograms.Tabs.Add(Tb);
            UpdateProgramNames();
            thPrograms.Invalidate();
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
                    ProgramManager.Programs.RemoveAt(Index);
                    thPrograms.Tabs.RemoveAt(Index);
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
        }
        private void UpdateProgramNames() {
            int j = 0;
            int Index = -1;
            foreach (ProgramObject Prg in ProgramManager.Programs) {
                string PrgName = "";
                Index++;
                if (Prg.Name.Trim().Length == 0) {
                    if (j > 0) {
                        PrgName = "Untitled Program " + j.ToString();
                    }
                    else {
                        PrgName = "Untitled Program";
                    }
                    j++;
                }
                else {
                    PrgName = Prg.Name;
                }
                if (thPrograms.Tabs.Count > 0) {
                    if ((Index >= 0) && (Index < thPrograms.Tabs.Count)) {
                        thPrograms.Tabs[Index].Text = PrgName;
                        thPrograms.Tabs[Index].Tag = Prg;
                    }
                }
            }
        }


        #endregion

        private void editToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void Output_Enter(object sender, EventArgs e) {

        }

        private void Output_Validated(object sender, EventArgs e) {

        }
        private void Output_Click(object sender, EventArgs e) {
            LastEntered = sender;
            Output.Focus();
        }
        private void Output_MouseClick(object sender, MouseEventArgs e) {

        }
        private void lstStepProgram_MouseClick(object sender, MouseEventArgs e) {
            LastEntered = sender;
        }
        private void navigator1_MouseClick(object sender, MouseEventArgs e) {
            LastEntered = sender;
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) {
            lstStepProgram.LineSelectAll();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e) {

        }
        private void btnMenuExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void setStepCursorToolStripMenuItem_Click(object sender, EventArgs e) {
            SetCursor();
        }
        private void SetCursor() {
            if (lstStepProgram.SelectionCount == 1) {
                if (ProgramManager.CurrentProgram != null) {
                    if (ProgramManager.CurrentProgram == lstStepProgram.Tag) {
                        ProgramManager.CurrentProgram.ProgramMarker = lstStepProgram.SelectedIndex;
                    }
                }
                //if (CurrentProgram == lstStepProgram.Tag) {
                lstStepProgram.LineMarkerIndex = lstStepProgram.SelectedIndex;
                if (lstStepProgram.Tag != null) {
                    if (lstStepProgram.Tag.GetType() == typeof(ProgramObject)) {
                        ((ProgramObject)lstStepProgram.Tag).ProgramMarker = lstStepProgram.SelectedIndex;
                    }
                }
                //}
            }
        }
        private void lstStepProgram_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                SetCursor();
            }
            e.Handled = true;
        }
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
                        ToolStripMenuItem btnRecentItem = new ToolStripMenuItem();
                        btnRecentItem.Text = j.ToString() + "  " + Path.GetFileNameWithoutExtension(FileName);
                        btnRecentItem.Tag = FileName;
                        btnRecentItem.Click += BtnRecentItem_Click;
                        btnRecentProjects.DropDownItems.Add(btnRecentItem);
                        j++;
                    }
                }
            }
        }
        private void btnRecentProjects_DropDownOpening(object sender, EventArgs e) {
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
                CloseAll();
                Open(FileName);
                AddFiletoRecentFiles(FileName);
            }
        }

        private void channelsToolStripMenuItem_Click(object sender, EventArgs e) {
            navigator1.Visible = channelsToolStripMenuItem.Checked;
        }
        private void btnMenuShowStepPrg_Click(object sender, EventArgs e) {
            pnlStepProgram.Visible = btnMenuShowStepPrg.Checked;
        }
        private void pnlStepProgram_CloseButtonClicked(object sender, Point HitPoint) {
            btnMenuShowStepPrg.Checked = false;
            pnlStepProgram.Visible = false;
        }

        private void Form1_Deactivate(object sender, EventArgs e) {
            Color FadeInColor = Color.FromArgb(100, DesignerSetup.GetAccentColor());
            msMain.BackColorNorthFadeIn = FadeInColor;
            msMain.UseNorthFadeIn = false;
        }
        private void Form1_Activated(object sender, EventArgs e) {
            Color FadeInColor = Color.FromArgb(100, DesignerSetup.GetAccentColor());
            msMain.BackColorNorthFadeIn = FadeInColor;
            msMain.UseNorthFadeIn = true;
        }

        private void lstStepProgram_Load(object sender, EventArgs e) {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.IsMaster = btnMenuModbusMaster.Checked;
            }
        }

        private void modbusRegistersToolStripMenuItem_Click(object sender, EventArgs e) {
            ModbusRegisters MbRegs = new ModbusRegisters();
            ApplicationManager.OpenInternalApplicationOnce(MbRegs);
        }

        private void btnNewStep_Click(object sender, EventArgs e) {

        }

        private void btnRun_DropDownOpening(object sender, EventArgs e) {
            ListPrograms(sender);
        }

        private void activeProgramToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            ListPrograms(sender);
        }
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstStepProgram.Tag == null) { return; }
            if (lstStepProgram.Tag.GetType() == typeof(ProgramObject)) {
                ProgramProperties PrgProp = new ProgramProperties();
                PrgProp.SelectedProgram = (ProgramObject)lstStepProgram.Tag;
                PrgProp.StartPosition = FormStartPosition.CenterParent;
                PrgProp.Owner = this;
                ApplicationManager.OpenInternalApplicationOnce(PrgProp, true);
            }

        }
        private void tabHeader1_SelectedIndexChanged(object sender, int CurrentIndex, int PreviousIndex) {
            if (thPrograms.Tabs.Count > 0) {
                if (CurrentIndex < thPrograms.Tabs.Count) {
                    object? TagData = thPrograms.Tabs[CurrentIndex].Tag;
                    if (TagData != null) {
                        if (TagData.GetType() == typeof(ProgramObject)) {
                            lstStepProgram.Tag = TagData;
                            ProgramManager.CurrentEditingProgram = (ProgramObject)TagData;
                            lstStepProgram.ExternalItems = ((ProgramObject)TagData).Program;
                            lstStepProgram.LineMarkerIndex = ((ProgramObject)TagData).ProgramMarker;
                        }
                    }
                }
            }
        }

        private void toolStripSeparator27_Click(object sender, EventArgs e) {

        }

        private void tabHeader1_Load(object sender, EventArgs e) {

        }

        private void activeProgramToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings ConfigApp = new Settings();
            ApplicationManager.OpenInternalApplicationOnce(ConfigApp, true);
        }

        private void keyPadToolStripMenuItem_Click(object sender, EventArgs e) {
            Keypad KeypadApp = new Keypad();
            ApplicationManager.OpenInternalApplicationOnce(KeypadApp, true);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            About AboutWin = new About();
            ApplicationManager.OpenInternalApplicationOnce(AboutWin, true);
        }

        private void ddbPorts_Click(object sender, EventArgs e) {

        }

        private void textComparatorToolStripMenuItem_Click(object sender, EventArgs e) {
            WindowForms.TextComparator TxtCompare = new WindowForms.TextComparator();
            ApplicationManager.OpenInternalApplicationOnce(TxtCompare, true);
        }
        private void ProgramManager_ProgramListingChanged() {
            lstStepProgram.Invalidate();
        }

      
    }
    public enum StreamInputFormat {
        Text = 0x01,
        BinaryStream = 0x02,
        CCommand = 0x04,
        ModbusRTU = 0x05
    }
    public enum StreamOutputFormat {
        Text = 0x01,
        CCommand = 0x02,
        ModbusRTU = 0x05
    }

    public class FullScreenStyle {
        public bool IsFullScreen = false;
        public FormWindowState WindowState = FormWindowState.Normal;
        public FormBorderStyle BorderStyle = FormBorderStyle.Sizable;
        public Point WindowPosition;
        public Size WindowSize;
    }
}