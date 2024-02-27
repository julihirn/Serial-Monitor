using Handlers;
using ODModules;
using Serial_Monitor.Classes.Modbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.Enums.FormatEnums;

namespace Serial_Monitor.Classes {
    public class SerialManager {
        //Thread TrFramer;
        //bool FramerRunning = true;
        Thread? HeartbeatThread = null; // new Thread();
        Thread? ModbusRTUFramerThread = null;
        public SerialManager() {
            iD = Guid.NewGuid().ToString();
            Port.DataReceived += Port_DataReceived;
            Port.WriteTimeout = 1000;
            Port.ReadTimeout = 10000;
            Port.ReadBufferSize = 10000;
            HeartbeatThread = new Thread(HeartBeat);
            HeartbeatThread.IsBackground = true;
            HeartbeatThread.Start();

            ModbusRTUFramerThread = new Thread(ModbusFramer);
            ModbusRTUFramerThread.IsBackground = true;

            registers = new ModbusSlave(this, -1);
            //TrFramer = new Thread(Framer);
            //TrFramer.IsBackground = true;
            //TrFramer.Start();
            //for (int i = 0; i < Modbus.ModbusSupport.MaximumRegisters; i++) {
            //    coils[i] = new ModbusCoil(i, DataSelection.ModbusDataCoils, this);
            //    discreteInputs[i] = new ModbusCoil(i, DataSelection.ModbusDataDiscreteInputs, this);
            //    inputRegisters[i] = new ModbusRegister(i, DataSelection.ModbusDataInputRegisters, this);
            //    holdingRegisters[i] = new ModbusRegister(i, DataSelection.ModbusDataHoldingRegisters, this);
            //}

        }
        ~SerialManager() {
            CleanUp();

        }
        public void ClearSlaves() {
            foreach (ModbusSlave Slave in slave) {
                Slave.CleanUp();
            }
            slave.Clear();
        }
        public void CleanUp() {
            RunHeartBeat = false;
            //Array.Clear(coils, 0, coils.Length);
            //Array.Clear(discreteInputs, 0, discreteInputs.Length);
            //Array.Clear(inputRegisters, 0, inputRegisters.Length);
            //Array.Clear(holdingRegisters, 0, holdingRegisters.Length);
            //coils = new ModbusCoil[0];
            //discreteInputs = new ModbusCoil[0];
            //inputRegisters = new ModbusRegister[0];
            //holdingRegisters = new ModbusRegister[0];
            if (registers != null) {
                registers.CleanUp();
            }
            ClearSlaves();
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
        public void Connect() {
            try {
                this.Port.Open();
            }
            catch {
                SystemManager.InvokeErrorMessage(ErrorType.M_Error, "COM_PSTART", "Could not open the port");
            }
            SystemManager.InvokePortStatusChanged(this);
        }
        public void Disconnect() {
            try {
                Port.Close();
            }
            catch {
                SystemManager.InvokeErrorMessage(ErrorType.M_Error, "COM_PEND", "Could not close the port");
            }
            SystemManager.InvokePortStatusChanged(this);
        }
        public event NameChangedHandler? NameChanged;
        public delegate void NameChangedHandler(object sender, string Data);

        public event CommandProcessedHandler? CommandProcessed;
        public delegate void CommandProcessedHandler(object sender, string Data);
        public delegate void DataProcessedHandler(object sender, bool PrintLine, string Data);
        public event DataProcessedHandler? DataReceived;
        private SerialPort Port = new SerialPort();
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
        int outputRTUSilenceCalibration = 0;
        [Category("Modbus RTU")]
        [DisplayName("Output Silence Calibration")]
        public int OutputRTUSilenceCalibration {
            get { return outputRTUSilenceCalibration; }
            set {
                outputRTUSilenceCalibration = value;
                SystemManager.InvokeChannelPropertiesChanged(this);
            }
        }
        int inputRTUSilenceCalibration = 100;
        [Category("Modbus RTU")]
        [DisplayName("Input Silence Calibration")]
        public int InputRTUSilenceCalibration {
            get { return inputRTUSilenceCalibration; }
            set {
                inputRTUSilenceCalibration = value;
                SystemManager.InvokeChannelPropertiesChanged(this);
            }
        }
        bool autoReconnect = false;
        [Category("Connection")]
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
                    try {
                        Port.PortName = value;
                        NameChanged?.Invoke(this, name);
                        SystemManager.InvokeChannelRename(this);
                    }
                    catch { }
                }
            }
        }
        [Category("Port")]
        [DisplayName("Data Bits")]
        public int DataBits {
            get {
                if (Port != null) { return Port.DataBits; }
                return 8;
            }
            set {
                if (Port != null) {
                    try {
                        Port.DataBits = value;
                        SystemManager.InvokeChannelPropertiesChanged(this);
                    }
                    catch { }
                }
            }
        }
        [Category("Port")]
        [DisplayName("Stop Bits")]
        public StopBits StopBits {
            get {
                if (Port != null) { return Port.StopBits; }
                return System.IO.Ports.StopBits.One;
            }
            set {
                if (Port != null) {
                    try {
                        Port.StopBits = value;
                        SystemManager.InvokeChannelPropertiesChanged(this);
                    }
                    catch { }
                }
            }
        }
        [Category("Port")]
        [DisplayName("Parity")]
        public Parity Parity {
            get {
                if (Port != null) { return Port.Parity; }
                return System.IO.Ports.Parity.None;
            }
            set {
                if (Port != null) {
                    try {
                        Port.Parity = value;
                        SystemManager.InvokeChannelPropertiesChanged(this);
                    }
                    catch { }
                }
            }
        }
        [Category("Port")]
        [DisplayName("Handshake")]
        public Handshake Handshake {
            get {
                if (Port != null) { return Port.Handshake; }
                return System.IO.Ports.Handshake.None;
            }
            set {
                if (Port != null) {
                    try {
                        Port.Handshake = value;
                        SystemManager.InvokeChannelPropertiesChanged(this);
                    }
                    catch { }
                }
            }
        }
        private Modbus.ModbusSlave? registers = null;
        [Browsable(false)]
        public Modbus.ModbusSlave? Registers {
            get { return registers; }
        }
        private List<Modbus.ModbusSlave> slave = new List<ModbusSlave>();
        [Browsable(false)]
        public List<ModbusSlave> Slave {
            get { return slave; }
        }
        //private Modbus.ModbusCoil[] coils = new Modbus.ModbusCoil[Modbus.ModbusSupport.MaximumRegisters];//new List<ModbusCoil>(Modbus.ModbusSupport.MaximumRegisters);//new ModbusCoil[Modbus.ModbusSupport.MaximumRegisters];
        //[Browsable(false)]
        //public Modbus.ModbusCoil[] Coils {
        //    get { return coils; }
        //}
        //private Modbus.ModbusCoil[] discreteInputs = new Modbus.ModbusCoil[Modbus.ModbusSupport.MaximumRegisters];//new List<ModbusCoil>(Modbus.ModbusSupport.MaximumRegisters); //new bool[Modbus.ModbusSupport.MaximumRegisters];
        //[Browsable(false)]
        //public Modbus.ModbusCoil[] DiscreteInputs {
        //    get { return discreteInputs; }
        //}//ModbusRegister
        //private Modbus.ModbusRegister[] inputRegisters = new Modbus.ModbusRegister[Modbus.ModbusSupport.MaximumRegisters]; //new short[Modbus.ModbusSupport.MaximumRegisters];
        //[Browsable(false)]
        //public Modbus.ModbusRegister[] InputRegisters {
        //    get { return inputRegisters; }
        //}
        //private Modbus.ModbusRegister[] holdingRegisters = new Modbus.ModbusRegister[Modbus.ModbusSupport.MaximumRegisters]; //new short[Modbus.ModbusSupport.MaximumRegisters];
        //[Browsable(false)]
        //public Modbus.ModbusRegister[] HoldingRegisters {
        //    get { return holdingRegisters; }
        //}
        StreamInputFormat inputFormat = StreamInputFormat.Text;
        [Category("Data Formatting")]
        [DisplayName("Input Format")]
        public StreamInputFormat InputFormat {
            get { return inputFormat; }
            set {
                if (value != inputFormat) {
                    RXCurrentByte = 0;
                    ASCIIState = ModbusASCIIState.Ready;
                    State = MessageState.Ready;
                    CurrentByte = 0;
                }
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
        [Browsable(false)]
        public bool Connected {
            get {
                return Port.IsOpen;
            }
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
                    case StreamOutputFormat.ModbusASCII:
                        ModbusCommand(Data);
                        break;
                    case StreamOutputFormat.StreamBinary:
                        StreamTransmit(Data, Enums.ModbusEnums.DataFormat.Binary);
                        break;
                    case StreamOutputFormat.StreamOctal:
                        StreamTransmit(Data, Enums.ModbusEnums.DataFormat.Octal);
                        break;
                    case StreamOutputFormat.StreamDecimal:
                        StreamTransmit(Data, Enums.ModbusEnums.DataFormat.Decimal);
                        break;
                    case StreamOutputFormat.StreamHexadecimal:
                        StreamTransmit(Data, Enums.ModbusEnums.DataFormat.Hexadecimal);
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
                case StreamInputFormat.ModbusASCII:
                    ModbusASCIIProcessor(sender);
                    break;
                case StreamInputFormat.StreamBinary:
                    StreamProcessor(sender, Enums.ModbusEnums.DataFormat.Binary);
                    break;
                case StreamInputFormat.StreamOctal:
                    StreamProcessor(sender, Enums.ModbusEnums.DataFormat.Octal);
                    break;
                case StreamInputFormat.StreamDecimal:
                    StreamProcessor(sender, Enums.ModbusEnums.DataFormat.Decimal);
                    break;
                case StreamInputFormat.StreamHexadecimal:
                    StreamProcessor(sender, Enums.ModbusEnums.DataFormat.Hexadecimal);
                    break;
                default:
                    break;
            }
            lastReceivedTime = DateTime.UtcNow;
        }
        #endregion
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
                    ProgramManager.ProgramDataReceived(this.ID, Result);
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
                    ProgramManager.ProgramDataReceived(this.ID, Result);
                }
            }
            catch { }
        }
        private void StreamProcessor(object sender, Enums.ModbusEnums.DataFormat Format) {
            try {
                byte[] Buffer = new byte[1000];
                int i = 0;
                int BytesToRead = ((SerialPort)sender).BytesToRead;
                bytesReceived += (ulong)BytesToRead;
                i = ((SerialPort)sender).Read(Buffer, 0, BytesToRead);
                string Result = "";
                for (int j = 0; j < BytesToRead; j++) {
                    switch (Format) {
                        case Enums.ModbusEnums.DataFormat.Binary:
                            Result += Classes.Formatters.ByteToBinary(Buffer[j]); break;
                        case Enums.ModbusEnums.DataFormat.Octal:
                            Result += Convert.ToString(Buffer[j], 8); break;
                        case Enums.ModbusEnums.DataFormat.Decimal:
                            Result += Buffer[j].ToString(); break;
                        case Enums.ModbusEnums.DataFormat.Hexadecimal:
                            Result += Classes.Formatters.ByteToHex(Buffer[j]); break;
                        default: break;
                    }
                    Result += " ";
                }
                DataReceived?.Invoke(this, true, Result);
                ProgramManager.ProgramDataReceived(this.ID, Result);
            }
            catch { }
        }

        byte[] RXBuffer = new byte[short.MaxValue];
        private int RXCurrentByte = 0;
        private void ModbusRTUProcessor(object sender) {
            try {
                if ((DateTime.UtcNow.Ticks - lastReceivedTime.Ticks) >= SilenceLength + inputRTUSilenceCalibration) {
                    RXCurrentByte = 0;
                }
                int i = 0;
                int BytesToRead = ((SerialPort)sender).BytesToRead;
                byte[] Buffer = new byte[BytesToRead];
                bytesReceived += (ulong)BytesToRead;
                i = ((SerialPort)sender).Read(Buffer, 0, BytesToRead);
                Array.Copy(Buffer, 0, RXBuffer, RXCurrentByte, BytesToRead);
                RXCurrentByte += BytesToRead;
                int LatchedBytesToCheck = RXCurrentByte;
                bool NothingFound = true;
                if (LatchedBytesToCheck >= 0) {
                    for (int j = 4; j <= LatchedBytesToCheck; j++) {
                        lastReceivedTime = DateTime.UtcNow;
                        if (ModbusSupport.IsModbusFrameVaild(RXBuffer, j) == false) { continue; }
                        lastReceivedTime = DateTime.UtcNow;
                        int NewIndex = j+1;
                        int NewLength = (LatchedBytesToCheck - j);
                        if (NewLength >= 0) {
                            byte[] Temp = RXBuffer;
                            byte[] TemoSends = new byte[j];
                            Array.Copy(RXBuffer, 0, TemoSends, 0, j);
                            if (NewLength > 0) {
                                Array.Copy(Temp, NewIndex, RXBuffer, 0, NewLength);
                            }
                            RXCurrentByte = NewLength;
                            Thread TrMbRTURx = new Thread(() => RTUStringProcessor(TemoSends));
                            TrMbRTURx.Name = "TrMbRTURx";
                            TrMbRTURx.IsBackground = true;
                            TrMbRTURx.Start();

                        }
                        else {
                            RXCurrentByte = 0;
                        }
                        NothingFound = false;
                        break;
                    }
                }
                if (NothingFound == true) {
                }
                if (RXCurrentByte > 512) {
                    RXCurrentByte = 0;
                }
                lastReceivedTime = DateTime.UtcNow;
                //if (ModbusSupport.IsModbusFrameVaild(RXBuffer, RXCurrentByte) == true) {
                //    //string StringBuffer = PrintStream(Buffer);
                //    //DataReceived?.Invoke(this, true, StringBuffer);
                //    //ProgramManager.ProgramDataReceived(this.ID, StringBuffer);
                //    //ModbusSupport.FunctionCode Func = (ModbusSupport.FunctionCode)Buffer[1];
                //    //ModbusProcessCommand(ref Buffer, Func, Buffer[0]);
                //    RXCurrentByte = 0;
                //    Thread TrMbRTURx = new Thread(() => RTUStringProcessor(Buffer));
                //    TrMbRTURx.Name = "TrMbRTURx";
                //    TrMbRTURx.IsBackground = true;
                //    TrMbRTURx.Start();
                //}
                //else {
                //    string StringBuffer = PrintStream(Buffer);
                //    Debug.Print("Invalid: " + StringBuffer);
                //}
            }
            catch { }
            lastReceivedTime = DateTime.UtcNow;
        }
        private void TestPrint(byte[] InBuffer) {
            string StringBuffer = PrintStream(InBuffer);
            DataReceived?.Invoke(this, true, StringBuffer);
        }
        private void RTUStringProcessor(byte[] InBuffer) {
            string StringBuffer = PrintStream(InBuffer);
            DataReceived?.Invoke(this, true, StringBuffer);
            ProgramManager.ProgramDataReceived(this.ID, StringBuffer);
            ModbusSupport.FunctionCode Func = (ModbusSupport.FunctionCode)InBuffer[1];
            ModbusProcessCommand(ref InBuffer, Func, InBuffer[0]);
        }
        ModbusASCIIState ASCIIState = ModbusASCIIState.Ready;
        private void ModbusASCIIProcessor(object sender) {
            try {
                int j = 0;
                int BytesToRead = ((SerialPort)sender).BytesToRead;
                byte[] Buffer = new byte[BytesToRead];
                bytesReceived += (ulong)BytesToRead;
                j = ((SerialPort)sender).Read(Buffer, 0, BytesToRead);
                for (int i = 0; i < BytesToRead; i++) {
                    switch (ASCIIState) {
                        case ModbusASCIIState.Ready:
                            RXCurrentByte = 0;
                            if (Buffer[i] == ':') {
                                ASCIIState = ModbusASCIIState.Armmed;
                            }
                            break;
                        case ModbusASCIIState.Armmed:
                            if (Buffer[i] == '\r') {
                                ASCIIState = ModbusASCIIState.Closing;
                            }
                            else if (Buffer[i] == '\n') {
                                //Invalid!
                                ASCIIState = ModbusASCIIState.Ready;
                                RXCurrentByte = 0;
                            }
                            else {
                                RXBuffer[RXCurrentByte] = Buffer[i];
                                RXCurrentByte++;
                            }
                            break;
                        case ModbusASCIIState.Closing:
                            if (Buffer[i] == '\n') {
                                ModbusASCIICommandProcessor();
                                //ClearRXBuffer();
                            }
                            RXCurrentByte = 0;
                            ASCIIState = ModbusASCIIState.Ready;
                            break;
                    }
                }
            }
            catch { }
        }
        private void ClearRXBuffer() {
            for (int i = 0; i < RXCurrentByte; i++) {
                RXBuffer[i] = 0x00;
            }
        }
        private void ModbusASCIICommandProcessor() {
            if (RXCurrentByte < 4) { return; }
            int DataPacketSize = RXCurrentByte - 2;
            byte[] Buffer = new byte[DataPacketSize];

            Array.Copy(RXBuffer, 0, Buffer, 0, DataPacketSize);
            byte LRC_Calculated = ModbusSupport.CalculateLRC(Buffer, (ushort)DataPacketSize, 0);
            byte LRC_Recieved = ModbusSupport.GetArrayValue(DataPacketSize, ref RXBuffer);
            if (LRC_Calculated != LRC_Recieved) { return; }
            string StringBuffer = PrintStream(Buffer);
            DataReceived?.Invoke(this, true, StringBuffer);
            ProgramManager.ProgramDataReceived(this.ID, StringBuffer);
            int Slave = ModbusSupport.GetArrayValue(0, ref Buffer);
            int Func = ModbusSupport.GetArrayValue(2, ref Buffer);
            ModbusSupport.FunctionCode Function = (ModbusSupport.FunctionCode)Func;
            ModbusProcessCommand(ref Buffer, Function, Slave);
        }
        private void ModbusProcessCommand(ref byte[] Buffer, ModbusSupport.FunctionCode Function, int Address) {
            if (isMaster == true) {
                switch (Function) {
                    case ModbusSupport.FunctionCode.ReadCoils:
                        ModbusMasterReadCoils(Buffer, RXCurrentByte, false); break;
                    case ModbusSupport.FunctionCode.WriteSingleCoil:
                        ModbusMasterWriteCoilReturn(Buffer, RXCurrentByte); break;
                    case ModbusSupport.FunctionCode.WriteSingleHoldingRegister:
                        ModbusMasterWriteRegisterReturn(Buffer, RXCurrentByte); break;
                    case ModbusSupport.FunctionCode.WriteMultipleHoldingRegisters:
                        ModbusMasterWriteMultipleRegisterReturn(Buffer, RXCurrentByte); break;
                    case ModbusSupport.FunctionCode.ReadDiscreteInputs:
                        ModbusMasterReadCoils(Buffer, RXCurrentByte); break;
                    case ModbusSupport.FunctionCode.ReadHoldingRegisters:
                        ModbusMasterReadRegisters(Buffer, RXCurrentByte); break;
                    case ModbusSupport.FunctionCode.ReadInputRegisters:
                        ModbusMasterReadRegisters(Buffer, RXCurrentByte, false); break;
                    case ModbusSupport.FunctionCode.Diagnostics:
                        ModbusMasterDiagnosticsReturn(Buffer, RXCurrentByte); break;
                    default:
                        //ModbusPostException(Buffer[0], (Modbus.FunctionCode)Buffer[1], ModbusException.IllegalFunction);
                        break;
                }
            }
            else {
                if (Address == unitAddress) {
                    switch (Function) {
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
                        case ModbusSupport.FunctionCode.WriteMultipleCoils:
                            ModbusSlaveWriteCoils(Buffer, RXCurrentByte); break;
                        default:
                            ModbusPostException(Address, Function, ModbusException.IllegalFunction);
                            break;
                    }
                }
            }
        }
        #endregion
        #region Modbus
        // private Modbus.FunctionCode LastSentCode = Modbus.FunctionCode.NoCommand;
        private ushort LastRequestedAddress = 0;
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
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            if (InputFormat == StreamInputFormat.ModbusRTU) {
                int Slave = Input[0];
                int Func = Input[1];
                int StartAddress = (int)((Input[2] << 8) | Input[3]);
                short CoilCount = (short)((Input[4] << 8) | Input[5]);
                if ((CoilCount < 0x01) || (CoilCount > 0x07D0)) {
                    ModbusPostException(Slave, (ModbusSupport.FunctionCode)Func, ModbusException.IllegalDataValue);
                    return;
                }
                ////int Bytes = (CoilCount + 7) / 8;
                //int ArrayLength = 3 + Bytes;
                byte[] Temp = ModbusSupport.BulidReadCoils(this, true, IsDiscrete, (ModbusSupport.FunctionCode)Func, Slave, (short)StartAddress, CoilCount);
                TransmitFrame(Temp);
            }
            else if (InputFormat == StreamInputFormat.ModbusASCII) {
                int Slave = ModbusSupport.GetArrayValue(0, ref Input);
                int Func = ModbusSupport.GetArrayValue(2, ref Input);
                int StartAddress = ModbusSupport.GetArrayValueRead4(4, ref Input);
                short CoilCount = (short)ModbusSupport.GetArrayValueRead4(8, ref Input);
                if ((CoilCount < 0x01) || (CoilCount > 0x07D0)) {
                    ModbusPostException(Slave, (ModbusSupport.FunctionCode)Func, ModbusException.IllegalDataValue);
                    return;
                }
                byte[] Temp = ModbusSupport.BulidReadCoils(this, true, IsDiscrete, (ModbusSupport.FunctionCode)Func, Slave, (short)StartAddress, CoilCount);
                TransmitFrame(Temp);
            }
        }
        private void ModbusMasterDiagnosticsReturn(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int Device = Input[0];
                int TempFunction = (int)((Input[2] << 8) | Input[3]);
                int Val = (int)((Input[4] << 8) | Input[5]);
                try {
                    ModbusSupport.DiagnosticSubFunction SubFunction = (ModbusSupport.DiagnosticSubFunction)TempFunction;
                    SystemManager.ModbusDiagnosticsReturn(this, Device, SubFunction, Val);
                }
                catch { }
            }
            else if (inputFormat == StreamInputFormat.ModbusASCII) {
                int Device = ModbusSupport.GetArrayValue(0, ref Input);
                int TempFunction = ModbusSupport.GetArrayValueRead4(4, ref Input);
                int Val = ModbusSupport.GetArrayValueRead4(8, ref Input);
                try {
                    ModbusSupport.DiagnosticSubFunction SubFunction = (ModbusSupport.DiagnosticSubFunction)TempFunction;
                    SystemManager.ModbusDiagnosticsReturn(this, Device, SubFunction, Val);
                }
                catch { }
            }
        }
        private void ModbusMasterWriteCoilReturn(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int Device = Input[0];
                int StartAddress = (int)((Input[2] << 8) | Input[3]);
                int Val = (int)((Input[4] << 8) | Input[5]);
                //coils[StartAddress].Value = Val == 0xFF00 ? true : false;
                ModbusSupport.SetRegister(this, DataSelection.ModbusDataCoils, Device, StartAddress, Val == 0xFF00 ? true : false);
            }
            else if (inputFormat == StreamInputFormat.ModbusASCII) {
                int Device = ModbusSupport.GetArrayValue(0, ref Input);
                int StartAddress = ModbusSupport.GetArrayValueRead4(4, ref Input);
                int Val = ModbusSupport.GetArrayValueRead4(8, ref Input);
                //coils[StartAddress].Value = Val == 0xFF00 ? true : false;
                ModbusSupport.SetRegister(this, DataSelection.ModbusDataCoils, Device, StartAddress, Val == 0xFF00 ? true : false);
            }
        }
        private void ModbusSlaveWriteCoil(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int StartAddress = (int)((Input[2] << 8) | Input[3]);
                int Val = (int)((Input[4] << 8) | Input[5]);
                //coils[StartAddress].Value = Val == 0xFF00 ? true : false;
                ModbusSupport.SetRegister(this, DataSelection.ModbusDataCoils, StartAddress, Val == 0xFF00 ? true : false);
                byte[] Temp = ModbusSupport.BulidWriteSinglePacket(outputFormat, (ModbusSupport.FunctionCode)Input[1], Input[0], (short)StartAddress, Input[4], Input[5]);
                //byte[] Temp = new byte[6];
                //Temp[0] = Input[0];//Adr
                //Temp[1] = Input[1];//Fun
                //Temp[2] = Input[2];//Str1
                //Temp[3] = Input[3];//Str1
                //Temp[4] = Input[4];//Val1
                //Temp[5] = Input[5];//Val2
                TransmitFrame(Temp);
            }
            else if (inputFormat == StreamInputFormat.ModbusASCII) {
                int StartAddress = ModbusSupport.GetArrayValueRead4(4, ref Input);
                int Val = ModbusSupport.GetArrayValueRead4(8, ref Input);
                //coils[StartAddress].Value = Val == 0xFF00 ? true : false;
                ModbusSupport.SetRegister(this, DataSelection.ModbusDataCoils, StartAddress, Val == 0xFF00 ? true : false);
                int Func = ModbusSupport.GetArrayValue(2, ref Input);
                int Slave = ModbusSupport.GetArrayValue(0, ref Input);
                byte Val_High = (byte)(Val >> 8);
                byte Val_Low = (byte)(Val & 0XFF);
                byte[] Temp = ModbusSupport.BulidWriteSinglePacket(outputFormat, (ModbusSupport.FunctionCode)Func, Slave, (short)StartAddress, Val_High, Val_Low);
                TransmitFrame(Temp);
            }
        }
        private void ModbusSlaveWriteCoils(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int Slave = Input[0];
                int StartAddress = (int)((Input[2] << 8) | Input[3]);
                int Count = (int)((Input[4] << 8) | Input[5]);
                if (Count > 0x007B) {
                    ModbusPostException(Input[0], (ModbusSupport.FunctionCode)Input[1], ModbusException.IllegalDataValue);
                    return;
                }
                int Bytes = Input[6];
                int CoilCount = 0;
                for (int i = 0; i < Bytes; i++) {
                    int Val = Input[7 + i];
                    for (int j = 0; j < 8; j++) {
                        bool TempBool = false;
                        if (((Val >> j) & 0x01) == 0x01) { TempBool = true; }
                        //coils[StartAddress + CoilCount].Value = TempBool;
                        ModbusSupport.SetRegister(this, DataSelection.ModbusDataCoils, StartAddress + CoilCount, TempBool);
                        CoilCount++;
                        if (CoilCount == Count) {
                            break;
                        }
                    }
                }
                byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, ModbusSupport.FunctionCode.WriteMultipleCoils, Slave, (short)StartAddress, (short)Count);
                TransmitFrame(Temp);
            }
            else if (inputFormat == StreamInputFormat.ModbusASCII) {
                int Slave = ModbusSupport.GetArrayValue(0, ref Input);
                int Func = ModbusSupport.GetArrayValue(2, ref Input);
                int StartAddress = ModbusSupport.GetArrayValueRead4(4, ref Input);
                int Count = ModbusSupport.GetArrayValueRead4(8, ref Input);
                if (Count > 0x007B) {
                    ModbusPostException(Slave, (ModbusSupport.FunctionCode)Func, ModbusException.IllegalDataValue);
                    return;
                }
                int Bytes = ModbusSupport.GetArrayValue(12, ref Input);
                int k = 0;
                int CoilCount = 0;
                for (int i = 0; i < Bytes; i++) {
                    int Val = ModbusSupport.GetArrayValue(14 + k, ref Input); k += 2;
                    for (int j = 0; j < 8; j++) {
                        bool TempBool = false;
                        if (((Val >> j) & 0x01) == 0x01) { TempBool = true; }
                        //coils[StartAddress + CoilCount].Value = TempBool;
                        ModbusSupport.SetRegister(this, DataSelection.ModbusDataCoils, StartAddress + CoilCount, TempBool);
                        CoilCount++;
                        if (CoilCount == Count) {
                            break;
                        }
                    }
                }
                byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, (ModbusSupport.FunctionCode)Func, Slave, (short)StartAddress, (short)Count);
                TransmitFrame(Temp);
            }
        }
        private void ModbusSlaveReadRegisters(byte[] Input, int Length, bool IsHolding = true) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int Slave = Input[0];
                int Func = Input[1];
                int StartAddress = (int)((Input[2] << 8) | Input[3]);
                short RegisterCount = (short)((Input[4] << 8) | Input[5]);
                if ((RegisterCount < 0x01) || (RegisterCount > 0x7D)) {
                    ModbusPostException(Slave, (ModbusSupport.FunctionCode)Func, ModbusException.IllegalDataValue);
                    return;
                }
                int ArrayLength = 3 + (RegisterCount * 2);
                byte[] Temp = ModbusSupport.BulidReadRegisters(this, true, IsHolding, (ModbusSupport.FunctionCode)Func, Slave, (short)StartAddress, RegisterCount);
                //DataReceived?.Invoke(this, true, PrintStream(Output));
                TransmitFrame(Temp);
            }
            else if (inputFormat == StreamInputFormat.ModbusASCII) {
                int Slave = ModbusSupport.GetArrayValue(0, ref Input);
                int Func = ModbusSupport.GetArrayValue(2, ref Input);
                int StartAddress = ModbusSupport.GetArrayValueRead4(4, ref Input);
                short RegisterCount = (short)ModbusSupport.GetArrayValueRead4(8, ref Input);
                if ((RegisterCount < 0x01) || (RegisterCount > 0x7D)) {
                    ModbusPostException(Slave, (ModbusSupport.FunctionCode)Func, ModbusException.IllegalDataValue);
                    return;
                }
                byte[] Temp = ModbusSupport.BulidReadRegisters(this, true, IsHolding, (ModbusSupport.FunctionCode)Func, Slave, (short)StartAddress, RegisterCount);
                //DataReceived?.Invoke(this, true, PrintStream(Output));
                TransmitFrame(Temp);

            }
        }
        private void ModbusSlaveWriteRegister(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int StartAddress = (int)((Input[2] << 8) | Input[3]);
                int Val = (int)((Input[4] << 8) | Input[5]);
                ModbusSupport.SetRegister(this, DataSelection.ModbusDataHoldingRegisters, StartAddress, (short)Val);
                //holdingRegisters[StartAddress].Value = (short)Val;
                byte[] Temp = ModbusSupport.BulidWriteSinglePacket(outputFormat, (ModbusSupport.FunctionCode)Input[1], Input[0], (short)StartAddress, Input[4], Input[5]);
                //byte[] Temp = new byte[6];
                //Temp[0] = Input[0];//Adr
                //Temp[1] = Input[1];//Fun
                //Temp[2] = Input[2];//Str1
                //Temp[3] = Input[3];//Str1
                //Temp[4] = Input[4];//Val1
                //Temp[5] = Input[5];//Val2
                TransmitFrame(Temp);
            }
            else if (inputFormat == StreamInputFormat.ModbusASCII) {
                int Slave = ModbusSupport.GetArrayValue(0, ref Input);
                int Func = ModbusSupport.GetArrayValue(2, ref Input);
                int StartAddress = ModbusSupport.GetArrayValueRead4(4, ref Input);
                int Val = ModbusSupport.GetArrayValueRead4(8, ref Input);
                //holdingRegisters[StartAddress].Value = (short)Val;
                ModbusSupport.SetRegister(this, DataSelection.ModbusDataHoldingRegisters, StartAddress, (short)Val);
                byte Val_High = (byte)(Val >> 8);
                byte Val_Low = (byte)(Val & 0XFF);
                byte[] Temp = ModbusSupport.BulidWriteSinglePacket(outputFormat, (ModbusSupport.FunctionCode)Func, Slave, (short)StartAddress, Val_High, Val_Low);
                TransmitFrame(Temp);
            }
        }
        private void ModbusMasterWriteRegisterReturn(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int Device = Input[0];
                int StartAddress = (int)((Input[2] << 8) | Input[3]);
                int Val = (int)((Input[4] << 8) | Input[5]);
                //holdingRegisters[StartAddress].Value = (short)Val;
                ModbusSupport.SetRegister(this, DataSelection.ModbusDataHoldingRegisters, Device, StartAddress, (short)Val);
            }
            else if (inputFormat == StreamInputFormat.ModbusASCII) {
                int Device = ModbusSupport.GetArrayValue(0, ref Input);
                int StartAddress = ModbusSupport.GetArrayValueRead4(4, ref Input);
                int Val = ModbusSupport.GetArrayValueRead4(8, ref Input);
                //holdingRegisters[StartAddress].Value = (short)Val;
                ModbusSupport.SetRegister(this, DataSelection.ModbusDataHoldingRegisters, Device, StartAddress, (short)Val);
            }
        }
        private void ModbusMasterWriteMultipleRegisterReturn(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int Device = Input[0];
                int StartAddress = (int)((Input[2] << 8) | Input[3]);
                int Val = (int)((Input[4] << 8) | Input[5]);
                //holdingRegisters[StartAddress].Value = (short)Val;
                ModbusSupport.SetRegister(this, DataSelection.ModbusDataHoldingRegisters, Device, StartAddress, (short)Val);
            }
            else if (inputFormat == StreamInputFormat.ModbusASCII) {
                int Device = ModbusSupport.GetArrayValue(0, ref Input);
                int StartAddress = ModbusSupport.GetArrayValueRead4(4, ref Input);
                int Val = ModbusSupport.GetArrayValueRead4(8, ref Input);
                //holdingRegisters[StartAddress].Value = (short)Val;
                ModbusSupport.SetRegister(this, DataSelection.ModbusDataHoldingRegisters, Device, StartAddress, (short)Val);
            }
        }
        private void ModbusSlaveWriteRegisters(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int Slave = Input[0];
                int StartAddress = (int)((Input[2] << 8) | Input[3]);
                int Count = (int)((Input[4] << 8) | Input[5]);
                if (Count > 0x007B) {
                    ModbusPostException(Input[0], (ModbusSupport.FunctionCode)Input[1], ModbusException.IllegalDataValue);
                    return;
                }
                int Bytes = Input[6];
                int j = 0;
                for (int i = 0; i < Count; i++) {
                    int Val = (int)((Input[7 + j] << 8) | Input[8 + j]);
                    j += 2;

                    //holdingRegisters[StartAddress + i].Value = (short)Val;
                    ModbusSupport.SetRegister(this, DataSelection.ModbusDataHoldingRegisters, StartAddress + i, (short)Val);
                }

                byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, ModbusSupport.FunctionCode.WriteMultipleHoldingRegisters, Slave, (short)StartAddress, (short)Count);
                TransmitFrame(Temp);
            }
            else if (inputFormat == StreamInputFormat.ModbusASCII) {
                int Slave = ModbusSupport.GetArrayValue(0, ref Input);
                int Func = ModbusSupport.GetArrayValue(2, ref Input);
                int StartAddress = ModbusSupport.GetArrayValueRead4(4, ref Input);
                int Count = ModbusSupport.GetArrayValueRead4(8, ref Input);
                if (Count > 0x007B) {
                    ModbusPostException(Slave, (ModbusSupport.FunctionCode)Func, ModbusException.IllegalDataValue);
                    return;
                }
                int Bytes = ModbusSupport.GetArrayValue(12, ref Input);
                int j = 0;
                for (int i = 0; i < Count; i++) {
                    int Val = ModbusSupport.GetArrayValueRead4(14 + j, ref Input);
                    j += 4;
                    //holdingRegisters[StartAddress + i].Value = (short)Val;
                    ModbusSupport.SetRegister(this, DataSelection.ModbusDataHoldingRegisters, StartAddress + i, (short)Val);
                }
                byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, (ModbusSupport.FunctionCode)Func, Slave, (short)StartAddress, (short)Count);
                TransmitFrame(Temp);
            }
        }
        private void ModbusMasterReadCoils(byte[] Input, int Length, bool IsDiscrete = true) {
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int Device = Input[0];
                int Bytes = Input[2];
                int k = 0;
                for (int i = 0; i < Bytes; i++) {
                    for (int j = 0; j < 8; j++) {
                        int Temp = Input[3 + i];
                        bool TempBool = ((Temp >> j) & 0x01) == 0x01 ? true : false;
                        if (IsDiscrete == true) {
                            ModbusSupport.SetRegister(this, DataSelection.ModbusDataDiscreteInputs, Device, LastRequestedAddress + k, TempBool);
                            //discreteInputs[LastRequestedAddress + k].Value = TempBool;
                        }
                        else {
                            ModbusSupport.SetRegister(this, DataSelection.ModbusDataCoils, Device, LastRequestedAddress + k, TempBool);
                            //coils[LastRequestedAddress + k].Value = TempBool;
                        }
                        k++;
                    }
                }
            }
            else if (inputFormat == StreamInputFormat.ModbusASCII) {
                int Device = ModbusSupport.GetArrayValue(0, ref Input);
                int Bytes = ModbusSupport.GetArrayValue(4, ref Input);
                int k = 0;
                for (int i = 0; i < Bytes; i++) {
                    int Temp = ModbusSupport.GetArrayValue(6 + (i * 2), ref Input);
                    for (int j = 0; j < 8; j++) {
                        bool TempBool = ((Temp >> j) & 0x01) == 0x01 ? true : false;
                        if (IsDiscrete == true) {
                            ModbusSupport.SetRegister(this, DataSelection.ModbusDataDiscreteInputs, Device, LastRequestedAddress + i, TempBool);
                            //discreteInputs[LastRequestedAddress + k].Value = TempBool;
                        }
                        else {
                            ModbusSupport.SetRegister(this, DataSelection.ModbusDataCoils, Device, LastRequestedAddress + i, TempBool);
                            //coils[LastRequestedAddress + k].Value = TempBool;
                        }
                        k++;
                    }
                }
            }
        }
        private void ModbusMasterReadRegisters(byte[] Input, int Length, bool IsHolding = true) {
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int Device = Input[0];
                int Count = Input[2] / 2;
                int k = 0;
                for (int i = 0; i < Count; i++) {
                    short Temp = (short)(((int)Input[3 + k] << 8) | (int)Input[4 + k]);
                    if (IsHolding == true) {
                        ModbusSupport.SetRegister(this, DataSelection.ModbusDataHoldingRegisters, Device, LastRequestedAddress + i, Temp);
                        //holdingRegisters[LastRequestedAddress + i].Value = Temp;
                    }
                    else {
                        ModbusSupport.SetRegister(this, DataSelection.ModbusDataInputRegisters, Device, LastRequestedAddress + i, Temp);
                        //inputRegisters[LastRequestedAddress + i].Value = Temp;
                    }
                    k += 2;
                }
            }
            else if (inputFormat == StreamInputFormat.ModbusASCII) {
                int Device = ModbusSupport.GetArrayValue(0, ref Input);
                int Count = ModbusSupport.GetArrayValue(4, ref Input) / 2;
                int k = 0;
                for (int i = 0; i < Count; i++) {
                    short Temp = (short)ModbusSupport.GetArrayValueRead4(6 + k, ref Input);
                    if (IsHolding == true) {
                        ModbusSupport.SetRegister(this, DataSelection.ModbusDataHoldingRegisters, Device, LastRequestedAddress + i, Temp);
                        //holdingRegisters[LastRequestedAddress + i].Value = Temp;
                    }
                    else {
                        ModbusSupport.SetRegister(this, DataSelection.ModbusDataInputRegisters, Device, LastRequestedAddress + i, Temp);
                        //inputRegisters[LastRequestedAddress + i].Value = Temp;
                    }
                    k += 4;
                }
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
        List<ModbusReturnResult> AwaitingResults = new List<ModbusReturnResult>();
        public void ModbusDiagnostics(int Device, ModbusSupport.DiagnosticSubFunction SubFunction, short Request) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidDiagnosticsPacket(outputFormat, Device, SubFunction, Request);
            //LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusWriteMaskRegister(int Device, short Address, short AndMask, short OrMask) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidMaskWritePacket(outputFormat, Device, Address, AndMask, OrMask);
            //LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusReadCoils(int Device, short Address, short Count) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            if ((Device < 1) || (Count > 0x07D0)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, ModbusSupport.FunctionCode.ReadCoils, Device, Address, Count);
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusReadDiscreteInputs(int Device, short Address, short Count) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            if ((Device < 1) || (Count > 0x07D0)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, ModbusSupport.FunctionCode.ReadDiscreteInputs, Device, Address, Count);
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusReadInputRegisters(int Device, short Address, short Count) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            if ((Device < 1) || (Count > 0x7D)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, ModbusSupport.FunctionCode.ReadInputRegisters, Device, Address, Count);
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusReadHoldingRegisters(int Device, short Address, short Count) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            if ((Device < 1) || (Count > 0x7D)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, ModbusSupport.FunctionCode.ReadHoldingRegisters, Device, Address, Count);
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusWriteCoil(int Device, short Address, bool Value) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            byte ValueTemp = 0x00;
            if (Value == true) {
                ValueTemp = (byte)0xFF;
            }
            else {
                ValueTemp = (byte)0x00;
            }
            byte[] Temp = ModbusSupport.BulidWriteSinglePacket(outputFormat, ModbusSupport.FunctionCode.WriteSingleCoil, Device, Address, ValueTemp, 0x00);
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusWriteRegister(int Device, short Address, short Value) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            byte Value0 = (byte)(Value >> 8);
            byte Value1 = (byte)(Value & 0xFF);
            byte[] Temp = ModbusSupport.BulidWriteSinglePacket(outputFormat, ModbusSupport.FunctionCode.WriteSingleHoldingRegister, Device, Address, Value0, Value1);
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusWriteMultipleCoils(int Device, short Address, List<bool> Values) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidWriteMultiplePacket(outputFormat, ModbusSupport.FunctionCode.WriteMultipleCoils, Device, Address, Values);
            //AwaitingResults.Add(new ModbusReturnResult(ModbusSupport.FunctionCode.WriteMultipleCoils, Device, Address, Values));
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusWriteMultipleRegisters(int Device, short Address, List<short> Values) {
            if ((Device < 0) || (Device > 255)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidWriteMultiplePacket(outputFormat, ModbusSupport.FunctionCode.WriteMultipleHoldingRegisters, Device, Address, Values);
            //AwaitingResults.Add(new ModbusReturnResult(ModbusSupport.FunctionCode.WriteMultipleCoils, Device, Address, Values));
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void NewSlave(int Unit) {
            int UnitIndex = ModbusSupport.UnitToIndex(this, Unit);
            if (UnitIndex == -1) {
                Slave.Add(new ModbusSlave(this, Unit));
                SystemManager.InvokeSlaveAdded(this);
            }
        }
        public void ModbusCommand(string Input) {
            if (Connected == false) { return; }
            try {
                if (isMaster == false) { return; }
                string Temp = Input.ToUpper().TrimStart(' ').TrimStart('\t');
                int Unit = 1;
                int Start = 0;
                //int Count = 1;
                if (CommandManager.TestKeyword(ref Temp, "UNIT")) {
                    string StrAddress = CommandManager.ReadAndRemove(ref Temp);

                    bool Success = int.TryParse(StrAddress, out Unit);
                    if (Success == false) { return; }
                    int UnitIndex = ModbusSupport.UnitToIndex(this, Unit);
                    if (UnitIndex == -1) {
                        NewSlave(Unit);
                    }
                }
                if (CommandManager.TestKeyword(ref Temp, "READ")) {
                    if (CommandManager.GetValue(ref Temp, "COILS", out Start)) {
                        InitialTestReadQuery(Unit, Start, ref Temp, DataSelection.ModbusDataCoils);
                    }
                    else if (CommandManager.GetValue(ref Temp, "DISCRETE", out Start)) {
                        InitialTestReadQuery(Unit, Start, ref Temp, DataSelection.ModbusDataDiscreteInputs);
                    }
                    else if (CommandManager.GetValue(ref Temp, "REGISTERS", out Start)) {
                        InitialTestReadQuery(Unit, Start, ref Temp, DataSelection.ModbusDataHoldingRegisters);
                    }
                    else if (CommandManager.GetValue(ref Temp, "HOLDINGS", out Start)) {
                        InitialTestReadQuery(Unit, Start, ref Temp, DataSelection.ModbusDataHoldingRegisters);
                    }
                    else if (CommandManager.GetValue(ref Temp, "INREGISTERS", out Start)) {
                        InitialTestReadQuery(Unit, Start, ref Temp, DataSelection.ModbusDataInputRegisters);
                    }
                    else if (CommandManager.GetValue(ref Temp, "INPUTS", out Start)) {
                        InitialTestReadQuery(Unit, Start, ref Temp, DataSelection.ModbusDataInputRegisters);
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "COILS")) {
                        SecondTestReadQuery(Unit, ref Temp, DataSelection.ModbusDataCoils);
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "DISCRETE")) {
                        SecondTestReadQuery(Unit, ref Temp, DataSelection.ModbusDataDiscreteInputs);
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "REGISTERS")) {
                        SecondTestReadQuery(Unit, ref Temp, DataSelection.ModbusDataHoldingRegisters);
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "HOLDINGS")) {
                        SecondTestReadQuery(Unit, ref Temp, DataSelection.ModbusDataHoldingRegisters);
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "INREGISTERS")) {
                        SecondTestReadQuery(Unit, ref Temp, DataSelection.ModbusDataInputRegisters);
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "INPUTS")) {
                        SecondTestReadQuery(Unit, ref Temp, DataSelection.ModbusDataInputRegisters);
                    }
                    else if (CommandManager.GetValue(ref Temp, "COIL", out Start)) {
                        SingleTestReadQuery(Unit, Start, ref Temp, DataSelection.ModbusDataCoils);
                    }
                    else if (CommandManager.GetValue(ref Temp, "REGISTER", out Start)) {
                        SingleTestReadQuery(Unit, Start, ref Temp, DataSelection.ModbusDataHoldingRegisters);
                    }
                    else if (CommandManager.GetValue(ref Temp, "HOLDING", out Start)) {
                        SingleTestReadQuery(Unit, Start, ref Temp, DataSelection.ModbusDataHoldingRegisters);
                    }
                    else if (CommandManager.GetValue(ref Temp, "INREGISTER", out Start)) {
                        SingleTestReadQuery(Unit, Start, ref Temp, DataSelection.ModbusDataInputRegisters);
                    }
                    else if (CommandManager.GetValue(ref Temp, "INPUT", out Start)) {
                        SingleTestReadQuery(Unit, Start, ref Temp, DataSelection.ModbusDataInputRegisters);
                    }
                }
                else if (CommandManager.TestKeyword(ref Temp, "WRITE")) {
                    if (CommandManager.TestKeyword(ref Temp, "REGISTERS")) {
                        if (CommandManager.GetValue(ref Temp, "FROM", out Start, false)) {
                            List<short> Values = new List<short>();
                            if (CommandManager.GetIntegerValues(ref Temp, "WITH", ref Values)) {
                                ModbusWriteMultipleRegisters(Unit, (short)Start, Values);
                            }
                        }
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "HOLDINGS")) {
                        if (CommandManager.GetValue(ref Temp, "FROM", out Start, false)) {
                            List<short> Values = new List<short>();
                            if (CommandManager.GetIntegerValues(ref Temp, "WITH", ref Values)) {
                                ModbusWriteMultipleRegisters(Unit, (short)Start, Values);
                            }
                        }
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "COILS")) {
                        if (CommandManager.GetValue(ref Temp, "FROM", out Start, false)) {
                            List<bool> Values = new List<bool>();
                            if (CommandManager.GetBooleanValues(ref Temp, "WITH", ref Values)) {
                                ModbusWriteMultipleCoils(Unit, (short)Start, Values);
                            }
                        }
                    }
                    else if (CommandManager.GetValue(ref Temp, "COIL", out Start, true)) {
                        if (CommandManager.TestKeyword(ref Temp, "=")) {
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
                    else if (CommandManager.GetValue(ref Temp, "REGISTER", out Start, true)) {
                        int Value = 0;
                        if (CommandManager.GetValue(ref Temp, "=", out Value)) {
                            ModbusWriteRegister(Unit, (short)Start, (short)Value);
                        }
                        else { ModbusWriteRegister(Unit, (short)Start, (short)0); }
                    }
                    else if (CommandManager.GetValue(ref Temp, "HOLDING", out Start, true)) {
                        int Value = 0;
                        if (CommandManager.GetValue(ref Temp, "=", out Value)) {
                            ModbusWriteRegister(Unit, (short)Start, (short)Value);
                        }
                        else { ModbusWriteRegister(Unit, (short)Start, (short)0); }
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "MASK")) {
                        if (CommandManager.GetValue(ref Temp, "REGISTER", out Start, ' ')) {
                            int Value = 0;
                            if (CommandManager.GetValue(ref Temp, "WITH", out Value, ',')) {
                                int Value2 = 0;
                                if (CommandManager.GetValue(ref Temp, ",", out Value2)) {
                                    ModbusWriteMaskRegister(Unit, (short)Start, (short)Value, (short)Value2);
                                }
                                else {
                                    ModbusWriteMaskRegister(Unit, (short)Start, (short)Value, 0);
                                }
                            }
                        }
                    }
                }
                else if (CommandManager.TestKeyword(ref Temp, "DIAGNOSTICS")) {
                    if (CommandManager.TestKeyword(ref Temp, "RETURN")) {
                        if (CommandManager.TestKeyword(ref Temp, "QUERY")) {
                            if (CommandManager.GetValue(ref Temp, "WITH", out Start, false)) {
                                ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnQueryData, (short)Start);
                            }
                        }
                        else if (CommandManager.TestKeyword(ref Temp, "REGISTER")) {
                            ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnDiagnosticRegister, 0);
                        }
                        else if (CommandManager.TestKeyword(ref Temp, "BUS")) {
                            if (CommandManager.TestKeyword(ref Temp, "MESSAGES")) {
                                ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnBusMessageCount, 0);
                            }
                            else if (CommandManager.TestKeyword(ref Temp, "ERRORS")) {
                                ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnBusCommunicationErrorCount, 0);
                            }
                            else if (CommandManager.TestKeyword(ref Temp, "EXCEPTIONS")) {
                                ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnBusExceptionErrorCount, 0);
                            }
                            else if (CommandManager.TestKeyword(ref Temp, "OVERRUNS")) {
                                ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnBusCharacterOverrunCount, 0);
                            }
                        }
                        else if (CommandManager.TestKeyword(ref Temp, "SLAVE")) {
                            if (CommandManager.TestKeyword(ref Temp, "MESSAGES")) {
                                ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnSlaveMessageCount, 0);
                            }
                            else if (CommandManager.TestKeyword(ref Temp, "BUSY")) {
                                ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnSlaveBusyCount, 0);
                            }
                            else if (CommandManager.TestKeyword(ref Temp, "NORES")) {
                                ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnSlaveNoResponseCount, 0);
                            }
                            else if (CommandManager.TestKeyword(ref Temp, "NONAK")) {
                                ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnSlaveNAKCount, 0);
                            }
                        }
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "CLEAR")) {
                        if (CommandManager.TestKeyword(ref Temp, "COUNTERS")) {
                            ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ClearCountersAndDiagnosticRegister, 0);
                        }
                        else if (CommandManager.TestKeyword(ref Temp, "OVERRUN")) {
                            ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ClearOverrunCounterAndFlag, 0);
                        }
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "RESTART")) {
                        if (CommandManager.GetValue(ref Temp, "WITH", out Start, false)) {
                            ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.RestartCommunicationsOption, (short)Start);
                        }
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "FORCE")) {
                        if (CommandManager.TestKeyword(ref Temp, "LISTEN")) {
                            ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ForceListenOnlyMode, 0);
                        }
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "SET")) {
                        if (CommandManager.TestKeyword(ref Temp, "DELIMITER")) {
                            if (CommandManager.GetValue(ref Temp, "WITH", out Start, false)) {
                                ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ChangeASCIIInputDelimiter, (short)Start);
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private void InitialTestReadQuery(int Unit, int Start, ref string Temp, DataSelection DataSet) {
            int Count = 0;
            if (CommandManager.GetValue(ref Temp, "QTY", out Count)) {
                SelectRead(Unit, (short)Start, (short)Count, DataSet);
            }
            else if (CommandManager.GetValue(ref Temp, "TO", out Count)) {
                Point StartAndDiff = CommandManager.GetStartAndDifference(Start, Count);
                if (StartAndDiff.Y <= 0) { return; }
                SelectRead(Unit, (short)StartAndDiff.X, (short)StartAndDiff.Y, DataSet);
            }
            else { SelectRead(Unit, (short)Start, (short)1, DataSet); }
        }
        private void SingleTestReadQuery(int Unit, int Start, ref string Temp, DataSelection DataSet) {
            SelectRead(Unit, (short)Start, (short)1, DataSet);
        }
        private void SelectRead(int Unit, short Start, short Count, DataSelection DataSet) {
            switch (DataSet) {
                case DataSelection.ModbusDataCoils:
                    ModbusReadCoils(Unit, Start, Count); break;
                case DataSelection.ModbusDataDiscreteInputs:
                    ModbusReadDiscreteInputs(Unit, Start, Count); break;
                case DataSelection.ModbusDataInputRegisters:
                    ModbusReadInputRegisters(Unit, Start, Count); break;
                case DataSelection.ModbusDataHoldingRegisters:
                    ModbusReadHoldingRegisters(Unit, Start, Count); break;
                default: return;
            }
        }
        private void SecondTestReadQuery(int Unit, ref string Temp, DataSelection DataSet) {
            int Start = 0;
            int Count = 0;
            if (CommandManager.GetValue(ref Temp, "FROM", out Start, false)) {
                if (CommandManager.GetValue(ref Temp, "TO", out Count)) {
                    Point StartAndDiff = CommandManager.GetStartAndDifference(Start, Count);
                    if (StartAndDiff.Y <= 0) { return; }
                    switch (DataSet) {
                        case DataSelection.ModbusDataCoils:
                            ModbusReadCoils(Unit, (short)StartAndDiff.X, (short)StartAndDiff.Y); break;
                        case DataSelection.ModbusDataDiscreteInputs:
                            ModbusReadDiscreteInputs(Unit, (short)StartAndDiff.X, (short)StartAndDiff.Y); break;
                        case DataSelection.ModbusDataInputRegisters:
                            ModbusReadInputRegisters(Unit, (short)StartAndDiff.X, (short)StartAndDiff.Y); break;
                        case DataSelection.ModbusDataHoldingRegisters:
                            ModbusReadHoldingRegisters(Unit, (short)StartAndDiff.X, (short)StartAndDiff.Y); break;
                        default: return;
                    }

                }
            }
        }
        #endregion
        #region Modbus Transmission
        private List<byte[]> ModbusTransmitBuffer = new List<byte[]>();
        private void ModbusFramer() {
            while (ModbusTransmitBuffer.Count > 0) {
                if ((DateTime.UtcNow.Ticks - LastTransmittedTime.Ticks) > SilenceLength + outputRTUSilenceCalibration) {
                    lastTransmittedTime = DateTime.UtcNow;
                    if (ModbusTransmitBuffer.Count > 0) {
                        byte[] Data = ModbusTransmitBuffer[0];
                        TransmitRTUFrame(Data);
                        ModbusTransmitBuffer.RemoveAt(0);
                    }
                }
            }
        }
        private void TransmitFrame(byte[] Data) {
            if (outputFormat == StreamOutputFormat.ModbusRTU) {
                if ((DateTime.UtcNow.Ticks - LastTransmittedTime.Ticks) > SilenceLength + outputRTUSilenceCalibration) {
                    TransmitRTUFrame(Data);
                }
                else {
                    ModbusTransmitBuffer.Add(Data);
                    bool StartThread = false;
                    if (ModbusRTUFramerThread != null) {
                        if (ModbusRTUFramerThread.ThreadState != System.Threading.ThreadState.Running) {
                            StartThread = true;
                        }
                    }
                    else { StartThread = true; }
                    if (StartThread) {
                        ModbusRTUFramerThread = new Thread(ModbusFramer);
                        ModbusRTUFramerThread.Start();
                    }
                }
            }
            else if (outputFormat == StreamOutputFormat.ModbusASCII) {
                TransmitASCIIFrame(Data);
            }
        }
        private void TransmitRTUFrame(byte[] Data) {
            byte[] Output = new byte[Data.Length + 2];
            ushort CRC = ModbusSupport.CalculateCRC(Data, (ushort)Data.Length, 0);
            Array.Copy(Data, 0, Output, 0, Data.Length);
            Output[Output.Length - 2] = (byte)(CRC & 0xFF);
            Output[Output.Length - 1] = (byte)(CRC >> 8);
            lastTransmittedTime = DateTime.UtcNow;
            Port.Write(Output, 0, Output.Length);
            lastTransmittedTime = DateTime.UtcNow;
            bytesSent += (ulong)Output.Length;
            DataReceived?.Invoke(this, true, PrintStream(Output));
        }
        private void TransmitASCIIFrame(byte[] Data) {
            byte[] Output = new byte[Data.Length + 5];
            byte LRC = ModbusSupport.CalculateLRC(Data, (ushort)Data.Length, 0);
            Array.Copy(Data, 0, Output, 1, Data.Length);
            Output[0] = (byte)':';
            ModbusSupport.SetArrayValue(Output.Length - 4, LRC, ref Output);
            Output[Output.Length - 2] = (byte)'\r';
            Output[Output.Length - 1] = (byte)'\n';
            lastTransmittedTime = DateTime.UtcNow;
            DataReceived?.Invoke(this, true, PrintStream(Output));
            Port.Write(Output, 0, Output.Length);
            lastTransmittedTime = DateTime.UtcNow;
            bytesSent += (ulong)Output.Length;
        }
        #endregion
        #region Modbus Slaves
        public void NewSlave(int Address, string Name) {
            int Index = ModbusSupport.UnitToIndex(this, Address);
            if (Index > 0) { return; }
            slave.Add(new ModbusSlave(this, Address, Name));
            SystemManager.InvokeSlaveAdded(this);
        }
        public void RemoveSlave(int Address, bool UseIndex = false) {
            int Index = UseIndex == false ? ModbusSupport.UnitToIndex(this, Address) : Address;
            if (Index < 0) { return; }
            if (Index >= Slave.Count) { return; }
            ModbusSupport.RemoveSnapshot(Slave[Index]);
            Slave[Index].CleanUp();
            Slave.RemoveAt(Index);
            GC.Collect();
            if (Slave.Count <= 0) {
                NewSlave(1);
            }
            SystemManager.InvokeSlaveChanged(this);
        }
        public void RenameSlave(int Address, string Name) {
            int Index = ModbusSupport.UnitToIndex(this, Address);
            if (Index < 0) { return; }
            Slave[Index].Name = Name;
            SystemManager.InvokeSlaveChanged(this);
        }
        #endregion 
        #region Data Formatting
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
        #endregion
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
        #region C Command Recieve Handler 
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
                    ProgramManager.ProgramDataReceived(this.ID, CurrentCommand);
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
        #region Stream Transmission
        private bool StreamTransmit(string Data, Enums.ModbusEnums.DataFormat Format) {
            byte[] Output;
            if (Formatters.StringToByteStream(Data, Format, out Output)) {
                try {
                    if (Port.IsOpen) {
                        Port.Write(Output, 0, Output.Length);
                    }
                    return true;
                }
                catch {
                    return false;
                }
            }
            return false;
        }
        #endregion
        private enum MessageState {
            Ready = 0x00,
            Armed = 0x01,
            InCommand = 0x02,
            Complete = 0x04
        }
        private enum ModbusASCIIState {
            Ready = 0x00,
            Armmed = 0x01,
            Closing = 0x02
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
