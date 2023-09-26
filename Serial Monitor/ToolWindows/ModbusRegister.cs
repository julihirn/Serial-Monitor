using Serial_Monitor.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.ToolWindows {
    public partial class ModbusRegister : Components.MdiClientForm, ITheme {
        public ModbusRegister() {
            InitializeComponent();
        }

        private void ModbusRegister_Load(object sender, EventArgs e) {
            ApplyTheme();
        }
        public void ApplyTheme() {
            this.CloseColor = Properties.Settings.Default.THM_COL_ForeColor;
            this.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            this.BorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            this.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            Classes.Theming.ThemeManager.ThemeControl(lstRegisters);
        }
    }
}
