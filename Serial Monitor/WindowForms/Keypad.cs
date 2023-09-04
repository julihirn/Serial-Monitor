using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Button_Commands;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.WindowForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Serial_Monitor {
    public partial class Keypad : Form, Interfaces.ITheme {
        public Keypad() {
            InitializeComponent();
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
        }

        private void Keypad_Load(object sender, EventArgs e) {

            kpCommands.ExternalItems = Classes.ProjectManager.Buttons;
            RecolorAll();
        }

        private void keypad1_ButtonClicked(object Sender, ODModules.KeypadButton Button, Point GridLocation) {
            if (Button.Tag == null) { return; }
            if (Button.Tag.GetType() == typeof(BtnCommand)){
                BtnCommand btnCommand = (BtnCommand)Button.Tag;
                if (btnCommand.Type == Classes.Button_Commands.CommandType.SendString) {
                    SystemManager.SendString(btnCommand.Channel, btnCommand.CommandLine);
                }
                else if (btnCommand.Type == Classes.Button_Commands.CommandType.SendText) {
                    SystemManager.SendTextFile(btnCommand.Channel, btnCommand.CommandLine);
                }
                else if (btnCommand.Type == Classes.Button_Commands.CommandType.ExecuteProgram) {
                    ProgramManager.ExecuteProgram(btnCommand.CommandLine);
                }
            }
        }
        private void kpCommands_ButtonRightClicked(object Sender, ODModules.KeypadButton Button, Point GridLocation) {
            if (Button.Tag == null) { return; }
            if (Button.Tag.GetType() == typeof(BtnCommand)) {
                BtnCommand btnCommand = (BtnCommand)Button.Tag;
                KeypadButtonProperties KpbtnProp = new KeypadButtonProperties();
                KpbtnProp.Command = btnCommand.CommandLine;
                KpbtnProp.ButtonName = Button.Text;
                KpbtnProp.ShowDialog();

                if (KpbtnProp.DialogResult == DialogResult.OK) {
                    btnCommand.CommandLine = KpbtnProp.Command;
                    btnCommand.Type = KpbtnProp.CommandType;
                    Button.Text = KpbtnProp.ButtonName;
                }
                kpCommands.Invalidate();
            }
        }
        public void ApplyTheme() {

            RecolorAll();
        }
        private void RecolorAll() {
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            kpCommands.BackColor = Properties.Settings.Default.THM_COL_Editor;
            kpCommands.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            kpCommands.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            kpCommands.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            //kpCommands.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
            //kpCommands.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;
            kpCommands.BorderColorNorth = Properties.Settings.Default.THM_COL_BorderColor;
            kpCommands.BorderColorSouth = Properties.Settings.Default.THM_COL_BorderColor;

            kpCommands.BackColorHoverNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            kpCommands.BackColorHoverSouth = Properties.Settings.Default.THM_COL_ButtonSelected;

           
        }
    }
}
