using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ODModules;
using Serial_Monitor.Classes.Theming;
using Serial_Monitor.Interfaces;
namespace Serial_Monitor.Components {
    public partial class AppearancePopup : TemplateContextMenu, Interfaces.ITheme {
        public AppearancePopup() {
            InitializeComponent();
            tcPages.DebugMode = false;
            ApplyTheme();
        }
        public void ApplyTheme() {
            ThemeManager.ThemeControl(thSettings);
            ThemeManager.ThemeControl(tcPages);
            ThemeManager.ThemeControl(psMainScaler);
            ThemeManager.ThemeControl(tbUnit);
            lblpnlUnit.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
        }

        protected override void OnValidated(EventArgs e) {
            base.OnValidated(e);
        }

        protected override void OnValidating(CancelEventArgs e) {
            //ApplyTheme();
            base.OnValidating(e);
        }

        protected override void OnVisibleChanged(EventArgs e) {
            ApplyTheme();
            base.OnVisibleChanged(e);
        }

        private void textBox1__TextChanged(object sender, EventArgs e) {
            ntbTemplate.Unit = tbUnit.Text;
            psMainScaler.Invalidate();
        }
    }
}
