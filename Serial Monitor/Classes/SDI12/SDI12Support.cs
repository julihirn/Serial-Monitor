using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Serial_Monitor.Classes.SDI12 {
    public static class SDI12Support {
        public static (bool, byte) IntegerAddressToByte(int Address) {
            if (Address < 0) { return (false, 0); }
            else if ((Address >= 0) && (Address <= 9)) { return (true, (byte)(0x30 + Address)); }
            else if ((Address >= 10) && (Address <= 36)) { return (true, (byte)(0x41 + Address)); }
            else if ((Address >= 37) && (Address <= 63)) { return (true, (byte)(0x61 + Address)); }
            return (false, 0);
        }
        public static int ByteAddressToInteger(byte Address) {
            if (Address < 0x30) { return -1; }
            else if ((Address >= 0x30) && (Address <= 0x39)) { return Address - 0x30; }
            else if ((Address >= 0x41) && (Address <= 0x5A)) { return (Address - 0x41) + 0x0A; }
            else if ((Address >= 0x61) && (Address <= 0x7A)) { return (Address - 0x61) + 0x25; }
            return -1;
        }
        public static byte[] PackageCommand(byte[] Input) {
            byte[] Output = new byte[Input.Length + 1];
            Array.Copy(Input, 0, Output, 0, Input.Length);
            Output[Input.Length] = (byte)'!';
            return Output;
        }
        public static byte[] PackageCommand(int Address, byte[]? Input) {
            if (Input != null) {
                byte[] Output = new byte[2];
                (bool, byte) Temp = IntegerAddressToByte(Address);
                if (Temp.Item1 == false) { return Array.Empty<byte>(); }
                Output[0] = Temp.Item2;
                Output[Input.Length] = (byte)'!';
                return Output;
            }
            else {
                byte[] Output = new byte[Input.Length + 2];
                Array.Copy(Input, 0, Output, 1, Input.Length);
                (bool, byte) Temp = IntegerAddressToByte(Address);
                if (Temp.Item1 == false) { return Array.Empty<byte>(); }
                Output[0] = Temp.Item2;
                Output[Input.Length] = (byte)'!';
                return Output;
            }
        }
    }
}
