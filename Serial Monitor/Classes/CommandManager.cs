using Handlers;
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
