using FastColoredTextBoxNS;
using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Enums;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Components;
using Serial_Monitor.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static Serial_Monitor.Classes.Enums.ModbusEnums;

namespace Serial_Monitor.Dialogs {
    public partial class WriteRegisters : SkinnedForm, ITheme {
        const int MaxRegisters = 100;
        public WriteRegisters(SerialManager? SerialMan) {
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
        private void WriteRegisters_Load(object sender, EventArgs e) {
            EnumManager.LoadDataFormats(ddbFormat, CmDisplayFormat_Click);
            EnumManager.LoadDataSizes(ddbSize, CmDisplaySize_Click);
            ApplyTheme();
            AdjustUserInterface();
        }
        private void AdjustUserInterface() {
            tsFormat.Padding = DesignerSetup.ScalePadding(tsFormat.Padding);
            tsMain.Padding = DesignerSetup.ScalePadding(tsMain.Padding);
            lstRegisters.ScaleColumnWidths();
        }
        public void ApplyTheme() {
            RecolorAll();
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Add, btnAdd, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, btnRemove, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveUp, btnMoveUp, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.MoveDown, btnMoveDown, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
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
            Classes.Theming.ThemeManager.ThemeControl(lblpnlFormat);
            Classes.Theming.ThemeManager.ThemeControl(labelPanel1);
            Classes.Theming.ThemeManager.ThemeControl(numtxtUnit);
            Classes.Theming.ThemeManager.ThemeControl(numtxtAddress);
            Classes.Theming.ThemeManager.ThemeControl(tsMain);
            Classes.Theming.ThemeManager.ThemeControl(tsFormat, true);
            Classes.Theming.ThemeManager.ThemeControl(lstRegisters);
            Classes.Theming.ThemeManager.ThemeControl(cmMain);

            cmbxDataSet.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            cmbxDataSet.BackColor = Properties.Settings.Default.THM_COL_Editor;
            cmbxDataSet.BorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            cmbxDataSet.ButtonColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(btnAccept);
            Classes.Theming.ThemeManager.ThemeControl(btnCancel);

            this.ResumeLayout();
        }
        private void Cancel() {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCancel_ButtonClicked(object sender) {
            Cancel();
        }
        private void btnAccept_ButtonClicked(object sender) {
            Send();
        }
        private void sendToolStripMenuItem_Click(object sender, EventArgs e) {
            Send();
        }
        private void btnMoveUp_Click(object sender, EventArgs e) {
            lstRegisters.LineMove(false);
            UpdateRegisterCounters(true);
        }
        private void btnMoveDown_Click(object sender, EventArgs e) {
            lstRegisters.LineMove(true);
            UpdateRegisterCounters(true);
        }
        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e) {
            lstRegisters.LineMove(false);
            UpdateRegisterCounters(true);
        }
        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e) {
            lstRegisters.LineMove(true);
            UpdateRegisterCounters(true);
        }
        private void btnRemove_Click(object sender, EventArgs e) {
            lstRegisters.LineRemoveSelected();
            UpdateRegisterCounters(true);
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e) {
            lstRegisters.LineRemoveSelected();
            UpdateRegisterCounters(true);
        }
        private void WriteRegisters_FormClosing(object sender, FormClosingEventArgs e) {
            lstRegisters.LineRemoveAll();
            manager = null;
        }
        BinaryFormatFlags FormatFlags = BinaryFormatFlags.Length16Bit;
        ByteOrder WordOrder = ByteOrder.LittleEndian;
        DataFormat Format = DataFormat.Decimal;
        DataSize dataSize = DataSize.Bits16;
        DataSize DataSize {
            get {
                return dataSize;
            }
            set {
                dataSize = value;
                Words = EnumManager.DataSizeToInteger(dataSize) / 16;
                if (Words == 0) { Words = 1; }
                SetFlags();
                ClearControls(lstRegisters);
            }
        }
        int Words = 1;
        bool isSigned = false;
        bool IsSigned {
            get { return isSigned; }
            set {
                isSigned = value;
                SetFlags();
                ClearControls(lstRegisters);
                btnSign.Text = isSigned == true ? "Signed" : "Unsigned";
            }
        }
        private void SetFlags() {
            switch (dataSize) {
                case DataSize.Bits8: FormatFlags = BinaryFormatFlags.Length8Bit; break;
                case DataSize.Bits16: FormatFlags = BinaryFormatFlags.Length16Bit; break;
                case DataSize.Bits32: FormatFlags = BinaryFormatFlags.Length32Bit; break;
                case DataSize.Bits64: FormatFlags = BinaryFormatFlags.Length64Bit; break;
                default: return;
            }
            if (isSigned) {
                FormatFlags |= BinaryFormatFlags.Signed;
            }
        }
        private void CmDisplayFormat_Click(object? sender, EventArgs e) {
            object? ButtonData = ModbusEditor.GetContextMenuItemData(sender);
            if (ButtonData == null) { return; }
            if (ButtonData.GetType()! != typeof(ModbusEnums.DataFormat)) { return; }
            Format = (DataFormat)ButtonData;
            if (Format == DataFormat.Float) {
                DataSize = DataSize.Bits32;
            }
            else if (Format == DataFormat.Double) {
                DataSize = DataSize.Bits64;
            }
            else if (Format == DataFormat.Char) {
                DataSize = DataSize.Bits16;
            }
            ddbSize.Text = EnumManager.DataSizeToString(DataSize);
            ddbFormat.Text = EnumManager.DataFormatToString(Format).A;
            lstRegisters.LineRemoveAll();
            ClearControls(lstRegisters);
        }
        private void CmDisplaySize_Click(object? sender, EventArgs e) {
            object? ButtonData = ModbusEditor.GetContextMenuItemData(sender);
            if (ButtonData == null) { return; }
            if (ButtonData.GetType()! != typeof(ModbusEnums.DataSize)) { return; }
            DataSize = (DataSize)ButtonData;
            if (Format == DataFormat.Float) {
                if (DataSize != DataSize.Bits32) { Format = DataFormat.Decimal; }
            }
            else if (Format == DataFormat.Double) {
                if (DataSize != DataSize.Bits64) { Format = DataFormat.Decimal; }
            }
            else if (Format == DataFormat.Char) {
                if (DataSize != DataSize.Bits16) { Format = DataFormat.Decimal; }
            }
            ddbSize.Text = EnumManager.DataSizeToString(DataSize);
            ddbFormat.Text = EnumManager.DataFormatToString(Format).A;
            lstRegisters.LineRemoveAll();
        }
        private void btnSize_Click(object sender, EventArgs e) {
            IsSigned = !IsSigned;
            lstRegisters.LineRemoveAll();
        }
        private void btnAdd_Click(object sender, EventArgs e) {
            Add();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e) {
            Add();
        }

        private void Add() {
            if ((lstRegisters.Items.Count * Words) >= MaxRegisters) { return; }
            ListItem itemBasis = new ListItem();
            ListSubItem ValueItem = new ListSubItem("0");
            ValueItem.Tag = 0;
            itemBasis.SubItems.Add(ValueItem);
            lstRegisters.Items.Add(itemBasis);
            UpdateRegisterCounters(false);
            lstRegisters.Invalidate();
        }
        private void Send() {
            if (manager == null) { return; }
            if (manager.IsMaster == false) { return; }
            if (lstRegisters.Items.Count <= 0) { return; }
            string Query = "UNIT " + numtxtUnit.Value.ToString() + " ";
            Query += "WRITE REGISTERS FROM " + numtxtAddress.Value.ToString() + " WITH ";
            int Items = 0;
            foreach (ListItem Li in lstRegisters.Items) {
                if (Li.SubItems.Count == 1) {
                    long Temp = Classes.Formatters.StringToLong(Li[1].Text, Format, DataSize, IsSigned);
                    AppendData(Temp, ref Query);
                    Query += ",";
                    Items++;
                }
            }
            if (Items <= 0) { return; }
            if (Items > MaxRegisters) { return; }
            Query = Query.TrimEnd(',');
            SystemManager.SendModbusCommand(manager, DataSelection.ModbusDataCoils, Query);

        }
        private void AppendData(long Data, ref string Output) {
            if (DataSize == DataSize.Bits8) {
                short Temp = (short)(0xFF & Data);
                Output += Temp.ToString();
            }
            else if (DataSize == DataSize.Bits16) {
                short Temp = (short)(0xFFFF & Data);
                Output += Temp.ToString();
            }
            else if (DataSize == DataSize.Bits32) {
                if (WordOrder == ByteOrder.BigEndian) {
                    short Temp = (short)(0xFFFF & Data);
                    Output += ShiftData(Data, 0) + "," + ShiftData(Data, 1);
                }
                else if (WordOrder == ByteOrder.LittleEndian) {
                    short Temp = (short)(0xFFFF & Data);
                    Output += ShiftData(Data, 1) + "," + ShiftData(Data, 0);
                }

            }
            else if (DataSize == DataSize.Bits64) {
                if (WordOrder == ByteOrder.BigEndian) {
                    short Temp = (short)(0xFFFF & Data);
                    Output += ShiftData(Data, 0) + "," + ShiftData(Data, 1) + "," + ShiftData(Data, 2) + "," + ShiftData(Data, 3);
                }
                else if (WordOrder == ByteOrder.LittleEndian) {
                    short Temp = (short)(0xFFFF & Data);
                    Output += ShiftData(Data, 3) + "," + ShiftData(Data, 2) + "," + ShiftData(Data, 1) + "," + ShiftData(Data, 0);
                }
            }
        }
        private short ShiftData(long Value, int Shift) {
            return (short)(0XFFFF & (Value >> (Shift * 16)));
        }
        private void lstRegisters_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            if (e.Column == 1) {
                AddValueBox(e, lstRegisters, EdVal_ArrowKeyPress, false);
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

            Components.EditNumber EdVal = new Components.EditNumber(LstCtrl, e.ParentItem, e.Column, e.Item, UseName, Rect, ParRect);
            LstCtrl.Controls.Add(EdVal);
            bool IsFloat = false;
            if (Format == DataFormat.Binary) {
                EdVal.Editor.Base = NumericTextbox.NumberBase.Base2;
            }
            else if (Format == DataFormat.Octal) {
                EdVal.Editor.Base = NumericTextbox.NumberBase.Base8;
            }
            else if (Format == DataFormat.Decimal) {
                EdVal.Editor.Base = NumericTextbox.NumberBase.Base10;
                EdVal.Editor.AllowFractionals = false;
            }
            else if (Format == DataFormat.Hexadecimal) {
                EdVal.Editor.Base = NumericTextbox.NumberBase.Base16;
            }
            else if (Format == DataFormat.Float) {
                EdVal.Editor.Base = NumericTextbox.NumberBase.Base10;
                EdVal.Editor.AllowFractionals = true;
                IsFloat = true;
            }
            else if (Format == DataFormat.Double) {
                EdVal.Editor.Base = NumericTextbox.NumberBase.Base10;
                EdVal.Editor.AllowFractionals = true;
                IsFloat = true;
            }
            if (IsFloat == false) {
                DualNumericalString Range = MathHandler.GetBinaryFormatRange(FormatFlags);
                EdVal.Editor.RangeLimited = true;
                EdVal.Editor.IsMetric = false;
                EdVal.Editor.Minimum = Range.A;
                EdVal.Editor.Maximum = Range.B;
            }

            EdVal.Editor.Value = e.ParentItem[e.Column].Text;
            EdVal.ArrowKeyPress += arrowKeyPressed;
            EdVal.Focus();
            EdVal.Show();
        }
        private void EdVal_ArrowKeyPress(ControlEnums.ArrowKey Direction) {
            if (Direction == ControlEnums.ArrowKey.Up) {

            }
        }
        public void ClearControls(ODModules.ListControl LstCtrl) {
            LstCtrl.Controls.Clear();
        }
        private void UpdateRegisterCounters(bool Redraw = true) {
            int Count = 0; int.TryParse(numtxtAddress.Value.ToString(), out Count);
            foreach (ListItem Li in lstRegisters.Items) {
                Li.Text = Count.ToString();
                Count += Words;
            }
            if (Redraw == false) { return; }
            lstRegisters.Invalidate();
        }
        private void numtxtAddress_ValueChanged(object sender, ValueChangedEventArgs e) {
            UpdateRegisterCounters(true);
        }
    }
}
