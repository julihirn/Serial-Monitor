﻿using Handlers;
using ODModules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public class ModbusSnapshot {
        const int Indx_Name = 1;
        const int Indx_Display = 2;
        const int Indx_Size = 3;
        const int Indx_Signed = 4;
        const int Indx_Value = 2;

        public event SnapshotRemovedHandler? SnapshotRemoved;
        public delegate void SnapshotRemovedHandler(object sender);

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
                        string Range = "(" + StartIndex.ToString() + ", " + EndIndex.ToString() + ")";
                        return manager.StateName + " - " + EnumManager.ModbusDataSelectionToString(Selection).A + Range;
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
        SerialManager? manager = null;
        public SerialManager? Manager {
            get { return manager; }
            set {
                manager = value;
            }
        }
        private List<ListItem> listings = new List<ListItem>();
        public List<ListItem> Listings {
            get { return listings; }
        }
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
            if (listings[LocalIndex].SubItems.Count >= 2) {
                switch (selection) {
                    case DataSelection.ModbusDataCoils:
                        listings[LocalIndex][Indx_Name].Text = manager.Coils[Index].Name;
                        break;
                    case DataSelection.ModbusDataDiscreteInputs:
                        listings[LocalIndex][Indx_Name].Text = manager.DiscreteInputs[Index].Name;
                        break;
                    case DataSelection.ModbusDataInputRegisters:
                        listings[LocalIndex][Indx_Name].Text = manager.InputRegisters[Index].Name;
                        break;
                    case DataSelection.ModbusDataHoldingRegisters:
                        listings[LocalIndex][Indx_Name].Text = manager.HoldingRegisters[Index].Name;
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
            if (listings[LocalIndex].SubItems.Count >= Indx_Value) {
                switch (selection) {
                    case DataSelection.ModbusDataCoils:
                        listings[LocalIndex][Indx_Value].Text = manager.Coils[Index].Value.ToString();
                        break;
                    case DataSelection.ModbusDataDiscreteInputs:
                        listings[LocalIndex][Indx_Value].Text = manager.DiscreteInputs[Index].Value.ToString();
                        break;
                    case DataSelection.ModbusDataInputRegisters:
                        listings[LocalIndex][Indx_Value].Text = manager.InputRegisters[Index].FormattedValue;
                        break;
                    case DataSelection.ModbusDataHoldingRegisters:
                        listings[LocalIndex][Indx_Value].Text = manager.HoldingRegisters[Index].FormattedValue;
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
            if (listings[LocalIndex].SubItems.Count >= Indx_Value) {
                switch (selection) {
                    case DataSelection.ModbusDataCoils:
                        listings[LocalIndex][Indx_Value].Text = manager.Coils[Index].Value.ToString();
                        break;
                    case DataSelection.ModbusDataDiscreteInputs:
                        listings[LocalIndex][Indx_Value].Text = manager.DiscreteInputs[Index].Value.ToString();
                        break;
                    case DataSelection.ModbusDataInputRegisters:
                        listings[LocalIndex][Indx_Value].Text = manager.InputRegisters[Index].FormattedValue;
                        break;
                    case DataSelection.ModbusDataHoldingRegisters:
                        listings[LocalIndex][Indx_Value].Text = manager.HoldingRegisters[Index].FormattedValue;
                        break;
                }

            }
        }
        public ModbusSnapshot(SerialManager serialManager, DataSelection selection, int StartIndex, int Count) {
            iD = Guid.NewGuid().ToString();
            manager = serialManager;
            this.selection = selection;
            this.startIndex = StartIndex;
            this.count = Count;
            int Offset = StartIndex;
            for (int i = 0; i < Count; i++) {
                AddLine(Offset);
                Offset++;
            }
        }
        public ModbusSnapshot(SerialManager serialManager, DataSelection selection, int StartIndex, int Count, Rectangle Bounds) {
            iD = Guid.NewGuid().ToString();
            manager = serialManager;
            this.selection = selection;
            this.startIndex = StartIndex;
            this.count = Count;
            int Offset = StartIndex;
            for (int i = 0; i < Count; i++) {
                AddLine(Offset);
                Offset++;
            }
            this.Bounds = Bounds;
        }
        private void AddLine(int Index) {
            if (Index > short.MaxValue) { return; }
            if (manager == null) { return; }
            ListItem PLi = new ListItem();
            PLi.Value = Index;
            ListSubItem CLi1 = new ListSubItem();
            ListSubItem CLi3 = new ListSubItem();
            if (selection == DataSelection.ModbusDataCoils) {
                PLi.Tag = manager.Coils[Index];
                CLi1.Text = manager.Coils[Index].Name;
                CLi3.Text = manager.Coils[Index].Value.ToString();
            }
            else if (selection == DataSelection.ModbusDataDiscreteInputs) {
                PLi.Tag = manager.DiscreteInputs[Index];
                CLi1.Text = manager.DiscreteInputs[Index].Name;
                CLi3.Text = manager.DiscreteInputs[Index].Value.ToString();
            }
            else if (selection == DataSelection.ModbusDataHoldingRegisters) {
                PLi.Tag = manager.HoldingRegisters[Index];
                CLi1.Text = manager.HoldingRegisters[Index].Name;
                CLi3.Text = manager.HoldingRegisters[Index].FormattedValue;
            }
            else if (selection == DataSelection.ModbusDataInputRegisters) {
                PLi.Tag = manager.InputRegisters[Index];
                CLi1.Text = manager.InputRegisters[Index].Name;
                CLi3.Text = manager.InputRegisters[Index].FormattedValue;
            }
            PLi.SubItems.Add(CLi1);
            PLi.SubItems.Add(CLi3);
            listings.Add(PLi);
        }
    }
}
