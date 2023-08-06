using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Step_Programs {
    public class VariableLinkage {
        string name = "";
        public string Name {
            get { return name; }
        }
        string assignment = "";
        public string Value {
            get { return assignment; }
            set { assignment = value; }
        }
        public VariableLinkage(string name, string assignment) {
            this.name = name;
            this.assignment = assignment;
        }
    }
}
