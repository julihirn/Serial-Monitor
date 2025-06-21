using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Interpreter {
    public class ExpressionInterpreter {
        public bool IsExpression(string Input, bool AllowFunctions) {
            string Pattern = "\"^\\s*((\\(*\\s*(?:\\d+(?:\\.\\d+)?|[a-zA-Z_][a-zA-Z0-9_]*)\\s*\\)*)(\\s*[-+*/]\\s*\\(*\\s*(?:\\d+(?:\\.\\d+)?|[a-zA-Z_][a-zA-Z0-9_]*)\\s*\\)*)*)\\s*$\"g";
            return Regex.IsMatch(Input, Pattern);
        }
    }
}
