using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Modbus;
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
using ListControl = ODModules.ListControl;

namespace Serial_Monitor.ToolWindows {
    public partial class ModbusRegister : Components.MdiClientForm, ITheme {
        Classes.Modbus.ModbusSnapshot snapshot;
        public Classes.Modbus.ModbusSnapshot Snapshot {
            get { return snapshot; }
        }

        public ModbusRegister(Classes.Modbus.ModbusSnapshot snapShot) {
            Intialise(snapShot);
        }
        public ModbusRegister(Classes.Modbus.ModbusSnapshot snapShot, bool UseBounds) {
            Intialise(snapShot);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = snapShot.Location;
            this.Size = snapShot.Size;
        }
        private void Intialise(Classes.Modbus.ModbusSnapshot snapShot) {
            InitializeComponent();
            snapshot = snapShot;
            if (lstRegisters.Columns.Count > 0) {
                lstRegisters.Columns[0].CountOffset = snapshot.StartIndex;
            }
            lstRegisters.ExternalItems = snapshot.Listings;
            lstRegisters.Invalidate();
            UpdateWindowName();
        }
        private void ModbusRegister_Load(object sender, EventArgs e) {
            ApplyTheme();
            snapshot.SnapshotRemoved += Snapshot_SnapshotRemoved;
            SystemManager.ModbusReceived += SystemManager_ModbusReceived;
            SystemManager.ChannelRenamed += SystemManager_ChannelRenamed;
            SystemManager.ModbusPropertyChanged += SystemManager_ModbusPropertyChanged;
            SystemManager.ModbusRegisterRenamed += SystemManager_ModbusRegisterRenamed;
            IgnoreBoundsChange = false;
        }

        private void SystemManager_ModbusPropertyChanged(object Data, int Index, DataSelection DataType) {
            // lstRegisters.ExternalItems[Index]
            snapshot.UpdateRow(Index);
            lstRegisters.Invalidate();
        }

        private void SystemManager_ModbusRegisterRenamed(object Data, int Index, DataSelection DataType) {
            if (snapshot.Selection != DataType) { return; }
            snapshot.RenameFromRegister(Index);
            lstRegisters.Invalidate();
        }

        private void SystemManager_ChannelRenamed(SerialManager sender) {
            if (snapshot.Manager == null) { return; }
            if (sender.ID == snapshot.Manager.ID) {
                UpdateWindowName();
            }
        }
        private void UpdateWindowName() {
            this.Text = snapshot.Name;
        }
        private void SystemManager_ModbusReceived(object Data, int Index, DataSelection DataType) {
            if (snapshot.Selection != DataType) { return; }
            snapshot.SetValue(Index);
            lstRegisters.Invalidate();
        }

        private void Snapshot_SnapshotRemoved(object sender) {
            this.Close();
        }

        public void ApplyTheme() {
            this.CloseColor = Properties.Settings.Default.THM_COL_ForeColor;
            this.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            this.BorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            this.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            Classes.Theming.ThemeManager.ThemeControl(lstRegisters);
        }

        private void ModbusRegister_FormClosing(object sender, FormClosingEventArgs e) {
            snapshot.SnapshotRemoved -= Snapshot_SnapshotRemoved;
            SystemManager.ModbusReceived -= SystemManager_ModbusReceived;
            SystemManager.ChannelRenamed -= SystemManager_ChannelRenamed;
            SystemManager.ModbusPropertyChanged -= SystemManager_ModbusPropertyChanged;
        }


        private void AddRenameBox(DropDownClickedEventArgs e, ListControl LstCtrl) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            if (LstItem.Tag == null) { return; }
            if (e.ParentItem == null) { return; }
            if (e.ParentItem.SubItems == null) { return; }


            if (LstItem.Tag.GetType() == typeof(ModbusCoil)) {
                ModbusCoil coil = (ModbusCoil)LstItem.Tag;
                Rectangle Rect = new Rectangle(e.Location, e.ItemSize);
                Rectangle ParRect = new Rectangle(e.ScreenLocation, e.ItemSize);
                Components.EditValue EdVal = new Components.EditValue(coil.Name, LstCtrl, e.ParentItem, 1, e.Item + snapshot.StartIndex, null, coil, Rect, ParRect, snapshot.Selection);
                LstCtrl.Controls.Add(EdVal);
                EdVal.Focus();
                EdVal.Show();
            }
            else if (LstItem.Tag.GetType() == typeof(ModbusRegister)) {
                ModbusRegister reg = (ModbusRegister)LstItem.Tag;
                Rectangle Rect = new Rectangle(e.Location, e.ItemSize);
                Rectangle ParRect = new Rectangle(e.ScreenLocation, e.ItemSize);
                Components.EditValue EdVal = new Components.EditValue(reg.Name, LstCtrl, e.ParentItem, 1, e.Item + snapshot.StartIndex, null, reg, Rect, ParRect, snapshot.Selection);
                LstCtrl.Controls.Add(EdVal);
                EdVal.Focus();
                EdVal.Show();
            }
        }

        private void lstRegisters_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            if (e.Column == 1) {
                //EditValue EdVal = new EditValue(StepEnumerations.StepExecutable.Label, LstItem.SubItems[0].Text, lstMonitor, LstItem, null, LstItem.Tag, false);
                //
                //EdVal.Sz = e.ItemSize;
                //EdVal.Location = e.ScreenLocation;
                //EdVal.Show();
                AddRenameBox(e, lstRegisters);
            }
        }
        bool IgnoreBoundsChange = true;
        private void ModbusRegister_SizeChanged(object sender, EventArgs e) {
            if (IgnoreBoundsChange) { return; }
            snapshot.Size = this.Size;
        }
        private void ModbusRegister_Move(object sender, EventArgs e) {
            if (IgnoreBoundsChange) { return; }
            snapshot.Location = this.Location;
        }

        private void ModbusRegister_CloseButtonClicked(object sender) {
            ModbusSupport.RemoveSnapshot(snapshot);
            this.Close();
        }
    }
}
