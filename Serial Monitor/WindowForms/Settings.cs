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
                foreach (Control LblPnl in TbPg.Controls) {
                    if (LblPnl.GetType() == typeof(LabelPanel)) {
                        LabelPanel Temp = (LabelPanel)LblPnl;
                        if (Temp.Inlinelabel == true) {
                            Temp.InlineWidth = DesignerSetup.ScaleInteger(Temp.InlineWidth);
                        }
                        ScaleInnerLabelPanel(Temp);
                    }
                }
            }
        }
        private void ScaleInnerLabelPanel(LabelPanel Input) {
            foreach (Control LblPnl in Input.Controls) {
                if (LblPnl.GetType() == typeof(LabelPanel)) {
                    LabelPanel Temp = (LabelPanel)LblPnl;
                    if (Temp.Inlinelabel == true) {
                        Temp.InlineWidth = DesignerSetup.ScaleInteger(Temp.InlineWidth);
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
            ToolStripMenuItem BaseItem = (ToolStripMenuItem)sender;
            if (BaseItem.Tag == null) { return; }
            string Cmd = BaseItem.Tag.ToString() ?? "";
            foreach (object Tsi in ddbInputFormat.DropDownItems) {
                if (Tsi.GetType() != typeof(ToolStripMenuItem)) { continue; }
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)Tsi;
                if (Tsmi.Tag == null) { continue; }
                if (Tsmi.Tag.ToString() == Cmd) {
                    ddbInputFormat.Text = EnumManager.InputFormatToString(EnumManager.StringToInputFormat(Tsmi.Tag.ToString() ?? ""), false).A;
                    ((ToolStripMenuItem)Tsi).Checked = true;
                    Properties.Settings.Default.DEF_STR_InputFormat = Tsmi.Tag.ToString();
                    Properties.Settings.Default.Save();
                }
                else { ((ToolStripMenuItem)Tsi).Checked = false; }
            }
        }
        private void OutputFormatClicked(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() != typeof(ToolStripMenuItem)) { return; }
            ToolStripMenuItem BaseItem = (ToolStripMenuItem)sender;
            if (BaseItem.Tag == null) { return; }
            string Cmd = BaseItem.Tag.ToString() ?? "";
            foreach (object Tsi in ddbOutputFormat.DropDownItems) {
                if (Tsi.GetType() != typeof(ToolStripMenuItem)) { continue; }
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)Tsi;
                if (Tsmi.Tag == null) { continue; }
                if (Tsmi.Tag.ToString() == Cmd) {
                    ddbOutputFormat.Text = EnumManager.OutputFormatToString(EnumManager.StringToOutputFormat(Tsmi.Tag.ToString() ?? ""), false).A;
                    ((ToolStripMenuItem)Tsi).Checked = true;
                    Properties.Settings.Default.DEF_STR_OutputFormat = Tsmi.Tag.ToString();
                    Properties.Settings.Default.Save();
                }
                else { ((ToolStripMenuItem)Tsi).Checked = false; }
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
                chbxProgSyntaxHighlighting.Checked = Properties.Settings.Default.PRG_BOL_SyntaxHighlighting;
                chbxProgCommandIndentation.Checked = Properties.Settings.Default.PRG_BOL_CommandIndentation;
                chbxProgCommandInsertBefore.Checked = Properties.Settings.Default.PRG_BOL_InsertBefore;
                int Indx_PortDisplay = Properties.Settings.Default.CHAN_OPT_PortDisplay;
                if (Indx_PortDisplay < 0) {
                    comboBox2.SelectedIndex = 0;
                }
                else if (Indx_PortDisplay >= comboBox2.Items.Count) {
                    comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
                }
                else {
                    comboBox2.SelectedIndex = Indx_PortDisplay;
                }
            }
            catch { }
            PreventWriting = false;
        }
        private void SelectComboboxItemWithValue(ComboBox Cm, string Value) {
            if (Cm.Items.Count == 0) { return; }
            for (int i = 0; i < Cm.Items.Count; i++) {
                object? Item = Cm.Items[i];
                if (Item == null) { continue; }
                if (Item.ToString() == Value) {
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
                if (Item.Tag == null) { continue; }
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
                if (Item.Tag == null) { continue; }
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
                if (Item.Tag == null) { continue; }
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
            object? Data = comboBox1.SelectedItem;
            if (Data == null) { return; }
            int Temp = 9600; int.TryParse(Data.ToString(), out Temp);
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
            SetPortBits(6);
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

        private void btngrThemes_Load(object sender, EventArgs e) {

        }

        private void chbxSyntaxHighlighting_CheckedChanged(object sender, EventArgs e) {
            if (PreventWriting) { return; }
            Properties.Settings.Default.PRG_BOL_SyntaxHighlighting = chbxProgSyntaxHighlighting.Checked;
            Properties.Settings.Default.Save();
            ProgramManager.ProgramSettingChange();
        }
        private void chbxProgCommandIndentation_CheckedChanged(object sender, EventArgs e) {
            if (PreventWriting) { return; }
            Properties.Settings.Default.PRG_BOL_CommandIndentation = chbxProgCommandIndentation.Checked;
            Properties.Settings.Default.Save();
            ProgramManager.ProgramSettingChange();
        }
        private void chbxProgCommandInsertBefore_CheckedChanged(object sender, EventArgs e) {
            if (PreventWriting) { return; }
            Properties.Settings.Default.PRG_BOL_InsertBefore = chbxProgCommandInsertBefore.Checked;
            Properties.Settings.Default.Save();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            if (PreventWriting) { return; }
            Properties.Settings.Default.CHAN_OPT_PortDisplay = comboBox2.SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
