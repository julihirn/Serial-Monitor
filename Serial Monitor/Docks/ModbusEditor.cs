using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.Docks {
    [ToolboxItem(true)]
    public partial class ModbusEditor : ODModules.Docking.DockDocument {
        public ModbusEditor() {
            InitializeComponent();
        }
        protected override CreateParams CreateParams {
            get {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        //private Color borderColor = Color.Gray;
        //[System.ComponentModel.Category("Appearance")]
        //public Color BorderColor {
        //    get {
        //        return borderColor;
        //    }
        //    set {
        //        borderColor = value;
        //        Invalidate();
        //    }
        //}
        private void ModbusEditor_Load(object sender, EventArgs e) {

        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

        }

        private void thDataPagesHeader_Load(object sender, EventArgs e) {

        }

        //private void pnlInset_Resize(object sender, EventArgs e) {
        //    pnlInset.Invalidate();
        //}

        //private void pnlInset_Paint(object sender, PaintEventArgs e) {
        //    using (SolidBrush brush = new SolidBrush(borderColor)) {
        //        using (Pen Pn = new Pen(brush)) {
        //            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, Width - 1, Height - 1));
        //        }
        //    }
        //}

        //private void thDataPagesHeader_Load(object sender, EventArgs e) {

        //}
    }
}
