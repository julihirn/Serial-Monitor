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
            this.lstRegisters = new ODModules.ListControl();
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
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column3.CountOffset = 0;
            column3.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column3.DropDownRight = false;
            column3.DropDownVisible = false;
            column3.FixedWidth = false;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column3.Text = "Value";
            column3.UseItemBackColor = false;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 70;
            this.lstRegisters.Columns.Add(column1);
            this.lstRegisters.Columns.Add(column2);
            this.lstRegisters.Columns.Add(column3);
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
            this.lstRegisters.Location = new System.Drawing.Point(5, 18);
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
            this.lstRegisters.Size = new System.Drawing.Size(240, 227);
            this.lstRegisters.SpanColumn = 0;
            this.lstRegisters.TabIndex = 0;
            this.lstRegisters.UseLocalList = false;
            this.lstRegisters.VerScroll = 0;
            this.lstRegisters.DropDownClicked += new ODModules.ListControl.DropDownClickedHandler(this.lstRegisters_DropDownClicked);
            // 
            // ModbusRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 250);
            this.CloseButtonCloses = false;
            this.Controls.Add(this.lstRegisters);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(250, 100);
            this.Name = "ModbusRegister";
            this.Padding = new System.Windows.Forms.Padding(5, 18, 5, 5);
            this.Text = "Modbus Register";
            this.CloseButtonClicked += new Serial_Monitor.Components.MdiClientForm.CloseButtonClickedHandler(this.ModbusRegister_CloseButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModbusRegister_FormClosing);
            this.Load += new System.EventHandler(this.ModbusRegister_Load);
            this.SizeChanged += new System.EventHandler(this.ModbusRegister_SizeChanged);
            this.Move += new System.EventHandler(this.ModbusRegister_Move);
            this.ResumeLayout(false);

        }

        #endregion

        private ODModules.ListControl lstRegisters;
    }
}