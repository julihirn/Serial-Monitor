using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public class ModbusObject {
        string name = "";
        public string Name {
            get { return name; }
            set { name = value; }
        }
        Color backColor = Color.White;
        public Color BackColor {
            get { return backColor; }
            set { backColor = value; }
        }
        Color foreColor = Color.Black;
        public Color ForeColor {
            get { return foreColor; }
            set { foreColor = value; }
        }
        bool useBackColor = false;
        public bool UseBackColor { 
            get { return useBackColor; } 
            set {  useBackColor = value; }
        }
        bool useForeColor = false;
        public bool UseForeColor {
            get { return useForeColor; }
            set { useForeColor = value; }
        }
    }
}
