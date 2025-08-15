using Serial_Monitor.Classes.Enums;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.Enums.ModbusEnums;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

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
                UpdateLastUpdate();
                SystemManager.RegisterValueChanged(parent, this, Index, typeData);
            }
        }
        public string ValueWithUnit {
            get {
                switch (format) {
                    case CoilFormat.Boolean:
                        return coilValue.ToString();
                    case CoilFormat.Bit:
                        return coilValue == true ? "1" : "0";
                    case CoilFormat.PowerState:
                        return coilValue == true ? "On" : "Off";
                    case CoilFormat.ValveState:
                        return coilValue == true ? "Open" : "Closed";
                    case CoilFormat.EnabledState:
                        return coilValue == true ? "Enabled" : "Disabled";
                    case CoilFormat.ActivationState:
                        return coilValue == true ? "Activated" : "Deactivated";
                    default:
                        return coilValue.ToString();
                }
                
            }
        }
        ModbusEnums.CoilFormat format = ModbusEnums.CoilFormat.Boolean;
        public ModbusEnums.CoilFormat Format {
            get { return format; }
            set {
                format = value;
                SystemManager.ModbusRegisterPropertyChanged(parent, this, Index, typeData);
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
                SetThemeIndependantForeColor(Color.FromArgb(Temp));
                UseForeColor = true;
            }
            else if (Input.A.ToLower() == "backcolor") {
                int Temp = 0;
                int.TryParse(Input.B, out Temp);
                SetThemeIndependantBackColor(Color.FromArgb(Temp));
                UseBackColor = true;
            }
            else if (Input.A.ToLower() == "format") {
                Format = EnumManager.StringToCoilFormat(Input.B);
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
