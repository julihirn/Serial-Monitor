using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes {
    public static class EnumManager {
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
        public static StreamInputFormat StringToInputFormat(string Input) {
            if (Input == "frmTxt") {
                return StreamInputFormat.Text;
            }
            else if (Input == "frmStream") {
                return StreamInputFormat.BinaryStream;
            }
            else if (Input == "frmCCommand") {
                return StreamInputFormat.CCommand;
            }
            else if (Input == "frmModbusRTU") {
                return StreamInputFormat.ModbusRTU;
            }
            return StreamInputFormat.Text;
        }
        public static StringPair InputFormatToString(StreamInputFormat Input) {
            if (Input == StreamInputFormat.Text) {
                return new StringPair("Text", "frmTxt");
            }
            else if (Input == StreamInputFormat.BinaryStream) {
                return new StringPair("Binary Stream", "frmStream");
            }
            else if (Input == StreamInputFormat.CCommand) {
                return new StringPair("C Command", "frmCCommand");
            }
            else if (Input == StreamInputFormat.ModbusRTU) {
                return new StringPair("Modbus RTU", "frmModbusRTU");
            }
            return new StringPair("Text", "frmTxt");
        }
        public static StreamOutputFormat StringToOutputFormat(string Input) {
            if (Input == "frmTxt") {
                return StreamOutputFormat.Text;
            }
            else if (Input == "frmCCommand") {
                return StreamOutputFormat.CCommand;
            }
            else if (Input == "frmModbusRTU") {
                return StreamOutputFormat.ModbusRTU;
            }
            return StreamOutputFormat.Text;
        }
        public static StringPair OutputFormatToString(StreamOutputFormat Input) {
            if (Input == StreamOutputFormat.Text) {
                return new StringPair("Text", "frmTxt");
            }
            else if (Input == StreamOutputFormat.CCommand) {
                return new StringPair("C Command", "frmCCommand");
            }
            else if (Input == StreamOutputFormat.ModbusRTU) {
                return new StringPair("Modbus RTU", "frmModbusRTU");
            }
            return new StringPair("Text", "frmTxt");
        }
    }
}
