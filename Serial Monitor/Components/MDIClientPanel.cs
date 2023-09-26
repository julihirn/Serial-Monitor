using Serial_Monitor.Classes.Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Components {
    public class MdiClientPanel : Panel {
        private MdiClient _ctlClient = new MdiClient();



        public delegate void ActivateHandler(object sender, MdiClientForm child);
        public event ActivateHandler OnChildActivated;

        [DllImport("User32.Dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("User32.Dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_CLIENTEDGE = 0x200;

        public Form ActiveMDIWnd {
            get;
            set;
        }
        public List<MdiClientForm> ChildForms = new List<MdiClientForm>();
        public MdiClientPanel() {
            InitializeComponent();
            base.Controls.Add(_ctlClient);
            this.SetBevel(false);
        }

        private Form _mdiForm = null;
        public Form MdiForm {
            get {
                if (_mdiForm == null) {
                    _mdiForm = new Form();
                    // Set the hidden _ctlClient field which is used to determine if the form is an MDI form
                    System.Reflection.FieldInfo ?field = typeof(Form).GetField("ctlClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (field != null) {
                        field.SetValue(_mdiForm, _ctlClient);
                    }
                }
                return _mdiForm;
            }
        }

        public override Color BackColor {
            get { return base.BackColor; }
            set {
                base.BackColor = value;
                _ctlClient.BackColor = value;
            }
        }

        private void InitializeComponent() {
            SuspendLayout();
            ResumeLayout(false);
        }
        public MdiClientForm AddChild(MdiClientForm child) {
            child.MyMdiContainer = this;
            child.MdiParent = MdiForm;
            ChildForms.Add(child);
            child.FormBorderStyle = FormBorderStyle.None;
            child.Show();
            return child;
        }
        public void RestoreChildForms() {
            foreach (MdiClientForm child in ChildForms) {
                child.WindowState = FormWindowState.Normal;
                child.MaximizeBox = true;
                child.MinimizeBox = true;
            }
        }
        public void ChildActivated(MdiClientForm ?child) {
            if (child == null) { return; }
            ActiveMDIWnd = child;

            if (OnChildActivated != null)
                OnChildActivated(this, child);
        }
        public void ChildClosed(MdiClientForm ?child) {
            if (child == null) { return; }
            ChildForms.Remove(child);
        }
    }
    public static class MDIClientSupport {
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", ExactSpelling = true)]
        private static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_CLIENTEDGE = 0x200;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_NOREDRAW = 0x0008;
        private const uint SWP_NOACTIVATE = 0x0010;
        private const uint SWP_FRAMECHANGED = 0x0020;
        private const uint SWP_SHOWWINDOW = 0x0040;
        private const uint SWP_HIDEWINDOW = 0x0080;
        private const uint SWP_NOCOPYBITS = 0x0100;
        private const uint SWP_NOOWNERZORDER = 0x0200;
        private const uint SWP_NOSENDCHANGING = 0x0400;
        public static bool SetBevel(this Panel form, bool show) {
            foreach (Control c in form.Controls) {
                MdiClient? client = c as MdiClient;
                if (client != null) {
                    int windowLong = GetWindowLong(c.Handle, GWL_EXSTYLE);

                    if (show) {
                        windowLong |= WS_EX_CLIENTEDGE;
                    }
                    else {
                        windowLong &= ~WS_EX_CLIENTEDGE;
                    }

                    SetWindowLong(c.Handle, GWL_EXSTYLE, windowLong);

                    // Update the non-client area.
                    SetWindowPos(client.Handle, IntPtr.Zero, 0, 0, 0, 0,
                        SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER |
                        SWP_NOOWNERZORDER | SWP_FRAMECHANGED);

                    return true;
                }
            }
            return false;
        }
        public static bool SetBevel(this Form form, bool show) {
            foreach (Control c in form.Controls) {
                MdiClient? client = c as MdiClient;
                if (client != null) {
                    int windowLong = GetWindowLong(c.Handle, GWL_EXSTYLE);

                    if (show) {
                        windowLong |= WS_EX_CLIENTEDGE;
                    }
                    else {
                        windowLong &= ~WS_EX_CLIENTEDGE;
                    }

                    SetWindowLong(c.Handle, GWL_EXSTYLE, windowLong);

                    // Update the non-client area.
                    SetWindowPos(client.Handle, IntPtr.Zero, 0, 0, 0, 0,
                        SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER |
                        SWP_NOOWNERZORDER | SWP_FRAMECHANGED);

                    return true;
                }
            }
            return false;
        }

    }
}
