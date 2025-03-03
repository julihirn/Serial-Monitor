using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.Enums.FormatEnums;

namespace Serial_Monitor.Classes.Support {
    public static class SerialSupport {
        public static string PrintStream(byte[] Data) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Data.Length; i++) {
                sb.Append(Classes.Formatters.ByteToHex(Data[i]));
                if (i < Data.Length - 1) {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
        public static bool IsModbusFormat(StreamOutputFormat Format) {
            if (Format == StreamOutputFormat.ModbusRTU) { return true; }
            else if (Format == StreamOutputFormat.ModbusASCII) { return true; }
            return false;
        }
        public static bool IsModbusFormat(StreamInputFormat Format) {
            if (Format == StreamInputFormat.ModbusRTU) { return true; }
            else if (Format == StreamInputFormat.ModbusASCII) { return true; }
            return false;
        }
    }
}
