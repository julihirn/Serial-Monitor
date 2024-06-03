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
using static Serial_Monitor.Classes.Enums.ControlEnums;
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
                    ModbusEditor.ShowHideColumns(showFormats, showLastUpdated, snapshot.Selection, lstRegisters);
                    lstRegisters.Invalidate();
                }
            }
        }
        bool showLastUpdated = false;
        public bool ShowLastUpdated {
            get {
                return showLastUpdated;
            }
            set {
                showLastUpdated = value;
                if (snapshot != null) {
                    ModbusEditor.ShowHideColumns(showFormats, showLastUpdated, snapshot.Selection, lstRegisters);
                    lstRegisters.Invalidate();
                }
            }
        }
        bool showUnits = true;
        public bool ShowUnits {
            get {
                return showUnits;
            }
            set {
                showUnits = value;
                if (snapshot != null) {
                    snapshot.ShowUnits = showUnits;
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
            snapshot.SnapshotRenamed += Snapshot_SnapshotRenamed;
            if (lstRegisters.Columns.Count > 0) {
                if (snapshot.SelectionType == Classes.Enums.ModbusEnums.SnapshotSelectionType.Custom) {
                    lstRegisters.Columns[0].DisplayType = ColumnDisplayType.Text;
                }
                lstRegisters.Columns[0].CountOffset = snapshot.StartIndex;
            }
            ModbusEditor.ShowHideColumns(showFormats, showLastUpdated, snapshot.Selection, lstRegisters);
            lstRegisters.ExternalItems = snapshot.Listings;
            lstRegisters.Invalidate();
            UpdateWindowName();
        }
        private void Snapshot_SnapshotRenamed(object sender) {
            UpdateWindowName();
        }
        private void ModbusRegister_Load(object sender, EventArgs e) {
            AdjustUserInterface();
            ApplyTheme();
            EnumManager.LoadCoilFormats(cmCoilFormats, CmCoilFormat_Click);
            EnumManager.LoadDataFormats(cmDisplayFormats, CmDisplayFormat_Click);
            EnumManager.LoadDataSizes(cmDataSize, CmDisplaySize_Click);
            if (snapshot != null) {
                snapshot.SnapshotRemoved += Snapshot_SnapshotRemoved;
                SystemManager.ModbusReceived += SystemManager_ModbusReceived;
                SystemManager.ChannelRenamed += SystemManager_ChannelRenamed;
                SystemManager.ModbusPropertyChanged += SystemManager_ModbusPropertyChanged;
                SystemManager.ModbusRegisterRenamed += SystemManager_ModbusRegisterRenamed;
                SystemManager.ModbusAppearanceChanged += SystemManager_ModbusAppearanceChanged;
                SystemManager.ModbusPropertiesChanged += SystemManager_ModbusPropertiesChanged;
                //this.GotFocus += ModbusRegister_GotFocus;
                //this.LostFocus += ModbusRegister_LostFocus;
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
            if (snapshot.Manager.Channel == null) { return; }
            if (parentManager.Channel == null) { return; }
            if (snapshot.Manager.Channel.ID == parentManager.Channel.ID) {
                snapshot.UpdateRow(Index);
                lstRegisters.Invalidate();
            }
        }
        private void SystemManager_ModbusRegisterRenamed(ModbusSlave parentManager, object Data, int Index, DataSelection DataType) {
            if (snapshot == null) { return; }
            if (snapshot.Selection != DataType) { return; }
            if (snapshot.Manager == null) { return; }
            if (snapshot.Manager.Channel == null) { return; }
            if (parentManager.Channel == null) { return; }
            if (snapshot.Manager.Channel.ID == parentManager.Channel.ID) {
                snapshot.RenameFromRegister(Index);
                lstRegisters.Invalidate();
            }
        }
        private void SystemManager_ModbusAppearanceChanged(ModbusSlave sender, List<int> Indices, DataSelection DataType) {
            if (snapshot == null) { return; }
            if (snapshot.Manager == null) { return; }
            if (snapshot.Manager.Channel == null) { return; }
            if (sender.Channel == null) { return; }
            if (snapshot.Manager.Channel.ID != sender.Channel.ID) { return; }
            foreach (int i in Indices) {
                snapshot.UpdateRowAppearance(i);
            }
            lstRegisters.Invalidate();
        }
        private void SystemManager_ModbusPropertiesChanged(ModbusSlave sender, List<int> Indices, DataSelection DataType) {
            Thread Tr = new Thread(() => ApplyProperties(sender, Indices, DataType));
            Tr.Name = "ModbusProp_Apply";
            Tr.IsBackground = true;
            Tr.Start();
        }
        private void ApplyProperties(ModbusSlave sender, List<int> Indices, DataSelection DataType) {
            if (snapshot == null) { return; }
            if (snapshot.Manager == null) { return; }
            if (snapshot.Manager.Channel == null) { return; }
            if (sender.Channel == null) { return; }
            if (snapshot.Manager.Channel.ID != sender.Channel.ID) { return; }
            foreach (int i in Indices) {
                snapshot.UpdateRowAppearance(i);
            }
            this.BeginInvoke(new MethodInvoker(delegate {
                this.lstRegisters.Invalidate();
            }));
        }
        private void SystemManager_ChannelRenamed(SerialManager sender) {
            if (snapshot == null) { return; }
            if (snapshot.Manager == null) { return; }
            if (snapshot.Manager.Channel == null) { return; }
            if (sender.ID == snapshot.Manager.Channel.ID) {
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
            if (snapshot.Manager.Channel == null) { return; }
            if (parentManager.Channel == null) { return; }
            bool Proceed = false;
            if (parentManager.Channel.IsMaster) {
                if (snapshot.Manager.Address == parentManager.Address) {
                    Proceed = true;
                }
            }
            else {
                Proceed = true;
            }
            if (Proceed) {
                if (snapshot.Manager.Channel.ID == parentManager.Channel.ID) {
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
            this.SelectedBorderColor = Properties.Settings.Default.THM_COL_SelectedColor;
            Classes.Theming.ThemeManager.ThemeControl(lstRegisters);
            Classes.Theming.ThemeManager.ThemeControl(cmDataSize);
            Classes.Theming.ThemeManager.ThemeControl(cmDisplayFormats);
            Classes.Theming.ThemeManager.ThemeControl(cmCoilFormats);
        }

        private void ModbusRegister_FormClosing(object sender, FormClosingEventArgs e) {
            if (snapshot != null) {
                snapshot.SnapshotRemoved -= Snapshot_SnapshotRemoved;
            }
            snapshot.SnapshotRenamed -= Snapshot_SnapshotRenamed;
            SystemManager.ModbusRegisterRenamed -= SystemManager_ModbusRegisterRenamed;
            SystemManager.ModbusAppearanceChanged -= SystemManager_ModbusAppearanceChanged;
            SystemManager.ModbusReceived -= SystemManager_ModbusReceived;
            SystemManager.ChannelRenamed -= SystemManager_ChannelRenamed;
            SystemManager.ModbusPropertyChanged -= SystemManager_ModbusPropertyChanged;
            SystemManager.ModbusPropertiesChanged -= SystemManager_ModbusPropertiesChanged;
            EnumManager.ClearClickHandles(cmCoilFormats, CmCoilFormat_Click);
            EnumManager.ClearClickHandles(cmDisplayFormats, CmDisplayFormat_Click);
            EnumManager.ClearClickHandles(cmDataSize, CmDisplaySize_Click);
            //this.GotFocus -= ModbusRegister_GotFocus;
            //this.LostFocus -= ModbusRegister_LostFocus;
        }




        private void lstRegisters_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.ParentItem == null) { return; }
            if (snapshot == null) { return; }
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
                else if (DataTag.GetType() == typeof(ModbusCoil)) {
                    ModbusEditor.CheckItem(cmCoilFormats, ((ModbusCoil)DataTag).Format);
                    cmCoilFormats.Tag = e;
                    cmCoilFormats.Show(ModbusEditor.AddPoint(e));
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
                if (snapshot.Manager.Channel == null) { return; }
                if (DataTag.GetType() == typeof(Classes.Modbus.ModbusCoil)) {
                    Classes.Modbus.ModbusCoil coil = (Classes.Modbus.ModbusCoil)DataTag;
                    if (snapshot != null) {
                        if (ModbusEditor.CanChangeValue(snapshot.Manager.Channel, coil.ComponentType) == false) { return; }
                        coil.Value = !coil.Value;

                        LstItem[ModbusEditor.Indx_Value].Text = coil.ValueWithUnit;
                        if (ModbusSupport.SendOnChange == false) { return; }
                        SystemManager.SendModbusCommand(snapshot.Manager, snapshot.Selection, "Write Coil " + e.ParentItem.Value.ToString() + " = " + coil.Value.ToString());
                    }
                }
                else if (DataTag.GetType() == typeof(Classes.Modbus.ModbusRegister)) {
                    if (snapshot != null) {
                        if (ModbusEditor.CanChangeValue(snapshot.Manager.Channel, ((Classes.Modbus.ModbusRegister)DataTag).ComponentType) == false) { return; }
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
            ForceClose();
        }
        public void ForceClose() {
            if (snapshot != null) {
                ModbusSupport.RemoveSnapshot(snapshot);
            }
            this.Close();
            ModbusSupport.SnapshotClosedApp();
        }
        public void FormClose() {
            this.Close();
            ModbusSupport.SnapshotClosedApp();
        }
        private void EdVal_ArrowKeyPress(ControlEnums.ArrowKey Direction) {
            if (Direction == ArrowKey.Down) {
                lstRegisters.SelectNextDropDown();
            }
            else if (Direction == ArrowKey.Up) {
                lstRegisters.SelectPreviousDropDown();
            }
        }

        private void CmCoilFormat_Click(object? sender, EventArgs e) {
            object? ButtonData = ModbusEditor.GetContextMenuItemData(sender);
            object? Data = ModbusEditor.GetContextMenuData(sender);
            if (Data == null) { return; }
            if (ButtonData == null) { return; }
            if (ButtonData.GetType()! != typeof(ModbusEnums.CoilFormat)) { return; }
            CoilFormat Frmt = (CoilFormat)ButtonData;
            if (Data.GetType() == typeof(DropDownClickedEventArgs)) {
                DropDownClickedEventArgs Args = (DropDownClickedEventArgs)Data;
                if (Args.ParentItem == null) { return; }
                if (Args.ParentItem.Tag == null) { return; }
                if (Args.ParentItem.Tag.GetType() == typeof(ModbusCoil)) {
                    ModbusCoil Reg = (ModbusCoil)Args.ParentItem.Tag;
                    Reg.Format = Frmt;
                    Args.ParentItem[Args.Column].Text = EnumManager.CoilFormatToString(Reg.Format).A;
                    Args.ParentItem[ModbusEditor.Indx_Value].Text = Reg.ValueWithUnit;
                    Args.ParentItem[ModbusEditor.Indx_LastUpdated].Text = Reg.GetLastUpdatedTime();
                    lstRegisters.Invalidate();
                }
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
                    Args.ParentItem[ModbusEditor.Indx_LastUpdated].Text = Reg.GetLastUpdatedTime();
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
                    Args.ParentItem[ModbusEditor.Indx_LastUpdated].Text = Reg.GetLastUpdatedTime();
                    ModbusEditor.RetroactivelyApplyFormatChanges(Args.Item, lstRegisters);
                    lstRegisters.Invalidate();
                }
            }
        }

        private void lstRegisters_ItemClicked(object sender, ListItem Item, int Index, Rectangle ItemBounds) {

        }

        private void lstRegisters_ItemCheckedChanged(object sender, ItemCheckedChangeEventArgs e) {
            if (snapshot == null) { return; }
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.Column == ModbusEditor.Indx_Signed) {
                if (DataTag.GetType() == typeof(Classes.Modbus.ModbusRegister)) {
                    Classes.Modbus.ModbusRegister Reg = (Classes.Modbus.ModbusRegister)DataTag;
                    Reg.Signed = e.Checked;
                    //LstItem[ModbusEditor.Indx_Value].Text = Reg.FormattedValue;
                    snapshot.UpdateRow(e.Item);
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

        private void lstRegisters_SelectionChanged(object sender, SelectedItemsEventArgs e) {
            ModbusEditor.CheckSelectedPropertiesAreEqualAsync(sender);
        }
    }
}
