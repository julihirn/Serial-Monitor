using ODModules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Serial_Monitor.Classes.Button_Commands {
    public class BtnCommand {
        public BtnCommand() {
            isSet = false;
        }
        public KeypadButton? LinkedButton = null;
        CommandType commandType = CommandType.NoAssignedCommand;
        [Category("Command")]
        [DisplayName("Execution Type")]
        [TypeConverter(typeof(EnumTypeConverter))]
        public CommandType Type {
            get { return commandType; }
            set {
                commandType = value;
                isEdited = true;
                InvokePropertyChanged();
            }
        }
        Keys shortCutKeys = Keys.None;
        [Category("Command")]
        public Keys Shortcut {
            get { return shortCutKeys; }
            set {
                shortCutKeys = value;
                if (LinkedButton != null) {
                    LinkedButton.ShortCutKeys = shortCutKeys;
                    ProjectManager.InvokeButtonPropertyChanged(LinkedButton);
                }
            }
        }
        public void SetValue(CommandType Type, string CommandLine, string Channel, int DisplaySym, int CommandShortcut) {
            isSet = true;
            commandType = Type;
            this.commandLine = CommandLine;
            this.channel = Channel;
            if (LinkedButton != null) {
                displayText = LinkedButton.Text;
            }
            try {
                DisplaySymbol = (DisplaySymbol)DisplaySym;
            }
            catch { }
            try {
                Shortcut = (Keys)CommandShortcut;
            }
            catch { }
            isEdited = false;
        }
        public void Reset() {
            isSet = false;
            isEdited = false;
            commandType = CommandType.NoAssignedCommand;
            commandLine = "";
            DisplaySymbol = DisplaySymbol.NoSymbol;
            Shortcut = Keys.None;
        }
        string displayText = "";
        [Category("Appearance")]
        [DisplayName("Text")]
        public string Text {
            get { return displayText; }
            set {
                displayText = value;
                isEdited = true;
                if (LinkedButton != null) {
                    LinkedButton.Text = displayText;
                }
                InvokePropertyChanged();
            }
        }
        DisplaySymbol displaySymbol = DisplaySymbol.NoSymbol;
        [Category("Appearance")]
        [DisplayName("Display Image")]
        [TypeConverter(typeof(EnumTypeConverter))]
        public DisplaySymbol DisplaySymbol {
            get { return displaySymbol; }
            set {
                displaySymbol = value;
                isEdited = true;
                SetDisplaySymbol(value, LinkedButton);
                InvokePropertyChanged();
            }
        }

        public static void SetDisplaySymbol(DisplaySymbol Symbol, KeypadButton? Btn) {
            if (Btn == null) { return; }
            Size GenSize = new Size(DesignerSetup.MediumIconSize, DesignerSetup.MediumIconSize);
            switch (Symbol) {
                case DisplaySymbol.NoSymbol:
                    Btn.Icon = null; break;
                case DisplaySymbol.SymbolUp:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveUp, Btn, GenSize); break;
                case DisplaySymbol.SymbolDown:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveDown, Btn, GenSize); break;
                case DisplaySymbol.SymbolLeft:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveLeft, Btn, GenSize); break;
                case DisplaySymbol.SymbolRight:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveRight, Btn, GenSize); break;
                case DisplaySymbol.SymbolAdd:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Add, Btn, GenSize); break;
                case DisplaySymbol.SymbolSubstract:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, Btn, GenSize); break;
                case DisplaySymbol.SymbolRun:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, Btn, GenSize); break;
                case DisplaySymbol.SymbolPause:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Pause, Btn, GenSize); break;
                case DisplaySymbol.SymbolStop:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, Btn, GenSize); break;
                case DisplaySymbol.SymbolAccept:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Checkmark, Btn, GenSize); break;
                case DisplaySymbol.SymbolCancel:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Cancel, Btn, GenSize); break;
                case DisplaySymbol.SymbolInfinity:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Infinity, Btn, GenSize); break;
                case DisplaySymbol.SymbolBroadcast:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.InfraredDevice, Btn, GenSize); break;
                case DisplaySymbol.SymbolStepBack:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.IntellitraceStepBack, Btn, GenSize); break;
                case DisplaySymbol.SymbolStepForward:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.IntellitraceStepOver, Btn, GenSize); break;
                case DisplaySymbol.SymbolStepOver:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.IntellitraceStepOver, Btn, GenSize); break;
                case DisplaySymbol.SymbolStepOut:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.IntellitraceStepOut, Btn, GenSize); break;
                case DisplaySymbol.SymbolLockX:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.LockXAxis, Btn, GenSize); break;
                case DisplaySymbol.SymbolLockY:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.LockYAxis, Btn, GenSize); break;
                case DisplaySymbol.SymbolLockZ:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.LockZAxis, Btn, GenSize); break;
                case DisplaySymbol.SymbolLock:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Lock, Btn, GenSize); break;
                case DisplaySymbol.SymbolUnlock:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Unlock, Btn, GenSize); break;
                case DisplaySymbol.SymbolNew:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.New, Btn, GenSize); break;
                case DisplaySymbol.SymbolRefresh:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Refresh, Btn, GenSize); break;
                case DisplaySymbol.SymbolRestart:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Restart, Btn, GenSize); break;
                case DisplaySymbol.SymbolReturn:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Return, Btn, GenSize); break;
                case DisplaySymbol.SymbolSettings:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Settings_16x, Btn, GenSize); break;
                case DisplaySymbol.SymbolShutdown:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.ShutDown, Btn, GenSize); break;
                case DisplaySymbol.SymbolRotateCounterclockwise:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.StepOver, Btn, GenSize); break;
                case DisplaySymbol.SymbolRotateClockwise:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.StepBackOver, Btn, GenSize); break;
                case DisplaySymbol.SymbolRotateBack:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.StepBackward, Btn, GenSize); break;
                case DisplaySymbol.SymbolRotateForward:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.StepForward, Btn, GenSize); break;
                case DisplaySymbol.SymbolStepTo:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.StepInto, Btn, GenSize); break;
                case DisplaySymbol.SymbolStepAway:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.StepOut, Btn, GenSize); break;
                case DisplaySymbol.SymbolSync:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Sync, Btn, GenSize); break;
                case DisplaySymbol.SymbolTime:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Time, Btn, GenSize); break;
                case DisplaySymbol.SymbolMute:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.AudioMute, Btn, GenSize); break;
                case DisplaySymbol.SymbolSound:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Volume, Btn, GenSize); break;
                default:
                    Btn.Icon = null; break;
            }
        }
        string commandLine = "";
        [Category("Command")]
        [DisplayName("Command")]
        public string CommandLine {
            get { return commandLine; }
            set {
                commandLine = value;
                isEdited = true;
                InvokePropertyChanged();
            }
        }
        string channel = "";
        [Category("Transmission")]
        [DisplayName("Channel")]
        public string Channel {
            get { return channel; }
            set {
                channel = value;
                isEdited = true;
                InvokePropertyChanged();
            }
        }
        private bool isEdited = false;
        [Browsable(false)]
        public bool IsEdited {
            get { return isEdited; }
        }
        private bool isSet = false;
        [Browsable(false)]
        public bool IsSet {
            get { return isSet; }
        }
        private void InvokePropertyChanged() {
            if (LinkedButton != null) {
                ProjectManager.InvokeButtonPropertyChanged(LinkedButton);
            }
        }
    }
    public enum CommandType {
        [Description("No Action")]
        NoAssignedCommand = 0x00,
        [Description("Send String")]
        SendString = 0x01,
        [Description("Send Text")]
        SendText = 0x02,
        [Description("Run Program")]
        ExecuteProgram = 0x04
    }
    public enum DisplaySymbol {
        [Description("No Symbol")]
        NoSymbol = 0x00,
        [Description("Up")]
        SymbolUp = 0x01,
        [Description("Down")]
        SymbolDown = 0x02,
        [Description("Left")]
        SymbolLeft = 0x03,
        [Description("Right")]
        SymbolRight = 0x04,
        [Description("Increase")]
        SymbolAdd = 0x05,
        [Description("Decrease")]
        SymbolSubstract = 0x06,
        [Description("Play")]
        SymbolRun = 0x07,
        [Description("Pause")]
        SymbolPause = 0x08,
        [Description("Stop")]
        SymbolStop = 0x09,
        [Description("Accept")]
        SymbolAccept = 0x0A,
        [Description("Cancel")]
        SymbolCancel = 0x0B,
        [Description("Infinity")]
        SymbolInfinity = 0x0C,
        [Description("Broadcast")]
        SymbolBroadcast = 0x0D,
        [Description("Step Back")]
        SymbolStepBack = 0x0E,
        [Description("Step Forward")]
        SymbolStepForward = 0x0F,
        [Description("Step Over")]
        SymbolStepOver = 0x10,
        [Description("Step Out")]
        SymbolStepOut = 0x11,
        [Description("Lock X Axis")]
        SymbolLockX = 0x12,
        [Description("Lock Y Axis")]
        SymbolLockY = 0x13,
        [Description("Lock Z Axis")]
        SymbolLockZ = 0x14,
        [Description("Lock")]
        SymbolLock = 0x15,
        [Description("Unlock")]
        SymbolUnlock = 0x16,
        [Description("New")]
        SymbolNew = 0x17,
        [Description("Refresh")]
        SymbolRefresh = 0x18,
        [Description("Restart")]
        SymbolRestart = 0x19,
        [Description("Return")]
        SymbolReturn = 0x1A,
        [Description("Settings")]
        SymbolSettings = 0x1B,
        [Description("Power")]
        SymbolShutdown = 0x1C,
        [Description("Rotate Clockwise")]
        SymbolRotateCounterclockwise = 0x1D,
        [Description("Rotate Counter Clockwise")]
        SymbolRotateClockwise = 0x1E,
        [Description("Rotate Backwards")]
        SymbolRotateBack = 0x1F,
        [Description("Rotate Forwards")]
        SymbolRotateForward = 0x20,
        [Description("Step To")]
        SymbolStepTo = 0x21,
        [Description("Step Away")]
        SymbolStepAway = 0x22,
        [Description("Sync")]
        SymbolSync = 0x23,
        [Description("Time")]
        SymbolTime = 0x24,
        [Description("Mute")]
        SymbolMute = 0x25,
        [Description("Sound")]
        SymbolSound = 0x26
    }
    class EnumTypeConverter : EnumConverter {
        private Type enumType;
        public EnumTypeConverter(Type type) : base(type) {
            enumType = type;
        }
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type destType) {
            return destType == typeof(string);
        }
        public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destType) {
            FieldInfo? fi = enumType.GetField(System.Enum.GetName(enumType, value) ?? "");
            Attribute? Attrib = Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
            DescriptionAttribute? dna = null;
            if (Attrib != null) {
                dna = (DescriptionAttribute)Attrib;
            }
            if (dna != null)
                return dna.Description;
            else
                return value.ToString() ?? "";
        }
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type srcType) {
            return srcType == typeof(string);
        }
        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) {
            foreach (FieldInfo fi in enumType.GetFields()) {
                Attribute? Attrib = Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
                DescriptionAttribute? dna = null;
                if (Attrib != null) {
                    dna = (DescriptionAttribute)Attrib;
                }
                if ((dna != null) && ((string)value == dna.Description))
                    return System.Enum.Parse(enumType, fi.Name);
            }
            return System.Enum.Parse(enumType, (string)value);
        }
    }
}
