namespace Serial_Monitor.ToolWindows {
    partial class ModbusRegister {
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
            ODModules.Column column5 = new ODModules.Column();
            ODModules.Column column6 = new ODModules.Column();
            ODModules.Column column7 = new ODModules.Column();
            lstRegisters = new ODModules.ListControl();
            cmDisplayFormats = new ODModules.ContextMenu();
            cmDataSize = new ODModules.ContextMenu();
            cmCoilFormats = new ODModules.ContextMenu();
            SuspendLayout();
            // 
            // lstRegisters
            // 
            lstRegisters.AllowColumnSpanning = false;
            lstRegisters.AllowMouseWheel = true;
            lstRegisters.BorderColor = Color.Gray;
            lstRegisters.Borders = ODModules.Borders.None;
            lstRegisters.ColumnColor = Color.LightGray;
            lstRegisters.ColumnForeColor = Color.Black;
            lstRegisters.ColumnLineColor = Color.DimGray;
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column1.CountOffset = 0;
            column1.DataFormat = ODModules.ColumnDataFormat.Integer;
            column1.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column1.DropDownRight = false;
            column1.DropDownVisible = true;
            column1.Exportable = true;
            column1.ExportName = "address";
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column1.Text = "";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 50;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DataFormat = ODModules.ColumnDataFormat.None;
            column2.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column2.DropDownRight = false;
            column2.DropDownVisible = false;
            column2.Exportable = true;
            column2.ExportName = "";
            column2.FixedWidth = false;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column2.Text = "Name";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 100;
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column3.CountOffset = 0;
            column3.DataFormat = ODModules.ColumnDataFormat.None;
            column3.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column3.DropDownRight = false;
            column3.DropDownVisible = true;
            column3.Exportable = true;
            column3.ExportName = "";
            column3.FixedWidth = false;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column3.Text = "Display";
            column3.UseItemBackColor = false;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 80;
            column4.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column4.CountOffset = 0;
            column4.DataFormat = ODModules.ColumnDataFormat.Integer;
            column4.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column4.DropDownRight = false;
            column4.DropDownVisible = true;
            column4.Exportable = false;
            column4.ExportName = "";
            column4.FixedWidth = true;
            column4.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column4.Text = "Size";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 75;
            column5.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column5.CountOffset = 0;
            column5.DataFormat = ODModules.ColumnDataFormat.Boolean;
            column5.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column5.DropDownRight = false;
            column5.DropDownVisible = true;
            column5.Exportable = false;
            column5.ExportName = "";
            column5.FixedWidth = true;
            column5.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column5.Text = "Signed";
            column5.UseItemBackColor = false;
            column5.UseItemForeColor = false;
            column5.Visible = true;
            column5.Width = 50;
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
            column6.Text = "Value";
            column6.UseItemBackColor = false;
            column6.UseItemForeColor = false;
            column6.Visible = true;
            column6.Width = 120;
            column7.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column7.CountOffset = 0;
            column7.DataFormat = ODModules.ColumnDataFormat.Text;
            column7.DisplayType = ODModules.ColumnDisplayType.Text;
            column7.DropDownRight = false;
            column7.DropDownVisible = true;
            column7.Exportable = true;
            column7.ExportName = "";
            column7.FixedWidth = false;
            column7.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column7.Text = "Last Updated";
            column7.UseItemBackColor = false;
            column7.UseItemForeColor = false;
            column7.Visible = false;
            column7.Width = 80;
            lstRegisters.Columns.Add(column1);
            lstRegisters.Columns.Add(column2);
            lstRegisters.Columns.Add(column3);
            lstRegisters.Columns.Add(column4);
            lstRegisters.Columns.Add(column5);
            lstRegisters.Columns.Add(column6);
            lstRegisters.Columns.Add(column7);
            lstRegisters.Dock = DockStyle.Fill;
            lstRegisters.DropDownMouseDown = Color.DimGray;
            lstRegisters.DropDownMouseOver = Color.LightGray;
            lstRegisters.ExternalItems = null;
            lstRegisters.Filter = null;
            lstRegisters.FilterColumn = 0;
            lstRegisters.GridlineColor = Color.LightGray;
            lstRegisters.HighlightStrength = 128;
            lstRegisters.HorizontalScrollStep = 3;
            lstRegisters.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstRegisters.LineMarkerIndex = 0;
            lstRegisters.Location = new Point(5, 18);
            lstRegisters.MarkerBorderColor = Color.LimeGreen;
            lstRegisters.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstRegisters.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstRegisters.Name = "lstRegisters";
            lstRegisters.RowColor = Color.LightGray;
            lstRegisters.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstRegisters.ScrollBarNorth = Color.DarkTurquoise;
            lstRegisters.ScrollBarSouth = Color.DeepSkyBlue;
            lstRegisters.ScrollItems = 3;
            lstRegisters.SelectedColor = Color.SkyBlue;
            lstRegisters.SelectionColor = Color.Gray;
            lstRegisters.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstRegisters.ShowGrid = true;
            lstRegisters.ShowItemIndentation = false;
            lstRegisters.ShowMarker = false;
            lstRegisters.ShowRowColors = true;
            lstRegisters.Size = new Size(310, 227);
            lstRegisters.SpanColumn = 0;
            lstRegisters.TabIndex = 0;
            lstRegisters.UseLocalList = false;
            lstRegisters.VerScroll = 0;
            lstRegisters.Zoom = 100;
            lstRegisters.DropDownClicked += lstRegisters_DropDownClicked;
            lstRegisters.ItemCheckedChanged += lstRegisters_ItemCheckedChanged;
            lstRegisters.ItemClicked += lstRegisters_ItemClicked;
            lstRegisters.SelectionChanged += lstRegisters_SelectionChanged;
            // 
            // cmDisplayFormats
            // 
            cmDisplayFormats.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmDisplayFormats.BorderColor = Color.Black;
            cmDisplayFormats.DropShadowEnabled = false;
            cmDisplayFormats.ForeColor = Color.White;
            cmDisplayFormats.ImageScalingSize = new Size(32, 32);
            cmDisplayFormats.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmDisplayFormats.MenuBackColorNorth = Color.DodgerBlue;
            cmDisplayFormats.MenuBackColorSouth = Color.DodgerBlue;
            cmDisplayFormats.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmDisplayFormats.Name = "cmDisplayFormats";
            cmDisplayFormats.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmDisplayFormats.ShowInsetShadow = false;
            cmDisplayFormats.ShowItemInsetShadow = false;
            cmDisplayFormats.Size = new Size(61, 4);
            // 
            // cmDataSize
            // 
            cmDataSize.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmDataSize.BorderColor = Color.Black;
            cmDataSize.DropShadowEnabled = false;
            cmDataSize.ForeColor = Color.White;
            cmDataSize.ImageScalingSize = new Size(32, 32);
            cmDataSize.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmDataSize.MenuBackColorNorth = Color.DodgerBlue;
            cmDataSize.MenuBackColorSouth = Color.DodgerBlue;
            cmDataSize.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmDataSize.Name = "cmDataSize";
            cmDataSize.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmDataSize.ShowInsetShadow = false;
            cmDataSize.ShowItemInsetShadow = false;
            cmDataSize.Size = new Size(61, 4);
            // 
            // cmCoilFormats
            // 
            cmCoilFormats.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmCoilFormats.BorderColor = Color.Black;
            cmCoilFormats.DropShadowEnabled = false;
            cmCoilFormats.ForeColor = Color.White;
            cmCoilFormats.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmCoilFormats.MenuBackColorNorth = Color.DodgerBlue;
            cmCoilFormats.MenuBackColorSouth = Color.DodgerBlue;
            cmCoilFormats.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmCoilFormats.Name = "cmCoilFormats";
            cmCoilFormats.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmCoilFormats.ShowInsetShadow = false;
            cmCoilFormats.ShowItemInsetShadow = false;
            cmCoilFormats.Size = new Size(181, 26);
            // 
            // ModbusRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 250);
            CloseButtonCloses = false;
            Controls.Add(lstRegisters);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(250, 100);
            Name = "ModbusRegister";
            Padding = new Padding(5, 18, 5, 5);
            Text = "Modbus Register";
            CloseButtonClicked += ModbusRegister_CloseButtonClicked;
            Activated += ModbusRegister_Activated;
            FormClosing += ModbusRegister_FormClosing;
            Load += ModbusRegister_Load;
            SizeChanged += ModbusRegister_SizeChanged;
            Move += ModbusRegister_Move;
            ResumeLayout(false);
        }

        #endregion
        private ODModules.ContextMenu cmDisplayFormats;
        private ODModules.ContextMenu cmDataSize;
        public ODModules.ListControl lstRegisters;
        private ODModules.ContextMenu cmCoilFormats;
    }
}