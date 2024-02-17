using Serial_Monitor.Classes.Modbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.Components {
    public partial class SnapshotClient : UserControl {
        public SnapshotClient() {
            InitializeComponent();
        }
        public List<MdiClientForm> ChildForms = new List<MdiClientForm>();
        public MdiClientForm AddChild(MdiClientForm child) {
            ChildForms.Add(child);
            child.MyMdiContainer = this;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            pnlClient.Controls.Add(child);
            child.Show();
            if (tileWindows == true) {
                LayoutGrid();
            }
            return child;
        }
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
        public void CloseForm(MdiClientForm Frm) {
            for(int i = ChildForms.Count - 1; i >= 0; i--) {
                if (Frm.ID == ChildForms[i].ID) {
                    ChildForms.RemoveAt(i);
                    break;
                }
            }
            if (tileWindows) {
                LayoutGrid();
            }
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
        private Point AddToPoint(Point InputA, Point InputB, bool AddX = true, bool AddY = true) {
            return new Point((AddX == true ? InputA.X + InputB.X : 0), (AddY == true ? InputA.Y + InputB.Y : 0));
        }
        private Point AddToPoint(Size InputA, Point InputB, bool AddX = true, bool AddY = true) {
            return new Point((AddX == true ? InputA.Width + InputB.X : InputB.X), (AddY == true ? InputA.Height + InputB.Y : InputB.Y));
        }

        private void pnlClient_SizeChanged(object sender, EventArgs e) {
            if (tileWindows) {
                LayoutGrid();
            }
        }
    }
}
