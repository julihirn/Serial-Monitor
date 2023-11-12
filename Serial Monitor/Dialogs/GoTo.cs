using ODModules;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Serial_Monitor.Dialogs {
    public partial class GoTo : Form, ITheme {
        public GoTo() {
            InitializeComponent();
        }

        private void GoTo_Load(object sender, EventArgs e) {
            numtxtAddress.Maximum = new Handlers.NumericalString(ModbusSupport.MaximumRegisters);
            lblpnlAddress.InlineWidth = DesignerSetup.ScaleInteger(lblpnlAddress.InlineWidth);
            lblpnlName.InlineWidth = DesignerSetup.ScaleInteger(lblpnlName.InlineWidth);
            numtxtAddress.Height = textBox2.Height;
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            RecolorAll();
        }
        public void ApplyTheme() {
            RecolorAll();
        }
        public int Address {
            get {
                int val = 0;
                int.TryParse(numtxtAddress.Value.ToString(), out val);
                return val;
            }
        }
        public string GoToText {
            get {
                return textBox2.Text;
            }
        }
        bool isNumeric = true;
        public bool IsNumeric {
            get {
                return isNumeric;
            }
            set {
                isNumeric = value;
                if (value == true) {
                    lblpnlAddress.Visible = true;
                    lblpnlName.Visible = false;
                }
                else {
                    lblpnlAddress.Visible = false;
                    lblpnlName.Visible = true;
                }
            }
        }
        private void Accept() {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void Cancel() {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void RecolorAll() {

            lblpnlAddress.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            lblpnlAddress.LabelBackColor = Properties.Settings.Default.THM_COL_Editor;
            lblpnlAddress.BackColor = Properties.Settings.Default.THM_COL_Editor;

            lblpnlName.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            lblpnlName.LabelBackColor = Properties.Settings.Default.THM_COL_Editor;
            lblpnlName.BackColor = Properties.Settings.Default.THM_COL_Editor;

            textBox2.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            textBox2.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            Classes.Theming.ThemeManager.ThemeControl(numtxtAddress);

            BackColor = Properties.Settings.Default.THM_COL_Editor;

            Classes.Theming.ThemeManager.ThemeControl(btnAccept);
            Classes.Theming.ThemeManager.ThemeControl(btnCancel);
        }

        private void btnAccept_ButtonClicked(object sender) {
            Accept();
        }

        private void btnCancel_ButtonClicked(object sender) {
            Cancel();
        }
        private void btnHiddenCancel_Click(object sender, EventArgs e) {
            Cancel();
        }
        private void btnHiddenAccept_Click(object sender, EventArgs e) {
            Accept();
        }

        private void GoTo_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void GoTo_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                Accept(); e.Handled = e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape) {
                Cancel(); e.Handled = e.SuppressKeyPress = true;
            }

        }

        private void numtxtAddress_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                Accept(); e.Handled = e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape) {
                Cancel(); e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                Accept(); e.Handled = e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape) {
                Cancel(); e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void numtxtAddress_EnterPressed(NumericTextbox sender) {
            Accept();
        }
        private void numtxtAddress_EscapePressed(NumericTextbox sender) {
            Cancel();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) {

        }
    }
}
