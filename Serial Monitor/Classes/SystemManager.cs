using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.Classes {
    public static class SystemManager {
        public static List<int> DefaultBauds = new List<int>();
        public static List<SerialManager> SerialManagers = new List<SerialManager>();
        public static event ModbusReceivedHandler? ModbusReceived;
        public delegate void ModbusReceivedHandler(object Data, int Index, DataSelection DataType);
        public static void RegisterValueChanged(object Data, int Index, DataSelection DataType) {
            ModbusReceived?.Invoke(Data, Index, DataType);
        }
        public  static void SendModbusCommand(SerialManager ?CurrentManager, DataSelection DataSet, string Command) {
           
            if (CurrentManager == null) { return; }
            if (CurrentManager.IsMaster == false) { return; }
            if ((DataSet == DataSelection.ModbusDataCoils) || (DataSet == DataSelection.ModbusDataHoldingRegisters)) {
                CurrentManager.ModbusCommand(Command);
            }
        }
        public static void LoadDefaultBauds() {
            DefaultBauds.Add(50);
            DefaultBauds.Add(75);
            DefaultBauds.Add(110);
            DefaultBauds.Add(134);
            DefaultBauds.Add(150);
            DefaultBauds.Add(200);
            DefaultBauds.Add(300);
            DefaultBauds.Add(600);
            DefaultBauds.Add(1200);
            DefaultBauds.Add(1800);
            DefaultBauds.Add(2400);
            DefaultBauds.Add(4800);
            DefaultBauds.Add(9600);
            DefaultBauds.Add(19200);
            DefaultBauds.Add(28800);
            DefaultBauds.Add(38400);
            DefaultBauds.Add(57600);
            DefaultBauds.Add(76800);
            DefaultBauds.Add(115200);
            DefaultBauds.Add(230400);
            DefaultBauds.Add(460800);
            DefaultBauds.Add(576000);
            DefaultBauds.Add(921600);
        }
    }
}
