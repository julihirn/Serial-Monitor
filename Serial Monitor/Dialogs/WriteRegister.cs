using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Components;
using Serial_Monitor.Interfaces;
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
    public partial class WriteRegister : SkinnedForm, ITheme {
        protected override CreateParams CreateParams {
            get {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        SerialManager? manager = null;
        public SerialManager? Manager {
            get {
                return manager;
            }
        }
        public WriteRegister(SerialManager? SerialMan) {
            manager = SerialMan;
            InitializeComponent();
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            numtxtAddress.Height = cmbxDataSet.Height;
            numtxtUnit.Height = cmbxDataSet.Height;
            numtxtValue.Height = cmbxDataSet.Height;

            numtxtAddress.Maximum = new Handlers.NumericalString(ModbusSupport.MaximumRegisters);
        }
        public void ApplyTheme() {
            RecolorAll();
        }
        private void RecolorAll() {
            this.SuspendLayout();
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            TitleBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            TitleForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            InactiveBorderColor = Properties.Settings.Default.THM_COL_MenuBack;
            ActiveBorderColor = Properties.Settings.Default.THM_COL_SelectedColor;
            Classes.Theming.ThemeManager.ThemeControl(lblpnlAddress);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlQuantity);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlRegisters);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlValue);
            Classes.Theming.ThemeManager.ThemeControl(labelPanel1);
            Classes.Theming.ThemeManager.ThemeControl(numtxtUnit);
            Classes.Theming.ThemeManager.ThemeControl(numtxtAddress);

            cmbxDataSet.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            cmbxDataSet.BackColor = Properties.Settings.Default.THM_COL_Editor;
            cmbxDataSet.BorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            cmbxDataSet.ButtonColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(btnAccept);
            Classes.Theming.ThemeManager.ThemeControl(btnCancel);

            Classes.Theming.ThemeManager.ThemeControl(numtxtValue);
            this.ResumeLayout();
        }
        private void Cancel() {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void Send() {
            if (manager == null) { return; }
            if (manager.IsMaster == false) { return; }
            string Query = "UNIT " + numtxtUnit.Value.ToString() + " ";
            Query += "WRITE REGISTER " + numtxtAddress.Value.ToString();
            Query += " = " + numtxtValue.Value.ToString();
            SystemManager.SendModbusCommand(manager, DataSelection.ModbusDataHoldingRegisters, Query);
        }

        private void btnAccept_ButtonClicked(object sender) {
            Send();
        }

        private void btnCancel_ButtonClicked(object sender) {
            Cancel();
        }

        private void WriteRegister_Load(object sender, EventArgs e) {
            RecolorAll();
        }
    }
}
