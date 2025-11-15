namespace Serial_Monitor.Components {
    partial class StepCommandPopup {
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
            sltbSearch = new ODModules.SingleLineTextBox();
            lstCommands = new ODModules.ListControl();
            SuspendLayout();
            // 
            // sltbSearch
            // 
            sltbSearch.AllowShortcuts = true;
            sltbSearch.BorderColor = Color.MediumSlateBlue;
            sltbSearch.BorderSize = 1;
            sltbSearch.CaretColor = Color.Black;
            sltbSearch.Dock = DockStyle.Top;
            sltbSearch.FocusLostClearSelection = true;
            sltbSearch.Location = new Point(0, 0);
            sltbSearch.MaskArrowKeyEvents = true;
            sltbSearch.MaxLength = 65535;
            sltbSearch.Name = "sltbSearch";
            sltbSearch.Padding = new Padding(6, 0, 0, 0);
            sltbSearch.PlaceholderForeColor = Color.DimGray;
            sltbSearch.PlaceHolderText = "Search for a Command";
            sltbSearch.SelectedBackColor = Color.LightGray;
            sltbSearch.SelectedBorderColor = Color.HotPink;
            sltbSearch.SelectionColor = Color.LightBlue;
            sltbSearch.Size = new Size(347, 42);
            sltbSearch.TabIndex = 0;
            sltbSearch.TextAlign = HorizontalAlignment.Left;
            sltbSearch.TextChanged += sltbSearch_TextChanged;
            sltbSearch.KeyPress += sltbSearch_KeyPress;
            // 
            // lstCommands
            // 
            lstCommands.AllowArrowKeyCellSelect = true;
            lstCommands.AllowColumnSpanning = true;
            lstCommands.AllowMouseWheel = true;
            lstCommands.BorderColor = Color.Gray;
            lstCommands.Borders = ODModules.Borders.None;
            lstCommands.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            lstCommands.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            lstCommands.CellPixelFit = true;
            lstCommands.CellSelectEditableOnly = true;
            lstCommands.CellSelectionBorderColor = Color.Blue;
            lstCommands.ColumnColor = Color.LightGray;
            lstCommands.ColumnForeColor = Color.Black;
            lstCommands.ColumnLineColor = Color.DimGray;
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column1.CountOffset = 0;
            column1.DataFormat = ODModules.ColumnDataFormat.None;
            column1.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column1.DropDownRight = false;
            column1.DropDownVisible = false;
            column1.Exportable = false;
            column1.ExportName = "";
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column1.Text = "Commands";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 173;
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
            column2.Text = "Column";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = false;
            column2.Width = 50;
            lstCommands.Columns.Add(column1);
            lstCommands.Columns.Add(column2);
            lstCommands.Dock = DockStyle.Fill;
            lstCommands.DropDownMouseDown = Color.DimGray;
            lstCommands.DropDownMouseOver = Color.LightGray;
            lstCommands.ExternalItems = null;
            lstCommands.Filter = "";
            lstCommands.FilterColumn = 0;
            lstCommands.FilterSearchType = ODModules.ListControl.FilterSearch.Contains;
            lstCommands.GridlineColor = Color.LightGray;
            lstCommands.HighlightStrength = 128;
            lstCommands.HorizontalScrollStep = 3;
            lstCommands.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstCommands.LineMarkerIndex = 0;
            lstCommands.Location = new Point(0, 42);
            lstCommands.MarkerBorderColor = Color.LimeGreen;
            lstCommands.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstCommands.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstCommands.MoveControlOnCellChange = true;
            lstCommands.Name = "lstCommands";
            lstCommands.RowColor = Color.LightGray;
            lstCommands.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstCommands.ScrollBarNorth = Color.DarkTurquoise;
            lstCommands.ScrollBarSouth = Color.DeepSkyBlue;
            lstCommands.ScrollItems = 3;
            lstCommands.SelectedColor = Color.SkyBlue;
            lstCommands.SelectionColor = Color.Gray;
            lstCommands.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstCommands.ShowCellSelection = false;
            lstCommands.ShowGrid = false;
            lstCommands.ShowHeader = false;
            lstCommands.ShowItemIndentation = false;
            lstCommands.ShowMarker = false;
            lstCommands.ShowRowColors = false;
            lstCommands.Size = new Size(347, 358);
            lstCommands.SpanColumn = 0;
            lstCommands.TabIndex = 1;
            lstCommands.UseLocalList = true;
            lstCommands.VerScroll = 0;
            lstCommands.Zoom = 100;
            lstCommands.DropDownClicked += lstCommands_DropDownClicked;
            lstCommands.Load += lstCommands_Load;
            lstCommands.KeyDown += lstCommands_KeyDown;
            lstCommands.KeyPress += lstCommands_KeyPress;
            // 
            // StepCommandPopup
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lstCommands);
            Controls.Add(sltbSearch);
            Name = "StepCommandPopup";
            Size = new Size(347, 400);
            Load += StepCommandPopup_Load;
            ResumeLayout(false);
        }

        #endregion
        private ODModules.ListControl lstCommands;
        public ODModules.SingleLineTextBox sltbSearch;
    }
}
