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
            set { read = value; BuildQuery(); }
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
                    unit = value; 
                }
                BuildQuery();
            }
        }
        DataSelection selection = DataSelection.ModbusDataCoils;
        public DataSelection Selection {
            get { return selection; }
            set {
                selection = value; BuildQuery();
            }
        }
        ushort start = 0;
        public ushort Start {
            get { return start; }
            set {
                start = value;
                if (end < start) {
                    ushort Temp = start;
                    start = end;
                    end = Temp;
                }
                BuildQuery();
            }
        }
        ushort end = 0;
        public ushort End {
            get { return end; }
            set {
                end = value; 
                if (end < start) {
                    ushort Temp = start;
                    start = end;
                    end = Temp;
                }
                BuildQuery();
            }
        }
        // 0 - 4, QTY 5
        public ushort Quantity {
            get { 
                return (ushort)(((int)end - (int)start) + 1); 
            }
            set {
                end = (ushort)(start + value);
                BuildQuery();
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
        DateTime lastActivatedTime = DateTime.MinValue;
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
            BuildQuery();
        }
        internal void Invalidate() {
            if (enabled == false) { return; }
            long TimeDifference = (long)Math.Floor((decimal)(DateTime.UtcNow.Ticks - lastActivatedTime.Ticks) / 10000.0m);
            if (TimeDifference >= frequency) {
                lastActivatedTime = DateTime.UtcNow;
                SystemManager.SendModbusCommand(channel, query);
            }
        }
        private void BuildQuery() {
            StringBuilder SbQuery = new StringBuilder();
            char Space = ' ';
            SbQuery.Append("UNIT");
            SbQuery.Append(Unit.ToString());
            SbQuery.Append(Space);
            if (read == true) {
                SbQuery.Append("READ");
                SbQuery.Append(Space);
                string RegisterType = "";
                switch (selection) {
                    case DataSelection.ModbusDataCoils:
                        RegisterType = Quantity <= 1 ? "COIL" : "COILS"; break;
                    case DataSelection.ModbusDataDiscreteInputs:
                        RegisterType = "DISCRETE"; break;
                    case DataSelection.ModbusDataHoldingRegisters:
                        RegisterType = Quantity <=1 ? "HOLDING" : "HOLDINGS"; break;
                    case DataSelection.ModbusDataInputRegisters:
                        RegisterType = Quantity <= 1 ? "INREGISTER" : "INREGISTERS"; break;
                }
                if (Quantity <= 1) {
                    MiniBuilder(ref SbQuery, RegisterType, start);
                }
                else {
                    MiniBuilder(ref SbQuery, RegisterType, start, end);
                }
            }
            else {

            }
            query = SbQuery.ToString();
        }
        private void MiniBuilder(ref StringBuilder SbQuery, string Query, int From) {
            char Space = ' ';
            SbQuery.Append(Query);
            SbQuery.Append(Space);
            SbQuery.Append(start.ToString());
        }
        private void MiniBuilder(ref StringBuilder SbQuery, string Query, int From, int To) {
            char Space = ' ';
            SbQuery.Append(Query);
            SbQuery.Append(Space);
            SbQuery.Append("FROM");
            SbQuery.Append(Space);
            SbQuery.Append(start.ToString());
            SbQuery.Append(Space);
            SbQuery.Append("TO");
            SbQuery.Append(Space);
            SbQuery.Append(end.ToString());
        }
    }
}
