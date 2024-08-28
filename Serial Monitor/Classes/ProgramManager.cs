﻿using Handlers;
using Handlers.ShadowX;
using ODModules;
using Serial_Monitor.Plugin;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.Step_Programs.StepEnumerations;
using DataType = Serial_Monitor.Classes.Step_Programs.DataType;
using System.Text.RegularExpressions;
using System.ComponentModel.Design;
using System.Xml.Linq;
using System.Diagnostics.Eventing.Reader;

namespace Serial_Monitor.Classes {
    public static class ProgramManager {
        public static Thread? ThreadStepExecutable;

        public static event ProgramArrayChangedHandler? ArrayChanged;
        public delegate void ProgramArrayChangedHandler(int Index, bool ItemRemoved);

        public static event ProgramEditorChangedHandler? ProgramEditorChanged;
        public delegate void ProgramEditorChangedHandler(ProgramObject? ProgramObj);

        public static event ProgramVariableChangedHandler? ProgramVariableChanged;
        public delegate void ProgramVariableChangedHandler(ProgramObject? ProgramObj, bool IsGlobal, int Index);

        public static event ProgramSettingChnagedHandler? ProgramSettingChanged;
        public delegate void ProgramSettingChnagedHandler();

        public static event ProgramRemovedHandler? ProgramRemoved;
        public delegate void ProgramRemovedHandler(string ID);
        public static event ProgramListingChangedHandler? ProgramListingChanged;
        public delegate void ProgramListingChangedHandler();
        public static event ProgramNameChangedHandler? ProgramNameChanged;
        public delegate void ProgramNameChangedHandler(object sender);

        public static event ProgramRaisedEventHandler? ProgramEventRaised;
        public delegate void ProgramRaisedEventHandler(ProgramObject? ProgramObj, string Value);
        #region Properties
        private static ProgramObject? currentEditingProgram = null;
        public static ProgramObject? CurrentEditingProgram {
            get { return currentEditingProgram; }
            set {
                currentEditingProgram = value;
                if (currentEditingProgram != null) {
                    ProgramEditorChanged?.Invoke(currentEditingProgram);
                }
                else {
                    ProgramEditorChanged?.Invoke(null);
                }
            }
        }
        static bool enableOverexecuteCheck = false;
        public static bool EnableOverexecuteCheck {
            get { return enableOverexecuteCheck; }
            set {
                enableOverexecuteCheck = value;
            }
        }
        #endregion
        #region State and System Variables
        static StepEnumerations.StepState programState = StepEnumerations.StepState.Stopped;
        static StepEnumerations.StepState PreviousProgramState;
        public static StepEnumerations.StepState ProgramState {
            get { return programState; }
            set {
                PreviousProgramState = programState;
                programState = value;
            }
        }
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

        public static List<ProgramObject> Programs = new List<ProgramObject>(1);

        public static ProgramObject? CurrentProgram = null;

        public static StepEnumerations.StepExecutable CurrentFunction = StepEnumerations.StepExecutable.NoOperation;
        public static StepEnumerations.StepExecutable LastFunction = StepEnumerations.StepExecutable.NoOperation;
        public static List<LabelLinkage> LabelPositions = new List<LabelLinkage>();

        public static List<ConditionalLinkage> Conditionals = new List<ConditionalLinkage>();
        public static string StepExecutableToString(StepEnumerations.StepExecutable StepEx) {
            return StringHandler.MergeStrings(StringHandler.SpiltStringAtCapitals(StepEx.ToString()), ' ');
        }
        #endregion
        public static void ProgramNameChange(object sender) {
            ProgramNameChanged?.Invoke(sender);
        }
        public static void ProgramSettingChange() {
            ProgramSettingChanged?.Invoke();
        }
        #region Threading
        public static void LaunchThread() {
            executionThreadRunning = true;
            ThreadStepExecutable = new Thread(StepProgram);
            ThreadStepExecutable.IsBackground = true;
            ThreadStepExecutable.Start();
        }
        public static void TestThread() {
            if (executionThreadRunning == false) {
                SystemManager.Print(ErrorType.M_Notification, "PROG_THREAD_EXE", "Restarting execution thread...");
                try {
                    LaunchThread();
                }
                catch {
                    SystemManager.Print(ErrorType.M_Notification, "PROG_THREAD_FAIL", "Program thread could not be launched!");
                    executionThreadRunning = false;
                }
            }
        }
        #endregion 
        #region Program Transport
        public static void RunFromStart() {

            ProgramManager.SetupProgram();
            ProgramManager.ProgramStep = 0;
            ProgramManager.ProgramState = StepEnumerations.StepState.Running;
        }
        public static void RunFromStart(string ProgramName, bool UseProgramCommand = false) {
            bool ProgramFound = false;
            if (ProgramName.Length > 0) {
                bool Resulted = false;
                string ProName = "";
                foreach (ProgramObject PrgObj in Programs) {
                    if (UseProgramCommand == false) {
                        if (PrgObj.Name == ProgramName) {
                            CurrentProgram = PrgObj;
                            ProgramFound = true;
                            ProName = PrgObj.Name;
                            if (SystemManager.MainInstance != null) { SystemManager.MainInstance.MethodSetRunText(PrgObj.Name); }
                            break;
                        }
                    }
                    else {
                        if (PrgObj.Command == ProgramName) {
                            CurrentProgram = PrgObj;
                            ProgramFound = true;
                            ProName = PrgObj.Name;
                            if (SystemManager.MainInstance != null) { SystemManager.MainInstance.MethodSetRunText(PrgObj.Name); }
                            break;
                        }
                    }
                }
                if (Resulted == true) {
                    if (SystemManager.MainInstance != null) {
                        SystemManager.MainInstance.MethodSetRunText(ProName);
                    }
                }
            }
            if (ProgramFound == false) {
                ProgramState = StepEnumerations.StepState.Stopped;
                ProgramStep = 0;
                SystemManager.Print(ErrorType.M_Warning, "NO_EXE_PRG", "'" + ProgramName + "' is not a vaild registered program name");
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
            WaitUntil_State = WaitUntilState.Ready;

            if (CurrentProgram == null) { return; }
            FindConditionalEnd();
            LastUICommand = DateTime.UtcNow;
            OverPollCount = 0;
        }
        public static void FindConditionalEnd() {
            Conditionals.Clear();
            LabelPositions.Clear();
            int IfDepth = 0;
            if (CurrentProgram == null) { return; }
            for (int i = 0; i < CurrentProgram.Program.Count; i++) {
                int LastConditional = Conditionals.Count - 1;
                StepExecutable ExeStep = GetStepFunctionFromIndex(i);
                if (ExeStep == StepEnumerations.StepExecutable.EndIf) {
                    try {
                        IfDepth--;
                        SetEndIf(IfDepth, i);
                        //Conditionals[LastConditional - IfDepth].End = i;
                    }
                    catch { }
                }
                else if (ExeStep == StepEnumerations.StepExecutable.If) {
                    Conditionals.Add(new ConditionalLinkage(i, CurrentProgram.Program.Count, IfDepth));
                    IfDepth++;
                }
                else if (ExeStep == StepEnumerations.StepExecutable.Else) {
                    try {
                        if (IfDepth > 0) {
                            SetElse(IfDepth - 1, i);
                            //Conditionals[LastConditional - IfDepth - 1].ElseEnd = i;
                        }
                    }
                    catch { }
                }
                else if (ExeStep == StepExecutable.Label) {
                    BulidGoTos(GetArgumentFromIndex(i), i);
                }
            }
        }
        private static void SetEndIf(int Depth, int EndLine) {
            int LastDepth = 0;
            for (int j = Conditionals.Count - 1; j >= 0; j--) {
                if (Conditionals[j].Depth == Depth) {
                    Conditionals[j].End = EndLine;
                    return;
                }
                if (LastDepth == Conditionals[j].Depth) {
                    break;
                }
                LastDepth = Conditionals[j].Depth;
            }
        }
        private static void SetElse(int Depth, int EndLine) {
            int LastDepth = 0;
            for (int j = Conditionals.Count - 1; j >= 0; j--) {
                if (Conditionals[j].Depth == Depth) {
                    Conditionals[j].ElseEnd = EndLine;
                    return;
                }
                if (LastDepth == Conditionals[j].Depth) {
                    break;
                }
                LastDepth = Conditionals[j].Depth;
            }
        }
        private static StepEnumerations.StepExecutable GetStepFunctionFromIndex(int i) {
            if (CurrentProgram == null) { return StepEnumerations.StepExecutable.NoOperation; }
            if (CurrentProgram.Program[i].SubItems.Count == 3) {
                object? TagData = CurrentProgram.Program[i].SubItems[1].Tag;
                if (TagData == null) { return StepEnumerations.StepExecutable.NoOperation; }
                return (StepEnumerations.StepExecutable)TagData;
            }
            return StepEnumerations.StepExecutable.NoOperation;
        }
        private static string GetArgumentFromIndex(int i) {
            if (CurrentProgram == null) { return ""; }
            if (CurrentProgram.Program[i].SubItems.Count == 3) {
                string? TagData = CurrentProgram.Program[i].SubItems[2].Text;
                if (TagData == null) { return ""; }
                return TagData;
            }
            return "";
        }
        #endregion
        #region Program Execution
        static DateTime LastUICommand = DateTime.UtcNow;
        private static void InvokeSetup() {
            if (ProgramState == StepEnumerations.StepState.Running) {
                if (ProgramState != PreviousProgramState) {
                    FindConditionalEnd();
                }
            }
            PreviousProgramState = ProgramState;
        }
        public static void StepProgram() {
            bool CleanAll = false;
            try {
                while (true) {
                    if (CurrentProgram != null) {
                        InvokeSetup();
                        if (ProgramStep < 0) {
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
                                            CurrentFunction = Function;
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
                    else {
                        if (Properties.Settings.Default.PRG_BOL_LimitExecution1ms == true) {
                            Thread.Sleep(1);
                        }
                    }
                }
            }
            catch (Exception e) {
                ProgramState = StepEnumerations.StepState.Stopped;
                SystemManager.Print(ErrorType.M_Error, "PROG_THREAD_DEAD", "The program execution thread has exited due to a caught exception...");
                SystemManager.Print(ErrorType.M_Error, "", e.Message);
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
                case StepEnumerations.StepExecutable.SendVariable:
                    SendString(GetVariable(Arguments), false); break;
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
                                        SystemManager.Print(ErrorType.M_Notification, "", item);
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
                    ClearTerminal();
                    break;
                case StepEnumerations.StepExecutable.Print:
                    Print(Arguments);
                    break;
                case StepEnumerations.StepExecutable.PrintVariable:
                    Print(GetVariable(Arguments));
                    break;
                case StepEnumerations.StepExecutable.SelectChannel:
                    ProgramSerialManagement(Function, Arguments);
                    break;
                case StepEnumerations.StepExecutable.Open:
                    ProgramSerialManagement(Function, Arguments);
                    break;
                case StepEnumerations.StepExecutable.Close:
                    ProgramSerialManagement(Function, Arguments);
                    break;
                case StepEnumerations.StepExecutable.Label:
                    SetLabel(Arguments);
                    break;
                case StepEnumerations.StepExecutable.DeclareVariable:
                    SetVariable(Arguments); break;
                case StepEnumerations.StepExecutable.CopyText:
                    CopyText(Arguments); break;
                case StepEnumerations.StepExecutable.CopyVariable:
                    CopyVariableValue(Arguments); break;
                case StepEnumerations.StepExecutable.IncrementVariable:
                    IncrementDecrementVariable(Arguments, false); break;
                case StepEnumerations.StepExecutable.DecrementVariable:
                    IncrementDecrementVariable(Arguments, true); break;
                case StepEnumerations.StepExecutable.EvaluateExpression:
                    EvaluateExpression(Arguments); break;
                case StepEnumerations.StepExecutable.RemoveFirstArrayItem:
                    RemoveFirstArrayItem(); break;
                case StepEnumerations.StepExecutable.PushArrayValue:
                    PushArrayValue(Arguments); break;
                case StepEnumerations.StepExecutable.If:
                    EvaluateConditional(Arguments); break;
                case StepEnumerations.StepExecutable.Else:
                    EvatuateElseCondition(); break;
                case StepEnumerations.StepExecutable.GoTo:
                    GotoLabel(Arguments);
                    break;
                case StepEnumerations.StepExecutable.GoToLine:
                    GotoLine(Arguments);
                    break;
                case StepEnumerations.StepExecutable.WaitUntilReceived:
                    EvaluateWaitUntilReceieved(Arguments); break;
                case StepEnumerations.StepExecutable.RaiseEvent:
                    ProgramRaiseEvent(Arguments); break;
                //WaitUntilRaiseEvent
                case StepEnumerations.StepExecutable.WaitUntilRaiseEvent:
                    ProgramRaiseEventOnWait(Arguments); break;
                case StepEnumerations.StepExecutable.MousePosition:
                    //invoke(new MethodInvoker(delegate {
                    SetMousePosition(Arguments);
                    // }));
                    break;
                case StepEnumerations.StepExecutable.MousePositionOffset:
                    //invoke(new MethodInvoker(delegate {
                    SetMousePositionOffset(Arguments);
                    // }));
                    break;
                case StepEnumerations.StepExecutable.MouseLeftClick:
                    //BeginInvoke(new MethodInvoker(delegate {
                    mouse_event(0x02, 0, 0, 0, 0);
                    mouse_event(0x04, 0, 0, 0, 0);
                    //}));
                    break;
                case StepEnumerations.StepExecutable.SendKeys:
                    SendKeys(Arguments);
                    break;
                case StepEnumerations.StepExecutable.ReplaceInVariable:
                    ReplaceInVariable(Arguments);
                    break;
                default:
                    break;
            }
        }
        #endregion
        #region Event Raisers
        private static void ProgramRaiseEvent(string Argument, bool IgnoreVariables = false) {
            string Output = "";
            if (CurrentProgram == null) { return; }
            if (IgnoreVariables == false) {
                VariableResult VarResult = CurrentProgram.GetVariable(Argument);
                if (VarResult.IsValid == true) {
                    Output = VarResult.Value;
                }
                else {
                    if (Argument.ToLower() == "waituntil") {
                        bool Temp = WaitUnit_ConditionMet;
                        WaitUnit_ConditionMet = false;
                        Output = Temp.ToString();
                    }
                    else { Output = Argument; }
                }
            }
            else { Output = Argument; }
            ProgramEventRaised?.Invoke(CurrentProgram, Output);
        }
        private static void ProgramRaiseEventOnWait(string Argument) {
            //Arguments Format Channel, TimeOut, Contains, Value
            if (WaitUntil_State == WaitUntilState.Waiting) {
                if (ConversionHandler.DateIntervalDifference(WaitUntil_TriggerTime, DateTime.UtcNow, ConversionHandler.Interval.Millisecond) >= WaitUntil_Timeout) {
                    NoStepProgramIncrement = false;
                    WaitUntil_State = WaitUntilState.Ready;
                    WaitUnit_ConditionMet = false;
                    return;
                }
                NoStepProgramIncrement = true;
                return;
            }
            else if (WaitUntil_State == WaitUntilState.Finished) {
                NoStepProgramIncrement = false;
                WaitUntil_State = WaitUntilState.Ready;
                return;
            }
            STR_MVSSF Arguments = StringHandler.SpiltAndCombineAfter(Argument, ',', 3);
            if (Arguments.Count < 4) { return; }
            string Channel = StripAwayTag("Channel = ", Arguments.Value[0]);
            string TimeOut = StripAwayTag("TimeOut = ", Arguments.Value[1]);
            string Contains = Arguments.Value[2];
            bool ResultedInChannel = false;
            try {

                foreach (SerialManager SerMan in SystemManager.SerialManagers) {
                    if (SerMan.StateName == Channel) {
                        WaitUntilRx_Channel = SerMan.ID;
                        ResultedInChannel = true;
                        break;
                    }
                }
            }
            catch {
                ResultedInChannel = false;
            }
            if (ResultedInChannel == false) {
                WaitUntilRx_Channel = "";
            }
            WaitUntilRx_Condition = StripAwayTag("Value = ", Arguments.Value[3]);
            int TempTimeout = 1;
            int.TryParse(TimeOut, out TempTimeout);
            if (TempTimeout >= 1) {
                WaitUntil_Timeout = TempTimeout;
            }
            WaitUntil_TriggerTime = DateTime.UtcNow;
            WaitUntil_State = WaitUntilState.Waiting;
            NoStepProgramIncrement = true;
        }
        #endregion
        #region UI Commands
        static ulong OverPollCount = 100;
        private static bool IsExecutionAllowed() {
            if (enableOverexecuteCheck == false) { return true; }
            DateTime Now = DateTime.UtcNow;
            double Result = ConversionHandler.DateIntervalDifference(LastUICommand, Now, ConversionHandler.Interval.Microsecond);
            if (Result > 5000) {
                OverPollCount = 0;
                return true;
            }
            OverPollCount++;
            if (OverPollCount < 500) {
                return true;
            }
            return false;
        }
        private static void ProgramSerialManagement(StepEnumerations.StepExecutable Function, string Arguments) {
            if (IsExecutionAllowed()) {
                if (SystemManager.MainInstance != null) {
                    LastUICommand = DateTime.UtcNow;
                    SystemManager.MainInstance.ProgramSerialManagement(Function, Arguments);
                }
            }
        }
        private static void SendKeys(string Arguments) {
            if (IsExecutionAllowed()) {
                if (SystemManager.MainInstance != null) {
                    LastUICommand = DateTime.UtcNow;
                    SystemManager.MainInstance.MethodSendKeys(Arguments);
                }
            }
        }
        private static void Print(string Arguments) {
            if (IsExecutionAllowed()) {
                if (SystemManager.MainInstance != null) {
                    LastUICommand = DateTime.UtcNow;
                    SystemManager.MainInstance.MethodPrinting(Arguments);
                }
            }
        }
        private static void ClearTerminal() {
            if (IsExecutionAllowed()) {
                if (SystemManager.MainInstance != null) {
                    LastUICommand = DateTime.UtcNow;
                    SystemManager.MainInstance.MethodClearing();

                }
            }
        }
        #endregion
        #region Data Transmission
        static List<StringPair> Lines = new List<StringPair>();
        private static void AttendToLastLine(string Source, string Text, bool CheckForNewLine = true) {
            if (Lines.Count > 0) {
                if ((Lines[Lines.Count - 1].A == Source) ? true : false) {
                    Text = Text.Replace("\0", "");
                    Lines[Lines.Count - 1].B += Text;
                    if (CheckForNewLine) {
                        string line = Lines[Lines.Count - 1].B;
                        line = line.Replace("\u0084", "\n");
                        if (line.Contains('\n')) {
                            line = line.Replace("\r", "");
                            STR_MVSSF list = StringHandler.SpiltStringMutipleValues(line, '\n');
                            if (list.Count == 1) {
                                Lines[Lines.Count - 1].B = list.Value[0];
                            }
                            else if (list.Count > 1) {
                                Lines[Lines.Count - 1].B = list.Value[0];
                                for (int i = 1; i < list.Count; i++) {
                                    Lines.Add(new StringPair(Source, list.Value[i]));
                                }
                            }
                        }
                    }
                }
                else {
                    Lines.Add(new StringPair(Source, Text));
                }
            }
            else {
                Lines.Add(new StringPair(Source, Text));
            }
            if (Lines.Count > 10) {
                try {
                    Lines.RemoveRange(0, 9);
                }
                catch { }
            }
        }
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
                else if (CurrentSender == SerMan.StateName) {
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
                else if (CurrentSender == SerMan.StateName) {
                    SerMan.Post(Arguments, WriteLine);
                    break;
                }
            }
        }

        #endregion
        #region Variables
        public static void SetVariable(string ProgramName, string Name, string Assignment, VariableScope Scope) {
            ProgramObject? Program = GetProgramByName(ProgramName);
            if (Program == null) { return; }
            if (Name.ToLower() == "waituntil") { return; }
            if (Scope == VariableScope.None) { return; }
            VariableResult VarResult = Program.GetVariable(Name);
            if (VarResult.IsValid == true) {
                if ((VarResult.Scope == VariableScope.Global) && (Scope == VariableScope.Global)) {
                    Program.GlobalVariables[VarResult.Index].Value = Assignment;
                    ProgramVariableChanged?.Invoke(CurrentProgram, true, VarResult.Index);
                }
                else if ((VarResult.Scope == VariableScope.Local) && (Scope == VariableScope.Local)) {
                    Program.Variables[VarResult.Index].Value = Assignment;
                    ProgramVariableChanged?.Invoke(CurrentProgram, false, VarResult.Index);
                }
            }
            else {
                if (Scope == VariableScope.Global) {
                    Program.GlobalVariables.Add(new VariableLinkage(Name, Assignment));
                    ProgramVariableChanged?.Invoke(CurrentProgram, true, Program.GlobalVariables.Count - 1);
                }
                else if (Scope == VariableScope.Local) {
                    Program.Variables.Add(new VariableLinkage(Name, Assignment));
                    ProgramVariableChanged?.Invoke(CurrentProgram, false, Program.Variables.Count - 1);
                }
            }
        }
        public static void SetVariable(string Name, string Assignment) {
            ProgramObject? Program = CurrentProgram;
            if (Program == null) { return; }
            if (Name.ToLower() == "waituntil") { return; }
            VariableResult VarResult = Program.GetVariable(Name);
            if (VarResult.IsValid == true) {
                if ((VarResult.Scope == VariableScope.Global)) {
                    Program.GlobalVariables[VarResult.Index].Value = Assignment;
                    ProgramVariableChanged?.Invoke(CurrentProgram, true, VarResult.Index);
                }
                else if ((VarResult.Scope == VariableScope.Local)) {
                    Program.Variables[VarResult.Index].Value = Assignment;
                    ProgramVariableChanged?.Invoke(CurrentProgram, false, VarResult.Index);
                }
            }
            else {
                Program.Variables.Add(new VariableLinkage(Name, Assignment));
                ProgramVariableChanged?.Invoke(CurrentProgram, false, Program.Variables.Count - 1);
            }
        }
        public static void SetVariable(string ProgramName, string Name, string Assignment) {
            SetVariable(ProgramName, Name, Assignment, VariableScope.Global);
        }
        private static ProgramObject? GetProgramByName(string Name) {
            try {
                foreach (ProgramObject Prg in Programs) {
                    if (Prg.Name == Name) {
                        return Prg;
                    }
                }
            }
            catch { }
            return null;
        }
        public static string GetVariable(string Argument, bool UseInput = false) {
            if (CurrentProgram == null) { return ""; }
            VariableResult VarResult = CurrentProgram.GetVariable(Argument);
            if (VarResult.IsValid == true) {
                return VarResult.Value;
            }
            if (Argument.ToLower() == "waituntil") {
                bool Temp = WaitUnit_ConditionMet;
                WaitUnit_ConditionMet = false;
                return Temp.ToString();
            }
            if (UseInput == true) { return Argument; }
            return "";
        }
        public static ReplaceTextObject ReplaceAndAssign(string Arguments) {
            ReplaceTextObject Output = new ReplaceTextObject();
            Output.IsValid = false;
            if (CurrentProgram == null) { return Output; }
            string VarName = Arguments.Split('=')[0];
            if (!Arguments.Contains('=')) { return Output; }
            string Assignment = StringHandler.SpiltAndCombineAfter(Arguments, '=', 1).Value[1];
            if (!Assignment.EndsWith(')')) { return Output; }
            if (!Assignment.Contains(".Replace(")) { return Output; }
            //\.Replace\(.*\)
            string[] Values = Assignment.Split(new string[] { ".Replace(" }, StringSplitOptions.None);
            if (Values.Length < 2) { return Output; }
            else if (Values.Length == 2) {
                Output.Output = VarName;
                Output.Input = Values[0];
                string[] Args = Values[1].Split(new string[] { "\",\"" }, StringSplitOptions.None);
                if (Args.Length < 2) { return Output; }
                if ((Args[0].StartsWith("\"")) && (Args[1].EndsWith("\")"))) {
                    Output.TextToReplace = Args[0].Remove(0, 1);
                    Output.ReplaceWith = Args[1].Remove(Args[1].Length - 2, 2);
                    Output.IsValid = true;
                }
            }
            return Output;
        }
        private static void ReplaceInVariable(string Argument) {
            if (CurrentProgram == null) { return; }
            ReplaceTextObject Arguments = ReplaceAndAssign(Argument);
            Arguments.Input = GetVariable(Arguments.Input, true);
            Arguments.TextToReplace = GetVariable(Arguments.TextToReplace, true);
            Arguments.ReplaceWith = GetVariable(Arguments.ReplaceWith, true);
            if ((Arguments.TextToReplace.Length <= 0) || (Arguments.ReplaceWith.Length <= 0)) {
                SetVariable(Arguments.Output, Arguments.Input);
            }
            else {
                string NewString = Arguments.Input.Replace(Arguments.TextToReplace, Arguments.ReplaceWith);
                SetVariable(Arguments.Output, NewString);
            }
        }
        public static string PackageReplace(string Assignment, string Input, string ReplaceCue, string ReplaceWith) {
            return Assignment + "=" + Input + ".Replace(" + StringHandler.EncapsulateString(ReplaceCue) + "," + StringHandler.EncapsulateString(ReplaceWith) + ")";
        }
        public static void CopyVariableValue(string Argument) {
            if (SystemManager.MainInstance != null) {
                SystemManager.MainInstance.MethodCopying(GetVariable(Argument, false));
            }
        }
        public static void CopyText(string Argument) {
            if (SystemManager.MainInstance != null) {
                SystemManager.MainInstance.MethodCopying(Argument);
            }
        }
        public static void SetVariable(string Arguments) {
            if (!Arguments.Contains('=')) { return; }
            string VarName = Arguments.Split('=')[0];
            string VarValue = StringHandler.SpiltAndCombineAfter(Arguments, '=', 1).Value[1];
            if (CurrentProgram == null) { return; }
            bool ExistsInVariables = SetVariableInScope(VarName, VarValue);
            if (ExistsInVariables == false) {
                VariableLinkage LblLink = new VariableLinkage(VarName, VarValue);
                CurrentProgram.Variables.Add(LblLink);
                ProgramVariableChanged?.Invoke(CurrentProgram, false, CurrentProgram.Variables.Count - 1);
            }
        }
        private static bool SetVariableInScope(string Name, string Value) {
            bool ExistsInVariables = false;
            if (CurrentProgram == null) { return ExistsInVariables; }
            if (CurrentProgram.GlobalVariables.Count > 0) {
                for (int i = 0; i < CurrentProgram.GlobalVariables.Count; i++) {
                    if (CurrentProgram.GlobalVariables[i].Name == Name) {
                        CurrentProgram.GlobalVariables[i].Value = Value;
                        ProgramVariableChanged?.Invoke(CurrentProgram, true, i);
                        return true;
                    }
                }
            }
            if (CurrentProgram.Variables.Count > 0) {
                for (int i = 0; i < CurrentProgram.Variables.Count; i++) {
                    if (CurrentProgram.Variables[i].Name == Name) {
                        CurrentProgram.Variables[i].Value = Value;
                        ProgramVariableChanged?.Invoke(CurrentProgram, false, i);
                        return true;
                    }
                }
            }
            return ExistsInVariables;
        }
        public static void RemoveFirstArrayItem() {
            if (CurrentProgram == null) { return; }
            if (CurrentProgram.Array.Count > 1) {
                CurrentProgram.Array.RemoveAt(0);
                ArrayChanged?.Invoke(0, true);
            }
        }
        public static void PushArrayValue(string Argument) {
            if (CurrentProgram == null) { return; }
            string VarName = Argument.Split('=')[0];
            string VarExpression = StringHandler.SpiltAndCombineAfter(Argument, '=', 1).Value[1];
            VariableLinkage? Assignment = GetVariableAssignment(VarName.Trim(' '));
            if (Assignment == null) { return; }
            List<string> Vars = Handlers.MathHandler.ExtractVariablesFromExpression(VarExpression.Replace('=', (char)0x01));
            List<VariableResult> VarResult = GetVariables(Vars);
            bool StringExpression = IsStringExpression(VarResult);
            if (StringExpression == false) {
                int Temp = -1; int.TryParse(MathHandler.EvaluateExpression(VarExpression, ConvertVariables(VarResult)).ToString(), out Temp);
                if ((Temp >= 0) && (Temp < CurrentProgram.Array.Count)) {
                    if (CurrentProgram.Array.Count > 0) {
                        Assignment.Value = CurrentProgram.Array[Temp];
                    }
                }
            }
        }
        public static void EvaluateExpression(string Argument) {
            if (CurrentProgram == null) { return; }
            string VarName = Argument.Split('=')[0];
            string VarExpression = StringHandler.SpiltAndCombineAfter(Argument, '=', 1).Value[1];
            VariableLinkage? Assignment = GetVariableAssignment(VarName.Trim(' '));
            if (Assignment == null) { return; }
            List<string> Vars = Handlers.MathHandler.ExtractVariablesFromExpression(VarExpression.Replace('=', (char)0x01));
            List<VariableResult> VarResult = GetVariables(Vars);
            bool StringExpression = IsStringExpression(VarResult);
            if (StringExpression) {
                string Output = "";
                STR_MVSSF Spilts = StringHandler.SpiltStringMutipleValues(VarExpression, '+');
                foreach (string Str in Spilts.Value) {
                    int Index = GetVariableIndex(VarResult, Str.Replace((char)0x01, '=').Trim(' '));
                    if (Index >= 0) {
                        Output += VarResult[Index].Value;
                    }
                    else {
                        Output += Str;
                    }
                }
                Assignment.Value = Output;
            }
            else {
                Assignment.Value = MathHandler.EvaluateExpression(VarExpression, ConvertVariables(VarResult)).ToString();
            }
        }
        private static int GetVariableIndex(List<VariableResult> VarResult, string Name) {
            int Index = 0;
            foreach (VariableResult Var in VarResult) {
                if (Var.Name == Name) { return Index; }
                Index++;
            }
            return -1;
        }
        private static List<MathVariable> ConvertVariables(List<VariableResult> Results) {
            List<MathVariable> Variables = new List<MathVariable>();
            foreach (VariableResult Result in Results) {
                Variables.Add(new MathVariable(Result.Name, Result.Value));
            }
            return Variables;
        }
        private static VariableLinkage? GetVariableAssignment(string Argument) {
            if (CurrentProgram == null) { return null; }
            if (CurrentProgram.GlobalVariables.Count > 0) {
                for (int i = 0; i < CurrentProgram.GlobalVariables.Count; i++) {
                    if (CurrentProgram.GlobalVariables[i].Name == Argument) {
                        return CurrentProgram.GlobalVariables[i];
                    }
                }
            }
            if (CurrentProgram.Variables.Count > 0) {
                for (int i = 0; i < CurrentProgram.Variables.Count; i++) {
                    if (CurrentProgram.Variables[i].Name == Argument) {
                        return CurrentProgram.Variables[i];
                    }
                }
            }
            return null;
        }
        private static List<VariableResult> GetVariables(List<string> Vars) {
            List<VariableResult> VarResult = new List<VariableResult>();
            if (CurrentProgram == null) { return VarResult; }
            foreach (string Var in Vars) {
                VarResult.Add(CurrentProgram.GetVariable(Var));
            }
            return VarResult;
        }
        private static bool IsStringExpression(List<VariableResult> VarResult) {
            if (CurrentProgram == null) { return false; }
            bool IsStringExp = false;
            foreach (VariableResult Var in VarResult) {
                if (ConversionHandler.IsNumeric(Var.Value) == false) { IsStringExp = true; break; }
            }
            return IsStringExp;
        }
        #endregion

        #region Control Flow
        //private delegate void delAddText(string text);
        //private static delAddText safeAddText = new delAddText(AddText);

        private static int WaitUntil_Timeout = 1;
        private static string WaitUntilRx_Condition = "";
        private static string WaitUntilRx_Channel = "";
        private static DateTime WaitUntil_TriggerTime = DateTime.UtcNow;

        private static bool WaitUntil_Contains = true;

        private static bool WaitUnit_ConditionMet = false;
        private static WaitUntilState WaitUntil_State = WaitUntilState.Ready;
        private enum WaitUntilState {
            Ready = 0x00,
            Waiting = 0x01,
            Finished = 0x02
        }
        public static void ProgramDataReceived(string ChannelID, string Value) {
            if (WaitUntil_State != WaitUntilState.Waiting) { return; }
            AttendToLastLine(ChannelID, Value);
            if (Lines.Count == 0) { return; }
            try {
                if (WaitUntilRx_Channel == "") {
                    if (WaitUntil_Contains) {
                        if (Lines[Lines.Count - 1].B.Contains(WaitUntilRx_Condition)) {
                            WaitUntil_State = WaitUntilState.Finished;
                            WaitUnit_ConditionMet = true;
                            try {
                                if (CurrentFunction == StepExecutable.WaitUntilRaiseEvent) {
                                    ProgramRaiseEvent(Lines[Lines.Count - 1].B, true);
                                }
                                Lines.RemoveAt(Lines.Count - 1);
                            }
                            catch { }
                        }
                    }
                    else {
                        if (Lines[Lines.Count - 1].B == WaitUntilRx_Condition) {
                            WaitUntil_State = WaitUntilState.Finished;
                            WaitUnit_ConditionMet = true;
                            try {
                                if (CurrentFunction == StepExecutable.WaitUntilRaiseEvent) {
                                    ProgramRaiseEvent(Lines[Lines.Count - 1].B, true);
                                }
                                Lines.RemoveAt(Lines.Count - 1);
                            }
                            catch { }
                        }
                    }
                }
                else {
                    if (ChannelID == WaitUntilRx_Channel) {
                        for (int i = Lines.Count - 1; i >= 0; i--) {
                            if (WaitUntil_Contains) {
                                if (Lines[i].B.Contains(WaitUntilRx_Condition)) {
                                    WaitUntil_State = WaitUntilState.Finished;
                                    WaitUnit_ConditionMet = true;
                                    try {
                                        if (CurrentFunction == StepExecutable.WaitUntilRaiseEvent) {
                                            ProgramRaiseEvent(Lines[i].B, true);
                                        }
                                        Lines.RemoveAt(i);
                                    }
                                    catch { }
                                }
                            }
                            else {
                                if (Lines[i].B == WaitUntilRx_Condition) {
                                    WaitUntil_State = WaitUntilState.Finished;
                                    WaitUnit_ConditionMet = true;
                                    try {
                                        if (CurrentFunction == StepExecutable.WaitUntilRaiseEvent) {
                                            ProgramRaiseEvent(Lines[i].B, true);
                                        }
                                        Lines.RemoveAt(i);
                                    }
                                    catch { }
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private static void EvaluateWaitUntilReceieved(string Argument) {
            //Arguments Format Channel, TimeOut, Contains, Value
            if (WaitUntil_State == WaitUntilState.Waiting) {
                if (ConversionHandler.DateIntervalDifference(WaitUntil_TriggerTime, DateTime.UtcNow, ConversionHandler.Interval.Millisecond) >= WaitUntil_Timeout) {
                    NoStepProgramIncrement = false;
                    WaitUntil_State = WaitUntilState.Ready;
                    WaitUnit_ConditionMet = false;
                    return;
                }
                NoStepProgramIncrement = true;
                return;
            }
            else if (WaitUntil_State == WaitUntilState.Finished) {
                NoStepProgramIncrement = false;
                WaitUntil_State = WaitUntilState.Ready;
                return;
            }
            STR_MVSSF Arguments = StringHandler.SpiltAndCombineAfter(Argument, ',', 3);
            if (Arguments.Count < 4) { return; }
            string Channel = StripAwayTag("Channel = ", Arguments.Value[0]);
            string TimeOut = StripAwayTag("TimeOut = ", Arguments.Value[1]);
            string Contains = Arguments.Value[2];
            bool ResultedInChannel = false;
            try {

                foreach (SerialManager SerMan in SystemManager.SerialManagers) {
                    if (SerMan.StateName == Channel) {
                        WaitUntilRx_Channel = SerMan.ID;
                        ResultedInChannel = true;
                        break;
                    }
                }
            }
            catch {
                ResultedInChannel = false;
            }
            if (ResultedInChannel == false) {
                WaitUntilRx_Channel = "";
            }
            WaitUntilRx_Condition = StripAwayTag("Value = ", Arguments.Value[3]);
            int TempTimeout = 1;
            int.TryParse(TimeOut, out TempTimeout);
            if (TempTimeout >= 1) {
                WaitUntil_Timeout = TempTimeout;
            }
            WaitUntil_TriggerTime = DateTime.UtcNow;
            WaitUntil_State = WaitUntilState.Waiting;
            NoStepProgramIncrement = true;
        }
        public static string StripAwayTag(string Tag, string Input) {
            if (Input.Contains(Tag)) {
                return Input.Remove(0, Tag.Length);
            }
            return Input;
        }
        private static void Call(string Arguments) {
            ProgramState = StepEnumerations.StepState.Paused;
            CleanProgramData();
            NoStepProgramIncrement = true;
            RunFromStart(Arguments, false);
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
                SystemManager.Print(ErrorType.M_Warning, "NO_JMP_LBL", "'" + Arguments + "' could not be found");
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
            if (CurrentProgram.GlobalVariables.Count > 0) {
                for (int i = 0; i < CurrentProgram.GlobalVariables.Count; i++) {
                    if (CurrentProgram.GlobalVariables[i].Name == Argument) {
                        if (ConversionHandler.IsNumeric(CurrentProgram.GlobalVariables[i].Value)) {
                            decimal Value = 0;
                            Decimal.TryParse(CurrentProgram.GlobalVariables[i].Value, out Value);
                            Value += Decrement == true ? -1.0m : 1.0m;
                            CurrentProgram.GlobalVariables[i].Value = Value.ToString();
                            ProgramVariableChanged?.Invoke(CurrentProgram, true, i);
                            break;
                        }
                    }
                }
            }
            if (CurrentProgram.Variables.Count > 0) {
                for (int i = 0; i < CurrentProgram.Variables.Count; i++) {
                    if (CurrentProgram.Variables[i].Name == Argument) {
                        if (ConversionHandler.IsNumeric(CurrentProgram.Variables[i].Value)) {
                            decimal Value = 0;
                            Decimal.TryParse(CurrentProgram.Variables[i].Value, out Value);
                            Value += Decrement == true ? -1.0m : 1.0m;
                            CurrentProgram.Variables[i].Value = Value.ToString();
                            ProgramVariableChanged?.Invoke(CurrentProgram, false, i);
                            return;
                        }
                    }
                }
            }
        }
        public static void EvaluateConditional(string Arguments) {
            bool Result = EvaluateSmallCondition(Arguments);
            if (Result == false) {
                int StartCounter = ProgramManager.ProgramStep;
                foreach (ConditionalLinkage ConLnk in Conditionals) {
                    if (ConLnk.Start == StartCounter) {
                        if (ConLnk.ElseEnd == -1) {
                            ProgramManager.ProgramStep = ConLnk.End;
                        }
                        else {
                            ProgramManager.ProgramStep = ConLnk.ElseEnd;
                        }
                        break;
                    }
                }
            }
        }
        private static void EvatuateElseCondition() {
            if (LastFunction == StepExecutable.If) { return; }
            int StartCounter = ProgramManager.ProgramStep;
            foreach (ConditionalLinkage ConLnk in Conditionals) {
                if (ConLnk.ElseEnd == StartCounter) {
                    ProgramManager.ProgramStep = ConLnk.End;
                    break;
                }
            }
        }
        private static bool EvaluateSmallCondition(string Arguments) {
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
            return Result;
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
        private static void BulidGoTos(string LabelName, int LabelIndex) {
            bool ExistsInPositions = false;
            if (LabelPositions.Count > 0) {
                for (int i = 0; i < LabelPositions.Count; i++) {
                    if (LabelPositions[i].Label == LabelName) {
                        ExistsInPositions = true; break;
                    }
                }
            }
            if (ExistsInPositions == false) {
                LabelLinkage LblLink = new LabelLinkage(LabelName, LabelIndex);
                LabelPositions.Add(LblLink);
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
                        if (SystemManager.MainInstance != null) { SystemManager.MainInstance.MethodSetRunText(PrgObj.Name); }
                        break;
                    }
                }
            }
            if (ProgramFound == false) {
                ProgramState = StepEnumerations.StepState.Stopped;
                ProgramStep = 0;
                SystemManager.Print(ErrorType.M_Warning, "NO_EXE_PRG", "'" + ProgramName + "' is not a vaild registered program name");
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
        private static void SetMousePositionOffset(string Arguments) {
            string Args = Arguments.Replace(" ", "");
            if (Args.Contains(",")) {
                string XStr = Args.Split(',')[0];
                string YStr = Args.Split(',')[1];
                int X = 0; int Y = 0;
                int.TryParse(XStr, out X);
                int.TryParse(YStr, out Y);
                Point Temp = Cursor.Position;
                Cursor.Position = new Point(Temp.X + X, Temp.Y + Y);
            }
        }
        #endregion
        #region Program Arguments and Commands
        public static DataType StepExecutableToDataType(StepEnumerations.StepExecutable StepExe) {
            switch (StepExe) {
                case StepEnumerations.StepExecutable.Delay:
                    return DataType.Number;
                case StepEnumerations.StepExecutable.SendVariable:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.CopyVariable:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.CopyText:
                    return DataType.Text;
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
                case StepEnumerations.StepExecutable.SelectChannel:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.Open:
                    return DataType.EnumVal;
                //case StepEnumerations.StepExecutable.Close:
                //    return DataType.EnumVal;
                case StepEnumerations.StepExecutable.SwitchSender:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.DeclareVariable:
                    return DataType.DualString;
                case StepEnumerations.StepExecutable.IncrementVariable:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.DecrementVariable:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.EvaluateExpression:
                    return DataType.DualString;
                case StepEnumerations.StepExecutable.PushArrayValue:
                    return DataType.DualString;
                case StepEnumerations.StepExecutable.If:
                    return DataType.Text;
                case StepEnumerations.StepExecutable.MousePosition:
                    return DataType.CursorLocation;
                case StepEnumerations.StepExecutable.MousePositionOffset:
                    return DataType.CursorLocation;
                case StepEnumerations.StepExecutable.WaitUntilReceived:
                    return DataType.WaitUntilRX;
                case StepEnumerations.StepExecutable.WaitUntilRaiseEvent:
                    return DataType.WaitUntilRX;
                case StepEnumerations.StepExecutable.ReplaceInVariable:
                    return DataType.ReplaceText;
                case StepEnumerations.StepExecutable.RaiseEvent:
                    return DataType.Text;
                default: return DataType.Null;
            }
        }
        public static StepKeyWordType StepExecutableToKeyWordType(StepExecutable StepExe) {
            switch (StepExe) {
                case StepEnumerations.StepExecutable.If:
                    return StepKeyWordType.ControlFlow;
                case StepEnumerations.StepExecutable.Else:
                    return StepKeyWordType.ControlFlow;
                case StepEnumerations.StepExecutable.EndIf:
                    return StepKeyWordType.ControlFlow;
                case StepEnumerations.StepExecutable.End:
                    return StepKeyWordType.ReturnsAndCalls;
                case StepEnumerations.StepExecutable.Call:
                    return StepKeyWordType.ReturnsAndCalls;
                case StepEnumerations.StepExecutable.GoTo:
                    return StepKeyWordType.ReturnsAndCalls;
                case StepEnumerations.StepExecutable.GoToLine:
                    return StepKeyWordType.ReturnsAndCalls;
                case StepEnumerations.StepExecutable.Label:
                    return StepKeyWordType.ReturnsAndCalls;
                case StepExecutable.DeclareVariable:
                    return StepKeyWordType.VariableDeclaration;
                default:
                    return StepKeyWordType.Normal;
            }
        }
        public static bool AcceptsArguments(StepEnumerations.StepExecutable StepExe) {
            DataType CmdType = StepExecutableToDataType(StepExe);
            if (CmdType == DataType.Null) { return false; }
            return true;
            //if (StepExe == StepEnumerations.StepExecutable.NoOperation) { return false; }
            //else if (StepExe == StepEnumerations.StepExecutable.End) { return false; }
            //else if (StepExe == StepEnumerations.StepExecutable.EndIf) { return false; }
            //else if (StepExe == StepEnumerations.StepExecutable.Clear) { return false; }
            //else if (StepExe == StepEnumerations.StepExecutable.Close) { return false; }
            //else if (StepExe == StepEnumerations.StepExecutable.MouseLeftClick) { return false; }
            //return true;
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
        #endregion
        #region Program Editing
        public static void AddCommandLine(StepEnumerations.StepExecutable StepChange) {
            if (CurrentEditingProgram == null) { return; }
            ListItem Lip = new ListItem();
            ListSubItem LiE = new ListSubItem(true);
            ListSubItem LiC = new ListSubItem();
            LiC.Tag = StepChange;
            LiC.Text = StepExecutableToString(StepChange);

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
            if (SystemManager.MainInstance != null) {
                ApplySyntaxColouring(SystemManager.MainInstance.lstStepProgram, -1, true);
                ApplyIndentation(SystemManager.MainInstance.lstStepProgram);
            }

        }
        internal static void ArrangeProgramOrderings(TabHeader thPrograms) {
            int Index = 0;
            foreach (Tab TabPrg in thPrograms.Tabs) {
                if (TabPrg.Tag != null) {
                    if (TabPrg.Tag.GetType() == typeof(ProgramObject)) {
                        ((ProgramObject)TabPrg.Tag).DisplayIndex = Index;
                        Index++;
                    }
                }
            }
            Programs = Programs.OrderBy(x => x.DisplayIndex).ToList();
        }
        internal static void UpdateProgramNames(TabHeader thPrograms) {
            int j = 0;
            foreach (ProgramObject Prg in ProgramManager.Programs) {
                if (Prg.Name.Trim().Length == 0) {
                    Prg.UntitledProgramNmber = j;
                    j++;
                }
                else {
                    Prg.UntitledProgramNmber = -1;
                }
            }
            string LocalisatedText = LocalisationManager.GetLocalisedText("untitledProgram", "Untitled Program");
            if (thPrograms.Tabs.Count > 0) {
                foreach (Tab Tb in thPrograms.Tabs) {
                    if (Tb.Tag != null) {
                        if (Tb.Tag.GetType() == typeof(ProgramObject)) {
                            ProgramObject PrObj = (ProgramObject)Tb.Tag;
                            if (PrObj.UntitledProgramNmber >= 1) {
                                Tb.Text = LocalisatedText + " " + PrObj.UntitledProgramNmber.ToString();
                            }
                            else if (PrObj.UntitledProgramNmber == 0) {
                                Tb.Text = LocalisatedText;
                            }
                            else {
                                Tb.Text = PrObj.Name;
                            }
                        }
                    }
                }
            }
        }

        #endregion
        #region Program Transport
        internal static void SetCursorAtSelected(ODModules.ListControl? ProgramEditor) {
            if (ProgramEditor == null) { return; }
            if (ProgramEditor.SelectionCount == 1) {
                if (CurrentProgram != null) {
                    if (CurrentProgram == ProgramEditor.Tag) {
                        CurrentProgram.ProgramMarker = ProgramEditor.SelectedIndex;
                    }
                }
                ProgramEditor.LineMarkerIndex = ProgramEditor.SelectedIndex;
                if (ProgramEditor.Tag != null) {
                    if (ProgramEditor.Tag.GetType() == typeof(ProgramObject)) {
                        ((ProgramObject)ProgramEditor.Tag).ProgramMarker = ProgramEditor.SelectedIndex;
                    }
                }
            }
        }
        internal static void SetCursorAtIndex(ODModules.ListControl? ProgramEditor, int Index) {
            if (ProgramEditor == null) { return; }
            if (CurrentProgram != null) {
                ProgramEditor.LineMarkerIndex = Index;
                CurrentProgram.ProgramMarker = Index;
            }
        }
        internal static void Run(ODModules.ListControl? ProgramEditor) {
            if (ProgramEditor == null) { return; }
            TestThread();
            if (CurrentProgram == null) { return; }
            if (CurrentProgram == ProgramEditor.Tag) {
                if (CurrentProgram.ProgramMarker >= CurrentProgram.Program.Count) {
                    RunFromStart();
                }
                else {
                    SetupProgram();
                    ProgramStep = CurrentProgram.ProgramMarker;
                    ProgramState = StepState.Running;
                }
            }
        }
        public static void RunProgramFromStart() {
            TestThread();
            RunFromStart();
        }
        public static void StopProgram() {
            ProgramState = StepState.Stopped;
            ProgramStep = 0;
        }
        public static void PauseProgram() {
            ProgramState = StepState.Paused;
        }
        #endregion
        #region Program Command Connectivity
        public static void ExecuteProgram(string ProgramCommand) {
            if (ProgramCommand.Trim(' ') == "") { return; }
            ProgramState = StepEnumerations.StepState.Paused;
            TestThread();
            CleanProgramData();
            //SetupProgram();
            RunFromStart(ProgramCommand, true);
        }
        #endregion
        #region Program Removing
        public static void RemoveProgram(int Index) {
            ProgramRemoved?.Invoke(Programs[Index].ID);
            Programs[Index].Clear();
            Programs.RemoveAt(Index);
        }
        public static void RemoveProgram(ProgramObject Objct) {
            ProgramRemoved?.Invoke(Objct.ID);
            Objct.Clear();
            Programs.Remove(Objct);
        }
        #endregion
        #region Formatters
        private static void ApplyColorColumnProperty(ODModules.ListControl lstStepProgram, bool Enabled) {
            foreach (Column Col in lstStepProgram.Columns) {
                Col.UseItemForeColor = Enabled;
            }
        }
        static bool IsSyntaxColoured = false;
        public static void ApplySyntaxColouring(ODModules.ListControl lstStepProgram, int Index = -1, bool ForceApply = false) {
            if (Properties.Settings.Default.PRG_BOL_SyntaxHighlighting == false) {
                if (IsSyntaxColoured == true) {
                    ApplyColorColumnProperty(lstStepProgram, false);
                    lstStepProgram.Invalidate();
                }
                IsSyntaxColoured = false;
                return;
            }
            if ((IsSyntaxColoured != Properties.Settings.Default.PRG_BOL_SyntaxHighlighting) || (ForceApply == true)) {
                ApplyColorColumnProperty(lstStepProgram, true);
                IsSyntaxColoured = true;
                for (int i = 0; i < lstStepProgram.CurrentItems.Count; i++) {
                    ApplySyntaxColor(lstStepProgram, i);
                }
                lstStepProgram.Invalidate();
                return;
            }
            IsSyntaxColoured = true;
            ApplySyntaxColor(lstStepProgram, Index);
            lstStepProgram.Invalidate();
        }
        private static void ApplySyntaxColor(ODModules.ListControl lstStepProgram, int Index) {
            if (Index < 0) { return; }
            if (lstStepProgram.CurrentItems.Count == 0) { return; }
            if (Index >= lstStepProgram.CurrentItems.Count) { return; }
            bool IsNotCommented = lstStepProgram.CurrentItems[Index][1].Checked;
            object? objTag = lstStepProgram.CurrentItems[Index][2].Tag;
            StepEnumerations.StepExecutable StepExe = StepEnumerations.StepExecutable.NoOperation;
            if (objTag != null) {
                if (objTag.GetType() == typeof(StepEnumerations.StepExecutable)) {
                    StepExe = (StepEnumerations.StepExecutable)objTag;
                }
            }
            for (int i = 0; i < lstStepProgram.Columns.Count; i++) {
                if (IsNotCommented == false) {
                    lstStepProgram.CurrentItems[Index][i].ForeColor = Properties.Settings.Default.THM_COL_CommentColor;
                }
                else {
                    if (i < lstStepProgram.Columns.Count - 1) {
                        StepEnumerations.StepKeyWordType KeywordType = ProgramManager.StepExecutableToKeyWordType(StepExe);

                        if (KeywordType == StepEnumerations.StepKeyWordType.ControlFlow) {
                            lstStepProgram.CurrentItems[Index][i].ForeColor = Properties.Settings.Default.THM_COL_KeyWordColor;
                        }
                        else if (KeywordType == StepEnumerations.StepKeyWordType.ReturnsAndCalls) {
                            lstStepProgram.CurrentItems[Index][i].ForeColor = Properties.Settings.Default.THM_COL_ReturnsAndCalls;
                        }
                        else if (KeywordType == StepEnumerations.StepKeyWordType.VariableDeclaration) {
                            lstStepProgram.CurrentItems[Index][i].ForeColor = Properties.Settings.Default.THM_COL_VariablesColor;
                        }
                        else {
                            lstStepProgram.CurrentItems[Index][i].ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                        }
                    }
                    else {
                        lstStepProgram.CurrentItems[Index][i].ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                    }
                }

            }
        }
        public static void ApplyIndentation(ODModules.ListControl lstStepProgram, bool Redraw = true) {
            if (Properties.Settings.Default.PRG_BOL_CommandIndentation == false) {
                lstStepProgram.ShowItemIndentation = false;
                if (Redraw) {
                    lstStepProgram.Invalidate();
                }
                return;
            }
            uint Indent = 0;
            for (int i = 0; i < lstStepProgram.CurrentItems.Count; i++) {
                if (lstStepProgram.CurrentItems[i].SubItems.Count != 3) { continue; }
                object? objTag = lstStepProgram.CurrentItems[i][2].Tag;
                bool IsCommented = !lstStepProgram.CurrentItems[i][1].Checked;
                StepEnumerations.StepExecutable StepExe = StepEnumerations.StepExecutable.NoOperation;
                if (objTag != null) {
                    if (objTag.GetType() == typeof(StepEnumerations.StepExecutable)) {
                        StepExe = (StepEnumerations.StepExecutable)objTag;
                    }
                }
                StepEnumerations.StepKeyWordType KeywordType = ProgramManager.StepExecutableToKeyWordType(StepExe);

                if (KeywordType == StepEnumerations.StepKeyWordType.ControlFlow) {
                    if (IsCommented == true) {
                        lstStepProgram.CurrentItems[i][2].Indentation = Indent;
                    }
                    else {
                        if (Indent > 0) {
                            if ((StepExe == StepEnumerations.StepExecutable.EndIf) || (StepExe == StepEnumerations.StepExecutable.Else)) {
                                Indent--;
                            }
                        }
                        lstStepProgram.CurrentItems[i][2].Indentation = Indent;
                        if ((StepExe == StepEnumerations.StepExecutable.If) || (StepExe == StepEnumerations.StepExecutable.Else)) {
                            Indent++;
                        }
                    }
                }
                else {
                    lstStepProgram.CurrentItems[i][2].Indentation = Indent;
                }
            }
            lstStepProgram.ShowItemIndentation = true;
            if (Redraw) {
                lstStepProgram.Invalidate();
            }
        }
        #endregion
        #region Program Editor Pages
        internal static void DetermineTabs(TabHeader thPrograms) {
            int j = 0;
            string Name = "";
            foreach (ProgramObject Prg in Programs) {
                if (Prg.Name.Trim().Length == 0) {
                    Name = GetUntitledText(ref j);
                }
                else {
                    Name = Prg.Name;
                }
                Tab Tb = new Tab();
                Tb.Text = Name;
                Tb.Tag = Prg;
                thPrograms.Tabs.Add(Tb);
            }
            thPrograms.Invalidate();
        }
        internal static void DetermineName(TabHeader thPrograms, object btnRun) {
            int j = 0;
            string Name = "";
            string StoredName = "";
            bool Resulted = false;
            foreach (Tab PrgTab in thPrograms.Tabs) {
                if (PrgTab.Tag == null) { continue; }
                if (PrgTab.Tag.GetType() != typeof(ProgramObject)) { continue; }
                ProgramObject Prg = (ProgramObject)PrgTab.Tag;
                if (Prg.Name.Trim().Length == 0) {
                    Name = GetUntitledText(ref j);
                }
                else {
                    Name = Prg.Name;
                }
                PrgTab.Text = Name;
                if (Prg == ProgramManager.CurrentProgram) {
                    StoredName = Name;
                    Resulted = true;
                }
            }
            if (Resulted == true) {
                if (btnRun.GetType() == typeof(ToolStripSplitButton)) {
                    ((ToolStripSplitButton)btnRun).Text = StoredName;
                }
            }
            thPrograms.Invalidate();
        }
        private static string GetUntitledText(ref int Index) {
            string TempName = "";
            string LocalisatedText = LocalisationManager.GetLocalisedText("untitledProgram", "Untitled Program");
            if (Index > 0) {
                TempName = LocalisatedText + " " + Index.ToString();
            }
            else {
                TempName = LocalisatedText;
            }
            Index++;
            return TempName;
        }
        #endregion
        public enum EnableChanged {
            EnableSelected = 0x01,
            DisableSelected = 0x00,
            ToggleSelected = 0x02
        }
    }
}
