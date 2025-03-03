using FastColoredTextBoxNS;
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
                UpdateLastUpdate();
                ModifyValue();
                if (Parent != null) {
                    if (Parent.Channel != null) {
                        CheckPreviousRegisters(Index, typeData, Parent);
                    }
                }
                SystemManager.RegisterValueChanged(parent, this, Index, typeData);
            }
        }
        string formattedValue = "0";
        public string FormattedValue {
            get { return FormatDecimal(formattedValue, decimalFormat, format); }
            //set {
            //    formattedValue = value;
            //    SystemManager.RegisterValueChanged(parent, this, Index, typeData);
            //}
        }
        public string ValueWithUnit {
            get {
                if (ProjectManager.ShowUnits == false) {
                    //if (format >= ModbusEnums.DataFormat.Float) {
                    //    return FormatDecimal(formattedValue, decimalFormat);
                    //}
                    //else {
                    //    return formattedValue;
                    //}
                    return FormattedValue;
                }
                switch (format) {
                    case ModbusEnums.DataFormat.Decimal:
                        return FormattedValue + GetUnitString();
                    case ModbusEnums.DataFormat.Float:
                        return FormattedValue + GetUnitString(); //FormatDecimal(formattedValue, decimalFormat) + GetUnitString();
                    case ModbusEnums.DataFormat.Double:
                        return FormattedValue + GetUnitString(); //FormatDecimal(formattedValue, decimalFormat) + GetUnitString();
                }
                return FormattedValue;
            }
        }
        private static string FormatDecimal(string Input, ModbusEnums.FloatFormat Frmt, ModbusEnums.DataFormat Format) {
            if (Frmt == ModbusEnums.FloatFormat.None) { return Input; }
            if (Format < ModbusEnums.DataFormat.Float) { return Input; }
            decimal Out = 0.0m;
            decimal.TryParse(Input, out Out);
            return Out.ToString(EnumManager.FloatFormatToString(Frmt).A);
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
                //if (value == ModbusEnums.DataFormat.Float) {
                //    dataSize = ModbusEnums.DataSize.Bits32;
                //    signed = false;
                //}
                //else if (value == ModbusEnums.DataFormat.Double) {
                //    dataSize = ModbusEnums.DataSize.Bits64;
                //    signed = false;
                //}
                //else if (value == ModbusEnums.DataFormat.Char) {
                //    dataSize = ModbusEnums.DataSize.Bits16;
                //    signed = false;
                //}
                if (value == ModbusEnums.DataFormat.Float) {
                    if (dataSize != ModbusEnums.DataSize.Bits32) {
                        dataSize = ModbusEnums.DataSize.Bits32;
                    }
                }
                else if (value == ModbusEnums.DataFormat.Double) {
                    if (dataSize != ModbusEnums.DataSize.Bits64) {
                        dataSize = ModbusEnums.DataSize.Bits64;
                    }
                }
                else if (value == ModbusEnums.DataFormat.Char) {
                    if (dataSize != ModbusEnums.DataSize.Bits16) {
                        dataSize = ModbusEnums.DataSize.Bits16;
                    }
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
                //if (format == ModbusEnums.DataFormat.Float) {
                //    dataSize = ModbusEnums.DataSize.Bits32;
                //    signed = false;
                //}
                //else if (format == ModbusEnums.DataFormat.Double) {
                //    dataSize = ModbusEnums.DataSize.Bits64;
                //    signed = false;
                //}
                //else if (format == ModbusEnums.DataFormat.Char) {
                //    dataSize = ModbusEnums.DataSize.Bits16;
                //    signed = false;
                //}
                //else {
                //    dataSize = value;
                //}
                if (value != ModbusEnums.DataSize.Bits32) {
                    if (format == ModbusEnums.DataFormat.Float) {
                        format = ModbusEnums.DataFormat.Decimal;
                    }
                }
                else if (value != ModbusEnums.DataSize.Bits64) {
                    if (format == ModbusEnums.DataFormat.Double) {
                        format = ModbusEnums.DataFormat.Decimal;
                    }
                }
                else if (value != ModbusEnums.DataSize.Bits16) {
                    if (format == ModbusEnums.DataFormat.Char) {
                        format = ModbusEnums.DataFormat.Decimal;
                    }
                }
                dataSize = value;

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
        ModbusEnums.FloatFormat decimalFormat = ModbusEnums.FloatFormat.None;
        public ModbusEnums.FloatFormat DecimalFormat {
            get { return decimalFormat; }
            set {
                decimalFormat = value;
                ModifyValue();
                SystemManager.ModbusRegisterPropertyChanged(parent, this, Index, typeData);
            }
        }
        #endregion
        #region Value Modification
        public void PushValue(long Input, bool AllowTransmit) {
            if (parent == null) { return; }
            if (parent.Channel == null) { return; }
            if (dataSize <= ModbusEnums.DataSize.Bits16) {
                short Temp = (short)(0xFFFF & Input);
                regValue = Temp;
                ModifyValue();
                if (parent != null) {
                    CheckPreviousRegisters(Index, typeData, parent);
                }
                SystemManager.RegisterValueChanged(parent, this, Index, typeData);
                if (parent != null) {
                    if ((AllowTransmit) && (parent.Channel.IsMaster)) {
                        SystemManager.SendModbusCommand(parent, typeData, "Write Register " + Index.ToString() + " = " + Value.ToString());
                    }
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
                else if (wordOrder == ModbusEnums.ByteOrder.BigEndianByteSwap) {
                    regValue = (short)SwapBytesAndCombine((ushort)(0xFFFF & Input), true);
                    if (Index + 1 < ModbusSupport.MaximumRegisters) {
                        SetData(Index + 1, 1, Input, typeData, parent, AllowTransmit, true);
                    }
                }
                else if (wordOrder == ModbusEnums.ByteOrder.LittleEndianByteSwap) {
                    regValue = QuickShiftDataDown(Input, 1, true);
                    if (Index + 1 < ModbusSupport.MaximumRegisters) {
                        SetData(Index + 1, 0, Input, typeData, parent, AllowTransmit, true);
                    }
                }
                ModifyValue();
                SystemManager.RegisterValueChanged(parent, this, Index, typeData);
                if ((AllowTransmit) && (parent.Channel.IsMaster)) {
                    SystemManager.SendModbusCommand(parent, typeData, "Write Register " + Index.ToString() + " = " + Value.ToString());
                }
            }
            else if (dataSize == ModbusEnums.DataSize.Bits64) {
                if (wordOrder == ModbusEnums.ByteOrder.LittleEndian) {
                    regValue = (short)(0xFFFF & Input);
                    if (Index + 3 < ModbusSupport.MaximumRegisters) {
                        SetData(Index + 1, 1, Input, typeData, parent, AllowTransmit);
                        SetData(Index + 2, 2, Input, typeData, parent, AllowTransmit);
                        SetData(Index + 3, 3, Input, typeData, parent, AllowTransmit);
                    }
                }
                else if (wordOrder == ModbusEnums.ByteOrder.BigEndian) {
                    regValue = QuickShiftDataDown(Input, 3);
                    if (Index + 3 < ModbusSupport.MaximumRegisters) {
                        SetData(Index + 1, 2, Input, typeData, parent, AllowTransmit);
                        SetData(Index + 2, 1, Input, typeData, parent, AllowTransmit);
                        SetData(Index + 3, 0, Input, typeData, parent, AllowTransmit);
                    }
                }
                else if (wordOrder == ModbusEnums.ByteOrder.LittleEndianByteSwap) {
                    regValue = (short)SwapBytesAndCombine((ushort)(0xFFFF & Input), true);
                    if (Index + 3 < ModbusSupport.MaximumRegisters) {
                        SetData(Index + 1, 1, Input, typeData, parent, AllowTransmit, true);
                        SetData(Index + 2, 2, Input, typeData, parent, AllowTransmit);
                        SetData(Index + 3, 3, Input, typeData, parent, AllowTransmit, true);
                    }
                }
                else if (wordOrder == ModbusEnums.ByteOrder.BigEndianByteSwap) {
                    regValue = QuickShiftDataDown(Input, 3, true);
                    if (Index + 3 < ModbusSupport.MaximumRegisters) {
                        SetData(Index + 1, 2, Input, typeData, parent, AllowTransmit, true);
                        SetData(Index + 2, 1, Input, typeData, parent, AllowTransmit, true);
                        SetData(Index + 3, 0, Input, typeData, parent, AllowTransmit, true);
                    }
                }
                SystemManager.RegisterValueChanged(parent, this, Index, typeData);
                ModifyValue();
                if ((AllowTransmit) && (parent.Channel.IsMaster)) {
                    SystemManager.SendModbusCommand(parent, typeData, "Write Register " + Index.ToString() + " = " + Value.ToString());
                }
            }
            UpdateLastUpdate();
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
                        else if (wordOrder == ModbusEnums.ByteOrder.BigEndianByteSwap) {
                            Temp = QuickShiftDataUp(regValue, 0, true);
                            Temp |= AppendData(Index + 1, 1, typeData, parent, true);
                        }
                        else if (wordOrder == ModbusEnums.ByteOrder.LittleEndianByteSwap) {
                            Temp = QuickShiftDataUp(regValue, 1, true);
                            Temp |= AppendData(Index + 1, 0, typeData, parent, true);
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
                        else if (wordOrder == ModbusEnums.ByteOrder.BigEndianByteSwap) {
                            Temp = QuickShiftDataUp(regValue, 0, true);
                            Temp |= AppendData(Index + 1, 1, typeData, parent, true);
                            Temp |= AppendData(Index + 2, 2, typeData, parent, true);
                            Temp |= AppendData(Index + 3, 3, typeData, parent, true);
                        }
                        else if (wordOrder == ModbusEnums.ByteOrder.LittleEndianByteSwap) {
                            Temp = QuickShiftDataUp(regValue, 3, true);
                            Temp |= AppendData(Index + 1, 2, typeData, parent, true);
                            Temp |= AppendData(Index + 2, 1, typeData, parent, true);
                            Temp |= AppendData(Index + 3, 0, typeData, parent, true);
                        }
                    }
                }
                formattedValue = Formatters.LongToString((long)Temp, format, dataSize, signed);
            }
            UpdateLastUpdate();
        }
        #endregion
        #region Format/Size Support Functions
        private static bool CheckAndChangeNeighbouringFormats(int Index, ModbusSlave? parentManager, ModbusEnums.DataSize Size, DataSelection Selection) {
            if (parentManager == null) { return false; }
            if (parentManager.Channel == null) { return false; }
            int ItemsToCheck = 0;
            if (Size == ModbusEnums.DataSize.Bits32) { ItemsToCheck = 3; }
            else if (Size == ModbusEnums.DataSize.Bits64) { ItemsToCheck = 3; }
            else { return false; }
            for (int i = 1; i <= ItemsToCheck; i++) {
                int NextIndex = Index - i;
                if (NextIndex >= 0) {
                    ModbusEnums.DataSize NextSize = GetDataSize(NextIndex, parentManager, Selection);
                    if (IsSizeAndDistanceInScope(Size, NextSize, i, true) == true) {
                        ResetFormats(NextIndex, parentManager, Selection);
                    }
                }
            }
            for (int i = 1; i <= ItemsToCheck; i++) {
                int NextIndex = Index + i;
                if (NextIndex < ModbusSupport.MaximumRegisters) {
                    ModbusEnums.DataSize NextSize = GetDataSize(NextIndex, parentManager, Selection);
                    if (IsSizeAndDistanceInScope(Size, NextSize, i, false) == true) {
                        ResetFormats(NextIndex, parentManager, Selection);
                    }
                }
            }
            return false;
        }
        internal void DefaultSize() {
            this.dataSize = ModbusEnums.DataSize.Bits16;
            ModifyValue();
            SystemManager.ModbusRegisterPropertyChanged(parent, this, Index, typeData);
        }
        internal void DefaultFormat() {
            this.format = ModbusEnums.DataFormat.Decimal;
            ModifyValue();
            SystemManager.ModbusRegisterPropertyChanged(parent, this, Index, typeData);
        }
        private static void ResetFormats(int Index, ModbusSlave parentManager, DataSelection Selection) {
            ModbusEnums.DataSize CurrentSize = GetDataSize(Index, parentManager, Selection);
            ModbusEnums.DataFormat CurrentFormat = GetDataFormat(Index, parentManager, Selection);
            if (CurrentSize < ModbusEnums.DataSize.Bits32) { return; }
            if (Selection == DataSelection.ModbusDataInputRegisters) {
                if ((CurrentFormat == ModbusEnums.DataFormat.Float) || (CurrentFormat == ModbusEnums.DataFormat.Double)) {
                    parentManager.InputRegisters[Index].DefaultFormat();
                }
                parentManager.InputRegisters[Index].DefaultSize();
            }
            else if (Selection == DataSelection.ModbusDataHoldingRegisters) {
                if ((CurrentFormat == ModbusEnums.DataFormat.Float) || (CurrentFormat == ModbusEnums.DataFormat.Double)) {
                    parentManager.HoldingRegisters[Index].DefaultFormat();
                }
                parentManager.HoldingRegisters[Index].DefaultSize();
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
        private static bool IsSizeAndDistanceInScope(ModbusEnums.DataSize CentreSize, ModbusEnums.DataSize Size, int Distance, bool Above) {
            if (CentreSize == ModbusEnums.DataSize.Bits32) {
                if (Size == ModbusEnums.DataSize.Bits32) {
                    if (Distance <= 1) { return true; }
                    return false;
                }
                else if (Size == ModbusEnums.DataSize.Bits64) {
                    if (Above) {
                        if (Distance <= 3) { return true; }
                    }
                    else {
                        if (Distance <= 1) { return true; }
                    }
                    return false;
                }
                return false;
            }
            else if (CentreSize == ModbusEnums.DataSize.Bits64) {
                if (Size == ModbusEnums.DataSize.Bits32) {
                    if (Above) {
                        if (Distance <= 1) { return true; }
                    }
                    else {
                        if (Distance <= 3) { return true; }
                    }
                    return false;
                }
                else if (Size == ModbusEnums.DataSize.Bits64) {
                    if (Distance <= 3) { return true; }
                    return false;
                }
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
        private static long QuickShiftDataUp(short Input, int Shift, bool ByteSwap = false) {
            ushort Data = SwapBytesAndCombine((ushort)Input, ByteSwap);
            long Output = 0;
            Output = (long)Data << (Shift * 16);
            return Output;
        }
        private static short QuickShiftDataDown(long Input, int Shift, bool ByteSwap = false) {
            short Output = 0;
            Output = (short)SwapBytesAndCombine((ushort)((Input >> (Shift * 16)) & 0xFFFF), ByteSwap);
            return Output;
        }
        private static long AppendData(int NextIndex, int Shift, DataSelection typeData, ModbusSlave parentManager, bool SwapBytes = false) {
            if (parentManager == null) { return 0; }
            if (parentManager.Channel == null) { return 0; }
            if (typeData == DataSelection.ModbusDataInputRegisters) {
                if (parentManager.InputRegisters.Length <= NextIndex) { return 0; }
                ushort Data = SwapBytesAndCombine((ushort)parentManager.InputRegisters[NextIndex].Value, SwapBytes);
                long Output = 0;
                Output = (long)Data << (Shift * 16);
                return Output;
            }
            else if (typeData == DataSelection.ModbusDataHoldingRegisters) {
                if (parentManager.HoldingRegisters.Length <= NextIndex) { return 0; }
                ushort Data = SwapBytesAndCombine((ushort)parentManager.HoldingRegisters[NextIndex].Value, SwapBytes);
                long Output = 0;
                Output = (long)Data << (Shift * 16);
                return Output;
            }
            return 0;
        }
        private static ushort SwapBytesAndCombine(ushort Input, bool Swap) {
            if (Swap == false) { return Input; }
            ushort Temp = (ushort)((Input << 8) | ((Input >> 8) & 0x0F));
            return Temp;
        }
        private static void SetData(int NextIndex, int Shift, long Value, DataSelection typeData, ModbusSlave? parentManager, bool AllowTransmit, bool ByteSwap = false) {
            if (parentManager == null) { return; }
            if (parentManager.Channel == null) { return; }
            if (typeData == DataSelection.ModbusDataInputRegisters) {
                if (parentManager.InputRegisters.Length <= NextIndex) { return; }
                long Temp = Value >> (Shift * 16);
                ushort Output = SwapBytesAndCombine((ushort)(Temp & 0xFFFF), ByteSwap);
                parentManager.InputRegisters[NextIndex].PushValue((long)Output, AllowTransmit);
            }
            else if (typeData == DataSelection.ModbusDataHoldingRegisters) {
                if (parentManager.HoldingRegisters.Length <= NextIndex) { return; }
                long Temp = Value >> (Shift * 16);
                ushort Output = SwapBytesAndCombine((ushort)(Temp & 0xFFFF), ByteSwap);
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
            else if (Input.A.ToLower() == "decimalformat") {
                DecimalFormat = EnumManager.StringToFloatFormat(Input.B);
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
            dataSize = ModbusEnums.DataSize.Bits16;
            formattedValue = "0";
            regValue = 0;
            userChanged = false;
            unit = "";
            prefix = ConversionHandler.Prefix.None;
        }
    }
}