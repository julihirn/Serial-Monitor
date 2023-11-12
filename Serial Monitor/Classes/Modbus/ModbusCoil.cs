using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public class ModbusCoil : ModbusObject {
        public ModbusCoil(int index, DataSelection Type, SerialManager Manager) {
            Index = index;
            typeData = Type;
            parentManager = Manager;
        }
        #region Fixed Properties
        SerialManager? parentManager = null;
        public SerialManager? ParentManager {
            get { return parentManager; }
        }
        int Index = 0;
        public int Address {
            get { return Index; }
        }
        DataSelection typeData = DataSelection.ModbusDataCoils;
        public DataSelection ComponentType {
            get { return typeData; }
        }
        bool userChanged = false;
        public bool UserChanged {
            get { return userChanged; }
        }
        #endregion
        #region Properties
        bool coilValue = false;
        public bool Value {
            get { return coilValue; }
            set {
                coilValue = value;
                SystemManager.RegisterValueChanged(parentManager, this, Index, typeData);
            }
        }
        #endregion 
        #region File Support
        public void Set(StringPair Input) {
            if (Input.A.ToLower() == "name") {
                Name = Input.B;
            }
            else if (Input.A.ToLower() == "value") {
                Value = (Input.B == "1" ? true : false);
            }
        }
        #endregion
    }
}
