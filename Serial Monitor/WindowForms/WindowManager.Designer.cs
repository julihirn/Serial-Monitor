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
            this.msMain = new ODModules.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFileRun = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWinRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnWinMinimise = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWinHide = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWinClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnWinCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColorNorth = System.Drawing.Color.DodgerBlue;
            this.msMain.BackColorNorthFadeIn = System.Drawing.Color.DodgerBlue;
            this.msMain.BackColorSouth = System.Drawing.Color.DodgerBlue;
            this.msMain.ItemForeColor = System.Drawing.Color.Black;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.msMain.ItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.msMain.ItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.msMain.ItemSelectedForeColor = System.Drawing.Color.Black;
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.MenuBackColorNorth = System.Drawing.Color.DodgerBlue;
            this.msMain.MenuBackColorSouth = System.Drawing.Color.DodgerBlue;
            this.msMain.MenuBorderColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.MenuSeparatorColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.MenuSymbolColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(360, 24);
            this.msMain.StripItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.msMain.StripItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.msMain.TabIndex = 2;
            this.msMain.Text = "menuStrip1";
            this.msMain.UseNorthFadeIn = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFileRun,
            this.btnFileExit});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // btnFileRun
            // 
            this.btnFileRun.ForeColor = System.Drawing.Color.Black;
            this.btnFileRun.Name = "btnFileRun";
            this.btnFileRun.Size = new System.Drawing.Size(180, 22);
            this.btnFileRun.Text = "Run";
            // 
            // btnFileExit
            // 
            this.btnFileExit.ForeColor = System.Drawing.Color.Black;
            this.btnFileExit.Name = "btnFileExit";
            this.btnFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.btnFileExit.Size = new System.Drawing.Size(180, 22);
            this.btnFileExit.Text = "Exit";
            this.btnFileExit.Click += new System.EventHandler(this.btnFileExit_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnWinRefresh,
            this.toolStripSeparator2,
            this.btnWinMinimise,
            this.btnWinHide,
            this.btnWinClose,
            this.toolStripSeparator1,
            this.btnWinCloseAll});
            this.windowToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // btnWinRefresh
            // 
            this.btnWinRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnWinRefresh.Name = "btnWinRefresh";
            this.btnWinRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.btnWinRefresh.Size = new System.Drawing.Size(196, 22);
            this.btnWinRefresh.Text = "Refresh";
            this.btnWinRefresh.Click += new System.EventHandler(this.btnWinRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // btnWinMinimise
            // 
            this.btnWinMinimise.Enabled = false;
            this.btnWinMinimise.ForeColor = System.Drawing.Color.Black;
            this.btnWinMinimise.Name = "btnWinMinimise";
            this.btnWinMinimise.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.btnWinMinimise.Size = new System.Drawing.Size(196, 22);
            this.btnWinMinimise.Text = "Minimise";
            this.btnWinMinimise.Click += new System.EventHandler(this.btnWinMinimise_Click);
            // 
            // btnWinHide
            // 
            this.btnWinHide.Enabled = false;
            this.btnWinHide.ForeColor = System.Drawing.Color.Black;
            this.btnWinHide.Name = "btnWinHide";
            this.btnWinHide.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Down)));
            this.btnWinHide.Size = new System.Drawing.Size(196, 22);
            this.btnWinHide.Text = "Hide";
            this.btnWinHide.Click += new System.EventHandler(this.btnWinHide_Click);
            // 
            // btnWinClose
            // 
            this.btnWinClose.Enabled = false;
            this.btnWinClose.ForeColor = System.Drawing.Color.Black;
            this.btnWinClose.Name = "btnWinClose";
            this.btnWinClose.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.btnWinClose.Size = new System.Drawing.Size(196, 22);
            this.btnWinClose.Text = "Close";
            this.btnWinClose.Click += new System.EventHandler(this.btnWinClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // btnWinCloseAll
            // 
            this.btnWinCloseAll.ForeColor = System.Drawing.Color.Black;
            this.btnWinCloseAll.Name = "btnWinCloseAll";
            this.btnWinCloseAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.btnWinCloseAll.Size = new System.Drawing.Size(196, 22);
            this.btnWinCloseAll.Text = "Close All";
            this.btnWinCloseAll.Click += new System.EventHandler(this.btnWinCloseAll_Click);
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(360, 255);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // WindowManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 279);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.msMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WindowManager";
            this.Text = "Window Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WindowManager_FormClosed);
            this.Load += new System.EventHandler(this.WindowManager_Load);
            this.SizeChanged += new System.EventHandler(this.WindowManager_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.WindowManager_VisibleChanged);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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