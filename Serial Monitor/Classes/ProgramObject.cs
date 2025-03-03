using ODModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serial_Monitor.Classes.Step_Programs;
using Handlers;
using static Serial_Monitor.Classes.Step_Programs.StepEnumerations;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Net.Mime.MediaTypeNames;

namespace Serial_Monitor.Classes {
    public class ProgramObject {
        public ProgramObject(string Name) {
            this.name = Name;
            iD = Guid.NewGuid().ToString();
        }

        public ProgramObject() {
            iD = Guid.NewGuid().ToString();
        }

        string iD = "";
        [Browsable(false)]
        public string ID {
            get { return iD; }
        }
        private int displayIndex = 0;
        public int DisplayIndex {
            get { return displayIndex; }
            set {
                displayIndex = value;
            }
        }
        private List<string> array = new List<string>();
        public List<string> Array {
            get { return array; }
        }
        private string name = "";
        public string Name {
            get { return name; }
            set {
                name = value;
                ProgramManager.ProgramNameChange(this);
            }
        }
        public int UntitledProgramNmber = -1;
        private string command = "";
        public string Command {
            get { return command; }
            set { command = value; }
        }
        private List<ListItem> program = new List<ListItem>();
        public List<ListItem> Program {
            get { return program; }
        }
        private List<VariableLinkage> variables = new List<VariableLinkage>();
        public List<VariableLinkage> Variables {
            get { return variables; }
        }
        private List<VariableLinkage> globalVariables = new List<VariableLinkage>();
        public List<VariableLinkage> GlobalVariables {
            get { return globalVariables; }
        }
        int programMarker = -1;
        public int ProgramMarker {
            get { return programMarker; }
            set { programMarker = value; }
        }
        public void DecodeFileCommand(string FCommand) {
            if (FCommand.Length >= 11) {
                ListItem Lip = new ListItem();
                ListSubItem LiE = new ListSubItem(FCommand[0] == '1' ? true : false);
                ListSubItem LiC = new ListSubItem();
                string CmdStr = StringHandler.GetStringInEncapulated(FCommand, ':', ':', 0, 1);//FCommand.Substring(2, 8);
                long CmdInt = 0; long.TryParse(CmdStr, out CmdInt);
                LiC.Tag = (StepEnumerations.StepExecutable)CmdInt;
                LiC.Text = ProgramManager.StepExecutableToString((StepEnumerations.StepExecutable)CmdInt);

                ListSubItem LiA = new ListSubItem();
                LiA.Text = StringHandler.GetStringInEncapulated(FCommand, ':', ':', 1, -1);//FCommand.Remove(0, 11);
                Lip.SubItems.Add(LiE);
                Lip.SubItems.Add(LiC);
                Lip.SubItems.Add(LiA);
                program.Add(Lip);
            }
        }
        public void DecodeLegacyFileCommand(string FCommand) {
            if (FCommand.Contains(":")) {
                ListItem Lip = new ListItem();
                ListSubItem LiE = new ListSubItem(true);
                ListSubItem LiC = new ListSubItem();
                STR_MVSSF Data = StringHandler.SpiltAndCombineAfter(FCommand, ':', 1);
                StepEnumerations.StepExecutable Exe = ProjectManager.ExecutableFromLegacyString(Data.Value[0]);
                LiC.Tag = Exe;
                LiC.Text = ProgramManager.StepExecutableToString(Exe);

                ListSubItem LiA = new ListSubItem();
                if (Data.Count == 2) {
                    LiA.Text = Data.Value[1];
                }
                Lip.SubItems.Add(LiE);
                Lip.SubItems.Add(LiC);
                Lip.SubItems.Add(LiA);
                program.Add(Lip);
            }
        }
        public void ClearVariables() {
            variables.Clear();
        }
        public void AddCommandLine(StepExecutable Command, string Arguments) {
            ListItem Lip = new ListItem();
            ListSubItem LiE = new ListSubItem(true);
            ListSubItem LiC = new ListSubItem();
            LiC.Tag = Command;
            LiC.Text = ProgramManager.StepExecutableToString(Command);

            ListSubItem LiA = new ListSubItem();
            LiA.Text = Arguments;
            Lip.SubItems.Add(LiE);
            Lip.SubItems.Add(LiC);
            Lip.SubItems.Add(LiA);
            program.Add(Lip);
        }
        public bool InsertCommandLine(int Index, StepExecutable Command, string Arguments) {
            if ((Index < 0) || (Index > program.Count)) { return false; }
            ListItem Lip = new ListItem();
            ListSubItem LiE = new ListSubItem(true);
            ListSubItem LiC = new ListSubItem();
            LiC.Tag = Command;
            LiC.Text = ProgramManager.StepExecutableToString(Command);

            ListSubItem LiA = new ListSubItem();
            LiA.Text = Arguments;
            Lip.SubItems.Add(LiE);
            Lip.SubItems.Add(LiC);
            Lip.SubItems.Add(LiA);
            program.Insert(Index, Lip);
            return true;
        }
        public bool AddOrInsertCommandLine(StepExecutable Command, string Arguments, int InsertLine = -1) {
            if (InsertLine < 0) {
                AddCommandLine(Command, Arguments); return true;
            }
            return InsertCommandLine(InsertLine, Command, Arguments);
        }
        const int PROG_DATA_SIZE = 3;
        const int PROG_DATA_INDX_LINENUM = 0;
        const int PROG_DATA_INDX_ENABLE = 1;
        const int PROG_DATA_INDX_COMMAND = 2;
        const int PROG_DATA_INDX_ARGUMENTS = 3;
        public (int Index, bool Enabled, StepExecutable Command, string Arguments) GetCommandLine(int Index) {
            if ((Index < 0) || (Index > program.Count)) {
                return (-1, false, StepExecutable.NoOperation, "");
            }
            ListItem? LineItem = program[Index];
            if (LineItem == null) {
                return (-1, false, StepExecutable.NoOperation, "");
            }
            if (LineItem.SubItems.Count < PROG_DATA_SIZE) {
                return (-1, false, StepExecutable.NoOperation, "");
            }
            bool Enabled = LineItem[PROG_DATA_INDX_ENABLE].Checked;
            object? objFunction = LineItem[PROG_DATA_INDX_COMMAND].Tag;
            string Arguments = LineItem.SubItems[PROG_DATA_INDX_ARGUMENTS].Text;
            StepExecutable Function = StepExecutable.NoOperation;
            if (objFunction != null) {
                if (objFunction.GetType() == typeof(StepEnumerations.StepExecutable)) {
                    Function = (StepEnumerations.StepExecutable)objFunction;
                }
            }
            return (Index, Enabled, Function, Arguments);
        }
        public bool SetCommandLine(int Index, bool Enable, StepExecutable Command, string Arguments) {
            if ((Index < 0) || (Index > program.Count)) { return false; }
            StepExecutable PreviousCommand = GetCommandLineCommand(Index);
            string PreviousArquments = GetCommandLineArguments(Index);
            string TempArguments = Arguments;
            if (!ProgramManager.AcceptsArguments(Command)) {
                TempArguments = "";
            }
            program[Index][PROG_DATA_INDX_ENABLE].Checked = Enable;
            program[Index][PROG_DATA_INDX_COMMAND].Tag = Command;
            program[Index][PROG_DATA_INDX_COMMAND].Text = ProgramManager.StepExecutableToString(Command);
            program[Index][PROG_DATA_INDX_ARGUMENTS].Text = Arguments;
            return true;
        }
        public bool SetCommandLineArguments(int Index, string Arguments) {
            if ((Index < 0) || (Index > program.Count)) { return false; }
            StepExecutable PreviousCommand = GetCommandLineCommand(Index);
            string TempArguments = Arguments;
            if (!ProgramManager.AcceptsArguments(PreviousCommand)) {
                TempArguments = "";
            }
            //program[Index][PROG_DATA_INDX_ENABLE].Checked = GetCommandLineEnabled(Index);
            //program[Index][PROG_DATA_INDX_COMMAND].Tag = PreviousCommand;
            //program[Index][PROG_DATA_INDX_COMMAND].Text = ProgramManager.StepExecutableToString(PreviousCommand);
            program[Index][PROG_DATA_INDX_ARGUMENTS].Text = TempArguments;
            return true;
        }
        public StepExecutable GetCommandLineCommand(int Index) {
            if ((Index < 0) || (Index > program.Count)) {
                return StepExecutable.NoOperation;
            }
            ListItem? LineItem = program[Index];
            if (LineItem == null) {
                return StepExecutable.NoOperation;
            }
            if (LineItem.SubItems.Count < PROG_DATA_SIZE) {
                return StepExecutable.NoOperation;
            }
            object? objFunction = LineItem[PROG_DATA_INDX_COMMAND].Tag;
            StepExecutable Function = StepExecutable.NoOperation;
            if (objFunction != null) {
                if (objFunction.GetType() == typeof(StepEnumerations.StepExecutable)) {
                    Function = (StepEnumerations.StepExecutable)objFunction;
                }
            }
            return Function;
        }
        public string GetCommandLineArguments(int Index) {
            if ((Index < 0) || (Index > program.Count)) {
                return "";
            }
            ListItem? LineItem = program[Index];
            if (LineItem == null) {
                return "";
            }
            if (LineItem.SubItems.Count < PROG_DATA_SIZE) {
                return "";
            }
            return LineItem[PROG_DATA_INDX_ARGUMENTS].Text;
        }
        public bool GetCommandLineEnabled(int Index) {
            if ((Index < 0) || (Index > program.Count)) {
                return false;
            }
            ListItem? LineItem = program[Index];
            if (LineItem == null) {
                return false;
            }
            if (LineItem.SubItems.Count < PROG_DATA_SIZE) {
                return false;
            }
            return LineItem.SubItems[0].Checked;
        }
        public VariableResult GetVariable(string Name) {
            int i = 0;
            int j = 0;
            foreach (VariableLinkage Var in globalVariables) {
                if (Name == Var.Name) {
                    return new VariableResult(Var.Name, Var.Value, VariableScope.Global, i);
                }
                i++;
            }
            foreach (VariableLinkage Var in Variables) {
                if (Name == Var.Name) {
                    return new VariableResult(Var.Name, Var.Value, VariableScope.Local, j);
                }
                j++;
            }
            return new VariableResult(Name);
        }
        public void Clear() {
            array.Clear();
            variables.Clear();
            for (int i = program.Count - 1; i >= 0; i--) {
                program[i].SubItems.Clear();
                program.RemoveAt(i);
            }
        }
        public int SelectedCount() {
            if (program.Count == 0) { return 0; }
            int SelectCount = 0;
            for (int i = 0; i < program.Count; i++) {
                if (program[i].Selected == true) {
                    SelectCount++;
                }
            }
            return SelectCount;
        }
    }
}
