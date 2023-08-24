namespace Serial_Monitor {
    partial class Monitor {
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
            this.components = new System.ComponentModel.Container();
            ODModules.Column column1 = new ODModules.Column();
            ODModules.Column column2 = new ODModules.Column();
            ODModules.Column column3 = new ODModules.Column();
            ODModules.Column column4 = new ODModules.Column();
            ODModules.ListItem listItem1 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem1 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem2 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem3 = new ODModules.ListSubItem();
            ODModules.Column column5 = new ODModules.Column();
            ODModules.Column column6 = new ODModules.Column();
            ODModules.Column column7 = new ODModules.Column();
            ODModules.Column column8 = new ODModules.Column();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor));
            this.lstMonitor = new ODModules.ListControl();
            this.pnlMonitor = new System.Windows.Forms.SplitContainer();
            this.lstSelector = new ODModules.ListControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tsMain = new ODModules.ToolStrip();
            this.btnSaveLog = new System.Windows.Forms.ToolStripButton();
            this.btnOpenLog = new System.Windows.Forms.ToolStripButton();
            this.btnOpenLogLocation = new System.Windows.Forms.ToolStripButton();
            this.btnOpenExcelDoc = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnStartLog = new System.Windows.Forms.ToolStripButton();
            this.btnStopLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOptRegSingleMode = new System.Windows.Forms.ToolStripButton();
            this.btnOptRegMultiMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOnTop = new System.Windows.Forms.ToolStripButton();
            this.LogUpdater = new System.Windows.Forms.Timer(this.components);
            this.DisplayUpdater = new System.Windows.Forms.Timer(this.components);
            this.msMain = new ODModules.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insetModbusMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMonitor)).BeginInit();
            this.pnlMonitor.Panel1.SuspendLayout();
            this.pnlMonitor.Panel2.SuspendLayout();
            this.pnlMonitor.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
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
            column1.DisplayType = ODModules.ColumnDisplayType.Text;
            column1.DropDownRight = false;
            column1.DropDownVisible = true;
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column1.Text = "Register Name";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 100;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.DisplayType = ODModules.ColumnDisplayType.Text;
            column2.DropDownRight = false;
            column2.DropDownVisible = false;
            column2.FixedWidth = false;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column2.Text = "Port";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 70;
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column3.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column3.DropDownRight = false;
            column3.DropDownVisible = false;
            column3.FixedWidth = false;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column3.Text = "Data";
            column3.UseItemBackColor = true;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 100;
            column4.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column4.DisplayType = ODModules.ColumnDisplayType.Text;
            column4.DropDownRight = false;
            column4.DropDownVisible = false;
            column4.FixedWidth = false;
            column4.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column4.Text = "Last Updated";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 120;
            this.lstMonitor.Columns.Add(column1);
            this.lstMonitor.Columns.Add(column2);
            this.lstMonitor.Columns.Add(column3);
            this.lstMonitor.Columns.Add(column4);
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
            listSubItem2.BackColor = System.Drawing.Color.Transparent;
            listSubItem2.Checked = false;
            listSubItem2.ForeColor = System.Drawing.Color.Black;
            listSubItem2.Name = "";
            listSubItem2.Tag = null;
            listSubItem2.Text = "";
            listSubItem3.BackColor = System.Drawing.Color.Transparent;
            listSubItem3.Checked = false;
            listSubItem3.ForeColor = System.Drawing.Color.Black;
            listSubItem3.Name = "";
            listSubItem3.Tag = null;
            listSubItem3.Text = "";
            listItem1.SubItems.Add(listSubItem1);
            listItem1.SubItems.Add(listSubItem2);
            listItem1.SubItems.Add(listSubItem3);
            listItem1.Tag = null;
            listItem1.Text = "";
            this.lstMonitor.Items.Add(listItem1);
            this.lstMonitor.LineMarkerIndex = 0;
            this.lstMonitor.Location = new System.Drawing.Point(0, 0);
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
            this.lstMonitor.Size = new System.Drawing.Size(392, 355);
            this.lstMonitor.SpanColumn = -1;
            this.lstMonitor.TabIndex = 1;
            this.lstMonitor.UseLocalList = true;
            this.lstMonitor.VerScroll = 0;
            // 
            // pnlMonitor
            // 
            this.pnlMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMonitor.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.pnlMonitor.Location = new System.Drawing.Point(0, 65);
            this.pnlMonitor.Name = "pnlMonitor";
            // 
            // pnlMonitor.Panel1
            // 
            this.pnlMonitor.Panel1.Controls.Add(this.lstSelector);
            // 
            // pnlMonitor.Panel2
            // 
            this.pnlMonitor.Panel2.Controls.Add(this.lstMonitor);
            this.pnlMonitor.Size = new System.Drawing.Size(573, 355);
            this.pnlMonitor.SplitterDistance = 177;
            this.pnlMonitor.TabIndex = 2;
            // 
            // lstSelector
            // 
            this.lstSelector.AllowColumnSpanning = false;
            this.lstSelector.AllowMouseWheel = true;
            this.lstSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lstSelector.ColumnColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lstSelector.ColumnForeColor = System.Drawing.Color.WhiteSmoke;
            this.lstSelector.ColumnLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            column5.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column5.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column5.DropDownRight = false;
            column5.DropDownVisible = true;
            column5.FixedWidth = false;
            column5.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column5.Text = "";
            column5.UseItemBackColor = false;
            column5.UseItemForeColor = false;
            column5.Visible = true;
            column5.Width = 40;
            column6.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column6.DisplayType = ODModules.ColumnDisplayType.Text;
            column6.DropDownRight = false;
            column6.DropDownVisible = true;
            column6.FixedWidth = false;
            column6.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column6.Text = "Port";
            column6.UseItemBackColor = false;
            column6.UseItemForeColor = false;
            column6.Visible = true;
            column6.Width = 40;
            column7.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column7.DisplayType = ODModules.ColumnDisplayType.Text;
            column7.DropDownRight = false;
            column7.DropDownVisible = true;
            column7.FixedWidth = false;
            column7.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column7.Text = "Registers";
            column7.UseItemBackColor = false;
            column7.UseItemForeColor = false;
            column7.Visible = true;
            column7.Width = 60;
            column8.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column8.DisplayType = ODModules.ColumnDisplayType.Text;
            column8.DropDownRight = false;
            column8.DropDownVisible = true;
            column8.FixedWidth = false;
            column8.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column8.Text = "Type";
            column8.UseItemBackColor = false;
            column8.UseItemForeColor = false;
            column8.Visible = true;
            column8.Width = 77;
            this.lstSelector.Columns.Add(column5);
            this.lstSelector.Columns.Add(column6);
            this.lstSelector.Columns.Add(column7);
            this.lstSelector.Columns.Add(column8);
            this.lstSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelector.DropDownMouseDown = System.Drawing.Color.DimGray;
            this.lstSelector.DropDownMouseOver = System.Drawing.Color.LightGray;
            this.lstSelector.ExternalItems = null;
            this.lstSelector.Filter = null;
            this.lstSelector.FilterColumn = 2;
            this.lstSelector.ForeColor = System.Drawing.Color.White;
            this.lstSelector.GridlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lstSelector.HighlightStrength = 128;
            this.lstSelector.HorScroll = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lstSelector.LineMarkerIndex = 0;
            this.lstSelector.Location = new System.Drawing.Point(0, 0);
            this.lstSelector.MarkerBorderColor = System.Drawing.Color.LimeGreen;
            this.lstSelector.MarkerFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.lstSelector.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            this.lstSelector.Name = "lstSelector";
            this.lstSelector.RowColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lstSelector.ScrollBarMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lstSelector.ScrollBarNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstSelector.ScrollBarSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstSelector.ScrollItems = 3;
            this.lstSelector.SelectedColor = System.Drawing.Color.SteelBlue;
            this.lstSelector.SelectionColor = System.Drawing.Color.Gray;
            this.lstSelector.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lstSelector.ShowGrid = true;
            this.lstSelector.ShowMarker = false;
            this.lstSelector.ShowRowColors = true;
            this.lstSelector.Size = new System.Drawing.Size(177, 355);
            this.lstSelector.SpanColumn = 2;
            this.lstSelector.TabIndex = 2;
            this.lstSelector.UseLocalList = true;
            this.lstSelector.VerScroll = 0;
            this.lstSelector.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstSelector_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(573, 16);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tsMain
            // 
            this.tsMain.BackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.BackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.ItemCheckedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMain.ItemCheckedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMain.ItemForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveLog,
            this.btnOpenLog,
            this.btnOpenLogLocation,
            this.btnOpenExcelDoc,
            this.toolStripSeparator1,
            this.btnStartLog,
            this.btnStopLog,
            this.toolStripSeparator2,
            this.btnOptRegSingleMode,
            this.btnOptRegMultiMode,
            this.toolStripSeparator3,
            this.btnOnTop});
            this.tsMain.ItemSelectedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.ItemSelectedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.ItemSelectedForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.MenuBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.MenuBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.MenuBorderColor = System.Drawing.Color.DimGray;
            this.tsMain.MenuSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tsMain.MenuSymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsMain.Size = new System.Drawing.Size(573, 25);
            this.tsMain.StripItemSelectedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.StripItemSelectedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.TabIndex = 3;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveLog.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLog.Image")));
            this.btnSaveLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(23, 22);
            this.btnSaveLog.Text = "Save Log";
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenLog.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenLog.Image")));
            this.btnOpenLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(23, 22);
            this.btnOpenLog.Text = "Open Log";
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // btnOpenLogLocation
            // 
            this.btnOpenLogLocation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenLogLocation.Enabled = false;
            this.btnOpenLogLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenLogLocation.Image")));
            this.btnOpenLogLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenLogLocation.Name = "btnOpenLogLocation";
            this.btnOpenLogLocation.Size = new System.Drawing.Size(23, 22);
            this.btnOpenLogLocation.Text = "Open Log Location";
            this.btnOpenLogLocation.Click += new System.EventHandler(this.btnOpenLogLocation_Click);
            // 
            // btnOpenExcelDoc
            // 
            this.btnOpenExcelDoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenExcelDoc.Enabled = false;
            this.btnOpenExcelDoc.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenExcelDoc.Image")));
            this.btnOpenExcelDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenExcelDoc.Name = "btnOpenExcelDoc";
            this.btnOpenExcelDoc.Size = new System.Drawing.Size(23, 22);
            this.btnOpenExcelDoc.Text = "Open Copy of Log in Excel";
            this.btnOpenExcelDoc.Click += new System.EventHandler(this.btnOpenExcelDoc_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnStartLog
            // 
            this.btnStartLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStartLog.Enabled = false;
            this.btnStartLog.Image = ((System.Drawing.Image)(resources.GetObject("btnStartLog.Image")));
            this.btnStartLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartLog.Name = "btnStartLog";
            this.btnStartLog.Size = new System.Drawing.Size(23, 22);
            this.btnStartLog.Text = "Start Logging";
            this.btnStartLog.Click += new System.EventHandler(this.btnStartLog_Click);
            // 
            // btnStopLog
            // 
            this.btnStopLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopLog.Enabled = false;
            this.btnStopLog.Image = ((System.Drawing.Image)(resources.GetObject("btnStopLog.Image")));
            this.btnStopLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopLog.Name = "btnStopLog";
            this.btnStopLog.Size = new System.Drawing.Size(23, 22);
            this.btnStopLog.Text = "Stop Logging";
            this.btnStopLog.Click += new System.EventHandler(this.btnStopLog_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOptRegSingleMode
            // 
            this.btnOptRegSingleMode.Checked = true;
            this.btnOptRegSingleMode.CheckOnClick = true;
            this.btnOptRegSingleMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnOptRegSingleMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOptRegSingleMode.Image = ((System.Drawing.Image)(resources.GetObject("btnOptRegSingleMode.Image")));
            this.btnOptRegSingleMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptRegSingleMode.Name = "btnOptRegSingleMode";
            this.btnOptRegSingleMode.Size = new System.Drawing.Size(23, 22);
            this.btnOptRegSingleMode.Text = "Single Register Mode";
            this.btnOptRegSingleMode.Click += new System.EventHandler(this.btnOptRegSingleMode_Click);
            // 
            // btnOptRegMultiMode
            // 
            this.btnOptRegMultiMode.CheckOnClick = true;
            this.btnOptRegMultiMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOptRegMultiMode.Image = ((System.Drawing.Image)(resources.GetObject("btnOptRegMultiMode.Image")));
            this.btnOptRegMultiMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptRegMultiMode.Name = "btnOptRegMultiMode";
            this.btnOptRegMultiMode.Size = new System.Drawing.Size(23, 22);
            this.btnOptRegMultiMode.Text = "Multi Register Mode";
            this.btnOptRegMultiMode.Click += new System.EventHandler(this.btnOptRegMultiMode_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnOnTop
            // 
            this.btnOnTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOnTop.Image = ((System.Drawing.Image)(resources.GetObject("btnOnTop.Image")));
            this.btnOnTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOnTop.Name = "btnOnTop";
            this.btnOnTop.Size = new System.Drawing.Size(23, 22);
            this.btnOnTop.Text = "Always On Top";
            this.btnOnTop.Click += new System.EventHandler(this.btnOnTop_Click);
            // 
            // LogUpdater
            // 
            this.LogUpdater.Enabled = true;
            this.LogUpdater.Interval = 1000;
            this.LogUpdater.Tick += new System.EventHandler(this.LogUpdater_Tick);
            // 
            // DisplayUpdater
            // 
            this.DisplayUpdater.Enabled = true;
            this.DisplayUpdater.Interval = 250;
            this.DisplayUpdater.Tick += new System.EventHandler(this.DisplayUpdater_Tick);
            // 
            // msMain
            // 
            this.msMain.BackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.BackColorNorthFadeIn = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.msMain.BackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.ItemForeColor = System.Drawing.SystemColors.Window;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.registersToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.msMain.ItemSelectedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.msMain.ItemSelectedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.msMain.ItemSelectedForeColor = System.Drawing.SystemColors.Window;
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.MenuBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.MenuBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.MenuBorderColor = System.Drawing.Color.DimGray;
            this.msMain.MenuSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.msMain.MenuSymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(573, 24);
            this.msMain.StripItemSelectedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.msMain.StripItemSelectedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.msMain.TabIndex = 5;
            this.msMain.Text = "Main Menu";
            this.msMain.UseNorthFadeIn = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.openToolStripMenuItem.Text = "&Open Log";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(166, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveToolStripMenuItem.Text = "&Save Log";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(166, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator6,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator7,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Visible = false;
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(119, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(119, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // registersToolStripMenuItem
            // 
            this.registersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insetModbusMonitorToolStripMenuItem});
            this.registersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.registersToolStripMenuItem.Name = "registersToolStripMenuItem";
            this.registersToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.registersToolStripMenuItem.Text = "&Registers";
            this.registersToolStripMenuItem.Visible = false;
            // 
            // insetModbusMonitorToolStripMenuItem
            // 
            this.insetModbusMonitorToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.insetModbusMonitorToolStripMenuItem.Name = "insetModbusMonitorToolStripMenuItem";
            this.insetModbusMonitorToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.insetModbusMonitorToolStripMenuItem.Text = "Insert Modbus Monitor";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            this.customizeToolStripMenuItem.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator8,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            this.helpToolStripMenuItem.Visible = false;
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(119, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(573, 420);
            this.Controls.Add(this.pnlMonitor);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.msMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "Monitor";
            this.Text = "Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Monitor_FormClosing);
            this.Load += new System.EventHandler(this.Monitor_Load);
            this.pnlMonitor.Panel1.ResumeLayout(false);
            this.pnlMonitor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMonitor)).EndInit();
            this.pnlMonitor.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ODModules.ListControl lstMonitor;
        private SplitContainer pnlMonitor;
        //private ODModules.ListControl listControl1;
        private ODModules.ToolStrip tsMain;
        private ToolStripButton btnSaveLog;
        private ToolStripButton btnOpenLog;
        private ToolStripButton btnOpenLogLocation;
        private ToolStripButton btnOpenExcelDoc;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnStartLog;
        private ToolStripButton btnStopLog;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnOnTop;
        private System.Windows.Forms.Timer LogUpdater;
        private System.Windows.Forms.Timer DisplayUpdater;
        private ODModules.ListControl lstSelector;
        private ToolStripButton btnOptRegSingleMode;
        private ToolStripButton btnOptRegMultiMode;
        private ToolStripSeparator toolStripSeparator3;
        private TextBox textBox1;
        private ODModules.MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem customizeToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem contentsToolStripMenuItem;
        private ToolStripMenuItem indexToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem registersToolStripMenuItem;
        private ToolStripMenuItem insetModbusMonitorToolStripMenuItem;
    }
}