using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Step_Programs {
    [Serializable]
    public class ProgramDataObject {
        public bool Enabled = true;
        public StepEnumerations.StepExecutable Command = StepEnumerations.StepExecutable.NoOperation;
        public string Arguments = "";
    }
}
