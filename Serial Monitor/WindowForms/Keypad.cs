using Serial_Monitor.Classes.Step_Programs;
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
        }

        private void keypad1_ButtonClicked(object Sender, ODModules.KeypadButton Button, Point GridLocation) {
          
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
