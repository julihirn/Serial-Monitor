using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Serial_Monitor.Classes.Enums {
    public static class FormatEnums {
        public enum StreamInputFormat {
            Text = 0x01,
            [Description("Binary Stream")]
            BinaryStream = 0x02,
            [Description("Command")]
            CCommand = 0x04,
            [Description("Modbus RTU")]
            ModbusRTU = 0x05,
            [Description("Modbus ASCII")]
            ModbusASCII = 0x06
        }
        public enum StreamOutputFormat {
            Text = 0x01,
            [Description("Command")]
            CCommand = 0x02,
            [Description("Modbus RTU")]
            ModbusRTU = 0x05,
            [Description("Modbus ASCII")]
            ModbusASCII = 0x06
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
            Toogle = 0x02
        }
    }
}
