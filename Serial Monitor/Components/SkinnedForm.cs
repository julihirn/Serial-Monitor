using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.Components {
    public partial class SkinnedForm : Form {
        private System.Windows.Forms.Timer _resizeRedrawTimer;
        public SkinnedForm() {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
              ControlStyles.UserPaint |
              ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
            InitializeComponent();
            HandleFocusEvents();
           
            this.Deactivate += (s, e) => _isDeactivating = true;
            this.Activated += (s, e) => _isDeactivating = false;
            _resizeRedrawTimer = new System.Windows.Forms.Timer();
            _resizeRedrawTimer.Interval = 50; // ~20 FPS
            _resizeRedrawTimer.Tick += (s, e) => this.Invalidate(true);
        }
        protected override CreateParams CreateParams {
            get {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        Color activeBorderColor = Color.SteelBlue;
        [Category("Appearance")]
        public Color ActiveBorderColor {
            get {
                return activeBorderColor;
            }
            set { activeBorderColor = value; RepaintBorder(); }
        }
        Color inactiveBorderColor = Color.DarkGray;
        [Category("Appearance")]
        public Color InactiveBorderColor {
            get {
                return inactiveBorderColor;
            }
            set { inactiveBorderColor = value; RepaintBorder(); }
        }
        Color titleBackColor = Color.SteelBlue;
        [Category("Appearance")]
        public Color TitleBackColor {
            get {
                return titleBackColor;
            }
            set {
                titleBackColor = value; RepaintBorder();
            }
        }
        Color titleForeColor = Color.White;
        [Category("Appearance")]
        public Color TitleForeColor {
            get {
                return titleForeColor;
            }
            set {
                titleForeColor = value; RepaintBorder();
            }
        }
        bool enableMica = false;
        [Category("Appearance")]
        public bool EnableTransparency {
            get {
                return enableMica;
            }
            set {
                enableMica = value; RepaintBorder();
            }
        }
        private bool CanBeTransparent {
            get {
                if (EnableTransparency) {
                    return DesignerSetup.IsWindows11OrGreater();
                }
                return false;
            }
        }
        bool isActive = false;
        public bool IsActive {
            get {
                return isActive;
            }
        }
        private void SkinnedForm_Load(object sender, EventArgs e) {

        }
        private const int DWMWA_SYSTEMBACKDROP_TYPE = 38; // Introduced in Windows 11 build 22000
        private enum DwmSystemBackdropType {
            Auto = 0,
            None = 1,
            Mica = 2,
            Acrylic = 3,
            Tabbed = 4
        }
        private string ToBgr(Color c) => $"{c.B:X2}{c.G:X2}{c.R:X2}";

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);
        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [StructLayout(LayoutKind.Sequential)]
        private struct MARGINS { public int cxLeftWidth, cxRightWidth, cyTopHeight, cyBottomHeight; }

        MARGINS margins = new MARGINS { cxLeftWidth = 1, cxRightWidth = 1, cyTopHeight = 1, cyBottomHeight = 1 };

        const int DWWMA_CAPTION_COLOR = 35;
        const int DWWMA_BORDER_COLOR = 34;
        const int DWMWA_TEXT_COLOR = 36;
        private void EnableMica(IntPtr hWnd) {
            try {
                if (CanBeTransparent) {
                    int micaValue = (int)DwmSystemBackdropType.Acrylic;
                    DwmSetWindowAttribute(hWnd, DWMWA_SYSTEMBACKDROP_TYPE, new int[] { micaValue }, sizeof(int));
                }
                else {
                    int noneValue = (int)DwmSystemBackdropType.None;
                    DwmSetWindowAttribute(hWnd, DWMWA_SYSTEMBACKDROP_TYPE, new int[] { noneValue }, sizeof(int));
                }
            }
            catch {
            }
        }
        public void CustomWindow(Color captionColor, Color fontColor, Color borderColor, IntPtr handle) {
            IntPtr hWnd = handle;
            EnableMica(this.Handle);
            if (!DesignerSetup.IsWindows11OrGreater()) { return; }
            try {
                if (CanBeTransparent) {
                    int micaValue = (int)DwmSystemBackdropType.Mica;
                    DwmSetWindowAttribute(hWnd, DWMWA_SYSTEMBACKDROP_TYPE, new int[] { micaValue }, sizeof(int));
                }
                else {
                    int[] caption = new int[] { int.Parse(ToBgr(captionColor), System.Globalization.NumberStyles.HexNumber) };
                    DwmSetWindowAttribute(hWnd, DWWMA_CAPTION_COLOR, caption, 4);
                }
                int[] font = new int[] { int.Parse(ToBgr(fontColor), System.Globalization.NumberStyles.HexNumber) };
                DwmSetWindowAttribute(hWnd, DWMWA_TEXT_COLOR, font, 4);
                //Change border color
                int[] border = new int[] { int.Parse(ToBgr(borderColor), System.Globalization.NumberStyles.HexNumber) };
                DwmSetWindowAttribute(hWnd, DWWMA_BORDER_COLOR, border, 4);

            }
            catch { }

        }
        //public void CustomWindow(Color captionColor, Color fontColor, Color borderColor, IntPtr handle) {
        //    IntPtr hWnd = handle;
        //    if (!DesignerSetup.IsWindows11OrGreater()){
        //        return;
        //    }
        //    try {
        //        int micaValue = (int)(CanBeTransparent ? DwmSystemBackdropType.Mica : DwmSystemBackdropType.None);
        //        DwmSetWindowAttribute(hWnd, DWMWA_SYSTEMBACKDROP_TYPE, new[] { micaValue }, sizeof(int));
        //        DwmSetWindowAttribute(hWnd, DWWMA_CAPTION_COLOR, new[] { captionColor.ToArgb() }, 4);
        //        DwmSetWindowAttribute(hWnd, DWMWA_TEXT_COLOR, new[] { fontColor.ToArgb() }, 4);
        //        Color semi = Color.FromArgb(128, borderColor); 
        //        DwmSetWindowAttribute(hWnd, DWWMA_BORDER_COLOR, new[] { semi.ToArgb() }, 4);
        //    }
        //    catch {
        //        // Safe fail
        //    }
        //}
        private void RepaintBorder() {
            EnableMica(this.Handle);
            if (isActive) {
                CustomWindow(titleBackColor, titleForeColor, activeBorderColor, this.Handle);
            }
            else {
                CustomWindow(titleBackColor, titleForeColor, inactiveBorderColor, this.Handle);
            }
        }
        private void HandleFocusEvents() {
            this.LostFocus += Form_LostFocus;
            this.GotFocus += Form_GotFocus;
            this.Activated += SkinnedForm_Activated;
            this.Deactivate += SkinnedForm_Deactivate;
        }

        private void SkinnedForm_Deactivate(object? sender, EventArgs e) {
            isActive = false;
            RepaintBorder();
        }
        private void SkinnedForm_Activated(object? sender, EventArgs e) {
            isActive = true;
            RepaintBorder();
        }
        private void Form_LostFocus(object? sender, EventArgs e) {
            if (!this.ContainsFocus) {
                isActive = false;
            }
            RepaintBorder();
        }
        private void Form_GotFocus(object? sender, EventArgs e) {
            isActive = true;
            RepaintBorder();
        }
        protected override void OnPaintBackground(PaintEventArgs e) {
            if (enableMica) {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(80, titleBackColor))) {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
            }
            else {
                e.Graphics.Clear(this.BackColor);
            }
        }
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        const uint GW_OWNER = 4;
        private bool _isRestoring = false;
        private bool _isDeactivating = false;
        private bool _isResizing = false;
        public bool IsAppDeactivating => _isDeactivating;
        protected override void WndProc(ref Message m) {
            const int WM_ERASEBKGND = 0x0014;
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_RESTORE = 0xF120;
            const int WM_ENTERSIZEMOVE = 0x0231;
            const int WM_EXITSIZEMOVE = 0x0232;
            const int WM_SETFOCUS = 0x0007;
            const int WM_ACTIVATE = 0x0006;
            const int WA_ACTIVE = 1;
            const int WA_CLICKACTIVE = 2;

            const int WM_NCACTIVATE = 0x0086;
            const int WM_KILLFOCUS = 0x0008;
            const int WM_WINDOWPOSCHANGING = 0x0046;
            const int WM_WINDOWPOSCHANGED = 0x0047;

            // Only log the messages we care about to avoid spamming too much
            //if (m.Msg == WM_ACTIVATE || m.Msg == WM_NCACTIVATE || m.Msg == WM_SETFOCUS ||
            //    m.Msg == WM_KILLFOCUS || m.Msg == WM_WINDOWPOSCHANGING || m.Msg == WM_WINDOWPOSCHANGED) {
            //    var fg = GetForegroundWindow();
            //    Debug.WriteLine($"WndProc: Msg=0x{m.Msg:X} WParam={m.WParam} LParam={m.LParam} Foreground=0x{fg.ToInt64():X}");
            //}

            if (m.Msg == WM_ACTIVATE) {
                Debug.WriteLine($"\nACTIVATE: wParam={m.WParam}  Foreground={GetForegroundWindow():X}");
                IntPtr owner = GetWindow(this.Handle, GW_OWNER);
                Debug.WriteLine($"Owner: {owner:X}\n");
            }

            // Prevent white flash on load by skipping background erase
            if (m.Msg == WM_ERASEBKGND) {
                m.Result = IntPtr.Zero;
                return;
            }

            // Throttled redraw during live resize
            if (m.Msg == WM_ENTERSIZEMOVE) {
                _isResizing = true;
                _resizeRedrawTimer.Start();
            }
            else if (m.Msg == WM_EXITSIZEMOVE) {
                _isResizing = false;
                _resizeRedrawTimer.Stop();
                this.Invalidate(true); // Final clean repaint
            }

            // Detect when window is about to restore from minimized
            if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt32() & 0xFFF0) == SC_RESTORE) {
                _isRestoring = true;
                this.SuspendLayout();
            }

            base.WndProc(ref m);

            // After restoring, resume layout and repaint border once
            if (_isRestoring && m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt32() & 0xFFF0) == SC_RESTORE) {
                _isRestoring = false;
                this.ResumeLayout(true);
                RepaintBorder();
            }
        }
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            EnableMica(this.Handle);
            RepaintBorder();
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                if (!DesignerSetup.IsWindows11OrGreater()) {
                    DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
                }
            }
        }
        //protected override void OnShown(EventArgs e) {
        //    base.OnShown(e);
        //    EnableMica(this.Handle);
        //    RepaintBorder();
         
        //}
        //protected override void OnLoad(EventArgs e) {
        //    base.OnLoad(e);

        //    // Apply mica after the system finishes sizing & positioning
        //    this.BeginInvoke(new Action(() =>
        //    {
        //        EnableMica(this.Handle);
        //        RepaintBorder();
        //    }));
        //}

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            Debug.WriteLine($"OnLoad: StartPosition={StartPosition}, Location={Location}");
        }
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            Debug.WriteLine($"OnShown: StartPosition={StartPosition}, Location={Location}");
        }
    }
}
