using Serial_Monitor.Classes;
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
    public partial class ProgramProperties : Form {
        public ProgramProperties() {
            InitializeComponent();
        }
        ProgramObject? selectedProgram = null;
        bool AllowChanges = true;
        public ProgramObject? SelectedProgram {
            get { return selectedProgram; }
            set { 
                selectedProgram = value; 
                if (value != null) {
                    AllowChanges = false;
                    textBox1.Text = value.Name;
                    textBox2.Text = value.Command;
                    AllowChanges = true;
                }
            }
        }
        private void ProgramProperties_Load(object sender, EventArgs e) {
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (selectedProgram == null) {return;}
            if (AllowChanges == true) {
                selectedProgram.Name = textBox1.Text;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e) {
            if (selectedProgram == null) { return; }
            if (AllowChanges == true) {
                selectedProgram.Command = textBox2.Text;
            }
        }

        private void ProgramProperties_KeyPress(object sender, KeyPressEventArgs e) {
           
        }

        private void ProgramProperties_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                this.Close();
            }
        }

        private void ProgramProperties_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void ProgramProperties_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void ProgramProperties_FormClosing(object sender, FormClosingEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
    }
}
