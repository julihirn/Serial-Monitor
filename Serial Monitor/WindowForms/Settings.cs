using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Step_Programs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO.Ports;
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

            Properties.Settings.Default.THM_COL_Match = Color.FromArgb(191, 255, 191);
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
            Properties.Settings.Default.THM_COL_SelectedColor = Color.FromArgb(204, 206, 219);
            Properties.Settings.Default.THM_COL_ScrollColor = Color.FromArgb(200, 200, 200);
            Properties.Settings.Default.THM_COL_SymbolColor = Color.FromArgb(41, 27, 85);
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
            Properties.Settings.Default.THM_COL_BorderColor = Color.FromArgb(74, 67, 120);
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
            LoadInputFormats();
            LoadOutputFormats();
            ApplyTheme();
            LoadConfigurations();
            LoadSettings();
        }
        private void LoadInputFormats() {
            StreamInputFormat[] Formats = (StreamInputFormat[])StreamInputFormat.GetValues(typeof(StreamInputFormat));
            foreach (StreamInputFormat Frmt in Formats) {
                StringPair Data = EnumManager.InputFormatToString(Frmt, true);
                ToolStripMenuItem Tsi = new ToolStripMenuItem();
                Tsi.Text = Data.A;
                Tsi.Tag = Data.B;
                if (Data.B == Properties.Settings.Default.DEF_STR_InputFormat) {
                    Tsi.Checked = true;
                    ddbInputFormat.Text = EnumManager.InputFormatToString(EnumManager.StringToInputFormat(Tsi.Tag.ToString() ?? ""),false).A;
                }
                Tsi.Click += InputFormatClicked;
                ddbInputFormat.DropDownItems.Add(Tsi);
            }
        }
        private void LoadOutputFormats() {
            StreamOutputFormat[] Formats = (StreamOutputFormat[])StreamOutputFormat.GetValues(typeof(StreamOutputFormat));
            foreach (StreamOutputFormat Frmt in Formats) {
                StringPair Data = EnumManager.OutputFormatToString(Frmt, true);
                ToolStripMenuItem Tsi = new ToolStripMenuItem();
                Tsi.Text = Data.A;
                Tsi.Tag = Data.B;
                if (Data.B == Properties.Settings.Default.DEF_STR_OutputFormat) {
                    Tsi.Checked = true;
                    ddbOutputFormat.Text = EnumManager.OutputFormatToString(EnumManager.StringToOutputFormat(Tsi.Tag.ToString() ?? ""), false).A;
                }
                Tsi.Click += OutputFormatClicked;
               ddbOutputFormat.DropDownItems.Add(Tsi);
            }
        }

        private void InputFormatClicked(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() != typeof(ToolStripMenuItem)) { return; }
            string Cmd = ((ToolStripMenuItem)sender).Tag.ToString() ?? "";
            foreach(ToolStripMenuItem Tsi in ddbInputFormat.DropDownItems) {
                if (Tsi.Tag.ToString() == Cmd) {
                    ddbInputFormat.Text = EnumManager.InputFormatToString(EnumManager.StringToInputFormat(Tsi.Tag.ToString() ?? ""), false).A;
                    Tsi.Checked = true;
                    Properties.Settings.Default.DEF_STR_InputFormat = Tsi.Tag.ToString();
                    Properties.Settings.Default.Save();
                }
                else { Tsi.Checked = false; }
            }
        }
        private void OutputFormatClicked(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() != typeof(ToolStripMenuItem)) { return; }
            string Cmd = ((ToolStripMenuItem)sender).Tag.ToString() ?? "";
            foreach (ToolStripMenuItem Tsi in ddbOutputFormat.DropDownItems) {
                if (Tsi.Tag.ToString() == Cmd) {
                    ddbOutputFormat.Text = EnumManager.OutputFormatToString(EnumManager.StringToOutputFormat(Tsi.Tag.ToString() ??""), false).A;
                    Tsi.Checked = true;
                    Properties.Settings.Default.DEF_STR_OutputFormat = Tsi.Tag.ToString();
                    Properties.Settings.Default.Save();
                }
                else { Tsi.Checked = false; }
            }
        }
        private void LoadConfigurations() {
            foreach (int i in SystemManager.DefaultBauds) {
                comboBox1.Items.Add(i.ToString());

            }
        }
        private void LoadSettings() {
            try {
                SelectComboboxItemWithValue(comboBox1, Properties.Settings.Default.DEF_INT_BaudRate.ToString());
                SetPortParityBits(EnumManager.StringToParity(Properties.Settings.Default.DEF_STR_ParityBit), false);
                SetPortStopBits(EnumManager.StringToStopBits(Properties.Settings.Default.DEF_STR_StopBits), false);
                SetPortBits(Properties.Settings.Default.DEF_INT_DataBits,false);
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
        private void SetPortParityBits(Parity PBits, bool Save = true) {
            string Temp = EnumManager.ParityToString(PBits);
            ddbParity.Text = Temp;
            if (Save) {
                Properties.Settings.Default.DEF_STR_ParityBit = Temp;
                Properties.Settings.Default.Save();
            }
            CheckParity(ddbParity.Text);
        }
        private void SetPortBits(int Bits, bool Save = true) {
            string Temp = Bits.ToString();
            ddbBits.Text = Temp;
            if (Save) {
                Properties.Settings.Default.DEF_INT_DataBits = Bits;
                Properties.Settings.Default.Save();
            }
            CheckBits(Bits.ToString());
        }
        private void SetPortStopBits(StopBits StopBts, bool Save = true) {
            string Temp = EnumManager.StopBitsToString(StopBts);
            ddbOptSB1.Text = Temp;
            if (Save) {
                Properties.Settings.Default.DEF_STR_StopBits = Temp;
                Properties.Settings.Default.Save();
            }
            CheckStopBits(ddbOptSB1.Text);
        }
        private void CheckBits(string Type) {
            foreach (ToolStripMenuItem Item in ddbBits.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
        }
        private void CheckParity(string Type) {
            foreach (ToolStripMenuItem Item in ddbParity.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
        }
        private void CheckStopBits(string Type) {
            foreach (ToolStripMenuItem Item in ddbOptSB1.DropDownItems) {
                if (Item.Tag.ToString() == Type) {
                    Item.Checked = true;
                }
                else {
                    Item.Checked = false;
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (PreventWriting) { return; }
            int Temp = 9600; int.TryParse(comboBox1.SelectedItem.ToString(), out Temp);
            Properties.Settings.Default.DEF_INT_BaudRate = Temp;
            Properties.Settings.Default.Save();
        }

        private void Settings_Activated(object sender, EventArgs e) {
            Color FadeInColor = Color.FromArgb(255, DesignerSetup.GetAccentColor());
            // thSettings.BackColor = FadeInColor;

        }
        private void Settings_Deactivate(object sender, EventArgs e) {
            Color FadeInColor = Color.FromArgb(255, DesignerSetup.GetAccentColor());
            // thSettings.BackColor = FadeInColor;
        }

        private void ddbOptDB5_Click(object sender, EventArgs e) {
            SetPortBits(5);
        }
        private void ddbOptDB6_Click(object sender, EventArgs e) {
            SetPortBits(5);
        }
        private void ddbOptDB7_Click(object sender, EventArgs e) {
            SetPortBits(7);
        }
        private void ddbOptDB8_Click(object sender, EventArgs e) {
            SetPortBits(8);
        }
        private void ddbOptPBNone_Click(object sender, EventArgs e) {
            SetPortParityBits(Parity.None);
        }
        private void ddbOptPBEven_Click(object sender, EventArgs e) {
            SetPortParityBits(Parity.Even);
        }
        private void ddbOptPBOdd_Click(object sender, EventArgs e) {
            SetPortParityBits(Parity.Odd);
        }
        private void ddbOptPBMark_Click(object sender, EventArgs e) {
            SetPortParityBits(Parity.Mark);
        }
        private void ddbOptPBSpace_Click(object sender, EventArgs e) {
            SetPortParityBits(Parity.Space);
        }
        private void stopBitToolStripMenuItem_Click(object sender, EventArgs e) {
            SetPortStopBits(StopBits.One);
        }
        private void ddbOptSB15_Click(object sender, EventArgs e) {
            SetPortStopBits(StopBits.OnePointFive);
        }
        private void ddbOptSB2_Click(object sender, EventArgs e) {
            SetPortStopBits(StopBits.Two);
        }
    }
}
