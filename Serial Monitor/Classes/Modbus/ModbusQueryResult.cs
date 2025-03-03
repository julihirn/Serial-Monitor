using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public class ModbusQueryResult {
        public ModbusQueryResult(string Query) {
            this.query = Regex.Replace(Query, @"\r\n?|\n", " ").TrimEnd(); ;
        }
        private DateTime startTime = DateTime.UtcNow;
        public DateTime StartTime {
            get { return startTime; } 
        }
        public Guid Guid { get; } = Guid.NewGuid();

        private string query = "";
        public string Query {
            get { return query; }
        }
    }
    public enum ModbusQueryState {
        Stopped = 0x00,
        Executing = 0x01,
        Completed = 0x02
    }
}
