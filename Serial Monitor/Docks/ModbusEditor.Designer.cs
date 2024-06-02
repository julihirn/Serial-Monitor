namespace Serial_Monitor.Docks {
    partial class ModbusEditor {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            ODModules.Tab tab2 = new ODModules.Tab();
            ODModules.Column column1 = new ODModules.Column();
            ODModules.Column column2 = new ODModules.Column();
            ODModules.Column column3 = new ODModules.Column();
            ODModules.Column column4 = new ODModules.Column();
            ODModules.Column column5 = new ODModules.Column();
            ODModules.Column column6 = new ODModules.Column();
            ODModules.Column column7 = new ODModules.Column();
            ODModules.ListItem listItem1 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem1 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem2 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem3 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem4 = new ODModules.ListSubItem();
            ODModules.Tab tab1 = new ODModules.Tab();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModbusEditor));
            thDataPagesHeader = new ODModules.TabHeader();
            tbDataPages = new ODModules.HiddenTabControl();
            tpRegisters = new TabPage();
            lstMonitor = new ODModules.ListControl();
            thSlaves = new ODModules.TabHeader();
            navigator1 = new ODModules.Navigator();
            tpRegisterFiltering = new TabPage();
            ssClient = new Components.SnapshotClient();
            tbDataPages.SuspendLayout();
            tpRegisters.SuspendLayout();
            tpRegisterFiltering.SuspendLayout();
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
            thDataPagesHeader.BindedTabControl = tbDataPages;
            thDataPagesHeader.BorderColor = Color.Gray;
            thDataPagesHeader.Borders = ODModules.Borders.None;
            thDataPagesHeader.CloseHoverColor = Color.Brown;
            thDataPagesHeader.Dock = DockStyle.Top;
            thDataPagesHeader.ForeColor = Color.White;
            thDataPagesHeader.HeaderDownForeColor = Color.Gray;
            thDataPagesHeader.HeaderForeColor = Color.Black;
            thDataPagesHeader.HeaderHoverForeColor = Color.Blue;
            thDataPagesHeader.Location = new Point(0, 0);
            thDataPagesHeader.Name = "thDataPagesHeader";
            thDataPagesHeader.Padding = new Padding(5, 0, 0, 0);
            thDataPagesHeader.SelectedIndex = 0;
            thDataPagesHeader.ShowAddButton = false;
            thDataPagesHeader.ShowHeader = false;
            thDataPagesHeader.ShowTabDividers = true;
            thDataPagesHeader.ShowTabs = true;
            thDataPagesHeader.Size = new Size(473, 27);
            thDataPagesHeader.TabBackColor = Color.Transparent;
            thDataPagesHeader.TabBorderColor = Color.Transparent;
            thDataPagesHeader.TabClickedBackColor = Color.DarkGray;
            thDataPagesHeader.TabDividerColor = Color.White;
            thDataPagesHeader.TabHoverBackColor = Color.LightGray;
            thDataPagesHeader.TabIndex = 7;
            thDataPagesHeader.TabRuleColor = Color.FromArgb(100, 128, 128, 128);
            tab2.Selected = true;
            tab2.Tag = null;
            tab2.Text = "";
            thDataPagesHeader.Tabs.Add(tab2);
            thDataPagesHeader.TabSelectedBackColor = Color.FromArgb(100, 128, 128, 128);
            thDataPagesHeader.TabSelectedBorderColor = Color.FromArgb(100, 128, 128, 128);
            thDataPagesHeader.TabSelectedForeColor = Color.WhiteSmoke;
            thDataPagesHeader.TabSelectedShadowColor = Color.Black;
            thDataPagesHeader.TabStyle = ODModules.TabHeader.TabStyles.Normal;
            thDataPagesHeader.UseBindingTabControl = true;
            thDataPagesHeader.Load += thDataPagesHeader_Load;
            // 
            // tbDataPages
            // 
            tbDataPages.Controls.Add(tpRegisters);
            tbDataPages.Controls.Add(tpRegisterFiltering);
            tbDataPages.DebugMode = true;
            tbDataPages.DefaultColor1 = Color.FromArgb(12, 12, 12);
            tbDataPages.Dock = DockStyle.Fill;
            tbDataPages.DrawMode = TabDrawMode.OwnerDrawFixed;
            tbDataPages.ForeColor = Color.White;
            tbDataPages.ItemSize = new Size(20, 20);
            tbDataPages.Location = new Point(0, 27);
            tbDataPages.Margin = new Padding(0);
            tbDataPages.Multiline = true;
            tbDataPages.Name = "tbDataPages";
            tbDataPages.SelectedIndex = 0;
            tbDataPages.Size = new Size(473, 352);
            tbDataPages.TabIndex = 8;
            // 
            // tpRegisters
            // 
            tpRegisters.Controls.Add(lstMonitor);
            tpRegisters.Controls.Add(thSlaves);
            tpRegisters.Controls.Add(navigator1);
            tpRegisters.Font = new Font("Segoe UI", 9F);
            tpRegisters.Location = new Point(4, 24);
            tpRegisters.Name = "tpRegisters";
            tpRegisters.Size = new Size(465, 324);
            tpRegisters.TabIndex = 0;
            tpRegisters.Text = "Master View";
            tpRegisters.UseVisualStyleBackColor = true;
            // 
            // lstMonitor
            // 
            lstMonitor.AllowColumnSpanning = false;
            lstMonitor.AllowMouseWheel = true;
            lstMonitor.BackColor = Color.FromArgb(20, 20, 20);
            lstMonitor.BorderColor = Color.Gray;
            lstMonitor.Borders = ODModules.Borders.BottomAndRight;
            lstMonitor.ColumnColor = Color.FromArgb(30, 30, 30);
            lstMonitor.ColumnForeColor = Color.WhiteSmoke;
            lstMonitor.ColumnLineColor = Color.FromArgb(64, 64, 64);
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column1.CountOffset = 0;
            column1.DataFormat = ODModules.ColumnDataFormat.Integer;
            column1.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column1.DropDownRight = false;
            column1.DropDownVisible = false;
            column1.Exportable = true;
            column1.ExportName = "address";
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column1.Text = "";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 50;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DataFormat = ODModules.ColumnDataFormat.None;
            column2.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column2.DropDownRight = false;
            column2.DropDownVisible = false;
            column2.Exportable = true;
            column2.ExportName = "";
            column2.FixedWidth = false;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column2.Text = "Name";
            column2.UseItemBackColor = true;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 100;
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column3.CountOffset = 0;
            column3.DataFormat = ODModules.ColumnDataFormat.Text;
            column3.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column3.DropDownRight = false;
            column3.DropDownVisible = true;
            column3.Exportable = true;
            column3.ExportName = "";
            column3.FixedWidth = false;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column3.Text = "Display";
            column3.UseItemBackColor = false;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 80;
            column4.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column4.CountOffset = 0;
            column4.DataFormat = ODModules.ColumnDataFormat.Integer;
            column4.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column4.DropDownRight = false;
            column4.DropDownVisible = true;
            column4.Exportable = true;
            column4.ExportName = "";
            column4.FixedWidth = true;
            column4.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column4.Text = "Size";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 75;
            column5.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column5.CountOffset = 0;
            column5.DataFormat = ODModules.ColumnDataFormat.Boolean;
            column5.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column5.DropDownRight = false;
            column5.DropDownVisible = true;
            column5.Exportable = true;
            column5.ExportName = "";
            column5.FixedWidth = true;
            column5.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column5.Text = "Signed";
            column5.UseItemBackColor = false;
            column5.UseItemForeColor = false;
            column5.Visible = true;
            column5.Width = 50;
            column6.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column6.CountOffset = 0;
            column6.DataFormat = ODModules.ColumnDataFormat.None;
            column6.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column6.DropDownRight = false;
            column6.DropDownVisible = false;
            column6.Exportable = true;
            column6.ExportName = "";
            column6.FixedWidth = false;
            column6.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column6.Text = "Value";
            column6.UseItemBackColor = false;
            column6.UseItemForeColor = false;
            column6.Visible = true;
            column6.Width = 80;
            column7.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column7.CountOffset = 0;
            column7.DataFormat = ODModules.ColumnDataFormat.Text;
            column7.DisplayType = ODModules.ColumnDisplayType.Text;
            column7.DropDownRight = false;
            column7.DropDownVisible = true;
            column7.Exportable = true;
            column7.ExportName = "";
            column7.FixedWidth = false;
            column7.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column7.Text = "Last Updated";
            column7.UseItemBackColor = false;
            column7.UseItemForeColor = false;
            column7.Visible = false;
            column7.Width = 100;
            lstMonitor.Columns.Add(column1);
            lstMonitor.Columns.Add(column2);
            lstMonitor.Columns.Add(column3);
            lstMonitor.Columns.Add(column4);
            lstMonitor.Columns.Add(column5);
            lstMonitor.Columns.Add(column6);
            lstMonitor.Columns.Add(column7);
            lstMonitor.Dock = DockStyle.Fill;
            lstMonitor.DropDownMouseDown = Color.DimGray;
            lstMonitor.DropDownMouseOver = Color.LightGray;
            lstMonitor.ExternalItems = null;
            lstMonitor.Filter = null;
            lstMonitor.FilterColumn = 0;
            lstMonitor.ForeColor = Color.White;
            lstMonitor.GridlineColor = Color.FromArgb(30, 30, 30);
            lstMonitor.HighlightStrength = 128;
            lstMonitor.HorizontalScrollStep = 3;
            lstMonitor.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            listItem1.BackColor = Color.Transparent;
            listItem1.Checked = false;
            listItem1.ForeColor = Color.Black;
            listItem1.Indentation = 0U;
            listItem1.LineBackColor = Color.Transparent;
            listItem1.LineForeColor = Color.Black;
            listItem1.Name = "";
            listItem1.Selected = false;
            listSubItem1.BackColor = Color.Transparent;
            listSubItem1.Checked = false;
            listSubItem1.ForeColor = Color.Black;
            listSubItem1.Indentation = 0U;
            listSubItem1.Name = "";
            listSubItem1.Tag = null;
            listSubItem1.Text = "";
            listSubItem1.Value = 0;
            listSubItem2.BackColor = Color.Transparent;
            listSubItem2.Checked = false;
            listSubItem2.ForeColor = Color.Black;
            listSubItem2.Indentation = 0U;
            listSubItem2.Name = "";
            listSubItem2.Tag = null;
            listSubItem2.Text = "";
            listSubItem2.Value = 0;
            listSubItem3.BackColor = Color.Transparent;
            listSubItem3.Checked = false;
            listSubItem3.ForeColor = Color.Black;
            listSubItem3.Indentation = 0U;
            listSubItem3.Name = "";
            listSubItem3.Tag = null;
            listSubItem3.Text = "";
            listSubItem3.Value = 0;
            listSubItem4.BackColor = Color.Transparent;
            listSubItem4.Checked = false;
            listSubItem4.ForeColor = Color.Black;
            listSubItem4.Indentation = 0U;
            listSubItem4.Name = "";
            listSubItem4.Tag = null;
            listSubItem4.Text = "";
            listSubItem4.Value = 0;
            listItem1.SubItems.Add(listSubItem1);
            listItem1.SubItems.Add(listSubItem2);
            listItem1.SubItems.Add(listSubItem3);
            listItem1.SubItems.Add(listSubItem4);
            listItem1.Tag = null;
            listItem1.Text = "";
            listItem1.UseLineBackColor = false;
            listItem1.UseLineForeColor = false;
            listItem1.Value = 0;
            lstMonitor.Items.Add(listItem1);
            lstMonitor.LineMarkerIndex = 0;
            lstMonitor.Location = new Point(81, 27);
            lstMonitor.MarkerBorderColor = Color.LimeGreen;
            lstMonitor.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstMonitor.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstMonitor.Name = "lstMonitor";
            lstMonitor.RowColor = Color.FromArgb(23, 23, 23);
            lstMonitor.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstMonitor.ScrollBarNorth = Color.FromArgb(64, 64, 64);
            lstMonitor.ScrollBarSouth = Color.FromArgb(64, 64, 64);
            lstMonitor.ScrollItems = 3;
            lstMonitor.SelectedColor = Color.SteelBlue;
            lstMonitor.SelectionColor = Color.Gray;
            lstMonitor.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstMonitor.ShowGrid = true;
            lstMonitor.ShowItemIndentation = false;
            lstMonitor.ShowMarker = false;
            lstMonitor.ShowRowColors = true;
            lstMonitor.Size = new Size(384, 297);
            lstMonitor.SpanColumn = -1;
            lstMonitor.TabIndex = 3;
            lstMonitor.UseLocalList = false;
            lstMonitor.VerScroll = 0;
            lstMonitor.Zoom = 100;
            // 
            // thSlaves
            // 
            thSlaves.AddHoverColor = Color.LimeGreen;
            thSlaves.AllowDragReordering = true;
            thSlaves.AllowTabResize = true;
            thSlaves.ArrowColor = Color.DarkGray;
            thSlaves.ArrowDisabledColor = Color.FromArgb(128, 0, 0, 0);
            thSlaves.ArrowHoverColor = Color.SteelBlue;
            thSlaves.BackColor = Color.FromArgb(31, 31, 31);
            thSlaves.BindedTabControl = null;
            thSlaves.BorderColor = Color.Gray;
            thSlaves.Borders = ODModules.Borders.Right;
            thSlaves.CloseHoverColor = Color.Brown;
            thSlaves.Dock = DockStyle.Top;
            thSlaves.ForeColor = Color.White;
            thSlaves.HeaderDownForeColor = Color.Gray;
            thSlaves.HeaderForeColor = Color.Black;
            thSlaves.HeaderHoverForeColor = Color.Blue;
            thSlaves.Location = new Point(81, 0);
            thSlaves.Name = "thSlaves";
            thSlaves.Padding = new Padding(5, 0, 0, 0);
            thSlaves.SelectedIndex = 0;
            thSlaves.ShowAddButton = false;
            thSlaves.ShowHeader = true;
            thSlaves.ShowTabDividers = true;
            thSlaves.ShowTabs = true;
            thSlaves.Size = new Size(384, 27);
            thSlaves.TabBackColor = Color.Transparent;
            thSlaves.TabBorderColor = Color.Transparent;
            thSlaves.TabClickedBackColor = Color.DarkGray;
            thSlaves.TabDividerColor = Color.White;
            thSlaves.TabHoverBackColor = Color.LightGray;
            thSlaves.TabIndex = 7;
            thSlaves.TabRuleColor = Color.FromArgb(100, 128, 128, 128);
            tab1.Selected = true;
            tab1.Tag = null;
            tab1.Text = "Main";
            thSlaves.Tabs.Add(tab1);
            thSlaves.TabSelectedBackColor = Color.FromArgb(100, 128, 128, 128);
            thSlaves.TabSelectedBorderColor = Color.FromArgb(100, 128, 128, 128);
            thSlaves.TabSelectedForeColor = Color.WhiteSmoke;
            thSlaves.TabSelectedShadowColor = Color.Black;
            thSlaves.TabStyle = ODModules.TabHeader.TabStyles.Normal;
            thSlaves.UseBindingTabControl = false;
            // 
            // navigator1
            // 
            navigator1.ArrowColor = Color.Black;
            navigator1.ArrowMouseOverColor = Color.DodgerBlue;
            navigator1.BackColor = Color.FromArgb(40, 40, 40);
            navigator1.BorderColor = Color.Gray;
            navigator1.Borders = ODModules.Borders.BottomAndLeft;
            navigator1.DisplayStyle = ODModules.Navigator.Style.Right;
            navigator1.DisplayText = "StateName";
            navigator1.DividerBorderColor = Color.FromArgb(0, 0, 0);
            navigator1.Dock = DockStyle.Left;
            navigator1.ForeColor = Color.White;
            navigator1.LinkedList = null;
            navigator1.Location = new Point(0, 0);
            navigator1.MidColor = Color.FromArgb(20, 20, 20);
            navigator1.Name = "navigator1";
            navigator1.SelectedColor = Color.FromArgb(60, 0, 0, 0);
            navigator1.SelectedItem = -1;
            navigator1.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            navigator1.ShowAnimations = true;
            navigator1.ShowBorder = true;
            navigator1.ShowStatuses = false;
            navigator1.SideShadowColor = Color.FromArgb(20, 0, 0, 0);
            navigator1.Size = new Size(81, 324);
            navigator1.Status1 = (ODModules.StatusCondition)resources.GetObject("navigator1.Status1");
            navigator1.Status2 = (ODModules.StatusCondition)resources.GetObject("navigator1.Status2");
            navigator1.Status3 = (ODModules.StatusCondition)resources.GetObject("navigator1.Status3");
            navigator1.StatusData = "Status";
            navigator1.TabIndex = 2;
            // 
            // tpRegisterFiltering
            // 
            tpRegisterFiltering.Controls.Add(ssClient);
            tpRegisterFiltering.Font = new Font("Segoe UI", 9F);
            tpRegisterFiltering.Location = new Point(4, 24);
            tpRegisterFiltering.Name = "tpRegisterFiltering";
            tpRegisterFiltering.Size = new Size(465, 324);
            tpRegisterFiltering.TabIndex = 1;
            tpRegisterFiltering.Text = "Snapshot View";
            tpRegisterFiltering.UseVisualStyleBackColor = true;
            // 
            // ssClient
            // 
            ssClient.BorderColor = Color.Gray;
            ssClient.Dock = DockStyle.Fill;
            ssClient.Location = new Point(0, 0);
            ssClient.Name = "ssClient";
            ssClient.Padding = new Padding(1);
            ssClient.SelectorCollection = null;
            ssClient.Size = new Size(465, 324);
            ssClient.TabIndex = 1;
            ssClient.TileWindows = false;
            // 
            // ModbusEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tbDataPages);
            Controls.Add(thDataPagesHeader);
            DockText = "Modbus Editor";
            DoubleBuffered = true;
            Name = "ModbusEditor";
            SerializationKey = "mbEditor";
            Size = new Size(473, 379);
            Load += ModbusEditor_Load;
            tbDataPages.ResumeLayout(false);
            tpRegisters.ResumeLayout(false);
            tpRegisterFiltering.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabPage tpRegisters;
        private TabPage tpRegisterFiltering;
        internal ODModules.TabHeader thDataPagesHeader;
        internal ODModules.ListControl lstMonitor;
        internal ODModules.TabHeader thSlaves;
        internal ODModules.Navigator navigator1;
        internal Components.SnapshotClient ssClient;
        internal ODModules.HiddenTabControl tbDataPages;
    }
}
