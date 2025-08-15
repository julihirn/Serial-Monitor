using Handlers;
using ODModules;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.Enums.FormatEnums;

namespace Serial_Monitor.Classes.Modbus {
    public static class ModbusSupport {
        public static event SnapshotClosedHandler? SnapshotClosed;
        public delegate void SnapshotClosedHandler();

        public const int MaximumRegisters = ushort.MaxValue;
        public const int MaximumDevices = 247;

        static bool applyOnChange = true;
        public static bool SendOnChange {
            get {
                return applyOnChange;
            }
            set {
                applyOnChange = value;
            }
        }

        public static void SnapshotClosedApp() {
            SnapshotClosed?.Invoke();
        }

        #region Coil/Register Support
        public static bool IsRegisterEdited(object? Input, bool CheckValues = false) {
            if (Input == null) { return false; }
            if (Input.GetType() == typeof(ModbusCoil)) {
                ModbusCoil Current = (ModbusCoil)Input;
                if (Current.Name != "") { return true; }
                if (CheckValues == true) {
                    if (Current.Value != false) { return true; }
                }
                if (Current.Format != Enums.ModbusEnums.CoilFormat.Boolean) { return true; }
                if (Current.UseForeColor == true) { return true; }
                if (Current.UseBackColor == true) { return true; }
            }
            else if (Input.GetType() == typeof(Modbus.ModbusRegister)) {
                Modbus.ModbusRegister Current = (Modbus.ModbusRegister)Input;
                if (Current.Name != "") { return true; }
                if (Current.Size != Enums.ModbusEnums.DataSize.Bits16) { return true; }
                if (Current.Format != Enums.ModbusEnums.DataFormat.Decimal) { return true; }
                if (Current.WordOrder != Enums.ModbusEnums.ByteOrder.BigEndian) { return true; }
                if (Current.Unit != "") { return true; }
                if (Current.Prefix != ConversionHandler.Prefix.None) { return true; }
                if (CheckValues == true) {
                    if (Current.Value != 0) { return true; }
                }
                if (Current.UseForeColor == true) { return true; }
                if (Current.UseForeColor == true) { return true; }
                if (Current.DecimalFormat != Enums.ModbusEnums.FloatFormat.None) { return true; }
            }
            return false;
        }
        public static Structures.ValidString BulidRegisterSerialisedString(SerialManager? Manager, int Unit, int Address, DataSelection Select, bool IncludeValue = false) {
            if (Manager == null) { return new ValidString(); }
            if (Manager.Registers == null) { return new ValidString(); }
            try {
                if (Unit <= -1) {
                    if (Select == DataSelection.ModbusDataCoils) {
                        if (Address < Manager.Registers.Coils.Count()) {
                            return BulidRegisterSerialisedString(Manager.Registers.Coils[Address], IncludeValue);
                        }
                    }
                    else if (Select == DataSelection.ModbusDataDiscreteInputs) {
                        if (Address < Manager.Registers.DiscreteInputs.Count()) {
                            return BulidRegisterSerialisedString(Manager.Registers.DiscreteInputs[Address], IncludeValue);
                        }
                    }
                    else if (Select == DataSelection.ModbusDataInputRegisters) {
                        if (Address < Manager.Registers.InputRegisters.Count()) {
                            return BulidRegisterSerialisedString(Manager.Registers.InputRegisters[Address], IncludeValue);
                        }
                    }
                    else if (Select == DataSelection.ModbusDataHoldingRegisters) {
                        if (Address < Manager.Registers.HoldingRegisters.Count()) {
                            return BulidRegisterSerialisedString(Manager.Registers.HoldingRegisters[Address], IncludeValue);
                        }
                    }
                }
                else {
                    if (Unit < 0) { new ValidString(); }
                    if (Select == DataSelection.ModbusDataCoils) {
                        if (Address < Manager.Slave[Unit].Coils.Count()) {
                            return BulidRegisterSerialisedString(Manager.Slave[Unit].Coils[Address], IncludeValue);
                        }
                    }
                    else if (Select == DataSelection.ModbusDataDiscreteInputs) {
                        if (Address < Manager.Slave[Unit].DiscreteInputs.Count()) {
                            return BulidRegisterSerialisedString(Manager.Slave[Unit].DiscreteInputs[Address], IncludeValue);
                        }
                    }
                    else if (Select == DataSelection.ModbusDataInputRegisters) {
                        if (Address < Manager.Slave[Unit].InputRegisters.Count()) {
                            return BulidRegisterSerialisedString(Manager.Slave[Unit].InputRegisters[Address], IncludeValue);
                        }
                    }
                    else if (Select == DataSelection.ModbusDataHoldingRegisters) {
                        if (Address < Manager.Slave[Unit].HoldingRegisters.Count()) {
                            return BulidRegisterSerialisedString(Manager.Slave[Unit].HoldingRegisters[Address], IncludeValue);
                        }
                    }
                }
            }
            catch { return new ValidString(); }
            return new ValidString();
        }
        public static Structures.ValidString BulidRegisterSerialisedString(object? Input, bool IncludeValue = false) {
            string Output = "";
            if (Input == null) { return new Structures.ValidString(); }
            if (IsRegisterEdited(Input, IncludeValue) == false) { return new Structures.ValidString(); }
            if (Input.GetType() == typeof(ModbusCoil)) {
                ModbusCoil Current = (ModbusCoil)Input;
                string Address = EnumManager.ModbusDataSelectionToString(Current.ComponentType, true).B + Current.Address;
                List<string> Values = new List<string>();
                Values.Add(Address);
                if (Current.Name.Length > 0) {
                    Values.Add(TagData("Name", Current.Name));
                }
                if (Current.UseBackColor) {
                    Values.Add(TagData("BackColor", Current.GetThemeIndependantBackColor().ToArgb()));
                }
                if (Current.Format != Enums.ModbusEnums.CoilFormat.Boolean) {
                    Values.Add(TagData("Format", EnumManager.CoilFormatToString(Current.Format).B));
                }
                if (Current.UseForeColor) {
                    Values.Add(TagData("ForeColor", Current.GetThemeIndependantForeColor().ToArgb()));
                }
                Values.Add(TagData("Value", Current.Value));

                Output = GenerateCommaSeperatedValues(Values);
            }
            else if (Input.GetType() == typeof(Modbus.ModbusRegister)) {
                Modbus.ModbusRegister Current = (Modbus.ModbusRegister)Input;
                string Address = EnumManager.ModbusDataSelectionToString(Current.ComponentType, true).B + Current.Address;
                List<string> Values = new List<string>();
                Values.Add(Address);
                if (Current.Name.Length > 0) {
                    Values.Add(TagData("Name", Current.Name));
                }
                if (Current.Format != Enums.ModbusEnums.DataFormat.Decimal) {
                    Values.Add(TagData("Format", EnumManager.DataFormatToString(Current.Format).B));
                }
                if (Current.Size != Enums.ModbusEnums.DataSize.Bits16) {
                    Values.Add(TagData("Size", EnumManager.DataSizeToInteger(Current.Size)));
                }
                if (Current.WordOrder != Enums.ModbusEnums.ByteOrder.BigEndian) {
                    Values.Add(TagData("WordOrder", EnumManager.WordOrderToString(Current.WordOrder).B));
                }
                if (Current.Unit != "") {
                    Values.Add(TagData("Unit", Current.Unit));
                }
                if (Current.Prefix != ConversionHandler.Prefix.None) {
                    Values.Add(TagData("Prefix", ConversionHandler.PrefixToSymbol(Current.Prefix)));
                }
                if (Current.DecimalFormat != Enums.ModbusEnums.FloatFormat.None) {
                    Values.Add(TagData("DecimalFormat", EnumManager.FloatFormatToString(Current.DecimalFormat).B));
                }
                Values.Add(TagData("Signed", Current.Signed));
                Values.Add(TagData("Value", Current.Value));
                if (Current.UseBackColor) {
                    Values.Add(TagData("BackColor", Current.GetThemeIndependantBackColor().ToArgb()));
                }
                if (Current.UseForeColor) {
                    Values.Add(TagData("ForeColor", Current.GetThemeIndependantForeColor().ToArgb()));
                }
                Output = GenerateCommaSeperatedValues(Values);
            }
            return new Structures.ValidString(Output);
        }
        private static string GenerateCommaSeperatedValues(List<string> Values) {
            string Output = "";
            for (int i = 0; i < Values.Count; i++) {
                Output += Values[i];
                if (i < Values.Count - 1) { Output += ", "; }
            }
            return Output;
        }
        private static string TagData(string Name, string Value) {
            return Name + " = " + StringHandler.EncapsulateString(Value);
        }
        private static string TagData(string Name, bool Value) {
            return Name + " = " + ((Value == true) ? "1" : "0");
        }
        private static string TagData(string Name, int Value) {
            return Name + " = " + Value.ToString();
        }
        private static string TagData(string Name, short Value) {
            return Name + " = " + Value.ToString();
        }
        private static List<StringPair> GetTaggedData(string Input) {
            List<StringPair> Output = new List<StringPair>();
            STR_MVSSF Spilts = StringHandler.SpiltStringMutipleValues(Input, ',');
            List<string> Values = new List<string>();
            for (int i = 0; i < Spilts.Count; i++) {
                if (i == 0) {
                    Values.Add(Spilts.Value[i]);
                }
                else {
                    if (Regex.IsMatch(Spilts.Value[i], "\\s*[A-Za-z]+\\s*=\\s*(?:(\\-{0,1}\\d+.\\d*)|\\-{0,1}\\d+)\\s*")) {
                        Values.Add(Spilts.Value[i]);
                    }
                    else if (Regex.IsMatch(Spilts.Value[i], "\\s*[A-Za-z]+\\s*=\\s*(?:\\\"[\\w\\s\\D]+\\\")\\s*")) {
                        Values.Add(Spilts.Value[i]);
                    }
                    else {
                        Values[Values.Count - 1] += "," + Spilts.Value[i];
                    }
                }
            }
            for (int i = 0; i < Values.Count; i++) {
                string Temp = Values[i].TrimStart(' ');
                try {
                    if (Temp.Contains("=")) {
                        string Name = Temp.Split('=')[0].Trim(' ');
                        string Assignment = StringHandler.SpiltAndCombineAfter(Temp, '=', 1).Value[1].TrimStart(' ').TrimEnd(' ');
                        if (Assignment.StartsWith('\"') && Assignment.EndsWith('\"')) {
                            Assignment = Assignment.Remove(Assignment.Length - 1, 1);
                            Assignment = Assignment.Remove(0, 1);
                        }
                        else if (Assignment.StartsWith('\'') && Assignment.EndsWith('\'')) {
                            Assignment = Assignment.Remove(Assignment.Length - 1, 1);
                            Assignment = Assignment.Remove(0, 1);
                        }
                        Output.Add(new StringPair(Name, Assignment));
                    }
                }
                catch { }
            }
            return Output;
        }
        public static void DecodeFileRegisterCommand(string SerialisedString, int Unit, SerialManager? CurrentManager) {
            if (CurrentManager == null) { return; }
            if (CurrentManager.Registers == null) { return; }
            if (!SerialisedString.Contains(',')) { return; }
            string TempStrSelection = SerialisedString.Split(',')[0];
            if (TempStrSelection.ToLower().StartsWith("prop")) {
                if (Unit < 0) { return; }
                SerialisedString = StringHandler.SpiltAndCombineAfter(SerialisedString, ',', 1).Value[1];
                List<StringPair> Props = GetTaggedData(SerialisedString);
                int SlaveIndex = ModbusSupport.UnitToIndex(CurrentManager, Unit);
                if (SlaveIndex < 0) { return; }
                foreach (StringPair DataPair in Props) {
                    if (DataPair.A.ToLower() == "name") {
                        try {
                            CurrentManager.Slave[SlaveIndex].Name = DataPair.B;
                        }
                        catch { }
                    }
                    else if (DataPair.A.ToLower() == "addressformat") {
                        try {
                            CurrentManager.Slave[SlaveIndex].AddressFormat = EnumManager.StringToAddressingSystem(DataPair.B);
                        }
                        catch { }
                    }
                }
                return;
            }
            if (!Regex.IsMatch(TempStrSelection, "[A-Za-z][0-9]+")) { return; }
            SerialisedString = StringHandler.SpiltAndCombineAfter(SerialisedString, ',', 1).Value[1];
            string TempStrIndex = TempStrSelection.Remove(0, 1);
            int Index = -1; int.TryParse(TempStrIndex, out Index);
            DataSelection Selection = EnumManager.ModbusStringToDataSelection(TempStrSelection[0].ToString());
            List<StringPair> Data = GetTaggedData(SerialisedString);
            if (Unit < 0) {
                foreach (StringPair DataPair in Data) {
                    try {
                        switch (Selection) {
                            case DataSelection.ModbusDataCoils:
                                CurrentManager.Registers.Coils[Index].Set(DataPair);
                                break;
                            case DataSelection.ModbusDataDiscreteInputs:
                                CurrentManager.Registers.DiscreteInputs[Index].Set(DataPair);
                                break;
                            case DataSelection.ModbusDataInputRegisters:
                                CurrentManager.Registers.InputRegisters[Index].Set(DataPair);
                                break;
                            case DataSelection.ModbusDataHoldingRegisters:
                                CurrentManager.Registers.HoldingRegisters[Index].Set(DataPair);
                                break;

                            default:
                                return;
                        }
                    }
                    catch { }
                }
            }
            else {
                int SlaveIndex = ModbusSupport.UnitToIndex(CurrentManager, Unit);
                if (SlaveIndex < 0) { return; }
                foreach (StringPair DataPair in Data) {
                    try {
                        switch (Selection) {
                            case DataSelection.ModbusDataCoils:
                                CurrentManager.Slave[SlaveIndex].Coils[Index].Set(DataPair);
                                break;
                            case DataSelection.ModbusDataDiscreteInputs:
                                CurrentManager.Slave[SlaveIndex].DiscreteInputs[Index].Set(DataPair);
                                break;
                            case DataSelection.ModbusDataInputRegisters:
                                CurrentManager.Slave[SlaveIndex].InputRegisters[Index].Set(DataPair);
                                break;
                            case DataSelection.ModbusDataHoldingRegisters:
                                CurrentManager.Slave[SlaveIndex].HoldingRegisters[Index].Set(DataPair);
                                break;

                            default:
                                return;
                        }
                    }
                    catch { }
                }
            }
        }
        public static List<RegisterRequest> GetModifiedRegisters(SerialManager? CurrentManager, int Unit) {
            List<RegisterRequest> Registers = new List<RegisterRequest>();
            if (CurrentManager == null) { return Registers; }
            if (CurrentManager.Registers == null) { return Registers; }
            try {
                if (Unit < 0) {
                    for (int i = 0; i < MaximumRegisters; i++) {
                        if (i < CurrentManager.Registers.Coils.Count()) {
                            bool Result = IsRegisterEdited(CurrentManager.Registers.Coils[i]);
                            if (Result == true) {
                                Registers.Add(new RegisterRequest(i, DataSelection.ModbusDataCoils));
                            }
                        }
                        if (i < CurrentManager.Registers.DiscreteInputs.Count()) {
                            bool Result = IsRegisterEdited(CurrentManager.Registers.DiscreteInputs[i]);
                            if (Result == true) {
                                Registers.Add(new RegisterRequest(i, DataSelection.ModbusDataDiscreteInputs));
                            }
                        }
                        if (i < CurrentManager.Registers.InputRegisters.Count()) {
                            bool Result = IsRegisterEdited(CurrentManager.Registers.InputRegisters[i]);
                            if (Result == true) {
                                Registers.Add(new RegisterRequest(i, DataSelection.ModbusDataInputRegisters));
                            }
                        }
                        if (i < CurrentManager.Registers.HoldingRegisters.Count()) {
                            bool Result = IsRegisterEdited(CurrentManager.Registers.HoldingRegisters[i]);
                            if (Result == true) {
                                Registers.Add(new RegisterRequest(i, DataSelection.ModbusDataHoldingRegisters));
                            }
                        }
                    }
                }
                else {
                    for (int i = 0; i < MaximumRegisters; i++) {
                        if (i < CurrentManager.Slave[Unit].Coils.Count()) {
                            bool Result = IsRegisterEdited(CurrentManager.Slave[Unit].Coils[i]);
                            if (Result == true) {
                                Registers.Add(new RegisterRequest(i, DataSelection.ModbusDataCoils));
                            }
                        }
                        if (i < CurrentManager.Slave[Unit].DiscreteInputs.Count()) {
                            bool Result = IsRegisterEdited(CurrentManager.Slave[Unit].DiscreteInputs[i]);
                            if (Result == true) {
                                Registers.Add(new RegisterRequest(i, DataSelection.ModbusDataDiscreteInputs));
                            }
                        }
                        if (i < CurrentManager.Slave[Unit].InputRegisters.Count()) {
                            bool Result = IsRegisterEdited(CurrentManager.Slave[Unit].InputRegisters[i]);
                            if (Result == true) {
                                Registers.Add(new RegisterRequest(i, DataSelection.ModbusDataInputRegisters));
                            }
                        }
                        if (i < CurrentManager.Slave[Unit].HoldingRegisters.Count()) {
                            bool Result = IsRegisterEdited(CurrentManager.Slave[Unit].HoldingRegisters[i]);
                            if (Result == true) {
                                Registers.Add(new RegisterRequest(i, DataSelection.ModbusDataHoldingRegisters));
                            }
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
        public static void NewSnapshot(string Name, ModbusSlave Serman, DataSelection Selection, int Index, int Count, bool ShowUnits) {
            ModbusSnapshot Snap = new ModbusSnapshot(Serman, Selection, Index, Count);
            Snap.Name = Name;
            Snap.ShowUnits = ShowUnits;
            Snapshots.Add(Snap);
        }
        public static void NewSnapshot(string Name, ModbusSlave Serman, DataSelection Selection, int Index, int Count, Rectangle Bounds, bool ShowUnits) {
            ModbusSnapshot Snap = new ModbusSnapshot(Serman, Selection, Index, Count, Bounds);
            Snap.Name = Name;
            Snap.ShowUnits = ShowUnits;
            Snapshots.Add(Snap);
        }
        public static void NewSnapshot(string Name, ModbusSlave Serman, DataSelection Selection, List<int> Indices, bool ShowUnits) {
            ModbusSnapshot Snap = new ModbusSnapshot(Serman, Selection, Indices);
            Snap.ShowUnits = ShowUnits;
            Snap.Name = Name;
            Snapshots.Add(Snap);
        }
        public static void NewSnapshot(string Name, ModbusSlave Serman, DataSelection Selection, List<int> Indices, Rectangle Bounds, bool ShowUnits) {
            ModbusSnapshot Snap = new ModbusSnapshot(Serman, Selection, Indices, Bounds);
            Snap.ShowUnits = ShowUnits;
            Snap.Name = Name;
            Snapshots.Add(Snap);
        }
        public static ToolWindows.ModbusRegister NewSnapshotForm(string Name, ModbusSlave Serman, DataSelection Selection, int Index, int Count) {
            ModbusSnapshot Snap = new ModbusSnapshot(Serman, Selection, Index, Count);
            Snap.Name = Name;
            Snapshots.Add(Snap);
            ToolWindows.ModbusRegister frm = new ToolWindows.ModbusRegister(Snap);
            return frm;
        }
        public static ToolWindows.ModbusRegister NewSnapshotForm(string Name, ModbusSlave Serman, DataSelection Selection, List<int> Indices) {
            ModbusSnapshot Snap = new ModbusSnapshot(Serman, Selection, Indices);
            Snap.Name = Name;
            Snapshots.Add(Snap);
            ToolWindows.ModbusRegister frm = new ToolWindows.ModbusRegister(Snap);
            return frm;
        }
        public static void CloseSnapshot(SerialManager Manager) {
            for (int i = Snapshots.Count - 1; i >= 0; i--) {
                ModbusSlave? CurrentSlave = Snapshots[i].Manager;
                if (CurrentSlave != null) {
                    if (CurrentSlave.Channel != null) {
                        SerialManager? CurrentManager = CurrentSlave.Channel;
                        if (CurrentManager != null) {
                            if (CurrentManager.ID == Manager.ID) {
                                Snapshots[i].Close();
                                Snapshots.RemoveAt(i);
                            }
                        }
                    }
                }
            }
            GC.Collect();
        }
        public static void RemoveSnapshot(ModbusSlave Slave) {
            for (int i = Snapshots.Count - 1; i >= 0; i--) {
                ModbusSlave? TempSlave = Snapshots[i].Manager;
                if (TempSlave == null) { continue; }
                if (TempSlave.ID == Slave.ID) {
                    Snapshots[i].Close();
                    Snapshots.RemoveAt(i);
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
                ModbusSlave? Slave = Snapshots[i].Manager;
                if (Slave == null) { continue; }
                SerialManager? CurrentManager = Slave.Channel;
                if (CurrentManager != null) {
                    Snapshots[i].Close();
                    Snapshots.RemoveAt(i);
                }
            }
            GC.Collect();
        }
        public static bool IsModbusFrameVaild(byte[] InputBuffer, int Length) {
            if (Length < 5) { return false; }
            if ((InputBuffer[0] < 1) || (InputBuffer[0] > 247)) { return false; }
            byte[] CRC = new byte[2];
            CRC = BitConverter.GetBytes(CalculateCRC(InputBuffer, (ushort)(Length - 2), 0));
            if (CRC[0] != InputBuffer[Length - 2] | CRC[1] != InputBuffer[Length - 1]) {
                return false;
            }
            return true;
        }
        #endregion
        #region Modbus CRC
        public static byte CalculateLRC(byte[] Input, ushort BytesCount, int Start) {
            byte Output = 0;
            for (int i = Start; i < BytesCount; i++) {
                Output += Input[i];
            }
            return (byte)(-Output);
        }
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
        #region Register Altering
        public static int UnitToIndex(SerialManager SerMan, int Unit) {
            int Index = -1;
            for (int i = 0; i < SerMan.Slave.Count; i++) {
                if (SerMan.Slave[i].Address == Unit) {
                    Index = i; break;
                }
            }
            return Index;
        }
        public static void SetRegister(SerialManager SerMan, DataSelection Selection, int Address, short Value) {
            if (SerMan.Registers == null) { return; }
            switch (Selection) {
                case DataSelection.ModbusDataHoldingRegisters:
                    SerMan.Registers.HoldingRegisters[Address].Value = Value;
                    break;
                case DataSelection.ModbusDataInputRegisters:
                    SerMan.Registers.InputRegisters[Address].Value = Value;
                    break;
                default: return;
            }
        }
        public static void SetRegister(SerialManager SerMan, DataSelection Selection, int Address, bool Value) {
            if (SerMan.Registers == null) { return; }
            switch (Selection) {
                case DataSelection.ModbusDataCoils:
                    SerMan.Registers.Coils[Address].Value = Value;
                    break;
                case DataSelection.ModbusDataDiscreteInputs:
                    SerMan.Registers.DiscreteInputs[Address].Value = Value;
                    break;
                default: return;
            }
        }
        public static void SetRegister(SerialManager SerMan, DataSelection Selection, int Unit, int Address, short Value) {
            if (SerMan.Slave.Count == 0) { return; }
            int Index = UnitToIndex(SerMan, Unit);
            if (Index < 0) { return; }
            switch (Selection) {
                case DataSelection.ModbusDataHoldingRegisters:
                    SerMan.Slave[Index].HoldingRegisters[Address].Value = Value;
                    break;
                case DataSelection.ModbusDataInputRegisters:
                    SerMan.Slave[Index].InputRegisters[Address].Value = Value;
                    break;
                default: return;
            }
        }
        public static void SetRegister(SerialManager SerMan, DataSelection Selection, int Unit, int Address, bool Value) {
            if (SerMan.Slave.Count == 0) { return; }
            int Index = UnitToIndex(SerMan, Unit);
            if (Index < 0) { return; }
            switch (Selection) {
                case DataSelection.ModbusDataCoils:
                    SerMan.Slave[Index].Coils[Address].Value = Value;
                    break;
                case DataSelection.ModbusDataDiscreteInputs:
                    SerMan.Slave[Index].DiscreteInputs[Address].Value = Value;
                    break;
                default: return;
            }
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
        #region Modbus RTU ASCII Functions
        public static byte GetArrayValue(int Offset, ref byte[] Buffer) {
            if (Offset <= Buffer.Length - 2) {
                char Val1 = (char)Buffer[Offset];
                char Val2 = (char)Buffer[Offset + 1];
                string TempStr = Val1.ToString() + Val2.ToString();
                return (byte)Convert.ToInt32(TempStr, 16);
            }
            return 0x00;
        }
        public static int GetArrayValueRead4(int Offset, ref byte[] Buffer) {
            if (Offset <= Buffer.Length - 4) {
                char Val1 = (char)Buffer[Offset];
                char Val2 = (char)Buffer[Offset + 1];
                char Val3 = (char)Buffer[Offset + 2];
                char Val4 = (char)Buffer[Offset + 3];
                string TempStr = Val1.ToString() + Val2.ToString() + Val3.ToString() + Val4.ToString();
                return (int)Convert.ToInt32(TempStr, 16);
            }
            return 0x00;
        }
        public static int SetArrayValue(int Offset, byte Value, ref byte[] Buffer) {
            string HexValue = Formatters.ByteToHex(Value, false);
            if (Offset + 1 < Buffer.Length) {
                Buffer[Offset] = (byte)HexValue[0];
                Buffer[Offset + 1] = (byte)HexValue[1];
                return Offset + 2;
            }
            return Offset;
        }
        public static void SetArrayValue(ref int Offset, byte Value, ref byte[] Buffer) {
            string HexValue = Formatters.ByteToHex(Value, false);
            if (Offset + 1 < Buffer.Length) {
                Buffer[Offset] = (byte)HexValue[0];
                Buffer[Offset + 1] = (byte)HexValue[1];
                Offset = Offset + 2;
            }
        }
        public static byte[] BulidExceptionPacket(StreamOutputFormat Format, int Device, FunctionCode Function, ModbusSupport.ModbusException Code) {
            int FunctionTemp = (byte)Function + 0x80;
            if (Format == StreamOutputFormat.ModbusRTU) {
                byte[] Temp = new byte[3];
                Temp[0] = (byte)Device;//Adr
                Temp[1] = (byte)FunctionTemp;//Fun
                Temp[2] = (byte)Code;
                return Temp;
            }
            else {
                byte[] Temp = new byte[6];
                int RunningAddress = 0;
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)Device, ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)FunctionTemp, ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)Code, ref Temp);
                return Temp;
            }
        }
        public static byte[] BulidMaskWritePacket(StreamOutputFormat Format, int Device, int Address, int AndMask, int OrMask) {
            if (Format == StreamOutputFormat.ModbusRTU) {
                byte[] Temp = new byte[8];
                Temp[0] = (byte)Device;//Adr
                Temp[1] = (byte)FunctionCode.WriteMaskRegister;//Fun
                Temp[2] = (byte)((int)Address >> 8);//Str1
                Temp[3] = (byte)((int)Address & 0xFF);//Str1
                Temp[4] = (byte)(AndMask >> 8);//Cnt1
                Temp[5] = (byte)(AndMask & 0xFF);//Cnt2
                Temp[6] = (byte)(OrMask >> 8);//Cnt1
                Temp[7] = (byte)(OrMask & 0xFF);//Cnt2
                return Temp;
            }
            else {
                byte[] Temp = new byte[14];
                int RunningAddress = 0;
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)Device, ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)FunctionCode.WriteMaskRegister, ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)((int)Address >> 8), ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)((int)Address & 0xFF), ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)(AndMask >> 8), ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)(AndMask & 0xFF), ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)(OrMask >> 8), ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)(OrMask & 0xFF), ref Temp);
                return Temp;
            }
        }
        public static byte[] BulidReadDeviceIdPacket(StreamOutputFormat Format, int Device, DiagnosticDeviceIdentification DeviceIdComponent, short ObjectId) {
            int TempData = ObjectId;
            if (Format == StreamOutputFormat.ModbusRTU) {
                byte[] Temp = new byte[5];
                Temp[0] = (byte)Device;//Adr
                Temp[1] = (byte)FunctionCode.ReadDeviceIdentification;//Fun
                Temp[2] = (byte)0x0E;//Str1
                Temp[3] = (byte)((int)DeviceIdComponent & 0xFF);//Str1
                Temp[4] = (byte)(TempData & 0xFF);//Cnt2
                return Temp;
            }
            else {
                byte[] Temp = new byte[10];
                int RunningAddress = 0;
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)Device, ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)FunctionCode.ReadDeviceIdentification, ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)0X0E, ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)((int)DeviceIdComponent & 0xFF), ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)(TempData & 0xFF), ref Temp);
                return Temp;
            }
        }
        public static byte[] BulidDiagnosticsPacket(StreamOutputFormat Format, int Device, DiagnosticSubFunction SubFunction, short Request) {
            int TempData = Request;
            if (SubFunction == DiagnosticSubFunction.ReturnDiagnosticRegister) { TempData = 0x00; }
            else if (SubFunction == DiagnosticSubFunction.ForceListenOnlyMode) { TempData = 0x00; }
            else if (SubFunction >= DiagnosticSubFunction.ClearCountersAndDiagnosticRegister) { TempData = 0x00; }

            if (Format == StreamOutputFormat.ModbusRTU) {
                byte[] Temp = new byte[6];
                Temp[0] = (byte)Device;//Adr
                Temp[1] = (byte)FunctionCode.Diagnostics;//Fun
                Temp[2] = (byte)((int)SubFunction >> 8);//Str1
                Temp[3] = (byte)((int)SubFunction & 0xFF);//Str1
                Temp[4] = (byte)(TempData >> 8);//Cnt1
                Temp[5] = (byte)(TempData & 0xFF);//Cnt2
                return Temp;
            }
            else {
                byte[] Temp = new byte[12];
                int RunningAddress = 0;
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)Device, ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)FunctionCode.Diagnostics, ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)((int)SubFunction >> 8), ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)((int)SubFunction & 0xFF), ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)(TempData >> 8), ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)(TempData & 0xFF), ref Temp);
                return Temp;
            }
        }
        public static byte[] BulidReadPacket(StreamOutputFormat Format, FunctionCode Function, int Device, short Address, short Count) {
            if (Format == StreamOutputFormat.ModbusRTU) {
                byte[] Temp = new byte[6];
                Temp[0] = (byte)Device;//Adr
                Temp[1] = (byte)Function;//Fun
                Temp[2] = (byte)(Address >> 8);//Str1
                Temp[3] = (byte)(Address & 0xFF);//Str1
                Temp[4] = (byte)(Count >> 8);//Cnt1
                Temp[5] = (byte)(Count & 0xFF);//Cnt2
                return Temp;
            }
            else {
                byte[] Temp = new byte[12];
                int RunningAddress = 0;
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)Device, ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)Function, ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)(Address >> 8), ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)(Address & 0xFF), ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)(Count >> 8), ref Temp);
                ModbusSupport.SetArrayValue(ref RunningAddress, (byte)(Count & 0xFF), ref Temp);
                return Temp;
            }
        }
        public static byte[] BulidWriteSinglePacket(StreamOutputFormat Format, FunctionCode Function, int Device, short Address, byte Value0, byte Value1) {
            if (Format == StreamOutputFormat.ModbusRTU) {
                byte[] Temp = new byte[6];
                Temp[0] = (byte)Device;//Adr
                Temp[1] = (byte)Function;//Fun
                Temp[2] = (byte)(Address >> 8);//Str1
                Temp[3] = (byte)(Address & 0xFF);//Str1
                Temp[4] = Value0;
                Temp[5] = Value1;
                return Temp;
            }
            else {
                byte[] Temp = new byte[12];
                int RunningAddress = 0;
                SetArrayValue(ref RunningAddress, (byte)Device, ref Temp);
                SetArrayValue(ref RunningAddress, (byte)Function, ref Temp);
                SetArrayValue(ref RunningAddress, (byte)(Address >> 8), ref Temp);
                SetArrayValue(ref RunningAddress, (byte)(Address & 0xFF), ref Temp);
                SetArrayValue(ref RunningAddress, Value0, ref Temp);
                SetArrayValue(ref RunningAddress, Value1, ref Temp);
                return Temp;
            }
        }
        public static byte[] BulidWriteMultiplePacket(StreamOutputFormat Format, FunctionCode Function, int Device, short Address, List<short> Values) {
            if (Format == StreamOutputFormat.ModbusRTU) {
                byte[] Temp = new byte[7 + (Values.Count * 2)];
                Temp[0] = (byte)Device;//Adr
                Temp[1] = (byte)Function;//Fun
                Temp[2] = (byte)(Address >> 8);//Str1
                Temp[3] = (byte)(Address & 0xFF);//Str1
                Temp[4] = (byte)(Values.Count >> 8);//Str1
                Temp[5] = (byte)(Values.Count & 0xFF);//Str1
                Temp[6] = (byte)(Values.Count * 2);//Str1
                int j = 0;
                for (int i = 0; i < Values.Count; i++) {
                    Temp[7 + j] = (byte)(Values[i] >> 8);
                    Temp[8 + j] = (byte)(Values[i] & 0xFF);
                    j += 2;
                }
                return Temp;
            }
            else {
                byte[] Temp = new byte[14 + (Values.Count * 4)];
                int RunningAddress = 0;
                SetArrayValue(ref RunningAddress, (byte)Device, ref Temp);
                SetArrayValue(ref RunningAddress, (byte)Function, ref Temp);
                SetArrayValue(ref RunningAddress, (byte)(Address >> 8), ref Temp);
                SetArrayValue(ref RunningAddress, (byte)(Address & 0xFF), ref Temp);
                SetArrayValue(ref RunningAddress, (byte)(Values.Count >> 8), ref Temp);
                SetArrayValue(ref RunningAddress, (byte)(Values.Count & 0xFF), ref Temp);
                SetArrayValue(ref RunningAddress, (byte)(Values.Count * 2), ref Temp);
                for (int i = 0; i < Values.Count; i++) {
                    SetArrayValue(ref RunningAddress, (byte)(Values[i] >> 8), ref Temp);
                    SetArrayValue(ref RunningAddress, (byte)(Values[i] & 0xFF), ref Temp);
                }

                return Temp;
            }
        }
        public static byte[] BulidWriteMultiplePacket(StreamOutputFormat Format, FunctionCode Function, int Device, short Address, List<bool> Values) {
            int ByteCount = (Values.Count + 7) / 8;
            if (Format == StreamOutputFormat.ModbusRTU) {
                byte[] Temp = new byte[7 + ByteCount];
                Temp[0] = (byte)Device;//Adr
                Temp[1] = (byte)Function;//Fun
                Temp[2] = (byte)(Address >> 8);//Str1
                Temp[3] = (byte)(Address & 0xFF);//Str1
                Temp[4] = (byte)(Values.Count >> 8);//Str1
                Temp[5] = (byte)(Values.Count & 0xFF);//Str1
                Temp[6] = (byte)ByteCount;
                int j = 0;
                int k = 0;//Bytes - 1;
                for (int i = 0; i < Values.Count; i++) {
                    byte BinTemp = 0x00;
                    BinTemp = (byte)(Values[i] == true ? 0x01 : 0x00);
                    Temp[7 + k] |= (byte)(BinTemp << j);
                    j++;
                    if (j == 8) {
                        k++; j = 0;
                    }
                }
                return Temp;
            }
            else {
                byte[] Temp = new byte[14 + (ByteCount * 2)];
                int RunningAddress = 0;
                SetArrayValue(ref RunningAddress, (byte)Device, ref Temp);
                SetArrayValue(ref RunningAddress, (byte)Function, ref Temp);
                SetArrayValue(ref RunningAddress, (byte)(Address >> 8), ref Temp);
                SetArrayValue(ref RunningAddress, (byte)(Address & 0xFF), ref Temp);
                SetArrayValue(ref RunningAddress, (byte)(Values.Count >> 8), ref Temp);
                SetArrayValue(ref RunningAddress, (byte)(Values.Count & 0xFF), ref Temp);
                SetArrayValue(ref RunningAddress, (byte)ByteCount, ref Temp);
                int j = 0;
                int k = 0;//Bytes - 1;
                byte[] Packets = new byte[ByteCount];
                for (int i = 0; i < Values.Count; i++) {
                    byte BinTemp = 0x00;
                    BinTemp = (byte)(Values[i] == true ? 0x01 : 0x00);
                    Packets[k] |= (byte)(BinTemp << j);
                    j++;
                    if (j == 8) {
                        k++; j = 0;
                    }
                }
                for (int i = 0; i < Packets.Length; i++) {
                    SetArrayValue(ref RunningAddress, Packets[i], ref Temp);
                }

                return Temp;
            }
        }
        public static byte[] BulidReadCoils(SerialManager Serman, bool IsSlave, bool IsDiscrete, FunctionCode Function, int Device, short Address, short CoilCount) {
            if (Serman.Registers == null) { return new byte[0]; }
            int Index = -1;
            if (IsSlave == false) {
                Index = UnitToIndex(Serman, Device);
            }
            if (Serman.OutputFormat == StreamOutputFormat.ModbusASCII) {
                int Bytes = (CoilCount + 7) / 8;
                int ArrayLength = 6 + (Bytes * 2);
                byte[] Temp = new byte[ArrayLength];
                int TOffset = 0;
                SetArrayValue(ref TOffset, (byte)Device, ref Temp);
                SetArrayValue(ref TOffset, (byte)Function, ref Temp);
                SetArrayValue(ref TOffset, (byte)Bytes, ref Temp);
                int j = 0;
                int k = 0;//Bytes - 1;
                byte[] Packets = new byte[Bytes];

                for (int i = 0; i < CoilCount; i++) {
                    byte BinTemp = 0x00;
                    if (IsDiscrete == true) {
                        if (IsSlave == true) {
                            BinTemp = (byte)(Serman.Registers.DiscreteInputs[Address + i].Value == true ? 0x01 : 0x00);
                        }
                        else {
                            if (Index > -1) {
                                BinTemp = (byte)(Serman.Slave[Index].DiscreteInputs[Address + i].Value == true ? 0x01 : 0x00);
                            }
                        }
                    }
                    else {
                        if (IsSlave == true) {
                            BinTemp = (byte)(Serman.Registers.Coils[Address + i].Value == true ? 0x01 : 0x00);
                        }
                        else {
                            if (Index > -1) {
                                BinTemp = (byte)(Serman.Slave[Index].Coils[Address + i].Value == true ? 0x01 : 0x00);
                            }
                        }
                    }
                    Packets[k] |= (byte)(BinTemp << j);
                    j++;
                    if (j == 8) {
                        k++; j = 0;
                    }
                }
                for (int i = 0; i < Packets.Length; i++) {
                    SetArrayValue(ref TOffset, Packets[i], ref Temp);
                }
                return Temp;
            }
            else if (Serman.OutputFormat == StreamOutputFormat.ModbusRTU) {
                int Bytes = (CoilCount + 7) / 8;
                int ArrayLength = 3 + Bytes;
                byte[] Temp = new byte[ArrayLength];
                Temp[0] = (byte)Device;//Adr
                Temp[1] = (byte)Function;//Fun
                Temp[2] = (byte)Bytes;//Len
                int j = 0;
                int k = 0;//Bytes - 1;
                for (int i = 0; i < CoilCount; i++) {
                    byte BinTemp = 0x00;
                    if (IsDiscrete == true) {
                        if (IsSlave == true) {
                            BinTemp = (byte)(Serman.Registers.DiscreteInputs[Address + i].Value == true ? 0x01 : 0x00);
                        }
                        else {
                            if (Index > -1) {
                                BinTemp = (byte)(Serman.Slave[Index].DiscreteInputs[Address + i].Value == true ? 0x01 : 0x00);
                            }
                        }
                    }
                    else {
                        if (IsSlave == true) {
                            BinTemp = (byte)(Serman.Registers.Coils[Address + i].Value == true ? 0x01 : 0x00);
                        }
                        else {
                            if (Index > -1) {
                                BinTemp = (byte)(Serman.Slave[Index].Coils[Address + i].Value == true ? 0x01 : 0x00);
                            }
                        }
                    }
                    Temp[3 + k] |= (byte)(BinTemp << j);
                    j++;
                    if (j == 8) {
                        k++; j = 0;
                    }
                }
                return Temp;
            }
            return new byte[0];
        }
        public static byte[] BulidReadRegisters(SerialManager Serman, bool IsSlave, bool IsHolding, FunctionCode Function, int Device, short Address, short RegisterCount) {
            if (Serman.Registers == null) { return new byte[0]; }
            int Index = -1;
            if (IsSlave == false) {
                Index = UnitToIndex(Serman, Device);
            }
            if (Serman.OutputFormat == StreamOutputFormat.ModbusASCII) {
                int ArrayLength = 6 + (RegisterCount * 4);
                byte[] Temp = new byte[ArrayLength];
                int TOffset = 0;
                SetArrayValue(ref TOffset, (byte)Device, ref Temp);
                SetArrayValue(ref TOffset, (byte)Function, ref Temp);
                SetArrayValue(ref TOffset, (byte)(byte)(RegisterCount * 2), ref Temp);

                int Offset = 6;
                if (IsHolding == true) {
                    if (IsSlave == true) {
                        for (int i = 0; i < RegisterCount; i++) {
                            SetArrayValue(ref Offset, (byte)(Serman.Registers.HoldingRegisters[Address + i].Value >> 8), ref Temp);
                            SetArrayValue(ref Offset, (byte)(Serman.Registers.HoldingRegisters[Address + i].Value & 0xFF), ref Temp);
                        }
                    }
                    else {

                        if (Index > -1) {
                            for (int i = 0; i < RegisterCount; i++) {
                                SetArrayValue(ref Offset, (byte)(Serman.Slave[Index].HoldingRegisters[Address + i].Value >> 8), ref Temp);
                                SetArrayValue(ref Offset, (byte)(Serman.Slave[Index].HoldingRegisters[Address + i].Value & 0xFF), ref Temp);
                            }
                        }
                    }
                }
                else {
                    if (IsSlave == true) {
                        for (int i = 0; i < RegisterCount; i++) {
                            SetArrayValue(ref Offset, (byte)(Serman.Registers.InputRegisters[Address + i].Value >> 8), ref Temp);
                            SetArrayValue(ref Offset, (byte)(Serman.Registers.InputRegisters[Address + i].Value & 0xFF), ref Temp);
                        }
                    }
                    else {
                        if (Index > -1) {
                            for (int i = 0; i < RegisterCount; i++) {
                                SetArrayValue(ref Offset, (byte)(Serman.Slave[Index].InputRegisters[Address + i].Value >> 8), ref Temp);
                                SetArrayValue(ref Offset, (byte)(Serman.Slave[Index].InputRegisters[Address + i].Value & 0xFF), ref Temp);
                            }
                        }
                    }
                    return Temp;
                }
            }
            else if (Serman.OutputFormat == StreamOutputFormat.ModbusRTU) {
                int ArrayLength = 6 + (RegisterCount * 2);
                byte[] Temp = new byte[ArrayLength];
                Temp[0] = (byte)Device;
                Temp[1] = (byte)Function;
                Temp[2] = (byte)(RegisterCount * 2);
                int Offset = 0;
                if (IsHolding == true) {
                    if (IsSlave == true) {
                        for (int i = 0; i < RegisterCount; i++) {
                            Temp[3 + Offset] = (byte)(Serman.Registers.HoldingRegisters[Address + i].Value >> 8); Offset++;
                            Temp[3 + Offset] = (byte)(Serman.Registers.HoldingRegisters[Address + i].Value & 0xFF); Offset++;
                        }
                    }
                    else {
                        if (Index > -1) {
                            for (int i = 0; i < RegisterCount; i++) {
                                Temp[3 + Offset] = (byte)(Serman.Slave[Index].HoldingRegisters[Address + i].Value >> 8); Offset++;
                                Temp[3 + Offset] = (byte)(Serman.Slave[Index].HoldingRegisters[Address + i].Value & 0xFF); Offset++;
                            }
                        }
                    }
                }
                else {
                    if (IsSlave == true) {
                        for (int i = 0; i < RegisterCount; i++) {
                            Temp[3 + Offset] = (byte)(Serman.Registers.InputRegisters[Address + i].Value >> 8); Offset++;
                            Temp[3 + Offset] = (byte)(Serman.Registers.InputRegisters[Address + i].Value & 0xFF); Offset++;
                        }
                    }
                    else {
                        if (Index > -1) {
                            for (int i = 0; i < RegisterCount; i++) {
                                Temp[3 + Offset] = (byte)(Serman.Slave[Index].InputRegisters[Address + i].Value >> 8); Offset++;
                                Temp[3 + Offset] = (byte)(Serman.Slave[Index].InputRegisters[Address + i].Value & 0xFF); Offset++;
                            }
                        }
                    }
                }
                return Temp;
            }
            return new byte[0];
        }
        #endregion
        #region Pollers and Drivers
        public static List<ModbusPoller> Pollers = new List<ModbusPoller>();
        public static void RemovePollers(SerialManager Manager) {
            for (int i = Pollers.Count - 1; i >= 0; i--) {
                SerialManager? Channel = Pollers[i].Channel;
                if (Channel != null) {
                    if (Channel.ID == Manager.ID) {
                        Pollers[i].Channel = null;
                        Pollers.RemoveAt(i);
                    }
                }
            }
            GC.Collect();
        }
        public static void ClearPollers() {
            for (int i = Pollers.Count - 1; i >= 0; i--) {
                Pollers[i].Channel = null;
                Pollers.RemoveAt(i);
            }
            GC.Collect();
        }
        public static void NewPoller(SerialManager? Manager, bool Read, int Unit, DataSelection Selection, int Start) {
            ModbusPoller MbPoll = new ModbusPoller(Manager, Read, Unit, Selection, Start);
            Pollers.Add(MbPoll);
        }
        public static void NewPoller(SerialManager? Manager, bool Read, int Unit, DataSelection Selection, int Start, int End) {
            ModbusPoller MbPoll = new ModbusPoller(Manager, Read, Unit, Selection, Start, End);
            Pollers.Add(MbPoll);
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
            WriteMultipleHoldingRegisters = 0x10,
            Diagnostics = 0x08,
            WriteMaskRegister = 0x16,
            ReadDeviceIdentification = 0x2B
        }
        public enum DiagnosticSubFunction {
            ReturnQueryData = 0x00,
            RestartCommunicationsOption = 0x01,
            ReturnDiagnosticRegister = 0x02,
            ChangeASCIIInputDelimiter = 0x03,
            ForceListenOnlyMode = 0x04,
            ClearCountersAndDiagnosticRegister = 0x0A,
            ReturnBusMessageCount = 0x0B,
            ReturnBusCommunicationErrorCount = 0x0C,
            ReturnBusExceptionErrorCount = 0x0D,
            ReturnSlaveMessageCount = 0x0E,
            ReturnSlaveNoResponseCount = 0x0F,
            ReturnSlaveNAKCount = 0x10,
            ReturnSlaveBusyCount = 0x11,
            ReturnBusCharacterOverrunCount = 0x12,
            ClearOverrunCounterAndFlag = 0x14
        }
        public enum DiagnosticDeviceIdentification {
            ReadBasicIdentification = 0x01,
            ReadRegularIdentification = 0x02,
            ReadExtendedIdentification = 0x03,
            ReadSpecificIdentification = 0x04
        }
        public enum ModbusException {
            IllegalFunction = 0x01,
            IllegalDataAddress = 0x02,
            IllegalDataValue = 0x03,
            SlaveDeviceFailure = 0x04,
            Acknowledge = 0x05,
            SlaveDeviceBusy = 0x06,
            MemoryParityError = 0x08,
            GatewayPathUnavaliable = 0x0A,
            GatewayTargetDeviceFailedToRespond = 0x0B
        }
    }
}
