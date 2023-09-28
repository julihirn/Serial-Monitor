using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Serial_Monitor.WindowForms {
    public partial class Terminal : Form, Interfaces.ITheme {
        SerialManager? manager = null;
        private SerialManager? Manager {
            get { return manager; }
        }
        public Terminal(SerialManager Manager) {
            this.manager = Manager;
            Manager.CommandProcessed += Manager_CommandProcessed;
            Manager.DataReceived += Manager_DataReceived;
            Manager.NameChanged += Manager_NameChanged;
            InitializeComponent();
            ChangeFormName(manager.StateName, "");
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            AddIcons();
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
                SourceName = SM.Port.PortName;
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
                SourceName = SM.Port.PortName;
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
        private void SetFormat(object Index) {
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
    }
}
