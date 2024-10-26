using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.Enums.FormatEnums;
using static System.Windows.Forms.LinkLabel;

namespace Serial_Monitor.WindowForms {
    public partial class Terminal : Form, Interfaces.ITheme {
        SerialManager? manager = null;
        private SerialManager? Manager {
            get { return manager; }
        }
        public Terminal(SerialManager Manager) {
            this.manager = Manager;
            InitializeComponent();

            Manager.CommandProcessed += Manager_CommandProcessed;
            Manager.DataReceived += Manager_DataReceived;
            Manager.NameChanged += Manager_NameChanged;
            SystemManager.PortStatusChanged += SystemManager_PortStatusChanged;
            SystemManager.ChannelPropertyChanged += SystemManager_ChannelPropertyChanged;

            ChangeFormName(manager.StateName, "");
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            AddIcons();
            foreach (int i in SystemManager.DefaultBauds) {
                LoadBAUDRate(i);
            }
            RefreshPorts();
            EnumManager.LoadInputFormats(btnChannelInputFormat, InputFormat_Click, false);
            EnumManager.LoadOutputFormats(btnChannelOutputFormat, OutputFormat_Click, false);
            SystemManager.CheckFormatOption(Properties.Settings.Default.DEF_INT_BaudRate, btnChannelBaudVals);
            SetProperties();
            ConnectionStatus();
        }

        private void SystemManager_PortStatusChanged(SerialManager sender) {
            this.BeginInvoke(new MethodInvoker(delegate {
                if (manager == null) { return; }
                if (sender.ID != manager.ID) { return; }
                ConnectionStatus();
            }));
        }
        private void SystemManager_ChannelPropertyChanged(SerialManager sender) {
            if (manager == null) { return; }
            if (sender.ID != manager.ID) { return; }
            SetProperties();
        }
        private void SetProperties() {
            if (manager == null) { return; }
            CheckLineFormat();
            modbusMasterToolStripMenuItem.Checked = manager.IsMaster;
            SystemManager.CheckFormatOption(manager.DataBits.ToString(), btnChannelDataBits);
            SystemManager.CheckFormatOption(EnumManager.ParityToString(manager.Parity), btnChannelParity);
            SystemManager.CheckFormatOption(EnumManager.StopBitsToString(manager.StopBits), btnChannelStopBits);
            SystemManager.CheckFormatOption(manager.BaudRate, btnChannelBaudVals);
            SystemManager.CheckFormatOption(EnumManager.HandshakeToString(manager.Handshake), btnChannelFlowCtrl);
            SystemManager.CheckFormatOption(EnumManager.InputFormatToString(manager.InputFormat).B, btnChannelInputFormat);
            SystemManager.CheckFormatOption(EnumManager.OutputFormatToString(manager.OutputFormat).B, btnChannelOutputFormat);
            outputInMasterTerminalToolStripMenuItem.Checked = manager.OutputToMasterTerminal;
            allowEscapeCharToolStripMenuItem.Checked = manager.AllowEscapeCharacters;
        }
        private void ConnectionStatus() {
            if (manager == null) { return; }
            if (manager.Connected == true) {
                connectToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = true;

                btnChannelPort.Enabled = false;
                btnChannelBaudVals.Enabled = false;
                btnChannelDataBits.Enabled = false;
                btnChannelParity.Enabled = false;
                btnChannelStopBits.Enabled = false;
                btnChannelFlowCtrl.Enabled = false;
            }
            else {
                connectToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = false;

                btnChannelPort.Enabled = true;
                btnChannelBaudVals.Enabled = true;
                btnChannelDataBits.Enabled = true;
                btnChannelParity.Enabled = true;
                btnChannelStopBits.Enabled = true;
                btnChannelFlowCtrl.Enabled = true;
            }
        }
        private void Manager_NameChanged(object sender, string Data) {
            if (manager == null) { return; }
            ChangeFormName(manager.StateName, LogFile);
        }
        private void ChangeFormName(string Item, string File) {

            if (Item.Length == 0) {
                if (File.Trim().Length == 0) {
                    Text = "Terminal";
                }
                else {
                    Text = Path.GetFileNameWithoutExtension(File) + " - Terminal";
                }
            }
            if (File.Trim().Length == 0) {
                Text = Item + " - Terminal";
            }
            else {
                Text = Path.GetFileNameWithoutExtension(File) + " | " + Item + " - Terminal";
            }

        }
        private void Manager_DataReceived(object sender, bool PrintLine, string Data) {
            string SourceName = "";
            if (sender.GetType() == typeof(SerialManager)) {
                SerialManager SM = (SerialManager)sender;
                SourceName = SM.PortName;
            }

            if (PrintLine == true) {
                PushToBuffer(Data);
                Output.Print(SourceName, Data);
            }
            else {
                AppendToLastLine(Data, true);
                Output.AttendToLastLine(SourceName, Data, true);
            }
        }
        public void PushLineBuffer(string Text) {
            Text = Text.Replace("\r", "");
            List<string> LinesToPrint = SpiltString(Text, '\n');
            for (int i = 0; i < LinesToPrint.Count; i++) {
                string Temp = LinesToPrint[i];
                PushToBuffer(Temp);
            }
        }
        private List<string> SpiltString(string value, char chr) {
            string rechr = chr.ToString();
            string fullval = value;
            var splitval = fullval.Split(rechr.ToCharArray());
            var cnt = fullval.Split(chr);
            List<string> cp = new List<string>();
            for (int i = 0; i <= cnt.Count() - 1; i++) {
                cp.Add(splitval[i]);
            }
            return cp;
        }
        private void Manager_CommandProcessed(object sender, string Data) {
            string SourceName = "";
            if (sender.GetType() == typeof(SerialManager)) {
                SerialManager SM = (SerialManager)sender;
                SourceName = SM.PortName;
            }
            PushToBuffer(Data);
            Output.Print(SourceName, Data);

        }
        private void PushToBuffer(string Data) {
            string Output = ""; DateTime Now = DateTime.Now;
            Output += StringHandler.EncapsulateString(Now.ToString("dd/MM/yyyy")) + ",";
            Output += StringHandler.EncapsulateString(Now.ToString("HH:mm:ss")) + ",";
            Output += StringHandler.EncapsulateString(Data);
            if (WriteToFirst == true) {
                FirstBuffer.Add(Output);
            }
            else {
                SecondBuffer.Add(Output);
            }
        }
        string TempData = "";
        public void AppendToLastLine(string Text, bool CheckForNewLine = true) {
            Text = Text.Replace("\0", "");
            TempData += Text;
            if (TempData.Length > 50) {
                PushLineBuffer(TempData);
                TempData = "";
            }
            if (CheckForNewLine == true) {
                string Temp = TempData;
                Temp = Temp.Replace("\u0084", "\n");
                if (Temp.Contains('\n')) {
                    Temp = Temp.Replace("\r", "");
                    List<string> LinesToPrint = SpiltString(Temp, '\n');
                    if (LinesToPrint.Count == 1) {
                        TempData = LinesToPrint[0];
                    }
                    else if (LinesToPrint.Count > 1) {
                        PushToBuffer(LinesToPrint[0]);
                        for (int i = 1; i < LinesToPrint.Count; i++) {
                            if (i < LinesToPrint.Count - 1) {
                                PushLineBuffer(LinesToPrint[i]);
                            }
                            else {
                                TempData = LinesToPrint[i];
                            }
                        }
                    }
                }
            }
        }
        private void Terminal_Load(object sender, EventArgs e) {
            RecolorAll();
        }
        public void ApplyTheme() {

            RecolorAll();
            AddIcons();
        }
        private void AddIcons() {
            DesignerSetup.LinkSVGtoControl(Properties.Resources.ClearWindowContent, btnMenuClearTerminal, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.ClearWindowContent, btnClearTerminal, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.BringForward, btnTopMost, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, btnStartLogging, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, btnStartLog, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, btnStopLog, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, btnStopLogging, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Save_16x, btnSaveLog, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.OpenFile_16x, btnOpenLog, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Connect_16x, connectToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Disconnect_16x, disconnectToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Property, propertiesToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Input, btnChannelInputFormat, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Output1, btnChannelOutputFormat, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

        }
        private void RecolorAll() {
            ApplicationManager.IsDark = Properties.Settings.Default.THM_SET_IsDark;
            this.SuspendLayout();
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(Output);
            Classes.Theming.ThemeManager.ThemeControl(msMain);
            Classes.Theming.ThemeManager.ThemeControl(tsMain);

            this.ResumeLayout();
        }
        private void Terminal_FormClosing(object sender, FormClosingEventArgs e) {
            if (Manager == null) { return; }
            Manager.CommandProcessed -= Manager_CommandProcessed;
            Manager.DataReceived -= Manager_DataReceived;
            Manager.NameChanged -= Manager_NameChanged;
            SystemManager.PortStatusChanged -= SystemManager_PortStatusChanged;
            SystemManager.ChannelPropertyChanged -= SystemManager_ChannelPropertyChanged;
        }
        private void Output_CommandEntered(object sender, CommandEnteredEventArgs e) {
            try {
                if (Manager != null) {
                    Manager.Post(e.Command, false);
                }
            }
            catch {

            }
        }
        private void Terminal_KeyPress(object sender, KeyPressEventArgs e) {
            Output.Focus();
        }
        private void SetFormat(object? Index) {
            if (Index == null) { return; }
            int FormatIndex = -1; int.TryParse(Index.ToString(), out FormatIndex);
            foreach (ToolStripItem MItem in ddbDisplayTime.DropDownItems) {
                if (MItem.Tag != null) {
                    int Indx = -1; int.TryParse(MItem.Tag.ToString(), out Indx);
                    if (Indx == FormatIndex) {
                        ddbDisplayTime.Text = MItem.Text;
                        // break;
                    }
                    else {
                        if (MItem.GetType() == typeof(ToolStripMenuItem)) {
                            ((ToolStripMenuItem)MItem).Checked = false;
                        }
                    }
                }
            }
            switch (FormatIndex) {
                case 0:
                    Output.TimeStamps = ConsoleInterface.TimeStampFormat.NoTimeStamps;
                    btnMenuDispDataOnly.Checked = true;
                    btnMenuDispTime.Checked = false;
                    btnMenuDispDate.Checked = false;
                    btnMenuDispDateTime.Checked = false;
                    break;
                case 1:
                    Output.TimeStamps = ConsoleInterface.TimeStampFormat.Time;
                    btnMenuDispDataOnly.Checked = false;
                    btnMenuDispTime.Checked = true;
                    btnMenuDispDate.Checked = false;
                    btnMenuDispDateTime.Checked = false;
                    break;
                case 3:
                    Output.TimeStamps = ConsoleInterface.TimeStampFormat.Date;
                    btnMenuDispDataOnly.Checked = false;
                    btnMenuDispTime.Checked = false;
                    btnMenuDispDate.Checked = true;
                    btnMenuDispDateTime.Checked = false;
                    break;
                case 4:
                    Output.TimeStamps = ConsoleInterface.TimeStampFormat.DateTime;
                    btnMenuDispDataOnly.Checked = false;
                    btnMenuDispTime.Checked = false;
                    btnMenuDispDate.Checked = false;
                    btnMenuDispDateTime.Checked = true;
                    break;
            }
        }
        private void dataOnlyToolStripMenuItem_Click(object sender, EventArgs e) {
            SetFormat(dataOnlyToolStripMenuItem.Tag);
        }
        private void timeStampsToolStripMenuItem_Click(object sender, EventArgs e) {
            SetFormat(timeStampsToolStripMenuItem.Tag);
        }
        private void dateStampsToolStripMenuItem_Click(object sender, EventArgs e) {
            SetFormat(dateStampsToolStripMenuItem.Tag);
        }
        private void dateTimeStampsToolStripMenuItem_Click(object sender, EventArgs e) {
            SetFormat(dateTimeStampsToolStripMenuItem.Tag);
        }
        private void dataOnlyToolStripMenuItem1_Click(object sender, EventArgs e) {
            SetFormat(btnMenuDispDataOnly.Tag);
        }
        private void btnMenuDispTime_Click(object sender, EventArgs e) {
            SetFormat(btnMenuDispTime.Tag);
        }
        private void btnMenuDispDate_Click(object sender, EventArgs e) {
            SetFormat(btnMenuDispDate.Tag);
        }
        private void btnMenuDispDateTime_Click(object sender, EventArgs e) {
            SetFormat(btnMenuDispDateTime.Tag);
        }
        private void TopMostSetting() {
            btnTopMost.Checked = !btnTopMost.Checked;
            btnMenuTopMost.Checked = !btnMenuTopMost.Checked;
            this.TopMost = !this.TopMost;
        }
        private void topMostToolStripMenuItem_Click(object sender, EventArgs e) {
            btnTopMost.Checked = !btnTopMost.Checked;
            btnMenuTopMost.Checked = !btnMenuTopMost.Checked;
            this.TopMost = !this.TopMost;
        }
        private void toolStripButton2_Click(object sender, EventArgs e) {
            TopMostSetting();
        }

        private void btnClearTerminal_Click(object sender, EventArgs e) {
            Output.Clear();
        }
        private void btnMenuClearTerminal_Click(object sender, EventArgs e) {
            Output.Clear();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnMenuZoom050_Click(object sender, EventArgs e) {
            Output.Zoom = 50;
        }
        private void btnMenuZoom075_Click(object sender, EventArgs e) {
            Output.Zoom = 75;
        }
        private void btnMenuZoom100_Click(object sender, EventArgs e) {
            Output.Zoom = 100;
        }
        private void btnMenuZoom110_Click(object sender, EventArgs e) {
            Output.Zoom = 110;
        }
        private void btnMenuZoom120_Click(object sender, EventArgs e) {
            Output.Zoom = 120;
        }
        private void btnMenuZoom150_Click(object sender, EventArgs e) {
            Output.Zoom = 150;
        }
        private void btnMenuZoom200_Click(object sender, EventArgs e) {
            Output.Zoom = 200;
        }
        private void btnMenuZoom300_Click(object sender, EventArgs e) {
            Output.Zoom = 300;
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings ConfigApp = new Settings();
            ApplicationManager.OpenInternalApplicationOnce(ConfigApp, true);
        }


        string LogFile = "";
        bool IsRunning = false;
        long LogSize = 0;
        DateTime LoggingStart = DateTime.Now;
        DateTime LastEntry = DateTime.Now;
        int Interval = 10;
        List<string> FirstBuffer = new List<string>();
        List<string> SecondBuffer = new List<string>();
        bool WriteToFirst = true;

        #region Actions
        private void btnStartLog_Click(object sender, EventArgs e) {
            StartLogging();
        }
        private void btnStopLog_Click(object sender, EventArgs e) {
            StopLogging();
        }
        private void btnStartLogging_Click(object sender, EventArgs e) {
            StartLogging();
        }
        private void btnStopLogging_Click(object sender, EventArgs e) {
            StopLogging();
        }
        private void StartLogging() {
            IsRunning = true;
            btnStartLog.Enabled = false;
            btnStartLogging.Enabled = false;
            btnStopLog.Enabled = true;
            btnStopLogging.Enabled = true;
            btnSaveLog.Enabled = false;
            btnOpenLog.Enabled = false;
            //saveToolStripMenuItem.Enabled = false;
            //openToolStripMenuItem.Enabled = false;
            LoggingStart = DateTime.Now;
        }
        private void StopLogging() {
            IsRunning = false;
            btnStopLog.Enabled = false;
            btnStartLog.Enabled = true;
            btnStopLogging.Enabled = false;
            btnStartLogging.Enabled = true;
            btnSaveLog.Enabled = true;
            btnOpenLog.Enabled = true;
            //saveToolStripMenuItem.Enabled = true;
            //openToolStripMenuItem.Enabled = true;
        }
        #endregion
        #region File Handling
        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenLog();
        }
        private void btnSaveLog_Click(object sender, EventArgs e) {
            SaveLog();
        }
        private void OpenLog() {
            OpenFileDialog OpenDialog = new OpenFileDialog();
            OpenDialog.Filter = "Comma Seperated Values Document| *.csv";
            OpenDialog.Title = "Open Log";
            if (OpenDialog.ShowDialog() == DialogResult.OK) {
                try {
                    LogFile = OpenDialog.FileName;
                    IsRunning = false;
                    btnOpenLogLocation.Enabled = true;
                    btnStartLog.Enabled = true;
                    btnStopLog.Enabled = false;
                    btnStartLogging.Enabled = true;
                    btnStopLogging.Enabled = false;
                    btnSaveLog.Enabled = true;
                    btnOpenLog.Enabled = true;
                    if (manager != null) {
                        ChangeFormName(manager.StateName, LogFile);
                    }
                    LogSize = 0;
                    System.IO.StreamReader myStreamReader = System.IO.File.OpenText(LogFile); ;
                    try {
                        while (myStreamReader.Peek() > -1) {
                            myStreamReader.ReadLine();
                            LogSize++;
                        }
                    }
                    catch (Exception Ex) {
                        ExceptionHandler.PostMessage(ErrorType.M_Error, "LOG_CHK ->" + Ex.Message.ToString(), Application.ProductName, "Terminal", "TERM_LOG_CHK");
                    }
                    finally {
                        if (myStreamReader != null) {
                            myStreamReader.Dispose();
                        }
                    }
                }
                catch (Exception Ex) {
                    ExceptionHandler.PostMessage(ErrorType.M_Warning, "LOG_OPEN ->" + Ex.Message.ToString(), Application.ProductName, "Terminal", "TERM_LOG_OPEN");
                }
            }
        }
        private void SaveLog() {
            SaveFileDialog SaveDialog = new SaveFileDialog();
            SaveDialog.Filter = "Comma Seperated Values Document| *.csv";
            SaveDialog.Title = "Save Log";
            if (SaveDialog.ShowDialog() == DialogResult.OK) {
                try {
                    LogFile = SaveDialog.FileName;
                    using (StreamWriter Sw = new StreamWriter(LogFile, false)) {
                        List<CSVObject> Data = new List<CSVObject>();
                        Data.Add(new CSVObject("Date"));
                        Data.Add(new CSVObject("Time"));
                        Data.Add(new CSVObject("Data"));
                    }
                    IsRunning = false;
                    btnOpenLogLocation.Enabled = true;
                    btnStartLog.Enabled = true;
                    btnStopLog.Enabled = false;
                    btnStartLogging.Enabled = true;
                    btnStopLogging.Enabled = false;
                    if (manager != null) {
                        ChangeFormName(manager.StateName, LogFile);
                    }
                }
                catch (Exception Ex) {
                    ExceptionHandler.PostMessage(ErrorType.M_Warning, "LOG_SAVE ->" + Ex.Message.ToString(), Application.ProductName, "Terminal", "TERM_LOG_SAVE");
                }
            }
        }
        #endregion
        #region Data Logging
        private void LogUpdater_Tick(object sender, EventArgs e) {
            if (IsRunning == true) {
                if (ConversionHandler.DateIntervalDifference(LastEntry, DateTime.Now, ConversionHandler.Interval.Second) >= Interval) {
                    LastEntry = DateTime.Now;
                    LogNow();
                }
            }
        }
        private void LogNow() {
            if (System.IO.File.Exists(LogFile)) {
                try {
                    using (StreamWriter Sw = new StreamWriter(LogFile, true)) {
                        if (WriteToFirst == true) {
                            //Debug.Print("A");
                            //Read from second
                            if (SecondBuffer.Count > 0) {
                                for (int i = 0; i < SecondBuffer.Count; i++) {
                                    Sw.WriteLine(SecondBuffer[i]); LogSize++;
                                }
                            }
                            SecondBuffer.Clear();
                            WriteToFirst = false;
                        }
                        else {
                            //Debug.Print("B");
                            if (FirstBuffer.Count > 0) {
                                for (int i = 0; i < FirstBuffer.Count; i++) {
                                    Sw.WriteLine(FirstBuffer[i]); LogSize++;
                                }
                            }
                            FirstBuffer.Clear();
                            WriteToFirst = true;
                        }
                    }

                }
                catch (Exception Ex) {
                    ExceptionHandler.PostMessage(ErrorType.M_Error, "LOG_APPND ->" + Ex.Message.ToString(), Application.ProductName, "Terminal", "LOG_SAVE");
                }
            }
            else {
                ExceptionHandler.PostMessage(ErrorType.M_Warning, "LOG_APPND -> Log at " + LogFile + ", does not exist.", Application.ProductName, "Terminal", "LOG_SAVE");
            }
        }
        #endregion

        private void btnOpenLogLocation_Click(object sender, EventArgs e) {
            if (!File.Exists(LogFile)) {
                return;
            }
            string argument = "/select, \"" + LogFile + "\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

        private void msMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }

        private void Terminal_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void Terminal_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void Terminal_FormClosed(object sender, FormClosedEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }

        private void windowManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            WindowForms.WindowManager WindowMan = new WindowForms.WindowManager();
            Classes.ApplicationManager.OpenInternalApplicationOnce(WindowMan, true);
        }

        private void btnOptFrmLineNone_Click(object sender, EventArgs e) {
            SetLineFormat(LineFormatting.None);
        }
        private void btnOptFrmLineLF_Click(object sender, EventArgs e) {
            SetLineFormat(LineFormatting.LF);
        }
        private void btnOptFrmLineCRLF_Click(object sender, EventArgs e) {
            SetLineFormat(LineFormatting.CRLF);
        }
        private void btnOptFrmLineCR_Click(object sender, EventArgs e) {
            SetLineFormat(LineFormatting.CR);
        }
        private void SetLineFormat(LineFormatting Format) {
            if (manager != null) {
                manager.LineFormat = Format;
                SystemManager.CheckFormatOption(EnumManager.LineFormattingToString(manager.LineFormat), btnMenuTextFormat);
            }
        }
        private void CheckLineFormat() {
            if (manager != null) {
                SystemManager.CheckFormatOption(EnumManager.LineFormattingToString(manager.LineFormat), btnMenuTextFormat);
            }
        }
        private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
            if (manager != null) {
                manager.Connect();
            }
        }
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) {
            if (manager != null) {
                manager.Disconnect();
            }
        }
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            ApplicationManager.OpenSerialProperties(manager, false, true);
        }
        private void modbusMasterToolStripMenuItem_Click(object sender, EventArgs e) {
            if (manager != null) {
                manager.IsMaster = !manager.IsMaster;
            }
        }
        #region Bit Settings
        private void SetPortBits(int Bits) {
            if (manager != null) {
                manager.DataBits = Bits;
            }
            SystemManager.CheckFormatOption(Bits.ToString(), btnChannelDataBits);
        }
        private void btnChanDB5_Click(object sender, EventArgs e) {
            SetPortBits(5);
        }
        private void btnChanDB6_Click(object sender, EventArgs e) {
            SetPortBits(6);
        }
        private void btnChanDB7_Click(object sender, EventArgs e) {
            SetPortBits(7);
        }
        private void btnChanDB8_Click(object sender, EventArgs e) {
            SetPortBits(8);
        }
        #endregion
        #region Parity Settings
        private void SetPortParityBits(Parity PBits) {
            if (manager != null) {
                manager.Parity = PBits;
                SystemManager.CheckFormatOption(EnumManager.ParityToString(manager.Parity), btnChannelParity);
            }
        }
        private void btnChannelNoParity_Click(object sender, EventArgs e) {
            SetPortParityBits(Parity.None);
        }
        private void btnChannelEvenParity_Click(object sender, EventArgs e) {
            SetPortParityBits(Parity.Even);
        }
        private void btnChannelOddParity_Click(object sender, EventArgs e) {
            SetPortParityBits(Parity.Odd);
        }
        private void btnChannelSpaceParity_Click(object sender, EventArgs e) {
            SetPortParityBits(Parity.Space);
        }
        private void btnChannelMarkParity_Click(object sender, EventArgs e) {
            SetPortParityBits(Parity.Mark);
        }
        #endregion
        #region Stop Bit Settings
        private void SetPortStopBits(StopBits StopBts) {
            if (manager != null) {
                manager.StopBits = StopBts;
                SystemManager.CheckFormatOption(EnumManager.StopBitsToString(manager.StopBits), btnChannelStopBits);
            }
        }
        private void btnChannelStopBits1_Click(object sender, EventArgs e) {
            SetPortStopBits(StopBits.One);
        }
        private void btnChannelStopBits15_Click(object sender, EventArgs e) {
            SetPortStopBits(StopBits.OnePointFive);
        }
        private void btnChannelStopBits2_Click(object sender, EventArgs e) {
            SetPortStopBits(StopBits.Two);
        }
        #endregion
        #region Baud Rates
        private void LoadBAUDRate(int Rate) {
            ToolStripMenuItem BaudRateBtn2 = new ToolStripMenuItem();
            BaudRateBtn2.Text = Rate.ToString();
            BaudRateBtn2.Tag = Rate;
            BaudRateBtn2.ImageScaling = ToolStripItemImageScaling.None;
            BaudRateBtn2.Click += BaudRateBtn_Click;
            btnChannelBaudVals.DropDownItems.Add(BaudRateBtn2);
        }
        private void BaudRateBtn_Click(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
                if (Tsmi.Tag == null) { return; }
                if (manager != null) {
                    manager.BaudRate = int.Parse(Tsmi.Tag.ToString() ?? "9600");
                    SystemManager.CheckFormatOption(manager.BaudRate, btnChannelBaudVals);
                }
            }
        }
        #endregion
        #region Ports
        private void CleanHandlers() {
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
            if (manager != null) {
                SystemManager.CheckFormatOption(manager.PortName, btnChannelPort);
            }
        }
        private bool ItemExists(string Name) {
            foreach (object Item in btnChannelPort.DropDownItems) {
                if (Item.GetType() == typeof(ToolStripMenuItem)) {
                    ToolStripMenuItem Tsmi = (ToolStripMenuItem)Item;
                    if (Tsmi.Tag == null) { continue; }
                    if (((ToolStripMenuItem)Item).Tag != null) {
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
                if (manager != null) {
                    SelectedPort = Tsmi.Tag.ToString() ?? "COM1";
                    manager.PortName = SelectedPort;
                }
                SystemManager.CheckFormatOption(SelectedPort, btnChannelPort);
            }
        }
        private void btnChannelPort_DropDownOpening(object sender, EventArgs e) {
            RefreshPorts();
        }
        #endregion
        #region Control Flow Settings
        private void SetControlFlow(Handshake HandShake) {
            if (manager != null) {
                manager.Handshake = HandShake;
                SystemManager.CheckFormatOption(EnumManager.HandshakeToString(manager.Handshake), btnChannelFlowCtrl);
            }
        }
        private void btnChannelFlowNone_Click(object sender, EventArgs e) {
            SetControlFlow(Handshake.None);
        }
        private void btnChannelFlowXONXOFF_Click(object sender, EventArgs e) {
            SetControlFlow(Handshake.XOnXOff);
        }
        private void btnChannelFlowRTSCTS_Click(object sender, EventArgs e) {
            SetControlFlow(Handshake.RequestToSend);
        }
        private void btnChannelFlowDSRDTR_Click(object sender, EventArgs e) {
            SetControlFlow(Handshake.RequestToSendXOnXOff);
        }
        #endregion
        #region IO Formats
        private void InputFormat_Click(object? sender, EventArgs e) {
            if (sender == null) { return; }
            ToolStripItem Tsi = (ToolStripItem)sender;
            if (Tsi.Tag == null) { return; }
            InputFormatChange(Tsi.Tag.ToString() ?? "");
        }
        private void OutputFormat_Click(object? sender, EventArgs e) {
            if (sender == null) { return; }
            ToolStripItem Tsi = (ToolStripItem)sender;
            if (Tsi.Tag == null) { return; }
            OutputFormatChange(Tsi.Tag.ToString() ?? "");
        }
        private void InputFormatChange(string? ControlText) {
            if (ControlText == null) { return; }
            StreamInputFormat FormatPair = EnumManager.StringToInputFormat(ControlText);
            StringPair TextualPair = EnumManager.InputFormatToString(FormatPair, false);
            if (manager != null) {
                manager.InputFormat = FormatPair;
                SystemManager.CheckFormatOption(ControlText, btnChannelInputFormat);
            }
        }
        private void OutputFormatChange(string? ControlText) {
            if (ControlText == null) { return; }
            StreamOutputFormat FormatPair = EnumManager.StringToOutputFormat(ControlText);
            StringPair TextualPair = EnumManager.OutputFormatToString(FormatPair, false);
            if (manager != null) {
                manager.OutputFormat = FormatPair;
                SystemManager.CheckFormatOption(ControlText, btnChannelOutputFormat);
            }
        }
        #endregion

        private void outputInMasterTerminalToolStripMenuItem_Click(object sender, EventArgs e) {
            if (manager != null) {
                manager.OutputToMasterTerminal = !manager.OutputToMasterTerminal;
            }
        }
        private void allowEscapeCharToolStripMenuItem_Click(object sender, EventArgs e) {
            if (manager != null) {
                manager.AllowEscapeCharacters = !manager.AllowEscapeCharacters;
            }
        }
    }
}
