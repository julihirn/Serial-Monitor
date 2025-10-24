using Handlers;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public static class ModbusQuery {
        public static void ExecuteQuery(string Query) {
            string NextQuery = Query;
            while (NextQuery.Length > 1) {
                string CurrentQuery = Classes.CommandManager.GetQuery(NextQuery, ref NextQuery);
                string CurrentQueryUntouched = CurrentQuery;
                List<StringPair> Vars = GetModbusQueryVariables(ref CurrentQuery);
                ApplyModbusQueryVariables(ref CurrentQuery, Vars);
                string ChannelName = "";
                bool State = Classes.CommandManager.GetValue(ref CurrentQuery, "USING", out ChannelName, false);
                if (State == false) { break; }
                SerialManager? Current = SystemManager.GetChannel(ChannelName);
                if (Current == null) { break; }
                bool WasMaster = Current.IsMaster;
                bool ResetMaster = false;
                //CurrentQuery = CurrentQuery.ToUpper();
                if (Classes.CommandManager.TestKeyword(ref CurrentQuery, "AS")) {
                    if (Classes.CommandManager.TestKeyword(ref CurrentQuery, "MASTER")) {
                        Current.IsMaster = true;
                        ResetMaster = true;
                    }
                }
                SystemManager.SendModbusCommand(Current, CurrentQuery);
                if (ResetMaster == true) { Current.IsMaster = WasMaster; }
            }
        }
        private static List<StringPair> GetModbusQueryVariables(ref string CurrentQuery) {
            List<StringPair> Output = new List<StringPair>();
            while (CurrentQuery.ToUpper().Contains("DECLARE")) {
                string TempName = "";
                string TempValue = "";
                if (Classes.CommandManager.GetValue(ref CurrentQuery, "DECLARE", out TempName, false, true)) {
                    if (Classes.CommandManager.IsModbusKeyword(TempName) == false) {
                        if (Classes.CommandManager.GetValue(ref CurrentQuery, "=", out TempValue, false)) {
                            Output.Add(new StringPair(TempName, TempValue));
                        }
                    }
                }
            }
            return Output;
        }
        private static void ApplyModbusQueryVariables(ref string CurrentQuery, List<StringPair> Vars) {
            foreach (StringPair Sp in Vars) {
                CurrentQuery = CurrentQuery.Replace(Sp.A, Sp.B);
            }
        }
        #region Modbus Query Processing
        public static void ModbusCommand(SerialManager? Channel, string Input) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            try {
                if (Channel.IsMaster == false) { return; }
                string Temp = Input.TrimStart(' ').TrimStart('\t');
                int Unit = 1;
                int GenericFunction = -1;
                //int Count = 1;
                if (CommandManager.TestKeyword(ref Temp, "UNIT", true)) {
                    string StrAddress = CommandManager.ReadAndRemove(ref Temp);

                    bool Success = Formatters.StringToInteger(StrAddress, out Unit);
                    if (Unit > ModbusSupport.MaximumDevices) {
                        Success = false;
                    }
                    if (Success == false) { return; }
                    int UnitIndex = ModbusSupport.UnitToIndex(Channel, Unit);
                    if (UnitIndex == -1) {
                        Channel.NewSlave(Unit);
                    }
                }
                if (CommandManager.TestKeyword(ref Temp, "READ")) {
                    PerformRead(Channel, Unit, ref Temp);
                }
                else if (CommandManager.TestKeyword(ref Temp, "WRITE")) {
                    PerformWrite(Channel, Unit, ref Temp);
                }
                else if (CommandManager.TestKeyword(ref Temp, "DIAGNOSTICS")) {
                    PerformDiagnosticFunctions(Channel, Unit, ref Temp);
                }
                else if (CommandManager.GetValue(ref Temp, "FUNCTION", out GenericFunction)) {
                    PerformGenericFunction(Channel, Unit, GenericFunction, ref Temp);
                }
            }
            catch { }
        }
        #region QueryFunctionGroups
        private static void PerformRead(SerialManager Channel, int Unit, ref string Temp) {
            int Start = 0;
            if (CommandManager.GetValue(ref Temp, "COILS", out Start)) {
                InitialTestReadQuery(Channel, Unit, Start, ref Temp, DataSelection.ModbusDataCoils);
            }
            else if (CommandManager.GetValue(ref Temp, "DISCRETE", out Start)) {
                InitialTestReadQuery(Channel, Unit, Start, ref Temp, DataSelection.ModbusDataDiscreteInputs);
            }
            else if (CommandManager.GetValue(ref Temp, "REGISTERS", out Start)) {
                InitialTestReadQuery(Channel, Unit, Start, ref Temp, DataSelection.ModbusDataHoldingRegisters);
            }
            else if (CommandManager.GetValue(ref Temp, "HOLDINGS", out Start)) {
                InitialTestReadQuery(Channel, Unit, Start, ref Temp, DataSelection.ModbusDataHoldingRegisters);
            }
            else if (CommandManager.GetValue(ref Temp, "INREGISTERS", out Start)) {
                InitialTestReadQuery(Channel, Unit, Start, ref Temp, DataSelection.ModbusDataInputRegisters);
            }
            else if (CommandManager.GetValue(ref Temp, "INPUTS", out Start)) {
                InitialTestReadQuery(Channel, Unit, Start, ref Temp, DataSelection.ModbusDataInputRegisters);
            }
            else if (CommandManager.TestKeyword(ref Temp, "COILS")) {
                SecondTestReadQuery(Channel, Unit, ref Temp, DataSelection.ModbusDataCoils);
            }
            else if (CommandManager.TestKeyword(ref Temp, "DISCRETE")) {
                SecondTestReadQuery(Channel, Unit, ref Temp, DataSelection.ModbusDataDiscreteInputs);
            }
            else if (CommandManager.TestKeyword(ref Temp, "REGISTERS")) {
                SecondTestReadQuery(Channel, Unit, ref Temp, DataSelection.ModbusDataHoldingRegisters);
            }
            else if (CommandManager.TestKeyword(ref Temp, "HOLDINGS")) {
                SecondTestReadQuery(Channel, Unit, ref Temp, DataSelection.ModbusDataHoldingRegisters);
            }
            else if (CommandManager.TestKeyword(ref Temp, "INREGISTERS")) {
                SecondTestReadQuery(Channel, Unit, ref Temp, DataSelection.ModbusDataInputRegisters);
            }
            else if (CommandManager.TestKeyword(ref Temp, "INPUTS")) {
                SecondTestReadQuery(Channel, Unit, ref Temp, DataSelection.ModbusDataInputRegisters);
            }
            else if (CommandManager.GetValue(ref Temp, "COIL", out Start)) {
                SingleTestReadQuery(Channel, Unit, Start, ref Temp, DataSelection.ModbusDataCoils);
            }
            else if (CommandManager.GetValue(ref Temp, "DISCRETE", out Start)) {
                SingleTestReadQuery(Channel, Unit, Start, ref Temp, DataSelection.ModbusDataDiscreteInputs);
            }
            else if (CommandManager.GetValue(ref Temp, "REGISTER", out Start)) {
                SingleTestReadQuery(Channel, Unit, Start, ref Temp, DataSelection.ModbusDataHoldingRegisters);
            }
            else if (CommandManager.GetValue(ref Temp, "HOLDING", out Start)) {
                SingleTestReadQuery(Channel, Unit, Start, ref Temp, DataSelection.ModbusDataHoldingRegisters);
            }
            else if (CommandManager.GetValue(ref Temp, "INREGISTER", out Start)) {
                SingleTestReadQuery(Channel, Unit, Start, ref Temp, DataSelection.ModbusDataInputRegisters);
            }
            else if (CommandManager.GetValue(ref Temp, "INPUT", out Start)) {
                SingleTestReadQuery(Channel, Unit, Start, ref Temp, DataSelection.ModbusDataInputRegisters);
            }
        }
        private static void PerformWrite(SerialManager Channel, int Unit, ref string Temp) {
            int Start = 0;
            if (CommandManager.TestKeyword(ref Temp, "REGISTERS")) {
                if (CommandManager.GetValue(ref Temp, "FROM", out Start, false)) {
                    List<short> Values = new List<short>();
                    if (CommandManager.GetIntegerValues(ref Temp, "WITH", ref Values)) {
                        Channel.ModbusWriteMultipleRegisters(Unit, (short)Start, Values);
                    }
                    else if (CommandManager.GetCharacterValues(ref Temp, "WITH", ref Values)) {
                        Channel.ModbusWriteMultipleRegisters(Unit, (short)Start, Values);
                    }
                }
            }
            else if (CommandManager.TestKeyword(ref Temp, "HOLDINGS")) {
                if (CommandManager.GetValue(ref Temp, "FROM", out Start, false)) {
                    List<short> Values = new List<short>();
                    if (CommandManager.GetIntegerValues(ref Temp, "WITH", ref Values)) {
                        Channel.ModbusWriteMultipleRegisters(Unit, (short)Start, Values);
                    }
                    else if (CommandManager.GetCharacterValues(ref Temp, "WITH", ref Values)) {
                        Channel.ModbusWriteMultipleRegisters(Unit, (short)Start, Values);
                    }
                }
            }
            else if (CommandManager.TestKeyword(ref Temp, "COILS")) {
                if (CommandManager.GetValue(ref Temp, "FROM", out Start, false)) {
                    List<bool> Values = new List<bool>();
                    if (CommandManager.GetBooleanValues(ref Temp, "WITH", ref Values)) {
                        Channel.ModbusWriteMultipleCoils(Unit, (short)Start, Values);
                    }
                }
            }
            else if (CommandManager.GetValue(ref Temp, "COIL", out Start, true)) {
                if (CommandManager.TestKeyword(ref Temp, "=")) {
                    bool Tbool = false;
                    if (Temp.Trim(' ') == "TRUE") {
                        Tbool = true;
                    }
                    else if (Temp.Trim(' ') == "T") {
                        Tbool = true;
                    }
                    else if (Temp.Trim(' ') == "1") {
                        Tbool = true;
                    }
                    Channel.ModbusWriteCoil(Unit, (short)Start, Tbool);
                }
            }
            else if (CommandManager.GetValue(ref Temp, "REGISTER", out Start, true)) {
                int Value = 0;
                if (CommandManager.GetValue(ref Temp, "=", out Value)) {
                    Channel.ModbusWriteRegister(Unit, (short)Start, (short)Value);
                }
                else { Channel.ModbusWriteRegister(Unit, (short)Start, (short)0); }
            }
            else if (CommandManager.GetValue(ref Temp, "HOLDING", out Start, true)) {
                int Value = 0;
                if (CommandManager.GetValue(ref Temp, "=", out Value)) {
                    Channel.ModbusWriteRegister(Unit, (short)Start, (short)Value);
                }
                else { Channel.ModbusWriteRegister(Unit, (short)Start, (short)0); }
            }
            else if (CommandManager.TestKeyword(ref Temp, "MASK")) {
                if (CommandManager.GetValue(ref Temp, "REGISTER", out Start, ' ')) {
                    int Value = 0;
                    if (CommandManager.GetValue(ref Temp, "WITH", out Value, ',')) {
                        int Value2 = 0;
                        if (CommandManager.GetValue(ref Temp, ",", out Value2)) {
                            Channel.ModbusWriteMaskRegister(Unit, (short)Start, (short)Value, (short)Value2);
                        }
                        else {
                            Channel.ModbusWriteMaskRegister(Unit, (short)Start, (short)Value, 0);
                        }
                    }
                }
            }
        }
        private static void PerformDiagnosticFunctions(SerialManager Channel, int Unit, ref string Temp) {
            int Start = 0;
            if (CommandManager.TestKeyword(ref Temp, "RETURN")) {
                if (CommandManager.TestKeyword(ref Temp, "QUERY")) {
                    if (CommandManager.GetValue(ref Temp, "WITH", out Start, false)) {
                        Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnQueryData, (short)Start);
                    }
                }
                else if (CommandManager.TestKeyword(ref Temp, "REGISTER")) {
                    Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnDiagnosticRegister, 0);
                }
                else if (CommandManager.TestKeyword(ref Temp, "BUS")) {
                    if (CommandManager.TestKeyword(ref Temp, "MESSAGES")) {
                        Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnBusMessageCount, 0);
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "ERRORS")) {
                        Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnBusCommunicationErrorCount, 0);
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "EXCEPTIONS")) {
                        Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnBusExceptionErrorCount, 0);
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "OVERRUNS")) {
                        Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnBusCharacterOverrunCount, 0);
                    }
                }
                else if (CommandManager.TestKeyword(ref Temp, "SLAVE")) {
                    if (CommandManager.TestKeyword(ref Temp, "MESSAGES")) {
                        Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnSlaveMessageCount, 0);
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "BUSY")) {
                        Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnSlaveBusyCount, 0);
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "NORES")) {
                        Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnSlaveNoResponseCount, 0);
                    }
                    else if (CommandManager.TestKeyword(ref Temp, "NONAK")) {
                        Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ReturnSlaveNAKCount, 0);
                    }
                }
            }
            else if (CommandManager.TestKeyword(ref Temp, "CLEAR")) {
                if (CommandManager.TestKeyword(ref Temp, "COUNTERS")) {
                    Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ClearCountersAndDiagnosticRegister, 0);
                }
                else if (CommandManager.TestKeyword(ref Temp, "OVERRUN")) {
                    Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ClearOverrunCounterAndFlag, 0);
                }
            }
            else if (CommandManager.TestKeyword(ref Temp, "RESTART")) {
                if (CommandManager.GetValue(ref Temp, "WITH", out Start, false)) {
                    Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.RestartCommunicationsOption, (short)Start);
                }
            }
            else if (CommandManager.TestKeyword(ref Temp, "FORCE")) {
                if (CommandManager.TestKeyword(ref Temp, "LISTEN")) {
                    Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ForceListenOnlyMode, 0);
                }
            }
            else if (CommandManager.TestKeyword(ref Temp, "SET")) {
                if (CommandManager.TestKeyword(ref Temp, "DELIMITER")) {
                    if (CommandManager.GetValue(ref Temp, "WITH", out Start, false)) {
                        Channel.ModbusDiagnostics(Unit, ModbusSupport.DiagnosticSubFunction.ChangeASCIIInputDelimiter, (short)Start);
                    }
                }
            }
            else if (CommandManager.TestKeyword(ref Temp, "READ")) {
                if (CommandManager.TestKeyword(ref Temp, "BASIC")) {
                    ReadDeviceIdentification(Channel, Unit, ModbusSupport.DiagnosticDeviceIdentification.ReadBasicIdentification, ref Temp);
                }
                else if (CommandManager.TestKeyword(ref Temp, "REGULAR")) {
                    ReadDeviceIdentification(Channel, Unit, ModbusSupport.DiagnosticDeviceIdentification.ReadRegularIdentification, ref Temp);
                }
                else if (CommandManager.TestKeyword(ref Temp, "EXTENDED")) {
                    ReadDeviceIdentification(Channel, Unit, ModbusSupport.DiagnosticDeviceIdentification.ReadExtendedIdentification, ref Temp);
                }
                else if (CommandManager.TestKeyword(ref Temp, "SPECIFIC")) {
                    ReadDeviceIdentification(Channel, Unit, ModbusSupport.DiagnosticDeviceIdentification.ReadExtendedIdentification, ref Temp);
                }
            }
        }

        private static void PerformGenericFunction(SerialManager Channel, int Unit, int GenericFunction, ref string Temp) {
            if (GenericFunction < 0) { return; }
            List<short> Values = new List<short>();
            if (CommandManager.GetIntegerValues(ref Temp, "WITH", ref Values)) {
                Channel.ModbusSendGenericFunction(Unit, GenericFunction, Values);
            }
            else if (CommandManager.GetCharacterValues(ref Temp, "WITH", ref Values)) {
                Channel.ModbusSendGenericFunction(Unit, GenericFunction, Values);
            }
        }
        #endregion
        private static void ReadDeviceIdentification(SerialManager Channel, int Unit, ModbusSupport.DiagnosticDeviceIdentification ReadRequest, ref string Temp) {
            int Start = 0;
            if (CommandManager.TestKeyword(ref Temp, "IDENTIFICATION")) {
                if (CommandManager.GetValue(ref Temp, "WITH", out Start, false)) {
                    Channel.ModbusReadDeviceIdentification(Unit, ReadRequest, (short)Start);
                }
                else {
                    Channel.ModbusReadDeviceIdentification(Unit, ReadRequest, 0);
                }
            }
            else if (CommandManager.TestKeyword(ref Temp, "ID")) {
                if (CommandManager.GetValue(ref Temp, "WITH", out Start, false)) {
                    Channel.ModbusReadDeviceIdentification(Unit, ReadRequest, (short)Start);
                }
                else {
                    Channel.ModbusReadDeviceIdentification(Unit, ReadRequest, 0);
                }
            }
        }
        internal static void InitialTestReadQuery(SerialManager Channel, int Unit, int Start, ref string Temp, DataSelection DataSet) {
            int Count = 0;
            if (CommandManager.GetValue(ref Temp, "QTY", out Count)) {
                if (StartQtyInRange(Start, Count) == false) { return; }
                SelectRead(Channel, Unit, (short)Start, (short)Count, DataSet);
            }
            else if (CommandManager.GetValue(ref Temp, "TO", out Count)) {
                Point StartAndDiff = CommandManager.GetStartAndDifference(Start, Count);
                if (StartDiffInRange(StartAndDiff) == false) { return; }
                SelectRead(Channel, Unit, (short)StartAndDiff.X, (short)StartAndDiff.Y, DataSet);
            }
            else { SelectRead(Channel, Unit, (short)Start, (short)1, DataSet); }
        }
        internal static void SingleTestReadQuery(SerialManager Channel, int Unit, int Start, ref string Temp, DataSelection DataSet) {
            SelectRead(Channel, Unit, (short)Start, (short)1, DataSet);
        }
        internal static void SelectRead(SerialManager Channel, int Unit, short Start, short Count, DataSelection DataSet) {
            switch (DataSet) {
                case DataSelection.ModbusDataCoils:
                    Channel.ModbusReadCoils(Unit, Start, Count); break;
                case DataSelection.ModbusDataDiscreteInputs:
                    Channel.ModbusReadDiscreteInputs(Unit, Start, Count); break;
                case DataSelection.ModbusDataInputRegisters:
                    Channel.ModbusReadInputRegisters(Unit, Start, Count); break;
                case DataSelection.ModbusDataHoldingRegisters:
                    Channel.ModbusReadHoldingRegisters(Unit, Start, Count); break;
                default: return;
            }
        }
        internal static void SecondTestReadQuery(SerialManager Channel, int Unit, ref string Temp, DataSelection DataSet) {
            int Start = 0;
            int Count = 0;
            if (CommandManager.GetValue(ref Temp, "FROM", out Start, false)) {
                if (CommandManager.GetValue(ref Temp, "TO", out Count)) {
                    Point StartAndDiff = CommandManager.GetStartAndDifference(Start, Count);
                    if (StartDiffInRange(StartAndDiff) == false) { return; }
                    switch (DataSet) {
                        case DataSelection.ModbusDataCoils:
                            Channel.ModbusReadCoils(Unit, (short)StartAndDiff.X, (short)StartAndDiff.Y); break;
                        case DataSelection.ModbusDataDiscreteInputs:
                            Channel.ModbusReadDiscreteInputs(Unit, (short)StartAndDiff.X, (short)StartAndDiff.Y); break;
                        case DataSelection.ModbusDataInputRegisters:
                            Channel.ModbusReadInputRegisters(Unit, (short)StartAndDiff.X, (short)StartAndDiff.Y); break;
                        case DataSelection.ModbusDataHoldingRegisters:
                            Channel.ModbusReadHoldingRegisters(Unit, (short)StartAndDiff.X, (short)StartAndDiff.Y); break;
                        default: return;
                    }

                }
                else if (CommandManager.GetValue(ref Temp, "QTY", out Count)) {
                    if (StartQtyInRange(Start, Count) == false) { return; }
                    SelectRead(Channel, Unit, (short)Start, (short)Count, DataSet);
                }
            }
        }
        private static bool StartQtyInRange(int Start, int Qty) {
            if (Qty <= 0) { return false; }
            if (Start >= ModbusSupport.MaximumRegisters) { return false; }
            if ((Start + Qty) >= ModbusSupport.MaximumRegisters) { return false; }
            return true;
        }
        private static bool StartDiffInRange(Point StartAndDiff) {
            if (StartAndDiff.Y <= 0) { return false; }
            if (StartAndDiff.X >= ModbusSupport.MaximumRegisters) { return false; }
            if ((StartAndDiff.X + (StartAndDiff.Y - 1)) >= ModbusSupport.MaximumRegisters) { return false; }
            return true;
        }
        #endregion
    }
}
