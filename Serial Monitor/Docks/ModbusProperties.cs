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

namespace Serial_Monitor.Docks {
    public partial class ModbusProperties : ODModules.Docking.ToolWindow, Interfaces.ITheme {
        ModbusRegisters? EditorInstance = null;
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
            }
            EnumManager.LoadDataSizes(toolStrip1, DataSize_Click);
            EnumManager.LoadCoilFormats(ddlBooleanDisplay, ModbusEnums.CoilFormat.Boolean);
            EnumManager.LoadDataFormats(ddlDisplay, ModbusEnums.DataFormat.Decimal);
            EnumManager.LoadWordOrders(ddlEndianness, ModbusEnums.ByteOrder.LittleEndian);
            PreventLoad = false;
        }

        private void EditorInstance_ViewChanged(object? sender) {
            DataSelection? Select = GetDataSelection();
            if (Select > DataSelection.ModbusDataDiscreteInputs) {
                lblpnlBoolDisplay.Visible = false;
                lblpnlDisplay.Visible = true;
                lblpnlEndianess.Visible = true;
                lblpnlSize.Visible = true;
                lblpnlUnits.Visible = true;
            }
            else {
                lblpnlBoolDisplay.Visible = true;
                lblpnlDisplay.Visible = false;
                lblpnlEndianess.Visible = false;
                lblpnlSize.Visible = false;
                lblpnlUnits.Visible = false;
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
            //Classes.Enums.ModbusEnums.DataSize DataSize = (Classes.Enums.ModbusEnums.DataSize)sender;
            //DataSelection? Select = GetDataSelection();
            //Classes.Modbus.ModbusEditor.ChangeSize(GetCurrentSlave(), Select, sender, CurrentEditor, DataSize);
            Classes.Modbus.ModbusEditor.ChangeSizeList(sender, CurrentEditor);
        }
        private void EditorInstance_FormClosing(object? sender, FormClosingEventArgs e) {
            if (EditorInstance == null) { return; }
            EditorInstance.FormClosing -= EditorInstance_FormClosing;
            EditorInstance = null;
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
            ThemeManager.ThemeControl(tbUnit);

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
        private DataSelection? GetDataSelection() {
            if (EditorInstance == null) { return null; }
            return EditorInstance.GetDataSelection();
        }
        private ModbusSlave? GetCurrentSlave() {
            if (EditorInstance == null) { return null; }
            return EditorInstance.GetCurrentSlave();
        }
        ConversionHandler.Prefix LastPrefix = ConversionHandler.Prefix.None;
        private void ntbMain_PrefixChanged(object sender) {
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
            //Classes.Enums.ModbusEnums.DataSize DataSize = (Classes.Enums.ModbusEnums.DataSize)sender;
            //DataSelection? Select = GetDataSelection();
            //Classes.Modbus.ModbusEditor.ChangeSize(GetCurrentSlave(), Select, sender, CurrentEditor, DataSize);
            Classes.Modbus.ModbusEditor.ChangeDisplayFormatList(EnumManager.IntegerToDataFormat(ddlDisplay.SelectedIndex), CurrentEditor);
        }

        private void ddlEndianness_SelectedIndexChanged(object sender, EventArgs e) {
            if (PreventLoad == true) { return; }
            ODModules.ListControl? CurrentEditor = GetCurrentListView();
            //Classes.Enums.ModbusEnums.DataSize DataSize = (Classes.Enums.ModbusEnums.DataSize)sender;
            //DataSelection? Select = GetDataSelection();
            //Classes.Modbus.ModbusEditor.ChangeSize(GetCurrentSlave(), Select, sender, CurrentEditor, DataSize);
            Classes.Modbus.ModbusEditor.ChangeWordOrderList(EnumManager.IntegerToWordOrder(ddlEndianness.SelectedIndex), CurrentEditor);
        }

        private void tbUnit__TextChanged(object sender, EventArgs e) {
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
    }
}
