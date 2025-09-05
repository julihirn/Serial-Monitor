using ODModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    internal class ModbusRegisterEdit {
        public ModbusRegister? Register = null;
        public int Column = -1;
        public ListItem Item;
        public DataSelection Selection;
        public ModbusRegisterEdit(ModbusRegister? reg, int column, ListItem Li, DataSelection dataSelect) {
            Register = reg;
            Column = column;
            this.Item = Li;
            this.Selection = dataSelect;
        }
    }
}
