using Handlers;
using ODModules;
using Serial_Monitor.Classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Serial_Monitor.Classes.Enums.ModbusEnums;
using ListControl = ODModules.ListControl;

namespace Serial_Monitor.Classes.Modbus {
    public static class ModbusPollerSupport {
        public static event PollersChangedHandler? PollersChanged;
        public delegate void PollersChangedHandler();

        public static event PollerRemovedHandler? PollerRemoved;
        public delegate void PollerRemovedHandler();

        #region Pollers and Drivers
        internal const int INDX_POLL_ENABLE = 0;
        internal const int INDX_POLL_FREQ = 1;
        internal const int INDX_POLL_CHANNEL = 2;
        internal const int INDX_POLL_UNIT = 3;
        internal const int INDX_POLL_FUNCTION = 4;
        internal const int INDX_POLL_ADDRESS_START = 5;
        internal const int INDX_POLL_COUNT = 6;
        internal const int INDX_POLL_ADDRESS_END = 7;

        internal const int INDX_POLL_MAX = 8;
        private static volatile List<ModbusPoller> pollers = new List<ModbusPoller>();
        private static List<ListItem> pollerList = new List<ListItem>();
        internal static List<ModbusPoller> Pollers {
            get { return pollers; }
        }
        internal static List<ListItem> PollerList {
            get { return pollerList; }
        }
        internal static ModbusPoller? GetPollerFromListItem(ListItem? Li) {
            if (Li == null) { return null; }
            if (Li.Tag == null) { return null; }
            if (Li.Tag.GetType() != typeof(ModbusPoller)) { return null; }
            return (ModbusPoller)(Li.Tag);
        }
        public static void RemovePollers(SerialManager Manager) {
            PausePolling();
            for (int i = pollerList.Count - 1; i >= 0; i--) {
                ModbusPoller? Poller = GetPollerFromListItem(pollerList[i]);
                if (Poller == null) { continue; }
                SerialManager? Channel = Poller.Channel;
                if (Channel == null) { continue; }
                if (Channel.ID != Manager.ID) { continue; }
                pollerList[i].Tag = null;
                pollerList.RemoveAt(i);
            }
            for (int i = pollers.Count - 1; i >= 0; i--) {
                SerialManager? Channel = pollers[i].Channel;
                if (Channel == null) { continue; }
                if (Channel.ID != Manager.ID) { continue; }
                pollers[i].Channel = null;
                pollers.RemoveAt(i);
            }
            ResumePolling();
            GC.Collect();
            PollersChanged?.Invoke();
            PollerRemoved?.Invoke();
        }
        public static void ClearPollers() {
            PausePolling();
            for (int i = pollerList.Count - 1; i >= 0; i--) {
                pollerList[i].Tag = null;
                pollerList.RemoveAt(i);
            }
            for (int i = pollers.Count - 1; i >= 0; i--) {
                pollers[i].Channel = null;
                pollers.RemoveAt(i);
            }
            ResumePolling();
            GC.Collect();
            PollersChanged?.Invoke();
            PollerRemoved?.Invoke();
        }
        public static void NewPoller() {
            if (pollers.Count > 20) { return; }
            ModbusPoller MbPoll = new ModbusPoller(null, true, 1, DataSelection.ModbusDataHoldingRegisters, 0);
            PausePolling();
            pollers.Add(MbPoll);
            CreatePollerListItem(MbPoll);
            ResumePolling();
        }
        public static void NewPoller(SerialManager? Manager, bool Read, int Unit, DataSelection Selection, int Start, int Frequency, bool Enabled = true) {
            ModbusPoller MbPoll = new ModbusPoller(Manager, Read, Unit, Selection, Start);
            MbPoll.Enabled = Enabled;
            MbPoll.Frequency = Frequency;
            PausePolling();
            pollers.Add(MbPoll);
            CreatePollerListItem(MbPoll);
            ResumePolling();
        }
        public static void NewPoller(SerialManager? Manager, bool Read, int Unit, DataSelection Selection, int Start, int End, int Frequency, bool Enabled = true) {
            ModbusPoller MbPoll = new ModbusPoller(Manager, Read, Unit, Selection, Start, End);
            MbPoll.Enabled = Enabled;
            MbPoll.Frequency = Frequency;
            PausePolling();
            pollers.Add(MbPoll);
            CreatePollerListItem(MbPoll);
            ResumePolling();
        }
        internal static void SetPollerEnable(ListItem? Li, bool State) {
            if (Li == null) { return; }
            //if (Li.SubItems.Count < INDX_POLL_MAX) { return; }
            ModbusPoller? MbPoll = GetPollerFromListItem(Li);
            if (MbPoll == null) { return; }
            MbPoll.Enabled = State;
            Li[INDX_POLL_ENABLE].Checked = State;
            PollersChanged?.Invoke();
        }
        internal static void SetPollerFrequency(ListItem? Li, int Frequency) {
            if (Li == null) { return; }
            //if (Li.SubItems.Count < INDX_POLL_MAX) { return; }
            ModbusPoller? MbPoll = GetPollerFromListItem(Li);
            if (MbPoll == null) { return; }
            MbPoll.Frequency = Frequency;
            if (MbPoll.Frequency >= 1000) {
                decimal Seconds = MbPoll.Frequency / 1000.0m;
                Li[INDX_POLL_FREQ].Text = Seconds.ToString() + " s";
            }
            else {
                Li[INDX_POLL_FREQ].Text = MbPoll.Frequency.ToString() + " ms";
            }
            PollersChanged?.Invoke();
        }
        internal static void SetPollerChannel(ListItem? Li, SerialManager? Channel) {
            if (Li == null) { return; }
            //if (Li.SubItems.Count < INDX_POLL_MAX) { return; }
            ModbusPoller? MbPoll = GetPollerFromListItem(Li);
            if (MbPoll == null) { return; }
            MbPoll.Channel = Channel;
            Li[INDX_POLL_CHANNEL].Text = MbPoll.Channel == null ? "" : MbPoll.Channel.StateName;
            PollersChanged?.Invoke();
        }
        internal static void SetPollerUnit(ListItem? Li, ushort Unit) {
            if (Li == null) { return; }
            //if (Li.SubItems.Count < INDX_POLL_MAX) { return; }
            ModbusPoller? MbPoll = GetPollerFromListItem(Li);
            if (MbPoll == null) { return; }
            MbPoll.Unit = Unit;
            Li[INDX_POLL_UNIT].Text = MbPoll.Unit.ToString();
            PollersChanged?.Invoke();
        }
        internal static void SetPollerFunction(ListItem? Li, DataSelection RegisterType) {
            if (Li == null) { return; }
            //if (Li.SubItems.Count < INDX_POLL_MAX) { return; }
            ModbusPoller? MbPoll = GetPollerFromListItem(Li);
            if (MbPoll == null) { return; }
            MbPoll.Selection = RegisterType;
            Li[INDX_POLL_FUNCTION].Text = EnumManager.ModbusDataSelectionToString(MbPoll.Selection).A;
            PollersChanged?.Invoke();
        }
        internal static void SetPollerAddressStart(ListItem? Li, ushort Address) {
            if (Li == null) { return; }
            //if (Li.SubItems.Count < INDX_POLL_MAX) { return; }
            ModbusPoller? MbPoll = GetPollerFromListItem(Li);
            if (MbPoll == null) { return; }
            MbPoll.Start = Address;
            Li[INDX_POLL_COUNT].Text = MbPoll.Quantity.ToString();
            Li[INDX_POLL_ADDRESS_START].Text = MbPoll.Start.ToString();
            Li[INDX_POLL_ADDRESS_END].Text = MbPoll.End.ToString();
            PollersChanged?.Invoke();
        }
        internal static void SetPollerAddressEnd(ListItem? Li, ushort Address) {
            if (Li == null) { return; }
            //if (Li.SubItems.Count < INDX_POLL_MAX) { return; }
            ModbusPoller? MbPoll = GetPollerFromListItem(Li);
            if (MbPoll == null) { return; }
            MbPoll.End = Address;
            Li[INDX_POLL_COUNT].Text = MbPoll.Quantity.ToString();
            Li[INDX_POLL_ADDRESS_START].Text = MbPoll.Start.ToString();
            Li[INDX_POLL_ADDRESS_END].Text = MbPoll.End.ToString();
            PollersChanged?.Invoke();
        }
        internal static void SetPollerCount(ListItem? Li, ushort Count) {
            if (Li == null) { return; }
            //if (Li.SubItems.Count < INDX_POLL_MAX) { return; }
            ModbusPoller? MbPoll = GetPollerFromListItem(Li);
            if (MbPoll == null) { return; }
            MbPoll.Quantity = Count;
            Li[INDX_POLL_COUNT].Text = MbPoll.Quantity.ToString();
            Li[INDX_POLL_ADDRESS_START].Text = MbPoll.Start.ToString();
            Li[INDX_POLL_ADDRESS_END].Text = MbPoll.End.ToString();
            PollersChanged?.Invoke();
        }
        internal static void SetPollingSelectedState(ListControl LstCtrl, bool Enable) {
            RemoveAllControls(LstCtrl);
            PausePolling();
            for (int i = pollerList.Count - 1; i >= 0; i--) {
                if (!pollerList[i].Selected) { continue; }
                ModbusPoller? Mbp = GetPollerFromListItem(pollerList[i]);
                if (Mbp == null) { continue; }
                Mbp.Enabled = Enable;
                pollerList[i].Checked = Enable;
            }
            ResumePolling();
            GC.Collect();
            PollersChanged?.Invoke();
        }
        private static void CreatePollerListItem(ModbusPoller? Poller) {
            if (Poller == null) { return; }
            ListItem LiMain = new ListItem();
            LiMain.Checked = true;
            LiMain.Tag = Poller;
            ListSubItem LiS_Frequency = new ListSubItem();
            if (Poller.Frequency >= 1000) {
                decimal Seconds = Poller.Frequency / 1000.0m;
                LiS_Frequency.Text = Seconds.ToString() + " s";
            }
            else {
                LiS_Frequency.Text = Poller.Frequency.ToString() + " ms";
            }
            LiMain.SubItems.Add(LiS_Frequency);
            ListSubItem LiS_Channel = new ListSubItem();
            LiS_Channel.Text = Poller.Channel == null ? "" : Poller.Channel.StateName;
            LiMain.SubItems.Add(LiS_Channel);
            ListSubItem LiS_Unit = new ListSubItem();
            LiS_Unit.Text = Poller.Unit.ToString();
            LiMain.SubItems.Add(LiS_Unit);
            ListSubItem LiS_Function = new ListSubItem();
            LiS_Function.Text = EnumManager.ModbusDataSelectionToString(Poller.Selection).A;
            LiMain.SubItems.Add(LiS_Function);
            ListSubItem LiS_Address = new ListSubItem();
            LiS_Address.Text = Poller.Start.ToString();
            LiMain.SubItems.Add(LiS_Address);
            ListSubItem LiS_Count = new ListSubItem();
            LiS_Count.Text = Poller.Quantity.ToString();
            LiMain.SubItems.Add(LiS_Count);
            ListSubItem LiS_AddressEnd = new ListSubItem();
            LiS_AddressEnd.Text = Poller.End.ToString();
            LiMain.SubItems.Add(LiS_AddressEnd);
            pollerList.Add(LiMain);
            PollersChanged?.Invoke();
        }
        internal static void RemoveSelected(ListControl LstCtrl) {
            RemoveAllControls(LstCtrl);
            PausePolling();
            List<Guid> MarkedForDeletion = new List<Guid>();
            for (int i = pollerList.Count - 1; i >= 0; i--) {
                if (!pollerList[i].Selected) { continue; }
                Guid? Id = GetPollerId(pollerList[i]);
                if (Id == null) { continue; }
                MarkedForDeletion.Add((Guid)Id);
                pollerList[i].Tag = null;
                pollerList.RemoveAt(i);
            }
            for (int i = pollers.Count - 1; i >= 0; i--) {
                if (!MarkedForDeletion.Contains(pollers[i].Id)) { continue; }
                pollers[i].Channel = null;
                pollers.RemoveAt(i);
            }
            ResumePolling();
            GC.Collect();
            PollersChanged?.Invoke();
        }
        private static Guid? GetPollerId(ListItem? Li) {
            if (Li == null) { return null; }
            if (Li.Tag == null) { return null; }
            if (Li.Tag.GetType() != typeof(ModbusPoller)) { return null; }
            return ((ModbusPoller)Li.Tag).Id;
        }
        internal static void InitaliseModbusPollers() {
            Thread Tr_Pollers = new Thread(PollerThread);
            Tr_Pollers.Name = "Tr_ModbusPollerService";
            Tr_Pollers.IsBackground = true;
            Tr_Pollers.Start();
        }
        private static volatile bool PollingPaused = false;
        private static volatile bool Polling = false;
        private static volatile int CurrentPoll = 0;
        public static void PausePolling(bool WaitUntilComplete = true) {
            PollingPaused = true;
            if (WaitUntilComplete) {
                while (Polling) {
                    Thread.Sleep(1);
                }
            }
        }
        public static void ResumePolling() {
            PollingPaused = false;
        }
        private static void PollerThread() {
            while (true) {
                if (PollingPaused) { Thread.Sleep(1000); continue; }
                if (pollers.Count <= 0) { Thread.Sleep(1000); continue; }
                Polling = true;
                if ((CurrentPoll > -1) && (pollers.Count >= 1) && (CurrentPoll < pollers.Count)) {
                    pollers[CurrentPoll].Invalidate();
                }
                ++CurrentPoll;
                if (CurrentPoll >= pollers.Count) { CurrentPoll = 0; }
                Polling = false;
                Thread.Sleep(1);
            }
        }
        #endregion

        public static void AddValueBox(DropDownClickedEventArgs e, ListControl LstCtrl, string? DataToPush, bool UseItemIndex = false) {
            ListItem? LstItem = e.ParentItem;
            //LastPoint = new Point(e.Column, e.Item);
            if (LstItem == null) { return; }
            object? DataTag = LstItem.Tag;
            if (DataTag == null) { return; }
            if (e.ParentItem == null) { return; }
            if (e.ParentItem.SubItems == null) { return; }
            int ItemIndex = e.Item;
            if (UseItemIndex == false) {
                ItemIndex = e.ParentItem.Value;
            }
            if (DataTag.GetType() == typeof(ModbusPoller)) {
                ModbusPoller Poller = (ModbusPoller)DataTag;
                ODModules.NumericTextbox Tb = new ODModules.NumericTextbox();
                Tb.BackColor = LstCtrl.BackColor;
                Tb.Font = LstCtrl.Font;
                Tb.AutoSize = false;
                Tb.HasUnit = false;
                Tb.ShowLabel = false;
                Tb.ForeColor = LstCtrl.ForeColor;
                Tb.FixedNumericPadding = 6;
                Tb.AllowFractionals = false;
                Tb.AllowNegatives = false;
                Tb.UseFixedNumericPadding = false;
                Tb.SelectedBorderColor = LstCtrl.CellSelectionBorderColor;
                ModbusPollerEditItem Column = (ModbusPollerEditItem)e.Column;
                NumericalString Min = new NumericalString(0);
                NumericalString Max = new NumericalString(255);
                Tb.IsMetric = false;
                switch (Column) {
                    case ModbusPollerEditItem.Unit:
                        Tb.Value = Poller.Unit;
                        Tb.Minimum = Min;
                        Tb.Maximum = Max;
                        break;
                    case ModbusPollerEditItem.Frequency:
                        Tb.IsMetric = true;
                        Tb.HasUnit = true;
                        Tb.AllowFractionals = true;
                        if (Poller.Frequency >= 1000) {
                            Tb.Value = Poller.Frequency / 1000.0m;
                            Tb.Prefix = NumericTextbox.MetricPrefix.None;
                        }
                        else {
                            Tb.Value = Poller.Frequency;
                            Tb.Prefix = NumericTextbox.MetricPrefix.Milli;
                        }
                        Tb.Minimum = Min;
                        Tb.Maximum = new NumericalString(60000);
                        Tb.Unit = "s";
                   
                        break;
                    case ModbusPollerEditItem.AddressStart:
                        Tb.Value = Poller.Start;
                        Tb.Minimum = Min;
                        Tb.Maximum = new NumericalString(ushort.MaxValue);
                        break;
                    case ModbusPollerEditItem.AddressEnd:
                        Tb.Value = Poller.End;
                        Tb.Minimum = Min;
                        Tb.Maximum = new NumericalString(ushort.MaxValue);
                        break;
                    case ModbusPollerEditItem.Count:
                        Tb.Value = Poller.Quantity; 
                        Tb.Minimum = Min;
                        if (Poller.Selection > DataSelection.ModbusDataDiscreteInputs) {
                            Tb.Maximum = new NumericalString(125);
                        }
                        else {
                            Tb.Maximum = new NumericalString(2000);
                        }
                            break;
                    //125 

                    default:
                        break;
                }


                Tb.RangeLimited = true;
                //SetNumericTextBox(Tb, Poller);
                Tb.ArrowKeysControlNumber = false;
                Tb.Tag = new ModbusPollerEdit(Poller, LstItem, e.Column, Column);

                //Components.EditValue EdVal = new Components.EditValue(Pm.Name, LstCtrl, e.ParentItem, Indx_Name, ItemIndex, null, coil, Rect, ParRect, DataSet);
                LstCtrl.AddControlToCell(Tb);

                Tb.Focus();
                //EdVal.ArrowKeyPress += arrowKeyPressed;
                Tb.Leave += Tb_LostFocus;
                Tb.KeyPress += Tb_KeyPress;
                Tb.EnterPressed += Nb_EnterPressed;
                Tb.ValueChanged += Tb_ValueChanged;
                Tb.PrefixChanged += Tb_PrefixChanged;
                //SystemManager.InvokeModbusEditorChanged();
                if (DataToPush != null) {
                    for (int i = 0; i < DataToPush.Length; i++) {
                        Tb.PushCharacter(DataToPush[i]);
                    }
                }
            }
        }
        private static void Tb_PrefixChanged(object sender) {
            if (sender.GetType() != typeof(NumericTextbox)) { return; }
            NumericTextbox Ttb = (NumericTextbox)sender;
            if (!Ttb.HasUnit) { return; }
            if (Ttb.Prefix < NumericTextbox.MetricPrefix.Milli) {
                Ttb.Prefix = NumericTextbox.MetricPrefix.Milli;
            }
            else if (Ttb.Prefix > NumericTextbox.MetricPrefix.None) {
                Ttb.Prefix = NumericTextbox.MetricPrefix.None;
            }
            ChangeValue(sender);
        }
        private static void Tb_LostFocus(object? sender, EventArgs e) {
            RemoveControl(sender);
        }
        private static void Nb_EnterPressed(NumericTextbox sender) {
            RemoveControl(sender);
        }
        private static void Tb_KeyPress(object? sender, KeyPressEventArgs e) {
            if (e.KeyChar == ' ') {
                RemoveControl(sender);
            }
        }
        private static void Tb_ValueChanged(object sender, ValueChangedEventArgs e) {
            ChangeValue(sender);
        }
        private static void ChangeValue(object sender) {
            if (sender.GetType() != typeof(NumericTextbox)) { return; }
            NumericTextbox Ttb = (NumericTextbox)sender;
            object? Tag = Ttb.Tag;
            if (Tag == null) { return; }
            if (Tag.GetType() != typeof(ModbusPollerEdit)) { return; }
            ModbusPollerEdit pd = (ModbusPollerEdit)Tag;
            if (pd == null) { return; }

            string Value = Ttb.Value.ToString() ?? "0";
            decimal IntValue = 0;
            decimal.TryParse(Value, out IntValue);
            if ((Ttb.HasUnit) && (Ttb.Prefix == NumericTextbox.MetricPrefix.None)) {
                IntValue = IntValue * 1000;
            }
            ModbusPollerEditItem Column = pd.EditItem;
            try {
                switch (Column) {
                    case ModbusPollerEditItem.Unit:
                        SetPollerUnit(pd.EditorItem, (ushort)IntValue);
                        break;
                    case ModbusPollerEditItem.Frequency:
                        SetPollerFrequency(pd.EditorItem, (int)IntValue);
                        break;
                    case ModbusPollerEditItem.AddressStart:
                        SetPollerAddressStart(pd.EditorItem, (ushort)IntValue);
                        break;
                    case ModbusPollerEditItem.AddressEnd:
                        SetPollerAddressEnd(pd.EditorItem, (ushort)IntValue);
                        break;
                    case ModbusPollerEditItem.Count:
                        SetPollerCount(pd.EditorItem, (ushort)IntValue);
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }
        private static void RemoveControl(object? sender, bool InvokeEvent = true) {
            if (sender == null) { return; }
            if (sender.GetType() == typeof(ODModules.NumericTextbox)) {
                ODModules.NumericTextbox OdTb = (ODModules.NumericTextbox)sender;
                OdTb.LostFocus -= Tb_LostFocus;
                OdTb.EnterPressed -= Nb_EnterPressed;
                OdTb.ValueChanged -= Tb_ValueChanged;
                OdTb.PrefixChanged -= Tb_PrefixChanged;
                if (OdTb.Parent == null) { return; }
                OdTb.Parent.Controls.Remove(OdTb);
            }
            if (InvokeEvent) { SystemManager.InvokeModbusEditorChanged(); }
        }
        public static void RemoveAllControls(ODModules.ListControl LstCtrl) {
            if (LstCtrl.Controls.Count == 0) { return; }
            for (int i = LstCtrl.Controls.Count - 1; i >= 0; i--) {
                RemoveControl(LstCtrl.Controls[i], false);
            }
            //SystemManager.InvokeModbusEditorChanged();
        }
        public static void ClearControls(ListControl LstCtrl) {
            LstCtrl.Controls.Clear();
            // GC.Collect();
            Thread Tr = new Thread(PurgeData);
            Tr.IsBackground = true;
            Tr.Start();
        }
        static DateTime PreviousInstance = DateTime.MinValue;
        internal static void PurgeData() {
            if (ConversionHandler.DateIntervalDifference(PreviousInstance, DateTime.UtcNow, ConversionHandler.Interval.Millisecond) >= 1000) {
                GC.Collect();
                PreviousInstance = DateTime.UtcNow;
            }
        }

        public static void ChangeDataSelection(DropDownClickedEventArgs? e, ListControl? LstMonitor, string? SearchText) {
            if (e == null) { return; }
            if (LstMonitor == null) { return; }
            if (e.ParentItem == null) { return; }
            object? TempData = e.ParentItem.Tag;
            if (TempData == null) { return; }
            if (TempData.GetType() != typeof(ModbusRegister)) { return; }
            ModbusRegister Reg = (ModbusRegister)TempData;
            if (SearchText == null) { return; }
            if (SearchText.Trim() == "") { return; }
            DataSelection[] Formats = (DataSelection[])DataSelection.GetValues(typeof(DataSelection));
            DataSelection Selection = DataSelection.ModbusDataHoldingRegisters;
            foreach (DataSelection Frmt in Formats) {
                string Data = EnumManager.ModbusDataSelectionToString(Frmt).A;
                if (Data.ToLower().Contains(SearchText.ToLower())) {
                    Selection = Frmt;
                    break;
                }
            }
            SetPollerFunction(e.ParentItem, Selection);
        }
        public static void CheckItem(object DropDownList, DataSelection CheckOn) {
            if (DropDownList.GetType() == typeof(ContextMenu)) {
                ContextMenu Btn = (ContextMenu)DropDownList;
                foreach (ToolStripItem Tsi in Btn.Items) {
                    if (Tsi.GetType() != typeof(ToolStripMenuItem)) { continue; }
                    ToolStripMenuItem Item = (ToolStripMenuItem)Tsi;
                    if (Item.Tag == null) {
                        Item.Checked = false;
                        continue;
                    }
                    else {
                        if (Item.Tag.GetType() == typeof(DataSelection)) {
                            DataSelection dataFormat = (DataSelection)Item.Tag;
                            if (dataFormat == CheckOn) { Item.Checked = true; }
                            else { Item.Checked = false; }
                        }
                    }
                }
            }
        }
    }
    public class ModbusPollerEdit {
        private ListItem editorItem;
        public ListItem EditorItem {
            get { return editorItem; }
        }
        private ModbusPoller poller;
        public ModbusPoller Poller {
            get { return poller; }
        }
        private int column;
        public int Column {
            get { return column; }
        }
        private ModbusPollerEditItem editItem;
        public ModbusPollerEditItem EditItem {
            get { return editItem; }
        }
        public ModbusPollerEdit(ModbusPoller Poller, ListItem EditorItem, int Column, ModbusPollerEditItem EditItem) {
            this.poller = Poller;
            this.editorItem = EditorItem;
            this.column = Column;
            this.editItem = EditItem;
        }
    }
    public enum ModbusPollerEditItem {
        Enable = 0x00,
        Frequency = 0x01,
        Channel = 0x02,
        Unit = 0x03,
        Function = 0x04,
        AddressStart = 0x05,
        Count = 0x06,
        AddressEnd = 0x07
    }
}
