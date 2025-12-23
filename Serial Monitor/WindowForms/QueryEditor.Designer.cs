namespace Serial_Monitor.WindowForms {
    partial class QueryEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryEditor));
            msMain = new ODModules.MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            printToolStripMenuItem = new ToolStripMenuItem();
            printPreviewToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            queryToolStripMenuItem = new ToolStripMenuItem();
            executeToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            customizeToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            tsMain = new ODModules.ToolStrip();
            btnNew = new ToolStripButton();
            btnOpen = new ToolStripButton();
            btnSave = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            btnExecute = new ToolStripButton();
            fctEditor = new FastColoredTextBoxNS.FastColoredTextBox();
            dmpScroll = new FastColoredTextBoxNS.DocumentMap();
            tscMain = new ToolStripContainer();
            msMain.SuspendLayout();
            tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fctEditor).BeginInit();
            tscMain.ContentPanel.SuspendLayout();
            tscMain.TopToolStripPanel.SuspendLayout();
            tscMain.SuspendLayout();
            SuspendLayout();
            // 
            // msMain
            // 
            msMain.BackColorNorth = Color.DodgerBlue;
            msMain.BackColorNorthFadeIn = Color.DodgerBlue;
            msMain.BackColorSouth = Color.DodgerBlue;
            msMain.Fade = true;
            msMain.ImageScalingSize = new Size(32, 32);
            msMain.ItemForeColor = Color.Black;
            msMain.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, queryToolStripMenuItem, toolsToolStripMenuItem });
            msMain.ItemSelectedBackColorNorth = Color.White;
            msMain.ItemSelectedBackColorSouth = Color.White;
            msMain.ItemSelectedForeColor = Color.Black;
            msMain.Location = new Point(0, 0);
            msMain.MenuBackColorNorth = Color.DodgerBlue;
            msMain.MenuBackColorSouth = Color.DodgerBlue;
            msMain.MenuBorderColor = Color.WhiteSmoke;
            msMain.MenuSeparatorColor = Color.WhiteSmoke;
            msMain.MenuSymbolColor = Color.WhiteSmoke;
            msMain.Name = "msMain";
            msMain.Padding = new Padding(11, 4, 0, 4);
            msMain.Size = new Size(899, 44);
            msMain.StripItemSelectedBackColorNorth = Color.White;
            msMain.StripItemSelectedBackColorSouth = Color.White;
            msMain.TabIndex = 0;
            msMain.Text = "menuStrip1";
            msMain.UseNorthFadeIn = false;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, printToolStripMenuItem, printPreviewToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = Color.Black;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 36);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.ForeColor = Color.Black;
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            newToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(291, 44);
            newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.ForeColor = Color.Black;
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(291, 44);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(288, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.ForeColor = Color.Black;
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(291, 44);
            saveToolStripMenuItem.Text = "&Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.ForeColor = Color.Black;
            saveAsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(291, 44);
            saveAsToolStripMenuItem.Text = "Save &As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(288, 6);
            toolStripSeparator1.Visible = false;
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.ForeColor = Color.Black;
            printToolStripMenuItem.Image = (Image)resources.GetObject("printToolStripMenuItem.Image");
            printToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            printToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.Size = new Size(291, 44);
            printToolStripMenuItem.Text = "&Print";
            printToolStripMenuItem.Visible = false;
            // 
            // printPreviewToolStripMenuItem
            // 
            printPreviewToolStripMenuItem.ForeColor = Color.Black;
            printPreviewToolStripMenuItem.Image = (Image)resources.GetObject("printPreviewToolStripMenuItem.Image");
            printPreviewToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            printPreviewToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            printPreviewToolStripMenuItem.Size = new Size(291, 44);
            printPreviewToolStripMenuItem.Text = "Print Pre&view";
            printPreviewToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(288, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.ForeColor = Color.Black;
            exitToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(291, 44);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator3, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator4, selectAllToolStripMenuItem });
            editToolStripMenuItem.ForeColor = Color.Black;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(74, 36);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.ForeColor = Color.Black;
            undoToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(327, 44);
            undoToolStripMenuItem.Text = "&Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.ForeColor = Color.Black;
            redoToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            redoToolStripMenuItem.Size = new Size(327, 44);
            redoToolStripMenuItem.Text = "&Redo";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(324, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.ForeColor = Color.Black;
            cutToolStripMenuItem.Image = (Image)resources.GetObject("cutToolStripMenuItem.Image");
            cutToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            cutToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(327, 44);
            cutToolStripMenuItem.Text = "Cu&t";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ForeColor = Color.Black;
            copyToolStripMenuItem.Image = (Image)resources.GetObject("copyToolStripMenuItem.Image");
            copyToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            copyToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(327, 44);
            copyToolStripMenuItem.Text = "&Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ForeColor = Color.Black;
            pasteToolStripMenuItem.Image = (Image)resources.GetObject("pasteToolStripMenuItem.Image");
            pasteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            pasteToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(327, 44);
            pasteToolStripMenuItem.Text = "&Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(324, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.ForeColor = Color.Black;
            selectAllToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllToolStripMenuItem.Size = new Size(327, 44);
            selectAllToolStripMenuItem.Text = "Select &All";
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            // 
            // queryToolStripMenuItem
            // 
            queryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { executeToolStripMenuItem });
            queryToolStripMenuItem.ForeColor = Color.Black;
            queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            queryToolStripMenuItem.Size = new Size(99, 36);
            queryToolStripMenuItem.Text = "&Query";
            // 
            // executeToolStripMenuItem
            // 
            executeToolStripMenuItem.ForeColor = Color.Black;
            executeToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            executeToolStripMenuItem.ShortcutKeys = Keys.F5;
            executeToolStripMenuItem.Size = new Size(268, 44);
            executeToolStripMenuItem.Text = "&Execute";
            executeToolStripMenuItem.Click += executeToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customizeToolStripMenuItem, optionsToolStripMenuItem });
            toolsToolStripMenuItem.ForeColor = Color.Black;
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(89, 36);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.ForeColor = Color.Black;
            customizeToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new Size(304, 44);
            customizeToolStripMenuItem.Text = "&Customize";
            customizeToolStripMenuItem.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.ForeColor = Color.Black;
            optionsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            optionsToolStripMenuItem.Size = new Size(304, 44);
            optionsToolStripMenuItem.Text = "&Options";
            optionsToolStripMenuItem.Click += optionsToolStripMenuItem_Click;
            // 
            // tsMain
            // 
            tsMain.BackColorNorth = Color.DodgerBlue;
            tsMain.BackColorSouth = Color.DodgerBlue;
            tsMain.BorderColor = Color.WhiteSmoke;
            tsMain.Dock = DockStyle.None;
            tsMain.GripColor = Color.WhiteSmoke;
            tsMain.ImageScalingSize = new Size(32, 32);
            tsMain.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemForeColor = Color.Black;
            tsMain.Items.AddRange(new ToolStripItem[] { btnNew, btnOpen, btnSave, toolStripSeparator5, btnExecute });
            tsMain.ItemSelectedBackColorNorth = Color.White;
            tsMain.ItemSelectedBackColorSouth = Color.White;
            tsMain.ItemSelectedForeColor = Color.Black;
            tsMain.Location = new Point(7, 0);
            tsMain.MenuBackColorNorth = Color.DodgerBlue;
            tsMain.MenuBackColorSouth = Color.DodgerBlue;
            tsMain.MenuBorderColor = Color.WhiteSmoke;
            tsMain.MenuSeparatorColor = Color.WhiteSmoke;
            tsMain.MenuSymbolColor = Color.WhiteSmoke;
            tsMain.Name = "tsMain";
            tsMain.Padding = new Padding(0);
            tsMain.RoundedToolStrip = true;
            tsMain.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            tsMain.ShowBorder = true;
            tsMain.ShowShadow = true;
            tsMain.Size = new Size(292, 54);
            tsMain.StripItemSelectedBackColorNorth = Color.White;
            tsMain.StripItemSelectedBackColorSouth = Color.White;
            tsMain.TabIndex = 1;
            tsMain.Text = "toolStrip1";
            // 
            // btnNew
            // 
            btnNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.ImageScaling = ToolStripItemImageScaling.None;
            btnNew.ImageTransparentColor = Color.Magenta;
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(46, 36);
            btnNew.Text = "New";
            btnNew.Click += btnNew_Click;
            // 
            // btnOpen
            // 
            btnOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOpen.Image = (Image)resources.GetObject("btnOpen.Image");
            btnOpen.ImageScaling = ToolStripItemImageScaling.None;
            btnOpen.ImageTransparentColor = Color.Magenta;
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(46, 36);
            btnOpen.Text = "Open";
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSave
            // 
            btnSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageScaling = ToolStripItemImageScaling.None;
            btnSave.ImageTransparentColor = Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(46, 36);
            btnSave.Text = "toolStripButton3";
            btnSave.ToolTipText = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 42);
            // 
            // btnExecute
            // 
            btnExecute.Image = (Image)resources.GetObject("btnExecute.Image");
            btnExecute.ImageScaling = ToolStripItemImageScaling.None;
            btnExecute.ImageTransparentColor = Color.Magenta;
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(116, 36);
            btnExecute.Text = "Execute";
            btnExecute.Click += btnExecute_Click;
            // 
            // fctEditor
            // 
            fctEditor.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            fctEditor.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);";
            fctEditor.AutoScrollMinSize = new Size(347, 203);
            fctEditor.BackBrush = null;
            fctEditor.BackColor = SystemColors.Window;
            fctEditor.CharHeight = 29;
            fctEditor.CharWidth = 16;
            fctEditor.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fctEditor.Dock = DockStyle.Fill;
            fctEditor.Hotkeys = resources.GetString("fctEditor.Hotkeys");
            fctEditor.IndentBackColor = Color.LightGray;
            fctEditor.IsReplaceMode = false;
            fctEditor.LineNumberColor = Color.FromArgb(64, 64, 64);
            fctEditor.Location = new Point(0, 0);
            fctEditor.Margin = new Padding(6, 6, 6, 6);
            fctEditor.Name = "fctEditor";
            fctEditor.Paddings = new Padding(0);
            fctEditor.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            fctEditor.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("fctEditor.ServiceColors");
            fctEditor.ServiceLinesColor = Color.Gray;
            fctEditor.ShowScrollBars = false;
            fctEditor.Size = new Size(899, 672);
            fctEditor.TabIndex = 2;
            fctEditor.Text = "BEGIN\r\n    USING COM1\r\n    UNIT 1\r\n    WRITE REGISTERS\r\n    FROM 1\r\n    WITH 1, 2, 3\r\nEND";
            fctEditor.Zoom = 100;
            fctEditor.TextChanged += fctEditor_TextChanged;
            fctEditor.Load += fctEditor_Load;
            // 
            // dmpScroll
            // 
            dmpScroll.BackColor = Color.FromArgb(224, 224, 224);
            dmpScroll.Dock = DockStyle.Right;
            dmpScroll.ForeColor = Color.DarkGray;
            dmpScroll.Location = new Point(739, 0);
            dmpScroll.Margin = new Padding(6, 6, 6, 6);
            dmpScroll.Name = "dmpScroll";
            dmpScroll.Size = new Size(160, 672);
            dmpScroll.TabIndex = 3;
            dmpScroll.Target = fctEditor;
            dmpScroll.Text = "documentMap1";
            // 
            // tscMain
            // 
            // 
            // tscMain.ContentPanel
            // 
            tscMain.ContentPanel.Controls.Add(dmpScroll);
            tscMain.ContentPanel.Controls.Add(fctEditor);
            tscMain.ContentPanel.Size = new Size(899, 672);
            tscMain.Dock = DockStyle.Fill;
            tscMain.Location = new Point(0, 44);
            tscMain.Name = "tscMain";
            tscMain.Size = new Size(899, 726);
            tscMain.TabIndex = 4;
            tscMain.Text = "toolStripContainer1";
            // 
            // tscMain.TopToolStripPanel
            // 
            tscMain.TopToolStripPanel.Controls.Add(tsMain);
            // 
            // QueryEditor
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(899, 770);
            Controls.Add(tscMain);
            Controls.Add(msMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msMain;
            Margin = new Padding(6, 6, 6, 6);
            Name = "QueryEditor";
            Text = "Untitled - Query Editor";
            Load += QueryEditor_Load;
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fctEditor).EndInit();
            tscMain.ContentPanel.ResumeLayout(false);
            tscMain.TopToolStripPanel.ResumeLayout(false);
            tscMain.TopToolStripPanel.PerformLayout();
            tscMain.ResumeLayout(false);
            tscMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ODModules.ToolStrip tsMain;
        private FastColoredTextBoxNS.FastColoredTextBox fctEditor;
        private FastColoredTextBoxNS.DocumentMap dmpScroll;
        private ToolStripButton btnExecute;
        private ToolStripMenuItem queryToolStripMenuItem;
        private ToolStripMenuItem executeToolStripMenuItem;
        private ToolStripButton btnNew;
        private ToolStripButton btnOpen;
        private ToolStripButton btnSave;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripContainer tscMain;
    }
}