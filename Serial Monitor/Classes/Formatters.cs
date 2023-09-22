using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes {
    public static class Formatters {
        public static string ByteToChar(byte Input) {
            char Val = (char)Input;
            switch (Val) {
                case '\r':
                    return "[CR]";
                case '\n':
                    return "[LF]";
                case (char)0x00:
                    return "[NUL]";
                case (char)0x01:
                    return "[SOH]";
                case (char)0x02:
                    return "[STX]";
                case (char)0x03:
                    return "[ETX]";
                case (char)0x04:
                    return "[EOT]";
                case (char)0x05:
                    return "[ENQ]";
                case (char)0x06:
                    return "[ACK]";
                case (char)0x07:
                    return "[BEL]";
                case (char)0x08:
                    return "[BS]";
                case (char)0x09:
                    return "[TAB]";
                case (char)0x0B:
                    return "[VT]";
                case (char)0x0C:
                    return "[FF]";
                case (char)0x0E:
                    return "[SO]";
                case (char)0x0F:
                    return "[SI]";
                case (char)0x10:
                    return "[DLE]";
                case (char)0x11:
                    return "[DC1]";
                case (char)0x12:
                    return "[DC2]";
                case (char)0x13:
                    return "[DC3]";
                case (char)0x14:
                    return "[DC4]";
                case (char)0x15:
                    return "[NAK]";
                case (char)0x16:
                    return "[SYN]";
                case (char)0x17:
                    return "[ETB]";
                case (char)0x18:
                    return "[CAN]";
                case (char)0x19:
                    return "[EM]";
                case (char)0x1A:
                    return "[SUB]";
                case (char)0x1B:
                    return "[ESC]";
                case (char)0x1C:
                    return "[FS]";
                case (char)0x1D:
                    return "[GS]";
                case (char)0x1E:
                    return "[RS]";
                case (char)0x1F:
                    return "[US]";
                default:
                    return Val.ToString();
            }
        }
        public static string ByteToBinary(byte Input) {
            string Result = "";
            for (int i = 7; i >= 0; i--) {
                uint Shift = (uint)(0x01 << i);

                Result += (Input & Shift) == Shift ? "1" : "0";
            }
            return Result;
        }
        public static string ByteToHex(byte Input) {
            byte[] bytes = new byte[1];
            bytes[0] = Input;
            string str = BitConverter.ToString(bytes);
            if (str.Length == 1) {
                str = "0x0" + str;
            }
            else { str = "0x" + str; }
            return str;
        }
    }
}
