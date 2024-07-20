﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Step_Programs {
    public class ForLinkage {
        int start = 0;
        public int Start {
            get { return start; }
        }
        int end = 0;
        public int End {
            get { return end; }
            set { end = value; }
        }
        bool initialised = false;
        public ForLinkage(int start, int end) {
            this.start = start;
            this.end = end;
        }
    }
}
