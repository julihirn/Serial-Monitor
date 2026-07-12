using Handlers;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serial_Monitor.Plugin;
using static Serial_Monitor.Classes.SerialManager;
using System.Reflection;
using Serial_Monitor.Classes.Modbus;
using ODModules;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace Serial_Monitor.Classes {
    public static class SystemManager {
        public static MainWindow? MainInstance = null;

        public static List<int> DefaultBauds = new List<int>();
        public static List<SerialManager> SerialManagers = new List<SerialManager>();
        #region Channel Global Events
        public static event ChannelAddedHandler? ChannelAdded;
        public delegate void ChannelAddedHandler(int RemovedIndex);
        public static event ChannelRequestsHandlesHandler? ChannelRequestsHandles;
        public delegate void ChannelRequestsHandlesHandler(SerialManager SerMan);

        public static event ChannelRemovedHandler? ChannelRemoved;
        public delegate void ChannelRemovedHandler(int RemovedIndex);
        public static event ChannelRenamedHandler? ChannelRenamed;
        public delegate void ChannelRenamedHandler(SerialManager sender);

        public static event ChannelSlaveAddedHandler? SlaveAdded;
        public delegate void ChannelSlaveAddedHandler(SerialManager sender);

        public static event ChannelSlaveChangedHandler? SlaveChanged;
        public delegate void ChannelSlaveChangedHandler(SerialManager sender);

        public static event ChannelSelectionChangedHandler? ChannelSelectedChanged;
        public delegate void ChannelSelectionChangedHandler(SerialManager? sender);

        public static event ChannelPropertyChangedHandler? ChannelPropertyChanged;
        public delegate void ChannelPropertyChangedHandler(SerialManager sender);

        public static event ChannelScanCompleteHandler? ChannelScanComplete;
        public delegate void ChannelScanCompleteHandler(SerialManager? sender, string OldPort, string NewPort, bool PortFound);

        public static event ChannelDataReceivedHandler? ChannelDataReceived;
        public delegate void ChannelDataReceivedHandler(SerialManager? sender, DataPacket Payload, bool PrintLine);

        public static event PortStatusChangedHandler? PortStatusChanged;
        public delegate void PortStatusChangedHandler(SerialManager sender);

        public static event PortListingReturnedHandler? PortListingReturned;
        public delegate void PortListingReturnedHandler(List<Port> ports);
        #endregion
        #region System Global Events
        public static event PluginsLoadedHandler? PluginsLoaded;
        public delegate void PluginsLoadedHandler();

        public static event ErrorMessageHandler? ErrorInvoked;
        public delegate void ErrorMessageHandler(ErrorType Type, string Sender, string Message);
        #endregion 
        #region Modbus Global Events
        public static event ModbusPropertyChangedHandler? ModbusPropertyChanged;
        public delegate void ModbusPropertyChangedHandler(ModbusSlave sender, object Data, int Index, DataSelection DataType);
        public static event ModbusRegisterRenamedHandler? ModbusRegisterRenamed;
        public delegate void ModbusRegisterRenamedHandler(ModbusSlave sender, object Data, int Index, DataSelection DataType);
        public static event ModbusReceivedHandler? ModbusReceived;
        public delegate void ModbusReceivedHandler(ModbusSlave sender, object Data, int Index, DataSelection DataType);

        public static event ModbusAppearanceChangedHandler? ModbusAppearanceChanged;
        public delegate void ModbusAppearanceChangedHandler(ModbusSlave sender, List<int> Indices, DataSelection DataType);
        public static event ModbusAppearanceChangedHandler? ModbusPropertiesChanged;

        public static event ModbusExceptionRaisedHandler? ModbusExceptionRaised;
        public delegate void ModbusExceptionRaisedHandler(SerialManager sender, int Slave, ModbusSupport.FunctionCode Function, ModbusSupport.ModbusException Exception);

        public static event ModbusDiagnosticsReceivedHandler? ModbusDiagnosticsReceived;
        public delegate void ModbusDiagnosticsReceivedHandler(SerialManager sender, int Slave, ModbusSupport.DiagnosticSubFunction SubFunction, int Data);

        public static event ModbusEditorControlChanged? ModbusEditorChanged;
        public delegate void ModbusEditorControlChanged();
        #endregion
        #region Project Global Events
        public static event ProjectEditedHandler? ProjectEdited;
        public delegate void ProjectEditedHandler();
        #endregion 
        public static void InvokeProjectEdited() {
            ProjectEdited?.Invoke();
        }

        public static void InvokeSlaveAdded(SerialManager sender) {
            SlaveAdded?.Invoke(sender);
        }
        public static void InvokeSlaveChanged(SerialManager sender) {
            SlaveChanged?.Invoke(sender);
        }
        public static void InvokeErrorMessage(ErrorType Type, string Sender, string Message) {
            Print(Type, Sender, Message);
            ErrorInvoked?.Invoke(Type, Sender, Message);
        }
        public static void InvokePortStatusChanged(SerialManager sender) {
            PortStatusChanged?.Invoke(sender);
        }
        internal static void InvokeChannelDataReceived(SerialManager sender, byte[] bPayload, int Length, string sPayload, bool PrintLine) {
            ChannelDataReceived?.Invoke(sender, new DataPacket(bPayload, Length, sPayload), PrintLine);
        }
        internal static void InvokeChannelDataReceived(SerialManager sender, byte bPayload, string sPayload, bool PrintLine) {
            byte[] nByte = new byte[1]; nByte[0] = bPayload;
            ChannelDataReceived?.Invoke(sender, new DataPacket(nByte, 1, sPayload), PrintLine);
        }
        public static void InvokeChannelRename(SerialManager sender) {
            ChannelRenamed?.Invoke(sender);
        }
        public static void InvokeChannelPropertiesChanged(SerialManager sender) {
            ChannelPropertyChanged?.Invoke(sender);
        }
        public static void InvokeChannelSelectedChanged(SerialManager? sender) {
            ChannelSelectedChanged?.Invoke(sender);
        }
        internal static void InvokeChannelScanComplete(SerialManager? sender, string OldPort, string NewPort, bool PortFound) {
            if (sender == null) { return; }
            ChannelScanComplete?.Invoke(sender, OldPort, NewPort, PortFound);
        }
        public static void ModbusExceptionReturn(SerialManager? SerMan, int Slave, ModbusSupport.FunctionCode Function, ModbusSupport.ModbusException Exception) {
            if (SerMan == null) { return; }
            ModbusExceptionRaised?.Invoke(SerMan, Slave, Function, Exception);
        }
        public static void ModbusDiagnosticsReturn(SerialManager? SerMan, int Slave, ModbusSupport.DiagnosticSubFunction SubFunction, int Data) {
            if (SerMan == null) { return; }
            ModbusDiagnosticsReceived?.Invoke(SerMan, Slave, SubFunction, Data);
        }
        public static void ModbusRegisterAppearanceChanged(ModbusSlave? Sender, List<int> Indices, DataSelection? DataType) {
            if (Sender == null) { return; }
            if (Sender.Channel == null) { return; }
            if (DataType == null) { return; }
            ModbusAppearanceChanged?.Invoke(Sender, Indices, (DataSelection)DataType);
        }
        public static void ModbusRegisterPropertiesChanged(ModbusSlave? Sender, List<int> Indices, DataSelection? DataType) {
            if (Sender == null) { return; }
            if (Sender.Channel == null) { return; }
            if (DataType == null) { return; }
            ModbusPropertiesChanged?.Invoke(Sender, Indices, (DataSelection)DataType);
        }
        public static void ModbusRegisterPropertyChanged(ModbusSlave? Sender, object Data, int Index, DataSelection DataType) {
            if (Sender == null) { return; }
            if (Sender.Channel == null) { return; }
            ModbusPropertyChanged?.Invoke(Sender, Data, Index, DataType);
        }
        public static void RegisterNameChanged(ModbusSlave? Sender, object Data, int Index, DataSelection DataType) {
            if (Sender == null) { return; }
            if (Sender.Channel == null) { return; }
            ModbusRegisterRenamed?.Invoke(Sender, Data, Index, DataType);
        }
        public static void RegisterValueChanged(ModbusSlave? Sender, object Data, int Index, DataSelection DataType) {
            if (Sender == null) { return; }
            if (Sender.Channel == null) { return; }
            ModbusReceived?.Invoke(Sender, Data, Index, DataType);
        }
        internal static void InvokeModbusEditorChanged() {
            ModbusEditorChanged?.Invoke();
        }
        public static void SendModbusCommand(SerialManager? CurrentManager, DataSelection DataSet, string Command) {
            if (CurrentManager == null) { return; }
            if (CurrentManager.IsMaster == false) { return; }
            if ((DataSet == DataSelection.ModbusDataCoils) || (DataSet == DataSelection.ModbusDataHoldingRegisters)) {
                ModbusQuery.ModbusCommand(CurrentManager, Command);
            }
        }
        public static void SendModbusCommand(ModbusSlave? CurrentManager, DataSelection DataSet, string Command) {
            if (CurrentManager == null) { return; }
            if (CurrentManager.Channel == null) { return; }
            if (CurrentManager.Address < 0) { return; }
            if (CurrentManager.Channel.IsMaster == false) { return; }
            if ((DataSet == DataSelection.ModbusDataCoils) || (DataSet == DataSelection.ModbusDataHoldingRegisters)) {
                ModbusQuery.ModbusCommand(CurrentManager.Channel, "Unit " + CurrentManager.Address + " " + Command);
            }
        }
        public static void SendModbusCommand(SerialManager? CurrentManager, string Command) {
            if (CurrentManager == null) { return; }
            if (CurrentManager.IsMaster == false) { return; }
            ModbusQuery.ModbusCommand(CurrentManager, Command);
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
        public static void SendTextFile(SerialManager? Channel, string FilePath) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            if (!File.Exists(FilePath)) { return; }
            List<string> Lines = new List<string>();
            try {
                using (StreamReader Sr = new StreamReader(FilePath)) {
                    if (Sr != null) {
                        while (Sr.Peek() > -1) {
                            string item = Sr.ReadLine() ?? "";
                            Lines.Add(item);
                        }
                    }
                }
            }
            catch { }
            Thread TrPost = new Thread(() => SendTextAsync(Channel, Lines));
            TrPost.IsBackground = true;
            TrPost.Start();
        }
        private static void SendTextAsync(SerialManager? Channel, List<string> Lines) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            foreach (string l in Lines) {
                Channel.Post(l);
                Thread.Sleep(1);
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
        public static void AddChannel(string ManagerName, bool CheckExisting = false) {
            if (CheckExisting) {
                if (GetChannel(ManagerName) != null) { return; }
            }
            SerialManager SerMan = new SerialManager();
            SystemManager.SerialManagers.Add(SerMan);
            SerMan.BaudRate = Properties.Settings.Default.DEF_INT_BaudRate;
            try {
                SerMan.DataBits = Properties.Settings.Default.DEF_INT_DataBits;
            }
            catch {
                SerMan.DataBits = 8;
            }
            SerMan.Parity = EnumManager.StringToParity(Properties.Settings.Default.DEF_STR_ParityBit);
            SerMan.StopBits = EnumManager.StringToStopBits(Properties.Settings.Default.DEF_STR_StopBits);
            SerMan.InputFormat = EnumManager.StringToInputFormat(Properties.Settings.Default.DEF_STR_InputFormat);
            SerMan.OutputFormat = EnumManager.StringToOutputFormat(Properties.Settings.Default.DEF_STR_OutputFormat);
            SerMan.Name = ManagerName;

            SerMan.Slave.Add(new ModbusSlave(SerMan, 1));
            ChannelRequestsHandles?.Invoke(SerMan);
            ChannelAdded?.Invoke(SerialManagers.Count - 1);
        }
        public static void AddChannel(string ManagerName, CommandProcessedHandler SerManager_CommandProcessed) {
            SerialManager SerMan = new SerialManager();
            SystemManager.SerialManagers.Add(SerMan);
            SerMan.BaudRate = Properties.Settings.Default.DEF_INT_BaudRate;
            try {
                SerMan.DataBits = Properties.Settings.Default.DEF_INT_DataBits;
            }
            catch {
                SerMan.DataBits = 8;
            }
            SerMan.Parity = EnumManager.StringToParity(Properties.Settings.Default.DEF_STR_ParityBit);
            SerMan.StopBits = EnumManager.StringToStopBits(Properties.Settings.Default.DEF_STR_StopBits);
            SerMan.InputFormat = EnumManager.StringToInputFormat(Properties.Settings.Default.DEF_STR_InputFormat);
            SerMan.OutputFormat = EnumManager.StringToOutputFormat(Properties.Settings.Default.DEF_STR_OutputFormat);
            SerMan.Name = ManagerName;
            SerMan.CommandProcessed += SerManager_CommandProcessed;
            //SerMan.DataReceived += SerMan_DataReceived;
            SerMan.Slave.Add(new ModbusSlave(SerMan, 1));
            ChannelAdded?.Invoke(SerialManagers.Count - 1);
        }
        public static void RemoveChannel(int ChannelIndex, CommandProcessedHandler SerManager_CommandProcessed) {
            if (SerialManagers.Count > 1) {
                if ((ChannelIndex < SerialManagers.Count) && (ChannelIndex != -1)) {
                    SerialManagers[ChannelIndex].CommandProcessed -= SerManager_CommandProcessed;
                    //SerialManagers[ChannelIndex].DataReceived -= SerMan_DataReceived;
                    ApplicationManager.CloseInternalApplication("TERM_" + SerialManagers[ChannelIndex].ID);
                    ApplicationManager.CloseInternalApplication("PROP_" + SerialManagers[ChannelIndex].ID);
                    ModbusSupport.CloseSnapshot(SerialManagers[ChannelIndex]);
                    ModbusSupport.RemovePollers(SerialManagers[ChannelIndex]);
                    SerialManagers[ChannelIndex].CleanUp();
                    SerialManagers.RemoveAt(ChannelIndex);
                    ChannelRemoved?.Invoke(ChannelIndex);
                }
            }
        }
        //, DataProcessedHandler SerMan_DataReceived
        public static void ClearChannels(CommandProcessedHandler SerManager_CommandProcessed) {
            Modbus.ModbusSupport.ClearSnapshots();
            ModbusSupport.ClearPollers();
            for (int i = SerialManagers.Count - 1; i >= 0; i--) {
                SerialManagers[i].CleanUp();
                SerialManagers[i].CommandProcessed -= SerManager_CommandProcessed;
                //SerialManagers[i].DataReceived -= SerMan_DataReceived;
                SerialManagers.RemoveAt(i);
            }
        }
        public static SerialManager? GetChannel(string ChannelName) {
            if (ChannelName.Trim() == "") { return null; }
            foreach (SerialManager SerMan in SerialManagers) {
                if (SerMan.StateName.ToLower() == ChannelName.ToLower()) { return SerMan; }
            }
            return null;
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
        public static int GetChannelIndex(ModbusSlave? Slave) {
            if (Slave == null) { return -1; }
            if (Slave.Channel == null) { return -1; }
            if (SerialManagers.Count > 0) {
                int Output = SerialManagers.IndexOf(Slave.Channel);
                return Output;
            }
            return -1;
        }
        #endregion
        #region Ports and Listing
        public static List<Port> GetSerialPortSettingBased() {
            List<Port> Results = new List<Port>();
            //if (Properties.Settings.Default.CHAN_BOL_PreferLegacyPortListing) {
            //    Results = GetSerialPortLegacyListing();
            //}
            //else {
            //    Results = GetSerialPort();
            //}
            Results = GetSerialPortQuickListing();
            //if (!Properties.Settings.Default.CHAN_BOL_PreferLegacyPortListing) {
            Thread Tr_ListDetails = new Thread(ListPortDetails);
            Tr_ListDetails.IsBackground = true;
            Tr_ListDetails.Name = "Tr_ListPortDetails";
            Tr_ListDetails.Start();
            //}
            return Results.OrderBy(x => x.PortName.Length).ThenBy(x => x.PortName).ToList();
        }
        private static List<Port> GetSerialPort() {
            List<Port> Results = new List<Port>();
            try {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
                ManagementObjectCollection moc = searcher.Get();
                foreach (ManagementObject queryObj in moc) {
                    if (queryObj["Caption"] == null) { continue; }
                    string Name = queryObj["Caption"].ToString() ?? "";
                    Regex Pattern = new Regex(@"(?<Port>\(COM\d+\))");
                    Match Match = Pattern.Match(Name);
                    if (Match.Success) {
                        string PortBracketed = Match.Groups["Port"].Value;
                        string Port = PortBracketed.Replace("(", "").Replace(")", "");
                        string CleanName = Name.Replace(PortBracketed, "");
                        string DeviceID = queryObj["DeviceID"].ToString() ?? "COM1";
                        Port Sp = new Port(Port, CleanName, queryObj["Caption"].ToString() ?? "");
                        Results.Add(Sp);
                    }

                }
                List<Port> TempNonListed = GetSerialPortQuickListing();
                foreach (Port PortLegacy in TempNonListed) {
                    if (!Results.Any(x => x.PortName == PortLegacy.PortName)) {
                        Results.Add(new Port(PortLegacy.PortName, "", PortLegacy.PortName));
                    }
                }
            }
            catch (ManagementException e) {
            }
            return Results;
        }
        private static void ListPortDetails() {
            List<Port> Ports = GetSerialPort();
            if (Ports.Count == 0) { return; }
            PortListingReturned?.Invoke(Ports);
        }
        public static List<Port> GetSerialPortQuickListing() {
            List<Port> Results = new List<Port>();
            string[] TempPorts = SerialPort.GetPortNames();
            foreach (string Str in TempPorts) {
                Results.Add(new Port(Str, "", ""));
            }
            return Results;
        }
        public static void CleanPortHandlers(object DropDownList, List<Port> Ports, EventHandler ClickHandle) {
            Type t = DropDownList.GetType();
            Dictionary<string, Port> portLookup = Ports.ToDictionary(p => p.PortName);
            if (t == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)DropDownList;
                for (int i = Tsmi.DropDownItems.Count - 1; i >= 0; i--) {
                    object Itms = Tsmi.DropDownItems[i];
                    if (Itms.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    object? Tag = ((ToolStripMenuItem)Itms).Tag;
                    if (Tag == null) { continue; }
                    if (Tag.GetType() != typeof(Port)) { continue; }
                    Port currentPort = (Port)Tag;
                    if (portLookup.ContainsKey(currentPort.PortName)) { continue; }
                    ((ToolStripMenuItem)Itms).Click -= ClickHandle;
                    Tsmi.DropDownItems.RemoveAt(i);
                }
            }
            else if (t == typeof(ToolStripDropDownButton)) {
                ToolStripDropDownButton Tsmi = (ToolStripDropDownButton)DropDownList;
                for (int i = Tsmi.DropDownItems.Count - 1; i >= 0; i--) {
                    object Itms = Tsmi.DropDownItems[i];
                    if (Itms.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    object? Tag = ((ToolStripMenuItem)Itms).Tag;
                    if (Tag == null) { continue; }
                    if (Tag.GetType() != typeof(Port)) { continue; }
                    Port currentPort = (Port)Tag;
                    if (portLookup.ContainsKey(currentPort.PortName)) { continue; }
                    ((ToolStripMenuItem)Itms).Click -= ClickHandle;
                    Tsmi.DropDownItems.RemoveAt(i);
                }
            }
        }
        public static void AddPortListing(object DropDownList, Port port, EventHandler ClickHandle) {
            if (PortItemExists(DropDownList, port) == true) { return; }
            int InsertionPoint = PortInsertionPoint(DropDownList, port);
            if (InsertionPoint == -1) {
                NewPortListing(DropDownList, port, ClickHandle);
            }
            else {
                InsertPortListing(DropDownList, InsertionPoint, port, ClickHandle);
            }
        }
        private static int PortInsertionPoint(object Tsmi, Port port) {
            int Index = -1;
            Type t = Tsmi.GetType();
            if (t == typeof(ToolStripMenuItem)) {
                foreach (object Item in ((ToolStripMenuItem)Tsmi).DropDownItems) {
                    Index++;
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Tssmi = (ToolStripMenuItem)Item;
                    if (Tssmi.Tag == null) { continue; }
                    if (Tssmi.Tag.GetType() != typeof(Port)) { continue; }
                    if (Index >= ((ToolStripMenuItem)Tsmi).DropDownItems.Count - 1) { return -1; }
                    if (port.PortNumber < ((Port)Tssmi.Tag).PortNumber) {
                        return Index;
                    }
                }
            }
            else if (t == typeof(ToolStripDropDownButton)) {
                foreach (object Item in ((ToolStripDropDownButton)Tsmi).DropDownItems) {
                    Index++;
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Tssmi = (ToolStripMenuItem)Item;
                    if (Tssmi.Tag == null) { continue; }
                    if (Tssmi.Tag.GetType() != typeof(Port)) { continue; }
                    if (Index >= ((ToolStripDropDownButton)Tsmi).DropDownItems.Count - 1) { return -1; }
                    if (port.PortNumber < ((Port)Tssmi.Tag).PortNumber) {
                        return Index;
                    }
                }
            }

            return -1;
        }
        public static void NewPortListing(object DropDownList, Port port, EventHandler ClickHandle) {
            ToolStripMenuItem Itm = new ToolStripMenuItem();
            Itm.Text = port.DisplayName;
            Itm.Tag = port;
            Itm.ToolTipText = port.ToolTip;
            Itm.ImageScaling = ToolStripItemImageScaling.None;
            Itm.CheckOnClick = true;
            Itm.Click += ClickHandle;
            Type t = DropDownList.GetType();
            if (t == typeof(ToolStripMenuItem)) {
                ((ToolStripMenuItem)DropDownList).DropDownItems.Add(Itm);
            }
            else if (t == typeof(ToolStripDropDownButton)) {
                ((ToolStripDropDownButton)DropDownList).DropDownItems.Add(Itm);
            }
        }
        public static void InsertPortListing(object DropDownList, int Index, Port port, EventHandler ClickHandle) {
            ToolStripMenuItem Itm = new ToolStripMenuItem();
            Itm.Text = port.DisplayName;
            Itm.Tag = port;
            Itm.ToolTipText = port.ToolTip;
            Itm.ImageScaling = ToolStripItemImageScaling.None;
            Itm.CheckOnClick = true;
            Itm.Click += ClickHandle;
            Type t = DropDownList.GetType();
            if (t == typeof(ToolStripMenuItem)) {
                ((ToolStripMenuItem)DropDownList).DropDownItems.Insert(Index, Itm);
            }
            else if (t == typeof(ToolStripDropDownButton)) {
                ((ToolStripDropDownButton)DropDownList).DropDownItems.Insert(Index, Itm);
            }
        }
        public static int PortCount(object DropDownList) {
            int Count = 0;
            Type t = DropDownList.GetType();
            if (t == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)DropDownList;
                foreach (object Item in Tsmi.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Tssmi = (ToolStripMenuItem)Item;
                    if (Tssmi.Tag == null) { continue; }
                    if (Tssmi.Tag.GetType() != typeof(Port)) { continue; }
                    ++Count;
                }
            }
            else if (t == typeof(ToolStripDropDownButton)) {
                ToolStripDropDownButton Tsmi = (ToolStripDropDownButton)DropDownList;
                foreach (object Item in Tsmi.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Tssmi = (ToolStripMenuItem)Item;
                    if (Tssmi.Tag == null) { continue; }
                    if (Tssmi.Tag.GetType() != typeof(Port)) { continue; }
                    ++Count;
                }
            }
            return Count;
        }
        public static Port? GetFirstListing(object DropDownList) {
            Type t = DropDownList.GetType();
            if (t == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)DropDownList;
                foreach (object Item in Tsmi.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Tssmi = (ToolStripMenuItem)Item;
                    if (Tssmi.Tag == null) { continue; }
                    if (Tssmi.Tag.GetType() != typeof(Port)) { continue; }
                    return (Port)Tssmi.Tag;
                }
            }
            else if (t == typeof(ToolStripDropDownButton)) {
                ToolStripDropDownButton Tsmi = (ToolStripDropDownButton)DropDownList;
                foreach (object Item in Tsmi.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Tssmi = (ToolStripMenuItem)Item;
                    if (Tssmi.Tag == null) { continue; }
                    if (Tssmi.Tag.GetType() != typeof(Port)) { continue; }
                    return (Port)Tssmi.Tag;
                }
            }
            return null;
        }
        public static int GetPortNumber(ToolStripMenuItem? Tsmi) {
            if (Tsmi == null) { return -1; }
            if (Tsmi.Tag == null) { return -1; }
            if (Tsmi.Tag.GetType() != typeof(Port)) { return -1; }
            Port CurrentPort = (Port)Tsmi.Tag;
            return CurrentPort.PortNumber;
        }
        public static void CheckPort(object DropDownList, Port port) {
            Type t = DropDownList.GetType();
            if (t == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)DropDownList;
                foreach (object Item in Tsmi.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Tssmi = (ToolStripMenuItem)Item;
                    if (Tssmi.Tag == null) { continue; }
                    if (Tssmi.Tag.GetType() != typeof(Port)) { continue; }
                    Port CurrentPort = (Port)Tssmi.Tag;
                    Tssmi.Checked = CurrentPort.PortName == port.PortName;
                }
            }
            else if (t == typeof(ToolStripDropDownButton)) {
                ToolStripDropDownButton Tsmi = (ToolStripDropDownButton)DropDownList;
                foreach (object Item in Tsmi.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Tssmi = (ToolStripMenuItem)Item;
                    if (Tssmi.Tag == null) { continue; }
                    if (Tssmi.Tag.GetType() != typeof(Port)) { continue; }
                    Port CurrentPort = (Port)Tssmi.Tag;
                    Tssmi.Checked = CurrentPort.PortName == port.PortName;
                }
            }
        }
        public static void AssignNewData(object dropDownList, List<Port> ports) {
            Dictionary<string, Port> lookup = ports.ToDictionary(p => p.PortName);
            if (dropDownList is ToolStripMenuItem menuItem) {
                UpdatePorts(menuItem.DropDownItems, lookup);
            }
            else if (dropDownList is ToolStripDropDownButton dropDownButton) {
                UpdatePorts(dropDownButton.DropDownItems, lookup);
            }
        }

        private static void UpdatePorts(ToolStripItemCollection items, Dictionary<string, Port> lookup) {
            foreach (object item in items) {
                if (item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                ToolStripMenuItem Tssmi = (ToolStripMenuItem)item;
                if (Tssmi.Tag is not Port currentPort) { continue; }
                if (lookup.TryGetValue(currentPort.PortName, out var newPort)) {
                    currentPort.Name = newPort.Name;
                    currentPort.ToolTip = newPort.ToolTip;
                    Tssmi.Text = currentPort.DisplayName;
                    Tssmi.ToolTipText = currentPort.ToolTip;
                }
            }
        }
        public static void CheckPort(object DropDownList, string portName) {
            Port port = new Port(portName, "", "");
            Type t = DropDownList.GetType();
            if (t == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)DropDownList;
                foreach (object Item in Tsmi.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Tssmi = (ToolStripMenuItem)Item;
                    if (Tssmi.Tag == null) { continue; }
                    if (Tssmi.Tag.GetType() != typeof(Port)) { continue; }
                    Port CurrentPort = (Port)Tssmi.Tag;
                    Tssmi.Checked = CurrentPort.PortName == port.PortName;
                }
            }
            else if (t == typeof(ToolStripDropDownButton)) {
                ToolStripDropDownButton Tsmi = (ToolStripDropDownButton)DropDownList;
                foreach (object Item in Tsmi.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Tssmi = (ToolStripMenuItem)Item;
                    if (Tssmi.Tag == null) { continue; }
                    if (Tssmi.Tag.GetType() != typeof(Port)) { continue; }
                    Port CurrentPort = (Port)Tssmi.Tag;
                    Tssmi.Checked = CurrentPort.PortName == port.PortName;
                }
            }
        }
        public static bool PortItemExists(object DropDownList, Port port) {
            Type t = DropDownList.GetType();
            if (t == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)DropDownList;
                foreach (object Item in Tsmi.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Tssmi = ((ToolStripMenuItem)Item);
                    if (Tssmi.Tag == null) { continue; }
                    if (Tssmi.Tag.GetType() != typeof(Port)) { continue; }
                    Port CurrentPort = (Port)Tssmi.Tag;
                    if (CurrentPort.PortName == port.PortName) {
                        return true;
                    }
                }
            }
            else if (t == typeof(ToolStripDropDownButton)) {
                ToolStripDropDownButton Tsmi = (ToolStripDropDownButton)DropDownList;
                foreach (object Item in Tsmi.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Tssmi = ((ToolStripMenuItem)Item);
                    if (Tssmi.Tag == null) { continue; }
                    if (Tssmi.Tag.GetType() != typeof(Port)) { continue; }
                    Port CurrentPort = (Port)Tssmi.Tag;
                    if (CurrentPort.PortName == port.PortName) {
                        return true;
                    }

                }
            }
            return false;
        }
        #endregion
        public static void Initialize() {
            SystemLinkage.ProgramRun += SystemLinkage_ProgramRun;
        }
        private static void SystemLinkage_ProgramRun(string Name) {
            ProgramManager.ExecuteProgram(Name);
        }
        #region Port Management
        public static void CloseAll() {
            foreach (SerialManager SerMan in SystemManager.SerialManagers) {
                if (SerMan.Connected == true) {
                    SerMan.Disconnect();
                }
            }
        }
        #endregion
        #region Plugins
        static List<Structures.PlugIn> plugins = new List<Structures.PlugIn>();
        public static List<Structures.PlugIn> Plugins {
            get { return plugins; }
        }
        public static void LoadPlugins() {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\Plugins" ?? "";//GetExecutionFolder();
            if (Path.Exists(path)) {
                try {
                    LoadPlugins(path);
                }
                catch { }
            }
        }
        public static void LoadPlugins(string folder) {
            Debug.Print("Loading Plugins...");
            plugins.Clear();
            // Get files in folder
            string[] files = Directory.GetFiles(folder, "*.dll");
            foreach (string file in files) {
                try {
                    Assembly assembly = Assembly.LoadFile(file);
                    var types = assembly.GetExportedTypes();
                    bool PlugInLoaded = false;
                    Type? pluginType = assembly.GetTypes().FirstOrDefault(t => typeof(IWindowPlugin).IsAssignableFrom(t) && !t.IsInterface);
                    if (pluginType == null) { continue; }
                    plugins.Add(new PlugIn(file));
                    //                PlugInLoaded = true;
                    //foreach (Type type in types) {
                    //    try {
                    //        if (type.GetInterfaces().Contains(typeof(IWindowPlugin))) {
                    //            object? instance = Activator.CreateInstance(type);
                    //            if (instance != null) {
                    //                //plugins.Add((IWindowPlugin)instance);
                    //                plugins.Add(new PlugIn(file));
                    //                PlugInLoaded = true;
                    //                break;
                    //            }
                    //        }
                    //    }
                    //    catch { }
                    //    if (PlugInLoaded) {
                    //        break;
                    //    }
                    //}
                    if (!PlugInLoaded) {
                        // assembly.
                    }

                }
                catch { }
            }
            PluginsLoaded?.Invoke();
        }
        public static void ApplyPlugins(object ExtensionList, EventHandler ExtensionClicked) {
            Debug.Print("Applying...");
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) ?? "";//GetExecutionFolder();
            try {
                if (Plugins.Count > 0) {
                    if (ExtensionList.GetType() == typeof(ToolStripMenuItem)) {
                        ((ToolStripMenuItem)ExtensionList).Visible = true;
                        foreach (PlugIn Plugin in Plugins) {
                            ToolStripMenuItem Tsi = new ToolStripMenuItem();
                            Tsi.Text = Plugin.Name;

                            Tsi.Click += ExtensionClicked;
                            Tsi.Tag = Plugin;
                            ((ToolStripMenuItem)ExtensionList).DropDownItems.Add(Tsi);
                        }
                    }

                }
            }
            catch { }
        }
        #endregion
        #region Debugging
        public static void Print(ErrorType Severity, string ErrorCode, string Msg) {
            if (MainInstance == null) { return; }
            if (Severity == ErrorType.M_Error) {
                MainInstance.MethodPrinting("ERROR: " + ErrorCode + " " + Msg, ErrorType.M_Error);
            }
            else if (Severity == ErrorType.M_CriticalError) {
                MainInstance.MethodPrinting("STOP: " + ErrorCode + " " + Msg, ErrorType.M_CriticalError);
            }
            else if (Severity == ErrorType.M_Warning) {
                MainInstance.MethodPrinting("WARNING: " + ErrorCode + " " + Msg, ErrorType.M_Warning);
            }
            else if (Severity == ErrorType.M_Notification) {
                MainInstance.MethodPrinting(Msg);
            }
        }
        public static void Print(Guid Id, string Msg) {
            if (MainInstance == null) { return; }
            try {
                MainInstance.MethodPrinting(Id, Msg);
            }
            catch { }
        }
        public static void PrintAppend(Guid Id, string Msg) {
            if (MainInstance == null) { return; }
            try {
                MainInstance.MethodPrintingAppend(Id, Msg);
            }
            catch { }
        }
        public static void PrintAppend(string Msg) {
            if (MainInstance == null) { return; }
            try {
                MainInstance.MethodPrintingAppend(Msg);
            }
            catch { }
        }
        public static void AddTerminalColor(Guid Id, bool Enable, Color TextColor, string SourceName) {
            if (MainInstance == null) { return; }
            try {
                MainInstance.MethodAddTerminalColor(Id, Enable, TextColor, SourceName);
            }
            catch { }
        }
        #endregion
        #region Editor Selectors
        internal static void CheckFormatOption(string Type, object Ctrl) {
            if (Ctrl.GetType() == typeof(ToolStripDropDownButton)) {
                ToolStripDropDownButton Tsddbtn = (ToolStripDropDownButton)Ctrl;
                foreach (object Item in Tsddbtn.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem? Tsmi = (ToolStripMenuItem)Item;
                    if (Tsmi == null) { continue; }
                    if (Tsmi.Tag == null) { continue; }
                    if (Tsmi.Tag.ToString() == Type) {
                        Tsmi.Checked = true;
                    }
                    else {
                        Tsmi.Checked = false;
                    }
                }
            }
            else if (Ctrl.GetType() == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)Ctrl;
                foreach (object Item in Tsmi.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem? TsmiS = (ToolStripMenuItem)Item;
                    if (TsmiS == null) { continue; }
                    if (TsmiS.Tag == null) { continue; }
                    if (TsmiS.Tag.ToString() == Type) {
                        TsmiS.Checked = true;
                    }
                    else {
                        TsmiS.Checked = false;
                    }
                }
            }
        }
        internal static void CheckFormatOption(int Type, object Ctrl) {
            if (Ctrl.GetType() == typeof(ToolStripDropDownButton)) {
                ToolStripDropDownButton Tsddbtn = (ToolStripDropDownButton)Ctrl;
                foreach (object Item in Tsddbtn.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem? Tsmi = (ToolStripMenuItem)Item;
                    if (Tsmi.Tag == null) { continue; }
                    if (Tsmi.Tag.ToString() == Type.ToString()) {
                        Tsmi.Checked = true;
                    }
                    else {
                        Tsmi.Checked = false;
                    }
                }
            }
            else if (Ctrl.GetType() == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)Ctrl;
                foreach (object Item in Tsmi.DropDownItems) {
                    if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem? TsmiS = (ToolStripMenuItem)Item;
                    if (TsmiS.Tag == null) { continue; }
                    if (TsmiS.Tag.ToString() == Type.ToString()) {
                        TsmiS.Checked = true;
                    }
                    else {
                        TsmiS.Checked = false;
                    }
                }
            }
        }
        #endregion
        internal static ProgramObject? GetProgramObjectFromTab(TabClickedEventArgs? Args) {
            if (Args == null) { return null; }
            if (Args.SelectedTab.GetType() == typeof(Tab)) {
                Tab TabData = (Tab)Args.SelectedTab;
                if (TabData.Tag == null) { return null; }
                if (TabData.Tag.GetType() == typeof(ProgramObject)) {
                    return (ProgramObject)TabData.Tag;
                }
            }
            return null;
        }
        #region Global File and Project Handling
        public static void Open(string FilePath) {
            if (MainInstance == null) { return; }
            if (!File.Exists(FilePath)) { return; }
            MainInstance.Open(FilePath);
        }
        public static void Save(bool SaveAs = false) {
            if (MainInstance == null) { return; }
            MainInstance.Save(SaveAs);
        }
        public static void OpenViaFileDialog() {
            if (MainInstance == null) { return; }
            MainInstance.OpenFileViaDialog();
        }
        public static void New() {
            if (MainInstance == null) { return; }
            MainInstance.New();
        }
        #endregion 
    }
}
