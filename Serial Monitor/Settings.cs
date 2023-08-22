using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor {
    public partial class Settings : Form {
        public Settings() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {
            Properties.Settings.Default.THM_COL_MenuBack = Color.FromArgb(31, 31, 31);
            Properties.Settings.Default.THM_COL_ButtonSelected = Color.FromArgb(64, 64, 64);
            Properties.Settings.Default.THM_COL_Editor = Color.FromArgb(16, 16, 16);
            Properties.Settings.Default.THM_COL_ForeColor = Color.White;
            Properties.Settings.Default.THM_COL_BorderColor = Color.DimGray;
            Properties.Settings.Default.THM_COL_SeperatorColor = Color.FromArgb(55, 55, 55);
            Properties.Settings.Default.THM_COL_SelectedColor = Color.SteelBlue;
            Properties.Settings.Default.THM_COL_ScrollColor = Color.FromArgb(64, 64, 64);
            Properties.Settings.Default.THM_COL_SymbolColor = Color.DarkGray;
            Properties.Settings.Default.THM_COL_StopColor = Color.Brown;
            Properties.Settings.Default.THM_COL_SeconaryBackColor = Color.FromArgb(40, 40, 40);
            Properties.Settings.Default.THM_COL_TerminalForeColor = Color.FromArgb(255, 255, 192);

            Properties.Settings.Default.THM_COL_RowColor = Color.FromArgb(23, 23, 23);
            Properties.Settings.Default.THM_COL_GridLineColor = Color.FromArgb(30, 30, 30);

            Properties.Settings.Default.THM_SET_IsDark = true;
            Classes.ApplicationManager.ReapplyThemeToAll();
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e) {
            
            Properties.Settings.Default.THM_COL_MenuBack = Color.FromArgb(224, 224, 224);
            Properties.Settings.Default.THM_COL_ButtonSelected = Color.FromArgb(191, 191, 191);
            Properties.Settings.Default.THM_COL_Editor = Color.FromArgb(245, 245, 245);
            Properties.Settings.Default.THM_COL_ForeColor = Color.Black;
            Properties.Settings.Default.THM_COL_BorderColor = Color.FromArgb(150, 150, 150);
            Properties.Settings.Default.THM_COL_SeperatorColor = Color.FromArgb(200, 200, 200);
            Properties.Settings.Default.THM_COL_SelectedColor = Color.SteelBlue;
            Properties.Settings.Default.THM_COL_ScrollColor = Color.FromArgb(200, 200, 200);
            Properties.Settings.Default.THM_COL_SymbolColor = Color.DimGray;
            Properties.Settings.Default.THM_COL_StopColor = Color.Brown;
            Properties.Settings.Default.THM_COL_SeconaryBackColor = Color.FromArgb(215, 215, 215);
            Properties.Settings.Default.THM_COL_TerminalForeColor = Color.FromArgb(0, 0, 63);

            Properties.Settings.Default.THM_COL_RowColor = Color.FromArgb(232, 232, 232);
            Properties.Settings.Default.THM_COL_GridLineColor = Color.FromArgb(225, 225, 225);

            Properties.Settings.Default.THM_SET_IsDark = false;
            Classes.ApplicationManager.ReapplyThemeToAll();
            Properties.Settings.Default.Save();
        }

        private void Settings_Load(object sender, EventArgs e) {

        }
    }
}
