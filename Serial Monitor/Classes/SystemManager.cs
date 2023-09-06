using Handlers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.SerialManager;

namespace Serial_Monitor.Classes {
    public static class SystemManager {
        public static List<int> DefaultBauds = new List<int>();
        public static List<SerialManager> SerialManagers = new List<SerialManager>();

        public static event ChanneAddedHandler? ChannelAdded;
        public delegate void ChanneAddedHandler(int RemovedIndex);
        public static event ChannelRemovedHandler? ChannelRemoved;
        public delegate void ChannelRemovedHandler(int RemovedIndex);

        public static event ModbusReceivedHandler? ModbusReceived;
        public delegate void ModbusReceivedHandler(object Data, int Index, DataSelection DataType);
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

                    SerialManagers.RemoveAt(ChannelIndex);
                    ChannelRemoved?.Invoke(ChannelIndex);
                }
            }
        }
        public static void ClearChannels(CommandProcessedHandler SerManager_CommandProcessed, DataProcessedHandler SerMan_DataReceived) {
            for (int i = SerialManagers.Count - 1; i >= 0; i--) {
                SerialManagers[i].CleanUp();
                SerialManagers[i].CommandProcessed -= SerManager_CommandProcessed;
                SerialManagers[i].DataReceived -= SerMan_DataReceived;
                SerialManagers.RemoveAt(i);
            }
        }
        public static SerialManager ?GetChannel(int ChannelIndex) {
            if (SerialManagers.Count > 0) {
                if ((ChannelIndex < SerialManagers.Count) && (ChannelIndex != -1)) {
                    return SerialManagers[ChannelIndex];
                }
            }
            return null;
        }
        #endregion
    }
}
