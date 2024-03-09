using ODModules;
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
        #endregion
    }
}
