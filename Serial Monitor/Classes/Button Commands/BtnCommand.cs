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
                SetDisplaySymbol();
                InvokePropertyChanged();
            }
        }

        private void SetDisplaySymbol() {
            if (LinkedButton == null) { return; }
            Size GenSize = new Size(DesignerSetup.MediumIconSize, DesignerSetup.MediumIconSize);
            switch (displaySymbol) {
                case DisplaySymbol.NoSymbol:
                    LinkedButton.Icon = null; break;
                case DisplaySymbol.SymbolUp:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveUp, LinkedButton, GenSize); break;
                case DisplaySymbol.SymbolDown:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveDown, LinkedButton, GenSize); break;
                case DisplaySymbol.SymbolLeft:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveLeft, LinkedButton, GenSize); break;
                case DisplaySymbol.SymbolRight:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveRight, LinkedButton, GenSize); break;
                case DisplaySymbol.SymbolAdd:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Add, LinkedButton, GenSize); break;
                case DisplaySymbol.SymbolSubstract:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, LinkedButton, GenSize); break;
                case DisplaySymbol.SymbolRun:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, LinkedButton, GenSize); break;
                case DisplaySymbol.SymbolPause:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Pause, LinkedButton, GenSize); break;
                case DisplaySymbol.SymbolStop:
                    DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, LinkedButton, GenSize); break;
                default:
                    LinkedButton.Icon = null; break;
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
        SymbolStop = 0x09
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
