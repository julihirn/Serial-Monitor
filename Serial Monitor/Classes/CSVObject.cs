using Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes {
    public struct CSVObject {
        private decimal DecimalValue;
        private string TextValue;
        private bool BooleanValue;
        CSVType Type;
        public CSVObject(object ?Value = null) {
            BooleanValue = false;
            TextValue = "NULL";
            Type = CSVType.Text;
            DecimalValue = 0;
        }
        public CSVObject(int Value) {
            BooleanValue = false;
            TextValue = "";
            Type = CSVType.Number;
            DecimalValue = (decimal)Value;
        }
        public CSVObject(decimal Value) {
            BooleanValue = false;
            TextValue = "";
            Type = CSVType.Number;
            DecimalValue = Value; TextValue = ""; BooleanValue = false;
        }
        public CSVObject(float Value) {
            BooleanValue = false;
            TextValue = "";
            Type = CSVType.Number;
            DecimalValue = (decimal)Value;
        }
        public CSVObject(double Value) {
            BooleanValue = false;
            TextValue = "";
            Type = CSVType.Number;
            DecimalValue = (decimal)Value;
        }
        public CSVObject(uint Value) {
            BooleanValue = false;
            TextValue = "";
            Type = CSVType.Number;
            DecimalValue = (decimal)Value;
        }
        public CSVObject(ulong Value) {
            BooleanValue = false;
            TextValue = "";
            Type = CSVType.Number;
            DecimalValue = (decimal)Value;
        }
        public CSVObject(long Value) {
            BooleanValue = false;
            TextValue = "";
            Type = CSVType.Number;
            DecimalValue = (decimal)Value;
        }
        public CSVObject(byte Value) {
            BooleanValue = false;
            TextValue = "";
            Type = CSVType.Number;
            DecimalValue = (decimal)Value;
        }
        public CSVObject(bool Value) {
            DecimalValue = 0;
            TextValue = "";
            Type = CSVType.Boolean;
            BooleanValue = Value;
        }
        public CSVObject(string Value) {
            BooleanValue = false;
            DecimalValue = 0;
            Type = CSVType.Text;
            TextValue = Value;
        }
        public override string ToString() {
            switch (Type) {
                case CSVType.Number:
                    return DecimalValue.ToString();
                case CSVType.Boolean:
                    return BooleanValue.ToString();
                case CSVType.Text:
                    return StringHandler.EncapsulateString(TextValue);
                default:
                    return "";
            }
        }

    }
    public enum CSVType {
        Blank = 0x00,
        Number = 0x01,
        Text = 0x02,
        Boolean = 0x03
    }
}
