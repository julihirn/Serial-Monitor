using Handlers;
using ODModules;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.Enums.FormatEnums;

namespace Serial_Monitor.Classes {
    public class SerialManager : IDisposable {

        const int MODBUS_MIN_DEVICE_ADDRESS = 0;
        const int MODBUS_MAX_DEVICE_ADDRESS = 255;
        //Thread TrFramer;
        //bool FramerRunning = true;
        Thread? HeartbeatThread = null; // new Thread();
        Thread? ModbusRTUFramerThread = null;
        public SerialManager() {
            iD = Guid.NewGuid().ToString();
            // Port.DataReceived += Port_DataReceived;
            //Port.
            Port.WriteTimeout = 1000;
            Port.ReadTimeout = 10000;
            Port.ReadBufferSize = 10000;
            Port.WriteBufferSize = 50000;
            Port.DtrEnable = true;
            HeartbeatThread = new Thread(HeartBeat);
            HeartbeatThread.IsBackground = true;
            HeartbeatThread.Start();

            ModbusRTUFramerThread = new Thread(ModbusFramer);
            ModbusRTUFramerThread.IsBackground = true;

            registers = new ModbusSlave(this, -1);
            DeriveSilence();
        }
        public void Dispose() {
            GC.SuppressFinalize(this);
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
            if (registers != null) {
                registers.CleanUp();
            }
            ClearSlaves();
            try {
                //Port.DataReceived -= Port_DataReceived;
                if (Port.IsOpen == true) { Port.Close(); }
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
                        if (OpenPrevious != Connected) {
                            SystemManager.InvokePortStatusChanged(this);
                            OpenPrevious = Connected;
                        }
                        Connect();
                    }
                }
                catch { }
                Thread.Sleep(1000);
            }
        }
        public void Connect() {
            try {
                if (!Connected) {
                    DeriveSilence();
                    //Serial.DeviceHandler.SetLowLatency(PortName);
                    this.Port.Open();
                    InitaliseZeroLatencyReceiver();
                }
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
        uint bufferSize = 5;
        [Category("Modbus")]
        [DisplayName("Buffer Size")]
        public uint BufferSize {
            get { return bufferSize; }
            set {
                bufferSize = value;
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
        bool outputModbusFrameToTerminal = false;
        [Category("Modbus")]
        [DisplayName("Output Modbus Frame")]
        public bool OutputModbusFrameToTerminal {
            get { return outputModbusFrameToTerminal; }
            set {
                outputModbusFrameToTerminal = value;
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
        int inputRTUSilenceCalibration = 0;
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
                        DeriveSilence();

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
                        DeriveSilence();
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
                        DeriveSilence();
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
                        DeriveSilence();
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
        protected Stream GetStream() {
            return this.Port.BaseStream;
        }
        long SilenceLength = 29166;
        private void DeriveSilence() {
            decimal PacketLength = DataBits + 1;
            if (Parity != Parity.None) { PacketLength++; }
            if (StopBits == StopBits.One) { PacketLength++; }
            else if (StopBits == StopBits.OnePointFive) { PacketLength += 1.5m; }
            else if (StopBits == StopBits.Two) { PacketLength += 2.0m; }

            SilenceLength = (long)((1.0m / (decimal)Port.BaudRate) * 35000000.0m * PacketLength);
            //if (SilenceLength < 10000) {
            //    SilenceLength = 1000000;
            //}
            //SilenceLength = (long)(280000000.0m / (decimal)Port.BaudRate);
        }
        bool allowEscapeCharacters = true;
        [Category("Data Formatting")]
        [DisplayName("Allow Escape Characters")]
        public bool AllowEscapeCharacters {
            get { return allowEscapeCharacters; }
            set {
                allowEscapeCharacters = value;
                SystemManager.InvokeChannelPropertiesChanged(this);
            }
        }
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
        [Category("Port Scanning")]
        [DisplayName("Scan String")]
        public string ScanWithString {
            get { return Scan_String; }
            set {
                if (Scan_InProgress) { return; }
                Scan_String = value;
            }
        }
        [Category("Port Scanning")]
        [DisplayName("Retry Attempts")]
        public uint ScanRetryCount {
            get { return Scan_RequestedRetryCount; }
            set {
                if (Scan_InProgress) { return; }
                if (value <= 0) { Scan_RequestedRetryCount = 1; }
                Scan_RequestedRetryCount = value;
            }
        }
        [Category("Port Scanning")]
        [DisplayName("Timeout")]
        public uint ScanTimeout {
            get { return Scan_Timeout; }
            set {
                if (Scan_InProgress) { return; }
                if (value <= 0) { Scan_Timeout = 1; }
                Scan_Timeout = value;
            }
        }
        [Category("Port Scanning")]
        [DisplayName("Ignore Port Failures")]
        public bool ScanIgnorePortFailures {
            get { return Scan_IgnorePortFailures; }
            set {
                if (Scan_InProgress) { return; }
                Scan_IgnorePortFailures = value;
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
                if (allowEscapeCharacters) {
                    return SendEscapedSequence(Data, Appendage, false);

                }
                return Post(Data + Appendage, false);
            }
            else {
                if (allowEscapeCharacters) {
                    return SendEscapedSequence(Data, "", false);
                }
                return Post(Data, false);
            }
        }
        private bool SendEscapedSequence(string Input, string Appendage = "", bool Writeline = false) {
            try {
                string Unescaped = Regex.Unescape(Input) + Appendage;
                return Post(Unescaped, Writeline);
            }
            catch {
                SystemManager.Print(ErrorType.M_Warning, "POST_INVALID_ESC", "The text: \"" + Input + "\" contains an invalid escape sequence");
                return false;
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
                        ModbusQuery.ModbusCommand(this, Data);
                        break;
                    case StreamOutputFormat.ModbusASCII:
                        ModbusQuery.ModbusCommand(this, Data);
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
                    case StreamOutputFormat.Base64:
                        TransmitBase64(Data);
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
        private void InitaliseZeroLatencyReceiver() {
            Thread TrMbRTURx = new Thread(() => ZeroLatencyReceiver());
            TrMbRTURx.Name = "TrSPRx";
            TrMbRTURx.Priority = ThreadPriority.Highest;
            TrMbRTURx.IsBackground = true;
            TrMbRTURx.Start();
        }
        private void ZeroLatencyReceiver() {
            byte[] buffer = new byte[2000];
            Action? kickoffRead = null;
            kickoffRead = delegate {
                if (Port.IsOpen) {
                    Port.BaseStream.BeginRead(buffer, 0, buffer.Length, delegate (IAsyncResult ar) {
                        try {
                            //if (!Port.IsOpen) { return; }
                            if (Port.IsOpen && Port.BaseStream.CanRead) {
                                try {
                                    int actualLength = Port.BaseStream.EndRead(ar);
                                    byte[] received = new byte[actualLength];
                                    Buffer.BlockCopy(buffer, 0, received, 0, actualLength);
                                    switch (InputFormat) {
                                        case StreamInputFormat.Text:
                                            TextProcessor(received);
                                            break;
                                        case StreamInputFormat.CCommand:
                                            CCommandProcessor(received);
                                            break;
                                        case StreamInputFormat.BinaryStream:
                                            StreamProcessor(received);
                                            break;
                                        case StreamInputFormat.HexStream:
                                            HexStreamProcessor(received);
                                            break;
                                        case StreamInputFormat.ModbusRTU:
                                            ModbusRTUProcessor(received);
                                            break;
                                        case StreamInputFormat.ModbusASCII:
                                            ModbusASCIIProcessor(received);
                                            break;
                                        case StreamInputFormat.StreamBinary:
                                            StreamProcessor(received, Enums.ModbusEnums.DataFormat.Binary);
                                            break;
                                        case StreamInputFormat.StreamOctal:
                                            StreamProcessor(received, Enums.ModbusEnums.DataFormat.Octal);
                                            break;
                                        case StreamInputFormat.StreamDecimal:
                                            StreamProcessor(received, Enums.ModbusEnums.DataFormat.Decimal);
                                            break;
                                        case StreamInputFormat.StreamHexadecimal:
                                            StreamProcessor(received, Enums.ModbusEnums.DataFormat.Hexadecimal);
                                            break;
                                        default:
                                            break;
                                    }
                                    lastReceivedTime = DateTime.UtcNow;
                                }
                                catch (IOException ex) {
                                    Console.WriteLine("Device disconnected! IOException: " + ex.Message);
                                }
                            }
                        }
                        catch (IOException ex) {
                            Console.WriteLine("Device disconnected! IOException: " + ex.Message);
                        }
                        if (kickoffRead != null) {
                            if (Port.IsOpen) {
                                kickoffRead();
                            }
                        }
                    }, null);
                }
            };
            if (kickoffRead != null) {
                if (Port.IsOpen) {
                    kickoffRead();
                }
            }
        }
        #endregion
        #region Data Processing
        private string lastReceivedLine = "";
        [Browsable(false)]
        public string LastReceivedLine {
            get { return lastReceivedLine; }
        }
        private string secondLastReceivedLine = "";
        [Browsable(false)]
        public string SecondLastReceivedLine {
            get { return secondLastReceivedLine; }
        }
        private string thirdLastReceivedLine = "";
        [Browsable(false)]
        public string ThirdLastReceivedLine {
            get { return thirdLastReceivedLine; }
        }
        [Browsable(false)]
        public string LastReceived {
            get {
                if (lastReceivedLine.Length == 0) {
                    return secondLastReceivedLine;
                }
                else { return lastReceivedLine; }
            }
        }
        private void TextProcessor(byte[] InputBuf) {
            try {
                StringBuilder sb = new StringBuilder();
                bytesReceived += (ulong)InputBuf.Length;
                for (int j = 0; j < InputBuf.Length; j++) {
                    string Result = ((char)InputBuf[j]).ToString();
                    PushToLast((char)InputBuf[j]);
                    //Output.AttendToLastLine(((char)Buffer[j]).ToString(), true);
                    sb.Append(Result);
                    //DataReceived?.Invoke(this, false, Result);
                    ProgramManager.ProgramDataReceived(this.ID, Result);
                }
                DataReceived?.Invoke(this, false, sb.ToString());
                SystemManager.InvokeChannelDataReceived(this, InputBuf, InputBuf.Length, sb.ToString(), false);
            }
            catch { }
        }
        private void TextProcessor(object sender) {
            try {
                byte[] Buffer = new byte[ushort.MaxValue + 1];
                int i = 0;
                int BytesToRead = ((SerialPort)sender).BytesToRead;
                bytesReceived += (ulong)BytesToRead;
                i = ((SerialPort)sender).Read(Buffer, 0, BytesToRead);
                for (int j = 0; j < BytesToRead; j++) {
                    string Result = ((char)Buffer[j]).ToString();
                    PushToLast((char)Buffer[j]);
                    //Output.AttendToLastLine(((char)Buffer[j]).ToString(), true);
                    DataReceived?.Invoke(this, false, Result);
                    ProgramManager.ProgramDataReceived(this.ID, Result);
                }
            }
            catch { }
        }
        private void PushToLast(char Input) {
            if (lastReceivedLine.Length > 400) {
                if ((Input == '\r') || (Input == '\n')) {
                    thirdLastReceivedLine = secondLastReceivedLine;
                    secondLastReceivedLine = lastReceivedLine;
                    lastReceivedLine = "";
                }
                else { lastReceivedLine = Input.ToString(); }
            }
            else {
                if ((Input == '\r') || (Input == '\n')) {
                    thirdLastReceivedLine = secondLastReceivedLine;
                    secondLastReceivedLine = lastReceivedLine;
                    lastReceivedLine = "";
                }
                else { lastReceivedLine += Input; }
            }
        }
        private void CCommandProcessor(byte[] InputBuf) {
            try {
                bytesReceived += (ulong)InputBuf.Length;
                for (int j = 0; j < InputBuf.Length; j++) {
                    ProcessByte(InputBuf[j]);
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
        private void StreamProcessor(byte[] InputBuf) {
            try {
                bytesReceived += (ulong)InputBuf.Length;
                string Space = "  ";
                for (int j = 0; j < InputBuf.Length; j++) {
                    StringBuilder Result = new StringBuilder();
                    Result.Append(Classes.Formatters.ByteToBinary(InputBuf[j]));
                    Result.Append(Space);
                    Result.Append(Classes.Formatters.ByteToHex(InputBuf[j]));
                    Result.Append(Space);
                    string Char = ((char)InputBuf[j]).ToString();
                    Result.Append(Classes.Formatters.ByteToChar(InputBuf[j]));
                    //Output.Print(Result);
                    DataReceived?.Invoke(this, true, Result.ToString());
                    SystemManager.InvokeChannelDataReceived(this, InputBuf[j], Result.ToString(), true);
                    ProgramManager.ProgramDataReceived(this.ID, Result.ToString());
                }
            }
            catch { }
        }
        private void HexStreamProcessor(byte[] InputBuf) {
            try {
                bytesReceived += (ulong)InputBuf.Length;
                string Space = " ";
                const int HexLength = 5;
                const int MaxLength = 40;
                int PayloadDisplayLength = 0;
                StringBuilder HexResult = new StringBuilder();
                StringBuilder StrResult = new StringBuilder();
                for (int j = 0; j < InputBuf.Length; j++) {
                    HexResult.Append(Classes.Formatters.ByteToHex(InputBuf[j]));
                    StrResult.Append(Classes.Formatters.ByteToChar(InputBuf[j]));
                    HexResult.Append(Space);
                    PayloadDisplayLength += HexLength;
                    if (((j % 8) == 0) || (j == InputBuf.Length - 1)) {
                        HexResult.Append(Space);
                        int DiffLength = MaxLength - PayloadDisplayLength;
                        if (DiffLength > 0) {
                            for (int k = 0; k < DiffLength; k++) {
                                HexResult.Append(Space);
                            }
                        }
                        string Char = ((char)InputBuf[j]).ToString();
                        HexResult.Append(StrResult.ToString());
                        //Output.Print(Result);
                        DataReceived?.Invoke(this, true, HexResult.ToString());
                        SystemManager.InvokeChannelDataReceived(this, InputBuf[j], HexResult.ToString(), true);
                        ProgramManager.ProgramDataReceived(this.ID, HexResult.ToString());
                        HexResult.Clear();
                        StrResult.Clear();
                        PayloadDisplayLength = 0;
                    }
                }
            }
            catch { }
        }
        private void StreamProcessor(byte[] InputBuf, Enums.ModbusEnums.DataFormat Format) {
            try {
                bytesReceived += (ulong)InputBuf.Length;
                string Result = "";
                for (int j = 0; j < InputBuf.Length; j++) {
                    switch (Format) {
                        case Enums.ModbusEnums.DataFormat.Binary:
                            Result += Classes.Formatters.ByteToBinary(InputBuf[j]); break;
                        case Enums.ModbusEnums.DataFormat.Octal:
                            Result += Convert.ToString(InputBuf[j], 8); break;
                        case Enums.ModbusEnums.DataFormat.Decimal:
                            Result += InputBuf[j].ToString(); break;
                        case Enums.ModbusEnums.DataFormat.Hexadecimal:
                            Result += Classes.Formatters.ByteToHex(InputBuf[j]); break;
                        default: break;
                    }
                    Result += " ";
                }
                SystemManager.InvokeChannelDataReceived(this, InputBuf, InputBuf.Length, Result.ToString(), false);
                DataReceived?.Invoke(this, true, Result);
                ProgramManager.ProgramDataReceived(this.ID, Result);
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
        //private void ModbusRTUVerifier() {
        //    try {
        //        int LatchedBytesToCheck = RXCurrentByte;
        //        bool NothingFound = true;
        //        if (LatchedBytesToCheck >= 0) {
        //            // Debug.Print("Read Length: " + Buffer.Length + " " + RXCurrentByte.ToString());
        //            for (int j = 4; j <= LatchedBytesToCheck; j++) {
        //                lastReceivedTime = DateTime.UtcNow;

        //                if (ModbusSupport.IsModbusFrameVaild(RXBuffer, j) == false) { continue; }
        //                lastReceivedTime = DateTime.UtcNow;
        //                int NewIndex = j + 1;
        //                int NewLength = (LatchedBytesToCheck - j);
        //                if (NewLength >= 0) {
        //                    byte[] Temp = RXBuffer;
        //                    byte[] TemoSends = new byte[j];
        //                    Array.Copy(RXBuffer, 0, TemoSends, 0, j);
        //                    if (NewLength > 0) {
        //                        Array.Copy(Temp, NewIndex, RXBuffer, 0, NewLength);
        //                    }
        //                    RXCurrentByte = NewLength;
        //                    Port.DiscardInBuffer();
        //                    Thread TrMbRTURx = new Thread(() => RTUStringProcessor(TemoSends));
        //                    TrMbRTURx.Name = "TrMbRTURx";
        //                    TrMbRTURx.IsBackground = true;
        //                    TrMbRTURx.Start();

        //                }
        //                else {
        //                    RXCurrentByte = 0;
        //                }
        //                NothingFound = false;
        //                break;
        //            }
        //        }
        //        if (NothingFound == true) {
        //        }
        //        if (RXCurrentByte > 512) {
        //            RXCurrentByte = 0;
        //        }
        //        lastReceivedTime = DateTime.UtcNow;
        //    }
        //    catch { }
        //}
        //private void ModbusRTUProcessor(object sender) {
        //    try {
        //        if ((DateTime.UtcNow.Ticks - lastReceivedTime.Ticks) >= SilenceLength + 10000) {
        //            RXCurrentByte = 0;
        //            //Debug.Print("Timeout");
        //        }
        //        lastReceivedTime = DateTime.UtcNow;
        //        int i = 0;
        //        int BytesToRead = ((SerialPort)sender).BytesToRead;
        //        byte[] Buffer = new byte[BytesToRead];
        //        bytesReceived += (ulong)BytesToRead;
        //        i = ((SerialPort)sender).Read(Buffer, 0, BytesToRead);
        //        Array.Copy(Buffer, 0, RXBuffer, RXCurrentByte, BytesToRead);
        //        RXCurrentByte += BytesToRead;
        //        //Debug.Print(DateTime.UtcNow.Ticks.ToString() + " Read Length: " + Buffer.Length.ToString() + " " + RXCurrentByte.ToString());
        //        Thread TrMbRTUVerfy = new Thread(() => ModbusRTUVerifier());
        //        TrMbRTUVerfy.Name = "TrMbRTUVerfy";
        //        TrMbRTUVerfy.IsBackground = true;
        //        TrMbRTUVerfy.Start();
        //        //int LatchedBytesToCheck = RXCurrentByte;
        //        //bool NothingFound = true;
        //        //if (LatchedBytesToCheck >= 0) {
        //        //    Debug.Print("Read Length: " + Buffer.Length + " " + RXCurrentByte.ToString());
        //        //    for (int j = 4; j <= LatchedBytesToCheck; j++) {
        //        //        lastReceivedTime = DateTime.UtcNow;

        //        //        if (ModbusSupport.IsModbusFrameVaild(RXBuffer, j) == false) { continue; }

        //        //        lastReceivedTime = DateTime.UtcNow;
        //        //        int NewIndex = j + 1;
        //        //        int NewLength = (LatchedBytesToCheck - j);
        //        //        if (NewLength >= 0) {
        //        //            byte[] Temp = RXBuffer;
        //        //            byte[] TemoSends = new byte[j];
        //        //            Array.Copy(RXBuffer, 0, TemoSends, 0, j);
        //        //            if (NewLength > 0) {
        //        //                Array.Copy(Temp, NewIndex, RXBuffer, 0, NewLength);
        //        //            }
        //        //            RXCurrentByte = NewLength;
        //        //            Thread TrMbRTURx = new Thread(() => RTUStringProcessor(TemoSends));
        //        //            TrMbRTURx.Name = "TrMbRTURx";
        //        //            TrMbRTURx.IsBackground = true;
        //        //            TrMbRTURx.Start();

        //        //        }
        //        //        else {
        //        //            RXCurrentByte = 0;
        //        //        }
        //        //        NothingFound = false;
        //        //        break;
        //        //    }
        //        //}
        //        //if (NothingFound == true) {
        //        //}
        //        if (RXCurrentByte > 512) {
        //            RXCurrentByte = 0;
        //        }
        //        lastReceivedTime = DateTime.UtcNow;
        //        //if (ModbusSupport.IsModbusFrameVaild(RXBuffer, RXCurrentByte) == true) {
        //        //    //string StringBuffer = PrintStream(Buffer);
        //        //    //DataReceived?.Invoke(this, true, StringBuffer);
        //        //    //ProgramManager.ProgramDataReceived(this.ID, StringBuffer);
        //        //    //ModbusSupport.FunctionCode Func = (ModbusSupport.FunctionCode)Buffer[1];
        //        //    //ModbusProcessCommand(ref Buffer, Func, Buffer[0]);
        //        //    RXCurrentByte = 0;
        //        //    Thread TrMbRTURx = new Thread(() => RTUStringProcessor(Buffer));
        //        //    TrMbRTURx.Name = "TrMbRTURx";
        //        //    TrMbRTURx.IsBackground = true;
        //        //    TrMbRTURx.Start();
        //        //}
        //        //else {
        //        //    string StringBuffer = PrintStream(Buffer);
        //        //    Debug.Print("Invalid: " + StringBuffer);
        //        //}
        //    }
        //    catch { }
        //    lastReceivedTime = DateTime.UtcNow;
        //}
        bool AwaitingPreviousCommand = false;
        private void ModbusRTUProcessor(byte[] InputBuf) {
            try {

                AwaitingPreviousCommand = true;
                lastReceivedTime = DateTime.UtcNow;
                bytesReceived += (ulong)InputBuf.Length;
                Array.Copy(InputBuf, 0, RXBuffer, RXCurrentByte, InputBuf.Length);
                RXCurrentByte += InputBuf.Length;
                lastReceivedTime = DateTime.UtcNow;
                //Debug.Print(DateTime.UtcNow.Ticks.ToString() + " Read Length: " + Buffer.Length.ToString() + " " + RXCurrentByte.ToString());
                if (ModbusSupport.IsModbusFrameVaild(RXBuffer, RXCurrentByte) == true) {
                    AwaitingPreviousCommand = false;
                    byte[] BlockBuffer = new byte[RXCurrentByte];
                    Array.Copy(RXBuffer, 0, BlockBuffer, 0, BlockBuffer.Length);
                    lastReceivedTime = DateTime.UtcNow;
                    RXCurrentByte = 0;
                    Thread TrMbRTURx = new Thread(() => RTUStringProcessor(BlockBuffer));
                    TrMbRTURx.Name = "TrMbRTURx";
                    TrMbRTURx.IsBackground = true;
                    TrMbRTURx.Start();
                }
                DateTime Now = DateTime.UtcNow;
                if ((Now.Ticks - lastReceivedTime.Ticks) >= SilenceLength) {// + 10000000
                    RXCurrentByte = 0;
                    Debug.Print("Timeout " + ConversionHandler.DateIntervalDifference(Now, lastReceivedTime, ConversionHandler.Interval.Millisecond).ToString());
                    AwaitingPreviousCommand = false;
                }
                if (RXCurrentByte > 512) {
                    RXCurrentByte = 0;
                }
                lastReceivedTime = DateTime.UtcNow;
            }
            catch { }
            lastReceivedTime = DateTime.UtcNow;
        }

        private void TestPrint(byte[] InBuffer) {
            string StringBuffer = Support.SerialSupport.PrintStream(InBuffer);
            DataReceived?.Invoke(this, true, StringBuffer);
        }
        private void RTUStringProcessor(byte[] InBuffer) {
            string StringBuffer = Support.SerialSupport.PrintStream(InBuffer);
          
            if (outputModbusFrameToTerminal) {
                DataReceived?.Invoke(this, true, StringBuffer);
                SystemManager.InvokeChannelDataReceived(this, InBuffer, InBuffer.Length, StringBuffer, true);
            }
            ProgramManager.ProgramDataReceived(this.ID, StringBuffer);
            ModbusSupport.FunctionCode Func = (ModbusSupport.FunctionCode)InBuffer[1];
            ModbusProcessCommand(ref InBuffer, Func, InBuffer[0]);
        }
        ModbusASCIIState ASCIIState = ModbusASCIIState.Ready;
        private void ModbusASCIIProcessor(byte[] InBuffer) {
            try {
                bytesReceived += (ulong)InBuffer.Length;
                for (int i = 0; i < InBuffer.Length; i++) {
                    switch (ASCIIState) {
                        case ModbusASCIIState.Ready:
                            RXCurrentByte = 0;
                            if (InBuffer[i] == ':') {
                                ASCIIState = ModbusASCIIState.Armmed;
                            }
                            break;
                        case ModbusASCIIState.Armmed:
                            if (InBuffer[i] == '\r') {
                                ASCIIState = ModbusASCIIState.Closing;
                            }
                            else if (InBuffer[i] == '\n') {
                                //Invalid!
                                ASCIIState = ModbusASCIIState.Ready;
                                RXCurrentByte = 0;
                            }
                            else {
                                RXBuffer[RXCurrentByte] = InBuffer[i];
                                RXCurrentByte++;
                            }
                            break;
                        case ModbusASCIIState.Closing:
                            if (InBuffer[i] == '\n') {
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
        SDI12State SDIState = SDI12State.Ready;
        private void SDI12Processor(object sender) {
            try {
                int j = 0;
                int BytesToRead = ((SerialPort)sender).BytesToRead;
                byte[] Buffer = new byte[BytesToRead];
                bytesReceived += (ulong)BytesToRead;
                j = ((SerialPort)sender).Read(Buffer, 0, BytesToRead);
                for (int i = 0; i < BytesToRead; i++) {
                    switch (SDIState) {
                        case SDI12State.Ready:
                            RXBuffer[RXCurrentByte] = Buffer[i];
                            RXCurrentByte++;
                            break;
                        case SDI12State.Armmed:
                            if (Buffer[i] == '\r') {
                                SDIState = SDI12State.Closing;
                            }
                            else if (Buffer[i] == '\n') {
                                //Invalid!
                                SDIState = SDI12State.Ready;
                                RXCurrentByte = 0;
                            }
                            else {
                                RXBuffer[RXCurrentByte] = Buffer[i];
                                RXCurrentByte++;
                            }
                            break;
                        case SDI12State.Closing:
                            if (Buffer[i] == '\n') {
                                SDI12CommandProcessor();
                                //ClearRXBuffer();
                            }
                            RXCurrentByte = 0;
                            SDIState = SDI12State.Ready;
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
        private void SDI12CommandProcessor() {

        }
        private void ModbusASCIICommandProcessor() {
            if (RXCurrentByte < 4) { return; }
            int DataPacketSize = RXCurrentByte - 2;
            byte[] Buffer = new byte[DataPacketSize];

            Array.Copy(RXBuffer, 0, Buffer, 0, DataPacketSize);
            byte LRC_Calculated = ModbusSupport.CalculateLRC(Buffer, (ushort)DataPacketSize, 0);
            byte LRC_Recieved = ModbusSupport.GetArrayValue(DataPacketSize, ref RXBuffer);
            if (LRC_Calculated != LRC_Recieved) { return; }
            string StringBuffer = Support.SerialSupport.PrintStream(Buffer);
            DataReceived?.Invoke(this, true, StringBuffer);
            SystemManager.InvokeChannelDataReceived(this, Buffer, DataPacketSize, StringBuffer, true);
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
                        ModbusMasterExceptionReturn(Buffer, RXCurrentByte); break;
                        //ModbusPostException(Buffer[0], (Modbus.FunctionCode)Buffer[1], ModbusException.IllegalFunction);

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
                            ModbusPostException(Address, Function, ModbusSupport.ModbusException.IllegalFunction);
                            break;
                    }
                }
            }
        }
        #endregion
        #region Modbus
        // private Modbus.FunctionCode LastSentCode = Modbus.FunctionCode.NoCommand;
        private ushort LastRequestedAddress = 0;
        private void ModbusPostException(int Address, ModbusSupport.FunctionCode Function, ModbusSupport.ModbusException Code) {
            //Adr Fun Cde
            byte[] Temp = ModbusSupport.BulidExceptionPacket(outputFormat, Address, Function, Code);
            //
            //byte[] Temp = new byte[3];
            //Temp[0] = (byte)Address;//Adr
            //Temp[1] = (byte)((byte)Function + (byte)0x80);//Fun
            //Temp[2] = (byte)Code;//Len
            if (outputFormat == StreamOutputFormat.ModbusRTU) {
                byte[] Output = new byte[5];
                Array.Copy(Temp, 0, Output, 0, 3);
                ushort CRC = ModbusSupport.CalculateCRC(Temp, (ushort)(3), 0);

                Output[4] = (byte)(CRC & 0xFF);
                Output[5] = (byte)(CRC >> 8);
                Port.Write(Output, 0, 5);
                bytesSent += (ulong)5;
                string strPayload = Support.SerialSupport.PrintStream(Output);
                DataReceived?.Invoke(this, true, strPayload);
                SystemManager.InvokeChannelDataReceived(this, Output, Output.Length, strPayload, true);
            }
            else if (outputFormat == StreamOutputFormat.ModbusASCII) {
                TransmitASCIIFrame(Temp);
            }
        }
        private void ModbusSlaveReadCoils(byte[] Input, int Length, bool IsDiscrete = true) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            try {
                if (InputFormat == StreamInputFormat.ModbusRTU) {
                    int Slave = Input[0];
                    int Func = Input[1];
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    short CoilCount = (short)((Input[4] << 8) | Input[5]);
                    if ((CoilCount < 0x01) || (CoilCount > 0x07D0)) {
                        ModbusPostException(Slave, (ModbusSupport.FunctionCode)Func, ModbusSupport.ModbusException.IllegalDataValue);
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
                        ModbusPostException(Slave, (ModbusSupport.FunctionCode)Func, ModbusSupport.ModbusException.IllegalDataValue);
                        return;
                    }
                    byte[] Temp = ModbusSupport.BulidReadCoils(this, true, IsDiscrete, (ModbusSupport.FunctionCode)Func, Slave, (short)StartAddress, CoilCount);
                    TransmitFrame(Temp);
                }
            }
            catch { }
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
        private void ModbusMasterExceptionReturn(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int Device = Input[0];
                int FunctionCode = Input[1] & 0x7F;
                int ExceptionCode = Input[2];
                try {
                    ModbusSupport.ModbusException Exception = (ModbusSupport.ModbusException)ExceptionCode;
                    ModbusSupport.FunctionCode Function = (ModbusSupport.FunctionCode)FunctionCode;
                    PostException(Device, Function, Exception);
                    SystemManager.ModbusExceptionReturn(this, Device, Function, Exception);
                }
                catch { }
            }
            else if (inputFormat == StreamInputFormat.ModbusASCII) {
                int Device = ModbusSupport.GetArrayValue(0, ref Input);
                int FunctionCode = ModbusSupport.GetArrayValue(2, ref Input) & 0x7F;
                int ExceptionCode = ModbusSupport.GetArrayValue(4, ref Input);
                try {
                    ModbusSupport.ModbusException Exception = (ModbusSupport.ModbusException)ExceptionCode;
                    ModbusSupport.FunctionCode Function = (ModbusSupport.FunctionCode)FunctionCode;
                    PostException(Device, Function, Exception);
                    SystemManager.ModbusExceptionReturn(this, Device, Function, Exception);
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
            try {
                if (inputFormat == StreamInputFormat.ModbusRTU) {
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    int Val = (int)((Input[4] << 8) | Input[5]);
                    //coils[StartAddress].Value = Val == 0xFF00 ? true : false;
                    ModbusSupport.SetRegister(this, DataSelection.ModbusDataCoils, StartAddress, Val == 0xFF00 ? true : false);
                    byte[] Temp = ModbusSupport.BulidWriteSinglePacket(outputFormat, (ModbusSupport.FunctionCode)Input[1], Input[0], (short)StartAddress, Input[4], Input[5]);
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
            catch { }
        }
        private void ModbusSlaveWriteCoils(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            try {
                if (inputFormat == StreamInputFormat.ModbusRTU) {
                    int Slave = Input[0];
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    int Count = (int)((Input[4] << 8) | Input[5]);
                    if (Count > 0x007B) {
                        ModbusPostException(Input[0], (ModbusSupport.FunctionCode)Input[1], ModbusSupport.ModbusException.IllegalDataValue);
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
                            if (CoilCount == Count) { break; }
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
                        ModbusPostException(Slave, (ModbusSupport.FunctionCode)Func, ModbusSupport.ModbusException.IllegalDataValue);
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
                            if (CoilCount == Count) { break; }
                        }
                    }
                    byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, (ModbusSupport.FunctionCode)Func, Slave, (short)StartAddress, (short)Count);
                    TransmitFrame(Temp);
                }
            }
            catch { }
        }
        private void ModbusSlaveReadRegisters(byte[] Input, int Length, bool IsHolding = true) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            try {
                if (inputFormat == StreamInputFormat.ModbusRTU) {
                    int Slave = Input[0];
                    int Func = Input[1];
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    short RegisterCount = (short)((Input[4] << 8) | Input[5]);
                    if ((RegisterCount < 0x01) || (RegisterCount > 0x7D)) {
                        ModbusPostException(Slave, (ModbusSupport.FunctionCode)Func, ModbusSupport.ModbusException.IllegalDataValue);
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
                        ModbusPostException(Slave, (ModbusSupport.FunctionCode)Func, ModbusSupport.ModbusException.IllegalDataValue);
                        return;
                    }
                    byte[] Temp = ModbusSupport.BulidReadRegisters(this, true, IsHolding, (ModbusSupport.FunctionCode)Func, Slave, (short)StartAddress, RegisterCount);
                    //DataReceived?.Invoke(this, true, PrintStream(Output));
                    TransmitFrame(Temp);

                }
            }
            catch { }
        }
        private void ModbusSlaveWriteRegister(byte[] Input, int Length) {
            //ADR FUN ST1 STR2 LN1 LN2
            if (Port == null) { return; }
            if (!Port.IsOpen) { return; }
            try {
                if (inputFormat == StreamInputFormat.ModbusRTU) {
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    int Val = (int)((Input[4] << 8) | Input[5]);
                    ModbusSupport.SetRegister(this, DataSelection.ModbusDataHoldingRegisters, StartAddress, (short)Val);
                    //holdingRegisters[StartAddress].Value = (short)Val;
                    byte[] Temp = ModbusSupport.BulidWriteSinglePacket(outputFormat, (ModbusSupport.FunctionCode)Input[1], Input[0], (short)StartAddress, Input[4], Input[5]);
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
            catch { }
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
            try {
                if (inputFormat == StreamInputFormat.ModbusRTU) {
                    int Slave = Input[0];
                    int StartAddress = (int)((Input[2] << 8) | Input[3]);
                    int Count = (int)((Input[4] << 8) | Input[5]);
                    if (Count > 0x007B) {
                        ModbusPostException(Input[0], (ModbusSupport.FunctionCode)Input[1], ModbusSupport.ModbusException.IllegalDataValue);
                        return;
                    }
                    int Bytes = Input[6];
                    int j = 0;
                    for (int i = 0; i < Count; i++) {
                        int Val = (int)((Input[7 + j] << 8) | Input[8 + j]);
                        j += 2;
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
                        ModbusPostException(Slave, (ModbusSupport.FunctionCode)Func, ModbusSupport.ModbusException.IllegalDataValue);
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
            catch { }
        }
        private void ModbusMasterReadCoils(byte[] Input, int Length, bool IsDiscrete = true) {
            DataSelection DataSelect = DataSelection.ModbusDataCoils;
            if (IsDiscrete == true) { DataSelect = DataSelection.ModbusDataDiscreteInputs; }
            if (inputFormat == StreamInputFormat.ModbusRTU) {
                int Device = Input[0];
                int Bytes = Input[2];
                int k = 0;
                for (int i = 0; i < Bytes; i++) {
                    for (int j = 0; j < 8; j++) {
                        int Temp = Input[3 + i];
                        bool TempBool = ((Temp >> j) & 0x01) == 0x01 ? true : false;
                        ModbusSupport.SetRegister(this, DataSelect, Device, LastRequestedAddress + k, TempBool);
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
                        ModbusSupport.SetRegister(this, DataSelect, Device, LastRequestedAddress + i, TempBool);
                        k++;
                    }
                }
            }
        }
        private void ModbusMasterReadRegisters(byte[] Input, int Length, bool IsHolding = true) {
            DataSelection DataSelect = DataSelection.ModbusDataInputRegisters;
            if (IsHolding == true) { DataSelect = DataSelection.ModbusDataHoldingRegisters; }
            try {
                if (inputFormat == StreamInputFormat.ModbusRTU) {
                    int Device = Input[0];
                    int Count = Input[2] / 2;
                    int k = 0;
                    for (int i = 0; i < Count; i++) {
                        short Temp = (short)(((int)Input[3 + k] << 8) | (int)Input[4 + k]);
                        ModbusSupport.SetRegister(this, DataSelect, Device, LastRequestedAddress + i, Temp);
                        k += 2;
                    }
                }
                else if (inputFormat == StreamInputFormat.ModbusASCII) {
                    int Device = ModbusSupport.GetArrayValue(0, ref Input);
                    int Count = ModbusSupport.GetArrayValue(4, ref Input) / 2;
                    int k = 0;
                    for (int i = 0; i < Count; i++) {
                        short Temp = (short)ModbusSupport.GetArrayValueRead4(6 + k, ref Input);
                        ModbusSupport.SetRegister(this, DataSelect, Device, LastRequestedAddress + i, Temp);
                        k += 4;
                    }
                }
            }
            catch { }
        }

        #endregion
        #region Modbus Functions
        private bool SetSlaveAsBusy(int Device) {
            if (!isMaster) { return false; }
            foreach(ModbusSlave slave in Slave) {
                if (slave.Address == Device) {
                    slave.MarkBusy();
                    return true; 
                }
            }
            return false;
        }
        private bool SetSlaveAsFree(int Device) {
            if (!isMaster) { return false; }
            foreach (ModbusSlave slave in Slave) {
                if (slave.Address == Device) {
                    slave.MarkFree();
                    return true;
                }
            }
            return false;
        }
        List<ModbusRequest> AwaitingResults = new List<ModbusRequest>();
        public void ModbusReadDeviceIdentification(int Device, ModbusSupport.DiagnosticDeviceIdentification ReadSection, short ObjectId) {
            if ((Device < MODBUS_MIN_DEVICE_ADDRESS) || (Device > MODBUS_MAX_DEVICE_ADDRESS)) { return; }
            if (!Support.SerialSupport.IsModbusFormat(outputFormat)) { return; }
            if ((ObjectId < 0) || (ObjectId > 255)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidReadDeviceIdPacket(outputFormat, Device, ReadSection, ObjectId);
            //LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusDiagnostics(int Device, ModbusSupport.DiagnosticSubFunction SubFunction, short Request) {
            if ((Device < MODBUS_MIN_DEVICE_ADDRESS) || (Device > MODBUS_MAX_DEVICE_ADDRESS)) { return; }
            if (!Support.SerialSupport.IsModbusFormat(outputFormat)) { return; }
            byte[] Temp = ModbusSupport.BulidDiagnosticsPacket(outputFormat, Device, SubFunction, Request);
            //LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusWriteMaskRegister(int Device, short Address, short AndMask, short OrMask) {
            if ((Device < MODBUS_MIN_DEVICE_ADDRESS) || (Device > MODBUS_MAX_DEVICE_ADDRESS)) { return; }
            if (!Support.SerialSupport.IsModbusFormat(outputFormat)) { return; }
            byte[] Temp = ModbusSupport.BulidMaskWritePacket(outputFormat, Device, Address, AndMask, OrMask);
            //LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusReadCoils(int Device, short Address, short Count) {
            if ((Device < MODBUS_MIN_DEVICE_ADDRESS) || (Device > MODBUS_MAX_DEVICE_ADDRESS)) { return; }
            if (!Support.SerialSupport.IsModbusFormat(outputFormat)) { return; }
            if ((Device < 1) || (Count > 0x07D0)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, ModbusSupport.FunctionCode.ReadCoils, Device, Address, Count);
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusReadDiscreteInputs(int Device, short Address, short Count) {
            if ((Device < MODBUS_MIN_DEVICE_ADDRESS) || (Device > MODBUS_MAX_DEVICE_ADDRESS)) { return; }
            if (!Support.SerialSupport.IsModbusFormat(outputFormat)) { return; }
            if ((Device < 1) || (Count > 0x07D0)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, ModbusSupport.FunctionCode.ReadDiscreteInputs, Device, Address, Count);
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusReadInputRegisters(int Device, short Address, short Count) {
            if ((Device < MODBUS_MIN_DEVICE_ADDRESS) || (Device > MODBUS_MAX_DEVICE_ADDRESS)) { return; }
            if (!Support.SerialSupport.IsModbusFormat(outputFormat)) { return; }
            if ((Device < 1) || (Count > 0x7D)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, ModbusSupport.FunctionCode.ReadInputRegisters, Device, Address, Count);
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusReadHoldingRegisters(int Device, short Address, short Count) {
            if ((Device < MODBUS_MIN_DEVICE_ADDRESS) || (Device > MODBUS_MAX_DEVICE_ADDRESS)) { return; }
            if (!Support.SerialSupport.IsModbusFormat(outputFormat)) { return; }
            if ((Device < 1) || (Count > 0x7D)) {
                return;
            }
            byte[] Temp = ModbusSupport.BulidReadPacket(outputFormat, ModbusSupport.FunctionCode.ReadHoldingRegisters, Device, Address, Count);
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusWriteCoil(int Device, short Address, bool Value) {
            if ((Device < MODBUS_MIN_DEVICE_ADDRESS) || (Device > MODBUS_MAX_DEVICE_ADDRESS)) { return; }
            if (!Support.SerialSupport.IsModbusFormat(outputFormat)) { return; }
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
            if ((Device < MODBUS_MIN_DEVICE_ADDRESS) || (Device > MODBUS_MAX_DEVICE_ADDRESS)) { return; }
            if (!Support.SerialSupport.IsModbusFormat(outputFormat)) { return; }
            byte Value0 = (byte)(Value >> 8);
            byte Value1 = (byte)(Value & 0xFF);
            byte[] Temp = ModbusSupport.BulidWriteSinglePacket(outputFormat, ModbusSupport.FunctionCode.WriteSingleHoldingRegister, Device, Address, Value0, Value1);
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusWriteMultipleCoils(int Device, short Address, List<bool> Values) {
            if ((Device < MODBUS_MIN_DEVICE_ADDRESS) || (Device > MODBUS_MAX_DEVICE_ADDRESS)) { return; }
            if (!Support.SerialSupport.IsModbusFormat(outputFormat)) { return; }
            byte[] Temp = ModbusSupport.BulidWriteMultiplePacket(outputFormat, ModbusSupport.FunctionCode.WriteMultipleCoils, Device, Address, Values);
            //AwaitingResults.Add(new ModbusReturnResult(ModbusSupport.FunctionCode.WriteMultipleCoils, Device, Address, Values));
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusWriteMultipleRegisters(int Device, short Address, List<short> Values) {
            if ((Device < MODBUS_MIN_DEVICE_ADDRESS) || (Device > MODBUS_MAX_DEVICE_ADDRESS)) { return; }
            if (AwaitingPreviousCommand == true) { return; }
            if (!Support.SerialSupport.IsModbusFormat(outputFormat)) { return; }
            byte[] Temp = ModbusSupport.BulidWriteMultiplePacket(outputFormat, ModbusSupport.FunctionCode.WriteMultipleHoldingRegisters, Device, Address, Values);
            //AwaitingResults.Add(new ModbusReturnResult(ModbusSupport.FunctionCode.WriteMultipleCoils, Device, Address, Values));
            LastRequestedAddress = (ushort)Address;
            TransmitFrame(Temp);
        }
        public void ModbusSendGenericFunction(int Device, int Function, List<short> Values) {
            if ((Device < MODBUS_MIN_DEVICE_ADDRESS) || (Device > MODBUS_MAX_DEVICE_ADDRESS)) { return; }
            if ((Function < 0) || (Function > 0xFF)) { return; }
            if (AwaitingPreviousCommand == true) { return; }
            if (!Support.SerialSupport.IsModbusFormat(outputFormat)) { return; }
            byte[] Temp = ModbusSupport.BulidCustomFunctionPacket(outputFormat, Function, Device, Values);
            TransmitFrame(Temp);
        }
        public void NewSlave(int Unit) {
            int UnitIndex = ModbusSupport.UnitToIndex(this, Unit);
            if (UnitIndex == -1) {
                Slave.Add(new ModbusSlave(this, Unit));
                SystemManager.InvokeSlaveAdded(this);
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
                        if (ModbusTransmitBuffer.Count > 0) {
                            try {
                                ModbusTransmitBuffer.RemoveAt(0);
                            }
                            catch { }
                        }
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
        private byte[] TransmitRTUFrame(byte[] Data) {
            byte[] Output = new byte[Data.Length + 2];
            ushort CRC = ModbusSupport.CalculateCRC(Data, (ushort)Data.Length, 0);
            Array.Copy(Data, 0, Output, 0, Data.Length);
            Output[Output.Length - 2] = (byte)(CRC & 0xFF);
            Output[Output.Length - 1] = (byte)(CRC >> 8);
            lastTransmittedTime = DateTime.UtcNow;
            Port.Write(Output, 0, Output.Length);
            lastTransmittedTime = DateTime.UtcNow;
            bytesSent += (ulong)Output.Length;
            if (outputModbusFrameToTerminal) {
                string strPayload = Support.SerialSupport.PrintStream(Output);
                DataReceived?.Invoke(this, true, strPayload);
                SystemManager.InvokeChannelDataReceived(this, Output, Output.Length, strPayload, true);
            }
            return Output;
        }
        private byte[] TransmitASCIIFrame(byte[] Data) {
            byte[] Output = new byte[Data.Length + 5];
            byte LRC = ModbusSupport.CalculateLRC(Data, (ushort)Data.Length, 0);
            Array.Copy(Data, 0, Output, 1, Data.Length);
            Output[0] = (byte)':';
            ModbusSupport.SetArrayValue(Output.Length - 4, LRC, ref Output);
            Output[Output.Length - 2] = (byte)'\r';
            Output[Output.Length - 1] = (byte)'\n';
            lastTransmittedTime = DateTime.UtcNow;
            if (outputModbusFrameToTerminal) {
                string strPayload = Support.SerialSupport.PrintStream(Output);
                DataReceived?.Invoke(this, true, strPayload);
                SystemManager.InvokeChannelDataReceived(this, Output, Output.Length, strPayload, true);
            }
            Port.Write(Output, 0, Output.Length);
            lastTransmittedTime = DateTime.UtcNow;
            bytesSent += (ulong)Output.Length;
            return Output;
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

        private void PostException(int Slave, Modbus.ModbusSupport.FunctionCode Function, Modbus.ModbusSupport.ModbusException Exception) {
            Thread Tr = new Thread(() => PostExceptionThread(Slave, Function, Exception));
            Tr.Name = "Mb_Except_Proc";
            Tr.IsBackground = true;
            Tr.Start();
        }
        private void PostExceptionThread(int Unit, Modbus.ModbusSupport.FunctionCode Function, Modbus.ModbusSupport.ModbusException Exception) {
            try {
                foreach (ModbusSlave Slv in Slave) {
                    if (Slv.Address == Unit) {
                        Slv.RaiseException(Function, Exception);
                        break;
                    }
                }
            }
            catch { }
        }
        #endregion
        #region Data Formatting
        public bool Transmit(byte Data) {
            try {
                if (Port.IsOpen == true) {
                    byte[] data = { Data };
                    Port.Write(data, 0, data.Length);
                }
                bytesSent += (ulong)1;
                return true;
            }
            catch { return false; }
        }
        public bool Transmit(byte[] Data) {
            try {
                if (Port.IsOpen == true) {
                    Port.Write(Data, 0, Data.Length);
                }
                bytesSent += (ulong)Data.Length;
                return true;
            }
            catch { return false; }
        }
        public bool Transmit(byte[] Data, int Start, int Length) {
            try {
                if (Port.IsOpen == true) {
                    Port.Write(Data, Start, Length);
                }
                bytesSent += (ulong)Length;
                return true;
            }
            catch { return false; }
        }
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
        private void TransmitBase64(string Data) {
            byte[] TextBytes = System.Text.Encoding.UTF8.GetBytes(Data);
            string Temp = System.Convert.ToBase64String(TextBytes);
            if (Port.IsOpen) {
                Port.Write(Temp);
                bytesSent += (ulong)Temp.Length;
            }
        }
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
        #region Port Scanner
        private bool Scan_InProgress = false;
        [Browsable(false)]
        public bool ScanInProgress {
            get { return Scan_InProgress; }
        }
        [Browsable(false)]
        public bool ScanCompleted {
            get { return Scan_Completed; }
        }
        List<Port>? ScanPorts = null;
        System.Windows.Forms.Timer Tmr_Scanner = new System.Windows.Forms.Timer();
        int ScanPortIndx = 0;
        DateTime LastScan = DateTime.MinValue;
        ScanState Scan_Progress = ScanState.Open;
        uint Scan_Timeout = 1000;
        uint Scan_RetryCount = 0;
        uint Scan_RequestedRetryCount = 5;
        string Scan_String = "";
        string Scan_OldPort = "";
        ulong Scan_BytesCountStart = 0;
        bool Scan_HasTransmitted = false;
        bool Scan_IgnorePortFailures = false;
        bool Scan_Handl_Assigned = false;
        bool Scan_Completed = false;
        public void ScanAndSetPort(string ScanWith, uint RetryCount = 3, uint TimeOut = 1000, bool IgnorePortFailures = true) {
            if (Scan_InProgress) { return; }
            Scan_String = ScanWith;
            Scan_RequestedRetryCount = RetryCount;
            Scan_Timeout = TimeOut;
            Scan_IgnorePortFailures = IgnorePortFailures;
            ScanAndSetPort();
        }
        public void StopScan() {
            EndScan(true);
        }
        public void ScanAndSetPort() {
            Scan_Completed = false;
            Tmr_Scanner.Enabled = false;
            Scan_OldPort = PortName;
            ScanPortIndx = 0;
            Scan_RetryCount = 0;
            Scan_Progress = ScanState.Initialise;
            Scan_HasTransmitted = false;
            if (Scan_Handl_Assigned) {
                Tmr_Scanner.Tick -= Tmr_Scanner_Tick;
                Scan_Handl_Assigned = false;
            }
            ScanPorts = SystemManager.GetSerialPortLegacyListing().OrderBy(x => x.PortName.Length).ThenBy(x => x.PortName).ToList();
            Tmr_Scanner.Interval = 10;
            Tmr_Scanner.Tick += Tmr_Scanner_Tick;
            Scan_Handl_Assigned = true;
            Tmr_Scanner.Enabled = true;
        }
        private void Tmr_Scanner_Tick(object? sender, EventArgs e) {
            if (ScanPorts == null) { EndScan(); return; }
            if (ScanPortIndx < ScanPorts.Count) {
                string SelectPort = ScanPorts[ScanPortIndx].PortName;
                //Debug.Print(SelectPort);
                switch (Scan_Progress) {
                    case ScanState.Initialise:
                        //Debug.Print("Init");
                        Disconnect();
                        Scan_Progress = ScanState.Open;
                        Scan_RetryCount = 0;
                        return;
                    case ScanState.Open:
                        //Debug.Print("Open");
                        PortName = SelectPort;
                        Scan_BytesCountStart = bytesReceived;
                        Connect();
                        Scan_BytesCountStart = bytesReceived;
                        Scan_Progress = ScanState.Await;

                        return;
                    case ScanState.Await:

                        if ((bytesReceived - Scan_BytesCountStart) > 0) {
                            if (Scan_HasTransmitted) {
                                //Debug.Print("Recv");
                                Scan_Progress = ScanState.Close; return;
                            }
                        }
                        if (ConversionHandler.DateIntervalDifference(LastScan, DateTime.UtcNow, ConversionHandler.Interval.Millisecond) < Scan_Timeout) {
                            return;
                        }
                        if (Scan_RequestedRetryCount == 0) { EndScan(); return; }
                        if (Connected == false) {
                            //Debug.Print("Await: NC");
                            if (Scan_IgnorePortFailures) {
                                Scan_Progress = ScanState.MoveToNext; return;
                            }
                            else {
                                if (Scan_RetryCount < Scan_RequestedRetryCount) {
                                    Scan_Progress = ScanState.Open;
                                    Scan_RetryCount++;
                                }
                                else { Scan_Progress = ScanState.MoveToNext; return; }
                            }
                        }
                        else {
                            //Debug.Print("Await: C");
                            if (Scan_RetryCount < Scan_RequestedRetryCount) {
                                Post(Scan_String); Scan_HasTransmitted = true;
                                Scan_RetryCount++;
                            }
                            else { Scan_Progress = ScanState.MoveToNext; return; }
                        }
                        LastScan = DateTime.UtcNow;
                        break;
                    case ScanState.Close:
                        //Debug.Print("Close");
                        EndScan(false); break;
                    case ScanState.MoveToNext:
                        //Debug.Print("Next");
                        Scan_HasTransmitted = false;
                        Disconnect();
                        Scan_RetryCount = 0;
                        ScanPortIndx++;
                        Scan_Progress = ScanState.Open;
                        break;
                    default: break;
                }

            }
            else {
                EndScan();
            }
        }
        private void EndScan(bool Restore = true) {
            Tmr_Scanner.Enabled = false;
            ScanPortIndx = 0;
            Scan_RetryCount = 0;
            ScanPorts = null;
            Scan_InProgress = false;
            Tmr_Scanner.Tick -= Tmr_Scanner_Tick;
            Scan_Handl_Assigned = false;
            Disconnect();
            if (Restore) {
                SystemManager.InvokeChannelScanComplete(this, Scan_OldPort, PortName, false);
                PortName = Scan_OldPort;
            }
            else {
                SystemManager.InvokeChannelScanComplete(this, Scan_OldPort, PortName, true);
            }
            Scan_Completed = true;
        }
        #endregion
        private enum ScanState {
            Initialise = 0x00,
            Open = 0x01,
            Await = 0x02,
            Close = 0x03,
            MoveToNext = 0x04
        }
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
        private enum SDI12State {
            Ready = 0x00,
            Armmed = 0x01,
            Closing = 0x02
        }

    }
    public enum DataSelection {
        ModbusDataCoils = 0x00,
        ModbusDataDiscreteInputs = 0x01,
        ModbusDataInputRegisters = 0x02,
        ModbusDataHoldingRegisters = 0x03
    }
}
