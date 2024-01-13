using ODModules;
using Serial_Monitor.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Components.EditValue;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Serial_Monitor.Components {
    public partial class EditNumber : UserControl, Interfaces.ITheme {
        public event ArrowKeyPressedHandler? ArrowKeyPress;
        ODModules.ListControl? lstControl = null;
        ListItem? ListItem = null;
        bool UseName = false;
        int Index = -1;
        int Column = -1;
        Rectangle ParentBounds = Rectangle.Empty;
        public EditNumber(ODModules.ListControl? List, ListItem? Item, int Column, int Index, bool UseName, Rectangle ObjectBounds, Rectangle ParentBounds) {
            InitializeComponent();
            this.Size = ObjectBounds.Size;
            this.Location = ObjectBounds.Location;
            this.ParentBounds = ParentBounds;
            ListItem = Item;
            lstControl = List;
            this.UseName = UseName;
            if (Index < 0) { return; }
            this.Index = Index;
            this.Column = Column;
            ApplyTheme();
            AdjustUI();
            BindParentEvents();
            this.LostFocus += EditValue_LostFocus;
        }
        Color selectedColor = Color.Blue;
        public Color SelectedColor {
            get { return selectedColor; }
            set { selectedColor = value; Invalidate(); }
        }
        private void AdjustUI() {

        }
        private void EditValue_LostFocus(object? sender, EventArgs e) {
            // PushValue();
        }

        private void EditNumber_Load(object sender, EventArgs e) {
            ApplyTheme();
        }
        public void ApplyTheme() {
            this.BackColor = Properties.Settings.Default.THM_COL_Editor;


            this.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            Editor.BackColor = Properties.Settings.Default.THM_COL_Editor;
            Editor.BorderColor = Color.Transparent;
            Editor.SelectedBorderColor = Color.Transparent;
            Editor.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;


            SelectedColor = Properties.Settings.Default.THM_COL_SelectedColor;
        }
        protected override void OnPaint(PaintEventArgs e) {
            using (SolidBrush BrdBr = new SolidBrush(selectedColor)) {
                using (Pen BrdPn = new Pen(BrdBr)) {
                    e.Graphics.DrawRectangle(BrdPn, new Rectangle(0, 0, Width - 1, Height - 1));
                }
            }
            base.OnPaint(e);
        }
        private void BindParentEvents() {
            if (lstControl == null) { return; }
            lstControl.MouseClick += Ctrl_MouseClick;
            lstControl.MouseWheel += LstControl_MouseWheel;
            lstControl.MouseDown += LstControl_MouseDown;
            lstControl.LostFocus += LstControl_LostFocus;
            lstControl.Resize += LstControl_Resize;
        }
        private void UnbindParentEvents() {
            if (lstControl == null) { return; }
            lstControl.MouseWheel -= LstControl_MouseWheel;
            lstControl.MouseClick -= Ctrl_MouseClick;
            lstControl.MouseDown -= LstControl_MouseDown;
            lstControl.LostFocus -= LstControl_LostFocus;
            lstControl.Resize -= LstControl_Resize;
            if (ArrowKeyPress != null) {
                Delegate[] clientList = ArrowKeyPress.GetInvocationList();
                foreach (var d in clientList) {
                    ArrowKeyPress -= (d as ArrowKeyPressedHandler);
                }
            }
        }
        private void LstControl_MouseDown(object? sender, MouseEventArgs e) {
            PushValue();
        }
        private void LstControl_LostFocus(object? sender, EventArgs e) {

        }
        private void LstControl_MouseWheel(object? sender, MouseEventArgs e) {
            if (e.Delta != 0) {
                PushValue();
            }
        }
        private void LstControl_Resize(object? sender, EventArgs e) {
            PushValue();
        }
        private void Ctrl_MouseClick(object? sender, MouseEventArgs e) {
            PushValue();
        }
        public void PushValue() {
            if (ListItem == null) { return; }
            try {
                ListItem[Column].Text = Editor.Value.ToString() ?? "0";
            }
            catch { }
            UnbindParentEvents();
            if (lstControl != null) {
                this.LostFocus -= EditValue_LostFocus;
                lstControl.Controls.Remove(this);
            }
            else {
                if (this.Parent != null) {
                    this.LostFocus -= EditValue_LostFocus;
                    Parent.Controls.Remove(this);
                }
            }
        }
    }
}
