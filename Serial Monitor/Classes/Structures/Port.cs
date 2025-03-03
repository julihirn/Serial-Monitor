using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Serial_Monitor.Classes.Structures {
    public class Port {
        public string DisplayName {
            get {
                if (Properties.Settings.Default.CHAN_BOL_PreferLegacyPortListing) {
                    return PortName;
                }
                int Indx_PortDisplay = Properties.Settings.Default.CHAN_OPT_PortDisplay;
                if (Indx_PortDisplay <= 0) {
                    if (PortName.Length <= 4) {
                        return PortName + "    " + Name;
                    }
                    else if (PortName.Length == 4) {
                        return PortName + "   " + Name;
                    }
                    else if (PortName.Length == 5) {
                        return PortName + "  " + Name;
                    }
                }
                else if (Indx_PortDisplay == 1) {
                    if (Name.Trim().Length == 0) { return PortName; }
                    return Name;
                }
                else if (Indx_PortDisplay == 2) {
                    return PortName;
                }
                return PortName;
            }
        }
        public string PortName;
        public string Name;
        public string ToolTip;
        public Port(string Port, string Name, string ToolTip) {
            this.PortName = Port;
            this.Name = Name;
            this.ToolTip = ToolTip;
        }
    }
}
