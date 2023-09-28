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
            ODModules.Column column9 = new ODModules.Column();
            ODModules.Column column10 = new ODModules.Column();
            ODModules.Column column11 = new ODModules.Column();
            ODModules.Column column12 = new ODModules.Column();
            ODModules.ListItem listItem2 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem4 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem5 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem6 = new ODModules.ListSubItem();
            ODModules.Column column13 = new ODModules.Column();
            ODModules.Column column14 = new ODModules.Column();
            ODModules.Column column15 = new ODModules.Column();
            ODModules.Column column16 = new ODModules.Column();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monitor));
            this.lstMonitor = new ODModules.ListControl();
            this.pnlMonitor = new System.Windows.Forms.SplitContainer();
            this.lstSelector = new ODModules.ListControl();
            this.txtbxSearch = new System.Windows.Forms.TextBox();
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
            this.openLogLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.searchAvaliableRegistersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addToMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startLoggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopLoggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            column9.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column9.CountOffset = 0;
            column9.DisplayType = ODModules.ColumnDisplayType.Text;
            column9.DropDownRight = false;
            column9.DropDownVisible = true;
            column9.FixedWidth = false;
            column9.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column9.Text = "Register Name";
            column9.UseItemBackColor = false;
            column9.UseItemForeColor = false;
            column9.Visible = true;
            column9.Width = 100;
            column10.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column10.CountOffset = 0;
            column10.DisplayType = ODModules.ColumnDisplayType.Text;
            column10.DropDownRight = false;
            column10.DropDownVisible = false;
            column10.FixedWidth = false;
            column10.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column10.Text = "Port";
            column10.UseItemBackColor = false;
            column10.UseItemForeColor = false;
            column10.Visible = true;
            column10.Width = 70;
            column11.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column11.CountOffset = 0;
            column11.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column11.DropDownRight = false;
            column11.DropDownVisible = false;
            column11.FixedWidth = false;
            column11.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column11.Text = "Data";
            column11.UseItemBackColor = true;
            column11.UseItemForeColor = false;
            column11.Visible = true;
            column11.Width = 100;
            column12.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column12.CountOffset = 0;
            column12.DisplayType = ODModules.ColumnDisplayType.Text;
            column12.DropDownRight = false;
            column12.DropDownVisible = false;
            column12.FixedWidth = false;
            column12.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column12.Text = "Last Updated";
            column12.UseItemBackColor = false;
            column12.UseItemForeColor = false;
            column12.Visible = true;
            column12.Width = 120;
            this.lstMonitor.Columns.Add(column9);
            this.lstMonitor.Columns.Add(column10);
            this.lstMonitor.Columns.Add(column11);
            this.lstMonitor.Columns.Add(column12);
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
            listItem2.BackColor = System.Drawing.Color.Transparent;
            listItem2.Checked = false;
            listItem2.ForeColor = System.Drawing.Color.Black;
            listItem2.Name = "";
            listItem2.Selected = false;
            listSubItem4.BackColor = System.Drawing.Color.Transparent;
            listSubItem4.Checked = false;
            listSubItem4.ForeColor = System.Drawing.Color.Black;
            listSubItem4.Name = "";
            listSubItem4.Tag = null;
            listSubItem4.Text = "";
            listSubItem5.BackColor = System.Drawing.Color.Transparent;
            listSubItem5.Checked = false;
            listSubItem5.ForeColor = System.Drawing.Color.Black;
            listSubItem5.Name = "";
            listSubItem5.Tag = null;
            listSubItem5.Text = "";
            listSubItem6.BackColor = System.Drawing.Color.Transparent;
            listSubItem6.Checked = false;
            listSubItem6.ForeColor = System.Drawing.Color.Black;
            listSubItem6.Name = "";
            listSubItem6.Tag = null;
            listSubItem6.Text = "";
            listItem2.SubItems.Add(listSubItem4);
            listItem2.SubItems.Add(listSubItem5);
            listItem2.SubItems.Add(listSubItem6);
            listItem2.Tag = null;
            listItem2.Text = "";
            this.lstMonitor.Items.Add(listItem2);
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
            this.lstMonitor.Size = new System.Drawing.Size(378, 371);
            this.lstMonitor.SpanColumn = -1;
            this.lstMonitor.TabIndex = 1;
            this.lstMonitor.UseLocalList = true;
            this.lstMonitor.VerScroll = 0;
            // 
            // pnlMonitor
            // 
            this.pnlMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMonitor.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.pnlMonitor.Location = new System.Drawing.Point(0, 49);
            this.pnlMonitor.Name = "pnlMonitor";
            // 
            // pnlMonitor.Panel1
            // 
            this.pnlMonitor.Panel1.Controls.Add(this.lstSelector);
            this.pnlMonitor.Panel1.Controls.Add(this.txtbxSearch);
            // 
            // pnlMonitor.Panel2
            // 
            this.pnlMonitor.Panel2.Controls.Add(this.lstMonitor);
            this.pnlMonitor.Size = new System.Drawing.Size(587, 371);
            this.pnlMonitor.SplitterDistance = 205;
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
            column13.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column13.CountOffset = 0;
            column13.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column13.DropDownRight = false;
            column13.DropDownVisible = true;
            column13.FixedWidth = false;
            column13.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column13.Text = "";
            column13.UseItemBackColor = false;
            column13.UseItemForeColor = false;
            column13.Visible = true;
            column13.Width = 40;
            column14.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column14.CountOffset = 0;
            column14.DisplayType = ODModules.ColumnDisplayType.Text;
            column14.DropDownRight = false;
            column14.DropDownVisible = true;
            column14.FixedWidth = false;
            column14.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column14.Text = "Port";
            column14.UseItemBackColor = false;
            column14.UseItemForeColor = false;
            column14.Visible = true;
            column14.Width = 40;
            column15.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column15.CountOffset = 0;
            column15.DisplayType = ODModules.ColumnDisplayType.Text;
            column15.DropDownRight = false;
            column15.DropDownVisible = true;
            column15.FixedWidth = false;
            column15.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column15.Text = "Registers";
            column15.UseItemBackColor = false;
            column15.UseItemForeColor = false;
            column15.Visible = true;
            column15.Width = 60;
            column16.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column16.CountOffset = 0;
            column16.DisplayType = ODModules.ColumnDisplayType.Text;
            column16.DropDownRight = false;
            column16.DropDownVisible = true;
            column16.FixedWidth = false;
            column16.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column16.Text = "Type";
            column16.UseItemBackColor = false;
            column16.UseItemForeColor = false;
            column16.Visible = true;
            column16.Width = 77;
            this.lstSelector.Columns.Add(column13);
            this.lstSelector.Columns.Add(column14);
            this.lstSelector.Columns.Add(column15);
            this.lstSelector.Columns.Add(column16);
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
            this.lstSelector.Location = new System.Drawing.Point(0, 16);
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
            this.lstSelector.Size = new System.Drawing.Size(205, 355);
            this.lstSelector.SpanColumn = 2;
            this.lstSelector.TabIndex = 2;
            this.lstSelector.UseLocalList = true;
            this.lstSelector.VerScroll = 0;
            this.lstSelector.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstSelector_MouseClick);
            // 
            // txtbxSearch
            // 
            this.txtbxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.txtbxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtbxSearch.ForeColor = System.Drawing.Color.White;
            this.txtbxSearch.Location = new System.Drawing.Point(0, 0);
            this.txtbxSearch.Name = "txtbxSearch";
            this.txtbxSearch.PlaceholderText = "Search Registers";
            this.txtbxSearch.Size = new System.Drawing.Size(205, 16);
            this.txtbxSearch.TabIndex = 4;
            this.txtbxSearch.Visible = false;
            this.txtbxSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtbxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxSearch_KeyDown);
            this.txtbxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxSearch_KeyPress);
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
            this.tsMain.Size = new System.Drawing.Size(587, 25);
            this.tsMain.StripItemSelectedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.StripItemSelectedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.TabIndex = 3;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveLog.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveLog.Image")));
            this.btnSaveLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            this.btnOpenLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            this.btnOpenLogLocation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpenLogLocation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenLogLocation.Name = "btnOpenLogLocation";
            this.btnOpenLogLocation.Size = new System.Drawing.Size(23, 22);
            this.btnOpenLogLocation.Text = "Open Log Location";
            this.btnOpenLogLocation.Visible = false;
            this.btnOpenLogLocation.Click += new System.EventHandler(this.btnOpenLogLocation_Click);
            // 
            // btnOpenExcelDoc
            // 
            this.btnOpenExcelDoc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpenExcelDoc.Enabled = false;
            this.btnOpenExcelDoc.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenExcelDoc.Image")));
            this.btnOpenExcelDoc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            this.btnStartLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            this.btnStopLog.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            this.btnOptRegSingleMode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            this.btnOptRegMultiMode.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            this.btnOnTop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
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
            this.loggingToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.windowToolStripMenuItem,
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
            this.msMain.Size = new System.Drawing.Size(587, 24);
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
            this.openLogLocationToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openToolStripMenuItem.Text = "&Open Log";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openLogLocationToolStripMenuItem
            // 
            this.openLogLocationToolStripMenuItem.Enabled = false;
            this.openLogLocationToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.openLogLocationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openLogLocationToolStripMenuItem.Name = "openLogLocationToolStripMenuItem";
            this.openLogLocationToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.openLogLocationToolStripMenuItem.Text = "Open Log Location";
            this.openLogLocationToolStripMenuItem.Click += new System.EventHandler(this.openLogLocationToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(172, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.saveToolStripMenuItem.Text = "&Save Log";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(172, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
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
            this.insetModbusMonitorToolStripMenuItem,
            this.searchAvaliableRegistersToolStripMenuItem,
            this.toolStripSeparator4,
            this.addToMonitorToolStripMenuItem,
            this.removeFromMonitorToolStripMenuItem});
            this.registersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.registersToolStripMenuItem.Name = "registersToolStripMenuItem";
            this.registersToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.registersToolStripMenuItem.Text = "&Registers";
            // 
            // insetModbusMonitorToolStripMenuItem
            // 
            this.insetModbusMonitorToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.insetModbusMonitorToolStripMenuItem.Name = "insetModbusMonitorToolStripMenuItem";
            this.insetModbusMonitorToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.insetModbusMonitorToolStripMenuItem.Text = "Insert Modbus Monitor";
            this.insetModbusMonitorToolStripMenuItem.Visible = false;
            // 
            // searchAvaliableRegistersToolStripMenuItem
            // 
            this.searchAvaliableRegistersToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.searchAvaliableRegistersToolStripMenuItem.Name = "searchAvaliableRegistersToolStripMenuItem";
            this.searchAvaliableRegistersToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.searchAvaliableRegistersToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.searchAvaliableRegistersToolStripMenuItem.Text = "&Search Registers";
            this.searchAvaliableRegistersToolStripMenuItem.Click += new System.EventHandler(this.searchAvaliableRegistersToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(240, 6);
            // 
            // addToMonitorToolStripMenuItem
            // 
            this.addToMonitorToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.addToMonitorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addToMonitorToolStripMenuItem.Name = "addToMonitorToolStripMenuItem";
            this.addToMonitorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.addToMonitorToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.addToMonitorToolStripMenuItem.Text = "&Add to Monitor";
            this.addToMonitorToolStripMenuItem.Click += new System.EventHandler(this.addToMonitorToolStripMenuItem_Click);
            // 
            // removeFromMonitorToolStripMenuItem
            // 
            this.removeFromMonitorToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.removeFromMonitorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.removeFromMonitorToolStripMenuItem.Name = "removeFromMonitorToolStripMenuItem";
            this.removeFromMonitorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.removeFromMonitorToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.removeFromMonitorToolStripMenuItem.Text = "&Remove from Monitor";
            this.removeFromMonitorToolStripMenuItem.Click += new System.EventHandler(this.removeFromMonitorToolStripMenuItem_Click);
            // 
            // loggingToolStripMenuItem
            // 
            this.loggingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startLoggingToolStripMenuItem,
            this.stopLoggingToolStripMenuItem});
            this.loggingToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            this.loggingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.loggingToolStripMenuItem.Text = "&Logging";
            // 
            // startLoggingToolStripMenuItem
            // 
            this.startLoggingToolStripMenuItem.Enabled = false;
            this.startLoggingToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.startLoggingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.startLoggingToolStripMenuItem.Name = "startLoggingToolStripMenuItem";
            this.startLoggingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.startLoggingToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.startLoggingToolStripMenuItem.Text = "&Start Logging";
            this.startLoggingToolStripMenuItem.Click += new System.EventHandler(this.startLoggingToolStripMenuItem_Click);
            // 
            // stopLoggingToolStripMenuItem
            // 
            this.stopLoggingToolStripMenuItem.Enabled = false;
            this.stopLoggingToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.stopLoggingToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stopLoggingToolStripMenuItem.Name = "stopLoggingToolStripMenuItem";
            this.stopLoggingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.End)));
            this.stopLoggingToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.stopLoggingToolStripMenuItem.Text = "Stop &Logging";
            this.stopLoggingToolStripMenuItem.Click += new System.EventHandler(this.stopLoggingToolStripMenuItem_Click);
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
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            this.customizeToolStripMenuItem.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowManagerToolStripMenuItem});
            this.windowToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // windowManagerToolStripMenuItem
            // 
            this.windowManagerToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.windowManagerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.windowManagerToolStripMenuItem.Name = "windowManagerToolStripMenuItem";
            this.windowManagerToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.windowManagerToolStripMenuItem.Text = "&Window Manager";
            this.windowManagerToolStripMenuItem.Click += new System.EventHandler(this.windowManagerToolStripMenuItem_Click);
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
            this.contentsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
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
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(587, 420);
            this.Controls.Add(this.pnlMonitor);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.msMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "Monitor";
            this.Text = "Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Monitor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Monitor_FormClosed);
            this.Load += new System.EventHandler(this.Monitor_Load);
            this.SizeChanged += new System.EventHandler(this.Monitor_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.Monitor_VisibleChanged);
            this.pnlMonitor.Panel1.ResumeLayout(false);
            this.pnlMonitor.Panel1.PerformLayout();
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
        private TextBox txtbxSearch;
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
        private ToolStripMenuItem searchAvaliableRegistersToolStripMenuItem;
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem windowManagerToolStripMenuItem;
        private ToolStripMenuItem loggingToolStripMenuItem;
        private ToolStripMenuItem startLoggingToolStripMenuItem;
        private ToolStripMenuItem stopLoggingToolStripMenuItem;
        private ToolStripMenuItem openLogLocationToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem addToMonitorToolStripMenuItem;
        private ToolStripMenuItem removeFromMonitorToolStripMenuItem;
    }
}