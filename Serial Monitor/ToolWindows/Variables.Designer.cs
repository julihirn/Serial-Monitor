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
            ODModules.Column column5 = new ODModules.Column();
            ODModules.Column column6 = new ODModules.Column();
            ODModules.Column column7 = new ODModules.Column();
            ODModules.Column column8 = new ODModules.Column();
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
            tbpgVariables = new TabPage();
            lstVars = new ODModules.ListControl();
            tabpgArray = new TabPage();
            lstArray = new ODModules.ListControl();
            msMain = new ODModules.MenuStrip();
            editToolStripMenuItem = new ToolStripMenuItem();
            moveUpToolStripMenuItem = new ToolStripMenuItem();
            moveDownToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            cutToolStripMenuItem1 = new ToolStripMenuItem();
            copyToolStripMenuItem1 = new ToolStripMenuItem();
            pasteToolStripMenuItem1 = new ToolStripMenuItem();
            deleteToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            valuesToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            globalVariablesToolStripMenuItem = new ToolStripMenuItem();
            localVariablesToolStripMenuItem = new ToolStripMenuItem();
            arrayToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            topMostToolStripMenuItem = new ToolStripMenuItem();
            cntrlExtender = new ODModules.ControlExtensions.ControlExtender();
            tsiExtender = new ODModules.ControlExtensions.ToolStripItemExtender();
            tbVars.SuspendLayout();
            tbpgGlobals.SuspendLayout();
            cmArray.SuspendLayout();
            tbpgVariables.SuspendLayout();
            tabpgArray.SuspendLayout();
            msMain.SuspendLayout();
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
            thDataPagesHeader.BorderColor = Color.Gray;
            thDataPagesHeader.Borders = ODModules.Borders.None;
            thDataPagesHeader.CloseHoverColor = Color.Brown;
            thDataPagesHeader.Dock = DockStyle.Top;
            thDataPagesHeader.ForeColor = Color.White;
            thDataPagesHeader.HeaderDownForeColor = Color.Gray;
            thDataPagesHeader.HeaderForeColor = Color.Black;
            thDataPagesHeader.HeaderHoverForeColor = Color.Blue;
            thDataPagesHeader.Location = new Point(0, 44);
            thDataPagesHeader.Margin = new Padding(6, 6, 6, 6);
            thDataPagesHeader.Name = "thDataPagesHeader";
            thDataPagesHeader.Padding = new Padding(9, 0, 0, 0);
            thDataPagesHeader.SelectedIndex = 0;
            thDataPagesHeader.SelectedTabGradient = true;
            thDataPagesHeader.ShowAddButton = false;
            thDataPagesHeader.ShowHeader = false;
            thDataPagesHeader.ShowTabDividers = true;
            thDataPagesHeader.ShowTabs = true;
            thDataPagesHeader.Size = new Size(513, 58);
            thDataPagesHeader.TabBackColor = Color.Transparent;
            thDataPagesHeader.TabBorderColor = Color.Transparent;
            thDataPagesHeader.TabClickedBackColor = Color.DarkGray;
            thDataPagesHeader.TabDividerColor = Color.White;
            thDataPagesHeader.TabHoverBackColor = Color.LightGray;
            thDataPagesHeader.TabInactiveForeColor = Color.DarkGray;
            thDataPagesHeader.TabIndex = 7;
            thDataPagesHeader.TabRuleColor = Color.FromArgb(100, 128, 128, 128);
            tab1.Selected = true;
            tab1.Tag = null;
            tab1.Text = "";
            thDataPagesHeader.Tabs.Add(tab1);
            thDataPagesHeader.TabSelectedBackColor = Color.FromArgb(100, 128, 128, 128);
            thDataPagesHeader.TabSelectedBackColorNorth = Color.Gray;
            thDataPagesHeader.TabSelectedBorderColor = Color.FromArgb(100, 128, 128, 128);
            thDataPagesHeader.TabSelectedForeColor = Color.WhiteSmoke;
            thDataPagesHeader.TabSelectedShadowColor = Color.Black;
            thDataPagesHeader.TabStyle = ODModules.TabHeader.TabStyles.Normal;
            thDataPagesHeader.TabToolTips = null;
            cntrlExtender.SetTranslationReference(thDataPagesHeader, "");
            thDataPagesHeader.UseBindingTabControl = true;
            thDataPagesHeader.SelectedIndexChanged += thDataPagesHeader_SelectedIndexChanged;
            // 
            // tbVars
            // 
            tbVars.Controls.Add(tbpgGlobals);
            tbVars.Controls.Add(tbpgVariables);
            tbVars.Controls.Add(tabpgArray);
            tbVars.DebugMode = true;
            tbVars.DefaultColor1 = Color.DodgerBlue;
            tbVars.Dock = DockStyle.Fill;
            tbVars.DrawMode = TabDrawMode.OwnerDrawFixed;
            tbVars.ForeColor = Color.White;
            tbVars.ItemSize = new Size(20, 20);
            tbVars.Location = new Point(0, 102);
            tbVars.Margin = new Padding(0);
            tbVars.Multiline = true;
            tbVars.Name = "tbVars";
            tbVars.SelectedIndex = 0;
            tbVars.Size = new Size(513, 568);
            tbVars.TabIndex = 8;
            cntrlExtender.SetTranslationReference(tbVars, "");
            // 
            // tbpgGlobals
            // 
            tbpgGlobals.Controls.Add(lstGlobals);
            tbpgGlobals.Font = new Font("Segoe UI", 9F);
            tbpgGlobals.Location = new Point(4, 24);
            tbpgGlobals.Margin = new Padding(6, 6, 6, 6);
            tbpgGlobals.Name = "tbpgGlobals";
            tbpgGlobals.Size = new Size(505, 540);
            tbpgGlobals.TabIndex = 1;
            tbpgGlobals.Text = "Globals";
            cntrlExtender.SetTranslationReference(tbpgGlobals, "");
            tbpgGlobals.UseVisualStyleBackColor = true;
            // 
            // lstGlobals
            // 
            lstGlobals.AllowArrowKeyCellSelect = false;
            lstGlobals.AllowColumnSpanning = true;
            lstGlobals.AllowMouseWheel = true;
            lstGlobals.BorderColor = Color.Gray;
            lstGlobals.Borders = ODModules.Borders.None;
            lstGlobals.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            lstGlobals.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            lstGlobals.CellPixelFit = true;
            lstGlobals.CellSelectEditableOnly = true;
            lstGlobals.CellSelectionBorderColor = Color.Blue;
            lstGlobals.ColumnColor = Color.LightGray;
            lstGlobals.ColumnForeColor = Color.Black;
            lstGlobals.ColumnLineColor = Color.DimGray;
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column1.CountOffset = 0;
            column1.DataFormat = ODModules.ColumnDataFormat.None;
            column1.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column1.DropDownRight = false;
            column1.DropDownVisible = true;
            column1.Exportable = false;
            column1.ExportName = "";
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column1.Text = "";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 35;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DataFormat = ODModules.ColumnDataFormat.None;
            column2.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column2.DropDownRight = false;
            column2.DropDownVisible = false;
            column2.Exportable = false;
            column2.ExportName = "";
            column2.FixedWidth = false;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column2.Text = "Name";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 60;
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column3.CountOffset = 0;
            column3.DataFormat = ODModules.ColumnDataFormat.None;
            column3.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column3.DropDownRight = false;
            column3.DropDownVisible = false;
            column3.Exportable = false;
            column3.ExportName = "";
            column3.FixedWidth = true;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column3.Text = "Value";
            column3.UseItemBackColor = false;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 157;
            lstGlobals.Columns.Add(column1);
            lstGlobals.Columns.Add(column2);
            lstGlobals.Columns.Add(column3);
            lstGlobals.ContextMenuStrip = cmArray;
            lstGlobals.Dock = DockStyle.Fill;
            lstGlobals.DropDownMouseDown = Color.DimGray;
            lstGlobals.DropDownMouseOver = Color.LightGray;
            lstGlobals.ExternalItems = null;
            lstGlobals.Filter = null;
            lstGlobals.FilterColumn = 0;
            lstGlobals.FilterSearchType = ODModules.ListControl.FilterSearch.Contains;
            lstGlobals.GridlineColor = Color.LightGray;
            lstGlobals.HighlightStrength = 128;
            lstGlobals.HorizontalScrollStep = 3;
            lstGlobals.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstGlobals.LineMarkerIndex = 0;
            lstGlobals.Location = new Point(0, 0);
            lstGlobals.Margin = new Padding(6, 6, 6, 6);
            lstGlobals.MarkerBorderColor = Color.LimeGreen;
            lstGlobals.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstGlobals.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstGlobals.MoveControlOnCellChange = true;
            lstGlobals.Name = "lstGlobals";
            lstGlobals.RowColor = Color.LightGray;
            lstGlobals.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstGlobals.ScrollBarNorth = Color.DarkTurquoise;
            lstGlobals.ScrollBarSouth = Color.DeepSkyBlue;
            lstGlobals.ScrollItems = 3;
            lstGlobals.SelectedColor = Color.SkyBlue;
            lstGlobals.SelectionColor = Color.Gray;
            lstGlobals.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstGlobals.ShowCellSelection = false;
            lstGlobals.ShowGrid = true;
            lstGlobals.ShowHeader = true;
            lstGlobals.ShowItemIndentation = false;
            lstGlobals.ShowMarker = false;
            lstGlobals.ShowRowColors = false;
            lstGlobals.Size = new Size(505, 540);
            lstGlobals.SpanColumn = 2;
            lstGlobals.TabIndex = 1;
            cntrlExtender.SetTranslationReference(lstGlobals, "");
            lstGlobals.UseLocalList = true;
            lstGlobals.VerScroll = 0;
            lstGlobals.Zoom = 100;
            lstGlobals.DropDownClicked += lstGlobals_DropDownClicked;
            // 
            // cmArray
            // 
            cmArray.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmArray.BorderColor = Color.Black;
            cmArray.DropShadowEnabled = false;
            cmArray.ForeColor = Color.White;
            cmArray.ImageScalingSize = new Size(32, 32);
            cmArray.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmArray.Items.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem });
            cmArray.MenuBackColorNorth = Color.DodgerBlue;
            cmArray.MenuBackColorSouth = Color.DodgerBlue;
            cmArray.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmArray.Name = "cmArray";
            cmArray.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmArray.ShowInsetShadow = false;
            cmArray.ShowItemInsetShadow = false;
            cmArray.Size = new Size(301, 200);
            cntrlExtender.SetTranslationReference(cmArray, "");
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(300, 38);
            cutToolStripMenuItem.Text = "Cut";
            tsiExtender.SetTranslationReference(cutToolStripMenuItem, "cut");
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(300, 38);
            copyToolStripMenuItem.Text = "Copy";
            tsiExtender.SetTranslationReference(copyToolStripMenuItem, "copy");
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(300, 38);
            pasteToolStripMenuItem.Text = "Paste";
            tsiExtender.SetTranslationReference(pasteToolStripMenuItem, "paste");
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(300, 38);
            deleteToolStripMenuItem.Text = "Delete";
            tsiExtender.SetTranslationReference(deleteToolStripMenuItem, "delete");
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // tbpgVariables
            // 
            tbpgVariables.Controls.Add(lstVars);
            tbpgVariables.Font = new Font("Segoe UI", 9F);
            tbpgVariables.Location = new Point(4, 24);
            tbpgVariables.Margin = new Padding(6, 6, 6, 6);
            tbpgVariables.Name = "tbpgVariables";
            tbpgVariables.Size = new Size(505, 533);
            tbpgVariables.TabIndex = 2;
            tbpgVariables.Text = "Variables";
            cntrlExtender.SetTranslationReference(tbpgVariables, "");
            tbpgVariables.UseVisualStyleBackColor = true;
            // 
            // lstVars
            // 
            lstVars.AllowArrowKeyCellSelect = false;
            lstVars.AllowColumnSpanning = true;
            lstVars.AllowMouseWheel = true;
            lstVars.BorderColor = Color.Gray;
            lstVars.Borders = ODModules.Borders.None;
            lstVars.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            lstVars.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            lstVars.CellPixelFit = true;
            lstVars.CellSelectEditableOnly = true;
            lstVars.CellSelectionBorderColor = Color.Blue;
            lstVars.ColumnColor = Color.LightGray;
            lstVars.ColumnForeColor = Color.Black;
            lstVars.ColumnLineColor = Color.DimGray;
            column4.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column4.CountOffset = 0;
            column4.DataFormat = ODModules.ColumnDataFormat.None;
            column4.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column4.DropDownRight = false;
            column4.DropDownVisible = true;
            column4.Exportable = false;
            column4.ExportName = "";
            column4.FixedWidth = false;
            column4.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column4.Text = "";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 35;
            column5.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column5.CountOffset = 0;
            column5.DataFormat = ODModules.ColumnDataFormat.None;
            column5.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column5.DropDownRight = false;
            column5.DropDownVisible = false;
            column5.Exportable = false;
            column5.ExportName = "";
            column5.FixedWidth = false;
            column5.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column5.Text = "Name";
            column5.UseItemBackColor = false;
            column5.UseItemForeColor = false;
            column5.Visible = true;
            column5.Width = 60;
            column6.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column6.CountOffset = 0;
            column6.DataFormat = ODModules.ColumnDataFormat.None;
            column6.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column6.DropDownRight = false;
            column6.DropDownVisible = false;
            column6.Exportable = false;
            column6.ExportName = "";
            column6.FixedWidth = true;
            column6.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column6.Text = "Value";
            column6.UseItemBackColor = false;
            column6.UseItemForeColor = false;
            column6.Visible = true;
            column6.Width = 173;
            lstVars.Columns.Add(column4);
            lstVars.Columns.Add(column5);
            lstVars.Columns.Add(column6);
            lstVars.ContextMenuStrip = cmArray;
            lstVars.Dock = DockStyle.Fill;
            lstVars.DropDownMouseDown = Color.DimGray;
            lstVars.DropDownMouseOver = Color.LightGray;
            lstVars.ExternalItems = null;
            lstVars.Filter = null;
            lstVars.FilterColumn = 0;
            lstVars.FilterSearchType = ODModules.ListControl.FilterSearch.Contains;
            lstVars.GridlineColor = Color.LightGray;
            lstVars.HighlightStrength = 128;
            lstVars.HorizontalScrollStep = 3;
            lstVars.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstVars.LineMarkerIndex = 0;
            lstVars.Location = new Point(0, 0);
            lstVars.Margin = new Padding(6, 6, 6, 6);
            lstVars.MarkerBorderColor = Color.LimeGreen;
            lstVars.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstVars.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstVars.MoveControlOnCellChange = true;
            lstVars.Name = "lstVars";
            lstVars.RowColor = Color.LightGray;
            lstVars.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstVars.ScrollBarNorth = Color.DarkTurquoise;
            lstVars.ScrollBarSouth = Color.DeepSkyBlue;
            lstVars.ScrollItems = 3;
            lstVars.SelectedColor = Color.SkyBlue;
            lstVars.SelectionColor = Color.Gray;
            lstVars.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstVars.ShowCellSelection = false;
            lstVars.ShowGrid = true;
            lstVars.ShowHeader = true;
            lstVars.ShowItemIndentation = false;
            lstVars.ShowMarker = false;
            lstVars.ShowRowColors = false;
            lstVars.Size = new Size(505, 533);
            lstVars.SpanColumn = 2;
            lstVars.TabIndex = 2;
            cntrlExtender.SetTranslationReference(lstVars, "");
            lstVars.UseLocalList = true;
            lstVars.VerScroll = 0;
            lstVars.Zoom = 100;
            lstVars.DropDownClicked += lstVars_DropDownClicked;
            // 
            // tabpgArray
            // 
            tabpgArray.Controls.Add(lstArray);
            tabpgArray.Font = new Font("Segoe UI", 9F);
            tabpgArray.Location = new Point(4, 24);
            tabpgArray.Margin = new Padding(6, 6, 6, 6);
            tabpgArray.Name = "tabpgArray";
            tabpgArray.Size = new Size(505, 533);
            tabpgArray.TabIndex = 0;
            tabpgArray.Text = "Array";
            cntrlExtender.SetTranslationReference(tabpgArray, "");
            tabpgArray.UseVisualStyleBackColor = true;
            // 
            // lstArray
            // 
            lstArray.AllowArrowKeyCellSelect = false;
            lstArray.AllowColumnSpanning = true;
            lstArray.AllowMouseWheel = true;
            lstArray.BorderColor = Color.Gray;
            lstArray.Borders = ODModules.Borders.None;
            lstArray.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            lstArray.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            lstArray.CellPixelFit = true;
            lstArray.CellSelectEditableOnly = true;
            lstArray.CellSelectionBorderColor = Color.Blue;
            lstArray.ColumnColor = Color.LightGray;
            lstArray.ColumnForeColor = Color.Black;
            lstArray.ColumnLineColor = Color.DimGray;
            column7.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column7.CountOffset = 0;
            column7.DataFormat = ODModules.ColumnDataFormat.None;
            column7.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column7.DropDownRight = false;
            column7.DropDownVisible = true;
            column7.Exportable = false;
            column7.ExportName = "";
            column7.FixedWidth = false;
            column7.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column7.Text = "";
            column7.UseItemBackColor = false;
            column7.UseItemForeColor = false;
            column7.Visible = true;
            column7.Width = 60;
            column8.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column8.CountOffset = 0;
            column8.DataFormat = ODModules.ColumnDataFormat.None;
            column8.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column8.DropDownRight = false;
            column8.DropDownVisible = false;
            column8.Exportable = false;
            column8.ExportName = "";
            column8.FixedWidth = true;
            column8.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column8.Text = "Value";
            column8.UseItemBackColor = false;
            column8.UseItemForeColor = false;
            column8.Visible = true;
            column8.Width = 208;
            lstArray.Columns.Add(column7);
            lstArray.Columns.Add(column8);
            lstArray.ContextMenuStrip = cmArray;
            lstArray.Dock = DockStyle.Fill;
            lstArray.DropDownMouseDown = Color.DimGray;
            lstArray.DropDownMouseOver = Color.LightGray;
            lstArray.ExternalItems = null;
            lstArray.Filter = null;
            lstArray.FilterColumn = 0;
            lstArray.FilterSearchType = ODModules.ListControl.FilterSearch.Contains;
            lstArray.GridlineColor = Color.LightGray;
            lstArray.HighlightStrength = 128;
            lstArray.HorizontalScrollStep = 3;
            lstArray.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstArray.LineMarkerIndex = 0;
            lstArray.Location = new Point(0, 0);
            lstArray.Margin = new Padding(6, 6, 6, 6);
            lstArray.MarkerBorderColor = Color.LimeGreen;
            lstArray.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstArray.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstArray.MoveControlOnCellChange = true;
            lstArray.Name = "lstArray";
            lstArray.RowColor = Color.LightGray;
            lstArray.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstArray.ScrollBarNorth = Color.DarkTurquoise;
            lstArray.ScrollBarSouth = Color.DeepSkyBlue;
            lstArray.ScrollItems = 3;
            lstArray.SelectedColor = Color.SkyBlue;
            lstArray.SelectionColor = Color.Gray;
            lstArray.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstArray.ShowCellSelection = false;
            lstArray.ShowGrid = true;
            lstArray.ShowHeader = true;
            lstArray.ShowItemIndentation = false;
            lstArray.ShowMarker = false;
            lstArray.ShowRowColors = false;
            lstArray.Size = new Size(505, 533);
            lstArray.SpanColumn = 1;
            lstArray.TabIndex = 0;
            cntrlExtender.SetTranslationReference(lstArray, "");
            lstArray.UseLocalList = true;
            lstArray.VerScroll = 0;
            lstArray.Zoom = 100;
            lstArray.DropDownClicked += lstArray_DropDownClicked;
            // 
            // msMain
            // 
            msMain.BackColorNorth = Color.DodgerBlue;
            msMain.BackColorNorthFadeIn = Color.DodgerBlue;
            msMain.BackColorSouth = Color.DodgerBlue;
            msMain.Fade = true;
            msMain.ImageScalingSize = new Size(32, 32);
            msMain.ItemForeColor = Color.Black;
            msMain.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, valuesToolStripMenuItem, viewToolStripMenuItem });
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
            msMain.Size = new Size(513, 44);
            msMain.StripItemSelectedBackColorNorth = Color.White;
            msMain.StripItemSelectedBackColorSouth = Color.White;
            msMain.TabIndex = 9;
            msMain.Text = "menuStrip1";
            cntrlExtender.SetTranslationReference(msMain, "");
            msMain.UseNorthFadeIn = false;
            msMain.ItemClicked += msMain_ItemClicked;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { moveUpToolStripMenuItem, moveDownToolStripMenuItem, toolStripSeparator2, cutToolStripMenuItem1, copyToolStripMenuItem1, pasteToolStripMenuItem1, deleteToolStripMenuItem1, toolStripSeparator1, selectAllToolStripMenuItem });
            editToolStripMenuItem.ForeColor = Color.Black;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(74, 36);
            editToolStripMenuItem.Text = "&Edit";
            tsiExtender.SetTranslationReference(editToolStripMenuItem, "edit");
            // 
            // moveUpToolStripMenuItem
            // 
            moveUpToolStripMenuItem.Enabled = false;
            moveUpToolStripMenuItem.ForeColor = Color.Black;
            moveUpToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            moveUpToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Up;
            moveUpToolStripMenuItem.Size = new Size(406, 44);
            moveUpToolStripMenuItem.Text = "Move &Up";
            tsiExtender.SetTranslationReference(moveUpToolStripMenuItem, "moveUp");
            moveUpToolStripMenuItem.Click += moveUpToolStripMenuItem_Click;
            // 
            // moveDownToolStripMenuItem
            // 
            moveDownToolStripMenuItem.Enabled = false;
            moveDownToolStripMenuItem.ForeColor = Color.Black;
            moveDownToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            moveDownToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Down;
            moveDownToolStripMenuItem.Size = new Size(406, 44);
            moveDownToolStripMenuItem.Text = "Move &Down";
            tsiExtender.SetTranslationReference(moveDownToolStripMenuItem, "moveDown");
            moveDownToolStripMenuItem.Click += moveDownToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(403, 6);
            tsiExtender.SetTranslationReference(toolStripSeparator2, "");
            // 
            // cutToolStripMenuItem1
            // 
            cutToolStripMenuItem1.ForeColor = Color.Black;
            cutToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            cutToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem1.Size = new Size(406, 44);
            cutToolStripMenuItem1.Text = "&Cut";
            tsiExtender.SetTranslationReference(cutToolStripMenuItem1, "cut");
            cutToolStripMenuItem1.Click += cutToolStripMenuItem1_Click;
            // 
            // copyToolStripMenuItem1
            // 
            copyToolStripMenuItem1.ForeColor = Color.Black;
            copyToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            copyToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem1.Size = new Size(406, 44);
            copyToolStripMenuItem1.Text = "&Copy";
            tsiExtender.SetTranslationReference(copyToolStripMenuItem1, "copy");
            copyToolStripMenuItem1.Click += copyToolStripMenuItem1_Click;
            // 
            // pasteToolStripMenuItem1
            // 
            pasteToolStripMenuItem1.Enabled = false;
            pasteToolStripMenuItem1.ForeColor = Color.Black;
            pasteToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            pasteToolStripMenuItem1.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem1.Size = new Size(406, 44);
            pasteToolStripMenuItem1.Text = "&Paste";
            tsiExtender.SetTranslationReference(pasteToolStripMenuItem1, "paste");
            pasteToolStripMenuItem1.Click += pasteToolStripMenuItem1_Click;
            // 
            // deleteToolStripMenuItem1
            // 
            deleteToolStripMenuItem1.ForeColor = Color.Black;
            deleteToolStripMenuItem1.ImageScaling = ToolStripItemImageScaling.None;
            deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            deleteToolStripMenuItem1.ShortcutKeys = Keys.Delete;
            deleteToolStripMenuItem1.Size = new Size(406, 44);
            deleteToolStripMenuItem1.Text = "&Delete";
            tsiExtender.SetTranslationReference(deleteToolStripMenuItem1, "delete");
            deleteToolStripMenuItem1.Click += deleteToolStripMenuItem1_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(403, 6);
            tsiExtender.SetTranslationReference(toolStripSeparator1, "");
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.ForeColor = Color.Black;
            selectAllToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllToolStripMenuItem.Size = new Size(406, 44);
            selectAllToolStripMenuItem.Text = "&Select All";
            tsiExtender.SetTranslationReference(selectAllToolStripMenuItem, "selectAll");
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            // 
            // valuesToolStripMenuItem
            // 
            valuesToolStripMenuItem.ForeColor = Color.Black;
            valuesToolStripMenuItem.Name = "valuesToolStripMenuItem";
            valuesToolStripMenuItem.Size = new Size(102, 36);
            valuesToolStripMenuItem.Text = "&Values";
            tsiExtender.SetTranslationReference(valuesToolStripMenuItem, "");
            valuesToolStripMenuItem.Visible = false;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { globalVariablesToolStripMenuItem, localVariablesToolStripMenuItem, arrayToolStripMenuItem, toolStripSeparator3, topMostToolStripMenuItem });
            viewToolStripMenuItem.ForeColor = Color.Black;
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(85, 36);
            viewToolStripMenuItem.Text = "&View";
            tsiExtender.SetTranslationReference(viewToolStripMenuItem, "view");
            // 
            // globalVariablesToolStripMenuItem
            // 
            globalVariablesToolStripMenuItem.Checked = true;
            globalVariablesToolStripMenuItem.CheckState = CheckState.Checked;
            globalVariablesToolStripMenuItem.ForeColor = Color.Black;
            globalVariablesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            globalVariablesToolStripMenuItem.Name = "globalVariablesToolStripMenuItem";
            globalVariablesToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D1;
            globalVariablesToolStripMenuItem.Size = new Size(388, 44);
            globalVariablesToolStripMenuItem.Text = "&Global Variables";
            tsiExtender.SetTranslationReference(globalVariablesToolStripMenuItem, "globalVariables");
            globalVariablesToolStripMenuItem.Click += globalVariablesToolStripMenuItem_Click;
            // 
            // localVariablesToolStripMenuItem
            // 
            localVariablesToolStripMenuItem.ForeColor = Color.Black;
            localVariablesToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            localVariablesToolStripMenuItem.Name = "localVariablesToolStripMenuItem";
            localVariablesToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D2;
            localVariablesToolStripMenuItem.Size = new Size(388, 44);
            localVariablesToolStripMenuItem.Text = "&Local Variables";
            tsiExtender.SetTranslationReference(localVariablesToolStripMenuItem, "localVariables");
            localVariablesToolStripMenuItem.Click += localVariablesToolStripMenuItem_Click;
            // 
            // arrayToolStripMenuItem
            // 
            arrayToolStripMenuItem.ForeColor = Color.Black;
            arrayToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            arrayToolStripMenuItem.Name = "arrayToolStripMenuItem";
            arrayToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D3;
            arrayToolStripMenuItem.Size = new Size(388, 44);
            arrayToolStripMenuItem.Text = "&Array";
            tsiExtender.SetTranslationReference(arrayToolStripMenuItem, "array");
            arrayToolStripMenuItem.Click += arrayToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(385, 6);
            tsiExtender.SetTranslationReference(toolStripSeparator3, "");
            // 
            // topMostToolStripMenuItem
            // 
            topMostToolStripMenuItem.ForeColor = Color.Black;
            topMostToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            topMostToolStripMenuItem.Size = new Size(388, 44);
            topMostToolStripMenuItem.Text = "&Top Most";
            tsiExtender.SetTranslationReference(topMostToolStripMenuItem, "topMost");
            topMostToolStripMenuItem.Click += topMostToolStripMenuItem_Click;
            // 
            // Variables
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 670);
            Controls.Add(tbVars);
            Controls.Add(thDataPagesHeader);
            Controls.Add(msMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = msMain;
            Margin = new Padding(6, 6, 6, 6);
            Name = "Variables";
            Text = "Variables";
            HelpButtonClicked += Variables_HelpButtonClicked;
            FormClosing += Variables_FormClosing;
            Load += Variables_Load;
            tbVars.ResumeLayout(false);
            tbpgGlobals.ResumeLayout(false);
            cmArray.ResumeLayout(false);
            tbpgVariables.ResumeLayout(false);
            tabpgArray.ResumeLayout(false);
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private TabPage tbpgVariables;
        private ODModules.ListControl lstVars;
        private ODModules.MenuStrip msMain;
        private ToolStripMenuItem valuesToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem topMostToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem1;
        private ToolStripMenuItem copyToolStripMenuItem1;
        private ToolStripMenuItem pasteToolStripMenuItem1;
        private ToolStripMenuItem deleteToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem moveUpToolStripMenuItem;
        private ToolStripMenuItem moveDownToolStripMenuItem;
        private ToolStripMenuItem globalVariablesToolStripMenuItem;
        private ToolStripMenuItem localVariablesToolStripMenuItem;
        private ToolStripMenuItem arrayToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ODModules.ControlExtensions.ControlExtender cntrlExtender;
        private ODModules.ControlExtensions.ToolStripItemExtender tsiExtender;
    }
}