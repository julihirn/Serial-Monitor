using Handlers;
using Microsoft.Win32;
using ODModules;
using Serial_Monitor.Classes.Button_Commands;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataType = Handlers.DataType;

namespace Serial_Monitor.Classes {
    public static class ProjectManager {

        public static event DocumentLoadedHandler? DocumentLoaded;
        public delegate void DocumentLoadedHandler();

        public static List<KeypadButton> Buttons = new List<KeypadButton>();
        private const int MaximumButtons = 25;


        static bool keypadTopMost = false;
        public static bool KeypadTopMost {
            get { return keypadTopMost; }
            set {
                keypadTopMost = value;
                Form? Keyp = ApplicationManager.GetFormByName("Keypad");
                if (Keyp == null) { return; }
                if (typeof(Interfaces.Application.IGenerics).IsAssignableFrom(Keyp.GetType())) {
                    ((Interfaces.Application.IGenerics)Keyp).SetTopMost(value);
                }

            }
        }
        public static decimal ProgramVersion {
            get {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
                string TempVer = fvi.ProductMajorPart + "." + fvi.ProductMinorPart.ToString();
                decimal TempProgramVersion = 0; decimal.TryParse(TempVer, out TempProgramVersion);
                return TempProgramVersion;
            }
        }
        public static int ProgramBulid {
            get {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
                return fvi.ProductBuildPart;
            }
        }
        public static void SetKeypadButton(int Index, string CmdType, string CmcLine, string DisplayText, string Channel, int Symbol, int CommandShortcut) {
            if (Buttons.Count == MaximumButtons) {
                if (Index < MaximumButtons) {
                    KeypadButton Btn = Buttons[Index];
                    object? TagData = Btn.Tag;
                    if (TagData != null) {
                        if (TagData.GetType() == typeof(BtnCommand)) {
                            Btn.Text = DisplayText;
                            BtnCommand Data = (BtnCommand)TagData;
                            Data.SetValue(EnumManager.StringToCommandType(CmdType), CmcLine, Channel, Symbol, CommandShortcut);
                        }
                    }
                }
            }
        }
        public static void ClearKeypadButtons() {
            for (int i = 0; i < Buttons.Count; i++) {
                object? TagData = Buttons[i].Tag;
                if (TagData != null) {
                    if (TagData.GetType() == typeof(BtnCommand)) {
                        Buttons[i].Text = "";
                        BtnCommand Data = (BtnCommand)TagData;
                        Data.Reset();
                    }
                }
            }
        }
        public static void LoadGenericKeypadButtons() {
            for (int i = 0; i < MaximumButtons; i++) {
                BtnCommand Cmd = new BtnCommand();
                KeypadButton kBtn = new KeypadButton();
                kBtn.Tag = Cmd;
                Buttons.Add(kBtn);
                Cmd.LinkedButton = Buttons[i];
            }
        }
        public static event FileOpenedHandler? ProgramNameChanged;
        public delegate void FileOpenedHandler(string Address);

        public static event ButtonPropertyChangedHandler? ButtonPropertyChanged;
        public delegate void ButtonPropertyChangedHandler(KeypadButton sender);
        public static void InvokeButtonPropertyChanged(KeypadButton sender) {
            ButtonPropertyChanged?.Invoke(sender);
        }
        public static void WriteFile(string FileAddress) {
            using (StreamWriter Sw = new StreamWriter(FileAddress)) {
                Sw.WriteLine("--------------------------");
                Sw.WriteLine("-- SERIAL MONITOR");
                Sw.WriteLine("-- VERSION " + ProgramVersion + " (Build " + ProgramBulid.ToString() + ")");
                Sw.WriteLine("--------------------------");
                Sw.WriteLine("");
                DocumentHandler.WriteEntry(Sw, "1");
                WriteProperties(Sw);

                Sw.WriteLine("");
                WriteChannels(Sw);
                Sw.WriteLine("");
                WritePrograms(Sw);
                Sw.WriteLine("");
                WriteSnapshots(Sw);
                Sw.WriteLine("");
                WriteKeypad(Sw);

            }
        }
        private static void WriteProperties(StreamWriter Sw) {
            DocumentHandler.WriteComment(Sw, 0, "  Document Details");
            DocumentHandler.Write(Sw, 1, "ProgramName", "");
            DocumentHandler.Write(Sw, 1, "Author", Environment.UserName);
            DocumentHandler.Write(Sw, 1, "Version", ProgramVersion);
            Sw.WriteLine("");
            DocumentHandler.Write(Sw, 1, "KeypadTopMost", keypadTopMost);
        }
        private static void WriteChannels(StreamWriter Sw) {
            if (SystemManager.SerialManagers.Count > 0) {
                DocumentHandler.WriteComment(Sw, 0, "  Channels");
                int i = 0;
                foreach (SerialManager Sm in SystemManager.SerialManagers) {
                    DocumentHandler.Write(Sw, 1, "CHAN_" + i.ToString());
                    DocumentHandler.Write(Sw, 2, "Name", Sm.Name);
                    DocumentHandler.Write(Sw, 2, "Port", Sm.PortName);
                    DocumentHandler.Write(Sw, 2, "Baud", Sm.BaudRate);
                    DocumentHandler.Write(Sw, 2, "DataSize", Sm.DataBits);
                    DocumentHandler.Write(Sw, 2, "StopBits", EnumManager.StopBitsToString(Sm.StopBits));
                    DocumentHandler.Write(Sw, 2, "Parity", EnumManager.ParityToString(Sm.Parity));
                    DocumentHandler.Write(Sw, 2, "ControlFlow", EnumManager.HandshakeToString(Sm.Handshake));
                    DocumentHandler.Write(Sw, 2, "InType", EnumManager.InputFormatToString(Sm.InputFormat).B);
                    DocumentHandler.Write(Sw, 2, "OutType", EnumManager.OutputFormatToString(Sm.OutputFormat).B);
                    DocumentHandler.Write(Sw, 2, "LineFormat", EnumManager.LineFormattingToString(Sm.LineFormat));
                    DocumentHandler.Write(Sw, 2, "ModbusMstr", Sm.IsMaster);
                    DocumentHandler.Write(Sw, 2, "OutputToMstr", Sm.OutputToMasterTerminal);
                    DocumentHandler.Write(Sw, 2, "AutoConnect", Sm.AutoReconnect);
                    WriteRegisters(Sw, Sm, -1, 0);
                    for (int x = 0; x < Sm.Slave.Count; x++) {
                        int SlaveIndex = ModbusSupport.UnitToIndex(Sm,Sm.Slave[x].Address);
                        WriteRegisters(Sw, Sm, SlaveIndex, Sm.Slave[x].Address);
                    }
                    Sw.WriteLine(StringHandler.AddTabs(1, "}"));
                    i++;
                }
            }
        }
        private static void WriteRegisters(StreamWriter Sw, SerialManager Sm, int Index, int Unit) {
            List<RegisterRequest> RegistersToWrite = Modbus.ModbusSupport.GetModifiedRegisters(Sm, Index);
            if (RegistersToWrite.Count > 0) {
                if (Index < 0) {
                    Sw.WriteLine(StringHandler.AddTabs(2, "def,a(str):Registers={"));
                }
                else {
                    Sw.WriteLine(StringHandler.AddTabs(2, "def,a(str):Registers_" + Unit.ToString() + "={"));
                }
                foreach (RegisterRequest Rq in RegistersToWrite) {
                    ValidString Result = Modbus.ModbusSupport.BulidRegisterSerialisedString(Sm, Index, Rq.Index, Rq.Selection);
                    if (Result.IsValid == true) {
                        Sw.WriteLine(StringHandler.AddTabs(3, StringHandler.EncapsulateString(Result.Value)));
                    }
                }
                Sw.WriteLine(StringHandler.AddTabs(2, "}"));
            }
        }
        private static void WritePrograms(StreamWriter Sw) {
            if (ProgramManager.Programs.Count > 0) {
                DocumentHandler.WriteComment(Sw, 0, "  Step Programs");
                int Cnt = 0;
                foreach (ProgramObject Prg in ProgramManager.Programs) {
                    if (Prg.Program.Count > 0) {
                        DocumentHandler.Write(Sw, 1, "STEP_" + Cnt.ToString());
                        DocumentHandler.Write(Sw, 2, "Name", Prg.Name);
                        DocumentHandler.Write(Sw, 2, "Command", Prg.Command);
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,a(str):Data={"));
                        foreach (ListItem LstItm in Prg.Program) {
                            if (LstItm.SubItems.Count == 3) {
                                string EnableTxt = LstItm.SubItems[0].Checked == true ? "1" : "0";
                                string Command = "";
                                object? CommandObj = LstItm.SubItems[1].Tag;
                                if (CommandObj != null) {
                                    if (CommandObj.GetType() == typeof(StepEnumerations.StepExecutable)) {      //4294967295
                                        Command = ((long)((StepEnumerations.StepExecutable)CommandObj)).ToString("0000000000");
                                    }
                                }
                                string Arguments = LstItm.SubItems[2].Text;
                                Sw.WriteLine(StringHandler.AddTabs(3, StringHandler.EncapsulateString(EnableTxt + ":" + Command + ":" + Arguments)));
                            }
                        }
                        Sw.WriteLine(StringHandler.AddTabs(2, "}"));
                        if (Prg.Array.Count > 0) {
                            Sw.WriteLine(StringHandler.AddTabs(2, "def,a(str):Array={"));
                            foreach (string val in Prg.Array) {
                                Sw.WriteLine(StringHandler.AddTabs(3, StringHandler.EncapsulateString(val)));
                            }
                            Sw.WriteLine(StringHandler.AddTabs(2, "}"));
                        }
                        Sw.WriteLine(StringHandler.AddTabs(1, "}"));
                    }
                    Cnt++;
                }
            }
        }
        private static void WriteKeypad(StreamWriter Sw) {
            if (Buttons.Count > 0) {
                DocumentHandler.WriteComment(Sw, 0, "  Keypad Buttons");
                int Cnt = 0;
                foreach (KeypadButton Btn in Buttons) {
                    if (Btn.Tag != null) {
                        if (Btn.Tag.GetType() == typeof(BtnCommand)) {
                            BtnCommand CmdSet = (BtnCommand)Btn.Tag;
                            if ((CmdSet.IsSet == true) || (CmdSet.IsEdited == true)) {
                                DocumentHandler.Write(Sw, 1, "KBTN_" + Cnt.ToString());
                                DocumentHandler.Write(Sw, 2, "Text", Btn.Text);
                                DocumentHandler.Write(Sw, 2, "Command", CmdSet.CommandLine);
                                DocumentHandler.Write(Sw, 2, "Type", EnumManager.CommandTypeToString(CmdSet.Type));
                                DocumentHandler.Write(Sw, 2, "Channel", CmdSet.Channel);
                                DocumentHandler.Write(Sw, 2, "Symbol", (int)CmdSet.DisplaySymbol);
                                DocumentHandler.Write(Sw, 2, "Shortcut", (int)CmdSet.Shortcut);
                                Sw.WriteLine(StringHandler.AddTabs(1, "}"));
                            }
                        }
                    }
                    Cnt++;
                }
            }
        }
        private static void WriteSnapshots(StreamWriter Sw) {
            if (ModbusSupport.Snapshots.Count > 0) {
                DocumentHandler.WriteComment(Sw, 0, "  Modbus Snapshots");
                int Cnt = 0;
                foreach (ModbusSnapshot Mss in ModbusSupport.Snapshots) {
                    if (Mss.Manager != null) {
                        DocumentHandler.Write(Sw, 1, "MSPSH_" + Cnt.ToString());
                        DocumentHandler.Write(Sw, 2, "SnapshotType", EnumManager.ModbusSnapshotTypeToString(Mss.SelectionType).B);
                        DocumentHandler.Write(Sw, 2, "Name", Mss.BaseName);
                        DocumentHandler.Write(Sw, 2, "Channel", SystemManager.GetChannelIndex(Mss.Manager));
                        DocumentHandler.Write(Sw, 2, "Unit", Mss.Manager.Address);
                        DocumentHandler.Write(Sw, 2, "Type", EnumManager.ModbusDataSelectionToString(Mss.Selection).B);

                        if (Mss.SelectionType == Enums.ModbusEnums.SnapshotSelectionType.Concurrent) {
                            DocumentHandler.Write(Sw, 2, "Address", Mss.StartIndex);
                            DocumentHandler.Write(Sw, 2, "Count", Mss.Count);
                        }
                        else {
                            Sw.WriteLine(StringHandler.AddTabs(2, "def,a(int):Indices={"));
                            foreach (ListItem Li in Mss.Listings) {
                                Sw.WriteLine(StringHandler.AddTabs(3, Li.Value.ToString()));
                            }
                            Sw.WriteLine(StringHandler.AddTabs(2, "}"));
                        }
                        DocumentHandler.Write(Sw, 2, "Bounds", RectangleToString(Mss.Bounds));

                        Sw.WriteLine(StringHandler.AddTabs(1, "}"));
                    }
                    Cnt++;
                }
            }
        }
        private static string RectangleToString(Rectangle Rect) {
            return Rect.X.ToString() + "," + Rect.Y.ToString() + "," + Rect.Width.ToString() + "," + Rect.Height.ToString();
        }
        private static Rectangle StringToRectangle(string Rect) {
            STR_MVSSF Spilt = StringHandler.SpiltStringMutipleValues(Rect, ',');
            if (Spilt.Count != 4) { return Rectangle.Empty; }
            int x = 0; int.TryParse(Spilt.Value[0], out x);
            int y = 0; int.TryParse(Spilt.Value[1], out y);
            int w = 0; int.TryParse(Spilt.Value[2], out w);
            int h = 0; int.TryParse(Spilt.Value[3], out h);
            return new Rectangle(x, y, w, h);
        }
        private static List<string> GetList(object Input) {
            if (Input == null) {
                return new List<string>();
            }
            if (Input.GetType() == typeof(List<string>)) {
                return (List<string>)Input;
            }
            return new List<string>();
        }
        private static List<int> GetIntegerList(object Input) {
            if (Input == null) {
                return new List<int>();
            }
            if (Input.GetType() == typeof(List<int>)) {
                return (List<int>)Input;
            }
            return new List<int>();
        }
        public static void ReadSMPFile(string FileAddress, SerialManager.CommandProcessedHandler CmdProc, SerialManager.DataProcessedHandler DataProc) {
            ProgramManager.Programs.Add(new ProgramObject());
            int CurrentProgramIndex = 0;
            for (int i = 0; i < DocumentHandler.PARM.Count; i++) {
                string ParameterName = DocumentHandler.PARM[i].Name;
                ParameterStructure Pstrc = DocumentHandler.PARM[i];
                if (ParameterName.StartsWith("CHAN")) {
                    LoadChannel(Pstrc, CmdProc, DataProc);
                }
                else if (ParameterName.StartsWith("KBTN")) {
                    LoadKeypadButton(Pstrc);
                }
                else if (ParameterName.StartsWith("STEP")) {
                    LoadStepProgram(Pstrc, ref CurrentProgramIndex);
                }
                else if (ParameterName.StartsWith("MSPSH")) {
                    LoadSnapshots(Pstrc);
                }
                //MSPSH
            }
            DocumentLoaded?.Invoke();
            DocumentHandler.LINES.Clear();
            DocumentHandler.PARM.Clear();
            DocumentHandler.INST.Clear();
            DocumentHandler.LINES.Clear();
            DocumentHandler.ENUMERATION.Clear();
            GC.Collect();
        }
        private static void LoadChannel(ParameterStructure Pstrc, SerialManager.CommandProcessedHandler CmdProc, SerialManager.DataProcessedHandler DataProc) {
            SerialManager Sm = new SerialManager();
            Sm.Name = DocumentHandler.GetStringVariable(Pstrc, "Name", "");
            try {
                Sm.PortName = DocumentHandler.GetStringVariable(Pstrc, "Port", "");
            }
            catch { }
            try {
                Sm.BaudRate = DocumentHandler.GetIntegerVariable(Pstrc, "Baud", 9600);
            }
            catch { }
            try {
                Sm.DataBits = DocumentHandler.GetIntegerVariable(Pstrc, "DataSize", 8);
            }
            catch { }
            try {
                Sm.StopBits = EnumManager.StringToStopBits(DocumentHandler.GetStringVariable(Pstrc, "StopBits", "1"));
            }
            catch { }
            try {
                Sm.Parity = EnumManager.StringToParity(DocumentHandler.GetStringVariable(Pstrc, "Parity", "N"));
            }
            catch { }
            try {
                Sm.Handshake = EnumManager.StringToHandshake(DocumentHandler.GetStringVariable(Pstrc, "ControlFlow", ""));
            }
            catch { }
            try {
                Sm.InputFormat = EnumManager.StringToInputFormat(DocumentHandler.GetStringVariable(Pstrc, "InType", "frmTxt"));
            }
            catch { }
            try {
                Sm.OutputFormat = EnumManager.StringToOutputFormat(DocumentHandler.GetStringVariable(Pstrc, "OutType", "frmTxt"));
            }
            catch { }
            try {
                Sm.LineFormat = EnumManager.StringToLineFormatting(DocumentHandler.GetStringVariable(Pstrc, "LineFormat", "frmLineNone"));
            }
            catch { }
            try {
                Sm.IsMaster = DocumentHandler.GetBooleanVariable(Pstrc, "ModbusMstr");
            }
            catch { }
            try {
                Sm.OutputToMasterTerminal = DocumentHandler.GetBooleanVariable(Pstrc, "OutputToMstr", true);
            }
            catch { }
            try {
                Sm.AutoReconnect = DocumentHandler.GetBooleanVariable(Pstrc, "AutoConnect");
            }
            catch { }
            if (DocumentHandler.IsDefinedInParameter("Registers", Pstrc)) {
                List<string> Data = GetList(Pstrc.GetVariable("Registers", false, DataType.STR));
                for (int j = 0; j < Data.Count; j++) {
                    ModbusSupport.DecodeFileRegsisterCommand(Data[j], -1, Sm);
                }
            }
            List<string> RegisterSets = GetListOfVarName("Registers_", Pstrc);
            if (RegisterSets.Count > 0) {
                foreach (string RegList in RegisterSets) {
                    string TempUnit = RegList.Replace("Registers_", "");
                    int Unit = -1; int.TryParse(TempUnit, out Unit);
                    if (Unit < 0) { continue; }
                    Sm.NewSlave(Unit);
                    List<string> Data = GetList(Pstrc.GetVariable(RegList, false, DataType.STR));
                    for (int j = 0; j < Data.Count; j++) {
                        ModbusSupport.DecodeFileRegsisterCommand(Data[j], Unit, Sm);
                    }
                }
            }
            Sm.CommandProcessed += CmdProc;// SerManager_CommandProcessed;
            Sm.DataReceived += DataProc;// SerMan_DataReceived;
            if (Sm.Slave.Count  == 0) {
                Sm.Slave.Add(new ModbusSlave(Sm, 1));
            }
            SystemManager.SerialManagers.Add(Sm);
        }
        private static List<string> GetListOfVarName(string Input, ParameterStructure Pstrc) {
            List<string> VarNames = new List<string>();
            foreach (Variable Var in Pstrc.VALUES) {
                if (Var.Name.StartsWith(Input)) {
                    VarNames.Add(Var.Name);
                }
            }
            return VarNames;
        }
        private static void LoadKeypadButton(ParameterStructure Pstrc) {
            if (Pstrc.Name.Split('_').Length == 2) {
                string IndexStr = Pstrc.Name.Split('_')[1];
                int Index = 0; int.TryParse(IndexStr, out Index);
                string ButtonText = DocumentHandler.GetStringVariable(Pstrc, "Text", "");
                string CommandText = DocumentHandler.GetStringVariable(Pstrc, "Command", "");
                string CommandType = DocumentHandler.GetStringVariable(Pstrc, "Type", "NONE");
                string CommandChannel = DocumentHandler.GetStringVariable(Pstrc, "Channel", "");
                int CommandSymbol = DocumentHandler.GetIntegerVariable(Pstrc, "Symbol", 0);
                int CommandShortcut = DocumentHandler.GetIntegerVariable(Pstrc, "Shortcut", 0);
                SetKeypadButton(Index, CommandType, CommandText, ButtonText, CommandChannel, CommandSymbol, CommandShortcut);
            }
        }
        private static void LoadStepProgram(ParameterStructure Pstrc, ref int CurrentProgramIndex) {
            if (CurrentProgramIndex > 0) {
                ProgramManager.Programs.Add(new ProgramObject());
            }
            //E:00000000:
            ProgramManager.Programs[CurrentProgramIndex].Name = DocumentHandler.GetStringVariable(Pstrc, "Name", "");
            ProgramManager.Programs[CurrentProgramIndex].Command = DocumentHandler.GetStringVariable(Pstrc, "Command", "");
            if (DocumentHandler.IsDefinedInParameter("Data", Pstrc)) {

                List<string> Data = GetList(Pstrc.GetVariable("Data", false, DataType.STR));
                for (int j = 0; j < Data.Count; j++) {
                    ProgramManager.Programs[CurrentProgramIndex].DecodeFileCommand(Data[j]);
                }
            }
            if (DocumentHandler.IsDefinedInParameter("Array", Pstrc)) {
                List<string> Data = GetList(Pstrc.GetVariable("Array", false, DataType.STR));
                for (int j = 0; j < Data.Count; j++) {
                    ProgramManager.Programs[CurrentProgramIndex].Array.Add(Data[j]);
                }
            }
            CurrentProgramIndex++;
        }
        private static void LoadSnapshots(ParameterStructure Pstrc) {
            string Snapshot_Name = DocumentHandler.GetStringVariable(Pstrc, "Name", "");
            DataSelection Snapshot_Type = EnumManager.ModbusStringToDataSelection(DocumentHandler.GetStringVariable(Pstrc, "Type", ""));
            SerialManager? Snapshot_Channel = SystemManager.GetChannel(DocumentHandler.GetIntegerVariable(Pstrc, "Channel", -1));
            int Unit = DocumentHandler.GetIntegerVariable(Pstrc, "Unit", -1);
            if (Snapshot_Channel != null) {
                Enums.ModbusEnums.SnapshotSelectionType Snapshot_Selection = EnumManager.ModbusStringToSnapshotType(DocumentHandler.GetStringVariable(Pstrc, "SnapshotType", ""));
                if (Snapshot_Selection == Enums.ModbusEnums.SnapshotSelectionType.Concurrent) {
                    int Address = DocumentHandler.GetIntegerVariable(Pstrc, "Address", 0);
                    int Count = DocumentHandler.GetIntegerVariable(Pstrc, "Count", 10);
                    Rectangle Bounds = StringToRectangle(DocumentHandler.GetStringVariable(Pstrc, "Bounds", ""));
                    if (Unit <= 0) {
                        if (Snapshot_Channel.Registers != null) {
                            ModbusSupport.NewSnapshot(Snapshot_Channel.Registers, Snapshot_Type, Address, Count, Bounds);
                        }
                    }
                    else {
                        int SlaveIndex = ModbusSupport.UnitToIndex(Snapshot_Channel, Unit);
                        if (SlaveIndex < 0) { return; }
                        ModbusSupport.NewSnapshot(Snapshot_Channel.Slave[SlaveIndex], Snapshot_Type, Address, Count, Bounds);
                    }

                }
                else if (Snapshot_Selection == Enums.ModbusEnums.SnapshotSelectionType.Custom) {
                    List<int> Data = GetIntegerList(Pstrc.GetVariable("Indices", false, DataType.INT));
                    Rectangle Bounds = StringToRectangle(DocumentHandler.GetStringVariable(Pstrc, "Bounds", ""));
                    if (Data.Count > 0) {
                        if (Unit < 0) {
                            if (Snapshot_Channel.Registers != null) {
                                ModbusSupport.NewSnapshot(Snapshot_Channel.Registers, Snapshot_Type, Data, Bounds);
                            }
                        }
                        else {
                            int Index = ModbusSupport.UnitToIndex(Snapshot_Channel, Unit);
                            if (Index > -1) {
                                ModbusSupport.NewSnapshot(Snapshot_Channel.Slave[Index], Snapshot_Type, Data, Bounds);
                            }
                        }
                    }
                }
            }
        }
        public static void ReadCMSLFile(string FileAddress, SerialManager.CommandProcessedHandler CmdProc, SerialManager.DataProcessedHandler DataProc) {
            SerialManager Sm = new SerialManager();
            Sm.CommandProcessed += CmdProc;// SerManager_CommandProcessed;
            Sm.DataReceived += DataProc;// SerMan_DataReceived;
            SystemManager.SerialManagers.Add(Sm);
            ProgramManager.Programs.Add(new ProgramObject("Legacy Program"));
            try {
                using (StreamReader TxtReader = new StreamReader(FileAddress)) {
                    while (TxtReader.Peek() > -1) {
                        ProgramManager.Programs[0].DecodeLegacyFileCommand(TxtReader.ReadLine() ?? "");
                    }
                }
            }
            catch { }
        }
        public static StepEnumerations.StepExecutable ExecutableFromLegacyString(string Input) {
            Input = Input.ToUpper();
            if (Input == "SND") { return StepEnumerations.StepExecutable.SendString; }
            else if (Input == "STXT") { return StepEnumerations.StepExecutable.SendText; }
            else if (Input == "PRNT") { return StepEnumerations.StepExecutable.Print; }
            else if (Input == "END") { return StepEnumerations.StepExecutable.Close; }
            else if (Input == "OPEN") { return StepEnumerations.StepExecutable.Open; }
            else if (Input == "SNDL") { return StepEnumerations.StepExecutable.SendString; }
            else if (Input == "CLR") { return StepEnumerations.StepExecutable.Clear; }
            else if (Input == "DLY") { return StepEnumerations.StepExecutable.Delay; }
            else if (Input == "GOTO") { return StepEnumerations.StepExecutable.GoToLine; }
            // else if (Input == "WHEN_TCK") { return StepEnumerations.StepExecutable.GoTo; }
            else if (Input == "SBYTE") { return StepEnumerations.StepExecutable.SendByte; }
            else if (Input == "SWS") { return StepEnumerations.StepExecutable.SwitchSender; }
            else { return StepEnumerations.StepExecutable.NoOperation; }
        }
    }
}
