using Enum.Extensions;
using Handlers;
using Microsoft.Win32;
using ODModules;
using Serial_Monitor.Classes.Enums;
using Serial_Monitor.Classes.Step_Programs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.Enums.FormatEnums;
using static Serial_Monitor.Classes.Enums.ModbusEnums;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ListControl = ODModules.ListControl;

namespace Serial_Monitor.Classes.Modbus {
    public static class ModbusEditor {
        public const int Indx_Name = 1;
        public const int Indx_Display = 2;
        public const int Indx_Size = 3;
        public const int Indx_Signed = 4;
        public const int Indx_Value = 5;
        public const int Indx_LastUpdated = 6;

        public static event ViewUpdatedHandler? ViewUpdated;
        public delegate void ViewUpdatedHandler(ListControl LstControl);

        public static event EditorPropertiesEqualHandler? EditorPropertiesEqual;
        public delegate void EditorPropertiesEqualHandler(ListControl? LstControl, ModbusPropertyFlags EqualProperties, ModbusProperty CurrentProperties, bool ItemsSelected);

        public static Size MinimumSize = new Size(464, 213);
        #region Loaders
        static bool IsFirstLoad = true;
        static bool RefreshThreadRunning = false;
        public static List<ListItem> MasterRegisterEditor = new List<ListItem>();
        public static void LoadRegisters(ListControl LstControl, SerialManager? CurrentManager, DataSelection DataSet, int SlaveIndex) {
            Thread Tr = new Thread(() => LoadRegistersThreaded(LstControl, CurrentManager, DataSet, SlaveIndex));
            Tr.IsBackground = true;
            Tr.Name = "Tr_RegisterLoader";
            Tr.Start();
        }
        private static void LoadRegistersThreaded(ListControl LstControl, SerialManager? CurrentManager, DataSelection DataSet, int SlaveIndex) {
            if (RefreshThreadRunning == true) { return; }
            if (CurrentManager == null) { return; }
            if (CurrentManager.Registers == null) { return; }
            if (SlaveIndex >= CurrentManager.Slave.Count) { return; }
            RefreshThreadRunning = true;
            if (SlaveIndex < 0) {
                int i = 0;
                if (DataSet == DataSelection.ModbusDataCoils) {
                    foreach (ModbusCoil Coil in CurrentManager.Registers.Coils) {
                        AddMonitorItem(Coil, i, CurrentManager.Registers.AddressFormat, DataSet); i++;
                    }
                }
                else if (DataSet == DataSelection.ModbusDataDiscreteInputs) {
                    foreach (ModbusCoil Coil in CurrentManager.Registers.DiscreteInputs) {
                        AddMonitorItem(Coil, i, CurrentManager.Registers.AddressFormat, DataSet); i++;
                    }
                }
                else if (DataSet == DataSelection.ModbusDataInputRegisters) {
                    foreach (ModbusRegister Coil in CurrentManager.Registers.InputRegisters) {
                        AddMonitorItem(Coil, i, CurrentManager.Registers.AddressFormat, DataSet); i++;
                    }
                }
                else if (DataSet == DataSelection.ModbusDataHoldingRegisters) {
                    foreach (ModbusRegister Coil in CurrentManager.Registers.HoldingRegisters) {
                        AddMonitorItem(Coil, i, CurrentManager.Registers.AddressFormat, DataSet); i++;
                    }
                }
            }
            else {
                int i = 0;
                if (DataSet == DataSelection.ModbusDataCoils) {
                    foreach (ModbusCoil Coil in CurrentManager.Slave[SlaveIndex].Coils) {
                        AddMonitorItem(Coil, i, CurrentManager.Slave[SlaveIndex].AddressFormat, DataSet);
                        i++;
                    }
                }
                else if (DataSet == DataSelection.ModbusDataDiscreteInputs) {
                    foreach (ModbusCoil Coil in CurrentManager.Slave[SlaveIndex].DiscreteInputs) {
                        AddMonitorItem(Coil, i, CurrentManager.Slave[SlaveIndex].AddressFormat, DataSet);
                        i++;
                    }
                }
                else if (DataSet == DataSelection.ModbusDataInputRegisters) {
                    foreach (ModbusRegister Coil in CurrentManager.Slave[SlaveIndex].InputRegisters) {
                        AddMonitorItem(Coil, i, CurrentManager.Slave[SlaveIndex].AddressFormat, DataSet);
                        i++;
                    }
                }
                else if (DataSet == DataSelection.ModbusDataHoldingRegisters) {
                    foreach (ModbusRegister Coil in CurrentManager.Slave[SlaveIndex].HoldingRegisters) {
                        AddMonitorItem(Coil, i, CurrentManager.Slave[SlaveIndex].AddressFormat, DataSet);
                        i++;
                    }
                }
            }
            IsFirstLoad = false;
            //LstControl.Invoke(new MethodInvoker(delegate {
            RefreshThreadRunning = false;
            //}));
            //LstControl.Invalidate();
            ViewUpdate(LstControl);
        }
        public static void ViewUpdate(ListControl LstControl) {
            ViewUpdated?.Invoke(LstControl);
        }
        private static void AddMonitorItem(ModbusCoil Coil, int Index, AddressSystem AddressFormat, DataSelection DataSet) {
            if (IsFirstLoad) {
                ListItem PLi = new ListItem();
                PLi.Tag = Coil;
                PLi.Value = Index;
                PLi.UseLineBackColor = Coil.UseBackColor;
                PLi.UseLineForeColor = Coil.UseForeColor;
                PLi.LineBackColor = Coil.BackColor;
                PLi.LineForeColor = Coil.ForeColor;
                ApplyAddressSystemToItem(PLi, Index, AddressFormat, DataSet);
                ListSubItem CLi1 = new ListSubItem(Coil.Name);
                ListSubItem CLi2 = new ListSubItem(EnumManager.CoilFormatToString(Coil.Format).A);
                ListSubItem CLi3 = new ListSubItem();
                ListSubItem CLi4 = new ListSubItem();
                ListSubItem CLi5 = new ListSubItem(Coil.ValueWithUnit);
                ListSubItem CLi6 = new ListSubItem(Coil.GetLastUpdatedTime());
                PLi.SubItems.Add(CLi1);
                PLi.SubItems.Add(CLi2);
                PLi.SubItems.Add(CLi3);
                PLi.SubItems.Add(CLi4);
                PLi.SubItems.Add(CLi5);
                PLi.SubItems.Add(CLi6);
                MasterRegisterEditor.Add(PLi);
            }
            else {
                MasterRegisterEditor[Index].Tag = null;
                MasterRegisterEditor[Index].Tag = Coil;
                MasterRegisterEditor[Index].UseLineBackColor = Coil.UseBackColor;
                MasterRegisterEditor[Index].UseLineForeColor = Coil.UseForeColor;
                MasterRegisterEditor[Index].LineBackColor = Coil.BackColor;
                MasterRegisterEditor[Index].LineForeColor = Coil.ForeColor;
                ApplyAddressSystemToItem(MasterRegisterEditor[Index], Index, AddressFormat, DataSet);
                MasterRegisterEditor[Index][Indx_Name].Text = Coil.Name;
                MasterRegisterEditor[Index][Indx_Display].Text = EnumManager.CoilFormatToString(Coil.Format).A;
                MasterRegisterEditor[Index][Indx_Size].Text = "";
                MasterRegisterEditor[Index][Indx_Signed].Text = "";
                MasterRegisterEditor[Index][Indx_Value].Text = Coil.ValueWithUnit;
                MasterRegisterEditor[Index][Indx_LastUpdated].Text = Coil.GetLastUpdatedTime();
            }
        }
        private static void AddMonitorItem(ModbusRegister Register, int Index, AddressSystem AddressFormat, DataSelection DataSet) {
            if (IsFirstLoad) {
                ListItem PLi = new ListItem();
                PLi.Tag = Register;
                PLi.Value = Index;
                PLi.UseLineBackColor = Register.UseBackColor;
                PLi.UseLineForeColor = Register.UseForeColor;
                PLi.LineBackColor = Register.BackColor;
                PLi.LineForeColor = Register.ForeColor;
                ApplyAddressSystemToItem(PLi, Index, AddressFormat, DataSet);
                ListSubItem CLi1 = new ListSubItem(Register.Name);
                ListSubItem CLi2 = new ListSubItem(EnumManager.DataFormatToString(Register.Format).A);
                ListSubItem CLi3 = new ListSubItem(EnumManager.DataSizeToString(Register.Size));
                ListSubItem CLi4 = new ListSubItem(Register.Signed);
                ListSubItem CLi5 = new ListSubItem(Register.ValueWithUnit);
                ListSubItem CLi6 = new ListSubItem(Register.GetLastUpdatedTime());
                PLi.SubItems.Add(CLi1);
                PLi.SubItems.Add(CLi2);
                PLi.SubItems.Add(CLi3);
                PLi.SubItems.Add(CLi4);
                PLi.SubItems.Add(CLi5);
                PLi.SubItems.Add(CLi6);
                MasterRegisterEditor.Add(PLi);
            }
            else {
                MasterRegisterEditor[Index].Tag = null;
                MasterRegisterEditor[Index].Tag = Register;
                MasterRegisterEditor[Index].UseLineBackColor = Register.UseBackColor;
                MasterRegisterEditor[Index].UseLineForeColor = Register.UseForeColor;
                MasterRegisterEditor[Index].LineBackColor = Register.BackColor;
                MasterRegisterEditor[Index].LineForeColor = Register.ForeColor;
                ApplyAddressSystemToItem(MasterRegisterEditor[Index], Index, AddressFormat, DataSet);
                MasterRegisterEditor[Index][Indx_Name].Text = Register.Name;
                MasterRegisterEditor[Index][Indx_Display].Text = EnumManager.DataFormatToString(Register.Format).A;
                MasterRegisterEditor[Index][Indx_Size].Text = EnumManager.DataSizeToString(Register.Size);
                MasterRegisterEditor[Index][Indx_Signed].Checked = Register.Signed;
                MasterRegisterEditor[Index][Indx_Value].Text = Register.ValueWithUnit;
                MasterRegisterEditor[Index][Indx_LastUpdated].Text = Register.GetLastUpdatedTime();
            }
        }
        private static void ApplyAddressSystemToItem(ListItem Li, int Address, AddressSystem AddressFormat, DataSelection Selection) {
            int Offset = 0;
            switch (AddressFormat) {
                case AddressSystem.ZeroBasedDecimal:
                    Li.Text = Address.ToString();
                    return;
                case AddressSystem.OneBasedDecimal:
                    Li.Text = (Address + 1).ToString();
                    return;
                case AddressSystem.ZeroBasedHexadecimal:
                    Offset = 0;
                    break;
                case AddressSystem.OneBasedHexadecimal:
                    Offset = 1;
                    break;
                case AddressSystem.PLCAddress:
                    Offset = 1;
                    break;
                default:
                    break;
            }
            if (((int)AddressFormat & 0x100) == 0x100) {
                int i = Offset + Address;
                if ((AddressFormat == AddressSystem.ZeroBasedHexadecimal) || (AddressFormat == AddressSystem.OneBasedHexadecimal)) {
                    Li.Text = Formatters.Integer16ToHex(i);
                }
                else if (AddressFormat == AddressSystem.PLCAddress) {
                    Li.Text = Formatters.PLCAddress(i, Selection);
                }
            }
        }
        public static void RemoveReferences() {
            foreach (ListItem Li in MasterRegisterEditor) {
                Li.Tag = null;
            }
        }
        #endregion 
        #region Editors
        public static void AddRenameBox(DropDownClickedEventArgs e, ListControl LstCtrl, DataSelection DataSet, Components.EditValue.ArrowKeyPressedHandler arrowKeyPressed, bool UseItemIndex = false) {
            ListItem? LstItem = e.ParentItem;
            //LastPoint = new Point(e.Column, e.Item);
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.ParentItem == null) { return; }
            if (e.ParentItem.SubItems == null) { return; }
            int ItemIndex = e.Item;
            if (UseItemIndex == true) {
                ItemIndex = e.ParentItem.Value;
            }
            if (DataTag.GetType() == typeof(ModbusCoil)) {
                ModbusCoil coil = (ModbusCoil)DataTag;
                Rectangle Rect = new Rectangle(e.Location, e.ItemSize);
                Rectangle ParRect = new Rectangle(e.ScreenLocation, e.ItemSize);
                Components.EditValue EdVal = new Components.EditValue(coil.Name, LstCtrl, e.ParentItem, Indx_Name, ItemIndex, null, coil, Rect, ParRect, DataSet);
                LstCtrl.Controls.Add(EdVal);
                EdVal.ArrowKeyPress += arrowKeyPressed;
                EdVal.Focus();
                EdVal.Show();
            }
            else if (DataTag.GetType() == typeof(ModbusRegister)) {
                ModbusRegister reg = (ModbusRegister)DataTag;
                Rectangle Rect = new Rectangle(e.Location, e.ItemSize);
                Rectangle ParRect = new Rectangle(e.ScreenLocation, e.ItemSize);
                Components.EditValue EdVal = new Components.EditValue(reg.Name, LstCtrl, e.ParentItem, Indx_Name, ItemIndex, null, reg, Rect, ParRect, DataSet);
                LstCtrl.Controls.Add(EdVal);
                EdVal.ArrowKeyPress += arrowKeyPressed;
                EdVal.Focus();
                EdVal.Show();
            }
        }
        public static void AddTextBox(DropDownClickedEventArgs e, ListControl LstCtrl, DataSelection DataSet, Components.EditValue.ArrowKeyPressedHandler arrowKeyPressed, string? DataToPush, bool UseItemIndex = false) {
            ListItem? LstItem = e.ParentItem;
            //LastPoint = new Point(e.Column, e.Item);
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.ParentItem == null) { return; }
            if (e.ParentItem.SubItems == null) { return; }
            int ItemIndex = e.Item;
            if (UseItemIndex == false) {
                ItemIndex = e.ParentItem.Value;
            }
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
            Tb.MaskArrowKeyEvents = true;
            if (DataTag.GetType() == typeof(ModbusRegister)) {
                ModbusRegister reg = (ModbusRegister)DataTag;
                Tb.Text = reg.Name;
                Tb.Tag = new ModbusRegisterEdit(reg, Indx_Name, LstItem, DataSet);
            }
            else if (DataTag.GetType() == typeof(ModbusCoil)) {
                ModbusCoil reg = (ModbusCoil)DataTag;
                Tb.Text = reg.Name;
                Tb.Tag = new ModbusCoilEdit(reg, Indx_Name, LstItem, DataSet);
            }
            LstCtrl.AddControlToCell(Tb);
            Tb.Focus();
            //EdVal.ArrowKeyPress += arrowKeyPressed;
            Tb.Leave += Tb_LostFocus;
            //Tb.KeyPress += Tb_KeyPress;
            SystemManager.InvokeModbusEditorChanged();
            Tb.EnterPressed += Tb_EnterPressed;
            Tb.TextChanged += Tb_TextChanged;
            if (DataToPush != null) {
                if ((DataToPush.Length == 1) && (DataToPush[0] == '\b')) {
                    Tb.RemoveLastCharacter();
                }
                else { 
                    Tb.AppendText(DataToPush);
                }
            }
        }


        private static void Tb_EnterPressed(SingleLineTextBox sender) {
            RemoveControl(sender);
        }
        public static void AddValueBox(DropDownClickedEventArgs e, ListControl LstCtrl, DataSelection DataSet, Components.EditValue.ArrowKeyPressedHandler arrowKeyPressed, string? DataToPush, bool UseItemIndex = false) {
            ListItem? LstItem = e.ParentItem;
            //LastPoint = new Point(e.Column, e.Item);
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.ParentItem == null) { return; }
            if (e.ParentItem.SubItems == null) { return; }
            int ItemIndex = e.Item;
            if (UseItemIndex == false) {
                ItemIndex = e.ParentItem.Value;
            }
            if (DataTag.GetType() == typeof(ModbusRegister)) {
                ModbusRegister reg = (ModbusRegister)DataTag;
                //Rectangle Rect = new Rectangle(e.Location, e.ItemSize);
                //Rectangle ParRect = new Rectangle(e.ScreenLocation, e.ItemSize);
                //Components.EditValue EdVal = new Components.EditValue(reg.FormattedValue, LstCtrl, e.ParentItem, Indx_Value, ItemIndex, reg, Rect, ParRect, DataSet);
                //LstCtrl.Controls.Add(EdVal);
                //
                //EdVal.ArrowKeyPress += arrowKeyPressed;
                //EdVal.Focus();
                //EdVal.Show();
                ODModules.NumericTextbox Tb = new ODModules.NumericTextbox();
                Tb.BackColor = LstCtrl.BackColor;
                Tb.Font = LstCtrl.Font;
                Tb.AutoSize = false;
                Tb.ShowLabel = false;
                Tb.ForeColor = LstCtrl.ForeColor;
                Tb.FixedNumericPadding = 6;
                Tb.UseFixedNumericPadding = false;
                Tb.SelectedBorderColor = LstCtrl.CellSelectionBorderColor;
                Tb.Value = reg.FormattedValue;

                Tb.RangeLimited = true;
                SetNumericTextBox(Tb, reg);
                Tb.ArrowKeysControlNumber = false;
                Tb.Tag = new ModbusRegisterEdit(reg, Indx_Value, LstItem, DataSet);

                //Components.EditValue EdVal = new Components.EditValue(Pm.Name, LstCtrl, e.ParentItem, Indx_Name, ItemIndex, null, coil, Rect, ParRect, DataSet);
                LstCtrl.AddControlToCell(Tb);

                Tb.Focus();
                //EdVal.ArrowKeyPress += arrowKeyPressed;
                Tb.Leave += Tb_LostFocus;
                Tb.KeyPress += Tb_KeyPress;
                Tb.EnterPressed += Nb_EnterPressed;
                Tb.ValueChanged += Tb_ValueChanged;
                SystemManager.InvokeModbusEditorChanged();
                if (DataToPush != null) {
                    for (int i = 0; i < DataToPush.Length; i++) {
                        Tb.PushCharacter(DataToPush[i]);
                    }
                }
            }
        }
        internal static void SetNumericTextBox(NumericTextbox? Ntb, string? Value, DataSize size, DataFormat frmt, bool Signed) {
            if (Value == null) { return; }
            if (Ntb == null) { return; }
            string InputValue = Value;
            if (frmt == Classes.Enums.ModbusEnums.DataFormat.Binary) {
                Ntb.Base = NumericTextbox.NumberBase.Base2;
                DualNumericalString DualNum = Formatters.GetBounds(size, Signed);
                Ntb.Minimum = DualNum.A;
                Ntb.Maximum = DualNum.B;
                InputValue = InputValue.TrimStart('0').Replace(" ", "");
            }
            else if (frmt == Classes.Enums.ModbusEnums.DataFormat.Octal) {
                Ntb.Base = NumericTextbox.NumberBase.Base8;
                DualNumericalString DualNum = Formatters.GetBounds(size, Signed);
                Ntb.Minimum = DualNum.A;
                Ntb.Maximum = DualNum.B;
                InputValue = InputValue.TrimStart('0');
            }
            else if (frmt == Classes.Enums.ModbusEnums.DataFormat.Decimal) {
                Ntb.Base = NumericTextbox.NumberBase.Base10;
                Ntb.AllowFractionals = false;
                Ntb.AllowNegatives = Signed;
                DualNumericalString DualNum = Formatters.GetBounds(size, Signed);
                Ntb.Minimum = DualNum.A;
                Ntb.Maximum = DualNum.B;
            }
            else if (frmt == Classes.Enums.ModbusEnums.DataFormat.Hexadecimal) {
                Ntb.Base = NumericTextbox.NumberBase.Base16;
                DualNumericalString DualNum = Formatters.GetBounds(size, Signed);
                Ntb.Minimum = DualNum.A;
                Ntb.Maximum = DualNum.B;
                InputValue = InputValue.TrimStart('0');
            }
            else if (frmt == Classes.Enums.ModbusEnums.DataFormat.Double) {
                Ntb.AllowFractionals = true;
                Ntb.AllowNegatives = true;
                Ntb.Minimum = MathHandler.EvaluateExpression("-1.7976931348623157*(10^(308))", null);
                Ntb.Maximum = MathHandler.EvaluateExpression("1.7976931348623157*(10^(308))", null);
                Ntb.NumericalFormat = NumericTextbox.NumberFormat.Scientific;

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
            else if (frmt == Classes.Enums.ModbusEnums.DataFormat.Float) {
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
                //Ntb.Unit = Reg.Unit;
                //Ntb.Prefix = EnumManager.GetPrefix(Reg);
                Ntb.Prefix = NumericTextbox.MetricPrefix.None;
                Ntb.Unit = "";
            }
            else if (frmt == Classes.Enums.ModbusEnums.DataFormat.Char) {

            }
            if (InputValue.Length > 0) {
                Ntb.Value = InputValue;
            }
            else { Ntb.Value = 0; }
        }
        private static void SetNumericTextBox(NumericTextbox? Ntb, ModbusRegister? Reg) {
            if (Reg == null) { return; }
            if (Ntb == null) { return; }
            string InputValue = Reg.FormattedValue;
            if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Binary) {
                Ntb.Base = NumericTextbox.NumberBase.Base2;
                DualNumericalString DualNum = Formatters.GetBounds(Reg.Size, Reg.Signed);
                Ntb.Minimum = DualNum.A;
                Ntb.Maximum = DualNum.B;
                InputValue = InputValue.TrimStart('0').Replace(" ", "");
            }
            else if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Octal) {
                Ntb.Base = NumericTextbox.NumberBase.Base8;
                DualNumericalString DualNum = Formatters.GetBounds(Reg.Size, Reg.Signed);
                Ntb.Minimum = DualNum.A;
                Ntb.Maximum = DualNum.B;
                InputValue = InputValue.TrimStart('0');
            }
            else if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Decimal) {
                Ntb.Base = NumericTextbox.NumberBase.Base10;
                Ntb.AllowFractionals = false;
                Ntb.AllowNegatives = Reg.Signed;
                DualNumericalString DualNum = Formatters.GetBounds(Reg.Size, Reg.Signed);
                Ntb.Minimum = DualNum.A;
                Ntb.Maximum = DualNum.B;
                Ntb.Unit = Reg.Unit;
                Ntb.Prefix = EnumManager.GetPrefix(Reg);
            }
            else if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Hexadecimal) {
                Ntb.Base = NumericTextbox.NumberBase.Base16;
                DualNumericalString DualNum = Formatters.GetBounds(Reg.Size, Reg.Signed);
                Ntb.Minimum = DualNum.A;
                Ntb.Maximum = DualNum.B;
                InputValue = InputValue.TrimStart('0');
            }
            else if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Double) {
                Ntb.AllowFractionals = true;
                Ntb.AllowNegatives = true;
                Ntb.Minimum = MathHandler.EvaluateExpression("-1.7976931348623157*(10^(308))", null);
                Ntb.Maximum = MathHandler.EvaluateExpression("1.7976931348623157*(10^(308))", null);
                Ntb.NumericalFormat = NumericTextbox.NumberFormat.Scientific;
                Ntb.Unit = Reg.Unit;
                Ntb.Prefix = EnumManager.GetPrefix(Reg);

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
            else if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Float) {
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
                Ntb.Unit = Reg.Unit;
                Ntb.Prefix = EnumManager.GetPrefix(Reg);

            }
            else if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Char) {

            }
            if (InputValue.Length > 0) {
                Ntb.Value = InputValue;
            }
            else { Ntb.Value = 0; }
        }
        private static void Tb_TextChanged(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() != typeof(SingleLineTextBox)) { return; }
            SingleLineTextBox Ttb = (SingleLineTextBox)sender;
            object? Tag = Ttb.Tag;
            if (Tag == null) { return; }
            if (Tag.GetType() == typeof(ModbusCoilEdit)) {
                ModbusCoilEdit pd = (ModbusCoilEdit)Tag;
                if (pd == null) { return; }
                if (pd.Coil == null) { return; }
                pd.Coil.Name = Ttb.Text ?? "";
                //pd.Register.PushValue()
                SystemManager.RegisterNameChanged(pd.Coil.Parent, pd.Coil.Name, pd.Coil.Address, pd.Selection);
                pd.Item[pd.Column].Text = pd.Coil.Name;
            }
            else if (Tag.GetType() == typeof(ModbusRegisterEdit)) {
                ModbusRegisterEdit pd = (ModbusRegisterEdit)Tag;
                if (pd == null) { return; }
                if (pd.Register == null) { return; }
                pd.Register.Name = Ttb.Text ?? "";
                //pd.Register.PushValue()
                SystemManager.RegisterNameChanged(pd.Register.Parent, pd.Register, pd.Register.Address, pd.Selection);
                pd.Item[pd.Column].Text = pd.Register.Name;
            }
        }
        private static void Tb_ValueChanged(object sender, ValueChangedEventArgs e) {
            if (sender.GetType() != typeof(NumericTextbox)) { return; }
            NumericTextbox Ttb = (NumericTextbox)sender;
            object? Tag = Ttb.Tag;
            if (Tag == null) { return; }
            if (Tag.GetType() != typeof(ModbusRegisterEdit)) { return; }
            ModbusRegisterEdit pd = (ModbusRegisterEdit)Tag;
            if (pd == null) { return; }
            if (pd.Register == null) { return; }
            EnumManager.PushPrefix(pd.Register, Ttb.Prefix);
            pd.Register.PushValue(Formatters.StringToLong(Ttb.Value.ToString() ?? "0", pd.Register.Format, pd.Register.Size, pd.Register.Signed), true);
            //pd.Register.PushValue()
            SystemManager.RegisterValueChanged(pd.Register.Parent, pd.Register.FormattedValue, pd.Register.Address, pd.Selection);
            pd.Item[pd.Column].Text = pd.Register.ValueWithUnit;
        }
        public static void RemoveAllControls(ODModules.ListControl LstCtrl) {
            for (int i = LstCtrl.Controls.Count - 1; i >= 0; i--) {
                RemoveControl(LstCtrl.Controls[i], false);
            }
            SystemManager.InvokeModbusEditorChanged();
        }
        private static void Nb_EnterPressed(NumericTextbox sender) {
            RemoveControl(sender);
        }

        private static void Tb_KeyPress(object? sender, KeyPressEventArgs e) {
            if (e.KeyChar == ' ') {
                RemoveControl(sender);
            }
        }
        private static void RemoveControl(object? sender, bool InvokeEvent = true) {
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
                OdTb.EnterPressed -= Nb_EnterPressed;
                OdTb.ValueChanged -= Tb_ValueChanged;
                if (OdTb.Parent == null) { return; }
                OdTb.Parent.Controls.Remove(OdTb);
            }
            else if (sender.GetType() == typeof(ODModules.SingleLineTextBox)) {
                ODModules.SingleLineTextBox OdTb = (ODModules.SingleLineTextBox)sender;
                OdTb.LostFocus -= Tb_LostFocus;
                OdTb.EnterPressed -= Tb_EnterPressed;
                OdTb.TextChanged -= Tb_TextChanged;
                if (OdTb.Parent == null) { return; }
                OdTb.Parent.Controls.Remove(OdTb);
            }
            if (InvokeEvent) { SystemManager.InvokeModbusEditorChanged(); }
        }
        private static void Tb_LostFocus(object? sender, EventArgs e) {
            RemoveControl(sender);
        }
        public static void ClearControls(ListControl LstCtrl) {
            LstCtrl.Controls.Clear();
            // GC.Collect();
            Thread Tr = new Thread(PurgeData);
            Tr.IsBackground = true;
            Tr.Start();
        }
        static DateTime PreviousInstance = DateTime.MinValue;
        internal static void PurgeData() {
            if (ConversionHandler.DateIntervalDifference(PreviousInstance, DateTime.UtcNow, ConversionHandler.Interval.Millisecond) >= 1000) {
                GC.Collect();
                PreviousInstance = DateTime.UtcNow;
            }
        }
        #endregion
        #region Editing Support
        public static bool ItemInBounds(ListControl DataList, int Index, uint Column) {
            if (Index < 0) { return false; }
            if (DataList.CurrentItems.Count > 0) {
                if (Index < DataList.CurrentItems.Count) {
                    if (Column == 0) {
                        return true;
                    }
                    else {
                        if (DataList.CurrentItems[Index].SubItems.Count > 0) {
                            if (DataList.CurrentItems[Index].SubItems.Count > Column - 1) {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        #endregion
        #region Appearance/View
        private static void InvalidateColumns(ListControl lsMonitor) {
            foreach (Column col in lsMonitor.Columns) {
                int TWidth = col.Width;
                col.Width = TWidth;
            }
        }
        public static void ShowHideColumns(bool showFormats, bool showLastUpdate, DataSelection DataSet, ListControl lstMonitor) {
            lstMonitor.Columns[Indx_LastUpdated].Visible = showLastUpdate;
            //if (showLastUpdate == true) {
                //int TWidth = lstMonitor.Columns[Indx_LastUpdated].Width;
                //lstMonitor.Columns[Indx_LastUpdated].Width = TWidth;
            //}
            if (showFormats == false) {
                lstMonitor.Columns[Indx_Size].Visible = false;
                lstMonitor.Columns[Indx_Signed].Visible = false;
                lstMonitor.Columns[Indx_Display].Visible = false;
                //return;
            }
            else {
                lstMonitor.Columns[Indx_Display].Visible = true;
            }
            if (DataSet == DataSelection.ModbusDataCoils) {
                if (showFormats == true) {
                    lstMonitor.Columns[Indx_Size].Visible = false;
                    lstMonitor.Columns[Indx_Signed].Visible = false;
                }
            }
            else if (DataSet == DataSelection.ModbusDataDiscreteInputs) {
                if (showFormats == true) {
                    lstMonitor.Columns[Indx_Size].Visible = false;
                    lstMonitor.Columns[Indx_Signed].Visible = false;
                }
            }
            else if (DataSet == DataSelection.ModbusDataInputRegisters) {
                if (showFormats == true) {
                    lstMonitor.Columns[Indx_Size].Visible = true;
                    lstMonitor.Columns[Indx_Signed].Visible = true;
                }
            }
            else if (DataSet == DataSelection.ModbusDataHoldingRegisters) {
                if (showFormats == true) {
                    lstMonitor.Columns[Indx_Size].Visible = true;
                    lstMonitor.Columns[Indx_Signed].Visible = true;
                }
            }
            InvalidateColumns(lstMonitor);
            lstMonitor.ResetCellSelection();
            lstMonitor.Invalidate();
        }
        public static void ApplyAddressChanges(ListControl? lstMonitor, SerialManager? Channel, DataSelection Selection, int Slave) {
            if (lstMonitor == null) { return; }
            if (Channel == null) { return; }
            if (lstMonitor.Columns.Count < 1) { return; }
            ModbusSlave? Unit = null;
            if (Slave < 0) { Unit = Channel.Registers; }
            else {
                if (Slave >= Channel.Slave.Count) { return; }
                else { Unit = Channel.Slave[Slave]; }
            }
            if (Unit == null) { return; }
            AddressSystem AddressFormat = Unit.AddressFormat;
            int Offset = 0;
            switch (AddressFormat) {
                case AddressSystem.ZeroBasedDecimal:
                    lstMonitor.Columns[0].DisplayType = ColumnDisplayType.LineCount;
                    lstMonitor.Columns[0].CountOffset = 0;
                    break;
                case AddressSystem.OneBasedDecimal:
                    lstMonitor.Columns[0].DisplayType = ColumnDisplayType.LineCount;
                    lstMonitor.Columns[0].CountOffset = 1;
                    break;
                case AddressSystem.ZeroBasedHexadecimal:
                    lstMonitor.Columns[0].DisplayType = ColumnDisplayType.Text;
                    Offset = 0;
                    break;
                case AddressSystem.OneBasedHexadecimal:
                    lstMonitor.Columns[0].DisplayType = ColumnDisplayType.Text;
                    Offset = 1;
                    break;
                case AddressSystem.PLCAddress:
                    lstMonitor.Columns[0].DisplayType = ColumnDisplayType.Text;
                    Offset = 1;
                    break;
                default:
                    break;
            }
            if (((int)AddressFormat & 0x100) == 0x100) {
                int i = Offset;
                if ((AddressFormat == AddressSystem.ZeroBasedHexadecimal) || (AddressFormat == AddressSystem.OneBasedHexadecimal)) {
                    foreach (ListItem Li in lstMonitor.CurrentItems) {
                        Li[0].Text = Formatters.Integer16ToHex(i);
                        i++;
                    }
                }
                else if (AddressFormat == AddressSystem.PLCAddress) {
                    foreach (ListItem Li in lstMonitor.CurrentItems) {
                        Li[0].Text = Formatters.PLCAddress(i, Selection);
                        i++;
                    }
                }
            }
            lstMonitor.Invalidate();
        }

        #endregion
        #region Context Menu Handling
        public static object? GetContextMenuData(object? sender) {
            if (sender == null) { return null; }
            if (sender.GetType() != typeof(ToolStripMenuItem)) { return null; }
            ToolStripMenuItem Mi = (ToolStripMenuItem)sender;
            if (Mi.Owner == null) { return null; }
            if (Mi.Owner.GetType() != typeof(ContextMenu)) { return null; }
            ContextMenu Menu = (ContextMenu)Mi.Owner;
            return Menu.Tag;
        }
        public static object? GetContextMenuItemData(object? sender) {
            if (sender == null) { return null; }
            if (sender.GetType() != typeof(ToolStripMenuItem)) { return null; }
            ToolStripMenuItem Mi = (ToolStripMenuItem)sender;
            return Mi.Tag;
        }
        #endregion
        #region Formatters
        public static void RetroactivelyApplyFormatChanges(int CentreIndex, ListControl lstMonitor, bool ShowUnits) {
            for (int i = 1; i <= 3; i++) {
                int BeforeIndex = CentreIndex - i;
                int AfterIndex = CentreIndex + i;
                if (BeforeIndex >= 0) {
                    Classes.Modbus.ModbusRegister? Itm = GetRegisterFromItem(BeforeIndex, lstMonitor);
                    if (Itm != null) {
                        lstMonitor.CurrentItems[BeforeIndex][Indx_Display].Text = EnumManager.DataFormatToString(Itm.Format).A;
                        lstMonitor.CurrentItems[BeforeIndex][Indx_Size].Text = EnumManager.DataSizeToString(Itm.Size);
                        lstMonitor.CurrentItems[BeforeIndex][Indx_Value].Text = ShowUnits == true ? Itm.ValueWithUnit : Itm.FormattedValue;
                        lstMonitor.CurrentItems[BeforeIndex][Indx_Size].Text = EnumManager.DataSizeToString(Itm.Size);
                        lstMonitor.CurrentItems[BeforeIndex][Indx_LastUpdated].Text = Itm.GetLastUpdatedTime();
                    }
                }
                if (AfterIndex < lstMonitor.CurrentItems.Count) {
                    Classes.Modbus.ModbusRegister? Itm = GetRegisterFromItem(AfterIndex, lstMonitor);
                    if (Itm != null) {
                        lstMonitor.CurrentItems[AfterIndex][Indx_Display].Text = EnumManager.DataFormatToString(Itm.Format).A;
                        lstMonitor.CurrentItems[AfterIndex][Indx_Size].Text = EnumManager.DataSizeToString(Itm.Size);
                        lstMonitor.CurrentItems[AfterIndex][Indx_Value].Text = ShowUnits == true ? Itm.ValueWithUnit : Itm.FormattedValue;
                        lstMonitor.CurrentItems[AfterIndex][Indx_LastUpdated].Text = Itm.GetLastUpdatedTime();
                    }
                }
            }
        }
        public static Classes.Modbus.ModbusRegister? GetRegisterFromItem(int Index, ListControl lstMonitor) {
            if (Index >= lstMonitor.CurrentItems.Count) { return null; }
            if (Index < 0) { return null; }
            object? Data = lstMonitor.CurrentItems[Index].Tag;
            if (Data == null) { return null; }
            if (Data.GetType() == typeof(Classes.Modbus.ModbusRegister)) {
                return (Classes.Modbus.ModbusRegister)Data;
            }
            return null;
        }
        #endregion
        #region Drawing Support
        public static Point AddPoint(DropDownClickedEventArgs e) {
            return new Point(e.ScreenLocation.X, e.ScreenLocation.Y + e.ItemSize.Height);
        }
        #endregion
        #region Format Editing
        public static void ChangeFloatFormatList(object? sender, ListControl? lstMonitor) {
            if (lstMonitor == null) { return; }
            object? ButtonData = GetContextMenuItemData(sender);
            if (ButtonData == null) {
                if (sender == null) { return; }
                if (sender.GetType()! != typeof(ModbusEnums.FloatFormat)) { return; }
                ButtonData = sender;
            }
            if (ButtonData.GetType()! != typeof(ModbusEnums.FloatFormat)) {
                return;
            }
            FloatFormat Frmt = (FloatFormat)ButtonData;

            int SelectedCount = lstMonitor.SelectionCount;
            if (SelectedCount <= 0) { return; }
            foreach (ListItem Li in lstMonitor.CurrentItems) {
                if (Li.SubItems.Count >= Indx_Value) {
                    if (Li.Selected == true) {
                        if (Li.Tag == null) { continue; }
                        if (Li.Tag.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)Li.Tag;
                            Reg.DecimalFormat = Frmt;
                            Li[Indx_Value].Text = Reg.ValueWithUnit;
                        }
                        SelectedCount--;
                    }
                    if (SelectedCount <= 0) {
                        break;
                    }
                }
            }
            lstMonitor.Invalidate();
        }
        public static void ChangeCoilFormatList(object? sender, ListControl? lstMonitor) {
            if (lstMonitor == null) { return; }
            object? ButtonData = GetContextMenuItemData(sender);
            if (ButtonData == null) {
                if (sender == null) { return; }
                if (sender.GetType() != typeof(ModbusEnums.CoilFormat)) { return; }
                ButtonData = sender;
            }
            if (ButtonData.GetType() != typeof(ModbusEnums.CoilFormat)) { return; }
            CoilFormat Frmt = (CoilFormat)ButtonData;

            int SelectedCount = lstMonitor.SelectionCount;
            if (SelectedCount <= 0) { return; }
            foreach (ListItem Li in lstMonitor.CurrentItems) {
                if (Li.SubItems.Count >= Indx_Value) {
                    if (Li.Selected == true) {
                        if (Li.Tag == null) { continue; }
                        if (Li.Tag.GetType() == typeof(ModbusCoil)) {
                            ModbusCoil Reg = (ModbusCoil)Li.Tag;
                            Reg.Format = Frmt;
                            Li[Indx_Display].Text = EnumManager.CoilFormatToString(Reg.Format).A;
                            Li[Indx_Value].Text = Reg.ValueWithUnit;
                            RetroactivelyApplyFormatChanges(Reg.Address, lstMonitor, false);
                        }
                        SelectedCount--;
                    }
                    if (SelectedCount <= 0) {
                        break;
                    }
                }
            }
            lstMonitor.Invalidate();
        }
        public static void ChangeDisplayFormatListDual(object? sender, ListControl? lstMonitor, bool ShowUnits) {
            ChangeDisplayFormatList(sender, lstMonitor, ShowUnits);
            // ChangeDisplayFormatList(sender, lstMonitor, ShowUnits);
        }
        public static void ChangeDisplayFormatList(object? sender, ListControl? lstMonitor, bool ShowUnits) {
            if (lstMonitor == null) { return; }
            object? ButtonData = GetContextMenuItemData(sender);
            if (ButtonData == null) {
                if (sender == null) { return; }
                if (sender.GetType() != typeof(ModbusEnums.DataFormat)) { return; }
                ButtonData = sender;
            }
            if (ButtonData.GetType() != typeof(ModbusEnums.DataFormat)) { return; }
            DataFormat Frmt = (DataFormat)ButtonData;

            int SelectedCount = lstMonitor.SelectionCount;
            if (SelectedCount <= 0) { return; }
            int CurrentIndex = -1;
            int LastIndex = -10;
            foreach (ListItem Li in lstMonitor.CurrentItems) {
                if (Li.SubItems.Count >= Indx_Value) {
                    if (Li.Selected == true) {
                        if (Li.Tag == null) { continue; }
                        if (Li.Tag.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)Li.Tag;
                            DataSize SizeSet = EnumManager.DataFormatToDataSize(Frmt, Reg.Size);
                            CurrentIndex = Reg.Address;
                            if (SizeSet == DataSize.Bits32) {
                                if (CurrentIndex - LastIndex > 1) {
                                    Reg.Format = Frmt;
                                    LastIndex = CurrentIndex;
                                }
                                else {
                                    Reg.Format = EnumManager.ChangeSizeDependantDataFormat(Frmt);
                                }
                            }
                            else if (SizeSet == DataSize.Bits64) {
                                if (CurrentIndex - LastIndex > 3) {
                                    Reg.Format = Frmt;
                                    LastIndex = CurrentIndex;
                                }
                                else {
                                    Reg.Format = EnumManager.ChangeSizeDependantDataFormat(Frmt);
                                }
                            }
                            else {
                                Reg.Format = Frmt;
                            }
                            Li[Indx_Display].Text = EnumManager.DataFormatToString(Reg.Format).A;
                            Li[Indx_Size].Text = EnumManager.DataSizeToString(Reg.Size);
                            Li[Indx_Value].Text = Reg.ValueWithUnit;
                            RetroactivelyApplyFormatChanges(Reg.Address, lstMonitor, ShowUnits);
                        }
                        SelectedCount--;
                    }
                    if (SelectedCount <= 0) {
                        break;
                    }
                }
            }
            lstMonitor.Invalidate();
        }
        public static void ChangeSizeList(object? sender, ListControl? lstMonitor, bool ShowUnits) {
            if (lstMonitor == null) { return; }
            object? ButtonData = GetContextMenuItemData(sender);
            if (ButtonData == null) {
                if (sender == null) { return; }
                if (sender.GetType() != typeof(ModbusEnums.DataSize)) { return; }
                ButtonData = sender;
            }
            if (ButtonData.GetType() != typeof(ModbusEnums.DataSize)) { return; }
            DataSize Frmt = (DataSize)ButtonData;

            int SelectedCount = lstMonitor.SelectionCount;
            if (SelectedCount <= 0) { return; }
            int CurrentIndex = -1;
            int LastIndex = -10;
            foreach (ListItem Li in lstMonitor.CurrentItems) {
                if (Li.SubItems.Count >= ModbusEditor.Indx_Value) {
                    if (Li.Selected == true) {
                        if (Li.Tag == null) { continue; }
                        if (Li.Tag.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)Li.Tag;
                            CurrentIndex = Reg.Address;
                            if (Frmt == DataSize.Bits32) {
                                if (CurrentIndex - LastIndex > 1) {
                                    Reg.Size = DataSize.Bits32;
                                    LastIndex = CurrentIndex;
                                }
                                else {
                                    Reg.Size = DataSize.Bits16;
                                }
                            }
                            else if (Frmt == DataSize.Bits64) {
                                if (CurrentIndex - LastIndex > 3) {
                                    Reg.Size = DataSize.Bits64;
                                    LastIndex = CurrentIndex;
                                }
                                else {
                                    Reg.Size = DataSize.Bits16;
                                }
                            }
                            else {
                                Reg.Size = Frmt;
                            }
                            Li[Indx_Size].Text = EnumManager.DataSizeToString(Reg.Size);
                            Li[Indx_Display].Text = EnumManager.DataFormatToString(Reg.Format).A;
                            Li[Indx_Value].Text = Reg.ValueWithUnit;
                            RetroactivelyApplyFormatChanges(Reg.Address, lstMonitor, ShowUnits);
                        }
                        SelectedCount--;
                    }
                    if (SelectedCount <= 0) {
                        break;
                    }
                }
            }
            lstMonitor.Invalidate();
        }
        public static void ChangeDataSize(DropDownClickedEventArgs? e, ListControl? LstMonitor, string? SearchText, bool ShowUnits) {
            if (e == null) { return; }
            if (LstMonitor == null) { return; }
            if (e.ParentItem == null) { return; }
            object? TempData = e.ParentItem.Tag;
            if (TempData == null) { return; }
            if (TempData.GetType() != typeof(ModbusRegister)) { return; }
            ModbusRegister Reg = (ModbusRegister)TempData;
            if (SearchText == null) { return; }
            if (SearchText.Trim() == "") { return; }
            Enums.ModbusEnums.DataSize[] Formats = (DataSize[])DataSize.GetValues(typeof(Enums.ModbusEnums.DataSize));
            DataSize DatSize = DataSize.Bits16;
            foreach (ModbusEnums.DataSize Frmt in Formats) {
                string Data = EnumManager.DataSizeToString(Frmt);
                if (Data.ToLower().Contains(SearchText.ToLower())) {
                    DatSize = Frmt;
                    break;
                }
            }
            Reg.Size = DatSize;
            e.ParentItem[e.Column].Text = EnumManager.DataSizeToString(Reg.Size);
            e.ParentItem[ModbusEditor.Indx_Display].Text = EnumManager.DataFormatToString(Reg.Format).A;
            e.ParentItem[ModbusEditor.Indx_Value].Text = Reg.ValueWithUnit;
            ModbusEditor.RetroactivelyApplyFormatChanges(e.Item, LstMonitor, ShowUnits);
            LstMonitor.Invalidate();
        }
        public static void ChangeDataFormat(DropDownClickedEventArgs? e, ListControl? LstMonitor, string? SearchText, bool ShowUnits) {
            if (e == null) { return; }
            if (LstMonitor == null) { return; }
            if (e.ParentItem == null) { return; }
            object? TempData = e.ParentItem.Tag;
            if (TempData == null) { return; }
            if (SearchText == null) { return; }
            if (SearchText.Trim() == "") { return; }

            if (TempData.GetType() == typeof(ModbusRegister)) {
                ModbusRegister Reg = (ModbusRegister)TempData;

                Enums.ModbusEnums.DataFormat[] Formats = (DataFormat[])DataFormat.GetValues(typeof(Enums.ModbusEnums.DataFormat));
                DataFormat DatSize = DataFormat.Decimal;
                foreach (ModbusEnums.DataFormat Frmt in Formats) {
                    string Data = EnumManager.DataFormatToString(Frmt).A;
                    if (Data.ToLower().Contains(SearchText.ToLower())) {
                        DatSize = Frmt;
                        break;
                    }
                }
                Reg.Format = DatSize;
                e.ParentItem[ModbusEditor.Indx_Display].Text = EnumManager.DataSizeToString(Reg.Size);
                e.ParentItem[e.Column].Text = EnumManager.DataFormatToString(Reg.Format).A;
                e.ParentItem[ModbusEditor.Indx_Value].Text = Reg.ValueWithUnit;
                ModbusEditor.RetroactivelyApplyFormatChanges(e.Item, LstMonitor, ShowUnits);
            }
            else if (TempData.GetType() == typeof(ModbusCoil)) {
                ModbusCoil Reg = (ModbusCoil)TempData;

                Enums.ModbusEnums.CoilFormat[] Formats = (CoilFormat[])CoilFormat.GetValues(typeof(Enums.ModbusEnums.CoilFormat));
                CoilFormat DatSize = CoilFormat.Boolean;
                foreach (ModbusEnums.CoilFormat Frmt in Formats) {
                    string Data = EnumManager.CoilFormatToString(Frmt).A;
                    if (Data.ToLower().Contains(SearchText.ToLower())) {
                        DatSize = Frmt;
                        break;
                    }
                }
                Reg.Format = DatSize;
                e.ParentItem[e.Column].Text = EnumManager.CoilFormatToString(Reg.Format).A;
                e.ParentItem[ModbusEditor.Indx_Value].Text = Reg.ValueWithUnit;
            }
            LstMonitor.Invalidate();
        }
        public static void ChangeSignedList(ListControl? lstMonitor, SignedState State, bool ShowUnits) {
            if (lstMonitor == null) { return; }
            int SelectedCount = lstMonitor.SelectionCount;
            if (SelectedCount <= 0) { return; }
            foreach (ListItem Li in lstMonitor.CurrentItems) {
                if (Li.SubItems.Count >= ModbusEditor.Indx_Value) {
                    if (Li.Selected == true) {
                        if (Li.Tag == null) { continue; }
                        if (Li.Tag.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)Li.Tag;
                            if (Reg.Format == DataFormat.Float) {
                                Reg.Signed = false;
                            }
                            else if (Reg.Format == DataFormat.Double) {
                                Reg.Signed = false;
                            }
                            else {
                                switch (State) {
                                    case SignedState.Unsigned:
                                        Reg.Signed = false; break;
                                    case SignedState.Signed:
                                        Reg.Signed = true; break;
                                    case SignedState.Toggle:
                                        Reg.Signed = !Reg.Signed; break;
                                }
                            }
                            Li[Indx_Signed].Checked = Reg.Signed;
                            Li[Indx_Value].Text = Reg.ValueWithUnit;
                            RetroactivelyApplyFormatChanges(Reg.Address, lstMonitor, ShowUnits);
                        }
                        SelectedCount--;
                    }
                    if (SelectedCount <= 0) {
                        break;
                    }
                }
            }
            lstMonitor.Invalidate();
        }
        public static void ChangeWordOrderList(object? sender, ListControl? lstMonitor, bool ShowUnits) {
            object? ButtonData = GetContextMenuItemData(sender);
            if (ButtonData == null) {
                if (sender == null) { return; }
                else {
                    if (sender.GetType() == typeof(ModbusEnums.ByteOrder)) {
                        ButtonData = sender;
                    }
                }
            }
            if (ButtonData == null) { return; }
            if (ButtonData.GetType() != typeof(ModbusEnums.ByteOrder)) {
                if (sender == null) { return; }
                if (sender.GetType() != typeof(ModbusEnums.ByteOrder)) { return; }
                ButtonData = sender;
            }
            ByteOrder State = (ByteOrder)ButtonData;

            if (lstMonitor == null) { return; }
            int SelectedCount = lstMonitor.SelectionCount;
            if (SelectedCount <= 0) { return; }
            foreach (ListItem Li in lstMonitor.CurrentItems) {
                if (Li.SubItems.Count >= ModbusEditor.Indx_Value) {
                    if (Li.Selected == true) {
                        if (Li.Tag == null) { continue; }
                        if (Li.Tag.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)Li.Tag;
                            if (Reg.Format == DataFormat.Float) {
                                Reg.WordOrder = State;
                            }
                            else if (Reg.Format == DataFormat.Double) {
                                Reg.WordOrder = State;
                            }
                            else if (Reg.Size == DataSize.Bits32) {
                                Reg.WordOrder = State;
                            }
                            else if (Reg.Size == DataSize.Bits64) {
                                Reg.WordOrder = State;
                            }
                            else {
                                Reg.WordOrder = ByteOrder.LittleEndian;
                            }
                            Li[Indx_Signed].Checked = Reg.Signed;
                            Li[Indx_Value].Text = Reg.ValueWithUnit;
                            RetroactivelyApplyFormatChanges(Reg.Address, lstMonitor, ShowUnits);
                        }
                        SelectedCount--;
                    }
                    if (SelectedCount <= 0) {
                        break;
                    }
                }
            }
            lstMonitor.Invalidate();
        }
        #endregion
        #region Format Editing Support
        public static void CheckItem(object DropDownList, CoilFormat CheckOn) {
            if (DropDownList.GetType() == typeof(ContextMenu)) {
                ContextMenu Btn = (ContextMenu)DropDownList;
                foreach (ToolStripItem Tsi in Btn.Items) {
                    if (Tsi.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Item = (ToolStripMenuItem)Tsi;
                    if (Item.Tag == null) {
                        Item.Checked = false;
                        continue;
                    }
                    else {
                        if (Item.Tag.GetType() == typeof(ModbusEnums.CoilFormat)) {
                            ModbusEnums.CoilFormat dataFormat = (ModbusEnums.CoilFormat)Item.Tag;
                            if (dataFormat == CheckOn) { Item.Checked = true; }
                            else { Item.Checked = false; }
                        }
                    }
                }
            }
        }
        public static void CheckItem(object DropDownList, DataFormat CheckOn) {
            if (DropDownList.GetType() == typeof(ContextMenu)) {
                ContextMenu Btn = (ContextMenu)DropDownList;
                foreach (ToolStripItem Tsi in Btn.Items) {
                    if (Tsi.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Item = (ToolStripMenuItem)Tsi;
                    if (Item.Tag == null) {
                        Item.Checked = false;
                        continue;
                    }
                    else {
                        if (Item.Tag.GetType() == typeof(ModbusEnums.DataFormat)) {
                            ModbusEnums.DataFormat dataFormat = (ModbusEnums.DataFormat)Item.Tag;
                            if (dataFormat == CheckOn) { Item.Checked = true; }
                            else { Item.Checked = false; }
                        }
                    }
                }
            }
        }
        public static void CheckItem(object DropDownList, DataSize CheckOn) {
            if (DropDownList.GetType() == typeof(ContextMenu)) {
                ContextMenu Btn = (ContextMenu)DropDownList;
                foreach (ToolStripItem Tsi in Btn.Items) {
                    if (Tsi.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Item = (ToolStripMenuItem)Tsi;
                    if (Item.Tag == null) {
                        Item.Checked = false;
                        continue;
                    }
                    else {
                        if (Item.Tag.GetType() == typeof(ModbusEnums.DataSize)) {
                            ModbusEnums.DataSize dataFormat = (ModbusEnums.DataSize)Item.Tag;
                            if (dataFormat == CheckOn) { Item.Checked = true; }
                            else { Item.Checked = false; }
                        }
                    }
                }
            }
        }
        public static bool CanChangeValue(SerialManager? SerMan, DataSelection Selection) {
            if (SerMan == null) { return false; }
            if (SerMan.IsMaster == true) {
                if (Selection == DataSelection.ModbusDataCoils) {
                    return true;
                }
                else if (Selection == DataSelection.ModbusDataDiscreteInputs) {
                    return false;
                }
                else if (Selection == DataSelection.ModbusDataHoldingRegisters) {
                    return true;
                }
                else if (Selection == DataSelection.ModbusDataInputRegisters) {
                    return false;
                }
            }
            else {
                if (Selection == DataSelection.ModbusDataCoils) {
                    return true;
                }
                else if (Selection == DataSelection.ModbusDataDiscreteInputs) {
                    return true;
                }
                else if (Selection == DataSelection.ModbusDataHoldingRegisters) {
                    return true;
                }
                else if (Selection == DataSelection.ModbusDataInputRegisters) {
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region Format Additional Editing Options
        public static void Reset(ListControl ListEditor, ModbusClipboardFlags Flags, bool ClearSelection = true) {
            if (ListEditor.CurrentItems == null) { return; }
            for (int i = 0; i < ListEditor.CurrentItems.Count; i++) {
                if (ListEditor.CurrentItems[i].Selected == true) {
                    if (ListEditor.CurrentItems[i].SubItems.Count >= 5) {
                        object? objCmd = ListEditor.CurrentItems[i].Tag;
                        if (objCmd == null) { continue; }
                        if (objCmd.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)objCmd;
                            if (FlagSet(Flags, ModbusClipboardFlags.IncludeName)) {
                                Reg.Name = "";
                                ListEditor.CurrentItems[i][1].Text = Reg.Name;
                                SystemManager.RegisterNameChanged(Reg.Parent, Reg, Reg.Address, Reg.ComponentType);
                            }
                            if (FlagSet(Flags, ModbusClipboardFlags.IncludeValue)) {
                                Reg.Value = 0;
                            }
                            if (FlagSet(Flags, ModbusClipboardFlags.IncludeFormat)) {
                                Reg.DefaultFormat();
                                Reg.Signed = false;
                            }
                            if (FlagSet(Flags, ModbusClipboardFlags.IncludeSize)) {
                                Reg.DefaultSize();
                            }
                            if (FlagSet(Flags, ModbusClipboardFlags.IncludeAppearance)) {
                                Reg.UseBackColor = false;
                                Reg.UseForeColor = false;
                            }
                        }
                        else if (objCmd.GetType() == typeof(ModbusCoil)) {
                            ModbusCoil Reg = (ModbusCoil)objCmd;
                            if (FlagSet(Flags, ModbusClipboardFlags.IncludeName)) {
                                Reg.Name = "";
                                ListEditor.CurrentItems[i][1].Text = Reg.Name;
                                SystemManager.RegisterNameChanged(Reg.Parent, Reg, Reg.Address, Reg.ComponentType);
                            }
                            if (FlagSet(Flags, ModbusClipboardFlags.IncludeValue)) {
                                Reg.Value = false;
                            }
                            if (FlagSet(Flags, ModbusClipboardFlags.IncludeFormat)) {
                                Reg.Format = CoilFormat.Boolean;
                            }
                            if (FlagSet(Flags, ModbusClipboardFlags.IncludeAppearance)) {
                                Reg.UseBackColor = false;
                                Reg.UseForeColor = false;
                            }
                        }
                        if (ClearSelection == true) {
                            ListEditor.CurrentItems[i].Selected = false;
                        }
                    }
                }
            }
            ListEditor.Invalidate();
        }
        #endregion
        #region Clipboard
        const string Clipboard_ModbusDataType = "SERMAN:MODBUS_REG";
        public static void CopyRegistersAsText(ListControl? ListEditor, bool ClearSelection = true) {
            if (ListEditor == null) { return; }
            string Output = "";
            if (ListEditor.CurrentItems == null) { return; }
            for (int i = 0; i < ListEditor.CurrentItems.Count; i++) {
                if (ListEditor.CurrentItems[i].Selected == true) {
                    if (ListEditor.CurrentItems[i].SubItems.Count == 6) {
                        object? objCmd = ListEditor.CurrentItems[i].Tag;
                        if (objCmd == null) { continue; }
                        if (objCmd.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)objCmd;
                            Output += Reg.Address.ToString() + Constants.Tab;
                            Output += Reg.Name + Constants.Tab;
                            Output += EnumManager.DataFormatToString(Reg.Format).A + Constants.Tab;
                            Output += EnumManager.DataSizeToString(Reg.Size) + Constants.Tab;
                            Output += Reg.Signed.ToString() + Constants.Tab;
                            Output += Reg.FormattedValue + Constants.NewLineEnv;
                        }
                        else if (objCmd.GetType() == typeof(ModbusCoil)) {
                            ModbusCoil Reg = (ModbusCoil)objCmd;
                            Output += Reg.Address.ToString() + Constants.Tab;
                            Output += Reg.Name + Constants.Tab;
                            Output += "Boolean" + Constants.Tab;
                            Output += Reg.Value + Constants.NewLineEnv;
                        }
                        if (ClearSelection == true) {
                            ListEditor.CurrentItems[i].Selected = false;
                        }
                    }
                }
            }
            ListEditor.Invalidate();
            if (Output.Trim().Length <= 0) { return; }
            Clipboard.SetText(Output);
        }
        public static void CopyRegisters(ListControl? ListEditor, ModbusClipboardFlags Flags, bool ClearSelection = true) {
            if (ListEditor == null) { return; }
            if (ListEditor.CurrentItems == null) { return; }
            List<ModbusDataObject> list = new List<ModbusDataObject>();
            for (int i = 0; i < ListEditor.CurrentItems.Count; i++) {
                if (ListEditor.CurrentItems[i].Selected == true) {
                    if (ListEditor.CurrentItems[i].SubItems.Count == ModbusEditor.Indx_LastUpdated) {
                        object? objCmd = ListEditor.CurrentItems[i].Tag;
                        if (objCmd == null) { continue; }
                        if (objCmd.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)objCmd;
                            ModbusDataObject DataItem = new ModbusDataObject(Reg.Name, Reg.Value, Reg.Signed, Reg.Format, Reg.Size, Reg.UseForeColor, Reg.ForeColor, Reg.UseBackColor, Reg.BackColor, Flags);
                            list.Add(DataItem);
                        }
                        else if (objCmd.GetType() == typeof(ModbusCoil)) {
                            ModbusCoil Reg = (ModbusCoil)objCmd;
                            ModbusDataObject DataItem = new ModbusDataObject(Reg.Name, Reg.Value, Reg.UseForeColor, Reg.ForeColor, Reg.UseBackColor, Reg.BackColor, Flags);
                            list.Add(DataItem);
                        }
                        if (ClearSelection == true) {
                            ListEditor.CurrentItems[i].Selected = false;
                        }
                    }
                }
            }
            ListEditor.Invalidate();
            if (list.Count > 0) {
                Clipboard.SetData(Clipboard_ModbusDataType, list);
            }
        }
        public static void PasteRegisters(ListControl? ListEditor, bool ClearSelection = true) {
            if (ListEditor == null) { return; }
            object? Data = Clipboard.GetDataObject();
            if (Clipboard.ContainsData(Clipboard_ModbusDataType)) {
                List<int> Indices = new List<int>();
                bool LatchedSlave = false;
                ModbusSlave? Slave = null;
                DataSelection Selection = DataSelection.ModbusDataCoils;
                try {
                    if (ListEditor.CurrentItems == null) { return; }
                    object? PackagedData = Clipboard.GetData(Clipboard_ModbusDataType);
                    if (PackagedData == null) { return; }
                    List<ModbusDataObject>? CopiedItems = (List<ModbusDataObject>)PackagedData;
                    if (CopiedItems == null) { return; }
                    if (CopiedItems.Count <= 0) { return; }
                    if (ListEditor.SelectionCount <= 0) { return; }
                    int CountBuffer = ListEditor.CurrentItems.Count;
                    for (int i = 0; i < CountBuffer; i++) {
                        if (ListEditor.CurrentItems[i].Selected == true) {
                            for (int j = 0; j < CopiedItems.Count; j++) {
                                int k = j + i;
                                if (k < CountBuffer) {
                                    object? objCmd = ListEditor.CurrentItems[k].Tag;
                                    if (objCmd == null) { continue; }
                                    if (objCmd.GetType() == typeof(ModbusRegister)) {
                                        ModbusRegister Reg = (ModbusRegister)objCmd;
                                        if (FlagSet(CopiedItems[j], ModbusClipboardFlags.IncludeName)) {
                                            Reg.Name = CopiedItems[j].Name;
                                            ListEditor.CurrentItems[k][1].Text = Reg.Name;
                                            SystemManager.RegisterNameChanged(Reg.Parent, Reg, Reg.Address, Reg.ComponentType);
                                        }
                                        if (FlagSet(CopiedItems[j], ModbusClipboardFlags.IncludeValue)) {
                                            if (CopiedItems[j].IsRegister == true) {
                                                Reg.Value = (short)CopiedItems[j].Value;
                                            }
                                        }
                                        if (FlagSet(CopiedItems[j], ModbusClipboardFlags.IncludeFormat)) {
                                            Reg.Format = CopiedItems[j].Format;
                                            Reg.Signed = CopiedItems[j].Signed;
                                        }
                                        if (FlagSet(CopiedItems[j], ModbusClipboardFlags.IncludeSize)) {
                                            Reg.Size = CopiedItems[j].Size;
                                        }
                                        if (FlagSet(CopiedItems[j], ModbusClipboardFlags.IncludeAppearance)) {
                                            Reg.BackColor = CopiedItems[j].BackColor;
                                            Reg.ForeColor = CopiedItems[j].ForeColor;
                                            Reg.UseBackColor = CopiedItems[j].UseBackColor;
                                            Reg.UseForeColor = CopiedItems[j].UseForeColor;
                                            Indices.Add(k);
                                            if (LatchedSlave == false) {
                                                Slave = Reg.Parent;
                                                Selection = Reg.ComponentType;
                                                LatchedSlave = true;
                                            }
                                        }
                                    }
                                    else if (objCmd.GetType() == typeof(ModbusCoil)) {
                                        ModbusCoil Reg = (ModbusCoil)objCmd;
                                        if (FlagSet(CopiedItems[j], ModbusClipboardFlags.IncludeName)) {
                                            Reg.Name = CopiedItems[j].Name;
                                            ListEditor.CurrentItems[k][1].Text = Reg.Name;
                                            SystemManager.RegisterNameChanged(Reg.Parent, Reg, Reg.Address, Reg.ComponentType);
                                        }
                                        if (FlagSet(CopiedItems[j], ModbusClipboardFlags.IncludeValue)) {
                                            if (CopiedItems[j].IsRegister == false) {
                                                Reg.Value = (bool)CopiedItems[j].Value;
                                            }
                                        }
                                        if (FlagSet(CopiedItems[j], ModbusClipboardFlags.IncludeAppearance)) {
                                            Reg.BackColor = CopiedItems[j].BackColor;
                                            Reg.ForeColor = CopiedItems[j].ForeColor;
                                            Reg.UseBackColor = CopiedItems[j].UseBackColor;
                                            Reg.UseForeColor = CopiedItems[j].UseForeColor;
                                            Indices.Add(k);
                                            if (LatchedSlave == false) {
                                                Slave = Reg.Parent;
                                                Selection = Reg.ComponentType;
                                                LatchedSlave = true;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                    ListEditor.Invalidate();
                }
                catch { }
                if (Indices.Count > 0) {
                    SystemManager.ModbusRegisterAppearanceChanged(Slave, Indices, Selection);
                }
            }
            else {
                PasteRegisterNames(ListEditor);
            }
            //}
        }
        private static void PasteRegisterNames(ListControl ListEditor) {
            try {
                if (ListEditor.CurrentItems == null) { return; }
                List<string> CopiedItems = StringHandler.SpiltStringMutipleValues(Clipboard.GetText(), Constants.NewLine).Value;
                if (ListEditor.SelectionCount <= 0) { return; }
                int CountBuffer = ListEditor.CurrentItems.Count;
                for (int i = 0; i < CountBuffer; i++) {
                    if (ListEditor.CurrentItems[i].Selected == true) {
                        for (int j = 0; j < CopiedItems.Count; j++) {
                            int k = j + i;
                            if (k < CountBuffer) {
                                object? objCmd = ListEditor.CurrentItems[k].Tag;
                                if (objCmd == null) { continue; }
                                if (objCmd.GetType() == typeof(ModbusRegister)) {
                                    ModbusRegister Reg = (ModbusRegister)objCmd;
                                    Reg.Name = CopiedItems[j].Replace("\r", "");
                                    ListEditor.CurrentItems[k][1].Text = Reg.Name;
                                    SystemManager.RegisterNameChanged(Reg.Parent, Reg, Reg.Address, Reg.ComponentType);
                                }
                                else if (objCmd.GetType() == typeof(ModbusCoil)) {
                                    ModbusCoil Reg = (ModbusCoil)objCmd;
                                    Reg.Name = CopiedItems[j].Replace("\r", ""); ;
                                    ListEditor.CurrentItems[k][1].Text = Reg.Name;
                                    SystemManager.RegisterNameChanged(Reg.Parent, Reg, Reg.Address, Reg.ComponentType);
                                }
                            }
                        }
                        break;
                    }
                }
                ListEditor.Invalidate();
            }
            catch { }
        }
        #endregion
        #region Selection Handling
        public static void SelectAll(ListControl? ListEditor, bool Invert = false) {
            if (ListEditor == null) { return; }
            if (Invert == false) {
                ListEditor.LineSelectAll();
            }
            else {
                foreach (ListItem Li in ListEditor.CurrentItems) {
                    Li.Selected = !Li.Selected;
                }
                ListEditor.Invalidate();
            }
        }
        //ModbusClipboardFlags
        public static void SelectMatching(ListControl? ListEditor, ModbusClipboardFlags SelectFlags) {
            if (ListEditor == null) { return; }
            if (ListEditor.SelectionCount == 0) { return; }
            if (ListEditor.SelectionCount > 1) { return; }
            try {
                ModbusCoil? SelectedCoil = GetCoilFromTag(ListEditor.CurrentItems[ListEditor.SelectedIndex]);
                if (SelectedCoil != null) {
                    foreach (ListItem Li in ListEditor.CurrentItems) {
                        ModbusCoil? Temp = GetCoilFromTag(Li);
                        if (Temp == null) { continue; }
                        bool Select = false;
                        if (IsCopyFlagSet(SelectFlags, ModbusClipboardFlags.IncludeName)) {
                            if (SelectedCoil.Name.ToLower() == Temp.Name.ToLower()) {
                                Select = true;
                            }
                            else {
                                Select = false;
                            }
                        }
                        if (IsCopyFlagSet(SelectFlags, ModbusClipboardFlags.IncludeValue)) {
                            if (SelectedCoil.Value == Temp.Value) {
                                Select = true;
                            }
                            else {
                                Select = false;
                            }
                        }
                        if (IsCopyFlagSet(SelectFlags, ModbusClipboardFlags.IncludeFormat)) {
                            if (SelectedCoil.Format == Temp.Format) {
                                Select = true;
                            }
                            else {
                                Select = false;
                            }
                        }
                        Li.Selected = Select;
                    }
                }
                ModbusRegister? SelectedRegister = GetRegisterFromTag(ListEditor.CurrentItems[ListEditor.SelectedIndex]);
                if (SelectedRegister != null) {
                    foreach (ListItem Li in ListEditor.CurrentItems) {
                        ModbusRegister? Temp = GetRegisterFromTag(Li);
                        if (Temp == null) { continue; }
                        bool Select = false;
                        if (IsCopyFlagSet(SelectFlags, ModbusClipboardFlags.IncludeName)) {
                            if (SelectedRegister.Name.ToLower() == Temp.Name.ToLower()) {
                                Select = true;
                            }
                            else {
                                Select = false;
                            }
                        }
                        if (IsCopyFlagSet(SelectFlags, ModbusClipboardFlags.IncludeValue)) {
                            if (SelectedRegister.Value == Temp.Value) {
                                Select = true;
                            }
                            else {
                                Select = false;
                            }
                        }
                        if (IsCopyFlagSet(SelectFlags, ModbusClipboardFlags.IncludeFormat)) {
                            if (SelectedRegister.Format == Temp.Format) {
                                Select = true;
                            }
                            else {
                                Select = false;
                            }
                        }
                        if (IsCopyFlagSet(SelectFlags, ModbusClipboardFlags.IncludeSize)) {
                            if (SelectedRegister.Size == Temp.Size) {
                                Select = true;
                            }
                            else {
                                Select = false;
                            }
                        }
                        Li.Selected = Select;
                    }
                }
                ListEditor.Invalidate();
            }
            catch { }
        }
        private static bool IsCopyFlagSet(ModbusClipboardFlags Flags, ModbusClipboardFlags Mask) {
            if (((int)Flags & (int)Mask) == (int)Mask) { return true; }
            return false;
        }
        private static ModbusCoil? GetCoilFromTag(ListItem? Item) {
            if (Item == null) { return null; }
            object? DataTag = Item.Tag;
            if (DataTag == null) { return null; }
            if (DataTag.GetType() == typeof(ModbusCoil)) {
                return (ModbusCoil)DataTag;
            }
            return null;
        }
        private static ModbusRegister? GetRegisterFromTag(ListItem? Item) {
            if (Item == null) { return null; }
            object? DataTag = Item.Tag;
            if (DataTag == null) { return null; }
            if (DataTag.GetType() == typeof(ModbusRegister)) {
                return (ModbusRegister)DataTag;
            }
            return null;
        }
        #endregion
        #region Clipboard Support
        public static bool ContainsEditable(ListControl? LstCtrl) {
            if (LstCtrl == null) { return false; }
            if (LstCtrl.Controls.Count <= 0) { return false; }
            if (LstCtrl.Controls.Count >= 2) { return false; }
            object? Ctrl = LstCtrl.Controls[0];
            if (Ctrl.GetType() == typeof(NumericTextbox)) { return true; }
            else if (Ctrl.GetType() == typeof(SingleLineTextBox)) { return true; }
            return false;
        }
        public static void PasteTextIntoEditRegion(string Input, ListControl? LstCtrl) {
            if (LstCtrl == null) { return; }
            if (!ContainsEditable(LstCtrl)) { return; }
            object? Ctrl = LstCtrl.Controls[0];
            if (Ctrl.GetType() == typeof(NumericTextbox)) {
                ((NumericTextbox)Ctrl).Paste();
            }
            else if (Ctrl.GetType() == typeof(SingleLineTextBox)) {
                ((SingleLineTextBox)Ctrl).Paste();
            }
        }
        public static void CopyTextFromEditRegion(ListControl? LstCtrl) {
            if (LstCtrl == null) { return; }
            if (!ContainsEditable(LstCtrl)) { return; }
            object? Ctrl = LstCtrl.Controls[0];
            if (Ctrl.GetType() == typeof(NumericTextbox)) {
                ((NumericTextbox)Ctrl).Copy();
            }
            else if (Ctrl.GetType() == typeof(SingleLineTextBox)) {
                ((SingleLineTextBox)Ctrl).Copy();
            }
        }
        public static void CutTextFromEditRegion(ListControl? LstCtrl) {
            if (LstCtrl == null) { return; }
            if (!ContainsEditable(LstCtrl)) { return; }
            object? Ctrl = LstCtrl.Controls[0];
            if (Ctrl.GetType() == typeof(SingleLineTextBox)) {
                ((SingleLineTextBox)Ctrl).Cut();
            }
        }
        public static void DeleteTextFromEditRegion(ListControl? LstCtrl) {
            if (LstCtrl == null) { return; }
            if (!ContainsEditable(LstCtrl)) { return; }
            object? Ctrl = LstCtrl.Controls[0];
            if (Ctrl.GetType() == typeof(SingleLineTextBox)) {
                ((SingleLineTextBox)Ctrl).Delete();
            }
        }
        public static void SelectAllTextbox(ListControl? LstCtrl) {
            if (LstCtrl == null) { return; }
            if (!ContainsEditable(LstCtrl)) { return; }
            object? Ctrl = LstCtrl.Controls[0];
            if (Ctrl.GetType() == typeof(SingleLineTextBox)) {
                ((SingleLineTextBox)Ctrl).SelectAll();
            }
        }
        private static bool FlagSet(ModbusDataObject DataObj, ModbusClipboardFlags Flag) {
            if ((DataObj.IncludeFlags & Flag) == Flag) {
                return true;
            }
            else {
                return false;
            }
        }
        private static bool FlagSet(ModbusClipboardFlags DataObj, ModbusClipboardFlags Flag) {
            if ((DataObj & Flag) == Flag) {
                return true;
            }
            else {
                return false;
            }
        }
        #endregion
        public static List<int> ResetAppearance(object? sender, ListControl? lstMonitor) {
            if (lstMonitor == null) { return new List<int>(); }
            List<int> Indices = new List<int>();
            foreach (ListItem Li in lstMonitor.CurrentItems) {
                if (Li.SubItems.Count >= Indx_Value) {
                    if (Li.Selected == true) {
                        if (Li.Tag == null) { continue; }
                        if (Li.Tag.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)Li.Tag;
                            Reg.UseBackColor = false;
                            Reg.UseForeColor = false;

                            Li.UseLineForeColor = false;
                            Li.UseLineBackColor = false;

                            Indices.Add(Li.Value);
                        }
                        else if (Li.Tag.GetType() == typeof(ModbusCoil)) {
                            ModbusCoil Reg = (ModbusCoil)Li.Tag;
                            Reg.UseBackColor = false;
                            Reg.UseForeColor = false;

                            Li.UseLineForeColor = false;
                            Li.UseLineBackColor = false;

                            Indices.Add(Li.Value);
                        }
                    }
                }
            }
            lstMonitor.Invalidate();
            return Indices;
        }
        public static List<int> ChangeEntireAppearance(object? sender, ListControl? lstMonitor, ModbusAppearance Settings) {
            if (lstMonitor == null) { return new List<int>(); }
            List<int> Indices = new List<int>();
            foreach (ListItem Li in lstMonitor.CurrentItems) {
                if (Li.SubItems.Count >= Indx_Value) {
                    if (Li.Selected == true) {
                        if (Li.Tag == null) { continue; }
                        if (Li.Tag.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)Li.Tag;
                            Reg.UseBackColor = Settings.UseBackColor;
                            Reg.UseForeColor = Settings.UseForeColor;
                            Reg.BackColor = Settings.BackColor;
                            Reg.ForeColor = Settings.ForeColor;

                            Reg.Unit = Settings.Unit;
                            Reg.Prefix = Settings.Prefix;

                            Li.LineBackColor = Settings.BackColor;
                            Li.LineForeColor = Settings.ForeColor;

                            Li.UseLineForeColor = Settings.UseForeColor;
                            Li.UseLineBackColor = Settings.UseBackColor;


                            Li[Indx_Value].Text = Reg.ValueWithUnit;

                            Indices.Add(Li.Value);
                        }
                        else if (Li.Tag.GetType() == typeof(ModbusCoil)) {
                            ModbusCoil Reg = (ModbusCoil)Li.Tag;
                            Reg.UseBackColor = Settings.UseBackColor;
                            Reg.UseForeColor = Settings.UseForeColor;
                            Reg.BackColor = Settings.BackColor;
                            Reg.ForeColor = Settings.ForeColor;

                            Li.LineBackColor = Settings.BackColor;
                            Li.LineForeColor = Settings.ForeColor;

                            Li.UseLineForeColor = Settings.UseForeColor;
                            Li.UseLineBackColor = Settings.UseBackColor;

                            Indices.Add(Li.Value);
                        }
                    }
                }
            }
            lstMonitor.Invalidate();
            return Indices;
        }
        public static void ChangeProperty(ModbusSlave? Slave, DataSelection? Selection, object? sender, ListControl? lstMonitor, ModbusProperty Settings, ModbusPropertyFlags Flags) {
            Thread Tr = new Thread(new ThreadStart(() => ChangePropertyThread(Slave, Selection, sender, lstMonitor, Settings, Flags)));
            Tr.Name = "ModbusProp_Set";
            Tr.IsBackground = true;
            Tr.Start();
        }
        private static void ChangePropertyThread(ModbusSlave? Slave, DataSelection? Selection, object? sender, ListControl? lstMonitor, ModbusProperty Settings, ModbusPropertyFlags Flags) {
            if (lstMonitor == null) { return; }
            List<int> Indices = new List<int>();
            foreach (ListItem Li in lstMonitor.CurrentItems) {
                int Index = SetProperty(Li, Settings, Flags);
                if (Index >= 0) { Indices.Add(Li.Value); }
            }
            SystemManager.ModbusRegisterPropertiesChanged(Slave, Indices, Selection);
        }
        private static int SetProperty(ListItem Li, ModbusProperty Settings, ModbusPropertyFlags Flags) {
            if (Li.SubItems.Count >= Indx_Value) {
                if (Li.Selected == true) {
                    if (Li.Tag == null) { return -1; }
                    if (Li.Tag.GetType() == typeof(ModbusRegister)) {
                        ModbusRegister Reg = (ModbusRegister)Li.Tag;

                        if (IsPropertyFlagSet(Flags, ModbusPropertyFlags.BackColor)) {
                            Reg.BackColor = Settings.BackColor;
                            //Li.LineBackColor = Settings.BackColor;
                        }
                        if (IsPropertyFlagSet(Flags, ModbusPropertyFlags.ForeColor)) {
                            Reg.ForeColor = Settings.ForeColor;
                            //Li.LineForeColor = Settings.ForeColor;
                        }
                        if (IsPropertyFlagSet(Flags, ModbusPropertyFlags.UseBackColor)) {
                            Reg.UseBackColor = Settings.UseBackColor;
                            //Li.UseLineBackColor = Settings.UseBackColor;
                        }
                        if (IsPropertyFlagSet(Flags, ModbusPropertyFlags.UseForeColor)) {
                            Reg.UseForeColor = Settings.UseForeColor;
                            //Li.UseLineForeColor = Settings.UseForeColor;
                        }
                        if (IsPropertyFlagSet(Flags, ModbusPropertyFlags.Unit)) {
                            Reg.Unit = Settings.Unit;
                            //Li[Indx_Value].Text = Reg.ValueWithUnit;
                        }
                        if (IsPropertyFlagSet(Flags, ModbusPropertyFlags.Prefix)) {
                            Reg.Prefix = Settings.Prefix;
                            //Li[Indx_Value].Text = Reg.ValueWithUnit;
                        }

                        return Li.Value;
                    }
                    else if (Li.Tag.GetType() == typeof(ModbusCoil)) {
                        ModbusCoil Reg = (ModbusCoil)Li.Tag;
                        if (IsPropertyFlagSet(Flags, ModbusPropertyFlags.BackColor)) {
                            Reg.BackColor = Settings.BackColor;
                            //Li.LineBackColor = Settings.BackColor;
                        }
                        if (IsPropertyFlagSet(Flags, ModbusPropertyFlags.ForeColor)) {
                            Reg.ForeColor = Settings.ForeColor;
                            //Li.LineForeColor = Settings.ForeColor;
                        }
                        if (IsPropertyFlagSet(Flags, ModbusPropertyFlags.UseBackColor)) {
                            Reg.UseBackColor = Settings.UseBackColor;
                            //Li.UseLineBackColor = Settings.UseBackColor;
                        }
                        if (IsPropertyFlagSet(Flags, ModbusPropertyFlags.UseForeColor)) {
                            Reg.UseForeColor = Settings.UseForeColor;
                            //Li.UseLineForeColor = Settings.UseForeColor;
                        }

                        return Li.Value;
                    }
                }
            }
            return -1;
        }
        public static void ChangePrefix(ModbusSlave? Slave, DataSelection? Selection, object? sender, ListControl? lstMonitor, ConversionHandler.Prefix Prefix) {
            ModbusProperty Appearance = new ModbusProperty();
            Appearance.Prefix = Prefix;
            ModbusPropertyFlags Flags = ModbusPropertyFlags.Prefix;
            ChangeProperty(Slave, Selection, sender, lstMonitor, Appearance, Flags);
        }
        public static void ChangeUnit(ModbusSlave? Slave, DataSelection? Selection, object? sender, ListControl? lstMonitor, string Unit) {
            ModbusProperty Appearance = new ModbusProperty();
            Appearance.Unit = Unit;
            ModbusPropertyFlags Flags = ModbusPropertyFlags.Unit;
            ChangeProperty(Slave, Selection, sender, lstMonitor, Appearance, Flags);
        }
        public static void ChangeSize(ModbusSlave? Slave, DataSelection? Selection, object? sender, ListControl? lstMonitor, DataSize Size) {
            ModbusProperty Appearance = new ModbusProperty();
            Appearance.Size = Size;
            ModbusPropertyFlags Flags = ModbusPropertyFlags.Size;
            ChangeProperty(Slave, Selection, sender, lstMonitor, Appearance, Flags);
        }
        public static void ChangeTextColor(ModbusSlave? Slave, DataSelection? Selection, object? sender, ListControl? lstMonitor, Color ForeColor, bool UseColor) {
            ModbusProperty Appearance = new ModbusProperty();
            Appearance.ForeColor = ForeColor;
            Appearance.UseForeColor = UseColor;
            ModbusPropertyFlags Flags = ModbusPropertyFlags.ForeColor | ModbusPropertyFlags.UseForeColor;
            ChangeProperty(Slave, Selection, sender, lstMonitor, Appearance, Flags);
        }
        public static void ChangeBackColor(ModbusSlave? Slave, DataSelection? Selection, object? sender, ListControl? lstMonitor, Color BackColor, bool UseColor) {
            ModbusProperty Appearance = new ModbusProperty();
            Appearance.BackColor = BackColor;
            Appearance.UseBackColor = UseColor;
            ModbusPropertyFlags Flags = ModbusPropertyFlags.BackColor | ModbusPropertyFlags.UseBackColor;
            ChangeProperty(Slave, Selection, sender, lstMonitor, Appearance, Flags);
        }
        public static void UpdateAppearance(object? sender, ListControl lstMonitor) {
            int SelectedCount = lstMonitor.SelectionCount;
            if (SelectedCount <= 0) { return; }
            foreach (ListItem Li in lstMonitor.CurrentItems) {
                if (Li.SubItems.Count >= Indx_Value) {
                    if (Li.Selected == true) {
                        if (Li.Tag == null) { continue; }
                        if (Li.Tag.GetType() == typeof(ModbusObject)) {
                            ModbusObject Reg = (ModbusObject)Li.Tag;
                            if (Reg.UseBackColor == true) {
                                Li[Indx_Display].BackColor = Reg.BackColor;
                            }
                            if (Reg.UseForeColor == true) {
                                Li[Indx_Display].ForeColor = Reg.ForeColor;
                            }
                        }
                        SelectedCount--;
                    }
                    if (SelectedCount <= 0) {
                        break;
                    }
                }
            }
            lstMonitor.Invalidate();
        }
        private static bool IsPropertyFlagSet(ModbusPropertyFlags Flags, ModbusPropertyFlags FlagToCompare) {
            int SetFlags = (int)Flags;
            return (SetFlags & (int)FlagToCompare) == (int)FlagToCompare;
        }
        private static CancellationTokenSource? _propertyDebounceToken;
        public static void CheckSelectedPropertiesAreEqualAsync(object? lstMonitor, TimeSpan delay) {
            Thread Tr = new Thread(() => CheckSelectedPropertiesAreEqual((ListControl?)lstMonitor));
            Tr.IsBackground = true;
            Tr.Name = "Tr_PropertyChecker";
            Tr.Start();
            //_propertyDebounceToken?.Cancel();
            //_propertyDebounceToken = new CancellationTokenSource();
            //var token = _propertyDebounceToken.Token;
            //_ = Task.Run(async () => {
            //    try {
            //        await Task.Delay(delay, token);
            //        if (!token.IsCancellationRequested) {
            //           _= CheckSelectedPropertiesAreEqualAsyncTask(lstMonitor);
            //        }
            //    }
            //    catch (TaskCanceledException) {
            //    }
            //});
        }
        private static Task CheckSelectedPropertiesAreEqualAsyncTask(object? lstMonitor) {
            return Task.Run(() => CheckSelectedPropertiesAreEqual((ListControl?)lstMonitor));
        }
        public static void CheckSelectedPropertiesAreEqualAsync(ListControl? lstMonitor) {
            Thread Tr = new Thread(() => CheckSelectedPropertiesAreEqual(lstMonitor));
            Tr.IsBackground = true;
            Tr.Name = "Tr_PropertyChecker";
            Tr.Start();
        }
        private static void CheckSelectedPropertiesAreEqual(ListControl? lstMonitor) {
            if (lstMonitor == null) { EditorPropertiesEqual?.Invoke(null, ModbusPropertyFlags.None, new ModbusProperty(), false); return; }
            ModbusPropertyFlags Flags = ModbusPropertyFlags.None;
            Flags = Flags.Add(ModbusPropertyFlags.ForeColor);
            Flags = Flags.Add(ModbusPropertyFlags.BackColor);
            Flags = Flags.Add(ModbusPropertyFlags.UseForeColor);
            Flags = Flags.Add(ModbusPropertyFlags.UseBackColor);
            Flags = Flags.Add(ModbusPropertyFlags.Unit);
            Flags = Flags.Add(ModbusPropertyFlags.Size);
            Flags = Flags.Add(ModbusPropertyFlags.Prefix);
            Flags = Flags.Add(ModbusPropertyFlags.Format);
            Flags = Flags.Add(ModbusPropertyFlags.ByteOrder);
            Flags = Flags.Add(ModbusPropertyFlags.DecimalFormat);
            int i = 0;
            ModbusProperty PreviousProperty = new ModbusProperty();
            if (lstMonitor.SelectionCount <= 0) {
                Flags = ModbusPropertyFlags.None;
                EditorPropertiesEqual?.Invoke(lstMonitor, Flags, PreviousProperty, false);
                return;
            }
            foreach (ListItem Li in lstMonitor.CurrentItems) {
                if (Li.SubItems.Count < Indx_Value) { continue; }
                if (Li.Selected == false) { continue; }
                if (Li.Tag == null) { continue; }

                if (Li.Tag.GetType() == typeof(ModbusRegister)) {
                    ModbusRegister Reg = (ModbusRegister)Li.Tag;
                    if (i == 0) {
                        PreviousProperty.Size = Reg.Size;
                        PreviousProperty.Prefix = Reg.Prefix;
                        PreviousProperty.Unit = Reg.Unit;
                        PreviousProperty.BackColor = Reg.BackColor;
                        PreviousProperty.ForeColor = Reg.ForeColor;
                        PreviousProperty.UseBackColor = Reg.UseBackColor;
                        PreviousProperty.UseForeColor = Reg.UseForeColor;
                        PreviousProperty.Format = Reg.Format;
                        PreviousProperty.WordOrder = Reg.WordOrder;
                        PreviousProperty.DecimalFormat = Reg.DecimalFormat;
                    }
                    else {
                        if (PreviousProperty.Size != Reg.Size) { Flags = Flags.Remove(ModbusPropertyFlags.Size); }
                        if (PreviousProperty.Prefix != Reg.Prefix) { Flags = Flags.Remove(ModbusPropertyFlags.Prefix); }
                        if (PreviousProperty.Unit != Reg.Unit) { Flags = Flags.Remove(ModbusPropertyFlags.Unit); }
                        if (PreviousProperty.UseBackColor != Reg.UseBackColor) { Flags = Flags.Remove(ModbusPropertyFlags.UseBackColor); }
                        if (PreviousProperty.UseForeColor != Reg.UseForeColor) { Flags = Flags.Remove(ModbusPropertyFlags.UseForeColor); }
                        if (PreviousProperty.ForeColor != Reg.ForeColor) { Flags = Flags.Remove(ModbusPropertyFlags.ForeColor); }
                        if (PreviousProperty.BackColor != Reg.BackColor) { Flags = Flags.Remove(ModbusPropertyFlags.BackColor); }
                        if (PreviousProperty.WordOrder != Reg.WordOrder) { Flags = Flags.Remove(ModbusPropertyFlags.ByteOrder); }
                        if (PreviousProperty.Format != Reg.Format) { Flags = Flags.Remove(ModbusPropertyFlags.Format); }
                        if (PreviousProperty.DecimalFormat != Reg.DecimalFormat) { Flags = Flags.Remove(ModbusPropertyFlags.DecimalFormat); }
                    }
                }
                else if (Li.Tag.GetType() == typeof(ModbusCoil)) {
                    ModbusCoil Reg = (ModbusCoil)Li.Tag;
                    if (i == 0) {
                        PreviousProperty.BackColor = Reg.BackColor;
                        PreviousProperty.ForeColor = Reg.ForeColor;
                        PreviousProperty.UseBackColor = Reg.UseBackColor;
                        PreviousProperty.UseForeColor = Reg.UseForeColor;
                        PreviousProperty.CoilFormat = Reg.Format;
                    }
                    else {
                        if (PreviousProperty.UseBackColor != Reg.UseBackColor) { Flags = Flags.Remove(ModbusPropertyFlags.UseBackColor); }
                        if (PreviousProperty.UseForeColor != Reg.UseForeColor) { Flags = Flags.Remove(ModbusPropertyFlags.UseForeColor); }
                        if (PreviousProperty.ForeColor != Reg.ForeColor) { Flags = Flags.Remove(ModbusPropertyFlags.ForeColor); }
                        if (PreviousProperty.BackColor != Reg.BackColor) { Flags = Flags.Remove(ModbusPropertyFlags.BackColor); }
                        if (PreviousProperty.CoilFormat != Reg.Format) { Flags = Flags.Remove(ModbusPropertyFlags.Format); }
                    }
                }
                i++;
            }
            EditorPropertiesEqual?.Invoke(lstMonitor, Flags, PreviousProperty, true);
            GC.Collect();
            return;
        }
    }
    public struct ModbusAppearance {
        public Color ForeColor;
        public Color BackColor;
        public bool UseForeColor;
        public bool UseBackColor;
        public string Unit;
        public ConversionHandler.Prefix Prefix;
        public ModbusAppearance(bool UseForeColor, Color ForeColor, bool UseBackColor, Color BackColor) {
            this.UseForeColor = UseForeColor;
            this.ForeColor = ForeColor;
            this.UseBackColor = UseBackColor;
            this.BackColor = BackColor;
            this.Unit = "";
            this.Prefix = ConversionHandler.Prefix.None;

        }
        public ModbusAppearance(bool UseForeColor, Color ForeColor, bool UseBackColor, Color BackColor, string Unit, ConversionHandler.Prefix Prefix) {
            this.UseForeColor = UseForeColor;
            this.ForeColor = ForeColor;
            this.UseBackColor = UseBackColor;
            this.BackColor = BackColor;
            this.Unit = Unit;
            this.Prefix = Prefix;
        }
    }
    public class ModbusProperty {
        public Color ForeColor;
        public Color BackColor;
        public bool UseForeColor;
        public bool UseBackColor;
        public string Unit = "";
        public ConversionHandler.Prefix Prefix;
        public DataSize Size;
        public DataFormat Format;
        public CoilFormat CoilFormat;
        public ByteOrder WordOrder;
        public FloatFormat DecimalFormat;
    }
    public enum ModbusPropertyFlags {
        None = 0x00,
        ForeColor = 0x01,
        BackColor = 0x02,
        UseForeColor = 0x04,
        UseBackColor = 0x08,
        Unit = 0x10,
        Prefix = 0x20,
        Size = 0x40,
        Format = 0x80,
        ByteOrder = 0x100,
        DecimalFormat = 0x200
    }
}
