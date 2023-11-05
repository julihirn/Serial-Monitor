namespace Serial_Monitor.ToolWindows {
    partial class Variables {
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
            ODModules.Tab tab1 = new ODModules.Tab();
            ODModules.Column column1 = new ODModules.Column();
            ODModules.Column column2 = new ODModules.Column();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Variables));
            this.thDataPagesHeader = new ODModules.TabHeader();
            this.tbVars = new ODModules.HiddenTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstArray = new ODModules.ListControl();
            this.cmArray = new ODModules.ContextMenu();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbVars.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.cmArray.SuspendLayout();
            this.SuspendLayout();
            // 
            // thDataPagesHeader
            // 
            this.thDataPagesHeader.AddHoverColor = System.Drawing.Color.LimeGreen;
            this.thDataPagesHeader.AllowDragReordering = false;
            this.thDataPagesHeader.AllowTabResize = true;
            this.thDataPagesHeader.ArrowColor = System.Drawing.Color.DarkGray;
            this.thDataPagesHeader.ArrowDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.thDataPagesHeader.ArrowHoverColor = System.Drawing.Color.SteelBlue;
            this.thDataPagesHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.thDataPagesHeader.BindedTabControl = this.tbVars;
            this.thDataPagesHeader.CloseHoverColor = System.Drawing.Color.Brown;
            this.thDataPagesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.thDataPagesHeader.ForeColor = System.Drawing.Color.White;
            this.thDataPagesHeader.Location = new System.Drawing.Point(0, 0);
            this.thDataPagesHeader.Name = "thDataPagesHeader";
            this.thDataPagesHeader.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.thDataPagesHeader.SelectedIndex = 0;
            this.thDataPagesHeader.ShowAddButton = false;
            this.thDataPagesHeader.ShowTabDividers = true;
            this.thDataPagesHeader.Size = new System.Drawing.Size(258, 27);
            this.thDataPagesHeader.TabBackColor = System.Drawing.Color.Transparent;
            this.thDataPagesHeader.TabBorderColor = System.Drawing.Color.Transparent;
            this.thDataPagesHeader.TabClickedBackColor = System.Drawing.Color.DarkGray;
            this.thDataPagesHeader.TabDividerColor = System.Drawing.Color.White;
            this.thDataPagesHeader.TabHoverBackColor = System.Drawing.Color.LightGray;
            this.thDataPagesHeader.TabIndex = 7;
            this.thDataPagesHeader.TabRuleColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            tab1.Selected = true;
            tab1.Tag = null;
            tab1.Text = "";
            this.thDataPagesHeader.Tabs.Add(tab1);
            this.thDataPagesHeader.TabSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.thDataPagesHeader.TabSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.thDataPagesHeader.TabSelectedForeColor = System.Drawing.Color.WhiteSmoke;
            this.thDataPagesHeader.TabSelectedShadowColor = System.Drawing.Color.Black;
            this.thDataPagesHeader.TabStyle = ODModules.TabHeader.TabStyles.Normal;
            this.thDataPagesHeader.UseBindingTabControl = true;
            // 
            // tbVars
            // 
            this.tbVars.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbVars.Controls.Add(this.tabPage1);
            this.tbVars.DebugMode = false;
            this.tbVars.DefaultColor1 = System.Drawing.Color.DodgerBlue;
            this.tbVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbVars.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbVars.ForeColor = System.Drawing.Color.White;
            this.tbVars.Location = new System.Drawing.Point(0, 27);
            this.tbVars.Margin = new System.Windows.Forms.Padding(0);
            this.tbVars.Multiline = true;
            this.tbVars.Name = "tbVars";
            this.tbVars.SelectedIndex = 0;
            this.tbVars.Size = new System.Drawing.Size(258, 248);
            this.tbVars.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbVars.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstArray);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(250, 216);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Array";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstArray
            // 
            this.lstArray.AllowColumnSpanning = true;
            this.lstArray.AllowMouseWheel = true;
            this.lstArray.ColumnColor = System.Drawing.Color.LightGray;
            this.lstArray.ColumnForeColor = System.Drawing.Color.Black;
            this.lstArray.ColumnLineColor = System.Drawing.Color.DimGray;
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column1.CountOffset = 0;
            column1.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column1.DropDownRight = false;
            column1.DropDownVisible = true;
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column1.Text = "";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 60;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DisplayType = ODModules.ColumnDisplayType.Text;
            column2.DropDownRight = false;
            column2.DropDownVisible = true;
            column2.FixedWidth = true;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column2.Text = "Value";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 184;
            this.lstArray.Columns.Add(column1);
            this.lstArray.Columns.Add(column2);
            this.lstArray.ContextMenuStrip = this.cmArray;
            this.lstArray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstArray.DropDownMouseDown = System.Drawing.Color.DimGray;
            this.lstArray.DropDownMouseOver = System.Drawing.Color.LightGray;
            this.lstArray.ExternalItems = null;
            this.lstArray.Filter = null;
            this.lstArray.FilterColumn = 0;
            this.lstArray.GridlineColor = System.Drawing.Color.LightGray;
            this.lstArray.HighlightStrength = 128;
            this.lstArray.HorScroll = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lstArray.LineMarkerIndex = 0;
            this.lstArray.Location = new System.Drawing.Point(3, 3);
            this.lstArray.MarkerBorderColor = System.Drawing.Color.LimeGreen;
            this.lstArray.MarkerFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.lstArray.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            this.lstArray.Name = "lstArray";
            this.lstArray.RowColor = System.Drawing.Color.LightGray;
            this.lstArray.ScrollBarMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lstArray.ScrollBarNorth = System.Drawing.Color.DarkTurquoise;
            this.lstArray.ScrollBarSouth = System.Drawing.Color.DeepSkyBlue;
            this.lstArray.ScrollItems = 3;
            this.lstArray.SelectedColor = System.Drawing.Color.SkyBlue;
            this.lstArray.SelectionColor = System.Drawing.Color.Gray;
            this.lstArray.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lstArray.ShowGrid = true;
            this.lstArray.ShowMarker = false;
            this.lstArray.ShowRowColors = false;
            this.lstArray.Size = new System.Drawing.Size(244, 210);
            this.lstArray.SpanColumn = 1;
            this.lstArray.TabIndex = 0;
            this.lstArray.UseLocalList = true;
            this.lstArray.VerScroll = 0;
            // 
            // cmArray
            // 
            this.cmArray.ActionSymbolForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmArray.BorderColor = System.Drawing.Color.Black;
            this.cmArray.DropShadowEnabled = false;
            this.cmArray.ForeColor = System.Drawing.Color.White;
            this.cmArray.InsetShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmArray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmArray.MenuBackColorNorth = System.Drawing.Color.DodgerBlue;
            this.cmArray.MenuBackColorSouth = System.Drawing.Color.DodgerBlue;
            this.cmArray.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmArray.Name = "cmArray";
            this.cmArray.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmArray.ShowInsetShadow = false;
            this.cmArray.ShowItemInsetShadow = false;
            this.cmArray.Size = new System.Drawing.Size(145, 92);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // Variables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 275);
            this.Controls.Add(this.tbVars);
            this.Controls.Add(this.thDataPagesHeader);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Variables";
            this.Text = "Variables";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Variables_FormClosing);
            this.Load += new System.EventHandler(this.Variables_Load);
            this.tbVars.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.cmArray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ODModules.TabHeader thDataPagesHeader;
        private ODModules.HiddenTabControl tbVars;
        private TabPage tabPage1;
        private ODModules.ListControl lstArray;
        private ODModules.ContextMenu cmArray;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}