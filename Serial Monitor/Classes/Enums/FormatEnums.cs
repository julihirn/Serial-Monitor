using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Serial_Monitor.Classes.Enums {
    public static class FormatEnums {
        public enum StreamInputFormat {
            Text = 0x0001,
            [Description("Binary Stream")]
            BinaryStream = 0x0002,
            [Description("Hexadecimal Stream")]
            HexStream = 0x0003,
            [Description("Command")]
            CCommand = 0x0004,
            [Description("Modbus RTU")]
            ModbusRTU = 0x0201,
            [Description("Modbus ASCII")]
            ModbusASCII = 0x0202,
            [Description("Binary")]
            StreamBinary = 0x0401,
            [Description("Octal")]
            StreamOctal = 0x0402,
            [Description("Decimal")]
            StreamDecimal = 0x0403,
            [Description("Hexadecimal")]
            StreamHexadecimal = 0x0404
        }
        public enum StreamOutputFormat {
            Text = 0x0001,
            [Description("Command")]
            CCommand = 0x0002,
            [Description("Modbus RTU")]
            ModbusRTU = 0x0201,
            [Description("Modbus ASCII")]
            ModbusASCII = 0x0202,
            [Description("Binary")]
            StreamBinary = 0x0401,
            [Description("Octal")]
            StreamOctal = 0x0402,
            [Description("Decimal")]
            StreamDecimal = 0x0403,
            [Description("Hexadecimal")]
            StreamHexadecimal = 0x0404,
            [Description("Base 64")]
            Base64 = 0x0502
        }
        public enum LineFormatting {
            None = 0x00,
            LF = 0x01,
            CR = 0x02,
            CRLF = 0x03
        }
        public enum SignedState {
            Unsigned = 0x00,
            Signed = 0x01,
            Toggle = 0x02
        }
        public enum PadFrequency {
            None = 0x00,
            EveryFourth = 0x01,
            EveryEighth = 0x02
        }
    }
}
