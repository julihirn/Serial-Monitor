using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Plugin {
    public static class SystemLinkage {
        public static event SystemProgramRunHandler? ProgramRun;
        public delegate void SystemProgramRunHandler(string Name);
        public static void RunProgram(string Name) {
            ProgramRun?.Invoke(Name);
        }
    }
}
