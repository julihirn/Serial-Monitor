using ODModules;
using Serial_Monitor.Classes.Button_Commands;
using Serial_Monitor.Classes.Enums;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.Enums.ModbusEnums;
using Handlers;
using static Handlers.ConversionHandler;
using Serial_Monitor.Classes.Modbus;
using static ODModules.NumericTextbox;

namespace Serial_Monitor.Classes {
    public static class EnumManager {

        #region Modbus Data Size
        public static DataSize IntegerToDataSize(int Input) {
            if (Input == 8) {
                return DataSize.Bits8;
            }
            else if (Input == 16) {
                return DataSize.Bits16;
            }
            else if (Input == 32) {
                return DataSize.Bits32;
            }
            else if (Input == 64) {
                return DataSize.Bits64;
            }
            return DataSize.Bits16;
        }
        public static int DataSizeToInteger(DataSize Input) {
            if (Input == DataSize.Bits8) {
                return 8;
            }
            else if (Input == DataSize.Bits16) {
                return 16;
            }
            else if (Input == DataSize.Bits32) {
                return 32;
            }
            else if (Input == DataSize.Bits64) {
                return 64;
            }
            return 16;
        }
        public static string DataSizeToString(DataSize Input) {
            if (Input == DataSize.Bits8) {
                return "8 Bits";
            }
            else if (Input == DataSize.Bits16) {
                return "16 Bits";
            }
            else if (Input == DataSize.Bits32) {
                return "32 Bits";
            }
            else if (Input == DataSize.Bits64) {
                return "64 Bits";
            }
            return "16 Bits";
        }
        public static DataSize DataFormatToDataSize(DataFormat Input, DataSize CurrentSize) {
            if (Input == DataFormat.Double) {
                return DataSize.Bits64;
            }
            else if (Input == DataFormat.Float) {
                return DataSize.Bits32;
            }
            else if (Input == DataFormat.Char) {
                return DataSize.Bits16;
            }
            return CurrentSize;
        }
        public static DataFormat ChangeSizeDependantDataFormat(DataFormat Input) {
            if (Input == DataFormat.Double) {
                return DataFormat.Decimal;
            }
            else if (Input == DataFormat.Float) {
                return DataFormat.Decimal;
            }
            return Input;
        }
        #endregion
        #region Modbus Data Format
        public static CoilFormat StringToCoilFormat(string Input) {
            if (Input == "mbDataFrmtBoolean") {
                return CoilFormat.Boolean;
            }
            else if (Input == "mbDataFrmtBit") {
                return CoilFormat.Bit;
            }
            else if (Input == "mbDataFrmtPwrState") {
                return CoilFormat.PowerState;
            }
            else if (Input == "mbDataFrmtValState") {
                return CoilFormat.ValveState;
            }
            else if (Input == "mbDataFrmtValState") {
                return CoilFormat.ValveState;
            }
            else if (Input == "mbDataFrmEnabled") {
                return CoilFormat.EnabledState;
            }
            else if (Input == "mbDataFrmActivate") {
                return CoilFormat.ActivationState;
            }
            return CoilFormat.Boolean;
        }
        public static StringPair CoilFormatToString(CoilFormat Input) {
            if (Input == CoilFormat.Boolean) {
                return new StringPair("Boolean", "mbDataFrmtBoolean");
            }
            else if (Input == CoilFormat.Bit) {
                return new StringPair("Bit", "mbDataFrmtBit");
            }
            else if (Input == CoilFormat.PowerState) {
                return new StringPair("State (Power)", "mbDataFrmtPwrState");
            }
            else if (Input == CoilFormat.ValveState) {
                return new StringPair("State (Valve)", "mbDataFrmtValState");
            }
            else if (Input == CoilFormat.EnabledState) {
                return new StringPair("State (Enabled)", "mbDataFrmEnabled");
            }
            else if (Input == CoilFormat.ActivationState) {
                return new StringPair("State (Activation)", "mbDataFrmActivate");
            }
            return new StringPair("Boolean", "mbDataFrmtBoolean");
        }
        public static DataFormat StringToDataFormat(string Input) {
            if (Input == "mbDataFrmtBinary") {
                return DataFormat.Binary;
            }
            else if (Input == "mbDataFrmtOctal") {
                return DataFormat.Octal;
            }
            else if (Input == "mbDataFrmtDecimal") {
                return DataFormat.Decimal;
            }
            else if (Input == "mbDataFrmtHexadecimal") {
                return DataFormat.Hexadecimal;
            }
            else if (Input == "mbDataFrmtChar") {
                return DataFormat.Char;
            }
            else if (Input == "mbDataFrmtFloat") {
                return DataFormat.Float;
            }
            else if (Input == "mbDataFrmtDouble") {
                return DataFormat.Double;
            }
            return DataFormat.Decimal;
        }
        public static StringPair DataFormatToString(DataFormat Input) {
            if (Input == DataFormat.Binary) {
                return new StringPair("Binary", "mbDataFrmtBinary");
            }
            else if (Input == DataFormat.Octal) {
                return new StringPair("Octal", "mbDataFrmtOctal");
            }
            else if (Input == DataFormat.Decimal) {
                return new StringPair("Integer", "mbDataFrmtDecimal");
            }
            else if (Input == DataFormat.Hexadecimal) {
                return new StringPair("Hexadecimal", "mbDataFrmtHexadecimal");
            }
            else if (Input == DataFormat.Char) {
                return new StringPair("Character", "mbDataFrmtChar");
            }
            else if (Input == DataFormat.Float) {
                return new StringPair("Float", "mbDataFrmtFloat");
            }
            else if (Input == DataFormat.Double) {
                return new StringPair("Double", "mbDataFrmtDouble");
            }
            return new StringPair("Integer", "mbDataFrmtDecimal");
        }
        public static DataFormat IntegerToDataFormat(int Input) {
            DataFormat[] Formats = (DataFormat[])DataFormat.GetValues(typeof(Enums.ModbusEnums.DataFormat));
            if (Input < 0) { return Formats[0]; }
            else if (Input >= Formats.Length) { return Formats[Formats.Length - 1]; }
            else { return Formats[Input]; }
        }
        public static CoilFormat IntegerToCoilFormat(int Input) {
            CoilFormat[] Formats = (CoilFormat[])CoilFormat.GetValues(typeof(Enums.ModbusEnums.CoilFormat));
            if (Input < 0) { return Formats[0]; }
            else if (Input >= Formats.Length) { return Formats[Formats.Length - 1]; }
            else { return Formats[Input]; }
        }
        #endregion
        #region Modbus Word Order
        public static ByteOrder StringToWordOrder(string Input) {
            if (Input == "mbWordBigEnd") {
                return ByteOrder.BigEndian;
            }
            else if (Input == "mbWordLittleEnd") {
                return ByteOrder.LittleEndian;
            }
            else if (Input == "mbWordBigEndByteSwap") {
                return ByteOrder.BigEndianByteSwap;
            }
            else if (Input == "mbWordLittleEndByteSwap") {
                return ByteOrder.LittleEndianByteSwap;
            }
            return ByteOrder.LittleEndian;
        }
        public static StringPair WordOrderToString(ByteOrder Input) {
            if (Input == ByteOrder.BigEndian) {
                return new StringPair("Big Endian", "mbWordBigEnd");
            }
            else if (Input == ByteOrder.LittleEndian) {
                return new StringPair("Little Endian", "mbWordLittleEnd");
            }
            else if (Input == ByteOrder.BigEndianByteSwap) {
                return new StringPair("Big Endian (Byte Swap)", "mbWordBigEndByteSwap");
            }
            else if (Input == ByteOrder.LittleEndianByteSwap) {
                return new StringPair("Little Endian (Byte Swap)", "mbWordLittleEndByteSwap");
            }
            return new StringPair("Little Endian", "mbWordLittleEnd");
        }
        public static ByteOrder IntegerToWordOrder(int Input) {
            ByteOrder[] Formats = (ByteOrder[])ByteOrder.GetValues(typeof(Enums.ModbusEnums.ByteOrder));
            if (Input < 0) { return Formats[0]; }
            else if (Input >= Formats.Length) { return Formats[Formats.Length - 1]; }
            else { return Formats[Input]; }
        }
        #endregion
        #region Modbus Data Selection
        public static DataSelection ModbusStringToDataSelection(string Input) {
            if (Input == "mbTypeCoils") {
                return DataSelection.ModbusDataCoils;
            }
            else if (Input == "mbTypeDiscrete") {
                return DataSelection.ModbusDataDiscreteInputs;
            }
            else if (Input == "mbTypeRegHolding") {
                return DataSelection.ModbusDataHoldingRegisters;
            }
            else if (Input == "mbTypeRegInput") {
                return DataSelection.ModbusDataInputRegisters;
            }
            else if (Input == "C") {
                return DataSelection.ModbusDataCoils;
            }
            else if (Input == "D") {
                return DataSelection.ModbusDataDiscreteInputs;
            }
            else if (Input == "H") {
                return DataSelection.ModbusDataHoldingRegisters;
            }
            else if (Input == "I") {
                return DataSelection.ModbusDataInputRegisters;
            }
            return DataSelection.ModbusDataCoils;
        }
        public static StringPair ModbusDataSelectionToString(DataSelection Input, bool UseShortenCode = false) {
            if (Input == DataSelection.ModbusDataCoils) {
                if (UseShortenCode == false) {
                    return new StringPair("Coils", "mbTypeCoils");
                }
                return new StringPair("Coils", "C");
            }
            else if (Input == DataSelection.ModbusDataDiscreteInputs) {
                if (UseShortenCode == false) {
                    return new StringPair("Discrete", "mbTypeDiscrete");
                }
                return new StringPair("Discrete", "D");
            }
            else if (Input == DataSelection.ModbusDataHoldingRegisters) {
                if (UseShortenCode == false) {
                    return new StringPair("Holding Registers", "mbTypeRegHolding");
                }
                return new StringPair("Holding Registers", "H");
            }
            else if (Input == DataSelection.ModbusDataInputRegisters) {
                if (UseShortenCode == false) {
                    return new StringPair("Input Registers", "mbTypeRegInput");
                }
                return new StringPair("Input Registers", "I");
            }
            return new StringPair("Coils", "mbTypeCoils");
        }
        #endregion
        #region Modbus Snapshot Type
        public static SnapshotSelectionType ModbusStringToSnapshotType(string Input) {
            if (Input == "mbSSTypeConcurrent") {
                return SnapshotSelectionType.Concurrent;
            }
            else if (Input == "mbSSTypeCustom") {
                return SnapshotSelectionType.Custom;
            }
            return SnapshotSelectionType.Concurrent;
        }
        public static StringPair ModbusSnapshotTypeToString(SnapshotSelectionType Input) {
            if (Input == SnapshotSelectionType.Concurrent) {
                return new StringPair("Concurrent", "mbSSTypeConcurrent");
            }
            else if (Input == SnapshotSelectionType.Custom) {
                return new StringPair("Custom", "mbSSTypeCustom");
            }
            return new StringPair("Concurrent", "mbSSTypeConcurrent");
        }
        #endregion
        #region Keypad Button Command Types
        public static CommandType StringToCommandType(string Input) {
            if (Input.ToUpper() == "NONE") { return CommandType.NoAssignedCommand; }
            else if (Input.ToUpper() == "SENDSTR") { return CommandType.SendString; }
            else if (Input.ToUpper() == "SENDTXT") { return CommandType.SendText; }
            else if (Input.ToUpper() == "EXECMD") { return CommandType.ExecuteProgram; }
            else {
                return CommandType.NoAssignedCommand;
            }
        }
        public static string CommandTypeToString(CommandType Input) {
            if (Input == CommandType.NoAssignedCommand) { return "NONE"; }
            else if (Input == CommandType.SendString) { return "SENDSTR"; }
            else if (Input == CommandType.SendText) { return "SENDTXT"; }
            else if (Input == CommandType.ExecuteProgram) { return "EXECMD"; }
            else {
                return "NONE";
            }
        }
        #endregion
        #region Serial Port Stop Bits
        public static System.IO.Ports.StopBits StringToStopBits(string Input) {
            if (Input == "0") { return System.IO.Ports.StopBits.None; }
            else if (Input == "1") { return System.IO.Ports.StopBits.One; }
            else if (Input == "1.5") { return System.IO.Ports.StopBits.OnePointFive; }
            else if (Input == "2") { return System.IO.Ports.StopBits.Two; }
            return System.IO.Ports.StopBits.One;
        }
        public static string StopBitsToString(System.IO.Ports.StopBits Input) {
            if (Input == System.IO.Ports.StopBits.None) { return "0"; }
            else if (Input == System.IO.Ports.StopBits.One) { return "1"; }
            else if (Input == System.IO.Ports.StopBits.OnePointFive) { return "1.5"; }
            else if (Input == System.IO.Ports.StopBits.Two) { return "2"; }
            return "1";
        }
        #endregion
        #region Serial Port Parity
        public static System.IO.Ports.Parity StringToParity(string Input) {
            if (Input == "N") { return System.IO.Ports.Parity.None; }
            else if (Input == "M") { return System.IO.Ports.Parity.Mark; }
            else if (Input == "E") { return System.IO.Ports.Parity.Even; }
            else if (Input == "O") { return System.IO.Ports.Parity.Odd; }
            else if (Input == "S") { return System.IO.Ports.Parity.Space; }
            return System.IO.Ports.Parity.None;
        }
        public static string ParityToString(System.IO.Ports.Parity Input) {
            if (Input == System.IO.Ports.Parity.None) { return "N"; }
            else if (Input == System.IO.Ports.Parity.Mark) { return "M"; }
            else if (Input == System.IO.Ports.Parity.Even) { return "E"; }
            else if (Input == System.IO.Ports.Parity.Odd) { return "O"; }
            else if (Input == System.IO.Ports.Parity.Space) { return "S"; }
            return "N";
        }
        #endregion
        #region Serial Port Handshakes
        public static System.IO.Ports.Handshake StringToHandshake(string Input) {
            if (Input == "cfNone") { return System.IO.Ports.Handshake.None; }
            else if (Input == "cfXONXOFF") { return System.IO.Ports.Handshake.XOnXOff; }
            else if (Input == "cfRTSCTS") { return System.IO.Ports.Handshake.RequestToSend; }
            else if (Input == "cfDSRSTR") { return System.IO.Ports.Handshake.RequestToSendXOnXOff; }
            return System.IO.Ports.Handshake.None;
        }
        public static string HandshakeToString(System.IO.Ports.Handshake Input) {
            if (Input == System.IO.Ports.Handshake.None) { return "cfNone"; }
            else if (Input == System.IO.Ports.Handshake.XOnXOff) { return "cfXONXOFF"; }
            else if (Input == System.IO.Ports.Handshake.RequestToSend) { return "cfRTSCTS"; }
            else if (Input == System.IO.Ports.Handshake.RequestToSendXOnXOff) { return "cfDSRSTR"; }
            return "cfNone";
        }
        #endregion
        #region Input Formatting
        public static Enums.FormatEnums.StreamInputFormat StringToInputFormat(string Input) {
            if (Input == "frmTxt") {
                return Enums.FormatEnums.StreamInputFormat.Text;
            }
            else if (Input == "frmStream") {
                return Enums.FormatEnums.StreamInputFormat.BinaryStream;
            }
            else if (Input == "frmCCommand") {
                return Enums.FormatEnums.StreamInputFormat.CCommand;
            }
            else if (Input == "frmModbusRTU") {
                return Enums.FormatEnums.StreamInputFormat.ModbusRTU;
            }
            else if (Input == "frmModbusASCII") {
                return Enums.FormatEnums.StreamInputFormat.ModbusASCII;
            }
            else if (Input == "frmStreamBin") {
                return Enums.FormatEnums.StreamInputFormat.StreamBinary;
            }
            else if (Input == "frmStreamOct") {
                return Enums.FormatEnums.StreamInputFormat.StreamOctal;
            }
            else if (Input == "frmStreamDec") {
                return Enums.FormatEnums.StreamInputFormat.StreamDecimal;
            }
            else if (Input == "frmStreamHex") {
                return Enums.FormatEnums.StreamInputFormat.StreamHexadecimal;
            }
            return Enums.FormatEnums.StreamInputFormat.Text;
        }
        public static StringPair InputFormatToString(Enums.FormatEnums.StreamInputFormat Input, bool UseLongName = true) {
            if (Input == Enums.FormatEnums.StreamInputFormat.Text) {
                return new StringPair("&Text", "frmTxt");
            }
            else if (Input == Enums.FormatEnums.StreamInputFormat.BinaryStream) {
                if (UseLongName == true) {
                    return new StringPair("Binary &Stream", "frmStream");
                }
                else {
                    return new StringPair("Stream", "frmStream");
                }
            }
            else if (Input == Enums.FormatEnums.StreamInputFormat.CCommand) {
                if (UseLongName == true) {
                    return new StringPair("C &Command", "frmCCommand");
                }
                else {
                    return new StringPair("Command", "frmCCommand");
                }
            }
            else if (Input == Enums.FormatEnums.StreamInputFormat.ModbusRTU) {
                return new StringPair("Modbus &RTU", "frmModbusRTU");
            }
            else if (Input == Enums.FormatEnums.StreamInputFormat.ModbusASCII) {
                return new StringPair("Modbus &ASCII", "frmModbusASCII");
            }
            else if (Input == Enums.FormatEnums.StreamInputFormat.StreamBinary) {
                return new StringPair("&Binary", "frmStreamBin");
            }
            else if (Input == Enums.FormatEnums.StreamInputFormat.StreamOctal) {
                return new StringPair("&Octal", "frmStreamOct");
            }
            else if (Input == Enums.FormatEnums.StreamInputFormat.StreamDecimal) {
                return new StringPair("&Decimal", "frmStreamDec");
            }
            else if (Input == Enums.FormatEnums.StreamInputFormat.StreamHexadecimal) {
                return new StringPair("&Hexadecimal", "frmStreamHex");
            }
            return new StringPair("Text", "frmTxt");
        }
        #endregion
        #region Output Formatting
        public static Enums.FormatEnums.StreamOutputFormat StringToOutputFormat(string Input) {
            if (Input == "frmTxt") {
                return Enums.FormatEnums.StreamOutputFormat.Text;
            }
            else if (Input == "frmCCommand") {
                return Enums.FormatEnums.StreamOutputFormat.CCommand;
            }
            else if (Input == "frmModbusRTU") {
                return Enums.FormatEnums.StreamOutputFormat.ModbusRTU;
            }
            else if (Input == "frmModbusASCII") {
                return Enums.FormatEnums.StreamOutputFormat.ModbusASCII;
            }
            else if (Input == "frmStreamBin") {
                return Enums.FormatEnums.StreamOutputFormat.StreamBinary;
            }
            else if (Input == "frmStreamOct") {
                return Enums.FormatEnums.StreamOutputFormat.StreamOctal;
            }
            else if (Input == "frmStreamDec") {
                return Enums.FormatEnums.StreamOutputFormat.StreamDecimal;
            }
            else if (Input == "frmStreamHex") {
                return Enums.FormatEnums.StreamOutputFormat.StreamHexadecimal;
            }
            return Enums.FormatEnums.StreamOutputFormat.Text;
        }
        public static StringPair OutputFormatToString(Enums.FormatEnums.StreamOutputFormat Input, bool UseLongName = true) {
            if (Input == Enums.FormatEnums.StreamOutputFormat.Text) {
                return new StringPair("Text", "frmTxt");
            }
            else if (Input == Enums.FormatEnums.StreamOutputFormat.CCommand) {
                if (UseLongName == true) {
                    return new StringPair("C Command", "frmCCommand");
                }
                else {
                    return new StringPair("Command", "frmCCommand");
                }
            }
            else if (Input == Enums.FormatEnums.StreamOutputFormat.ModbusRTU) {
                return new StringPair("Modbus RTU", "frmModbusRTU");
            }
            else if (Input == Enums.FormatEnums.StreamOutputFormat.ModbusASCII) {
                return new StringPair("Modbus ASCII", "frmModbusASCII");
            }
            else if (Input == Enums.FormatEnums.StreamOutputFormat.StreamBinary) {
                return new StringPair("Binary", "frmStreamBin");
            }
            else if (Input == Enums.FormatEnums.StreamOutputFormat.StreamOctal) {
                return new StringPair("Octal", "frmStreamOct");
            }
            else if (Input == Enums.FormatEnums.StreamOutputFormat.StreamDecimal) {
                return new StringPair("Decimal", "frmStreamDec");
            }
            else if (Input == Enums.FormatEnums.StreamOutputFormat.StreamHexadecimal) {
                return new StringPair("Hexadecimal", "frmStreamHex");
            }
            return new StringPair("Text", "frmTxt");
        }
        #endregion
        #region Line Formatting
        public static Enums.FormatEnums.LineFormatting StringToLineFormatting(string Input) {
            if (Input == "frmLineNone") {
                return Enums.FormatEnums.LineFormatting.None;
            }
            else if (Input == "btnOptFrmLineLF") {
                return Enums.FormatEnums.LineFormatting.LF;
            }
            else if (Input == "frmLineCRLF") {
                return Enums.FormatEnums.LineFormatting.CRLF;
            }
            else if (Input == "frmLineCR") {
                return Enums.FormatEnums.LineFormatting.CR;
            }
            return Enums.FormatEnums.LineFormatting.None;
        }
        public static string LineFormattingToString(Enums.FormatEnums.LineFormatting Input) {
            if (Input == Enums.FormatEnums.LineFormatting.None) {
                return "frmLineNone";
            }
            else if (Input == Enums.FormatEnums.LineFormatting.LF) {
                return "frmLineLF";
            }
            else if (Input == Enums.FormatEnums.LineFormatting.CRLF) {
                return "frmLineCRLF";
            }
            else if (Input == Enums.FormatEnums.LineFormatting.CR) {
                return "frmLineCR";
            }
            return "frmLineNone";
        }
        #endregion

        private static bool FormatLookAhead(int CurrentIndex, ref Enums.FormatEnums.StreamInputFormat[] Formats) {
            if (CurrentIndex + 1 >= Formats.Length) { return false; }
            int CurrentValue = 0xFF00 & (int)Formats[CurrentIndex];
            int NextValue = 0xFF00 & (int)Formats[CurrentIndex + 1];
            return !(CurrentValue == NextValue);
        }
        private static bool FormatLookAhead(int CurrentIndex, ref Enums.FormatEnums.StreamOutputFormat[] Formats) {
            if (CurrentIndex + 1 >= Formats.Length) { return false; }
            int CurrentValue = 0xFF00 & (int)Formats[CurrentIndex];
            int NextValue = 0xFF00 & (int)Formats[CurrentIndex + 1];
            return !(CurrentValue == NextValue);
        }
        public static void LoadInputFormats(object DropDownList, EventHandler FormatClick, bool ApplyText = false) {
            Enums.FormatEnums.StreamInputFormat[] Formats = (Enums.FormatEnums.StreamInputFormat[])Enums.FormatEnums.StreamInputFormat.GetValues(typeof(Enums.FormatEnums.StreamInputFormat));
            int i = 0;
            foreach (Enums.FormatEnums.StreamInputFormat Frmt in Formats) {
                StringPair Data = EnumManager.InputFormatToString(Frmt, true);
                ToolStripMenuItem Tsi = new ToolStripMenuItem();
                Tsi.Text = Data.A;
                Tsi.Tag = Data.B;
                Tsi.ImageScaling = ToolStripItemImageScaling.None;
                if (Data.B == Properties.Settings.Default.DEF_STR_InputFormat) {
                    Tsi.Checked = true;
                    if (ApplyText == true) {
                        if (DropDownList.GetType() == typeof(ToolStripDropDownButton)) {
                            ToolStripDropDownButton Btn = (ToolStripDropDownButton)DropDownList;
                            Btn.Text = EnumManager.InputFormatToString(EnumManager.StringToInputFormat(Tsi.Tag.ToString() ?? ""), false).A;
                        }
                        else if (DropDownList.GetType() == typeof(ToolStripMenuItem)) {
                            ToolStripMenuItem Btn = (ToolStripMenuItem)DropDownList;
                            Btn.Text = EnumManager.InputFormatToString(EnumManager.StringToInputFormat(Tsi.Tag.ToString() ?? ""), false).A;
                        }
                    }
                }
                Tsi.Click += FormatClick;
                if (DropDownList.GetType() == typeof(ToolStripDropDownButton)) {
                    ToolStripDropDownButton Btn = (ToolStripDropDownButton)DropDownList;
                    Btn.DropDownItems.Add(Tsi);
                    if (FormatLookAhead(i, ref Formats)) {
                        ToolStripSeparator Sep = new ToolStripSeparator();
                        Btn.DropDownItems.Add(Sep);
                    }
                }
                else if (DropDownList.GetType() == typeof(ToolStripMenuItem)) {
                    ToolStripMenuItem Btn = (ToolStripMenuItem)DropDownList;
                    Btn.DropDownItems.Add(Tsi);
                    if (FormatLookAhead(i, ref Formats)) {
                        ToolStripSeparator Sep = new ToolStripSeparator();
                        Btn.DropDownItems.Add(Sep);
                    }
                }
                i++;
            }
        }
        public static void LoadOutputFormats(object DropDownList, EventHandler FormatClick, bool ApplyText = false) {
            int i = 0;
            Enums.FormatEnums.StreamOutputFormat[] Formats = (Enums.FormatEnums.StreamOutputFormat[])Enums.FormatEnums.StreamOutputFormat.GetValues(typeof(Enums.FormatEnums.StreamOutputFormat));
            foreach (Enums.FormatEnums.StreamOutputFormat Frmt in Formats) {
                StringPair Data = EnumManager.OutputFormatToString(Frmt, true);
                ToolStripMenuItem Tsi = new ToolStripMenuItem();
                Tsi.Text = Data.A;
                Tsi.Tag = Data.B;
                Tsi.ImageScaling = ToolStripItemImageScaling.None;
                if (Data.B == Properties.Settings.Default.DEF_STR_OutputFormat) {
                    Tsi.Checked = true;
                    if (ApplyText == true) {
                        if (DropDownList.GetType() == typeof(ToolStripDropDownButton)) {
                            ToolStripDropDownButton Btn = (ToolStripDropDownButton)DropDownList;
                            Btn.Text = EnumManager.OutputFormatToString(EnumManager.StringToOutputFormat(Tsi.Tag.ToString() ?? ""), false).A;
                        }
                        else if (DropDownList.GetType() == typeof(ToolStripMenuItem)) {
                            ToolStripMenuItem Btn = (ToolStripMenuItem)DropDownList;
                            Btn.Text = EnumManager.InputFormatToString(EnumManager.StringToInputFormat(Tsi.Tag.ToString() ?? ""), false).A;
                        }
                    }
                }
                Tsi.Click += FormatClick;
                if (DropDownList.GetType() == typeof(ToolStripDropDownButton)) {
                    ToolStripDropDownButton Btn = (ToolStripDropDownButton)DropDownList;
                    Btn.DropDownItems.Add(Tsi);
                    if (FormatLookAhead(i, ref Formats)) {
                        ToolStripSeparator Sep = new ToolStripSeparator();
                        Btn.DropDownItems.Add(Sep);
                    }
                }
                else if (DropDownList.GetType() == typeof(ToolStripMenuItem)) {
                    ToolStripMenuItem Btn = (ToolStripMenuItem)DropDownList;
                    Btn.DropDownItems.Add(Tsi);
                    if (FormatLookAhead(i, ref Formats)) {
                        ToolStripSeparator Sep = new ToolStripSeparator();
                        Btn.DropDownItems.Add(Sep);
                    }
                }
                i++;
            }
        }
        public static void ClearClickHandles(object DropDownList, EventHandler FormatClick) {
            if (DropDownList.GetType() == typeof(ContextMenu)) {
                ContextMenu Btn = (ContextMenu)DropDownList;
                foreach (ToolStripItem Tsi in Btn.Items) {
                    Btn.Click -= FormatClick;
                }
            }
            else if (DropDownList.GetType() == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem Btn = (ToolStripMenuItem)DropDownList;
                foreach (ToolStripItem Tsi in Btn.DropDownItems) {
                    Btn.Click -= FormatClick;
                }
            }
        }
        public static void LoadCoilFormats(object DropDownList, EventHandler FormatClick, bool ApplyChecked = false) {
            CoilFormat[] Formats = (CoilFormat[])CoilFormat.GetValues(typeof(Enums.ModbusEnums.CoilFormat));
            bool CheckFirst = true;
            foreach (ModbusEnums.CoilFormat Frmt in Formats) {
                StringPair Data = CoilFormatToString(Frmt);
                ToolStripMenuItem Tsi = new ToolStripMenuItem();
                Tsi.Text = Data.A;
                Tsi.ImageScaling = ToolStripItemImageScaling.None;
                Tsi.Tag = Frmt;
                Tsi.Click += FormatClick;
                if (CheckFirst) {
                    Tsi.Checked = true;
                    CheckFirst = false;
                }
                if (DropDownList.GetType() == typeof(ContextMenu)) {
                    ContextMenu Btn = (ContextMenu)DropDownList;
                    Btn.Items.Add(Tsi);
                }
                else if (DropDownList.GetType() == typeof(ToolStripMenuItem)) {
                    Tsi.Checked = false;
                    ToolStripMenuItem Btn = (ToolStripMenuItem)DropDownList;
                    Btn.DropDownItems.Add(Tsi);
                }
                else if (DropDownList.GetType() == typeof(ToolStripDropDownButton)) {
                    ToolStripDropDownButton Btn = (ToolStripDropDownButton)DropDownList;
                    if (ApplyChecked == false) { Tsi.Checked = false; }
                    else {
                        if (Tsi.Checked) {
                            Btn.Text = Data.A;
                        }
                    }
                    Btn.DropDownItems.Add(Tsi);
                }
            }
        }
        public static void LoadCoilFormats(object DropDownList, CoilFormat SelectedFormat) {
            CoilFormat[] Formats = (CoilFormat[])CoilFormat.GetValues(typeof(Enums.ModbusEnums.CoilFormat));
            bool CheckFirst = true;
            foreach (ModbusEnums.CoilFormat Frmt in Formats) {
                StringPair Data = CoilFormatToString(Frmt);
                if (DropDownList.GetType() == typeof(DropDownBox)) {
                    DropDownBox Btn = (DropDownBox)DropDownList;
                    Btn.Items.Add(Data.A);
                    if (SelectedFormat == Frmt) {
                        Btn.SelectedIndex = Btn.Items.Count - 1;
                    }
                }
            }
        }
        public static void LoadDataFormats(object DropDownList, EventHandler FormatClick, bool ApplyChecked = false) {
            DataFormat[] Formats = (DataFormat[])DataFormat.GetValues(typeof(Enums.ModbusEnums.DataFormat));
            bool CheckFirst = true;
            foreach (ModbusEnums.DataFormat Frmt in Formats) {
                StringPair Data = DataFormatToString(Frmt);
                ToolStripMenuItem Tsi = new ToolStripMenuItem();
                Tsi.Text = Data.A;
                Tsi.ImageScaling = ToolStripItemImageScaling.None;
                Tsi.Tag = Frmt;
                Tsi.Click += FormatClick;
                if (CheckFirst) {
                    Tsi.Checked = true;
                    CheckFirst = false;
                }
                if (DropDownList.GetType() == typeof(ContextMenu)) {
                    ContextMenu Btn = (ContextMenu)DropDownList;
                    Btn.Items.Add(Tsi);
                }
                else if (DropDownList.GetType() == typeof(ToolStripMenuItem)) {
                    Tsi.Checked = false;
                    ToolStripMenuItem Btn = (ToolStripMenuItem)DropDownList;
                    Btn.DropDownItems.Add(Tsi);
                }
                else if (DropDownList.GetType() == typeof(ToolStripDropDownButton)) {
                    ToolStripDropDownButton Btn = (ToolStripDropDownButton)DropDownList;
                    if (ApplyChecked == false) { Tsi.Checked = false; }
                    else {
                        if (Tsi.Checked) {
                            Btn.Text = Data.A;
                        }
                    }
                    Btn.DropDownItems.Add(Tsi);
                }
            }
        }
        public static void LoadDataFormats(object DropDownList, DataFormat SelectedFormat) {
            DataFormat[] Formats = (DataFormat[])DataFormat.GetValues(typeof(Enums.ModbusEnums.DataFormat));
            bool CheckFirst = true;
            foreach (ModbusEnums.DataFormat Frmt in Formats) {
                StringPair Data = DataFormatToString(Frmt);
                if (DropDownList.GetType() == typeof(DropDownBox)) {
                    DropDownBox Btn = (DropDownBox)DropDownList;
                    Btn.Items.Add(Data.A);
                    if (SelectedFormat == Frmt) {
                        Btn.SelectedIndex = Btn.Items.Count - 1;
                    }
                }
            }
        }
        public static void LoadDataSizes(object DropDownList, EventHandler FormatClick) {
            Enums.ModbusEnums.DataSize[] Formats = (DataSize[])DataSize.GetValues(typeof(Enums.ModbusEnums.DataSize));
            bool CheckFirst = true;
            foreach (ModbusEnums.DataSize Frmt in Formats) {
                string Data = DataSizeToString(Frmt);
                ToolStripMenuItem Tsi = new ToolStripMenuItem();
                Tsi.Text = Data;
                Tsi.ImageScaling = ToolStripItemImageScaling.None;
                Tsi.Tag = Frmt;
                Tsi.Click += FormatClick;
                if (CheckFirst) {
                    Tsi.Checked = true;
                    CheckFirst = false;
                }
                if (DropDownList.GetType() == typeof(ContextMenu)) {
                    ContextMenu Btn = (ContextMenu)DropDownList;
                    Btn.Items.Add(Tsi);
                }
                else if (DropDownList.GetType() == typeof(ToolStripMenuItem)) {
                    Tsi.Checked = false;
                    ToolStripMenuItem Btn = (ToolStripMenuItem)DropDownList;
                    Btn.DropDownItems.Add(Tsi);
                }
                else if (DropDownList.GetType() == typeof(ToolStripDropDownButton)) {
                    Tsi.Checked = false;
                    ToolStripDropDownButton Btn = (ToolStripDropDownButton)DropDownList;
                    Btn.DropDownItems.Add(Tsi);
                }
                else if (DropDownList.GetType() == typeof(ODModules.ToolStrip)) {
                    Tsi.Checked = false;
                    Tsi.Padding = new Padding(0, 0, 0, 0);
                    Tsi.Text = DataSizeToInteger(Frmt).ToString();
                    ODModules.ToolStrip TsMenu = (ODModules.ToolStrip)DropDownList;
                    TsMenu.Items.Add(Tsi);
                }
            }
        }
        public static void LoadWordOrders(object DropDownList, EventHandler FormatClick, bool ApplyChecked = false) {
            Enums.ModbusEnums.ByteOrder[] Formats = (ByteOrder[])ByteOrder.GetValues(typeof(Enums.ModbusEnums.ByteOrder));
            bool CheckFirst = true;
            foreach (ModbusEnums.ByteOrder Frmt in Formats) {
                string Data = WordOrderToString(Frmt).A;
                ToolStripMenuItem Tsi = new ToolStripMenuItem();
                Tsi.Text = Data;
                Tsi.ImageScaling = ToolStripItemImageScaling.None;
                Tsi.Tag = Frmt;
                Tsi.Click += FormatClick;
                if (CheckFirst) {
                    Tsi.Checked = true;
                    CheckFirst = false;
                }
                if (DropDownList.GetType() == typeof(ContextMenu)) {
                    ContextMenu Btn = (ContextMenu)DropDownList;
                    Btn.Items.Add(Tsi);
                }
                else if (DropDownList.GetType() == typeof(ToolStripMenuItem)) {
                    Tsi.Checked = false;
                    ToolStripMenuItem Btn = (ToolStripMenuItem)DropDownList;
                    Btn.DropDownItems.Add(Tsi);
                }
                else if (DropDownList.GetType() == typeof(ToolStripDropDownButton)) {
                    ToolStripDropDownButton Btn = (ToolStripDropDownButton)DropDownList;
                    if (ApplyChecked == false) { Tsi.Checked = false; }
                    else {
                        if (Tsi.Checked) {
                            Btn.Text = Data;
                        }
                    }
                    Btn.DropDownItems.Add(Tsi);
                }
            }
        }
        public static void LoadWordOrders(object DropDownList, ByteOrder SelectedFormat) {
            ByteOrder[] Formats = (ByteOrder[])ByteOrder.GetValues(typeof(Enums.ModbusEnums.ByteOrder));
            bool CheckFirst = true;
            foreach (ModbusEnums.ByteOrder Frmt in Formats) {
                StringPair Data =WordOrderToString(Frmt);
                if (DropDownList.GetType() == typeof(DropDownBox)) {
                    DropDownBox Btn = (DropDownBox)DropDownList;
                    Btn.Items.Add(Data.A);
                    if (SelectedFormat == Frmt) {
                        Btn.SelectedIndex = Btn.Items.Count - 1;
                    }
                }
            }
        }
        public static NumericTextbox.MetricPrefix GetPrefix(ModbusRegister? Register) {
            if (Register == null) { return MetricPrefix.None; }
            int Index = (int)Register.Prefix;
            return (MetricPrefix)Index;
        }
        public static void PushPrefix(ModbusRegister? Register, NumericTextbox.MetricPrefix PrefixToPush) {
            if (Register == null) { return; }
            int Index = (int)PrefixToPush;
            Register.Prefix = (Prefix)Index;
        }
    }
}
