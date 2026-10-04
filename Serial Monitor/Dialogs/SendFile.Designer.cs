namespace Serial_Monitor.Dialogs {
    partial class SendFile {
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
            ODModules.Column column5 = new ODModules.Column();
            ODModules.Column column6 = new ODModules.Column();
            ODModules.Column column7 = new ODModules.Column();
            ODModules.Column column8 = new ODModules.Column();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendFile));
            lblpnlSource = new ODModules.LabelPanel();
            labelPanel1 = new ODModules.LabelPanel();
            lstData = new ODModules.ListControl();
            tsSource = new ODModules.ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            openTextFileToolStripMenuItem = new ToolStripMenuItem();
            openBinaryToolStripMenuItem = new ToolStripMenuItem();
            lblpnlSource.SuspendLayout();
            tsSource.SuspendLayout();
            SuspendLayout();
            // 
            // lblpnlSource
            // 
            lblpnlSource.ArrowColor = Color.LightGray;
            lblpnlSource.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlSource.CloseColor = Color.Black;
            lblpnlSource.CloseMouseOverColor = Color.Red;
            lblpnlSource.Collapsed = false;
            lblpnlSource.Controls.Add(lstData);
            lblpnlSource.Controls.Add(tsSource);
            lblpnlSource.Dock = DockStyle.Top;
            lblpnlSource.DropShadow = false;
            lblpnlSource.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlSource.FixedInlineWidth = false;
            lblpnlSource.ForeColor = Color.White;
            lblpnlSource.Inlinelabel = false;
            lblpnlSource.InlineWidth = 100;
            lblpnlSource.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlSource.LabelFont = new Font("Segoe UI", 8F);
            lblpnlSource.LabelForeColor = Color.WhiteSmoke;
            lblpnlSource.Location = new Point(19, 21);
            lblpnlSource.Margin = new Padding(6);
            lblpnlSource.Name = "lblpnlSource";
            lblpnlSource.OverrideCollapseControl = false;
            lblpnlSource.Padding = new Padding(9, 41, 9, 11);
            lblpnlSource.PanelCollapsible = false;
            lblpnlSource.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlSource.SeparatorColor = Color.Gray;
            lblpnlSource.ShowCloseButton = false;
            lblpnlSource.ShowSeparator = false;
            lblpnlSource.Size = new Size(636, 355);
            lblpnlSource.TabIndex = 3;
            lblpnlSource.Text = "Source";
            // 
            // labelPanel1
            // 
            labelPanel1.ArrowColor = Color.LightGray;
            labelPanel1.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel1.CloseColor = Color.Black;
            labelPanel1.CloseMouseOverColor = Color.Red;
            labelPanel1.Collapsed = false;
            labelPanel1.Dock = DockStyle.Top;
            labelPanel1.DropShadow = false;
            labelPanel1.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel1.FixedInlineWidth = false;
            labelPanel1.ForeColor = Color.White;
            labelPanel1.Inlinelabel = false;
            labelPanel1.InlineWidth = 100;
            labelPanel1.LabelBackColor = Color.FromArgb(16, 16, 16);
            labelPanel1.LabelFont = new Font("Segoe UI", 8F);
            labelPanel1.LabelForeColor = Color.WhiteSmoke;
            labelPanel1.Location = new Point(19, 376);
            labelPanel1.Margin = new Padding(6);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = false;
            labelPanel1.Padding = new Padding(9, 41, 9, 11);
            labelPanel1.PanelCollapsible = false;
            labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel1.SeparatorColor = Color.Gray;
            labelPanel1.ShowCloseButton = false;
            labelPanel1.ShowSeparator = false;
            labelPanel1.Size = new Size(636, 232);
            labelPanel1.TabIndex = 4;
            labelPanel1.Text = "Control Flow";
            // 
            // lstData
            // 
            lstData.AllowArrowKeyCellSelect = false;
            lstData.AllowColumnSpanning = false;
            lstData.AllowMouseWheel = true;
            lstData.BorderColor = Color.Gray;
            lstData.Borders = ODModules.Borders.None;
            lstData.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            lstData.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            lstData.CellPixelFit = true;
            lstData.CellSelectEditableOnly = true;
            lstData.CellSelectionBorderColor = Color.Blue;
            lstData.ColumnColor = Color.LightGray;
            lstData.ColumnForeColor = Color.Black;
            lstData.ColumnLineColor = Color.DimGray;
            column5.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column5.CountOffset = 0;
            column5.DataFormat = ODModules.ColumnDataFormat.None;
            column5.DisplayType = ODModules.ColumnDisplayType.LineCount;
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
            column5.Width = 50;
            column6.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column6.CountOffset = 0;
            column6.DataFormat = ODModules.ColumnDataFormat.None;
            column6.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column6.DropDownRight = false;
            column6.DropDownVisible = true;
            column6.Exportable = false;
            column6.ExportName = "";
            column6.FixedWidth = true;
            column6.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column6.Text = "";
            column6.UseItemBackColor = false;
            column6.UseItemForeColor = false;
            column6.Visible = true;
            column6.Width = 30;
            column7.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column7.CountOffset = 0;
            column7.DataFormat = ODModules.ColumnDataFormat.None;
            column7.DisplayType = ODModules.ColumnDisplayType.Text;
            column7.DropDownRight = false;
            column7.DropDownVisible = true;
            column7.Exportable = false;
            column7.ExportName = "";
            column7.FixedWidth = false;
            column7.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column7.Text = "Status";
            column7.UseItemBackColor = false;
            column7.UseItemForeColor = false;
            column7.Visible = true;
            column7.Width = 70;
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
            column8.Text = "Data";
            column8.UseItemBackColor = false;
            column8.UseItemForeColor = false;
            column8.Visible = true;
            column8.Width = 120;
            lstData.Columns.Add(column5);
            lstData.Columns.Add(column6);
            lstData.Columns.Add(column7);
            lstData.Columns.Add(column8);
            lstData.Dock = DockStyle.Fill;
            lstData.DropDownMouseDown = Color.DimGray;
            lstData.DropDownMouseOver = Color.LightGray;
            lstData.ExternalItems = null;
            lstData.Filter = "";
            lstData.FilterColumn = 0;
            lstData.FilterSearchType = ODModules.ListControl.FilterSearch.Contains;
            lstData.GridlineColor = Color.LightGray;
            lstData.HighlightStrength = 128;
            lstData.HorizontalScrollStep = 3;
            lstData.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstData.LineMarkerIndex = 0;
            lstData.Location = new Point(9, 83);
            lstData.MarkerBorderColor = Color.LimeGreen;
            lstData.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstData.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstData.MoveControlOnCellChange = true;
            lstData.Name = "lstData";
            lstData.RowColor = Color.LightGray;
            lstData.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstData.ScrollBarNorth = Color.DarkTurquoise;
            lstData.ScrollBarSouth = Color.DeepSkyBlue;
            lstData.ScrollItems = 3;
            lstData.SelectedColor = Color.SkyBlue;
            lstData.SelectionColor = Color.Gray;
            lstData.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstData.ShowCellSelection = false;
            lstData.ShowGrid = false;
            lstData.ShowHeader = true;
            lstData.ShowItemIndentation = false;
            lstData.ShowMarker = false;
            lstData.ShowRowColors = false;
            lstData.Size = new Size(618, 261);
            lstData.SpanColumn = 0;
            lstData.TabIndex = 0;
            lstData.UseLocalList = true;
            lstData.VerScroll = 0;
            lstData.Zoom = 100;
            // 
            // tsSource
            // 
            tsSource.BackColorNorth = Color.DodgerBlue;
            tsSource.BackColorSouth = Color.DodgerBlue;
            tsSource.BorderColor = Color.WhiteSmoke;
            tsSource.GripColor = Color.WhiteSmoke;
            tsSource.ImageScalingSize = new Size(32, 32);
            tsSource.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            tsSource.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            tsSource.ItemForeColor = Color.Black;
            tsSource.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1 });
            tsSource.ItemSelectedBackColorNorth = Color.White;
            tsSource.ItemSelectedBackColorSouth = Color.White;
            tsSource.ItemSelectedForeColor = Color.Black;
            tsSource.Location = new Point(9, 41);
            tsSource.MenuBackColorNorth = Color.DodgerBlue;
            tsSource.MenuBackColorSouth = Color.DodgerBlue;
            tsSource.MenuBorderColor = Color.WhiteSmoke;
            tsSource.MenuSeparatorColor = Color.WhiteSmoke;
            tsSource.MenuSymbolColor = Color.WhiteSmoke;
            tsSource.Name = "tsSource";
            tsSource.RoundedToolStrip = false;
            tsSource.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            tsSource.ShowBorder = false;
            tsSource.ShowShadow = false;
            tsSource.Size = new Size(618, 42);
            tsSource.StripItemSelectedBackColorNorth = Color.White;
            tsSource.StripItemSelectedBackColorSouth = Color.White;
            tsSource.TabIndex = 1;
            tsSource.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { openTextFileToolStripMenuItem, openBinaryToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageScaling = ToolStripItemImageScaling.None;
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(54, 36);
            toolStripDropDownButton1.Text = "Open";
            // 
            // openTextFileToolStripMenuItem
            // 
            openTextFileToolStripMenuItem.ForeColor = Color.Black;
            openTextFileToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            openTextFileToolStripMenuItem.Name = "openTextFileToolStripMenuItem";
            openTextFileToolStripMenuItem.Size = new Size(359, 44);
            openTextFileToolStripMenuItem.Text = "Open Text File";
            // 
            // openBinaryToolStripMenuItem
            // 
            openBinaryToolStripMenuItem.ForeColor = Color.Black;
            openBinaryToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            openBinaryToolStripMenuItem.Name = "openBinaryToolStripMenuItem";
            openBinaryToolStripMenuItem.Size = new Size(359, 44);
            openBinaryToolStripMenuItem.Text = "Open Binary";
            // 
            // SendFile
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(674, 779);
            Controls.Add(labelPanel1);
            Controls.Add(lblpnlSource);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SendFile";
            Padding = new Padding(19, 21, 19, 21);
            Text = "Send File";
            Load += SendFile_Load;
            lblpnlSource.ResumeLayout(false);
            lblpnlSource.PerformLayout();
            tsSource.ResumeLayout(false);
            tsSource.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ODModules.LabelPanel lblpnlSource;
        private ODModules.LabelPanel labelPanel1;
        private ODModules.ListControl lstData;
        private ODModules.ToolStrip tsSource;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem openTextFileToolStripMenuItem;
        private ToolStripMenuItem openBinaryToolStripMenuItem;
    }
}