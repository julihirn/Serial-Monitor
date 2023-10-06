using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Structures {
    public class RegisterRequest {
        int index = -1;
        public int Index { get { return index; }}

        DataSelection selection = DataSelection.ModbusDataCoils;
        public DataSelection Selection {
            get { return selection; }
        }
        public RegisterRequest(int Index, DataSelection Selection) {
            this.index = Index;
            this.selection= Selection;
        }
    }
}
