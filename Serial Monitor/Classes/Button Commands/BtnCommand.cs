using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Button_Commands {
    public class BtnCommand {
        public BtnCommand() {
            isSet = false;
        }
        CommandType commandType = CommandType.NoAssignedCommand;
        public CommandType Type {
            get { return commandType; }
            set {
                commandType = value;
                isEdited = true;
            }
        }
        public void SetValue(CommandType Type, string CommandLine, string Channel) {
            isSet = true;
            commandType = Type;
            this.commandLine = CommandLine;
            this.channel = Channel;
        }
        public void Reset() {
            isSet = false;
            isEdited = false;
            commandType = CommandType.NoAssignedCommand;
            commandLine = "";
        }
        string commandLine = "";
        public string CommandLine {
            get { return commandLine; }
            set {
                commandLine = value;
                isEdited = true;
            }
        }
        string channel = "";
        public string Channel {
            get { return channel; }
            set {
                channel = value;
                isEdited = true;
            }
        }
        private bool isEdited = false;
        public bool IsEdited {
            get { return isEdited; }
        }
        private bool isSet = false;
        public bool IsSet {
            get { return isSet; }
        }
    }
    public enum CommandType {
        NoAssignedCommand = 0x00,
        SendString = 0x01,
        SendText = 0x02,
        ExecuteProgram = 0x04
    }
}
