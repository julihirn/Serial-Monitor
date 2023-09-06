using Handlers;
using ODModules;
using Serial_Monitor.Classes.Step_Programs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataType = Serial_Monitor.Classes.Step_Programs.DataType;

namespace Serial_Monitor.Classes {
    public static class ProgramManager {
        public static Thread? ThreadStepExecutable;

        public static event ProgramListingChangedHandler? ProgramListingChanged;
        public delegate void ProgramListingChangedHandler();
        public static event ProgramNameChangedHandler? ProgramNameChanged;
        public delegate void ProgramNameChangedHandler(object sender);
        public static List<ProgramObject> Programs = new List<ProgramObject>(1);

        public static ProgramObject? CurrentProgram = null;
        public static ProgramObject? CurrentEditingProgram = null;

        public static StepEnumerations.StepState ProgramState = StepEnumerations.StepState.Stopped;
        static bool executionThreadRunning = true;
        public static bool ExecutionThreadRunning {
            get { return executionThreadRunning; }
        }
        public static int ProgramStep = 0;
        public static int LastProgramStep = 0;
        public static string CurrentSender = "";
        public static string LatestOnClick = "";

        public static int Program_CurrentManager = 0;
        public static bool NoStepProgramIncrement = false;

        public static MainWindow? MainInstance = null;


        public static StepEnumerations.StepExecutable LastFunction = StepEnumerations.StepExecutable.NoOperation;
        public static List<LabelLinkage> LabelPositions = new List<LabelLinkage>();

        public static List<ConditionalLinkage> Conditionals = new List<ConditionalLinkage>();
        public static string StepExecutableToString(StepEnumerations.StepExecutable StepEx) {
            return StringHandler.MergeStrings(StringHandler.SpiltStringAtCapitals(StepEx.ToString()), ' ');
        }
        public static void ProgramNameChange(object sender) {
            ProgramNameChanged?.Invoke(sender);
        }
        public static void LaunchThread() {
            executionThreadRunning = true;
            ThreadStepExecutable = new Thread(StepProgram);
            ThreadStepExecutable.IsBackground = true;
            ThreadStepExecutable.Start();
        }
        public static void TestThread() {
            if (executionThreadRunning == false) {
                Print(ErrorType.M_Notification, "PROG_THREAD_EXE", "Restarting execution thread...");
                try {
                    LaunchThread();
                }
                catch {
                    Print(ErrorType.M_Notification, "PROG_THREAD_FAIL", "Porgram thread could not be launched!");
                    executionThreadRunning = false;
                }
            }
        }
        #region Program Transport
        public static void RunFromStart() {
            ProgramManager.SetupProgram();
            ProgramManager.ProgramStep = 0;
            ProgramManager.ProgramState = StepEnumerations.StepState.Running;
        }
        public static void RunFromStart(string ProgramName, bool UseProgramCommand = true) {
            bool ProgramFound = false;
            if (ProgramName.Length > 0) {
                bool Resulted = false;
                string ProName = "";
                foreach (ProgramObject PrgObj in Programs) {
                    if (UseProgramCommand == true) {
                        if (PrgObj.Name == ProgramName) {
                            CurrentProgram = PrgObj;
                            ProgramFound = true;
                            ProName = PrgObj.Name;
                            if (MainInstance != null) { MainInstance.MethodSetRunText(PrgObj.Name); }
                            break;
                        }
                    }
                    else {
                        if (PrgObj.Command == ProgramName) {
                            CurrentProgram = PrgObj;
                            ProgramFound = true;
                            ProName = PrgObj.Name;
                            if (MainInstance != null) { MainInstance.MethodSetRunText(PrgObj.Name); }
                            break;
                        }
                    }
                }
                if (Resulted == true) {
                    if (MainInstance != null) {
                        MainInstance.MethodSetRunText(ProName);
                    }
                }
            }
            if (ProgramFound == false) {
                ProgramState = StepEnumerations.StepState.Stopped;
                ProgramStep = 0;
                Print(ErrorType.M_Warning, "NO_EXE_PRG", "'" + ProgramName + "' is not a vaild registered program name");
            }
            else {
                SetupProgram();
                ProgramStep = 0;
                ProgramState = StepEnumerations.StepState.Running;

            }
        }
        #endregion
        #region Program Initalisation
        public static void SetupProgram() {
            Conditionals.Clear();
            if (CurrentProgram == null) { return; }
            for (int i = 0; i < CurrentProgram.Program.Count; i++) {
                if (CurrentProgram.Program[i].SubItems.Count == 3) {
                    object? TagData = CurrentProgram.Program[i].SubItems[1].Tag;
                    if (TagData != null) {
                        if (TagData.GetType() == typeof(StepEnumerations.StepExecutable)) {
                            if ((StepEnumerations.StepExecutable)TagData == StepEnumerations.StepExecutable.If) {
                                FindConditionalEnd(i);
                            }
                        }
                    }
                }
            }
        }
        public static void FindConditionalEnd(int StartIndex) {
            bool NothingMet = true;
            if (CurrentProgram == null) { return; }
            for (int i = StartIndex; i < CurrentProgram.Program.Count; i++) {
                if (CurrentProgram.Program[i].SubItems.Count == 3) {
                    object? TagData = CurrentProgram.Program[i].SubItems[1].Tag;
                    if (TagData != null) {
                        if (TagData.GetType() == typeof(StepEnumerations.StepExecutable)) {
                            if ((StepEnumerations.StepExecutable)TagData == StepEnumerations.StepExecutable.EndIf) {
                                Conditionals.Add(new ConditionalLinkage(StartIndex, i));
                                NothingMet = false;
                                break;
                            }
                        }
                    }
                }
            }
            if (NothingMet == true) {
                Conditionals.Add(new ConditionalLinkage(StartIndex, CurrentProgram.Program.Count));
            }
        }
        #endregion
        #region Program Execution
        public static void StepProgram() {
            bool CleanAll = false;
            try {
                while (true) {
                    if (CurrentProgram != null) {
                        if(ProgramStep < 0) {
                            ProgramState = StepEnumerations.StepState.Stopped;
                        }
                        if (CurrentProgram.Program.Count > 0) {
                            if (ProgramState == StepEnumerations.StepState.Running) {
                                CleanAll = true;
                                if (ProgramStep < CurrentProgram.Program.Count) {
                                    if (CurrentProgram.Program[ProgramStep].SubItems.Count == 3) {
                                        if (CurrentProgram.Program[ProgramStep].SubItems[0].Checked == true) {
                                            StepEnumerations.StepExecutable Function = StepEnumerations.StepExecutable.NoOperation;
                                            object? objFunction = CurrentProgram.Program[ProgramStep].SubItems[1].Tag;
                                            string objData = CurrentProgram.Program[ProgramStep].SubItems[2].Text;
                                            if (objFunction != null) {
                                                if (objFunction.GetType() == typeof(StepEnumerations.StepExecutable)) {
                                                    Function = (StepEnumerations.StepExecutable)objFunction;
                                                }
                                            }
                                            ExecuteLine(Function, objData);
                                            LastFunction = Function;
                                        }
                                    }
                                    if (NoStepProgramIncrement == false) {
                                        ProgramStep++;
                                    }
                                    else { NoStepProgramIncrement = false; }
                                }
                                else {
                                    ProgramState = StepEnumerations.StepState.Stopped;
                                }
                            }
                            else if (ProgramState == StepEnumerations.StepState.Stopped) {
                                if (CleanAll == true) {
                                    CleanProgramData();
                                    CleanAll = false;
                                }
                            }
                        }
                        else {
                            ProgramState = StepEnumerations.StepState.Stopped;
                        }
                    }
                    else {
                        ProgramState = StepEnumerations.StepState.Stopped;
                    }
                    if (ProgramState != StepEnumerations.StepState.Running) {
                        Thread.Sleep(1);
                    }
                }
            }
            catch (Exception e){
                ProgramState = StepEnumerations.StepState.Stopped;
                Print(ErrorType.M_Error, "PROG_THREAD_DEAD", "The program execution thread has exited due to a caught exception...");
                Print(ErrorType.M_Error, "", e.Message);
            }
            executionThreadRunning = false;
        }
        public static void ExecuteLine(StepEnumerations.StepExecutable Function, string Arguments) {
            switch (Function) {
                case StepEnumerations.StepExecutable.End:
                    ProgramState = StepEnumerations.StepState.Stopped;
                    break;
                case StepEnumerations.StepExecutable.NoOperation:
                    break;
                case StepEnumerations.StepExecutable.Delay:
                    SetDelay(Arguments);
                    break;
                case StepEnumerations.StepExecutable.SwitchSender:
                    CurrentSender = Arguments; break;
                case StepEnumerations.StepExecutable.SendByte:
                    SendByte(Arguments); break;
                case StepEnumerations.StepExecutable.SendString:
                    SendString(Arguments, false); break;
                case StepEnumerations.StepExecutable.SendLine:
                    SendString(Arguments, true); break;
                case StepEnumerations.StepExecutable.SendText:
                    if (File.Exists(Arguments)) {
                        try {
                            using (StreamReader Sr = new StreamReader(Arguments)) {
                                if (Sr != null) {
                                    while (Sr.Peek() > -1) {
                                        string item = Sr.ReadLine() ?? "";
                                        ProgramManager.SendString(item, true);
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                    break;
                case StepEnumerations.StepExecutable.PrintText:
                    if (File.Exists(Arguments)) {
                        try {
                            using (StreamReader Sr = new StreamReader(Arguments)) {
                                if (Sr != null) {
                                    while (Sr.Peek() > -1) {
                                        string item = Sr.ReadLine() ?? "";
                                        Print(ErrorType.M_Notification, "", item);
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                    break;
                case StepEnumerations.StepExecutable.SetProgram:
                    ContinueWithProgram(Arguments);
                    break;
                case StepEnumerations.StepExecutable.Call:
                    Call(Arguments);
                    break;
                case StepEnumerations.StepExecutable.Clear:
                    if (MainInstance != null) { MainInstance.MethodClearing(); }
                    break;
                case StepEnumerations.StepExecutable.Print:
                    if (MainInstance != null) { MainInstance.MethodPrinting(Arguments); }
                    break;
                case StepEnumerations.StepExecutable.PrintVariable:
                    if (MainInstance != null) { MainInstance.MethodPrinting(GetVariable(Arguments)); }
                    break;
                case StepEnumerations.StepExecutable.Open:
                    if (MainInstance != null) {
                        MainInstance.ProgramSerialManagement(Function, Arguments);
                    }
                    break;
                case StepEnumerations.StepExecutable.Close:
                    if (MainInstance != null) {
                        MainInstance.ProgramSerialManagement(Function, Arguments);
                    }
                    break;
                case StepEnumerations.StepExecutable.Label:
                    SetLabel(Arguments);
                    break;
                case StepEnumerations.StepExecutable.DeclareVariable:
                    SetVariable(Arguments); break;
                case StepEnumerations.StepExecutable.IncrementVariable:
                    IncrementDecrementVariable(Arguments, false); break;
                case StepEnumerations.StepExecutable.DecrementVariable:
                    IncrementDecrementVariable(Arguments, true); break;
                case StepEnumerations.StepExecutable.If:
                    EvaluateConditional(Arguments); break;
                case StepEnumerations.StepExecutable.GoTo:
                    GotoLabel(Arguments);
                    break;
                case StepEnumerations.StepExecutable.GoToLine:
                    GotoLine(Arguments);
                    break;
                case StepEnumerations.StepExecutable.MousePosition:
                    //invoke(new MethodInvoker(delegate {
                    SetMousePosition(Arguments);
                    // }));
                    break;
                case StepEnumerations.StepExecutable.MouseLeftClick:
                    //BeginInvoke(new MethodInvoker(delegate {
                    mouse_event(0x02, 0, 0, 0, 0);
                    mouse_event(0x04, 0, 0, 0, 0);
                    //}));
                    break;
                case StepEnumerations.StepExecutable.SendKeys:
                    if (MainInstance != null) {
                        MainInstance.MethodSendKeys(Arguments);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion 
        #region Data Transmission
        public static void SendByte(string Arguments) {
            byte Data = 0x00;
            if (Arguments.ToLower().StartsWith("0x")) {
                try {
                    Data = Byte.Parse(Arguments.Substring(2), NumberStyles.HexNumber);
                }
                catch { }
            }
            else { return; }
            foreach (SerialManager SerMan in SystemManager.SerialManagers) {
                if ((CurrentSender == "") || (CurrentSender.ToLower() == "all")) {
                    SerMan.Post(Data);
                }
                else if (CurrentSender == SerMan.Port.PortName) {
                    SerMan.Post(Data);
                    break;
                }
            }
        }
        public static void SendString(string Arguments, bool WriteLine = false) {
            foreach (SerialManager SerMan in SystemManager.SerialManagers) {
                if ((CurrentSender == "") || (CurrentSender.ToLower() == "all")) {
                    SerMan.Post(Arguments);
                }
                else if (CurrentSender == SerMan.Port.PortName) {
                    SerMan.Post(Arguments, WriteLine);
                    break;
                }
            }
        }

        #endregion
        #region Variables
        public static string GetVariable(string Argument, bool UseInput = false) {
            if (CurrentProgram == null) { return ""; }
            VariableResult VarResult = CurrentProgram.GetVariable(Argument);
            if (VarResult.IsValid == true) {
                return VarResult.Value;
            }
            if (UseInput == true) { return Argument; }
            return "";
        }
        public static void SetVariable(string Arguments) {
            bool ExistsInVariables = false;
            if (!Arguments.Contains('=')) { return; }
            string VarName = Arguments.Split('=')[0];
            string VarValue = StringHandler.SpiltAndCombineAfter(Arguments, '=', 1).Value[1];
            if (CurrentProgram == null) { return; }
            if (CurrentProgram.Variables.Count > 0) {
                for (int i = 0; i < CurrentProgram.Variables.Count; i++) {
                    if (CurrentProgram.Variables[i].Name == VarName) {
                        CurrentProgram.Variables[i].Value = VarValue;
                        ExistsInVariables = true; break;
                    }
                }
            }
            if (ExistsInVariables == false) {
                VariableLinkage LblLink = new VariableLinkage(VarName, VarValue);
                CurrentProgram.Variables.Add(LblLink);
            }
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
        #region Control Flow
        //private delegate void delAddText(string text);
        //private static delAddText safeAddText = new delAddText(AddText);
        private static void Call(string Arguments) {
            ProgramState = StepEnumerations.StepState.Paused;
            RunFromStart(Arguments);
            CleanProgramData();
            SetupProgram();
            NoStepProgramIncrement = true;
        }
        public static void GotoLabel(string Arguments) {
            bool LabelExists = false;
            if (LabelPositions.Count > 0) {
                for (int i = 0; i < LabelPositions.Count; i++) {
                    if (LabelPositions[i].Label == Arguments) {
                        ProgramStep = LabelPositions[i].LineNumber;
                        LabelExists = true; break;
                    }
                }
            }
            if (LabelExists == false) {
                Print(ErrorType.M_Warning, "NO_JMP_LBL", "'" + Arguments + "' could not be found");
            }
        }
        public static void GotoLine(string Arguments) {
            NoStepProgramIncrement = true;
            int TempLineNumber = 0;
            int.TryParse(Arguments, out TempLineNumber);
            ProgramStep = TempLineNumber;
        }
        public static void SetDelay(string Arguments) {
            try {
                int Milliseconds = 1;
                int.TryParse(Arguments, out Milliseconds);
                Thread.Sleep(Milliseconds);
            }
            catch { }
        }
        public static void CleanProgramData() {
            LabelPositions.Clear();
            if (CurrentProgram != null) {
                CurrentProgram.Variables.Clear();
            }
            Conditionals.Clear();
            LastFunction = StepEnumerations.StepExecutable.NoOperation;
        }
        public static void IncrementDecrementVariable(string Argument, bool Decrement) {
            if (CurrentProgram == null) { return; }
            if (CurrentProgram.Variables.Count > 0) {
                for (int i = 0; i < CurrentProgram.Variables.Count; i++) {
                    if (CurrentProgram.Variables[i].Name == Argument) {
                        if (ConversionHandler.IsNumeric(CurrentProgram.Variables[i].Value)) {
                            decimal Value = 0;
                            Decimal.TryParse(CurrentProgram.Variables[i].Value, out Value);
                            Value += Decrement == true ? -1.0m : 1.0m;
                            CurrentProgram.Variables[i].Value = Value.ToString();
                            break;
                        }
                    }
                }
            }
        }
        public static void EvaluateConditional(string Arguments) {
            bool Result = false;
            if (Arguments.Contains(">")) {
                string LeftArg = Arguments.Split('>')[0];
                string RightArg = StringHandler.SpiltAndCombineAfter(Arguments, '>', 1).Value[1];
                string LeftVal = GetVariable(LeftArg, true);
                string RightVal = GetVariable(RightArg, true);
                if (ConversionHandler.IsNumeric(LeftVal) && ConversionHandler.IsNumeric(RightVal)) {
                    decimal LeftDec = 0;
                    decimal RightDec = 0;
                    Decimal.TryParse(LeftVal, out LeftDec);
                    Decimal.TryParse(RightVal, out RightDec);
                    Result = LeftDec > RightDec ? true : false;
                }
            }
            else if (Arguments.Contains("<")) {
                string LeftArg = Arguments.Split('<')[0];
                string RightArg = StringHandler.SpiltAndCombineAfter(Arguments, '<', 1).Value[1];
                string LeftVal = GetVariable(LeftArg, true);
                string RightVal = GetVariable(RightArg, true);
                if (ConversionHandler.IsNumeric(LeftVal) && ConversionHandler.IsNumeric(RightVal)) {
                    decimal LeftDec = 0;
                    decimal RightDec = 0;
                    Decimal.TryParse(LeftVal, out LeftDec);
                    Decimal.TryParse(RightVal, out RightDec);
                    Result = LeftDec < RightDec ? true : false;
                }
            }
            else if (Arguments.Contains("=")) {
                string LeftArg = Arguments.Split('=')[0];
                string RightArg = StringHandler.SpiltAndCombineAfter(Arguments, '=', 1).Value[1];
                string LeftVal = GetVariable(LeftArg, true);
                string RightVal = GetVariable(RightArg, true);
                if (ConversionHandler.IsNumeric(LeftVal) && ConversionHandler.IsNumeric(RightVal)) {
                    decimal LeftDec = 0;
                    decimal RightDec = 0;
                    Decimal.TryParse(LeftVal, out LeftDec);
                    Decimal.TryParse(RightVal, out RightDec);
                    Result = LeftDec == RightDec ? true : false;
                }
                else {
                    Result = LeftVal == RightVal ? true : false;
                }
            }
            if (Result == false) {
                int StartCounter = ProgramManager.ProgramStep;
                foreach (ConditionalLinkage ConLnk in Conditionals) {
                    if (ConLnk.Start == StartCounter) {
                        ProgramManager.ProgramStep = ConLnk.End;
                        break;
                    }
                }
            }
        }

        public static void SetLabel(string Arguments) {
            if (LastFunction != StepEnumerations.StepExecutable.GoTo) {
                bool ExistsInPositions = false;
                if (LabelPositions.Count > 0) {
                    for (int i = 0; i < LabelPositions.Count; i++) {
                        if (LabelPositions[i].Label == Arguments) {
                            ExistsInPositions = true; break;
                        }
                    }
                }
                if (ExistsInPositions == false) {
                    LabelLinkage LblLink = new LabelLinkage(Arguments, ProgramManager.ProgramStep);
                    LabelPositions.Add(LblLink);
                }
            }
        }
        private static void ContinueWithProgram(string ProgramName) {
            StepEnumerations.StepState TempState = ProgramState;
            ProgramState = StepEnumerations.StepState.Paused;
            bool ProgramFound = false;
            if (ProgramName.Length > 0) {
                foreach (ProgramObject PrgObj in Programs) {
                    if (PrgObj.Name == ProgramName) {
                        CurrentProgram = PrgObj;
                        ProgramFound = true;
                        if (MainInstance != null) { MainInstance.MethodSetRunText(PrgObj.Name); }
                        break;
                    }
                }
            }
            if (ProgramFound == false) {
                ProgramState = StepEnumerations.StepState.Stopped;
                ProgramStep = 0;
                Print(ErrorType.M_Warning, "NO_EXE_PRG", "'" + ProgramName + "' is not a vaild registered program name");
            }
            else {
                if (TempState == StepEnumerations.StepState.Running) {
                    SetupProgram();
                    ProgramStep = 0;
                    ProgramState = StepEnumerations.StepState.Stopped;
                    NoStepProgramIncrement = true;
                }
            }

        }
        #endregion
        #region IO Events
        [DllImport("user32")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private static void SetMousePosition(string Arguments) {
            string Args = Arguments.Replace(" ", "");
            if (Args.Contains(",")) {
                string XStr = Args.Split(',')[0];
                string YStr = Args.Split(',')[1];
                int X = 0; int Y = 0;
                int.TryParse(XStr, out X);
                int.TryParse(YStr, out Y);
                Cursor.Position = new Point(X, Y);
            }
        }
        #endregion
        #region Program Editing
        public static DataType StepExeutableToDataType(StepEnumerations.StepExecutable StepExe) {
            switch (StepExe) {
                case StepEnumerations.StepExecutable.Delay:
                    return DataType.Number;
                case StepEnumerations.StepExecutable.SendKeys:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.SendString:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.SendByte:
                    return DataType.Byte;
                case StepEnumerations.StepExecutable.SendLine:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.Print:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.PrintVariable:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.PrintText:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.GoTo:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.GoToLine:
                    return DataType.Number;
                case StepEnumerations.StepExecutable.Call:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.SetProgram:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.Label:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.Open:
                    return DataType.EnumVal;
                case StepEnumerations.StepExecutable.Close:
                    return DataType.EnumVal;
                case StepEnumerations.StepExecutable.SwitchSender:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.DeclareVariable:
                    return DataType.DualString;
                case StepEnumerations.StepExecutable.IncrementVariable:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.DecrementVariable:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.If:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.MousePosition:
                    return DataType.CursorLocation;
                default: return DataType.Null;
            }
        }
        public static bool AcceptsArguments(StepEnumerations.StepExecutable StepExe) {
            if (StepExe == StepEnumerations.StepExecutable.NoOperation) { return false; }
            else if (StepExe == StepEnumerations.StepExecutable.End) { return false; }
            else if (StepExe == StepEnumerations.StepExecutable.EndIf) { return false; }
            else if (StepExe == StepEnumerations.StepExecutable.Clear) { return false; }
            else if (StepExe == StepEnumerations.StepExecutable.Close) { return false; }
            else if (StepExe == StepEnumerations.StepExecutable.MouseLeftClick) { return false; }
            return true;
        }
        public static string CommandDefaultValue(StepEnumerations.StepExecutable StepExe) {
            switch (StepExe) {
                case StepEnumerations.StepExecutable.NoOperation: return "";
                case StepEnumerations.StepExecutable.Delay: return "1000";
                default: return "";
            }
        }
        public static void ChangeSelectedLines(StepEnumerations.StepExecutable StepChange) {
            if (CurrentEditingProgram == null) { return; }
            if (CurrentEditingProgram.Program.Count <= 0) { return; }
            if (CurrentEditingProgram.SelectedCount() <= 0) { return; }
            foreach (ListItem Li in CurrentEditingProgram.Program) {
                if (Li.Selected == true) {
                    Li[2].Tag = StepChange;
                    Li[2].Text = StepExecutableToString((StepEnumerations.StepExecutable)StepChange);
                    Li[3].Text = CommandDefaultValue(StepChange);
                }
            }
            ProgramListingChanged?.Invoke();
        }
        public static void AddCommandLine(StepEnumerations.StepExecutable StepChange) {
            if (CurrentEditingProgram == null) { return; }
            ListItem Lip = new ListItem();
            ListSubItem LiE = new ListSubItem(true);
            ListSubItem LiC = new ListSubItem();
            LiC.Tag = StepChange;
            LiC.Text = StepExecutableToString((StepEnumerations.StepExecutable)StepChange);

            ListSubItem LiA = new ListSubItem();
            LiA.Text = CommandDefaultValue(StepChange);
            Lip.SubItems.Add(LiE);
            Lip.SubItems.Add(LiC);
            Lip.SubItems.Add(LiA);
            CurrentEditingProgram.Program.Add(Lip);
            ProgramListingChanged?.Invoke();
        }
        public static void CommandLine(StepEnumerations.StepExecutable StepChange) {
            if (CurrentEditingProgram == null) { return; }
            if (CurrentEditingProgram.Program.Count > 0) {
                if (CurrentEditingProgram.SelectedCount() > 0) {
                    ChangeSelectedLines(StepChange);
                }
                else {
                    AddCommandLine(StepChange);
                }
            }
            else {
                AddCommandLine(StepChange);
            }
        }
        #endregion
        #region Program Command Connectivity
        public static void ExecuteProgram(string ProgramCommand) {
            if (ProgramCommand.Trim(' ') == "") { return; }
            ProgramState = StepEnumerations.StepState.Paused;
            RunFromStart(ProgramCommand, false);
            CleanProgramData();
            SetupProgram();
            NoStepProgramIncrement = true;
        }
        #endregion
    }
}
