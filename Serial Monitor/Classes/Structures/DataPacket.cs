using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Structures {
    public struct DataPacket {
        public DataPacket(byte[] bPayload, int bPayloadLength, string sPayload) {
            bytePayload = new byte[bPayloadLength];
            Array.Copy(bPayload, 0, bytePayload, 0, bPayloadLength);
            textPayload = sPayload;
            length = bPayloadLength;
        }
        byte[] bytePayload;
        public byte[] BytePayload {
            get { return bytePayload; }
        }
        string textPayload;
        public string TextPayload {
            get { return textPayload; }
        }
        int length;
        public int Length {
            get { return length; }
        }
    }
}
