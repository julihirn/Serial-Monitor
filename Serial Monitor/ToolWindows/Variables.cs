using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
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
            //lstArray.Invalidate();
            if (selectedProgram == null) { return; }
            foreach (VariableLinkage str in selectedProgram.GlobalVariables) {
                ListItem Li = new ListItem(str.Name);
                ListSubItem Lis = new ListSubItem(str.Value);
                Li.SubItems.Add(Lis);
                lstGlobals.Items.Add(Li);
            }
            lstGlobals.Invalidate();
        }
        private void Variables_Load(object sender, EventArgs e) {
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            AdjustUserInterface();
            RecolorAll();
            ProgramManager.ProgramRemoved += ProgramManager_ProgramRemoved;
            ProgramManager.ArrayChanged += ProgramManager_ArrayChanged;
            ProgramManager.ProgramEditorChanged += ProgramManager_ProgramEditorChanged;
        }

        private void ProgramManager_ProgramEditorChanged(ProgramObject ?ProgramObj) {
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

            RecolorAll();
        }
        private void AdjustUserInterface() {
            tbVars.DebugMode = false;
            lstArray.ScaleColumnWidths();
            lstGlobals.ScaleColumnWidths();
            //navigator1.Width = DesignerSetup.ScaleInteger(navigator1.Width);
        }
        private void RecolorAll() {
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(thDataPagesHeader);
            Classes.Theming.ThemeManager.ThemeControl(tbVars);
            Classes.Theming.ThemeManager.ThemeControl(lstArray);
            Classes.Theming.ThemeManager.ThemeControl(lstGlobals);
            Classes.Theming.ThemeManager.ThemeControl(cmArray);
        }

        private void Variables_FormClosing(object sender, FormClosingEventArgs e) {
            ProgramManager.ProgramRemoved -= ProgramManager_ProgramRemoved;
            ProgramManager.ArrayChanged -= ProgramManager_ArrayChanged;
            ProgramManager.ProgramEditorChanged -= ProgramManager_ProgramEditorChanged;
        }
        private void ProgramManager_ProgramRemoved(string ID) {
            if (selectedProgram == null) { return; }
            if (selectedProgram.ID == ID) {
                SelectedProgram = null;
            }
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
        private void cutToolStripMenuItem_Click(object sender, EventArgs e) {
            CopyArray(true);
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            CopyArray();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
            PasteArray();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            DeleteArray();
        }

        private void lstGlobals_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            if (e.ParentItem == null) { return; }
            if (e.ParentItem.SubItems == null) { return; }
            Rectangle Rect = new Rectangle(e.Location, e.ItemSize);
            Rectangle ParRect = new Rectangle(e.ScreenLocation, e.ItemSize);
            Components.EditValue EdVal = new Components.EditValue(StepEnumerations.StepExecutable.SendString, e.ParentItem.SubItems[2].Text, lstGlobals, e.ParentItem, e.Column, null, false, Rect, ParRect);
            
            lstGlobals.Controls.Add(EdVal);
            EdVal.Focus();
            EdVal.Show();
        }
    }
}
