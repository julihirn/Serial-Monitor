using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor {
    public partial class EditValue : Form {
        public StepExecutable StepEx = StepExecutable.NoOperation;
        DataType SelectedType;
        ODModules.ListControl? lstControl = null;
        ListItem? ListItem = null;
        char Spiltter = '=';
        object? Linkage = null;
        object? Parameter = null;
        bool IgnoreChanges = true;
        int HSet = 30;
        public Size Sz = new Size(10, 10);
        public EditValue(StepExecutable StepExe, string InputValue, ODModules.ListControl ListCtrl, ListItem Item, object? Linkage, object? Parameter, bool IgnoreChanges) {
            InitializeComponent();
            this.Linkage = Linkage;
            this.Parameter = Parameter;
            this.IgnoreChanges = IgnoreChanges;
            Initalise(StepExe, InputValue, ListCtrl, Item);
        }
        public EditValue(StepExecutable StepExe, string InputValue, ODModules.ListControl ListCtrl, ListItem Item) {
            InitializeComponent();
            Initalise(StepExe, InputValue, ListCtrl, Item);
        }
        void Initalise(StepExecutable StepExe, string InputValue, ODModules.ListControl ListCtrl, ListItem Item) {
            StepEx = StepExe;
            string ArgumentLeft = "";
            string ArgumentRight = "";
            lstControl = ListCtrl;
            ListItem = Item;
            if (StepEx == StepExecutable.Delay) {
                SelectedType = DataType.Number;
            }
            else if (StepEx == StepExecutable.SendLine) {
                SelectedType = DataType.StringType;
            }
            else if (StepEx == StepExecutable.SendString) {
                SelectedType = DataType.StringType;
            }
            else if (StepEx == StepExecutable.SendText) {
                SelectedType = DataType.StringType;
            }
            else if (StepEx == StepExecutable.Print) {
                SelectedType = DataType.StringType;
            }
            else if (StepEx == StepExecutable.Label) {
                SelectedType = DataType.StringType;
            }
            else if (StepEx == StepExecutable.MousePosition) {
                SelectedType = DataType.CursorLocation;
            }
            else if (StepEx == StepExecutable.DeclareVariable) {
                SelectedType = DataType.DualString;
                Spiltter = '=';
                ArgumentLeft = StringHandler.SpiltString(InputValue, Spiltter, 0);
                if (InputValue.Contains('=')) {
                    ArgumentRight = StringHandler.SpiltAndCombineAfter(InputValue, Spiltter, 1).Value[1];
                }
            }
            else if ((StepEx == StepExecutable.Close) || (StepEx == StepExecutable.Open) || (StepEx == StepExecutable.SwitchSender)) {
                SelectedType = DataType.EnumVal;
                string[] ports = SerialPort.GetPortNames();
                Array.Sort(ports, StringComparer.CurrentCultureIgnoreCase);
                foreach (string port in ports) {
                    if (ItemExists(port) == false) {
                        flatComboBox1.Items.Add(port);
                    }
                }
            }
            if (SelectedType == DataType.Number) {
                numericTextbox1.Value = InputValue;
                numericTextbox1.Show();
                HSet = HeightGet(flatComboBox1.Height);
            }
            else if (SelectedType == DataType.StringType) {
                textBox1.Text = InputValue;
                textBox1.Show();
                HSet = HeightGet(textBox1.Height);
            }
            else if (SelectedType == DataType.EnumVal) {
                flatComboBox1.Text = InputValue;
                flatComboBox1.Show();
                HSet = HeightGet(flatComboBox1.Height);
            }
            else if (SelectedType == DataType.DualString) {
                textBox2.Text = ArgumentLeft;
                textBox3.Text = ArgumentRight;
                splitContainer1.Dock = DockStyle.Fill;
                splitContainer1.Show();
                HSet = HeightGet(textBox2.Height);
            }
            else if (SelectedType == DataType.CursorLocation) {
                label1.Show();
                HSet = HeightGet(label1.Height);
                label1.Text = InputValue;
            }
        }
        private int HeightGet(int ControlHeight) {
            return ControlHeight + Padding.Top + Padding.Bottom;
        }
        string outVal = "";
        public string Output {
            get { return outVal; }
        }
        private bool ItemExists(string Name) {
            foreach (string Item in flatComboBox1.Items) {
                if (Item == Name) {
                    return true;
                }
            }
            return false;
        }
        private void EditValue_Load(object sender, EventArgs e) {
            this.Size = Sz;
        }
        //protected override void WndProc(ref Message m) {
        //    const UInt32 WM_NCACTIVATE = 0x0086;
        //    base.WndProc(ref m);
        //    if (m.Msg == WM_NCACTIVATE && m.WParam.ToInt32() == 0) {
        //        this.Close();
        //    }
        //}

        private void button1_Click(object sender, EventArgs e) {

        }
        private enum DataType {
            StringType = 0x00,
            Number = 0x01,
            EnumVal = 0x02,
            DualString = 0x03,
            CursorLocation = 0x30
        }
        private void button2_ButtonClicked(object sender) {
            AcceptChanges();
        }
        private void AcceptChanges() {
            if (SelectedType == DataType.Number) {
                outVal = numericTextbox1.Value.ToString() ?? "0";
            }
            else if (SelectedType == DataType.StringType) {
                outVal = textBox1.Text;
            }
            else if (SelectedType == DataType.EnumVal) {
                outVal = flatComboBox1.Text;
            }
            else if (SelectedType == DataType.DualString) {
                outVal = textBox2.Text + Spiltter + textBox3.Text;
            }
            else if (SelectedType == DataType.CursorLocation) {
                outVal = Cursor.Position.X.ToString() + ", " + Cursor.Position.Y.ToString();
            }
            this.DialogResult = DialogResult.OK;

            if (IgnoreChanges == false) {
                if (Linkage != null) {
                    if (Linkage.GetType() == typeof(SerialManager)) {
                        if (Parameter != null) {
                            if (Parameter.GetType() == typeof(ModbusRegister)) {
                                ModbusRegister Reg = (ModbusRegister)Parameter;
                                decimal Temp = 0;
                                decimal.TryParse(outVal, out Temp);
                                try {
                                    Reg.Value = (short)Temp;
                                    SystemManager.SendModbusCommand((SerialManager)Linkage, Reg.ComponentType, "Write Register " + Reg.Address.ToString() + " = " + outVal);
                                }
                                catch { }
                            }
                        }
                    }
                }
                else {
                    if (Parameter != null) {
                        if (Parameter.GetType() == typeof(ModbusRegister)) {
                            ModbusRegister Reg = (ModbusRegister)Parameter;
                            if (StepEx == StepExecutable.Label) {
                                Reg.Name = outVal;
                                if (ListItem != null) {
                                    ListItem.SubItems[0].Text = Output;
                                }
                            }
                        }
                        else if (Parameter.GetType() == typeof(ModbusCoil)) {
                            ModbusCoil Reg = (ModbusCoil)Parameter;
                            if (StepEx == StepExecutable.Label) {
                                Reg.Name = outVal;
                                if (ListItem != null) {
                                    ListItem.SubItems[0].Text = Output;
                                }
                            }
                        }
                    }
                }
            }
            else {
                if (ListItem != null) {
                    ListItem.SubItems[2].Text = Output;
                }
            }
            if (lstControl != null) {
                lstControl.Invalidate();
            }
            // lstStepProgram.Invalidate();
            this.Close();
        }

        private void EditValue_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void EditValue_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Enter) {
                AcceptChanges();
            }
            else if (e.KeyData == Keys.Escape) {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void EditValue_Deactivate(object sender, EventArgs e) {
            if (SelectedType == DataType.CursorLocation) {
                AcceptChanges();
            }
            this.Close();
        }

        private void button2_Load(object sender, EventArgs e) {

        }
        protected override bool ShowWithoutActivation {
            get { return true; }
        }
       //protected override CreateParams CreateParams {
       //    get {
       //        CreateParams p = base.CreateParams;
       //
       //        p.Style |= 0x40000000; // WS_CHILD
       //        p.ExStyle |= 0x8000000; // WS_EX_NOACTIVATE - requires Win 2000 or higher :)
       //
       //        return p;
       //    }
       //}

    }
}
