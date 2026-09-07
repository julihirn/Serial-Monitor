using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Serial_Monitor.Classes.Interpreter {
    public class ExpressionInterpreter {
        private static readonly Regex StringRegex = new Regex(@"^""(?:\\.|[^""\\])*""$");
        private static readonly Regex FloatRegex = new Regex(@"^\d+\.\d+$");
        private static readonly Regex NumberRegex = new Regex(@"^(?:0x[0-9A-Fa-f]+|0b[01]+|\d+)$");

        public static bool IsExpression(string Input, bool AllowFunctions) {
            string Pattern = "";
            if (AllowFunctions) {
                Pattern = @"^\s*((\(*\s*(?:\d+(?:\.\d+)?|[a-zA-Z_][a-zA-Z0-9_]*|[a-zA-Z_][a-zA-Z0-9_]*\(.*\))\s*\)*)(\s*[-+*\/]\s*\(*\s*(?:\d+(?:\.\d+)?|[a-zA-Z_][a-zA-Z0-9_]*|[a-zA-Z_][a-zA-Z0-9_]*\(.*\))\s*\)*)*)\s*$";
            }
            else {
                Pattern = @"^\\s*((\(*\s*(?:\d+(?:\.\d+)?|[a-zA-Z_][a-zA-Z0-9_]*)\s*\)*)(\s*[-+*/]\s*\(*\s*(?:\d+(?:\.\d+)?|[a-zA-Z_][a-zA-Z0-9_]*)\s*\)*)*)\s*$";
            }
            return Regex.IsMatch(Input, Pattern);
        }
        public static TokenType DetermineTokenType(string Input) {
            Input = Input.Trim();
            if (StringRegex.IsMatch(Input)){
                return TokenType.String;
            }
            if (FloatRegex.IsMatch(Input)){
                return TokenType.Float;
            }
            if (NumberRegex.IsMatch(Input)){
                return TokenType.Number;
            }
            return TokenType.Expression;
        }
        public static List<string> GetArguments(string Input) {
            string[] parts = Regex.Split(Input, @",(?=(?:[^""]*""[^""]*"")*[^""]*$)(?=(?:[^()]*\([^()]*\))*[^()]*$)");
            return new List<string>(parts);
        }



    }
    public enum TokenType {
        Number = 0x00,
        Float = 0x01,
        String = 0x02,
        Expression = 0x04,
        Invaild = 0xFF

    }
}
