using ODModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serial_Monitor.Classes.Step_Programs;
using Handlers;
using static Serial_Monitor.Classes.Step_Programs.StepEnumerations;

namespace Serial_Monitor.Classes {
    public class ProgramObject {
        public ProgramObject(string Name) {
            this.name = Name;
        }
        public ProgramObject() {
        }
        private string name = "";
        public string Name {
            get { return name; }
            set { name = value;
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
            get { return program;}
        }
        private List<VariableLinkage> variables = new List<VariableLinkage>();
        public List<VariableLinkage> Variables {
            get { return variables; }
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
                string CmdStr = FCommand.Substring(2, 8);
                int CmdInt = 0; int.TryParse(CmdStr, out CmdInt);
                LiC.Tag = (StepEnumerations.StepExecutable)CmdInt;
                LiC.Text = ProgramManager.StepExecutableToString((StepEnumerations.StepExecutable)CmdInt);

                ListSubItem LiA = new ListSubItem();
                LiA.Text = FCommand.Remove(0, 11);
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
        public VariableResult GetVariable(string Name) {
            foreach (VariableLinkage Var in Variables) {
                if (Name == Var.Name) {
                    return new VariableResult(Var.Name, Var.Value);
                }
            }
            return new VariableResult(Name);
        }
        public void Clear() {
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
