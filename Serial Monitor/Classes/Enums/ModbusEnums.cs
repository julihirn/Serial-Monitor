using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Enums {
    public static class ModbusEnums {
        public enum AddressSystem {
            ZeroBasedDecimal = 0x000,
            OneBasedDecimal = 0x001,
            ZeroBasedHexadecimal = 0x100,
            OneBasedHexadecimal = 0x102,
            ZeroBasedOctal = 0x103,
            OneBasedOctal = 0x104,
            PLCAddress = 0x1F8
        }
        public enum DataFormat : byte {
            Binary = 0x00,
            Octal = 0x01,
            Decimal = 0x02,
            Hexadecimal = 0x03,
            Char = 0x04,
            Float = 0x05,
            Double = 0x06
        }
        public enum CoilFormat : byte {
            Bit = 0x00,
            Boolean = 0x01,
            PowerState = 0x02,
            ValveState = 0x03,
            EnabledState = 0x04,
            ActivationState = 0x05
        }
        public enum DataSize : byte {
            Bits8 = 0x00,
            Bits16 = 0x01,
            Bits32 = 0x02,
            Bits64 = 0x04
        }
        public enum SnapshotSelectionType : byte {
            Concurrent = 0x00,
            Custom = 0x01
        }
        public enum ByteOrder : byte {
            LittleEndian = 0x01,
            LittleEndianByteSwap = 0x02,
            //LittleEndian16 = 0x02,
            BigEndian = 0x03,
            BigEndianByteSwap = 0x04
        }
        public enum FloatFormat : byte {
            None = 0x00,
            //0.0
            FixedPlaces1 = 0x01,
            //0.00
            FixedPlaces2 = 0x02,
            //0.000
            FixedPlaces3 = 0x03,
            //0.0000
            FixedPlaces4 = 0x04,
            //0.00000
            FixedPlaces5 = 0x05,
            //0.000000
            FixedPlaces6 = 0x06,
            //0.0000000
            FixedPlaces7 = 0x07,
            //0.00000000
            FixedPlaces8 = 0x08,
            //0.000000000
            FixedPlaces9 = 0x09,
            //0.0000000000
            FixedPlaces10 = 0x0A,
            //0.00000000000
            FixedPlaces11 = 0x0B,
            //0.000000000000
            FixedPlaces12 = 0x0C

        }
        public enum DataType : byte { 
            Void = 0x00,
            Coil = 0x01,
            Register = 0x02,
            CoilArray = 0x04,
            RegisterArray = 0x08
        }
    }
}
