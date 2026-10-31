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
            ODModules.Column column9 = new ODModules.Column();
            ODModules.Column column10 = new ODModules.Column();
            ODModules.Column column11 = new ODModules.Column();
            ODModules.Column column12 = new ODModules.Column();
            ODModules.Column column13 = new ODModules.Column();
            ODModules.Column column14 = new ODModules.Column();
            ODModules.Column column15 = new ODModules.Column();
            ODModules.Column column16 = new ODModules.Column();
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
            btnCreateQuery = new ToolStripButton();
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
            column9.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column9.CountOffset = 0;
            column9.DataFormat = ODModules.ColumnDataFormat.None;
            column9.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column9.DropDownRight = false;
            column9.DropDownVisible = true;
            column9.Exportable = false;
            column9.ExportName = "";
            column9.FixedWidth = false;
            column9.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column9.Text = "";
            column9.UseItemBackColor = false;
            column9.UseItemForeColor = false;
            column9.Visible = true;
            column9.Width = 30;
            column10.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column10.CountOffset = 0;
            column10.DataFormat = ODModules.ColumnDataFormat.None;
            column10.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column10.DropDownRight = false;
            column10.DropDownVisible = false;
            column10.Exportable = false;
            column10.ExportName = "";
            column10.FixedWidth = false;
            column10.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column10.Text = "Frequency";
            column10.UseItemBackColor = false;
            column10.UseItemForeColor = false;
            column10.Visible = true;
            column10.Width = 80;
            column11.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column11.CountOffset = 0;
            column11.DataFormat = ODModules.ColumnDataFormat.None;
            column11.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column11.DropDownRight = false;
            column11.DropDownVisible = true;
            column11.Exportable = false;
            column11.ExportName = "";
            column11.FixedWidth = false;
            column11.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column11.Text = "Channel";
            column11.UseItemBackColor = false;
            column11.UseItemForeColor = false;
            column11.Visible = true;
            column11.Width = 100;
            column12.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column12.CountOffset = 0;
            column12.DataFormat = ODModules.ColumnDataFormat.None;
            column12.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column12.DropDownRight = false;
            column12.DropDownVisible = false;
            column12.Exportable = false;
            column12.ExportName = "";
            column12.FixedWidth = false;
            column12.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column12.Text = "Unit";
            column12.UseItemBackColor = false;
            column12.UseItemForeColor = false;
            column12.Visible = true;
            column12.Width = 50;
            column13.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column13.CountOffset = 0;
            column13.DataFormat = ODModules.ColumnDataFormat.None;
            column13.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column13.DropDownRight = false;
            column13.DropDownVisible = true;
            column13.Exportable = false;
            column13.ExportName = "";
            column13.FixedWidth = false;
            column13.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column13.Text = "Read";
            column13.UseItemBackColor = false;
            column13.UseItemForeColor = false;
            column13.Visible = true;
            column13.Width = 90;
            column14.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column14.CountOffset = 0;
            column14.DataFormat = ODModules.ColumnDataFormat.None;
            column14.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column14.DropDownRight = false;
            column14.DropDownVisible = false;
            column14.Exportable = false;
            column14.ExportName = "";
            column14.FixedWidth = false;
            column14.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column14.Text = "Address";
            column14.UseItemBackColor = false;
            column14.UseItemForeColor = false;
            column14.Visible = true;
            column14.Width = 50;
            column15.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column15.CountOffset = 0;
            column15.DataFormat = ODModules.ColumnDataFormat.None;
            column15.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column15.DropDownRight = false;
            column15.DropDownVisible = false;
            column15.Exportable = false;
            column15.ExportName = "";
            column15.FixedWidth = false;
            column15.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column15.Text = "Count";
            column15.UseItemBackColor = false;
            column15.UseItemForeColor = false;
            column15.Visible = true;
            column15.Width = 50;
            column16.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column16.CountOffset = 0;
            column16.DataFormat = ODModules.ColumnDataFormat.None;
            column16.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column16.DropDownRight = false;
            column16.DropDownVisible = false;
            column16.Exportable = false;
            column16.ExportName = "";
            column16.FixedWidth = false;
            column16.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column16.Text = "End";
            column16.UseItemBackColor = false;
            column16.UseItemForeColor = false;
            column16.Visible = false;
            column16.Width = 50;
            lstPollers.Columns.Add(column9);
            lstPollers.Columns.Add(column10);
            lstPollers.Columns.Add(column11);
            lstPollers.Columns.Add(column12);
            lstPollers.Columns.Add(column13);
            lstPollers.Columns.Add(column14);
            lstPollers.Columns.Add(column15);
            lstPollers.Columns.Add(column16);
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
            tsMain.Items.AddRange(new ToolStripItem[] { btnAddPoller, btnRemovePoller, toolStripSeparator1, btnStartPolling, btnStopPolling, toolStripSeparator2, btnStartAndEnd, btnCreateQuery });
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
            // btnCreateQuery
            // 
            btnCreateQuery.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCreateQuery.Enabled = false;
            btnCreateQuery.Image = (Image)resources.GetObject("btnCreateQuery.Image");
            btnCreateQuery.ImageScaling = ToolStripItemImageScaling.None;
            btnCreateQuery.ImageTransparentColor = Color.Magenta;
            btnCreateQuery.Name = "btnCreateQuery";
            btnCreateQuery.Size = new Size(46, 36);
            btnCreateQuery.Text = "Show Query";
            tsTranslationExtender.SetTranslationReference(btnCreateQuery, "showQuery");
            btnCreateQuery.Click += btnCreateQuery_Click;
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
        private ToolStripButton btnCreateQuery;
    }
}
