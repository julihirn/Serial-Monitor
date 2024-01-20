using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public class ModbusCoil : ModbusObject {
        public ModbusCoil(int index, DataSelection Type, ModbusSlave Manager) {
            Index = index;
            typeData = Type;
            parent = Manager;
        }
        #region Fixed Properties
        ModbusSlave? parent = null;
        public ModbusSlave? Parent {
            get { return parent; }
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
                SystemManager.RegisterValueChanged(parent, this, Index, typeData);
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
            else if (Input.A.ToLower() == "forecolor") {
                int Temp = 0;
                int.TryParse(Input.B, out Temp);
                ForeColor = Color.FromArgb(Temp);
                UseForeColor = true;
            }
            else if (Input.A.ToLower() == "backcolor") {
                int Temp = 0;
                int.TryParse(Input.B, out Temp);
                BackColor = Color.FromArgb(Temp);
                UseBackColor = true;
            }
        }
        #endregion
        public void Reset() {
            Name = "";
            coilValue = false;
            userChanged = false;
        }
    }
}
