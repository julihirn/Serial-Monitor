﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
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
                if (enableMica) {
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

        const int DWWMA_CAPTION_COLOR = 35;
        const int DWWMA_BORDER_COLOR = 34;
        const int DWMWA_TEXT_COLOR = 36;
        private void EnableMica(IntPtr hWnd) {
            try {
                if (CanBeTransparent) {
                    int micaValue = (int)DwmSystemBackdropType.Mica;
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
            if (DesignerSetup.IsWindows11OrGreater() == false) { return; }
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
        }
    }
}
