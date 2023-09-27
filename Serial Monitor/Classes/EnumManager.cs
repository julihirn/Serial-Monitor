using Serial_Monitor.Classes.Button_Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes {
    public static class EnumManager {
        public static DataSelection StringToDataSelection(string Input) {
            if (Input == "mbTypeCoils") {
                return DataSelection.ModbusDataCoils;
            }
            else if (Input == "mbTypeDiscrete") {
                return DataSelection.ModbusDataDiscreteInputs;
            }
            else if (Input == "mbTypeHolding") {
                return DataSelection.ModbusDataHoldingRegisters;
            }
            else if (Input == "mbTypeInput") {
                return DataSelection.ModbusDataInputRegisters;
            }
            return DataSelection.ModbusDataCoils;
        }
        public static StringPair DataSelectionToString(DataSelection Input) {
            if (Input == DataSelection.ModbusDataCoils) {
                return new StringPair("Coils", "mbTypeCoils");
            }
            else if (Input == DataSelection.ModbusDataDiscreteInputs) {
                return new StringPair("Discrete", "mbTypeDiscrete");
            }
            else if (Input == DataSelection.ModbusDataHoldingRegisters) {
                return new StringPair("Holding Registers", "mbTypeHolding");
            }
            else if (Input == DataSelection.ModbusDataInputRegisters) {
                return new StringPair("Input Registers", "mbTypeInput");
            }
            return new StringPair("Coils", "mbTypeCoils");
        }



        public static DataSelection StringToModbusDataSelection(string Input) {
            if (Input == "viewRegTypeCoils") {
                return DataSelection.ModbusDataCoils;
            }
            else if (Input == "viewRegTypeHolding") {
                return DataSelection.ModbusDataHoldingRegisters;
            }
            else if (Input == "viewRegTypeDiscrete") {
                return DataSelection.ModbusDataDiscreteInputs;
            }
            else if (Input == "viewRegTypeRegisters") {
                return DataSelection.ModbusDataInputRegisters;
            }
            return DataSelection.ModbusDataCoils;
        }
        public static string ModbusDataSelectionToString(DataSelection Input) {
            if (Input == DataSelection.ModbusDataCoils) { return "viewRegTypeCoils"; }
            else if (Input == DataSelection.ModbusDataHoldingRegisters) { return "viewRegTypeHolding"; }
            else if (Input == DataSelection.ModbusDataDiscreteInputs) { return "viewRegTypeDiscrete"; }
            else if (Input == DataSelection.ModbusDataInputRegisters) { return "viewRegTypeRegisters"; }
            else {
                return "viewRegTypeCoils";
            }
        }
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
            return Enums.FormatEnums.StreamInputFormat.Text;
        }
        public static StringPair InputFormatToString(Enums.FormatEnums.StreamInputFormat Input, bool UseLongName = true) {
            if (Input == Enums.FormatEnums.StreamInputFormat.Text) {
                return new StringPair("&Text", "frmTxt");
            }
            else if (Input == Enums.FormatEnums.StreamInputFormat.BinaryStream) {
                if (UseLongName == true) {
                    return new StringPair("&Binary Stream", "frmStream");
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
            return new StringPair("Text", "frmTxt");
        }
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
            return new StringPair("Text", "frmTxt");
        }
        public static LineFormatting StringToLineFormatting(string Input) {
            if (Input == "frmLineNone") {
                return LineFormatting.None;
            }
            else if (Input == "btnOptFrmLineLF") {
                return LineFormatting.LF;
            }
            else if (Input == "frmLineCRLF") {
                return LineFormatting.CRLF;
            }
            else if (Input == "frmLineCR") {
                return LineFormatting.CR;
            }
            return LineFormatting.None;
        }
        public static string LineFormattingToString(LineFormatting Input) {
            if (Input == LineFormatting.None) {
                return "frmLineNone";
            }
            else if (Input == LineFormatting.LF) {
                return "frmLineLF";
            }
            else if (Input == LineFormatting.CRLF) {
                return "frmLineCRLF";
            }
            else if (Input == LineFormatting.CR) {
                return "frmLineCR";
            }
            return "frmLineNone";
        }


        public static void LoadInputFormats(object DropDownList, EventHandler FormatClick, bool ApplyText = false) {
            Enums.FormatEnums.StreamInputFormat[] Formats = (Enums.FormatEnums.StreamInputFormat[])Enums.FormatEnums.StreamInputFormat.GetValues(typeof(Enums.FormatEnums.StreamInputFormat));
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
                }
                else if (DropDownList.GetType() == typeof(ToolStripMenuItem)) {
                    ToolStripMenuItem Btn = (ToolStripMenuItem)DropDownList;
                    Btn.DropDownItems.Add(Tsi);
                }
            }
        }
        public static void LoadOutputFormats(object DropDownList, EventHandler FormatClick, bool ApplyText = false) {
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
                }
                else if (DropDownList.GetType() == typeof(ToolStripMenuItem)) {
                    ToolStripMenuItem Btn = (ToolStripMenuItem)DropDownList;
                    Btn.DropDownItems.Add(Tsi);
                }
            }
        }
    }
    public enum LineFormatting {
        None = 0x00,
        LF = 0x01,
        CR = 0x02,
        CRLF = 0x03
    }
}
