﻿using FastColoredTextBoxNS;
using Serial_Monitor.Classes.Enums;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Handlers;
using ODModules;
using static System.Windows.Forms.DataFormats;
namespace Serial_Monitor.Classes.Modbus {

    public class ModbusRegister : ModbusObject {
        const bool TEST = false;
        public ModbusRegister(int index, DataSelection Type, ModbusSlave Manager) {
            Index = index;
            typeData = Type;
            parent = Manager;
        }
        #region Fixed Properties
        int Index = 0;
        public int Address {
            get { return Index; }
        }
        ModbusSlave? parent = null;
        public ModbusSlave? Parent {
            get { return parent; }
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
        short regValue = 0;
        public short Value {
            get { return regValue; }
            set {
                regValue = value;
                ModifyValue();
                if (Parent != null) {
                    if (Parent.Manager != null) {
                        CheckPreviousRegisters(Index, typeData, Parent);
                    }
                }
                SystemManager.RegisterValueChanged(parent, this, Index, typeData);
            }
        }
        string formattedValue = "0";
        public string FormattedValue {
            get { return formattedValue; }
            set {
                formattedValue = value;
                SystemManager.RegisterValueChanged(parent, this, Index, typeData);
            }
        }
        public string ValueWithUnit {
            get {
                if (ProjectManager.ShowUnits == false) {
                    return formattedValue;
                }
                switch (format) {
                    case ModbusEnums.DataFormat.Decimal:
                        return formattedValue + GetUnitString();
                    case ModbusEnums.DataFormat.Float:
                       return formattedValue + GetUnitString();
                    case ModbusEnums.DataFormat.Double:
                        return formattedValue + GetUnitString();
                }
                return formattedValue;
            }
        }
        private string GetUnitString() {
            string UnitBuild = ConversionHandler.PrefixToSymbol(prefix) + unit;
            if (UnitBuild.Trim(' ').Length > 0) {
                return " " + UnitBuild;
            }
            return "";
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
                bool ResetTo16 = CheckAndChangeNeighbouringFormats(Index, parent, dataSize, typeData);
                if (ResetTo16) {
                    dataSize = ModbusEnums.DataSize.Bits16;
                }
                if (dataSize < ModbusEnums.DataSize.Bits32) {
                    wordOrder = ModbusEnums.ByteOrder.LittleEndian;
                }
                ModifyValue();
                SystemManager.ModbusRegisterPropertyChanged(parent, this, Index, typeData);
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
                bool ResetTo16 = CheckAndChangeNeighbouringFormats(Index, parent, value, typeData);
                if (ResetTo16) {
                    dataSize = ModbusEnums.DataSize.Bits16;
                }
                if (dataSize < ModbusEnums.DataSize.Bits32) {
                    wordOrder = ModbusEnums.ByteOrder.LittleEndian;
                }
                ModifyValue();
                SystemManager.ModbusRegisterPropertyChanged(parent, this, Index, typeData);
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
                SystemManager.ModbusRegisterPropertyChanged(parent, this, Index, typeData);
            }
        }
        private ModbusEnums.ByteOrder wordOrder = ModbusEnums.ByteOrder.BigEndian;
        public ModbusEnums.ByteOrder WordOrder {
            get { return wordOrder; }
            set {
                if (dataSize >= ModbusEnums.DataSize.Bits32) {
                    wordOrder = value;
                }
                else {
                    wordOrder = ModbusEnums.ByteOrder.LittleEndian;
                }
                ModifyValue();
                SystemManager.ModbusRegisterPropertyChanged(parent, this, Index, typeData);
            }
        }
        string unit = "";
        public string Unit {
            get {
                return unit;
            }
            set {
                unit = value;
                SystemManager.ModbusRegisterPropertyChanged(parent, this, Index, typeData);
            }
        }
        ConversionHandler.Prefix prefix = ConversionHandler.Prefix.None;
        public ConversionHandler.Prefix Prefix { 
            get { return prefix; }
            set {
                prefix = value;
                SystemManager.ModbusRegisterPropertyChanged(parent, this, Index, typeData);
            }
        }
        
        #endregion
        #region Value Modification
        public void PushValue(long Input, bool AllowTransmit) {
            if (parent == null) { return; }
            if (parent.Manager == null) { return; }
            if (dataSize <= ModbusEnums.DataSize.Bits16) {
                short Temp = (short)(0xFFFF & Input);
                regValue = Temp;
                ModifyValue();
                if (parent != null) {
                    CheckPreviousRegisters(Index, typeData, parent);
                }
                SystemManager.RegisterValueChanged(parent, this, Index, typeData);
                if ((AllowTransmit) && (parent.Manager.IsMaster)) {
                    SystemManager.SendModbusCommand(parent, typeData, "Write Register " + Index.ToString() + " = " + Value.ToString());
                }
#if TEST
                    Debug.Print("Size: 16, Input: " + Input.ToString() + ", Set: " + regValue.ToString());
#endif
            }
            else if (dataSize == ModbusEnums.DataSize.Bits32) {
                if (wordOrder == ModbusEnums.ByteOrder.BigEndian) {
                    regValue = (short)(0xFFFF & Input);
                    if (Index + 1 < ModbusSupport.MaximumRegisters) {
                        SetData(Index + 1, 1, Input, typeData, parent, AllowTransmit);
                    }
                }
                else if (wordOrder == ModbusEnums.ByteOrder.LittleEndian) {
                    regValue = QuickShiftDataDown(Input, 1);
                    if (Index + 1 < ModbusSupport.MaximumRegisters) {
                        SetData(Index + 1, 0, Input, typeData, parent, AllowTransmit);
                    }
                }
                ModifyValue();
                SystemManager.RegisterValueChanged(parent, this, Index, typeData);
                if ((AllowTransmit) && (parent.Manager.IsMaster)) {
                    SystemManager.SendModbusCommand(parent, typeData, "Write Register " + Index.ToString() + " = " + Value.ToString());
                }
            }
            else if (dataSize == ModbusEnums.DataSize.Bits64) {
                if (wordOrder == ModbusEnums.ByteOrder.BigEndian) {
                    regValue = (short)(0xFFFF & Input);
                    if (Index + 3 < ModbusSupport.MaximumRegisters) {
                        SetData(Index + 1, 1, Input, typeData, parent, AllowTransmit);
                        SetData(Index + 2, 2, Input, typeData, parent, AllowTransmit);
                        SetData(Index + 3, 3, Input, typeData, parent, AllowTransmit);
                    }
                }
                else if (wordOrder == ModbusEnums.ByteOrder.LittleEndian) {
                    regValue = QuickShiftDataDown(Input, 3);
                    if (Index + 3 < ModbusSupport.MaximumRegisters) {
                        SetData(Index + 1, 2, Input, typeData, parent, AllowTransmit);
                        SetData(Index + 2, 1, Input, typeData, parent, AllowTransmit);
                        SetData(Index + 3, 0, Input, typeData, parent, AllowTransmit);
                    }
                }
                SystemManager.RegisterValueChanged(parent, this, Index, typeData);
                ModifyValue();
                if ((AllowTransmit) && (parent.Manager.IsMaster)) {
                    SystemManager.SendModbusCommand(parent, typeData, "Write Register " + Index.ToString() + " = " + Value.ToString());
                }
            }
        }
        public void ModifyValue() {
            if (dataSize <= ModbusEnums.DataSize.Bits16) {
                formattedValue = Formatters.LongToString((long)(ushort)regValue, format, dataSize, signed);
            }
            else if (dataSize == ModbusEnums.DataSize.Bits32) {
                long Temp = 0;
                if (parent == null) {
                    regValue = 0;
                    Temp = (long)(ushort)regValue;
                }
                else {
                    if (Index + 1 < ModbusSupport.MaximumRegisters - 1) {
#if TEST
                            Debug.Print("Size: 32, Formatter: ");
                            Debug.Print(" - " + ((ushort)regValue).ToString());
                            Debug.Print(" - " + AppendData(Index + 1, 1, typeData, parentManager).ToString());
#endif                  
                        if (wordOrder == ModbusEnums.ByteOrder.BigEndian) {
                            Temp = (long)(ushort)regValue;
                            Temp |= AppendData(Index + 1, 1, typeData, parent);
                        }
                        else if (wordOrder == ModbusEnums.ByteOrder.LittleEndian) {
                            Temp = QuickShiftDataUp(regValue, 1);
                            Temp |= AppendData(Index + 1, 0, typeData, parent);
                        }

#if TEST
                            Debug.Print(" Results In: " + Temp.ToString());
#endif
                    }
                }
                formattedValue = Formatters.LongToString(Temp, format, dataSize, signed);
            }
            else if (dataSize == ModbusEnums.DataSize.Bits64) {
                long Temp = 0;
                if (parent == null) {
                    regValue = 0;
                    Temp = (long)(ushort)regValue;
                }
                else {
                    if (Index + 3 < ModbusSupport.MaximumRegisters - 3) {
                        if (wordOrder == ModbusEnums.ByteOrder.BigEndian) {
                            Temp = (long)(ushort)regValue;
                            Temp |= AppendData(Index + 1, 1, typeData, parent);
                            Temp |= AppendData(Index + 2, 2, typeData, parent);
                            Temp |= AppendData(Index + 3, 3, typeData, parent);
                        }
                        else if (wordOrder == ModbusEnums.ByteOrder.LittleEndian) {
                            Temp = QuickShiftDataUp(regValue, 3);
                            Temp |= AppendData(Index + 1, 2, typeData, parent);
                            Temp |= AppendData(Index + 2, 1, typeData, parent);
                            Temp |= AppendData(Index + 3, 0, typeData, parent);
                        }
                    }
                }
                formattedValue = Formatters.LongToString((long)Temp, format, dataSize, signed);
            }
        }
        #endregion
        #region Format/Size Support Functions
        private static bool CheckAndChangeNeighbouringFormats(int Index, ModbusSlave? parentManager, ModbusEnums.DataSize Size, DataSelection Selection) {
            if (parentManager == null) { return false; }
            if (parentManager.Manager == null) { return false; }
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
                if (NextIndex < ModbusSupport.MaximumRegisters) {
                    ModbusEnums.DataSize NextSize = GetDataSize(NextIndex, parentManager, Selection);
                    if (IsSizeAndDistanceInScope(NextSize, i, true) == true) {
                        ResetFormats(NextIndex, parentManager, Selection);
                    }
                }
            }
            return false;
        }
        private static void ResetFormats(int Index, ModbusSlave parentManager, DataSelection Selection) {
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
        private static ModbusEnums.DataFormat GetDataFormat(int Index, ModbusSlave parentManager, DataSelection Selection) {
            if (Selection == DataSelection.ModbusDataInputRegisters) {
                return parentManager.InputRegisters[Index].Format;
            }
            else if (Selection == DataSelection.ModbusDataHoldingRegisters) {
                return parentManager.HoldingRegisters[Index].Format;
            }
            return ModbusEnums.DataFormat.Decimal;
        }
        private static ModbusEnums.DataSize GetDataSize(int Index, ModbusSlave parentManager, DataSelection Selection) {
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
        private static void CheckPreviousRegisters(int Index, DataSelection typeData, ModbusSlave parentManager) {
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
        #endregion
        #region Data Support Functions
        private static long QuickShiftDataUp(short Input, int Shift) {
            ushort Data = (ushort)Input;
            long Output = 0;
            Output = (long)Data << (Shift * 16);
            return Output;
        }
        private static short QuickShiftDataDown(long Input, int Shift) {
            short Output = 0;
            Output = (short)((Input >> (Shift * 16)) & 0xFFFF);
            return Output;
        }
        private static long AppendData(int NextIndex, int Shift, DataSelection typeData, ModbusSlave parentManager) {
            if (parentManager == null) { return 0; }
            if (parentManager.Manager == null) { return 0; }
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
        private static void SetData(int NextIndex, int Shift, long Value, DataSelection typeData, ModbusSlave? parentManager, bool AllowTransmit) {
            if (parentManager == null) { return; }
            if (parentManager.Manager == null) { return; }
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
        #endregion
        #region File Support
        public void Set(StringPair Input) {
            if (Input.A.ToLower() == "name") {
                Name = Input.B;
            }
            else if (Input.A.ToLower() == "unit") {
                Unit = Input.B;
            }
            else if (Input.A.ToLower() == "prefix") {
                Prefix = ConversionHandler.StringToPrefix(Input.B);
            }
            else if (Input.A.ToLower() == "value") {
                short Temp = 0;
                short.TryParse(Input.B, out Temp);
                Value = Temp;
            }
            else if (Input.A.ToLower() == "wordorder") {
                WordOrder = EnumManager.StringToWordOrder(Input.B);
            }
            else if (Input.A.ToLower() == "format") {
                Format = EnumManager.StringToDataFormat(Input.B);
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
            else if (Input.A.ToLower() == "size") {
                int Temp = 0;
                int.TryParse(Input.B, out Temp);
                Size = EnumManager.IntegerToDataSize(Temp);
            }
            else if (Input.A.ToLower() == "signed") {
                Signed = (Input.B == "1" ? true : false);
            }
        }
        #endregion
        public void Reset() {
            Name = "";
            wordOrder = ModbusEnums.ByteOrder.BigEndian;
            format = ModbusEnums.DataFormat.Decimal;
            dataSize = ModbusEnums.DataSize.Bits8;
            formattedValue = "0";
            regValue = 0;
            userChanged = false;
            unit = "";
            prefix = ConversionHandler.Prefix.None;
        }
    }
}