using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.Enums.ModbusEnums;

namespace Serial_Monitor.Classes.Structures {
    public struct ModbusFormat {
        public int Test = 0;
        DataFormat dataFormat;
        public DataFormat Format {
            get { return dataFormat; }
        }
        DataSize dataSize;
        public DataSize Size {
            get { return dataSize; }
        }
        bool signed;
        public bool Signed {
            get { return signed; }
        }
        bool isSize;
        public bool IsSize {
            get { return isSize; }
        }
        public ModbusFormat(DataFormat dataFormat, DataSize dataSize, bool signed, bool isSized) {
            this.dataFormat = dataFormat;
            this.dataSize = dataSize;
            this.signed = signed;
            this.isSize = isSized;
        }
    }
}
