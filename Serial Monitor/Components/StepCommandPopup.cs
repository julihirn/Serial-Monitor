using Handlers;
using ODModules;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Classes.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.Components {
    public partial class StepCommandPopup : TemplateContextMenu, Interfaces.ITheme {
        public TemplateContextMenuHost? Host = null;
        StepEnumerations.StepExecutable stepexe = StepEnumerations.StepExecutable.NoOperation;
        public StepEnumerations.StepExecutable Command {
            get { return stepexe; }
            set { stepexe = value; }
        }
        public StepCommandPopup() {
            InitializeComponent();
            ProgramEditing.LoadProgramOperations(lstCommands);
            ApplyTheme();
        }
        public void ApplyTheme() {
            ThemeManager.ThemeControl(lstCommands);
            ThemeManager.ThemeControl(sltbSearch);
        }
        private void StepCommandPopup_Load(object sender, EventArgs e) {

        }

        private void sltbSearch_TextChanged(object sender, EventArgs e) {
            lstCommands.Filter = (sltbSearch.Text ?? "").TrimEnd();
        }

        private void lstCommands_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            if (e.ParentItem == null) { return; }
            if (e.ParentItem.Tag == null) { return; }
            if (e.ParentItem.Tag.GetType() != typeof(StepEnumerations.StepExecutable)) { return; }
            stepexe = (StepEnumerations.StepExecutable)e.ParentItem.Tag;
            Accept();
        }
        private void lstCommands_KeyDown(object sender, KeyEventArgs e) {

        }
        private void Accept() {
            if (Host != null) {
                Host.Close();
            }
        }
        DateTime LastKeyDown = DateTime.MinValue;
        string DropDownSearchString = "";
        int LastSelectedCell = -1;
        int LastSelectedRow = -1;
        private void lstCommands_KeyPress(object sender, KeyPressEventArgs e) {
            if ((e.KeyChar == ' ') || (e.KeyChar == '\r')) {
                lstCommands.SelectDropForward(0, 0, true);
            }
            if (Char.IsLetterOrDigit(e.KeyChar) || (e.KeyChar == '\b')) {
                if (ConversionHandler.DateIntervalDifference(LastKeyDown, DateTime.UtcNow, ConversionHandler.Interval.Second) > 1) {
                    DropDownSearchString = "";
                }
                if ((LastSelectedCell != lstCommands.SelectedCell.X) || (LastSelectedRow != lstCommands.SelectedCell.Y)) {
                    DropDownSearchString = "";
                }
                LastSelectedCell = lstCommands.SelectedCell.X;
                LastSelectedRow = lstCommands.SelectedCell.Y;
                if (e.KeyChar != '\b') {
                    DropDownSearchString += e.KeyChar;
                }
                sltbSearch.Text += DropDownSearchString;
                sltbSearch.Focus();
                LastKeyDown = DateTime.UtcNow;
            }
        }
        private void sltbSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '\r') {
                lstCommands.ResetCellSelectionComplete();
                try {
                    if (lstCommands.SelectedCell == new Point(-1, -1)) {
                        lstCommands.SelectDropForward(1, 1, true);
                    }
                    else if (lstCommands.SelectedCell == new Point(-1, 0)) {
                        lstCommands.SelectDropForward(1, 0, true);
                    }
                    else if (lstCommands.SelectedCell == new Point(0, -1)) {
                        lstCommands.SelectDropForward(0, 1, true);
                    }
                    else if (lstCommands.SelectedCell.X == -1) {
                        lstCommands.SelectDropForward(1, 0, true);
                    }
                    else {
                        lstCommands.SelectDropForward(0, 0, true);
                    }
                    Accept();
                }
                catch { }
            }
        }

        private void lstCommands_Load(object sender, EventArgs e) {

        }
    }
}
