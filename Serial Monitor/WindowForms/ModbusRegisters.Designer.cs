namespace Serial_Monitor {
    partial class ModbusRegisters {
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
            ODModules.Column column1 = new ODModules.Column();
            ODModules.Column column2 = new ODModules.Column();
            ODModules.Column column3 = new ODModules.Column();
            ODModules.Column column4 = new ODModules.Column();
            ODModules.Column column5 = new ODModules.Column();
            ODModules.Column column6 = new ODModules.Column();
            ODModules.ListItem listItem1 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem1 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem2 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem3 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem4 = new ODModules.ListSubItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModbusRegisters));
            ODModules.Tab tab1 = new ODModules.Tab();
            this.navigator1 = new ODModules.Navigator();
            this.lstMonitor = new ODModules.ListControl();
            this.cmMonitor = new ODModules.ContextMenu();
            this.btnCmSelectionToSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new ODModules.ToolStrip();
            this.btnCoils = new System.Windows.Forms.ToolStripButton();
            this.btnDiscrete = new System.Windows.Forms.ToolStripButton();
            this.btnHolding = new System.Windows.Forms.ToolStripButton();
            this.btnInputRegisters = new System.Windows.Forms.ToolStripButton();
            this.lblTypeSelection = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnApplyOnClick = new System.Windows.Forms.ToolStripButton();
            this.btnLockEditor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMenuTopMost = new System.Windows.Forms.ToolStripButton();
            this.tbDataPages = new ODModules.HiddenTabControl();
            this.tpRegisters = new System.Windows.Forms.TabPage();
            this.tpRegisterFiltering = new System.Windows.Forms.TabPage();
            this.mdiClient = new Serial_Monitor.Components.MdiClientPanel();
            this.thDataPagesHeader = new ODModules.TabHeader();
            this.msMain = new ODModules.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCoilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDiscreteInputsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHoldingRegistersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInputRegistersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showFormatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnViewMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.btnViewSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.modbusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeCoilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModbusApplyonClick = new System.Windows.Forms.ToolStripMenuItem();
            this.btnModbusLockEditors = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelectionToSnapshot = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddbDisplayFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.ddpDataSize = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSigned = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.windowManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmDisplayFormats = new ODModules.ContextMenu();
            this.cmDataSize = new ODModules.ContextMenu();
            this.cmMonitor.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.tbDataPages.SuspendLayout();
            this.tpRegisters.SuspendLayout();
            this.tpRegisterFiltering.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigator1
            // 
            this.navigator1.ArrowColor = System.Drawing.Color.Black;
            this.navigator1.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.navigator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.navigator1.DisplayStyle = ODModules.Navigator.Style.Right;
            this.navigator1.DisplayText = "StateName";
            this.navigator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navigator1.ForeColor = System.Drawing.Color.White;
            this.navigator1.LinkedList = null;
            this.navigator1.Location = new System.Drawing.Point(0, 0);
            this.navigator1.Margin = new System.Windows.Forms.Padding(6);
            this.navigator1.MidColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.navigator1.Name = "navigator1";
            this.navigator1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navigator1.SelectedItem = -1;
            this.navigator1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navigator1.ShowAnimations = true;
            this.navigator1.SideShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navigator1.Size = new System.Drawing.Size(150, 547);
            this.navigator1.TabIndex = 2;
            this.navigator1.SelectedIndexChanged += new ODModules.Navigator.SelectedIndexChangedHandler(this.navigator1_SelectedIndexChanged);
            // 
            // lstMonitor
            // 
            this.lstMonitor.AllowColumnSpanning = false;
            this.lstMonitor.AllowMouseWheel = true;
            this.lstMonitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lstMonitor.ColumnColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lstMonitor.ColumnForeColor = System.Drawing.Color.WhiteSmoke;
            this.lstMonitor.ColumnLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column1.CountOffset = 0;
            column1.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column1.DropDownRight = false;
            column1.DropDownVisible = false;
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column1.Text = "";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 50;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column2.DropDownRight = false;
            column2.DropDownVisible = false;
            column2.FixedWidth = false;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column2.Text = "Name";
            column2.UseItemBackColor = true;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 150;
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column3.CountOffset = 0;
            column3.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column3.DropDownRight = false;
            column3.DropDownVisible = true;
            column3.FixedWidth = false;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column3.Text = "Display";
            column3.UseItemBackColor = false;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 80;
            column4.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column4.CountOffset = 0;
            column4.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column4.DropDownRight = false;
            column4.DropDownVisible = true;
            column4.FixedWidth = true;
            column4.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column4.Text = "Size";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 75;
            column5.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column5.CountOffset = 0;
            column5.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column5.DropDownRight = false;
            column5.DropDownVisible = true;
            column5.FixedWidth = true;
            column5.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column5.Text = "Signed";
            column5.UseItemBackColor = false;
            column5.UseItemForeColor = false;
            column5.Visible = true;
            column5.Width = 50;
            column6.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column6.CountOffset = 0;
            column6.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column6.DropDownRight = false;
            column6.DropDownVisible = false;
            column6.FixedWidth = false;
            column6.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column6.Text = "Value";
            column6.UseItemBackColor = false;
            column6.UseItemForeColor = false;
            column6.Visible = true;
            column6.Width = 120;
            this.lstMonitor.Columns.Add(column1);
            this.lstMonitor.Columns.Add(column2);
            this.lstMonitor.Columns.Add(column3);
            this.lstMonitor.Columns.Add(column4);
            this.lstMonitor.Columns.Add(column5);
            this.lstMonitor.Columns.Add(column6);
            this.lstMonitor.ContextMenuStrip = this.cmMonitor;
            this.lstMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMonitor.DropDownMouseDown = System.Drawing.Color.DimGray;
            this.lstMonitor.DropDownMouseOver = System.Drawing.Color.LightGray;
            this.lstMonitor.ExternalItems = null;
            this.lstMonitor.Filter = null;
            this.lstMonitor.FilterColumn = 0;
            this.lstMonitor.ForeColor = System.Drawing.Color.White;
            this.lstMonitor.GridlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lstMonitor.HighlightStrength = 128;
            this.lstMonitor.HorScroll = new decimal(new int[] {
            0,
            0,
            0,
            0});
            listItem1.BackColor = System.Drawing.Color.Transparent;
            listItem1.Checked = false;
            listItem1.ForeColor = System.Drawing.Color.Black;
            listItem1.Name = "";
            listItem1.Selected = false;
            listSubItem1.BackColor = System.Drawing.Color.Transparent;
            listSubItem1.Checked = false;
            listSubItem1.ForeColor = System.Drawing.Color.Black;
            listSubItem1.Name = "";
            listSubItem1.Tag = null;
            listSubItem1.Text = "";
            listSubItem1.Value = 0;
            listSubItem2.BackColor = System.Drawing.Color.Transparent;
            listSubItem2.Checked = false;
            listSubItem2.ForeColor = System.Drawing.Color.Black;
            listSubItem2.Name = "";
            listSubItem2.Tag = null;
            listSubItem2.Text = "";
            listSubItem2.Value = 0;
            listSubItem3.BackColor = System.Drawing.Color.Transparent;
            listSubItem3.Checked = false;
            listSubItem3.ForeColor = System.Drawing.Color.Black;
            listSubItem3.Name = "";
            listSubItem3.Tag = null;
            listSubItem3.Text = "";
            listSubItem3.Value = 0;
            listSubItem4.BackColor = System.Drawing.Color.Transparent;
            listSubItem4.Checked = false;
            listSubItem4.ForeColor = System.Drawing.Color.Black;
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
            listItem1.Value = 0;
            this.lstMonitor.Items.Add(listItem1);
            this.lstMonitor.LineMarkerIndex = 0;
            this.lstMonitor.Location = new System.Drawing.Point(150, 0);
            this.lstMonitor.Margin = new System.Windows.Forms.Padding(6);
            this.lstMonitor.MarkerBorderColor = System.Drawing.Color.LimeGreen;
            this.lstMonitor.MarkerFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.lstMonitor.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            this.lstMonitor.Name = "lstMonitor";
            this.lstMonitor.RowColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lstMonitor.ScrollBarMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lstMonitor.ScrollBarNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstMonitor.ScrollBarSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstMonitor.ScrollItems = 3;
            this.lstMonitor.SelectedColor = System.Drawing.Color.SteelBlue;
            this.lstMonitor.SelectionColor = System.Drawing.Color.Gray;
            this.lstMonitor.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lstMonitor.ShowGrid = true;
            this.lstMonitor.ShowMarker = false;
            this.lstMonitor.ShowRowColors = true;
            this.lstMonitor.Size = new System.Drawing.Size(1018, 547);
            this.lstMonitor.SpanColumn = -1;
            this.lstMonitor.TabIndex = 3;
            this.lstMonitor.UseLocalList = true;
            this.lstMonitor.VerScroll = 0;
            this.lstMonitor.DropDownClicked += new ODModules.ListControl.DropDownClickedHandler(this.lstMonitor_DropDownClicked);
            this.lstMonitor.ItemCheckedChanged += new ODModules.ListControl.ItemCheckedChangedHandler(this.lstMonitor_ItemCheckedChanged);
            // 
            // cmMonitor
            // 
            this.cmMonitor.ActionSymbolForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmMonitor.BorderColor = System.Drawing.Color.Black;
            this.cmMonitor.DropShadowEnabled = false;
            this.cmMonitor.ForeColor = System.Drawing.Color.White;
            this.cmMonitor.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmMonitor.InsetShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmMonitor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCmSelectionToSnapshot});
            this.cmMonitor.MenuBackColorNorth = System.Drawing.Color.DodgerBlue;
            this.cmMonitor.MenuBackColorSouth = System.Drawing.Color.DodgerBlue;
            this.cmMonitor.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmMonitor.Name = "cmMonitor";
            this.cmMonitor.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmMonitor.ShowInsetShadow = false;
            this.cmMonitor.ShowItemInsetShadow = false;
            this.cmMonitor.Size = new System.Drawing.Size(293, 42);
            // 
            // btnCmSelectionToSnapshot
            // 
            this.btnCmSelectionToSnapshot.Name = "btnCmSelectionToSnapshot";
            this.btnCmSelectionToSnapshot.Size = new System.Drawing.Size(292, 38);
            this.btnCmSelectionToSnapshot.Text = "Snapshot Selection";
            this.btnCmSelectionToSnapshot.Click += new System.EventHandler(this.snapshotSelectionToolStripMenuItem_Click);
            // 
            // tsMain
            // 
            this.tsMain.BackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.BackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.ItemCheckedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMain.ItemCheckedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMain.ItemForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCoils,
            this.btnDiscrete,
            this.btnHolding,
            this.btnInputRegisters,
            this.lblTypeSelection,
            this.toolStripSeparator1,
            this.btnApplyOnClick,
            this.btnLockEditor,
            this.toolStripSeparator6,
            this.btnMenuTopMost});
            this.tsMain.ItemSelectedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.ItemSelectedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.ItemSelectedForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.Location = new System.Drawing.Point(0, 46);
            this.tsMain.MenuBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.MenuBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.MenuBorderColor = System.Drawing.Color.DimGray;
            this.tsMain.MenuSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tsMain.MenuSymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.tsMain.Size = new System.Drawing.Size(1176, 38);
            this.tsMain.StripItemSelectedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.StripItemSelectedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.TabIndex = 4;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnCoils
            // 
            this.btnCoils.Checked = true;
            this.btnCoils.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnCoils.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCoils.Image = ((System.Drawing.Image)(resources.GetObject("btnCoils.Image")));
            this.btnCoils.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCoils.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCoils.Name = "btnCoils";
            this.btnCoils.Size = new System.Drawing.Size(46, 32);
            this.btnCoils.Text = "Coils";
            this.btnCoils.Click += new System.EventHandler(this.btnCoils_Click);
            // 
            // btnDiscrete
            // 
            this.btnDiscrete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDiscrete.Image = ((System.Drawing.Image)(resources.GetObject("btnDiscrete.Image")));
            this.btnDiscrete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDiscrete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDiscrete.Name = "btnDiscrete";
            this.btnDiscrete.Size = new System.Drawing.Size(46, 32);
            this.btnDiscrete.Text = "Discrete Inputs";
            this.btnDiscrete.Click += new System.EventHandler(this.btnDiscrete_Click);
            // 
            // btnHolding
            // 
            this.btnHolding.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHolding.Image = ((System.Drawing.Image)(resources.GetObject("btnHolding.Image")));
            this.btnHolding.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnHolding.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHolding.Name = "btnHolding";
            this.btnHolding.Size = new System.Drawing.Size(46, 32);
            this.btnHolding.Text = "Holding Registers";
            this.btnHolding.Click += new System.EventHandler(this.btnHolding_Click);
            // 
            // btnInputRegisters
            // 
            this.btnInputRegisters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInputRegisters.Image = ((System.Drawing.Image)(resources.GetObject("btnInputRegisters.Image")));
            this.btnInputRegisters.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInputRegisters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInputRegisters.Name = "btnInputRegisters";
            this.btnInputRegisters.Size = new System.Drawing.Size(46, 32);
            this.btnInputRegisters.Text = "Input Registers";
            this.btnInputRegisters.Click += new System.EventHandler(this.btnInputRegisters_Click);
            // 
            // lblTypeSelection
            // 
            this.lblTypeSelection.ForeColor = System.Drawing.Color.White;
            this.lblTypeSelection.Name = "lblTypeSelection";
            this.lblTypeSelection.Size = new System.Drawing.Size(65, 32);
            this.lblTypeSelection.Text = "Coils";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // btnApplyOnClick
            // 
            this.btnApplyOnClick.Checked = true;
            this.btnApplyOnClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnApplyOnClick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnApplyOnClick.Image = ((System.Drawing.Image)(resources.GetObject("btnApplyOnClick.Image")));
            this.btnApplyOnClick.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnApplyOnClick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApplyOnClick.Name = "btnApplyOnClick";
            this.btnApplyOnClick.Size = new System.Drawing.Size(46, 32);
            this.btnApplyOnClick.Text = "Send On Change";
            this.btnApplyOnClick.Click += new System.EventHandler(this.btnApplyOnClick_Click);
            // 
            // btnLockEditor
            // 
            this.btnLockEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLockEditor.Image = ((System.Drawing.Image)(resources.GetObject("btnLockEditor.Image")));
            this.btnLockEditor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLockEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLockEditor.Name = "btnLockEditor";
            this.btnLockEditor.Size = new System.Drawing.Size(46, 32);
            this.btnLockEditor.Text = "Lock Editor";
            this.btnLockEditor.Click += new System.EventHandler(this.btnLockEditor_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 38);
            // 
            // btnMenuTopMost
            // 
            this.btnMenuTopMost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMenuTopMost.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuTopMost.Image")));
            this.btnMenuTopMost.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMenuTopMost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMenuTopMost.Name = "btnMenuTopMost";
            this.btnMenuTopMost.Size = new System.Drawing.Size(46, 32);
            this.btnMenuTopMost.Text = "Top Most";
            this.btnMenuTopMost.Click += new System.EventHandler(this.btnMenuTopMost_Click);
            // 
            // tbDataPages
            // 
            this.tbDataPages.Controls.Add(this.tpRegisters);
            this.tbDataPages.Controls.Add(this.tpRegisterFiltering);
            this.tbDataPages.DebugMode = true;
            this.tbDataPages.DefaultColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.tbDataPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDataPages.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tbDataPages.ForeColor = System.Drawing.Color.White;
            this.tbDataPages.ItemSize = new System.Drawing.Size(20, 20);
            this.tbDataPages.Location = new System.Drawing.Point(0, 142);
            this.tbDataPages.Margin = new System.Windows.Forms.Padding(0);
            this.tbDataPages.Multiline = true;
            this.tbDataPages.Name = "tbDataPages";
            this.tbDataPages.SelectedIndex = 0;
            this.tbDataPages.Size = new System.Drawing.Size(1176, 575);
            this.tbDataPages.TabIndex = 5;
            // 
            // tpRegisters
            // 
            this.tpRegisters.Controls.Add(this.lstMonitor);
            this.tpRegisters.Controls.Add(this.navigator1);
            this.tpRegisters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tpRegisters.Location = new System.Drawing.Point(4, 24);
            this.tpRegisters.Margin = new System.Windows.Forms.Padding(6);
            this.tpRegisters.Name = "tpRegisters";
            this.tpRegisters.Size = new System.Drawing.Size(1168, 547);
            this.tpRegisters.TabIndex = 0;
            this.tpRegisters.Text = "Master View";
            this.tpRegisters.UseVisualStyleBackColor = true;
            // 
            // tpRegisterFiltering
            // 
            this.tpRegisterFiltering.Controls.Add(this.mdiClient);
            this.tpRegisterFiltering.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tpRegisterFiltering.Location = new System.Drawing.Point(4, 24);
            this.tpRegisterFiltering.Margin = new System.Windows.Forms.Padding(6);
            this.tpRegisterFiltering.Name = "tpRegisterFiltering";
            this.tpRegisterFiltering.Padding = new System.Windows.Forms.Padding(6);
            this.tpRegisterFiltering.Size = new System.Drawing.Size(1168, 547);
            this.tpRegisterFiltering.TabIndex = 1;
            this.tpRegisterFiltering.Text = "Snapshot View";
            this.tpRegisterFiltering.UseVisualStyleBackColor = true;
            // 
            // mdiClient
            // 
            this.mdiClient.ActiveMDIWnd = null;
            this.mdiClient.BackColor = System.Drawing.Color.Black;
            this.mdiClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdiClient.Location = new System.Drawing.Point(6, 6);
            this.mdiClient.Margin = new System.Windows.Forms.Padding(6);
            this.mdiClient.Name = "mdiClient";
            this.mdiClient.Size = new System.Drawing.Size(1156, 535);
            this.mdiClient.TabIndex = 0;
            this.mdiClient.OnChildActivated += new Serial_Monitor.Components.MdiClientPanel.ActivateHandler(this.mdiClient_OnChildActivated);
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
            this.thDataPagesHeader.BindedTabControl = this.tbDataPages;
            this.thDataPagesHeader.CloseHoverColor = System.Drawing.Color.Brown;
            this.thDataPagesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.thDataPagesHeader.ForeColor = System.Drawing.Color.White;
            this.thDataPagesHeader.Location = new System.Drawing.Point(0, 84);
            this.thDataPagesHeader.Margin = new System.Windows.Forms.Padding(6);
            this.thDataPagesHeader.Name = "thDataPagesHeader";
            this.thDataPagesHeader.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.thDataPagesHeader.SelectedIndex = 1;
            this.thDataPagesHeader.ShowAddButton = false;
            this.thDataPagesHeader.ShowTabDividers = true;
            this.thDataPagesHeader.Size = new System.Drawing.Size(1176, 58);
            this.thDataPagesHeader.TabBackColor = System.Drawing.Color.Transparent;
            this.thDataPagesHeader.TabBorderColor = System.Drawing.Color.Transparent;
            this.thDataPagesHeader.TabClickedBackColor = System.Drawing.Color.DarkGray;
            this.thDataPagesHeader.TabDividerColor = System.Drawing.Color.White;
            this.thDataPagesHeader.TabHoverBackColor = System.Drawing.Color.LightGray;
            this.thDataPagesHeader.TabIndex = 6;
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
            this.thDataPagesHeader.SelectedIndexChanged += new ODModules.TabHeader.SelectedIndexChangedHandler(this.thDataPagesHeader_SelectedIndexChanged);
            // 
            // msMain
            // 
            this.msMain.BackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.msMain.BackColorNorthFadeIn = System.Drawing.Color.DodgerBlue;
            this.msMain.BackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.msMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.msMain.ItemForeColor = System.Drawing.Color.White;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.modbusToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.msMain.ItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.msMain.ItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.msMain.ItemSelectedForeColor = System.Drawing.Color.Black;
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.MenuBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.msMain.MenuBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.msMain.MenuBorderColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.MenuSeparatorColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.MenuSymbolColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.msMain.Size = new System.Drawing.Size(1176, 46);
            this.msMain.StripItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.msMain.StripItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.msMain.TabIndex = 7;
            this.msMain.Text = "menuStrip1";
            this.msMain.UseNorthFadeIn = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator11,
            this.newToolStripMenuItem1,
            this.openToolStripMenuItem,
            this.toolStripSeparator12,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator7,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 38);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(338, 44);
            this.newToolStripMenuItem.Text = "New &View";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(335, 6);
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.newToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(338, 44);
            this.newToolStripMenuItem1.Text = "&New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(338, 44);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(335, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(338, 44);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveAsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(338, 44);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Enabled = false;
            this.printToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(338, 44);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Visible = false;
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Enabled = false;
            this.printPreviewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(338, 44);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            this.printPreviewToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(335, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(338, 44);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator4,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator5,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(74, 38);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Visible = false;
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.undoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(245, 44);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.redoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(245, 44);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(242, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(245, 44);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(245, 44);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(245, 44);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(242, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.selectAllToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(245, 44);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCoilsToolStripMenuItem,
            this.viewDiscreteInputsToolStripMenuItem,
            this.viewHoldingRegistersToolStripMenuItem,
            this.viewInputRegistersToolStripMenuItem,
            this.toolStripSeparator3,
            this.showFormatsToolStripMenuItem,
            this.toolStripSeparator9,
            this.btnViewMaster,
            this.btnViewSnapshot,
            this.toolStripSeparator10,
            this.btnTopMost});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(85, 38);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // viewCoilsToolStripMenuItem
            // 
            this.viewCoilsToolStripMenuItem.Checked = true;
            this.viewCoilsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewCoilsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewCoilsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewCoilsToolStripMenuItem.Name = "viewCoilsToolStripMenuItem";
            this.viewCoilsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.viewCoilsToolStripMenuItem.Size = new System.Drawing.Size(406, 44);
            this.viewCoilsToolStripMenuItem.Tag = "mbTypeCoils";
            this.viewCoilsToolStripMenuItem.Text = "&Coils";
            this.viewCoilsToolStripMenuItem.Click += new System.EventHandler(this.viewCoilsToolStripMenuItem_Click);
            // 
            // viewDiscreteInputsToolStripMenuItem
            // 
            this.viewDiscreteInputsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewDiscreteInputsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewDiscreteInputsToolStripMenuItem.Name = "viewDiscreteInputsToolStripMenuItem";
            this.viewDiscreteInputsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.viewDiscreteInputsToolStripMenuItem.Size = new System.Drawing.Size(406, 44);
            this.viewDiscreteInputsToolStripMenuItem.Tag = "mbTypeDiscrete";
            this.viewDiscreteInputsToolStripMenuItem.Text = "&Discrete Inputs";
            this.viewDiscreteInputsToolStripMenuItem.Click += new System.EventHandler(this.viewDiscreteInputsToolStripMenuItem_Click);
            // 
            // viewHoldingRegistersToolStripMenuItem
            // 
            this.viewHoldingRegistersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewHoldingRegistersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewHoldingRegistersToolStripMenuItem.Name = "viewHoldingRegistersToolStripMenuItem";
            this.viewHoldingRegistersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.viewHoldingRegistersToolStripMenuItem.Size = new System.Drawing.Size(406, 44);
            this.viewHoldingRegistersToolStripMenuItem.Tag = "mbTypeRegHolding";
            this.viewHoldingRegistersToolStripMenuItem.Text = "&Holding Registers";
            this.viewHoldingRegistersToolStripMenuItem.Click += new System.EventHandler(this.viewHoldingRegistersToolStripMenuItem_Click);
            // 
            // viewInputRegistersToolStripMenuItem
            // 
            this.viewInputRegistersToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewInputRegistersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewInputRegistersToolStripMenuItem.Name = "viewInputRegistersToolStripMenuItem";
            this.viewInputRegistersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
            this.viewInputRegistersToolStripMenuItem.Size = new System.Drawing.Size(406, 44);
            this.viewInputRegistersToolStripMenuItem.Tag = "mbTypeRegInput";
            this.viewInputRegistersToolStripMenuItem.Text = "Input &Registers";
            this.viewInputRegistersToolStripMenuItem.Click += new System.EventHandler(this.viewInputRegistersToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(403, 6);
            // 
            // showFormatsToolStripMenuItem
            // 
            this.showFormatsToolStripMenuItem.Checked = true;
            this.showFormatsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showFormatsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.showFormatsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showFormatsToolStripMenuItem.Name = "showFormatsToolStripMenuItem";
            this.showFormatsToolStripMenuItem.Size = new System.Drawing.Size(406, 44);
            this.showFormatsToolStripMenuItem.Text = "Show &Formats";
            this.showFormatsToolStripMenuItem.Click += new System.EventHandler(this.showFormatsToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(403, 6);
            // 
            // btnViewMaster
            // 
            this.btnViewMaster.Checked = true;
            this.btnViewMaster.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnViewMaster.ForeColor = System.Drawing.Color.White;
            this.btnViewMaster.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnViewMaster.Name = "btnViewMaster";
            this.btnViewMaster.Size = new System.Drawing.Size(406, 44);
            this.btnViewMaster.Text = "Master View";
            this.btnViewMaster.Click += new System.EventHandler(this.btnViewMaster_Click);
            // 
            // btnViewSnapshot
            // 
            this.btnViewSnapshot.ForeColor = System.Drawing.Color.White;
            this.btnViewSnapshot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnViewSnapshot.Name = "btnViewSnapshot";
            this.btnViewSnapshot.Size = new System.Drawing.Size(406, 44);
            this.btnViewSnapshot.Text = "Snapshot View";
            this.btnViewSnapshot.Click += new System.EventHandler(this.btnViewSnapshot_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(403, 6);
            // 
            // btnTopMost
            // 
            this.btnTopMost.ForeColor = System.Drawing.Color.White;
            this.btnTopMost.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTopMost.Name = "btnTopMost";
            this.btnTopMost.Size = new System.Drawing.Size(406, 44);
            this.btnTopMost.Text = "&Top Most";
            this.btnTopMost.Click += new System.EventHandler(this.windowTopMostToolStripMenuItem_Click);
            // 
            // modbusToolStripMenuItem
            // 
            this.modbusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.writeCoilToolStripMenuItem,
            this.writeRegisterToolStripMenuItem,
            this.toolStripSeparator2,
            this.btnModbusApplyonClick,
            this.btnModbusLockEditors,
            this.toolStripSeparator8,
            this.btnSelectionToSnapshot});
            this.modbusToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.modbusToolStripMenuItem.Name = "modbusToolStripMenuItem";
            this.modbusToolStripMenuItem.Size = new System.Drawing.Size(122, 38);
            this.modbusToolStripMenuItem.Text = "&Modbus";
            // 
            // writeCoilToolStripMenuItem
            // 
            this.writeCoilToolStripMenuItem.Enabled = false;
            this.writeCoilToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.writeCoilToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.writeCoilToolStripMenuItem.Name = "writeCoilToolStripMenuItem";
            this.writeCoilToolStripMenuItem.Size = new System.Drawing.Size(430, 44);
            this.writeCoilToolStripMenuItem.Text = "Write Coil";
            // 
            // writeRegisterToolStripMenuItem
            // 
            this.writeRegisterToolStripMenuItem.Enabled = false;
            this.writeRegisterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.writeRegisterToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.writeRegisterToolStripMenuItem.Name = "writeRegisterToolStripMenuItem";
            this.writeRegisterToolStripMenuItem.Size = new System.Drawing.Size(430, 44);
            this.writeRegisterToolStripMenuItem.Text = "Write Register";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(427, 6);
            // 
            // btnModbusApplyonClick
            // 
            this.btnModbusApplyonClick.Checked = true;
            this.btnModbusApplyonClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnModbusApplyonClick.ForeColor = System.Drawing.Color.White;
            this.btnModbusApplyonClick.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnModbusApplyonClick.Name = "btnModbusApplyonClick";
            this.btnModbusApplyonClick.Size = new System.Drawing.Size(430, 44);
            this.btnModbusApplyonClick.Text = "Send on Change";
            this.btnModbusApplyonClick.Click += new System.EventHandler(this.btnModbusApplyonClick_Click);
            // 
            // btnModbusLockEditors
            // 
            this.btnModbusLockEditors.ForeColor = System.Drawing.Color.White;
            this.btnModbusLockEditors.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnModbusLockEditors.Name = "btnModbusLockEditors";
            this.btnModbusLockEditors.Size = new System.Drawing.Size(430, 44);
            this.btnModbusLockEditors.Text = "Lock Editors";
            this.btnModbusLockEditors.Click += new System.EventHandler(this.btnModbusLockEditors_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(427, 6);
            // 
            // btnSelectionToSnapshot
            // 
            this.btnSelectionToSnapshot.ForeColor = System.Drawing.Color.White;
            this.btnSelectionToSnapshot.Name = "btnSelectionToSnapshot";
            this.btnSelectionToSnapshot.Size = new System.Drawing.Size(430, 44);
            this.btnSelectionToSnapshot.Text = "Add Selection to Snapshot";
            this.btnSelectionToSnapshot.Click += new System.EventHandler(this.addSelectionToSnapshotToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddbDisplayFormat,
            this.ddpDataSize,
            this.btnSigned});
            this.formatToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(109, 38);
            this.formatToolStripMenuItem.Text = "&Format";
            // 
            // ddbDisplayFormat
            // 
            this.ddbDisplayFormat.Enabled = false;
            this.ddbDisplayFormat.ForeColor = System.Drawing.Color.White;
            this.ddbDisplayFormat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ddbDisplayFormat.Name = "ddbDisplayFormat";
            this.ddbDisplayFormat.Size = new System.Drawing.Size(246, 44);
            this.ddbDisplayFormat.Text = "&Display";
            // 
            // ddpDataSize
            // 
            this.ddpDataSize.Enabled = false;
            this.ddpDataSize.ForeColor = System.Drawing.Color.White;
            this.ddpDataSize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ddpDataSize.Name = "ddpDataSize";
            this.ddpDataSize.Size = new System.Drawing.Size(246, 44);
            this.ddpDataSize.Text = "Data &Size";
            // 
            // btnSigned
            // 
            this.btnSigned.Enabled = false;
            this.btnSigned.ForeColor = System.Drawing.Color.White;
            this.btnSigned.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSigned.Name = "btnSigned";
            this.btnSigned.Size = new System.Drawing.Size(246, 44);
            this.btnSigned.Text = "Si&gned";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(89, 38);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(259, 44);
            this.customizeToolStripMenuItem.Text = "&Customize";
            this.customizeToolStripMenuItem.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(259, 44);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileHorizontalToolStripMenuItem,
            this.toolStripSeparator13,
            this.windowManagerToolStripMenuItem});
            this.windowToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(121, 38);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.tileHorizontalToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.tileHorizontalToolStripMenuItem.Text = "Tile Windows";
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontalToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(356, 6);
            // 
            // windowManagerToolStripMenuItem
            // 
            this.windowManagerToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.windowManagerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.windowManagerToolStripMenuItem.Name = "windowManagerToolStripMenuItem";
            this.windowManagerToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.windowManagerToolStripMenuItem.Text = "&Window Manager";
            this.windowManagerToolStripMenuItem.Click += new System.EventHandler(this.windowManagerToolStripMenuItem_Click);
            // 
            // cmDisplayFormats
            // 
            this.cmDisplayFormats.ActionSymbolForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmDisplayFormats.BorderColor = System.Drawing.Color.Black;
            this.cmDisplayFormats.DropShadowEnabled = false;
            this.cmDisplayFormats.ForeColor = System.Drawing.Color.White;
            this.cmDisplayFormats.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmDisplayFormats.InsetShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmDisplayFormats.MenuBackColorNorth = System.Drawing.Color.DodgerBlue;
            this.cmDisplayFormats.MenuBackColorSouth = System.Drawing.Color.DodgerBlue;
            this.cmDisplayFormats.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmDisplayFormats.Name = "cmDisplayFormats";
            this.cmDisplayFormats.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmDisplayFormats.ShowInsetShadow = false;
            this.cmDisplayFormats.ShowItemInsetShadow = false;
            this.cmDisplayFormats.Size = new System.Drawing.Size(61, 4);
            // 
            // cmDataSize
            // 
            this.cmDataSize.ActionSymbolForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmDataSize.BorderColor = System.Drawing.Color.Black;
            this.cmDataSize.DropShadowEnabled = false;
            this.cmDataSize.ForeColor = System.Drawing.Color.White;
            this.cmDataSize.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmDataSize.InsetShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmDataSize.MenuBackColorNorth = System.Drawing.Color.DodgerBlue;
            this.cmDataSize.MenuBackColorSouth = System.Drawing.Color.DodgerBlue;
            this.cmDataSize.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmDataSize.Name = "cmDataSize";
            this.cmDataSize.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmDataSize.ShowInsetShadow = false;
            this.cmDataSize.ShowItemInsetShadow = false;
            this.cmDataSize.Size = new System.Drawing.Size(61, 4);
            // 
            // ModbusRegisters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(1176, 717);
            this.Controls.Add(this.tbDataPages);
            this.Controls.Add(this.thDataPagesHeader);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.msMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ModbusRegisters";
            this.Text = "Modbus Registers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModbusRegisters_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModbusRegisters_FormClosed);
            this.Load += new System.EventHandler(this.ModbusRegisters_Load);
            this.SizeChanged += new System.EventHandler(this.ModbusRegisters_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.ModbusRegisters_VisibleChanged);
            this.cmMonitor.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.tbDataPages.ResumeLayout(false);
            this.tpRegisters.ResumeLayout(false);
            this.tpRegisterFiltering.ResumeLayout(false);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ODModules.Navigator navigator1;
        private ODModules.ListControl lstMonitor;
        private ODModules.ToolStrip tsMain;
        private ToolStripButton btnCoils;
        private ToolStripButton btnDiscrete;
        private ToolStripButton btnHolding;
        private ToolStripButton btnInputRegisters;
        private ToolStripLabel lblTypeSelection;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnApplyOnClick;
        private ToolStripButton btnLockEditor;
        private ODModules.HiddenTabControl tbDataPages;
        private TabPage tpRegisters;
        private TabPage tpRegisterFiltering;
        private ODModules.TabHeader thDataPagesHeader;
        private ODModules.MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripMenuItem printPreviewToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem modbusToolStripMenuItem;
        private ToolStripMenuItem writeCoilToolStripMenuItem;
        private ToolStripMenuItem writeRegisterToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem viewCoilsToolStripMenuItem;
        private ToolStripMenuItem viewDiscreteInputsToolStripMenuItem;
        private ToolStripMenuItem viewHoldingRegistersToolStripMenuItem;
        private ToolStripMenuItem viewInputRegistersToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem btnModbusApplyonClick;
        private ToolStripMenuItem btnModbusLockEditors;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem btnTopMost;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton btnMenuTopMost;
        private Components.MdiClientPanel mdiClient;
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem windowManagerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ODModules.ContextMenu cmMonitor;
        private ToolStripMenuItem btnCmSelectionToSnapshot;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem btnSelectionToSnapshot;
        private ODModules.ContextMenu cmDisplayFormats;
        private ODModules.ContextMenu cmDataSize;
        private ToolStripMenuItem formatToolStripMenuItem;
        private ToolStripMenuItem ddbDisplayFormat;
        private ToolStripMenuItem ddpDataSize;
        private ToolStripMenuItem btnSigned;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem btnViewMaster;
        private ToolStripMenuItem btnViewSnapshot;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem newToolStripMenuItem1;
        public ToolStripMenuItem showFormatsToolStripMenuItem;
        private ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator13;
    }
}