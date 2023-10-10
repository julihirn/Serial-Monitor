using Handlers;
using ODModules;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public static class ModbusSupport {
        public const int MaximumRegisters = short.MaxValue;

        static bool applyOnChange = true;
        public static bool SendOnChange {
            get {
                return applyOnChange;
            }
            set {
                applyOnChange = value;
            }
        }

        #region Coil/Register Support
        public static bool IsRegsiterEdited(object? Input, bool CheckValues = false) {
            if (Input == null) { return false; }
            if (Input.GetType() == typeof(ModbusCoil)) {
                ModbusCoil Current = (ModbusCoil)Input;
                if (Current.Name != "") { return true; }
                if (CheckValues == true) {
                    if (Current.Value != false) { return true; }
                }
            }
            else if (Input.GetType() == typeof(Modbus.ModbusRegister)) {
                Modbus.ModbusRegister Current = (Modbus.ModbusRegister)Input;
                if (Current.Name != "") { return true; }
                if (Current.Size != Enums.ModbusEnums.DataSize.Bits16) { return true; }
                if (Current.Format != Enums.ModbusEnums.DataFormat.Decimal) { return true; }
                if (CheckValues == true) {
                    if (Current.Value != 0) { return true; }
                }
            }
            return false;
        }
        public static Structures.ValidString BulidRegisterSerialisedString(SerialManager? Manager, int Index, DataSelection Select, bool IncludeValue = false) {
            if (Manager == null) { return new ValidString(); }
            try {
                if (Select == DataSelection.ModbusDataCoils) {
                    if (Index < Manager.Coils.Count()) {
                        return BulidRegisterSerialisedString(Manager.Coils[Index], IncludeValue);
                    }
                }
                else if (Select == DataSelection.ModbusDataDiscreteInputs) {
                    if (Index < Manager.DiscreteInputs.Count()) {
                        return BulidRegisterSerialisedString(Manager.DiscreteInputs[Index], IncludeValue);
                    }
                }
                else if (Select == DataSelection.ModbusDataInputRegisters) {
                    if (Index < Manager.InputRegisters.Count()) {
                        return BulidRegisterSerialisedString(Manager.InputRegisters[Index], IncludeValue);
                    }
                }
                else if (Select == DataSelection.ModbusDataHoldingRegisters) {
                    if (Index < Manager.HoldingRegisters.Count()) {
                        return BulidRegisterSerialisedString(Manager.HoldingRegisters[Index], IncludeValue);
                    }
                }
            }
            catch { return new ValidString(); }
            return new ValidString();
        }
        public static Structures.ValidString BulidRegisterSerialisedString(object? Input, bool IncludeValue = false) {
            string Output = "";
            if (Input == null) { return new Structures.ValidString(); }
            if (IsRegsiterEdited(Input, IncludeValue) == false) { return new Structures.ValidString(); }
            if (Input.GetType() == typeof(ModbusCoil)) {
                ModbusCoil Current = (ModbusCoil)Input;
                Output += EnumManager.ModbusDataSelectionToString(Current.ComponentType).B;
                Output += ":" + Current.Address;
                Output += ":" + ((Current.Value == true) ? "1" : "0");
                Output += ":" + Current.Name;

            }
            else if (Input.GetType() == typeof(Modbus.ModbusRegister)) {
                Modbus.ModbusRegister Current = (Modbus.ModbusRegister)Input;
                Output += EnumManager.ModbusDataSelectionToString(Current.ComponentType).B;
                Output += ":" + Current.Address;
                Output += ":" + Current.Value;
                Output += ":" + EnumManager.DataFormatToString(Current.Format).B;
                Output += ":" + EnumManager.DataSizeToInteger(Current.Size).ToString();
                Output += ":" + Current.Name;
            }
            return new Structures.ValidString(Output);
        }
        public static void DecodeFileRegsisterCommand(string SerialisedString, SerialManager? CurrentManager) {
            if (CurrentManager == null) { return; }
            if (!SerialisedString.Contains(':')) { return; }
            string TempStrSelection = SerialisedString.Split(':')[0];// StringHandler.GetStringInEncapulated(SerialisedString, ':', ':', 0, 1);
            string TempStrIndex = StringHandler.GetStringInEncapulated(SerialisedString, ':', ':', 0, 1);
            string TempStrValue = StringHandler.GetStringInEncapulated(SerialisedString, ':', ':', 1, 2);
            int Index = -1; int.TryParse(TempStrIndex, out Index);
            short Value = 0;
            int DataSize = 16;
            DataSelection Selection = EnumManager.ModbusStringToDataSelection(TempStrSelection);
            try {
                switch (Selection) {
                    case DataSelection.ModbusDataCoils:
                        CurrentManager.Coils[Index].Value = (TempStrValue == "1" ? true : false);
                        CurrentManager.Coils[Index].Name = StringHandler.GetStringInEncapulated(SerialisedString, ':', ':', 2, -1);
                        break;

                    case DataSelection.ModbusDataDiscreteInputs:
                        CurrentManager.DiscreteInputs[Index].Value = (TempStrValue == "1" ? true : false);
                        CurrentManager.DiscreteInputs[Index].Name = StringHandler.GetStringInEncapulated(SerialisedString, ':', ':', 2, -1);
                        break;
                    case DataSelection.ModbusDataInputRegisters:
                        short.TryParse(TempStrValue, out Value);
                        CurrentManager.InputRegisters[Index].Format = EnumManager.StringToDataFormat(StringHandler.GetStringInEncapulated(SerialisedString, ':', ':', 2, 3));
                        int.TryParse(StringHandler.GetStringInEncapulated(SerialisedString, ':', ':', 3, 4), out DataSize);
                        CurrentManager.InputRegisters[Index].Size = EnumManager.IntegerToDataSize(DataSize);
                        CurrentManager.InputRegisters[Index].Value = Value;
                        CurrentManager.InputRegisters[Index].Name = StringHandler.GetStringInEncapulated(SerialisedString, ':', ':', 4, -1);
                        break;
                    case DataSelection.ModbusDataHoldingRegisters:
                        short.TryParse(TempStrValue, out Value);
                        CurrentManager.HoldingRegisters[Index].Format = EnumManager.StringToDataFormat(StringHandler.GetStringInEncapulated(SerialisedString, ':', ':', 2, 3));
                        int.TryParse(StringHandler.GetStringInEncapulated(SerialisedString, ':', ':', 3, 4), out DataSize);
                        CurrentManager.HoldingRegisters[Index].Size = EnumManager.IntegerToDataSize(DataSize);
                        CurrentManager.HoldingRegisters[Index].Value = Value;
                        CurrentManager.HoldingRegisters[Index].Name = StringHandler.GetStringInEncapulated(SerialisedString, ':', ':', 4, -1);
                        break;

                    default:
                        return;
                }
            }
            catch { }
        }
        public static List<RegisterRequest> GetModifiedRegisters(SerialManager? CurrentManager) {
            List<RegisterRequest> Registers = new List<RegisterRequest>();
            if (CurrentManager == null) { return Registers; }
            try {
                for (int i = 0; i < MaximumRegisters; i++) {
                    if (i < CurrentManager.Coils.Count()) {
                        bool Result = IsRegsiterEdited(CurrentManager.Coils[i]);
                        if (Result == true) {
                            Registers.Add(new RegisterRequest(i, DataSelection.ModbusDataCoils));
                        }
                    }
                    if (i < CurrentManager.DiscreteInputs.Count()) {
                        bool Result = IsRegsiterEdited(CurrentManager.DiscreteInputs[i]);
                        if (Result == true) {
                            Registers.Add(new RegisterRequest(i, DataSelection.ModbusDataDiscreteInputs));
                        }
                    }
                    if (i < CurrentManager.InputRegisters.Count()) {
                        bool Result = IsRegsiterEdited(CurrentManager.InputRegisters[i]);
                        if (Result == true) {
                            Registers.Add(new RegisterRequest(i, DataSelection.ModbusDataInputRegisters));
                        }
                    }
                    if (i < CurrentManager.HoldingRegisters.Count()) {
                        bool Result = IsRegsiterEdited(CurrentManager.HoldingRegisters[i]);
                        if (Result == true) {
                            Registers.Add(new RegisterRequest(i, DataSelection.ModbusDataHoldingRegisters));
                        }
                    }
                }
            }
            catch { }
            return Registers;
        }
        
        #endregion
        #region Snapshots
        public static List<ModbusSnapshot> Snapshots = new List<ModbusSnapshot>();
        public static void NewSnapshot(SerialManager Serman, DataSelection Selection, int Index, int Count) {
            ModbusSnapshot Snap = new ModbusSnapshot(Serman, Selection, Index, Count);
            Snapshots.Add(Snap);
        }
        public static void NewSnapshot(SerialManager Serman, DataSelection Selection, int Index, int Count, Rectangle Bounds) {
            ModbusSnapshot Snap = new ModbusSnapshot(Serman, Selection, Index, Count, Bounds);
            Snapshots.Add(Snap);
        }
        public static void NewSnapshot(SerialManager Serman, DataSelection Selection, List<int> Indices) {
            ModbusSnapshot Snap = new ModbusSnapshot(Serman, Selection, Indices);
            Snapshots.Add(Snap);
        }
        public static void NewSnapshot(SerialManager Serman, DataSelection Selection, List<int> Indices, Rectangle Bounds) {
            ModbusSnapshot Snap = new ModbusSnapshot(Serman, Selection, Indices, Bounds);
            Snapshots.Add(Snap);
        }
        public static ToolWindows.ModbusRegister NewSnapshotForm(string Name, SerialManager Serman, DataSelection Selection, int Index, int Count) {
            ModbusSnapshot Snap = new ModbusSnapshot(Serman, Selection, Index, Count);
            Snap.Name = Name;
            Snapshots.Add(Snap);
            ToolWindows.ModbusRegister frm = new ToolWindows.ModbusRegister(Snap);
            return frm;
        }
        public static ToolWindows.ModbusRegister NewSnapshotForm(string Name, SerialManager Serman, DataSelection Selection, List<int> Indices) {
            ModbusSnapshot Snap = new ModbusSnapshot(Serman, Selection, Indices);
            Snap.Name = Name;
            Snapshots.Add(Snap);
            ToolWindows.ModbusRegister frm = new ToolWindows.ModbusRegister(Snap);
            return frm;
        }
        public static void CloseSnapshot(SerialManager Manager) {
            for (int i = Snapshots.Count - 1; i >= 0; i--) {
                SerialManager? CurrentManager = Snapshots[i].Manager;
                if (CurrentManager != null) {
                    if (CurrentManager.ID == Manager.ID) {
                        Snapshots[i].Close();
                        Snapshots.RemoveAt(i);
                    }
                }
            }
            GC.Collect();
        }
        public static void RemoveSnapshot(ModbusSnapshot Snapshot) {
            for (int i = Snapshots.Count - 1; i >= 0; i--) {
                if (Snapshots[i].ID == Snapshot.ID) {
                    Snapshots[i].Close();
                    Snapshots.RemoveAt(i);
                }
            }
            GC.Collect();
        }
        public static void ClearSnapshots() {
            for (int i = Snapshots.Count - 1; i >= 0; i--) {
                SerialManager? CurrentManager = Snapshots[i].Manager;
                if (CurrentManager != null) {
                    Snapshots[i].Close();
                    Snapshots.RemoveAt(i);
                }
            }
            GC.Collect();
        }
        public static bool IsModbusFrameVaild(byte[] InputBuffer, int Length) {
            if (Length < 6) { return false; }
            if (InputBuffer[0] < 1 | InputBuffer[0] > 247) { return false; }
            byte[] CRC = new byte[2];
            CRC = BitConverter.GetBytes(CalculateCRC(InputBuffer, (ushort)(Length - 2), 0));
            if (CRC[0] != InputBuffer[Length - 2] | CRC[1] != InputBuffer[Length - 1]) {
                return false;
            }
            return true;
        }
        #endregion
        #region Modbus CRC
        public static ushort CalculateCRC(byte[] Input, ushort BytesCount, int Start) {
            byte[] auchCRCHi = {
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01,
            0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0,
            0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01,
            0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81,
            0x40
            };

            byte[] auchCRCLo = {
            0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7, 0x05, 0xC5, 0xC4,
            0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E, 0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09,
            0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9, 0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD,
            0x1D, 0x1C, 0xDC, 0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
            0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32, 0x36, 0xF6, 0xF7,
            0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D, 0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A,
            0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38, 0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE,
            0x2E, 0x2F, 0xEF, 0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
            0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1, 0x63, 0xA3, 0xA2,
            0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4, 0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F,
            0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB, 0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB,
            0x7B, 0x7A, 0xBA, 0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
            0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0, 0x50, 0x90, 0x91,
            0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97, 0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C,
            0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E, 0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88,
            0x48, 0x49, 0x89, 0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
            0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83, 0x41, 0x81, 0x80,
            0x40
            };
            ushort usDataLen = BytesCount;
            byte uchCRCHi = 0xFF;
            byte uchCRCLo = 0xFF;
            int i = 0;
            int uIndex;
            while (usDataLen > 0) {
                usDataLen--;
                if (i + Start < Input.Length) {
                    uIndex = uchCRCLo ^ Input[i + Start];
                    uchCRCLo = (byte)(uchCRCHi ^ auchCRCHi[uIndex]);
                    uchCRCHi = auchCRCLo[uIndex];
                }
                i++;
            }
            return (ushort)(uchCRCHi << 8 | uchCRCLo);
        }
        #endregion
        #region Display Codes
        public static string FunctionCodeToString(FunctionCode Code) {
            switch (Code) {
                case FunctionCode.ReadDiscreteInputs:
                    return "Read Discrete Inputs";
                case FunctionCode.ReadCoils:
                    return "Read Coils";
                case FunctionCode.WriteSingleCoil:
                    return "Write Single Coils";
                case FunctionCode.WriteMultipleCoils:
                    return "Write Multiple Coils";
                case FunctionCode.ReadInputRegisters:
                    return "Read Input Registers";
                case FunctionCode.ReadHoldingRegisters:
                    return "Read Multiple Holding Registers";
                case FunctionCode.WriteSingleHoldingRegister:
                    return "Write Single Holding Register";
                case FunctionCode.WriteMultipleHoldingRegisters:
                    return "Write Multiple Holding Registers";
                default:
                    return "";
            }
        }
        #endregion 
        public enum FunctionCode {
            NoCommand = 0x00,
            ReadDiscreteInputs = 0x02,
            ReadCoils = 0x01,
            WriteSingleCoil = 0x05,
            WriteMultipleCoils = 0x0F,
            ReadInputRegisters = 0x04,
            ReadHoldingRegisters = 0x03,
            WriteSingleHoldingRegister = 0x06,
            WriteMultipleHoldingRegisters = 0x10
        }
    }
}
