﻿using Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes {
    public static class CommandManager {
        public static List<CommandItem> Commands = new List<CommandItem>();
        public static void AddCommand(string Path) {
            STR_MVSSF Address = StringHandler.SpiltStringMutipleValues(Path, '.');
            int AddressDepth = Address.Count;
            object? List = null;
            int j = 0;
            for (int i = AddressDepth; i > 0; i--) {
                int CurrentIndex = FindIndex(List, Address.Value[j]);
                if (CurrentIndex == -1) {

                }
            }
        }
        private static void AddToBranch(object? Parent, string Path) {
            if (Parent == null) {
                Commands.Add(new CommandItem(Path));
            }
            else {
                if (Parent.GetType() == typeof(CommandItem)) {
                    CommandItem Temp = (CommandItem)Parent;
                    //Temp.Commands.Add(new Command(Path));
                }
            }
        }
        private static int FindIndex(object? Parent, string Path) {
            string PathClean = Path.Trim(' ').Trim('\t');
            if (PathClean == "") { return -1; }
            if (Parent == null) {
                for (int i = 0; i < Commands.Count; i++) {
                    if (Commands[i].Name.ToLower() == PathClean.ToLower()) {
                        return i;
                    }
                }
                return -1;
            }
            else {
                if (Parent.GetType() == typeof(CommandItem)) {
                    CommandItem Temp = (CommandItem)Parent;
                    for (int i = 0; i < Temp.Commands.Count; i++) {
                        if (Temp.Commands[i].Name.ToLower() == PathClean.ToLower()) {
                            return i;
                        }
                    }
                    return -1;
                }
                else if (Parent.GetType() == typeof(CommandSubItem)) {
                    CommandSubItem Temp = (CommandSubItem)Parent;
                    for (int i = 0; i < Temp.Commands.Count; i++) {
                        if (Temp.Commands[i].Name.ToLower() == PathClean.ToLower()) {
                            return i;
                        }
                    }
                    return -1;
                }
            }
            return -1;
        }
        public static void ExecuteCommand(string CommandString) {

        }
        #region Command Parsing
        public static Point GetStartAndDifference(int Start, int End) {
            if (Start < End) {
                return new Point(Start, (End - Start) + 1);
            }
            return new Point(End, (Start - End) + 1);
        }
        public static bool GetIntegerValues(ref string Input, string Compare, ref List<short> Values, bool DelimitOnEquals = false) {
            if (TestKeyword(ref Input, Compare)) {

                if (DelimitOnEquals) {
                    string StrAddress = ReadAndRemove(ref Input, '=').TrimStart(' ');
                    STR_MVSSF TempValues = StringHandler.SpiltStringMutipleValues(StrAddress.Trim(' '), ',');
                    for (int i = 0; i < TempValues.Count; i++) {
                        short Temp = 0;
                        bool Success = short.TryParse(TempValues.Value[i], out Temp);
                        if (Success == false) { return false; }
                        Values.Add(Temp);
                    }
                }
                else {
                    string StrAddress = Input.TrimStart(' ');
                    STR_MVSSF TempValues = StringHandler.SpiltStringMutipleValues(StrAddress.Trim(' '), ',');
                    for (int i = 0; i < TempValues.Count; i++) {
                        short Temp = 0;
                        bool Success = short.TryParse(TempValues.Value[i], out Temp);
                        if (Success == false) { return false; }
                        Values.Add(Temp);
                    }
                }
                return true;
            }
            return false;
        }
        public static bool GetBooleanValues(ref string Input, string Compare, ref List<bool> Values, bool DelimitOnEquals = false) {
            if (TestKeyword(ref Input, Compare)) {

                if (DelimitOnEquals) {
                    string StrAddress = ReadAndRemove(ref Input, '=').TrimStart(' ');
                    STR_MVSSF TempValues = StringHandler.SpiltStringMutipleValues(StrAddress.Trim(' '), ',');
                    for (int i = 0; i < TempValues.Count; i++) {
                        string Temp = TempValues.Value[i].ToLower();
                        if (Temp == "1") {
                            Values.Add(true);
                        }
                        else if (Temp == "0") {
                            Values.Add(false);
                        }
                        else if (Temp == "f") {
                            Values.Add(false);
                        }
                        else if (Temp == "t") {
                            Values.Add(true);
                        }
                        else if (Temp == "false") {
                            Values.Add(false);
                        }
                        else if (Temp == "true") {
                            Values.Add(true);
                        }
                        else {
                            return false;
                        }
                    }
                }
                else {
                    string StrAddress = Input.TrimStart(' ');
                    STR_MVSSF TempValues = StringHandler.SpiltStringMutipleValues(StrAddress.Trim(' '), ',');
                    for (int i = 0; i < TempValues.Count; i++) {
                        string Temp = TempValues.Value[i].ToLower().Trim(' ');
                        if (Temp == "1") {
                            Values.Add(true);
                        }
                        else if (Temp == "0") {
                            Values.Add(false);
                        }
                        else if (Temp == "f") {
                            Values.Add(false);
                        }
                        else if (Temp == "t") {
                            Values.Add(true);
                        }
                        else if (Temp == "false") {
                            Values.Add(false);
                        }
                        else if (Temp == "true") {
                            Values.Add(true);
                        }
                        else {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
        public static bool GetValue(ref string Input, string Compare, out int Value, bool DelimitOnEquals = false) {
            string OldVal = Input;
            if (TestKeyword(ref Input, Compare)) {

                if (DelimitOnEquals) {
                    string StrAddress = ReadAndRemove(ref Input, '=').TrimStart(' ');
                    bool Success = int.TryParse(StrAddress, out Value);
                    if (Success == false) { Input = OldVal;  return false; }
                }
                else {
                    string StrAddress = ReadAndRemove(ref Input).TrimStart(' ');
                    bool Success = int.TryParse(StrAddress, out Value);
                    if (Success == false) { Input = OldVal; return false; }
                }
                return true;
            }
            Value = 0;
            Input = OldVal;
            return false;
        }
        public static bool GetValue(ref string Input, string Compare, out string Value, bool DelimitOnEquals = false, bool CaseInvariant = false) {
            if (TestKeyword(ref Input, Compare, CaseInvariant)) {

                if (DelimitOnEquals) {
                    string StrAddress = ReadAndRemove(ref Input, '=').TrimStart(' ');
                    Value = StrAddress;
                    return true;
                }
                else {
                    string StrAddress = ReadAndRemove(ref Input).TrimStart(' ');
                    Value = StrAddress;
                    return true;
                }
            }
            Value = "";
            return false;
        }
        public static bool GetValue(ref string Input, string Compare, out int Value, char Delimiter) {
            if (TestKeyword(ref Input, Compare)) {
                string StrAddress = ReadAndRemove(ref Input, Delimiter).TrimStart(' ');
                bool Success = int.TryParse(StrAddress, out Value);
                if (Success == false) { return false; }
                return true;
            }
            Value = 0;
            return false;
        }
        public static bool TestKeyword(ref string Input, string Compare, bool CaseInvariant = false) {
            if (CaseInvariant == true) {
                if (Input.ToUpper().StartsWith(Compare.ToUpper())) {
                    Input = Input.Remove(0, Compare.Length);
                    Input = Input.TrimStart(' ');
                    return true;
                }
            }
            else {
                if (Input.StartsWith(Compare)) {
                    Input = Input.Remove(0, Compare.Length);
                    Input = Input.TrimStart(' ');
                    return true;
                }
            }
            return false;
        }
        public static string ReadAndRemove(ref string Input, char RemoveChar = ' ') {
            string Temp = Input.Split(RemoveChar)[0];
            Input = Input.Remove(0, Temp.Length);
            Input = Input.TrimStart(' ');
            return Temp;
        }
        public static string GetQuery(string Input, ref string Remainder) {
            string Temp = "";
            bool InQuery = false;
            int QueryStart = -1;
            int QueryEnd = -1;
            int QueryAbsoluteEnd = -1;
            Input = Input.Replace((char)0x09, ' ');
            Input = Input.Replace('\n', ' ');
            Input = Input.Replace('\r', ' ');
            Input += " ";
            for (int i = 0; i < Input.Length; i++) {
                if (Input[i] == ' ') {
                    if (Temp.ToUpper() == "BEGIN") {
                        QueryStart = i;
                        InQuery = true;
                    }
                    else if (Temp.ToUpper() == "END") {
                        if (InQuery == true) {
                            QueryEnd = i-4;
                            QueryAbsoluteEnd = i;
                            InQuery = false;
                            break;
                        }

                    }
                    Temp = "";
                }
                else {
                    Temp += Input[i];
                }
            }
            if (QueryStart <= -1) { return ""; }
            if (QueryEnd <= -1) { return ""; }
            if (QueryStart >= Input.Length) { return ""; }
            if (QueryEnd >= Input.Length) { return ""; }
            Remainder = Input.Substring(QueryAbsoluteEnd, Input.Length - QueryAbsoluteEnd);
            return Input.Substring(QueryStart, QueryEnd - QueryStart).TrimStart(' ');
        }
        #endregion
        #region Modbus Query
        public static bool IsModbusKeyword(string Input) {
            string Temp = Input.ToLower();
            if (Temp == "read") { return true; }
            else if (Temp == "write") {  return true; }
            else if (Temp == "using") { return true; }
            else if (Temp == "begin") { return true; }
            else if (Temp == "end") { return true; }
            else if (Temp == "coil") { return true; }
            else if (Temp == "coils") { return true; }
            else if (Temp == "discrete") { return true; }
            else if (Temp == "register") { return true; }
            else if (Temp == "registers") { return true; }
            else if (Temp == "inregister") { return true; }
            else if (Temp == "inregisters") { return true; }
            else if (Temp == "holding") { return true; }
            else if (Temp == "holdings") { return true; }
            else if (Temp == "input") { return true; }
            else if (Temp == "inputs") { return true; }
            else if (Temp == "true") { return true; }
            else if (Temp == "false") { return true; }
            else if (Temp == "from") { return true; }
            else if (Temp == "to") { return true; }
            else if (Temp == "with") { return true; }
            else if (Temp == "qty") { return true; }
            else if (Temp == "mask") { return true; }
            else if (Temp == "diagnostics") { return true; }
            else if (Temp == "return") { return true; }
            else if (Temp == "query") { return true; }
            else if (Temp == "bus") { return true; }
            else if (Temp == "messages") { return true; }
            else if (Temp == "errors") { return true; }
            else if (Temp == "exceptions") { return true; }
            else if (Temp == "overruns") { return true; }
            else if (Temp == "slave") { return true; }
            else if (Temp == "busy") { return true; }
            else if (Temp == "nores") { return true; }
            else if (Temp == "noack") { return true; }
            else if (Temp == "clear") { return true; }
            else if (Temp == "counters") { return true; }
            else if (Temp == "restart") { return true; }
            else if (Temp == "force") { return true; }
            else if (Temp == "listen") { return true; }
            else if (Temp == "set") { return true; }
            else if (Temp == "delimiter") { return true; }
            return false;
        }
        #endregion
    }
    public class Command {
        private string name = "";
        public string Name {
            get { return name; }
            set { name = value; }
        }
        private bool indexable = false;
        public bool Indexable {
            get { return indexable; }
            set { indexable = value; }
        }
        private bool assignable = false;
        public bool Assignable {
            get { return assignable; }
            set { assignable = value; }
        }
        private bool executable = false;
        public bool Executable {
            get { return executable; }
            set { executable = value; }
        }
        private EventHandler? eventHandle = null;
        public EventHandler? EventHandle {
            get { return eventHandle; }
            set {
                eventHandle = value;
            }
        }
        List<Command> commands = new List<Command>();
        public List<Command> Commands {
            get { return commands; }
        }
    }
    public class CommandItem : Command {
        public CommandItem(string Name) {
            this.Name = Name;
        }
    }
    public class CommandSubItem : Command {
        public CommandSubItem(string Name) {
            this.Name = Name;
        }
    }
}
