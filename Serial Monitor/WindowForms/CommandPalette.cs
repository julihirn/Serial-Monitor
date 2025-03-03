using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Step_Programs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Serial_Monitor {
    public partial class CommandPalette : Components.SkinnedForm, Interfaces.ITheme {
        public CommandPalette() {
            InitializeComponent();
        }

        private void CommandPalette_Load(object sender, EventArgs e) {
            LoadProgramOperations();
            ApplyTheme();
            btngridCommands.ButtonSize = DesignerSetup.ScaleSize(btngridCommands.ButtonSize);

        }
        private void LoadProgramOperations() {
            StepEnumerations.StepExecutable[] Steps = (StepEnumerations.StepExecutable[])StepEnumerations.StepExecutable.GetValues(typeof(StepEnumerations.StepExecutable));
            int Index = 0;
            int LastValue = 0;
            foreach (StepEnumerations.StepExecutable StepEx in Steps) {
                int Value = (int)StepEx & 0xFF0000;
                //if (Index != 0) {
                //    if (LastValue != Value) {
                //        cmStepPrg.Items.Add(new ToolStripSeparator());
                //    }
                //}
                LoadProgramOperation(StepEx);
                Index++;
                LastValue = Value;
            }
        }
        private void LoadProgramOperation(StepEnumerations.StepExecutable StepEx) {
            GridButton StepOperationBtn = new GridButton();
            StepOperationBtn.Text = ProgramManager.StepExecutableToString(StepEx); //StepEx.ToString();
            StepOperationBtn.Tag = StepEx;
            //StepOperationBtn.ForeColor = Color.White;
            //StepOperationBtn.ImageScaling = ToolStripItemImageScaling.None;
            //StepOperationBtn.Click += StepOperationBtn_Click; ;
            btngridCommands.Buttons.Add(StepOperationBtn);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            btngridCommands.Filter = textBox1.Text;
        }

        private void buttonGrid1_ButtonClicked(object Sender, GridButton Button, Point GridLocation) {
            if (Button.Tag == null) { return; }
            if (Button.Tag.GetType() == typeof(StepEnumerations.StepExecutable)) {
                // Debug.Print(Button.Tag.ToString());
                ProgramManager.CommandLine((StepEnumerations.StepExecutable)Button.Tag);
            }
        }
        public void ApplyTheme() {
            RecolorAll();
        }
        private void RecolorAll() {
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            btngridCommands.BackColor = Properties.Settings.Default.THM_COL_Editor;
            btngridCommands.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            btngridCommands.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            btngridCommands.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            btngridCommands.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
            btngridCommands.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;
            btngridCommands.BorderColorNorth = Properties.Settings.Default.THM_COL_BorderColor;
            btngridCommands.BorderColorSouth = Properties.Settings.Default.THM_COL_BorderColor;

            btngridCommands.BackColorHoverNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            btngridCommands.BackColorHoverSouth = Properties.Settings.Default.THM_COL_ButtonSelected;

            textBox1.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            textBox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            TitleBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            TitleForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            InactiveBorderColor = Properties.Settings.Default.THM_COL_MenuBack;
            ActiveBorderColor = Properties.Settings.Default.THM_COL_SelectedColor;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                GridButton? Btn = btngridCommands.GetFirstButton();
                if (Btn == null) { return; }
                if (Btn.Tag == null) { return; }
                if (Btn.Tag.GetType() == typeof(StepEnumerations.StepExecutable)) {
                    // Debug.Print(Button.Tag.ToString());
                    ProgramManager.CommandLine((StepEnumerations.StepExecutable)Btn.Tag);
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void CommandPalette_KeyPress(object sender, KeyPressEventArgs e) {
            if (Char.IsLetterOrDigit(e.KeyChar)) {
                if (textBox1.Focused == false) {
                    textBox1.Text += e.KeyChar;
                    textBox1.Focus();
                    textBox1.SelectionStart = textBox1.Text.Length;
                    textBox1.SelectionLength = 0;
                }
            }
        }
        private void CommandPalette_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Back) {
                if (textBox1.Focused == false) {
                    if (textBox1.Text.Length > 0) {
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
                    }
                    textBox1.Focus();
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
            }
            else if (e.KeyCode == Keys.Delete) {
                textBox1.Text = "";
                textBox1.Focus();
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.SelectionLength = 0;
            }
        }

        private void CommandPalette_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void CommandPalette_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void CommandPalette_FormClosed(object sender, FormClosedEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
    }
}
