using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Enums;
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
using static Serial_Monitor.Classes.Enums.ModbusEnums;

namespace Serial_Monitor.Docks {
    public partial class ModbusPollers : SkinnedForm, ITheme {//ODModules.Docking.ToolWindow {
        public ModbusPollers() {
            InitializeComponent();
            LoadFormatters();
            ModbusPollerSupport.PollersChanged += ModbusPollerSupport_PollersChanged;
            ModbusPollerSupport.PollerRemoved += ModbusPollerSupport_PollerRemoved;
            SystemManager.ChannelRenamed += SystemManager_ChannelRenamed;
            lstPollers.ExternalItems = ModbusPollerSupport.PollerList;
            lstPollers.UseLocalList = false;
            ApplyTheme();
        }

        private void SystemManager_ChannelRenamed(SerialManager sender) {
            foreach (ListItem Li in lstPollers.CurrentItems) {
                ModbusPoller? MbP = ModbusPollerSupport.GetPollerFromListItem(Li);
                if (MbP == null) { continue; }
                if (MbP.Channel == null) { continue; }
                if (MbP.Channel.ID != sender.ID) { continue; }
                Li[ModbusPollerSupport.INDX_POLL_CHANNEL].Text = MbP.Channel.StateName;
            }
            lstPollers.Invalidate();
        }

        private void ModbusPollerSupport_PollerRemoved() {
            ModbusPollerSupport.RemoveAllControls(lstPollers);
        }

        private void ModbusPollerSupport_PollersChanged() {
            lstPollers.Invalidate();
        }

        private void ModbusPollers_Load(object sender, EventArgs e) {

        }
        private void LoadFormatters() {
            EnumManager.LoadModbusRegisterTypes(cmDataSet, CmModbusDataSelection_Click);
        }
        public void ApplyTheme() {
            RecolorAll();
            AddIcons();
        }
        private void AddIcons() {

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Add, btnAddPoller, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Remove, btnRemovePoller, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, btnStartPolling, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, btnStopPolling, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.CountDynamicValue, btnStartAndEnd, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
        }
        private void RecolorAll() {
            Classes.Theming.ThemeManager.ThemeControl(cmChannels);
            Classes.Theming.ThemeManager.ThemeControl(cmDataSet);
            Classes.Theming.ThemeManager.ThemeControl(tsMain);
            Classes.Theming.ThemeManager.ThemeControl(lstPollers);

            BackColor = Properties.Settings.Default.THM_COL_Editor;
            TitleBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            TitleForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            InactiveBorderColor = Properties.Settings.Default.THM_COL_MenuBack;
            ActiveBorderColor = Properties.Settings.Default.THM_COL_SelectedColor;
        }
        private void lstPollers_DropDownClicked(object sender, ODModules.DropDownClickedEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (LstItem.SubItems.Count < 5) { return; }
            if (e.Column == ModbusPollerSupport.INDX_POLL_ENABLE) {
                //ModbusPollerSupport.AddValueBox(e, lstPollers, e.Data);
            }
            else if (e.Column == ModbusPollerSupport.INDX_POLL_CHANNEL) {
                if ((e.Data == null) || (e.Data == "")) {
                    //ModbusEditor.CheckItem(cmDataSize, ((ModbusRegister)DataTag).Size);
                    ModbusPoller? Poller = ModbusPollerSupport.GetPollerFromListItem(LstItem);
                    if (Poller == null) { return; }
                    Guid? Id = Poller.Channel == null ? null : Poller.Channel.ID;
                    SystemManager.GetChannelsAsContextListIdTagged(cmChannels, CmChannel_Click, Id, true, true);
                    cmChannels.Tag = e;
                    cmChannels.Show(Classes.Modbus.ModbusEditor.AddPoint(e));
                }
                else {
                    //ModbusEditor.ChangeDataSize(e, editorModbus.lstMonitor, DropDownSearchString, GetCurrentShowUnits());
                }
            }
            else if (e.Column == ModbusPollerSupport.INDX_POLL_FUNCTION) {
                if ((e.Data == null) || (e.Data == "")) {
                    ModbusPollerSupport.CheckItem(cmDataSet, ((ModbusPoller)DataTag).Selection);
                    cmDataSet.Tag = e;
                    cmDataSet.Show(Classes.Modbus.ModbusEditor.AddPoint(e));
                }
                else {
                    ModbusPollerSupport.ChangeDataSelection(e, lstPollers, DropDownSearchString);
                }
            }

            else {
                ModbusPollerSupport.AddValueBox(e, lstPollers, e.Data);
            }
            lstPollers.Invalidate();
        }

        private void lstPollers_CellSelected(object sender, CellSelectedEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            // if (LstItem.SubItems.Count < 8) { return; }
            ModbusPollerSupport.RemoveAllControls(lstPollers);
        }

        private void lstPollers_SelectionChanged(object sender, SelectedItemsEventArgs e) {
            UpdateCommands();
            if (lstPollers.SelectionCount > 0) {
                btnRemovePoller.Enabled = true;
            }
            else {
                btnRemovePoller.Enabled = false;
                btnStartPolling.Enabled = false;
                btnStopPolling.Enabled = false;
            }
        }
        private void UpdateCommands() {
            if (lstPollers.SelectionCount == 1) {
                ListItem? Li = ((lstPollers.SelectedIndex > lstPollers.CurrentItems.Count) || (lstPollers.CurrentItems.Count == 0) || (lstPollers.SelectedIndex < 0)) ? null : lstPollers.CurrentItems[lstPollers.SelectedIndex];
                if (Li != null) {
                    btnStartPolling.Enabled = !Li.Checked;
                    btnStopPolling.Enabled = Li.Checked;
                }
                else {
                    btnStartPolling.Enabled = true;
                    btnStopPolling.Enabled = true;
                }
            }
            else if (lstPollers.SelectionCount > 1) {
                bool FirstState = false;
                bool StatesDiffer = false;
                int Count = 0;
                foreach (ListItem li in lstPollers.CurrentItems) {
                    if (!li.Selected) { continue; }
                    if (Count == 0) { FirstState = li.Checked; }
                    if (FirstState != li.Checked) { StatesDiffer = true; }
                    Count++;
                }
                if (StatesDiffer) {
                    btnStartPolling.Enabled = true;
                    btnStopPolling.Enabled = true;
                }
                else {
                    btnStartPolling.Enabled = !FirstState;
                    btnStopPolling.Enabled = FirstState;
                }
            }
        }
        DateTime LastKeyDown = DateTime.MinValue;
        string DropDownSearchString = "";
        int LastSelectedCell = -1;
        int LastSelectedRow = -1;
        private void lstPollers_KeyPress(object sender, KeyPressEventArgs e) {
            if ((e.KeyChar == ' ') || (e.KeyChar == '\r')) {
                lstPollers.SelectDropForward(0, 0, true);
            }
            if (Char.IsLetterOrDigit(e.KeyChar) || (e.KeyChar == '\b')) {
                if ((lstPollers.SelectedCell.X == ModbusPollerSupport.INDX_POLL_MAX) || (lstPollers.SelectedCell.X == ModbusPollerSupport.INDX_POLL_CHANNEL)) {
                    if (ConversionHandler.DateIntervalDifference(LastKeyDown, DateTime.UtcNow, ConversionHandler.Interval.Second) > 1) {
                        DropDownSearchString = "";
                    }
                    if ((LastSelectedCell != lstPollers.SelectedCell.X) || (LastSelectedRow != lstPollers.SelectedCell.Y)) {
                        DropDownSearchString = "";
                    }
                    LastSelectedCell = lstPollers.SelectedCell.X;
                    LastSelectedRow = lstPollers.SelectedCell.Y;
                    if (e.KeyChar != '\b') {
                        DropDownSearchString += e.KeyChar;
                    }

                    LastKeyDown = DateTime.UtcNow;
                }
                lstPollers.SelectDropForward(0, 0, true, e.KeyChar.ToString());
            }
        }

        private void lstPollers_ItemCheckedChanged(object sender, ItemCheckedChangeEventArgs e) {
            ListItem? LstItem = e.ParentItem;
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.Column == ModbusPollerSupport.INDX_POLL_ENABLE) {
                ModbusPollerSupport.SetPollerEnable(LstItem, e.Checked);
                lstPollers.Invalidate();
            }
        }

        private void btnAddPoller_Click(object sender, EventArgs e) {
            ModbusPollerSupport.NewPoller();
        }
        private void btnRemovePoller_Click(object sender, EventArgs e) {
            ModbusPollerSupport.RemoveSelected(lstPollers);
            UpdateCommands();
        }
        private void btnStartPolling_Click(object sender, EventArgs e) {
            ModbusPollerSupport.SetPollingSelectedState(lstPollers, true);
            UpdateCommands();
        }
        private void btnStopPolling_Click(object sender, EventArgs e) {
            ModbusPollerSupport.SetPollingSelectedState(lstPollers, false);
            UpdateCommands();
        }
        private void ModbusPollers_FormClosed(object sender, FormClosedEventArgs e) {
            SystemManager.ChannelRenamed -= SystemManager_ChannelRenamed;
            ModbusPollerSupport.PollerRemoved -= ModbusPollerSupport_PollerRemoved;
            ModbusPollerSupport.PollersChanged -= ModbusPollerSupport_PollersChanged;
        }

        private void btnStartAndEnd_Click(object sender, EventArgs e) {
            ModbusPollerSupport.RemoveAllControls(lstPollers);
            if (btnStartAndEnd.Checked) {
                lstPollers.Columns[ModbusPollerSupport.INDX_POLL_ADDRESS_START].Text = "Start";
                lstPollers.Columns[ModbusPollerSupport.INDX_POLL_ADDRESS_END].Width = lstPollers.Columns[ModbusPollerSupport.INDX_POLL_COUNT].Width;
                lstPollers.Columns[ModbusPollerSupport.INDX_POLL_COUNT].Visible = false;
                lstPollers.Columns[ModbusPollerSupport.INDX_POLL_ADDRESS_END].Visible = true;
            }
            else {
                lstPollers.Columns[ModbusPollerSupport.INDX_POLL_ADDRESS_START].Text = "Address";
                lstPollers.Columns[ModbusPollerSupport.INDX_POLL_COUNT].Width = lstPollers.Columns[ModbusPollerSupport.INDX_POLL_ADDRESS_END].Width;
                lstPollers.Columns[ModbusPollerSupport.INDX_POLL_COUNT].Visible = true;
                lstPollers.Columns[ModbusPollerSupport.INDX_POLL_ADDRESS_END].Visible = false;
            }
            lstPollers.Invalidate();
        }
        private void CmChannel_Click(object? sender, EventArgs e) {
            object? ButtonData = Classes.Modbus.ModbusEditor.GetContextMenuItemData(sender);
            object? Data = Classes.Modbus.ModbusEditor.GetContextMenuData(sender);
            if (Data == null) { return; }
            Guid? Id = null;
            if ((ButtonData != null) && (ButtonData.GetType() == typeof(Guid))) { Id = (Guid)ButtonData; }

            SerialManager? SerMgr = SystemManager.GetChannel(Id);
            if (Data.GetType() == typeof(DropDownClickedEventArgs)) {
                DropDownClickedEventArgs Args = (DropDownClickedEventArgs)Data;
                ModbusPollerSupport.SetPollerChannel(Args.ParentItem, SerMgr);
            }
        }
        private void CmModbusDataSelection_Click(object? sender, EventArgs e) {
            object? ButtonData = Classes.Modbus.ModbusEditor.GetContextMenuItemData(sender);
            object? Data = Classes.Modbus.ModbusEditor.GetContextMenuData(sender);
            if (Data == null) { return; }
            if (ButtonData == null) { return; }
            if (ButtonData.GetType()! != typeof(DataSelection)) { return; }
            DataSelection Frmt = (DataSelection)ButtonData;
            if (Data.GetType() == typeof(DropDownClickedEventArgs)) {
                DropDownClickedEventArgs Args = (DropDownClickedEventArgs)Data;
                if (Args.ParentItem == null) { return; }
                if (Args.ParentItem.Tag == null) { return; }
                if (Args.ParentItem.Tag.GetType() == typeof(ModbusPoller)) {
                    ModbusPoller Poller = (ModbusPoller)Args.ParentItem.Tag;
                    ModbusPollerSupport.SetPollerFunction(Args.ParentItem, Frmt);
                    //Args.ParentItem[Args.Column].Text = EnumManager.DataFormatToString(Reg.Format).A;
                    //Args.ParentItem[ModbusEditor.Indx_Size].Text = EnumManager.DataSizeToString(Reg.Size);
                    //Args.ParentItem[ModbusEditor.Indx_Value].Text = Reg.ValueWithUnit;
                    //ModbusEditor.RetroactivelyApplyFormatChanges(Args.Item, editorModbus.lstMonitor, GetCurrentShowUnits());
                    //editorModbus.lstMonitor.Invalidate();
                }
            }
        }

    }
}
