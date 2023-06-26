using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes {
    public class ModbusData {
        List<short> Registers = new List<short>();
        List<bool> Coils = new List<bool>();
        Modbus.FunctionCode Code;
        public ModbusData() {

        }
    }
}
