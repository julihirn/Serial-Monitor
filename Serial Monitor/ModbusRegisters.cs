using ODModules;
using Serial_Monitor.Classes;
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

namespace Serial_Monitor {
    public partial class ModbusRegisters : Form {
        public Form? Attached = null;
        public ModbusRegisters() {
            InitializeComponent();
        }

        private void ModbusRegisters_Load(object sender, EventArgs e) {
            //if (Attached != null) {
            //    if (Attached.GetType() == typeof(Form1)) {
            //        ((Form1)Attached).
            //    }
            //}
            AddIcons();
            SystemManager.ModbusReceived += SystemManager_ModbusReceived;
            navigator1.LinkedList = SystemManager.SerialManagers;
            navigator1.SelectedItem = 0;
            navigator1.Invalidate();
            try {
                CurrentManager = SystemManager.SerialManagers[0];
            }
            catch { }
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            LoadRegisters();
        }
        bool LockedEditor = false;
        public void AddIcons() {
            DesignerSetup.LinkSVGtoControl(Properties.Resources.BooleanData, btnCoils, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.BooleanData, btnDiscrete, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.DomainType, btnHolding, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.DomainType, btnInputRegisters, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.ApplyCodeChanges, btnApplyOnClick, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
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
        }

        SerialManager? CurrentManager = null;
        DataSelection DataSet = DataSelection.ModbusDataCoils;
        private void navigator1_SelectedIndexChanged(object sender, int SelectedIndex) {
            if (SystemManager.SerialManagers.Count > 0) {
                if ((SelectedIndex >= 0) && (SelectedIndex < SystemManager.SerialManagers.Count)) {
                    CurrentManager = SystemManager.SerialManagers[SelectedIndex];
                    LoadRegisters();
                }
            }
        }
        private void LoadRegisters() {
            lstMonitor.LineRemoveAll();
            if (CurrentManager == null) { return; }
            if (DataSet == DataSelection.ModbusDataCoils) {
                foreach (ModbusCoil Coil in CurrentManager.Coils) {
                    AddMonitorItem(Coil);
                }
            }
            else if (DataSet == DataSelection.ModbusDataDiscreteInputs) {
                foreach (ModbusCoil Coil in CurrentManager.DiscreteInputs) {
                    AddMonitorItem(Coil);
                }
            }
            else if (DataSet == DataSelection.ModbusDataInputRegisters) {
                foreach (ModbusRegister Coil in CurrentManager.InputRegisters) {
                    AddMonitorItem(Coil);
                }
            }
            else if (DataSet == DataSelection.ModbusDataHoldingRegisters) {
                foreach (ModbusRegister Coil in CurrentManager.HoldingRegisters) {
                    AddMonitorItem(Coil);
                }
            }
            lstMonitor.Invalidate();
        }
        private void AddMonitorItem(ModbusCoil Coil) {
            ListItem PLi = new ListItem();
            PLi.Tag = Coil;
            ListSubItem CLi1 = new ListSubItem(Coil.Name);
            ListSubItem CLi2 = new ListSubItem("Boolean");
            ListSubItem CLi3 = new ListSubItem(Coil.Value.ToString());
            PLi.SubItems.Add(CLi1);
            PLi.SubItems.Add(CLi2);
            PLi.SubItems.Add(CLi3);
            lstMonitor.Items.Add(PLi);
        }
        private void AddMonitorItem(ModbusRegister Register) {
            ListItem PLi = new ListItem();
            PLi.Tag = Register;
            ListSubItem CLi1 = new ListSubItem(Register.Name);
            ListSubItem CLi2 = new ListSubItem("");
            ListSubItem CLi3 = new ListSubItem(Register.Value.ToString());
            PLi.SubItems.Add(CLi1);
            PLi.SubItems.Add(CLi2);
            PLi.SubItems.Add(CLi3);
            lstMonitor.Items.Add(PLi);
        }


        private void btnDiscrete_Click(object sender, EventArgs e) {
            DataSet = DataSelection.ModbusDataDiscreteInputs;
            LoadRegisters();
            btnDiscrete.Checked = true;
            btnHolding.Checked = false;
            btnCoils.Checked = false;
            btnInputRegisters.Checked = false;
            lblTypeSelection.Text = "Discrete Inputs";
        }
        private void btnHolding_Click(object sender, EventArgs e) {
            DataSet = DataSelection.ModbusDataHoldingRegisters;
            LoadRegisters();
            btnDiscrete.Checked = false;
            btnHolding.Checked = true;
            btnCoils.Checked = false;
            btnInputRegisters.Checked = false;
            lblTypeSelection.Text = "Holding Registers";
        }
        private void btnInputRegisters_Click(object sender, EventArgs e) {
            DataSet = DataSelection.ModbusDataInputRegisters;
            LoadRegisters();
            btnDiscrete.Checked = false;
            btnHolding.Checked = false;
            btnCoils.Checked = false;
            btnInputRegisters.Checked = true;
            lblTypeSelection.Text = "Input Registers";
        }
        private void btnCoils_Click(object sender, EventArgs e) {
            DataSet = DataSelection.ModbusDataCoils;
            LoadRegisters();
            btnDiscrete.Checked = false;
            btnHolding.Checked = false;
            btnCoils.Checked = true;
            btnInputRegisters.Checked = false;
            lblTypeSelection.Text = "Coils";
        }

        private void ModbusRegisters_FormClosing(object sender, FormClosingEventArgs e) {
            SystemManager.ModbusReceived -= SystemManager_ModbusReceived;
        }
        private void SystemManager_ModbusReceived(object Data, int Index, DataSelection DataType) {
            if (Data == null) { return; }
            if (Data.GetType() == typeof(ModbusCoil)) {
                if (DataSet == DataType) {
                    ModbusCoil DigitalData = (ModbusCoil)Data;
                    if (ItemInBounds(Index, 3)) {
                        lstMonitor.Items[Index].SubItems[2].Text = DigitalData.Value.ToString();
                    }
                }
            }
            else if (Data.GetType() == typeof(ModbusRegister)) {
                if (DataSet == DataType) {
                    ModbusRegister DigitalData = (ModbusRegister)Data;
                    if (ItemInBounds(Index, 3)) {
                        lstMonitor.Items[Index].SubItems[2].Text = DigitalData.Value.ToString();
                    }
                }
            }
            lstMonitor.Invalidate();
        }
        private bool ItemInBounds(int Index, uint Column) {
            if (lstMonitor.Items.Count > 0) {
                if (Index < lstMonitor.Items.Count) {
                    if (Column == 0) {
                        return true;
                    }
                    else {
                        if (lstMonitor.Items[Index].SubItems.Count > 0) {
                            if (lstMonitor.Items[Index].SubItems.Count > Column - 1) {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void lstMonitor_DropDownClicked(object sender, DropDownClickedEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            if (e.Column == 1) {
                EditValue EdVal = new EditValue(StepExecutable.Label, LstItem.SubItems[0].Text, lstMonitor, LstItem, null, LstItem.Tag, false);
              
                EdVal.Sz = e.ItemSize;
                EdVal.Location = e.ScreenLocation;
                EdVal.Show();

            }
            else if (e.Column == 3) {
                if (LockedEditor == true) { return; }
                if (LstItem.Tag == null) { return; }
                if (LstItem.Tag.GetType() == typeof(ModbusCoil)) {
                    ModbusCoil coil = (ModbusCoil)LstItem.Tag;
                    coil.Value = !coil.Value;
                    if (LstItem.SubItems.Count >= 3) {
                        LstItem.SubItems[2].Text = coil.Value.ToString();
                    }
                    if (btnApplyOnClick.Checked == false) { return; }
                    SystemManager.SendModbusCommand(CurrentManager, DataSet, "Write Coil " + e.Item.ToString() + " = " + coil.Value.ToString());
                }
                else if (LstItem.Tag.GetType() == typeof(ModbusRegister)) {
                    ModbusRegister reg = (ModbusRegister)LstItem.Tag;
                    EditValue EdVal = new EditValue(StepExecutable.Delay, LstItem.SubItems[2].Text, lstMonitor, LstItem, CurrentManager, reg, !btnApplyOnClick.Checked);
                    EdVal.Location = e.ScreenLocation;
                    EdVal.Sz = e.ItemSize;
                    EdVal.Show();
                    if (LstItem.SubItems.Count >= 3) {
                        LstItem.SubItems[2].Text = reg.Value.ToString();
                    }
                }
            }
            lstMonitor.Invalidate();
        }
        private void btnLockEditor_Click(object sender, EventArgs e) {
            LockedEditor = !LockedEditor;
            ChangeLockedIcon(LockedEditor);
        }
    }
}
