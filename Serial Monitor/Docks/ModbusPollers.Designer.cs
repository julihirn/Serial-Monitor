namespace Serial_Monitor.Docks {
    partial class ModbusPollers {
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
            ODModules.Column column1 = new ODModules.Column();
            ODModules.Column column2 = new ODModules.Column();
            ODModules.Column column3 = new ODModules.Column();
            ODModules.Column column4 = new ODModules.Column();
            ODModules.Column column5 = new ODModules.Column();
            ODModules.Column column6 = new ODModules.Column();
            ODModules.Column column7 = new ODModules.Column();
            ODModules.Column column8 = new ODModules.Column();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModbusPollers));
            lstPollers = new ODModules.ListControl();
            tsMain = new ODModules.ToolStrip();
            btnAddPoller = new ToolStripButton();
            btnRemovePoller = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnStartPolling = new ToolStripButton();
            btnStopPolling = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnStartAndEnd = new ToolStripButton();
            cmDataSet = new ODModules.ContextMenu();
            cmChannels = new ODModules.ContextMenu();
            tsTranslationExtender = new ODModules.ControlExtensions.ToolStripItemExtender();
            tsMain.SuspendLayout();
            SuspendLayout();
            // 
            // lstPollers
            // 
            lstPollers.AllowArrowKeyCellSelect = true;
            lstPollers.AllowColumnSpanning = false;
            lstPollers.AllowMouseWheel = true;
            lstPollers.BorderColor = Color.Gray;
            lstPollers.Borders = ODModules.Borders.None;
            lstPollers.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            lstPollers.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            lstPollers.CellPixelFit = true;
            lstPollers.CellSelectEditableOnly = true;
            lstPollers.CellSelectionBorderColor = Color.Blue;
            lstPollers.ColumnColor = Color.LightGray;
            lstPollers.ColumnForeColor = Color.Black;
            lstPollers.ColumnLineColor = Color.DimGray;
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column1.CountOffset = 0;
            column1.DataFormat = ODModules.ColumnDataFormat.None;
            column1.DisplayType = ODModules.ColumnDisplayType.Checkbox;
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
            column1.Width = 30;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DataFormat = ODModules.ColumnDataFormat.None;
            column2.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column2.DropDownRight = false;
            column2.DropDownVisible = false;
            column2.Exportable = false;
            column2.ExportName = "";
            column2.FixedWidth = false;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column2.Text = "Frequency";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 80;
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column3.CountOffset = 0;
            column3.DataFormat = ODModules.ColumnDataFormat.None;
            column3.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column3.DropDownRight = false;
            column3.DropDownVisible = true;
            column3.Exportable = false;
            column3.ExportName = "";
            column3.FixedWidth = false;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column3.Text = "Channel";
            column3.UseItemBackColor = false;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 100;
            column4.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column4.CountOffset = 0;
            column4.DataFormat = ODModules.ColumnDataFormat.None;
            column4.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column4.DropDownRight = false;
            column4.DropDownVisible = false;
            column4.Exportable = false;
            column4.ExportName = "";
            column4.FixedWidth = false;
            column4.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column4.Text = "Unit";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 50;
            column5.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column5.CountOffset = 0;
            column5.DataFormat = ODModules.ColumnDataFormat.None;
            column5.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column5.DropDownRight = false;
            column5.DropDownVisible = true;
            column5.Exportable = false;
            column5.ExportName = "";
            column5.FixedWidth = false;
            column5.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column5.Text = "Read";
            column5.UseItemBackColor = false;
            column5.UseItemForeColor = false;
            column5.Visible = true;
            column5.Width = 90;
            column6.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column6.CountOffset = 0;
            column6.DataFormat = ODModules.ColumnDataFormat.None;
            column6.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column6.DropDownRight = false;
            column6.DropDownVisible = false;
            column6.Exportable = false;
            column6.ExportName = "";
            column6.FixedWidth = false;
            column6.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column6.Text = "Address";
            column6.UseItemBackColor = false;
            column6.UseItemForeColor = false;
            column6.Visible = true;
            column6.Width = 50;
            column7.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column7.CountOffset = 0;
            column7.DataFormat = ODModules.ColumnDataFormat.None;
            column7.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column7.DropDownRight = false;
            column7.DropDownVisible = false;
            column7.Exportable = false;
            column7.ExportName = "";
            column7.FixedWidth = false;
            column7.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column7.Text = "Count";
            column7.UseItemBackColor = false;
            column7.UseItemForeColor = false;
            column7.Visible = true;
            column7.Width = 50;
            column8.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column8.CountOffset = 0;
            column8.DataFormat = ODModules.ColumnDataFormat.None;
            column8.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column8.DropDownRight = false;
            column8.DropDownVisible = false;
            column8.Exportable = false;
            column8.ExportName = "";
            column8.FixedWidth = false;
            column8.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column8.Text = "End";
            column8.UseItemBackColor = false;
            column8.UseItemForeColor = false;
            column8.Visible = false;
            column8.Width = 50;
            lstPollers.Columns.Add(column1);
            lstPollers.Columns.Add(column2);
            lstPollers.Columns.Add(column3);
            lstPollers.Columns.Add(column4);
            lstPollers.Columns.Add(column5);
            lstPollers.Columns.Add(column6);
            lstPollers.Columns.Add(column7);
            lstPollers.Columns.Add(column8);
            lstPollers.Dock = DockStyle.Fill;
            lstPollers.DropDownMouseDown = Color.DimGray;
            lstPollers.DropDownMouseOver = Color.LightGray;
            lstPollers.ExternalItems = null;
            lstPollers.Filter = "";
            lstPollers.FilterColumn = 0;
            lstPollers.FilterSearchType = ODModules.ListControl.FilterSearch.Contains;
            lstPollers.GridlineColor = Color.LightGray;
            lstPollers.HighlightStrength = 128;
            lstPollers.HorizontalScrollStep = 3;
            lstPollers.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstPollers.LineMarkerIndex = 0;
            lstPollers.Location = new Point(0, 54);
            lstPollers.MarkerBorderColor = Color.LimeGreen;
            lstPollers.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstPollers.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstPollers.MoveControlOnCellChange = true;
            lstPollers.Name = "lstPollers";
            lstPollers.RowColor = Color.LightGray;
            lstPollers.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstPollers.ScrollBarNorth = Color.DarkTurquoise;
            lstPollers.ScrollBarSouth = Color.DeepSkyBlue;
            lstPollers.ScrollItems = 3;
            lstPollers.SelectedColor = Color.SkyBlue;
            lstPollers.SelectionColor = Color.Gray;
            lstPollers.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstPollers.ShowCellSelection = true;
            lstPollers.ShowGrid = true;
            lstPollers.ShowHeader = true;
            lstPollers.ShowItemIndentation = false;
            lstPollers.ShowMarker = false;
            lstPollers.ShowRowColors = false;
            lstPollers.Size = new Size(834, 325);
            lstPollers.SpanColumn = 0;
            lstPollers.TabIndex = 0;
            lstPollers.UseLocalList = true;
            lstPollers.VerScroll = 0;
            lstPollers.Zoom = 100;
            lstPollers.DropDownClicked += lstPollers_DropDownClicked;
            lstPollers.ItemCheckedChanged += lstPollers_ItemCheckedChanged;
            lstPollers.SelectionChanged += lstPollers_SelectionChanged;
            lstPollers.CellSelected += lstPollers_CellSelected;
            lstPollers.KeyPress += lstPollers_KeyPress;
            // 
            // tsMain
            // 
            tsMain.BackColorNorth = Color.DodgerBlue;
            tsMain.BackColorSouth = Color.DodgerBlue;
            tsMain.BorderColor = Color.WhiteSmoke;
            tsMain.GripColor = Color.WhiteSmoke;
            tsMain.GripStyle = ToolStripGripStyle.Hidden;
            tsMain.ImageScalingSize = new Size(32, 32);
            tsMain.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemForeColor = Color.Black;
            tsMain.Items.AddRange(new ToolStripItem[] { btnAddPoller, btnRemovePoller, toolStripSeparator1, btnStartPolling, btnStopPolling, toolStripSeparator2, btnStartAndEnd });
            tsMain.ItemSelectedBackColorNorth = Color.White;
            tsMain.ItemSelectedBackColorSouth = Color.White;
            tsMain.ItemSelectedForeColor = Color.Black;
            tsMain.Location = new Point(0, 0);
            tsMain.MenuBackColorNorth = Color.DodgerBlue;
            tsMain.MenuBackColorSouth = Color.DodgerBlue;
            tsMain.MenuBorderColor = Color.WhiteSmoke;
            tsMain.MenuSeparatorColor = Color.WhiteSmoke;
            tsMain.MenuSymbolColor = Color.WhiteSmoke;
            tsMain.Name = "tsMain";
            tsMain.Padding = new Padding(0);
            tsMain.RoundedToolStrip = true;
            tsMain.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            tsMain.ShowBorder = true;
            tsMain.ShowShadow = true;
            tsMain.Size = new Size(834, 54);
            tsMain.StripItemSelectedBackColorNorth = Color.White;
            tsMain.StripItemSelectedBackColorSouth = Color.White;
            tsMain.TabIndex = 1;
            tsMain.Text = "Main";
            // 
            // btnAddPoller
            // 
            btnAddPoller.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAddPoller.Image = (Image)resources.GetObject("btnAddPoller.Image");
            btnAddPoller.ImageScaling = ToolStripItemImageScaling.None;
            btnAddPoller.ImageTransparentColor = Color.Magenta;
            btnAddPoller.Name = "btnAddPoller";
            btnAddPoller.Size = new Size(46, 36);
            btnAddPoller.Text = "Add Poller";
            tsTranslationExtender.SetTranslationReference(btnAddPoller, "pollerAdd");
            btnAddPoller.Click += btnAddPoller_Click;
            // 
            // btnRemovePoller
            // 
            btnRemovePoller.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRemovePoller.Enabled = false;
            btnRemovePoller.Image = (Image)resources.GetObject("btnRemovePoller.Image");
            btnRemovePoller.ImageScaling = ToolStripItemImageScaling.None;
            btnRemovePoller.ImageTransparentColor = Color.Magenta;
            btnRemovePoller.Name = "btnRemovePoller";
            btnRemovePoller.Size = new Size(46, 36);
            btnRemovePoller.Text = "Remove Selected";
            tsTranslationExtender.SetTranslationReference(btnRemovePoller, "pollerRemove");
            btnRemovePoller.Click += btnRemovePoller_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 42);
            tsTranslationExtender.SetTranslationReference(toolStripSeparator1, "");
            // 
            // btnStartPolling
            // 
            btnStartPolling.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStartPolling.Enabled = false;
            btnStartPolling.Image = (Image)resources.GetObject("btnStartPolling.Image");
            btnStartPolling.ImageScaling = ToolStripItemImageScaling.None;
            btnStartPolling.ImageTransparentColor = Color.Magenta;
            btnStartPolling.Name = "btnStartPolling";
            btnStartPolling.Size = new Size(46, 36);
            btnStartPolling.Text = "Start Polling";
            tsTranslationExtender.SetTranslationReference(btnStartPolling, "pollingStart");
            btnStartPolling.Click += btnStartPolling_Click;
            // 
            // btnStopPolling
            // 
            btnStopPolling.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStopPolling.Enabled = false;
            btnStopPolling.Image = (Image)resources.GetObject("btnStopPolling.Image");
            btnStopPolling.ImageScaling = ToolStripItemImageScaling.None;
            btnStopPolling.ImageTransparentColor = Color.Magenta;
            btnStopPolling.Name = "btnStopPolling";
            btnStopPolling.Size = new Size(46, 36);
            btnStopPolling.Text = "Stop Polling";
            tsTranslationExtender.SetTranslationReference(btnStopPolling, "pollingStop");
            btnStopPolling.Click += btnStopPolling_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 42);
            tsTranslationExtender.SetTranslationReference(toolStripSeparator2, "");
            // 
            // btnStartAndEnd
            // 
            btnStartAndEnd.CheckOnClick = true;
            btnStartAndEnd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnStartAndEnd.Image = (Image)resources.GetObject("btnStartAndEnd.Image");
            btnStartAndEnd.ImageTransparentColor = Color.Magenta;
            btnStartAndEnd.Name = "btnStartAndEnd";
            btnStartAndEnd.Size = new Size(46, 36);
            btnStartAndEnd.Text = "Start and End";
            tsTranslationExtender.SetTranslationReference(btnStartAndEnd, "");
            btnStartAndEnd.Click += btnStartAndEnd_Click;
            // 
            // cmDataSet
            // 
            cmDataSet.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmDataSet.BorderColor = Color.Black;
            cmDataSet.DropShadowEnabled = false;
            cmDataSet.ForeColor = Color.White;
            cmDataSet.ImageScalingSize = new Size(32, 32);
            cmDataSet.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmDataSet.MenuBackColorNorth = Color.DodgerBlue;
            cmDataSet.MenuBackColorSouth = Color.DodgerBlue;
            cmDataSet.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmDataSet.Name = "cmDataSet";
            cmDataSet.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmDataSet.ShowCheckMargin = true;
            cmDataSet.ShowInsetShadow = false;
            cmDataSet.ShowItemInsetShadow = false;
            cmDataSet.Size = new Size(83, 4);
            // 
            // cmChannels
            // 
            cmChannels.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmChannels.BorderColor = Color.Black;
            cmChannels.DropShadowEnabled = false;
            cmChannels.ForeColor = Color.White;
            cmChannels.ImageScalingSize = new Size(32, 32);
            cmChannels.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmChannels.MenuBackColorNorth = Color.DodgerBlue;
            cmChannels.MenuBackColorSouth = Color.DodgerBlue;
            cmChannels.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmChannels.Name = "cmDataSet";
            cmChannels.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmChannels.ShowCheckMargin = true;
            cmChannels.ShowInsetShadow = false;
            cmChannels.ShowItemInsetShadow = false;
            cmChannels.Size = new Size(83, 4);
            // 
            // ModbusPollers
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(834, 379);
            Controls.Add(lstPollers);
            Controls.Add(tsMain);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6);
            Name = "ModbusPollers";
            Text = "Modbus Poll Manager";
            FormClosed += ModbusPollers_FormClosed;
            Load += ModbusPollers_Load;
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.ListControl lstPollers;
        private ODModules.ToolStrip tsMain;
        private ToolStripButton btnAddPoller;
        private ToolStripButton btnRemovePoller;
        private ODModules.ContextMenu cmDataSet;
        private ODModules.ContextMenu cmChannels;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton btnStartAndEnd;
        private ODModules.ControlExtensions.ToolStripItemExtender tsTranslationExtender;
        private ToolStripButton btnStartPolling;
        private ToolStripButton btnStopPolling;
        private ToolStripSeparator toolStripSeparator2;
    }
}
