using Handlers;
using Serial_Monitor.Classes.Step_Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes {
    public static class ProgramManager {
        public static event ProgramNameChangedHandler? ProgramNameChanged;
        public delegate void ProgramNameChangedHandler(object sender);
        public static string StepExecutableToString(StepEnumerations.StepExecutable StepEx) {
            return StringHandler.MergeStrings(StringHandler.SpiltStringAtCapitals(StepEx.ToString()), ' ');
        }
        public static void ProgramNameChange(object sender) {
            ProgramNameChanged?.Invoke(sender);
        }
    }
}
