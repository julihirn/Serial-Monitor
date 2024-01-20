using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Handlers;
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

            ThemeManager.ThemeControl(cbxFore);
            ThemeManager.ThemeControl(cbxBack);

            ThemeManager.ThemeControl(label1);
            ThemeManager.ThemeControl(label2);

            ApplyThemeButton(btnBack);
            ApplyThemeButton(btnFore);
            lblpnlUnit.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
        }
        private void ApplyThemeButton(ODModules.Button btn) {
            btn.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            btn.BackColorDownNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            btn.BackColorDownSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            btn.BorderColorNorth = Properties.Settings.Default.THM_COL_BorderColor;
            btn.BorderColorSouth = Properties.Settings.Default.THM_COL_BorderColor;
            btn.BorderColorDownNorth = Properties.Settings.Default.THM_COL_BorderColor;
            btn.BorderColorDownSouth = Properties.Settings.Default.THM_COL_BorderColor;
        }
        ODModules.ListControl? lstControl = null;
        public ODModules.ListControl? LinkedList {
            get { return lstControl; }
            set {
                lstControl = null;
                lstControl = value;
            }
        }
        Color itemForeColor = Color.Black;
        public Color ItemForeColor {
            get { return itemForeColor; }
            set { itemForeColor = value; }
        }
        Color itemBackColor = Color.White;
        public Color ItemBackColor {
            get { return itemBackColor; }
            set { itemBackColor = value; }
        }
        public bool UseItemForeColor {
            get { return cbxFore.Checked; }
            set { cbxFore.Checked = value; }
        }
        public bool UseItemBackColor {
            get { return cbxBack.Checked; }
            set { cbxBack.Checked = value; }
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

        private void thSettings_Load(object sender, EventArgs e) {

        }

        private void cwMain_ColorChanged(object sender, EventArgs e) {
            ColorChanged();
        }
        private void ColorChanged() {
            if (IgnoreChanges) { return; }
            if (CurrentEditorBack) {
                btnBack.BackColorSouth = cwMain.HslColor.ToRgbColor();
                btnBack.BackColorNorth = cwMain.HslColor.ToRgbColor();
                itemBackColor = cwMain.HslColor.ToRgbColor();
            }
            else {
                btnFore.BackColorSouth = cwMain.HslColor.ToRgbColor();
                btnFore.BackColorNorth = cwMain.HslColor.ToRgbColor();
                itemForeColor = cwMain.HslColor.ToRgbColor();
            }
        }
        bool CurrentEditorBack = true;
        bool IgnoreChanges = false;
        private void btnFore_Load(object sender, EventArgs e) {

        }
        private void btnBack_Load(object sender, EventArgs e) {

        }
        private void btnFore_ButtonClicked(object sender) {
            IgnoreChanges = true;
            CurrentEditorBack = false;
            cwMain.Color = itemForeColor;
            lcsBrightness.Value = (int)(100.0f * new HSV(itemForeColor).B);
            IgnoreChanges = false;
        }
        private void btnBack_ButtonClicked(object sender) {
            IgnoreChanges = true;
            CurrentEditorBack = true;
            cwMain.Color = itemBackColor;
            lcsBrightness.Value = (int)(100.0f * new HSV(ItemBackColor).B);
            IgnoreChanges = false;
        }

        private void lcsBrightness_ValueChanged(object sender, EventArgs e) {
            cwMain.Lightness = (double)lcsBrightness.Value / 100.0f;
        }
        private void cwMain_LightnessChanged(object sender, EventArgs e) {
            ColorChanged();
        }
    }
}
