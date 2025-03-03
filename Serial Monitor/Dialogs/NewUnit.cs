using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.Dialogs {
    public partial class NewUnit : SkinnedForm, Interfaces.ITheme {
        SerialManager? manager = null;
        public SerialManager? Manager {
            get { return manager; }
        }
        int unit = -1;
        public int Unit {
            get { return unit; }
        }
        string displayname = "";
        public string DisplayName {
            get { return displayname; }
        }
        protected override CreateParams CreateParams {
            get {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        public NewUnit(SerialManager Manager) {
            InitializeComponent();
            this.manager = Manager;
            LoadAvaliableUnits();
        }
        private void LoadAvaliableUnits() {
            if (manager == null) { return; }
            //247
            for (int i = 1; i <= 247; i++) {
                int Index = ModbusSupport.UnitToIndex(manager, i);
                if (Index == -1) {
                    UnitPreview unitPreview = new UnitPreview(i);
                    cmbxUnitAddress.Items.Add(unitPreview);
                }
            }
            if (cmbxUnitAddress.Items.Count > 0) {
                cmbxUnitAddress.SelectedIndex = 0;
            }
        }

        private void NewUnit_Load(object sender, EventArgs e) {
            ApplyTheme();
        }
        public void ApplyTheme() {
            RecolorAll();
        }
        private void RecolorAll() {
            this.SuspendLayout();
            TitleBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            TitleForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            InactiveBorderColor = Properties.Settings.Default.THM_COL_MenuBack;
            ActiveBorderColor = Properties.Settings.Default.THM_COL_SelectedColor;
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(lblpnlUnitAddress);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlDisplayName);
            Classes.Theming.ThemeManager.ThemeControl(textBox1);


            cmbxUnitAddress.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            cmbxUnitAddress.BackColor = Properties.Settings.Default.THM_COL_Editor;
            cmbxUnitAddress.BorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            cmbxUnitAddress.ButtonColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(btnAccept);
            Classes.Theming.ThemeManager.ThemeControl(btnCancel);
            this.ResumeLayout();
        }

        private void btnHiddenCancel_Click(object sender, EventArgs e) {
            manager = null;
            DialogResult = DialogResult.Cancel;
        }
        private void btnHiddenAccept_Click(object sender, EventArgs e) {
            displayname = textBox1.Text;
            if (cmbxUnitAddress.SelectedItem == null) { return; }
            if (cmbxUnitAddress.SelectedItem.GetType() == typeof(UnitPreview)) {
                unit = ((UnitPreview)cmbxUnitAddress.SelectedItem).Unit;
            }
            DialogResult = DialogResult.OK;
        }
        private void btnAccept_ButtonClicked(object sender) {
            displayname = textBox1.Text;
            if (cmbxUnitAddress.SelectedItem == null) { return; }
            if (cmbxUnitAddress.SelectedItem.GetType() == typeof(UnitPreview)) {
                unit = ((UnitPreview)cmbxUnitAddress.SelectedItem).Unit;
            }
            DialogResult = DialogResult.OK;
        }
        private void btnCancel_ButtonClicked(object sender) {
            manager = null;
            DialogResult = DialogResult.Cancel;
        }

        private void NewUnit_FormClosing(object sender, FormClosingEventArgs e) {

        }
        public void CleanUp() {
            manager = null;
        }
        private void NewUnit_FormClosed(object sender, FormClosedEventArgs e) {

        }
    }
    public struct UnitPreview {
        public string DisplayText;
        public int Unit;
        public UnitPreview(int UnitNumber) {
            Unit = UnitNumber;
            DisplayText = "Unit " + Unit;
        }

        public override string? ToString() {
            return "Unit " + Unit.ToString();
        }
    }
}
