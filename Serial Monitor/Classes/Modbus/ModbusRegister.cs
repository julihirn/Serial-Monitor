using Serial_Monitor.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public class ModbusRegister {
        int Index = 0;
        SerialManager? parentManager = null;
        public SerialManager? ParentManager {
            get { return parentManager; }
        }
        DataSelection typeData = DataSelection.ModbusDataCoils;
        public DataSelection ComponentType {
            get { return typeData; }
        }
        public int Address {
            get { return Index; }
        }
        public ModbusRegister(int index, DataSelection Type, SerialManager Manager) {
            Index = index;
            typeData = Type;
            parentManager = Manager;
        }
        short regValue = 0;
        public short Value {
            get { return regValue; }
            set {
                regValue = value;
                ModifyValue();
                CheckPreviousRegisters(Index,typeData,ParentManager);
                SystemManager.RegisterValueChanged(this, Index, typeData);
            }
        }
        string formattedValue = "0";
        public string FormattedValue {
            get { return formattedValue; }
            set {
                formattedValue = value;
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
        ModbusEnums.DataFormat format = ModbusEnums.DataFormat.Decimal;
        public ModbusEnums.DataFormat Format {
            get { return format; }
            set {
                if (value == ModbusEnums.DataFormat.Float) {
                    dataSize = ModbusEnums.DataSize.Bits32;
                    signed = false;
                }
                else if (value == ModbusEnums.DataFormat.Double) {
                    dataSize = ModbusEnums.DataSize.Bits64;
                    signed = false;
                }
                else if (value == ModbusEnums.DataFormat.Char) {
                    dataSize = ModbusEnums.DataSize.Bits16;
                    signed = false;
                }
                format = value;
                ModifyValue();
                SystemManager.ModbusRegisterPropertyChanged(this, Index, typeData);
            }
        }
        ModbusEnums.DataSize dataSize = ModbusEnums.DataSize.Bits16;
        public ModbusEnums.DataSize Size {
            get { return dataSize; }
            set {
                if (format == ModbusEnums.DataFormat.Float) {
                    dataSize = ModbusEnums.DataSize.Bits32;
                    signed = false;
                }
                else if (format == ModbusEnums.DataFormat.Double) {
                    dataSize = ModbusEnums.DataSize.Bits64;
                    signed = false;
                }
                else if (format == ModbusEnums.DataFormat.Char) {
                    dataSize = ModbusEnums.DataSize.Bits16;
                    signed = false;
                }
                else {
                    dataSize = value;
                }
                ModifyValue();
                SystemManager.ModbusRegisterPropertyChanged(this, Index, typeData);
            }
        }
        bool signed = false;
        public bool Signed {
            get { return signed; }
            set {
                if (format == ModbusEnums.DataFormat.Float) {
                    signed = false;
                }
                else if (format == ModbusEnums.DataFormat.Double) {
                    signed = false;
                }
                else if (format == ModbusEnums.DataFormat.Char) {
                    signed = false;
                }
                else {
                    signed = value;
                }
                ModifyValue();
                SystemManager.ModbusRegisterPropertyChanged(this, Index, typeData);
            }
        }
        private static void CheckPreviousRegisters(int Index, DataSelection typeData, SerialManager parentManager) {
            if (parentManager == null) { return; }
            int CurrentIndex = Index;
            int MarkedIndex = -1;
            if (typeData == DataSelection.ModbusDataInputRegisters) {
                for (int i = 1; i < 4; i++) {
                    CurrentIndex = Index - i;
                    if (CurrentIndex >= 0) {
                        if (parentManager.InputRegisters[CurrentIndex].Size > ModbusEnums.DataSize.Bits16) {
                            MarkedIndex = CurrentIndex;
                            break;
                        }
                    }
                    else { break; }
                }
                if (MarkedIndex >= 0) {
                    parentManager.HoldingRegisters[MarkedIndex].ModifyValue();
                    SystemManager.RegisterValueChanged(parentManager.InputRegisters[MarkedIndex], MarkedIndex, typeData);
                }
            }
            else if (typeData == DataSelection.ModbusDataHoldingRegisters) {
                for (int i = 1; i < 4; i++) {
                    CurrentIndex = Index - i;
                    if (CurrentIndex >= 0) {
                        if (parentManager.HoldingRegisters[CurrentIndex].Size > ModbusEnums.DataSize.Bits16) {
                            MarkedIndex = CurrentIndex;
                            break;
                        }
                    }
                    else { break; }
                }
                if (MarkedIndex >= 0) {
                    parentManager.HoldingRegisters[MarkedIndex].ModifyValue();
                    SystemManager.RegisterValueChanged(parentManager.HoldingRegisters[MarkedIndex], MarkedIndex, typeData);
                }
            }
        }
        public void ModifyValue() {
            if (dataSize <= ModbusEnums.DataSize.Bits16) {
                formattedValue = Formatters.LongToString((long)regValue, format, dataSize, signed);
            }
            else if (dataSize == ModbusEnums.DataSize.Bits32) {
                long Temp = 0;
                if (parentManager == null) {
                    regValue = 0;
                    Temp = (long)regValue;
                }
                else {
                    if (Index + 1 < short.MaxValue - 1) {
                        Temp = (long)regValue;
                        Temp |= AppendData(Index + 1, 1, typeData, parentManager);
                    }
                }
                formattedValue = Formatters.LongToString(Temp, format, dataSize, signed);
            }
            else if (dataSize == ModbusEnums.DataSize.Bits64) {
                long Temp = 0;
                if (parentManager == null) {
                    regValue = 0;
                    Temp = (long)regValue;
                }
                else {
                    if (Index + 3 < short.MaxValue - 3) {
                        Temp = (long)regValue;
                        Temp |= AppendData(Index + 1, 1, typeData, parentManager);
                        Temp |= AppendData(Index + 2, 2, typeData, parentManager);
                        Temp |= AppendData(Index + 3, 3, typeData, parentManager);
                    }
                }
                formattedValue = Formatters.LongToString(Temp, format, dataSize, signed);
            }
        }
        private static long AppendData(int NextIndex, int Shift, DataSelection typeData, SerialManager parentManager) {
            if (parentManager == null) { return 0; }
            if (typeData == DataSelection.ModbusDataInputRegisters) {
                if (parentManager.InputRegisters.Length <= NextIndex) { return 0; }
                short Data = parentManager.InputRegisters[NextIndex].Value;
                long Output = 0;
                Output = (long)Data << (Shift * 16);
                return Output;
            }
            else if (typeData == DataSelection.ModbusDataHoldingRegisters) {
                if (parentManager.HoldingRegisters.Length <= NextIndex) { return 0; }
                short Data = parentManager.HoldingRegisters[NextIndex].Value;
                long Output = 0;
                Output = (long)Data << (Shift * 16);
                return Output;
            }
            return 0;
        }
    }
}
