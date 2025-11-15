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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Serial_Monitor.WindowForms {
    public partial class SlaveManager : SkinnedForm, Interfaces.ITheme {
        public SlaveManager() {
            InitializeComponent();
            ApplyTheme();
        }

        private void SlaveManager_Load(object sender, EventArgs e) {
            RefreshListings();
        }
        private void RefreshListings() {
            foreach (SerialManager Chan in SystemManager.SerialManagers) {
                if (Chan.IsMaster == false) {
                    AddChannelItem(Chan);
                }
                else {
                    foreach (ModbusSlave Slve in Chan.Slave) {
                        AddChannelItem(Chan, Slve);
                    }
                }

            }
        }
        private void AddChannelItem(SerialManager Channel) {
            ListItem li = new ListItem(Channel.StateName);
            li.Tag = Channel.Registers;
            ListSubItem liChanType = new ListSubItem(Channel.IsMaster == true ? "Master" : "Slave");
            li.SubItems.Add(liChanType);
            ListSubItem liUnitNo = new ListSubItem(Channel.UnitAddress.ToString());
            li.SubItems.Add(liUnitNo);
            ListSubItem liUnitName = new ListSubItem("");
            li.SubItems.Add(liUnitName);
            lstChannels.Items.Add(li);
        }
        private void AddChannelItem(SerialManager Channel, ModbusSlave Unit) {
            ListItem li = new ListItem(Channel.StateName);
            li.Tag = Unit;
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
            Classes.Theming.ThemeManager.ThemeControl(lstChannels);
            Classes.Theming.ThemeManager.ThemeControl(msMain);
            this.ResumeLayout();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {

        }
    }
}
