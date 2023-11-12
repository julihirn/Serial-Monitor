using Handlers.ShadowX;
using Handlers;
using ODModules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Serial_Monitor.Classes;
using System.DirectoryServices.ActiveDirectory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Serial_Monitor {
    public partial class Monitor : Form, Interfaces.ITheme {
        public Form? Attached = null;
        public Monitor() {
            InitializeComponent();
            lstMonitor.Items.Clear();
        }
        #region User Interface and Loading
        private void Monitor_Load(object sender, EventArgs e) {
            RecolorAll();
            AddIcons();
            if (Attached != null) {
                if (Attached.GetType() == typeof(MainWindow)) {
                    ((MainWindow)Attached).CommandProcessed += Monitor_CommandProcessed;
                }
            }
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            AdjustUserInterface();
        }
        private void AdjustUserInterface() {
            msMain.Padding = DesignerSetup.ScalePadding(msMain.Padding);
            tsMain.Padding = DesignerSetup.ScalePadding(tsMain.Padding);
            lstMonitor.ScaleColumnWidths();
            lstSelector.ScaleColumnWidths();
           
            //pnlMonitor.Panel1.Width = DesignerSetup.ScaleInteger(pnlMonitor.Panel1.Width);
        }
        private void Monitor_FormClosing(object sender, FormClosingEventArgs e) {
            if (Attached != null) {
                if (Attached.GetType() == typeof(MainWindow)) {
                    ((MainWindow)Attached).CommandProcessed -= Monitor_CommandProcessed;
                }
            }
            lstMonitor.LineRemoveAll();
            lstSelector.LineRemoveAll();
            GC.Collect();
        }
        public void AddIcons() {
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Save_16x, btnSaveLog, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.OpenFile_16x, btnOpenLog, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Save_16x, saveToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.OpenFile_16x, openToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));


            DesignerSetup.LinkSVGtoControl(Properties.Resources.Paste, btnOpenLogLocation, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, btnStartLog, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, btnStopLog, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, startLoggingToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, stopLoggingToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Add, addToMonitorToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, removeFromMonitorToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.ExcelWorksheetView, btnOpenExcelDoc, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.BringForward, btnOnTop, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));


            DesignerSetup.LinkSVGtoControl(Properties.Resources.Small, btnOptRegSingleMode, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.ItemListView, btnOptRegMultiMode, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.Timeline, showlastupdate, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
        }
        #endregion
        string LogFile = "";
        bool IsRunning = false;
        long LogSize = 0;
        DateTime LoggingStart = DateTime.Now;
        DateTime LastEntry = DateTime.Now;
        int Interval = 10;
        #region Theme
        public void ApplyTheme() {

            RecolorAll();
            AddIcons();
        }
        private void RecolorAll() {
            ApplicationManager.IsDark = Properties.Settings.Default.THM_SET_IsDark;
            this.SuspendLayout();

            BackColor = Properties.Settings.Default.THM_COL_Editor;
            txtbxSearch.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            txtbxSearch.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            Classes.Theming.ThemeManager.ThemeControl(msMain);
            Classes.Theming.ThemeManager.ThemeControl(tsMain);

            Classes.Theming.ThemeManager.ThemeControl(lstSelector);

            Classes.Theming.ThemeManager.ThemeControl(lstMonitor);
            pnlMonitor.BackColor = Properties.Settings.Default.THM_COL_Editor;

            this.ResumeLayout();
        }
        #endregion
        #region Actions
        private void btnSaveLog_Click(object sender, EventArgs e) {
            SaveLog();
        }
        private void btnOpenLog_Click(object sender, EventArgs e) {
            OpenLog();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveLog();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenLog();
        }
        private void OpenLogLocation() {
            if (!File.Exists(LogFile)) {
                return;
            }
            string argument = "/select, \"" + LogFile + "\"";
            System.Diagnostics.Process.Start("explorer.exe", argument);
        }
        private void btnOpenLogLocation_Click(object sender, EventArgs e) {
            OpenLogLocation();
        }
        private void openLogLocationToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenLogLocation();
        }
        private void btnOpenExcelDoc_Click(object sender, EventArgs e) {
            try {
                Type? officeType = Type.GetTypeFromProgID("Excel.Application");
                if (officeType == null) { return; }
                bool CurrentLogState = IsRunning;
                if (officeType != null) {
                    IsRunning = false;
                    btnStartLog.Enabled = true;
                    btnStopLog.Enabled = false;
                    startLoggingToolStripMenuItem.Enabled = true;
                    stopLoggingToolStripMenuItem.Enabled = false;
                    btnSaveLog.Enabled = true;
                    btnOpenLog.Enabled = true;

                    if (File.Exists(LogFile)) {
                        string NewPath = Path.GetDirectoryName(LogFile) + @"\" + Path.GetFileNameWithoutExtension(LogFile) + @"_extract_" + DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss") + Path.GetExtension(LogFile);
                        File.Copy(LogFile, NewPath);
                        Process.Start(NewPath);
                    }


                    if (CurrentLogState == true) {
                        btnStartLog.Enabled = false;
                        btnStopLog.Enabled = true;
                        startLoggingToolStripMenuItem.Enabled = false;
                        stopLoggingToolStripMenuItem.Enabled = true;
                        IsRunning = CurrentLogState;
                    }
                }
            }
            catch { }
        }
        private void StartLog() {
            IsRunning = true;
            startLoggingToolStripMenuItem.Enabled = false;
            stopLoggingToolStripMenuItem.Enabled = true;
            btnStartLog.Enabled = false;
            btnStopLog.Enabled = true;
            btnSaveLog.Enabled = false;
            btnOpenLog.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            openToolStripMenuItem.Enabled = false;
            LoggingStart = DateTime.Now;
        }
        private void StopLog() {
            IsRunning = false;
            btnStopLog.Enabled = false;
            btnStartLog.Enabled = true;
            startLoggingToolStripMenuItem.Enabled = true;
            stopLoggingToolStripMenuItem.Enabled = false;
            btnSaveLog.Enabled = true;
            btnOpenLog.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            openToolStripMenuItem.Enabled = true;
        }
        private void btnStartLog_Click(object sender, EventArgs e) {
            StartLog();
        }
        private void startLoggingToolStripMenuItem_Click(object sender, EventArgs e) {
            StartLog();
        }
        private void stopLoggingToolStripMenuItem_Click(object sender, EventArgs e) {
            StopLog();
        }
        private void btnStopLog_Click(object sender, EventArgs e) {
            StopLog();
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
                        foreach (Column Col in lstMonitor.Columns) {
                            Data.Add(new CSVObject(Col.Text));
                        }
                        Sw.WriteLine(WriteCSVLine(Data));
                    }
                    IsRunning = false;
                    btnOpenLogLocation.Enabled = true;
                    openLogLocationToolStripMenuItem.Enabled = true;
                    btnStartLog.Enabled = true;
                    btnStopLog.Enabled = false;
                    startLoggingToolStripMenuItem.Enabled = true;
                    stopLoggingToolStripMenuItem.Enabled = false;
                    btnOpenExcelDoc.Enabled = true;
                    this.Text = Path.GetFileNameWithoutExtension(LogFile) + " - Monitor";
                }
                catch (Exception Ex) {
                    ExceptionHandler.PostMessage(ErrorType.M_Warning, "LOG_SAVE ->" + Ex.Message.ToString(), Application.ProductName, "Monitor", "MON_LOG_SAVE");
                }
            }
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
                    openLogLocationToolStripMenuItem.Enabled = true;
                    btnStartLog.Enabled = true;
                    btnStopLog.Enabled = false;
                    startLoggingToolStripMenuItem.Enabled = true;
                    stopLoggingToolStripMenuItem.Enabled = false;
                    btnOpenExcelDoc.Enabled = true;
                    btnSaveLog.Enabled = true;
                    btnOpenLog.Enabled = true;

                    this.Text = Path.GetFileNameWithoutExtension(LogFile) + " - Monitor";
                    LogSize = 0;
                    System.IO.StreamReader myStreamReader = System.IO.File.OpenText(LogFile); ;
                    try {
                        while (myStreamReader.Peek() > -1) {
                            myStreamReader.ReadLine();
                            LogSize++;
                        }
                    }
                    catch (Exception Ex) {
                        ExceptionHandler.PostMessage(ErrorType.M_Error, "LOG_CHK ->" + Ex.Message.ToString(), Application.ProductName, "Monitor", "MON_LOG_CHK");
                    }
                    finally {
                        if (myStreamReader != null) {
                            myStreamReader.Dispose();
                        }
                    }
                }
                catch (Exception Ex) {
                    ExceptionHandler.PostMessage(ErrorType.M_Warning, "LOG_OPEN ->" + Ex.Message.ToString(), Application.ProductName, "Monitor", "MON_LOG_OPEN");
                }
            }
        }


        private void btnOnTop_Click(object sender, EventArgs e) {
            this.TopMost = !this.TopMost;
            btnOnTop.Checked = !btnOnTop.Checked;
        }
        #endregion
        #region Logging
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
                        foreach (ListItem Li in lstMonitor.Items) {
                            List<CSVObject> Data = new List<CSVObject>();
                            DateTime Now = DateTime.Now;
                            Data.Add(new CSVObject(Now.ToString("dd/MM/yyyy")));
                            Data.Add(new CSVObject(Now.ToString("HH:mm:ss")));
                            Data.Add(new CSVObject(Li.Text));
                            Data.Add(new CSVObject(Li.SubItems[0].Text));
                            Data.Add(new CSVObject(Li.SubItems[1].Text));
                            Data.Add(new CSVObject(Li.SubItems[2].Text));
                            Sw.WriteLine(WriteCSVLine(Data));
                            LogSize++;
                        }
                    }

                }
                catch (Exception Ex) {
                    ExceptionHandler.PostMessage(ErrorType.M_Error, "LOG_APPND ->" + Ex.Message.ToString(), Application.ProductName, "Monitor", "LOG_SAVE");
                }
            }
            else {
                ExceptionHandler.PostMessage(ErrorType.M_Warning, "LOG_APPND -> Log at " + LogFile + ", does not exist.", Application.ProductName, "Monitor", "LOG_SAVE");
            }
        }
        private string WriteCSVLine(List<CSVObject> Data) {
            string Output = "";
            if (Data.Count > 0) {
                for (int i = 0; i < Data.Count; i++) {
                    Output += Data[i].ToString();
                    if (i < Data.Count - 1) {
                        Output += ",";
                    }
                }
            }
            return Output;
        }
        #endregion

        private void DisplayUpdater_Tick(object sender, EventArgs e) {
            if (ActorAdded == true) {
                ActorAdded = false;
                lstSelector.Invalidate();
            }
            try {
                foreach (ListItem Lvi in lstMonitor.Items) {
                    if (Lvi.Tag != null) {
                        if (Lvi.Tag.GetType() == typeof(DataObject)) {
                            DataObject Dobj = (DataObject)Lvi.Tag;
                            if (Dobj.Type != MonitorDataType.Actor) {

                            }
                            if (Dobj.Assignment != Dobj.AssignmentPrevious) {
                                Dobj.MatchPreviousAssignment();

                                Lvi.SubItems[1].Text = Dobj.Assignment;
                            }
                            else {

                            }
                            if (ConversionHandler.DateIntervalDifference(Dobj.LastChanged, DateTime.Now, ConversionHandler.Interval.Second) > 1) {
                                Lvi.SubItems[1].BackColor = Color.Transparent;
                            }
                            else {
                                Lvi.SubItems[1].BackColor = Properties.Settings.Default.THM_COL_MonitorChanged;
                            }
                            Lvi.SubItems[2].Text = Dobj.LastUpdated.ToString("HH:mm:ss");
                        }
                    }
                }
            }
            catch { }
            lstMonitor.Invalidate();
        }

        

        private void Monitor_CommandProcessed(object sender, string Data) {
            if (sender.GetType() == typeof(Classes.SerialManager)) {
                SerialManager SerMan = (Classes.SerialManager)sender;
                string Port = SerMan.PortName;
                string Name = "";
                string Assignment = "";
                if (Data.Contains("=")) {
                    Name = Data.Split('=')[0];
                    Assignment = Data.Split('=')[1];
                }
                else {
                    Name = Data;
                }
                AssignActor(Port, Name, Assignment);
            }
        }
        #region Adding and Removing Monitor
        bool ActorAdded = false;
        private void AssignActor(string Port, string Name, string Assignment) {
            bool ItemExists = false;
            try {
                foreach (ListItem Item in lstSelector.Items) {
                    if (Item.Tag != null) {
                        if (Item.Tag.GetType() == typeof(DataObject)) {
                            DataObject Dobj = ((DataObject)Item.Tag);
                            if ((Dobj.Name == Name) && (Dobj.Port == Port)) {
                                Dobj.Assignment = Assignment;
                                ItemExists = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch { }
            if (ItemExists == false) {
                ListItem LstItem = new ListItem();
                LstItem.SubItems.Add(new ListSubItem(Port));
                LstItem.SubItems.Add(new ListSubItem(Name));
                LstItem.SubItems.Add(new ListSubItem("Actor"));
                LstItem.Tag = new DataObject(Port, Name, Assignment);
                lstSelector.Items.Add(LstItem);
                ActorAdded = true;
            }
        }
        private void lstSelector_MouseClick(object sender, MouseEventArgs e) {
            foreach (ListItem Item in lstSelector.Items) {
                if (Item.Tag != null) {
                    if (Item.Tag.GetType() == typeof(DataObject)) {
                        DataObject Dobj = ((DataObject)Item.Tag);
                        if (Item.CheckedChanged == true) {
                            Item.ResetChangedChanged();
                            if (Item.Checked == true) {
                                AddActorToMonitor(Dobj);
                            }
                            else {
                                DeleteActorToMonitor(Dobj);
                            }
                        }
                    }
                }
            }
        }
        private void AddActorToMonitor(DataObject Din) {
            bool ExistsInList = false;
            foreach (ListItem Item in lstMonitor.Items) {
                if (Item.Tag != null) {
                    if (Item.Tag.GetType() == typeof(DataObject)) {
                        DataObject Dobj = ((DataObject)Item.Tag);
                        if (Din.Equals(Dobj)) {
                            ExistsInList = true;
                            break;
                        }
                    }
                }
            }
            if (ExistsInList == false) {
                ListItem lstItemRegName = new ListItem(Din.Name);
                ListSubItem lstSubItemPort = new ListSubItem(Din.Port);
                ListSubItem lstSubItemData = new ListSubItem(Din.Assignment);
                lstSubItemData.Tag = Din.Assignment;
                ListSubItem lstSubItemDate = new ListSubItem(Din.LastUpdated.ToString("HH:mm:ss"));
                lstItemRegName.SubItems.Add(lstSubItemPort);
                lstItemRegName.SubItems.Add(lstSubItemData);
                lstItemRegName.SubItems.Add(lstSubItemDate);
                lstItemRegName.Tag = Din;
                lstMonitor.Items.Add(lstItemRegName);
            }
        }
        private void DeleteActorToMonitor(DataObject Din) {
            int RemoveIndex = -1;
            for (int i = lstMonitor.Items.Count - 1; i >= 0; i--) {
                if (lstMonitor.Items[i].Tag != null) {
                    object? Tg = lstMonitor.Items[i].Tag;
                    if (Tg != null) {
                        if (Tg.GetType() == typeof(DataObject)) {
                            DataObject Dobj = ((DataObject)Tg);
                            if (Din.Equals(Dobj)) {
                                RemoveIndex = i;
                                lstMonitor.Items.RemoveAt(RemoveIndex);
                            }
                        }
                    }
                }
            }
            //if (RemoveIndex >= 0) {
            //    lstMonitor.Items.RemoveAt(RemoveIndex);
            //}
        }
        private void addToMonitorToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (ListItem Item in lstSelector.Items) {
                if (Item.Selected == true) {
                    if (Item.Tag != null) {
                        if (Item.Tag.GetType() == typeof(DataObject)) {
                            DataObject Dobj = ((DataObject)Item.Tag);
                            Item.Checked = true;
                            if (Item.CheckedChanged == true) {
                                Item.ResetChangedChanged();
                                AddActorToMonitor(Dobj);
                            }
                        }
                    }
                }
            }
        }
        private void removeFromMonitorToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (ListItem Item in lstSelector.Items) {
                if (Item.Selected == true) {
                    if (Item.Tag != null) {
                        if (Item.Tag.GetType() == typeof(DataObject)) {
                            DataObject Dobj = ((DataObject)Item.Tag);
                            Item.Checked = false;
                            if (Item.CheckedChanged == true) {
                                Item.ResetChangedChanged();
                                DeleteActorToMonitor(Dobj);
                            }
                        }
                    }
                }
            }
        }
        #endregion
        private void btnOptRegSingleMode_Click(object sender, EventArgs e) {
            if (btnOptRegSingleMode.Checked == true) {
                btnOptRegMultiMode.Checked = false;
            }
            else {
                btnOptRegMultiMode.Checked = true;
            }
        }
        private void btnOptRegMultiMode_Click(object sender, EventArgs e) {
            if (btnOptRegMultiMode.Checked == true) {
                btnOptRegSingleMode.Checked = false;
            }
            else {
                btnOptRegSingleMode.Checked = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            lstSelector.Filter = txtbxSearch.Text;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Monitor_Load_1(object sender, EventArgs e) {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings ConfigApp = new Settings();
            ApplicationManager.OpenInternalApplicationOnce(ConfigApp, true);
        }

        private void Monitor_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void Monitor_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void Monitor_FormClosed(object sender, FormClosedEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }

        private void searchAvaliableRegistersToolStripMenuItem_Click(object sender, EventArgs e) {
            txtbxSearch.Show();
        }
        private void txtbxSearch_KeyPress(object sender, KeyPressEventArgs e) {

        }
        private void txtbxSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                txtbxSearch.Hide();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void windowManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            WindowForms.WindowManager WindowMan = new WindowForms.WindowManager();
            Classes.ApplicationManager.OpenInternalApplicationOnce(WindowMan, true);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e) {

        }
    }
    public enum MonitorDataType {
        Actor = 0x01,
        ModbusCoil = 0x02,
        ModbusDiscrete = 0x03,
        ModbusInputRegister = 0x04,
        ModbusHoldingReegister = 0x05
    }
    public class DataObject {
        public DataObject(string Port, string Name, string Assignment) {
            this.port = Port;
            this.name = Name;
            this.assignment = Assignment;
        }
        public DataObject(string Port, string Name) {
            this.port = Port;
            this.name = Name;
        }
        MonitorDataType type = MonitorDataType.Actor;
        public MonitorDataType Type {
            get { return type; }
        }
        string port = "";
        public string Port {
            get { return port; }
            set { port = value; }
        }
        string name = "";
        public string Name {
            get { return name; }
            set { name = value; }
        }
        DateTime lastUpdated = DateTime.Now;
        public DateTime LastUpdated {
            get { return lastUpdated; }
        }
        DateTime lastChanged = DateTime.Now;
        public DateTime LastChanged {
            get { return lastChanged; }
        }
        string assignmentPrevious = "";
        string assignment = "";
        public string AssignmentPrevious {
            get { return assignmentPrevious; }
        }
        public void MatchPreviousAssignment() {
            assignmentPrevious = assignment;
        }
        public string Assignment {
            get { return assignment; }
            set {
                assignmentPrevious = assignment;
                assignment = value;
                if (assignmentPrevious != value) {
                    lastChanged = DateTime.Now;
                }
                lastUpdated = DateTime.Now;
            }
        }
        public bool Equals(DataObject? Dobj) {
            if (Dobj == null) { return false; }
            if ((Dobj.Name == this.name) && (Dobj.Port == this.port)) {
                return true;
            }
            return false;
        }
    }
}
