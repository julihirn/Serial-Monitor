using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Interpreter {
    public static class TimeFunctions {

        public static bool GetTimeQuery(string Arguments, ref List<short> Values) {
            if (Arguments == "") {
                long unixTimeMs = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
                Values.Add((short)(unixTimeMs & 0xFFFF));
                Values.Add((short)((unixTimeMs >> 16) & 0xFFFF));
                Values.Add((short)((unixTimeMs >> 32) & 0xFFFF));
                Values.Add((short)((unixTimeMs >> 48) & 0xFFFF));
                return true;
            }
            else if (Arguments.ToUpper().Trim() == "\"TICKS\"") {
                long ticks = DateTime.Now.Ticks;
                Values.Add((short)(ticks & 0xFFFF));
                Values.Add((short)((ticks >> 16) & 0xFFFF));
                Values.Add((short)((ticks >> 32) & 0xFFFF));
                Values.Add((short)((ticks >> 48) & 0xFFFF));
                return true;
            }
            else{
                long ticks = DateTime.Now.Ticks;
                Values.Add((short)(ticks & 0xFFFF));
                Values.Add((short)((ticks >> 16) & 0xFFFF));
                Values.Add((short)((ticks >> 32) & 0xFFFF));
                Values.Add((short)((ticks >> 48) & 0xFFFF));
                return true;
            }
        }
    }
}
