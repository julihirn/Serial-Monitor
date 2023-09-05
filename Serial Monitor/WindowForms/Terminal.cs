using ODModules;
using Serial_Monitor.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.WindowForms {
    public partial class Terminal : Form, Interfaces.ITheme {
        SerialManager ?manager = null;
        private SerialManager ?Manager {
            get { return manager; }
        }
        public Terminal(SerialManager Manager) {
            this.manager = Manager;
            Manager.CommandProcessed += Manager_CommandProcessed;
            Manager.DataReceived += Manager_DataReceived;
            Manager.NameChanged += Manager_NameChanged;
            InitializeComponent();
            ChangeFormName(manager.StateName);
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            AddIcons();
        }

        private void Manager_NameChanged(object sender, string Data) {
            if (manager == null) { return; }
            ChangeFormName(manager.StateName);
        }
        private void ChangeFormName(string Item) {
            if (Item.Length == 0) { Text = "Terminal"; }
            Text = Item + " - Terminal";
        }
        private void Manager_DataReceived(object sender, bool PrintLine, string Data) {
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
        private void Manager_CommandProcessed(object sender, string Data) {
            string SourceName = "";
            if (sender.GetType() == typeof(SerialManager)) {
                SerialManager SM = (SerialManager)sender;
                SourceName = SM.Port.PortName;
            }
            Output.Print(SourceName, Data);
        }
        private void Terminal_Load(object sender, EventArgs e) {
            RecolorAll();
        }
        public void ApplyTheme() {

            RecolorAll();
            AddIcons();
        }
        private void AddIcons() {
            DesignerSetup.LinkSVGtoControl(Properties.Resources.ClearWindowContent, btnClearTerminal, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.BringForward, btnTopMost, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
        }
        private void RecolorAll() {
            ApplicationManager.IsDark = Properties.Settings.Default.THM_SET_IsDark;
            this.SuspendLayout();
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            Output.ForeColor = Properties.Settings.Default.THM_COL_TerminalForeColor;

            Output.BackColor = Properties.Settings.Default.THM_COL_Editor;

            Output.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
            Output.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;

            tsMain.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.MenuBackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.MenuBackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.ItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            tsMain.ItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            tsMain.StripItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            tsMain.StripItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            tsMain.MenuBorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            tsMain.MenuSeparatorColor = Properties.Settings.Default.THM_COL_SeperatorColor;
            tsMain.MenuSymbolColor = Properties.Settings.Default.THM_COL_SymbolColor;

            tsMain.ItemCheckedBackColorNorth = Properties.Settings.Default.THM_COL_SymbolColor;
            tsMain.ItemCheckedBackColorSouth = Properties.Settings.Default.THM_COL_SymbolColor;

            tsMain.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            tsMain.ItemForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            tsMain.ItemSelectedForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            foreach(ToolStripItem Itm in tsMain.Items) {
                Itm.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            }
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
                if (MItem.Tag != null){
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
                    break;
                case 1:
                    Output.TimeStamps = ConsoleInterface.TimeStampFormat.Time;
                    break;
                case 3:
                    Output.TimeStamps = ConsoleInterface.TimeStampFormat.Date;
                    break;
                case 4:
                    Output.TimeStamps = ConsoleInterface.TimeStampFormat.DateTime;
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
        private void TopMostSetting() {
            btnTopMost.Checked = !btnTopMost.Checked;
            //btnMenuTopMost.Checked = !btnMenuTopMost.Checked;
            this.TopMost = !this.TopMost;
        }
        private void toolStripButton2_Click(object sender, EventArgs e) {
            TopMostSetting();
        }

        private void btnClearTerminal_Click(object sender, EventArgs e) {
            Output.Clear();
        }
    }
}
