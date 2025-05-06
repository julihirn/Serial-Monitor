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
            components = new System.ComponentModel.Container();
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
            lstMonitor = new ODModules.ListControl();
            pnlMonitor = new SplitContainer();
            lstSelector = new ODModules.ListControl();
            txtbxSearch = new TextBox();
            tsMain = new ODModules.ToolStrip();
            btnSaveLog = new ToolStripButton();
            btnOpenLog = new ToolStripButton();
            btnOpenLogLocation = new ToolStripButton();
            btnOpenExcelDoc = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnStartLog = new ToolStripButton();
            btnStopLog = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnOptRegSingleMode = new ToolStripButton();
            btnOptRegMultiMode = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnOnTop = new ToolStripButton();
            LogUpdater = new System.Windows.Forms.Timer(components);
            DisplayUpdater = new System.Windows.Forms.Timer(components);
            msMain = new ODModules.MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            openLogLocationToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            registersToolStripMenuItem = new ToolStripMenuItem();
            insetModbusMonitorToolStripMenuItem = new ToolStripMenuItem();
            searchAvaliableRegistersToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            addToMonitorToolStripMenuItem = new ToolStripMenuItem();
            removeFromMonitorToolStripMenuItem = new ToolStripMenuItem();
            loggingToolStripMenuItem = new ToolStripMenuItem();
            startLoggingToolStripMenuItem = new ToolStripMenuItem();
            stopLoggingToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            customizeToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            windowToolStripMenuItem = new ToolStripMenuItem();
            windowManagerToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            contentsToolStripMenuItem = new ToolStripMenuItem();
            indexToolStripMenuItem = new ToolStripMenuItem();
            searchToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pnlMonitor).BeginInit();
            pnlMonitor.Panel1.SuspendLayout();
            pnlMonitor.Panel2.SuspendLayout();
            pnlMonitor.SuspendLayout();
            tsMain.SuspendLayout();
            msMain.SuspendLayout();
            SuspendLayout();
            // 
            // lstMonitor
            // 
            lstMonitor.AllowColumnSpanning = false;
            lstMonitor.AllowMouseWheel = true;
            lstMonitor.BackColor = Color.FromArgb(20, 20, 20);
            lstMonitor.BorderColor = Color.Gray;
            lstMonitor.Borders = ODModules.Borders.None;
            lstMonitor.ColumnColor = Color.FromArgb(30, 30, 30);
            lstMonitor.ColumnForeColor = Color.WhiteSmoke;
            lstMonitor.ColumnLineColor = Color.FromArgb(64, 64, 64);
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column1.CountOffset = 0;
            column1.DataFormat = ODModules.ColumnDataFormat.None;
            column1.DisplayType = ODModules.ColumnDisplayType.Text;
            column1.DropDownRight = false;
            column1.DropDownVisible = true;
            column1.Exportable = false;
            column1.ExportName = "";
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column1.Text = "Register Name";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 100;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DataFormat = ODModules.ColumnDataFormat.None;
            column2.DisplayType = ODModules.ColumnDisplayType.Text;
            column2.DropDownRight = false;
            column2.DropDownVisible = false;
            column2.Exportable = false;
            column2.ExportName = "";
            column2.FixedWidth = false;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column2.Text = "Channel";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 70;
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column3.CountOffset = 0;
            column3.DataFormat = ODModules.ColumnDataFormat.None;
            column3.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column3.DropDownRight = false;
            column3.DropDownVisible = false;
            column3.Exportable = false;
            column3.ExportName = "";
            column3.FixedWidth = false;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column3.Text = "Data";
            column3.UseItemBackColor = true;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 100;
            column4.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column4.CountOffset = 0;
            column4.DataFormat = ODModules.ColumnDataFormat.None;
            column4.DisplayType = ODModules.ColumnDisplayType.Text;
            column4.DropDownRight = false;
            column4.DropDownVisible = false;
            column4.Exportable = false;
            column4.ExportName = "";
            column4.FixedWidth = false;
            column4.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column4.Text = "Last Updated";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 120;
            lstMonitor.Columns.Add(column1);
            lstMonitor.Columns.Add(column2);
            lstMonitor.Columns.Add(column3);
            lstMonitor.Columns.Add(column4);
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
            listItem1.SubItems.Add(listSubItem1);
            listItem1.SubItems.Add(listSubItem2);
            listItem1.SubItems.Add(listSubItem3);
            listItem1.Tag = null;
            listItem1.Text = "";
            listItem1.UseLineBackColor = false;
            listItem1.UseLineForeColor = false;
            listItem1.Value = 0;
            lstMonitor.Items.Add(listItem1);
            lstMonitor.LineMarkerIndex = 0;
            lstMonitor.Location = new Point(0, 0);
            lstMonitor.Margin = new Padding(6, 6, 6, 6);
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
            lstMonitor.Size = new Size(702, 826);
            lstMonitor.SpanColumn = -1;
            lstMonitor.TabIndex = 1;
            lstMonitor.UseLocalList = true;
            lstMonitor.VerScroll = 0;
            lstMonitor.Zoom = 100;
            // 
            // pnlMonitor
            // 
            pnlMonitor.Dock = DockStyle.Fill;
            pnlMonitor.FixedPanel = FixedPanel.Panel1;
            pnlMonitor.Location = new Point(0, 70);
            pnlMonitor.Margin = new Padding(6, 6, 6, 6);
            pnlMonitor.Name = "pnlMonitor";
            // 
            // pnlMonitor.Panel1
            // 
            pnlMonitor.Panel1.Controls.Add(lstSelector);
            pnlMonitor.Panel1.Controls.Add(txtbxSearch);
            // 
            // pnlMonitor.Panel2
            // 
            pnlMonitor.Panel2.Controls.Add(lstMonitor);
            pnlMonitor.Size = new Size(1090, 826);
            pnlMonitor.SplitterDistance = 381;
            pnlMonitor.SplitterWidth = 7;
            pnlMonitor.TabIndex = 2;
            // 
            // lstSelector
            // 
            lstSelector.AllowColumnSpanning = false;
            lstSelector.AllowMouseWheel = true;
            lstSelector.BackColor = Color.FromArgb(20, 20, 20);
            lstSelector.BorderColor = Color.Gray;
            lstSelector.Borders = ODModules.Borders.None;
            lstSelector.ColumnColor = Color.FromArgb(30, 30, 30);
            lstSelector.ColumnForeColor = Color.WhiteSmoke;
            lstSelector.ColumnLineColor = Color.FromArgb(64, 64, 64);
            column5.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column5.CountOffset = 0;
            column5.DataFormat = ODModules.ColumnDataFormat.None;
            column5.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column5.DropDownRight = false;
            column5.DropDownVisible = true;
            column5.Exportable = false;
            column5.ExportName = "";
            column5.FixedWidth = false;
            column5.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column5.Text = "";
            column5.UseItemBackColor = false;
            column5.UseItemForeColor = false;
            column5.Visible = true;
            column5.Width = 40;
            column6.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column6.CountOffset = 0;
            column6.DataFormat = ODModules.ColumnDataFormat.None;
            column6.DisplayType = ODModules.ColumnDisplayType.Text;
            column6.DropDownRight = false;
            column6.DropDownVisible = true;
            column6.Exportable = false;
            column6.ExportName = "";
            column6.FixedWidth = false;
            column6.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column6.Text = "Channel";
            column6.UseItemBackColor = false;
            column6.UseItemForeColor = false;
            column6.Visible = true;
            column6.Width = 40;
            column7.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column7.CountOffset = 0;
            column7.DataFormat = ODModules.ColumnDataFormat.None;
            column7.DisplayType = ODModules.ColumnDisplayType.Text;
            column7.DropDownRight = false;
            column7.DropDownVisible = true;
            column7.Exportable = false;
            column7.ExportName = "";
            column7.FixedWidth = false;
            column7.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column7.Text = "Registers";
            column7.UseItemBackColor = false;
            column7.UseItemForeColor = false;
            column7.Visible = true;
            column7.Width = 60;
            column8.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column8.CountOffset = 0;
            column8.DataFormat = ODModules.ColumnDataFormat.None;
            column8.DisplayType = ODModules.ColumnDisplayType.Text;
            column8.DropDownRight = false;
            column8.DropDownVisible = true;
            column8.Exportable = false;
            column8.ExportName = "";
            column8.FixedWidth = false;
            column8.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column8.Text = "Type";
            column8.UseItemBackColor = false;
            column8.UseItemForeColor = false;
            column8.Visible = true;
            column8.Width = 77;
            lstSelector.Columns.Add(column5);
            lstSelector.Columns.Add(column6);
            lstSelector.Columns.Add(column7);
            lstSelector.Columns.Add(column8);
            lstSelector.Dock = DockStyle.Fill;
            lstSelector.DropDownMouseDown = Color.DimGray;
            lstSelector.DropDownMouseOver = Color.LightGray;
            lstSelector.ExternalItems = null;
            lstSelector.Filter = null;
            lstSelector.FilterColumn = 2;
            lstSelector.ForeColor = Color.White;
            lstSelector.GridlineColor = Color.FromArgb(30, 30, 30);
            lstSelector.HighlightStrength = 128;
            lstSelector.HorizontalScrollStep = 3;
            lstSelector.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstSelector.LineMarkerIndex = 0;
            lstSelector.Location = new Point(0, 32);
            lstSelector.Margin = new Padding(6, 6, 6, 6);
            lstSelector.MarkerBorderColor = Color.LimeGreen;
            lstSelector.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstSelector.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstSelector.Name = "lstSelector";
            lstSelector.RowColor = Color.FromArgb(23, 23, 23);
            lstSelector.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstSelector.ScrollBarNorth = Color.FromArgb(64, 64, 64);
            lstSelector.ScrollBarSouth = Color.FromArgb(64, 64, 64);
            lstSelector.ScrollItems = 3;
            lstSelector.SelectedColor = Color.SteelBlue;
            lstSelector.SelectionColor = Color.Gray;
            lstSelector.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstSelector.ShowGrid = true;
            lstSelector.ShowItemIndentation = false;
            lstSelector.ShowMarker = false;
            lstSelector.ShowRowColors = true;
            lstSelector.Size = new Size(381, 794);
            lstSelector.SpanColumn = 2;
            lstSelector.TabIndex = 2;
            lstSelector.UseLocalList = true;
            lstSelector.VerScroll = 0;
            lstSelector.Zoom = 100;
            lstSelector.MouseClick += lstSelector_MouseClick;
            // 
            // txtbxSearch
            // 
            txtbxSearch.BackColor = Color.FromArgb(13, 13, 13);
            txtbxSearch.BorderStyle = BorderStyle.None;
            txtbxSearch.Dock = DockStyle.Top;
            txtbxSearch.ForeColor = Color.White;
            txtbxSearch.Location = new Point(0, 0);
            txtbxSearch.Margin = new Padding(6, 6, 6, 6);
            txtbxSearch.Name = "txtbxSearch";
            txtbxSearch.PlaceholderText = "Search Registers";
            txtbxSearch.Size = new Size(381, 32);
            txtbxSearch.TabIndex = 4;
            txtbxSearch.Visible = false;
            txtbxSearch.TextChanged += textBox1_TextChanged;
            txtbxSearch.KeyDown += txtbxSearch_KeyDown;
            txtbxSearch.KeyPress += txtbxSearch_KeyPress;
            // 
            // tsMain
            // 
            tsMain.BackColorNorth = Color.FromArgb(31, 31, 31);
            tsMain.BackColorSouth = Color.FromArgb(31, 31, 31);
            tsMain.BorderColor = Color.WhiteSmoke;
            tsMain.ImageScalingSize = new Size(32, 32);
            tsMain.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemForeColor = Color.WhiteSmoke;
            tsMain.Items.AddRange(new ToolStripItem[] { btnSaveLog, btnOpenLog, btnOpenLogLocation, btnOpenExcelDoc, toolStripSeparator1, btnStartLog, btnStopLog, toolStripSeparator2, btnOptRegSingleMode, btnOptRegMultiMode, toolStripSeparator3, btnOnTop });
            tsMain.ItemSelectedBackColorNorth = Color.FromArgb(64, 64, 64);
            tsMain.ItemSelectedBackColorSouth = Color.FromArgb(64, 64, 64);
            tsMain.ItemSelectedForeColor = Color.WhiteSmoke;
            tsMain.Location = new Point(0, 44);
            tsMain.MenuBackColorNorth = Color.FromArgb(31, 31, 31);
            tsMain.MenuBackColorSouth = Color.FromArgb(31, 31, 31);
            tsMain.MenuBorderColor = Color.DimGray;
            tsMain.MenuSeparatorColor = Color.FromArgb(55, 55, 55);
            tsMain.MenuSymbolColor = Color.FromArgb(64, 64, 64);
            tsMain.Name = "tsMain";
            tsMain.Padding = new Padding(0, 0, 4, 0);
            tsMain.RoundedToolStrip = false;
            tsMain.ShowBorder = false;
            tsMain.Size = new Size(1090, 26);
            tsMain.StripItemSelectedBackColorNorth = Color.FromArgb(64, 64, 64);
            tsMain.StripItemSelectedBackColorSouth = Color.FromArgb(64, 64, 64);
            tsMain.TabIndex = 3;
            tsMain.Text = "toolStrip1";
            // 
            // btnSaveLog
            // 
            btnSaveLog.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSaveLog.Image = (Image)resources.GetObject("btnSaveLog.Image");
            btnSaveLog.ImageScaling = ToolStripItemImageScaling.None;
            btnSaveLog.ImageTransparentColor = Color.Magenta;
            btnSaveLog.Name = "btnSaveLog";
            btnSaveLog.Size = new Size(46, 20);
            btnSaveLog.Text = "Save Log";
            btnSaveLog.Click += btnSaveLog_Click;
            // 
            // btnOpenLog
            // 
            btnOpenLog.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOpenLog.Image = (Image)resources.GetObject("btnOpenLog.Image");
            btnOpenLog.ImageScaling = ToolStripItemImageScaling.None;
            btnOpenLog.ImageTransparentColor = Color.Magenta;
            btnOpenLog.Name = "btnOpenLog";
            btnOpenLog.Size = new Size(46, 20);
            btnOpenLog.Text = "Open Log";
            btnOpenLog.Click += btnOpenLog_Click;
            // 
            // btnOpenLogLocation
            // 
            btnOpenLogLocation.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOpenLogLocation.Enabled = false;
            btnOpenLogLocation.Image = (Image)resources.GetObject("btnOpenLogLocation.Image");
            btnOpenLogLocation.ImageScaling = ToolStripItemImageScaling.None;
            btnOpenLogLocation.ImageTransparentColor = Color.Magenta;
            btnOpenLogLocation.Name = "btnOpenLogLocation";
            btnOpenLogLocation.Size = new Size(46, 20);
            btnOpenLogLocation.Text = "Open Log Location";
            btnOpenLogLocation.Visible = false;
            btnOpenLogLocation.Click += btnOpenLogLocation_Click;
            // 
            // btnOpenExcelDoc
            // 
            btnOpenExcelDoc.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOpenExcelDoc.Enabled = false;
            btnOpenExcelDoc.Image = (Image)resources.GetObject("btnOpenExcelDoc.Image");
            btnOpenExcelDoc.ImageScaling = ToolStripItemImageScaling.None;
            btnOpenExcelDoc.ImageTransparentColor = Color.Magenta;
            btnOpenExcelDoc.Name = "btnOpenExcelDoc";
            btnOpenExcelDoc.Size = new Size(46, 20);
            btnOpenExcelDoc.Text = "Open Copy of Log in Excel";
            btnOpenExcelDoc.Click += btnOpenExcelDoc_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 26);
            // 
            // btnStartLog
            // 
            btnStartLog.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStartLog.Enabled = false;
            btnStartLog.Image = (Image)resources.GetObject("btnStartLog.Image");
            btnStartLog.ImageScaling = ToolStripItemImageScaling.None;
            btnStartLog.ImageTransparentColor = Color.Magenta;
            btnStartLog.Name = "btnStartLog";
            btnStartLog.Size = new Size(46, 20);
            btnStartLog.Text = "Start Logging";
            btnStartLog.Click += btnStartLog_Click;
            // 
            // btnStopLog
            // 
            btnStopLog.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStopLog.Enabled = false;
            btnStopLog.Image = (Image)resources.GetObject("btnStopLog.Image");
            btnStopLog.ImageScaling = ToolStripItemImageScaling.None;
            btnStopLog.ImageTransparentColor = Color.Magenta;
            btnStopLog.Name = "btnStopLog";
            btnStopLog.Size = new Size(46, 20);
            btnStopLog.Text = "Stop Logging";
            btnStopLog.Click += btnStopLog_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 26);
            // 
            // btnOptRegSingleMode
            // 
            btnOptRegSingleMode.Checked = true;
            btnOptRegSingleMode.CheckOnClick = true;
            btnOptRegSingleMode.CheckState = CheckState.Checked;
            btnOptRegSingleMode.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOptRegSingleMode.Image = (Image)resources.GetObject("btnOptRegSingleMode.Image");
            btnOptRegSingleMode.ImageScaling = ToolStripItemImageScaling.None;
            btnOptRegSingleMode.ImageTransparentColor = Color.Magenta;
            btnOptRegSingleMode.Name = "btnOptRegSingleMode";
            btnOptRegSingleMode.Size = new Size(46, 20);
            btnOptRegSingleMode.Text = "Single Register Mode";
            btnOptRegSingleMode.Click += btnOptRegSingleMode_Click;
            // 
            // btnOptRegMultiMode
            // 
            btnOptRegMultiMode.CheckOnClick = true;
            btnOptRegMultiMode.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOptRegMultiMode.Image = (Image)resources.GetObject("btnOptRegMultiMode.Image");
            btnOptRegMultiMode.ImageScaling = ToolStripItemImageScaling.None;
            btnOptRegMultiMode.ImageTransparentColor = Color.Magenta;
            btnOptRegMultiMode.Name = "btnOptRegMultiMode";
            btnOptRegMultiMode.Size = new Size(46, 20);
            btnOptRegMultiMode.Text = "Multi Register Mode";
            btnOptRegMultiMode.Click += btnOptRegMultiMode_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 26);
            // 
            // btnOnTop
            // 
            btnOnTop.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOnTop.Image = (Image)resources.GetObject("btnOnTop.Image");
            btnOnTop.ImageScaling = ToolStripItemImageScaling.None;
            btnOnTop.ImageTransparentColor = Color.Magenta;
            btnOnTop.Name = "btnOnTop";
            btnOnTop.Size = new Size(46, 20);
            btnOnTop.Text = "Always On Top";
            btnOnTop.Click += btnOnTop_Click;
            // 
            // LogUpdater
            // 
            LogUpdater.Enabled = true;
            LogUpdater.Interval = 1000;
            LogUpdater.Tick += LogUpdater_Tick;
            // 
            // DisplayUpdater
            // 
            DisplayUpdater.Enabled = true;
            DisplayUpdater.Interval = 250;
            DisplayUpdater.Tick += DisplayUpdater_Tick;
            // 
            // msMain
            // 
            msMain.BackColorNorth = Color.FromArgb(31, 31, 31);
            msMain.BackColorNorthFadeIn = Color.FromArgb(10, 10, 10);
            msMain.BackColorSouth = Color.FromArgb(31, 31, 31);
            msMain.Fade = true;
            msMain.ImageScalingSize = new Size(32, 32);
            msMain.ItemForeColor = SystemColors.Window;
            msMain.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, registersToolStripMenuItem, loggingToolStripMenuItem, toolsToolStripMenuItem, windowToolStripMenuItem, helpToolStripMenuItem });
            msMain.ItemSelectedBackColorNorth = Color.FromArgb(64, 64, 64);
            msMain.ItemSelectedBackColorSouth = Color.FromArgb(64, 64, 64);
            msMain.ItemSelectedForeColor = SystemColors.Window;
            msMain.Location = new Point(0, 0);
            msMain.MenuBackColorNorth = Color.FromArgb(31, 31, 31);
            msMain.MenuBackColorSouth = Color.FromArgb(31, 31, 31);
            msMain.MenuBorderColor = Color.DimGray;
            msMain.MenuSeparatorColor = Color.FromArgb(55, 55, 55);
            msMain.MenuSymbolColor = Color.FromArgb(64, 64, 64);
            msMain.Name = "msMain";
            msMain.Padding = new Padding(11, 4, 0, 4);
            msMain.Size = new Size(1090, 44);
            msMain.StripItemSelectedBackColorNorth = Color.FromArgb(64, 64, 64);
            msMain.StripItemSelectedBackColorSouth = Color.FromArgb(64, 64, 64);
            msMain.TabIndex = 5;
            msMain.Text = "Main Menu";
            msMain.UseNorthFadeIn = false;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, openLogLocationToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, toolStripSeparator5, exitToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = SystemColors.Window;
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 36);
            fileToolStripMenuItem.Text = "&File";
            fileToolStripMenuItem.Click += fileToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.ForeColor = SystemColors.Window;
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(349, 44);
            openToolStripMenuItem.Text = "&Open Log";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openLogLocationToolStripMenuItem
            // 
            openLogLocationToolStripMenuItem.Enabled = false;
            openLogLocationToolStripMenuItem.ForeColor = SystemColors.Window;
            openLogLocationToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            openLogLocationToolStripMenuItem.Name = "openLogLocationToolStripMenuItem";
            openLogLocationToolStripMenuItem.Size = new Size(349, 44);
            openLogLocationToolStripMenuItem.Text = "Open Log Location";
            openLogLocationToolStripMenuItem.Click += openLogLocationToolStripMenuItem_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(346, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.ForeColor = SystemColors.Window;
            saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(349, 44);
            saveToolStripMenuItem.Text = "&Save Log";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(346, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.ForeColor = SystemColors.Window;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(349, 44);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator6, cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator7, selectAllToolStripMenuItem });
            editToolStripMenuItem.ForeColor = SystemColors.Window;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(74, 36);
            editToolStripMenuItem.Text = "&Edit";
            editToolStripMenuItem.Visible = false;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.ForeColor = SystemColors.Window;
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(245, 44);
            undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.ForeColor = SystemColors.Window;
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(245, 44);
            redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(242, 6);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.ForeColor = SystemColors.Window;
            cutToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(245, 44);
            cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ForeColor = SystemColors.Window;
            copyToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(245, 44);
            copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ForeColor = SystemColors.Window;
            pasteToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(245, 44);
            pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(242, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.ForeColor = SystemColors.Window;
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.Size = new Size(245, 44);
            selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // registersToolStripMenuItem
            // 
            registersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { insetModbusMonitorToolStripMenuItem, searchAvaliableRegistersToolStripMenuItem, toolStripSeparator4, addToMonitorToolStripMenuItem, removeFromMonitorToolStripMenuItem });
            registersToolStripMenuItem.ForeColor = SystemColors.Window;
            registersToolStripMenuItem.Name = "registersToolStripMenuItem";
            registersToolStripMenuItem.Size = new Size(129, 36);
            registersToolStripMenuItem.Text = "&Registers";
            // 
            // insetModbusMonitorToolStripMenuItem
            // 
            insetModbusMonitorToolStripMenuItem.ForeColor = SystemColors.Window;
            insetModbusMonitorToolStripMenuItem.Name = "insetModbusMonitorToolStripMenuItem";
            insetModbusMonitorToolStripMenuItem.Size = new Size(487, 44);
            insetModbusMonitorToolStripMenuItem.Text = "Insert Modbus Monitor";
            insetModbusMonitorToolStripMenuItem.Visible = false;
            // 
            // searchAvaliableRegistersToolStripMenuItem
            // 
            searchAvaliableRegistersToolStripMenuItem.ForeColor = SystemColors.Window;
            searchAvaliableRegistersToolStripMenuItem.Name = "searchAvaliableRegistersToolStripMenuItem";
            searchAvaliableRegistersToolStripMenuItem.ShortcutKeys = Keys.F2;
            searchAvaliableRegistersToolStripMenuItem.Size = new Size(487, 44);
            searchAvaliableRegistersToolStripMenuItem.Text = "&Search Registers";
            searchAvaliableRegistersToolStripMenuItem.Click += searchAvaliableRegistersToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(484, 6);
            // 
            // addToMonitorToolStripMenuItem
            // 
            addToMonitorToolStripMenuItem.ForeColor = SystemColors.Window;
            addToMonitorToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            addToMonitorToolStripMenuItem.Name = "addToMonitorToolStripMenuItem";
            addToMonitorToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.W;
            addToMonitorToolStripMenuItem.Size = new Size(487, 44);
            addToMonitorToolStripMenuItem.Text = "&Add to Monitor";
            addToMonitorToolStripMenuItem.Click += addToMonitorToolStripMenuItem_Click;
            // 
            // removeFromMonitorToolStripMenuItem
            // 
            removeFromMonitorToolStripMenuItem.ForeColor = SystemColors.Window;
            removeFromMonitorToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            removeFromMonitorToolStripMenuItem.Name = "removeFromMonitorToolStripMenuItem";
            removeFromMonitorToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Delete;
            removeFromMonitorToolStripMenuItem.Size = new Size(487, 44);
            removeFromMonitorToolStripMenuItem.Text = "&Remove from Monitor";
            removeFromMonitorToolStripMenuItem.Click += removeFromMonitorToolStripMenuItem_Click;
            // 
            // loggingToolStripMenuItem
            // 
            loggingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { startLoggingToolStripMenuItem, stopLoggingToolStripMenuItem });
            loggingToolStripMenuItem.ForeColor = SystemColors.Window;
            loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            loggingToolStripMenuItem.Size = new Size(121, 36);
            loggingToolStripMenuItem.Text = "&Logging";
            // 
            // startLoggingToolStripMenuItem
            // 
            startLoggingToolStripMenuItem.Enabled = false;
            startLoggingToolStripMenuItem.ForeColor = SystemColors.Window;
            startLoggingToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            startLoggingToolStripMenuItem.Name = "startLoggingToolStripMenuItem";
            startLoggingToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Space;
            startLoggingToolStripMenuItem.Size = new Size(419, 44);
            startLoggingToolStripMenuItem.Text = "&Start Logging";
            startLoggingToolStripMenuItem.Click += startLoggingToolStripMenuItem_Click;
            // 
            // stopLoggingToolStripMenuItem
            // 
            stopLoggingToolStripMenuItem.Enabled = false;
            stopLoggingToolStripMenuItem.ForeColor = SystemColors.Window;
            stopLoggingToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            stopLoggingToolStripMenuItem.Name = "stopLoggingToolStripMenuItem";
            stopLoggingToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.End;
            stopLoggingToolStripMenuItem.Size = new Size(419, 44);
            stopLoggingToolStripMenuItem.Text = "Stop &Logging";
            stopLoggingToolStripMenuItem.Click += stopLoggingToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customizeToolStripMenuItem, optionsToolStripMenuItem });
            toolsToolStripMenuItem.ForeColor = SystemColors.Window;
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(89, 36);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            customizeToolStripMenuItem.ForeColor = SystemColors.Window;
            customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            customizeToolStripMenuItem.Size = new Size(259, 44);
            customizeToolStripMenuItem.Text = "&Customize";
            customizeToolStripMenuItem.Visible = false;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.ForeColor = SystemColors.Window;
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(259, 44);
            optionsToolStripMenuItem.Text = "&Options";
            optionsToolStripMenuItem.Click += optionsToolStripMenuItem_Click;
            // 
            // windowToolStripMenuItem
            // 
            windowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { windowManagerToolStripMenuItem });
            windowToolStripMenuItem.ForeColor = SystemColors.Window;
            windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            windowToolStripMenuItem.Size = new Size(121, 36);
            windowToolStripMenuItem.Text = "&Window";
            // 
            // windowManagerToolStripMenuItem
            // 
            windowManagerToolStripMenuItem.ForeColor = SystemColors.Window;
            windowManagerToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            windowManagerToolStripMenuItem.Name = "windowManagerToolStripMenuItem";
            windowManagerToolStripMenuItem.Size = new Size(336, 44);
            windowManagerToolStripMenuItem.Text = "&Window Manager";
            windowManagerToolStripMenuItem.Click += windowManagerToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { contentsToolStripMenuItem, indexToolStripMenuItem, searchToolStripMenuItem, toolStripSeparator8, aboutToolStripMenuItem });
            helpToolStripMenuItem.ForeColor = SystemColors.Window;
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(84, 36);
            helpToolStripMenuItem.Text = "&Help";
            helpToolStripMenuItem.Visible = false;
            // 
            // contentsToolStripMenuItem
            // 
            contentsToolStripMenuItem.ForeColor = SystemColors.Window;
            contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            contentsToolStripMenuItem.Size = new Size(243, 44);
            contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            indexToolStripMenuItem.ForeColor = SystemColors.Window;
            indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            indexToolStripMenuItem.Size = new Size(243, 44);
            indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            searchToolStripMenuItem.ForeColor = SystemColors.Window;
            searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            searchToolStripMenuItem.Size = new Size(243, 44);
            searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(240, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.ForeColor = SystemColors.Window;
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(243, 44);
            aboutToolStripMenuItem.Text = "&About...";
            // 
            // Monitor
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(1090, 896);
            Controls.Add(pnlMonitor);
            Controls.Add(tsMain);
            Controls.Add(msMain);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(0, 0);
            MainMenuStrip = msMain;
            Margin = new Padding(6, 6, 6, 6);
            Name = "Monitor";
            Text = "Monitor";
            FormClosing += Monitor_FormClosing;
            FormClosed += Monitor_FormClosed;
            Load += Monitor_Load;
            SizeChanged += Monitor_SizeChanged;
            VisibleChanged += Monitor_VisibleChanged;
            pnlMonitor.Panel1.ResumeLayout(false);
            pnlMonitor.Panel1.PerformLayout();
            pnlMonitor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnlMonitor).EndInit();
            pnlMonitor.ResumeLayout(false);
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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