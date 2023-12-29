using Handlers;
using Microsoft.VisualBasic.ApplicationServices;
using Serial_Monitor.Classes.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ODModules;
using System.Diagnostics;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Classes;

namespace Serial_Monitor.Components {
    public partial class BitTogglerPopup : TemplateContextMenu, Interfaces.ITheme {
        public BitTogglerPopup() {
            InitializeComponent();
        }
        public void ApplyTheme() {
            ThemeManager.ThemeControl(btToggler);

        }

        protected override void OnHandleDestroyed(EventArgs e) {
            base.OnHandleDestroyed(e);
        }

        protected override void OnValidated(EventArgs e) {
            base.OnValidated(e);
        }

        protected override void OnValidating(CancelEventArgs e) {
            //ApplyTheme();
            base.OnValidating(e);
        }

        protected override void OnVisibleChanged(EventArgs e) {
            ApplyTheme();
            base.OnVisibleChanged(e);
        }

        private void btToggler_BitToggled(object sender, int Bit, string Value) {
            if (Register == null) { return; }
            Register.PushValue(Formatters.StringToLong(Value, Classes.Enums.ModbusEnums.DataFormat.Binary, Register.Size, Register.Signed), true);
            SystemManager.RegisterValueChanged(Register.Parent, Register.FormattedValue, Register.Address, Register.ComponentType);
        }
        ModbusRegister? register = null;
        public ModbusRegister? Register {
            get { return register; }
            set {
                if (value != null) {
                    Bits = EnumManager.DataSizeToInteger(value.Size);
                    btToggler.Value = value.FormattedValue;
                }
                register = value;
            }
        }
        public int Bits {
            get { return btToggler.Bits; }
            set { btToggler.Bits = value; }
        }
    }
}
