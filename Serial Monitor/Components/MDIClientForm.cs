using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ODModules.LabelPanel;

namespace Serial_Monitor.Components {
    public class MdiClientForm : Form {
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;
        // Private Const WM_NCHITTEST As Integer = &H84
        protected override void WndProc(ref System.Windows.Forms.Message m) {
            if (m.Msg != 0x5) {
                base.WndProc(ref m);
            }
            int ScaleGrip = DesignerSetup.ScaleInteger(5);
            try {
                switch (m.Msg) {
                    case WM_NCHITTEST: {
                            base.WndProc(ref m);
                            var pt = new Point(m.LParam.ToInt32());
                            pt = this.PointToClient(pt);
                            if (pt.X < ScaleGrip && pt.Y < ScaleGrip) {
                                m.Result = new IntPtr(HTTOPLEFT);
                            }
                            else if (pt.X > this.Width - ScaleGrip && pt.Y < ScaleGrip) {
                                m.Result = new IntPtr(HTTOPRIGHT);
                            }
                            else if (pt.Y < ScaleGrip) {
                                m.Result = new IntPtr(HTTOP);
                            }
                            else if (pt.X < ScaleGrip && pt.Y > this.Height - ScaleGrip) {
                                m.Result = new IntPtr(HTBOTTOMLEFT);
                            }
                            else if (pt.X > this.Width - ScaleGrip && pt.Y > this.Height - ScaleGrip) {
                                m.Result = new IntPtr(HTBOTTOMRIGHT);
                            }
                            else if (pt.Y > this.Height - ScaleGrip) {
                                m.Result = new IntPtr(HTBOTTOM);
                            }
                            else if (pt.X < ScaleGrip) {
                                m.Result = new IntPtr(HTLEFT);
                            }
                            else if (pt.X > this.Width - ScaleGrip) {
                                m.Result = new IntPtr(HTRIGHT);
                            }
                            else {
                                base.WndProc(ref m);
                            }
                            if (CloseMarker.Contains(pt) == false) {
                                if (m.Result == (IntPtr)HTCLIENT) {
                                    m.Result = (IntPtr)HTCAPTION;
                                }
                                if (CloseMarker_MouseInRegion == true) {
                                    CloseMarker_MouseInRegion = false;
                                    Invalidate();
                                }
                            }

                            break;
                        }

                    default:
                        break;
                }
            }
            catch { }
        }
        //public MdiClientPanel MyMdiContainer { get; set; }
        public SnapshotClient MyMdiContainer { get; set; }
        public MdiClientForm() {
            iD = Guid.NewGuid().ToString();
            labelFont = new Font(Font.FontFamily, 8);
            Activated += OnFormActivated;
            FormClosed += OnFormClosed;

        }



        string iD = "";
        [Browsable(false)]
        public string ID {
            get { return iD; }
        }
        public event CloseButtonClickedHandler? CloseButtonClicked;
        public delegate void CloseButtonClickedHandler(object sender);
        void OnFormClosed(object? sender, FormClosedEventArgs e) {
            //MyMdiContainer.ChildClosed(this);
            MyMdiContainer.CloseForm(this);
            Activated -= OnFormActivated;
            FormClosed -= OnFormClosed;
        }
        private void OnFormActivated(object? sender, EventArgs e) {
            //MyMdiContainer.ChildActivated(this);
        }

        private void MdiClientForm_Load(object ?sender, EventArgs e) {

        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // MdiClientForm
            // 
            this.ClientSize = new System.Drawing.Size(228, 219);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MdiClientForm";
            this.Load += new System.EventHandler(this.MdiClientForm_Load_1);
            this.ResumeLayout(false);

        }


        private void MdiClientForm_Load_1(object ?sender, EventArgs e) {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e) {
            Invalidate();
            base.OnResize(e);
        }

        private bool closeButtonCloses = true;
        [System.ComponentModel.Category("Control")]
        public bool CloseButtonCloses {
            get {
                return closeButtonCloses;
            }
            set {
                closeButtonCloses = value;
            }
        }
        private Color borderColor = Color.Gray;
        [System.ComponentModel.Category("Appearance")]
        public Color BorderColor {
            get {
                return borderColor;
            }
            set {
                borderColor = value;
                Invalidate();
            }
        }
        private Color closeColor = Color.Black;
        [System.ComponentModel.Category("Appearance")]
        public Color CloseColor {
            get {
                return closeColor;
            }
            set {
                closeColor = value;
                Invalidate();
            }
        }
        private Color closeMouseOverColor = Color.Red;
        [System.ComponentModel.Category("Appearance")]
        public Color CloseMouseOverColor {
            get {
                return closeMouseOverColor;
            }
            set {
                closeMouseOverColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        public override string Text {
            get {
                return base.Text;
            }
            set {
                base.Text = value;
                PaddingSettingChanged = true;
                Invalidate();
            }
        }
        bool PaddingSettingChanged = true;
        private Font labelFont;
        [System.ComponentModel.Category("Appearance")]
        public Font LabelFont {
            get {
                return labelFont;
            }
            set {
                labelFont = value;
                PaddingSettingChanged = true;
                Invalidate();
            }
        }
        private Color labelColor = Color.Black;
        [System.ComponentModel.Category("Appearance")]
        public Color LabelForeColor {
            get {
                return labelColor;
            }
            set {
                labelColor = value;
                Invalidate();
            }
        }

        float TextPadding = 10;
        int TextHeight = 20;
        //int BasicTextSize = 10;
        SizeF UnitSize;
        Rectangle CloseMarker;
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            using (Font UnitFont = new Font(this.Font.FontFamily, 6.0f)) {
                UnitSize = e.Graphics.MeasureString("W", UnitFont);
            }
            if (PaddingSettingChanged == true) {
                TextPadding = e.Graphics.MeasureString("W", labelFont).Width;
                TextHeight = (int)e.Graphics.MeasureString("W", labelFont).Height + (int)(TextPadding / 4.0f);

                Padding Pad = new Padding(Padding.Left, TextHeight, Padding.Right, Padding.Bottom);
                Padding = Pad;
                PaddingSettingChanged = false;
            }
            //using (SolidBrush BackColorBrush = new SolidBrush(labelBackColor)) {
            //    e.Graphics.FillRectangle(BackColorBrush, new Rectangle(0, 0, Width, TextHeight));
            //}
            DrawActionButtons(e);
            if (Text.Length > 0) {
                using (SolidBrush ForeColorBrush = new SolidBrush(labelColor)) {
                    e.Graphics.DrawString(Text, labelFont, ForeColorBrush, new Point((int)(TextPadding / 4.0f), (int)(TextPadding / 4.0f)));
                }
            }
            using (SolidBrush BrdBr = new SolidBrush(BorderColor)) {
                using (Pen BrdPn = new Pen(BrdBr)) {
                    e.Graphics.DrawRectangle(BrdPn, new Rectangle(0, 0, Width - 1, Height - 1));
                }
            }
            base.OnPaint(e);
        }

        private void DrawActionButtons(PaintEventArgs e) {
            Size ButtonSize = new Size((int)UnitSize.Height, (int)UnitSize.Height);



            int CollaspeOffset = 0;
            int CloseSmall = (int)(UnitSize.Height * 0.8f);
            Point CloseButtonPosition = new Point(Width - (int)(UnitSize.Width * 1.8) - CollaspeOffset, (int)(TextPadding / 4.0f) + (int)((TextHeight - CloseSmall) / 2.0f));
            CloseMarker = new Rectangle(CloseButtonPosition, new Size(CloseSmall, CloseSmall));
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Color collapseCloseColor = closeColor;
            if (CloseMarker_MouseInRegion == true) {
                collapseCloseColor = closeMouseOverColor;
            }
            using (SolidBrush ActionBrush = new SolidBrush(collapseCloseColor)) {
                using (Pen ActionPen = new Pen(ActionBrush, 1)) {
                    e.Graphics.DrawLine(ActionPen, new Point(CloseMarker.X, CloseMarker.Y), new Point(CloseMarker.X + CloseMarker.Width, CloseMarker.Y + CloseMarker.Height));
                    e.Graphics.DrawLine(ActionPen, new Point(CloseMarker.X, CloseMarker.Y + CloseMarker.Height), new Point(CloseMarker.X + CloseMarker.Width, CloseMarker.Y));
                }
            }
            CollaspeOffset = (int)(ButtonSize.Width * 1.8f);
        }

        bool CloseMarker_MouseInRegion = false;
        protected override void OnMouseClick(MouseEventArgs e) {
            if (CloseMarker.Contains(e.Location)) {
                if (closeButtonCloses) {
                    this.Close();
                }
                else {
                    CloseButtonClicked?.Invoke(this);
                }
            }
            base.OnMouseClick(e);
        }
        protected override void OnMouseMove(MouseEventArgs e) {

            //bool HitButton = false;
            if (CloseMarker.Contains(e.Location)) {
                CloseMarker_MouseInRegion = true;
               // HitButton = true;
            }
            else {
                CloseMarker_MouseInRegion = false;
            }
            Invalidate();
            //CurrentLocation = Cursor.Position;
            base.OnMouseMove(e);
        }
    }
}
