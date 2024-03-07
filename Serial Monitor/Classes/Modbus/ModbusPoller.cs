using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public class ModbusPoller {
        int frequency = 1000;
        public int Frequency {
            get { return frequency; }
            set {
                if (value < 1) {
                    frequency = 1;
                }
                else {
                    frequency = value;
                }
            }
        }
        #region Channel Selection Properties
        SerialManager? channel = null;
        public SerialManager? Channel {
            get { return channel; }
            set { channel = value; }
        }
        bool read = true;
        public bool Read {
            get { return read; }
            set { read = value; BulidQuery(); }
        }
        #endregion 
        #region Query Properties
        ushort unit = 1;
        public ushort Unit {
            get { return unit; }
            set {
                if (value < 1) {
                    unit = 1;
                }
                else {
                    unit = value; BulidQuery();
                }
            }
        }
        DataSelection selection = DataSelection.ModbusDataCoils;
        public DataSelection Selection {
            get { return selection; }
            set {
                selection = value; BulidQuery();
            }
        }
        ushort start = 1;
        public ushort Start {
            get { return start; }
            set {
                start = value; BulidQuery();
            }
        }
        ushort end = 1;
        public ushort End {
            get { return end; }
            set {
                end = value; BulidQuery();
            }
        }
        public ushort Quantity {
            get { 
                return (ushort)((int)end - (int)start); 
            }
        }
        string query = "";
        public string Query {
            get { return query; }
        }
        #endregion
        string name = "";
        public string Name {
            get { return name; }
            set { name = value; }
        }
        bool enabled = true;
        public bool Enabled {
            get { return enabled; }
            set { enabled = value; }
        }
        DateTime lastActivatedTime = DateTime.UtcNow;
        public DateTime LastActivatedTime {
            get { return lastActivatedTime; }
        }
        public ModbusPoller() {

        }
        public ModbusPoller(SerialManager? Manager, bool Read, int Unit, DataSelection Selection, int Start) {
            this.channel = Manager;
            this.read = Read;
            this.unit = (ushort)Unit;
            this.Selection = Selection;
            this.start = (ushort)Start;
            this.end = start;
        }
        public ModbusPoller(SerialManager? Manager, bool Read, int Unit, DataSelection Selection, int Start, int End) {
            this.channel = Manager;
            this.read = Read;
            this.unit = (ushort)Unit;
            this.Selection = Selection;
            if (Start < End) {
                this.start = (ushort)Start;
                this.end = (ushort)End;
            }
            else if (Start > End) {
                this.start = (ushort)End;
                this.end = (ushort)Start;
            }
            else {
                this.start = (ushort)Start;
                this.end = start;
            }
            BulidQuery();
        }
        public void Invalidate() {
            if (enabled == false) { return; }
            long TimeDifference = (long)Math.Floor((decimal)(DateTime.UtcNow.Ticks - lastActivatedTime.Ticks) / 10000.0m);
            if (TimeDifference >= frequency) {
                lastActivatedTime = DateTime.UtcNow;
                SystemManager.SendModbusCommand(channel, query);
            }
        }
        private void BulidQuery() {
            string Temp = "UNIT " + Unit.ToString() + " ";
            if (read == true) {
                if (selection == DataSelection.ModbusDataCoils) {
                    if (Quantity == 0) {
                        Temp += "READ COIL " + start.ToString();
                    }
                    else {
                        Temp = "READ COILS FROM " + start.ToString() + " TO " + end.ToString();
                    }
                }
                else if (selection == DataSelection.ModbusDataDiscreteInputs) {
                    if (Quantity == 0) {
                        Temp += "READ DISCRETE " + start.ToString();
                    }
                    else {
                        Temp = "READ DISCRETE FROM " + start.ToString() + " TO " + end.ToString();
                    }
                }
                else if (selection == DataSelection.ModbusDataHoldingRegisters) {
                    if (Quantity == 0) {
                        Temp += "READ HOLDING " + start.ToString();
                    }
                    else {
                        Temp = "READ HOLDINGS FROM " + start.ToString() + " TO " + end.ToString();
                    }
                }
                else if (selection == DataSelection.ModbusDataInputRegisters) {
                    if (Quantity == 0) {
                        Temp += "READ INREGISTER " + start.ToString();
                    }
                    else {
                        Temp = "READ INREGISTERS FROM " + start.ToString() + " TO " + end.ToString();
                    }
                }
            }
            else {

            }
        }
    }
}
