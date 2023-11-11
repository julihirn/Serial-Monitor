using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus
{
    public class ModbusCoil: ModbusObject {
        SerialManager? parentManager = null;
        public SerialManager? ParentManager {
            get { return parentManager; }
        }
        int Index = 0;
        DataSelection typeData = DataSelection.ModbusDataCoils;
        public DataSelection ComponentType {
            get { return typeData; }
        }
        public int Address {
            get { return Index; }
        }
        public ModbusCoil(int index, DataSelection Type, SerialManager Manager) {
            Index = index;
            typeData = Type;
            parentManager = Manager;
        }
        bool coilValue = false;
        public bool Value {
            get { return coilValue; }
            set {
                coilValue = value;
                SystemManager.RegisterValueChanged(parentManager, this, Index, typeData);
            }
        }
        bool userChanged = false;
        public bool UserChanged {
            get { return userChanged; }
        }
        public void Set(StringPair Input) {
            if (Input.A.ToLower() == "name") {
                Name = Input.B;
            }
            else if (Input.A.ToLower() == "value") {
                Value = (Input.B == "1" ? true : false);
            }
        }
    }
}
