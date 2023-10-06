using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Structures;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.Dialogs
{
    public partial class InsertModbusSnapshot : Form, Interfaces.ITheme {
        public InsertModbusSnapshot() {
            InitializeComponent();
            numtxtAddress.Height = cmbxDataSet.Height;
            numtxtQuantity.Height = cmbxDataSet.Height;
        }

        private void InsertModbusSnapshot_Load(object sender, EventArgs e) {
            ApplyTheme();
            bool LockFirst = true;
            foreach(SerialManager Chan in SystemManager.SerialManagers) {
                GridButton Btn = new GridButton();
                Btn.Text = Chan.StateName;
                Btn.Tag = Chan;
                Btn.RadioButtonGroup = "main";
                Btn.Type = ButtonType.RadioButton;
                Btn.Enabled = true;
                if (LockFirst) {
                    Btn.Checked = true;
                    manager = Chan;
                    LockFirst = false;
                }
                btngridChannels.Buttons.Add(Btn);
            }
            DataSelection[] Formats = (DataSelection[])DataSelection.GetValues(typeof(DataSelection));
            foreach (DataSelection Frmt in Formats) {
                StringPair Data = EnumManager.ModbusDataSelectionToString(Frmt);
                cmbxDataSet.Items.Add(Data.A);
            }
            cmbxDataSet.SelectedIndex = 0;
            numtxtQuantity.Value = 10;
        }
        public void ApplyTheme() {
            RecolorAll();
        }
        private void RecolorAll() {
            this.SuspendLayout();
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(lblpnlAddress);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlDisplayName);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlQuantity);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlRegisters);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlChannel);
            Classes.Theming.ThemeManager.ThemeControl(labelPanel1);
            Classes.Theming.ThemeManager.ThemeControl(btngridChannels);
            Classes.Theming.ThemeManager.ThemeControl(numtxtAddress);
            Classes.Theming.ThemeManager.ThemeControl(numtxtQuantity);
            textBox1.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            textBox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            cmbxDataSet.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            cmbxDataSet.BackColor = Properties.Settings.Default.THM_COL_Editor;
            cmbxDataSet.BorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            cmbxDataSet.ButtonColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(btnAccept);
            Classes.Theming.ThemeManager.ThemeControl(btnCancel);
            this.ResumeLayout();
        }
        private void btnAccept_Load(object sender, EventArgs e) {

        }
        public string DisplayName {
            get {
                return textBox1.Text;
            }
        }
        SerialManager? manager = null;
        public SerialManager ?Manager {
            get {
                return manager;
            }
        }
        public DataSelection DataSet {
            get {
                DataSelection[] Formats = (DataSelection[])DataSelection.GetValues(typeof(DataSelection));
                return Formats[cmbxDataSet.SelectedIndex];
            }
        }
        public int Address {
            get {
                int val = 0;
                int.TryParse(numtxtAddress.Value.ToString(), out val);
                return val;
            }
        }
        public int Quantity {
            get {
                int val = 1;
                int.TryParse(numtxtQuantity.Value.ToString(), out val);
                return val;
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


        private void btnAccept_ButtonClicked(object sender) {
            Accept();
        }
        private void btnHiddenAccept_Click(object sender, EventArgs e) {
            Accept();
        }
        private void btnCancel_ButtonClicked(object sender) {
            Cancel();
        }
        private void btnHiddenCancel_Click(object sender, EventArgs e) {
            Cancel();
        }
        private void btngridChannels_ButtonClicked(object Sender, GridButton Button, Point GridLocation) {
            if (Button.Tag == null) { return; }
            if (Button.Tag.GetType() == typeof(SerialManager)) {
                manager = (SerialManager)Button.Tag;
            }
        }
    }
}
