using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Enums;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.Enums.ModbusEnums;
using ListControl = ODModules.ListControl;

namespace Serial_Monitor {
    public partial class ModbusRegisters : Form, Interfaces.ITheme {
        public Form? Attached = null;

        const int Indx_Name = 1;
        const int Indx_Display = 2;
        const int Indx_Size = 3;
        const int Indx_Signed = 4;
        const int Indx_Value = 5;

        public ModbusRegisters() {
            InitializeComponent();
            tbDataPages.DebugMode = false;
        }
        bool showFormats = true;
        public bool ShowFormats {
            get {
                return showFormats;
            }
            set {
                showFormatsToolStripMenuItem.Checked = value;
                showFormats = value;
                ShowHideColumns();
            }
        }
        private void ModbusRegisters_Load(object sender, EventArgs e) {
            //if (Attached != null) {
            //    if (Attached.GetType() == typeof(Form1)) {
            //        ((Form1)Attached).
            //    }
            //}
            EnumManager.LoadDataFormats(cmDisplayFormats, CmDisplayFormat_Click);
            EnumManager.LoadDataSizes(cmDataSize, CmDisplaySize_Click);
            EnumManager.LoadDataFormats(ddbDisplayFormat, CmDisplayFormatList_Click);
            EnumManager.LoadDataSizes(ddpDataSize, CmDisplaySizeList_Click);
            RecolorAll();
            AddIcons();
            SystemManager.ChannelAdded += SystemManager_ChannelAdded;
            SystemManager.ChannelRemoved += SystemManager_ChannelRemoved;
            SystemManager.ChannelRenamed += SystemManager_ChannelRenamed;
            SystemManager.ModbusReceived += SystemManager_ModbusReceived;
            SystemManager.ModbusRegisterRenamed += SystemManager_ModbusRegisterRenamed;
            ProjectManager.DocumentLoaded += ProjectManager_DocumentLoaded;
            navigator1.LinkedList = SystemManager.SerialManagers;
            navigator1.SelectedItem = 0;
            navigator1.Invalidate();
            try {
                CurrentManager = SystemManager.SerialManagers[0];
            }
            catch { }
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            LoadRegisters();
            lstMonitor.ScaleColumnWidths();
            mdiClient.MdiForm.MainMenuStrip = msMain;
            LoadForms();
        }
        private void CmDisplayFormatList_Click(object? sender, EventArgs e) {
            object? ButtonData = GetContextMenuItemData(sender);
            if (ButtonData == null) { return; }
            if (ButtonData.GetType()! != typeof(ModbusEnums.DataFormat)) { return; }
            DataFormat Frmt = (DataFormat)ButtonData;

            int SelectedCount = lstMonitor.SelectionCount;
            if (SelectedCount <= 0) { return; }
            foreach (ListItem Li in lstMonitor.Items) {
                if (Li.SubItems.Count >= Indx_Value) {
                    if (Li.Selected == true) {
                        if (Li.Tag == null) { continue; }
                        if (Li.Tag.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)Li.Tag;
                            Reg.Format = Frmt;
                            Li[Indx_Display].Text = EnumManager.DataFormatToString(Reg.Format).A;
                            Li[Indx_Size].Text = EnumManager.DataSizeToString(Reg.Size);
                            Li[Indx_Value].Text = Reg.FormattedValue;
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
        private void CmDisplayFormat_Click(object? sender, EventArgs e) {
            object? ButtonData = GetContextMenuItemData(sender);
            object? Data = GetContextMenuData(sender);
            if (Data == null) { return; }
            if (ButtonData == null) { return; }
            if (ButtonData.GetType()! != typeof(ModbusEnums.DataFormat)) { return; }
            DataFormat Frmt = (DataFormat)ButtonData;
            if (Data.GetType() == typeof(DropDownClickedEventArgs)) {
                DropDownClickedEventArgs Args = (DropDownClickedEventArgs)Data;
                if (Args.ParentItem == null) { return; }
                if (Args.ParentItem.Tag == null) { return; }
                if (Args.ParentItem.Tag.GetType() == typeof(ModbusRegister)) {
                    ModbusRegister Reg = (ModbusRegister)Args.ParentItem.Tag;
                    Reg.Format = Frmt;
                    Args.ParentItem[Args.Column].Text = EnumManager.DataFormatToString(Reg.Format).A;
                    Args.ParentItem[Indx_Size].Text = EnumManager.DataSizeToString(Reg.Size);
                    Args.ParentItem[Indx_Value].Text = Reg.FormattedValue;
                    lstMonitor.Invalidate();
                }
            }
        }
        private void CmDisplaySize_Click(object? sender, EventArgs e) {
            object? ButtonData = GetContextMenuItemData(sender);
            object? Data = GetContextMenuData(sender);
            if (Data == null) { return; }
            if (ButtonData == null) { return; }
            if (ButtonData.GetType()! != typeof(ModbusEnums.DataSize)) { return; }
            DataSize Frmt = (DataSize)ButtonData;
            if (Data.GetType() == typeof(DropDownClickedEventArgs)) {
                DropDownClickedEventArgs Args = (DropDownClickedEventArgs)Data;
                if (Args.ParentItem == null) { return; }
                if (Args.ParentItem.Tag == null) { return; }
                if (Args.ParentItem.Tag.GetType() == typeof(ModbusRegister)) {
                    ModbusRegister Reg = (ModbusRegister)Args.ParentItem.Tag;
                    Reg.Size = Frmt;
                    Args.ParentItem[Args.Column].Text = EnumManager.DataSizeToString(Reg.Size);
                    Args.ParentItem[Indx_Display].Text = EnumManager.DataFormatToString(Reg.Format).A;
                    Args.ParentItem[Indx_Value].Text = Reg.FormattedValue;
                    lstMonitor.Invalidate();
                }
            }
        }
        private void CmDisplaySizeList_Click(object? sender, EventArgs e) {
            object? ButtonData = GetContextMenuItemData(sender);
            if (ButtonData == null) { return; }
            if (ButtonData.GetType()! != typeof(ModbusEnums.DataSize)) { return; }
            DataSize Frmt = (DataSize)ButtonData;

            int SelectedCount = lstMonitor.SelectionCount;
            if (SelectedCount <= 0) { return; }
            foreach (ListItem Li in lstMonitor.Items) {
                if (Li.SubItems.Count >= Indx_Value) {
                    if (Li.Selected == true) {
                        if (Li.Tag == null) { continue; }
                        if (Li.Tag.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)Li.Tag;
                            Reg.Size = Frmt;
                            Li[Indx_Size].Text = EnumManager.DataSizeToString(Reg.Size);
                            Li[Indx_Display].Text = EnumManager.DataFormatToString(Reg.Format).A;
                            Li[Indx_Value].Text = Reg.FormattedValue;
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
        private object? GetContextMenuData(object? sender) {
            if (sender == null) { return null; }
            if (sender.GetType() != typeof(ToolStripMenuItem)) { return null; }
            ToolStripMenuItem Mi = (ToolStripMenuItem)sender;
            if (Mi.Owner == null) { return null; }
            if (Mi.Owner.GetType() != typeof(ContextMenu)) { return null; }
            ContextMenu Menu = (ContextMenu)Mi.Owner;
            return Menu.Tag;
        }
        private object? GetContextMenuItemData(object? sender) {
            if (sender == null) { return null; }
            if (sender.GetType() != typeof(ToolStripMenuItem)) { return null; }
            ToolStripMenuItem Mi = (ToolStripMenuItem)sender;
            return Mi.Tag;
        }
        private void LoadForms() {
            foreach (ModbusSnapshot Snap in ModbusSupport.Snapshots) {
                ToolWindows.ModbusRegister frm = new ToolWindows.ModbusRegister(Snap, true);
                mdiClient.AddChild(frm);
            }
        }
        private void SystemManager_ModbusRegisterRenamed(object Data, int Index, DataSelection DataType) {
            if (Data == null) { return; }
            if (Data.GetType() == typeof(ModbusCoil)) {
                if (DataSet == DataType) {
                    ModbusCoil DigitalData = (ModbusCoil)Data;
                    if (ItemInBounds(Index, 1)) {
                        lstMonitor.Items[Index][Indx_Name].Text = DigitalData.Name.ToString();
                    }
                }
            }
            else if (Data.GetType() == typeof(ModbusRegister)) {
                if (DataSet == DataType) {
                    ModbusRegister DigitalData = (ModbusRegister)Data;
                    if (ItemInBounds(Index, 1)) {
                        lstMonitor.Items[Index][Indx_Name].Text = DigitalData.Name.ToString();
                    }
                }
            }
            navigator1.Invalidate();
        }
        private void SystemManager_ChannelRenamed(SerialManager sender) {
            navigator1.Invalidate();

        }
        private void ProjectManager_DocumentLoaded() {
            navigator1.SelectedItem = 0;
            CurrentManager = SystemManager.SerialManagers[0];
            LoadRegisters();
           
            LoadForms();
        }
        #region Theme
        public void ApplyTheme() {

            RecolorAll();
            AddIcons();
        }
        private void RecolorAll() {
            ApplicationManager.IsDark = Properties.Settings.Default.THM_SET_IsDark;
            this.SuspendLayout();
            BackColor = Properties.Settings.Default.THM_COL_Editor;

            Classes.Theming.ThemeManager.ThemeControl(thDataPagesHeader);
            Classes.Theming.ThemeManager.ThemeControl(msMain);
            Classes.Theming.ThemeManager.ThemeControl(tsMain);
            Classes.Theming.ThemeManager.ThemeControl(lstMonitor);
            Classes.Theming.ThemeManager.ThemeControl(tbDataPages);
            Classes.Theming.ThemeManager.ThemeControl(navigator1);

            Classes.Theming.ThemeManager.ThemeControl(cmDataSize);
            Classes.Theming.ThemeManager.ThemeControl(cmDisplayFormats);
            Classes.Theming.ThemeManager.ThemeControl(cmMonitor);
            mdiClient.BackColor = Properties.Settings.Default.THM_COL_Editor;
            this.ResumeLayout();
        }
        #endregion
        bool LockedEditor = false;
        public void AddIcons() {
            DesignerSetup.LinkSVGtoControl(Properties.Resources.BooleanData, btnCoils, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.BooleanData, btnDiscrete, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.DomainType, btnHolding, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.DomainType, btnInputRegisters, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.BringForward, btnMenuTopMost, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.NewItem, newToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.ApplyCodeChanges, btnApplyOnClick, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            ChangeLockedIcon(LockedEditor);
        }
        private void SystemManager_ChannelAdded(int RemovedIndex) {
            navigator1.Invalidate();
        }
        private void SystemManager_ChannelRemoved(int RemovedIndex) {
            if (navigator1.SelectedItem >= navigator1.ItemCount) {
                navigator1.SelectedItem -= 1;
            }
            else {
                navigator1.Invalidate();
            }
        }
        private void ChangeLockedIcon(bool Input) {
            if (Input == true) {
                DesignerSetup.LinkSVGtoControl(Properties.Resources.Lock, btnLockEditor, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
                btnLockEditor.Text = "Lock Editor";
            }
            else {
                DesignerSetup.LinkSVGtoControl(Properties.Resources.Unlock, btnLockEditor, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
                btnLockEditor.Text = "Unlock Editor";
            }
        }

        SerialManager? CurrentManager = null;
        DataSelection dataSet = DataSelection.ModbusDataCoils;
        DataSelection DataSet {
            get { return dataSet; }
            set {
                dataSet = value;
                lblTypeSelection.Text = EnumManager.ModbusDataSelectionToString(value).A;
                if (value == DataSelection.ModbusDataCoils) {
                    btnDiscrete.Checked = false;
                    btnHolding.Checked = false;
                    btnCoils.Checked = true;
                    btnInputRegisters.Checked = false;
                }
                else if (value == DataSelection.ModbusDataDiscreteInputs) {
                    btnDiscrete.Checked = true;
                    btnHolding.Checked = false;
                    btnCoils.Checked = false;
                    btnInputRegisters.Checked = false;
                }
                else if (value == DataSelection.ModbusDataInputRegisters) {
                    btnDiscrete.Checked = false;
                    btnHolding.Checked = false;
                    btnCoils.Checked = false;
                    btnInputRegisters.Checked = true;
                }
                else if (value == DataSelection.ModbusDataHoldingRegisters) {
                    btnDiscrete.Checked = false;
                    btnHolding.Checked = true;
                    btnCoils.Checked = false;
                    btnInputRegisters.Checked = false;
                }
                if (value > DataSelection.ModbusDataDiscreteInputs) {
                    ddbDisplayFormat.Enabled = true;
                    ddpDataSize.Enabled = true;
                }
                else {
                    ddbDisplayFormat.Enabled = false;
                    ddpDataSize.Enabled = false;
                }
                ClearEditors();
                ShowHideColumns();
                LoadRegisters();
                CheckModbusDataSelection();
            }
        }
        private void ClearEditors() {
            foreach (Control ctrl in lstMonitor.Controls) {
                if (ctrl.GetType() == typeof(Components.EditValue)) {
                    ((Components.EditValue)ctrl).PushValue();
                }
            }
        }
        private void CheckModbusDataSelection() {
            string DataView = EnumManager.ModbusDataSelectionToString(DataSet).B;
            foreach (ToolStripItem Tsi in viewToolStripMenuItem.DropDownItems) {
                if (Tsi.Tag != null) {
                    string TagData = Tsi.Tag.ToString() ?? "";
                    if (TagData.StartsWith("mbType")) {
                        if (TagData == DataView) {
                            ((ToolStripMenuItem)Tsi).Checked = true;
                        }
                        else {
                            ((ToolStripMenuItem)Tsi).Checked = false;
                        }
                    }
                }
            }
        }
        private void navigator1_SelectedIndexChanged(object sender, int SelectedIndex) {
            if (SystemManager.SerialManagers.Count > 0) {
                if ((SelectedIndex >= 0) && (SelectedIndex < SystemManager.SerialManagers.Count)) {
                    CurrentManager = SystemManager.SerialManagers[SelectedIndex];
                    LoadRegisters();
                }
            }
        }
        private void ShowHideColumns() {
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
        private void LoadRegisters() {
            lstMonitor.LineRemoveAll();
            if (CurrentManager == null) { return; }
            if (DataSet == DataSelection.ModbusDataCoils) {
                foreach (ModbusCoil Coil in CurrentManager.Coils) {
                    AddMonitorItem(Coil);
                }
            }
            else if (DataSet == DataSelection.ModbusDataDiscreteInputs) {
                foreach (ModbusCoil Coil in CurrentManager.DiscreteInputs) {
                    AddMonitorItem(Coil);
                }
            }
            else if (DataSet == DataSelection.ModbusDataInputRegisters) {
                foreach (ModbusRegister Coil in CurrentManager.InputRegisters) {
                    AddMonitorItem(Coil);
                }
            }
            else if (DataSet == DataSelection.ModbusDataHoldingRegisters) {
                foreach (ModbusRegister Coil in CurrentManager.HoldingRegisters) {
                    AddMonitorItem(Coil);
                }
            }
            lstMonitor.Invalidate();
        }
        private void AddMonitorItem(ModbusCoil Coil) {
            ListItem PLi = new ListItem();
            PLi.Tag = Coil;
            ListSubItem CLi1 = new ListSubItem(Coil.Name);
            ListSubItem CLi2 = new ListSubItem("Boolean");
            ListSubItem CLi3 = new ListSubItem();
            ListSubItem CLi4 = new ListSubItem();
            ListSubItem CLi5 = new ListSubItem(Coil.Value.ToString());
            PLi.SubItems.Add(CLi1);
            PLi.SubItems.Add(CLi2);
            PLi.SubItems.Add(CLi3);
            PLi.SubItems.Add(CLi4);
            PLi.SubItems.Add(CLi5);
            lstMonitor.Items.Add(PLi);
        }
        private void AddMonitorItem(ModbusRegister Register) {
            ListItem PLi = new ListItem();
            PLi.Tag = Register;
            ListSubItem CLi1 = new ListSubItem(Register.Name);
            ListSubItem CLi2 = new ListSubItem(EnumManager.DataFormatToString(Register.Format).A);
            ListSubItem CLi3 = new ListSubItem(EnumManager.DataSizeToString(Register.Size));
            ListSubItem CLi4 = new ListSubItem(Register.Signed);
            ListSubItem CLi5 = new ListSubItem(Register.FormattedValue);
            PLi.SubItems.Add(CLi1);
            PLi.SubItems.Add(CLi2);
            PLi.SubItems.Add(CLi3);
            PLi.SubItems.Add(CLi4);
            PLi.SubItems.Add(CLi5);
            lstMonitor.Items.Add(PLi);
        }


        private void btnDiscrete_Click(object sender, EventArgs e) {
            DataSet = DataSelection.ModbusDataDiscreteInputs;
        }
        private void btnHolding_Click(object sender, EventArgs e) {
            DataSet = DataSelection.ModbusDataHoldingRegisters;
        }
        private void btnInputRegisters_Click(object sender, EventArgs e) {
            DataSet = DataSelection.ModbusDataInputRegisters;
        }
        private void btnCoils_Click(object sender, EventArgs e) {
            DataSet = DataSelection.ModbusDataCoils;
        }

        private void ModbusRegisters_FormClosing(object sender, FormClosingEventArgs e) {
            SystemManager.ChannelAdded -= SystemManager_ChannelAdded;
            SystemManager.ChannelRemoved -= SystemManager_ChannelRemoved;
            SystemManager.ChannelRenamed -= SystemManager_ChannelRenamed;
            SystemManager.ModbusReceived -= SystemManager_ModbusReceived;
            SystemManager.ModbusRegisterRenamed -= SystemManager_ModbusRegisterRenamed;
            ProjectManager.DocumentLoaded -= ProjectManager_DocumentLoaded;

            EnumManager.ClearClickHandles(cmDisplayFormats, CmDisplayFormat_Click);
            EnumManager.ClearClickHandles(cmDataSize, CmDisplaySize_Click);
            EnumManager.ClearClickHandles(ddbDisplayFormat, CmDisplayFormatList_Click);
            EnumManager.ClearClickHandles(ddpDataSize, CmDisplaySizeList_Click);
            lstMonitor.LineRemoveAll();
            GC.Collect();
        }
        private void SystemManager_ModbusReceived(object Data, int Index, DataSelection DataType) {
            if (Data == null) { return; }
            if (Data.GetType() == typeof(ModbusCoil)) {
                if (DataSet == DataType) {
                    ModbusCoil DigitalData = (ModbusCoil)Data;
                    if (ItemInBounds(Index, Indx_Value)) {
                        lstMonitor.Items[Index][Indx_Value].Text = DigitalData.Value.ToString();
                    }
                }
            }
            else if (Data.GetType() == typeof(ModbusRegister)) {
                if (DataSet == DataType) {
                    ModbusRegister DigitalData = (ModbusRegister)Data;
                    if (ItemInBounds(Index, Indx_Value)) {
                        lstMonitor.Items[Index][Indx_Value].Text = DigitalData.FormattedValue;
                    }
                }
            }
            lstMonitor.Invalidate();
        }
        private bool ItemInBounds(int Index, uint Column) {
            if (Index < 0) { return false; }
            if (lstMonitor.Items.Count > 0) {
                if (Index < lstMonitor.Items.Count) {
                    if (Column == 0) {
                        return true;
                    }
                    else {
                        if (lstMonitor.Items[Index].SubItems.Count > 0) {
                            if (lstMonitor.Items[Index].SubItems.Count > Column - 1) {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        Point LastPoint = Point.Empty;
        private void AddRenameBox(DropDownClickedEventArgs e, ListControl LstCtrl) {
            ListItem? LstItem = e.ParentItem;
            LastPoint = new Point(e.Column, e.Item);
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.ParentItem == null) { return; }
            if (e.ParentItem.SubItems == null) { return; }

            if (DataTag.GetType() == typeof(ModbusCoil)) {
                ModbusCoil coil = (ModbusCoil)DataTag;
                Rectangle Rect = new Rectangle(e.Location, e.ItemSize);
                Rectangle ParRect = new Rectangle(e.ScreenLocation, e.ItemSize);
                Components.EditValue EdVal = new Components.EditValue(coil.Name, LstCtrl, e.ParentItem, Indx_Name, e.Item, null, coil, Rect, ParRect, DataSet);
                LstCtrl.Controls.Add(EdVal);
                EdVal.ArrowKeyPress += EdVal_ArrowKeyPress;
                EdVal.Focus();
                EdVal.Show();
            }
            else if (DataTag.GetType() == typeof(ModbusRegister)) {
                ModbusRegister reg = (ModbusRegister)DataTag;
                Rectangle Rect = new Rectangle(e.Location, e.ItemSize);
                Rectangle ParRect = new Rectangle(e.ScreenLocation, e.ItemSize);
                Components.EditValue EdVal = new Components.EditValue(reg.Name, LstCtrl, e.ParentItem, Indx_Name, e.Item, null, reg, Rect, ParRect, DataSet);
                LstCtrl.Controls.Add(EdVal);
                EdVal.ArrowKeyPress += EdVal_ArrowKeyPress;
                EdVal.Focus();
                EdVal.Show();
            }
        }
        private void EdVal_ArrowKeyPress(bool IsUp) {
            if (IsUp == false) {

            }
        }

        bool ApplyOnClick = false;
        private void lstMonitor_ItemCheckedChanged(object sender, ItemCheckedChangeEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.Column == Indx_Signed) {
                if (DataTag.GetType() == typeof(ModbusRegister)) {
                    ModbusRegister Reg = (ModbusRegister)DataTag;
                    Reg.Signed = e.Checked;
                    LstItem[Indx_Value].Text = Reg.FormattedValue;
                    lstMonitor.Invalidate();
                }
            }
        }
        private void lstMonitor_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (LstItem.SubItems.Count < 5) { return; }
            if (e.Column == Indx_Name) {
                //EditValue EdVal = new EditValue(StepEnumerations.StepExecutable.Label, LstItem.SubItems[0].Text, lstMonitor, LstItem, null, LstItem.Tag, false);
                //
                //EdVal.Sz = e.ItemSize;
                //EdVal.Location = e.ScreenLocation;
                //EdVal.Show();
                AddRenameBox(e, lstMonitor);
            }
            else if (e.Column == Indx_Display) {
                if (DataTag.GetType() == typeof(ModbusRegister)) {
                    CheckItem(cmDisplayFormats, ((ModbusRegister)DataTag).Format);
                    cmDisplayFormats.Tag = e;
                    cmDisplayFormats.Show(AddPoint(e));
                }
            }
            else if (e.Column == Indx_Size) {
                if (DataTag.GetType() == typeof(ModbusRegister)) {
                    CheckItem(cmDataSize, ((ModbusRegister)DataTag).Size);
                    cmDataSize.Tag = e;
                    cmDataSize.Show(AddPoint(e));
                }
            }
            else if (e.Column == Indx_Value) {
                if (LockedEditor == true) { return; }
                if (DataTag.GetType() == typeof(ModbusCoil)) {
                    ModbusCoil coil = (ModbusCoil)DataTag;
                    coil.Value = !coil.Value;

                    LstItem[Indx_Value].Text = coil.Value.ToString();
                    if (btnApplyOnClick.Checked == false) { return; }
                    SystemManager.SendModbusCommand(CurrentManager, DataSet, "Write Coil " + e.Item.ToString() + " = " + coil.Value.ToString());
                }
                else if (DataTag.GetType() == typeof(ModbusRegister)) {
                    ModbusRegister reg = (ModbusRegister)DataTag;
                    EditValue EdVal = new EditValue(StepEnumerations.StepExecutable.Delay, LstItem.SubItems[4].Text, lstMonitor, LstItem, CurrentManager, reg, !btnApplyOnClick.Checked);
                    EdVal.Location = e.ScreenLocation;
                    EdVal.Sz = e.ItemSize;
                    EdVal.Show();
                    LstItem[Indx_Value].Text = reg.Value.ToString();
                }
            }
            lstMonitor.Invalidate();
        }
        private Point AddPoint(DropDownClickedEventArgs e) {
            return new Point(e.ScreenLocation.X, e.ScreenLocation.Y + e.ItemSize.Height);
        }
        private void CheckItem(object DropDownList, DataFormat CheckOn) {
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
        private void CheckItem(object DropDownList, DataSize CheckOn) {
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
        private void btnApplyOnClick_Click(object sender, EventArgs e) {
            btnApplyOnClick.Checked = !btnApplyOnClick.Checked;
            btnModbusApplyonClick.Checked = btnApplyOnClick.Checked;
        }
        private void btnModbusApplyonClick_Click(object sender, EventArgs e) {
            btnModbusApplyonClick.Checked = !btnModbusApplyonClick.Checked;
            btnApplyOnClick.Checked = btnModbusApplyonClick.Checked;
        }
        private void btnModbusLockEditors_Click(object sender, EventArgs e) {
            UnlockLockEditors();
        }
        private void btnLockEditor_Click(object sender, EventArgs e) {
            UnlockLockEditors();
        }
        private void UnlockLockEditors() {
            LockedEditor = !LockedEditor;
            btnModbusLockEditors.Checked = LockedEditor;
            ChangeLockedIcon(LockedEditor);
        }

        private void ModbusRegisters_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void ModbusRegisters_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void ModbusRegisters_FormClosed(object sender, FormClosedEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void viewCoilsToolStripMenuItem_Click(object sender, EventArgs e) {
            DataSet = DataSelection.ModbusDataCoils;
        }
        private void viewDiscreteInputsToolStripMenuItem_Click(object sender, EventArgs e) {
            DataSet = DataSelection.ModbusDataDiscreteInputs;
        }
        private void viewHoldingRegistersToolStripMenuItem_Click(object sender, EventArgs e) {
            DataSet = DataSelection.ModbusDataHoldingRegisters;
        }
        private void viewInputRegistersToolStripMenuItem_Click(object sender, EventArgs e) {
            DataSet = DataSelection.ModbusDataInputRegisters;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings ConfigApp = new Settings();
            ApplicationManager.OpenInternalApplicationOnce(ConfigApp, true);
        }


        private void TopMostSetting() {
            btnTopMost.Checked = !btnTopMost.Checked;
            btnMenuTopMost.Checked = !btnMenuTopMost.Checked;
            this.TopMost = !this.TopMost;
        }

        private void btnMenuTopMost_Click(object sender, EventArgs e) {
            TopMostSetting();
        }
        private void windowTopMostToolStripMenuItem_Click(object sender, EventArgs e) {
            TopMostSetting();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            Dialogs.InsertModbusSnapshot InsSnap = new Dialogs.InsertModbusSnapshot();
            // PrgProp.SelectedProgram = (ProgramObject)lstStepProgram.Tag;
            ApplicationManager.OpenInternalApplicationAsDialog(InsSnap, this);
            if (InsSnap.DialogResult == DialogResult.OK) {
                if (InsSnap.Manager != null) {
                    ToolWindows.ModbusRegister frm = ModbusSupport.NewSnapshotForm(InsSnap.DisplayName, InsSnap.Manager, InsSnap.DataSet, InsSnap.Address, InsSnap.Quantity);
                    mdiClient.AddChild(frm);
                }
            }

        }
        private void windowManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            WindowForms.WindowManager WindowMan = new WindowForms.WindowManager();
            Classes.ApplicationManager.OpenInternalApplicationOnce(WindowMan, true);
        }

        private void snapshotSelectionToolStripMenuItem_Click(object sender, EventArgs e) {
            AddSelectionToSnapshot();
        }
        private void addSelectionToSnapshotToolStripMenuItem_Click(object sender, EventArgs e) {
            AddSelectionToSnapshot();
        }
        private void AddSelectionToSnapshot() {
            if (CurrentManager == null) { return; }
            if (lstMonitor.SelectedItems() >= 1) {
                int Address = lstMonitor.SelectedIndex;
                int Count = lstMonitor.SelectedItems();
                bool IsConcurrent = true;
                int ItemCount = 0;
                bool LastSelectionStatus = true;
                List<int> Values = new List<int>();
                for (int i = Address; i < lstMonitor.Items.Count; i++) {
                    if (LastSelectionStatus != lstMonitor.Items[i].Selected) {
                        IsConcurrent = false;
                    }
                    if (lstMonitor.Items[i].Selected == true) {
                        ItemCount++;
                        LastSelectionStatus = true;
                        Values.Add(i);
                    }
                    else {
                        LastSelectionStatus = false;
                    }
                    if (ItemCount >= Count) {
                        break;
                    }
                }
                if (IsConcurrent) {
                    ToolWindows.ModbusRegister frm = ModbusSupport.NewSnapshotForm("", CurrentManager, DataSet, Address, Count);
                    mdiClient.AddChild(frm);
                }
                else {
                    if (Values.Count > 0) {
                        ToolWindows.ModbusRegister frm = ModbusSupport.NewSnapshotForm("", CurrentManager, DataSet, Values);
                        mdiClient.AddChild(frm);
                    }
                }

            }

        }

        private void showFormatsToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowFormats = !ShowFormats;
        }

        private void btnViewMaster_Click(object sender, EventArgs e) {
            thDataPagesHeader.SelectedIndex = 0;
        }
        private void btnViewSnapshot_Click(object sender, EventArgs e) {
            thDataPagesHeader.SelectedIndex = 1;
        }

        private void thDataPagesHeader_SelectedIndexChanged(object sender, int CurrentIndex, int PreviousIndex) {
            if (CurrentIndex == 0) {
                btnViewMaster.Checked = true;
                btnViewSnapshot.Checked = false;
            }
            else if (CurrentIndex == 1) {
                btnViewMaster.Checked = false;
                btnViewSnapshot.Checked = true;

            }
        }
    }
}
