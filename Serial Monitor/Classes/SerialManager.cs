using Handlers;
using ODModules;
using Serial_Monitor.Classes.Modbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.Enums.FormatEnums;

namespace Serial_Monitor.Classes {
    public class SerialManager {
        //Thread TrFramer;
        //bool FramerRunning = true;
        Thread HeartbeatThread = null; // new Thread();
        public SerialManager() {
            iD = Guid.NewGuid().ToString();
            Port.DataReceived += Port_DataReceived;
            Port.WriteTimeout = 1000;
            HeartbeatThread = new Thread(HeartBeat);
            HeartbeatThread.IsBackground = true;
            HeartbeatThread.Start();
            //TrFramer = new Thread(Framer);
            //TrFramer.IsBackground = true;
            //TrFramer.Start();
            for (int i = 0; i < Modbus.ModbusSupport.MaximumRegisters; i++) {
                coils[i] = new ModbusCoil(i, DataSelection.ModbusDataCoils, this);
                discreteInputs[i] = new ModbusCoil(i, DataSelection.ModbusDataDiscreteInputs, this);
                inputRegisters[i] = new ModbusRegister(i, DataSelection.ModbusDataInputRegisters, this);
                holdingRegisters[i] = new ModbusRegister(i, DataSelection.ModbusDataHoldingRegisters, this);
            }
        }
        ~SerialManager() {
            CleanUp();

        }
        public void CleanUp() {
            RunHeartBeat = false;
            Array.Clear(coils, 0, coils.Length);
            Array.Clear(discreteInputs, 0, discreteInputs.Length);
            Array.Clear(inputRegisters, 0, inputRegisters.Length);
            Array.Clear(holdingRegisters, 0, holdingRegisters.Length);
            coils = new ModbusCoil[0];
            discreteInputs = new ModbusCoil[0];
            inputRegisters = new ModbusRegister[0];
            holdingRegisters = new ModbusRegister[0];
            try {
                Port.DataReceived -= Port_DataReceived;
                if (Port.IsOpen == true) {
                    Port.Close();
                }
            }
            catch { }
            GC.Collect();
        }
        bool RunHeartBeat = true;
        bool OpenPrevious = false;
        private void HeartBeat() {
            while (RunHeartBeat) {
                try {
                    if (autoReconnect == true) {
                        if (OpenPrevious != Port.IsOpen) {
                            SystemManager.InvokePortStatusChanged(this);
                            OpenPrevious = Port.IsOpen;
                        }
                        if (Port.IsOpen == false) {
                            Port.Open();
                        }
                    }
                }
                catch { }
                Thread.Sleep(1000);
            }
        }
        public event NameChangedHandler? NameChanged;
        public delegate void NameChangedHandler(object sender, string Data);

        public event CommandProcessedHandler? CommandProcessed;
        public delegate void CommandProcessedHandler(object sender, string Data);
        public delegate void DataProcessedHandler(object sender, bool PrintLine, string Data);
        public event DataProcessedHandler? DataReceived;
        public SerialPort Port = new SerialPort();
        [Browsable(false)]
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
        string iD = "";
        [Browsable(false)]
        public string ID {
            get { return iD; }
        }
        bool selected = false;
        [Browsable(false)]
        public bool Selected {
            get { return selected; }
            set { selected = value; }
        }
        bool outputToMasterTerminal = true;
        [Category("General")]
        [DisplayName("Output to Terminal")]
        public bool OutputToMasterTerminal {
            get { return outputToMasterTerminal; }
            set {
                outputToMasterTerminal = value;
                SystemManager.InvokeChannelPropertiesChanged(this);
            }
        }
        bool isMaster = false;
        [Category("Modbus")]
        [DisplayName("Modbus Master")]
        public bool IsMaster {
            get { return isMaster; }
            set {
                isMaster = value;
                SystemManager.InvokeChannelPropertiesChanged(this);
            }
        }
        uint unitAddress = 1;
        [Category("Modbus")]
        [DisplayName("Unit Address")]
        public uint UnitAddress {
            get { return unitAddress; }
            set {
                unitAddress = value;
                SystemManager.InvokeChannelPropertiesChanged(this);
            }
        }
        bool autoReconnect = false;
        [DisplayName("Auto Reconnect")]
        public bool AutoReconnect {
            get { return autoReconnect; }
            set {
                autoReconnect = value;
                SystemManager.InvokeChannelPropertiesChanged(this);
            }
        }
        bool systemEnabled = true;
        [Browsable(false)]
        public bool SystemEnabled {
            get { return systemEnabled; }
            set {
                systemEnabled = value;
                SystemManager.InvokeChannelPropertiesChanged(this);
            }
        }
        string name = "Untitled";
        string nameOld = "Untitled";
        [Category("General")]
        public string Name {
            get { return name; }
            set {
                name = value;
                if (name != nameOld) {
                    NameChanged?.Invoke(this, name);
                    SystemManager.InvokeChannelRename(this);
                    nameOld = value;
                }
            }
        }
        long SilenceLength = 29166;
        [Category("Port")]
        [DisplayName("Baud Rate")]
        public int BaudRate {
            get {
                if (Port != null) { return Port.BaudRate; }
                return 9600;
            }
            set {
                if (Port != null) {
                    if (value > 0) {
                        Port.BaudRate = value;
                        SilenceLength = (long)(280000000.0m / (decimal)Port.BaudRate);
                        SystemManager.InvokeChannelPropertiesChanged(this);
                    }
                }
            }
        }
        [Category("Port")]
        [DisplayName("Port")]
        public string PortName {
            get {
                if (Port != null) { return Port.PortName; }
                return "COM1";
            }
            set {
                if (Port != null) {
                    Port.PortName = value;
                    NameChanged?.Invoke(this, name);
                    SystemManager.InvokeChannelRename(this);
                }
            }
        }
        private Modbus.ModbusCoil[] coils = new Modbus.ModbusCoil[Modbus.ModbusSupport.MaximumRegisters];//new List<ModbusCoil>(Modbus.ModbusSupport.MaximumRegisters);//new ModbusCoil[Modbus.ModbusSupport.MaximumRegisters];
        [Browsable(false)]
        public Modbus.ModbusCoil[] Coils {
            get { return coils; }
        }
        private Modbus.ModbusCoil[] discreteInputs = new Modbus.ModbusCoil[Modbus.ModbusSupport.MaximumRegisters];//new List<ModbusCoil>(Modbus.ModbusSupport.MaximumRegisters); //new bool[Modbus.ModbusSupport.MaximumRegisters];
        [Browsable(false)]
        public Modbus.ModbusCoil[] DiscreteInputs {
            get { return discreteInputs; }
        }//ModbusRegister
        private Modbus.ModbusRegister[] inputRegisters = new Modbus.ModbusRegister[Modbus.ModbusSupport.MaximumRegisters]; //new short[Modbus.ModbusSupport.MaximumRegisters];
        [Browsable(false)]
        public Modbus.ModbusRegister[] InputRegisters {
            get { return inputRegisters; }
        }
        private Modbus.ModbusRegister[] holdingRegisters = new Modbus.ModbusRegister[Modbus.ModbusSupport.MaximumRegisters]; //new short[Modbus.ModbusSupport.MaximumRegisters];
        [Browsable(false)]
        public Modbus.ModbusRegister[] HoldingRegisters {
            get { return holdingRegisters; }
        }
        StreamInputFormat inputFormat = StreamInputFormat.Text;
        [Category("Data Formatting")]
        [DisplayName("Input Format")]
        public StreamInputFormat InputFormat {
            get { return inputFormat; }
            set {
                inputFormat = value;
                SystemManager.InvokeChannelPropertiesChanged(this);
            }
        }
        StreamOutputFormat outputFormat = StreamOutputFormat.Text;
        [Category("Data Formatting")]
        [DisplayName("Output Format")]
        public StreamOutputFormat OutputFormat {
            get { return outputFormat; }
            set {
                outputFormat = value;
                SystemManager.InvokeChannelPropertiesChanged(this);
            }
        }
        bool useCheckSums = true;
        [Category("Commands")]
        [DisplayName("Command Check Sum")]
        public bool UseCheckSums {
            get {
                return useCheckSums;
            }
            set {
                useCheckSums = value;
                SystemManager.InvokeChannelPropertiesChanged(this);
            }
        }
        LineFormatting lineFormat = LineFormatting.None;
        [Category("Data Formatting")]
        [DisplayName("Line Format")]
        public LineFormatting LineFormat {
            get { return lineFormat; }
            set {
                lineFormat = value;
                SystemManager.InvokeChannelPropertiesChanged(this);
            }
        }
        #endregion
        #region Reporting
        public void ResetCounters() {
            commandsSent = 0;
            commandsReceived = 0;
            bytesReceived = 0;
            bytesSent = 0;
        }
        ulong commandsSent = 0;
        [Browsable(false)]
        public ulong CommandsSent {
            get { return commandsSent; }
        }
        ulong commandsReceived = 0;
        [Browsable(false)]
        public ulong CommandsReceived {
            get { return commandsReceived; }
        }
        ulong bytesSent = 0;
        [Browsable(false)]
        public ulong BytesSent {
            get { return bytesSent; }
        }
        ulong bytesReceived = 0;
        [Browsable(false)]
        public ulong BytesReceived {
            get { return bytesReceived; }
        }
        DateTime lastCommandReceivedTime = DateTime.Now;
        [Browsable(false)]
        public DateTime LastCommandReceivedTime {
            get { return lastCommandReceivedTime; }
        }
        DateTime lastReceivedTime = DateTime.Now;
        [Browsable(false)]
        public DateTime LastReceivedTime {
            get { return lastReceivedTime; }
        }
        DateTime lastTransmittedTime = DateTime.UtcNow;
        [Browsable(false)]
        public DateTime LastTransmittedTime {
            get { return lastTransmittedTime; }
        }
        #endregion
        #region Transmission
        public bool Post(string Data) {
            if (outputFormat == StreamOutputFormat.Text) {
                string Appendage = "";
                //bool NewLine = false;
                switch (lineFormat) {
                    case LineFormatting.LF:
                        Appendage = "\n"; break;
                    case LineFormatting.CRLF:
                        Appendage = "\r\n"; break;
                    case LineFormatting.CR:
                        Appendage = "\r"; break;
                    default:
                        break;
                }
                return Post(Data + Appendage, false);
            }
            else {
                return Post(Data, false);

            }
        }
        public bool Post(string Data, bool WriteLine = false) {
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
                    Result += Classes.Formatters.ByteToBinary(Buffer[j]) + "  ";
                    Result += Classes.Formatters.ByteToHex(Buffer[j]) + "  ";
                    string Char = ((char)Buffer[j]).ToString();
                    Result += Classes.Formatters.ByteToChar(Buffer[j]);
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
                if (ModbusSupport.IsModbusFrameVaild(RXBuffer, RXCurrentByte) == true) {
                    DataReceived?.Invoke(this, true, PrintStream(Buffer));
                    if (isMaster == true) {
                        ModbusSupport.FunctionCode Func = (ModbusSupport.FunctionCode)Buffer[1];
                        switch (Func) {
                            case ModbusSupport.FunctionCode.ReadCoils:
                                ModbusMasterReadCoils(Buffer, RXCurrentByte, false); break;
                            case ModbusSupport.FunctionCode.WriteSingleCoil:
                                ModbusMasterWriteCoilReturn(Buffer, RXCurrentByte); break;
                            case ModbusSupport.FunctionCode.WriteSingleHoldingRegister:
                                ModbusMasterWriteRegisterReturn(Buffer, RXCurrentByte); break;
                            case ModbusSupport.FunctionCode.ReadDiscreteInputs:
                                ModbusMasterReadCoils(Buffer, RXCurrentByte); break;
                            case ModbusSupport.FunctionCode.ReadHoldingRegisters:
                                ModbusMasterReadRegisters(Buffer, RXCurrentByte); break;
                            case ModbusSupport.FunctionCode.ReadInputRegisters:
                                ModbusMasterReadRegisters(Buffer, RXCurrentByte, false); break;
                            default:
                                //ModbusPostException(Buffer[0], (Modbus.FunctionCode)Buffer[1], ModbusException.IllegalFunction);
                                break;
                        }
                    }
                    else {
                        if (Buffer[0] == unitAddress) {
                            ModbusSupport.FunctionCode Func = (ModbusSupport.FunctionCode)Buffer[1];
                            switch (Func) {
                                case ModbusSupport.FunctionCode.ReadCoils:
                                    ModbusSlaveReadCoils(Buffer, RXCurrentByte, false); break;
                                case ModbusSupport.FunctionCode.WriteSingleCoil:
                                    ModbusSlaveWriteCoil(Buffer, RXCurrentByte); break;
                                case ModbusSupport.FunctionCode.ReadDiscreteInputs:
                                    ModbusSlaveReadCoils(Buffer, RXCurrentByte); break;
                                case ModbusSupport.FunctionCode.ReadHoldingRegisters:
                                    ModbusSlaveReadRegisters(Buffer, RXCurrentByte); break;
                                case ModbusSupport.FunctionCode.ReadInputRegisters:
                                    ModbusSlaveReadRegisters(Buffer, RXCurrentByte, false); break;
                                case ModbusSupport.FunctionCode.WriteSingleHoldingRegister:
                                    ModbusSlaveWriteRegister(Buffer, RXCurrentByte); break;
                                case ModbusSupport.FunctionCode.WriteMultipleHoldingRegisters:
                                    ModbusSlaveWriteRegisters(Buffer, RXCurrentByte); break;
                                default:
                                    ModbusPostException(Buffer[0], (ModbusSupport.FunctionCode)Buffer[1], ModbusException.IllegalFunction);
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
        // private Modbus.FunctionCode LastSentCode = Modbus.FunctionCode.NoCommand;
        private short LastRequestedAddress = 0;
        private void ModbusPostException(int Address, ModbusSupport.FunctionCode Function, ModbusException Code) {
            //Adr Fun Cde
            byte[] Output = new byte[5];
            byte[] Temp = new byte[3];
            Temp[0] = (byte)Address;//Adr
            Temp[1] = (byte)((byte)Function + (byte)0x80);//Fun
            Temp[2] = (byte)Code;//Len

            Array.Copy(Temp, 0, Output, 0, 3);
            ushort CRC = ModbusSupport.CalculateCRC(Temp, (ushort)(3), 0);

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
                        ModbusPostException(Input[0], (ModbusSupport.FunctionCode)Input[1], ModbusException.IllegalDataValue);
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
        private void ModbusMasterWriteCoilReturn(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port != null) {
                if (Port.IsOpen) {
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    int Val = (int)((Input[4] << 8) | Input[5]);
                    coils[StartAddress].Value = Val == 0xFF00 ? true : false;
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
                        ModbusPostException(Input[0], (ModbusSupport.FunctionCode)Input[1], ModbusException.IllegalDataValue);
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
        private void ModbusMasterWriteRegisterReturn(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port != null) {
                if (Port.IsOpen) {
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    int Val = (int)((Input[4] << 8) | Input[5]);
                    holdingRegisters[StartAddress].Value = (short)Val;
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
                        ModbusPostException(Input[0], (ModbusSupport.FunctionCode)Input[1], ModbusException.IllegalDataValue);
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
                Temp += Classes.Formatters.ByteToHex(Data[i]) + " ";
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
            Temp[1] = (byte)ModbusSupport.FunctionCode.ReadCoils;//Fun
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
            Temp[1] = (byte)ModbusSupport.FunctionCode.ReadDiscreteInputs;//Fun
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
            Temp[1] = (byte)ModbusSupport.FunctionCode.ReadInputRegisters;//Fun
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
            Temp[1] = (byte)ModbusSupport.FunctionCode.ReadDiscreteInputs;//Fun
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
            Temp[1] = (byte)ModbusSupport.FunctionCode.WriteSingleCoil;//Fun
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
            Temp[1] = (byte)ModbusSupport.FunctionCode.WriteSingleHoldingRegister;//Fun
            Temp[2] = (byte)(Address >> 8);//Str1
            Temp[3] = (byte)(Address & 0xFF);//Str1
            Temp[4] = (byte)(Value >> 8);//Cnt1
            Temp[5] = (byte)(Value & 0xFF);//Cnt2

            TransmitFrame(Temp);
        }
        private void TransmitFrame(byte[] Data) {
            if ((DateTime.UtcNow.Ticks - LastTransmittedTime.Ticks) > SilenceLength) {

                byte[] Output = new byte[Data.Length + 2];
                ushort CRC = ModbusSupport.CalculateCRC(Data, (ushort)Data.Length, 0);
                Array.Copy(Data, 0, Output, 0, Data.Length);
                Output[Output.Length - 2] = (byte)(CRC & 0xFF);
                Output[Output.Length - 1] = (byte)(CRC >> 8);
                Port.Write(Output, 0, Output.Length);
                bytesSent += (ulong)Output.Length;
                DataReceived?.Invoke(this, true, PrintStream(Output));
            }
        }
        public void ModbusCommand(string Input) {
            if (isMaster == false) { return; }
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
                if (GetValue(ref Temp, "COIL", out Start, true)) {
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
                else if (GetValue(ref Temp, "REGISTER", out Start, true)) {
                    int Value = 0;
                    if (GetValue(ref Temp, "=", out Value)) {
                        ModbusWriteRegister(Unit, (short)Start, (short)Value);
                    }
                    else { ModbusWriteRegister(Unit, (short)Start, (short)0); }
                }
            }
        }
        private bool GetValue(ref string Input, string Compare, out int Value, bool DelimitOnEquals = false) {
            if (TestKeyword(ref Input, Compare)) {
                
                if (DelimitOnEquals) {
                    string StrAddress = ReadAndRemove(ref Input,'=').TrimStart(' ');
                    bool Success = int.TryParse(StrAddress, out Value);
                    if (Success == false) { return false; }
                }
                else {
                    string StrAddress = ReadAndRemove(ref Input).TrimStart(' ');
                    bool Success = int.TryParse(StrAddress, out Value);
                    if (Success == false) { return false; }
                }
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
        private string ReadAndRemove(ref string Input, char RemoveChar = ' ') {
            string Temp = Input.Split(RemoveChar)[0];
            Input = Input.Remove(0, Temp.Length);
            Input = Input.TrimStart(' ');
            return Temp;
        }
        #endregion
        #region Data Formatting


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
        const uint MAX_COMMAND_LENGTH = 500;
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
    public enum DataSelection {
        ModbusDataCoils = 0x00,
        ModbusDataDiscreteInputs = 0x01,
        ModbusDataInputRegisters = 0x02,
        ModbusDataHoldingRegisters = 0x03
    }
}
