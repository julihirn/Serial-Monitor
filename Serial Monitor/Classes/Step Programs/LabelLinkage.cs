using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Step_Programs {
    public class LabelLinkage {
        string label = "";
        public string Label {
            get { return label; }
        }
        int lineNumber = -1;
        public int LineNumber {
            get { return lineNumber; }
        }
        public LabelLinkage(string label, int lineNumber) {
            this.label = label;
            this.lineNumber = lineNumber;
        }
    }
}
