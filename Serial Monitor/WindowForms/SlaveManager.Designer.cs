namespace Serial_Monitor.WindowForms {
    partial class SlaveManager {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlaveManager));
            msMain = new ODModules.MenuStrip();
            editToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            lstChannels = new ODModules.ListControl();
            msMain.SuspendLayout();
            SuspendLayout();
            // 
            // msMain
            // 
            msMain.BackColorNorth = Color.DodgerBlue;
            msMain.BackColorNorthFadeIn = Color.DodgerBlue;
            msMain.BackColorSouth = Color.DodgerBlue;
            msMain.Fade = true;
            msMain.ImageScalingSize = new Size(32, 32);
            msMain.ItemForeColor = Color.Black;
            msMain.Items.AddRange(new ToolStripItem[] { editToolStripMenuItem });
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
            msMain.Size = new Size(675, 42);
            msMain.StripItemSelectedBackColorNorth = Color.White;
            msMain.StripItemSelectedBackColorSouth = Color.White;
            msMain.TabIndex = 0;
            msMain.Text = "menuStrip1";
            msMain.UseNorthFadeIn = false;
            msMain.ItemClicked += menuStrip1_ItemClicked;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem });
            editToolStripMenuItem.ForeColor = Color.Black;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(74, 38);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.ForeColor = Color.Black;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(217, 44);
            cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ForeColor = Color.Black;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(217, 44);
            copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ForeColor = Color.Black;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(217, 44);
            pasteToolStripMenuItem.Text = "&Paste";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.ForeColor = Color.Black;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(217, 44);
            deleteToolStripMenuItem.Text = "&Delete";
            // 
            // lstChannels
            // 
            lstChannels.AllowArrowKeyCellSelect = false;
            lstChannels.AllowColumnSpanning = false;
            lstChannels.AllowMouseWheel = true;
            lstChannels.BorderColor = Color.Gray;
            lstChannels.Borders = ODModules.Borders.None;
            lstChannels.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            lstChannels.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            lstChannels.CellPixelFit = true;
            lstChannels.CellSelectEditableOnly = true;
            lstChannels.CellSelectionBorderColor = Color.Blue;
            lstChannels.ColumnColor = Color.LightGray;
            lstChannels.ColumnForeColor = Color.Black;
            lstChannels.ColumnLineColor = Color.DimGray;
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
            column1.Text = "Channel";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 100;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DataFormat = ODModules.ColumnDataFormat.None;
            column2.DisplayType = ODModules.ColumnDisplayType.Text;
            column2.DropDownRight = false;
            column2.DropDownVisible = true;
            column2.Exportable = false;
            column2.ExportName = "";
            column2.FixedWidth = false;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column2.Text = "Type";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 80;
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column3.CountOffset = 0;
            column3.DataFormat = ODModules.ColumnDataFormat.None;
            column3.DisplayType = ODModules.ColumnDisplayType.Text;
            column3.DropDownRight = false;
            column3.DropDownVisible = true;
            column3.Exportable = false;
            column3.ExportName = "";
            column3.FixedWidth = false;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column3.Text = "Unit";
            column3.UseItemBackColor = false;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 50;
            column4.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column4.CountOffset = 0;
            column4.DataFormat = ODModules.ColumnDataFormat.None;
            column4.DisplayType = ODModules.ColumnDisplayType.Text;
            column4.DropDownRight = false;
            column4.DropDownVisible = true;
            column4.Exportable = false;
            column4.ExportName = "";
            column4.FixedWidth = false;
            column4.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column4.Text = "Name";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 150;
            lstChannels.Columns.Add(column1);
            lstChannels.Columns.Add(column2);
            lstChannels.Columns.Add(column3);
            lstChannels.Columns.Add(column4);
            lstChannels.Dock = DockStyle.Fill;
            lstChannels.DropDownMouseDown = Color.DimGray;
            lstChannels.DropDownMouseOver = Color.LightGray;
            lstChannels.ExternalItems = null;
            lstChannels.Filter = "";
            lstChannels.FilterColumn = 0;
            lstChannels.FilterSearchType = ODModules.ListControl.FilterSearch.Contains;
            lstChannels.GridlineColor = Color.LightGray;
            lstChannels.HighlightStrength = 128;
            lstChannels.HorizontalScrollStep = 3;
            lstChannels.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstChannels.LineMarkerIndex = 0;
            lstChannels.Location = new Point(0, 42);
            lstChannels.MarkerBorderColor = Color.LimeGreen;
            lstChannels.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstChannels.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstChannels.MoveControlOnCellChange = true;
            lstChannels.Name = "lstChannels";
            lstChannels.RowColor = Color.LightGray;
            lstChannels.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstChannels.ScrollBarNorth = Color.DarkTurquoise;
            lstChannels.ScrollBarSouth = Color.DeepSkyBlue;
            lstChannels.ScrollItems = 3;
            lstChannels.SelectedColor = Color.SkyBlue;
            lstChannels.SelectionColor = Color.Gray;
            lstChannels.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstChannels.ShowCellSelection = false;
            lstChannels.ShowGrid = false;
            lstChannels.ShowItemIndentation = false;
            lstChannels.ShowMarker = false;
            lstChannels.ShowRowColors = false;
            lstChannels.Size = new Size(675, 586);
            lstChannels.SpanColumn = 0;
            lstChannels.TabIndex = 1;
            lstChannels.UseLocalList = true;
            lstChannels.VerScroll = 0;
            lstChannels.Zoom = 100;
            // 
            // SlaveManager
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(675, 628);
            Controls.Add(lstChannels);
            Controls.Add(msMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msMain;
            Name = "SlaveManager";
            Text = "Slave Manager";
            Load += SlaveManager_Load;
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.MenuStrip msMain;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ODModules.ListControl lstChannels;
    }
}