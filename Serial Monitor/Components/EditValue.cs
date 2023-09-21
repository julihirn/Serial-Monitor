using Handlers;
using ODModules;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataType = Serial_Monitor.Classes.Step_Programs.DataType;

namespace Serial_Monitor.Components {
    public partial class EditValue : UserControl, Interfaces.ITheme{
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
        int Index = 0;
        object? Parameter = null;
        Rectangle ParentBounds = Rectangle.Empty;
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
            this.Size = ObjectBounds.Size;
            this.Location = ObjectBounds.Location;
            //this.IgnoreChanges = IgnoreChanges;
            this.Focus();
            Initalise(StepExe, InputValue, ListCtrl, Item);
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
            flatComboBox1.BackColor = Properties.Settings.Default.THM_COL_Editor;

            this.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox2.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox3.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            numericTextbox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            flatComboBox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            numericTextbox1.BorderColor = Color.Transparent;
            numericTextbox1.SelectedBorderColor = Color.Transparent;
        }

        private void EditValue_Leave(object sender, EventArgs e) {
            PushValue();
            
        }
        private void PushValue() {
            if (ListItem == null) { return; }
            if (ListItem.SubItems.Count < Index) { return; }
            if (AllowEditChanges == false) { return; }
            switch (Type) {
                case DataType.Text:
                    ListItem[Index].Text = TempString1;
                    textBox1.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.Number:
                    ListItem[Index].Text = numericTextbox1.Value.ToString() ?? "0";
                    numericTextbox1.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.Byte:
                    ListItem[Index].Text = MathHandler.HexadecimalToDecimal(numericTextbox1.Value.ToString() ?? "0", BinaryFormatFlags.Length8Bit).ToString(); //;
                    break;
                case DataType.DualString:
                    ListItem[Index].Text = textBox2.Text + "=" + textBox3.Text;
                    break;
                case DataType.CursorLocation:

                    break;
                case DataType.EnumVal:
                    ListItem[Index].Text = flatComboBox1.Text;
                    break;

                default:
                    break;
            }
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PushValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
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
            public event LeftButtonDown ?MouseDown;

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
    }
}
