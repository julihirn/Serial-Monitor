using Handlers;
using ODModules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Serial_Monitor.Classes {
    public class SerialManager {
        //Thread TrFramer;
        bool FramerRunning = true;
        public SerialManager() {
            Port.DataReceived += Port_DataReceived;
            Port.WriteTimeout = 1000;
            //TrFramer = new Thread(Framer);
            //TrFramer.IsBackground = true;
            //TrFramer.Start();
            for (int i = 0; i < short.MaxValue; i++) {
                coils[i] = new ModbusCoil(i, DataSelection.ModbusDataCoils);
                discreteInputs[i] = new ModbusCoil(i, DataSelection.ModbusDataDiscreteInputs);
                inputRegisters[i] = new ModbusRegister(i, DataSelection.ModbusDataInputRegisters);
                holdingRegisters[i] = new ModbusRegister(i, DataSelection.ModbusDataHoldingRegisters);
            }
        }
        ~SerialManager() {
            Port.DataReceived -= Port_DataReceived;
            try {
                if (Port.IsOpen == true) {
                    Port.Close();
                }
            }
            catch { }
            //if (TrFramer != null) {
            //    FramerRunning = false;
            //    TrFramer.Join();
            //}

        }

        public event CommandProcessedHandler? CommandProcessed;
        public delegate void CommandProcessedHandler(object sender, string Data);
        public delegate void DataProcessedHandler(object sender, bool PrintLine, string Data);
        public event DataProcessedHandler? DataReceived;
        const uint MAX_COMMAND_LENGTH = 500;
        public SerialPort Port = new SerialPort();
        public string StateName {
            get {
                if (Port == null) {
                    return name;
                }
                else {
                    if (name == "") {
                        return Port.PortName;
                    }
                    else { return name; }
                    // + ": " + Port.BaudRate.ToString() + ", " + Port.DataBits.ToString() + EnumManager.ParityToString(Port.Parity) + EnumManager.StopBitsToString(Port.StopBits);
                }
            }
        }
        #region Properties
        bool selected = false;
        public bool Selected {
            get { return selected; }
            set { selected = value; }
        }
        bool isMaster = false;
        public bool IsMaster {
            get { return isMaster; }
            set { isMaster = value; }
        }
        uint unitAddress = 1;
        public uint UnitAddress {
            get { return unitAddress; }
            set { unitAddress = value; }
        }
        bool systemEnabled = true;
        public bool SystemEnabled {
            get { return systemEnabled; }
            set { systemEnabled = value; }
        }
        string name = "Untitled";
        public string Name {
            get { return name; }
            set { name = value; }
        }
        long SilenceLength = 29166;
        public int BaudRate {
            get {
                if (Port != null) { return Port.BaudRate; }
                return 9600;
            }
            set {
                if (Port != null) {
                    Port.BaudRate = value;
                    SilenceLength = (long)(280000000.0m / (decimal)Port.BaudRate);
                }
            }
        }
        private ModbusCoil[] coils = new ModbusCoil[short.MaxValue];//new List<ModbusCoil>(short.MaxValue);//new ModbusCoil[short.MaxValue];
        public ModbusCoil[] Coils {
            get { return coils; }
        }
        private ModbusCoil[] discreteInputs = new ModbusCoil[short.MaxValue];//new List<ModbusCoil>(short.MaxValue); //new bool[short.MaxValue];
        public ModbusCoil[] DiscreteInputs {
            get { return discreteInputs; }
        }//ModbusRegister
        private ModbusRegister[] inputRegisters = new ModbusRegister[short.MaxValue]; //new short[short.MaxValue];
        public ModbusRegister[] InputRegisters {
            get { return inputRegisters; }
        }
        private ModbusRegister[] holdingRegisters = new ModbusRegister[short.MaxValue]; //new short[short.MaxValue];
        public ModbusRegister[] HoldingRegisters {
            get { return holdingRegisters; }
        }
        StreamInputFormat inputFormat = StreamInputFormat.Text;
        public StreamInputFormat InputFormat {
            get { return inputFormat; }
            set { inputFormat = value; }
        }
        StreamOutputFormat outputFormat = StreamOutputFormat.Text;
        public StreamOutputFormat OutputFormat {
            get { return outputFormat; }
            set { outputFormat = value; }
        }
        bool useCheckSums = true;
        public bool UseCheckSums {
            get {
                return useCheckSums;
            }
            set {
                useCheckSums = value;
            }
        }
        #endregion
        #region Reporting
        ulong commandsSent = 0;
        public ulong CommandsSent {
            get { return commandsSent; }
        }
        ulong commandsReceived = 0;
        public ulong CommandsReceived {
            get { return commandsReceived; }
        }
        ulong bytesSent = 0;
        public ulong BytesSent {
            get { return bytesSent; }
        }
        ulong bytesReceived = 0;
        public ulong BytesReceived {
            get { return bytesReceived; }
        }
        DateTime lastCommandReceivedTime = DateTime.Now;
        public DateTime LastCommandReceivedTime {
            get { return lastCommandReceivedTime; }
        }
        DateTime lastReceivedTime = DateTime.Now;
        public DateTime LastReceivedTime {
            get { return lastReceivedTime; }
        }
        DateTime lastTransmittedTime = DateTime.UtcNow;
        public DateTime LastTransmittedTime {
            get { return lastTransmittedTime; }
        }
        #endregion
        #region Transmission
        public bool Post(string Data, bool WriteLine = true) {
            try {
                switch (outputFormat) {
                    case StreamOutputFormat.Text:
                        if (Port.IsOpen) {
                            if (WriteLine == true) {
                                Port.WriteLine(Data);
                                bytesSent += (ulong)Data.Length + 2;
                            }
                            else {
                                Port.Write(Data);
                                bytesSent += (ulong)Data.Length;
                            }
                        }
                        break;
                    case StreamOutputFormat.CCommand:
                        Transmit(Data, false);
                        break;
                    case StreamOutputFormat.ModbusRTU:
                        ModbusCommand(Data);
                        break;
                }
                return true;
            }
            catch {
                return false;
            }
        }
        public bool Post(byte Data) {
            try {
                if (Port.IsOpen) {
                    byte[] Array = new byte[1];
                    Array[0] = Data;
                    Port.Write(Array, 0, 1);
                }
                return true;
            }
            catch {
                return false;
            }
        }

        #endregion
        #region Reception

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e) {
            switch (InputFormat) {
                case StreamInputFormat.Text:
                    TextProcessor(sender);
                    break;
                case StreamInputFormat.CCommand:
                    CCommandProcessor(sender);
                    break;
                case StreamInputFormat.BinaryStream:
                    StreamProcessor(sender);
                    break;
                case StreamInputFormat.ModbusRTU:
                    ModbusRTUProcessor(sender);
                    break;
                default:
                    break;
            }
            lastReceivedTime = DateTime.UtcNow;
        }
        #region Data Processing
        private void TextProcessor(object sender) {
            try {
                byte[] Buffer = new byte[ushort.MaxValue + 1];
                int i = 0;
                int BytesToRead = ((SerialPort)sender).BytesToRead;
                bytesReceived += (ulong)BytesToRead;
                i = ((SerialPort)sender).Read(Buffer, 0, BytesToRead);
                for (int j = 0; j < BytesToRead; j++) {
                    string Result = ((char)Buffer[j]).ToString();
                    //Output.AttendToLastLine(((char)Buffer[j]).ToString(), true);
                    DataReceived?.Invoke(this, false, Result);
                }
            }
            catch { }
        }
        private void CCommandProcessor(object sender) {
            try {
                byte[] Buffer = new byte[1000];
                int i = 0;
                int BytesToRead = ((SerialPort)sender).BytesToRead;
                bytesReceived += (ulong)BytesToRead;
                i = ((SerialPort)sender).Read(Buffer, 0, BytesToRead);
                for (int j = 0; j < BytesToRead; j++) {
                    ProcessByte(Buffer[j]);
                }
            }
            catch { }
        }
        private void StreamProcessor(object sender) {
            try {
                byte[] Buffer = new byte[1000];
                int i = 0;
                int BytesToRead = ((SerialPort)sender).BytesToRead;
                bytesReceived += (ulong)BytesToRead;
                i = ((SerialPort)sender).Read(Buffer, 0, BytesToRead);
                for (int j = 0; j < BytesToRead; j++) {
                    string Result = "";
                    Result += ByteToBinary(Buffer[j]) + "  ";
                    Result += ByteToHex(Buffer[j]) + "  ";
                    string Char = ((char)Buffer[j]).ToString();
                    Result += ByteToChar(Buffer[j]);
                    //Output.Print(Result);
                    DataReceived?.Invoke(this, true, Result);
                }
            }
            catch { }
        }

        byte[] RXBuffer = new byte[short.MaxValue];
        private int RXCurrentByte = 0;
        private void ModbusRTUProcessor(object sender) {
            try {
                if ((DateTime.UtcNow.Ticks - lastReceivedTime.Ticks) > SilenceLength) {
                    RXCurrentByte = 0;
                }
                int i = 0;
                int BytesToRead = ((SerialPort)sender).BytesToRead;
                byte[] Buffer = new byte[BytesToRead];
                bytesReceived += (ulong)BytesToRead;
                i = ((SerialPort)sender).Read(Buffer, 0, BytesToRead);
                Array.Copy(Buffer, 0, RXBuffer, RXCurrentByte, BytesToRead);
                RXCurrentByte += BytesToRead;
                if (Modbus.IsModbusFrameVaild(RXBuffer, RXCurrentByte) == true) {
                    DataReceived?.Invoke(this, true, PrintStream(Buffer));
                    if (isMaster == true) {
                        Modbus.FunctionCode Func = (Modbus.FunctionCode)Buffer[1];
                        switch (Func) {
                            case Modbus.FunctionCode.ReadCoils:
                                ModbusMasterReadCoils(Buffer, RXCurrentByte, false); break;
                            case Modbus.FunctionCode.WriteSingleCoil:
                            case Modbus.FunctionCode.ReadDiscreteInputs:
                                ModbusMasterReadCoils(Buffer, RXCurrentByte); break;
                            case Modbus.FunctionCode.ReadHoldingRegisters:
                                ModbusMasterReadRegisters(Buffer, RXCurrentByte); break;
                            case Modbus.FunctionCode.ReadInputRegisters:
                                ModbusMasterReadRegisters(Buffer, RXCurrentByte, false); break;
                            default:
                                //ModbusPostException(Buffer[0], (Modbus.FunctionCode)Buffer[1], ModbusException.IllegalFunction);
                                break;
                        }
                    }
                    else {
                        if (Buffer[0] == unitAddress) {
                            Modbus.FunctionCode Func = (Modbus.FunctionCode)Buffer[1];
                            switch (Func) {
                                case Modbus.FunctionCode.ReadCoils:
                                    ModbusSlaveReadCoils(Buffer, RXCurrentByte, false); break;
                                case Modbus.FunctionCode.WriteSingleCoil:
                                    ModbusSlaveWriteCoil(Buffer, RXCurrentByte); break;
                                case Modbus.FunctionCode.ReadDiscreteInputs:
                                    ModbusSlaveReadCoils(Buffer, RXCurrentByte); break;
                                case Modbus.FunctionCode.ReadHoldingRegisters:
                                    ModbusSlaveReadRegisters(Buffer, RXCurrentByte); break;
                                case Modbus.FunctionCode.ReadInputRegisters:
                                    ModbusSlaveReadRegisters(Buffer, RXCurrentByte, false); break;
                                case Modbus.FunctionCode.WriteSingleHoldingRegister:
                                    ModbusSlaveWriteRegister(Buffer, RXCurrentByte); break;
                                case Modbus.FunctionCode.WriteMultipleHoldingRegisters:
                                    ModbusSlaveWriteRegisters(Buffer, RXCurrentByte); break;
                                default:
                                    ModbusPostException(Buffer[0], (Modbus.FunctionCode)Buffer[1], ModbusException.IllegalFunction);
                                    break;
                            }
                        }
                    }
                    RXCurrentByte = 0;
                }

            }
            catch { }
        }

        #endregion
        #endregion
        #region Modbus
        private Modbus.FunctionCode LastSentCode;
        private short LastRequestedAddress = 0;
        private void ModbusPostException(int Address, Modbus.FunctionCode Function, ModbusException Code) {
            //Adr Fun Cde
            byte[] Output = new byte[5];
            byte[] Temp = new byte[3];
            Temp[0] = (byte)Address;//Adr
            Temp[1] = (byte)((byte)Function + (byte)0x80);//Fun
            Temp[2] = (byte)Code;//Len

            Array.Copy(Temp, 0, Output, 0, 3);
            ushort CRC = Modbus.CalculateCRC(Temp, (ushort)(3), 0);

            Output[4] = (byte)(CRC & 0xFF);
            Output[5] = (byte)(CRC >> 8);
            Port.Write(Output, 0, 5);
            bytesSent += (ulong)5;
            DataReceived?.Invoke(this, true, PrintStream(Output));
        }
        private void ModbusSlaveReadCoils(byte[] Input, int Length, bool IsDiscrete = true) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port != null) {
                if (Port.IsOpen) {
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    short CoilCount = (short)((Input[4] << 8) | Input[5]);
                    if ((CoilCount < 0x01) || (CoilCount > 0x07D0)) {
                        ModbusPostException(Input[0], (Modbus.FunctionCode)Input[1], ModbusException.IllegalDataValue);
                        return;
                    }
                    int Bytes = (CoilCount + 7) / 8;
                    int ArrayLength = 3 + Bytes;
                    byte[] Temp = new byte[ArrayLength];
                    Temp[0] = Input[0];//Adr
                    Temp[1] = Input[1];//Fun
                    Temp[2] = (byte)Bytes;//Len
                    int j = 0;
                    int k = 0;//Bytes - 1;
                    for (int i = 0; i < CoilCount; i++) {
                        byte BinTemp = 0x00;
                        if (IsDiscrete == true) {
                            BinTemp = (byte)(discreteInputs[StartAddress + i].Value == true ? 0x01 : 0x00);
                        }
                        else {
                            BinTemp = (byte)(coils[StartAddress + i].Value == true ? 0x01 : 0x00);
                        }
                        Temp[3 + k] |= (byte)(BinTemp << j);
                        j++;
                        if (j == 8) {
                            k++; j = 0;
                        }
                    }
                    TransmitFrame(Temp);
                }
            }
        }
        private void ModbusSlaveWriteCoil(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port != null) {
                if (Port.IsOpen) {
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    int Val = (int)((Input[4] << 8) | Input[5]);
                    coils[StartAddress].Value = Val == 0xFF00 ? true : false;

                    byte[] Temp = new byte[6];
                    Temp[0] = Input[0];//Adr
                    Temp[1] = Input[1];//Fun
                    Temp[2] = Input[2];//Str1
                    Temp[3] = Input[3];//Str1
                    Temp[4] = Input[4];//Val1
                    Temp[5] = Input[5];//Val2
                    TransmitFrame(Temp);
                }
            }
        }
        private void ModbusSlaveReadRegisters(byte[] Input, int Length, bool IsHolding = true) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port != null) {
                if (Port.IsOpen) {
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    short RegisterCount = (short)((Input[4] << 8) | Input[5]);
                    if ((RegisterCount < 0x01) || (RegisterCount > 0x7D)) {
                        ModbusPostException(Input[0], (Modbus.FunctionCode)Input[1], ModbusException.IllegalDataValue);
                        return;
                    }
                    int ArrayLength = 3 + (RegisterCount * 2);
                    byte[] Temp = new byte[ArrayLength];
                    Temp[0] = Input[0];
                    Temp[1] = Input[1];
                    Temp[2] = (byte)(RegisterCount * 2);
                    int Offset = 0;
                    if (IsHolding == true) {
                        for (int i = 0; i < RegisterCount; i++) {
                            Temp[3 + Offset] = (byte)(holdingRegisters[StartAddress + i].Value >> 8); Offset++;
                            Temp[3 + Offset] = (byte)(holdingRegisters[StartAddress + i].Value & 0xFF); Offset++;
                        }
                    }
                    else {
                        for (int i = 0; i < RegisterCount; i++) {
                            Temp[3 + Offset] = (byte)(inputRegisters[StartAddress + i].Value >> 8); Offset++;
                            Temp[3 + Offset] = (byte)(inputRegisters[StartAddress + i].Value & 0xFF); Offset++;
                        }
                    }
                    //DataReceived?.Invoke(this, true, PrintStream(Output));
                    TransmitFrame(Temp);
                }
            }
        }
        private void ModbusSlaveWriteRegister(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port != null) {
                if (Port.IsOpen) {
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    int Val = (int)((Input[4] << 8) | Input[5]);
                    holdingRegisters[StartAddress].Value = (short)Val;
                    byte[] Temp = new byte[6];
                    Temp[0] = Input[0];//Adr
                    Temp[1] = Input[1];//Fun
                    Temp[2] = Input[2];//Str1
                    Temp[3] = Input[3];//Str1
                    Temp[4] = Input[4];//Val1
                    Temp[5] = Input[5];//Val2
                    TransmitFrame(Temp);
                }
            }
        }
        private void ModbusSlaveWriteRegisters(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port != null) {
                if (Port.IsOpen) {
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    int Count = (int)((Input[4] << 8) | Input[5]);
                    if (Count > 0x007B) {
                        ModbusPostException(Input[0], (Modbus.FunctionCode)Input[1], ModbusException.IllegalDataValue);
                        return;
                    }
                    int Bytes = Input[6];
                    int j = 0;
                    for (int i = 0; i < Count; i++) {
                        int Val = (int)((Input[6 + j] << 8) | Input[7 + j]);
                        j += 2;
                        holdingRegisters[StartAddress + i].Value = (short)Val;
                    }
                    byte[] Temp = new byte[6];
                    Temp[0] = Input[0];//Adr
                    Temp[1] = Input[1];//Fun
                    Temp[2] = Input[2];//Str1
                    Temp[3] = Input[3];//Str1
                    Temp[4] = Input[4];//Cnt1
                    Temp[5] = Input[5];//Cnt2
                    TransmitFrame(Temp);
                }
            }
        }

        private void ModbusMasterReadCoils(byte[] Input, int Length, bool IsDiscrete = true) {
            int Bytes = Input[2];
            int k = 0;
            for (int i = 0; i < Bytes; i++) {
                for (int j = 0; j < 8; j++) {
                    int Temp = Input[3 + i];
                    bool TempBool = ((Temp >> j) & 0x01) == 0x01 ? true : false;
                    if (IsDiscrete == true) {
                        discreteInputs[LastRequestedAddress + k].Value = TempBool;
                    }
                    else {
                        coils[LastRequestedAddress + k].Value = TempBool;
                    }
                    k++;
                }
            }
        }
        private void ModbusMasterReadRegisters(byte[] Input, int Length, bool IsHolding = true) {
            int Count = Input[2] / 2;
            int k = 0;
            for (int i = 0; i < Count; i++) {
                short Temp = (short)(((int)Input[3 + k] << 8) | (int)Input[4 + k]);
                if (IsHolding == true) {
                    holdingRegisters[LastRequestedAddress + i].Value = Temp;
                }
                else {
                    inputRegisters[LastRequestedAddress + i].Value = Temp;
                }
                k += 2;
            }
        }
        private string PrintStream(byte[] Data) {
            string Temp = "";
            for (int i = 0; i < Data.Length; i++) {
                Temp += ByteToHex(Data[i]) + " ";
            }
            return Temp;
        }
        #endregion
        #region Modbus Functions
        public void ModbusReadCoils(int Device, short Address, short Count) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            if ((Device < 1) || (Count > 0x07D0)) {
                return;
            }
            byte[] Temp = new byte[6];
            Temp[0] = (byte)Device;//Adr
            Temp[1] = (byte)Modbus.FunctionCode.ReadCoils;//Fun
            Temp[2] = (byte)(Address >> 8);//Str1
            Temp[3] = (byte)(Address & 0xFF);//Str1
            Temp[4] = (byte)(Count >> 8);//Cnt1
            Temp[5] = (byte)(Count & 0xFF);//Cnt2
            LastRequestedAddress = Address;
            TransmitFrame(Temp);
        }
        public void ModbusReadDiscreteInputs(int Device, short Address, short Count) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            if ((Device < 1) || (Count > 0x07D0)) {
                return;
            }
            byte[] Temp = new byte[6];
            Temp[0] = (byte)Device;//Adr
            Temp[1] = (byte)Modbus.FunctionCode.ReadDiscreteInputs;//Fun
            Temp[2] = (byte)(Address >> 8);//Str1
            Temp[3] = (byte)(Address & 0xFF);//Str1
            Temp[4] = (byte)(Count >> 8);//Cnt1
            Temp[5] = (byte)(Count & 0xFF);//Cnt2
            LastRequestedAddress = Address;
            TransmitFrame(Temp);
        }
        public void ModbusReadInputRegisters(int Device, short Address, short Count) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            if ((Device < 1) || (Count > 0x7D)) {
                return;
            }
            byte[] Temp = new byte[5];
            Temp[0] = (byte)Device;//Adr
            Temp[1] = (byte)Modbus.FunctionCode.ReadInputRegisters;//Fun
            Temp[2] = (byte)(Address >> 8);//Str1
            Temp[3] = (byte)(Address & 0xFF);//Str1
            Temp[4] = (byte)(Count >> 8);//Cnt1
            Temp[5] = (byte)(Count & 0xFF);//Cnt2
            LastRequestedAddress = Address;
            TransmitFrame(Temp);
        }
        public void ModbusReadHoldingRegisters(int Device, short Address, short Count) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            if ((Device < 1) || (Count > 0x7D)) {
                return;
            }
            byte[] Temp = new byte[6];
            Temp[0] = (byte)Device;//Adr
            Temp[1] = (byte)Modbus.FunctionCode.ReadDiscreteInputs;//Fun
            Temp[2] = (byte)(Address >> 8);//Str1
            Temp[3] = (byte)(Address & 0xFF);//Str1
            Temp[4] = (byte)(Count >> 8);//Cnt1
            Temp[5] = (byte)(Count & 0xFF);//Cnt2
            LastRequestedAddress = Address;
            TransmitFrame(Temp);
        }
        public void ModbusWriteCoil(int Device, short Address, bool Value) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            byte[] Temp = new byte[6];
            Temp[0] = (byte)Device;//Adr
            Temp[1] = (byte)Modbus.FunctionCode.WriteSingleCoil;//Fun
            Temp[2] = (byte)(Address >> 8);//Str1
            Temp[3] = (byte)(Address & 0xFF);//Str1
            if (Value == true) {
                Temp[4] = (byte)0xFF;
            }
            else {
                Temp[4] = (byte)0x00;
            }
            //Cnt1
            Temp[5] = (byte)0x00;
            TransmitFrame(Temp);
        }
        public void ModbusWriteRegister(int Device, short Address, short Value) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            byte[] Temp = new byte[6];
            Temp[0] = (byte)Device;//Adr
            Temp[1] = (byte)Modbus.FunctionCode.WriteSingleHoldingRegister;//Fun
            Temp[2] = (byte)(Address >> 8);//Str1
            Temp[3] = (byte)(Address & 0xFF);//Str1
            Temp[4] = (byte)(Value >> 8);//Cnt1
            Temp[5] = (byte)(Value & 0xFF);//Cnt2

            TransmitFrame(Temp);
        }
        private void TransmitFrame(byte[] Data) {
            if ((DateTime.UtcNow.Ticks - LastTransmittedTime.Ticks) > SilenceLength) {

                byte[] Output = new byte[Data.Length + 2];
                ushort CRC = Modbus.CalculateCRC(Data, (ushort)Data.Length, 0);
                Array.Copy(Data, 0, Output, 0, Data.Length);
                Output[Output.Length - 2] = (byte)(CRC & 0xFF);
                Output[Output.Length - 1] = (byte)(CRC >> 8);
                Port.Write(Output, 0, Output.Length);
                bytesSent += (ulong)Output.Length;
                DataReceived?.Invoke(this, true, PrintStream(Output));
            }
        }
        public void ModbusCommand(string Input) {
            string Temp = Input.ToUpper().TrimStart(' ').TrimStart('\t');
            int Unit = 1;
            int Start = 0;
            int Count = 1;
            if (TestKeyword(ref Temp, "UNIT")) {
                string StrAddress = ReadAndRemove(ref Temp);

                bool Success = int.TryParse(StrAddress, out Unit);
                if (Success == false) { return; }

            }
            if (TestKeyword(ref Temp, "READ")) {
                if (GetValue(ref Temp, "COILS", out Start)) {
                    if (GetValue(ref Temp, "QTY", out Count)) {
                        ModbusReadCoils(Unit, (short)Start, (short)Count);
                    }
                    else { ModbusReadCoils(Unit, (short)Start, (short)1); }
                }
                else if (GetValue(ref Temp, "DISCRETE", out Start)) {
                    if (GetValue(ref Temp, "QTY", out Count)) {
                        ModbusReadDiscreteInputs(Unit, (short)Start, (short)Count);
                    }
                    else { ModbusReadDiscreteInputs(Unit, (short)Start, (short)1); }
                }
                else if (GetValue(ref Temp, "REGISTERS", out Start)) {
                    if (GetValue(ref Temp, "QTY", out Count)) {
                        ModbusReadHoldingRegisters(Unit, (short)Start, (short)Count);
                    }
                    else { ModbusReadHoldingRegisters(Unit, (short)Start, (short)1); }
                }
                else if (GetValue(ref Temp, "INREGISTERS", out Start)) {
                    if (GetValue(ref Temp, "QTY", out Count)) {
                        ModbusReadInputRegisters(Unit, (short)Start, (short)Count);
                    }
                    else { ModbusReadInputRegisters(Unit, (short)Start, (short)1); }
                }
            }
            else if (TestKeyword(ref Temp, "WRITE")) {
                if (GetValue(ref Temp, "COIL", out Start)) {
                    if (TestKeyword(ref Temp, "=")) {
                        bool Tbool = false;
                        if (Temp.Trim(' ') == "TRUE") {
                            Tbool = true;
                        }
                        else if (Temp.Trim(' ') == "T") {
                            Tbool = true;
                        }
                        else if (Temp.Trim(' ') == "1") {
                            Tbool = true;
                        }
                        ModbusWriteCoil(Unit, (short)Start, Tbool);
                    }
                }
                else if (GetValue(ref Temp, "REGISTER", out Start)) {
                    int Value = 0;
                    if (GetValue(ref Temp, "=", out Value)) {
                        ModbusWriteRegister(Unit, (short)Start, (short)Value);
                    }
                    else { ModbusWriteRegister(Unit, (short)Start, (short)0); }
                }
            }
        }
        private bool GetValue(ref string Input, string Compare, out int Value) {
            if (TestKeyword(ref Input, Compare)) {
                string StrAddress = ReadAndRemove(ref Input);

                bool Success = int.TryParse(StrAddress, out Value);
                if (Success == false) { return false; }
                return true;
            }
            Value = 0;
            return false;
        }
        private bool TestKeyword(ref string Input, string Compare) {
            if (Input.StartsWith(Compare)) {
                Input = Input.Remove(0, Compare.Length);
                Input = Input.TrimStart(' ');
                return true;
            }
            return false;
        }
        private string ReadAndRemove(ref string Input) {
            string Temp = Input.Split(' ')[0];
            Input = Input.Remove(0, Temp.Length);
            Input = Input.TrimStart(' ');
            return Temp;
        }
        #endregion
        #region Data Formatting
        private string ByteToChar(byte Input) {
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
        private string ByteToBinary(byte Input) {
            string Result = "";
            for (int i = 7; i >= 0; i--) {
                uint Shift = (uint)(0x01 << i);

                Result += (Input & Shift) == Shift ? "1" : "0";
            }
            return Result;
        }
        private string ByteToHex(byte Input) {
            byte[] bytes = new byte[1];
            bytes[0] = Input;
            string str = BitConverter.ToString(bytes);
            if (str.Length == 1) {
                str = "0x0" + str;
            }
            else { str = "0x" + str; }
            return str;
        }

        #endregion
        public bool Transmit(string Input, bool OverrideChecksum = false) {
            string BuildString = "C:" + Input + ";";
            if ((useCheckSums == true) && (OverrideChecksum == false)) {
                BuildString = "C:" + AppendCheckSum(Input) + ";";
            }
            try {
                if (Port.IsOpen == true) {
                    byte[] Array = new byte[100];
                    bytesSent += (ulong)BuildString.Length;
                    for (int i = 0; i < BuildString.Length; i++) {
                        Array[i] = (byte)BuildString[i];
                    }
                    Port.Write(Array, 0, BuildString.Length);
                }
                commandsSent++;
                return true;
            }
            catch { return false; }
        }
        #region Check Sum Handler
        public bool EvaluateCheckSum(string Input) {
            byte CheckInt = (byte)Input[Input.Length - 1];
            byte CheckSum = (byte)0;
            for (int i = 0; i < Input.Length - 1; i++) {
                CheckSum += (byte)Input[i];
            }
            if (CheckSum == 0x3B) { CheckSum += 10; }
            if (CheckSum == 0x00) { CheckSum += 5; }
            if (CheckInt == CheckSum) {
                return true;
            }
            return false;
        }
        private string AppendCheckSum(string Input) {
            if (Input == null) { return ""; }
            if (Input.Length == 0) { return ""; }
            byte CheckSum = 0;
            for (int i = 0; i < Input.Length; i++) {
                CheckSum += (byte)Input[i];
            }
            if (useCheckSums == true) {
                if (CheckSum == 0x3B) { CheckSum += 10; }
                if (CheckSum == 0x00) { CheckSum += 5; }
                return Input + (char)CheckSum;
            }
            else { return Input; }
        }
        #endregion
        #region Recieve Handler 
        string CurrentCommand = "";
        string BuildingCommand = "";
        MessageState State = MessageState.Ready;
        DateTime LastReceiveTime = DateTime.Now;
        uint CurrentByte = 0;
        public void ProcessByte(byte Input) {
            char TextByte = Convert.ToChar(Input);
            // Debug.Print(((char)TextByte).ToString());
            switch (State) {
                case MessageState.Ready:
                    if (TextByte == 'C') { State = MessageState.Armed; LastReceiveTime = DateTime.Now; }
                    return;
                case MessageState.Armed:
                    if (TextByte == ':') { State = MessageState.InCommand; CurrentByte = 0; }
                    else { State = MessageState.Ready; }
                    return;
                case MessageState.InCommand:
                    if (CurrentByte < MAX_COMMAND_LENGTH) {
                        if (TextByte == ';') { State = MessageState.Complete; }
                        else {
                            BuildingCommand += TextByte;
                            CurrentByte++;
                        }
                    }
                    else {
                        BuildingCommand = "";
                        State = MessageState.Ready;
                        CurrentByte = 0;
                        //TransmitErrorStatus(true, ERROR_COMMAND_TOO_LONG);
                    }
                    break;
                default:
                    break;
            }

            if (State == MessageState.Complete) {
                commandsReceived++;
                CurrentByte = 0;
                CurrentCommand = BuildingCommand;
                BuildingCommand = "";
                State = MessageState.Ready;
                if (useCheckSums == false) {
                    CommandProcessed?.Invoke(this, CurrentCommand);
                }
                else {
                    if (EvaluateCheckSum(CurrentCommand) == true) {
                        if (CurrentCommand.Length > 0) {
                            string CommandOut = CurrentCommand.Remove(CurrentCommand.Length - 1, 1);
                            CommandProcessed?.Invoke(this, CommandOut);
                        }
                    }
                }
                //ProcessCommandString(CurrentCommand);
                //Thread ThreadProcessCommand = new Thread(() => ProcessCommandString(CurrentCommand));
                //StateTime = DateTime.Now;
                //Thread ThreadProcessCommand = new Thread(ProcessCommandString);
                //ThreadProcessCommand.IsBackground = true;
                //ThreadProcessCommand.Start();
            }
        }
        #endregion
        private enum MessageState {
            Ready = 0x00,
            Armed = 0x01,
            InCommand = 0x02,
            Complete = 0x04
        }
        private enum ModbusException {
            IllegalFunction = 0x01,
            IllegalDataAddress = 0x02,
            IllegalDataValue = 0x03,
            SlaveDeviceFailure = 0x04
        }
    }
    public class ModbusCoil {
        int Index = 0;
        DataSelection typeData = DataSelection.ModbusDataCoils;
        public DataSelection ComponentType {
            get { return typeData; }
        }
        public int Address {
            get { return Index; }
        }
        public ModbusCoil(int index, DataSelection Type) {
            Index = index;
            typeData = Type;
        }
        bool coilValue = false;
        public bool Value {
            get { return coilValue; }
            set {
                coilValue = value;
                SystemManager.RegisterValueChanged(this, Index, typeData);
            }
        }
        string name = "";
        public string Name {
            get { return name; }
            set {
                name = value;
            }
        }
        bool userChanged = false;
        public bool UserChanged {
            get { return userChanged; }
        }
    }
    public class ModbusRegister {
        int Index = 0;
        DataSelection typeData = DataSelection.ModbusDataCoils;
        public DataSelection ComponentType {
            get { return typeData; }
        }
        public int Address {
            get { return Index; }
        }
        public ModbusRegister(int index, DataSelection Type) {
            Index = index;
            typeData = Type;
        }
        short regValue = 0;
        public short Value {
            get { return regValue; }
            set {
                regValue = value;
                SystemManager.RegisterValueChanged(this, Index, typeData);
            }
        }
        string name = "";
        public string Name {
            get { return name; }
            set { name = value; }
        }
        bool userChanged = false;
        public bool UserChanged {
            get { return userChanged; }
        }
    }
    public enum DataSelection {
        ModbusDataCoils = 0x00,
        ModbusDataDiscreteInputs = 0x01,
        ModbusDataInputRegisters = 0x02,
        ModbusDataHoldingRegisters = 0x03
    }
}
