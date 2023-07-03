using ODModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes {
    public class ProgramObject {
        private string name = "";
        public string Name {
            get { return name; }
            set { name = value;
                ProgramManager.ProgramNameChange(this);
            } 
        }
        private string command = "";
        public string Command {
            get { return command; }
            set { command = value; }
        }
        private List<ListItem> program = new List<ListItem>();
        public List<ListItem> Program {
            get { return program;}
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
                LiC.Tag = (StepExecutable)CmdInt;
                LiC.Text = ProgramManager.StepExecutableToString((StepExecutable)CmdInt);

                ListSubItem LiA = new ListSubItem();
                LiA.Text = FCommand.Remove(0, 11);
                Lip.SubItems.Add(LiE);
                Lip.SubItems.Add(LiC);
                Lip.SubItems.Add(LiA);
                program.Add(Lip);
            }
        }
        public void Clear() {
            for (int i = program.Count - 1; i >= 0; i--) {
                program[i].SubItems.Clear();
                program.RemoveAt(i);
            }
        }
    }
}
