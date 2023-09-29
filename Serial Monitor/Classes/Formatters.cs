﻿using Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.Enums.ModbusEnums;

namespace Serial_Monitor.Classes {
    public static class Formatters {
        public static unsafe int SingleToInt32Bits(float value) {
            return *(int*)(&value);
        }
        public static unsafe float Int32BitsToSingle(int value) {
            return *(float*)(&value);
        }
        public static unsafe double Int64BitsToDouble(long value) {
            return *(double*)(&value);
        }
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
        #region Modbus Data Input Formatters
        public static string LongToString(long Input, DataFormat Format, DataSize Size, bool IsSigned) {
            string Output = "0";
            if (Format == DataFormat.Binary) {
                return LongToBinary(Input, Size);
            }
            else if (Format == DataFormat.Octal) {
                return LongToOctal(Input, Size);
            }
            else if (Format == DataFormat.Decimal) {
                return LongToDecimal(Input, Size, IsSigned);
            }
            else if (Format == DataFormat.Hexadecimal) {
                return LongToHexadecimal(Input, Size);
            }
            else if (Format == DataFormat.Char) {
                char Data = (char)((long)0xFFFF & Input);
                Output = Data.ToString();
            }
            else if (Format == DataFormat.Float) {
                int Data = (int)((long)0xFFFFFFFF & Input);
                float Temp = Int32BitsToSingle(Data);
                Output = Temp.ToString();
            }
            else if (Format == DataFormat.Double) {
                double Data = Int64BitsToDouble(Input);
                Output = Data.ToString();
            }
            return Output;
        }
        private static string LongToBinary(long Input, DataSize Size) {
            if (Size == DataSize.Bits8) {
                byte Data = (byte)((long)0xFF & Input);
                return ByteToBinary(Data);
            }
            else if (Size == DataSize.Bits16) {
                short Data = (short)((long)0xFFFF & Input);
                return StringHandler.PadWithCharacter(Convert.ToString(Data, 2), 16, '0', false);
            }
            else if (Size == DataSize.Bits32) {
                int Data = (int)((long)0xFFFFFFFF & Input);
                return StringHandler.PadWithCharacter(Convert.ToString(Data, 2), 32, '0', false);
            }
            else if (Size == DataSize.Bits64) {
                return StringHandler.PadWithCharacter(Convert.ToString(Input, 2), 64, '0', false);
            }
            return "";
        }
        private static string LongToOctal(long Input, DataSize Size) {
            string Output = "0";
            if (Size == DataSize.Bits8) {
                byte Data = (byte)((long)0xFF & Input);
                Output = ByteToBinary(Data);
                return MathHandler.BinaryToOctal(Output);
            }
            else if (Size == DataSize.Bits16) {
                short Data = (short)((long)0xFFFF & Input);
                Output = StringHandler.PadWithCharacter(Convert.ToString(Data, 2), 16, '0', false);
                return MathHandler.BinaryToOctal(Output);
            }
            else if (Size == DataSize.Bits32) {
                int Data = (int)((long)0xFFFFFFFF & Input);
                Output = StringHandler.PadWithCharacter(Convert.ToString(Data, 2), 32, '0', false);
                return MathHandler.BinaryToOctal(Output);
            }
            else if (Size == DataSize.Bits64) {
                Output = StringHandler.PadWithCharacter(Convert.ToString(Input, 2), 64, '0', false);
                return MathHandler.BinaryToOctal(Output);
            }
            return "0";
        }
        private static string LongToDecimal(long Input, DataSize Size, bool IsSigned) {
            if (Size == DataSize.Bits8) {
                if (IsSigned == true) {
                    sbyte Data = (sbyte)((long)0xFF & Input);
                    return Data.ToString();
                }
                else {
                    byte Data = (byte)((long)0xFF & Input);
                    return Data.ToString();
                }
            }
            else if (Size == DataSize.Bits16) {
                if (IsSigned == false) {
                    ushort Data = (ushort)((long)0xFFFF & Input);
                    return Data.ToString();
                }
                else {
                    short Data = (short)((long)0xFFFF & Input);
                    return Data.ToString();
                }
            }
            else if (Size == DataSize.Bits32) {
                if (IsSigned == false) {
                    uint Data = (uint)((long)0xFFFFFFFF & Input);
                    return Data.ToString();
                }
                else {
                    int Data = (int)((long)0xFFFFFFFF & Input);
                    return Data.ToString();
                }
            }
            else if (Size == DataSize.Bits64) {
                if (IsSigned == false) {
                    return ((ulong)Input).ToString();
                }
                else {
                    return Input.ToString();
                }
            }
            return "0";
        }
        private static string LongToHexadecimal(long Input, DataSize Size) {
            string Output = "0";
            if (Size == DataSize.Bits8) {
                byte Data = (byte)((long)0xFF & Input);
                Output = ByteToBinary(Data);
                return MathHandler.BinaryToHexadecimal(Output);
            }
            else if (Size == DataSize.Bits16) {
                short Data = (short)((long)0xFFFF & Input);
                Output = StringHandler.PadWithCharacter(Convert.ToString(Data, 2), 16, '0', false);
                return MathHandler.BinaryToHexadecimal(Output);
            }
            else if (Size == DataSize.Bits32) {
                int Data = (int)((long)0xFFFFFFFF & Input);
                Output = StringHandler.PadWithCharacter(Convert.ToString(Data, 2), 32, '0', false);
                return MathHandler.BinaryToHexadecimal(Output);
            }
            else if (Size == DataSize.Bits64) {
                Output = StringHandler.PadWithCharacter(Convert.ToString(Input, 2), 64, '0', false);
                return MathHandler.BinaryToHexadecimal(Output);
            }
            return "0";
        }
        #endregion
        #region Modbus Data Output Formatters
        public static long StringToLong(string Input, DataFormat Format, DataSize Size, bool IsSigned) {
            long Output = 0;
            if (Format == DataFormat.Binary) {
                Output = MathHandler.BinaryToDecimal(Input, GetFlags(Size, IsSigned)).ToLong();
            }
            else if (Format == DataFormat.Octal) {
                Output = MathHandler.OctalToDecimal(Input, GetFlags(Size, IsSigned)).ToLong();
            }
            else if (Format == DataFormat.Hexadecimal) {
                Output = MathHandler.HexadecimalToDecimal(Input, GetFlags(Size, IsSigned)).ToLong();
            }
            else if (Format == DataFormat.Decimal) {
                Output = StringToDecimal(Input, Size, IsSigned);
            }
            else if (Format == DataFormat.Float) {
                float Temp = 0; float.TryParse(Input, out Temp);
                Output = (int)Temp;
            }
            else if (Format == DataFormat.Double) {
                double Temp = 0; double.TryParse(Input, out Temp);
                Output = (long)Temp;
            }
            else if (Format == DataFormat.Char) {
                char Temp = (char)0; char.TryParse(Input, out Temp);
                Output = (long)Temp;
            }
            return Output;
        }
        private static long StringToDecimal(string Input, DataSize Size, bool IsSigned) {
            if (Size == DataSize.Bits8) {
                if (IsSigned == true) {
                    sbyte Temp = 0; sbyte.TryParse(Input, out Temp);
                    return (long)Temp;
                }
                else {
                    byte Temp = 0; byte.TryParse(Input, out Temp);
                    return (long)Temp;
                }
            }
            else if (Size == DataSize.Bits16) {
                if (IsSigned == false) {
                    ushort Temp = 0; ushort.TryParse(Input, out Temp);
                    return (long)Temp;
                }
                else {
                    short Temp = 0; short.TryParse(Input, out Temp);
                    return (long)Temp;
                }
            }
            else if (Size == DataSize.Bits32) {
                if (IsSigned == false) {
                    uint Temp = 0; uint.TryParse(Input, out Temp);
                    return (long)Temp;
                }
                else {
                    int Temp = 0; int.TryParse(Input, out Temp);
                    return (long)Temp;
                }
            }
            else if (Size == DataSize.Bits64) {
                if (IsSigned == false) {
                    ulong Temp = 0; ulong.TryParse(Input, out Temp);
                    return (long)Temp;
                }
                else {
                    long Temp = 0; long.TryParse(Input, out Temp);
                    return Temp;
                }
            }
            return 0;
        }
        private static BinaryFormatFlags GetFlags(DataSize Size, bool IsSigned) {
            BinaryFormatFlags Output = IsSigned == true ? BinaryFormatFlags.Signed : 0x00;
            switch (Size) {
                case DataSize.Bits8:
                    Output |= BinaryFormatFlags.Length8Bit; break;
                case DataSize.Bits16:
                    Output |= BinaryFormatFlags.Length16Bit; break;
                case DataSize.Bits32:
                    Output |= BinaryFormatFlags.Length32Bit; break;
                case DataSize.Bits64:
                    Output |= BinaryFormatFlags.Length64Bit; break;
                default:
                    Output |= BinaryFormatFlags.Length16Bit; break;
            }
            return Output;
        }

        #endregion 
    }
  
}
