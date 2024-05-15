using Handlers;
using Microsoft.Win32;
using ODModules;
using Serial_Monitor.Classes.Enums;
using Serial_Monitor.Classes.Step_Programs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.Enums.FormatEnums;
using static Serial_Monitor.Classes.Enums.ModbusEnums;
using ListControl = ODModules.ListControl;

namespace Serial_Monitor.Classes.Modbus {
    public static class ModbusEditor {
        public const int Indx_Name = 1;
        public const int Indx_Display = 2;
        public const int Indx_Size = 3;
        public const int Indx_Signed = 4;
        public const int Indx_Value = 5;

        public static event ViewUpdatedHandler? ViewUpdated;
        public delegate void ViewUpdatedHandler(ListControl LstControl);

        public static Size MinimumSize = new Size(464, 213);
        #region Loaders
        static bool IsFirstLoad = true;
        public static List<ListItem> MasterRegisterEditor = new List<ListItem>();
        public static void LoadRegisters(ListControl LstControl, SerialManager? CurrentManager, DataSelection DataSet, int SlaveIndex) {
            Thread Tr = new Thread(() => LoadRegistersThreaded(LstControl, CurrentManager, DataSet, SlaveIndex));
            Tr.IsBackground = true;
            Tr.Name = "Tr_RegisterLoader";
            Tr.Start();
        }
        private static void LoadRegistersThreaded(ListControl LstControl, SerialManager? CurrentManager, DataSelection DataSet, int SlaveIndex) {
            if (CurrentManager == null) { return; }
            if (CurrentManager.Registers == null) { return; }
            if (SlaveIndex >= CurrentManager.Slave.Count) { return; }
            if (SlaveIndex < 0) {
                int i = 0;
                if (DataSet == DataSelection.ModbusDataCoils) {
                    foreach (ModbusCoil Coil in CurrentManager.Registers.Coils) {
                        AddMonitorItem(Coil, i); i++;
                    }
                }
                else if (DataSet == DataSelection.ModbusDataDiscreteInputs) {
                    foreach (ModbusCoil Coil in CurrentManager.Registers.DiscreteInputs) {
                        AddMonitorItem(Coil, i); i++;
                    }
                }
                else if (DataSet == DataSelection.ModbusDataInputRegisters) {
                    foreach (ModbusRegister Coil in CurrentManager.Registers.InputRegisters) {
                        AddMonitorItem(Coil, i); i++;
                    }
                }
                else if (DataSet == DataSelection.ModbusDataHoldingRegisters) {
                    foreach (ModbusRegister Coil in CurrentManager.Registers.HoldingRegisters) {
                        AddMonitorItem(Coil, i); i++;
                    }
                }
            }
            else {
                int i = 0;
                if (DataSet == DataSelection.ModbusDataCoils) {
                    foreach (ModbusCoil Coil in CurrentManager.Slave[SlaveIndex].Coils) {
                        AddMonitorItem(Coil, i);
                        i++;
                    }
                }
                else if (DataSet == DataSelection.ModbusDataDiscreteInputs) {
                    foreach (ModbusCoil Coil in CurrentManager.Slave[SlaveIndex].DiscreteInputs) {
                        AddMonitorItem(Coil, i);
                        i++;
                    }
                }
                else if (DataSet == DataSelection.ModbusDataInputRegisters) {
                    foreach (ModbusRegister Coil in CurrentManager.Slave[SlaveIndex].InputRegisters) {
                        AddMonitorItem(Coil, i);
                        i++;
                    }
                }
                else if (DataSet == DataSelection.ModbusDataHoldingRegisters) {
                    foreach (ModbusRegister Coil in CurrentManager.Slave[SlaveIndex].HoldingRegisters) {
                        AddMonitorItem(Coil, i);
                        i++;
                    }
                }
            }
            IsFirstLoad = false;
            //LstControl.Invoke(new MethodInvoker(delegate {

            //}));
            //LstControl.Invalidate();
            ViewUpdate(LstControl);
        }
        public static void ViewUpdate(ListControl LstControl) {
            ViewUpdated?.Invoke(LstControl);
        }
        private static void AddMonitorItem(ModbusCoil Coil, int Index) {
            if (IsFirstLoad) {
                ListItem PLi = new ListItem();
                PLi.Tag = Coil;
                PLi.Value = Index;
                PLi.UseLineBackColor = Coil.UseBackColor;
                PLi.UseLineForeColor = Coil.UseForeColor;
                PLi.LineBackColor = Coil.BackColor;
                PLi.LineForeColor = Coil.ForeColor;
                ListSubItem CLi1 = new ListSubItem(Coil.Name);
                ListSubItem CLi2 = new ListSubItem(EnumManager.CoilFormatToString(Coil.Format).A);
                ListSubItem CLi3 = new ListSubItem();
                ListSubItem CLi4 = new ListSubItem();
                ListSubItem CLi5 = new ListSubItem(Coil.ValueWithUnit);
                PLi.SubItems.Add(CLi1);
                PLi.SubItems.Add(CLi2);
                PLi.SubItems.Add(CLi3);
                PLi.SubItems.Add(CLi4);
                PLi.SubItems.Add(CLi5);
                MasterRegisterEditor.Add(PLi);
            }
            else {
                MasterRegisterEditor[Index].Tag = null;
                MasterRegisterEditor[Index].Tag = Coil;
                MasterRegisterEditor[Index].UseLineBackColor = Coil.UseBackColor;
                MasterRegisterEditor[Index].UseLineForeColor = Coil.UseForeColor;
                MasterRegisterEditor[Index].LineBackColor = Coil.BackColor;
                MasterRegisterEditor[Index].LineForeColor = Coil.ForeColor;
                MasterRegisterEditor[Index][Indx_Name].Text = Coil.Name;
                MasterRegisterEditor[Index][Indx_Display].Text = EnumManager.CoilFormatToString(Coil.Format).A;
                MasterRegisterEditor[Index][Indx_Size].Text = "";
                MasterRegisterEditor[Index][Indx_Signed].Text = "";
                MasterRegisterEditor[Index][Indx_Value].Text = Coil.ValueWithUnit;
            }
        }
        private static void AddMonitorItem(ModbusRegister Register, int Index) {
            if (IsFirstLoad) {
                ListItem PLi = new ListItem();
                PLi.Tag = Register;
                PLi.Value = Index;
                PLi.UseLineBackColor = Register.UseBackColor;
                PLi.UseLineForeColor = Register.UseForeColor;
                PLi.LineBackColor = Register.BackColor;
                PLi.LineForeColor = Register.ForeColor;
                ListSubItem CLi1 = new ListSubItem(Register.Name);
                ListSubItem CLi2 = new ListSubItem(EnumManager.DataFormatToString(Register.Format).A);
                ListSubItem CLi3 = new ListSubItem(EnumManager.DataSizeToString(Register.Size));
                ListSubItem CLi4 = new ListSubItem(Register.Signed);
                ListSubItem CLi5 = new ListSubItem(Register.ValueWithUnit);
                PLi.SubItems.Add(CLi1);
                PLi.SubItems.Add(CLi2);
                PLi.SubItems.Add(CLi3);
                PLi.SubItems.Add(CLi4);
                PLi.SubItems.Add(CLi5);
                MasterRegisterEditor.Add(PLi);
            }
            else {
                MasterRegisterEditor[Index].Tag = null;
                MasterRegisterEditor[Index].Tag = Register;
                MasterRegisterEditor[Index].UseLineBackColor = Register.UseBackColor;
                MasterRegisterEditor[Index].UseLineForeColor = Register.UseForeColor;
                MasterRegisterEditor[Index].LineBackColor = Register.BackColor;
                MasterRegisterEditor[Index].LineForeColor = Register.ForeColor;
                MasterRegisterEditor[Index][Indx_Name].Text = Register.Name;
                MasterRegisterEditor[Index][Indx_Display].Text = EnumManager.DataFormatToString(Register.Format).A;
                MasterRegisterEditor[Index][Indx_Size].Text = EnumManager.DataSizeToString(Register.Size);
                MasterRegisterEditor[Index][Indx_Signed].Checked = Register.Signed;
                MasterRegisterEditor[Index][Indx_Value].Text = Register.ValueWithUnit;
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
        public static void AddValueBox(DropDownClickedEventArgs e, ListControl LstCtrl, DataSelection DataSet, Components.EditValue.ArrowKeyPressedHandler arrowKeyPressed, bool UseItemIndex = false) {
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
                Rectangle Rect = new Rectangle(e.Location, e.ItemSize);
                Rectangle ParRect = new Rectangle(e.ScreenLocation, e.ItemSize);
                Components.EditValue EdVal = new Components.EditValue(reg.FormattedValue, LstCtrl, e.ParentItem, Indx_Value, ItemIndex, reg, Rect, ParRect, DataSet);
                LstCtrl.Controls.Add(EdVal);

                EdVal.ArrowKeyPress += arrowKeyPressed;
                EdVal.Focus();
                EdVal.Show();
            }
        }
        public static void ClearControls(ListControl LstCtrl) {
            LstCtrl.Controls.Clear();
            // GC.Collect();
            Thread Tr = new Thread(PurgeData);
            Tr.IsBackground = true;
            Tr.Start();
        }
        static DateTime PreviousInstance = DateTime.MinValue;
        private static void PurgeData() {
            if (ConversionHandler.DateIntervalDifference(PreviousInstance, DateTime.UtcNow, ConversionHandler.Interval.Millisecond ) >= 1000) {
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
        public static void ShowHideColumns(bool showFormats, DataSelection DataSet, ListControl lstMonitor) {
            if (showFormats == false) {
                lstMonitor.Columns[Indx_Size].Visible = false;
                lstMonitor.Columns[Indx_Signed].Visible = false;
                lstMonitor.Columns[Indx_Display].Visible = false;
                return;
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
        public static void RetroactivelyApplyFormatChanges(int CentreIndex, ListControl lstMonitor) {
            for (int i = 1; i <= 3; i++) {
                int BeforeIndex = CentreIndex - i;
                int AfterIndex = CentreIndex + i;
                if (BeforeIndex >= 0) {
                    Classes.Modbus.ModbusRegister? Itm = GetRegisterFromItem(BeforeIndex, lstMonitor);
                    if (Itm != null) {
                        lstMonitor.Items[BeforeIndex][Indx_Display].Text = EnumManager.DataFormatToString(Itm.Format).A;
                        lstMonitor.Items[BeforeIndex][Indx_Size].Text = EnumManager.DataSizeToString(Itm.Size);
                        lstMonitor.Items[BeforeIndex][Indx_Value].Text = Itm.FormattedValue;
                    }
                }
                if (AfterIndex < lstMonitor.Items.Count) {
                    Classes.Modbus.ModbusRegister? Itm = GetRegisterFromItem(AfterIndex, lstMonitor);
                    if (Itm != null) {
                        lstMonitor.Items[AfterIndex][Indx_Display].Text = EnumManager.DataFormatToString(Itm.Format).A;
                        lstMonitor.Items[AfterIndex][Indx_Size].Text = EnumManager.DataSizeToString(Itm.Size);
                        lstMonitor.Items[AfterIndex][Indx_Value].Text = Itm.FormattedValue;
                    }
                }
            }
        }
        public static Classes.Modbus.ModbusRegister? GetRegisterFromItem(int Index, ListControl lstMonitor) {
            if (Index >= lstMonitor.Items.Count) { return null; }
            if (Index < 0) { return null; }
            object? Data = lstMonitor.Items[Index].Tag;
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
        public static void ChangeCoilFormatList(object? sender, ListControl? lstMonitor) {
            if (lstMonitor == null) { return; }
            object? ButtonData = GetContextMenuItemData(sender);
            if (ButtonData == null) {
                if (sender == null) { return; }
                if (sender.GetType()! != typeof(ModbusEnums.CoilFormat)) { return; }
                ButtonData = sender;
            }
            if (ButtonData.GetType()! != typeof(ModbusEnums.CoilFormat)) {
                return;
            }
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
                            RetroactivelyApplyFormatChanges(Reg.Address, lstMonitor);
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
        public static void ChangeDisplayFormatList(object? sender, ListControl? lstMonitor) {
            if (lstMonitor == null) { return; }
            object? ButtonData = GetContextMenuItemData(sender);
            if (ButtonData == null) {
                if (sender == null) { return; }
                if (sender.GetType()! != typeof(ModbusEnums.DataFormat)) { return; }
                ButtonData = sender;
            }
            if (ButtonData.GetType()! != typeof(ModbusEnums.DataFormat)) {
                return;
            }
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
                            RetroactivelyApplyFormatChanges(Reg.Address, lstMonitor);
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
        public static void ChangeSizeList(object? sender, ListControl? lstMonitor) {
            if (lstMonitor == null) { return; }
            object? ButtonData = GetContextMenuItemData(sender);
            if (ButtonData == null) {
                if (sender == null) { return; }
                if (sender.GetType()! != typeof(ModbusEnums.DataSize)) { return; }
                ButtonData = sender;
            }
            if (ButtonData.GetType()! != typeof(ModbusEnums.DataSize)) { return; }
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
                            RetroactivelyApplyFormatChanges(Reg.Address, lstMonitor);
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
        public static void ChangeSignedList(ListControl? lstMonitor, SignedState State) {
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
                                    case SignedState.Toogle:
                                        Reg.Signed = !Reg.Signed; break;
                                }
                            }
                            Li[Indx_Signed].Checked = Reg.Signed;
                            Li[Indx_Value].Text = Reg.ValueWithUnit;
                            RetroactivelyApplyFormatChanges(Reg.Address, lstMonitor);
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
        public static void ChangeWordOrderList(object? sender, ListControl? lstMonitor) {
            object? ButtonData = GetContextMenuItemData(sender);
            if (ButtonData == null) { return; }
            if (ButtonData.GetType()! != typeof(ModbusEnums.ByteOrder)) {
                if (sender == null) { return; }
                if (sender.GetType()! != typeof(ModbusEnums.ByteOrder)) { return; }
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
                            RetroactivelyApplyFormatChanges(Reg.Address, lstMonitor);
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
                    if (ListEditor.CurrentItems[i].SubItems.Count == 5) {
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
                                Reg.Format = DataFormat.Decimal;
                                Reg.Signed = false;
                            }
                            if (FlagSet(Flags, ModbusClipboardFlags.IncludeSize)) {
                                Reg.Size = DataSize.Bits16;
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
                    if (ListEditor.CurrentItems[i].SubItems.Count == 5) {
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
                    if (ListEditor.CurrentItems[i].SubItems.Count == 5) {
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
        public static void ChangeAppearance(object? sender, ListControl lstMonitor) {
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
    public struct ModbusProperty {
        public Color ForeColor;
        public Color BackColor;
        public bool UseForeColor;
        public bool UseBackColor;
        public string Unit;
        public ConversionHandler.Prefix Prefix;
        public DataSize Size;
    }
    public enum ModbusPropertyFlags {
        None = 0x00,
        ForeColor = 0x01,
        BackColor = 0x02,
        UseForeColor = 0x04,
        UseBackColor = 0x08,
        Unit = 0x10,
        Prefix = 0x20,
        Size = 0x40
    }
}
