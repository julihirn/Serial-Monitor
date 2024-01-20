using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.Enums.ModbusEnums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Serial_Monitor.ToolWindows {
    public partial class Variables : Form, Interfaces.ITheme {
        public Variables() {
            InitializeComponent();
        }
        ProgramObject? selectedProgram = null;
        bool AllowChanges = true;
        public ProgramObject? SelectedProgram {
            get { return selectedProgram; }
            set {
                selectedProgram = value;
                if (value != null) {
                    AllowChanges = false;
                }
                ListArray();
                ListGlobals();
            }
        }
        private void ListArray() {
            lstArray.LineRemoveAll();
            //lstArray.Invalidate();
            if (selectedProgram == null) { return; }
            foreach (string str in selectedProgram.Array) {
                ListItem Li = new ListItem();
                ListSubItem Lis = new ListSubItem(str);
                Li.SubItems.Add(Lis);
                lstArray.Items.Add(Li);
            }
            lstArray.Invalidate();
        }
        private void ListGlobals() {
            lstGlobals.LineRemoveAll();
            lstVars.LineRemoveAll();
            ListVariables(true);
            ListVariables(false);
            lstGlobals.Invalidate();
            lstVars.Invalidate();
        }
        private void ListVariables(bool IsGlobal) {
            if (SelectedProgram == null) { return; }
            if (IsGlobal) {
                foreach (VariableLinkage Var in SelectedProgram.GlobalVariables) {
                    ListItem Li = new ListItem();
                    ListSubItem Lis1 = new ListSubItem(Var.Name);
                    ListSubItem Lis2 = new ListSubItem(Var.Value);
                    Li.SubItems.Add(Lis1); Li.SubItems.Add(Lis2);
                    lstGlobals.Items.Add(Li);
                }
            }
            else {
                foreach (VariableLinkage Var in SelectedProgram.Variables) {
                    ListItem Li = new ListItem();
                    ListSubItem Lis1 = new ListSubItem(Var.Name);
                    ListSubItem Lis2 = new ListSubItem(Var.Value);
                    Li.SubItems.Add(Lis1); Li.SubItems.Add(Lis2);
                    lstVars.Items.Add(Li);
                }
            }
        }
        private void Variables_Load(object sender, EventArgs e) {
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            AdjustUserInterface();
            RecolorAll();
            AddIcons();
            ProgramManager.ProgramRemoved += ProgramManager_ProgramRemoved;
            ProgramManager.ArrayChanged += ProgramManager_ArrayChanged;
            ProgramManager.ProgramEditorChanged += ProgramManager_ProgramEditorChanged;
            ProgramManager.ProgramVariableChanged += ProgramManager_ProgramVariableChanged;
        }

        private void ProgramManager_ProgramVariableChanged(ProgramObject? ProgramObj, bool IsGlobal, int Index) {
            if (ProgramObj == null) { return; }
            if (ConversionHandler.DateIntervalDifference(LastUpdate, DateTime.UtcNow, ConversionHandler.Interval.Microsecond) < 1000) { return; }
            this.BeginInvoke(new MethodInvoker(delegate {
                this.VariableChanged(ProgramObj.ID, IsGlobal, Index);
            }));
        }
        DateTime LastUpdate = DateTime.UtcNow;
        private void VariableChanged(string ID, bool IsGlobal, int Index) {
            if (SelectedProgram == null) { return; }
            if (ID != SelectedProgram.ID) { return; }
            try {
                if (IsGlobal == true) {
                    if (SelectedProgram.GlobalVariables.Count != lstGlobals.CurrentItems.Count) {
                        lstGlobals.LineRemoveAll();
                        ListVariables(true);
                    }
                    else {
                        try {
                            if (Index < lstGlobals.CurrentItems.Count) {
                                lstGlobals.CurrentItems[Index][2].Text = SelectedProgram.GlobalVariables[Index].Value;
                            }
                        }
                        catch {
                            lstGlobals.LineRemoveAll();
                            ListVariables(true);
                        }
                    }
                    lstGlobals.Invalidate();
                }
                else {
                    if (SelectedProgram.Variables.Count != lstVars.CurrentItems.Count) {
                        lstVars.LineRemoveAll();
                        ListVariables(false);
                    }
                    else {
                        try {
                            if (Index < lstVars.CurrentItems.Count) {
                                lstVars.CurrentItems[Index][2].Text = SelectedProgram.Variables[Index].Value;
                            }
                        }
                        catch {
                            lstVars.LineRemoveAll();
                            ListVariables(false);
                        }
                    }
                    lstVars.Invalidate();
                }
            }
            catch { }
            LastUpdate = DateTime.UtcNow;
        }
        private void ProgramManager_ProgramEditorChanged(ProgramObject? ProgramObj) {
            SelectedProgram = ProgramObj;
        }

        private void ProgramManager_ArrayChanged(int Index, bool ItemRemoved) {
            if (lstArray.Items.Count > Index) {
                if (ItemRemoved == true) {
                    this.BeginInvoke(new MethodInvoker(delegate {
                        this.lstArray.Items.RemoveAt(Index);
                        this.lstArray.Invalidate();
                    }));
                }

            }
        }

        public void ApplyTheme() {
            AddIcons();
            RecolorAll();
        }
        private void AdjustUserInterface() {
            tbVars.DebugMode = false;
            lstArray.ScaleColumnWidths();
            lstGlobals.ScaleColumnWidths();
            lstVars.ScaleColumnWidths();

            msMain.Padding = DesignerSetup.ScalePadding(msMain.Padding);
            //navigator1.Width = DesignerSetup.ScaleInteger(navigator1.Width);
        }
        private void RecolorAll() {
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(thDataPagesHeader);
            Classes.Theming.ThemeManager.ThemeControl(tbVars);
            Classes.Theming.ThemeManager.ThemeControl(lstArray);
            Classes.Theming.ThemeManager.ThemeControl(lstGlobals);
            Classes.Theming.ThemeManager.ThemeControl(lstVars);
            Classes.Theming.ThemeManager.ThemeControl(cmArray);

            Classes.Theming.ThemeManager.ThemeControl(msMain);
        }
        private void AddIcons() {
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Cut, cutToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Copy, copyToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Paste, pasteToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));


            DesignerSetup.LinkSVGtoControl(Properties.Resources.Cut, cutToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Copy, copyToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Paste, pasteToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveDown, moveDownToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveUp, moveUpToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
        }

        private void Variables_FormClosing(object sender, FormClosingEventArgs e) {
            ProgramManager.ProgramRemoved -= ProgramManager_ProgramRemoved;
            ProgramManager.ArrayChanged -= ProgramManager_ArrayChanged;
            ProgramManager.ProgramEditorChanged -= ProgramManager_ProgramEditorChanged;
            ProgramManager.ProgramVariableChanged -= ProgramManager_ProgramVariableChanged;
        }
        private void ProgramManager_ProgramRemoved(string ID) {
            if (selectedProgram == null) { return; }
            if (selectedProgram.ID == ID) {
                SelectedProgram = null;
            }
        }
        #region Clipboard
        private void CopyVariable(ODModules.ListControl List, bool Delete = false) {
            string Output = "";
            int i = 0;

            foreach (ListItem li in List.Items) {
                if (li.SubItems.Count <= 0) { continue; }
                if (li.Selected) {
                    if (i < lstArray.SelectedItems()) {
                        Output += li[2].Text + Constants.NewLineEnv;
                    }
                    else {
                        Output += li[2].Text; ;
                    }
                    i++;
                }
            }
            if (Output.Length > 0) {
                Clipboard.SetText(Output);
            }
            if (Delete == false) { return; }
            DeleteVariables(List);
        }
        private void CopyArray(bool Delete = false) {
            string Output = "";
            int i = 0;

            foreach (ListItem li in lstArray.Items) {
                if (li.SubItems.Count <= 0) { continue; }
                if (li.Selected) {
                    if (i < lstArray.SelectedItems()) {
                        Output += li[1].Text + Constants.NewLineEnv;
                    }
                    else {
                        Output += li[1].Text; ;
                    }
                    i++;
                }
            }
            if (Output.Length > 0) {
                Clipboard.SetText(Output);
            }
            if (Delete == false) { return; }
            DeleteArray();
        }
        private void DeleteArray() {
            if (selectedProgram == null) { return; }
            for (int i = lstArray.Items.Count - 1; i >= 0; i--) {
                if (lstArray.Items[i].Selected) {
                    selectedProgram.Array.RemoveAt(i);
                    lstArray.Items.RemoveAt(i);
                }
            }
            lstArray.Invalidate();
        }
        private void DeleteVariables(ODModules.ListControl List) {
            try {
                if (selectedProgram == null) { return; }
                for (int i = List.Items.Count - 1; i >= 0; i--) {
                    if (List.Items[i].Selected) {
                        if (List.Name == lstGlobals.Name) {
                            selectedProgram.GlobalVariables.RemoveAt(i);
                        }
                        else if (List.Name == lstVars.Name) {
                            selectedProgram.Variables.RemoveAt(i);
                        }
                        List.Items.RemoveAt(i);
                    }
                }
                List.Invalidate();
            }
            catch { }
        }
        private void PasteArray() {
            if (selectedProgram == null) { return; }
            string TempList = Clipboard.GetText();
            if (TempList.Length == 0) { return; }
            TempList = TempList.Replace("\r\n", "\n");
            STR_MVSSF Values = StringHandler.SpiltStringMutipleValues(TempList, '\n');
            int SelectedCount = lstArray.SelectedItems();
            if (SelectedCount == 0) {
                for (int i = 0; i < Values.Value.Count; i++) {
                    selectedProgram.Array.Add(Values.Value[i]);
                    ListItem Li = new ListItem();
                    ListSubItem Lis = new ListSubItem(Values.Value[i]);
                    Li.SubItems.Add(Lis);
                    lstArray.Items.Add(Li);
                }
                lstArray.Invalidate();
            }
            else {
                for (int i = lstArray.Items.Count - 1; i >= 0; i--) {
                    if (SelectedCount > 0) {
                        if (lstArray.Items[i].Selected == true) {
                            for (int j = 0; j < Values.Value.Count; j++) {
                                int TempIndx = j + i + 1;
                                if (TempIndx < selectedProgram.Array.Count) {
                                    selectedProgram.Array.Insert(TempIndx, Values.Value[j]);
                                }
                                else {
                                    selectedProgram.Array.Add(Values.Value[j]);
                                }
                            }
                            SelectedCount--;
                        }
                    }
                }
                ListArray();
            }
        }
        private void PasteVariables(ODModules.ListControl List) {
            if (selectedProgram == null) { return; }
            string TempList = Clipboard.GetText();
            if (TempList.Length == 0) { return; }
            TempList = TempList.Replace("\r\n", "\n");
            STR_MVSSF Values = StringHandler.SpiltStringMutipleValues(TempList, '\n');
            int SelectedCount = List.SelectedItems();
            if (SelectedCount == 0) {
                for (int i = 0; i < Values.Value.Count; i++) {
                    selectedProgram.Array.Add(Values.Value[i]);
                    ListItem Li = new ListItem();
                    ListSubItem Lis = new ListSubItem(Values.Value[i]);
                    Li.SubItems.Add(Lis);
                    List.Items.Add(Li);
                }
                List.Invalidate();
            }
            else {
                for (int i = List.Items.Count - 1; i >= 0; i--) {
                    if (SelectedCount > 0) {
                        if (List.Items[i].Selected == true) {
                            for (int j = 0; j < Values.Value.Count; j++) {
                                int TempIndx = j + i + 1;
                                if (TempIndx < selectedProgram.Array.Count) {
                                    selectedProgram.Array.Insert(TempIndx, Values.Value[j]);
                                }
                                else {
                                    selectedProgram.Array.Add(Values.Value[j]);
                                }
                            }
                            SelectedCount--;
                        }
                    }
                }
                ListArray();
            }
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e) {
            Copy(true);
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
            Paste();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            Delete();
        }
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e) {
            Copy(true);
        }
        private void copyToolStripMenuItem1_Click(object sender, EventArgs e) {
            Copy();
        }
        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e) {
            Paste();
        }
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e) {
            Delete();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) {
            if (thDataPagesHeader.SelectedIndex == 0) {
                lstGlobals.LineSelectAll();
            }
            else if (thDataPagesHeader.SelectedIndex == 1) {
                lstVars.LineSelectAll();
            }
            else if (thDataPagesHeader.SelectedIndex == 2) {
                lstArray.LineSelectAll();
            }
        }
        private void Copy(bool DeleteSelected = false) {
            if (thDataPagesHeader.SelectedIndex == 0) {
                CopyVariable(lstGlobals, DeleteSelected);
            }
            else if (thDataPagesHeader.SelectedIndex == 1) {
                CopyVariable(lstVars, DeleteSelected);
            }
            else if (thDataPagesHeader.SelectedIndex == 2) {
                CopyArray(DeleteSelected);
            }
        }
        private void Paste() {
            if (thDataPagesHeader.SelectedIndex == 0) {
                DeleteVariables(lstGlobals);
            }
            else if (thDataPagesHeader.SelectedIndex == 1) {
                DeleteVariables(lstVars);
            }
            else if (thDataPagesHeader.SelectedIndex == 2) {
                PasteArray();
            }
        }
        private void Delete() {
            if (thDataPagesHeader.SelectedIndex == 0) {

            }
            else if (thDataPagesHeader.SelectedIndex == 1) {

            }
            else if (thDataPagesHeader.SelectedIndex == 2) {
                DeleteArray();
            }
        }
        #endregion
        private void msMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }
        private void topMostToolStripMenuItem_Click(object sender, EventArgs e) {
            SetTopMost(!topMostToolStripMenuItem.Checked);
        }
        public void SetTopMost(bool State) {
            topMostToolStripMenuItem.Checked = State;
            this.TopMost = State;
        }


        bool LockedEditor = false;
        private void lstArray_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            if (e.Column == 1) {
                if (LockedEditor == true) { return; }
                AddValueBox(e, lstArray, EdVal_ArrowKeyPress, false);
            }
            lstArray.Invalidate();
        }
        private void lstVars_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            if (e.Column == 2) {
                if (LockedEditor == true) { return; }
                AddValueBox(e, lstVars, EdVal_ArrowKeyPress, false);
            }
            else if (e.Column == 1) {
                //  if (LockedEditor == true) { return; }
                //  AddValueBox(e, lstVars, EdVal_ArrowKeyPress, true);
            }
        }
        private void lstGlobals_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            if (e.Column == 2) {
                if (LockedEditor == true) { return; }
                AddValueBox(e, lstGlobals, EdVal_ArrowKeyPress, false);
            }
            else if (e.Column == 1) {
                //  if (LockedEditor == true) { return; }
                // AddValueBox(e, lstGlobals, EdVal_ArrowKeyPress, true);
            }
        }
        public void AddValueBox(DropDownClickedEventArgs e, ODModules.ListControl LstCtrl, Components.EditValue.ArrowKeyPressedHandler arrowKeyPressed, bool UseName = false) {
            ListItem? LstItem = e.ParentItem;
            //LastPoint = new Point(e.Column, e.Item);
            if (LstItem == null) { return; }
            if (e.ParentItem == null) { return; }
            if (e.ParentItem.SubItems == null) { return; }
            Rectangle Rect = new Rectangle(e.Location, e.ItemSize);
            Rectangle ParRect = new Rectangle(e.ScreenLocation, e.ItemSize);
            Components.ProgramDataSet DataSet = Components.ProgramDataSet.GlobalVariable;
            if (LstCtrl.Name == lstGlobals.Name) {
                DataSet = Components.ProgramDataSet.GlobalVariable;
            }
            else if (LstCtrl.Name == lstVars.Name) {
                DataSet = Components.ProgramDataSet.Variable;
                return;
            }
            else if (LstCtrl.Name == lstArray.Name) {
                DataSet = Components.ProgramDataSet.Array;
            }
            Components.EditVariable EdVal = new Components.EditVariable(LstCtrl, e.ParentItem, e.Column, selectedProgram, DataSet, e.Item, UseName, Rect, ParRect);
            LstCtrl.Controls.Add(EdVal);
            EdVal.ArrowKeyPress += arrowKeyPressed;
            EdVal.Focus();
            EdVal.Show();
        }
        private void EdVal_ArrowKeyPress(bool IsUp) {
            if (IsUp == false) {

            }
        }
        public void ClearControls(ODModules.ListControl LstCtrl) {
            LstCtrl.Controls.Clear();
        }
        private void thDataPagesHeader_SelectedIndexChanged(object sender, int CurrentIndex, int PreviousIndex) {
            ClearControls(lstVars);
            ClearControls(lstArray);
            ClearControls(lstGlobals);
            GC.Collect();
            if (CurrentIndex == 2) {
                moveDownToolStripMenuItem.Enabled = true;
                moveUpToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem1.Enabled = true;
            }
            else {
                moveDownToolStripMenuItem.Enabled = false;
                moveUpToolStripMenuItem.Enabled = false;
                pasteToolStripMenuItem.Enabled = false;
                pasteToolStripMenuItem1.Enabled = false;
            }
            if (CurrentIndex == 0) {
                globalVariablesToolStripMenuItem.Checked = true;
                localVariablesToolStripMenuItem.Checked = false;
                arrayToolStripMenuItem.Checked = false;
            }
            else if (CurrentIndex == 1) {
                globalVariablesToolStripMenuItem.Checked = false;
                localVariablesToolStripMenuItem.Checked = true;
                arrayToolStripMenuItem.Checked = false;
            }
            else if (CurrentIndex == 2) {
                globalVariablesToolStripMenuItem.Checked = false;
                localVariablesToolStripMenuItem.Checked = false;
                arrayToolStripMenuItem.Checked = true;
            }
        }
        private void LineMove(ODModules.ListControl LstCtrl, bool MoveDown) {
            if (selectedProgram == null) { return; }
            if (!MoveDown) {
                for (int i = 0; i <= LstCtrl.Items.Count - 1; i++) {
                    if (LstCtrl.Items[i].Selected && i > 0) {
                        ListItem value = LstCtrl.Items[i - 1];
                        ListItem value2 = LstCtrl.Items[i];
                        LstCtrl.Items[i - 1] = value2;
                        LstCtrl.Items[i] = value;
                        if (thDataPagesHeader.SelectedIndex == 2) {
                            string ValueStr = selectedProgram.Array[i - 1];
                            string ValueStr2 = selectedProgram.Array[i];
                            selectedProgram.Array[i - 1] = ValueStr2;
                            selectedProgram.Array[i] = ValueStr;
                        }
                    }
                }
            }
            else {
                for (int k = LstCtrl.Items.Count - 1; k >= 0; k += -1) {
                    if (LstCtrl.Items[k].Selected && k < LstCtrl.Items.Count - 1) {
                        if (thDataPagesHeader.SelectedIndex == 2) {
                            //LstCtrl.LineMove(false);
                            ListItem value = LstCtrl.Items[k + 1];
                            ListItem value2 = LstCtrl.Items[k];
                            LstCtrl.Items[k] = value;
                            LstCtrl.Items[k + 1] = value2;

                            string ValueStr = selectedProgram.Array[k + 1];
                            string ValueStr2 = selectedProgram.Array[k];
                            selectedProgram.Array[k + 1] = ValueStr2;
                            selectedProgram.Array[k] = ValueStr;
                        }
                    }
                }
            }

            LstCtrl.Invalidate();
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e) {
            LineMove(lstArray, false);
        }
        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e) {
            LineMove(lstArray, true);
        }

        private void globalVariablesToolStripMenuItem_Click(object sender, EventArgs e) {
            thDataPagesHeader.SelectedIndex = 0;
        }
        private void localVariablesToolStripMenuItem_Click(object sender, EventArgs e) {
            thDataPagesHeader.SelectedIndex = 1;
        }
        private void arrayToolStripMenuItem_Click(object sender, EventArgs e) {
            thDataPagesHeader.SelectedIndex = 2;
        }

        private void Variables_HelpButtonClicked(object sender, CancelEventArgs e) {

        }
    }
}
