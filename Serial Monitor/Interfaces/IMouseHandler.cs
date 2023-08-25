using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Serial_Monitor.Interfaces {
    public interface IMouseHandler {
        event EventHandler<MouseDownEventArgs> MouseEvent;
    }
    public class MouseDownEventArgs : EventArgs {
        public MouseDownEventArgs() { }
        public MouseDownEventArgs(IntPtr hWnd, Point point) {
            this.ControlHandle = hWnd;
            this.Position = point;
        }
        public IntPtr ControlHandle { get; }
        public Point Position { get; }
    }
}
