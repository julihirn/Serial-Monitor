using Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.Enums.FormatEnums;
using static Serial_Monitor.Classes.Enums.ModbusEnums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Serial_Monitor.Classes {
    public static class Formatters {
        #region Low Level Converters
        public static unsafe int SingleToInt32Bits(float value) {
            return *(int*)(&value);
        }
        public static unsafe long DoubleToInt64Bits(double value) {
            return *(long*)(&value);
        }
        public static unsafe float Int32BitsToSingle(int value) {
            return *(float*)(&value);
        }
        public static unsafe double Int64BitsToDouble(long value) {
            return *(double*)(&value);
        }
        #endregion
        #region Human Readable Formatters
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
            StringBuilder Result = new StringBuilder();
            for (int i = 7; i >= 0; i--) {
                uint Shift = (uint)(0x01 << i);
                Result.Append((Input & Shift) == Shift ? '1' : '0');
            }
            return Result.ToString();
        }
        public static string ByteToHex(byte Input, bool AffixStart = true) {
            byte[] bytes = new byte[1];
            bytes[0] = Input;
            string str = BitConverter.ToString(bytes).ToUpper();
            string Prefix = "0x";
            StringBuilder Result = new StringBuilder();
            if (str.Length == 1) {
                if (AffixStart == true) {
                    Result.Append(Prefix); Result.Append('0'); Result.Append(str);
                }
                else { Result.Append('0'); Result.Append(str); }
            }
            else {
                if (AffixStart == true) { Result.Append(Prefix); Result.Append(str); }
            }
            return Result.ToString();
        }
        #endregion
        #region Modbus Data Input Formatters
        public static string LongToString(long Input, DataFormat Format, DataSize Size, bool IsSigned) {
            string Output = "0";
            if (Format == DataFormat.Binary) {
                string BinaryValue = LongToBinary(Input, Size);
                return PadBinary(BinaryValue, Size, PadFrequency.EveryFourth);
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
                float InputTemp = 0; float.TryParse(Input, out InputTemp);
                Output = (long)SingleToInt32Bits(InputTemp);
            }
            else if (Format == DataFormat.Double) {
                double InputTemp = 0; double.TryParse(Input, out InputTemp);
                Output = DoubleToInt64Bits(InputTemp);
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
        public static DualNumericalString GetBounds(DataSize Size, bool IsSigned) {
            BinaryFormatFlags Flags = GetFlags(Size, IsSigned);
            return MathHandler.GetBinaryFormatRange(Flags);
        }
        #endregion
        #region Stream Formatters
        public static bool StringToByteStream(string Data, DataFormat Format, out byte[] Output) {
            STR_MVSSF Values = StringHandler.SpiltStringMutipleValues(Data, ' ');
            Output = new byte[Values.Count];
            switch (Format) {
                case DataFormat.Binary:
                    return BinaryToByteStream(ref Values, ref Output);
                case DataFormat.Octal:
                    return OctalToByteStream(ref Values, ref Output);
                case DataFormat.Decimal:
                    return DecimalToByteStream(ref Values, ref Output);
                case DataFormat.Hexadecimal:
                    return HexadecimalToByteStream(ref Values, ref Output);
                default:
                    return false;
            }
        }
        private static bool BinaryToByteStream(ref STR_MVSSF Values, ref byte[] Output) {
            int i = 0;
            foreach (string Temp in Values.Value) {
                string TempStr = Temp.Trim().ToLower();
                if (TempStr.StartsWith("0b")) { TempStr = TempStr.Replace("0b", ""); }
                if (Regex.IsMatch(TempStr, @"^[0-1]+$")) {
                    if ((TempStr.Length >= 1) && (TempStr.Length <= 8)) {
                        byte Out = (byte)Convert.ToInt32(TempStr, 2);
                        Output[i] = Out;
                    }
                    else {
                        SystemManager.Print(ErrorType.M_Warning, "FRM_TX_LEN", "The value: '" + Temp + "', is too long.");
                        return false;
                    }
                }
                else {
                    SystemManager.Print(ErrorType.M_Warning, "FRM_TX_MM", "The value: '" + Temp + "', is not a binary number.");
                    return false;
                }
                i++;
            }
            return true;
        }
        private static bool OctalToByteStream(ref STR_MVSSF Values, ref byte[] Output) {
            int i = 0;
            foreach (string Temp in Values.Value) {
                string TempStr = Temp.Trim().ToLower();
                if (Regex.IsMatch(TempStr, @"^[0-7]+$")) {
                    if ((TempStr.Length >= 1) && (TempStr.Length <= 3)) {
                        byte Out = (byte)Convert.ToInt32(TempStr, 8);
                        Output[i] = Out;
                    }
                    else {
                        SystemManager.Print(ErrorType.M_Warning, "FRM_TX_LEN", "The value: '" + Temp + "', is too long.");
                        return false;
                    }
                }
                else {
                    SystemManager.Print(ErrorType.M_Warning, "FRM_TX_MM", "The value: '" + Temp + "', is not an octal number.");
                    return false;
                }
                i++;
            }
            return true;
        }
        private static bool DecimalToByteStream(ref STR_MVSSF Values, ref byte[] Output) {
            int i = 0;
            foreach (string Temp in Values.Value) {
                string TempStr = Temp.Trim().ToLower();
                if (Regex.IsMatch(TempStr, @"^[0-9]+$")) {
                    if ((TempStr.Length >= 1) && (TempStr.Length <= 3)) {
                        byte Out = (byte)Convert.ToInt32(TempStr);
                        Output[i] = Out;
                    }
                    else {
                        SystemManager.Print(ErrorType.M_Warning, "FRM_TX_LEN", "The value: '" + Temp + "', is too long.");
                        return false;
                    }
                }
                else {
                    SystemManager.Print(ErrorType.M_Warning, "FRM_TX_MM", "The value: '" + Temp + "', is not an integer.");
                    return false;
                }
                i++;
            }
            return true;
        }
        private static bool HexadecimalToByteStream(ref STR_MVSSF Values, ref byte[] Output) {
            int i = 0;
            foreach (string Temp in Values.Value) {
                string TempStr = Temp.Trim().ToLower();
                if (TempStr.StartsWith("0x")) { TempStr = TempStr.Replace("0x", ""); }
                if (Regex.IsMatch(TempStr, @"^[A-Fa-f0-9]+$")) {
                    if ((TempStr.Length >= 1) && (TempStr.Length <= 2)) {
                        byte Out = (byte)Convert.ToInt32(TempStr, 16);
                        Output[i] = Out;
                    }
                    else {
                        SystemManager.Print(ErrorType.M_Warning, "FRM_TX_LEN", "The value: '" + Temp + "', is too long.");
                        return false;
                    }
                }
                else {
                    SystemManager.Print(ErrorType.M_Warning, "FRM_TX_MM", "The value: '" + Temp + "', is not a hexadecimal number.");
                    return false;
                }
                i++;
            }
            return true;
        }
        #endregion
        #region Data Fromatters
        private static string PadBinary(string Input, DataSize Size, PadFrequency Frequency) {
            if (Frequency == PadFrequency.None) { return Input; }
            int SizeInt = EnumManager.DataSizeToInteger(Size);
            StringBuilder Sb = new StringBuilder();
            //string Output = "";
            int TickFrequency = 0;
            switch (Frequency) {
                case PadFrequency.EveryFourth:
                    TickFrequency = 4; break;
                case PadFrequency.EveryEighth:
                    TickFrequency = 8; break;
                default:
                    return Input;
            }
            for (int i = 0; i < Input.Length; i++) {
                int x = Input.Length - 1 - i;
              
                Sb.Append(Input[i]);
                if ((x != SizeInt - 1) && (x != 0)) {
                    if ((x % TickFrequency) == 0) {
                        Sb.Append(" ");
                    }
                }


            }
            return Sb.ToString();
        }
        public static bool StringToInteger(string Input, out int Output) {
            if (Regex.Match(Input, "(0x|0X)[0-9a-fA-F]{1,4}").Success == true) {
                string Temp = Input.Replace("0x", "").Replace("0X", "").Replace(" ", "");
                int i = Convert.ToInt32(Temp, 16);
                Output = (int)i;
                return true;
            }
            else if (Regex.Match(Input, "(0b|0B)([0-1]{4}\\s*){1,4}").Success == true) {
                string Temp = Input.ToLower();
                Temp = Temp.Replace("0b", "").Replace(" ", "");
                int i = Convert.ToInt32(Temp, 2);
                Output = (int)i;
                return true;
            }
            //else if (Regex.Match(Input, "(0x[0-1]{1,4})|(0X[0-9a-fA-F]{1,4})").Success == true) {
            //    int i = Convert.ToInt32(Input, 16);
            //    Output = (short)i;
            //    return true;
            //}
            else {
                return int.TryParse(Input, out Output);
            }
        }
        public static bool StringToShort(string Input, out short Output) {
            if (Regex.Match(Input, "(0x|0X)[0-9a-fA-F]{1,4}").Success == true) {
                string Temp = Input.Replace("0x", "").Replace("0X", "").Replace(" ","");
                int i = Convert.ToInt32(Temp, 16);
                Output = (short)i;
                return true;
            }
            else if (Regex.Match(Input, "(0b|0B)([0-1]{4}\\s*){1,4}").Success == true) {
                string Temp = Input.ToLower();
                Temp = Temp.Replace("0b", "").Replace(" ","");
                int i = Convert.ToInt32(Temp, 2);
                Output = (short)i;
                return true;
            }
            //else if (Regex.Match(Input, "(0x[0-1]{1,4})|(0X[0-9a-fA-F]{1,4})").Success == true) {
            //    int i = Convert.ToInt32(Input, 16);
            //    Output = (short)i;
            //    return true;
            //}
            else {
               return short.TryParse(Input, out Output);
            }
        }
        #endregion 
    }

}
