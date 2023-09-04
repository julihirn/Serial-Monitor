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

namespace Serial_Monitor {
    public partial class Settings : Form, Interfaces.ITheme {
        public Settings() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {
            Properties.Settings.Default.THM_COL_SelectedShadowColor = Color.Black;
            Properties.Settings.Default.THM_COL_MenuBack = Color.FromArgb(31, 31, 31);
            Properties.Settings.Default.THM_COL_ButtonSelected = Color.FromArgb(64, 64, 64);
            Properties.Settings.Default.THM_COL_ButtonChecked = Color.FromArgb(70, 70, 70);
            Properties.Settings.Default.THM_COL_Editor = Color.FromArgb(16, 16, 16);
            Properties.Settings.Default.THM_COL_ForeColor = Color.White;
            Properties.Settings.Default.THM_COL_SecondaryForeColor = Color.Silver;
            Properties.Settings.Default.THM_COL_BorderColor = Color.DimGray;
            Properties.Settings.Default.THM_COL_SeperatorColor = Color.FromArgb(55, 55, 55);
            Properties.Settings.Default.THM_COL_SelectedColor = Color.SteelBlue;
            Properties.Settings.Default.THM_COL_ScrollColor = Color.FromArgb(64, 64, 64);
            Properties.Settings.Default.THM_COL_SymbolColor = Color.DarkGray;
            Properties.Settings.Default.THM_COL_StopColor = Color.Brown;
            Properties.Settings.Default.THM_COL_SeconaryBackColor = Color.FromArgb(40, 40, 40);
            Properties.Settings.Default.THM_COL_TerminalForeColor = Color.FromArgb(255, 255, 192);

            Properties.Settings.Default.THM_COL_ColumnSeperatorColor = Color.FromArgb(64, 64, 64);

            Properties.Settings.Default.THM_COL_RowColor = Color.FromArgb(23, 23, 23);
            Properties.Settings.Default.THM_COL_GridLineColor = Color.FromArgb(30, 30, 30);

            Properties.Settings.Default.THM_COL_TabSelectedBorderColor = Color.FromArgb(100, 128, 128, 128);
            Properties.Settings.Default.THM_COL_TabSelectedColor = Color.FromArgb(100, 128, 128, 128);
            Properties.Settings.Default.THM_COL_TabSelectedForeColor = Color.White;

            Properties.Settings.Default.THM_COL_Match = Color.FromArgb(0, 64, 0);
            Properties.Settings.Default.THM_COL_Mismatched = Color.FromArgb(64, 0, 0);

            Properties.Settings.Default.THM_SET_IsDark = true;
            Classes.ApplicationManager.ReapplyThemeToAll();
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e) {
            Properties.Settings.Default.THM_COL_SelectedShadowColor = Color.Black;
            Properties.Settings.Default.THM_COL_MenuBack = Color.FromArgb(224, 224, 224);
            Properties.Settings.Default.THM_COL_ButtonSelected = Color.FromArgb(191, 191, 191);
            Properties.Settings.Default.THM_COL_ButtonChecked = Color.FromArgb(185, 185, 185);
            Properties.Settings.Default.THM_COL_Editor = Color.FromArgb(245, 245, 245);
            Properties.Settings.Default.THM_COL_ForeColor = Color.Black;
            Properties.Settings.Default.THM_COL_SecondaryForeColor = Color.DimGray;
            Properties.Settings.Default.THM_COL_BorderColor = Color.FromArgb(150, 150, 150);
            Properties.Settings.Default.THM_COL_SeperatorColor = Color.FromArgb(200, 200, 200);
            Properties.Settings.Default.THM_COL_SelectedColor = Color.LightSteelBlue;
            Properties.Settings.Default.THM_COL_ScrollColor = Color.FromArgb(200, 200, 200);
            Properties.Settings.Default.THM_COL_SymbolColor = Color.DimGray;
            Properties.Settings.Default.THM_COL_StopColor = Color.Brown;
            Properties.Settings.Default.THM_COL_SeconaryBackColor = Color.FromArgb(215, 215, 215);
            Properties.Settings.Default.THM_COL_TerminalForeColor = Color.FromArgb(0, 0, 63);

            Properties.Settings.Default.THM_COL_ColumnSeperatorColor = Color.FromArgb(180, 180, 180);

            Properties.Settings.Default.THM_COL_TabSelectedBorderColor = Color.FromArgb(100, 128, 128, 128);
            Properties.Settings.Default.THM_COL_TabSelectedColor = Color.FromArgb(100, 128, 128, 128);
            Properties.Settings.Default.THM_COL_TabSelectedForeColor = Color.Black;

            Properties.Settings.Default.THM_COL_RowColor = Color.FromArgb(232, 232, 232);
            Properties.Settings.Default.THM_COL_GridLineColor = Color.FromArgb(225, 225, 225);

            Properties.Settings.Default.THM_COL_Match =  Color.FromArgb(191, 255, 191);
            Properties.Settings.Default.THM_COL_Mismatched = Color.FromArgb(255, 191, 191);

            Properties.Settings.Default.THM_SET_IsDark = false;
            Classes.ApplicationManager.ReapplyThemeToAll();
            Properties.Settings.Default.Save();
        }
        private void button3_Click(object sender, EventArgs e) {
            Properties.Settings.Default.THM_COL_SelectedShadowColor = Color.FromArgb(44, 61, 91);
            Properties.Settings.Default.THM_COL_MenuBack = Color.FromArgb(214, 219, 233);
            Properties.Settings.Default.THM_COL_ButtonSelected = Color.FromArgb(189, 194, 208);
            Properties.Settings.Default.THM_COL_ButtonChecked = Color.FromArgb(155, 167, 183);
            Properties.Settings.Default.THM_COL_Editor = Color.FromArgb(245, 245, 245);
            Properties.Settings.Default.THM_COL_ForeColor = Color.Black;
            Properties.Settings.Default.THM_COL_SecondaryForeColor = Color.FromArgb(48, 67, 98);
            Properties.Settings.Default.THM_COL_BorderColor = Color.FromArgb(142, 135, 188);
            Properties.Settings.Default.THM_COL_SeperatorColor = Color.FromArgb(142, 155, 188);
            Properties.Settings.Default.THM_COL_SelectedColor = Color.FromArgb(204,206,219);
            Properties.Settings.Default.THM_COL_ScrollColor = Color.FromArgb(200, 200, 200);
            Properties.Settings.Default.THM_COL_SymbolColor = Color.FromArgb(41,27,85);
            Properties.Settings.Default.THM_COL_StopColor = Color.Brown;
            Properties.Settings.Default.THM_COL_SeconaryBackColor = Color.FromArgb(207, 214, 229);
            Properties.Settings.Default.THM_COL_TerminalForeColor = Color.FromArgb(0, 0, 63);

            Properties.Settings.Default.THM_COL_ColumnSeperatorColor = Color.FromArgb(204, 206, 219);

            Properties.Settings.Default.THM_COL_TabSelectedBorderColor = Color.FromArgb(142, 155, 188);
            Properties.Settings.Default.THM_COL_TabSelectedColor = Color.FromArgb(77, 96, 130);
            Properties.Settings.Default.THM_COL_TabSelectedForeColor = Color.White;

            Properties.Settings.Default.THM_COL_RowColor = Color.FromArgb(228, 232, 247);
            Properties.Settings.Default.THM_COL_GridLineColor = Color.FromArgb(225, 225, 225);

            Properties.Settings.Default.THM_COL_Match = Color.FromArgb(191, 255, 191);
            Properties.Settings.Default.THM_COL_Mismatched = Color.FromArgb(255, 191, 191);

            Properties.Settings.Default.THM_SET_IsDark = false;
            Classes.ApplicationManager.ReapplyThemeToAll();
            Properties.Settings.Default.Save();
        }

        private void button4_Click(object sender, EventArgs e) {
            Properties.Settings.Default.THM_COL_SelectedShadowColor = Color.Black;
            Properties.Settings.Default.THM_COL_MenuBack = Color.FromArgb(22, 27, 41);
            Properties.Settings.Default.THM_COL_ButtonSelected = Color.FromArgb(47, 52, 66);
            Properties.Settings.Default.THM_COL_ButtonChecked = Color.FromArgb(70, 70, 70);
            Properties.Settings.Default.THM_COL_Editor = Color.FromArgb(16, 16, 16);
            Properties.Settings.Default.THM_COL_ForeColor = Color.White;
            Properties.Settings.Default.THM_COL_SecondaryForeColor = Color.Silver;
            Properties.Settings.Default.THM_COL_BorderColor = Color.FromArgb(74,67,120);
            Properties.Settings.Default.THM_COL_SeperatorColor = Color.FromArgb(67, 80, 113);
            Properties.Settings.Default.THM_COL_SelectedColor = Color.SteelBlue;
            Properties.Settings.Default.THM_COL_ScrollColor = Color.FromArgb(64, 64, 64);
            Properties.Settings.Default.THM_COL_SymbolColor = Color.DarkGray;
            Properties.Settings.Default.THM_COL_StopColor = Color.Brown;
            Properties.Settings.Default.THM_COL_SeconaryBackColor = Color.FromArgb(26, 33, 48);
            Properties.Settings.Default.THM_COL_TerminalForeColor = Color.FromArgb(255, 255, 192);

            Properties.Settings.Default.THM_COL_ColumnSeperatorColor = Color.FromArgb(64, 64, 64);

            Properties.Settings.Default.THM_COL_RowColor = Color.FromArgb(23, 23, 23);
            Properties.Settings.Default.THM_COL_GridLineColor = Color.FromArgb(30, 30, 30);

            Properties.Settings.Default.THM_COL_TabSelectedBorderColor = Color.FromArgb(67, 80, 113);
            Properties.Settings.Default.THM_COL_TabSelectedColor = Color.FromArgb(125, 144, 178);
            Properties.Settings.Default.THM_COL_TabSelectedForeColor = Color.White;

            Properties.Settings.Default.THM_COL_Match = Color.FromArgb(0, 64, 0);
            Properties.Settings.Default.THM_COL_Mismatched = Color.FromArgb(64, 0, 0);

            Properties.Settings.Default.THM_SET_IsDark = true;
            Classes.ApplicationManager.ReapplyThemeToAll();
            Properties.Settings.Default.Save();
        }
        bool PreventWriting = true;
        private void Settings_Load(object sender, EventArgs e) {
            hiddenTabControl1.DebugMode = false;
            hiddenTabControl1.DefaultColor1 = BackColor;
            ApplyTheme();
            LoadConfigurations();
            LoadSettings();
        }
        private void LoadConfigurations() {
            foreach (int i in SystemManager.DefaultBauds) {
                comboBox1.Items.Add(i.ToString());

            }
        }
        private void LoadSettings() {
            try {
                SelectComboboxItemWithValue(comboBox1, Properties.Settings.Default.DEF_INT_BaudRate.ToString());
            }
            catch { }
            PreventWriting = false;
        }
        private void SelectComboboxItemWithValue(ComboBox Cm, string Value) {
            if (Cm.Items.Count == 0) { return; }
            for (int i = 0; i < Cm.Items.Count; i++) {
                if (Cm.Items[i].ToString() == Value) {
                    Cm.SelectedIndex = i;
                    break;
                }
            }
        }
        public void ApplyTheme() {

            RecolorAll();
        }
        private void RecolorAll() {
            ApplicationManager.IsDark = Properties.Settings.Default.THM_SET_IsDark;
            this.SuspendLayout();
            if (ApplicationManager.IsDark == true) {
                thSettings.TabSelectedShadowColor = Color.FromArgb(255, 0, 0, 0);
            }
            else {
                thSettings.TabSelectedShadowColor = Color.FromArgb(125, 0, 0, 0);
            }
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            hiddenTabControl1.DefaultColor1 = BackColor;

            thSettings.TabHoverBackColor = Properties.Settings.Default.THM_COL_ButtonSelected;

            thSettings.TabDividerColor = Properties.Settings.Default.THM_COL_SeperatorColor;

            thSettings.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            thSettings.TabSelectedForeColor = Properties.Settings.Default.THM_COL_ForeColor;


            this.ResumeLayout();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (PreventWriting) { return; }
            int Temp = 9600; int.TryParse(comboBox1.SelectedItem.ToString(), out Temp);
            Properties.Settings.Default.DEF_INT_BaudRate = Temp;
        }

        private void Settings_Activated(object sender, EventArgs e) {
            Color FadeInColor = Color.FromArgb(255, DesignerSetup.GetAccentColor());
           // thSettings.BackColor = FadeInColor;

        }
        private void Settings_Deactivate(object sender, EventArgs e) {
            Color FadeInColor = Color.FromArgb(255, DesignerSetup.GetAccentColor());
           // thSettings.BackColor = FadeInColor;
        }

     
    }
}
