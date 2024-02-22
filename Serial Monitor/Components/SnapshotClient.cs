using Serial_Monitor.Classes.Modbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Serial_Monitor.Components {
    public partial class SnapshotClient : UserControl {
        public delegate void ActivateHandler(object? sender, MdiClientForm child, int Index);
        public event ActivateHandler OnChildActivated;
        public delegate void AllClosedHandler(object? sender);
        public event AllClosedHandler OnNoForms;
        public delegate void SnapshotsChangedHandler(object? sender);
        public event SnapshotsChangedHandler SnapshotsChanged;
        public SnapshotClient() {
            InitializeComponent();
            pnlClient.ControlAdded += SnapshotClient_ControlAdded;
            pnlClient.ControlRemoved += SnapshotClient_ControlRemoved;
        }
        ToolStripMenuItem? selectorCollection = null;
        public ToolStripMenuItem? SelectorCollection {
            get { return selectorCollection; }
            set {
                if (selectorCollection != null) {
                    selectorCollection.DropDownOpening -= SelectorCollection_DropDownOpening;
                }
                selectorCollection = value;
                Populate();
                if (selectorCollection != null) {
                    selectorCollection.DropDownOpening += SelectorCollection_DropDownOpening;
                }
            }
        }
     
        private void SnapshotClient_Click(object? sender, EventArgs e) {
            if (sender == null) { return; }
            if (sender.GetType() != typeof(ToolStripMenuItem)) { return; }
            ToolStripMenuItem Tsmi = (ToolStripMenuItem)sender;
            if (Tsmi.Tag == null) { return; }
            if (Tsmi.Tag.GetType() != typeof(int)) { return; }
            InvokeByIndex((int)Tsmi.Tag);
        }

        public int Count {
            get { return ChildForms.Count; }
        }
        public List<MdiClientForm> ChildForms = new List<MdiClientForm>();
        public MdiClientForm AddChild(MdiClientForm child) {
            ChildForms.Add(child);
            child.MyMdiContainer = this;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.OnActivation += Child_OnActivation;
            pnlClient.Controls.Add(child);
            child.Show();
            if (tileWindows == true) {
                LayoutGrid();
            }
            Populate();
            SnapshotsChanged?.Invoke(this);
            return child;
        }

        private void Child_OnActivation(MdiClientForm child) {
            if (child.GetType() != typeof(ToolWindows.ModbusRegister)) { return; }
            InvokeById(((ToolWindows.ModbusRegister)child).ID);
            //Debug.Print(((ToolWindows.ModbusRegister)child).ID);
        }

        //private void Child_Validated(object? sender, EventArgs e) {
        //    if (sender == null) { return; }
        //    if (sender.GetType() != typeof(ToolWindows.ModbusRegister)) { return; }
        //    InvokeById(((ToolWindows.ModbusRegister)sender).ID);
        //    Debug.Print(((ToolWindows.ModbusRegister)sender).ID);
        //}

        //private void Child_GotFocus(object? sender, EventArgs e) {
        //    if (sender == null) { return; }
        //    if (sender.GetType() != typeof(ToolWindows.ModbusRegister)) { return; }
        //    InvokeById(((ToolWindows.ModbusRegister)sender).ID);
        //}

        bool tileWindows = false;
        public bool TileWindows {
            get { return tileWindows; }
            set {
                tileWindows = value;
                if (value == true) {
                    LayoutGrid();
                }
            }
        }
        int focusedForm = -1;
        public int FocusedForm {
            get { return focusedForm; }
        }
        public void CloseForm(MdiClientForm Frm) {
            for (int i = ChildForms.Count - 1; i >= 0; i--) {
                if (Frm.ID == ChildForms[i].ID) {
                    Frm.OnActivation -= Child_OnActivation;
                    ChildForms.RemoveAt(i);
                    break;
                }
            }
            if (tileWindows) {
                LayoutGrid();
            }
            Populate();
            SnapshotsChanged?.Invoke(this);
        }
        private void SnapshotClient_Load(object sender, EventArgs e) {

        }
        public void LayoutGrid() {
            Size TempSize = this.Size;
            int FormCount = ChildForms.Count;
            int Columns = (int)Math.Floor((double)TempSize.Width / (double)ModbusEditor.MinimumSize.Width);
            if (Columns <= 0) { return; }
            int Rows = (int)Math.Ceiling((float)FormCount / (float)Columns);
            Point AnchorPoint = new Point(0, 0);
            if (FormCount <= Columns) {
                int TempCount = FormCount <= 0 ? 1 : FormCount;
                foreach (MdiClientForm Form in ChildForms) {
                    Form.Location = AnchorPoint;
                    Size WindowSize = new Size(TempSize.Width / FormCount, Height);
                    Form.Size = WindowSize;
                    AnchorPoint = AddToPoint(WindowSize, AnchorPoint, true, false);
                }
            }
            else {
                if (Rows <= 0) { return; }
                int i = 0;
                int CurrentColumn = 0;
                int CurrentRow = 0;
                bool FillLast = false;
                bool IsLast = false;
                foreach (MdiClientForm Form in ChildForms) {
                    Form.Location = AnchorPoint;
                    Size WindowSize = new Size(TempSize.Width / Columns, Height / Rows);
                    if (FillLast == true) {
                        FillLast = false;
                    }
                    Form.Size = WindowSize;
                    AnchorPoint = AddToPoint(WindowSize, AnchorPoint, true, false);
                    i++;
                    CurrentColumn++;
                    if (i % Columns == 0) {
                        if (IsLast == false) {
                            AnchorPoint = AddToPoint(new Size(0, Height / Rows), new Point(0, AnchorPoint.Y), false, true);
                            CurrentColumn = 0;
                            CurrentRow++;

                            if (CurrentRow == Rows - 1) {
                                int TempColumns = FormCount - i;
                                if (TempColumns < Columns) {
                                    Columns = TempColumns;
                                    if (TempColumns <= 0) { TempColumns = 1; }
                                    FillLast = true;
                                    IsLast = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void InvokeById(string Id) {
            MdiClientForm? ClientFrm = null;
            int i = 0;
            foreach (MdiClientForm CFrm in this.ChildForms) {
                if (CFrm.ID == Id) {
                    ClientFrm = CFrm;
                    break;
                }
                i++;
            }
            if (ClientFrm == null) { return; }
            SelectForm(i);
            OnChildActivated?.Invoke(this, ClientFrm, i);
        }
        private void InvokeByIndex(int Index) {
            MdiClientForm? ClientFrm = null;
            if (Index < 0) {
                OnNoForms?.Invoke(this);
                return;
            }
            if (ChildForms.Count <= 0) { OnNoForms?.Invoke(this); return; }
            if (Index < 0) { return; }
            if (Index >= ChildForms.Count) { OnNoForms?.Invoke(this); return; }
            ClientFrm = ChildForms[Index];
            SelectForm(Index);
            if (ClientFrm == null) { OnNoForms?.Invoke(this); return; }
            OnChildActivated?.Invoke(this, ClientFrm, Index);
        }
        private void SelectForm(int Index) {
            if (ChildForms.Count <= 0) { return; }
            if (Index >= ChildForms.Count) { return; }
            if (Index < 0) { return; }
            int i = 0;
            foreach (MdiClientForm CFrm in this.ChildForms) {
                if (i == Index) {
                    CFrm.Selected = true;
                }
                else { CFrm.Selected = false; }
                i++;
            }
        }
        private Point AddToPoint(Point InputA, Point InputB, bool AddX = true, bool AddY = true) {
            return new Point((AddX == true ? InputA.X + InputB.X : 0), (AddY == true ? InputA.Y + InputB.Y : 0));
        }
        private Point AddToPoint(Size InputA, Point InputB, bool AddX = true, bool AddY = true) {
            return new Point((AddX == true ? InputA.Width + InputB.X : InputB.X), (AddY == true ? InputA.Height + InputB.Y : InputB.Y));
        }
        private void SnapshotClient_ControlRemoved(object? sender, ControlEventArgs e) {
            InvokeByIndex(ChildForms.Count - 1);
        }
        private void SnapshotClient_ControlAdded(object? sender, ControlEventArgs e) {
            InvokeByIndex(ChildForms.Count - 1);
            //InvokeActivationChange();
        }
        private void pnlClient_SizeChanged(object sender, EventArgs e) {
            if (tileWindows) {
                LayoutGrid();
            }
        }
        #region Closing
        public void CloseAll() {
            for (int i = this.ChildForms.Count - 1; i >= 0; i--) {
                if (this.ChildForms[i].GetType() == typeof(ToolWindows.ModbusRegister)) {
                    ((ToolWindows.ModbusRegister)this.ChildForms[i]).ForceClose();
                }
            }
        }
        public void CloseAtIndex(int Index) {
            if (ChildForms.Count <= 0) { return; }
            if (Index >= ChildForms.Count) { return; }
            if (Index < 0) { return; }
            if (this.ChildForms[Index].GetType() == typeof(ToolWindows.ModbusRegister)) {
                ((ToolWindows.ModbusRegister)this.ChildForms[Index]).ForceClose();
            }
        }
        private void pnlClient_Paint(object sender, PaintEventArgs e) {

        }
        #endregion
        #region Selector Settings
        private void SelectorCollection_DropDownOpening(object? sender, EventArgs e) {
            if (selectorCollection == null) { return; }
            foreach (object item in selectorCollection.DropDownItems) {
                if (item.GetType() == typeof(ToolStripMenuItem)) {
                    ToolStripMenuItem Tsmi = (ToolStripMenuItem)item;
                    if (Tsmi.Tag == null) { continue; }
                    if (Tsmi.Tag.GetType() != typeof(int)) { continue; }
                    int Index = (int)Tsmi.Tag;
                    if (Index < 0) { continue; }
                    if (Index >= ChildForms.Count) { continue; }
                    Tsmi.Checked = ChildForms[Index].Selected;
                    if (ChildForms[Index].GetType() == typeof(ToolWindows.ModbusRegister)) {
                        ToolWindows.ModbusRegister Mbr = (ToolWindows.ModbusRegister)ChildForms[Index];
                        Tsmi.Text = Mbr.Text;
                    }
                }
            }
        }
        private void Populate() {
            if (selectorCollection == null) { return; }
            if (Count == 0) {
                selectorCollection.Enabled = false;
            }
            else {
                selectorCollection.Enabled = true;
                try {
                    ClearSelector();
                    PopulateSelector();
                }
                catch { }
            }
        }
        private void ClearSelector() {
            if (selectorCollection == null) { return; }
            for (int i = selectorCollection.DropDownItems.Count - 1; i >= 0; i--) {
                selectorCollection.DropDownItems[i].Click -= SnapshotClient_Click;
                selectorCollection.DropDownItems.RemoveAt(i);
            }
        }
        private void PopulateSelector() {
            if (selectorCollection == null) { return; };
            int i = 0;
            foreach (MdiClientForm Form in ChildForms) {
                if (Form.GetType() == typeof(ToolWindows.ModbusRegister)) {
                    ToolStripMenuItem Tsmi = new ToolStripMenuItem();
                    ToolWindows.ModbusRegister Mbr = (ToolWindows.ModbusRegister)Form;
                    Tsmi.Checked = Mbr.Selected;
                    Tsmi.Tag = i;
                    Tsmi.ImageScaling = ToolStripItemImageScaling.None;
                    Tsmi.Text = Mbr.Text;
                    Tsmi.Click += SnapshotClient_Click;
                    selectorCollection.DropDownItems.Add(Tsmi);
                }
                i++;
            }
        }
        #endregion
    }
}
