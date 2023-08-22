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

namespace Serial_Monitor {
    public partial class Keypad : Form {
        public Keypad() {
            InitializeComponent();
        }

        private void Keypad_Load(object sender, EventArgs e) {
            keypad1.ExternalItems = Classes.ProjectManager.Buttons;
        }

        private void keypad1_ButtonClicked(object Sender, ODModules.KeypadButton Button, Point GridLocation) {
          
        }
    }
}
