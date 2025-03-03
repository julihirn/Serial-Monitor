using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.Components {
    public partial class SkinnedForm : Form {
        public SkinnedForm() {
            InitializeComponent();
            HandleFocusEvents();
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
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
        bool isActive = false;
        public bool IsActive {
            get {
                return isActive;
            }
        }
        private void SkinnedForm_Load(object sender, EventArgs e) {

        }
        private string ToBgr(Color c) => $"{c.B:X2}{c.G:X2}{c.R:X2}";

        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        const int DWWMA_CAPTION_COLOR = 35;
        const int DWWMA_BORDER_COLOR = 34;
        const int DWMWA_TEXT_COLOR = 36;
        public void CustomWindow(Color captionColor, Color fontColor, Color borderColor, IntPtr handle) {
            IntPtr hWnd = handle;
            //Change caption color
            try {
                if (DesignerSetup.IsWindows11OrGreater() == true) {
                    int[] caption = new int[] { int.Parse(ToBgr(captionColor), System.Globalization.NumberStyles.HexNumber) };
                    DwmSetWindowAttribute(hWnd, DWWMA_CAPTION_COLOR, caption, 4);
                    //Change font color
                    int[] font = new int[] { int.Parse(ToBgr(fontColor), System.Globalization.NumberStyles.HexNumber) };
                    DwmSetWindowAttribute(hWnd, DWMWA_TEXT_COLOR, font, 4);
                    //Change border color
                    int[] border = new int[] { int.Parse(ToBgr(borderColor), System.Globalization.NumberStyles.HexNumber) };
                    DwmSetWindowAttribute(hWnd, DWWMA_BORDER_COLOR, border, 4);
                }

            }
            catch { }

        }
        private void RepaintBorder() {
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
    }
}
