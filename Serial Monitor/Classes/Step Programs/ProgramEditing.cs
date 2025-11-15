using ODModules;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.ProgramManager;
using static Serial_Monitor.Classes.Step_Programs.StepEnumerations;

namespace Serial_Monitor.Classes.Step_Programs {
    internal static class ProgramEditing {
        const int PROG_DATA_SIZE = 3;
        const int PROG_DATA_INDX_LINENUM = 0;
        const int PROG_DATA_INDX_ENABLE = 1;
        const int PROG_DATA_INDX_COMMAND = 2;
        const int PROG_DATA_INDX_ARGUMENTS = 3;

        internal static void ChangeEnable(ODModules.ListControl? ProgramEditor, EnableChanged TypeOfChange) {
            if (ProgramEditor == null) { return; }
            if (ProgramEditor.CurrentItems == null) { return; }
            SystemManager.InvokeProjectEdited();
            int i = 0;
            foreach (ListItem Li in ProgramEditor.CurrentItems) {
                if (Li.SubItems.Count == 3) {
                    if (Li.Selected == true) {
                        switch (TypeOfChange) {
                            case EnableChanged.EnableSelected:
                                Li.SubItems[0].Checked = true;
                                break;
                            case EnableChanged.DisableSelected:
                                Li.SubItems[0].Checked = false;
                                break;

                            case EnableChanged.ToggleSelected:
                                Li.SubItems[0].Checked = !Li.SubItems[0].Checked;
                                break;
                            default:
                                break;
                        }
                        ApplySyntaxColouring(ProgramEditor, i);
                    }
                }
                i++;
            }
            ProgramEditor.Invalidate();
        }
        #region Navigation
        internal static void ProgramEditorChange(TabHeader thPrograms, ODModules.ListControl lstStepProgram, int CurrentIndex) {
            if (thPrograms.Tabs.Count <= 0) { return; }
            if (CurrentIndex >= thPrograms.Tabs.Count) { return; }
            object? TagData = thPrograms.Tabs[CurrentIndex].Tag;
            if (TagData == null) { return; }
            if (TagData.GetType() == typeof(ProgramObject)) {
                lstStepProgram.Tag = TagData;
                ProgramManager.CurrentEditingProgram = (ProgramObject)TagData;
                lstStepProgram.ExternalItems = ((ProgramObject)TagData).Program;
                lstStepProgram.LineMarkerIndex = ((ProgramObject)TagData).ProgramMarker;
                ProgramManager.ApplyIndentation(lstStepProgram, false);
                ProgramManager.ApplySyntaxColouring(lstStepProgram, -1, true);
            }
        }
        #endregion
        #region Programs
        internal static void NewProgram(TabHeader thPrograms, string Name = "") {
            ProgramObject PrgObj = new ProgramObject(Name);
            ProgramManager.Programs.Add(PrgObj);
            Tab Tb = new Tab();
            Tb.Text = Name;
            Tb.Tag = PrgObj;
            thPrograms.Tabs.Add(Tb);
            ProgramManager.UpdateProgramNames(thPrograms);
            thPrograms.Invalidate();
            SystemManager.InvokeProjectEdited();
        }
        internal static void RemoveProgram(TabHeader thPrograms, ODModules.ListControl lstStepProgram, ToolStripSplitButton btnRun, int Index) {
            bool ChangeActiveProgram = false;
            bool ChangeEditingProgram = false;
            if (Index >= thPrograms.Tabs.Count) { return; }
            object? DataTag = thPrograms.Tabs[Index].Tag;
            if (DataTag == null) { return; }
            if (DataTag.GetType() == typeof(ProgramObject)) {
                ProgramObject PrgObj = (ProgramObject)DataTag;
                if (PrgObj == ProgramManager.CurrentProgram) {
                    ProgramManager.CurrentProgram = null;
                    ChangeActiveProgram = true;
                }
                if (lstStepProgram.Tag == PrgObj) {
                    lstStepProgram.Tag = null;
                    ChangeEditingProgram = true;
                }
                try {
                    thPrograms.Tabs.RemoveAt(Index);
                    ProgramManager.RemoveProgram(PrgObj);
                }
                catch { }
            }
            if (ProgramManager.Programs.Count == 0) {
                ProgramEditing.NewProgram(thPrograms);
                lstStepProgram.Tag = ProgramManager.Programs[0];
                lstStepProgram.ExternalItems = ProgramManager.Programs[0].Program;
                ProgramManager.CurrentProgram = ProgramManager.Programs[0];
                thPrograms.SelectedIndex = 0;
                btnRun.Text = thPrograms.Tabs[0].Text;
            }
            else {
                if (ChangeActiveProgram == true) {
                    ProgramManager.CurrentProgram = ProgramManager.Programs[0];
                    btnRun.Text = thPrograms.Tabs[0].Text;
                }
                if (ChangeEditingProgram == true) {
                    thPrograms.SelectedIndex = ProgramManager.Programs.Count - 1;
                    lstStepProgram.Tag = ProgramManager.Programs[ProgramManager.Programs.Count - 1];
                    lstStepProgram.ExternalItems = ProgramManager.Programs[ProgramManager.Programs.Count - 1].Program;
                }
            }
            thPrograms.Invalidate();
            SystemManager.InvokeProjectEdited();
            ProgramManager.DetermineName(thPrograms, btnRun);
        }
        #endregion
        #region Clipboard
        internal const string Clipboard_ProgramDataType = "SERMAN:PRG_EVEDAT";
        internal static void CopyStepProgram(ODModules.ListControl? ProgramEditor, bool DeleteCopy = false, bool ClearSelection = true) {
            if (ProgramEditor == null) { return; }
            if (ProgramEditor.ExternalItems == null) { return; }
            List<ProgramDataObject> list = new List<ProgramDataObject>();
            for (int i = ProgramEditor.ExternalItems.Count - 1; i >= 0; i--) {
                if (ProgramEditor.ExternalItems[i].Selected == true) {
                    if (ProgramEditor.ExternalItems[i].SubItems.Count == 3) {
                        ProgramDataObject ProgramItem = new ProgramDataObject();
                        ProgramItem.Enabled = ProgramEditor.ExternalItems[i].SubItems[0].Checked;
                        object? objCmd = ProgramEditor.ExternalItems[i].SubItems[1].Tag;
                        if (objCmd != null) {
                            if (objCmd.GetType() == typeof(StepEnumerations.StepExecutable)) {
                                ProgramItem.Command = (StepEnumerations.StepExecutable)objCmd;
                            }
                            else { ProgramItem.Command = StepEnumerations.StepExecutable.NoOperation; }
                        }
                        else { ProgramItem.Command = StepEnumerations.StepExecutable.NoOperation; }
                        ProgramItem.Arguments = ProgramEditor.ExternalItems[i].SubItems[2].Text;
                        list.Add(ProgramItem);
                        if (DeleteCopy == true) {
                            ProgramEditor.LineRemove(i, false);
                        }
                        else {
                            if (ClearSelection == true) {
                                ProgramEditor.ExternalItems[i].Selected = false;
                            }
                        }
                    }
                }
            }
            ProgramEditor.Invalidate();
            if (list.Count > 0) {
                Clipboard.SetData(Clipboard_ProgramDataType, list);
            }
            //Clipboard.SetDataObject(null);
        }
        internal static void PasteStepProgram(ODModules.ListControl? ProgramEditor, bool ClearSelection = true) {
            if (ProgramEditor == null) { return; }
            object? Data = Clipboard.GetDataObject();
            if (!Clipboard.ContainsData(Clipboard_ProgramDataType)) { return; }
            try {
                if (ProgramEditor.ExternalItems == null) { return; }
                List<ProgramDataObject>? CopiedItems = (List<ProgramDataObject>?)Clipboard.GetData(Clipboard_ProgramDataType);
                if (CopiedItems == null) { return; }
                if (CopiedItems.Count > 0) {
                    if (ProgramEditor.SelectionCount > 0) {
                        int CountBuffer = ProgramEditor.ExternalItems.Count - 1;
                        for (int i = CountBuffer; i >= 0; i--) {
                            if (ProgramEditor.ExternalItems[i].Selected == true) {
                                InsertAtPoint(ProgramEditor, CopiedItems, i, false);
                            }
                        }
                    }
                    else {
                        InsertAtPoint(ProgramEditor, CopiedItems, -1, true);
                    }
                    SystemManager.InvokeProjectEdited();
                }
                ProgramManager.ApplySyntaxColouring(ProgramEditor, -1, true);
                ProgramManager.ApplyIndentation(ProgramEditor, false);
                ProgramEditor.Invalidate();
            }
            catch { }
            //}
        }
        internal static void InsertAtPoint(ODModules.ListControl? ProgramEditor, List<ProgramDataObject>? CopiedItems, int Index, bool ReverseInsert) {
            if (ProgramEditor == null) { return; }
            if (CopiedItems == null) { return; }
            if (CopiedItems.Count == 0) { return; }
            if (ReverseInsert == true) {
                for (int j = CopiedItems.Count - 1; j >= 0; j--) {
                    ListItem itPar = new ListItem();
                    ListSubItem itEnb = new ListSubItem(CopiedItems[j].Enabled);
                    StepEnumerations.StepExecutable StCmd = CopiedItems[j].Command;
                    ListSubItem itCmd = new ListSubItem(ProgramManager.StepExecutableToString(StCmd));
                    itCmd.Tag = StCmd;
                    ListSubItem itArg = new ListSubItem(CopiedItems[j].Arguments);
                    itPar.SubItems.Add(itEnb);
                    itPar.SubItems.Add(itCmd);
                    itPar.SubItems.Add(itArg);
                    ProgramEditor.LineInsert(Index, itPar, false);
                }
            }
            else {
                for (int j = 0; j < CopiedItems.Count; j++) {
                    ListItem itPar = new ListItem();
                    ListSubItem itEnb = new ListSubItem(CopiedItems[j].Enabled);
                    StepEnumerations.StepExecutable StCmd = CopiedItems[j].Command;
                    ListSubItem itCmd = new ListSubItem(ProgramManager.StepExecutableToString(StCmd));
                    itCmd.Tag = StCmd;
                    ListSubItem itArg = new ListSubItem(CopiedItems[j].Arguments);
                    itPar.SubItems.Add(itEnb);
                    itPar.SubItems.Add(itCmd);
                    itPar.SubItems.Add(itArg);
                    ProgramEditor.LineInsert(Index, itPar, false);
                }
            }
        }
        #endregion
        #region DropDown Editors
        internal static void ChangeStepCommand(ODModules.ListControl? ProgramEditor, DropDownClickedEventArgs? DropDownArgs, StepEnumerations.StepExecutable StepNew) {
            if (ProgramEditor == null) { return; }
            if (DropDownArgs == null) { return; }
            if (DropDownArgs.ParentItem == null) { return; }
            if (DropDownArgs.ParentItem.SubItems == null) { return; }
            try {
                ListItem? LstItem = DropDownArgs.ParentItem;
                if (LstItem == null) { return; }
                int Column = DropDownArgs.Column;
                int Item = DropDownArgs.Item;
                StepEnumerations.StepExecutable StepExe = StepEnumerations.StepExecutable.NoOperation;
                object? objExe = LstItem.SubItems[1].Tag;
                if (objExe != null) {
                    if (objExe.GetType() == typeof(StepEnumerations.StepExecutable)) {
                        StepExe = (StepEnumerations.StepExecutable)objExe;
                    }
                }
                if (StepExe == StepNew) { return; }
                if (Column == 0) {
                    LstItem.Tag = StepNew;
                    LstItem.Text = ProgramManager.StepExecutableToString(StepNew) ?? "";
                }
                else {
                    LstItem.SubItems[Column - 1].Tag = StepNew;
                    LstItem.SubItems[Column - 1].Text = ProgramManager.StepExecutableToString(StepNew) ?? "";
                }
                SetDefault(LstItem, StepNew);
                ProgramManager.ApplyIndentation(ProgramEditor, false);
                ProgramManager.ApplySyntaxColouring(ProgramEditor, Item);
                ProgramEditor.Invalidate();
                SystemManager.InvokeProjectEdited();
            }
            catch { }
        }
        internal static void ChangeStepCommand(ODModules.ListControl? ProgramEditor, ODModules.ContextMenu? StepDropDown, object? sender) {
            if (ProgramEditor == null) { return; }
            if (StepDropDown == null) { return; }
            if (sender == null) { return; }
            if (StepDropDown.Tag == null) { return; }
            if (sender.GetType() == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
                try {
                    if (StepDropDown.Tag.GetType() == typeof(DropDownClickedEventArgs)) {
                        ListItem? LstItem = ((DropDownClickedEventArgs)StepDropDown.Tag).ParentItem;
                        if (LstItem == null) { return; }
                        int Column = ((DropDownClickedEventArgs)StepDropDown.Tag).Column;
                        int Item = ((DropDownClickedEventArgs)StepDropDown.Tag).Item;
                        StepEnumerations.StepExecutable StepExe = StepEnumerations.StepExecutable.NoOperation;
                        object? objExe = Tsmi.Tag;
                        if (objExe != null) {
                            if (objExe.GetType() == typeof(StepEnumerations.StepExecutable)) {
                                StepExe = (StepEnumerations.StepExecutable)objExe;
                            }
                        }
                        if (Column == 0) {
                            LstItem.Tag = StepExe;
                            LstItem.Text = Tsmi.Text ?? "";
                        }
                        else {
                            LstItem.SubItems[Column - 1].Tag = StepExe;
                            LstItem.SubItems[Column - 1].Text = Tsmi.Text ?? "";
                        }
                        SetDefault(LstItem, StepExe);
                        ProgramManager.ApplyIndentation(ProgramEditor, false);
                        ProgramManager.ApplySyntaxColouring(ProgramEditor, Item);
                        ProgramEditor.Invalidate();
                        SystemManager.InvokeProjectEdited();
                    }
                }
                catch { }
            }
        }
        private static void SetDefault(ListItem Li, StepEnumerations.StepExecutable StepEx) {
            if (Li.SubItems.Count != 3) { return; }
            string DefaultText = "";
            if (StepEx == StepEnumerations.StepExecutable.Delay) {
                DefaultText = "1000";
            }
            else if (StepEx == StepEnumerations.StepExecutable.Open) {
                DefaultText = "COM1";
            }
            //else if (StepEx == StepEnumerations.StepExecutable.Close) {
            //    DefaultText = "COM1";
            //}
            Li.SubItems[2].Text = DefaultText;
        }
        internal static void DropDownClicked(ODModules.ListControl? ProgramEditor, ODModules.ContextMenu? StepDropDown, TemplateContextMenuHost popupHost, DropDownClickedEventArgs e, ref bool InEditingMode) {
            if (ProgramEditor == null) { return; }
            if (StepDropDown == null) { return; }
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            if (e.Column == 2) {
                StepDropDown.Tag = e;
                //StepDropDown.Show(e.ScreenLocation);
                popupHost.Show(e.ScreenLocation);
            }
            else if (e.Column == 3) {
                if (e.ParentItem == null) { return; }
                if (e.ParentItem.SubItems == null) { return; }
                object? objTag = e.ParentItem.SubItems[1].Tag;
                StepEnumerations.StepExecutable StepExe = StepEnumerations.StepExecutable.NoOperation;
                if (objTag != null) {
                    if (objTag.GetType() == typeof(StepEnumerations.StepExecutable)) {
                        StepExe = (StepEnumerations.StepExecutable)objTag;
                    }
                }
                if (ProgramManager.AcceptsArguments(StepExe) == false) { return; }
                if ((StepExe == StepEnumerations.StepExecutable.SendText) || (StepExe == StepEnumerations.StepExecutable.PrintText)) {
                    OpenFileDialog OpenDia = new OpenFileDialog();
                    OpenDia.Filter = @"Plain Text Document (*.txt)|*.txt";
                    OpenDia.ShowDialog();
                    if (File.Exists(OpenDia.FileName)) {
                        e.ParentItem.SubItems[2].Text = OpenDia.FileName;
                        ProgramEditor.Invalidate();
                    }
                }
                else {
                    if (ProgramManager.StepExecutableToDataType(StepExe) != Classes.Step_Programs.DataType.Null) {
                        Rectangle Rect = new Rectangle(e.Location, e.ItemSize);
                        Rectangle ParRect = new Rectangle(e.ScreenLocation, e.ItemSize);
                        Components.EditValue EdVal = new Components.EditValue(StepExe, e.ParentItem.SubItems[2].Text, ProgramEditor, e.ParentItem, 3, null, false, Rect, ParRect);
                        if ((StepExe == StepEnumerations.StepExecutable.Open) || (StepExe == StepEnumerations.StepExecutable.Close)) {
                            List<Port> Ports = SystemManager.GetSerialPortSettingBased();
                            foreach (Port port in Ports) {
                                EdVal.flatComboBox1.Items.Add(port.PortName);
                            }
                        }
                        ProgramEditor.Controls.Add(EdVal);
                        EdVal.Focus();
                        EdVal.Show();
                        InEditingMode = true;
                        //EditValue EdVal = new EditValue(StepExe, e.ParentItem.SubItems[2].Text, lstStepProgram, e.ParentItem);
                        //EdVal.Sz = e.ItemSize;
                        //EdVal.Location = e.ScreenLocation;
                        //EdVal.Show();

                        //if (EdVal.DialogResult == DialogResult.OK) {
                        //e.ParentItem.SubItems[2].Text = EdVal.Output;
                        // lstStepProgram.Invalidate();
                        //}
                    }
                }

            }
        }
        #endregion
        #region Line Editing
        internal static void NewLine(ODModules.ListControl? ProgramEditor, bool InvertInsert = false) {
            if (ProgramEditor == null) { return; }
            ListItem LiPar = new ListItem();
            ListSubItem LiChk = new ListSubItem(true); LiPar.SubItems.Add(LiChk);
            ListSubItem LiCmd = new ListSubItem(); LiPar.SubItems.Add(LiCmd);
            ListSubItem LiArgs = new ListSubItem(); LiPar.SubItems.Add(LiArgs);
            LiCmd.Text = ProgramManager.StepExecutableToString(StepEnumerations.StepExecutable.NoOperation);
            LiCmd.Tag = StepEnumerations.StepExecutable.NoOperation;
            //if (lstStepProgram.ExternalItems != null) {
            //    lstStepProgram.ExternalItems.Add(LiPar);
            //}
            bool InsertState = Properties.Settings.Default.PRG_BOL_InsertBefore;
            if (InvertInsert == true) {
                InsertState = !InsertState;
            }
            ProgramEditor.LineInsertAtSelected(LiPar, InsertState, true);
            ProgramManager.ApplySyntaxColouring(ProgramEditor, -1, true);
            ProgramManager.ApplyIndentation(ProgramEditor);
            ProgramEditor.Invalidate();
            SystemManager.InvokeProjectEdited();
        }
        internal static void MoveSelected(ODModules.ListControl? ProgramEditor, bool MoveDown) {
            if (ProgramEditor == null) { return; }
            SystemManager.InvokeProjectEdited();
            ProgramEditor.LineMove(MoveDown);
            ProgramManager.ApplyIndentation(ProgramEditor, true);
        }
        internal static void RemoveSelected(ODModules.ListControl? ProgramEditor) {
            if (ProgramEditor == null) { return; }
            ProgramManager.ProgramState = StepEnumerations.StepState.Stopped;
            SystemManager.InvokeProjectEdited();
            ProgramEditor.LineRemoveSelected();
            ProgramManager.ApplyIndentation(ProgramEditor, false);
            ProgramManager.ApplyIndentation(ProgramEditor);
        }
        #endregion
        #region Editing Loaders
        internal static void LoadProgramOperations(ODModules.ListControl? ContextEditor) {
            if (ContextEditor == null) { return; }
            StepEnumerations.StepExecutable[] Steps = (StepEnumerations.StepExecutable[])StepEnumerations.StepExecutable.GetValues(typeof(StepEnumerations.StepExecutable));
            int Index = 0;
            long LastValue = 0;
            foreach (StepEnumerations.StepExecutable StepEx in Steps) {
                long Value = (long)StepEx & 0x00FF0000;
                bool CommandInvisable = ((long)StepEx & 0xF0000000) >= 0x10000000 ? true : false;
                if (CommandInvisable == true) { continue; }
                LoadProgramOperation(ContextEditor, StepEx);
                Index++;
                LastValue = Value;
            }
        }
        internal static void LoadProgramOperations(ODModules.ContextMenu? ContextEditor, EventHandler? ClickHandle) {
            if (ContextEditor == null) { return; }
            StepEnumerations.StepExecutable[] Steps = (StepEnumerations.StepExecutable[])StepEnumerations.StepExecutable.GetValues(typeof(StepEnumerations.StepExecutable));
            int Index = 0;
            long LastValue = 0;
            foreach (StepEnumerations.StepExecutable StepEx in Steps) {
                long Value = (long)StepEx & 0x00FF0000;
                bool CommandInvisable = ((long)StepEx & 0xF0000000) >= 0x10000000 ? true : false;
                if (CommandInvisable == true) { continue; }
                if (Index != 0) {
                    if (LastValue != Value) {
                        ContextEditor.Items.Add(new ToolStripSeparator());
                    }
                }
                LoadProgramOperation(ContextEditor, ClickHandle, StepEx);
                Index++;
                LastValue = Value;
            }
        }
        private static void LoadProgramOperation(ODModules.ContextMenu? ContextEditor, EventHandler? ClickHandle, StepEnumerations.StepExecutable StepEx) {
            if (ContextEditor == null) { return; }
            ToolStripMenuItem StepOperationBtn = new ToolStripMenuItem();
            StepOperationBtn.Text = ProgramManager.StepExecutableToString(StepEx); //StepEx.ToString();
            StepOperationBtn.Tag = StepEx;
            StepOperationBtn.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            StepOperationBtn.ImageScaling = ToolStripItemImageScaling.None;
            if (ClickHandle != null) {
                StepOperationBtn.Click += ClickHandle;
            }
            ContextEditor.Items.Add(StepOperationBtn);
        }
        private static void LoadProgramOperation(ODModules.ListControl? ListCtrl, StepEnumerations.StepExecutable StepEx) {
            if (ListCtrl == null) { return; }
            ListItem StepOperationBtn = new ListItem();
            StepOperationBtn.Text = ProgramManager.StepExecutableToString(StepEx); //StepEx.ToString();
            StepOperationBtn.Tag = StepEx;
            ListCtrl.Items.Add(StepOperationBtn);
        }
        internal static void ListPrograms(object? MenuList, EventHandler ClickHandler) {
            if (MenuList == null) { return; }
            if (MenuList.GetType() == typeof(ToolStripSplitButton)) {
                ToolStripSplitButton menu = (ToolStripSplitButton)MenuList;
                for (int i = menu.DropDownItems.Count - 1; i >= 0; i--) {
                    if (menu.DropDownItems[i].Tag != null) {
                        menu.Click -= ClickHandler;
                        menu.DropDownItems.RemoveAt(i);
                    }
                }
            }
            else if (MenuList.GetType() == typeof(ToolStripMenuItem)) {
                ToolStripMenuItem menu = (ToolStripMenuItem)MenuList;
                for (int i = menu.DropDownItems.Count - 1; i >= 0; i--) {
                    if (menu.DropDownItems[i].Tag != null) {
                        menu.Click -= ClickHandler;
                        menu.DropDownItems.RemoveAt(i);
                    }
                }
            }

            int j = 0;
            foreach (ProgramObject Prg in ProgramManager.Programs) {
                ToolStripMenuItem TsMi = new ToolStripMenuItem();
                string LocalisatedText = LocalisationManager.GetLocalisedText("untitledProgram", "Untitled Program");
                if (Prg.Name.Trim().Length == 0) {
                    if (j > 0) {
                        TsMi.Text = LocalisatedText + " " + j.ToString();
                    }
                    else {
                        TsMi.Text = LocalisatedText;
                    }
                    j++;
                }
                else {
                    TsMi.Text = Prg.Name;
                }
                TsMi.ImageScaling = ToolStripItemImageScaling.None;
                TsMi.Tag = Prg;
                if (ProgramManager.CurrentProgram == Prg) {
                    TsMi.Checked = true;
                }
                TsMi.Click += ClickHandler;
                if (MenuList.GetType() == typeof(ToolStripSplitButton)) {
                    ToolStripSplitButton menu = (ToolStripSplitButton)MenuList;
                    menu.DropDownItems.Add(TsMi);
                }
                else if (MenuList.GetType() == typeof(ToolStripMenuItem)) {
                    ToolStripMenuItem menu = (ToolStripMenuItem)MenuList;
                    menu.DropDownItems.Add(TsMi);
                }
            }
        }
        #endregion
        #region Editors
        private static ProgramEdit? GetEditArguments(ListItem? Input, int LineIndex) {
            if (Input == null) { return null; }
            if (Input.SubItems == null) { return null; }
            if (Input.SubItems.Count != PROG_DATA_SIZE) { return null; }
            string Arguments = Input[PROG_DATA_INDX_ARGUMENTS].Text;
            object? objFunction = Input[PROG_DATA_INDX_COMMAND].Tag;
            StepExecutable Function = StepExecutable.NoOperation;
            if (objFunction != null) {
                if (objFunction.GetType() == typeof(StepEnumerations.StepExecutable)) {
                    Function = (StepEnumerations.StepExecutable)objFunction;
                }
            }
            bool Enabled = Input[PROG_DATA_INDX_ENABLE].Checked;
            return new ProgramEdit(LineIndex, Function, Arguments, Enabled, Input);
        }
        public static void AddTextBox(DropDownClickedEventArgs e, ODModules.ListControl LstCtrl, DataSelection DataSet, Components.EditValue.ArrowKeyPressedHandler arrowKeyPressed, string? DataToPush) {
            ProgramEdit? Data = GetEditArguments(e.ParentItem, e.Item);
            if (Data == null) { return; }
            ODModules.SingleLineTextBox Tb = new ODModules.SingleLineTextBox();
            Tb.BackColor = LstCtrl.BackColor;
            Tb.SelectedBackColor = LstCtrl.BackColor;
            Tb.Font = LstCtrl.Font;
            Tb.AutoSize = false;
            Tb.ForeColor = LstCtrl.ForeColor;
            Tb.CaretColor = LstCtrl.ForeColor;
            Tb.SelectionColor = LstCtrl.SelectedColor;
            Tb.Padding = new Padding(10, 0, 0, 0);
            Tb.SelectedBorderColor = LstCtrl.CellSelectionBorderColor;
            Tb.Text = Data.Arguments;
            Tb.Tag = Data;
            LstCtrl.AddControlToCell(Tb);
            Tb.Focus();
            //EdVal.ArrowKeyPress += arrowKeyPressed;
            Tb.Leave += Tb_LostFocus;
            //Tb.KeyPress += Tb_KeyPress;
            SystemManager.InvokeModbusEditorChanged();
            Tb.EnterPressed += Tb_EnterPressed;
            Tb.TextChanged += Tb_TextChanged;
            if (DataToPush != null) {
                Tb.AppendText(DataToPush);
            }
        }


        #endregion
        #region Editor Event Handlers
        private static void Tb_EnterPressed(SingleLineTextBox sender) {
            RemoveControl(sender);
        }
        private static void Tb_TextChanged(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() != typeof(SingleLineTextBox)) { return; }
            SingleLineTextBox Ttb = (SingleLineTextBox)sender;
            object? Tag = Ttb.Tag;
            if (Tag == null) { return; }
            if (Tag.GetType() == typeof(ProgramEdit)) {
                ProgramEdit pd = (ProgramEdit)Tag;
                if (pd == null) { return; }
                if (pd.Parent.SubItems.Count != PROG_DATA_SIZE) { return; }
                pd.Parent[PROG_DATA_INDX_ARGUMENTS].Text = Ttb.Text ?? "";
            }
        }
        private static void Tb_LostFocus(object? sender, EventArgs e) {
            RemoveControl(sender);
        }
        public static void RemoveAllControls(ODModules.ListControl LstCtrl) {
            for (int i = LstCtrl.Controls.Count - 1; i >= 0; i--) {
                RemoveControl(LstCtrl.Controls[i], false);
            }
            //SystemManager.InvokeModbusEditorChanged();
        }
        private static void RemoveControl(object? sender, bool InvokeEvent = true) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(ODModules.NumericTextbox)) {
                //ODModules.NumericTextbox OdTb = (ODModules.NumericTextbox)sender;
                //OdTb.LostFocus -= Tb_LostFocus;
                //OdTb.EnterPressed -= Nb_EnterPressed;
                //OdTb.ValueChanged -= Tb_ValueChanged;
                //if (OdTb.Parent == null) { return; }
                //OdTb.Parent.Controls.Remove(OdTb);
            }
            else if (sender.GetType() == typeof(ODModules.SingleLineTextBox)) {
                ODModules.SingleLineTextBox OdTb = (ODModules.SingleLineTextBox)sender;
                OdTb.LostFocus -= Tb_LostFocus;
                OdTb.EnterPressed -= Tb_EnterPressed;
                OdTb.TextChanged -= Tb_TextChanged;
                if (OdTb.Parent == null) { return; }
                OdTb.Parent.Controls.Remove(OdTb);
            }
            //if (InvokeEvent) { SystemManager.InvokeModbusEditorChanged(); }
        }
        #endregion
    }
}
