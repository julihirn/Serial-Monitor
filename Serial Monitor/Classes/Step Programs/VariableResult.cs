using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Step_Programs {
    public struct VariableResult {
        string name;
        public string Name {
            get { return name; }
        }
        string value;
        public string Value {
            get { return value; }
        }
        bool variableValid;
        public bool IsValid {
            get { return variableValid; }
        }
        public VariableResult(string Name, string Value) {
            this.name = Name;
            this.value = Value;
            variableValid = true;
        }
        public VariableResult(string Name) {
            this.name = Name;
            this.value = "";
            variableValid = false;
        }
    }
}
