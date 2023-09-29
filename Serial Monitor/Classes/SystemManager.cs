using Handlers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.SerialManager;

namespace Serial_Monitor.Classes {
    public static class SystemManager {
        public static List<int> DefaultBauds = new List<int>();
        public static List<SerialManager> SerialManagers = new List<SerialManager>();

        public static event ChannelAddedHandler? ChannelAdded;
        public delegate void ChannelAddedHandler(int RemovedIndex);
        public static event ChannelRemovedHandler? ChannelRemoved;
        public delegate void ChannelRemovedHandler(int RemovedIndex);
        public static event ChannelRenamedHandler? ChannelRenamed;
        public delegate void ChannelRenamedHandler(SerialManager sender);

        public static event ChannelPropertyChangedHandler? ChannelPropertyChanged;
        public delegate void ChannelPropertyChangedHandler(SerialManager sender);

        public static event PortStatusChangedHandler? PortStatusChanged;
        public delegate void PortStatusChangedHandler(SerialManager sender);

        public static event ModbusPropertyChangedHandler? ModbusPropertyChanged;
        public delegate void ModbusPropertyChangedHandler(object Data, int Index, DataSelection DataType);
        public static event ModbusRegisterRenamedHandler? ModbusRegisterRenamed;
        public delegate void ModbusRegisterRenamedHandler(object Data, int Index, DataSelection DataType);
        public static event ModbusReceivedHandler? ModbusReceived;
        public delegate void ModbusReceivedHandler(object Data, int Index, DataSelection DataType);

        public static void InvokePortStatusChanged(SerialManager sender) {
            PortStatusChanged?.Invoke(sender);
        }
        public static void InvokeChannelRename(SerialManager sender) {
            ChannelRenamed?.Invoke(sender);
        }
        public static void InvokeChannelPropertiesChanged(SerialManager sender) {
            ChannelPropertyChanged?.Invoke(sender);
        }
        public static void ModbusRegisterPropertyChanged(object Data, int Index, DataSelection DataType) {
            ModbusPropertyChanged?.Invoke(Data, Index, DataType);
        }
        public static void RegisterNameChanged(object Data, int Index, DataSelection DataType) {
            ModbusRegisterRenamed?.Invoke(Data, Index, DataType);
        }
        public static void RegisterValueChanged(object Data, int Index, DataSelection DataType) {
            ModbusReceived?.Invoke(Data, Index, DataType);
        }
        public static void SendModbusCommand(SerialManager? CurrentManager, DataSelection DataSet, string Command) {
            if (CurrentManager == null) { return; }
            if (CurrentManager.IsMaster == false) { return; }
            if ((DataSet == DataSelection.ModbusDataCoils) || (DataSet == DataSelection.ModbusDataHoldingRegisters)) {
                CurrentManager.ModbusCommand(Command);
            }
        }
        public static void LoadDefaultBauds() {
            DefaultBauds.Add(50);
            DefaultBauds.Add(75);
            DefaultBauds.Add(110);
            DefaultBauds.Add(134);
            DefaultBauds.Add(150);
            DefaultBauds.Add(200);
            DefaultBauds.Add(300);
            DefaultBauds.Add(600);
            DefaultBauds.Add(1200);
            DefaultBauds.Add(1800);
            DefaultBauds.Add(2400);
            DefaultBauds.Add(4800);
            DefaultBauds.Add(9600);
            DefaultBauds.Add(19200);
            DefaultBauds.Add(28800);
            DefaultBauds.Add(38400);
            DefaultBauds.Add(57600);
            DefaultBauds.Add(76800);
            DefaultBauds.Add(115200);
            DefaultBauds.Add(230400);
            DefaultBauds.Add(460800);
            DefaultBauds.Add(576000);
            DefaultBauds.Add(921600);
        }
        public static void SendString(string Channel, string Data) {
            int SendOn = GetChannelIndex(Channel);
            SendAtIndex(SendOn, Data);
        }
        public static void SendTextFile(string Channel, string FilePath) {
            int SendOn = GetChannelIndex(Channel);
            if (File.Exists(FilePath)) {
                try {
                    using (StreamReader Sr = new StreamReader(FilePath)) {
                        if (Sr != null) {
                            while (Sr.Peek() > -1) {
                                string item = Sr.ReadLine() ?? "";
                                SendAtIndex(SendOn, item);
                            }
                        }
                    }
                }
                catch { }
            }
        }
        private static void SendAtIndex(int SendOn, string Data) {
            if (SendOn == -1) {
                foreach (SerialManager SerMan in SerialManagers) {
                    SerMan.Post(Data);
                }
            }
            else {
                try {
                    SerialManagers[SendOn].Post(Data);
                }
                catch { }
            }
        }
        private static int GetChannelIndex(string Channel) {
            if (Channel.ToLower() == "all") { return -1; }
            int i = 0;
            foreach (SerialManager SerMan in SerialManagers) {
                if (SerMan.Name == Channel) {
                    return i;
                }
                i++;
            }
            return -1;
        }

        #region Channel Handling
        public static void AddChannel(string ManagerName, CommandProcessedHandler SerManager_CommandProcessed, DataProcessedHandler SerMan_DataReceived) {
            SerialManager SerMan = new SerialManager();
            SystemManager.SerialManagers.Add(SerMan);
            SerMan.BaudRate = Properties.Settings.Default.DEF_INT_BaudRate;
            try {
                SerMan.Port.DataBits = Properties.Settings.Default.DEF_INT_DataBits;
            }
            catch {
                SerMan.Port.DataBits = 8;
            }
            SerMan.Port.Parity = EnumManager.StringToParity(Properties.Settings.Default.DEF_STR_ParityBit);
            SerMan.Port.StopBits = EnumManager.StringToStopBits(Properties.Settings.Default.DEF_STR_StopBits);
            SerMan.InputFormat = EnumManager.StringToInputFormat(Properties.Settings.Default.DEF_STR_InputFormat);
            SerMan.OutputFormat = EnumManager.StringToOutputFormat(Properties.Settings.Default.DEF_STR_OutputFormat);
            SerMan.Name = ManagerName;
            SerMan.CommandProcessed += SerManager_CommandProcessed;
            SerMan.DataReceived += SerMan_DataReceived;
            ChannelAdded?.Invoke(SerialManagers.Count - 1);
        }
        public static void RemoveChannel(int ChannelIndex, CommandProcessedHandler SerManager_CommandProcessed, DataProcessedHandler SerMan_DataReceived) {
            if (SerialManagers.Count > 1) {
                if ((ChannelIndex < SerialManagers.Count) && (ChannelIndex != -1)) {
                    SerialManagers[ChannelIndex].CommandProcessed -= SerManager_CommandProcessed;
                    SerialManagers[ChannelIndex].DataReceived -= SerMan_DataReceived;
                    ApplicationManager.CloseInternalApplication("TERM_" + SerialManagers[ChannelIndex].ID);
                    ApplicationManager.CloseInternalApplication("PROP_" + SerialManagers[ChannelIndex].ID);
                    Modbus.ModbusSupport.CloseSnapshot(SerialManagers[ChannelIndex]);

                    SerialManagers.RemoveAt(ChannelIndex);
                    ChannelRemoved?.Invoke(ChannelIndex);
                }
            }
        }
        public static void ClearChannels(CommandProcessedHandler SerManager_CommandProcessed, DataProcessedHandler SerMan_DataReceived) {
            Modbus.ModbusSupport.ClearSnapshots();
            for (int i = SerialManagers.Count - 1; i >= 0; i--) {
                SerialManagers[i].CleanUp();
                SerialManagers[i].CommandProcessed -= SerManager_CommandProcessed;
                SerialManagers[i].DataReceived -= SerMan_DataReceived;
                SerialManagers.RemoveAt(i);
            }
        }
        public static SerialManager? GetChannel(int ChannelIndex) {
            if (ChannelIndex < 0) { return null; }
            if (SerialManagers.Count > 0) {
                if ((ChannelIndex < SerialManagers.Count) && (ChannelIndex != -1)) {
                    return SerialManagers[ChannelIndex];
                }
            }
            return null;
        }
        public static int GetChannelIndex(SerialManager? Channel) {
            if (Channel == null) { return -1; }
            if (SerialManagers.Count > 0) {
                int Output = SerialManagers.IndexOf(Channel);
                return Output;
            }
            return -1;
        }
        #endregion
        #region Ports and Listing
        public static List<StringPair> GetSerialPortSettingBased() {
            List<StringPair> Results = new List<StringPair>();
            if (Properties.Settings.Default.CHAN_BOL_PreferLegacyPortListing) {
                Results = GetSerialPortLegacyListing();
            }
            else {
                Results = GetSerialPort();
            }
            return Results.OrderBy(x => x.A.Length).ThenBy(x => x.A).ToList();
        }
        private static List<StringPair> GetSerialPort() {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_SerialPort");
            List<StringPair> Results = new List<StringPair>();
            foreach (ManagementObject result in searcher.Get()) {
                StringPair Sp = new StringPair(result["DeviceID"].ToString() ?? "COM1", result["Name"].ToString() ?? "");
                Results.Add(Sp);
            }
            return Results;
        }
        private static List<StringPair> GetSerialPortLegacyListing() {
            List<StringPair> Results = new List<StringPair>();
            string[] TempPorts = SerialPort.GetPortNames();
            foreach (string Str in TempPorts) {
                Results.Add(new StringPair(Str, ""));
            }
            return Results;
        }
        #endregion
    }
}
