using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Handlers;
using System.Diagnostics;
using Svg;
using ODModules;
using Serial_Monitor.Classes.Enums;
using Serial_Monitor.Components;

namespace Serial_Monitor.Docks {
    public partial class ModbusProperties : ODModules.Docking.ToolWindow, Interfaces.ITheme {
        ModbusRegisters? EditorInstance = null;

        TemplateContextMenuHost ?TextColorPopupHost;
        ColorPopup popTextColor = new ColorPopup(false);

        TemplateContextMenuHost ?BackColorPopupHost;
        ColorPopup popBackColor = new ColorPopup(true);
        protected override CreateParams CreateParams {
            get {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        bool PreventLoad = true;
        public ModbusProperties(ModbusRegisters? EditorInstance) {
            InitializeComponent();
            this.EditorInstance = EditorInstance;
            if (this.EditorInstance != null) {
                this.EditorInstance.FormClosing += EditorInstance_FormClosing;
                this.EditorInstance.ViewChanged += EditorInstance_ViewChanged;
                TextColorPopupHost = new TemplateContextMenuHost(popTextColor, this.EditorInstance);
                BackColorPopupHost = new TemplateContextMenuHost(popBackColor, this.EditorInstance);
                popTextColor.Host = TextColorPopupHost;
                popBackColor.Host = BackColorPopupHost;
                TextColorPopupHost.Closing += TextColorPopupHost_Closing;
                BackColorPopupHost.Closing += BackColorPopupHost_Closing;
                TextColorPopupHost.Opening += TextColorPopupHost_Opening;
                BackColorPopupHost.Opening += BackColorPopupHost_Opening;
            }
            Classes.Modbus.ModbusEditor.EditorPropertiesEqual += ModbusEditor_EditorPropertiesEqual;
            EnumManager.LoadDataSizes(toolStrip1, DataSize_Click);
            EnumManager.LoadCoilFormats(ddlBooleanDisplay, ModbusEnums.CoilFormat.Boolean);
            EnumManager.LoadDataFormats(ddlDisplay, ModbusEnums.DataFormat.Decimal);
            EnumManager.LoadWordOrders(ddlEndianness, ModbusEnums.ByteOrder.LittleEndian);
            EnumManager.LoadFloatFormats(ddlDecimalPlaces, ModbusEnums.FloatFormat.None);
            AdjustUI();
            PreventLoad = false;
        }
        private void AdjustUI() {
            if (PreventLoad == false) { return; }
            foreach(Control LblPnlParent in panel2.Controls) {
                if (LblPnlParent.GetType() != typeof(LabelPanel)) { continue; }
                foreach (Control LblPnl in LblPnlParent.Controls) {
                    if (LblPnl.GetType() != typeof(LabelPanel)) { continue; }
                    LabelPanel LblPnlCtrl = (LabelPanel)LblPnl;
                    if (LblPnlCtrl.Inlinelabel) {
                        LblPnlCtrl.InlineWidth = DesignerSetup.ScaleInteger(LblPnlCtrl.InlineWidth);
                    }

                }
            }
        }
        private void ModbusEditor_EditorPropertiesEqual(ODModules.ListControl LstControl, ModbusPropertyFlags EqualProperties, ModbusProperty CurrentProperties, bool ItemsSelected) {
            this.BeginInvoke(new MethodInvoker(delegate {
                AdjustProperties(EqualProperties, CurrentProperties, ItemsSelected);
            }));
        }
        private void SetEditors(bool Enabled) {
            ddlBooleanDisplay.Enabled = Enabled;
            ddlDisplay.Enabled = Enabled;
            ddlDecimalPlaces.Enabled = Enabled;
            ddlEndianness.Enabled = Enabled;
            ddlDisplay.Enabled = Enabled;
            tbUnit.Enabled = Enabled;
            pfsMain.Enabled = Enabled;
        }
        private void AdjustProperties(ModbusPropertyFlags EqualProperties, ModbusProperty CurrentProperties, bool ItemsSelected) {
            PreventLoad = true;
            SetEditors(ItemsSelected);
            if (IsFlagEqual(EqualProperties, ModbusPropertyFlags.ForeColor)) {
                SetButtonColor(btnTextColor, CurrentProperties.ForeColor, CurrentProperties.UseForeColor);
            }
            else {
                SetButtonColor(btnTextColor, CurrentProperties.ForeColor, false);
            }
            if (IsFlagEqual(EqualProperties, ModbusPropertyFlags.BackColor)) {
                SetButtonColor(btnBackColor, CurrentProperties.BackColor, CurrentProperties.UseBackColor);
            }
            else {
                SetButtonColor(btnBackColor, CurrentProperties.BackColor, false);
            }
            if (IsFlagEqual(EqualProperties, ModbusPropertyFlags.Size)) {

            }
            if (IsFlagEqual(EqualProperties, ModbusPropertyFlags.Prefix)) {
                ntbMain.Prefix = (NumericTextbox.MetricPrefix)CurrentProperties.Prefix;
                pfsMain.Invalidate();
            }
            else {
                ntbMain.Prefix = NumericTextbox.MetricPrefix.None;
                pfsMain.Invalidate();
            }
            if (IsFlagEqual(EqualProperties, ModbusPropertyFlags.Unit)) {
                tbUnit.Text = CurrentProperties.Unit;
            }
            else {
                tbUnit.Text = "";
            }
            if (IsFlagEqual(EqualProperties, ModbusPropertyFlags.Format)) {
                try {
                    ddlDisplay.SelectedIndex = (int)CurrentProperties.Format;
                }
                catch { }
                try {
                    ddlBooleanDisplay.SelectedIndex = (int)CurrentProperties.CoilFormat;
                }
                catch { }
            }
            else {
                ddlDisplay.SelectedIndex = -1;
                ddlBooleanDisplay.SelectedIndex = -1;
            }
            if (IsFlagEqual(EqualProperties, ModbusPropertyFlags.DecimalFormat)) {
                try {
                    ddlDecimalPlaces.SelectedIndex = (int)CurrentProperties.DecimalFormat;
                }
                catch { }
            }
            else {
                ddlDecimalPlaces.SelectedIndex = -1;
            }
            if (IsFlagEqual(EqualProperties, ModbusPropertyFlags.ByteOrder)) {
                try {
                    SelectWordSize(CurrentProperties.WordOrder);
                }
                catch { }
            }
            else {
                ddlEndianness.SelectedIndex = -1;
            }
            PreventLoad = false;
        }
        private void SelectWordSize(ModbusEnums.ByteOrder WordOrder) {
            string Temp_ByteOrder = EnumManager.WordOrderToString(WordOrder).A;
            for (int i = 0; i < ddlEndianness.Items.Count; i++) {
                object? Item = ddlEndianness.Items[i];
                if (Item == null) { continue; }
                string ItemValue = Item.ToString() ?? "";
                if (ItemValue == Temp_ByteOrder) {
                    ddlEndianness.SelectedIndex = i; break;
                }
            }
        }
        private bool IsFlagEqual(ModbusPropertyFlags SetFlags, ModbusPropertyFlags FlagToCheck) {
            int Flags = (int)SetFlags;
            if ((Flags & (int)FlagToCheck) == (int)FlagToCheck) { return true; }
            return false;
        }
        private void EditorInstance_ViewChanged(object? sender) {
            DataSelection? Select = GetDataSelection();
            ModbusSnapshot? Snap = GetSnapshot();
            if (Snap == null) {
                lblpnlSnapshot.Visible = false;
            }
            else {
                PreventLoad = true;
                tbSnapshotName.Text = Snap.BaseName;
                PreventLoad = false;
                lblpnlSnapshot.Visible = true;
            }
            if (Select == null) {
                lblpnlFormat.Visible = false;
                lblpnlAppearance.Visible = false;
                lblpnlBoolDisplay.Visible = false;
                lblpnlDisplay.Visible = false;
                lblpnlEndianess.Visible = false;
                lblpnlSize.Visible = false;
                lblpnlUnits.Visible = false;
                lblpnlDecimalFormat.Visible = false;
                return;
            }
            lblpnlFormat.Visible = true;
            lblpnlAppearance.Visible = true;
            if (Select > DataSelection.ModbusDataDiscreteInputs) {
                lblpnlBoolDisplay.Visible = false;
                lblpnlDisplay.Visible = true;
                lblpnlEndianess.Visible = true;
                lblpnlSize.Visible = true;
                lblpnlUnits.Visible = true;
                lblpnlDecimalFormat.Visible = true;
            }
            else {
                lblpnlBoolDisplay.Visible = true;
                lblpnlDisplay.Visible = false;
                lblpnlEndianess.Visible = false;
                lblpnlSize.Visible = false;
                lblpnlUnits.Visible = false;
                lblpnlDecimalFormat.Visible = false;
            }
        }

        private void DataSize_Click(object? sender, EventArgs e) {
            if (sender == null) { return; }
            this.Focus();
            //if (sender.GetType() != typeof(ToolStripMenuItem)) { return; }
            //ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
            //object? Tag = Tsmi.Tag;
            //if (Tag == null) { return; }
            //if (sender.GetType() != typeof(Classes.Enums.ModbusEnums.DataSize)) { return; }
            ODModules.ListControl? CurrentEditor = GetCurrentListView();
            bool ShowUnits = GetCurrentShowUnitsState();
            //Classes.Enums.ModbusEnums.DataSize DataSize = (Classes.Enums.ModbusEnums.DataSize)sender;
            //DataSelection? Select = GetDataSelection();
            //Classes.Modbus.ModbusEditor.ChangeSize(GetCurrentSlave(), Select, sender, CurrentEditor, DataSize);
            Classes.Modbus.ModbusEditor.ChangeSizeList(sender, CurrentEditor, ShowUnits);
        }
        private void EditorInstance_FormClosing(object? sender, FormClosingEventArgs e) {
            if (EditorInstance == null) { return; }
            EditorInstance.FormClosing -= EditorInstance_FormClosing;
            EditorInstance = null;
            Classes.Modbus.ModbusEditor.EditorPropertiesEqual -= ModbusEditor_EditorPropertiesEqual;
        }

        private void ModbusProperties_Load(object sender, EventArgs e) {

        }
        public void ApplyTheme() {
            foreach (Control control in panel2.Controls) {
                ThemeManager.ThemeControlAlternative(control);
                ThemePanel(control);
            }
            ThemeManager.ThemeControlAlternative(pfsMain);
            ThemeManager.ThemeControl(toolStrip1);
            ThemeManager.ThemeControl(ddlBooleanDisplay);
            ThemeManager.ThemeControl(ddlEndianness);
            ThemeManager.ThemeControl(ddlDisplay);
            ThemeManager.ThemeControl(ddlDecimalPlaces);
            ThemeManager.ThemeControl(tbUnit);
            ThemeManager.ThemeControl(tbSnapshotName);
            ThemeManager.ThemeControl(btnTextColor, true);
            ThemeManager.ThemeControl(btnBackColor, true);

        }
        private void ThemePanel(object Pnl) {
            if (Pnl.GetType() == typeof(LabelPanel)) {
                LabelPanel ChildPnl = (LabelPanel)Pnl;
                foreach (Control control in ChildPnl.Controls) {
                    ThemeManager.ThemeControlAlternative(control);
                }
            }
        }
        private ODModules.ListControl? GetCurrentListView() {
            if (EditorInstance == null) { return null; }
            return EditorInstance.GetCurrentListView();
        }
        private bool GetCurrentShowUnitsState() {
            if (EditorInstance == null) { return false; }
            return EditorInstance.GetCurrentShowUnits();
        }
        private DataSelection? GetDataSelection() {
            if (EditorInstance == null) { return null; }
            return EditorInstance.GetDataSelection();
        }
        private ModbusSnapshot? GetSnapshot() {
            if (EditorInstance == null) { return null; }
            if (EditorInstance.CurrentEditorView == ModbusRegisters.DataEditor.MasterView) { return null; }
            try {
                int TempIndex = EditorInstance.SnapshotCurrentIndex;
                if (TempIndex >= 0) {
                    if (EditorInstance.editorModbus.ssClient.ChildForms[TempIndex].GetType() == typeof(ToolWindows.ModbusRegister)) {
                        ModbusSnapshot? Snap = ((ToolWindows.ModbusRegister)EditorInstance.editorModbus.ssClient.ChildForms[TempIndex]).Snapshot;
                        return Snap;
                    }
                }
            }
            catch {
                return null;
            }
            return null;
        }
        private ModbusSlave? GetCurrentSlave() {
            if (EditorInstance == null) { return null; }
            return EditorInstance.GetCurrentSlave();
        }
        ConversionHandler.Prefix LastPrefix = ConversionHandler.Prefix.None;
        private void ntbMain_PrefixChanged(object sender) {
            if (PreventLoad == true) { return; }
            ODModules.ListControl? CurrentEditor = GetCurrentListView();
            DataSelection? Select = GetDataSelection();
            //ModbusAppearance MbAppear = new ModbusAppearance(popAppearance.UseItemForeColor, popAppearance.ItemForeColor, popAppearance.UseItemBackColor, popAppearance.ItemBackColor, popAppearance.Unit, popAppearance.Prefix);
            ConversionHandler.Prefix CurrentPrefix = (ConversionHandler.Prefix)ntbMain.Prefix;
            if (LastPrefix != CurrentPrefix) {
                //Debug.Print("RQ");
                Classes.Modbus.ModbusEditor.ChangePrefix(GetCurrentSlave(), Select, sender, CurrentEditor, CurrentPrefix);
            }
            LastPrefix = CurrentPrefix;

        }

        private void labelPanel2_Paint(object sender, PaintEventArgs e) {

        }
        private void ddlDisplay_SelectedIndexChanged(object sender, EventArgs e) {
            if (PreventLoad == true) { return; }
            ODModules.ListControl? CurrentEditor = GetCurrentListView();
            bool ShowUnits = GetCurrentShowUnitsState();
            //Classes.Enums.ModbusEnums.DataSize DataSize = (Classes.Enums.ModbusEnums.DataSize)sender;
            //DataSelection? Select = GetDataSelection();
            //Classes.Modbus.ModbusEditor.ChangeSize(GetCurrentSlave(), Select, sender, CurrentEditor, DataSize);
            Classes.Modbus.ModbusEditor.ChangeDisplayFormatListDual(EnumManager.IntegerToDataFormat(ddlDisplay.SelectedIndex), CurrentEditor, ShowUnits);
        }

        private void ddlEndianness_SelectedIndexChanged(object sender, EventArgs e) {
            if (PreventLoad == true) { return; }
            ODModules.ListControl? CurrentEditor = GetCurrentListView();
            bool ShowUnits = GetCurrentShowUnitsState();
            //Classes.Enums.ModbusEnums.DataSize DataSize = (Classes.Enums.ModbusEnums.DataSize)sender;
            //DataSelection? Select = GetDataSelection();
            //Classes.Modbus.ModbusEditor.ChangeSize(GetCurrentSlave(), Select, sender, CurrentEditor, DataSize);
            Classes.Modbus.ModbusEditor.ChangeWordOrderList(EnumManager.IntegerToWordOrder(ddlEndianness.SelectedIndex), CurrentEditor, ShowUnits);
        }

        private void tbUnit__TextChanged(object sender, EventArgs e) {
            if (PreventLoad == true) { return; }
            ODModules.ListControl? CurrentEditor = GetCurrentListView();
            DataSelection? Select = GetDataSelection();
            Classes.Modbus.ModbusEditor.ChangeUnit(GetCurrentSlave(), Select, sender, CurrentEditor, tbUnit.Text);
        }

        private void ddlBooleanDisplay_SelectedIndexChanged(object sender, EventArgs e) {
            if (PreventLoad == true) { return; }
            ODModules.ListControl? CurrentEditor = GetCurrentListView();
            //Classes.Enums.ModbusEnums.DataSize DataSize = (Classes.Enums.ModbusEnums.DataSize)sender;
            //DataSelection? Select = GetDataSelection();
            //Classes.Modbus.ModbusEditor.ChangeSize(GetCurrentSlave(), Select, sender, CurrentEditor, DataSize);
            Classes.Modbus.ModbusEditor.ChangeCoilFormatList(EnumManager.IntegerToCoilFormat(ddlBooleanDisplay.SelectedIndex), CurrentEditor);
        }
        private void ddlDecimalPlaces_SelectedIndexChanged(object sender, EventArgs e) {
            if (PreventLoad == true) { return; }
            ODModules.ListControl? CurrentEditor = GetCurrentListView();
            //Classes.Enums.ModbusEnums.DataSize DataSize = (Classes.Enums.ModbusEnums.DataSize)sender;
            //DataSelection? Select = GetDataSelection();
            //Classes.Modbus.ModbusEditor.ChangeSize(GetCurrentSlave(), Select, sender, CurrentEditor, DataSize);
            Classes.Modbus.ModbusEditor.ChangeFloatFormatList(EnumManager.IntegerToFloatFormat(ddlDecimalPlaces.SelectedIndex), CurrentEditor);

        }

        private void btnTextColor_ButtonClicked(object sender) {
            if (TextColorPopupHost == null) { return; }
            TextColorPopupHost.Show((Control)sender, new Rectangle(0, 0, 0, ((Control)sender).Height));
        }

        private void btnBackColor_ButtonClicked(object sender) {
            if (BackColorPopupHost == null) { return; }
            BackColorPopupHost.Show((Control)sender, new Rectangle(0, 0, 0, ((Control)sender).Height));
        }
        private void BackColorPopupHost_Closing(object? sender, ToolStripDropDownClosingEventArgs e) {
            if (PreventLoad == true) { return; }
            if (popBackColor.IsValid == false) { return; }
            ODModules.ListControl? CurrentEditor = GetCurrentListView();
            DataSelection? Select = GetDataSelection();
            SetButtonColor(btnBackColor, popBackColor.SelectedColor, popBackColor.ApplyColor);
            Classes.Modbus.ModbusEditor.ChangeBackColor(GetCurrentSlave(), Select, sender, CurrentEditor, popBackColor.SelectedColor, popBackColor.ApplyColor);
        }
        private void TextColorPopupHost_Closing(object? sender, ToolStripDropDownClosingEventArgs e) {
            if (PreventLoad == true) { return; }
            if (popTextColor.IsValid == false) { return; }
            ODModules.ListControl? CurrentEditor = GetCurrentListView();
            DataSelection? Select = GetDataSelection();
            SetButtonColor(btnTextColor, popTextColor.SelectedColor, popTextColor.ApplyColor);
            Classes.Modbus.ModbusEditor.ChangeTextColor(GetCurrentSlave(), Select, sender, CurrentEditor, popTextColor.SelectedColor, popTextColor.ApplyColor);
        }
        private void SetButtonColor(ODModules.Button Btn, Color DisplayColor, bool UseColor) {
            if (UseColor) {
                Btn.BackColorNorth = DisplayColor;
                Btn.BackColorSouth = DisplayColor;
            }
            else {
                Btn.BackColorNorth = Color.Transparent;
                Btn.BackColorSouth = Color.Transparent;
            }
        }
        private void BackColorPopupHost_Opening(object? sender, CancelEventArgs e) {
            popBackColor.ResetState();
        }
        private void TextColorPopupHost_Opening(object? sender, CancelEventArgs e) {
            popTextColor.ResetState();
        }
        private void tbSnapshotName__TextChanged(object sender, EventArgs e) {
            if (PreventLoad == true) { return; }
            ModbusSnapshot? Snap = GetSnapshot();
            if (Snap == null) { return; }
            Snap.Name = tbSnapshotName.Text;
        }
    }
}
