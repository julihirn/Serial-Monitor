using ODModules;
using Serial_Monitor.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.Dialogs {
    public partial class SendFile : SkinnedForm, Interfaces.ITheme {
        public SendFile() {
            InitializeComponent();
        }

        private void SendFile_Load(object sender, EventArgs e) {
            ApplyTheme();
        }
        public void ApplyTheme() {
            RecolorAll();
            AddIcons();
        }
        private void AddIcons() {
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.Cut, cmiTextBoxCut, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.Copy, cmiTextBoxCopy, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.Paste, cmiTextBoxPaste, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.Cancel, cmiTextBoxDelete, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.SelectAll, cmiTextBoxSelectAll, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
        }
        private void RecolorAll() {
            this.SuspendLayout();
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            TitleBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            TitleForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            InactiveBorderColor = Properties.Settings.Default.THM_COL_MenuBack;
            ActiveBorderColor = Properties.Settings.Default.THM_COL_SelectedColor;
            //Classes.Theming.ThemeManager.ThemeControl(lblpnlAddress);
           
            this.ResumeLayout();
        }
    }
}
