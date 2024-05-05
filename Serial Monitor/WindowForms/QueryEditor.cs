using FastColoredTextBoxNS;
using Handlers;
using Microsoft.VisualBasic.Devices;
using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Modbus;
using Serial_Monitor.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.IO;
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
            ApplyIcons();
        }
        private void AdjustUserInterface() {
            msMain.Padding = DesignerSetup.ScalePadding(msMain.Padding);
            tsMain.Padding = DesignerSetup.ScalePadding(tsMain.Padding);

        }
        public void ApplyTheme() {
            RecolorAll();
            ApplyIcons();
        }
        private void ApplyIcons() {
            DesignerSetup.LinkSVGtoControl(Properties.Resources.NewTreeQuery, newToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.OpenFile_16x, openToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Save_16x, saveToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.NewTreeQuery, btnNew, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.OpenFile_16x, btnOpen, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Save_16x, btnSave, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.UndoNoColor, undoToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Redo, redoToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Copy, copyToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Paste, pasteToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Cut, cutToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.SelectAll, selectAllToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Settings_16x, optionsToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));

            DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, executeToolStripMenuItem, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, btnExecute, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
        }
        private void RecolorAll() {
            this.SuspendLayout();
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            Classes.Theming.ThemeManager.ThemeControl(msMain);
            Classes.Theming.ThemeManager.ThemeControl(tsMain);
            Classes.Theming.ThemeManager.ThemeControl(fctEditor);
            Classes.Theming.ThemeManager.ThemeControl(dmpScroll);
            SetBrush(Comment, Properties.Settings.Default.THM_COL_CommentColor);
            SetBrush(KeyWord, Properties.Settings.Default.THM_COL_KeyWordColor);
            SetBrush(Numeric, Properties.Settings.Default.THM_COL_VariablesColor);
            SetBrush(Headers, Properties.Settings.Default.THM_COL_ReturnsAndCalls);

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
        TextStyle Headers = new TextStyle(Brushes.Plum, null, FontStyle.Regular);
        private void fctEditor_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e) {
            e.ChangedRange.ClearStyle(Comment);
            e.ChangedRange.ClearStyle(KeyWord);
            e.ChangedRange.ClearStyle(String);
            e.ChangedRange.ClearStyle(Numeric);
            //e.ChangedRange.ClearStyle(Special);
            //e.ChangedRange.ClearStyle(Headers);
            //highlight tags
            e.ChangedRange.SetStyle(Headers, @"(?<!--.*)(?:\b((?i:begin)|(?i:end))\b)");
            e.ChangedRange.SetStyle(KeyWord, @"(?<!--.*)(?:\b((?i:using)|(?i:declare)|(?i:as)|(?i:master)|(?i:unit)|(?i:write)|(?i:read)|(?i:register)|(?i:coil)|(?i:registers)|(?i:coils)|(?i:from)|(?i:with)|(?i:qty)|(?i:diagnostics)|(?i:query)|(?i:bus)|(?i:slave)|(?i:clear)|(?i:counters)|(?i:overrun)|(?i:restart)|(?i:force)|(?i:set)|(?i:delimiter)|(?i:discrete)|(?i:inregisters)|(?i:inregister)|(?i:holding)|(?i:holdings)|(?i:input)|(?i:inputs)|(?i:return)|(?i:true)|(?i:false)|(?i:to))\b)");
            //e.ChangedRange.SetStyle(Headers, @"(?<!--.*)(?:\b((?i:begin)|(?i:create lines)))");
            e.ChangedRange.SetStyle(String, "(?<!--.*)(?:(\").+(\"))");
            //e.ChangedRange.SetStyle(Special, @"(?<!--.*)(?:\bE\(\w+\)\B)|(?:\be\(\w+\)\B)|(?:\bA\(\w+\)\B)|(?:\ba\(\w+\)\B)");
            e.ChangedRange.SetStyle(Comment, "(--).+");//" <[^>]+>");
            e.ChangedRange.ClearFoldingMarkers();
            e.ChangedRange.SetFoldingMarkers("(?<!--.*)(?:{|(?i:begin))", "(?<!--.*)(?:})");
        }
        private void executeToolStripMenuItem_Click(object sender, EventArgs e) {
            ModbusQuery.ExecuteQuery(fctEditor.Text);
        }
        private void btnExecute_Click(object sender, EventArgs e) {
            ModbusQuery.ExecuteQuery(fctEditor.Text);
        }
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings ConfigApp = new Settings();
            ApplicationManager.OpenInternalApplicationOnce(ConfigApp, true);
        }
        #region Document Handling
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            Save();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            Save(true);
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            Open();
        }
        bool documentEdited = false;
        private bool DocumentEdited {
            get { return documentEdited; }
            set {
                documentEdited = value;
                if (CurrentDocument.Trim(' ') == "") {
                    SetTitle("Untitled");
                }
                else {
                    SetTitle(Path.GetFileNameWithoutExtension(CurrentDocument));
                }
            }
        }
        private void Open() {
            OpenFileDialog OpenDia = new OpenFileDialog();
            OpenDia.Filter = @"Modbus Query (*.mbq)|*.mbq";
            if (OpenDia.ShowDialog() == DialogResult.OK) {
                if (File.Exists(OpenDia.FileName)) {
                    try {
                        fctEditor.Clear();
                        using (System.IO.StreamReader FileRead = System.IO.File.OpenText(OpenDia.FileName)) {
                            while (FileRead.Peek() > -1) {
                                fctEditor.Text += FileRead.ReadLine() + Constants.NewLineEnv;
                            }
                        }
                        CurrentDocument = OpenDia.FileName;
                        DocumentEdited = false;
                    }
                    catch { }
                }
            }
        }
        string CurrentDocument = "";
        public void Save(bool SaveAs = false) {
            bool IsExistingFile = false;
            if (CurrentDocument.Trim(' ') != "") {
                if (File.Exists(CurrentDocument)) {
                    IsExistingFile = true;
                }
            }
            if (SaveAs == true) { IsExistingFile = false; }

            if (IsExistingFile == false) {
                SaveFileDialog Save = new SaveFileDialog();
                Save.Filter = @"Modbus Query (*.mbq)|*.mbq";
                Save.ShowDialog();
                if (Save.FileName != "") {
                    SetTitle(Path.GetFileNameWithoutExtension(Save.FileName));
                    WriteFile(Save.FileName);
                    CurrentDocument = Save.FileName;
                }
            }
            else {
                WriteFile(CurrentDocument);
                DocumentEdited = false;
            }
            //if (CurrentDocument.Trim(' ') == "") {
            //    btnOpenLocation.Enabled = false;
            //}
            //else {
            //    btnOpenLocation.Enabled = true;
            //}
            //AddFiletoRecentFiles(CurrentDocument);
        }
        private void WriteFile(string FileAddress) {
            using (StreamWriter Sw = new StreamWriter(FileAddress)) {
                foreach (string str in fctEditor.Lines) {
                    Sw.WriteLine(str);
                }
            }
        }
        #endregion
        private void SetTitle(string DocumentName) {
            if (documentEdited == true) {
                this.Text = "*" + DocumentName + " - " + "Query Editor";
            }
            else {
                this.Text = DocumentName + " - " + "Query Editor";
            }
        }
        #region Clipboard
        private void cutToolStripMenuItem_Click(object sender, EventArgs e) {
            fctEditor.Cut();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e) {
            fctEditor.Undo();
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e) {
            fctEditor.Redo();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) {
            fctEditor.Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) {
            fctEditor.Paste();
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) {
            fctEditor.SelectAll();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }
        #endregion


        private void btnNew_Click(object sender, EventArgs e) {

        }
        private void btnOpen_Click(object sender, EventArgs e) {
            Open();
        }
        private void btnSave_Click(object sender, EventArgs e) {
            Save();
        }
    }
}
