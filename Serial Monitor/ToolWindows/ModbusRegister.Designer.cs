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
            this.lstRegisters = new ODModules.ListControl();
            this.cmDisplayFormats = new ODModules.ContextMenu();
            this.cmDataSize = new ODModules.ContextMenu();
            this.SuspendLayout();
            // 
            // lstRegisters
            // 
            this.lstRegisters.AllowColumnSpanning = false;
            this.lstRegisters.AllowMouseWheel = true;
            this.lstRegisters.ColumnColor = System.Drawing.Color.LightGray;
            this.lstRegisters.ColumnForeColor = System.Drawing.Color.Black;
            this.lstRegisters.ColumnLineColor = System.Drawing.Color.DimGray;
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column1.CountOffset = 0;
            column1.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column1.DropDownRight = false;
            column1.DropDownVisible = true;
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column1.Text = "";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 50;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column2.DropDownRight = false;
            column2.DropDownVisible = false;
            column2.FixedWidth = false;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column2.Text = "Name";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 100;
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column3.CountOffset = 0;
            column3.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column3.DropDownRight = false;
            column3.DropDownVisible = true;
            column3.FixedWidth = false;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column3.Text = "Display";
            column3.UseItemBackColor = false;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 80;
            column4.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column4.CountOffset = 0;
            column4.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column4.DropDownRight = false;
            column4.DropDownVisible = true;
            column4.FixedWidth = true;
            column4.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column4.Text = "Size";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 75;
            column5.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column5.CountOffset = 0;
            column5.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column5.DropDownRight = false;
            column5.DropDownVisible = true;
            column5.FixedWidth = true;
            column5.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column5.Text = "Signed";
            column5.UseItemBackColor = false;
            column5.UseItemForeColor = false;
            column5.Visible = true;
            column5.Width = 50;
            column6.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column6.CountOffset = 0;
            column6.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column6.DropDownRight = false;
            column6.DropDownVisible = false;
            column6.FixedWidth = false;
            column6.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column6.Text = "Value";
            column6.UseItemBackColor = false;
            column6.UseItemForeColor = false;
            column6.Visible = true;
            column6.Width = 120;
            this.lstRegisters.Columns.Add(column1);
            this.lstRegisters.Columns.Add(column2);
            this.lstRegisters.Columns.Add(column3);
            this.lstRegisters.Columns.Add(column4);
            this.lstRegisters.Columns.Add(column5);
            this.lstRegisters.Columns.Add(column6);
            this.lstRegisters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRegisters.DropDownMouseDown = System.Drawing.Color.DimGray;
            this.lstRegisters.DropDownMouseOver = System.Drawing.Color.LightGray;
            this.lstRegisters.ExternalItems = null;
            this.lstRegisters.Filter = null;
            this.lstRegisters.FilterColumn = 0;
            this.lstRegisters.GridlineColor = System.Drawing.Color.LightGray;
            this.lstRegisters.HighlightStrength = 128;
            this.lstRegisters.HorScroll = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lstRegisters.LineMarkerIndex = 0;
            this.lstRegisters.Location = new System.Drawing.Point(9, 37);
            this.lstRegisters.Margin = new System.Windows.Forms.Padding(6);
            this.lstRegisters.MarkerBorderColor = System.Drawing.Color.LimeGreen;
            this.lstRegisters.MarkerFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.lstRegisters.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            this.lstRegisters.Name = "lstRegisters";
            this.lstRegisters.RowColor = System.Drawing.Color.LightGray;
            this.lstRegisters.ScrollBarMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lstRegisters.ScrollBarNorth = System.Drawing.Color.DarkTurquoise;
            this.lstRegisters.ScrollBarSouth = System.Drawing.Color.DeepSkyBlue;
            this.lstRegisters.ScrollItems = 3;
            this.lstRegisters.SelectedColor = System.Drawing.Color.SkyBlue;
            this.lstRegisters.SelectionColor = System.Drawing.Color.Gray;
            this.lstRegisters.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lstRegisters.ShowGrid = true;
            this.lstRegisters.ShowMarker = false;
            this.lstRegisters.ShowRowColors = true;
            this.lstRegisters.Size = new System.Drawing.Size(577, 485);
            this.lstRegisters.SpanColumn = 0;
            this.lstRegisters.TabIndex = 0;
            this.lstRegisters.UseLocalList = false;
            this.lstRegisters.VerScroll = 0;
            this.lstRegisters.DropDownClicked += new ODModules.ListControl.DropDownClickedHandler(this.lstRegisters_DropDownClicked);
            this.lstRegisters.ItemCheckedChanged += new ODModules.ListControl.ItemCheckedChangedHandler(this.lstRegisters_ItemCheckedChanged);
            this.lstRegisters.ItemClicked += new ODModules.ListControl.ItemClickedHandler(this.lstRegisters_ItemClicked);
            // 
            // cmDisplayFormats
            // 
            this.cmDisplayFormats.ActionSymbolForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmDisplayFormats.BorderColor = System.Drawing.Color.Black;
            this.cmDisplayFormats.DropShadowEnabled = false;
            this.cmDisplayFormats.ForeColor = System.Drawing.Color.White;
            this.cmDisplayFormats.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmDisplayFormats.InsetShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmDisplayFormats.MenuBackColorNorth = System.Drawing.Color.DodgerBlue;
            this.cmDisplayFormats.MenuBackColorSouth = System.Drawing.Color.DodgerBlue;
            this.cmDisplayFormats.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmDisplayFormats.Name = "cmDisplayFormats";
            this.cmDisplayFormats.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmDisplayFormats.ShowInsetShadow = false;
            this.cmDisplayFormats.ShowItemInsetShadow = false;
            this.cmDisplayFormats.Size = new System.Drawing.Size(61, 4);
            // 
            // cmDataSize
            // 
            this.cmDataSize.ActionSymbolForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmDataSize.BorderColor = System.Drawing.Color.Black;
            this.cmDataSize.DropShadowEnabled = false;
            this.cmDataSize.ForeColor = System.Drawing.Color.White;
            this.cmDataSize.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmDataSize.InsetShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmDataSize.MenuBackColorNorth = System.Drawing.Color.DodgerBlue;
            this.cmDataSize.MenuBackColorSouth = System.Drawing.Color.DodgerBlue;
            this.cmDataSize.MouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmDataSize.Name = "cmDataSize";
            this.cmDataSize.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cmDataSize.ShowInsetShadow = false;
            this.cmDataSize.ShowItemInsetShadow = false;
            this.cmDataSize.Size = new System.Drawing.Size(61, 4);
            // 
            // ModbusRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 533);
            this.CloseButtonCloses = false;
            this.Controls.Add(this.lstRegisters);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(464, 213);
            this.Name = "ModbusRegister";
            this.Padding = new System.Windows.Forms.Padding(9, 37, 9, 11);
            this.Text = "Modbus Register";
            this.CloseButtonClicked += new Serial_Monitor.Components.MdiClientForm.CloseButtonClickedHandler(this.ModbusRegister_CloseButtonClicked);
            this.Activated += new System.EventHandler(this.ModbusRegister_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModbusRegister_FormClosing);
            this.Load += new System.EventHandler(this.ModbusRegister_Load);
            this.SizeChanged += new System.EventHandler(this.ModbusRegister_SizeChanged);
            this.Move += new System.EventHandler(this.ModbusRegister_Move);
            this.ResumeLayout(false);

        }

        #endregion

        private ODModules.ListControl lstRegisters;
        private ODModules.ContextMenu cmDisplayFormats;
        private ODModules.ContextMenu cmDataSize;
    }
}