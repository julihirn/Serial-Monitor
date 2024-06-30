using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.SDI12 {
    public static class SDI12Commands {
        //https://www.sdi-12.org/current_specification/SDI-12_version-1_4-Jan-10-2019.pdf
        public static void AcknowledgeActive(SerialManager? Channel, int Address) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            byte[] Payload = SDI12Support.PackageCommand(Address, null);
            if (Payload.Length == 0) { return; }
            Channel.Transmit(Payload);
        }
        public static void SendIdentification(SerialManager? Channel, int Address) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            byte[] Temp = new byte[1];
            Temp[0] = (byte)'I';
            byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
            Channel.Transmit(Payload);
        }
        public static void ChangeAddress(SerialManager? Channel, int FromAddress, int ToAddress) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            (bool, byte) TempAddress = SDI12Support.IntegerAddressToByte(ToAddress);
            if (TempAddress.Item1 == false) { return; }
            byte[] Temp = new byte[2];
            Temp[0] = (byte)'A';
            Temp[1] = TempAddress.Item2;
            byte[] Payload = SDI12Support.PackageCommand(FromAddress, Temp);
            Channel.Transmit(Payload);
        }
        public static void AddressQuery(SerialManager? Channel) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            byte[] Temp = new byte[1];
            Temp[0] = (byte)'?';
            byte[] Payload = SDI12Support.PackageCommand(Temp);
            Channel.Transmit(Payload);
        }
        public static void StartMeasurement(SerialManager? Channel, int Address) {
            StartMeasurement(Channel, Address, false);
        }
        public static void StartMeasurement(SerialManager? Channel, int Address, bool WithCRC = false) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            if (WithCRC) {
                byte[] Temp = new byte[2];
                Temp[0] = (byte)'M';
                Temp[1] = (byte)'C';
                byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
                Channel.Transmit(Payload);
            }
            else {
                byte[] Temp = new byte[1];
                Temp[0] = (byte)'M';
                byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
                Channel.Transmit(Payload);
            }
        }
        public static void StartMeasurementRequestCRC(SerialManager? Channel, int Address) {
            StartMeasurement(Channel, Address, true);
        }
        public static void SendData(SerialManager? Channel, int Address, int Register) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            if ((Register < 0) || (Register > 9)) { return; }
            byte[] Temp = new byte[2];
            Temp[0] = (byte)'D';
            Temp[1] = (byte)(0x30 + Register);
            byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
            Channel.Transmit(Payload);
        }
        public static void AdditionalMeasurments(SerialManager? Channel, int Address, int Register, bool WithCRC = false) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            if ((Register < 1) || (Register > 9)) { return; }
            if (WithCRC) {
                byte[] Temp = new byte[3];
                Temp[0] = (byte)'M';
                Temp[1] = (byte)'C';
                Temp[2] = (byte)(0x30 + Register);
                byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
                Channel.Transmit(Payload);
            }
            else {
                byte[] Temp = new byte[2];
                Temp[0] = (byte)'M';
                Temp[1] = (byte)(0x30 + Register);
                byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
                Channel.Transmit(Payload);
            }
        }
        public static void StartVerification(SerialManager? Channel, int Address) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            byte[] Temp = new byte[1];
            Temp[0] = (byte)'V';
            byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
            Channel.Transmit(Payload);
        }
        public static void StartConcurrentMeasurement(SerialManager? Channel, int Address) {
            StartConcurrentMeasurement(Channel, Address, false);
        }
        public static void StartConcurrentMeasurementRequestCRC(SerialManager? Channel, int Address) {
            StartConcurrentMeasurement(Channel, Address, true);
        }
        public static void StartConcurrentMeasurement(SerialManager? Channel, int Address, bool WithCRC = false) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            if (WithCRC) {
                byte[] Temp = new byte[2];
                Temp[0] = (byte)'C';
                Temp[1] = (byte)'C';
                byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
                Channel.Transmit(Payload);

            }
            else {
                byte[] Temp = new byte[1];
                Temp[0] = (byte)'C';
                byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
                Channel.Transmit(Payload);
            }
        }
        public static void AdditionalConcurrentMeasurements(SerialManager? Channel, int Address, int Register) {
            AdditionalConcurrentMeasurements(Channel, Address, Register, false);
        }
        public static void AdditionalConcurrentMeasurementsRequestCRC(SerialManager? Channel, int Address, int Register) {
            AdditionalConcurrentMeasurements(Channel, Address, Register, true);
        }
        public static void AdditionalConcurrentMeasurements(SerialManager? Channel, int Address, int Register, bool WithCRC = false) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            if ((Register < 1) || (Register > 9)) { return; }
            if (WithCRC) {
                byte[] Temp = new byte[3];
                Temp[0] = (byte)'C';
                Temp[1] = (byte)'C';
                Temp[2] = (byte)(0x30 + Register);
                byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
                Channel.Transmit(Payload);
            }
            else {
                byte[] Temp = new byte[2];
                Temp[0] = (byte)'C';
                Temp[1] = (byte)(0x30 + Register);
                byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
                Channel.Transmit(Payload);
            }
        }
        public static void ContinuousMeasurements(SerialManager? Channel, int Address, int Register) {
            ContinuousMeasurements(Channel, Address, Register, false);
        }
        public static void ContinuousMeasurementsRequestCRC(SerialManager? Channel, int Address, int Register) {
            ContinuousMeasurements(Channel, Address, Register, true);
        }
        public static void ContinuousMeasurements(SerialManager? Channel, int Address, int Register, bool WithCRC = false) {
            if (Channel == null) { return; }
            if (Channel.Connected == false) { return; }
            if ((Register < 0) || (Register > 9)) { return; }
            if (WithCRC) {
                byte[] Temp = new byte[3];
                Temp[0] = (byte)'R';
                Temp[1] = (byte)'C';
                Temp[2] = (byte)(0x30 + Register);
                byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
                Channel.Transmit(Payload);
            }
            else {
                byte[] Temp = new byte[2];
                Temp[0] = (byte)'R';
                Temp[1] = (byte)(0x30 + Register);
                byte[] Payload = SDI12Support.PackageCommand(Address, Temp);
                Channel.Transmit(Payload);
            }
        }
    }
}
