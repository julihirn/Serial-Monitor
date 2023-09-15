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
    public partial class Oscilloscope : Form {
        public Oscilloscope() {
            InitializeComponent();
        }

        private void Oscilloscope_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void Oscilloscope_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void Oscilloscope_FormClosed(object sender, FormClosedEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
    }
}
