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

namespace Serial_Monitor.Docks {
    public partial class ModbusProperties : ODModules.Docking.ToolWindow, Interfaces.ITheme {
        ModbusRegisters? EditorInstance = null;
        public ModbusProperties(ModbusRegisters? EditorInstance) {
            InitializeComponent();
            this.EditorInstance = EditorInstance;
            if (this.EditorInstance != null) {
                this.EditorInstance.FormClosing += EditorInstance_FormClosing;
            }
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
            }
            ThemeManager.ThemeControlAlternative(pfsMain);
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
                Debug.Print("RQ");
                Classes.Modbus.ModbusEditor.ChangePrefix(GetCurrentSlave(), Select, sender, CurrentEditor, CurrentPrefix);
            }
            LastPrefix = CurrentPrefix;

        }
    }
}
