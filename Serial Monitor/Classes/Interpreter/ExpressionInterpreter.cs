using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Serial_Monitor.Classes.Interpreter {
    public class ExpressionInterpreter {
        public static bool IsExpression(string Input, bool AllowFunctions) {
            string Pattern = "";
            if (AllowFunctions) {
                Pattern = "\"^\\s*((\\(*\\s*(?:\\d+(?:\\.\\d+)?|[a-zA-Z_][a-zA-Z0-9_]*|[a-zA-Z_][a-zA-Z0-9_]*\\(.*\\))\\s*\\)*)(\\s*[-+*\\/]\\s*\\(*\\s*(?:\\d+(?:\\.\\d+)?|[a-zA-Z_][a-zA-Z0-9_]*|[a-zA-Z_][a-zA-Z0-9_]*\\(.*\\))\\s*\\)*)*)\\s*$\"g";
            }
            else {
                Pattern = "\"^\\s*((\\(*\\s*(?:\\d+(?:\\.\\d+)?|[a-zA-Z_][a-zA-Z0-9_]*)\\s*\\)*)(\\s*[-+*/]\\s*\\(*\\s*(?:\\d+(?:\\.\\d+)?|[a-zA-Z_][a-zA-Z0-9_]*)\\s*\\)*)*)\\s*$\"g";
            }
            return Regex.IsMatch(Input, Pattern);
        }
        public static TokenType DetermineTokenType(string Input) {
            if (IsExpression(Input, true)) { return TokenType.Expression; }
            else if (Input.Trim(' ').StartsWith('"') && Input.Trim(' ').EndsWith('"')) { return TokenType.String; }
            return TokenType.Number;
        }
        public static List<string> GetArguments(string Input) {
            string[] parts = Regex.Split(Input, @",(?=(?:[^""]*""[^""]*"")*[^""]*$)(?=(?:[^()]*\([^()]*\))*[^()]*$)");
            return new List<string>(parts);
        }
    }
    public enum TokenType {
        Number = 0x00,
        String = 0x01,
        Expression = 0x02,
        Invaild = 0xFF

    }
}
