using ODModules;
using Serial_Monitor.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Components.EditValue;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Serial_Monitor.Components {
    public partial class EditVariable : UserControl, Interfaces.ITheme {
        public event ArrowKeyPressedHandler? ArrowKeyPress;
        //private static MyFilter? mf = null;
        ODModules.ListControl? lstControl = null;
        ListItem? ListItem = null;
        ProgramObject? SelectedProgram = null;
        ProgramDataSet Set = ProgramDataSet.GlobalVariable;
        bool UseName = false;
        int Index = -1;
        int Column = -1;
        Rectangle ParentBounds = Rectangle.Empty;
        public EditVariable(ODModules.ListControl? List, ListItem? Item, int Column, ProgramObject? Program, ProgramDataSet DataSet, int Index, bool UseName, Rectangle ObjectBounds, Rectangle ParentBounds) {
            InitializeComponent();
            this.Size = ObjectBounds.Size;
            this.Location = ObjectBounds.Location;
            this.ParentBounds = ParentBounds;
            ListItem = Item;
            lstControl = List;
            Set = DataSet;
            this.UseName = UseName;
            if (Index < 0) { return; }
            if (Program == null) { return; }
            SelectedProgram = Program;
            this.Index = Index;
            this.Column = Column;
            try {
                if (Set == ProgramDataSet.GlobalVariable) {
                    if (UseName == true) {
                        textBox1.Text = Program.GlobalVariables[Index].Name;
                    }
                    else {
                        textBox1.Text = Program.GlobalVariables[Index].Value;
                    }
                }
                else if (Set == ProgramDataSet.Variable) {
                    if (UseName == true) {
                        textBox1.Text = Program.Variables[Index].Name;
                    }
                    else {
                        textBox1.Text = Program.Variables[Index].Value;
                    }
                }
                else if (Set == ProgramDataSet.Array) {
                    textBox1.Text = Program.Array[Index];
                }
            }
            catch { }
            ApplyTheme();
            AdjustUI();
            BindParentEvents();
            this.LostFocus += EditValue_LostFocus;
        }

        private void EditValue_LostFocus(object? sender, EventArgs e) {
            // PushValue();
        }

        private void AdjustUI() {
            textBox1.AutoSize = false;
        }
        Color selectedColor = Color.Blue;
        public Color SelectedColor {
            get { return selectedColor; }
            set { selectedColor = value; Invalidate(); }
        }
        private void EditVariable_Resize(object sender, EventArgs e) {
            Invalidate();
        }
        public void ApplyTheme() {
            this.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox1.BackColor = Properties.Settings.Default.THM_COL_Editor;

            this.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;


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

        private void EditVariable_Load(object sender, EventArgs e) {
            ApplyTheme();
        }
        private class MyFilter : IMessageFilter {

            public delegate void LeftButtonDown();
            public event LeftButtonDown? MouseDown;

            //public delegate void KeyPressUp(IntPtr target);
            //public event KeyPressUp KeyUp;
            private const int WM_KEYDWN = 0x100;
            private const int WM_KEYUP = 0x101;
            private const int WM_LBUTTONDOWN = 0x201;

            bool IMessageFilter.PreFilterMessage(ref Message m) {
                switch (m.Msg) {
                    // raise our KeyUp() event whenever a key is released in our app
                    case WM_KEYDWN:
                        //if (KeyUp != null) {
                        //    KeyUp(m.HWnd);
                        //}
                        break;

                    // raise our MouseDown() event whenever the mouse is left clicked somewhere in our app
                    case WM_LBUTTONDOWN:
                        if (MouseDown != null) {
                            MouseDown();
                        }
                        break;
                    case 96:
                        if (MouseDown != null) {
                            MouseDown();
                        }
                        break;
                    case 161:
                        if (MouseDown != null) {
                            MouseDown();
                        }
                        break;
                    case 15:
                        break;
                    default:
                        return false;

                }
                return false;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
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
        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PushValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        public void PushValue() {
            if (ListItem == null) { return; }
            if (SelectedProgram == null) { return; }
            try {
                if (Set == ProgramDataSet.GlobalVariable) {
                    if (UseName == true) {
                        // SelectedProgram.GlobalVariables[Index].Name = textBox1.Text;
                    }
                    else {
                        SelectedProgram.GlobalVariables[Index].Value = textBox1.Text;
                    }
                }
                else if (Set == ProgramDataSet.Variable) {
                    if (UseName == true) {
                        //SelectedProgram.Variables[Index].Name = textBox1.Text;
                    }
                    else {
                        SelectedProgram.Variables[Index].Value = textBox1.Text;
                    }
                }
                else if (Set == ProgramDataSet.Array) {
                    SelectedProgram.Array[Index] = textBox1.Text;
                }
                ListItem[Column].Text = textBox1.Text;
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
    public enum ProgramDataSet {
        GlobalVariable = 0x00,
        Variable = 0x01,
        Array = 0x02
    }
}
