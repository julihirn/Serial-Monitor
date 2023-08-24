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

        private void textBox1_TextChanged(object sender, EventArgs e) {
            txtComparer.CompareFrom = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
            txtComparer.CompareTo = textBox2.Text;
        }

        private void TextComparator_Load(object sender, EventArgs e) {
            ApplyTheme();
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

            textBox1.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            textBox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            textBox2.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            textBox2.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
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


        }
    }
}
