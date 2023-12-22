using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public class ModbusSlave {
        public ModbusSlave(SerialManager ParentManager, int Address) {
            manager = ParentManager;
            this.address = Address;
            LoadRegisters();
        }
        public ModbusSlave(SerialManager ParentManager, int Address, string Name) {
            manager = ParentManager;
            this.address = Address;
            this.name = Name;
            LoadRegisters();
        }
        private string name = "";
        public string Name {
            get { return name; }
            set { name = value; }
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
        SerialManager? manager = null;
        public SerialManager? Manager {
            get { return manager; }
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
    }
}
