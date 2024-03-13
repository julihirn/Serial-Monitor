using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.Docks {
    [ToolboxItem(true)]
    public partial class ModbusEditor : ODModules.Docking.DockDocument {
        public ModbusEditor() {
            InitializeComponent();
        }

        private void ModbusEditor_Load(object sender, EventArgs e) {

        }
    }
}
