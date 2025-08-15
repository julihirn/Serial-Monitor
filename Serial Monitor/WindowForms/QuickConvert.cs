using ODModules;
using Serial_Monitor.Classes.Enums;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Theming;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.Enums.ModbusEnums;
using Serial_Monitor.Classes.Structures;
using Serial_Monitor.Classes.Modbus;
using Handlers;
using ListControl = ODModules.ListControl;

namespace Serial_Monitor.WindowForms {
    public partial class QuickConvert : Components.SkinnedForm, Interfaces.ITheme, Interfaces.Application.IGenerics {
        public QuickConvert() {
            InitializeComponent();
            PopulateFormats();
        }

        private void QuickConvert_Load(object sender, EventArgs e) {
            RecolorAll();

        }
        public void ApplyTheme() {
            RecolorAll();
        }
        private void RecolorAll() {
            BackColor = Properties.Settings.Default.THM_COL_Editor;

            TitleBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            TitleForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            InactiveBorderColor = Properties.Settings.Default.THM_COL_MenuBack;
            ActiveBorderColor = Properties.Settings.Default.THM_COL_SelectedColor;
            ThemeManager.ThemeControl(lstConverter);
            ThemeManager.ThemeControl(msMain);
        }
        bool TopMostState = false;
        public void SetTopMost(bool State) {
            TopMostState = State;
            //topMostToolStripMenuItem.Checked = TopMostState;
            this.TopMost = State;
        }
        private void PopulateFormats() {
            CreateFormatItem(DataFormat.Binary, DataSize.Bits32, true);
            CreateFormatItem(DataFormat.Octal, DataSize.Bits32, true);
            CreateFormatItem(DataFormat.Decimal, DataSize.Bits32, true);
            CreateFormatItem(DataFormat.Hexadecimal, DataSize.Bits32, false);
            CreateFormatItem(DataFormat.Float, DataSize.Bits32, true);
            CreateFormatItem(DataFormat.Double, DataSize.Bits32, true);
            lstConverter.Invalidate();
        }
        private void CreateFormatItem(DataFormat Format, DataSize DSize, bool IsSigned) {
            ListItem Li = new ListItem(EnumManager.DataFormatToString(Format).A);
            Li.Checked = false;
            ListSubItem LisValue = new ListSubItem("0");
            Li.SubItems.Add(LisValue);
            Li.Tag = new ModbusFormat(Format, DSize, IsSigned, EnumManager.DataFormatSupportsSize(Format));
            lstConverter.Items.Add(Li);
        }
        private void PopulateFormatEditor() {
            DataFormat[] Formats = (DataFormat[])DataFormat.GetValues(typeof(DataFormat));
            foreach (ModbusEnums.DataFormat Frmt in Formats) {
                bool CanSign = EnumManager.DataFormatSupportsSign(Frmt);
                bool CanSize = EnumManager.DataFormatSupportsSize(Frmt);

            }
        }

        private void lstConverter_SelectionChanged(object sender, SelectedItemsEventArgs e) {

        }

        private void lstConverter_CellSelected(object sender, CellSelectedEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            // if (LstItem.SubItems.Count < 8) { return; }
            ModbusEditor.RemoveAllControls(lstConverter);
        }

        private void lstConverter_KeyPress(object sender, KeyPressEventArgs e) {
            if ((e.KeyChar == ' ') || (e.KeyChar == '\r')) {
                lstConverter.SelectDropForward(0, 0, true);
            }
        }

        private void lstConverter_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (LstItem.SubItems.Count < 0) { return; }
            if (e.Column == 1) {
                if (DataTag.GetType() == typeof(ModbusFormat)) {
                    AddValueBox(e, lstConverter, e.Data);
                }
            }
            lstConverter.Invalidate();
        }
        public void AddValueBox(DropDownClickedEventArgs e, ODModules.ListControl LstCtrl, string? DataToPush, bool UseItemIndex = false) {
            ListItem? LstItem = e.ParentItem;
            //LastPoint = new Point(e.Column, e.Item);
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.ParentItem == null) { return; }
            if (e.ParentItem.SubItems == null) { return; }
            int ItemIndex = e.Item;
            string ItemText = e.ParentItem[1].Text;
            if (DataTag.GetType() == typeof(ModbusFormat)) {
                ModbusFormat reg = (ModbusFormat)DataTag;
                ODModules.NumericTextbox Tb = new ODModules.NumericTextbox();
                Tb.BackColor = LstCtrl.BackColor;
                Tb.Font = LstCtrl.Font;
                Tb.AutoSize = false;
                Tb.ShowLabel = false;
                Tb.ForeColor = LstCtrl.ForeColor;
                Tb.FixedNumericPadding = 6;
                Tb.UseFixedNumericPadding = false;
                Tb.SelectedBorderColor = LstCtrl.CellSelectionBorderColor;
                Tb.RangeLimited = true;
                SetNumericTextBox(Tb, reg, ItemText);
                Tb.ArrowKeysControlNumber = false;
                Tb.Tag = DataTag;
                Tb.SecondaryTag = ItemIndex;

                //Components.EditValue EdVal = new Components.EditValue(Pm.Name, LstCtrl, e.ParentItem, Indx_Name, ItemIndex, null, coil, Rect, ParRect, DataSet);
                LstCtrl.AddControlToCell(Tb);

                Tb.Focus();
                //EdVal.ArrowKeyPress += arrowKeyPressed;
                Tb.Leave += Tb_LostFocus;
                Tb.KeyPress += Tb_KeyPress;
                Tb.EnterPressed += Tb_EnterPressed;
                Tb.ValueChanged += Tb_ValueChanged;
                if (DataToPush != null) {
                    for (int i = 0; i < DataToPush.Length; i++) {
                        Tb.PushCharacter(DataToPush[i]);
                    }
                }
            }
        }
        private void SetNumericTextBox(NumericTextbox? Ntb, ModbusFormat Frmt, string InputValue) {
            if (Ntb == null) { return; }
            if (Frmt.Format == Classes.Enums.ModbusEnums.DataFormat.Binary) {
                Ntb.Base = NumericTextbox.NumberBase.Base2;
                DualNumericalString DualNum = Formatters.GetBounds(Frmt.Size, Frmt.Signed);
                Ntb.Minimum = DualNum.A;
                Ntb.Maximum = DualNum.B;
                InputValue = InputValue.TrimStart('0').Replace(" ", "");
            }
            else if (Frmt.Format == Classes.Enums.ModbusEnums.DataFormat.Octal) {
                Ntb.Base = NumericTextbox.NumberBase.Base8;
                DualNumericalString DualNum = Formatters.GetBounds(Frmt.Size, Frmt.Signed);
                Ntb.Minimum = DualNum.A;
                Ntb.Maximum = DualNum.B;
                InputValue = InputValue.TrimStart('0');
            }
            else if (Frmt.Format == Classes.Enums.ModbusEnums.DataFormat.Decimal) {
                Ntb.Base = NumericTextbox.NumberBase.Base10;
                Ntb.AllowFractionals = false;
                Ntb.AllowNegatives = Frmt.Signed;
                DualNumericalString DualNum = Formatters.GetBounds(Frmt.Size, Frmt.Signed);
                Ntb.Minimum = DualNum.A;
                Ntb.Maximum = DualNum.B;
                Ntb.HasUnit = false;
            }
            else if (Frmt.Format == Classes.Enums.ModbusEnums.DataFormat.Hexadecimal) {
                Ntb.Base = NumericTextbox.NumberBase.Base16;
                DualNumericalString DualNum = Formatters.GetBounds(Frmt.Size, Frmt.Signed);
                Ntb.Minimum = DualNum.A;
                Ntb.Maximum = DualNum.B;
                InputValue = InputValue.TrimStart('0');
                Ntb.HasUnit = false;
            }
            else if (Frmt.Format == Classes.Enums.ModbusEnums.DataFormat.Double) {
                Ntb.AllowFractionals = true;
                Ntb.AllowNegatives = true;
                Ntb.Minimum = MathHandler.EvaluateExpression("-1.7976931348623157*(10^(308))", null);
                Ntb.Maximum = MathHandler.EvaluateExpression("1.7976931348623157*(10^(308))", null);
                Ntb.NumericalFormat = NumericTextbox.NumberFormat.Scientific;
                Ntb.HasUnit = false;

                if (InputValue.ToLower() == "nan") {
                    InputValue = "0";
                }
                else if (InputValue.ToLower() == "infinity") {
                    InputValue = double.MaxValue.ToString();
                }
                else if (InputValue.ToLower() == "-infinity") {
                    InputValue = double.MinValue.ToString();
                }
                if (InputValue.Contains('E')) {
                    InputValue = MathHandler.EvaluateExpression(InputValue.Replace("E", "*(10^(") + "))", null).ToString();
                }
            }
            else if (Frmt.Format == Classes.Enums.ModbusEnums.DataFormat.Float) {
                Ntb.AllowFractionals = true;
                Ntb.AllowNegatives = true;
                Ntb.Minimum = MathHandler.EvaluateExpression("-3.4028235*(10^(38))", null);
                Ntb.Maximum = MathHandler.EvaluateExpression("3.4028235*(10^(38))", null);
                Ntb.NumericalFormat = NumericTextbox.NumberFormat.Scientific;
                if (InputValue.ToLower() == "nan") {
                    InputValue = "0";
                }
                else if (InputValue.ToLower() == "infinity") {
                    InputValue = float.MaxValue.ToString();
                }
                else if (InputValue.ToLower() == "-infinity") {
                    InputValue = float.MinValue.ToString();
                }
                if (InputValue.Contains('E')) {
                    InputValue = MathHandler.EvaluateExpression(InputValue.Replace("E", "*(10^(") + "))", null).ToString();
                }
                Ntb.HasUnit = false;

            }
            else if (Frmt.Format == Classes.Enums.ModbusEnums.DataFormat.Char) {

            }
            if (InputValue.Length > 0) {
                Ntb.Value = InputValue;
            }
            else { Ntb.Value = 0; }
        }
        private void ConvertAll(int Index) {
            if (lstConverter.CurrentItems.Count == 0) { return; }
            if ((Index < 0)||(Index > lstConverter.CurrentItems.Count)) { return; }
            int i = -1;
            string PeggedData = lstConverter.CurrentItems[Index][1].Text;
            object? TempPegged = lstConverter.CurrentItems[Index].Tag;
            if (TempPegged == null) { return; }
            if (TempPegged.GetType() != typeof(ModbusFormat)) { return; }
            ModbusFormat PeggedFormat = (ModbusFormat)TempPegged;
            foreach (ListItem Li in lstConverter.CurrentItems) {
                ++i;
                if (Li.Tag == null) { continue; }
                object Temp = Li.Tag;
                if (Temp.GetType() != typeof(ModbusFormat)) { continue; }
                ModbusFormat Format = (ModbusFormat)Temp;
                if (i != Index) {
                    Li[1].Text = Formatters.StringFormattedToStringFormatted(PeggedData, PeggedFormat, Format);
                }
            }
        }
        private void Tb_ValueChanged(object sender, ValueChangedEventArgs e) {
            if (sender.GetType() != typeof(NumericTextbox)) { return; }
            NumericTextbox Ttb = (NumericTextbox)sender;
            object? Tag = Ttb.Tag;
            if (Tag == null) { return; }
            if (Tag.GetType() != typeof(ModbusFormat)) { return; }
            ModbusFormat? pd = (ModbusFormat)Tag;
            if (pd == null) { return; }
            if (Ttb.SecondaryTag == null) { return; }
            if (Ttb.SecondaryTag.GetType() != typeof(int)) { return; }
            int Index = (int)Ttb.SecondaryTag;
            try {
                lstConverter.Items[Index][1].Text = Ttb.Value.ToString() ?? "0";
            }
            catch { }
            ConvertAll(Index);
            lstConverter.Invalidate();
        }
        public void RemoveAllControls(ODModules.ListControl LstCtrl) {
            for (int i = LstCtrl.Controls.Count - 1; i >= 0; i--) {
                RemoveControl(LstCtrl.Controls[i]);
            }
        }
        private void Tb_EnterPressed(NumericTextbox sender) {
            RemoveControl(sender);
        }
        private void Tb_KeyPress(object? sender, KeyPressEventArgs e) {
            if (e.KeyChar == ' ') {
                RemoveControl(sender);
            }
        }
        private void RemoveControl(object? sender) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(ODModules.TextBox)) {
                ODModules.TextBox OdTb = (ODModules.TextBox)sender;
                OdTb.LostFocus -= Tb_LostFocus;
                if (OdTb.Parent == null) { return; }
                OdTb.Parent.Controls.Remove(OdTb);
            }
            else if (sender.GetType() == typeof(ODModules.NumericTextbox)) {
                ODModules.NumericTextbox OdTb = (ODModules.NumericTextbox)sender;
                OdTb.LostFocus -= Tb_LostFocus;
                //OdTb.EnterPressed -= Tb_EnterPressed;
                OdTb.ValueChanged -= Tb_ValueChanged;
                if (OdTb.Parent == null) { return; }
                OdTb.Parent.Controls.Remove(OdTb);
            }
        }
        private void Tb_LostFocus(object? sender, EventArgs e) {
            RemoveControl(sender);
        }
        public void ClearControls(ListControl LstCtrl) {
            LstCtrl.Controls.Clear();
            // GC.Collect();
            Thread Tr = new Thread(PurgeData);
            Tr.IsBackground = true;
            Tr.Start();
        }
        static DateTime PreviousInstance = DateTime.MinValue;
        private void PurgeData() {
            if (ConversionHandler.DateIntervalDifference(PreviousInstance, DateTime.UtcNow, ConversionHandler.Interval.Millisecond) >= 1000) {
                GC.Collect();
                PreviousInstance = DateTime.UtcNow;
            }
        }
    }
}
