using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.Enums.ModbusEnums;

namespace Serial_Monitor.Classes.Modbus {
    public class ModbusSlave {
        public ModbusSlave(SerialManager Channel, int Address) {
            iD = Guid.NewGuid().ToString();
            channel = Channel;
            this.address = Address;
            LoadRegisters();
        }
        public ModbusSlave(SerialManager Channel, int Address, string Name) {
            iD = Guid.NewGuid().ToString();
            channel = Channel;
            this.address = Address;
            this.name = Name;
            LoadRegisters();
        }
        private string name = "";
        public string Name {
            get { return name; }
            set { name = value; }
        }
        private AddressSystem addressFormat = AddressSystem.ZeroBasedDecimal;
        public AddressSystem AddressFormat {
            get { return addressFormat; }
            set { addressFormat = value; }
        }
        string iD = "";
        [Browsable(false)]
        public string ID {
            get { return iD; }
        }
        public string DisplayName {
            get { 
                if (name.Trim(' ') == "") {
                    return "Unit " + address.ToString();
                }
                return name; 
            }
        }
        private int address = 0;
        public int Address {
            get { return address; } 
        }
        SerialManager? channel = null;
        public SerialManager? Channel {
            get { return channel; }
        }
        private Modbus.ModbusCoil[] coils = new Modbus.ModbusCoil[Modbus.ModbusSupport.MaximumRegisters];//new List<ModbusCoil>(Modbus.ModbusSupport.MaximumRegisters);//new ModbusCoil[Modbus.ModbusSupport.MaximumRegisters];
        [Browsable(false)]
        public Modbus.ModbusCoil[] Coils {
            get { return coils; }
        }
        private Modbus.ModbusCoil[] discreteInputs = new Modbus.ModbusCoil[Modbus.ModbusSupport.MaximumRegisters];//new List<ModbusCoil>(Modbus.ModbusSupport.MaximumRegisters); //new bool[Modbus.ModbusSupport.MaximumRegisters];
        [Browsable(false)]
        public Modbus.ModbusCoil[] DiscreteInputs {
            get { return discreteInputs; }
        }//ModbusRegister
        private Modbus.ModbusRegister[] inputRegisters = new Modbus.ModbusRegister[Modbus.ModbusSupport.MaximumRegisters]; //new short[Modbus.ModbusSupport.MaximumRegisters];
        [Browsable(false)]
        public Modbus.ModbusRegister[] InputRegisters {
            get { return inputRegisters; }
        }
        private Modbus.ModbusRegister[] holdingRegisters = new Modbus.ModbusRegister[Modbus.ModbusSupport.MaximumRegisters]; //new short[Modbus.ModbusSupport.MaximumRegisters];
        [Browsable(false)]
        public Modbus.ModbusRegister[] HoldingRegisters {
            get { return holdingRegisters; }
        }
        private void LoadRegisters() {
            for (int i = 0; i < Modbus.ModbusSupport.MaximumRegisters; i++) {
                coils[i] = new ModbusCoil(i, DataSelection.ModbusDataCoils, this);
                discreteInputs[i] = new ModbusCoil(i, DataSelection.ModbusDataDiscreteInputs, this);
                inputRegisters[i] = new ModbusRegister(i, DataSelection.ModbusDataInputRegisters, this);
                holdingRegisters[i] = new ModbusRegister(i, DataSelection.ModbusDataHoldingRegisters, this);
            }
        }
        public void CleanUp() {
            Array.Clear(coils, 0, coils.Length);
            Array.Clear(discreteInputs, 0, discreteInputs.Length);
            Array.Clear(inputRegisters, 0, inputRegisters.Length);
            Array.Clear(holdingRegisters, 0, holdingRegisters.Length);
            coils = new ModbusCoil[0];
            discreteInputs = new ModbusCoil[0];
            inputRegisters = new ModbusRegister[0];
            holdingRegisters = new ModbusRegister[0];
            channel = null;
            GC.Collect();
        }
        public void Reset() {
            for (int i = 0; i < Modbus.ModbusSupport.MaximumRegisters; i++) {
                coils[i].Reset();
                discreteInputs[i].Reset();
                inputRegisters[i].Reset();
                holdingRegisters[i].Reset();
            }
        }
        public void RaiseException(Modbus.ModbusSupport.FunctionCode Function, Modbus.ModbusSupport.ModbusException Exception) {
            if (Exception == ModbusSupport.ModbusException.IllegalFunction) {
                exceptionCountIllegalFunction++;
            }
            else if (Exception == ModbusSupport.ModbusException.IllegalDataAddress) {
                exceptionCountIllegalDataAddress++;
            }
            else if (Exception == ModbusSupport.ModbusException.IllegalDataValue) {
                exceptionCountIllegalDataValue++;
            }
            else if (Exception == ModbusSupport.ModbusException.SlaveDeviceFailure) {
                exceptionCountSlaveDeviceFailure++;
            }
            else if (Exception == ModbusSupport.ModbusException.Acknowledge) {
                exceptionCountAcknowledge++;
            }
            else if (Exception == ModbusSupport.ModbusException.SlaveDeviceBusy) {
                exceptionCountSlaveDeviceBusy++;
            }
            else if (Exception == ModbusSupport.ModbusException.MemoryParityError) {
                exceptionCountAcknowledge++;
            }
            else if (Exception == ModbusSupport.ModbusException.GatewayPathUnavaliable) {
                exceptionCountGatewayPathUnavaliable++;
            }
            else if (Exception == ModbusSupport.ModbusException.GatewayTargetDeviceFailedToRespond) {
                exceptionCountFailedToRespond++;
            }
            exceptionCount++;
        }
        ulong exceptionCount = 0;
        [Browsable(false)]
        public ulong ExceptionCount {
            get { return exceptionCount; }
        }
        ulong exceptionCountIllegalFunction = 0;
        [Browsable(false)]
        public ulong IllegalFunctionErrorCount {
            get { return exceptionCountIllegalFunction; }
        }
        ulong exceptionCountIllegalDataAddress = 0;
        [Browsable(false)]
        public ulong IllegalDataAddressCount {
            get { return exceptionCountIllegalDataAddress; }
        }
        ulong exceptionCountIllegalDataValue = 0;
        [Browsable(false)]
        public ulong IllegalDataValueCount {
            get { return exceptionCountIllegalDataValue; }
        }
        ulong exceptionCountSlaveDeviceFailure = 0;
        [Browsable(false)]
        public ulong SlaveDeviceFailureCount {
            get { return exceptionCountSlaveDeviceFailure; }
        }
        ulong exceptionCountAcknowledge = 0;
        [Browsable(false)]
        public ulong AcknowledgeCount {
            get { return exceptionCountAcknowledge; }
        }
        ulong exceptionCountSlaveDeviceBusy = 0;
        [Browsable(false)]
        public ulong SlaveDeviceBusyCount {
            get { return exceptionCountSlaveDeviceBusy; }
        }
        ulong exceptionCountMemoryParityError = 0;
        [Browsable(false)]
        public ulong MemoryParityErrorCount {
            get { return exceptionCountMemoryParityError; }
        }
        ulong exceptionCountGatewayPathUnavaliable = 0;
        [Browsable(false)]
        public ulong GatewayPathUnavaliableCount {
            get { return exceptionCountGatewayPathUnavaliable; }
        }
        ulong exceptionCountFailedToRespond = 0;
        [Browsable(false)]
        public ulong GatewayTargetDeviceFailedToRespond {
            get { return exceptionCountFailedToRespond; }
        }
    }
}
