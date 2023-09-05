namespace Serial_Monitor.WindowForms {
    partial class Terminal {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Terminal));
            this.Output = new ODModules.ConsoleInterface();
            this.tsMain = new ODModules.ToolStrip();
            this.ddbDisplayTime = new System.Windows.Forms.ToolStripDropDownButton();
            this.dataOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeStampsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateStampsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimeStampsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClearTerminal = new System.Windows.Forms.ToolStripButton();
            this.btnTopMost = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Output
            // 
            this.Output.AllowCommandEntry = true;
            this.Output.AllowMouseSelection = false;
            this.Output.AllowMouseWheelZoom = false;
            this.Output.BufferLength = 10000;
            this.Output.CursorFlashSpeed = 0.5F;
            this.Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Output.ExtraLineAfterCommandEntered = false;
            this.Output.FlashCursor = false;
            this.Output.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Output.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Output.HorScroll = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Output.LineFormatting = true;
            this.Output.Location = new System.Drawing.Point(0, 25);
            this.Output.MaximumLength = 100;
            this.Output.Name = "Output";
            this.Output.OriginForeColor = System.Drawing.Color.Silver;
            this.Output.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.Output.PrintOnEntry = true;
            this.Output.ScrollBarMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Output.ScrollBarNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Output.ScrollBarSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Output.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Output.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(74)))));
            this.Output.ShowOrigin = false;
            this.Output.Size = new System.Drawing.Size(430, 299);
            this.Output.TabIndex = 1;
            this.Output.TimeStampForeColor = System.Drawing.Color.Gray;
            this.Output.TimeStamps = ODModules.ConsoleInterface.TimeStampFormat.NoTimeStamps;
            this.Output.VerScroll = 0;
            this.Output.Zoom = 100;
            this.Output.CommandEntered += new ODModules.ConsoleInterface.CommandEnteredEventHandler(this.Output_CommandEntered);
            // 
            // tsMain
            // 
            this.tsMain.BackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.BackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.ItemCheckedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMain.ItemCheckedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMain.ItemForeColor = System.Drawing.Color.Black;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddbDisplayTime,
            this.toolStripSeparator1,
            this.btnClearTerminal,
            this.btnTopMost});
            this.tsMain.ItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.tsMain.ItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.tsMain.ItemSelectedForeColor = System.Drawing.Color.Black;
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.MenuBackColorNorth = System.Drawing.Color.DodgerBlue;
            this.tsMain.MenuBackColorSouth = System.Drawing.Color.DodgerBlue;
            this.tsMain.MenuBorderColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.MenuSeparatorColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.MenuSymbolColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(430, 25);
            this.tsMain.StripItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.tsMain.StripItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "toolStrip1";
            // 
            // ddbDisplayTime
            // 
            this.ddbDisplayTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddbDisplayTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataOnlyToolStripMenuItem,
            this.timeStampsToolStripMenuItem,
            this.dateStampsToolStripMenuItem,
            this.dateTimeStampsToolStripMenuItem});
            this.ddbDisplayTime.ForeColor = System.Drawing.Color.White;
            this.ddbDisplayTime.Image = ((System.Drawing.Image)(resources.GetObject("ddbDisplayTime.Image")));
            this.ddbDisplayTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ddbDisplayTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddbDisplayTime.Name = "ddbDisplayTime";
            this.ddbDisplayTime.Size = new System.Drawing.Size(72, 22);
            this.ddbDisplayTime.Tag = "0";
            this.ddbDisplayTime.Text = "Data Only";
            // 
            // dataOnlyToolStripMenuItem
            // 
            this.dataOnlyToolStripMenuItem.Checked = true;
            this.dataOnlyToolStripMenuItem.CheckOnClick = true;
            this.dataOnlyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dataOnlyToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.dataOnlyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dataOnlyToolStripMenuItem.Name = "dataOnlyToolStripMenuItem";
            this.dataOnlyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.dataOnlyToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.dataOnlyToolStripMenuItem.Tag = "0";
            this.dataOnlyToolStripMenuItem.Text = "Data Only";
            this.dataOnlyToolStripMenuItem.Click += new System.EventHandler(this.dataOnlyToolStripMenuItem_Click);
            // 
            // timeStampsToolStripMenuItem
            // 
            this.timeStampsToolStripMenuItem.CheckOnClick = true;
            this.timeStampsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.timeStampsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.timeStampsToolStripMenuItem.Name = "timeStampsToolStripMenuItem";
            this.timeStampsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.timeStampsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.timeStampsToolStripMenuItem.Tag = "1";
            this.timeStampsToolStripMenuItem.Text = "Time Stamps";
            this.timeStampsToolStripMenuItem.Click += new System.EventHandler(this.timeStampsToolStripMenuItem_Click);
            // 
            // dateStampsToolStripMenuItem
            // 
            this.dateStampsToolStripMenuItem.CheckOnClick = true;
            this.dateStampsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.dateStampsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dateStampsToolStripMenuItem.Name = "dateStampsToolStripMenuItem";
            this.dateStampsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.dateStampsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.dateStampsToolStripMenuItem.Tag = "3";
            this.dateStampsToolStripMenuItem.Text = "Date Stamps";
            this.dateStampsToolStripMenuItem.Click += new System.EventHandler(this.dateStampsToolStripMenuItem_Click);
            // 
            // dateTimeStampsToolStripMenuItem
            // 
            this.dateTimeStampsToolStripMenuItem.CheckOnClick = true;
            this.dateTimeStampsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.dateTimeStampsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dateTimeStampsToolStripMenuItem.Name = "dateTimeStampsToolStripMenuItem";
            this.dateTimeStampsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
            this.dateTimeStampsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.dateTimeStampsToolStripMenuItem.Tag = "4";
            this.dateTimeStampsToolStripMenuItem.Text = "Date/Time Stamps";
            this.dateTimeStampsToolStripMenuItem.Click += new System.EventHandler(this.dateTimeStampsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClearTerminal
            // 
            this.btnClearTerminal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClearTerminal.Image = ((System.Drawing.Image)(resources.GetObject("btnClearTerminal.Image")));
            this.btnClearTerminal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearTerminal.Name = "btnClearTerminal";
            this.btnClearTerminal.Size = new System.Drawing.Size(23, 22);
            this.btnClearTerminal.Text = "Clear Terminal";
            this.btnClearTerminal.Click += new System.EventHandler(this.btnClearTerminal_Click);
            // 
            // btnTopMost
            // 
            this.btnTopMost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTopMost.Image = ((System.Drawing.Image)(resources.GetObject("btnTopMost.Image")));
            this.btnTopMost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTopMost.Name = "btnTopMost";
            this.btnTopMost.Size = new System.Drawing.Size(23, 22);
            this.btnTopMost.Text = "Window Top Most";
            this.btnTopMost.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // Terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(430, 324);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.tsMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Terminal";
            this.Text = "Terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Terminal_FormClosing);
            this.Load += new System.EventHandler(this.Terminal_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Terminal_KeyPress);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ODModules.ConsoleInterface Output;
        private ODModules.ToolStrip tsMain;
        private ToolStripDropDownButton ddbDisplayTime;
        private ToolStripMenuItem dataOnlyToolStripMenuItem;
        private ToolStripMenuItem timeStampsToolStripMenuItem;
        private ToolStripMenuItem dateStampsToolStripMenuItem;
        private ToolStripMenuItem dateTimeStampsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnClearTerminal;
        private ToolStripButton btnTopMost;
    }
}