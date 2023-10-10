using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Classes.Theming;
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
        bool PreventWriting = true;
        private void Settings_Load(object sender, EventArgs e) {
          
            AdjustUserInterface();
            hiddenTabControl1.DefaultColor1 = BackColor;
            ApplyTheme();
            LoadConfigurations();
            LoadSettings();
            LoadThemes();
        }
        private void AdjustUserInterface() {
            btngrThemes.ImageSize = DesignerSetup.GetSize(DesignerSetup.IconSize.Large);
            btngrThemes.ButtonSize = DesignerSetup.GetSize(DesignerSetup.IconSize.VeryLarge);
            btngrThemes.IconInline = false;
            hiddenTabControl1.DebugMode = false;
            ScaleLabelPanels(tabPage3);
        }
        private void ScaleLabelPanels(object Ctrl) {
            if (Ctrl.GetType() == typeof(TabPage)) {
                TabPage TbPg = (TabPage)Ctrl;
                foreach (LabelPanel LblPnl in TbPg.Controls) {
                    if (LblPnl.Inlinelabel == true) {
                        LblPnl.InlineWidth = DesignerSetup.ScaleInteger(LblPnl.InlineWidth);
                    }
                }
            }
        }
        private void LoadThemes() {
            btngrThemes.Buttons.Clear();
            foreach (Theme Thm in ThemeManager.Themes) {
                GridButton GrdBtn = new GridButton();
                GrdBtn.Icon = ThemeManager.DrawIcon(Thm, Font);
                GrdBtn.Tag = Thm;
                //if (Thm.Name != null) {
                //    GrdBtn.Text = Thm.Name;
                //}
                btngrThemes.Buttons.Add(GrdBtn);
            }
        }
        private void InputFormatClicked(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() != typeof(ToolStripMenuItem)) { return; }
            string Cmd = ((ToolStripMenuItem)sender).Tag.ToString() ?? "";
            foreach (ToolStripMenuItem Tsi in ddbInputFormat.DropDownItems) {
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
                    ddbOutputFormat.Text = EnumManager.OutputFormatToString(EnumManager.StringToOutputFormat(Tsi.Tag.ToString() ?? ""), false).A;
                    Tsi.Checked = true;
                    Properties.Settings.Default.DEF_STR_OutputFormat = Tsi.Tag.ToString();
                    Properties.Settings.Default.Save();
                }
                else { Tsi.Checked = false; }
            }
        }
        private void LoadConfigurations() {
            EnumManager.LoadInputFormats(ddbInputFormat, InputFormatClicked, true);
            EnumManager.LoadOutputFormats(ddbOutputFormat, OutputFormatClicked, true);
            foreach (int i in SystemManager.DefaultBauds) {
                comboBox1.Items.Add(i.ToString());
            }
        }
        private void LoadSettings() {
            try {
                SelectComboboxItemWithValue(comboBox1, Properties.Settings.Default.DEF_INT_BaudRate.ToString());
                SetPortParityBits(EnumManager.StringToParity(Properties.Settings.Default.DEF_STR_ParityBit), false);
                SetPortStopBits(EnumManager.StringToStopBits(Properties.Settings.Default.DEF_STR_StopBits), false);
                SetPortBits(Properties.Settings.Default.DEF_INT_DataBits, false);
                chbxAnimateCurStep.Checked = Properties.Settings.Default.PRG_BOL_AnimateCursor;
                chbxUseLegacyListing.Checked = Properties.Settings.Default.CHAN_BOL_PreferLegacyPortListing;
                chbxLimitExecutionBy1ms.Checked = Properties.Settings.Default.PRG_BOL_LimitExecution1ms;
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

        private void Settings_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void Settings_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void Settings_FormClosed(object sender, FormClosedEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }

        private void thSettings_Load(object sender, EventArgs e) {

        }

        private void chbxAnimateCurStep_CheckedChanged(object sender, EventArgs e) {
            if (PreventWriting) { return; }
            Properties.Settings.Default.PRG_BOL_AnimateCursor = chbxAnimateCurStep.Checked;
            Properties.Settings.Default.Save();
        }

        private void chbxUseLegacyListing_CheckedChanged(object sender, EventArgs e) {
            if (PreventWriting) { return; }
            Properties.Settings.Default.CHAN_BOL_PreferLegacyPortListing = chbxUseLegacyListing.Checked;
            Properties.Settings.Default.Save();
        }
        private void chbxLimitExecutionBy1ms_CheckedChanged(object sender, EventArgs e) {
            if (PreventWriting) { return; }
            Properties.Settings.Default.PRG_BOL_LimitExecution1ms = chbxLimitExecutionBy1ms.Checked;
            Properties.Settings.Default.Save();
        }

        private void btngrThemes_ButtonClicked(object Sender, GridButton Button, Point GridLocation) {
            if (Button.Tag == null) { return; }
            if (Button.Tag.GetType() != typeof(Theme)) { return; }
            Theme Thm = (Theme)Button.Tag;
            Thm.Apply();
        }
    }
}
