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
        public enum CoilFormat {
            Bit = 0x00,
            Boolean = 0x01,
            PowerState = 0x02,
            ValveState = 0x03,
            EnabledState = 0x04,
            ActivationState = 0x05
        }
        public enum DataSize {
            Bits8 = 0x00,
            Bits16 = 0x01,
            Bits32 = 0x02,
            Bits64 = 0x04
        }
        public enum SnapshotSelectionType {
            Concurrent = 0x00,
            Custom = 0x01
        }
        public enum ByteOrder {
            LittleEndian = 0x01,
            LittleEndianByteSwap = 0x02,
            //LittleEndian16 = 0x02,
            BigEndian = 0x03,
            BigEndianByteSwap = 0x04
        }
    }
}
