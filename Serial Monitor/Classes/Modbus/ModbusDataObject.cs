using Serial_Monitor.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    [Serializable]
    public class ModbusDataObject {
        bool isRegister = false;
        public bool IsRegister {
            get { return isRegister; }
        }
        string name = "";
        public string Name {
            get { return name; }
        }
        bool signed = false;
        public bool Signed {
            get { return signed; }
        }
        ModbusEnums.DataSize dataSize = ModbusEnums.DataSize.Bits16;
        public ModbusEnums.DataSize Size {
            get { return dataSize; }
        }
        ModbusEnums.DataFormat format = ModbusEnums.DataFormat.Decimal;
        public ModbusEnums.DataFormat Format {
            get { return format; }
        }
        ModbusClipboardFlags includeFlags = ModbusClipboardFlags.IncludeNothing;
        public ModbusClipboardFlags IncludeFlags {
            get { return includeFlags; }
        }
        short intValue = 0;
        bool bolValue = false;
        public object Value {
            get {
                if (isRegister == true) {
                    return intValue;
                }
                else {
                    return bolValue;
                }
            }
        }
        public ModbusDataObject(string Name, bool Input, ModbusClipboardFlags Flags) {
            this.includeFlags = Flags;
            this.bolValue = Input;
            this.name = Name;
            isRegister = false;
        }
        public ModbusDataObject(string Name, short Input, bool Signed, ModbusEnums.DataFormat Format, ModbusEnums.DataSize Size, ModbusClipboardFlags Flags) {
            this.includeFlags = Flags;
            this.intValue = Input;
            this.name = Name;
            this.signed = Signed;
            this.dataSize = Size;
            this.format = Format;
            isRegister = true; 
        }
    }
    public enum ModbusClipboardFlags {
        IncludeNothing = 0x00,
        IncludeName = 0x01,
        IncludeFormat = 0x04,
        IncludeSize = 0x08,
        IncludeValue = 0x10
    }
}
