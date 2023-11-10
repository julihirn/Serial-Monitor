using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Step_Programs {
    public enum DataType {
        Text = 0x00,
        Number = 0x01,
        Byte = 0x02,
        ModbusCustom = 0x03,
        EnumVal = 0x07,
        DualString = 0x08,
        CursorLocation = 0x30,
        WaitUntilRX = 0x6600,
        Null = 0xFFFFFF
    }
    public class VariableLinkage {
        string name = "";
        public string Name {
            get { return name; }
        }
        string assignment = "";
        public string Value {
            get { return assignment; }
            set { assignment = value; }
        }
        public VariableLinkage(string name, string assignment) {
            this.name = name;
            this.assignment = assignment;
        }
    }
}
