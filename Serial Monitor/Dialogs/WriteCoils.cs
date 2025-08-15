using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Components;
using Serial_Monitor.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Serial_Monitor.Dialogs {
    public partial class WriteCoils : SkinnedForm, ITheme {
        const int MaxCoils = 1968;
        public WriteCoils(SerialManager? SerialMan) {
            manager = SerialMan;
            InitializeComponent();
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            numtxtAddress.Maximum = new Handlers.NumericalString(ModbusSupport.MaximumRegisters);
            numtxtAddress.Height = cmbxDataSet.Height;
            numtxtUnit.Height = cmbxDataSet.Height;
        }
        protected override CreateParams CreateParams {
            get {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        SerialManager? manager = null;
        public SerialManager? Manager {
            get {
                return manager;
            }
        }
        private void WriteCoils_Load(object sender, EventArgs e) {
            ApplyTheme();
            AdjustUserInterface();
        }
        private void AdjustUserInterface() {
            tsMain.Padding = DesignerSetup.ScalePadding(tsMain.Padding);
            lstCoils.ScaleColumnWidths();
        }
        public void ApplyTheme() {
            RecolorAll();
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Add, addToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, removeToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveUp, moveUpToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveDown, moveDownToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Add, btnAdd, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, btnRemove, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveUp, btnMoveUp, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveDown, btnMoveDown, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Copy, copyToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Paste, pasteToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
        }
        private void RecolorAll() {
            this.SuspendLayout();
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            TitleBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            TitleForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            InactiveBorderColor = Properties.Settings.Default.THM_COL_MenuBack;
            ActiveBorderColor = Properties.Settings.Default.THM_COL_SelectedColor;
            Classes.Theming.ThemeManager.ThemeControl(lblpnlAddress);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlQuantity);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlRegisters);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlValue);
            Classes.Theming.ThemeManager.ThemeControl(labelPanel1);
            Classes.Theming.ThemeManager.ThemeControl(numtxtUnit);
            Classes.Theming.ThemeManager.ThemeControl(numtxtAddress);
            Classes.Theming.ThemeManager.ThemeControl(tsMain);
            Classes.Theming.ThemeManager.ThemeControl(lstCoils);
            Classes.Theming.ThemeManager.ThemeControl(cmMain);

            cmbxDataSet.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            cmbxDataSet.BackColor = Properties.Settings.Default.THM_COL_Editor;
            cmbxDataSet.BorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            cmbxDataSet.ButtonColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(btnAccept);
            Classes.Theming.ThemeManager.ThemeControl(btnCancel);

            this.ResumeLayout();
        }
        private void Add() {
            if (lstCoils.Items.Count >= MaxCoils) { return; }
            ListItem itemBasis = new ListItem();
            ListSubItem CheckBoxItem = new ListSubItem();
            itemBasis.SubItems.Add(CheckBoxItem);
            lstCoils.Items.Add(itemBasis);
            CheckOutofBounds();
        }
        private void Send() {
            if (manager == null) { return; }
            if (manager.IsMaster == false) { return; }
            if (lstCoils.Items.Count <= 0) { return; }
            string Query = "UNIT " + numtxtUnit.Value.ToString() + " ";
            Query += "WRITE COILS FROM " + numtxtAddress.Value.ToString() + " WITH ";
            int Items = 0;
            foreach (ListItem Li in lstCoils.Items) {
                if (Li.SubItems.Count == 1) {
                    Query += Li[1].Checked == true ? "1" : "0";
                    Query += ",";
                    Items++;
                }
            }
            if (Items <= 0) { return; }
            if (Items > MaxCoils) { return; }
            Query = Query.TrimEnd(',');
            SystemManager.SendModbusCommand(manager, DataSelection.ModbusDataCoils, Query);

        }
        private void Cancel() {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void toolStripButton1_Click(object sender, EventArgs e) {
            Add();
        }
        private void numtxtAddress_ValueChanged(object sender, ValueChangedEventArgs e) {
            int TempAdr = 0; int.TryParse(numtxtAddress.Value.ToString(), out TempAdr);
            lstCoils.Columns[0].CountOffset = TempAdr;
            CheckOutofBounds();
        }
        private void CheckOutofBounds() {
            int Count = 0; int.TryParse(numtxtAddress.Value.ToString(), out Count);
            foreach (ListItem Li in lstCoils.Items) {
                Li.Text = Count.ToString();
                if (Count < ushort.MaxValue) {
                    Li.UseLineBackColor = false;
                }
                else {
                    Li.UseLineBackColor = true;
                    Li.LineBackColor = Properties.Settings.Default.THM_COL_Mismatched;
                }
                Count++;
            }
            lstCoils.Invalidate();
        }
        private void WriteCoils_FormClosing(object sender, FormClosingEventArgs e) {
            lstCoils.LineRemoveAll();
            manager = null;
        }
        private void btnRemove_Click(object sender, EventArgs e) {
            lstCoils.LineRemoveSelected();
            CheckOutofBounds();
        }

        private void btnAccept_ButtonClicked(object sender) {
            Send();
        }
        private void btnCancel_ButtonClicked(object sender) {
            Cancel();
        }
        private void lstCoils_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space) {
                Toggle();
            }
        }
        private void Toggle() {
            int SelectedCount = lstCoils.SelectionCount;
            foreach (ListItem Li in lstCoils.Items) {
                if (Li.Selected == false) { continue; }
                if (Li.SubItems.Count == 1) {
                    Li[1].Checked = !Li[1].Checked;
                    SelectedCount--;
                }
                if (SelectedCount <= 0) { break; }
            }
            lstCoils.Invalidate();
        }

        private void btnMoveUp_Click(object sender, EventArgs e) {
            lstCoils.LineMove(false);
            CheckOutofBounds();
        }
        private void btnMoveDown_Click(object sender, EventArgs e) {
            lstCoils.LineMove(true);
            CheckOutofBounds();
        }
        private void sendToolStripMenuItem_Click(object sender, EventArgs e) {
            Send();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e) {
            Add();
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e) {
            lstCoils.LineRemoveSelected();
            CheckOutofBounds();
        }
        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e) {
            lstCoils.LineMove(false);
            CheckOutofBounds();
        }
        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e) {
            lstCoils.LineMove(true);
            CheckOutofBounds();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
            Paste();
        }
        private void Copy() {
            int SelectedCount = lstCoils.SelectionCount;
            string Values = "";
            int i = 0;
            if (SelectedCount <= 0) { return; }
            foreach (ListItem Li in lstCoils.Items) {
                if (Li.Selected == false) { continue; }
                if (Li.SubItems.Count == 1) {
                    if (i != 0) { Values += Constants.NewLineEnv; }
                    Values += Li[1].Checked.ToString();
                    SelectedCount--;
                    i++;
                }
                if (SelectedCount <= 0) { break; }
            }
            Clipboard.SetText(Values);
        }
        private void Paste() {
            STR_MVSSF Spilts = StringHandler.SpiltStringMutipleValues(Clipboard.GetText().Replace("\r", ""), '\n');
            int SelectedCount = lstCoils.SelectionCount;
            if (SelectedCount == 0) {
                for (int i = 0; i < Spilts.Count; i++) {
                    if (lstCoils.Items.Count >= MaxCoils) { lstCoils.Invalidate(); return; }
                    if (Spilts.Value[i].Trim() != "") {
                        ListItem itemBasis = new ListItem();
                        ListSubItem CheckBoxItem = new ListSubItem(GetCheckedState(Spilts.Value[i]));
                        itemBasis.SubItems.Add(CheckBoxItem);
                        lstCoils.Items.Add(itemBasis);
                    }
                }
                CheckOutofBounds();
                return;
            }
            for (int j = lstCoils.Items.Count - 1; j >= 0; j--) {
                if (lstCoils.Items[j].Selected == false) { continue; }
                for (int i = Spilts.Count - 1; i >= 0; i--) {
                    if (lstCoils.Items.Count >= MaxCoils) { lstCoils.Invalidate(); return; }
                    if (Spilts.Value[i].Trim() != "") {
                        ListItem itemBasis = new ListItem();
                        ListSubItem CheckBoxItem = new ListSubItem(GetCheckedState(Spilts.Value[i]));
                        itemBasis.SubItems.Add(CheckBoxItem);
                        lstCoils.Items.Insert(j, itemBasis);
                    }
                }
            }
            CheckOutofBounds();
        }
        private bool GetCheckedState(string Value) {
            string Val = Value.Replace(" ", "").Replace("\t", "").ToLower();
            if (Val == "t") { return true; }
            else if (Val == "true") { return true; }
            else if (Val == "1") { return true; }
            return false;
        }
    }
}
