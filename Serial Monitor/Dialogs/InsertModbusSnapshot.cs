using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Classes.Structures;
using Serial_Monitor.Components;
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

namespace Serial_Monitor.Dialogs {
    public partial class InsertModbusSnapshot : SkinnedForm, Interfaces.ITheme {
        protected override CreateParams CreateParams {
            get {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        public InsertModbusSnapshot() {
            InitializeComponent();
            numtxtAddress.Maximum = new Handlers.NumericalString(ModbusSupport.MaximumRegisters);
            numtxtAddress.Height = cmbxDataSet.Height;
            numtxtQuantity.Height = cmbxDataSet.Height;
        }

        private void InsertModbusSnapshot_Load(object sender, EventArgs e) {
            ApplyTheme();
            bool LockFirst = true;
            foreach (SerialManager Chan in SystemManager.SerialManagers) {
                if (Chan.IsMaster == false) {
                    AddChannelItem(Chan);
                    if (LockFirst) {
                        manager = Chan.Registers;
                        LockFirst = false;
                        lstChannels.Items[0].Checked = true;
                    }
                }
                else {
                    foreach (ModbusSlave Slve in Chan.Slave) {
                        AddChannelItem(Chan, Slve);
                        if (LockFirst) {
                            manager = Slve;
                            LockFirst = false;
                            lstChannels.Items[0].Checked = true;
                        }
                    }
                }

            }
            DataSelection[] Formats = (DataSelection[])DataSelection.GetValues(typeof(DataSelection));
            foreach (DataSelection Frmt in Formats) {
                StringPair Data = EnumManager.ModbusDataSelectionToString(Frmt);
                cmbxDataSet.Items.Add(Data.A);
            }
            cmbxDataSet.SelectedIndex = 0;
            numtxtQuantity.Value = 10;
        }
        private void AddChannelItem(SerialManager Channel) {
            ListItem li = new ListItem();
            li.Tag = Channel.Registers;
            ListSubItem liChanName = new ListSubItem(Channel.StateName);
            li.SubItems.Add(liChanName);
            ListSubItem liChanType = new ListSubItem(Channel.IsMaster == true ? "Master" : "Slave");
            li.SubItems.Add(liChanType);
            ListSubItem liUnitNo = new ListSubItem(Channel.UnitAddress.ToString());
            li.SubItems.Add(liUnitNo);
            ListSubItem liUnitName = new ListSubItem("");
            li.SubItems.Add(liUnitName);
            lstChannels.Items.Add(li);
        }
        private void AddChannelItem(SerialManager Channel, ModbusSlave Unit) {
            ListItem li = new ListItem();
            li.Tag = Unit;
            ListSubItem liChanName = new ListSubItem(Channel.StateName);
            li.SubItems.Add(liChanName);
            ListSubItem liChanType = new ListSubItem(Channel.IsMaster == true ? "Master" : "Slave");
            li.SubItems.Add(liChanType);
            ListSubItem liUnitNo = new ListSubItem(Unit.Address.ToString());
            li.SubItems.Add(liUnitNo);
            ListSubItem liUnitName = new ListSubItem(Unit.DisplayName);
            li.SubItems.Add(liUnitName);
            lstChannels.Items.Add(li);
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
            Classes.Theming.ThemeManager.ThemeControl(lblpnlDisplayName);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlQuantity);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlRegisters);
            Classes.Theming.ThemeManager.ThemeControl(lblpnlChannel);
            Classes.Theming.ThemeManager.ThemeControl(labelPanel1);
            Classes.Theming.ThemeManager.ThemeControl(lstChannels);
            Classes.Theming.ThemeManager.ThemeControl(numtxtAddress);
            Classes.Theming.ThemeManager.ThemeControl(numtxtQuantity);
            Classes.Theming.ThemeManager.ThemeControl(textBox1);


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
        ModbusSlave? manager = null;
        public ModbusSlave? Manager {
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
        private void lstChannels_ItemCheckedChanged(object sender, ItemCheckedChangeEventArgs e) {
            if (e.ParentItem == null) { return; }
            if (e.ParentItem.Tag == null) { return; }
            if (e.ParentItem.Tag.GetType() == typeof(ModbusSlave)) {
                if (e.ParentItem.Checked) {
                    manager = (ModbusSlave)e.ParentItem.Tag;
                }
            }
        }
        private void lstChannels_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == ' ') {
                if (lstChannels.SelectionCount == 1) {
                    foreach (ListItem li in lstChannels.Items) {
                        if (li.Selected) {
                            li.Checked = true;
                            if (li.Tag == null) { continue; }
                            if (li.Tag.GetType() == typeof(ModbusSlave)) {
                                manager = (ModbusSlave)li.Tag;
                            }
                        }
                        else {
                            li.Checked = false;
                        }
                    }
                }
            }
            lstChannels.Invalidate();
        }
    }
}
