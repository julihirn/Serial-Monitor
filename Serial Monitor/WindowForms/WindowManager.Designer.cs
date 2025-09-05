namespace Serial_Monitor.WindowForms {
    partial class WindowManager {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowManager));
            msMain = new ODModules.MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            btnFileRun = new ToolStripMenuItem();
            btnFileExit = new ToolStripMenuItem();
            windowToolStripMenuItem = new ToolStripMenuItem();
            btnWinRefresh = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            btnWinMinimise = new ToolStripMenuItem();
            btnWinHide = new ToolStripMenuItem();
            btnWinClose = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            btnWinCloseAll = new ToolStripMenuItem();
            listView1 = new ListView();
            msMain.SuspendLayout();
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
            msMain.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, windowToolStripMenuItem });
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
            msMain.Size = new Size(669, 46);
            msMain.StripItemSelectedBackColorNorth = Color.White;
            msMain.StripItemSelectedBackColorSouth = Color.White;
            msMain.TabIndex = 2;
            msMain.Text = "menuStrip1";
            msMain.UseNorthFadeIn = false;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnFileRun, btnFileExit });
            fileToolStripMenuItem.ForeColor = Color.Black;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 38);
            fileToolStripMenuItem.Text = "File";
            // 
            // btnFileRun
            // 
            btnFileRun.ForeColor = Color.Black;
            btnFileRun.Name = "btnFileRun";
            btnFileRun.Size = new Size(268, 44);
            btnFileRun.Text = "Run";
            // 
            // btnFileExit
            // 
            btnFileExit.ForeColor = Color.Black;
            btnFileExit.Name = "btnFileExit";
            btnFileExit.ShortcutKeys = Keys.Alt | Keys.F4;
            btnFileExit.Size = new Size(268, 44);
            btnFileExit.Text = "Exit";
            btnFileExit.Click += btnFileExit_Click;
            // 
            // windowToolStripMenuItem
            // 
            windowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { btnWinRefresh, toolStripSeparator2, btnWinMinimise, btnWinHide, btnWinClose, toolStripSeparator1, btnWinCloseAll });
            windowToolStripMenuItem.ForeColor = Color.Black;
            windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            windowToolStripMenuItem.Size = new Size(121, 38);
            windowToolStripMenuItem.Text = "Window";
            // 
            // btnWinRefresh
            // 
            btnWinRefresh.ForeColor = Color.Black;
            btnWinRefresh.Name = "btnWinRefresh";
            btnWinRefresh.ShortcutKeys = Keys.F5;
            btnWinRefresh.Size = new Size(391, 44);
            btnWinRefresh.Text = "Refresh";
            btnWinRefresh.Click += btnWinRefresh_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(388, 6);
            // 
            // btnWinMinimise
            // 
            btnWinMinimise.Enabled = false;
            btnWinMinimise.ForeColor = Color.Black;
            btnWinMinimise.Name = "btnWinMinimise";
            btnWinMinimise.ShortcutKeys = Keys.Control | Keys.Down;
            btnWinMinimise.Size = new Size(391, 44);
            btnWinMinimise.Text = "Minimise";
            btnWinMinimise.Click += btnWinMinimise_Click;
            // 
            // btnWinHide
            // 
            btnWinHide.Enabled = false;
            btnWinHide.ForeColor = Color.Black;
            btnWinHide.Name = "btnWinHide";
            btnWinHide.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Down;
            btnWinHide.Size = new Size(391, 44);
            btnWinHide.Text = "Hide";
            btnWinHide.Click += btnWinHide_Click;
            // 
            // btnWinClose
            // 
            btnWinClose.Enabled = false;
            btnWinClose.ForeColor = Color.Black;
            btnWinClose.Name = "btnWinClose";
            btnWinClose.ShortcutKeys = Keys.Delete;
            btnWinClose.Size = new Size(391, 44);
            btnWinClose.Text = "Close";
            btnWinClose.Click += btnWinClose_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(388, 6);
            // 
            // btnWinCloseAll
            // 
            btnWinCloseAll.ForeColor = Color.Black;
            btnWinCloseAll.Name = "btnWinCloseAll";
            btnWinCloseAll.ShortcutKeys = Keys.Control | Keys.Delete;
            btnWinCloseAll.Size = new Size(391, 44);
            btnWinCloseAll.Text = "Close All";
            btnWinCloseAll.Click += btnWinCloseAll_Click;
            // 
            // listView1
            // 
            listView1.BorderStyle = BorderStyle.None;
            listView1.Dock = DockStyle.Fill;
            listView1.Location = new Point(0, 46);
            listView1.Margin = new Padding(6);
            listView1.Name = "listView1";
            listView1.Size = new Size(669, 549);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Tile;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            // 
            // WindowManager
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(669, 595);
            Controls.Add(listView1);
            Controls.Add(msMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(0, 0);
            Margin = new Padding(6);
            Name = "WindowManager";
            Text = "Window Manager";
            FormClosed += WindowManager_FormClosed;
            Load += WindowManager_Load;
            SizeChanged += WindowManager_SizeChanged;
            VisibleChanged += WindowManager_VisibleChanged;
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private ODModules.MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem btnFileRun;
        private ToolStripMenuItem btnFileExit;
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem btnWinRefresh;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem btnWinMinimise;
        private ToolStripMenuItem btnWinHide;
        private ToolStripMenuItem btnWinClose;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem btnWinCloseAll;
        private ListView listView1;
    }
}