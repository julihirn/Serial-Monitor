using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Serial_Monitor.Components {


    public class MenuForm : SkinnedForm {
        private MenuStrip? menuStrip;
        [Category("Control")]
        public MenuStrip? EmbeddedMenuStrip {
            get { return menuStrip; }
            set {
                menuStrip = value;
                if (menuStrip != null) {
                    this.Controls.Remove(menuStrip); // Ensure it's drawn manually
                }
            }
        }
        private const int MENU_HEIGHT = 24;
        private const int BORDER_THICKNESS = 1; // Windows 10/11 invisible border

        public MenuForm() {
            //this.Text = "Smooth Non-Client MenuStrip";
            this.FormBorderStyle = FormBorderStyle.Sizable;
            //this.BackColor = Color.White;
            this.DoubleBuffered = true;


        }

        protected override void WndProc(ref Message m) {
            switch (m.Msg) {
                case 0x0083: // WM_NCCALCSIZE
                    HandleNcCalcSize(ref m);
                    return;
                case 0x0085: // WM_NCPAINT
                    HandleNcPaint();
                    m.Result = IntPtr.Zero;
                    return;
                case 0x0014: // WM_ERASEBKGND
                    m.Result = (IntPtr)1; // Prevent background flicker
                    return;
                case 0x0024: // WM_NCHITTEST
                    HandleNcHitTest(ref m);
                    return;
                case 0x0005: // WM_SIZE
                    this.Invalidate(); // Force redraw
                    break;
            }
            base.WndProc(ref m);
        }

        private void HandleNcCalcSize(ref Message m) {
            if (m.WParam != IntPtr.Zero) // Valid when TRUE
            {
                NCCALCSIZE_PARAMS nccsp = Marshal.PtrToStructure<NCCALCSIZE_PARAMS>(m.LParam);

                // Adjust for menu height while keeping modern thin border
                nccsp.rgrc[0].top += MENU_HEIGHT;
                nccsp.rgrc[0].left += BORDER_THICKNESS;
                nccsp.rgrc[0].right -= BORDER_THICKNESS;
                nccsp.rgrc[0].bottom -= BORDER_THICKNESS;

                Marshal.StructureToPtr(nccsp, m.LParam, false);
                m.Result = IntPtr.Zero;
            }
        }

        private void HandleNcPaint() {
            IntPtr hdc = GetWindowDC(this.Handle);
            if (hdc != IntPtr.Zero) {
                using (BufferedGraphicsContext bgc = new BufferedGraphicsContext()) {
                    using (BufferedGraphics bg = bgc.Allocate(Graphics.FromHdc(hdc), new Rectangle(0, 0, this.Width, MENU_HEIGHT))) {
                        Graphics g = bg.Graphics;
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        using (SolidBrush br = new SolidBrush(ActiveBorderColor)) {
                            g.FillRectangle(br, new Rectangle(BORDER_THICKNESS, BORDER_THICKNESS, this.Width - (2 * BORDER_THICKNESS), MENU_HEIGHT));
                        }

                        if (menuStrip != null) {
                            menuStrip.Renderer.DrawToolStripBackground(new ToolStripRenderEventArgs(g, menuStrip));
                            menuStrip.Renderer.DrawToolStripBorder(new ToolStripRenderEventArgs(g, menuStrip));
                        }
                        bg.Render();
                    }
                }
                ReleaseDC(this.Handle, hdc);
            }
        }

        private void HandleNcHitTest(ref Message m) {
            base.WndProc(ref m);
            if (m.Result == (IntPtr)1) // HTCLIENT
            {
                Point cursorPos = PointToClient(Cursor.Position);
                if (cursorPos.Y < MENU_HEIGHT)
                    m.Result = (IntPtr)2; // HTCAPTION (make it draggable)
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct NCCALCSIZE_PARAMS {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public RECT[] rgrc;
            public IntPtr lppos;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT {
            public int left, top, right, bottom;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
    }

}
