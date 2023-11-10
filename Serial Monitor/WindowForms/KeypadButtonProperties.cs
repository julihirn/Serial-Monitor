using ODModules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.WindowForms {
    public partial class KeypadButtonProperties : Form, Interfaces.ITheme {
        public KeypadButtonProperties() {
            InitializeComponent();
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
        }
        bool AllowEditing = false;
         string command = "";
        public string Command {
            get { return command; }
            set {
                command = value;
                textBox2.Text = value;
            }
        }
        string buttonName = "";
        public string ButtonName {
            get { return buttonName; }
            set {
                buttonName = value;
                textBox1.Text = value;
            }
        }
        Classes.Button_Commands.CommandType commandType = Classes.Button_Commands.CommandType.NoAssignedCommand;
        public Classes.Button_Commands.CommandType CommandType {
            get { return commandType; }
            set {
                commandType = value;
               
            }
        }
        private void KeypadButtonProperties_Load(object sender, EventArgs e) {
            RecolorAll();
            AllowEditing = true;
        }
        public void ApplyTheme() {

            RecolorAll();
        }
        private void RecolorAll() {
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            foreach (object Obj in this.Controls) {
                if (Obj.GetType() == typeof(LabelPanel)) {
                    ((LabelPanel)Obj).ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                    ((LabelPanel)Obj).LabelBackColor = Properties.Settings.Default.THM_COL_Editor;
                    ((LabelPanel)Obj).LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                    foreach (object ChildObj in ((LabelPanel)Obj).Controls) {
                        if (ChildObj.GetType() == typeof(System.Windows.Forms.TextBox)) {
                            ((System.Windows.Forms.TextBox)ChildObj).ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                            ((System.Windows.Forms.TextBox)ChildObj).BackColor = Properties.Settings.Default.THM_COL_MenuBack;
                        }
                    }
                }
            }

            keypad1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            keypad1.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            keypad1.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            keypad1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            //kpCommands.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
            //kpCommands.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;
            keypad1.BorderColorNorth = Properties.Settings.Default.THM_COL_BorderColor;
            keypad1.BorderColorSouth = Properties.Settings.Default.THM_COL_BorderColor;

            keypad1.BackColorMarkedNorth = Properties.Settings.Default.THM_COL_SelectedColor;
            keypad1.BackColorMarkedSouth = Properties.Settings.Default.THM_COL_SelectedColor;

            keypad1.BorderColorMarkedNorth = Properties.Settings.Default.THM_COL_BorderColor;
            keypad1.BorderColorMarkedSouth = Properties.Settings.Default.THM_COL_BorderColor;

            keypad1.BackColorHoverNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            keypad1.BackColorHoverSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
        }

        private void KeypadButtonProperties_FormClosing(object sender, FormClosingEventArgs e) {
            this.DialogResult = DialogResult.OK;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (AllowEditing == false) { return; }
            buttonName = textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e) {
            if (AllowEditing == false) { return; }
            command = textBox2.Text;
        }
        private void keypad1_ButtonClicked(object Sender, KeypadButton Button, Point GridLocation, int Index) {
            int CmdType = 0;
            int.TryParse(Button.Command, out CmdType);
            commandType = (Classes.Button_Commands.CommandType)CmdType;
        }
    }
}
