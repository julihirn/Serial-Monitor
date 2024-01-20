using FastColoredTextBoxNS;
using Microsoft.VisualBasic.Devices;
using ODModules;
using Serial_Monitor.Interfaces;
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
using static System.Windows.Forms.DataFormats;

namespace Serial_Monitor.WindowForms {
    public partial class QueryEditor : Form, ITheme {
        public QueryEditor() {
            InitializeComponent();
        }
        protected override CreateParams CreateParams {
            get {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        private void QueryEditor_Load(object sender, EventArgs e) {
            RecolorAll();
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
            AdjustUserInterface();
        }
        private void AdjustUserInterface() {
            msMain.Padding = DesignerSetup.ScalePadding(msMain.Padding);
            tsMain.Padding = DesignerSetup.ScalePadding(tsMain.Padding);
        
        }
        public void ApplyTheme() {
            RecolorAll();
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.Add, btnAdd, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
        }
        private void RecolorAll() {
            this.SuspendLayout();
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(tsMain);
            Classes.Theming.ThemeManager.ThemeControl(tsMain);
            Classes.Theming.ThemeManager.ThemeControl(fctEditor);
            Classes.Theming.ThemeManager.ThemeControl(dmpScroll);
            SetBrush(Comment, Properties.Settings.Default.THM_COL_CommentColor);
            SetBrush(KeyWord, Properties.Settings.Default.THM_COL_KeyWordColor);
            SetBrush(Numeric, Properties.Settings.Default.THM_COL_VariablesColor);

            this.ResumeLayout();
        }
        private void SetBrush(TextStyle Style, Color SetColor) {
            //using (SolidBrush Br = new SolidBrush(SetColor)) {
            Style.ForeBrush = new SolidBrush(SetColor);
            //}
        }
        private void fctEditor_Load(object sender, EventArgs e) {

        }
        TextStyle Comment = new TextStyle(Brushes.Lime, null, FontStyle.Regular);
        TextStyle KeyWord = new TextStyle(Brushes.DeepSkyBlue, null, FontStyle.Regular);
        TextStyle String = new TextStyle(Brushes.Tomato, null, FontStyle.Regular);
        TextStyle Numeric = new TextStyle(Brushes.Moccasin, null, FontStyle.Regular);
        //TextStyle Special = new TextStyle(Brushes.Teal, null, FontStyle.Regular);
        // TextStyle Headers = new TextStyle(Brushes.Plum, null, FontStyle.Regular);
        private void fctEditor_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
            e.ChangedRange.ClearStyle(Comment);
            e.ChangedRange.ClearStyle(KeyWord);
            e.ChangedRange.ClearStyle(String);
            e.ChangedRange.ClearStyle(Numeric);
            //e.ChangedRange.ClearStyle(Special);
            //e.ChangedRange.ClearStyle(Headers);
            //highlight tags

            e.ChangedRange.SetStyle(KeyWord, @"(?<!--.*)(?:\b((?i:unit)|(?i:write)|(?i:read)|(?i:register)|(?i:coil)|(?i:registers)|(?i:coils)|(?i:from)|(?i:with)|(?i:qty)|(?i:diagnostics)|(?i:query)|(?i:bus)|(?i:slave)|(?i:clear)|(?i:counters)|(?i:overrun)|(?i:restart)|(?i:force)|(?i:set)|(?i:delimiter)|(?i:discrete)|(?i:inregisters)|(?i:true)|(?i:false)|(?i:to))\b)");
            //e.ChangedRange.SetStyle(Headers, @"(?<!--.*)(?:\b((?i:begin)|(?i:create lines)))");
            e.ChangedRange.SetStyle(String, "(?<!--.*)(?:(\").+(\"))");
            //e.ChangedRange.SetStyle(Special, @"(?<!--.*)(?:\bE\(\w+\)\B)|(?:\be\(\w+\)\B)|(?:\bA\(\w+\)\B)|(?:\ba\(\w+\)\B)");
            e.ChangedRange.SetStyle(Comment, "(--).+");//" <[^>]+>");
            e.ChangedRange.ClearFoldingMarkers();
            e.ChangedRange.SetFoldingMarkers("(?<!--.*)(?:{|(?i:create lines))", "(?<!--.*)(?:})");
        }
    }
}
