using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Enums {
    public static class ModbusEnums {
        public enum DataFormat {
            Binary = 0x00,
            Octal = 0x01,
            Decimal = 0x02,
            Hexadecimal = 0x03,
            Char = 0x04,
            Float = 0x05,
            Double = 0x06
        }
        public enum DataSize {
            Bits8 = 0x00,
            Bits16 = 0x01,
            Bits32 = 0x02,
            Bits64 = 0x04,
        }
    }
}
