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
    public partial class ChecksumCalculator : Form, Interfaces.ITheme {
        public ChecksumCalculator() {
            InitializeComponent();
        }
        bool modbusRtu = true;
        bool ModbusRTU {
            get { return modbusRtu; }
            set { modbusRtu = value; }
        }
        public void ApplyTheme() {
            BackColor = Properties.Settings.Default.THM_COL_Editor;
        }

        private void ChecksumCalculator_Load(object sender, EventArgs e) {
            ApplyTheme();
        }
    }
}
