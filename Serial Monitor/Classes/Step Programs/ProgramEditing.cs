using ODModules;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.ProgramManager;

namespace Serial_Monitor.Classes.Step_Programs {
    internal static class ProgramEditing {
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

        #region Clipboard
        internal const string Clipboard_ProgramDataType = "SERMAN:PRG_EVEDAT";
        internal static void CopyStepProgram(ODModules.ListControl? ProgramEditor, bool DeleteCopy = false, bool ClearSelection = true) {
            if (ProgramEditor == null ) { return; }
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
        internal static void ChangeStepCommand(ODModules.ListControl? ProgramEditor, ODModules.ContextMenu? StepDropDown,object? sender) {
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
        internal static void DropDownClicked(ODModules.ListControl? ProgramEditor, ODModules.ContextMenu? StepDropDown, DropDownClickedEventArgs e, ref bool InEditingMode) {
            if (ProgramEditor == null) { return; }
            if (StepDropDown == null) { return; }
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            if (e.Column == 2) {
                StepDropDown.Tag = e;
                StepDropDown.Show(e.ScreenLocation);
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
            ProgramEditor.LineMove(true);
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
        internal static void LoadProgramOperations(ODModules.ContextMenu? ContextEditor, EventHandler ClickHandle) {
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
        private static void LoadProgramOperation(ODModules.ContextMenu? ContextEditor, EventHandler ClickHandle, StepEnumerations.StepExecutable StepEx) {
            if (ContextEditor == null) { return; }
            ToolStripMenuItem StepOperationBtn = new ToolStripMenuItem();
            StepOperationBtn.Text = ProgramManager.StepExecutableToString(StepEx); //StepEx.ToString();
            StepOperationBtn.Tag = StepEx;
            StepOperationBtn.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            StepOperationBtn.ImageScaling = ToolStripItemImageScaling.None;
            StepOperationBtn.Click += ClickHandle;
            ContextEditor.Items.Add(StepOperationBtn);
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
    }
}
