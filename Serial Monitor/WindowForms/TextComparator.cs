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
    public partial class TextComparator : Form, Interfaces.ITheme {
        public TextComparator() {
            InitializeComponent();
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
        }
        private void AdjustUserInterface() {
            labelPanel1.InlineWidth = DesignerSetup.ScaleInteger(labelPanel1.InlineWidth);
            labelPanel2.InlineWidth = DesignerSetup.ScaleInteger(labelPanel2.InlineWidth);
            lstMonitor.ScaleColumnWidths();
        }
        private void textBox1_TextChanged(object sender, EventArgs e) {
            txtComparer.CompareFrom = textBox1.Text;
            Reevaluate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
            txtComparer.CompareTo = textBox2.Text;
            Reevaluate();
        }

        private void TextComparator_Load(object sender, EventArgs e) {
            ApplyTheme();
            AdjustUserInterface();
        }
        public void ApplyTheme() {
            RecolorAll();
        }
        private void RecolorAll() {

            labelPanel1.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            labelPanel1.LabelBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            labelPanel1.BackColor = Properties.Settings.Default.THM_COL_Editor;

            labelPanel2.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            labelPanel2.LabelBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            labelPanel2.BackColor = Properties.Settings.Default.THM_COL_Editor;

            ThemeManager.ThemeControl(textBox1);
            ThemeManager.ThemeControl(textBox2);
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            txtComparer.BackColor = Properties.Settings.Default.THM_COL_Editor;
            txtComparer.EmptyTextColor = Properties.Settings.Default.THM_COL_Editor;
            //kpCommands.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            //kpCommands.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            //kpCommands.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            txtComparer.GridColor =Properties.Settings.Default.THM_COL_SeperatorColor;
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
    }
}
