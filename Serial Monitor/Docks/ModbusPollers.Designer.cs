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
            listControl1 = new ODModules.ListControl();
            SuspendLayout();
            // 
            // listControl1
            // 
            listControl1.AllowArrowKeyCellSelect = false;
            listControl1.AllowColumnSpanning = false;
            listControl1.AllowMouseWheel = true;
            listControl1.BorderColor = Color.Gray;
            listControl1.Borders = ODModules.Borders.None;
            listControl1.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            listControl1.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            listControl1.CellPixelFit = true;
            listControl1.CellSelectEditableOnly = true;
            listControl1.CellSelectionBorderColor = Color.Blue;
            listControl1.ColumnColor = Color.LightGray;
            listControl1.ColumnForeColor = Color.Black;
            listControl1.ColumnLineColor = Color.DimGray;
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column1.CountOffset = 0;
            column1.DataFormat = ODModules.ColumnDataFormat.None;
            column1.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column1.DropDownRight = false;
            column1.DropDownVisible = true;
            column1.Exportable = false;
            column1.ExportName = "";
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column1.Text = "";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 50;
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
            column2.Text = "Frequency";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 50;
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
            column3.Text = "Channel";
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
            column4.Text = "Unit";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 50;
            column5.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column5.CountOffset = 0;
            column5.DataFormat = ODModules.ColumnDataFormat.None;
            column5.DisplayType = ODModules.ColumnDisplayType.Text;
            column5.DropDownRight = false;
            column5.DropDownVisible = true;
            column5.Exportable = false;
            column5.ExportName = "";
            column5.FixedWidth = false;
            column5.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column5.Text = "Add";
            column5.UseItemBackColor = false;
            column5.UseItemForeColor = false;
            column5.Visible = true;
            column5.Width = 50;
            listControl1.Columns.Add(column1);
            listControl1.Columns.Add(column2);
            listControl1.Columns.Add(column3);
            listControl1.Columns.Add(column4);
            listControl1.Columns.Add(column5);
            listControl1.DropDownMouseDown = Color.DimGray;
            listControl1.DropDownMouseOver = Color.LightGray;
            listControl1.ExternalItems = null;
            listControl1.Filter = "";
            listControl1.FilterColumn = 0;
            listControl1.FilterSearchType = ODModules.ListControl.FilterSearch.Contains;
            listControl1.GridlineColor = Color.LightGray;
            listControl1.HighlightStrength = 128;
            listControl1.HorizontalScrollStep = 3;
            listControl1.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            listControl1.LineMarkerIndex = 0;
            listControl1.Location = new Point(49, 176);
            listControl1.MarkerBorderColor = Color.LimeGreen;
            listControl1.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            listControl1.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            listControl1.MoveControlOnCellChange = true;
            listControl1.Name = "listControl1";
            listControl1.RowColor = Color.LightGray;
            listControl1.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            listControl1.ScrollBarNorth = Color.DarkTurquoise;
            listControl1.ScrollBarSouth = Color.DeepSkyBlue;
            listControl1.ScrollItems = 3;
            listControl1.SelectedColor = Color.SkyBlue;
            listControl1.SelectionColor = Color.Gray;
            listControl1.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            listControl1.ShowCellSelection = false;
            listControl1.ShowGrid = false;
            listControl1.ShowItemIndentation = false;
            listControl1.ShowMarker = false;
            listControl1.ShowRowColors = false;
            listControl1.Size = new Size(287, 363);
            listControl1.SpanColumn = 0;
            listControl1.TabIndex = 0;
            listControl1.UseLocalList = true;
            listControl1.VerScroll = 0;
            listControl1.Zoom = 100;
            // 
            // ModbusPollers
            // 
            ActiveTitleBackColor = Color.White;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            Controls.Add(listControl1);
            DefaultDockArea = ODModules.Docking.DockArea.Right;
            DockText = "Modbus Pollers";
            ForeColor = Color.White;
            InactiveTitleBackColor = Color.FromArgb(16, 16, 16);
            InactiveTitleForeColor = Color.Gainsboro;
            Margin = new Padding(6, 6, 6, 6);
            Name = "ModbusPollers";
            SerializationKey = "ModbusPollers";
            Size = new Size(453, 646);
            Load += ModbusPollers_Load;
            ResumeLayout(false);
        }

        #endregion

        private ODModules.ListControl listControl1;
    }
}
