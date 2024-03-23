using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.Classes.Structures;
using Serial_Monitor.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Serial_Monitor.Classes.Enums.ControlEnums;
using DataType = Serial_Monitor.Classes.Step_Programs.DataType;

namespace Serial_Monitor.Components {
    public partial class EditValue : UserControl, Interfaces.ITheme {
        public event ArrowKeyPressedHandler? ArrowKeyPress;
        public delegate void ArrowKeyPressedHandler(ArrowKey Direction);

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

        //private static MyFilter? mf = null;
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
            AdjustUI();

            //if (mf == null) {
            //    mf = new MyFilter();
            //    Application.AddMessageFilter(mf);
            //    mf.MouseDown += new MyFilter.LeftButtonDown(mf_MouseDown);
            //}
            this.lstControl = ListCtrl;
            this.Parameter = Parameter;
            this.ParentBounds = ParentBounds;
            this.Column = Index;
            //foreach (object Ctrl in this.Controls) {
            //    if (Ctrl.GetType() == typeof(NumericTextbox)) {
            //        NumericTextbox txt = (NumericTextbox)Ctrl;
            //        txt.Height = textBox1.Height;
            //    }
            //    else if (Ctrl.GetType() == typeof(SplitContainer)) {
            //        SplitContainer txt = (SplitContainer)Ctrl;
            //        txt.Height = textBox1.Height;
            //    }
            //}
            this.Size = ObjectBounds.Size;
            this.Location = ObjectBounds.Location;
            //this.IgnoreChanges = IgnoreChanges;
            BindParentEvents();
            this.Focus();
            Initalise(StepExe, InputValue, ListCtrl, Item);
            ApplyTheme();
        }
        public EditValue(string InputValue, ODModules.ListControl ListCtrl, ListItem Item, int Column, int Index, object? Parameter, object LinkedObject, Rectangle ObjectBounds, Rectangle ParentBounds, DataSelection Dsel = DataSelection.ModbusDataCoils) {
            InitializeComponent();
            AdjustUI();
            this.OnClick(new EventArgs());
            UseLinked = true;
            Selection = Dsel;
            this.lstControl = ListCtrl;
            this.Parameter = Parameter;
            this.ParentBounds = ParentBounds;
            this.LinkedControl = LinkedObject;
            this.Column = Column;
            this.Index = Index;
            BindParentEvents();
            this.Size = ObjectBounds.Size;
            this.Location = ObjectBounds.Location;
            this.Focus();
            Initalise(StepEnumerations.StepExecutable.Label, InputValue, ListCtrl, Item);
            ApplyTheme();
        }
        public EditValue(string InputValue, ODModules.ListControl ListCtrl, ListItem Item, int Column, int Index, object LinkedObject, Rectangle ObjectBounds, Rectangle ParentBounds, DataSelection Dsel = DataSelection.ModbusDataCoils) {
            InitializeComponent();
            AdjustUI();
            this.OnClick(new EventArgs());
            UseLinked = true;
            Selection = Dsel;
            this.lstControl = ListCtrl;
            //this.Parameter = Parameter;
            this.numericTextbox1.ArrowKeysControlNumber = false;
            this.ParentBounds = ParentBounds;
            this.LinkedControl = LinkedObject;
            this.Column = Column;
            this.Index = Index;
            BindParentEvents();
            this.Size = ObjectBounds.Size;
            this.Location = ObjectBounds.Location;
            this.Focus();
            InitaliseWithType(DataType.ModbusCustom, InputValue, ListCtrl, Item);
            ApplyTheme();
        }
        private void BindParentEvents() {
            if (lstControl == null) { return; }
            lstControl.MouseClick += Ctrl_MouseClick;
            lstControl.MouseWheel += LstControl_MouseWheel;
            lstControl.MouseDown += LstControl_MouseDown;
            lstControl.LostFocus += LstControl_LostFocus;
            lstControl.Resize += LstControl_Resize;
        }
        private void AdjustUI() {
            textBox1.AutoSize = false;
            textBox2.AutoSize = false;
            textBox3.AutoSize = false;
            spPnlPoint.Width = DesignerSetup.ScaleInteger(spPnlPoint.Width);
            btnGrabPoint.Width = DesignerSetup.ScaleInteger(btnGrabPoint.Width);
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
            Step = StepExe;
            InitaliseWithType(Classes.ProgramManager.StepExecutableToDataType(StepExe), InputValue, ListCtrl, Item);
        }
        bool isPositionOffset = false;
        bool IsPositionOffset {
            get { return isPositionOffset; }
            set { isPositionOffset = value; }
        }
        StepEnumerations.StepExecutable Step = StepEnumerations.StepExecutable.NoOperation;
        private void InitaliseWithType(DataType StepExe, string InputValue, ODModules.ListControl ListCtrl, ListItem Item) {
            textBox1.AutoSize = false;
            textBox2.AutoSize = false;
            textBox3.AutoSize = false;
            Type = StepExe;
            ListItem = Item;
            numericTextbox1.NumberTextAlign = NumericTextbox.TextAlign.Left;
            switch (Type) {
                case DataType.Text:
                    textBox1.Text = InputValue;
                    pnlText.Dock = DockStyle.Fill;
                    pnlText.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.Number:
                    if (InputValue.Length > 0) {
                        numericTextbox1.Value = InputValue;
                    }
                    else { numericTextbox1.Value = 0; }
                    numericTextbox1.Show();
                    pnlNumber.Dock = DockStyle.Fill;
                    pnlNumber.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.Byte:
                    if (InputValue.Length > 0) {
                        numericTextbox1.Value = InputValue;
                    }
                    else { numericTextbox1.Value = 0; }
                    numericTextbox1.Base = NumericTextbox.NumberBase.Base16;
                    numericTextbox1.RangeLimited = true;
                    numericTextbox1.Maximum = new Handlers.NumericalString(255);
                    numericTextbox1.Show();
                    pnlNumber.Dock = DockStyle.Fill;
                    pnlNumber.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.DualString:
                    AssignDual(InputValue, '=');
                    pnlDualText.Dock = DockStyle.Fill;
                    pnlDualText.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.CursorLocation:
                    if (Step == StepEnumerations.StepExecutable.MousePosition) {
                        IsPositionOffset = true;
                    }
                    AssignDual(InputValue, ',', Type);
                    pnlPoint.Dock = DockStyle.Fill;
                    pnlPoint.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.EnumVal:
                    flatComboBox1.Text = InputValue;
                    flatComboBox1.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.ModbusCustom:
                    numericTextbox1.NumberTextAlign = NumericTextbox.TextAlign.Right;
                    SetupModbusRegisterLinkage(InputValue, ListCtrl, Item);

                    break;
                case DataType.WaitUntilRX:
                    AssignWaitUnitRX(InputValue);
                    pnlWaitUntilReceived.Dock = DockStyle.Fill;
                    pnlWaitUntilReceived.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.ReplaceText:
                    AssignReplace(ProgramManager.ReplaceAndAssign(InputValue));
                    pnlReplaceText.Dock = DockStyle.Fill;
                    pnlReplaceText.Show();
                    AllowEditChanges = true;
                    break;
                default:
                    break;
            }
        }
        private void SetupModbusRegisterLinkage(string InputValue, ODModules.ListControl ListCtrl, ListItem Item) {
            numericTextbox1.RangeLimited = true;
            HasSent = false;
            if (LinkedControl != null) {
                if (LinkedControl.GetType() == typeof(ModbusRegister)) {
                    ModbusRegister Reg = (ModbusRegister)LinkedControl;
                    numericTextbox1.NumericalFormat = NumericTextbox.NumberFormat.Decimal;
                    if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Binary) {
                        numericTextbox1.Base = NumericTextbox.NumberBase.Base2;
                        DualNumericalString DualNum = Formatters.GetBounds(Reg.Size, Reg.Signed);
                        numericTextbox1.Minimum = DualNum.A;
                        numericTextbox1.Maximum = DualNum.B;
                        InputValue = InputValue.TrimStart('0');
                    }
                    else if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Octal) {
                        numericTextbox1.Base = NumericTextbox.NumberBase.Base8;
                        DualNumericalString DualNum = Formatters.GetBounds(Reg.Size, Reg.Signed);
                        numericTextbox1.Minimum = DualNum.A;
                        numericTextbox1.Maximum = DualNum.B;
                        InputValue = InputValue.TrimStart('0');
                    }
                    else if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Decimal) {
                        numericTextbox1.Base = NumericTextbox.NumberBase.Base10;
                        numericTextbox1.AllowFractionals = false;
                        numericTextbox1.AllowNegatives = Reg.Signed;
                        DualNumericalString DualNum = Formatters.GetBounds(Reg.Size, Reg.Signed);
                        numericTextbox1.Minimum = DualNum.A;
                        numericTextbox1.Maximum = DualNum.B;
                        numericTextbox1.Unit = Reg.Unit;
                        numericTextbox1.Prefix = EnumManager.GetPrefix(Reg);
                    }
                    else if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Hexadecimal) {
                        numericTextbox1.Base = NumericTextbox.NumberBase.Base16;
                        DualNumericalString DualNum = Formatters.GetBounds(Reg.Size, Reg.Signed);
                        numericTextbox1.Minimum = DualNum.A;
                        numericTextbox1.Maximum = DualNum.B;
                        InputValue = InputValue.TrimStart('0');
                    }
                    else if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Double) {
                        numericTextbox1.AllowFractionals = true;
                        numericTextbox1.AllowNegatives = true;
                        numericTextbox1.Minimum = MathHandler.EvaluateExpression("-1.7976931348623157*(10^(308))", null);
                        numericTextbox1.Maximum = MathHandler.EvaluateExpression("1.7976931348623157*(10^(308))", null);
                        numericTextbox1.NumericalFormat = NumericTextbox.NumberFormat.Scientific;
                        numericTextbox1.Unit = Reg.Unit;
                        numericTextbox1.Prefix = EnumManager.GetPrefix(Reg);

                        if (InputValue.ToLower() == "nan") {
                            InputValue = "0";
                        }
                        else if (InputValue.ToLower() == "infinity") {
                            InputValue = double.MaxValue.ToString();
                        }
                        else if (InputValue.ToLower() == "-infinity") {
                            InputValue = double.MinValue.ToString();
                        }
                        if (InputValue.Contains('E')) {
                            InputValue = MathHandler.EvaluateExpression(InputValue.Replace("E", "*(10^(") + "))", null).ToString();
                        }
                    }
                    else if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Float) {
                        numericTextbox1.AllowFractionals = true;
                        numericTextbox1.AllowNegatives = true;
                        numericTextbox1.Minimum = MathHandler.EvaluateExpression("-3.4028235*(10^(38))", null);
                        numericTextbox1.Maximum = MathHandler.EvaluateExpression("3.4028235*(10^(38))", null);
                        numericTextbox1.NumericalFormat = NumericTextbox.NumberFormat.Scientific;
                        if (InputValue.ToLower() == "nan") {
                            InputValue = "0";
                        }
                        else if (InputValue.ToLower() == "infinity") {
                            InputValue = float.MaxValue.ToString();
                        }
                        else if (InputValue.ToLower() == "-infinity") {
                            InputValue = float.MinValue.ToString();
                        }
                        if (InputValue.Contains('E')) {
                            InputValue = MathHandler.EvaluateExpression(InputValue.Replace("E", "*(10^(") + "))", null).ToString();
                        }
                        numericTextbox1.Unit = Reg.Unit;
                        numericTextbox1.Prefix = EnumManager.GetPrefix(Reg);

                    }
                    else if (Reg.Format == Classes.Enums.ModbusEnums.DataFormat.Char) {

                    }
                }
            }

            if (InputValue.Length > 0) {
                numericTextbox1.Value = InputValue;
            }
            else { numericTextbox1.Value = 0; }
            numericTextbox1.Show();
            pnlNumber.Dock = DockStyle.Fill;
            pnlNumber.Show();
            AllowEditChanges = true;
        }
        private void AssignDual(string Value, char Spiltter = '=', DataType Set = DataType.DualString) {
            string ArgumentLeft = StringHandler.SpiltString(Value, Spiltter, 0);
            string ArgumentRight = "";
            if (Value.Contains(Spiltter)) {
                ArgumentRight = StringHandler.SpiltAndCombineAfter(Value, Spiltter, 1).Value[1];
            }
            if (Set == DataType.DualString) {
                textBox2.Text = ArgumentLeft;
                textBox3.Text = ArgumentRight;
            }
            else if (Set == DataType.CursorLocation) {
                ArgumentLeft = ArgumentLeft.Replace(" ", "");
                ArgumentRight = ArgumentRight.Replace(" ", "");
                if (ArgumentLeft.Length > 0) {
                    numericTextbox2.Value = ArgumentLeft;
                }
                else {
                    numericTextbox2.Value = 0;
                }
                if (ArgumentRight.Length > 0) {
                    numericTextbox3.Value = ArgumentRight;
                }
                else {
                    numericTextbox3.Value = 0;
                }
            }
        }
        private void AssignWaitUnitRX(string Value) {
            STR_MVSSF Arguments = StringHandler.SpiltAndCombineAfter(Value, ',', 3);
            if (Arguments.Count < 4) { return; }
            string Channel = ProgramManager.StripAwayTag("Channel = ", Arguments.Value[0]);
            string TimeOut = ProgramManager.StripAwayTag("TimeOut = ", Arguments.Value[1]);
            string Contains = Arguments.Value[2];
            string ValueExpress = ProgramManager.StripAwayTag("Value = ", Arguments.Value[3]);
            textBox4.Text = Channel;
            textBox5.Text = ValueExpress;
            numericTextbox4.Value = TimeOut;
        }
        private void AssignReplace(ReplaceTextObject Value) {
            textBox10.Text = Value.Output;
            textBox11.Text = Value.Input;
            textBox12.Text = Value.TextToReplace;
            textBox13.Text = Value.ReplaceWith;
        }
        private void EditValue_Load(object sender, EventArgs e) {
            ApplyTheme();
        }
        public void ApplyTheme() {
            this.BackColor = Properties.Settings.Default.THM_COL_Editor;
            pnlPoint.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox2.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox3.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox4.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox5.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox10.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox11.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox12.BackColor = Properties.Settings.Default.THM_COL_Editor;
            textBox13.BackColor = Properties.Settings.Default.THM_COL_Editor;

            lblX.BackColor = Properties.Settings.Default.THM_COL_Editor;
            lblX.ForeColor = Properties.Settings.Default.THM_COL_SecondaryForeColor;
            lblY.BackColor = Properties.Settings.Default.THM_COL_Editor;
            lblY.ForeColor = Properties.Settings.Default.THM_COL_SecondaryForeColor;

            lblChannel.BackColor = Properties.Settings.Default.THM_COL_Editor;
            lblChannel.ForeColor = Properties.Settings.Default.THM_COL_SecondaryForeColor;

            lblTimeOut.BackColor = Properties.Settings.Default.THM_COL_Editor;
            lblTimeOut.ForeColor = Properties.Settings.Default.THM_COL_SecondaryForeColor;

            lblWaitFor.BackColor = Properties.Settings.Default.THM_COL_Editor;
            lblWaitFor.ForeColor = Properties.Settings.Default.THM_COL_SecondaryForeColor;

            numericTextbox1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            numericTextbox1.BorderColor = Color.Transparent;
            numericTextbox1.SelectedBorderColor = Color.Transparent;
            numericTextbox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            numericTextbox2.BackColor = Properties.Settings.Default.THM_COL_Editor;
            numericTextbox2.BorderColor = Color.Transparent;
            numericTextbox2.SelectedBorderColor = Color.Transparent;
            numericTextbox2.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            numericTextbox3.BackColor = Properties.Settings.Default.THM_COL_Editor;
            numericTextbox3.BorderColor = Color.Transparent;
            numericTextbox3.SelectedBorderColor = Color.Transparent;
            numericTextbox3.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            numericTextbox4.BackColor = Properties.Settings.Default.THM_COL_Editor;
            numericTextbox4.BorderColor = Color.Transparent;
            numericTextbox4.SelectedBorderColor = Color.Transparent;
            numericTextbox4.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            this.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox2.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox3.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox4.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox5.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox10.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox11.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox12.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            textBox13.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            flatComboBox1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            flatComboBox1.BackColor = Properties.Settings.Default.THM_COL_Editor;


            SelectedColor = Properties.Settings.Default.THM_COL_SelectedColor;
            spPnlPoint.BackColor = Properties.Settings.Default.THM_COL_SelectedColor;
            spPnlPoint.Panel1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            spPnlPoint.Panel2.BackColor = Properties.Settings.Default.THM_COL_Editor;
            pnlDualText.BackColor = Properties.Settings.Default.THM_COL_SelectedColor;
            pnlDualText.Panel1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            pnlDualText.Panel2.BackColor = Properties.Settings.Default.THM_COL_Editor;

            pnlWaitUntilReceived.BackColor = Properties.Settings.Default.THM_COL_SelectedColor;
            pnlWaitUntilReceived.Panel1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            pnlWaitUntilReceived.Panel2.BackColor = Properties.Settings.Default.THM_COL_Editor;

            pnlSubWaitUnitRX.BackColor = Properties.Settings.Default.THM_COL_SelectedColor;
            pnlSubWaitUnitRX.Panel1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            pnlSubWaitUnitRX.Panel2.BackColor = Properties.Settings.Default.THM_COL_Editor;

            pnlReplaceText.BackColor = Properties.Settings.Default.THM_COL_SelectedColor;
            pnlReplaceText.Panel1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            pnlReplaceText.Panel2.BackColor = Properties.Settings.Default.THM_COL_Editor;

            splitContainer4.BackColor = Properties.Settings.Default.THM_COL_SelectedColor;
            splitContainer4.Panel1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            splitContainer4.Panel2.BackColor = Properties.Settings.Default.THM_COL_Editor;

            splitContainer3.BackColor = Properties.Settings.Default.THM_COL_SelectedColor;
            splitContainer3.Panel1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            splitContainer3.Panel2.BackColor = Properties.Settings.Default.THM_COL_Editor;

            btnGrabPoint.BackColorNorth = Properties.Settings.Default.THM_COL_SelectedColor;
            btnGrabPoint.BackColorSouth = Properties.Settings.Default.THM_COL_SelectedColor;
            btnGrabPoint.BorderColorNorth = Properties.Settings.Default.THM_COL_SelectedColor;
            btnGrabPoint.BorderColorSouth = Properties.Settings.Default.THM_COL_SelectedColor;

            btnGrabPoint.BorderColorHoverNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            btnGrabPoint.BorderColorHoverSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            btnGrabPoint.BackColorHoverNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            btnGrabPoint.BackColorHoverSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            btnGrabPoint.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
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
                    TempString1 = textBox1.Text;
                    ListItem[Column].Text = TempString1;
                    PushNameToControl(TempString1);
                    textBox1.Show();
                    AllowEditChanges = true;
                    break;
                case DataType.Number:
                    ListItem[Column].Text = numericTextbox1.Value.ToString() ?? "0";
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
                    ListItem[Column].Text = numericTextbox2.Value.ToString() + ", " + numericTextbox3.Value.ToString();
                    break;
                case DataType.EnumVal:
                    ListItem[Column].Text = flatComboBox1.Text;
                    break;
                case DataType.ModbusCustom:

                    //ListItem[Column].Text = flatComboBox1.Text;
                    PushValueToControl(numericTextbox1.Value.ToString() ?? "0");
                    break;
                case DataType.WaitUntilRX:
                    ListItem[Column].Text = "Channel = " + textBox4.Text + ",TimeOut = " + numericTextbox4.Value.ToString() + ",Contains,Value = " + textBox5.Text;
                    break;
                case DataType.ReplaceText:
                    ListItem[Column].Text = ProgramManager.PackageReplace(textBox10.Text, textBox11.Text, textBox12.Text, textBox13.Text);
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
        private void PushNameToControl(object Data) {
            if (UseLinked == false) { return; }
            if (LinkedControl == null) { return; }
            if (LinkedControl.GetType() == typeof(ModbusCoil)) {
                ModbusCoil coil = (ModbusCoil)LinkedControl;
                coil.Name = Data.ToString() ?? "";
                SystemManager.RegisterNameChanged(coil.Parent, coil, Index, Selection);
            }
            else if (LinkedControl.GetType() == typeof(ModbusRegister)) {
                ModbusRegister coil = (ModbusRegister)LinkedControl;
                coil.Name = Data.ToString() ?? "";
                SystemManager.RegisterNameChanged(coil.Parent, coil, Index, Selection);
            }
        }
        bool HasSent = false;
        private void PushValueToControl(object Data) {
            if (HasSent == true) { return; }
            if (UseLinked == false) { return; }
            if (LinkedControl == null) { return; }
            else if (LinkedControl.GetType() == typeof(ModbusRegister)) {
                ModbusRegister coil = (ModbusRegister)LinkedControl;
                EnumManager.PushPrefix(coil, numericTextbox1.Prefix);
                coil.PushValue(Formatters.StringToLong(Data.ToString() ?? "0", coil.Format, coil.Size, coil.Signed), true);
                //SystemManager.SendModbusCommand(coil.ParentManager, coil.ComponentType, "Write Register " + coil.Address + " = " + coil.Value.ToString());
                //coil.Value = Data.ToString() ?? "";
                //Needs attention!
                SystemManager.RegisterValueChanged(coil.Parent, coil.FormattedValue, coil.Address, Selection);
            }
            HasSent = true;
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
                ArrowKeyPress?.Invoke(ArrowKey.Down);
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
            using (SolidBrush BrdBr = new SolidBrush(selectedColor)) {
                using (Pen BrdPn = new Pen(BrdBr)) {
                    e.Graphics.DrawRectangle(BrdPn, new Rectangle(0, 0, Width - 1, Height - 1));
                }
            }
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e) {
            Invalidate();
            base.OnResize(e);
        }

        private void EditValue_Resize(object sender, EventArgs e) {
            //        int wfactor = 4; // half the line width, kinda
            //                         // create 6 points for path
            //        Point[] pts = {
            //new Point(0, 0),
            //new Point(wfactor, 0),
            //new Point(Width, Height - wfactor),
            //new Point(Width, Height) ,
            //new Point(Width - wfactor, Height),
            //new Point(0, wfactor) };
            //        // magic numbers! 
            //        byte[] types = {
            //0, // start point
            //1, // line
            //1, // line
            //1, // line
            //1, // line
            //1 }; // line 
            //        GraphicsPath path = new GraphicsPath(pts, types);
            //        this.Region = new Region(path);
        }
        bool MoveLock = false;
        private void btnGrabPoint_MouseDown(object sender, MouseEventArgs e) {
            MoveLock = true;
            Cursor.Current = Cursors.Cross;
        }
        private void btnGrabPoint_MouseUp(object sender, MouseEventArgs e) {
            MoveLock = false;
            Cursor.Current = Cursors.Default;
            UseOffset = false;
        }
        private void btnGrabPoint_MouseMove(object sender, MouseEventArgs e) {
            if (MoveLock == true) {
                if (UseOffset == false) {
                    string PointData = Cursor.Position.X.ToString() + "," + Cursor.Position.Y.ToString();
                    AssignDual(PointData, ',', Type);
                }
                else {
                    Point Diff = new Point(Cursor.Position.X - SetPoint.X, Cursor.Position.Y - SetPoint.Y);
                    string PointData = Diff.X.ToString() + "," + Diff.Y.ToString();
                    AssignDual(PointData, ',', Type);
                }
            }
        }

        private void numericTextbox2_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PushValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void numericTextbox3_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PushValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void numericTextbox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                PushValue();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        Point SetPoint = Point.Empty;
        bool UseOffset = false;
        private void btnGrabPoint_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == ' ') {
                SetPoint = Cursor.Position;
                UseOffset = true;
                e.Handled = true;
            }
        }

        private void EditValue_Load_1(object sender, EventArgs e) {

        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e) {

        }

        private void splitContainer4_Panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void EditValue_KeyPress(object sender, KeyPressEventArgs e) {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.Down) {

                ArrowKeyPress?.Invoke(ArrowKey.Down);
                PushValue();
                return true;
            }
            else if (keyData == Keys.Up) {

                ArrowKeyPress?.Invoke(ArrowKey.Up);
                PushValue();
                return true;
            }
            else if (keyData == Keys.Left) {

                ArrowKeyPress?.Invoke(ArrowKey.Left);
                PushValue();
                return true;
            }
            else if (keyData == Keys.Right) {

                ArrowKeyPress?.Invoke(ArrowKey.Right);
                PushValue();
                return true;
            }
            else {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        private void EditValue_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Down) {
                ArrowKeyPress?.Invoke(ArrowKey.Down);
            }
        }
    }
}
