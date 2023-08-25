using Handlers;
using ODModules;
using Serial_Monitor.Classes.Step_Programs;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataType = Handlers.DataType;

namespace Serial_Monitor.Classes {
    public static class ProjectManager {
        public static List<KeypadButton> Buttons = new List<KeypadButton>();

        public static event FileOpenedHandler? ProgramNameChanged;
        public delegate void FileOpenedHandler(string Address);
        public static void ClearKeypad() {
            Buttons.Clear();
        }
        public static void WriteFile(string FileAddress) {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string ProgramVersion = fvi.ProductMajorPart + "." + fvi.ProductMinorPart.ToString();
            using (StreamWriter Sw = new StreamWriter(FileAddress)) {
                Sw.WriteLine("--------------------------");
                Sw.WriteLine("-- SERIAL MONITOR");
                Sw.WriteLine("-- VERSION " + ProgramVersion + " (Build " + fvi.ProductBuildPart.ToString() + ")");
                Sw.WriteLine("--------------------------");
                Sw.WriteLine("");
                Sw.WriteLine("Begin,");
                Sw.WriteLine("Create Lines(1),");
                Sw.WriteLine("--  Document Details");
                Sw.WriteLine(StringHandler.AddTabs(1, "def,str:ProgramName=" + StringHandler.EncapsulateString("")));
                Sw.WriteLine(StringHandler.AddTabs(1, "def,str:Author=" + StringHandler.EncapsulateString(Environment.UserName)));
                Sw.WriteLine(StringHandler.AddTabs(1, "def,dec:Version=" + ProgramVersion));
                Sw.WriteLine("");
                if (SystemManager.SerialManagers.Count > 0) {
                    Sw.WriteLine("--  Channels");
                    int i = 0;
                    foreach (SerialManager Sm in SystemManager.SerialManagers) {
                        Sw.WriteLine(StringHandler.AddTabs(1, "def,parm:CHAN_" + i.ToString() + "{"));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:Name=" + StringHandler.EncapsulateString(Sm.Name)));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:Port=" + StringHandler.EncapsulateString(Sm.Port.PortName)));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,int:Baud=" + Sm.Port.BaudRate));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,int:DataSize=" + Sm.Port.DataBits));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:StopBits=" + StringHandler.EncapsulateString(EnumManager.StopBitsToString(Sm.Port.StopBits))));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:Parity=" + StringHandler.EncapsulateString(EnumManager.ParityToString(Sm.Port.Parity))));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:InType=" + StringHandler.EncapsulateString(EnumManager.InputFormatToString(Sm.InputFormat).B)));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:OutType=" + StringHandler.EncapsulateString(EnumManager.OutputFormatToString(Sm.OutputFormat).B)));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,bol:ModbusMstr=" + Sm.IsMaster.ToString()));
                        Sw.WriteLine(StringHandler.AddTabs(1, "}"));
                        i++;
                    }
                }
                Sw.WriteLine("");
                if (ProgramManager.Programs.Count > 0) {
                    Sw.WriteLine("--  Step Programs");
                    int Cnt = 0;
                    foreach (ProgramObject Prg in ProgramManager.Programs) {
                        if (Prg.Program.Count > 0) {
                            Sw.WriteLine(StringHandler.AddTabs(1, "def,parm:STEP_" + Cnt.ToString() + "{"));
                            Sw.WriteLine(StringHandler.AddTabs(2, "def,str:Name=" + StringHandler.EncapsulateString(Prg.Name)));
                            Sw.WriteLine(StringHandler.AddTabs(2, "def,str:Command=" + StringHandler.EncapsulateString(Prg.Command)));
                            Sw.WriteLine(StringHandler.AddTabs(2, "def,a(str):Data={"));
                            foreach (ListItem LstItm in Prg.Program) {
                                if (LstItm.SubItems.Count == 3) {
                                    string EnableTxt = LstItm.SubItems[0].Checked == true ? "1" : "0";
                                    string Command = "";
                                    object? CommandObj = LstItm.SubItems[1].Tag;
                                    if (CommandObj != null) {
                                        if (CommandObj.GetType() == typeof(StepEnumerations.StepExecutable)) {
                                            Command = ((int)((StepEnumerations.StepExecutable)CommandObj)).ToString("00000000");
                                        }
                                    }
                                    string Arguments = LstItm.SubItems[2].Text;
                                    Sw.WriteLine(StringHandler.AddTabs(3, StringHandler.EncapsulateString(EnableTxt + ":" + Command + ":" + Arguments)));
                                }
                            }
                            Sw.WriteLine(StringHandler.AddTabs(2, "}"));
                            Sw.WriteLine(StringHandler.AddTabs(1, "}"));
                        }
                        Cnt++;
                    }
                }
                if (Buttons.Count > 0) {
                    Sw.WriteLine("--  Keypad Buttons");
                    int Cnt = 0;
                    foreach (KeypadButton Btn in Buttons) {
                        Sw.WriteLine(StringHandler.AddTabs(1, "def,parm:KBTN_" + Cnt.ToString() + "{"));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:Text=" + StringHandler.EncapsulateString(Btn.Text)));
                        Sw.WriteLine(StringHandler.AddTabs(2, "def,str:Command=" + StringHandler.EncapsulateString(Btn.Command)));

                        Sw.WriteLine(StringHandler.AddTabs(2, "}"));
                        Sw.WriteLine(StringHandler.AddTabs(1, "}"));
                        Cnt++;
                    }
                }
            }
        }
        private static List<string> GetList(object Input) {
            if (Input == null) {
                return new List<string>();
            }
            if (Input.GetType() == typeof(List<string>)) {
                return (List<string>)Input;
            }
            return new List<string>();
        }
        public static void ReadSMPFile(string FileAddress, SerialManager.CommandProcessedHandler CmdProc, SerialManager.DataProcessedHandler DataProc) {
            ProgramManager.Programs.Add(new ProgramObject());
            int CurrentProgramIndex = 0;
            for (int i = 0; i < DocumentHandler.PARM.Count; i++) {
                string ParameterName = DocumentHandler.PARM[i].Name;
                if (ParameterName.StartsWith("CHAN")) {
                    ParameterStructure Pstrc = DocumentHandler.PARM[i];
                    SerialManager Sm = new SerialManager();
                    Sm.Name = DocumentHandler.GetStringVariable(Pstrc, "Name", "");
                    try {
                        Sm.Port.PortName = DocumentHandler.GetStringVariable(Pstrc, "Port", "");
                    }
                    catch { }
                    try {
                        Sm.BaudRate = DocumentHandler.GetIntegerVariable(Pstrc, "Baud", 9600);
                    }
                    catch { }
                    try {
                        Sm.Port.DataBits = DocumentHandler.GetIntegerVariable(Pstrc, "DataSize", 8);
                    }
                    catch { }
                    try {
                        Sm.Port.StopBits = EnumManager.StringToStopBits(DocumentHandler.GetStringVariable(Pstrc, "StopBits", "1"));
                    }
                    catch { }
                    try {
                        Sm.Port.Parity = EnumManager.StringToParity(DocumentHandler.GetStringVariable(Pstrc, "Parity", "N"));
                    }
                    catch { }
                    try {
                        Sm.InputFormat = EnumManager.StringToInputFormat(DocumentHandler.GetStringVariable(Pstrc, "InType", "frmTxt"));
                    }
                    catch { }
                    try {
                        Sm.OutputFormat = EnumManager.StringToOutputFormat(DocumentHandler.GetStringVariable(Pstrc, "OutType", "frmTxt"));
                    }
                    catch { }
                    try {
                        Sm.IsMaster = DocumentHandler.GetBooleanVariable(Pstrc, "ModbusMstr");
                    }
                    catch { }

                    Sm.CommandProcessed += CmdProc;// SerManager_CommandProcessed;
                    Sm.DataReceived += DataProc;// SerMan_DataReceived;
                    SystemManager.SerialManagers.Add(Sm);
                }
                else if (ParameterName.StartsWith("KBTN")) {
                    KeypadButton KButton = new KeypadButton();
                    KButton.Text = DocumentHandler.GetStringVariable(DocumentHandler.PARM[i], "Text", "");
                    Buttons.Add(KButton);
                }
                else if (ParameterName.StartsWith("STEP")) {
                    if (CurrentProgramIndex > 0) {
                        ProgramManager.Programs.Add(new ProgramObject());
                    }
                    //E:00000000:
                    ProgramManager.Programs[CurrentProgramIndex].Name = DocumentHandler.GetStringVariable(DocumentHandler.PARM[i], "Name", "");
                    ProgramManager.Programs[CurrentProgramIndex].Command = DocumentHandler.GetStringVariable(DocumentHandler.PARM[i], "Command", "");
                    if (DocumentHandler.IsDefinedInParameter("Data", DocumentHandler.PARM[i])) {

                        List<string> Data = GetList(DocumentHandler.PARM[i].GetVariable("Data", false, DataType.STR));
                        for (int j = 0; j < Data.Count; j++) {
                            ProgramManager.Programs[CurrentProgramIndex].DecodeFileCommand(Data[j]);
                        }
                    }
                    CurrentProgramIndex++;

                }
            }
        }
        public static void ReadCMSLFile(string FileAddress, SerialManager.CommandProcessedHandler CmdProc, SerialManager.DataProcessedHandler DataProc) {
            SerialManager Sm = new SerialManager();
            Sm.CommandProcessed += CmdProc;// SerManager_CommandProcessed;
            Sm.DataReceived += DataProc;// SerMan_DataReceived;
            SystemManager.SerialManagers.Add(Sm);
            ProgramManager.Programs.Add(new ProgramObject("Legacy Program"));
            try {
                using (StreamReader TxtReader = new StreamReader(FileAddress)) {
                    while (TxtReader.Peek() > -1) {
                        ProgramManager.Programs[0].DecodeLegacyFileCommand(TxtReader.ReadLine() ?? "");
                    }
                }
            }
            catch { }
        }
        public static StepEnumerations.StepExecutable ExecutableFromLegacyString(string Input) {
            Input = Input.ToUpper();
            if (Input == "SND") { return StepEnumerations.StepExecutable.SendString;}
            else if (Input == "STXT") { return StepEnumerations.StepExecutable.SendText; }
            else if (Input == "PRNT") { return StepEnumerations.StepExecutable.Print; }
            else if (Input == "END") { return StepEnumerations.StepExecutable.Close; }
            else if (Input == "OPEN") { return StepEnumerations.StepExecutable.Open; }
            else if (Input == "SNDL") { return StepEnumerations.StepExecutable.SendString; }
            else if (Input == "CLR") { return StepEnumerations.StepExecutable.Clear; }
            else if (Input == "DLY") { return StepEnumerations.StepExecutable.Delay; }
            else if (Input == "GOTO") { return StepEnumerations.StepExecutable.GoToLine; }
           // else if (Input == "WHEN_TCK") { return StepEnumerations.StepExecutable.GoTo; }
            else if (Input == "SBYTE") { return StepEnumerations.StepExecutable.SendByte; }
            else if (Input == "SWS") { return StepEnumerations.StepExecutable.SwitchSender; }
            else { return StepEnumerations.StepExecutable.NoOperation; }
        }
    }
}
