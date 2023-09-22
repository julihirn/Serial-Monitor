using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus
{
    public class ModbusRegister {
        int Index = 0;
        DataSelection typeData = DataSelection.ModbusDataCoils;
        public DataSelection ComponentType {
            get { return typeData; }
        }
        public int Address {
            get { return Index; }
        }
        public ModbusRegister(int index, DataSelection Type) {
            Index = index;
            typeData = Type;
        }
        short regValue = 0;
        public short Value {
            get { return regValue; }
            set {
                regValue = value;
                SystemManager.RegisterValueChanged(this, Index, typeData);
            }
        }
        string name = "";
        public string Name {
            get { return name; }
            set { name = value; }
        }
        bool userChanged = false;
        public bool UserChanged {
            get { return userChanged; }
        }
    }
}
