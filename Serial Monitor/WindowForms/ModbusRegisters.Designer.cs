namespace Serial_Monitor {
    partial class ModbusRegisters {
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
            ODModules.Column column9 = new ODModules.Column();
            ODModules.Column column10 = new ODModules.Column();
            ODModules.Column column11 = new ODModules.Column();
            ODModules.Column column12 = new ODModules.Column();
            ODModules.ListItem listItem3 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem9 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem10 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem11 = new ODModules.ListSubItem();
            ODModules.ListSubItem listSubItem12 = new ODModules.ListSubItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModbusRegisters));
            this.navigator1 = new ODModules.Navigator();
            this.lstMonitor = new ODModules.ListControl();
            this.tsMain = new ODModules.ToolStrip();
            this.btnCoils = new System.Windows.Forms.ToolStripButton();
            this.btnDiscrete = new System.Windows.Forms.ToolStripButton();
            this.btnHolding = new System.Windows.Forms.ToolStripButton();
            this.btnInputRegisters = new System.Windows.Forms.ToolStripButton();
            this.lblTypeSelection = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnApplyOnClick = new System.Windows.Forms.ToolStripButton();
            this.btnLockEditor = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigator1
            // 
            this.navigator1.ArrowColor = System.Drawing.Color.Black;
            this.navigator1.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.navigator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.navigator1.DisplayStyle = ODModules.Navigator.Style.Right;
            this.navigator1.DisplayText = "StateName";
            this.navigator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navigator1.ForeColor = System.Drawing.Color.White;
            this.navigator1.LinkedList = null;
            this.navigator1.Location = new System.Drawing.Point(0, 25);
            this.navigator1.MidColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.navigator1.Name = "navigator1";
            this.navigator1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navigator1.SelectedItem = -1;
            this.navigator1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navigator1.ShowAnimations = true;
            this.navigator1.SideShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navigator1.Size = new System.Drawing.Size(81, 311);
            this.navigator1.TabIndex = 2;
            this.navigator1.SelectedIndexChanged += new ODModules.Navigator.SelectedIndexChangedHandler(this.navigator1_SelectedIndexChanged);
            // 
            // lstMonitor
            // 
            this.lstMonitor.AllowColumnSpanning = false;
            this.lstMonitor.AllowMouseWheel = true;
            this.lstMonitor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lstMonitor.ColumnColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lstMonitor.ColumnForeColor = System.Drawing.Color.WhiteSmoke;
            this.lstMonitor.ColumnLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            column9.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column9.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column9.DropDownRight = false;
            column9.DropDownVisible = false;
            column9.FixedWidth = false;
            column9.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column9.Text = "";
            column9.UseItemBackColor = false;
            column9.UseItemForeColor = false;
            column9.Visible = true;
            column9.Width = 50;
            column10.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column10.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column10.DropDownRight = false;
            column10.DropDownVisible = false;
            column10.FixedWidth = false;
            column10.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column10.Text = "Name";
            column10.UseItemBackColor = true;
            column10.UseItemForeColor = false;
            column10.Visible = true;
            column10.Width = 150;
            column11.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column11.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column11.DropDownRight = false;
            column11.DropDownVisible = false;
            column11.FixedWidth = false;
            column11.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column11.Text = "Display";
            column11.UseItemBackColor = false;
            column11.UseItemForeColor = false;
            column11.Visible = true;
            column11.Width = 60;
            column12.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column12.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column12.DropDownRight = false;
            column12.DropDownVisible = false;
            column12.FixedWidth = false;
            column12.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column12.Text = "Value";
            column12.UseItemBackColor = false;
            column12.UseItemForeColor = false;
            column12.Visible = true;
            column12.Width = 120;
            this.lstMonitor.Columns.Add(column9);
            this.lstMonitor.Columns.Add(column10);
            this.lstMonitor.Columns.Add(column11);
            this.lstMonitor.Columns.Add(column12);
            this.lstMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMonitor.DropDownMouseDown = System.Drawing.Color.DimGray;
            this.lstMonitor.DropDownMouseOver = System.Drawing.Color.LightGray;
            this.lstMonitor.ExternalItems = null;
            this.lstMonitor.Filter = null;
            this.lstMonitor.FilterColumn = 0;
            this.lstMonitor.ForeColor = System.Drawing.Color.White;
            this.lstMonitor.GridlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lstMonitor.HighlightStrength = 128;
            this.lstMonitor.HorScroll = new decimal(new int[] {
            0,
            0,
            0,
            0});
            listItem3.BackColor = System.Drawing.Color.Transparent;
            listItem3.Checked = false;
            listItem3.ForeColor = System.Drawing.Color.Black;
            listItem3.Name = "";
            listItem3.Selected = false;
            listSubItem9.BackColor = System.Drawing.Color.Transparent;
            listSubItem9.Checked = false;
            listSubItem9.ForeColor = System.Drawing.Color.Black;
            listSubItem9.Name = "";
            listSubItem9.Tag = null;
            listSubItem9.Text = "";
            listSubItem10.BackColor = System.Drawing.Color.Transparent;
            listSubItem10.Checked = false;
            listSubItem10.ForeColor = System.Drawing.Color.Black;
            listSubItem10.Name = "";
            listSubItem10.Tag = null;
            listSubItem10.Text = "";
            listSubItem11.BackColor = System.Drawing.Color.Transparent;
            listSubItem11.Checked = false;
            listSubItem11.ForeColor = System.Drawing.Color.Black;
            listSubItem11.Name = "";
            listSubItem11.Tag = null;
            listSubItem11.Text = "";
            listSubItem12.BackColor = System.Drawing.Color.Transparent;
            listSubItem12.Checked = false;
            listSubItem12.ForeColor = System.Drawing.Color.Black;
            listSubItem12.Name = "";
            listSubItem12.Tag = null;
            listSubItem12.Text = "";
            listItem3.SubItems.Add(listSubItem9);
            listItem3.SubItems.Add(listSubItem10);
            listItem3.SubItems.Add(listSubItem11);
            listItem3.SubItems.Add(listSubItem12);
            listItem3.Tag = null;
            listItem3.Text = "";
            this.lstMonitor.Items.Add(listItem3);
            this.lstMonitor.LineMarkerIndex = 0;
            this.lstMonitor.Location = new System.Drawing.Point(81, 25);
            this.lstMonitor.MarkerBorderColor = System.Drawing.Color.LimeGreen;
            this.lstMonitor.MarkerFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.lstMonitor.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            this.lstMonitor.Name = "lstMonitor";
            this.lstMonitor.RowColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.lstMonitor.ScrollBarMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lstMonitor.ScrollBarNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstMonitor.ScrollBarSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstMonitor.ScrollItems = 3;
            this.lstMonitor.SelectedColor = System.Drawing.Color.SteelBlue;
            this.lstMonitor.SelectionColor = System.Drawing.Color.Gray;
            this.lstMonitor.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lstMonitor.ShowGrid = true;
            this.lstMonitor.ShowMarker = false;
            this.lstMonitor.ShowRowColors = true;
            this.lstMonitor.Size = new System.Drawing.Size(422, 311);
            this.lstMonitor.SpanColumn = -1;
            this.lstMonitor.TabIndex = 3;
            this.lstMonitor.UseLocalList = true;
            this.lstMonitor.VerScroll = 0;
            this.lstMonitor.DropDownClicked += new ODModules.ListControl.DropDownClickedHandler(this.lstMonitor_DropDownClicked);
            // 
            // tsMain
            // 
            this.tsMain.BackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.BackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.ItemCheckedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMain.ItemCheckedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMain.ItemForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCoils,
            this.btnDiscrete,
            this.btnHolding,
            this.btnInputRegisters,
            this.lblTypeSelection,
            this.toolStripSeparator1,
            this.btnApplyOnClick,
            this.btnLockEditor});
            this.tsMain.ItemSelectedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.ItemSelectedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.ItemSelectedForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.MenuBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.MenuBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.MenuBorderColor = System.Drawing.Color.DimGray;
            this.tsMain.MenuSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.tsMain.MenuSymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsMain.Size = new System.Drawing.Size(503, 25);
            this.tsMain.StripItemSelectedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.StripItemSelectedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tsMain.TabIndex = 4;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnCoils
            // 
            this.btnCoils.Checked = true;
            this.btnCoils.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnCoils.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCoils.Image = ((System.Drawing.Image)(resources.GetObject("btnCoils.Image")));
            this.btnCoils.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCoils.Name = "btnCoils";
            this.btnCoils.Size = new System.Drawing.Size(23, 22);
            this.btnCoils.Text = "Coils";
            this.btnCoils.Click += new System.EventHandler(this.btnCoils_Click);
            // 
            // btnDiscrete
            // 
            this.btnDiscrete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDiscrete.Image = ((System.Drawing.Image)(resources.GetObject("btnDiscrete.Image")));
            this.btnDiscrete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDiscrete.Name = "btnDiscrete";
            this.btnDiscrete.Size = new System.Drawing.Size(23, 22);
            this.btnDiscrete.Text = "Discrete Inputs";
            this.btnDiscrete.Click += new System.EventHandler(this.btnDiscrete_Click);
            // 
            // btnHolding
            // 
            this.btnHolding.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHolding.Image = ((System.Drawing.Image)(resources.GetObject("btnHolding.Image")));
            this.btnHolding.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHolding.Name = "btnHolding";
            this.btnHolding.Size = new System.Drawing.Size(23, 22);
            this.btnHolding.Text = "Holding Registers";
            this.btnHolding.Click += new System.EventHandler(this.btnHolding_Click);
            // 
            // btnInputRegisters
            // 
            this.btnInputRegisters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInputRegisters.Image = ((System.Drawing.Image)(resources.GetObject("btnInputRegisters.Image")));
            this.btnInputRegisters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInputRegisters.Name = "btnInputRegisters";
            this.btnInputRegisters.Size = new System.Drawing.Size(23, 22);
            this.btnInputRegisters.Text = "Input Registers";
            this.btnInputRegisters.Click += new System.EventHandler(this.btnInputRegisters_Click);
            // 
            // lblTypeSelection
            // 
            this.lblTypeSelection.ForeColor = System.Drawing.Color.White;
            this.lblTypeSelection.Name = "lblTypeSelection";
            this.lblTypeSelection.Size = new System.Drawing.Size(33, 22);
            this.lblTypeSelection.Text = "Coils";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnApplyOnClick
            // 
            this.btnApplyOnClick.Checked = true;
            this.btnApplyOnClick.CheckOnClick = true;
            this.btnApplyOnClick.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnApplyOnClick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnApplyOnClick.Image = ((System.Drawing.Image)(resources.GetObject("btnApplyOnClick.Image")));
            this.btnApplyOnClick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApplyOnClick.Name = "btnApplyOnClick";
            this.btnApplyOnClick.Size = new System.Drawing.Size(23, 22);
            this.btnApplyOnClick.Text = "Send On Change";
            // 
            // btnLockEditor
            // 
            this.btnLockEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLockEditor.Image = ((System.Drawing.Image)(resources.GetObject("btnLockEditor.Image")));
            this.btnLockEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLockEditor.Name = "btnLockEditor";
            this.btnLockEditor.Size = new System.Drawing.Size(23, 22);
            this.btnLockEditor.Text = "Lock Editor";
            this.btnLockEditor.Click += new System.EventHandler(this.btnLockEditor_Click);
            // 
            // ModbusRegisters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(503, 336);
            this.Controls.Add(this.lstMonitor);
            this.Controls.Add(this.navigator1);
            this.Controls.Add(this.tsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModbusRegisters";
            this.Text = "Modbus Registers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModbusRegisters_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ModbusRegisters_FormClosed);
            this.Load += new System.EventHandler(this.ModbusRegisters_Load);
            this.SizeChanged += new System.EventHandler(this.ModbusRegisters_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.ModbusRegisters_VisibleChanged);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ODModules.Navigator navigator1;
        private ODModules.ListControl lstMonitor;
        private ODModules.ToolStrip tsMain;
        private ToolStripButton btnCoils;
        private ToolStripButton btnDiscrete;
        private ToolStripButton btnHolding;
        private ToolStripButton btnInputRegisters;
        private ToolStripLabel lblTypeSelection;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnApplyOnClick;
        private ToolStripButton btnLockEditor;
    }
}