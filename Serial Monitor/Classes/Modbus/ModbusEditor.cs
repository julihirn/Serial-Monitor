using ODModules;
using Serial_Monitor.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.Enums.ModbusEnums;
using ListControl = ODModules.ListControl;

namespace Serial_Monitor.Classes.Modbus {
    public static class ModbusEditor {
        public const int Indx_Name = 1;
        public const int Indx_Display = 2;
        public const int Indx_Size = 3;
        public const int Indx_Signed = 4;
        public const int Indx_Value = 5;

        public static Size MinimumSize = new Size(464, 213);

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

        public static Point AddPoint(DropDownClickedEventArgs e) {
            return new Point(e.ScreenLocation.X, e.ScreenLocation.Y + e.ItemSize.Height);
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
    }
}
