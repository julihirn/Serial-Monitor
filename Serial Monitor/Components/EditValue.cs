using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataType = Serial_Monitor.Classes.Step_Programs.DataType;

namespace Serial_Monitor.Components {
    public partial class EditValue : UserControl, Interfaces.ITheme {
        public event ArrowKeyPressedHandler? ArrowKeyPress;
        public delegate void ArrowKeyPressedHandler(bool IsUp);

        private bool m_MouseEventSubscribed = false;
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);

            var form = this.ParentForm;
            if (form != null && form is IMouseHandler && !m_MouseEventSubscribed) {
                m_MouseEventSubscribed = true;
                ((IMouseHandler)form).MouseEvent += (s, a) => {
                    if (this.ContainsFocus && !this.ClientRectangle.Contains(PointToClient(a.Position))) {
                        // form.SelectNextControl(this, true, true, false, true);
                        PushValue();
                    }
                };
            }
        }

        private static MyFilter? mf = null;
        public EditValue() {

            InitializeComponent();


            SetStyle(ControlStyles.ContainerControl, true);
            this.LostFocus += EditValue_LostFocus;
        }
        Color selectedColor = Color.Blue;
        public Color SelectedColor {
            get { return selectedColor; }
            set { selectedColor = value; Invalidate(); }
        }

        private void mf_MouseDown() {
            if (this.Visible) {
                Rectangle ThisRectange = ParentBounds;// RectangleToScreen(this.);
                Debug.Print(ThisRectange.ToString() + " " + Cursor.Position.ToString());
                if (ThisRectange.Contains(Cursor.Position)) {
                    Debug.Print("Yes");
                }
                else {
                    PushValue();
                }
            }
        }
        private void EditValue_LostFocus(object? sender, EventArgs e) {
            PushValue();
        }

        DataType Type = DataType.Null;
        ODModules.ListControl? lstControl = null;
        ListItem? ListItem = null;
        int Column = 0;
        int Index = 0;
        object? Parameter = null;
        Rectangle ParentBounds = Rectangle.Empty;
        object? LinkedControl = null;
        bool UseLinked = false;
        DataSelection Selection = DataSelection.ModbusDataCoils;
        public EditValue(StepEnumerations.StepExecutable StepExe, string InputValue, ODModules.ListControl ListCtrl, ListItem Item, int Index, object? Parameter, bool IgnoreChanges, Rectangle ObjectBounds, Rectangle ParentBounds) {
            InitializeComponent();
            this.OnClick(new EventArgs());
            //if (mf == null) {
            //    mf = new MyFilter();
            //    Application.AddMessageFilter(mf);
            //    mf.MouseDown += new MyFilter.LeftButtonDown(mf_MouseDown);
            //}
            this.lstControl = ListCtrl;
            this.Parameter = Parameter;
            this.ParentBounds = ParentBounds;
            this.Column = Index;
            foreach (object Ctrl in this.Controls) {
                if (Ctrl.GetType() == typeof(NumericTextbox)) {
                    NumericTextbox txt = (NumericTextbox)Ctrl;
                    txt.Height = textBox1.Height;
                }
                else if (Ctrl.GetType() == typeof(SplitContainer)) {
                    SplitContainer txt = (SplitContainer)Ctrl;
                    txt.Height = textBox1.Height;
                }
            }
            this.Size = ObjectBounds.Size;
            this.Location = ObjectBounds.Location;
            //this.IgnoreChanges = IgnoreChanges;
            BindParentEvents();
            this.Focus();
            Initalise(StepExe, InputValue, ListCtrl, Item);
        }
        public EditValue(string InputValue, ODModules.ListControl ListCtrl, ListItem Item, int Column, int Index, object? Parameter, object LinkedObject, Rectangle ObjectBounds, Rectangle ParentBounds, DataSelection Dsel = DataSelection.ModbusDataCoils) {
            InitializeComponent();
            this.OnClick(new EventArgs());
            //if (mf == null) {
            //    mf = new MyFilter();
            //    Application.AddMessageFilter(mf);
            //    mf.MouseDown += new MyFilter.LeftButtonDown(mf_MouseDown);
            //}
            UseLinked = true;
            Selection = Dsel;
            this.lstControl = ListCtrl;
            this.Parameter = Parameter;
            this.ParentBounds = ParentBounds;
            this.LinkedControl = LinkedObject;
            this.Column = Column;
            this.Index = Index;
            foreach (object Ctrl in this.Controls) {
                if (Ctrl.GetType() == typeof(NumericTextbox)) {
                    NumericTextbox txt = (NumericTextbox)Ctrl;
                    txt.Height = textBox1.Height;
                }
                else if (Ctrl.GetType() == typeof(SplitContainer)) {
                    SplitContainer txt = (SplitContainer)Ctrl;
                    txt.Height = textBox1.Height;
                }
            }
            BindParentEvents();
            this.Size = ObjectBounds.Size;
            this.Location = ObjectBounds.Location;
            //this.IgnoreChanges = IgnoreChanges;
            this.Focus();
            Initalise(StepEnumerations.StepExecutable.Label, InputValue, ListCtrl, Item);
        }
        private void BindParentEvents() {
            if (lstControl == null) { return; }
            lstControl.MouseClick += Ctrl_MouseClick;
            lstControl.MouseWheel += LstControl_MouseWheel;
            lstControl.MouseDown += LstControl_MouseDown;
            lstControl.LostFocus += LstControl_LostFocus;
            lstControl.Resize += LstControl_Resize;
        }

        private void LstControl_Resize(object? sender, EventArgs e) {
            PushValue();
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
        private void LstControl_LostFocus(object? sender, EventArgs e) {
          
        }

        private void LstControl_MouseDown(object? sender, MouseEventArgs e) {
            PushValue();
        }

        private void LstControl_MouseWheel(object? sender, MouseEventArgs e) {
            if (e.Delta != 0) {
                PushValue();
            }
        }

    
        private void Ctrl_MouseClick(object? sender, MouseEventArgs e) {
            PushValue();
        }

        bool AllowEditChanges = false;

        private void Initalise(StepEnumerations.StepExecutable StepExe, string InputValue, ODModules.ListControl ListCtrl, ListItem Item) {
            Type = Classes.ProgramManager.StepExeutableToDataType(StepExe);
            ListItem = Item;
            switch (Type) {
                case DataType.Text:
                    textBox1.Text = InputValue;
                    textBox1.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.Number:
                    numericTextbox1.Value = InputValue;
                    numericTextbox1.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.Byte:
                    numericTextbox1.Value = InputValue;
                    numericTextbox1.Base = NumericTextbox.NumberBase.Base16;
                    numericTextbox1.RangeLimited = true;
                    numericTextbox1.Maximum = new Handlers.NumericalString(255);
                    numericTextbox1.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.DualString:
                    AssignDual(InputValue, '=');
                    splitContainer1.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.CursorLocation:

                    break;
                case DataType.EnumVal:
                    flatComboBox1.Text = InputValue;
                    flatComboBox1.Show();
                    AllowEditChanges = true;
                    break;

                default:
                    break;
            }
        }
        private void AssignDual(string Value, char Spiltter = '=') {
            string ArgumentLeft = StringHandler.SpiltString(Value, Spiltter, 0);
            string ArgumentRight = "";
            if (Value.Contains(Spiltter)) {
                ArgumentRight = StringHandler.SpiltAndCombineAfter(Value, Spiltter, 1).Value[1];
            }
            textBox2.Text = ArgumentLeft;
            textBox3.Text = ArgumentRight;
        }
        private void EditValue_Load(object sender, EventArgs e) {
            ApplyTheme();
        }
        public void ApplyTheme() {
            this.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox2.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox3.BackColor = Properties.Settings.Default.THM_COL_Editor;
            numericTextbox1.BackColor = Properties.Settings.Default.THM_COL_Editor;

            this.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox2.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox3.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            numericTextbox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            flatComboBox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            flatComboBox1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            numericTextbox1.BorderColor = Color.Transparent;
            numericTextbox1.SelectedBorderColor = Color.Transparent;
            SelectedColor = Properties.Settings.Default.THM_COL_SelectedColor;
            splitContainer1.BackColor = Properties.Settings.Default.THM_COL_SelectedColor;
            splitContainer1.Panel1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            splitContainer1.Panel2.BackColor = Properties.Settings.Default.THM_COL_Editor;
        }

        private void EditValue_Leave(object sender, EventArgs e) {
            PushValue();

        }
        public void PushValue() {
            if (ListItem == null) { return; }
            if (ListItem.SubItems.Count < Column) { return; }
            if (AllowEditChanges == false) { return; }
            switch (Type) {
                case DataType.Text:
                    ListItem[Column].Text = TempString1;
                    PushValueToControl(TempString1);
                    textBox1.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.Number:
                    ListItem[Column].Text = numericTextbox1.Value.ToString() ?? "0";
                    PushValueToControl(numericTextbox1.Value.ToString() ?? "0");
                    numericTextbox1.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.Byte:
                    ListItem[Column].Text = MathHandler.HexadecimalToDecimal(numericTextbox1.Value.ToString() ?? "0", BinaryFormatFlags.Length8Bit).ToString(); //;
                    break;
                case DataType.DualString:
                    ListItem[Column].Text = textBox2.Text + "=" + textBox3.Text;
                    break;
                case DataType.CursorLocation:

                    break;
                case DataType.EnumVal:
                    ListItem[Column].Text = flatComboBox1.Text;
                    break;

                default:
                    break;
            }
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
        private void PushValueToControl(object Data) {
            if (UseLinked == false) { return; }
            if (LinkedControl == null) { return; }
            if (LinkedControl.GetType() == typeof(ModbusCoil)) {
                ModbusCoil coil = (ModbusCoil)LinkedControl;
                coil.Name = Data.ToString() ?? "";
                SystemManager.RegisterNameChanged(coil, Index, Selection);
            }
            else if (LinkedControl.GetType() == typeof(ModbusRegister)) {
                ModbusRegister coil = (ModbusRegister)LinkedControl;
                coil.Name = Data.ToString() ?? "";
                SystemManager.RegisterNameChanged(coil, Index, Selection);
            }

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PushValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Down) {
                PushValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
                ArrowKeyPress?.Invoke(false);
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PushValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PushValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void flatComboBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PushValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void EditValue_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PushValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void EditValue_Validated(object sender, EventArgs e) {
            PushValue();
        }

        private void numericTextbox1_Leave(object sender, EventArgs e) {
            PushValue();
        }

        private void textBox1_Leave(object sender, EventArgs e) {
            PushValue();
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
        string TempString1 = "";
        private void textBox1_TextChanged(object sender, EventArgs e) {
            TempString1 = textBox1.Text;
        }

        protected override void OnPaint(PaintEventArgs e) {
            using(SolidBrush BrdBr = new SolidBrush(selectedColor)) {
                using(Pen BrdPn = new Pen(BrdBr)) {
                    e.Graphics.DrawRectangle(BrdPn,new Rectangle(0,0,Width-1,Height-1));
                }
            }
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e) {
            Invalidate();
            base.OnResize(e);
        }
    }
}
