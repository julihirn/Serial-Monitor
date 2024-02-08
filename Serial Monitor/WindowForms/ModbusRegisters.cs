using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Enums;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Components;
using Serial_Monitor.WindowForms;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.Enums.ModbusEnums;
using static System.Windows.Forms.AxHost;
using ListControl = ODModules.ListControl;

namespace Serial_Monitor {
    public partial class ModbusRegisters : Form, Interfaces.ITheme {
        public Form? Attached = null;
        TemplateContextMenuHost AppearancePopupHost;
        AppearancePopup popAppearance = new AppearancePopup();
        BitTogglerPopup popToggler = new BitTogglerPopup();
        TemplateContextMenuHost BitTogglerPopupHost;

        protected override CreateParams CreateParams {
            get {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        public ModbusRegisters() {
            InitializeComponent();
            lstMonitor.ExternalItems = ModbusEditor.MasterRegisterEditor;
            AppearancePopupHost = new TemplateContextMenuHost(popAppearance, this);
            BitTogglerPopupHost = new TemplateContextMenuHost(popToggler, this);
            tbDataPages.DebugMode = false;
            mdiClient.TileWindows = true;
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
        }
        private void ModbusRegisters_Load(object sender, EventArgs e) {
            //if (Attached != null) {
            //    if (Attached.GetType() == typeof(Form1)) {
            //        ((Form1)Attached).
            //    }
            //}

            btnApplyOnClick.Checked = ModbusSupport.SendOnChange;
            btnModbusApplyonClick.Checked = ModbusSupport.SendOnChange;
            AdjustUserInterface();
            ModbusEditor.ShowHideColumns(showFormats, DataSet, lstMonitor);
            EnumManager.LoadDataFormats(cmDisplayFormats, CmDisplayFormat_Click);
            EnumManager.LoadDataSizes(cmDataSize, CmDisplaySize_Click);
            EnumManager.LoadDataFormats(ddbDisplayFormat, CmDisplayFormatList_Click);
            EnumManager.LoadDataSizes(ddpDataSize, CmDisplaySizeList_Click);
            EnumManager.LoadWordOrders(ddbWordOrder, CmDisplayWordOrderList_Click);
            RecolorAll();
            AddIcons();
            LoadEvents();

            navigator1.LinkedList = SystemManager.SerialManagers;
            navigator1.SelectedItem = 0;
            navigator1.Invalidate();
            LoadChannels();




            mdiClient.MdiForm.MainMenuStrip = msMain;
            LoadForms();
            EnableDisableDialogEditors();
        }
        private void AppearancePopupHost_Opening(object? sender, CancelEventArgs e) {
        }
        #region Startup
        private void LoadChannels() {
            try {
                CurrentManager = SystemManager.SerialManagers[0];
                navigator1.SelectedItem = 0;
                CurrentEditorView = currentEditorView;
                if (CurrentManager != null) {
                    if (CurrentManager.IsMaster == true) {
                        if (CurrentManager.Slave.Count > 0) {
                            Slave = CurrentManager.Slave[0].Address;
                        }
                    }
                    else {
                        ModbusEditor.LoadRegisters(lstMonitor, CurrentManager, dataSet, slaveindex);
                    }

                }
                LoadSlaves();
            }
            catch { }
        }
        private void LoadEvents() {
            SystemManager.ChannelAdded += SystemManager_ChannelAdded;
            SystemManager.ChannelRemoved += SystemManager_ChannelRemoved;
            SystemManager.ChannelRenamed += SystemManager_ChannelRenamed;
            SystemManager.ModbusReceived += SystemManager_ModbusReceived;
            SystemManager.ModbusRegisterRenamed += SystemManager_ModbusRegisterRenamed;
            ProjectManager.DocumentLoaded += ProjectManager_DocumentLoaded;
            SystemManager.ModbusPropertyChanged += SystemManager_ModbusPropertyChanged;
            SystemManager.ChannelPropertyChanged += SystemManager_ChannelPropertyChanged;
            ModbusSupport.SnapshotClosed += ModbusSupport_SnapshotClosed;
            SystemManager.PortStatusChanged += SystemManager_PortStatusChanged;
            SystemManager.SlaveAdded += SystemManager_SlaveAdded;
            SystemManager.SlaveChanged += SystemManager_SlaveChanged;

            SystemManager.ModbusAppearanceChanged += SystemManager_ModbusAppearanceChanged;

            AppearancePopupHost.Opening += AppearancePopupHost_Opening;
            AppearancePopupHost.Closing += AppearancePopupHost_Closing;
            BitTogglerPopupHost.Closing += BitTogglerPopupHost_Closing;
        }



        private void LoadForms() {
            foreach (ModbusSnapshot Snap in ModbusSupport.Snapshots) {
                ToolWindows.ModbusRegister frm = new ToolWindows.ModbusRegister(Snap, true);
                mdiClient.AddChild(frm);
            }
        }
        private void LoadSlaves() {
            thSlaves.ClearTabs();
            if (CurrentManager == null) { thSlaves.Invalidate(); return; }
            thSlaves.Text = CurrentManager.IsMaster == true ? "Master" : "Unit " + CurrentManager.UnitAddress.ToString();
            thSlaves.ShowTabs = CurrentManager.IsMaster;
            foreach (ModbusSlave Slve in CurrentManager.Slave) {
                Tab? Result = GenerateTab(Slve);
                if (Result != null) {
                    thSlaves.Tabs.Add(Result);
                }
            }
            thSlaves.Invalidate();
        }
        private void SystemManager_SlaveChanged(SerialManager sender) {
            LoadSlaves();
        }

        private void SystemManager_SlaveAdded(SerialManager sender) {
            LoadSlaves();
        }


        private Tab? GenerateTab(ModbusSlave Slve) {
            if (CurrentManager == null) { return null; }
            Tab tbMain = new Tab();
            tbMain.Text = Slve.DisplayName;
            tbMain.Tag = Slve;

            return tbMain;
        }
        private void AdjustUserInterface() {
            msMain.Padding = DesignerSetup.ScalePadding(msMain.Padding);
            tsMain.Padding = DesignerSetup.ScalePadding(tsMain.Padding);
            cmDataSize.Padding = DesignerSetup.ScalePadding(cmDataSize.Padding);
            cmDisplayFormats.Padding = DesignerSetup.ScalePadding(cmDisplayFormats.Padding);
            cmMonitor.Padding = DesignerSetup.ScalePadding(cmMonitor.Padding);
            lstMonitor.ScaleColumnWidths();
            //navigator1.Width = DesignerSetup.ScaleInteger(navigator1.Width);
        }
        #endregion 
        #region Properties
        SerialManager? CurrentManager = null;
        bool LockedEditor = false;
        bool showFormats = true;
        public bool ShowFormats {
            get {
                return showFormats;
            }
            set {
                showFormatsToolStripMenuItem.Checked = value;
                showFormats = value;
                ModbusEditor.ShowHideColumns(showFormats, DataSet, lstMonitor);
            }
        }
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
                SetEditors();
                ClearEditors();
                ModbusEditor.ShowHideColumns(showFormats, DataSet, lstMonitor);
                ModbusEditor.LoadRegisters(lstMonitor, CurrentManager, dataSet, slaveindex);
                CheckModbusDataSelection();
            }
        }
        private DataEditor currentEditorView = DataEditor.MasterView;
        private DataEditor CurrentEditorView {
            get { return currentEditorView; }
            set {
                currentEditorView = value;
                if (value == DataEditor.MasterView) {
                    btnViewMaster.Checked = true;
                    btnViewSnapshot.Checked = false;
                    showFormatsToolStripMenuItem.Checked = showFormats;
                    showFormatsToolStripMenuItem.Enabled = true;
                    showUnitsToolStripMenuItem.Checked = ProjectManager.ShowUnits;
                    showUnitsToolStripMenuItem.Enabled = true;
                    goToToolStripMenuItem.Enabled = true;
                    if (CurrentManager != null) {
                        btnMenuModbusMaster.Checked = CurrentManager.IsMaster;
                        modbusMasterToolStripMenuItem.Checked = CurrentManager.IsMaster;
                        modbusMasterToolStripMenuItem.Enabled = true;

                        ChangeModbusActions(CurrentManager.IsMaster);
                        btnMenuModbusMaster.Enabled = true;
                        thSlaves.ShowTabs = CurrentManager.IsMaster;
                        thSlaves.Text = CurrentManager.IsMaster == true ? "Master" : "Unit " + CurrentManager.UnitAddress.ToString();
                    }
                    else {
                        btnMenuModbusMaster.Enabled = false;
                        modbusMasterToolStripMenuItem.Enabled = false;
                        ChangeModbusActions(false);
                    }
                    setIOFormatsToModbusRTUToolStripMenuItem.Enabled = true;
                    setIOFormatsToModbusASCIIToolStripMenuItem.Enabled = true;

                    ChangeClipboardActions(true);
                    EnableDisableDialogEditors();
                }
                else {
                    goToToolStripMenuItem.Enabled = false;
                    btnViewMaster.Checked = false;
                    btnViewSnapshot.Checked = true;
                    ChangeModbusActions(false);
                    if (SnapshotCurrentIndex < 0) {
                        showFormatsToolStripMenuItem.Checked = false;
                        showFormatsToolStripMenuItem.Enabled = false;
                        showUnitsToolStripMenuItem.Checked = false;
                        showUnitsToolStripMenuItem.Enabled = false;
                        btnMenuModbusMaster.Enabled = false;
                        btnMenuModbusMaster.Checked = false;
                        modbusMasterToolStripMenuItem.Checked = false;
                        modbusMasterToolStripMenuItem.Enabled = false;
                        setIOFormatsToModbusRTUToolStripMenuItem.Enabled = false;
                        setIOFormatsToModbusASCIIToolStripMenuItem.Enabled = false;

                        ChangeModbusDialogs(false);
                        ChangeClipboardActions(false);
                    }
                    else {
                        setIOFormatsToModbusRTUToolStripMenuItem.Enabled = true;
                        setIOFormatsToModbusASCIIToolStripMenuItem.Enabled = true;
                        showFormatsToolStripMenuItem.Enabled = true;
                        showUnitsToolStripMenuItem.Enabled = true;
                        try {
                            if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                                bool FormatsVisable = ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).ShowFormats;
                                showFormatsToolStripMenuItem.Checked = FormatsVisable;
                                bool UnitsVisable = ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).ShowUnits;
                                showUnitsToolStripMenuItem.Checked = UnitsVisable;
                                btnMenuModbusMaster.Enabled = true;
                                btnMenuModbusMaster.Checked = false;

                                modbusMasterToolStripMenuItem.Checked = false;
                                modbusMasterToolStripMenuItem.Enabled = true;
                                ModbusSnapshot? Snap = ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).Snapshot;
                                if (Snap != null) {
                                    if (Snap.Manager != null) {
                                        SerialManager? Man = Snap.Manager.Manager;
                                        if (Man != null) {
                                            btnMenuModbusMaster.Checked = Man.IsMaster;
                                            modbusMasterToolStripMenuItem.Checked = Man.IsMaster;
                                            modbusMasterToolStripMenuItem.Enabled = true;
                                        }
                                        else {
                                            btnMenuModbusMaster.Enabled = true;
                                            btnMenuModbusMaster.Checked = false;
                                            modbusMasterToolStripMenuItem.Checked = false;
                                            modbusMasterToolStripMenuItem.Enabled = true;
                                        }
                                    }
                                }
                                ChangeModbusDialogs(true);
                                ChangeClipboardActions(true);
                            }
                        }
                        catch {
                            showFormatsToolStripMenuItem.Enabled = false;
                            showUnitsToolStripMenuItem.Enabled = false;
                            ChangeClipboardActions(false);
                        }
                    }
                }
                ChangeLockView();
                SetEditors();
            }
        }
        private int slaveAddress = -1;
        private int slaveindex = -1;
        public int Slave {
            get { return slaveAddress; }
            set {
                slaveAddress = value;
                if (CurrentManager != null) {
                    slaveindex = ModbusSupport.UnitToIndex(CurrentManager, slaveAddress);
                }
                else {
                    slaveindex = -1;
                }
                ModbusEditor.LoadRegisters(lstMonitor, CurrentManager, dataSet, slaveindex);
                ModbusEditor.ClearControls(lstMonitor);
            }
        }

        int snapShotCurrentIndex = -1;
        public int SnapshotCurrentIndex {
            get { return snapShotCurrentIndex; }
            set {
                snapShotCurrentIndex = value;
                CurrentEditorView = currentEditorView;
                SetEditors();
            }
        }
        #endregion
        #region Enable/Disable Buttons and Actions
        private void SetEditors() {
            if (currentEditorView == DataEditor.MasterView) {
                if (dataSet > DataSelection.ModbusDataDiscreteInputs) {
                    SetFormatters(true);
                }
                else {
                    SetFormatters(false);
                }
                resetAppearanceToolStripMenuItem.Enabled = true;
                changeAppearanceToolStripMenuItem.Enabled = true;
            }
            else {
                try {
                    if (SnapshotCurrentIndex >= 0) {
                        if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                            ModbusSnapshot? Snap = ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).Snapshot;
                            if (Snap != null) {
                                resetAppearanceToolStripMenuItem.Enabled = true;
                                changeAddressToolStripMenuItem.Enabled = true;
                                if (Snap.Selection > DataSelection.ModbusDataDiscreteInputs) {
                                    SetFormatters(true);
                                }
                                else {
                                    SetFormatters(false);
                                }
                            }
                        }
                        else {
                            resetAppearanceToolStripMenuItem.Enabled = false;
                            changeAppearanceToolStripMenuItem.Enabled = false;
                            SetFormatters(false);
                        }
                    }
                    else {
                        resetAppearanceToolStripMenuItem.Enabled = false;
                        changeAppearanceToolStripMenuItem.Enabled = false;
                        SetFormatters(false);
                    }

                }
                catch {
                    resetAppearanceToolStripMenuItem.Enabled = false;
                    changeAppearanceToolStripMenuItem.Enabled = false;
                    SetFormatters(false);
                }
            }
        }
        private void SetFormatters(bool State) {
            ddbDisplayFormat.Enabled = State;
            ddpDataSize.Enabled = State;
            btnSigned.Enabled = State;
            ddbWordOrder.Enabled = State;
        }
        private void ChangeClipboardActions(bool Enable) {
            copyAsTextToolStripMenuItem.Enabled = Enable;
            pasteToolStripMenuItem.Enabled = Enable;
            copySpecialToolStripMenuItem.Enabled = Enable;
            copyToolStripMenuItem.Enabled = Enable;
            resetToolStripMenuItem.Enabled = Enable;
            selectAllToolStripMenuItem.Enabled = Enable;
            selectInvertToolStripMenuItem.Enabled = Enable;
            selectSpecialToolStripMenuItem.Enabled = Enable;
        }
        private void ChangeModbusActions(bool Enable) {
            newUnitToolStripMenuItem.Enabled = Enable;
            removeUnitToolStripMenuItem.Enabled = Enable;
            renameUnitToolStripMenuItem.Enabled = Enable;
            newUnitToolStripMenuItem1.Enabled = Enable;
            removeUnitToolStripMenuItem1.Enabled = Enable;
            renameUnitToolStripMenuItem1.Enabled = Enable;
        }
        private void EnableDisableDialogEditors() {
            if (CurrentManager == null) {
                ChangeModbusDialogs(false);
                return;
            }
            ChangeModbusDialogs(CurrentManager.IsMaster);
        }
        private void ChangeModbusDialogs(bool Enable) {
            writeCoilToolStripMenuItem.Enabled = Enable;
            writeMultipleCoilsToolStripMenuItem.Enabled = Enable;
            writeRegisterToolStripMenuItem.Enabled = Enable;
            writeRegisterMaskToolStripMenuItem.Enabled = Enable;
            writeMultipleRegistersToolStripMenuItem.Enabled = Enable;
        }
        #endregion
        #region Snapshot Support
        public void GetIndexFromForm(ToolWindows.ModbusRegister? RegisterEditor) {
            if (RegisterEditor == null) { SnapshotCurrentIndex = -1; return; }
            int Index = 0;
            if (mdiClient.ChildForms.Count <= 0) { SnapshotCurrentIndex = -1; }
            foreach (Components.MdiClientForm Frm in mdiClient.ChildForms) {
                if (Frm.GetType() == typeof(ToolWindows.ModbusRegister)) {
                    if (((ToolWindows.ModbusRegister)Frm).ID == RegisterEditor.ID) {
                        SnapshotCurrentIndex = Index; break;
                    }
                }
                Index++;
            }
        }
        public void GetIndexFromForm() {
            if (mdiClient.ChildForms.Count <= 0) { SnapshotCurrentIndex = -1; }
            SnapshotCurrentIndex = mdiClient.ChildForms.Count - 1;
        }
        #endregion
        #region Register Formatting
        private void CmDisplayFormatList_Click(object? sender, EventArgs e) {
            ListControl? CurrentEditor = GetCurrentListView();
            ModbusEditor.ChangeDisplayFormatList(sender, CurrentEditor);
        }
        private void CmDisplaySizeList_Click(object? sender, EventArgs e) {
            ListControl? CurrentEditor = GetCurrentListView();
            ModbusEditor.ChangeSizeList(sender, CurrentEditor);
        }
        private void CmDisplayWordOrderList_Click(object? sender, EventArgs e) {
            ListControl? CurrentEditor = GetCurrentListView();
            ModbusEditor.ChangeWordOrderList(sender, CurrentEditor);
        }
        private void ddbSigned_Click(object sender, EventArgs e) {
            ChangeSigned(FormatEnums.SignedState.Signed);
        }
        private void ddbUnsigned_Click(object sender, EventArgs e) {
            ChangeSigned(FormatEnums.SignedState.Unsigned);
        }
        private void ddbToggleSigned_Click(object sender, EventArgs e) {
            ChangeSigned(FormatEnums.SignedState.Toogle);
        }
        private void ChangeSigned(FormatEnums.SignedState State) {
            ListControl? CurrentEditor = GetCurrentListView();
            ModbusEditor.ChangeSignedList(CurrentEditor, State);
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
                if (Args.ParentItem.Tag.GetType() == typeof(ModbusRegister)) {
                    ModbusRegister Reg = (ModbusRegister)Args.ParentItem.Tag;
                    Reg.Format = Frmt;
                    Args.ParentItem[Args.Column].Text = EnumManager.DataFormatToString(Reg.Format).A;
                    Args.ParentItem[ModbusEditor.Indx_Size].Text = EnumManager.DataSizeToString(Reg.Size);
                    Args.ParentItem[ModbusEditor.Indx_Value].Text = Reg.ValueWithUnit;
                    ModbusEditor.RetroactivelyApplyFormatChanges(Args.Item, lstMonitor);
                    lstMonitor.Invalidate();
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
                if (Args.ParentItem.Tag.GetType() == typeof(ModbusRegister)) {
                    ModbusRegister Reg = (ModbusRegister)Args.ParentItem.Tag;
                    Reg.Size = Frmt;
                    Args.ParentItem[Args.Column].Text = EnumManager.DataSizeToString(Reg.Size);
                    Args.ParentItem[ModbusEditor.Indx_Display].Text = EnumManager.DataFormatToString(Reg.Format).A;
                    Args.ParentItem[ModbusEditor.Indx_Value].Text = Reg.ValueWithUnit;
                    ModbusEditor.RetroactivelyApplyFormatChanges(Args.Item, lstMonitor);
                    lstMonitor.Invalidate();
                }
            }
        }
        #endregion
        #region Modbus Event Handling
        private void SystemManager_ModbusPropertyChanged(ModbusSlave parentManager, object Data, int Index, DataSelection DataType) {
            // lstRegisters.ExternalItems[Index]
            if (CurrentManager == null) { return; }
            if (parentManager.Manager == null) { return; }
            if (CurrentManager.ID != parentManager.Manager.ID) { return; }
            if (Slave != parentManager.Address) { return; };
            try {
                if (lstMonitor.CurrentItems[Index].SubItems.Count <= ModbusEditor.Indx_Value) {
                    switch (dataSet) {
                        case DataSelection.ModbusDataCoils:
                            lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Value].Text = parentManager.Coils[Index].Value.ToString();
                            break;
                        case DataSelection.ModbusDataDiscreteInputs:
                            lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Value].Text = parentManager.DiscreteInputs[Index].Value.ToString();
                            break;
                        case DataSelection.ModbusDataInputRegisters:
                            lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Display].Text = EnumManager.DataFormatToString(parentManager.InputRegisters[Index].Format).A;
                            lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Size].Text = EnumManager.DataSizeToString(parentManager.InputRegisters[Index].Size);
                            lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Signed].Checked = parentManager.InputRegisters[Index].Signed;
                            lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Value].Text = parentManager.InputRegisters[Index].ValueWithUnit;
                            break;
                        case DataSelection.ModbusDataHoldingRegisters:
                            lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Display].Text = EnumManager.DataFormatToString(parentManager.HoldingRegisters[Index].Format).A;
                            lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Size].Text = EnumManager.DataSizeToString(parentManager.HoldingRegisters[Index].Size);
                            lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Signed].Checked = parentManager.HoldingRegisters[Index].Signed;
                            lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Value].Text = parentManager.HoldingRegisters[Index].ValueWithUnit;
                            break;
                    }
                }
            }
            catch { }
            lstMonitor.Invalidate();
        }
        private void SystemManager_ModbusRegisterRenamed(ModbusSlave parentManager, object Data, int Index, DataSelection DataType) {
            if (Data == null) { return; }
            if (CurrentManager == null) { return; }
            if (parentManager.Manager == null) { return; }
            if (CurrentManager.ID != parentManager.Manager.ID) { return; }
            if (Data.GetType() == typeof(ModbusCoil)) {
                if (DataSet == DataType) {
                    ModbusCoil DigitalData = (ModbusCoil)Data;
                    if (ModbusEditor.ItemInBounds(lstMonitor, Index, 1)) {
                        lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Name].Text = DigitalData.Name.ToString();
                    }
                }
            }
            else if (Data.GetType() == typeof(ModbusRegister)) {
                if (DataSet == DataType) {
                    ModbusRegister DigitalData = (ModbusRegister)Data;
                    if (ModbusEditor.ItemInBounds(lstMonitor, Index, 1)) {
                        lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Name].Text = DigitalData.Name.ToString();
                    }
                }
            }
            navigator1.Invalidate();

        }
        private void SystemManager_ChannelRenamed(SerialManager sender) {
            navigator1.Invalidate();
        }
        private void SystemManager_ModbusReceived(ModbusSlave parentManager, object Data, int Index, DataSelection DataType) {
            if (Data == null) { return; }
            if (CurrentManager == null) { return; }
            if (parentManager.Manager == null) { return; }
            bool Proceed = false;
            if (parentManager.Manager.IsMaster) {
                if (Slave == parentManager.Address) {
                    Proceed = true;
                }
            }
            else {
                Proceed = true;
            }
            if ((CurrentManager.ID == parentManager.Manager.ID) && (Proceed)) {
                if (Data.GetType() == typeof(ModbusCoil)) {
                    if (DataSet == DataType) {
                        ModbusCoil DigitalData = (ModbusCoil)Data;
                        if (ModbusEditor.ItemInBounds(lstMonitor, Index, ModbusEditor.Indx_Value)) {
                            lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Value].Text = DigitalData.Value.ToString();
                        }
                    }
                }
                else if (Data.GetType() == typeof(ModbusRegister)) {
                    if (DataSet == DataType) {
                        ModbusRegister DigitalData = (ModbusRegister)Data;
                        if (ModbusEditor.ItemInBounds(lstMonitor, Index, ModbusEditor.Indx_Value)) {
                            lstMonitor.CurrentItems[Index][ModbusEditor.Indx_Value].Text = DigitalData.ValueWithUnit;
                        }
                    }
                }
                lstMonitor.Invalidate();
            }
        }
        #endregion
        #region System and Project Event Handling
        private void ProjectManager_DocumentLoaded() {
            LoadChannels();
            LoadForms();
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
        private void SystemManager_PortStatusChanged(SerialManager sender) {

        }
        private void SystemManager_ChannelPropertyChanged(SerialManager sender) {
            CurrentEditorView = currentEditorView;
            EnableDisableDialogEditors();
        }
        #endregion
        #region Theme
        public void ApplyTheme() {

            RecolorAll();
            AddIcons();
        }
        private void RecolorAll() {
            ApplicationManager.IsDark = Properties.Settings.Default.THM_SET_IsDark;
            this.SuspendLayout();
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(thSlaves);
            Classes.Theming.ThemeManager.ThemeControl(thDataPagesHeader);
            Classes.Theming.ThemeManager.ThemeControl(msMain);
            Classes.Theming.ThemeManager.ThemeControl(tsMain);
            Classes.Theming.ThemeManager.ThemeControl(lstMonitor);
            Classes.Theming.ThemeManager.ThemeControl(tbDataPages);
            Classes.Theming.ThemeManager.ThemeControl(navigator1);

            Classes.Theming.ThemeManager.ThemeControl(cmDataSize);
            Classes.Theming.ThemeManager.ThemeControl(cmDisplayFormats);
            Classes.Theming.ThemeManager.ThemeControl(cmMonitor);
            Classes.Theming.ThemeManager.ThemeControl(cmChannels);
            Classes.Theming.ThemeManager.ThemeControl(cmMBChannel);
            mdiClient.BackColor = Properties.Settings.Default.THM_COL_Editor;
            this.ResumeLayout();
        }
        #endregion
        #region Icons
        public void AddIcons() {
            DesignerSetup.LinkSVGtoControl(Properties.Resources.BooleanData, btnCoils, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.BooleanData, btnDiscrete, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.DomainType, btnHolding, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.DomainType, btnInputRegisters, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.BringForward, btnMenuTopMost, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.NewItem, newToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Settings_16x, optionsToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.QueryView, querySenderToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.NewPartition, newUnitToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.NewPartition, newUnitToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Rename, renameUnitToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Rename, renameUnitToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, removeUnitToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, removeUnitToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.ColorPalette, changeAppearanceToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Copy, copyToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Paste, pasteToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Binary, bitTogglerToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.NewDeploymentPackage_16x, newToolStripMenuItem1, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.SelectAll, selectAllToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.SelectRows, btnSelectionToSnapshot, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            //DesignerSetup.LinkSVGtoControl(Properties.Resources.SaveAs_16x, saveAsToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Save_16x, saveToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.OpenFile_16x, openToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.ApplyCodeChanges, btnApplyOnClick, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Connect_16x, connectToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Disconnect_16x, disconnectToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            ChangeLockedIcon(LockedEditor);
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
            btnModbusLockEditors.Checked = Input;
        }
        #endregion


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
                    CurrentManager = null;
                    CurrentManager = SystemManager.SerialManagers[SelectedIndex];
                    if (CurrentManager != null) {
                        CurrentEditorView = CurrentEditorView;
                        LoadSlaves();
                        if (CurrentManager.IsMaster == true) {
                            thSlaves.ShowTabs = true;
                            GetSelectedTabSlave(thSlaves.SelectedIndex);
                        }
                        else {
                            thSlaves.ShowTabs = false;
                            Slave = -1;
                        }
                        thSlaves.Text = CurrentManager.IsMaster == true ? "Master" : "Unit " + CurrentManager.UnitAddress.ToString();
                    }
                    else {
                        ModbusEditor.LoadRegisters(lstMonitor, CurrentManager, dataSet, slaveindex);
                    }
                    EnableDisableDialogEditors();
                    ModbusEditor.ClearControls(lstMonitor);
                }
            }
        }
        #region Editing and List Support

        Point LastPoint = Point.Empty;
        private ListControl? GetCurrentListView() {
            if (currentEditorView == DataEditor.MasterView) {
                return lstMonitor;
            }
            else {
                try {
                    if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                        return ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).lstRegisters;
                    }
                }
                catch { }
            }
            return null;
        }
        private ModbusSlave? GetCurrentSlave() {
            if (currentEditorView == DataEditor.MasterView) {
                if (CurrentManager == null) { return null; }
                if (CurrentManager.IsMaster) {
                    return CurrentManager.Slave[slaveindex];
                }
                else {
                    return CurrentManager.Registers;
                }
            }
            else {
                try {
                    if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                        ModbusSnapshot? Snap = ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).Snapshot;
                        if (Snap == null) { return null; }
                        return Snap.Manager;
                    }
                }
                catch { }
            }
            return null;
        }
        private DataSelection? GetDataSelection() {
            if (currentEditorView == DataEditor.MasterView) {
                return DataSet;
            }
            else {
                try {
                    if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                        ModbusSnapshot? Snap = ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).Snapshot;
                        if (Snap == null) { return null; }
                        return Snap.Selection;
                    }
                }
                catch { }
            }
            return null;
        }
        private void EdVal_ArrowKeyPress(bool IsUp) {
            if (IsUp == false) {
                lstMonitor.SelectNextDropDown();
            }
        }
        bool ApplyOnClick = false;
        private void lstMonitor_ItemCheckedChanged(object sender, ItemCheckedChangeEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.Column == ModbusEditor.Indx_Signed) {
                if (DataTag.GetType() == typeof(ModbusRegister)) {
                    ModbusRegister Reg = (ModbusRegister)DataTag;
                    Reg.Signed = e.Checked;
                    LstItem[ModbusEditor.Indx_Value].Text = Reg.ValueWithUnit;
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
            if (e.Column == ModbusEditor.Indx_Name) {
                //AddRenameBox(e, lstMonitor);
                ModbusEditor.AddRenameBox(e, lstMonitor, DataSet, EdVal_ArrowKeyPress);
            }
            else if (e.Column == ModbusEditor.Indx_Display) {
                if (DataTag.GetType() == typeof(ModbusRegister)) {
                    ModbusEditor.CheckItem(cmDisplayFormats, ((ModbusRegister)DataTag).Format);
                    cmDisplayFormats.Tag = e;
                    cmDisplayFormats.Show(ModbusEditor.AddPoint(e));
                }
            }
            else if (e.Column == ModbusEditor.Indx_Size) {
                if (DataTag.GetType() == typeof(ModbusRegister)) {
                    ModbusEditor.CheckItem(cmDataSize, ((ModbusRegister)DataTag).Size);
                    cmDataSize.Tag = e;
                    cmDataSize.Show(ModbusEditor.AddPoint(e));
                }
            }
            else if (e.Column == ModbusEditor.Indx_Value) {
                if (LockedEditor == true) { return; }
                if (DataTag.GetType() == typeof(ModbusCoil)) {
                    ModbusCoil coil = (ModbusCoil)DataTag;
                    if (ModbusEditor.CanChangeValue(CurrentManager, coil.ComponentType) == false) { return; }
                    coil.Value = !coil.Value;

                    LstItem[ModbusEditor.Indx_Value].Text = coil.Value.ToString();
                    if (ModbusSupport.SendOnChange == false) { return; }
                    if (Slave >= 0) {
                        SystemManager.SendModbusCommand(CurrentManager, DataSet, "Unit " + Slave.ToString() + " Write Coil " + e.Item.ToString() + " = " + coil.Value.ToString());
                    }

                }
                else if (DataTag.GetType() == typeof(ModbusRegister)) {
                    if (ModbusEditor.CanChangeValue(CurrentManager, ((ModbusRegister)DataTag).ComponentType) == false) { return; }
                    ModbusEditor.AddValueBox(e, lstMonitor, DataSet, EdVal_ArrowKeyPress);
                }
            }
            lstMonitor.Invalidate();
        }
        #endregion
        #region Register Editing Support
        private void btnApplyOnClick_Click(object sender, EventArgs e) {
            ModbusSupport.SendOnChange = !ModbusSupport.SendOnChange;
            btnApplyOnClick.Checked = ModbusSupport.SendOnChange;
            btnModbusApplyonClick.Checked = ModbusSupport.SendOnChange;
        }
        private void btnModbusApplyonClick_Click(object sender, EventArgs e) {
            ModbusSupport.SendOnChange = !ModbusSupport.SendOnChange;
            btnApplyOnClick.Checked = ModbusSupport.SendOnChange;
            btnModbusApplyonClick.Checked = ModbusSupport.SendOnChange;
        }
        private void btnModbusLockEditors_Click(object sender, EventArgs e) {
            UnlockLockEditors();
        }
        private void btnLockEditor_Click(object sender, EventArgs e) {
            UnlockLockEditors();
        }
        private void UnlockLockEditors() {
            if (CurrentEditorView == DataEditor.MasterView) {
                LockedEditor = !LockedEditor;
                ChangeLockedIcon(LockedEditor);
            }
            else {
                try {
                    if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                        bool FormatsVisable = ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).Locked;
                        ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).Locked = !FormatsVisable;
                        ChangeLockedIcon(((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).Locked);
                    }
                }
                catch { }
            }
            CurrentEditorView = currentEditorView;
        }
        private void ChangeLockView() {
            if (CurrentEditorView == DataEditor.MasterView) {
                btnLockEditor.Enabled = true;
                btnModbusLockEditors.Enabled = true;
                ChangeLockedIcon(LockedEditor);
            }
            else {
                try {
                    if (SnapshotCurrentIndex >= 0) {
                        if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                            ChangeLockedIcon(((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).Locked);
                        }
                        btnLockEditor.Enabled = true;
                        btnModbusLockEditors.Enabled = true;
                    }
                    else {
                        btnLockEditor.Enabled = false;
                        btnModbusLockEditors.Enabled = false;
                    }
                }
                catch { }
            }
        }
        #endregion
        #region Window Event Handling
        private void ModbusRegisters_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void ModbusRegisters_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void ModbusRegisters_FormClosed(object sender, FormClosedEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void ModbusRegisters_FormClosing(object sender, FormClosingEventArgs e) {
            CurrentManager = null;
            SystemManager.ChannelAdded -= SystemManager_ChannelAdded;
            SystemManager.ChannelRemoved -= SystemManager_ChannelRemoved;
            SystemManager.ChannelRenamed -= SystemManager_ChannelRenamed;
            SystemManager.ModbusReceived -= SystemManager_ModbusReceived;
            SystemManager.ModbusRegisterRenamed -= SystemManager_ModbusRegisterRenamed;
            ProjectManager.DocumentLoaded -= ProjectManager_DocumentLoaded;
            SystemManager.ModbusPropertyChanged -= SystemManager_ModbusPropertyChanged;
            SystemManager.ChannelPropertyChanged -= SystemManager_ChannelPropertyChanged;

            SystemManager.SlaveAdded -= SystemManager_SlaveAdded;
            SystemManager.SlaveChanged -= SystemManager_SlaveChanged;

            ModbusSupport.SnapshotClosed -= ModbusSupport_SnapshotClosed;

            SystemManager.PortStatusChanged -= SystemManager_PortStatusChanged;

            SystemManager.ModbusAppearanceChanged -= SystemManager_ModbusAppearanceChanged;

            EnumManager.ClearClickHandles(cmDisplayFormats, CmDisplayFormat_Click);
            EnumManager.ClearClickHandles(cmDataSize, CmDisplaySize_Click);
            EnumManager.ClearClickHandles(ddbDisplayFormat, CmDisplayFormatList_Click);
            EnumManager.ClearClickHandles(ddpDataSize, CmDisplaySizeList_Click);
            BitTogglerPopupHost.Closing -= BitTogglerPopupHost_Closing;
            //foreach (ListItem Li in lstMonitor.CurrentItems) {
            //    Li.Tag = null;
            //}
            ModbusEditor.RemoveReferences();
            //lstMonitor.LineRemoveAll();
            GC.Collect();
        }
        #endregion 
        #region Windows, Tool and Options
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings ConfigApp = new Settings();
            ApplicationManager.OpenInternalApplicationOnce(ConfigApp, true);
        }
        private void windowManagerToolStripMenuItem_Click(object sender, EventArgs e) {
            WindowForms.WindowManager WindowMan = new WindowForms.WindowManager();
            Classes.ApplicationManager.OpenInternalApplicationOnce(WindowMan, true);
        }
        #endregion 
        #region Snapshot Editing and Support
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
                for (int i = Address; i < lstMonitor.CurrentItems.Count; i++) {
                    if (LastSelectionStatus != lstMonitor.CurrentItems[i].Selected) {
                        IsConcurrent = false;
                    }
                    if (lstMonitor.CurrentItems[i].Selected == true) {
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
                    if (Slave < 0) {
                        if (CurrentManager.Registers == null) { return; }
                        ToolWindows.ModbusRegister frm = ModbusSupport.NewSnapshotForm("", CurrentManager.Registers, DataSet, Address, Count);
                        mdiClient.AddChild(frm);
                    }
                    else {
                        if (slaveindex > -1) {
                            ToolWindows.ModbusRegister frm = ModbusSupport.NewSnapshotForm("", CurrentManager.Slave[slaveindex], DataSet, Address, Count);
                            mdiClient.AddChild(frm);
                        }
                    }
                }
                else {
                    if (Values.Count > 0) {
                        if (CurrentManager.Registers == null) { return; }
                        if (Slave < 0) {
                            ToolWindows.ModbusRegister frm = ModbusSupport.NewSnapshotForm("", CurrentManager.Registers, DataSet, Values);
                            mdiClient.AddChild(frm);
                        }
                        else {
                            if (slaveindex > -1) {
                                ToolWindows.ModbusRegister frm = ModbusSupport.NewSnapshotForm("", CurrentManager.Slave[slaveindex], DataSet, Values);
                                mdiClient.AddChild(frm);
                            }
                        }
                    }
                }
            }
        }
        private void mdiClient_OnChildActivated(object sender, MdiClientForm child) {
            if (child.GetType() == typeof(ToolWindows.ModbusRegister)) {
                GetIndexFromForm((ToolWindows.ModbusRegister)child);
            }
        }
        private void ModbusSupport_SnapshotClosed() {
            GetIndexFromForm();
        }
        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e) {
            mdiClient.TileWindows = !mdiClient.TileWindows;
            tileHorizontalToolStripMenuItem.Checked = !tileHorizontalToolStripMenuItem.Checked;
        }
        #endregion
        #region View
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
        private void showFormatsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (currentEditorView == DataEditor.MasterView) {
                ShowFormats = !ShowFormats;
            }
            else if (currentEditorView == DataEditor.SnapshotView) {
                try {
                    if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                        bool FormatsVisable = ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).ShowFormats;
                        ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).ShowFormats = !FormatsVisable;
                        CurrentEditorView = currentEditorView;
                    }
                }
                catch { }
            }
        }
        private void btnViewMaster_Click(object sender, EventArgs e) {
            thDataPagesHeader.SelectedIndex = 0;
        }
        private void btnViewSnapshot_Click(object sender, EventArgs e) {
            thDataPagesHeader.SelectedIndex = 1;
        }
        private void thDataPagesHeader_SelectedIndexChanged(object sender, int CurrentIndex, int PreviousIndex) {
            if (CurrentIndex == 0) {
                CurrentEditorView = DataEditor.MasterView;
            }
            else if (CurrentIndex == 1) {
                CurrentEditorView = DataEditor.SnapshotView;
            }
        }
        #endregion 
        #region Main Instance Project Handling
        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SystemManager.MainInstance == null) { return; }
            SystemManager.MainInstance.OpenFileViaDialog();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SystemManager.MainInstance == null) { return; }
            SystemManager.MainInstance.Save();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (SystemManager.MainInstance == null) { return; }
            SystemManager.MainInstance.Save(true);
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (SystemManager.MainInstance == null) { return; }
            SystemManager.MainInstance.New();
        }
        #endregion 
        #region Clipboard
        private void Reset() {
            ModbusClipboardFlags Flags = ModbusClipboardFlags.IncludeNothing;
            Flags |= ModbusClipboardFlags.IncludeName;
            Flags |= ModbusClipboardFlags.IncludeFormat;
            Flags |= ModbusClipboardFlags.IncludeSize;
            Flags |= ModbusClipboardFlags.IncludeValue;

            if (currentEditorView == DataEditor.MasterView) {
                ModbusEditor.Reset(lstMonitor, Flags);
            }
            else {
                try {

                    if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                        ModbusEditor.Reset(((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).lstRegisters, Flags);
                    }
                }
                catch { }
            }
        }
        private void SelectAll() {
            ListControl? CurrentEditor = GetCurrentListView();
            ModbusEditor.SelectAll(CurrentEditor);
        }
        private void SelectAllInvert() {
            ListControl? CurrentEditor = GetCurrentListView();
            ModbusEditor.SelectAll(CurrentEditor, true);
        }
        private void SelectMatching(ModbusClipboardFlags Flags) {
            ListControl? CurrentEditor = GetCurrentListView();
            ModbusEditor.SelectMatching(CurrentEditor, Flags);
        }
        private void Copy() {
            ModbusClipboardFlags Flags = ModbusClipboardFlags.IncludeNothing;
            Flags |= ModbusClipboardFlags.IncludeName;
            Flags |= ModbusClipboardFlags.IncludeFormat;
            Flags |= ModbusClipboardFlags.IncludeSize;
            Flags |= ModbusClipboardFlags.IncludeValue;
            CopyWithFlags(Flags);
        }
        private void CopyWithFlags(ModbusClipboardFlags Flags) {
            ListControl? CurrentEditor = GetCurrentListView();
            ModbusEditor.CopyRegisters(CurrentEditor, Flags);
        }
        private void Paste() {
            ListControl? CurrentEditor = GetCurrentListView();
            ModbusEditor.PasteRegisters(CurrentEditor);
        }
        private void CopyAsText() {
            ListControl? CurrentEditor = GetCurrentListView();
            ModbusEditor.CopyRegistersAsText(CurrentEditor);
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
            Paste();
        }
        private void copyAsTextToolStripMenuItem_Click(object sender, EventArgs e) {
            CopyAsText();
        }
        private void copyToolStripMenuItem1_Click(object sender, EventArgs e) {
            Copy();
        }
        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e) {
            Paste();
        }
        private void resetToolStripMenuItem_Click(object sender, EventArgs e) {
            Reset();
        }
        private void copyNamesToolStripMenuItem_Click(object sender, EventArgs e) {
            ModbusClipboardFlags Flags = ModbusClipboardFlags.IncludeName;
            CopyWithFlags(Flags);
        }
        private void copyFormatsToolStripMenuItem_Click(object sender, EventArgs e) {
            ModbusClipboardFlags Flags = ModbusClipboardFlags.IncludeNothing;
            Flags |= ModbusClipboardFlags.IncludeFormat;
            Flags |= ModbusClipboardFlags.IncludeSize;
            CopyWithFlags(Flags);
        }
        private void copyValuesToolStripMenuItem_Click(object sender, EventArgs e) {
            ModbusClipboardFlags Flags = ModbusClipboardFlags.IncludeValue;
            CopyWithFlags(Flags);
        }
        private void copyAppearanceToolStripMenuItem_Click(object sender, EventArgs e) {
            ModbusClipboardFlags Flags = ModbusClipboardFlags.IncludeAppearance;
            CopyWithFlags(Flags);
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) {
            SelectAll();
        }
        private void selectInvertToolStripMenuItem_Click(object sender, EventArgs e) {
            SelectAllInvert();
        }
        private void selectMatchingValuesToolStripMenuItem_Click(object sender, EventArgs e) {
            ModbusClipboardFlags Flags = ModbusClipboardFlags.IncludeValue;
            SelectMatching(Flags);
        }
        private void selectMatchingNamesToolStripMenuItem_Click(object sender, EventArgs e) {
            ModbusClipboardFlags Flags = ModbusClipboardFlags.IncludeName;
            SelectMatching(Flags);
        }
        private void selectMatchingFormatsToolStripMenuItem_Click(object sender, EventArgs e) {
            ModbusClipboardFlags Flags = ModbusClipboardFlags.IncludeFormat | ModbusClipboardFlags.IncludeSize;
            SelectMatching(Flags);
        }
        #endregion
        #region GoTo
        private void goToToolStripMenuItem1_Click(object sender, EventArgs e) {
            Dialogs.GoTo GoToAddress = new Dialogs.GoTo();
            GoToAddress.IsNumeric = true;
            if (ApplicationManager.OpenInternalApplicationAsDialog(GoToAddress, this) == DialogResult.OK) {
                lstMonitor.VerScroll = GoToAddress.Address;
            }
        }
        private void goToRegisterToolStripMenuItem_Click(object sender, EventArgs e) {
            if (lstMonitor.CurrentItems.Count <= 0) { return; }
            Dialogs.GoTo GoToRegister = new Dialogs.GoTo();
            GoToRegister.IsNumeric = false;
            if (ApplicationManager.OpenInternalApplicationAsDialog(GoToRegister, this) == DialogResult.OK) {
                int Marked = -1;
                string Temp = GoToRegister.GoToText;
                for (int i = 0; i < lstMonitor.CurrentItems.Count; i++) {
                    object? DataTag = lstMonitor.CurrentItems[i].Tag;
                    if (DataTag != null) {
                        if (DataTag.GetType() == typeof(Classes.Modbus.ModbusCoil)) {
                            if (((Classes.Modbus.ModbusCoil)DataTag).Name == Temp) {
                                Marked = i;
                                break;
                            }
                        }
                        else if (DataTag.GetType() == typeof(Classes.Modbus.ModbusRegister)) {
                            if (((Classes.Modbus.ModbusRegister)DataTag).Name == Temp) {
                                Marked = i;
                                break;
                            }
                        }
                    }
                }
                if (Marked >= 0) {
                    lstMonitor.VerScroll = Marked;
                }
            }
        }
        #endregion
        #region Modbus Functions
        private void writeCoilToolStripMenuItem_Click(object sender, EventArgs e) {
            SerialManager? Manager = GetViewManager();
            if (Manager == null) { return; }
            Dialogs.WriteCoil CmdWrite = new Dialogs.WriteCoil(Manager);
            ApplicationManager.OpenInternalApplicationAsDialog(CmdWrite, this);
        }
        private void writeMultipleCoilsToolStripMenuItem_Click(object sender, EventArgs e) {
            SerialManager? Manager = GetViewManager();
            if (Manager == null) { return; }
            Dialogs.WriteCoils CmdWrite = new Dialogs.WriteCoils(Manager);
            ApplicationManager.OpenInternalApplicationAsDialog(CmdWrite, this);
        }
        private void writeRegisterToolStripMenuItem_Click(object sender, EventArgs e) {
            SerialManager? Manager = GetViewManager();
            if (Manager == null) { return; }
            Dialogs.WriteRegister CmdWrite = new Dialogs.WriteRegister(Manager);
            ApplicationManager.OpenInternalApplicationAsDialog(CmdWrite, this);
        }
        private void writeMultipleRegistersToolStripMenuItem_Click(object sender, EventArgs e) {
            SerialManager? Manager = GetViewManager();
            if (Manager == null) { return; }
            Dialogs.WriteRegisters CmdWrite = new Dialogs.WriteRegisters(Manager);
            ApplicationManager.OpenInternalApplicationAsDialog(CmdWrite, this);
        }
        private SerialManager? GetViewManager() {
            try {
                if (currentEditorView == DataEditor.MasterView) {
                    if (CurrentManager == null) { return null; }
                    if (CurrentManager.IsMaster == false) { return null; }
                    return CurrentManager;

                }
                else {
                    if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                        ModbusSnapshot? Snap = ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).Snapshot;
                        if (Snap != null) {
                            if (Snap.Manager != null) {
                                SerialManager? SerMan = Snap.Manager.Manager;
                                if (SerMan == null) { return null; }
                                if (SerMan.IsMaster == false) { return null; }
                                return SerMan;
                            }
                        }
                    }
                }
            }
            catch { }
            return null;
        }
        private void writeRegisterMaskToolStripMenuItem_Click(object sender, EventArgs e) {
            SerialManager? Manager = GetViewManager();
            if (Manager == null) { return; }
            Dialogs.WriteMask CmdWrite = new Dialogs.WriteMask(Manager);
            ApplicationManager.OpenInternalApplicationAsDialog(CmdWrite, this);
        }
        #endregion
        #region Channel Format Settings
        private void SetModbusMaster() {
            try {
                if (currentEditorView == DataEditor.MasterView) {
                    if (CurrentManager == null) { return; }
                    CurrentManager.IsMaster = !CurrentManager.IsMaster;
                    btnMenuModbusMaster.Checked = CurrentManager.IsMaster;
                    modbusMasterToolStripMenuItem.Checked = CurrentManager.IsMaster;

                }
                else {
                    if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                        ModbusSnapshot? Snap = ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).Snapshot;
                        if (Snap != null) {
                            if (Snap.Manager != null) {
                                SerialManager? SerMan = Snap.Manager.Manager;
                                if (SerMan == null) { return; }
                                SerMan.IsMaster = !SerMan.IsMaster;
                                btnMenuModbusMaster.Checked = SerMan.IsMaster;
                                modbusMasterToolStripMenuItem.Checked = SerMan.IsMaster;
                                modbusMasterToolStripMenuItem.Checked = SerMan.IsMaster;
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private void btnMenuModbusMaster_Click(object sender, EventArgs e) {
            SetModbusMaster();
        }
        private void setIOFormatsToModbusRTUToolStripMenuItem_Click(object sender, EventArgs e) {
            SetFormat(true);
        }
        private void setIOFormatsToModbusASCIIToolStripMenuItem_Click(object sender, EventArgs e) {
            SetFormat(false);
        }
        private void SetFormat(bool ModbusRTU) {
            try {
                if (currentEditorView == DataEditor.MasterView) {
                    if (CurrentManager == null) { return; }
                    CurrentManager.InputFormat = ModbusRTU == true ? FormatEnums.StreamInputFormat.ModbusRTU : FormatEnums.StreamInputFormat.ModbusASCII;
                    CurrentManager.OutputFormat = ModbusRTU == true ? FormatEnums.StreamOutputFormat.ModbusRTU : FormatEnums.StreamOutputFormat.ModbusASCII;

                }
                else {
                    if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                        ModbusSnapshot? Snap = ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).Snapshot;
                        if (Snap != null) {
                            if (Snap.Manager != null) {
                                SerialManager? SerMan = Snap.Manager.Manager;
                                if (SerMan == null) { return; }
                                SerMan.InputFormat = ModbusRTU == true ? FormatEnums.StreamInputFormat.ModbusRTU : FormatEnums.StreamInputFormat.ModbusASCII;
                                SerMan.OutputFormat = ModbusRTU == true ? FormatEnums.StreamOutputFormat.ModbusRTU : FormatEnums.StreamOutputFormat.ModbusASCII;
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private void resetAppearanceToolStripMenuItem_Click(object sender, EventArgs e) {
            ListControl? Lst = GetCurrentListView();
            if (Lst == null) { return; }
            List<int> Indices = ModbusEditor.ResetAppearance(sender, Lst);
            DataSelection? Select = GetDataSelection();

            SystemManager.ModbusRegisterAppearanceChanged(GetCurrentSlave(), Indices, Select);
        }
        private void AppearancePopupHost_Closing(object? sender, ToolStripDropDownClosingEventArgs e) {
            ModbusAppearance MbAppear = new ModbusAppearance(popAppearance.UseItemForeColor, popAppearance.ItemForeColor, popAppearance.UseItemBackColor, popAppearance.ItemBackColor, popAppearance.Unit, popAppearance.Prefix);
            List<int> Indices = ModbusEditor.ChangeEntireAppearance(sender, popAppearance.LinkedList, MbAppear);
            popAppearance.LinkedList = null;
            DataSelection? Select = GetDataSelection();

            SystemManager.ModbusRegisterAppearanceChanged(GetCurrentSlave(), Indices, Select);
        }
        private void ddpDataSize_Click(object sender, EventArgs e) {

        }

        private void SystemManager_ModbusAppearanceChanged(ModbusSlave sender, List<int> Indices, DataSelection DataType) {
            if (CurrentManager == null) { return; }
            if (sender.Manager == null) { return; }
            if (CurrentManager.ID != sender.Manager.ID) { return; }
            if (lstMonitor.CurrentItems.Count == 0) { return; }
            foreach (int i in Indices) {
                if (i < lstMonitor.CurrentItems.Count) {
                    object? Data = lstMonitor.CurrentItems[i].Tag;
                    if (Data == null) { continue; }
                    //if (Data.GetType() != typeof(ModbusObject)) { continue; }
                    ModbusObject MBObject = (ModbusObject)Data;
                    lstMonitor.CurrentItems[i].UseLineBackColor = MBObject.UseBackColor;
                    lstMonitor.CurrentItems[i].LineBackColor = MBObject.BackColor;
                    lstMonitor.CurrentItems[i].UseLineForeColor = MBObject.UseForeColor;
                    lstMonitor.CurrentItems[i].LineForeColor = MBObject.ForeColor;
                }
            }
            lstMonitor.Invalidate();
        }
        #endregion
        #region Renaming
        bool InRenameMode = false;
        private void ShowChannelRenameBox(TabClickedEventArgs EventData) {
            Rectangle TabRectangle = EventData.TextArea;
            SerialManager SerMan = ((SerialManager)EventData.SelectedTab);
            string CurrentText = SerMan.Name;
            System.Windows.Forms.TextBox RenameBox = new System.Windows.Forms.TextBox();
            RenameBox.Text = CurrentText;
            RenameBox.Font = navigator1.Font;
            // RenameBox.BorderStyle = BorderStyle.None;
            RenameBox.Multiline = false;
            int CentreHeight = 0;
            RenameBox.Show();
            if (TabRectangle.Height > RenameBox.ClientSize.Height) {
                CentreHeight = ((TabRectangle.Height - RenameBox.ClientSize.Height) / 2) + TabRectangle.Y;
            }
            else {
                CentreHeight = ((RenameBox.ClientSize.Height - TabRectangle.Height) / 2) + TabRectangle.Y;
            }
            RenameBox.Location = new Point(TabRectangle.X, CentreHeight);
            RenameBox.Size = TabRectangle.Size;
            RenameBox.BringToFront();
            RenameBox.Tag = EventData;
            InRenameMode = true;
            navigator1.Controls.Add(RenameBox);
            RenameBox.Focus();
            RenameBox.Leave += RenameBox_Leave;
            RenameBox.LostFocus += RenameBox_LostFocus;
            RenameBox.KeyDown += RenameBox_KeyDown; ; ;
            RenameBox.TextChanged += RenameBox_TextChanged;
        }
        private void RenameBox_Leave(object? sender, EventArgs e) {
            if (sender == null) { return; }
            //if (sender.GetType() == typeof(TextBox)) {
            //    DeregisterTextbox((TextBox)sender);
            //    thPrograms.Controls.Remove((TextBox)sender);
            //}
            RemoveFromControl(sender);
        }
        private void RenameBox_KeyDown(object? sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.Enter) {
                if (sender == null) { return; }
                //if (sender.GetType() == typeof(TextBox)) {
                //    DeregisterTextbox((TextBox)sender);
                //    thPrograms.Controls.Remove((TextBox)sender);
                //}
                RemoveFromControl(sender);
                e.Handled = true;
                e.SuppressKeyPress = true;

            }
        }
        private void RemoveFromControl(object Ctrl) {
            if (Ctrl.GetType() == typeof(System.Windows.Forms.TextBox)) {
                System.Windows.Forms.TextBox TxBx = (System.Windows.Forms.TextBox)Ctrl;
                if (TxBx.Tag == null) { return; }
                if (TxBx.Tag.GetType() == typeof(TabClickedEventArgs)) {
                    TabClickedEventArgs TCEA = (TabClickedEventArgs)TxBx.Tag;
                    if (TCEA.SelectedTab == null) { return; }
                    if (TCEA.SelectedTab.GetType() == typeof(SerialManager)) {
                        navigator1.Controls.Remove(TxBx);
                    }
                    else if (TCEA.SelectedTab.GetType() == typeof(Tab)) {
                        thSlaves.Controls.Remove(TxBx);
                    }
                }
                DeregisterTextbox((System.Windows.Forms.TextBox)Ctrl);
            }
        }
        private void RenameBox_TextChanged(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(System.Windows.Forms.TextBox)) {
                System.Windows.Forms.TextBox TxBx = (System.Windows.Forms.TextBox)sender;
                if (TxBx.Tag == null) {
                    //DeregisterTextbox(TxBx);
                    //thPrograms.Controls.Remove(TxBx);
                    RemoveFromControl(sender);
                }
                else {
                    if (TxBx.Tag.GetType() == typeof(TabClickedEventArgs)) {
                        TabClickedEventArgs TCEA = (TabClickedEventArgs)TxBx.Tag;
                        object? Data = TCEA.SelectedTab;
                        if (Data == null) { return; }
                        if (Data.GetType() == typeof(Tab)) {
                            Tab TabData = (Tab)Data;
                            if (TabData.Tag == null) {
                                return;
                            }
                            if (TabData.Tag.GetType() == typeof(ProgramObject)) {
                                TabData.Text = TxBx.Text;
                                ((ProgramObject)TabData.Tag).Name = TxBx.Text;
                            }
                            else if (TabData.Tag.GetType() == typeof(ModbusSlave)) {

                                ((ModbusSlave)TabData.Tag).Name = TxBx.Text;
                                TabData.Text = ((ModbusSlave)TabData.Tag).DisplayName;
                            }

                        }
                        else if (Data.GetType() == typeof(SerialManager)) {
                            SystemManager.SerialManagers[TCEA.Index].Name = TxBx.Text;
                            navigator1.Invalidate();
                        }
                    }
                }
            }
        }
        private void RenameBox_LostFocus(object? sender, EventArgs e) {
            if (sender == null) { return; }
            //if (sender.GetType() == typeof(TextBox)) {
            //    DeregisterTextbox((TextBox)sender);
            //    thPrograms.Controls.Remove((TextBox)sender);
            //}
            RemoveFromControl(sender);
        }
        private void DeregisterTextbox(System.Windows.Forms.TextBox Tb) {
            Tb.Tag = null;
            Tb.Leave -= RenameBox_Leave;
            Tb.LostFocus -= RenameBox_LostFocus;
            Tb.TextChanged -= RenameBox_TextChanged;
            Tb.KeyDown -= RenameBox_KeyDown;
            InRenameMode = false;
        }
        #endregion
        #region Channel Actions
        private void btnRenameChannel_Click(object sender, EventArgs e) {
            TabClickedEventArgs? TagData = GetClickedArgs(cmChannels.Tag);
            if (TagData == null) { return; }
            if (TagData.SelectedTab.GetType() != typeof(SerialManager)) { return; }
            ShowChannelRenameBox(TagData);
        }
        private void btnModbusMaster_Click(object sender, EventArgs e) {
            TabClickedEventArgs? TagData = GetClickedArgs(cmChannels.Tag);
            if (TagData != null) {
                if (TagData.SelectedTab.GetType() == typeof(SerialManager)) {
                    ((SerialManager)TagData.SelectedTab).IsMaster = !((SerialManager)TagData.SelectedTab).IsMaster;
                }
            }
        }
        private void connectToolStripMenuItem_Click(object sender, EventArgs e) {
            TabClickedEventArgs? TagData = GetClickedArgs(cmChannels.Tag);
            if (TagData != null) {
                if (TagData.SelectedTab.GetType() == typeof(SerialManager)) {
                    ((SerialManager)TagData.SelectedTab).Connect();
                }
            }
        }
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) {
            TabClickedEventArgs? TagData = GetClickedArgs(cmChannels.Tag);
            if (TagData != null) {
                if (TagData.SelectedTab.GetType() == typeof(SerialManager)) {
                    ((SerialManager)TagData.SelectedTab).Disconnect();
                }
            }
        }
        private TabClickedEventArgs? GetClickedArgs(object? TagData) {
            if (TagData != null) {
                if (TagData.GetType() == typeof(TabClickedEventArgs)) {
                    TabClickedEventArgs Tb = (TabClickedEventArgs)TagData;
                    return Tb;
                }
            }
            return null;
        }
        private void navigator1_TabRightClicked(object sender, TabClickedEventArgs Tab) {
            if (sender == null) { return; }
            cmChannels.Tag = Tab;
            if (Tab.SelectedTab.GetType() == typeof(SerialManager)) {
                SerialManager SerMan = (SerialManager)Tab.SelectedTab;
                btnModbusMaster.Checked = SerMan.IsMaster;
                //outputInTerminalToolStripMenuItem.Checked = SerMan.OutputToMasterTerminal;
                if (SerMan.Connected == true) {
                    connectToolStripMenuItem.Enabled = false;
                    disconnectToolStripMenuItem.Enabled = true;
                }
                else {
                    connectToolStripMenuItem.Enabled = true;
                    disconnectToolStripMenuItem.Enabled = false;
                }
            }
            cmChannels.Show(Tab.ScreenLocation);
        }
        #endregion

        private void thSlaves_SelectedIndexChanged(object sender, int CurrentIndex, int PreviousIndex) {
            GetSelectedTabSlave(CurrentIndex);
        }
        private void GetSelectedTabSlave(int CurrentIndex) {
            try {
                object? Val = thSlaves.Tabs[CurrentIndex].Tag;
                if (Val == null) { return; }
                if (Val.GetType() == typeof(ModbusSlave)) {
                    Slave = ((ModbusSlave)Val).Address;
                }
            }
            catch { }
        }

        private void modbusMasterToolStripMenuItem_Click(object sender, EventArgs e) {
            SetModbusMaster();
        }

        private void thSlaves_HeaderClicked(object sender, TabHeaderClickedArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() != typeof(ODModules.TabHeader)) { return; }
            cmMBChannel.Tag = null;
            Point RelativePoint = e.Location;
            Point ThSlavesScreenLocation = thSlaves.PointToScreen(e.Location);
            RelativePoint = new Point(e.Location.X + ThSlavesScreenLocation.X, e.Location.Y + ThSlavesScreenLocation.Y + thSlaves.Height);
            cmMBChannel.Show(RelativePoint);
        }
        private void newUnitToolStripMenuItem1_Click(object sender, EventArgs e) {
            NewSlave();
        }
        private void renameUnitToolStripMenuItem1_Click(object sender, EventArgs e) {
            TabClickedEventArgs? TagData = thSlaves.GetCurrentTabEventArgs();//GetClickedArgs(cmMBChannel.Tag);
            if (TagData == null) { return; }
            // if (TagData.SelectedTab.GetType() != typeof(SerialManager)) { return; }
            ShowSlaveRenameBox(TagData, true);
        }
        private void removeUnitToolStripMenuItem1_Click(object sender, EventArgs e) {
            RemoveSelectedSlave();
        }
        private void newUnitToolStripMenuItem_Click(object sender, EventArgs e) {
            NewSlave();
        }
        private void removeUnitToolStripMenuItem_Click(object sender, EventArgs e) {
            RemoveSelectedSlave();
        }
        private void renameUnitToolStripMenuItem_Click(object sender, EventArgs e) {
            TabClickedEventArgs? TagData = thSlaves.GetCurrentTabEventArgs();//GetClickedArgs(cmMBChannel.Tag);
            if (TagData == null) { return; }
            // if (TagData.SelectedTab.GetType() != typeof(SerialManager)) { return; }
            ShowSlaveRenameBox(TagData, true);
        }
        private void thSlaves_TabDoubleClicked(object sender, TabClickedEventArgs Tab) {
            TabClickedEventArgs? TagData = thSlaves.GetCurrentTabEventArgs();//GetClickedArgs(cmMBChannel.Tag);
            if (TagData == null) { return; }
            // if (TagData.SelectedTab.GetType() != typeof(SerialManager)) { return; }
            ShowSlaveRenameBox(TagData, true);
        }
        private void ShowSlaveRenameBox(TabClickedEventArgs EventData, bool PushEventData = false) {
            if (PushEventData) {
                thSlaves.Tag = EventData;
            }
            Rectangle TabRectangle = UserInterfaceManager.GetRectangleFromTab(thSlaves, true);
            object? SelectedTab = EventData.SelectedTab;
            if (SelectedTab.GetType() != typeof(Tab)) { return; }
            object? TabData = ((Tab)SelectedTab).Tag;
            if (TabData == null) { return; }
            if (TabData.GetType() != typeof(ModbusSlave)) { return; }
            ModbusSlave? SlaveObj = (ModbusSlave)TabData;
            if (SlaveObj == null) { return; }
            string CurrentText = SlaveObj.Name;
            System.Windows.Forms.TextBox RenameBox = new System.Windows.Forms.TextBox();
            RenameBox.Text = CurrentText;
            RenameBox.Font = thSlaves.Font;
            // RenameBox.BorderStyle = BorderStyle.None;
            RenameBox.Multiline = false;
            int CentreHeight = 0;
            RenameBox.Show();
            if (TabRectangle.Height > RenameBox.ClientSize.Height) {
                CentreHeight = ((TabRectangle.Height - RenameBox.ClientSize.Height) / 2) + TabRectangle.Y;
            }
            else {
                CentreHeight = ((RenameBox.ClientSize.Height - TabRectangle.Height) / 2) + TabRectangle.Y;
            }
            RenameBox.Location = new Point(TabRectangle.X, CentreHeight);
            RenameBox.Size = TabRectangle.Size;
            RenameBox.BringToFront();
            RenameBox.Tag = EventData;
            InRenameMode = true;
            thSlaves.Controls.Add(RenameBox);
            RenameBox.Focus();
            RenameBox.Leave += RenameBox_Leave;
            RenameBox.LostFocus += RenameBox_LostFocus;
            RenameBox.KeyDown += RenameBox_KeyDown; ; ;
            RenameBox.TextChanged += RenameBox_TextChanged;
        }
        private ModbusSlave? GetSlaveFromTab(TabClickedEventArgs? Args) {
            if (Args == null) {
                if (CurrentManager == null) { return null; }
                try {
                    if (CurrentManager.IsMaster == false) { return null; }
                    return CurrentManager.Slave[slaveAddress];
                }
                catch { return null; }
            }
            else {
                return null;
            }
        }
        private void NewSlave() {
            if (CurrentManager == null) { return; }
            Dialogs.NewUnit InsSnap = new Dialogs.NewUnit(CurrentManager);
            // PrgProp.SelectedProgram = (ProgramObject)lstStepProgram.Tag;
            ApplicationManager.OpenInternalApplicationAsDialog(InsSnap, this);
            if (InsSnap.DialogResult == DialogResult.OK) {
                if (InsSnap.Manager != null) {
                    CurrentManager.NewSlave(InsSnap.Unit, InsSnap.DisplayName);
                }
            }
            InsSnap.CleanUp();
        }
        private void RemoveSelectedSlave() {
            if (CurrentManager == null) { return; }
            if ((slaveindex < thSlaves.Tabs.Count) && (slaveindex >= 0)) {
                thSlaves.Tabs[slaveindex].Tag = null;
            }
            CurrentManager.RemoveSlave(Slave);
        }
        private void thSlaves_CloseButtonClicked(object sender, int Index) {
            if (CurrentManager == null) { return; }
            object? Data = thSlaves.Tabs[Index].Tag;
            if (Data == null) { return; }
            int SlaveTemp = -1;
            if (Data.GetType() == typeof(ModbusSlave)) {
                SlaveTemp = ((ModbusSlave)Data).Address;
            }
            if ((slaveindex < thSlaves.Tabs.Count) && (Index >= 0)) {
                thSlaves.Tabs[Index].Tag = null;
            }
            CurrentManager.RemoveSlave(SlaveTemp);
        }

        private void showUnitsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (currentEditorView == DataEditor.MasterView) {
                ProjectManager.ShowUnits = !ProjectManager.ShowUnits;
                showUnitsToolStripMenuItem.Checked = ProjectManager.ShowUnits;
                ModbusEditor.LoadRegisters(lstMonitor, CurrentManager, dataSet, slaveindex);
            }
            else if (currentEditorView == DataEditor.SnapshotView) {
                try {
                    if (mdiClient.ChildForms[SnapshotCurrentIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                        bool UnitsVisable = ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).ShowUnits;
                        ((ToolWindows.ModbusRegister)mdiClient.ChildForms[SnapshotCurrentIndex]).ShowUnits = !UnitsVisable;
                        CurrentEditorView = currentEditorView;
                    }
                }
                catch { }
            }
        }

        private void changeAppearanceToolStripMenuItem_Click(object sender, EventArgs e) {
            ListControl? CurrentEditor = GetCurrentListView();
            popAppearance.LinkedList = CurrentEditor;

            AppearancePopupHost.ShowAndCentre(this);
        }
        private bool BitToggleEnabled() {
            ListControl? CurrentEditor = GetCurrentListView();
            if (CurrentEditor == null) { return false; }
            if (CurrentEditor.SelectionCount != 1) { return false; }
            int Index = CurrentEditor.SelectedIndex;
            object? TagData = CurrentEditor.CurrentItems[Index].Tag;
            if (TagData == null) { return false; }
            if (TagData.GetType() != typeof(ModbusRegister)) { return false; }
            ModbusRegister Register = (ModbusRegister)TagData;
            if (Register.Format != DataFormat.Binary) { return false; }
            return true;
        }
        private void bitTogglerToolStripMenuItem_Click(object sender, EventArgs e) {
            ListControl? CurrentEditor = GetCurrentListView();
            if (CurrentEditor == null) { return; }
            if (CurrentEditor.SelectionCount != 1) { return; }
            int Index = CurrentEditor.SelectedIndex;
            object? TagData = CurrentEditor.CurrentItems[Index].Tag;
            if (TagData == null) { return; }
            if (TagData.GetType() != typeof(ModbusRegister)) { return; }
            ModbusRegister Register = (ModbusRegister)TagData;
            if (Register.Format != DataFormat.Binary) { return; }
            popToggler.Register = (ModbusRegister)TagData;
            BitTogglerPopupHost.ShowAndCentre(this);
            //ModbusEditor.CopyRegistersAsText(CurrentEditor);
        }
        private void BitTogglerPopupHost_Closing(object? sender, ToolStripDropDownClosingEventArgs e) {
            popToggler.Register = null;
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            bitTogglerToolStripMenuItem.Enabled = BitToggleEnabled();
        }

        private void lstMonitor_ItemClicked(object sender, ListItem Item, int Index, Rectangle ItemBounds) {
            bitTogglerToolStripMenuItem.Enabled = BitToggleEnabled();
        }
        private void lstMonitor_ValueChanged() {
            bitTogglerToolStripMenuItem.Enabled = BitToggleEnabled();
        }
        private void querySenderToolStripMenuItem_Click(object sender, EventArgs e) {
            QueryEditor QueryApp = new QueryEditor();
            ApplicationManager.OpenInternalApplicationOnce(QueryApp, true);
        }

        private void ModbusRegisters_LocationChanged(object sender, EventArgs e) {

        }

        private enum DataEditor {
            MasterView = 0x00,
            SnapshotView = 0x01
        }
    }
}
