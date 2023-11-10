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
            ODModules.Column column3 = new ODModules.Column();
            ODModules.Column column4 = new ODModules.Column();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Variables));
            thDataPagesHeader = new ODModules.TabHeader();
            tbVars = new ODModules.HiddenTabControl();
            tbpgGlobals = new TabPage();
            lstGlobals = new ODModules.ListControl();
            cmArray = new ODModules.ContextMenu();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            tabpgArray = new TabPage();
            lstArray = new ODModules.ListControl();
            tbVars.SuspendLayout();
            tbpgGlobals.SuspendLayout();
            cmArray.SuspendLayout();
            tabpgArray.SuspendLayout();
            SuspendLayout();
            // 
            // thDataPagesHeader
            // 
            thDataPagesHeader.AddHoverColor = Color.LimeGreen;
            thDataPagesHeader.AllowDragReordering = false;
            thDataPagesHeader.AllowTabResize = true;
            thDataPagesHeader.ArrowColor = Color.DarkGray;
            thDataPagesHeader.ArrowDisabledColor = Color.FromArgb(128, 0, 0, 0);
            thDataPagesHeader.ArrowHoverColor = Color.SteelBlue;
            thDataPagesHeader.BackColor = Color.FromArgb(31, 31, 31);
            thDataPagesHeader.BindedTabControl = tbVars;
            thDataPagesHeader.CloseHoverColor = Color.Brown;
            thDataPagesHeader.Dock = DockStyle.Top;
            thDataPagesHeader.ForeColor = Color.White;
            thDataPagesHeader.Location = new Point(0, 0);
            thDataPagesHeader.Name = "thDataPagesHeader";
            thDataPagesHeader.Padding = new Padding(5, 0, 0, 0);
            thDataPagesHeader.SelectedIndex = 0;
            thDataPagesHeader.ShowAddButton = false;
            thDataPagesHeader.ShowTabDividers = true;
            thDataPagesHeader.Size = new Size(258, 27);
            thDataPagesHeader.TabBackColor = Color.Transparent;
            thDataPagesHeader.TabBorderColor = Color.Transparent;
            thDataPagesHeader.TabClickedBackColor = Color.DarkGray;
            thDataPagesHeader.TabDividerColor = Color.White;
            thDataPagesHeader.TabHoverBackColor = Color.LightGray;
            thDataPagesHeader.TabIndex = 7;
            thDataPagesHeader.TabRuleColor = Color.FromArgb(100, 128, 128, 128);
            tab1.Selected = true;
            tab1.Tag = null;
            tab1.Text = "";
            thDataPagesHeader.Tabs.Add(tab1);
            thDataPagesHeader.TabSelectedBackColor = Color.FromArgb(100, 128, 128, 128);
            thDataPagesHeader.TabSelectedBorderColor = Color.FromArgb(100, 128, 128, 128);
            thDataPagesHeader.TabSelectedForeColor = Color.WhiteSmoke;
            thDataPagesHeader.TabSelectedShadowColor = Color.Black;
            thDataPagesHeader.TabStyle = ODModules.TabHeader.TabStyles.Normal;
            thDataPagesHeader.UseBindingTabControl = true;
            // 
            // tbVars
            // 
            tbVars.Controls.Add(tbpgGlobals);
            tbVars.Controls.Add(tabpgArray);
            tbVars.DebugMode = true;
            tbVars.DefaultColor1 = Color.DodgerBlue;
            tbVars.Dock = DockStyle.Fill;
            tbVars.DrawMode = TabDrawMode.OwnerDrawFixed;
            tbVars.ForeColor = Color.White;
            tbVars.ItemSize = new Size(20, 20);
            tbVars.Location = new Point(0, 27);
            tbVars.Margin = new Padding(0);
            tbVars.Multiline = true;
            tbVars.Name = "tbVars";
            tbVars.SelectedIndex = 0;
            tbVars.Size = new Size(258, 248);
            tbVars.TabIndex = 8;
            // 
            // tbpgGlobals
            // 
            tbpgGlobals.Controls.Add(lstGlobals);
            tbpgGlobals.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tbpgGlobals.Location = new Point(4, 24);
            tbpgGlobals.Name = "tbpgGlobals";
            tbpgGlobals.Padding = new Padding(3);
            tbpgGlobals.Size = new Size(250, 220);
            tbpgGlobals.TabIndex = 1;
            tbpgGlobals.Text = "Variables";
            tbpgGlobals.UseVisualStyleBackColor = true;
            // 
            // lstGlobals
            // 
            lstGlobals.AllowColumnSpanning = true;
            lstGlobals.AllowMouseWheel = true;
            lstGlobals.ColumnColor = Color.LightGray;
            lstGlobals.ColumnForeColor = Color.Black;
            lstGlobals.ColumnLineColor = Color.DimGray;
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column1.CountOffset = 0;
            column1.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column1.DropDownRight = false;
            column1.DropDownVisible = false;
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column1.Text = "Name";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 80;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column2.DropDownRight = false;
            column2.DropDownVisible = false;
            column2.FixedWidth = true;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column2.Text = "Value";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 164;
            lstGlobals.Columns.Add(column1);
            lstGlobals.Columns.Add(column2);
            lstGlobals.ContextMenuStrip = cmArray;
            lstGlobals.Dock = DockStyle.Fill;
            lstGlobals.DropDownMouseDown = Color.DimGray;
            lstGlobals.DropDownMouseOver = Color.LightGray;
            lstGlobals.ExternalItems = null;
            lstGlobals.Filter = null;
            lstGlobals.FilterColumn = 0;
            lstGlobals.GridlineColor = Color.LightGray;
            lstGlobals.HighlightStrength = 128;
            lstGlobals.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstGlobals.LineMarkerIndex = 0;
            lstGlobals.Location = new Point(3, 3);
            lstGlobals.MarkerBorderColor = Color.LimeGreen;
            lstGlobals.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstGlobals.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstGlobals.Name = "lstGlobals";
            lstGlobals.RowColor = Color.LightGray;
            lstGlobals.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstGlobals.ScrollBarNorth = Color.DarkTurquoise;
            lstGlobals.ScrollBarSouth = Color.DeepSkyBlue;
            lstGlobals.ScrollItems = 3;
            lstGlobals.SelectedColor = Color.SkyBlue;
            lstGlobals.SelectionColor = Color.Gray;
            lstGlobals.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstGlobals.ShowGrid = true;
            lstGlobals.ShowMarker = false;
            lstGlobals.ShowRowColors = false;
            lstGlobals.Size = new Size(244, 214);
            lstGlobals.SpanColumn = 1;
            lstGlobals.TabIndex = 1;
            lstGlobals.UseLocalList = true;
            lstGlobals.VerScroll = 0;
            lstGlobals.DropDownClicked += lstGlobals_DropDownClicked;
            // 
            // cmArray
            // 
            cmArray.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmArray.BorderColor = Color.Black;
            cmArray.DropShadowEnabled = false;
            cmArray.ForeColor = Color.White;
            cmArray.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmArray.Items.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem });
            cmArray.MenuBackColorNorth = Color.DodgerBlue;
            cmArray.MenuBackColorSouth = Color.DodgerBlue;
            cmArray.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmArray.Name = "cmArray";
            cmArray.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmArray.ShowInsetShadow = false;
            cmArray.ShowItemInsetShadow = false;
            cmArray.Size = new Size(145, 92);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(144, 22);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(144, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(144, 22);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteToolStripMenuItem.Size = new Size(144, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // tabpgArray
            // 
            tabpgArray.Controls.Add(lstArray);
            tabpgArray.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tabpgArray.Location = new Point(4, 24);
            tabpgArray.Name = "tabpgArray";
            tabpgArray.Padding = new Padding(3);
            tabpgArray.Size = new Size(250, 220);
            tabpgArray.TabIndex = 0;
            tabpgArray.Text = "Array";
            tabpgArray.UseVisualStyleBackColor = true;
            // 
            // lstArray
            // 
            lstArray.AllowColumnSpanning = true;
            lstArray.AllowMouseWheel = true;
            lstArray.ColumnColor = Color.LightGray;
            lstArray.ColumnForeColor = Color.Black;
            lstArray.ColumnLineColor = Color.DimGray;
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column3.CountOffset = 0;
            column3.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column3.DropDownRight = false;
            column3.DropDownVisible = true;
            column3.FixedWidth = false;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column3.Text = "";
            column3.UseItemBackColor = false;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 60;
            column4.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column4.CountOffset = 0;
            column4.DisplayType = ODModules.ColumnDisplayType.Text;
            column4.DropDownRight = false;
            column4.DropDownVisible = true;
            column4.FixedWidth = true;
            column4.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column4.Text = "Value";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 184;
            lstArray.Columns.Add(column3);
            lstArray.Columns.Add(column4);
            lstArray.ContextMenuStrip = cmArray;
            lstArray.Dock = DockStyle.Fill;
            lstArray.DropDownMouseDown = Color.DimGray;
            lstArray.DropDownMouseOver = Color.LightGray;
            lstArray.ExternalItems = null;
            lstArray.Filter = null;
            lstArray.FilterColumn = 0;
            lstArray.GridlineColor = Color.LightGray;
            lstArray.HighlightStrength = 128;
            lstArray.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstArray.LineMarkerIndex = 0;
            lstArray.Location = new Point(3, 3);
            lstArray.MarkerBorderColor = Color.LimeGreen;
            lstArray.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstArray.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstArray.Name = "lstArray";
            lstArray.RowColor = Color.LightGray;
            lstArray.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstArray.ScrollBarNorth = Color.DarkTurquoise;
            lstArray.ScrollBarSouth = Color.DeepSkyBlue;
            lstArray.ScrollItems = 3;
            lstArray.SelectedColor = Color.SkyBlue;
            lstArray.SelectionColor = Color.Gray;
            lstArray.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstArray.ShowGrid = true;
            lstArray.ShowMarker = false;
            lstArray.ShowRowColors = false;
            lstArray.Size = new Size(244, 214);
            lstArray.SpanColumn = 1;
            lstArray.TabIndex = 0;
            lstArray.UseLocalList = true;
            lstArray.VerScroll = 0;
            // 
            // Variables
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 275);
            Controls.Add(tbVars);
            Controls.Add(thDataPagesHeader);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Variables";
            Text = "Variables";
            FormClosing += Variables_FormClosing;
            Load += Variables_Load;
            tbVars.ResumeLayout(false);
            tbpgGlobals.ResumeLayout(false);
            cmArray.ResumeLayout(false);
            tabpgArray.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ODModules.TabHeader thDataPagesHeader;
        private ODModules.HiddenTabControl tbVars;
        private TabPage tabpgArray;
        private ODModules.ListControl lstArray;
        private ODModules.ContextMenu cmArray;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private TabPage tbpgGlobals;
        private ODModules.ListControl lstGlobals;
    }
}