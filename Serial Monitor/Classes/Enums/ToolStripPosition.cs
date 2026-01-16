using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Enums {
    internal enum ToolStripPosition :byte {
        Top = 0x00,
        Bottom =0x01,
        Left = 0x02,
        Right = 0x03
    }
}
