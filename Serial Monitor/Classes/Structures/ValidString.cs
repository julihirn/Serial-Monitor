using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Structures {
    public class ValidString {
        public string Value;
        public bool IsValid;
        public ValidString(string Input, bool IsValid) {
            this.Value = Input;
            this.IsValid = IsValid;
        }
        public ValidString(string Input) {
            this.Value = Input;
            this.IsValid = true;
        }
        public ValidString() {
            this.Value = "";
            this.IsValid = false;
        }
    }
}
