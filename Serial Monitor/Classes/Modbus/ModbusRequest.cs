using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public class ModbusRequest {
        ModbusSupport.FunctionCode function;
        public ModbusSupport.FunctionCode Function {
            get { return Function; }
        }
        int device = 0;
        public int Device {
            get { return device; }
        }
        int address;
        public int Address {
            get { return address; }
        }
        //
        bool IsInteger = false;
        public object Values {
            get {
                if (IsInteger) {
                    return ShortValues;
                }
                else {
                    return BoolValues;
                }
            }
        }
        DateTime creationTime = DateTime.UtcNow;
        public DateTime CreationTime {
            get {
                return creationTime;
            }
        }
        List<bool> BoolValues = new List<bool>();
        List<short> ShortValues = new List<short>();
        public ModbusRequest(ModbusSupport.FunctionCode function, int device, int address, List<bool> Values) {
            this.function = function;
            this.device = device;
            this.address = address;
            IsInteger = false;
            this.BoolValues = Values;
            creationTime = DateTime.UtcNow;
        }
        public ModbusRequest(ModbusSupport.FunctionCode function, int device, int address, List<short> Values) {
            this.function = function;
            this.device = device;
            this.address = address;
            IsInteger = false;
            this.ShortValues = Values;
            creationTime = DateTime.UtcNow;
        }
    }
    public class Container<T> {
        private T _data;
        public Container(T value) {
            _data = value;
        }
        public T Data {
            get { return _data; }
            set { _data = value; }
        }
    }
}
