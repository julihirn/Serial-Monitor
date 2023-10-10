using Serial_Monitor.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                if (ParentManager != null) {
                    CheckPreviousRegisters(Index, typeData, ParentManager);
                }
                SystemManager.RegisterValueChanged(parentManager, this, Index, typeData);
            }
        }
        string formattedValue = "0";
        public string FormattedValue {
            get { return formattedValue; }
            set {
                formattedValue = value;
                SystemManager.RegisterValueChanged(parentManager, this, Index, typeData);
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
                bool ResetTo16 = CheckAndChangeNeighbouringFormats(Index, parentManager, dataSize, typeData);
                if (ResetTo16) {
                    dataSize = ModbusEnums.DataSize.Bits16;
                }
                ModifyValue();
                SystemManager.ModbusRegisterPropertyChanged(parentManager, this, Index, typeData);
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
                bool ResetTo16 = CheckAndChangeNeighbouringFormats(Index, parentManager, value, typeData);
                if (ResetTo16) {
                    dataSize = ModbusEnums.DataSize.Bits16;
                }
                ModifyValue();
                SystemManager.ModbusRegisterPropertyChanged(parentManager, this, Index, typeData);
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
                SystemManager.ModbusRegisterPropertyChanged(parentManager, this, Index, typeData);
            }
        }
        private static bool CheckAndChangeNeighbouringFormats(int Index, SerialManager? parentManager, ModbusEnums.DataSize Size, DataSelection Selection) {
            if (parentManager == null) { return false; }
            int ItemsToCheck = 0;
            if (Size == ModbusEnums.DataSize.Bits32) { ItemsToCheck = 3; }
            else if (Size == ModbusEnums.DataSize.Bits64) { ItemsToCheck = 3; }
            else { return false; }
            for (int i = 1; i <= ItemsToCheck; i++) {
                int NextIndex = Index - i;
                if (NextIndex >= 0) {
                    ModbusEnums.DataSize NextSize = GetDataSize(NextIndex, parentManager, Selection);
                    if (IsSizeAndDistanceInScope(NextSize, i) == true) {
                        ResetFormats(NextIndex, parentManager, Selection);
                    }
                }
            }
            for (int i = 1; i <= ItemsToCheck; i++) {
                int NextIndex = Index + i;
                if (NextIndex < short.MaxValue) {
                    ModbusEnums.DataSize NextSize = GetDataSize(NextIndex, parentManager, Selection);
                    if (IsSizeAndDistanceInScope(NextSize, i, true) == true) {
                        ResetFormats(NextIndex, parentManager, Selection);
                    }
                }
            }
            return false;
        }
        private static void ResetFormats(int Index, SerialManager parentManager, DataSelection Selection) {
            ModbusEnums.DataSize CurrentSize = GetDataSize(Index, parentManager, Selection);
            ModbusEnums.DataFormat CurrentFormat = GetDataFormat(Index, parentManager, Selection);
            if (CurrentSize < ModbusEnums.DataSize.Bits32) { return; }
            if (Selection == DataSelection.ModbusDataInputRegisters) {
                if ((CurrentFormat == ModbusEnums.DataFormat.Float) || (CurrentFormat == ModbusEnums.DataFormat.Double)) {
                    parentManager.InputRegisters[Index].Format = ModbusEnums.DataFormat.Decimal;
                }
                parentManager.InputRegisters[Index].Size = ModbusEnums.DataSize.Bits16;
            }
            else if (Selection == DataSelection.ModbusDataHoldingRegisters) {
                if ((CurrentFormat == ModbusEnums.DataFormat.Float) || (CurrentFormat == ModbusEnums.DataFormat.Double)) {
                    parentManager.HoldingRegisters[Index].Format = ModbusEnums.DataFormat.Decimal;
                }
                parentManager.HoldingRegisters[Index].Size = ModbusEnums.DataSize.Bits16;
            }
        }
        private static ModbusEnums.DataFormat GetDataFormat(int Index, SerialManager parentManager, DataSelection Selection) {
            if (Selection == DataSelection.ModbusDataInputRegisters) {
                return parentManager.InputRegisters[Index].Format;
            }
            else if (Selection == DataSelection.ModbusDataHoldingRegisters) {
                return parentManager.HoldingRegisters[Index].Format;
            }
            return ModbusEnums.DataFormat.Decimal;
        }
        private static ModbusEnums.DataSize GetDataSize(int Index, SerialManager parentManager, DataSelection Selection) {
            if (Selection == DataSelection.ModbusDataInputRegisters) {
                return parentManager.InputRegisters[Index].Size;
            }
            else if (Selection == DataSelection.ModbusDataHoldingRegisters) {
                return parentManager.HoldingRegisters[Index].Size;
            }
            return ModbusEnums.DataSize.Bits16;
        }
        private static bool IsSizeAndDistanceInScope(ModbusEnums.DataSize Size, int Distance, bool CheckAll = false) {
            if (Size == ModbusEnums.DataSize.Bits32) {
                if (CheckAll == false) {
                    if (Distance <= 1) { return true; }
                    return false;
                }
                else {
                    if (Distance <= 3) { return true; }
                    return false;
                }
            }
            else if (Size == ModbusEnums.DataSize.Bits64) {
                if (Distance <= 3) { return true; }
                return false;
            }
            return false;
        }
        public void PushValue(long Input, bool AllowTransmit) {
            if (parentManager == null) { return; }
            if (dataSize <= ModbusEnums.DataSize.Bits16) {
                short Temp = (short)(0xFFFF & Input);
                regValue = Temp;
                ModifyValue();
                if (ParentManager != null) {
                    CheckPreviousRegisters(Index, typeData, ParentManager);
                }
                SystemManager.RegisterValueChanged(parentManager, this, Index, typeData);
                if ((AllowTransmit) && (parentManager.IsMaster)) {
                    SystemManager.SendModbusCommand(parentManager, typeData, "Write Register " + Index.ToString() + " = " + Value.ToString());
                }
            }
            else if (dataSize == ModbusEnums.DataSize.Bits32) {
                if (Index + 1 < short.MaxValue) {
                    SetData(Index + 1, 1, Input, typeData, parentManager, AllowTransmit);
                }
                regValue = (short)(0xFFFF & Input);

                ModifyValue();
                SystemManager.RegisterValueChanged(parentManager, this, Index, typeData);
                if ((AllowTransmit) && (parentManager.IsMaster)) {
                    SystemManager.SendModbusCommand(parentManager, typeData, "Write Register " + Index.ToString() + " = " + Value.ToString());
                }
            }
            else if (dataSize == ModbusEnums.DataSize.Bits64) {
                if (Index + 3 < short.MaxValue) {
                    SetData(Index + 1, 1, Input, typeData, parentManager, AllowTransmit);
                    SetData(Index + 2, 2, Input, typeData, parentManager, AllowTransmit);
                    SetData(Index + 3, 3, Input, typeData, parentManager, AllowTransmit);
                }
                regValue = (short)(0xFFFF & Input);
                SystemManager.RegisterValueChanged(parentManager, this, Index, typeData);
                ModifyValue();
                if ((AllowTransmit) && (parentManager.IsMaster)) {
                    SystemManager.SendModbusCommand(parentManager, typeData, "Write Register " + Index.ToString() + " = " + Value.ToString());
                }
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
                    parentManager.InputRegisters[MarkedIndex].ModifyValue();
                    SystemManager.RegisterValueChanged(parentManager, parentManager.InputRegisters[MarkedIndex], MarkedIndex, typeData);
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
                    SystemManager.RegisterValueChanged(parentManager, parentManager.HoldingRegisters[MarkedIndex], MarkedIndex, typeData);
                }
            }
        }
        public void ModifyValue() {
            if (dataSize <= ModbusEnums.DataSize.Bits16) {
                formattedValue = Formatters.LongToString((long)(ushort)regValue, format, dataSize, signed);
            }
            else if (dataSize == ModbusEnums.DataSize.Bits32) {
                long Temp = 0;
                if (parentManager == null) {
                    regValue = 0;
                    Temp = (long)(ushort)regValue;
                }
                else {
                    if (Index + 1 < short.MaxValue - 1) {
                        Temp = (long)(ushort)regValue;
                        Temp |= AppendData(Index + 1, 1, typeData, parentManager);
                    }
                }
                formattedValue = Formatters.LongToString(Temp, format, dataSize, signed);
            }
            else if (dataSize == ModbusEnums.DataSize.Bits64) {
                long Temp = 0;
                if (parentManager == null) {
                    regValue = 0;
                    Temp = (long)(ushort)regValue;
                }
                else {
                    if (Index + 3 < short.MaxValue - 3) {
                        Temp = (long)(ushort)regValue;
                        Temp |= AppendData(Index + 1, 1, typeData, parentManager);
                        Temp |= AppendData(Index + 2, 2, typeData, parentManager);
                        Temp |= AppendData(Index + 3, 3, typeData, parentManager);
                    }
                }
                formattedValue = Formatters.LongToString((long)Temp, format, dataSize, signed);
            }
        }
        private static long AppendData(int NextIndex, int Shift, DataSelection typeData, SerialManager parentManager) {
            if (parentManager == null) { return 0; }
            if (typeData == DataSelection.ModbusDataInputRegisters) {
                if (parentManager.InputRegisters.Length <= NextIndex) { return 0; }
                ushort Data = (ushort)parentManager.InputRegisters[NextIndex].Value;
                long Output = 0;
                Output = (long)Data << (Shift * 16);
                return Output;
            }
            else if (typeData == DataSelection.ModbusDataHoldingRegisters) {
                if (parentManager.HoldingRegisters.Length <= NextIndex) { return 0; }
                ushort Data = (ushort)parentManager.HoldingRegisters[NextIndex].Value;
                long Output = 0;
                Output = (long)Data << (Shift * 16);
                return Output;
            }
            return 0;
        }
        private static void SetData(int NextIndex, int Shift, long Value, DataSelection typeData, SerialManager? parentManager, bool AllowTransmit) {
            if (parentManager == null) { return; }
            if (typeData == DataSelection.ModbusDataInputRegisters) {
                if (parentManager.InputRegisters.Length <= NextIndex) { return; }
                long Temp = Value >> (Shift * 16);
                ushort Output = (ushort)(Temp & 0xFFFF);
                parentManager.InputRegisters[NextIndex].PushValue((long)Output, AllowTransmit);
            }
            else if (typeData == DataSelection.ModbusDataHoldingRegisters) {
                if (parentManager.HoldingRegisters.Length <= NextIndex) { return; }
                long Temp = Value >> (Shift * 16);
                ushort Output = (ushort)(Temp & 0xFFFF);
                parentManager.HoldingRegisters[NextIndex].PushValue((long)Output, AllowTransmit);
            }
        }
    }
}
