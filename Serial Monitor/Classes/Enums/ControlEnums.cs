using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Enums {
    public  class ControlEnums {
        public enum ArrowKey {
            Up = 0x01,
            Down = 0x02,
            Left = 0x04,
            Right = 0x08
        }
    }
}
