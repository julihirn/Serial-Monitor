using ODModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Step_Programs {
    internal class ProgramEdit {
        public StepEnumerations.StepExecutable Command;
        public int Line;
        public string Arguments;
        public bool Enabled;
        public ListItem Parent;
        public ProgramEdit(int lineIndex, StepEnumerations.StepExecutable command, string arguments, bool enabled, ListItem parent) {
            Line = lineIndex;
            Command = command;
            Arguments = arguments;
            Enabled = enabled;
            Parent = parent;
        }
    }
}
