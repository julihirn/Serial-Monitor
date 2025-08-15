namespace Serial_Monitor.WindowForms {
    partial class QuickConvert {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickConvert));
            lstConverter = new ODModules.ListControl();
            msMain = new ODModules.MenuStrip();
            editToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            formatToolStripMenuItem = new ToolStripMenuItem();
            msMain.SuspendLayout();
            SuspendLayout();
            // 
            // lstConverter
            // 
            lstConverter.AllowArrowKeyCellSelect = true;
            lstConverter.AllowColumnSpanning = true;
            lstConverter.AllowMouseWheel = true;
            lstConverter.BorderColor = Color.Gray;
            lstConverter.Borders = ODModules.Borders.None;
            lstConverter.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            lstConverter.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            lstConverter.CellPixelFit = true;
            lstConverter.CellSelectEditableOnly = true;
            lstConverter.CellSelectionBorderColor = Color.Blue;
            lstConverter.ColumnColor = Color.LightGray;
            lstConverter.ColumnForeColor = Color.Black;
            lstConverter.ColumnLineColor = Color.DimGray;
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column1.CountOffset = 0;
            column1.DataFormat = ODModules.ColumnDataFormat.None;
            column1.DisplayType = ODModules.ColumnDisplayType.Text;
            column1.DropDownRight = false;
            column1.DropDownVisible = true;
            column1.Exportable = false;
            column1.ExportName = "";
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column1.Text = "Format";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 100;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column2.CountOffset = 0;
            column2.DataFormat = ODModules.ColumnDataFormat.None;
            column2.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column2.DropDownRight = false;
            column2.DropDownVisible = false;
            column2.Exportable = false;
            column2.ExportName = "";
            column2.FixedWidth = false;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column2.Text = "Value";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 258;
            lstConverter.Columns.Add(column1);
            lstConverter.Columns.Add(column2);
            lstConverter.Dock = DockStyle.Fill;
            lstConverter.DropDownMouseDown = Color.DimGray;
            lstConverter.DropDownMouseOver = Color.LightGray;
            lstConverter.ExternalItems = null;
            lstConverter.Filter = "";
            lstConverter.FilterColumn = 0;
            lstConverter.FilterSearchType = ODModules.ListControl.FilterSearch.Contains;
            lstConverter.GridlineColor = Color.LightGray;
            lstConverter.HighlightStrength = 128;
            lstConverter.HorizontalScrollStep = 3;
            lstConverter.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstConverter.LineMarkerIndex = 0;
            lstConverter.Location = new Point(0, 42);
            lstConverter.MarkerBorderColor = Color.LimeGreen;
            lstConverter.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstConverter.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstConverter.MoveControlOnCellChange = true;
            lstConverter.Name = "lstConverter";
            lstConverter.RowColor = Color.LightGray;
            lstConverter.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstConverter.ScrollBarNorth = Color.DarkTurquoise;
            lstConverter.ScrollBarSouth = Color.DeepSkyBlue;
            lstConverter.ScrollItems = 3;
            lstConverter.SelectedColor = Color.SkyBlue;
            lstConverter.SelectionColor = Color.Gray;
            lstConverter.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstConverter.ShowCellSelection = true;
            lstConverter.ShowGrid = true;
            lstConverter.ShowItemIndentation = false;
            lstConverter.ShowMarker = false;
            lstConverter.ShowRowColors = false;
            lstConverter.Size = new Size(716, 723);
            lstConverter.SpanColumn = 1;
            lstConverter.TabIndex = 1;
            lstConverter.UseLocalList = true;
            lstConverter.VerScroll = 0;
            lstConverter.Zoom = 100;
            lstConverter.DropDownClicked += lstConverter_DropDownClicked;
            lstConverter.SelectionChanged += lstConverter_SelectionChanged;
            lstConverter.CellSelected += lstConverter_CellSelected;
            lstConverter.KeyPress += lstConverter_KeyPress;
            // 
            // msMain
            // 
            msMain.BackColorNorth = Color.DodgerBlue;
            msMain.BackColorNorthFadeIn = Color.DodgerBlue;
            msMain.BackColorSouth = Color.DodgerBlue;
            msMain.Fade = true;
            msMain.ImageScalingSize = new Size(32, 32);
            msMain.ItemForeColor = Color.Black;
            msMain.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem, formatToolStripMenuItem });
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
            msMain.Size = new Size(716, 42);
            msMain.StripItemSelectedBackColorNorth = Color.White;
            msMain.StripItemSelectedBackColorSouth = Color.White;
            msMain.TabIndex = 2;
            msMain.Text = "menuStrip1";
            msMain.UseNorthFadeIn = false;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyToolStripMenuItem, pasteToolStripMenuItem });
            editToolStripMenuItem.ForeColor = Color.Black;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(74, 38);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ForeColor = Color.Black;
            copyToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(359, 44);
            copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ForeColor = Color.Black;
            pasteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(359, 44);
            pasteToolStripMenuItem.Text = "&Paste";
            // 
            // formatToolStripMenuItem
            // 
            formatToolStripMenuItem.ForeColor = Color.Black;
            formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            formatToolStripMenuItem.Size = new Size(109, 38);
            formatToolStripMenuItem.Text = "&Format";
            // 
            // QuickConvert
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(716, 765);
            Controls.Add(lstConverter);
            Controls.Add(msMain);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(0, 0);
            MainMenuStrip = msMain;
            Name = "QuickConvert";
            Text = "Quick Convert";
            Load += QuickConvert_Load;
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ODModules.ListControl lstConverter;
        private ODModules.MenuStrip msMain;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem formatToolStripMenuItem;
    }
}