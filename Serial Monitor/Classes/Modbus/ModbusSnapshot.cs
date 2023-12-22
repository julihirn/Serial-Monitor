using Handlers;
using Microsoft.Win32;
using ODModules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public class ModbusSnapshot {
        //public event SnapshotAppearanceChangedHandler? AppearanceChanged;
        //public delegate void SnapshotAppearanceChangedHandler(object sender);


        public event SnapshotRemovedHandler? SnapshotRemoved;
        public delegate void SnapshotRemovedHandler(object sender);

        #region Properties
        Classes.Enums.ModbusEnums.SnapshotSelectionType selectType = Enums.ModbusEnums.SnapshotSelectionType.Concurrent;
        public Classes.Enums.ModbusEnums.SnapshotSelectionType SelectionType {
            get { return selectType; }
        }
        int startIndex = 0;
        public int StartIndex {
            get { return startIndex; }
            set { startIndex = value; }
        }
        public int EndIndex {
            get {
                return startIndex + count - 1;
            }
        }
        int count = 1;
        public int Count {
            get { return count; }
            set {
                if (value > 0) {
                    count = value;
                }
            }
        }
        string name = "";
        public string BaseName {
            get { return name; }
        }
        public string Name {
            get {
                if (name.Trim().Length > 0) {
                    return name;
                }
                else {
                    if (manager != null) {
                        if (manager.Manager != null) {
                            string DeviceName = manager.Manager.StateName;
                            if (manager.Manager.IsMaster) {
                                DeviceName += " (Master: Unit " + manager.Address.ToString() + ")";
                            }
                            else {
                                DeviceName += " (Slave: Unit " + manager.Manager.UnitAddress.ToString() + ")";
                            }
                            if (selectType == Enums.ModbusEnums.SnapshotSelectionType.Concurrent) {
                                string Range = "(" + StartIndex.ToString() + ", " + EndIndex.ToString() + ")";
                                return DeviceName + " - " + EnumManager.ModbusDataSelectionToString(Selection).A + Range;
                            }
                            else {
                                return DeviceName + " - " + EnumManager.ModbusDataSelectionToString(Selection).A;
                            }
                        }
                        return name;
                    }
                    else {
                        return name;
                    }
                }
            }
            set { name = value; }
        }
        Rectangle bounds = new Rectangle();
        public Rectangle Bounds {
            get { return bounds; }
            set { bounds = value; }
        }
        public Size Size {
            get { return bounds.Size; }
            set {
                Rectangle Temp = bounds;
                bounds = new Rectangle(Temp.Location, value);
            }
        }
        public Point Location {
            get { return bounds.Location; }
            set {
                Rectangle Temp = bounds;
                bounds = new Rectangle(value, Temp.Size);
            }
        }
        DataSelection selection = DataSelection.ModbusDataCoils;
        public DataSelection Selection {
            get { return selection; }
            set { selection = value; }
        }
        ModbusSlave? manager = null;
        public ModbusSlave? Manager {
            get { return manager; }
            set {
                manager = value;
            }
        }
        private List<ListItem> listings = new List<ListItem>();
        public List<ListItem> Listings {
            get { return listings; }
        }
        #endregion
        string iD = "";
        [Browsable(false)]
        public string ID {
            get { return iD; }
        }
        public void Close() {
            SnapshotRemoved?.Invoke(this);
            manager = null;

            for (int i = listings.Count - 1; i >= 0; i--) {
                listings[i].SubItems.Clear();
                listings.RemoveAt(i);
            }
        }
        public void RenameFromRegister(int Index) {
            if (manager == null) { return; }
            if (listings.Count <= 0) { return; }
            int LocalIndex = GetListIndex(Index, ref listings);
            if (LocalIndex >= listings.Count) { return; }
            if (LocalIndex < 0) { return; }
            if (listings[LocalIndex].SubItems.Count >= ModbusEditor.Indx_Name) {
                switch (selection) {
                    case DataSelection.ModbusDataCoils:
                        listings[LocalIndex][ModbusEditor.Indx_Name].Text = manager.Coils[Index].Name;
                        break;
                    case DataSelection.ModbusDataDiscreteInputs:
                        listings[LocalIndex][ModbusEditor.Indx_Name].Text = manager.DiscreteInputs[Index].Name;
                        break;
                    case DataSelection.ModbusDataInputRegisters:
                        listings[LocalIndex][ModbusEditor.Indx_Name].Text = manager.InputRegisters[Index].Name;
                        break;
                    case DataSelection.ModbusDataHoldingRegisters:
                        listings[LocalIndex][ModbusEditor.Indx_Name].Text = manager.HoldingRegisters[Index].Name;
                        break;
                }

            }
        }
        public void UpdateRow(int Index) {
            if (manager == null) { return; }
            if (listings.Count <= 0) { return; }
            int LocalIndex = GetListIndex(Index, ref listings);
            if (LocalIndex >= listings.Count) { return; }
            if (LocalIndex < 0) { return; }
            if (listings[LocalIndex].SubItems.Count <= ModbusEditor.Indx_Value) {
                switch (selection) {
                    case DataSelection.ModbusDataCoils:
                        listings[LocalIndex][ModbusEditor.Indx_Value].Text = manager.Coils[Index].Value.ToString();
                        break;
                    case DataSelection.ModbusDataDiscreteInputs:
                        listings[LocalIndex][ModbusEditor.Indx_Value].Text = manager.DiscreteInputs[Index].Value.ToString();
                        break;
                    case DataSelection.ModbusDataInputRegisters:
                        listings[LocalIndex][ModbusEditor.Indx_Display].Text = EnumManager.DataFormatToString(manager.InputRegisters[Index].Format).A;
                        listings[LocalIndex][ModbusEditor.Indx_Size].Text = EnumManager.DataSizeToString(manager.InputRegisters[Index].Size);
                        listings[LocalIndex][ModbusEditor.Indx_Signed].Checked = manager.InputRegisters[Index].Signed;
                        listings[LocalIndex][ModbusEditor.Indx_Value].Text = manager.InputRegisters[Index].FormattedValue;
                        break;
                    case DataSelection.ModbusDataHoldingRegisters:
                        listings[LocalIndex][ModbusEditor.Indx_Display].Text = EnumManager.DataFormatToString(manager.HoldingRegisters[Index].Format).A;
                        listings[LocalIndex][ModbusEditor.Indx_Size].Text = EnumManager.DataSizeToString(manager.HoldingRegisters[Index].Size);
                        listings[LocalIndex][ModbusEditor.Indx_Signed].Checked = manager.HoldingRegisters[Index].Signed;
                        listings[LocalIndex][ModbusEditor.Indx_Value].Text = manager.HoldingRegisters[Index].FormattedValue;
                        break;
                }
            }
        }
        private static int GetListIndex(int AbsoluteIndex, ref List<ListItem> List) {
            if (List.Count <= 0) { return -1; }
            for (int i = 0; i < List.Count; i++) {
                if (List[i].Value == AbsoluteIndex) {
                    return i;
                }
            }
            return -1;
        }
        public void SetValue(int Index) {
            if (manager == null) { return; }
            int LocalIndex = GetListIndex(Index, ref listings);
            if (listings.Count <= 0) { return; }
            if (LocalIndex >= listings.Count) { return; }
            if (LocalIndex < 0) { return; }
            if (listings[LocalIndex].SubItems.Count <= ModbusEditor.Indx_Value) {
                switch (selection) {
                    case DataSelection.ModbusDataCoils:
                        listings[LocalIndex][ModbusEditor.Indx_Value].Text = manager.Coils[Index].Value.ToString();
                        break;
                    case DataSelection.ModbusDataDiscreteInputs:
                        listings[LocalIndex][ModbusEditor.Indx_Value].Text = manager.DiscreteInputs[Index].Value.ToString();
                        break;
                    case DataSelection.ModbusDataInputRegisters:
                        listings[LocalIndex][ModbusEditor.Indx_Value].Text = manager.InputRegisters[Index].FormattedValue;
                        break;
                    case DataSelection.ModbusDataHoldingRegisters:
                        listings[LocalIndex][ModbusEditor.Indx_Value].Text = manager.HoldingRegisters[Index].FormattedValue;
                        break;
                }

            }
        }

        public ModbusSnapshot(ModbusSlave serialManager, DataSelection selection, List<int> Indices) {
            InitaliseCustom(serialManager, selection, Indices);
        }
        public ModbusSnapshot(ModbusSlave serialManager, DataSelection selection, List<int> Indices, Rectangle Bounds) {
            InitaliseCustom(serialManager, selection, Indices);
            this.Bounds = Bounds;
        }
        public ModbusSnapshot(ModbusSlave serialManager, DataSelection selection, int StartIndex, int Count) {
            InitaliseConcurrent(serialManager, selection, StartIndex, Count);
        }
        public ModbusSnapshot(ModbusSlave serialManager, DataSelection selection, int StartIndex, int Count, Rectangle Bounds) {
            InitaliseConcurrent(serialManager, selection, StartIndex, Count);
            this.Bounds = Bounds;
        }
        private void InitaliseConcurrent(ModbusSlave slave, DataSelection selection, int StartIndex, int Count) {
            iD = Guid.NewGuid().ToString();
            selectType = Enums.ModbusEnums.SnapshotSelectionType.Concurrent;
            manager = slave;
            this.selection = selection;
            this.startIndex = StartIndex;
            this.count = Count;
            int Offset = StartIndex;
            for (int i = 0; i < Count; i++) {
                AddLine(Offset);
                Offset++;
            }
        }
        private void InitaliseCustom(ModbusSlave slave, DataSelection selection, List<int> Indices) {
            iD = Guid.NewGuid().ToString();
            selectType = Enums.ModbusEnums.SnapshotSelectionType.Custom;
            manager = slave;
            this.selection = selection;
            if (Indices.Count > 0) {
                this.startIndex = Indices[0];
                this.count = Indices.Count;
                foreach (int x in Indices) {
                    AddLine(x);
                }
            }
        }
        private void AddLine(int Index) {
            if (Index > ModbusSupport.MaximumRegisters) { return; }
            if (manager == null) { return; }
            ListItem PLi = new ListItem();
            PLi.Value = Index;
            if (selectType == Enums.ModbusEnums.SnapshotSelectionType.Custom) {
                PLi.Text = Index.ToString();
            }
            ListSubItem CLi1 = new ListSubItem();
            ListSubItem CLi2 = new ListSubItem();
            ListSubItem CLi3 = new ListSubItem();
            ListSubItem CLi4 = new ListSubItem();
            ListSubItem CLi5 = new ListSubItem();
            if (selection == DataSelection.ModbusDataCoils) {
                PLi.Tag = manager.Coils[Index];
                CLi1.Text = manager.Coils[Index].Name;
                CLi2.Text = "Boolean";
                CLi3.Text = "";
                CLi4.Text = "";
                CLi5.Text = manager.Coils[Index].Value.ToString();
            }
            else if (selection == DataSelection.ModbusDataDiscreteInputs) {
                PLi.Tag = manager.DiscreteInputs[Index];
                CLi1.Text = manager.DiscreteInputs[Index].Name;
                CLi2.Text = "Boolean";
                CLi3.Text = "";
                CLi4.Text = "";
                CLi5.Text = manager.DiscreteInputs[Index].Value.ToString();
            }
            else if (selection == DataSelection.ModbusDataHoldingRegisters) {
                PLi.Tag = manager.HoldingRegisters[Index];
                CLi1.Text = manager.HoldingRegisters[Index].Name;
                CLi2.Text = EnumManager.DataFormatToString(manager.HoldingRegisters[Index].Format).A;
                CLi3.Text = EnumManager.DataSizeToString(manager.HoldingRegisters[Index].Size);
                CLi4.Checked = manager.HoldingRegisters[Index].Signed;
                CLi5.Text = manager.HoldingRegisters[Index].FormattedValue;
            }
            else if (selection == DataSelection.ModbusDataInputRegisters) {
                PLi.Tag = manager.InputRegisters[Index];
                CLi1.Text = manager.InputRegisters[Index].Name;
                CLi2.Text = EnumManager.DataFormatToString(manager.InputRegisters[Index].Format).A;
                CLi3.Text = EnumManager.DataSizeToString(manager.InputRegisters[Index].Size);
                CLi4.Checked = manager.InputRegisters[Index].Signed;
                CLi5.Text = manager.InputRegisters[Index].FormattedValue;
            }
            PLi.SubItems.Add(CLi1);
            PLi.SubItems.Add(CLi2);
            PLi.SubItems.Add(CLi3);
            PLi.SubItems.Add(CLi4);
            PLi.SubItems.Add(CLi5);
            listings.Add(PLi);
        }
    }
}
