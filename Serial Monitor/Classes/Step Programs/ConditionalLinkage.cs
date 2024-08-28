using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Step_Programs {
    public class ConditionalLinkage {
        int start = 0;
        public int Start {
            get { return start; }
        }
        int end = 0;
        public int End {
            get { return end; }
            set { end = value; }
        }
        int elseend = -1;
        public int ElseEnd {
            get { return elseend; }
            set { elseend = value; }
        }
        int depth = 0;
        public int Depth {
            get { return depth; }
            set { depth = value; }
        }
        public ConditionalLinkage(int start, int end, int depth) {
            this.start = start;
            this.end = end;
            this.depth = depth;
        }
        public override string? ToString() {
            return "IF: Start = " + start.ToString() + ", End: " + end.ToString() + ", Depth: " + depth.ToString();
        }
    }
}
