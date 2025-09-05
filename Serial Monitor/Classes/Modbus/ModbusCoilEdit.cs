using ODModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    internal class ModbusCoilEdit {
        public ModbusCoil? Coil = null;
        public int Column = -1;
        public ListItem Item;
        public DataSelection Selection;
        public ModbusCoilEdit(ModbusCoil? coil, int column, ListItem Li, DataSelection dataSet) {
            Coil = coil;
            Column = column;
            this.Item = Li;
            this.Selection = dataSet;
        }
    }
}
