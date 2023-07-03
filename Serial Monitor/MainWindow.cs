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
using Microsoft.VisualBasic;
using ODModules;
using Serial_Monitor.Classes;
using Svg;
using static System.Windows.Forms.LinkLabel;

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
                    StringPair SelectIn = EnumManager.InputFormatToString(value.InputFormat);
                    StringPair SelectOut = EnumManager.OutputFormatToString(value.OutputFormat);
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
        List<ProgramObject> Programs = new List<ProgramObject>(1);
        ProgramObject? CurrentProgram = null;
        public MainWindow() {
            InitializeComponent();
            Programs.Add(new ProgramObject());
            lstStepProgram.ExternalItems = Programs[0].Program;
            lstStepProgram.Tag = Programs[0];
            CurrentProgram = Programs[0];

            ProgramManager.ProgramNameChanged += ProgramManager_ProgramNameChanged;


            AddManager("");
            currentManager = SystemManager.SerialManagers[0];
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            ThreadStepExecutable = new Thread(StepProgram);
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
        }
        public void ApplyTheme() {

            RecolorAll();
            AddIcons();
        }
        private void RecolorAll() {
            ApplicationManager.IsDark = Properties.Settings.Default.THM_SET_IsDark;
            this.SuspendLayout();

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


            msMain.MenuBorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            tsMain.MenuBorderColor = Properties.Settings.Default.THM_COL_BorderColor;

            msMain.MenuSeparatorColor = Properties.Settings.Default.THM_COL_SeperatorColor;
            tsMain.MenuSeparatorColor = Properties.Settings.Default.THM_COL_SeperatorColor;

            msMain.MenuSymbolColor = Properties.Settings.Default.THM_COL_SymbolColor;
            tsMain.MenuSymbolColor = Properties.Settings.Default.THM_COL_SymbolColor;

            tsMain.ItemCheckedBackColorNorth = Properties.Settings.Default.THM_COL_SymbolColor;
            tsMain.ItemCheckedBackColorNorth = Properties.Settings.Default.THM_COL_SymbolColor;

            tsMain.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            msMain.ItemForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            tsMain.ItemForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            msMain.ItemSelectedForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            tsMain.ItemSelectedForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            pnlStepProgram.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            tabHeader1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            lstStepProgram.ColumnForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            Output.ForeColor = Properties.Settings.Default.THM_COL_TerminalForeColor;

            Output.BackColor = Properties.Settings.Default.THM_COL_Editor;
            lstStepProgram.BackColor = Properties.Settings.Default.THM_COL_Editor;

            navigator1.BackColor = Properties.Settings.Default.THM_COL_SeconaryBackColor;
            navigator1.MidColor = Properties.Settings.Default.THM_COL_Editor;
            navigator1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            lstStepProgram.RowColor = Properties.Settings.Default.THM_COL_RowColor;
            lstStepProgram.GridlineColor = Properties.Settings.Default.THM_COL_GridLineColor;

            pnlStepProgram.LabelBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            pnlStepProgram.BackColor = Properties.Settings.Default.THM_COL_Editor;
            tabHeader1.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
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
            lblRxBytes.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            lblTxBytes.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            this.ResumeLayout();
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
            //navigator1.Width = DesignerSetup.ScaleInteger(navigator1.Width);
        }
        private void AddIcons() {
            DesignerSetup.SetImageSizes(RenderHandler.DPI());
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Memory, ddbPorts, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Connect_16x, btnConnect, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Disconnect_16x, btnDisconnect, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Input, ddbInputFormat, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Output1, ddbOutputFormat, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.RunStart_16x, runFromStartToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.RunStart_16x, btnRun, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, btnRunCursor, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Pause_16x, btnPause, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, btnStop, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Cut, cutToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Copy, copyToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Paste, pasteToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.de, deleteToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, runProgramToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.RunStart_16x, btnRunPrg, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Pause_16x, btnPausePrg, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, btnStopPrg, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.ClearWindowContent, btnClearTerminal, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.BringForward, btnTopMost, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Counter_16x, btnMonitor, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.NewDeploymentPackage_16x, btnNewStep, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.OpenFile_16x, btnOpenStep, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Save_16x, btnSaveStep, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));


            DesignerSetup.LinkSVGtoControl(Properties.Resources.ClearWindowContent, btnMenuClearTerminal, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.FullScreen, btnMenuFullScreen, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
        }
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
                    Itm.Click += Itm_Click; ;
                    ddbPorts.DropDownItems.Add(Itm);
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
            ddbBAUDRate.DropDownItems.Add(BaudRateBtn);
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
        private void CheckParity(string Type) {
            foreach (ToolStripMenuItem Item in ddbParity.DropDownItems) {
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
        private void CheckStopBits(string Type) {
            foreach (ToolStripMenuItem Item in ddbStopBits.DropDownItems) {
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
                    //switch (CurrentManager.OutputFormat) {
                    //    case StreamOutputFormat.Text:
                    //        if (CurrentManager.Port.IsOpen) {
                    //            CurrentManager.Port.WriteLine(e.Command);
                    //        }
                    //        break;
                    //    case StreamOutputFormat.CCommand:
                    //        CurrentManager.Transmit(e.Command, false);
                    //        break;
                    //}
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
        }
        private void btnInFormText_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.InputFormat = StreamInputFormat.Text;
                ddbInputFormat.Text = "Text";
            }
            CheckInputFormat("frmTxt");
        }
        private void btnInFormStream_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.InputFormat = StreamInputFormat.BinaryStream;
                ddbInputFormat.Text = "Stream";
            }
            CheckInputFormat("frmStream");
        }
        private void btnInFormCCommand_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.InputFormat = StreamInputFormat.CCommand;
                ddbInputFormat.Text = "Command";
            }
            CheckInputFormat("frmCCommand");
        }
        private void btnInFormModbusRTU_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.InputFormat = StreamInputFormat.ModbusRTU;
                ddbInputFormat.Text = "Modbus RTU";
            }
            CheckInputFormat("frmModbusRTU");
        }
        private void btnOutFormText_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.OutputFormat = StreamOutputFormat.Text;
                ddbOutputFormat.Text = "Text";
            }
            CheckOutputFormat("frmTxt");
        }
        private void btnOutFormCCommand_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.OutputFormat = StreamOutputFormat.CCommand;
                ddbOutputFormat.Text = "Command";
            }
            CheckOutputFormat("frmCCommand");
        }
        private void btnOutFormModbusRTU_Click(object sender, EventArgs e) {
            if (CurrentManager != null) {
                CurrentManager.OutputFormat = StreamOutputFormat.ModbusRTU;
                ddbOutputFormat.Text = "Modbus RTU";
            }
            CheckOutputFormat("frmModbusRTU");
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
        #endregion
        #region Program UI
        private void LoadProgramOperations() {
            StepExecutable[] Steps = (StepExecutable[])StepExecutable.GetValues(typeof(StepExecutable));
            int Index = 0;
            int LastValue = 0;
            foreach (StepExecutable StepEx in Steps) {
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
        private void LoadProgramOperation(StepExecutable StepEx) {
            ToolStripMenuItem StepOperationBtn = new ToolStripMenuItem();
            StepOperationBtn.Text = ProgramManager.StepExecutableToString(StepEx); //StepEx.ToString();
            StepOperationBtn.Tag = StepEx;
            StepOperationBtn.ForeColor = Color.White;
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
                        StepExecutable StepExe = StepExecutable.NoOperation;
                        object? objExe = ((ToolStripMenuItem)sender).Tag;
                        if (objExe != null) {
                            if (objExe.GetType() == typeof(StepExecutable)) {
                                StepExe = (StepExecutable)objExe;
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
        private void SetDefault(ListItem Li, StepExecutable StepEx) {
            if (Li.SubItems.Count != 3) { return; }
            string DefaultText = "";
            if (StepEx == StepExecutable.Delay) {
                DefaultText = "1000";
            }
            else if (StepEx == StepExecutable.Open) {
                DefaultText = "COM1";
            }
            //else if (StepEx == StepExecutable.Close) {
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
                StepExecutable StepExe = StepExecutable.NoOperation;
                if (objTag != null) {
                    if (objTag.GetType() == typeof(StepExecutable)) {
                        StepExe = (StepExecutable)objTag;
                    }
                }
                if (AcceptsArguments(StepExe) == false) { return; }
                if (StepExe == StepExecutable.SendText) {
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
        private bool AcceptsArguments(StepExecutable StepExe) {
            if (StepExe == StepExecutable.NoOperation) { return false; }
            else if (StepExe == StepExecutable.End) { return false; }
            else if (StepExe == StepExecutable.EndIf) { return false; }
            else if (StepExe == StepExecutable.Clear) { return false; }
            else if (StepExe == StepExecutable.Close) { return false; }
            else if (StepExe == StepExecutable.MouseLeftClick) { return false; }
            return true;
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
            LiCmd.Text = ProgramManager.StepExecutableToString(StepExecutable.NoOperation);
            LiCmd.Tag = StepExecutable.NoOperation;
            lstStepProgram.ExternalItems.Add(LiPar);
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
            ProgramState = StepState.Stopped;
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
                            if (objCmd.GetType() == typeof(StepExecutable)) {
                                ProgramItem.Command = (StepExecutable)objCmd;
                            }
                            else { ProgramItem.Command = StepExecutable.NoOperation; }
                        }
                        else { ProgramItem.Command = StepExecutable.NoOperation; }


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
                    StepExecutable StCmd = CopiedItems[j].Command;
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
                    StepExecutable StCmd = CopiedItems[j].Command;
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
        private void tmrProg_Tick(object sender, EventArgs e) {
            if (LastProgramStep != ProgramStep) {
                if (CurrentProgram == lstStepProgram.Tag) {
                    lstStepProgram.LineMarkerIndex = ProgramStep;
                }
                if (CurrentProgram != null) {
                    CurrentProgram.ProgramMarker = ProgramStep;
                }
                LastProgramStep = ProgramStep;
            }
            if (LastProgramState != ProgramState) {
                if (ProgramState == StepState.Running) {
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
                LastProgramState = ProgramState;
            }
            if (currentManager != null) {
                string RxCount = currentManager.BytesReceived.ToString();
                string TxCount = currentManager.BytesSent.ToString();
                if (lblRxBytes.Text != RxCount) { lblRxBytes.Text = RxCount; }
                if (lblTxBytes.Text != TxCount) { lblTxBytes.Text = TxCount; }
            }
        }
        private void RunFromStart() {
            SetupProgram();
            ProgramStep = 0;
            ProgramState = StepState.Running;
        }
        private void RunFromStart(string ProgramName) {
            bool ProgramFound = false;
            if (ProgramName.Length > 0) {
                foreach (ProgramObject PrgObj in Programs) {
                    if (PrgObj.Name == ProgramName) {
                        CurrentProgram = PrgObj;
                        ProgramFound = true;
                        btnRun.Text = PrgObj.Name;
                        break;
                    }
                }
            }
            if (ProgramFound == false) {
                ProgramState = StepState.Stopped;
                ProgramStep = 0;
                Print(ErrorType.M_Warning, "NO_EXE_PRG", "'" + ProgramName + "' is not a vaild registered program name");
            }
            else {
                SetupProgram();
                ProgramStep = 0;
                ProgramState = StepState.Running;
            }
        }
        private void ContinueWithProgram(string ProgramName) {
            StepState TempState = ProgramState;
            ProgramState = StepState.Paused;
            bool ProgramFound = false;
            if (ProgramName.Length > 0) {
                foreach (ProgramObject PrgObj in Programs) {
                    if (PrgObj.Name == ProgramName) {
                        CurrentProgram = PrgObj;
                        ProgramFound = true;
                        btnRun.Text = PrgObj.Name;
                        break;
                    }
                }
            }
            if (ProgramFound == false) {
                ProgramState = StepState.Stopped;
                ProgramStep = 0;
                Print(ErrorType.M_Warning, "NO_EXE_PRG", "'" + ProgramName + "' is not a vaild registered program name");
            }
            else {
                if (TempState == StepState.Running) {
                    SetupProgram();
                    ProgramStep = 0;
                    ProgramState = StepState.Running;
                }
                else { 
                    ProgramState = StepState.Stopped;
                    ProgramStep = 0;
                }
            }

        }
        private void Run() {
            if (CurrentProgram == null) { return; }
            if (CurrentProgram == lstStepProgram.Tag) {
                if (CurrentProgram.ProgramMarker >= CurrentProgram.Program.Count) {
                    RunFromStart();
                }
            }
            else {
                SetupProgram();
                ProgramStep = CurrentProgram.ProgramMarker;
                ProgramState = StepState.Running;
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
            foreach (ProgramObject Prg in Programs) {
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
                if (tabHeader1.Tabs.Count > 0) {
                    if ((Index >= 0) && (Index < tabHeader1.Tabs.Count)) {
                        tabHeader1.Tabs[Index].Text = Name;
                    }
                }
                if (Prg == CurrentProgram) {
                    StoredName = Name;
                    Resulted = true;
                    // break;
                }

            }
            if (Resulted == true) {
                btnRun.Text = StoredName;
            }
            tabHeader1.Invalidate();
        }
        private void DetermineTabs() {
            int j = 0;
            string Name = "";
            foreach (ProgramObject Prg in Programs) {
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
                tabHeader1.Tabs.Add(Tb);
            }
            tabHeader1.Invalidate();
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
            foreach (ProgramObject Prg in Programs) {
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
                if (CurrentProgram == Prg) {
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
                    CurrentProgram = ProgramObject;
                    btnRun.Text = TsMi.Text;
                }
            }
        }

        private void btnRun_Click(object sender, EventArgs e) {

        }
        private void btnRun_ButtonClick(object sender, EventArgs e) {
            RunFromStart();
        }
        private void runFromStartToolStripMenuItem_Click(object sender, EventArgs e) {
            RunFromStart();
        }
        private void btnPause_Click(object sender, EventArgs e) {
            ProgramState = StepState.Paused;
        }
        private void btnStop_Click(object sender, EventArgs e) {
            ProgramState = StepState.Stopped;
            ProgramStep = 0;
        }
        private void btnRunPrg_Click(object sender, EventArgs e) {
            RunFromStart();
        }
        private void btnPausePrg_Click(object sender, EventArgs e) {
            ProgramState = StepState.Paused;
        }
        private void btnStopPrg_Click(object sender, EventArgs e) {
            ProgramState = StepState.Stopped;
            ProgramStep = 0;
        }
        private void runToolStripMenuItem_Click(object sender, EventArgs e) {
            RunFromStart();
        }
        private void runProgramToolStripMenuItem_Click(object sender, EventArgs e) {
            Run();
        }
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e) {
            ProgramState = StepState.Paused;
        }
        private void stopToolStripMenuItem_Click(object sender, EventArgs e) {
            ProgramState = StepState.Stopped;
            ProgramStep = 0;
        }
        private void btnRunCursor_Click(object sender, EventArgs e) {
            Run();
        }
        #endregion
        #region Program
        StepState ProgramState = StepState.Stopped;
        StepState LastProgramState = StepState.Stopped;
        int ProgramStep = 0;
        int LastProgramStep = 0;
        string CurrentSender = "";
        public string LatestOnClick = "";
        StepExecutable LastFunction = StepExecutable.NoOperation;
        List<LabelLinkage> LabelPositions = new List<LabelLinkage>();
        List<VariableLinkage> Variables = new List<VariableLinkage>();
        List<ConditionalLinkage> Conditionals = new List<ConditionalLinkage>();
        private void StepProgram() {
            bool CleanAll = false;
            try {
                while (true) {
                    if (CurrentProgram != null) {
                        if (CurrentProgram.Program.Count > 0) {
                            if (ProgramState == StepState.Running) {
                                CleanAll = true;
                                if (ProgramStep < CurrentProgram.Program.Count) {
                                    if (CurrentProgram.Program[ProgramStep].SubItems.Count == 3) {
                                        if (CurrentProgram.Program[ProgramStep].SubItems[0].Checked == true) {
                                            StepExecutable Function = StepExecutable.NoOperation;
                                            object? objFunction = CurrentProgram.Program[ProgramStep].SubItems[1].Tag;
                                            string objData = CurrentProgram.Program[ProgramStep].SubItems[2].Text;
                                            if (objFunction != null) {
                                                if (objFunction.GetType() == typeof(StepExecutable)) {
                                                    Function = (StepExecutable)objFunction;
                                                }
                                            }
                                            ExecuteLine(Function, objData);
                                            LastFunction = Function;
                                        }
                                    }
                                    if (NoStepProgramIncrement == false) {
                                        ProgramStep++;
                                    }
                                }
                                else {
                                    ProgramState = StepState.Stopped;
                                }
                            }
                            else if (ProgramState == StepState.Stopped) {
                                if (CleanAll == true) {
                                    CleanProgramData();
                                    CleanAll = false;
                                }
                            }
                        }
                        else {
                            ProgramState = StepState.Stopped;
                        }
                    }
                    else {
                        ProgramState = StepState.Stopped;
                    }
                    if (ProgramState != StepState.Running) {
                        Thread.Sleep(1);
                    }
                }
            }
            catch {
                ProgramState = StepState.Stopped;
            }

            Debug.Print("Exited");
        }
        int Program_CurrentManager = 0;
        bool NoStepProgramIncrement = false;
        private void ExecuteLine(StepExecutable Function, string Arguments) {
            switch (Function) {
                case StepExecutable.End:
                    ProgramState = StepState.Stopped;
                    break;
                case StepExecutable.NoOperation:
                    break;
                case StepExecutable.Delay:
                    SetDelay(Arguments);
                    break;
                case StepExecutable.SwitchSender:
                    CurrentSender = Arguments; break;
                case StepExecutable.SendByte:
                    SendByte(Arguments); break;

                case StepExecutable.SendString:
                    SendString(Arguments, false); break;
                case StepExecutable.SendLine:
                    SendString(Arguments, true); break;
                case StepExecutable.SendText:
                    if (File.Exists(Arguments)) {
                        try {
                            using (StreamReader Sr = new StreamReader(Arguments)) {
                                if (Sr != null) {
                                    while (Sr.Peek() > -1) {
                                        string item = Sr.ReadLine() ?? "";
                                        SendString(item, true);
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                    break;
                case StepExecutable.SetProgram:
                    this.BeginInvoke(new MethodInvoker(delegate {
                        this.ContinueWithProgram(Arguments);
                    }));
                    break;
                case StepExecutable.Call:
                    ProgramState = StepState.Paused;
                    this.BeginInvoke(new MethodInvoker(delegate {
                        this.RunFromStart(Arguments);
                    }));
                    break;
                case StepExecutable.Clear:
                    this.BeginInvoke(new MethodInvoker(delegate {
                        this.Output.Clear();
                    }));
                    break;
                case StepExecutable.Print:
                    this.BeginInvoke(new MethodInvoker(delegate {
                        this.Output.Print(Arguments);
                    }));
                    break;
                case StepExecutable.PrintVariable:
                    this.BeginInvoke(new MethodInvoker(delegate {
                        this.Output.Print(GetVariable(Arguments));
                    }));
                    break;
                case StepExecutable.Open:
                    ProgramSerialManagement(Function, Arguments);
                    break;
                case StepExecutable.Close:
                    ProgramSerialManagement(Function, Arguments);
                    break;
                case StepExecutable.Label:
                    SetLabel(Arguments);
                    break;
                case StepExecutable.DeclareVariable:
                    SetVariable(Arguments); break;
                case StepExecutable.IncrementVariable:
                    IncrementDecrementVariable(Arguments, false); break;
                case StepExecutable.DecrementVariable:
                    IncrementDecrementVariable(Arguments, true); break;
                case StepExecutable.If:
                    EvaluateConditional(Arguments); break;
                case StepExecutable.GoTo:
                    GotoLabel(Arguments);
                    break;
                case StepExecutable.MousePosition:
                    this.BeginInvoke(new MethodInvoker(delegate {
                        this.SetMousePosition(Arguments);
                    })); break;
                case StepExecutable.MouseLeftClick:
                    this.BeginInvoke(new MethodInvoker(delegate {
                        mouse_event(0x02, 0, 0, 0, 0);
                        mouse_event(0x04, 0, 0, 0, 0);
                    }));
                    break;
                case StepExecutable.SendKeys:
                    this.BeginInvoke(new MethodInvoker(delegate {
                        SendKeys.Send(Arguments);
                    }));
                    break;
                default:
                    break;
            }
        }
        [DllImport("user32")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private void ProgramSerialManagement(StepExecutable StepEx, string Arguments) {
            if (Program_CurrentManager >= 0) {
                if (SystemManager.SerialManagers.Count == 0) { return; }
                if (Program_CurrentManager >= SystemManager.SerialManagers.Count) { return; }
                if (StepEx == StepExecutable.Open) {
                    this.BeginInvoke(new MethodInvoker(delegate {
                        this.SetPort(SystemManager.SerialManagers[Program_CurrentManager], Arguments);
                        this.Connect(SystemManager.SerialManagers[Program_CurrentManager]);
                    }));
                }
                else if (StepEx == StepExecutable.Close) {
                    this.BeginInvoke(new MethodInvoker(delegate {
                        this.Disconnect(SystemManager.SerialManagers[Program_CurrentManager]);
                    }));
                }

            }
        }
        private void SetMousePosition(string Arguments) {
            string Args = Arguments.Replace(" ", "");
            if (Args.Contains(",")) {
                string XStr = Args.Split(',')[0];
                string YStr = Args.Split(',')[1];
                int X = 0; int Y = 0;
                int.TryParse(XStr, out X);
                int.TryParse(YStr, out Y);
                Cursor.Position = new Point(X, Y);
            }
        }
        private void SetPort(SerialManager? SerMan, string Arguments) {
            try {
                SystemManager.SerialManagers[Program_CurrentManager].Port.PortName = Arguments;
            }
            catch {
                Print(ErrorType.M_Error, "COM_PSET", "'" + Arguments + "' is already in use or is an unrecognized port name");
            }
        }
        private void SetDelay(string Arguments) {
            try {
                int Milliseconds = 1;
                int.TryParse(Arguments, out Milliseconds);
                Thread.Sleep(Milliseconds);
            }
            catch { }
        }
        private void SendByte(string Arguments) {
            byte Data = 0x00;
            if (Arguments.ToLower().StartsWith("0x")) {
                try {
                    Data = Byte.Parse(Arguments.Substring(2), NumberStyles.HexNumber);
                }
                catch { }
            }
            else { return; }
            foreach (SerialManager SerMan in SystemManager.SerialManagers) {
                if ((CurrentSender == "") || (CurrentSender.ToLower() == "all")) {
                    SerMan.Post(Data);
                }
                else if (CurrentSender == SerMan.Port.PortName) {
                    SerMan.Post(Data);
                    break;
                }
            }
        }
        private void SendString(string Arguments, bool WriteLine = false) {
            foreach (SerialManager SerMan in SystemManager.SerialManagers) {
                if ((CurrentSender == "") || (CurrentSender.ToLower() == "all")) {
                    SerMan.Post(Arguments);
                }
                else if (CurrentSender == SerMan.Port.PortName) {
                    SerMan.Post(Arguments, WriteLine);
                    break;
                }
            }
        }
        private void CleanProgramData() {
            LabelPositions.Clear();
            Variables.Clear();
            Conditionals.Clear();
            LastFunction = StepExecutable.NoOperation;
        }
        private void SetVariable(string Arguments) {
            bool ExistsInVariables = false;
            if (!Arguments.Contains('=')) { return; }
            string VarName = Arguments.Split('=')[0];
            string VarValue = StringHandler.SpiltAndCombineAfter(Arguments, '=', 1).Value[1];

            if (Variables.Count > 0) {
                for (int i = 0; i < Variables.Count; i++) {
                    if (Variables[i].Name == VarName) {
                        Variables[i].Value = VarValue;
                        ExistsInVariables = true; break;
                    }
                }
            }
            if (ExistsInVariables == false) {
                VariableLinkage LblLink = new VariableLinkage(VarName, VarValue);
                Variables.Add(LblLink);
            }
        }
        private void IncrementDecrementVariable(string Argument, bool Decrement) {
            if (Variables.Count > 0) {
                for (int i = 0; i < Variables.Count; i++) {
                    if (Variables[i].Name == Argument) {
                        if (ConversionHandler.IsNumeric(Variables[i].Value)) {
                            decimal Value = 0;
                            Decimal.TryParse(Variables[i].Value, out Value);
                            Value += Decrement == true ? -1.0m : 1.0m;
                            Variables[i].Value = Value.ToString();
                            break;
                        }
                    }
                }
            }
        }
        private void EvaluateConditional(string Arguments) {
            bool Result = false;
            if (Arguments.Contains(">")) {
                string LeftArg = Arguments.Split('>')[0];
                string RightArg = StringHandler.SpiltAndCombineAfter(Arguments, '>', 1).Value[1];
                string LeftVal = GetVariable(LeftArg, true);
                string RightVal = GetVariable(RightArg, true);
                if (ConversionHandler.IsNumeric(LeftVal) && ConversionHandler.IsNumeric(RightVal)) {
                    decimal LeftDec = 0;
                    decimal RightDec = 0;
                    Decimal.TryParse(LeftVal, out LeftDec);
                    Decimal.TryParse(RightVal, out RightDec);
                    Result = LeftDec > RightDec ? true : false;
                }
            }
            else if (Arguments.Contains("<")) {
                string LeftArg = Arguments.Split('<')[0];
                string RightArg = StringHandler.SpiltAndCombineAfter(Arguments, '<', 1).Value[1];
                string LeftVal = GetVariable(LeftArg, true);
                string RightVal = GetVariable(RightArg, true);
                if (ConversionHandler.IsNumeric(LeftVal) && ConversionHandler.IsNumeric(RightVal)) {
                    decimal LeftDec = 0;
                    decimal RightDec = 0;
                    Decimal.TryParse(LeftVal, out LeftDec);
                    Decimal.TryParse(RightVal, out RightDec);
                    Result = LeftDec < RightDec ? true : false;
                }
            }
            else if (Arguments.Contains("=")) {
                string LeftArg = Arguments.Split('=')[0];
                string RightArg = StringHandler.SpiltAndCombineAfter(Arguments, '=', 1).Value[1];
                string LeftVal = GetVariable(LeftArg, true);
                string RightVal = GetVariable(RightArg, true);
                if (ConversionHandler.IsNumeric(LeftVal) && ConversionHandler.IsNumeric(RightVal)) {
                    decimal LeftDec = 0;
                    decimal RightDec = 0;
                    Decimal.TryParse(LeftVal, out LeftDec);
                    Decimal.TryParse(RightVal, out RightDec);
                    Result = LeftDec == RightDec ? true : false;
                }
                else {
                    Result = LeftVal == RightVal ? true : false;
                }
            }
            if (Result == false) {
                int StartCounter = ProgramStep;
                foreach (ConditionalLinkage ConLnk in Conditionals) {
                    if (ConLnk.Start == StartCounter) {
                        ProgramStep = ConLnk.End;
                        break;
                    }
                }
            }
        }
        private string GetVariable(string Argument, bool UseInput = false) {
            foreach (VariableLinkage Var in Variables) {
                if (Argument == Var.Name) {
                    return Var.Value;
                }
            }
            if (UseInput == true) { return Argument; }
            return "";
        }
        private void SetLabel(string Arguments) {
            if (LastFunction != StepExecutable.GoTo) {
                bool ExistsInPositions = false;
                if (LabelPositions.Count > 0) {
                    for (int i = 0; i < LabelPositions.Count; i++) {
                        if (LabelPositions[i].Label == Arguments) {
                            ExistsInPositions = true; break;
                        }
                    }
                }
                if (ExistsInPositions == false) {
                    LabelLinkage LblLink = new LabelLinkage(Arguments, ProgramStep);
                    LabelPositions.Add(LblLink);
                }
            }
        }
        private void GotoLabel(string Arguments) {
            bool LabelExists = false;
            if (LabelPositions.Count > 0) {
                for (int i = 0; i < LabelPositions.Count; i++) {
                    if (LabelPositions[i].Label == Arguments) {
                        ProgramStep = LabelPositions[i].LineNumber;
                        LabelExists = true; break;
                    }
                }
            }
            if (LabelExists == false) {
                this.BeginInvoke(new MethodInvoker(delegate {
                    this.Print(ErrorType.M_Warning, "NO_JMP_LBL", "'" + Arguments + "' could not be found");
                }));
            }
        }
        private void SetupProgram() {
            Conditionals.Clear();
            if (CurrentProgram == null) { return; }
            for (int i = 0; i < CurrentProgram.Program.Count; i++) {
                if (CurrentProgram.Program[i].SubItems.Count == 3) {
                    object? TagData = CurrentProgram.Program[i].SubItems[1].Tag;
                    if (TagData != null) {
                        if (TagData.GetType() == typeof(StepExecutable)) {
                            if ((StepExecutable)TagData == StepExecutable.If) {
                                FindConditionalEnd(i);
                            }
                        }
                    }
                }
            }
        }
        private void FindConditionalEnd(int StartIndex) {
            bool NothingMet = true;
            if (CurrentProgram == null) { return; }
            for (int i = StartIndex; i < CurrentProgram.Program.Count; i++) {
                if (CurrentProgram.Program[i].SubItems.Count == 3) {
                    object? TagData = CurrentProgram.Program[i].SubItems[1].Tag;
                    if (TagData != null) {
                        if (TagData.GetType() == typeof(StepExecutable)) {
                            if ((StepExecutable)TagData == StepExecutable.EndIf) {
                                Conditionals.Add(new ConditionalLinkage(StartIndex, i));
                                NothingMet = false;
                                break;
                            }
                        }
                    }
                }
            }
            if (NothingMet == true) {
                Conditionals.Add(new ConditionalLinkage(StartIndex, CurrentProgram.Program.Count));
            }
        }
        #endregion

        private void btnMonitor_Click(object sender, EventArgs e) {
            Monitor NewMonitor = new Monitor();
            NewMonitor.Attached = this;
            Classes.ApplicationManager.OpenInternalApplicationOnce(NewMonitor);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e) {
            if (pnlRenamePanel.Visible == false) {
                Output.Focus();
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
                    WriteFile(Save.FileName);
                    CurrentDocument = Save.FileName;
                }
            }
            else {
                WriteFile(CurrentDocument);
            }
            AddFiletoRecentFiles(CurrentDocument);
        }
        public void WriteFile(string FileAddress) {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string ProgramVersion = fvi.ProductMajorPart + "." + fvi.ProductMinorPart.ToString();
            using (StreamWriter Sw = new StreamWriter(FileAddress)) {
                Sw.WriteLine("--------------------------");
                Sw.WriteLine("-- SERIAL MONITOR");
                Sw.WriteLine("-- VERSION " + ProgramVersion + " (Build " + fvi.ProductBuildPart.ToString() + ")");
                Sw.WriteLine("--------------------------");
                Sw.WriteLine("");
                Sw.WriteLine("Begin,");
                Sw.WriteLine("Create Lines(1),");
                Sw.WriteLine("--  Document Details");
                Sw.WriteLine(StringHandler.AddTabs(1, "def,str:ProgramName=" + StringHandler.EncapsulateString("")));
                Sw.WriteLine(StringHandler.AddTabs(1, "def,str:Author=" + StringHandler.EncapsulateString(Environment.UserName)));
                Sw.WriteLine(StringHandler.AddTabs(1, "def,dec:Version=" + ProgramVersion));
                Sw.WriteLine("");
                if (SystemManager.SerialManagers.Count > 0) {
                    Sw.WriteLine("--  Channels");
                    int i = 0;
                    foreach (SerialManager Sm in SystemManager.SerialManagers) {
                        Sw.WriteLine(StringHandler.AddTabs(1, "def,parm:CHAN_" + i.ToString() + "{"));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:Name=" + StringHandler.EncapsulateString(Sm.Name)));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:Port=" + StringHandler.EncapsulateString(Sm.Port.PortName)));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,int:Baud=" + Sm.Port.BaudRate));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,int:DataSize=" + Sm.Port.DataBits));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:StopBits=" + StringHandler.EncapsulateString(EnumManager.StopBitsToString(Sm.Port.StopBits))));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:Parity=" + StringHandler.EncapsulateString(EnumManager.ParityToString(Sm.Port.Parity))));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:InType=" + StringHandler.EncapsulateString(EnumManager.InputFormatToString(Sm.InputFormat).B)));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:OutType=" + StringHandler.EncapsulateString(EnumManager.OutputFormatToString(Sm.OutputFormat).B)));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,bol:ModbusMstr=" + Sm.IsMaster.ToString()));
                        Sw.WriteLine(StringHandler.AddTabs(1, "}"));
                        i++;
                    }
                }
                Sw.WriteLine("");
                if (Programs.Count > 0) {
                    Sw.WriteLine("--  Step Programs");
                    int Cnt = 0;
                    foreach (ProgramObject Prg in Programs) {
                        if (Prg.Program.Count > 0) {
                            Sw.WriteLine(StringHandler.AddTabs(1, "def,parm:STEP_" + Cnt.ToString() + "{"));
                            Sw.WriteLine(StringHandler.AddTabs(2, "def,str:Name=" + StringHandler.EncapsulateString(Prg.Name)));
                            Sw.WriteLine(StringHandler.AddTabs(2, "def,str:Command=" + StringHandler.EncapsulateString(Prg.Command)));
                            Sw.WriteLine(StringHandler.AddTabs(2, "def,a(str):Data={"));
                            foreach (ListItem LstItm in Prg.Program) {
                                if (LstItm.SubItems.Count == 3) {
                                    string EnableTxt = LstItm.SubItems[0].Checked == true ? "1" : "0";
                                    string Command = "";
                                    object? CommandObj = LstItm.SubItems[1].Tag;
                                    if (CommandObj != null) {
                                        if (CommandObj.GetType() == typeof(StepExecutable)) {
                                            Command = ((int)((StepExecutable)CommandObj)).ToString("00000000");
                                        }
                                    }
                                    string Arguments = LstItm.SubItems[2].Text;
                                    Sw.WriteLine(StringHandler.AddTabs(3, StringHandler.EncapsulateString(EnableTxt + ":" + Command + ":" + Arguments)));
                                }
                            }
                            Sw.WriteLine(StringHandler.AddTabs(2, "}"));
                            Sw.WriteLine(StringHandler.AddTabs(1, "}"));
                        }
                        Cnt++;
                    }
                }
            }
        }
        private void ClearPrograms() {
            tabHeader1.ClearTabs();
            for (int i = Programs.Count - 1; i >= 0; i--) {
                Programs[i].Clear();
                Programs.RemoveAt(i);
            }
        }
        public void Open(string FileAddress) {

            DocumentHandler.Open(FileAddress);
            ClearManagers();
            ClearPrograms();
            lstStepProgram.LineRemoveAll();
            GC.Collect();
            Programs.Add(new ProgramObject());
            int CurrentProgramIndex = 0;
            for (int i = 0; i < DocumentHandler.PARM.Count; i++) {
                string ParameterName = DocumentHandler.PARM[i].Name;
                if (ParameterName.StartsWith("CHAN")) {
                    ParameterStructure Pstrc = DocumentHandler.PARM[i];
                    SerialManager Sm = new SerialManager();
                    Sm.Name = DocumentHandler.GetStringVariable(Pstrc, "Name", "");
                    try {
                        Sm.Port.PortName = DocumentHandler.GetStringVariable(Pstrc, "Port", "");
                    }
                    catch { }
                    try {
                        Sm.BaudRate = DocumentHandler.GetIntegerVariable(Pstrc, "Baud", 9600);
                    }
                    catch { }
                    try {
                        Sm.Port.DataBits = DocumentHandler.GetIntegerVariable(Pstrc, "DataSize", 8);
                    }
                    catch { }
                    try {
                        Sm.Port.StopBits = EnumManager.StringToStopBits(DocumentHandler.GetStringVariable(Pstrc, "StopBits", "1"));
                    }
                    catch { }
                    try {
                        Sm.Port.Parity = EnumManager.StringToParity(DocumentHandler.GetStringVariable(Pstrc, "Parity", "N"));
                    }
                    catch { }
                    try {
                        Sm.InputFormat = EnumManager.StringToInputFormat(DocumentHandler.GetStringVariable(Pstrc, "InType", "frmTxt"));
                    }
                    catch { }
                    try {
                        Sm.OutputFormat = EnumManager.StringToOutputFormat(DocumentHandler.GetStringVariable(Pstrc, "OutType", "frmTxt"));
                    }
                    catch { }
                    try {
                        Sm.IsMaster = DocumentHandler.GetBooleanVariable(Pstrc, "ModbusMstr");
                    }
                    catch { }

                    Sm.CommandProcessed += SerManager_CommandProcessed;
                    Sm.DataReceived += SerMan_DataReceived;
                    SystemManager.SerialManagers.Add(Sm);
                }
                else if (ParameterName.StartsWith("STEP")) {
                    if (CurrentProgramIndex > 0) {
                        Programs.Add(new ProgramObject());
                    }
                    //E:00000000:
                    Programs[CurrentProgramIndex].Name = DocumentHandler.GetStringVariable(DocumentHandler.PARM[i], "Name", "");
                    Programs[CurrentProgramIndex].Command = DocumentHandler.GetStringVariable(DocumentHandler.PARM[i], "Command", "");
                    if (DocumentHandler.IsDefinedInParameter("Data", DocumentHandler.PARM[i])) {

                        List<string> Data = GetList(DocumentHandler.PARM[i].GetVariable("Data", false, DataType.STR));
                        for (int j = 0; j < Data.Count; j++) {
                            Programs[CurrentProgramIndex].DecodeFileCommand(Data[j]);
                        }
                    }
                    CurrentProgramIndex++;

                }
            }
            if (SystemManager.SerialManagers.Count > 0) {
                navigator1.SelectedItem = 0;
                CurrentManager = SystemManager.SerialManagers[0];
            }
            lstStepProgram.ExternalItems = Programs[0].Program;
            lstStepProgram.Tag = Programs[0];
            CurrentProgram = Programs[0];
            lstStepProgram.Invalidate();
            CurrentDocument = FileAddress;
            DetermineName();
            DetermineTabs();
            this.Text = Path.GetFileNameWithoutExtension(CurrentDocument) + " - Serial Monitor";
        }

        private List<string> GetList(object Input) {
            if (Input == null) {
                return new List<string>();
            }
            if (Input.GetType() == typeof(List<string>)) {
                return (List<string>)Input;
            }
            return new List<string>();
        }
        private void NewProgram() {

            ProgramObject PrgObj = new ProgramObject();
            Programs.Add(PrgObj);
            Tab Tb = new Tab();
            Tb.Text = "";
            Tb.Tag = PrgObj;
            tabHeader1.Tabs.Add(Tb);
            UpdateProgramNames();
            tabHeader1.Invalidate();
        }
        private void RemoveProgram(int Index) {
            bool ChangeActiveProgram = false;
            bool ChangeEditingProgram = false;
            if (Index >= tabHeader1.Tabs.Count) { return; }
            object? DataTag = tabHeader1.Tabs[Index].Tag;
            if (DataTag == null) { return; }
            if (DataTag.GetType() == typeof(ProgramObject)) {
                ProgramObject PrgObj = (ProgramObject)DataTag;

                if (PrgObj == CurrentProgram) {
                    CurrentProgram = null;
                    ChangeActiveProgram = true;
                }
                if (lstStepProgram.Tag == PrgObj) {
                    lstStepProgram.Tag = null;
                    ChangeEditingProgram = true;
                }
                try {
                    Programs.RemoveAt(Index);
                    tabHeader1.Tabs.RemoveAt(Index);
                }
                catch { }
            }
            if (Programs.Count == 0) {
                NewProgram();
                lstStepProgram.Tag = Programs[0];
                lstStepProgram.ExternalItems = Programs[0].Program;
                CurrentProgram = Programs[0];
                tabHeader1.SelectedIndex = 0;
                btnRun.Text = tabHeader1.Tabs[0].Text;
            }
            else {
                if (ChangeActiveProgram == true) {
                    CurrentProgram = Programs[0];
                    btnRun.Text = tabHeader1.Tabs[0].Text;
                }
                if (ChangeEditingProgram == true) {
                    lstStepProgram.Tag = Programs[Programs.Count - 1];
                    lstStepProgram.ExternalItems = Programs[Programs.Count - 1].Program;
                }
            }
            tabHeader1.Invalidate();
        }
        private void UpdateProgramNames() {
            int j = 0;
            int Index = -1;
            foreach (ProgramObject Prg in Programs) {
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
                if (tabHeader1.Tabs.Count > 0) {
                    if ((Index >= 0) && (Index < tabHeader1.Tabs.Count)) {
                        tabHeader1.Tabs[Index].Text = PrgName;
                        tabHeader1.Tabs[Index].Tag = Prg;
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
                if (CurrentProgram != null) {
                    if (CurrentProgram == lstStepProgram.Tag) {
                        CurrentProgram.ProgramMarker = lstStepProgram.SelectedIndex;
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
            if (tabHeader1.Tabs.Count > 0) {
                if (CurrentIndex < tabHeader1.Tabs.Count) {
                    object? TagData = tabHeader1.Tabs[CurrentIndex].Tag;
                    if (TagData != null) {
                        if (TagData.GetType() == typeof(ProgramObject)) {
                            lstStepProgram.Tag = TagData;
                            lstStepProgram.ExternalItems = ((ProgramObject)TagData).Program;
                            lstStepProgram.LineMarkerIndex = ((ProgramObject)TagData).ProgramMarker;
                        }
                    }
                }
            }
        }
        private void tabHeader1_AddButtonClicked(object sender) {
            NewProgram();
        }
        private void tabHeader1_CloseButtonClicked(object sender, int Index) {
            RemoveProgram(Index);
        }

        private void toolStripSeparator27_Click(object sender, EventArgs e) {

        }
        private void removeProgramToolStripMenuItem_Click(object sender, EventArgs e) {
            RemoveProgram(tabHeader1.SelectedIndex);
        }
        private void newProgramToolStripMenuItem_Click(object sender, EventArgs e) {
            NewProgram();

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
    public enum StepState {
        Stopped = 0x00,
        Paused = 0x01,
        Running = 0x02
    }
    public enum StepExecutable {
        NoOperation = 0x000000,
        GoTo = 0x010080,
        Call = 0x010041,
        Label = 0x010040,
        Delay = 0x010100,
        End = 0x010200,
        SetProgram = 0x010001,
        If = 0x010081,
        EndIf = 0x01FFFF,
        SwitchSender = 0x020001,
        Open = 0x020020,
        Close = 0x020040,
        SendByte = 0x030002,
        SendString = 0x030004,
        SendLine = 0x030008,
        SendText = 0x030010,
        Print = 0x040040,
        PrintVariable = 0x040060,
        Clear = 0x040080,
        DeclareVariable = 0x050001,
        IncrementVariable = 0x050002,
        DecrementVariable = 0x050003,
        ///SelectChannel = 0x050400,
        //NewChannel = 0x050800,
        //DeleteChannel = 0x051000,
        JumpOnPress = 0x060001,
        MousePosition = 0x090001,
        MouseLeftClick = 0x090002,
        SendKeys = 0x090010,
    }
    public class FullScreenStyle {
        public bool IsFullScreen = false;
        public FormWindowState WindowState = FormWindowState.Normal;
        public FormBorderStyle BorderStyle = FormBorderStyle.Sizable;
        public Point WindowPosition;
        public Size WindowSize;
    }
    public class ConditionalLinkage {
        int start = 0;
        public int Start {
            get { return start; }
        }
        int end = 0;
        public int End {
            get { return end; }
        }
        public ConditionalLinkage(int start, int end) {
            this.start = start;
            this.end = end;
        }
    }
    public class LabelLinkage {
        string label = "";
        public string Label {
            get { return label; }
        }
        int lineNumber = -1;
        public int LineNumber {
            get { return lineNumber; }
        }
        public LabelLinkage(string label, int lineNumber) {
            this.label = label;
            this.lineNumber = lineNumber;
        }
    }
    public class VariableLinkage {
        string name = "";
        public string Name {
            get { return name; }
        }
        string assignment = "";
        public string Value {
            get { return assignment; }
            set { assignment = value; }
        }
        public VariableLinkage(string name, string assignment) {
            this.name = name;
            this.assignment = assignment;
        }
    }
    [Serializable]
    public class ProgramDataObject {
        public bool Enabled = true;
        public StepExecutable Command = StepExecutable.NoOperation;
        public string Arguments = "";
    }
}