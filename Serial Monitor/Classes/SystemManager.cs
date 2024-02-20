using Handlers;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serial_Monitor.Plugin;
using static Serial_Monitor.Classes.SerialManager;
using System.Reflection;
using Serial_Monitor.Classes.Modbus;
using ODModules;

namespace Serial_Monitor.Classes {
    public static class SystemManager {
        public static MainWindow? MainInstance = null;

        public static List<int> DefaultBauds = new List<int>();
        public static List<SerialManager> SerialManagers = new List<SerialManager>();

        public static event ChannelAddedHandler? ChannelAdded;
        public delegate void ChannelAddedHandler(int RemovedIndex);
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

        public static event PortStatusChangedHandler? PortStatusChanged;
        public delegate void PortStatusChangedHandler(SerialManager sender);

        public static event ErrorMessageHandler? ErrorInvoked;
        public delegate void ErrorMessageHandler(ErrorType Type, string Sender, string Message);

        public static event ModbusPropertyChangedHandler? ModbusPropertyChanged;
        public delegate void ModbusPropertyChangedHandler(ModbusSlave sender, object Data, int Index, DataSelection DataType);
        public static event ModbusRegisterRenamedHandler? ModbusRegisterRenamed;
        public delegate void ModbusRegisterRenamedHandler(ModbusSlave sender, object Data, int Index, DataSelection DataType);
        public static event ModbusReceivedHandler? ModbusReceived;
        public delegate void ModbusReceivedHandler(ModbusSlave sender, object Data, int Index, DataSelection DataType);

        public static event ModbusAppearanceChangedHandler? ModbusAppearanceChanged;
        public delegate void ModbusAppearanceChangedHandler(ModbusSlave sender, List<int> Indices, DataSelection DataType);

        public static event ModbusDiagnosticsReceivedHandler? ModbusDiagnosticsReceived;
        public delegate void ModbusDiagnosticsReceivedHandler(SerialManager sender, int Slave, ModbusSupport.DiagnosticSubFunction SubFunction, int Data);

        public static event PluginsLoadedHandler? PluginsLoaded;
        public delegate void PluginsLoadedHandler();

        public static void InvokeSlaveAdded(SerialManager sender) {
            SlaveAdded?.Invoke(sender);
        }
        public static void InvokeSlaveChanged(SerialManager sender) {
            SlaveChanged?.Invoke(sender);
        }
        public static void InvokeErrorMessage(ErrorType Type, string Sender, string Message) {
            ErrorInvoked?.Invoke(Type, Sender, Message);
        }
        public static void InvokePortStatusChanged(SerialManager sender) {
            PortStatusChanged?.Invoke(sender);
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

        public static void ModbusDiagnosticsReturn(SerialManager? SerMan, int Slave, ModbusSupport.DiagnosticSubFunction SubFunction, int Data) {
            if (SerMan == null) { return; }
            ModbusDiagnosticsReceived?.Invoke(SerMan, Slave, SubFunction, Data);
        }
        public static void ModbusRegisterAppearanceChanged(ModbusSlave? Sender, List<int> Indices, DataSelection? DataType) {
            if (Sender == null) { return; }
            if (Sender.Manager == null) { return; }
            if (DataType == null) { return; }
            ModbusAppearanceChanged?.Invoke(Sender, Indices, (DataSelection)DataType);
        }
        public static void ModbusRegisterPropertyChanged(ModbusSlave? Sender, object Data, int Index, DataSelection DataType) {
            if (Sender == null) { return; }
            if (Sender.Manager == null) { return; }
            ModbusPropertyChanged?.Invoke(Sender, Data, Index, DataType);
        }
        public static void RegisterNameChanged(ModbusSlave? Sender, object Data, int Index, DataSelection DataType) {
            if (Sender == null) { return; }
            if (Sender.Manager == null) { return; }
            ModbusRegisterRenamed?.Invoke(Sender, Data, Index, DataType);
        }
        public static void RegisterValueChanged(ModbusSlave? Sender, object Data, int Index, DataSelection DataType) {
            if (Sender == null) { return; }
            if (Sender.Manager == null) { return; }
            ModbusReceived?.Invoke(Sender, Data, Index, DataType);
        }
        public static void SendModbusCommand(SerialManager? CurrentManager, DataSelection DataSet, string Command) {
            if (CurrentManager == null) { return; }
            if (CurrentManager.IsMaster == false) { return; }
            if ((DataSet == DataSelection.ModbusDataCoils) || (DataSet == DataSelection.ModbusDataHoldingRegisters)) {
                CurrentManager.ModbusCommand(Command);
            }
        }
        public static void SendModbusCommand(ModbusSlave? CurrentManager, DataSelection DataSet, string Command) {
            if (CurrentManager == null) { return; }
            if (CurrentManager.Manager == null) { return; }
            if (CurrentManager.Address < 0) { return; }
            if (CurrentManager.Manager.IsMaster == false) { return; }
            if ((DataSet == DataSelection.ModbusDataCoils) || (DataSet == DataSelection.ModbusDataHoldingRegisters)) {
                CurrentManager.Manager.ModbusCommand("Unit " + CurrentManager.Address + " " + Command);
            }
        }
        public static void SendModbusCommand(SerialManager? CurrentManager, string Command) {
            if (CurrentManager == null) { return; }
            if (CurrentManager.IsMaster == false) { return; }
            CurrentManager.ModbusCommand(Command);
        }
        public static void ExecuteModbusQuery(string Query) {
            string NextQuery = Query;
            while (NextQuery.Length > 1) {
                string CurrentQuery = Classes.CommandManager.GetQuery(NextQuery, ref NextQuery);
                string CurrentQueryUntouched = CurrentQuery;
                List<StringPair> Vars = GetModbusQueryVariables(ref CurrentQuery);
                ApplyModbusQueryVariables(ref CurrentQuery, Vars);
                string ChannelName = "";
                bool State = Classes.CommandManager.GetValue(ref CurrentQuery, "USING", out ChannelName, false);
                if (State == false) { break; }
                SerialManager? Current = SystemManager.GetChannel(ChannelName);
                if (Current == null) { break; }
                bool WasMaster = Current.IsMaster;
                bool ResetMaster = false;
                CurrentQuery = CurrentQuery.ToUpper();
                if (Classes.CommandManager.TestKeyword(ref CurrentQuery, "AS")) {
                    if (Classes.CommandManager.TestKeyword(ref CurrentQuery, "MASTER")) {
                        Current.IsMaster = true;
                        ResetMaster = true;
                    }
                }
                SystemManager.SendModbusCommand(Current, CurrentQuery);
                if (ResetMaster == true) { Current.IsMaster = WasMaster; }
            }
        }
        private static List<StringPair> GetModbusQueryVariables(ref string CurrentQuery) {
            List <StringPair>  Output = new List<StringPair>();
            while (CurrentQuery.ToUpper().Contains("DECLARE")) {
                string TempName = "";
                string TempValue = "";
                if (Classes.CommandManager.GetValue(ref CurrentQuery, "DECLARE", out TempName, false, true)) {
                    if (Classes.CommandManager.IsModbusKeyword(TempName) == false) {
                        if (Classes.CommandManager.GetValue(ref CurrentQuery, "=", out TempValue, false)) {
                            Output.Add(new StringPair(TempName, TempValue));
                        }
                    }
                }
            }
            return Output;
        }
        private static void ApplyModbusQueryVariables(ref string CurrentQuery, List<StringPair> Vars) {
            foreach(StringPair Sp in Vars) {
                CurrentQuery = CurrentQuery.Replace(Sp.A, Sp.B);
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
            SerMan.DataReceived += SerMan_DataReceived;
            SerMan.Slave.Add(new ModbusSlave(SerMan, 1));
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
                    SerialManagers[ChannelIndex].CleanUp();
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
            if (Slave.Manager == null) { return -1; }
            if (SerialManagers.Count > 0) {
                int Output = SerialManagers.IndexOf(Slave.Manager);
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
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) ?? "";//GetExecutionFolder();
            try {
                LoadPlugins(path);
            }
            catch { }
        }
        public static void LoadPlugins(string folder) {
            plugins.Clear();
            // Get files in folder
            string[] files = Directory.GetFiles(folder, "*.dll");
            foreach (string file in files) {
                try {
                    Assembly assembly = Assembly.LoadFile(file);
                    var types = assembly.GetExportedTypes();

                    foreach (Type type in types) {
                        try {
                            if (type.GetInterfaces().Contains(typeof(IWindowPlugin))) {
                                object? instance = Activator.CreateInstance(type);
                                if (instance != null) {
                                    //plugins.Add((IWindowPlugin)instance);
                                    plugins.Add(new PlugIn(file));
                                }
                            }
                        }
                        catch { }
                    }

                }
                catch { }
            }
            PluginsLoaded?.Invoke();
        }
        public static void ApplyPlugins(object ExtensionList, EventHandler ExtensionClicked) {
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
                MainInstance.MethodPrinting("ERROR: " + ErrorCode + " " + Msg, 1);
            }
            else if (Severity == ErrorType.M_CriticalError) {
                MainInstance.MethodPrinting("STOP: " + ErrorCode + " " + Msg, 1);
            }
            else if (Severity == ErrorType.M_Warning) {
                MainInstance.MethodPrinting("WARNING: " + ErrorCode + " " + Msg, 0);
            }
            else if (Severity == ErrorType.M_Notification) {
                MainInstance.MethodPrinting(Msg);
            }
        }
        #endregion
        #region Editor Selectors
        public static void CheckFormatOption(string Type, object Ctrl) {
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
        public static void CheckFormatOption(int Type, object Ctrl) {
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
        //private void CheckOutputFormat(string Type) {
        //    foreach (object Item in ddbOutputFormat.DropDownItems) {
        //        if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
        //        if (((ToolStripMenuItem)Item).Tag.ToString() == Type) {
        //            ((ToolStripMenuItem)Item).Checked = true;
        //        }
        //        else {
        //            ((ToolStripMenuItem)Item).Checked = false;
        //        }
        //    }
        //    foreach (object Item in btnChannelOutputFormat.DropDownItems) {
        //        if (Item.GetType() != typeof(ToolStripMenuItem)) { continue; }
        //        if (((ToolStripMenuItem)Item).Tag.ToString() == Type) {
        //            ((ToolStripMenuItem)Item).Checked = true;
        //        }
        //        else {
        //            ((ToolStripMenuItem)Item).Checked = false;
        //        }
        //    }
        //}
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
    }
}
