using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Enums;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Interfaces;
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
using ListControl = ODModules.ListControl;

namespace Serial_Monitor.ToolWindows {
    public partial class ModbusRegister : Components.MdiClientForm, ITheme {


        Classes.Modbus.ModbusSnapshot? snapshot;
        public Classes.Modbus.ModbusSnapshot? Snapshot {
            get { return snapshot; }
        }
        bool showFormats = true;
        public bool ShowFormats {
            get {
                return showFormats;
            }
            set {
                showFormats = value;
                if (snapshot != null) {
                    ModbusEditor.ShowHideColumns(showFormats, snapshot.Selection, lstRegisters);
                    lstRegisters.Invalidate();
                }
            }
        }

        bool locked = false;
        public bool Locked {
            get {
                return locked;
            }
            set {
                locked = value;
            }
        }
        public ModbusRegister(Classes.Modbus.ModbusSnapshot? snapShot) {
            Intialise(snapShot);
        }
        public ModbusRegister(Classes.Modbus.ModbusSnapshot? snapShot, bool UseBounds) {
            Intialise(snapShot);
            this.StartPosition = FormStartPosition.Manual;
            if (snapShot != null) {
                this.Location = snapShot.Location;
                this.Size = snapShot.Size;
            }
        }
        private void Intialise(Classes.Modbus.ModbusSnapshot? snapShot) {
            InitializeComponent();
            if (snapShot == null) { return; }
            snapshot = snapShot;
            if (lstRegisters.Columns.Count > 0) {
                if (snapshot.SelectionType == Classes.Enums.ModbusEnums.SnapshotSelectionType.Custom) {
                    lstRegisters.Columns[0].DisplayType = ColumnDisplayType.Text;
                }
                lstRegisters.Columns[0].CountOffset = snapshot.StartIndex;
            }
            ModbusEditor.ShowHideColumns(showFormats, snapshot.Selection, lstRegisters);
            lstRegisters.ExternalItems = snapshot.Listings;
            lstRegisters.Invalidate();
            UpdateWindowName();
        }
        private void ModbusRegister_Load(object sender, EventArgs e) {
            AdjustUserInterface();
            ApplyTheme();
            EnumManager.LoadDataFormats(cmDisplayFormats, CmDisplayFormat_Click);
            EnumManager.LoadDataSizes(cmDataSize, CmDisplaySize_Click);
            if (snapshot != null) {
                snapshot.SnapshotRemoved += Snapshot_SnapshotRemoved;
                SystemManager.ModbusReceived += SystemManager_ModbusReceived;
                SystemManager.ChannelRenamed += SystemManager_ChannelRenamed;
                SystemManager.ModbusPropertyChanged += SystemManager_ModbusPropertyChanged;
                SystemManager.ModbusRegisterRenamed += SystemManager_ModbusRegisterRenamed;

                this.GotFocus += ModbusRegister_GotFocus;
                this.LostFocus += ModbusRegister_LostFocus;
                IgnoreBoundsChange = false;
            }
        }

        private void ModbusRegister_LostFocus(object? sender, EventArgs e) {

        }

        private void ModbusRegister_GotFocus(object? sender, EventArgs e) {
            Form? Temp = GetParent();
            if (Temp == null) { return; }
            if (Temp.GetType() == typeof(ModbusRegisters)) {
                ((ModbusRegisters)Temp).GetIndexFromForm(this);
            }

        }

        private void AdjustUserInterface() {
            cmDataSize.Padding = DesignerSetup.ScalePadding(cmDataSize.Padding);
            cmDisplayFormats.Padding = DesignerSetup.ScalePadding(cmDisplayFormats.Padding);
            lstRegisters.ScaleColumnWidths();
        }
        private void SystemManager_ModbusPropertyChanged(ModbusSlave parentManager, object Data, int Index, DataSelection DataType) {
            // lstRegisters.ExternalItems[Index]
            if (snapshot == null) { return; }
            if (snapshot.Manager == null) { return; }
            if (snapshot.Manager.Manager == null) { return; }
            if (parentManager.Manager == null) { return; }
            if (snapshot.Manager.Manager.ID == parentManager.Manager.ID) {
                snapshot.UpdateRow(Index);
                lstRegisters.Invalidate();
            }
        }

        private void SystemManager_ModbusRegisterRenamed(ModbusSlave parentManager, object Data, int Index, DataSelection DataType) {
            if (snapshot == null) { return; }
            if (snapshot.Selection != DataType) { return; }
            if (snapshot.Manager == null) { return; }
            if (snapshot.Manager.Manager == null) { return; }
            if (parentManager.Manager == null) { return; }
            if (snapshot.Manager.Manager.ID == parentManager.Manager.ID) {
                snapshot.RenameFromRegister(Index);
                lstRegisters.Invalidate();
            }
        }

        private void SystemManager_ChannelRenamed(SerialManager sender) {
            if (snapshot == null) { return; }
            if (snapshot.Manager == null) { return; }
            if (snapshot.Manager.Manager == null) { return; }
            if (sender.ID == snapshot.Manager.Manager.ID) {
                UpdateWindowName();
            }
        }
        private void UpdateWindowName() {
            if (snapshot == null) { return; }
            this.Text = snapshot.Name;
        }
        private void SystemManager_ModbusReceived(ModbusSlave parentManager, object Data, int Index, DataSelection DataType) {
            if (snapshot == null) { return; }
            if (snapshot.Selection != DataType) { return; }
            if (snapshot.Manager == null) { return; }
            if (snapshot.Manager.Manager == null) { return; }
            if (parentManager.Manager == null) { return; }
            bool Proceed = false;
            if (parentManager.Manager.IsMaster) {
                if (snapshot.Manager.Address == parentManager.Address) {
                    Proceed = true;
                }
            }
            else {
                Proceed = true;
            }
            if (Proceed) {
                if (snapshot.Manager.Manager.ID == parentManager.Manager.ID) {
                    snapshot.SetValue(Index);
                    lstRegisters.Invalidate();
                }
            }
        }
        private void Snapshot_SnapshotRemoved(object sender) {
            this.Close();
        }

        public void ApplyTheme() {
            this.CloseColor = Properties.Settings.Default.THM_COL_ForeColor;
            this.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            this.BorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            this.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            Classes.Theming.ThemeManager.ThemeControl(lstRegisters);
            Classes.Theming.ThemeManager.ThemeControl(cmDataSize);
            Classes.Theming.ThemeManager.ThemeControl(cmDisplayFormats);
        }

        private void ModbusRegister_FormClosing(object sender, FormClosingEventArgs e) {
            if (snapshot != null) {
                snapshot.SnapshotRemoved -= Snapshot_SnapshotRemoved;
            }
            SystemManager.ModbusReceived -= SystemManager_ModbusReceived;
            SystemManager.ChannelRenamed -= SystemManager_ChannelRenamed;
            SystemManager.ModbusPropertyChanged -= SystemManager_ModbusPropertyChanged;

            EnumManager.ClearClickHandles(cmDisplayFormats, CmDisplayFormat_Click);
            EnumManager.ClearClickHandles(cmDataSize, CmDisplaySize_Click);
            this.GotFocus -= ModbusRegister_GotFocus;
            this.LostFocus -= ModbusRegister_LostFocus;
        }




        private void lstRegisters_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.ParentItem == null) { return; }
            if (e.Column == ModbusEditor.Indx_Name) {
                if (snapshot != null) {
                    ModbusEditor.AddRenameBox(e, lstRegisters, snapshot.Selection, EdVal_ArrowKeyPress, true);
                }
            }
            else if (e.Column == ModbusEditor.Indx_Display) {
                if (DataTag.GetType() == typeof(Classes.Modbus.ModbusRegister)) {
                    ModbusEditor.CheckItem(cmDisplayFormats, ((Classes.Modbus.ModbusRegister)DataTag).Format);
                    cmDisplayFormats.Tag = e;
                    cmDisplayFormats.Show(ModbusEditor.AddPoint(e));
                }
            }
            else if (e.Column == ModbusEditor.Indx_Size) {
                if (DataTag.GetType() == typeof(Classes.Modbus.ModbusRegister)) {
                    ModbusEditor.CheckItem(cmDataSize, ((Classes.Modbus.ModbusRegister)DataTag).Size);
                    cmDataSize.Tag = e;
                    cmDataSize.Show(ModbusEditor.AddPoint(e));
                }
            }
            else if (e.Column == ModbusEditor.Indx_Value) {
                if (locked == true) { return; }
                if (snapshot.Manager == null) { return; }
                if (snapshot.Manager.Manager == null) { return; }
                if (DataTag.GetType() == typeof(Classes.Modbus.ModbusCoil)) {
                    Classes.Modbus.ModbusCoil coil = (Classes.Modbus.ModbusCoil)DataTag;
                    if (snapshot != null) {
                        if (ModbusEditor.CanChangeValue(snapshot.Manager.Manager, coil.ComponentType) == false) { return; }
                        coil.Value = !coil.Value;

                        LstItem[ModbusEditor.Indx_Value].Text = coil.Value.ToString();
                        if (ModbusSupport.SendOnChange == false) { return; }
                        SystemManager.SendModbusCommand(snapshot.Manager, snapshot.Selection, "Write Coil " + e.ParentItem.Value.ToString() + " = " + coil.Value.ToString());
                    }
                }
                else if (DataTag.GetType() == typeof(Classes.Modbus.ModbusRegister)) {
                    if (snapshot != null) {
                        if (ModbusEditor.CanChangeValue(snapshot.Manager.Manager, ((Classes.Modbus.ModbusRegister)DataTag).ComponentType) == false) { return; }
                        ModbusEditor.AddValueBox(e, lstRegisters, snapshot.Selection, EdVal_ArrowKeyPress, true);
                    }
                }
            }
        }
        bool IgnoreBoundsChange = true;
        private void ModbusRegister_SizeChanged(object sender, EventArgs e) {
            if (IgnoreBoundsChange) { return; }
            if (snapshot != null) {
                snapshot.Size = this.Size;
            }
        }
        private void ModbusRegister_Move(object sender, EventArgs e) {
            if (IgnoreBoundsChange) { return; }
            if (snapshot == null) { return; }
            snapshot.Location = this.Location;
        }

        private void ModbusRegister_CloseButtonClicked(object sender) {
            if (snapshot != null) {
                ModbusSupport.RemoveSnapshot(snapshot);
            }
            this.Close();
            ModbusSupport.SnapshotClosedApp();
        }
        private void EdVal_ArrowKeyPress(bool IsUp) {
            if (IsUp == false) {

            }
        }


        private void CmDisplayFormat_Click(object? sender, EventArgs e) {
            object? ButtonData = ModbusEditor.GetContextMenuItemData(sender);
            object? Data = ModbusEditor.GetContextMenuData(sender);
            if (Data == null) { return; }
            if (ButtonData == null) { return; }
            if (ButtonData.GetType()! != typeof(ModbusEnums.DataFormat)) { return; }
            DataFormat Frmt = (DataFormat)ButtonData;
            if (Data.GetType() == typeof(DropDownClickedEventArgs)) {
                DropDownClickedEventArgs Args = (DropDownClickedEventArgs)Data;
                if (Args.ParentItem == null) { return; }
                if (Args.ParentItem.Tag == null) { return; }
                if (Args.ParentItem.Tag.GetType() == typeof(Classes.Modbus.ModbusRegister)) {
                    Classes.Modbus.ModbusRegister Reg = (Classes.Modbus.ModbusRegister)Args.ParentItem.Tag;
                    Reg.Format = Frmt;
                    Args.ParentItem[Args.Column].Text = EnumManager.DataFormatToString(Reg.Format).A;
                    Args.ParentItem[ModbusEditor.Indx_Size].Text = EnumManager.DataSizeToString(Reg.Size);
                    Args.ParentItem[ModbusEditor.Indx_Value].Text = Reg.FormattedValue;
                    ModbusEditor.RetroactivelyApplyFormatChanges(Args.Item, lstRegisters);
                    lstRegisters.Invalidate();
                }
            }
        }
        private void CmDisplaySize_Click(object? sender, EventArgs e) {
            object? ButtonData = ModbusEditor.GetContextMenuItemData(sender);
            object? Data = ModbusEditor.GetContextMenuData(sender);
            if (Data == null) { return; }
            if (ButtonData == null) { return; }
            if (ButtonData.GetType()! != typeof(ModbusEnums.DataSize)) { return; }
            DataSize Frmt = (DataSize)ButtonData;
            if (Data.GetType() == typeof(DropDownClickedEventArgs)) {
                DropDownClickedEventArgs Args = (DropDownClickedEventArgs)Data;
                if (Args.ParentItem == null) { return; }
                if (Args.ParentItem.Tag == null) { return; }
                if (Args.ParentItem.Tag.GetType() == typeof(Classes.Modbus.ModbusRegister)) {
                    Classes.Modbus.ModbusRegister Reg = (Classes.Modbus.ModbusRegister)Args.ParentItem.Tag;
                    Reg.Size = Frmt;
                    Args.ParentItem[Args.Column].Text = EnumManager.DataSizeToString(Reg.Size);
                    Args.ParentItem[ModbusEditor.Indx_Display].Text = EnumManager.DataFormatToString(Reg.Format).A;
                    Args.ParentItem[ModbusEditor.Indx_Value].Text = Reg.FormattedValue;
                    ModbusEditor.RetroactivelyApplyFormatChanges(Args.Item, lstRegisters);
                    lstRegisters.Invalidate();
                }
            }
        }

        private void lstRegisters_ItemClicked(object sender, ListItem Item, int Index, Rectangle ItemBounds) {

        }

        private void lstRegisters_ItemCheckedChanged(object sender, ItemCheckedChangeEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.Column == ModbusEditor.Indx_Signed) {
                if (DataTag.GetType() == typeof(Classes.Modbus.ModbusRegister)) {
                    Classes.Modbus.ModbusRegister Reg = (Classes.Modbus.ModbusRegister)DataTag;
                    Reg.Signed = e.Checked;
                    LstItem[ModbusEditor.Indx_Value].Text = Reg.FormattedValue;
                    lstRegisters.Invalidate();
                }
            }
        }

        private void ModbusRegister_Activated(object sender, EventArgs e) {

        }
        private Form? GetParent() {
            Form? Frm = this.FindForm();
            //Control ?Temp = this.Parent;
            //while(Temp != null) {
            //    if (Temp.GetType() == typeof(System.Windows.Forms.Form)) {  return (Form)Temp; }
            //    Temp = Temp.Parent;
            //}
            //return null;
            return Frm;
        }
    }
}
