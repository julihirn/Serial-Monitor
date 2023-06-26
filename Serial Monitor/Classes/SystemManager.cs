using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.Classes {
    public static class SystemManager {
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
    }
}
