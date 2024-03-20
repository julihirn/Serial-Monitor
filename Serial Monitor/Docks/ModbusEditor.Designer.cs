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
            ODModules.Tab tab1 = new ODModules.Tab();
            ODModules.Column column13 = new ODModules.Column();
            ODModules.Column column14 = new ODModules.Column();
            ODModules.Column column15 = new ODModules.Column();
            ODModules.Column column16 = new ODModules.Column();
            ODModules.Column column17 = new ODModules.Column();
            ODModules.Column column18 = new ODModules.Column();
            ODModules.ListItem listItem3 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem9 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem10 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem11 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem12 = new ODModules.ListSubItem();
            ODModules.Tab tab3 = new ODModules.Tab();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModbusEditor));
            thDataPagesHeader = new ODModules.TabHeader();
            tbDataPages = new ODModules.HiddenTabControl();
            tpRegisters = new TabPage();
            lstMonitor = new ODModules.ListControl();
            thSlaves = new ODModules.TabHeader();
            navigator1 = new ODModules.Navigator();
            tpRegisterFiltering = new TabPage();
            ssClient = new Components.SnapshotClient();
            pnlInset = new Panel();
            tbDataPages.SuspendLayout();
            tpRegisters.SuspendLayout();
            tpRegisterFiltering.SuspendLayout();
            pnlInset.SuspendLayout();
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
            thDataPagesHeader.CloseHoverColor = Color.Brown;
            thDataPagesHeader.Dock = DockStyle.Top;
            thDataPagesHeader.ForeColor = Color.White;
            thDataPagesHeader.HeaderDownForeColor = Color.Gray;
            thDataPagesHeader.HeaderForeColor = Color.Black;
            thDataPagesHeader.HeaderHoverForeColor = Color.Blue;
            thDataPagesHeader.Location = new Point(0, 0);
            thDataPagesHeader.Name = "thDataPagesHeader";
            thDataPagesHeader.Padding = new Padding(5, 0, 0, 0);
            thDataPagesHeader.SelectedIndex = 1;
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
            tbDataPages.Location = new Point(1, 0);
            tbDataPages.Margin = new Padding(0);
            tbDataPages.Multiline = true;
            tbDataPages.Name = "tbDataPages";
            tbDataPages.SelectedIndex = 0;
            tbDataPages.Size = new Size(471, 351);
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
            tpRegisters.Size = new Size(463, 322);
            tpRegisters.TabIndex = 0;
            tpRegisters.Text = "Master View";
            tpRegisters.UseVisualStyleBackColor = true;
            // 
            // lstMonitor
            // 
            lstMonitor.AllowColumnSpanning = false;
            lstMonitor.AllowMouseWheel = true;
            lstMonitor.BackColor = Color.FromArgb(20, 20, 20);
            lstMonitor.ColumnColor = Color.FromArgb(30, 30, 30);
            lstMonitor.ColumnForeColor = Color.WhiteSmoke;
            lstMonitor.ColumnLineColor = Color.FromArgb(64, 64, 64);
            column13.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column13.CountOffset = 0;
            column13.DataFormat = ODModules.ColumnDataFormat.None;
            column13.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column13.DropDownRight = false;
            column13.DropDownVisible = false;
            column13.Exportable = false;
            column13.FixedWidth = false;
            column13.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column13.Text = "";
            column13.UseItemBackColor = false;
            column13.UseItemForeColor = false;
            column13.Visible = true;
            column13.Width = 50;
            column14.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column14.CountOffset = 0;
            column14.DataFormat = ODModules.ColumnDataFormat.None;
            column14.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column14.DropDownRight = false;
            column14.DropDownVisible = false;
            column14.Exportable = false;
            column14.FixedWidth = false;
            column14.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column14.Text = "Name";
            column14.UseItemBackColor = true;
            column14.UseItemForeColor = false;
            column14.Visible = true;
            column14.Width = 100;
            column15.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column15.CountOffset = 0;
            column15.DataFormat = ODModules.ColumnDataFormat.None;
            column15.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column15.DropDownRight = false;
            column15.DropDownVisible = true;
            column15.Exportable = false;
            column15.FixedWidth = false;
            column15.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column15.Text = "Display";
            column15.UseItemBackColor = false;
            column15.UseItemForeColor = false;
            column15.Visible = true;
            column15.Width = 80;
            column16.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column16.CountOffset = 0;
            column16.DataFormat = ODModules.ColumnDataFormat.None;
            column16.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column16.DropDownRight = false;
            column16.DropDownVisible = true;
            column16.Exportable = false;
            column16.FixedWidth = true;
            column16.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column16.Text = "Size";
            column16.UseItemBackColor = false;
            column16.UseItemForeColor = false;
            column16.Visible = true;
            column16.Width = 75;
            column17.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column17.CountOffset = 0;
            column17.DataFormat = ODModules.ColumnDataFormat.None;
            column17.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column17.DropDownRight = false;
            column17.DropDownVisible = true;
            column17.Exportable = false;
            column17.FixedWidth = true;
            column17.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column17.Text = "Signed";
            column17.UseItemBackColor = false;
            column17.UseItemForeColor = false;
            column17.Visible = true;
            column17.Width = 50;
            column18.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column18.CountOffset = 0;
            column18.DataFormat = ODModules.ColumnDataFormat.None;
            column18.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column18.DropDownRight = false;
            column18.DropDownVisible = false;
            column18.Exportable = false;
            column18.FixedWidth = false;
            column18.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column18.Text = "Value";
            column18.UseItemBackColor = false;
            column18.UseItemForeColor = false;
            column18.Visible = true;
            column18.Width = 120;
            lstMonitor.Columns.Add(column13);
            lstMonitor.Columns.Add(column14);
            lstMonitor.Columns.Add(column15);
            lstMonitor.Columns.Add(column16);
            lstMonitor.Columns.Add(column17);
            lstMonitor.Columns.Add(column18);
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
            listItem3.BackColor = Color.Transparent;
            listItem3.Checked = false;
            listItem3.ForeColor = Color.Black;
            listItem3.Indentation = 0U;
            listItem3.LineBackColor = Color.Transparent;
            listItem3.LineForeColor = Color.Black;
            listItem3.Name = "";
            listItem3.Selected = false;
            listSubItem9.BackColor = Color.Transparent;
            listSubItem9.Checked = false;
            listSubItem9.ForeColor = Color.Black;
            listSubItem9.Indentation = 0U;
            listSubItem9.Name = "";
            listSubItem9.Tag = null;
            listSubItem9.Text = "";
            listSubItem9.Value = 0;
            listSubItem10.BackColor = Color.Transparent;
            listSubItem10.Checked = false;
            listSubItem10.ForeColor = Color.Black;
            listSubItem10.Indentation = 0U;
            listSubItem10.Name = "";
            listSubItem10.Tag = null;
            listSubItem10.Text = "";
            listSubItem10.Value = 0;
            listSubItem11.BackColor = Color.Transparent;
            listSubItem11.Checked = false;
            listSubItem11.ForeColor = Color.Black;
            listSubItem11.Indentation = 0U;
            listSubItem11.Name = "";
            listSubItem11.Tag = null;
            listSubItem11.Text = "";
            listSubItem11.Value = 0;
            listSubItem12.BackColor = Color.Transparent;
            listSubItem12.Checked = false;
            listSubItem12.ForeColor = Color.Black;
            listSubItem12.Indentation = 0U;
            listSubItem12.Name = "";
            listSubItem12.Tag = null;
            listSubItem12.Text = "";
            listSubItem12.Value = 0;
            listItem3.SubItems.Add(listSubItem9);
            listItem3.SubItems.Add(listSubItem10);
            listItem3.SubItems.Add(listSubItem11);
            listItem3.SubItems.Add(listSubItem12);
            listItem3.Tag = null;
            listItem3.Text = "";
            listItem3.UseLineBackColor = false;
            listItem3.UseLineForeColor = false;
            listItem3.Value = 0;
            lstMonitor.Items.Add(listItem3);
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
            lstMonitor.Size = new Size(382, 295);
            lstMonitor.SpanColumn = -1;
            lstMonitor.TabIndex = 3;
            lstMonitor.UseLocalList = false;
            lstMonitor.VerScroll = 0;
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
            thSlaves.Size = new Size(382, 27);
            thSlaves.TabBackColor = Color.Transparent;
            thSlaves.TabBorderColor = Color.Transparent;
            thSlaves.TabClickedBackColor = Color.DarkGray;
            thSlaves.TabDividerColor = Color.White;
            thSlaves.TabHoverBackColor = Color.LightGray;
            thSlaves.TabIndex = 7;
            thSlaves.TabRuleColor = Color.FromArgb(100, 128, 128, 128);
            tab3.Selected = true;
            tab3.Tag = null;
            tab3.Text = "Main";
            thSlaves.Tabs.Add(tab3);
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
            navigator1.BorderColor = Color.FromArgb(0, 0, 0);
            navigator1.DisplayStyle = ODModules.Navigator.Style.Right;
            navigator1.DisplayText = "StateName";
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
            navigator1.Size = new Size(81, 322);
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
            tpRegisterFiltering.Padding = new Padding(3);
            tpRegisterFiltering.Size = new Size(463, 323);
            tpRegisterFiltering.TabIndex = 1;
            tpRegisterFiltering.Text = "Snapshot View";
            tpRegisterFiltering.UseVisualStyleBackColor = true;
            // 
            // ssClient
            // 
            ssClient.Dock = DockStyle.Fill;
            ssClient.Location = new Point(3, 3);
            ssClient.Name = "ssClient";
            ssClient.SelectorCollection = null;
            ssClient.Size = new Size(457, 317);
            ssClient.TabIndex = 1;
            ssClient.TileWindows = false;
            // 
            // pnlInset
            // 
            pnlInset.Controls.Add(tbDataPages);
            pnlInset.Dock = DockStyle.Fill;
            pnlInset.Location = new Point(0, 27);
            pnlInset.Name = "pnlInset";
            pnlInset.Padding = new Padding(1, 0, 1, 1);
            pnlInset.Size = new Size(473, 352);
            pnlInset.TabIndex = 9;
            pnlInset.Paint += pnlInset_Paint;
            pnlInset.Resize += pnlInset_Resize;
            // 
            // ModbusEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlInset);
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
            pnlInset.ResumeLayout(false);
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
        private Panel pnlInset;
    }
}
