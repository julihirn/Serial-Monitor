using ODModules;
using Serial_Monitor.Classes.Theming;
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
    public partial class TextComparator : Components.SkinnedForm, Interfaces.ITheme {
        public TextComparator() {
            InitializeComponent();
        }
        private void AdjustUserInterface() {
            labelPanel1.InlineWidth = DesignerSetup.ScaleInteger(labelPanel1.InlineWidth);
            labelPanel2.InlineWidth = DesignerSetup.ScaleInteger(labelPanel2.InlineWidth);
            //lstMonitor.ScaleColumnWidths();
        }
        private void TextComparator_Load(object sender, EventArgs e) {
            ApplyTheme();
            AdjustUserInterface();
        }
        public void ApplyTheme() {
            RecolorAll();
            AddIcons();
        }
        private void AddIcons() {
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Cut, cmiTextBoxCut, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Cut, cutToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Copy, cmiTextBoxCopy, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Copy, copyToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Paste, pasteToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Paste, cmiTextBoxPaste, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Cancel, deleteToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Cancel, cmiTextBoxDelete, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.SelectAll, cmiTextBoxSelectAll, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.SelectAll, selectAllToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));


        }
        private void RecolorAll() {

            labelPanel1.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            labelPanel1.LabelBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            labelPanel1.BackColor = Properties.Settings.Default.THM_COL_Editor;

            labelPanel2.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            labelPanel2.LabelBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            labelPanel2.BackColor = Properties.Settings.Default.THM_COL_Editor;

            ThemeManager.ThemeControl(sltbCompareFrom);
            ThemeManager.ThemeControl(sltbCompareTo);
            ThemeManager.ThemeControl(msMain);
            ThemeManager.ThemeControl(cmTextboxOptions);
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            txtComparer.BackColor = Properties.Settings.Default.THM_COL_Editor;
            txtComparer.EmptyTextColor = Properties.Settings.Default.THM_COL_Editor;
            //kpCommands.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            //kpCommands.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            //kpCommands.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            txtComparer.GridColor = Properties.Settings.Default.THM_COL_SeperatorColor;
            txtComparer.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            txtComparer.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
            txtComparer.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;

            txtComparer.SameColor = Properties.Settings.Default.THM_COL_Match;
            txtComparer.DifferenceColor = Properties.Settings.Default.THM_COL_Mismatched;
            //kpCommands.BorderColorNorth = Properties.Settings.Default.THM_COL_BorderColor;
            //kpCommands.BorderColorSouth = Properties.Settings.Default.THM_COL_BorderColor;
            //
            //kpCommands.BackColorHoverNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            //kpCommands.BackColorHoverSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            lstMonitor.ColumnForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            lstMonitor.BackColor = Properties.Settings.Default.THM_COL_Editor;
            lstMonitor.RowColor = Properties.Settings.Default.THM_COL_RowColor;
            lstMonitor.GridlineColor = Properties.Settings.Default.THM_COL_GridLineColor;
            lstMonitor.ColumnColor = Properties.Settings.Default.THM_COL_MenuBack;
            lstMonitor.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
            lstMonitor.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;
            lstMonitor.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            lstMonitor.SelectedColor = Properties.Settings.Default.THM_COL_SelectedColor;
            lstMonitor.ColumnLineColor = Properties.Settings.Default.THM_COL_ColumnSeperatorColor;

            TitleBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            TitleForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            InactiveBorderColor = Properties.Settings.Default.THM_COL_MenuBack;
            ActiveBorderColor = Properties.Settings.Default.THM_COL_SelectedColor;

        }
        private void Reevaluate() {
            try {
                int MaxLen = txtComparer.MaximumLength + 1;
                lstMonitor.Items[0][1].Text = txtComparer.CompareFrom.Length.ToString();
                lstMonitor.Items[1][1].Text = txtComparer.CompareTo.Length.ToString();
                lstMonitor.Items[2][1].Text = MaxLen.ToString();
                lstMonitor.Items[3][1].Text = txtComparer.IndexOfFirstMatch.ToString();
                lstMonitor.Items[4][1].Text = txtComparer.Matches.ToString();
                lstMonitor.Items[5][1].Text = txtComparer.Mismatches.ToString();
                lstMonitor.Invalidate();
            }
            catch { }
        }

        private void TextComparator_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void TextComparator_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void TextComparator_FormClosed(object sender, FormClosedEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void sltbCompareFrom_TextChanged(object sender, EventArgs e) {
            txtComparer.CompareFrom = sltbCompareFrom.Text;
            Reevaluate();
        }
        private void sltbCompareTo_TextChanged(object sender, EventArgs e) {
            txtComparer.CompareTo = sltbCompareTo.Text;
            Reevaluate();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e) {
            Cut();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
            Paste();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            Delete();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) {
            SelectAll();
        }
        private void Cut() {
            switch (FocusedControl) {
                case ControlFocus.CompareFrom:
                    sltbCompareFrom.Cut(); break;
                case ControlFocus.CompareTo:
                    sltbCompareTo.Cut(); break;
                case ControlFocus.Statistics:
                    break;
            }
        }
        private void Copy() {
            switch (FocusedControl) {
                case ControlFocus.CompareFrom:
                    sltbCompareFrom.Copy(); break;
                case ControlFocus.CompareTo:
                    sltbCompareTo.Copy(); break;
                case ControlFocus.Statistics:
                    break;
            }
        }
        private void Paste() {
            switch (FocusedControl) {
                case ControlFocus.CompareFrom:
                    sltbCompareFrom.Paste(); break;
                case ControlFocus.CompareTo:
                    sltbCompareTo.Paste(); break;
                case ControlFocus.Statistics:
                    break;
            }
        }
        private void Delete() {
            switch (FocusedControl) {
                case ControlFocus.CompareFrom:
                    sltbCompareFrom.Delete(); break;
                case ControlFocus.CompareTo:
                    sltbCompareTo.Delete(); break;
                case ControlFocus.Statistics:
                    break;
            }
        }
        private void SelectAll() {
            switch (FocusedControl) {
                case ControlFocus.CompareFrom:
                    sltbCompareFrom.SelectAll(); break;
                case ControlFocus.CompareTo:
                    sltbCompareTo.SelectAll(); break;
                case ControlFocus.Statistics:
                    break;
            }
        }
        ControlFocus focusedControl = ControlFocus.CompareFrom;
        ControlFocus FocusedControl {
            get { return focusedControl; }
            set {
                focusedControl = value;
                switch (value) {
                    case ControlFocus.CompareFrom:
                        compareFromToolStripMenuItem.Checked = true;
                        compareToToolStripMenuItem.Checked = false;
                        break;
                    case ControlFocus.CompareTo:
                        compareFromToolStripMenuItem.Checked = false;
                        compareToToolStripMenuItem.Checked = true;
                        break;
                    default:
                        compareFromToolStripMenuItem.Checked = false;
                        compareToToolStripMenuItem.Checked = false;
                        break;
                }
            }
        }
        private void sltbCompareFrom_Enter(object sender, EventArgs e) {
            FocusedControl = ControlFocus.CompareFrom;
        }
        private void sltbCompareTo_Enter(object sender, EventArgs e) {
            FocusedControl = ControlFocus.CompareTo;
        }
        object? ContextControl = null;
        private void cmTextboxOptions_Opening(object sender, CancelEventArgs e) {
            if (sender.GetType() != typeof(ContextMenu)) { return; }
            ContextControl = ((ContextMenu)sender).SourceControl;
        }

        private void cmiTextBoxCut_Click(object sender, EventArgs e) {
            if (ContextControl == null) { return; }
            if (ContextControl.GetType() == typeof(SingleLineTextBox)) {
                ((SingleLineTextBox)ContextControl).Cut();
            }
        }
        private void cmiTextBoxCopy_Click(object sender, EventArgs e) {
            if (ContextControl == null) { return; }
            if (ContextControl.GetType() == typeof(SingleLineTextBox)) {
                ((SingleLineTextBox)ContextControl).Copy();
            }
        }
        private void cmiTextBoxPaste_Click(object sender, EventArgs e) {
            if (ContextControl == null) { return; }
            if (ContextControl.GetType() == typeof(SingleLineTextBox)) {
                ((SingleLineTextBox)ContextControl).Paste();
            }
        }
        private void cmiTextBoxDelete_Click(object sender, EventArgs e) {
            if (ContextControl == null) { return; }
            if (ContextControl.GetType() == typeof(SingleLineTextBox)) {
                ((SingleLineTextBox)ContextControl).Delete();
            }
        }
        private void cmiTextBoxSelectAll_Click(object sender, EventArgs e) {
            if (ContextControl == null) { return; }
            if (ContextControl.GetType() == typeof(SingleLineTextBox)) {
                ((SingleLineTextBox)ContextControl).SelectAll();
            }
        }

        private void compareFromToolStripMenuItem_Click(object sender, EventArgs e) {
            sltbCompareFrom.Focus();
        }
        private void compareToToolStripMenuItem_Click(object sender, EventArgs e) {
            sltbCompareTo.Focus();
        }

        private enum ControlFocus {
            CompareFrom = 0x00,
            CompareTo = 0x01,
            Statistics = 0x02
        }
    }
}
