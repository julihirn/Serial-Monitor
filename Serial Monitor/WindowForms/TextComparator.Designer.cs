namespace Serial_Monitor.WindowForms {
    partial class TextComparator {
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
            ODModules.ListItem listItem1 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem1 = new ODModules.ListSubItem();
            ODModules.ListItem listItem2 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem2 = new ODModules.ListSubItem();
            ODModules.ListItem listItem3 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem3 = new ODModules.ListSubItem();
            ODModules.ListItem listItem4 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem4 = new ODModules.ListSubItem();
            ODModules.ListItem listItem5 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem5 = new ODModules.ListSubItem();
            ODModules.ListItem listItem6 = new ODModules.ListItem();
            ODModules.ListSubItem listSubItem6 = new ODModules.ListSubItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextComparator));
            this.txtComparer = new ODModules.TextCompare();
            this.labelPanel1 = new ODModules.LabelPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelPanel2 = new ODModules.LabelPanel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lstMonitor = new ODModules.ListControl();
            this.labelPanel1.SuspendLayout();
            this.labelPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtComparer
            // 
            this.txtComparer.CompareFrom = "";
            this.txtComparer.CompareTo = "";
            this.txtComparer.DifferenceColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtComparer.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtComparer.EmptyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.txtComparer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtComparer.ForeColor = System.Drawing.Color.White;
            this.txtComparer.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.txtComparer.Location = new System.Drawing.Point(0, 78);
            this.txtComparer.Name = "txtComparer";
            this.txtComparer.Padding = new System.Windows.Forms.Padding(5);
            this.txtComparer.SameColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtComparer.ScrollBarNorth = System.Drawing.Color.DarkTurquoise;
            this.txtComparer.ScrollBarSouth = System.Drawing.Color.DeepSkyBlue;
            this.txtComparer.ShowScrollBar = true;
            this.txtComparer.Size = new System.Drawing.Size(315, 69);
            this.txtComparer.TabIndex = 0;
            this.txtComparer.TextPosition = 0;
            this.txtComparer.UseEmptyTextColor = true;
            // 
            // labelPanel1
            // 
            this.labelPanel1.ArrowColor = System.Drawing.Color.LightGray;
            this.labelPanel1.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel1.AutoSize = true;
            this.labelPanel1.CloseColor = System.Drawing.Color.Black;
            this.labelPanel1.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel1.Collapsed = false;
            this.labelPanel1.Controls.Add(this.textBox1);
            this.labelPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPanel1.DropShadow = false;
            this.labelPanel1.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel1.FixedInlineWidth = false;
            this.labelPanel1.ForeColor = System.Drawing.Color.White;
            this.labelPanel1.Inlinelabel = false;
            this.labelPanel1.InlineWidth = 100;
            this.labelPanel1.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.labelPanel1.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel1.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelPanel1.Location = new System.Drawing.Point(0, 0);
            this.labelPanel1.Name = "labelPanel1";
            this.labelPanel1.OverrideCollapseControl = false;
            this.labelPanel1.Padding = new System.Windows.Forms.Padding(5, 18, 5, 5);
            this.labelPanel1.PanelCollapsible = false;
            this.labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.labelPanel1.ShowCloseButton = false;
            this.labelPanel1.Size = new System.Drawing.Size(315, 39);
            this.labelPanel1.TabIndex = 1;
            this.labelPanel1.Text = "Compare From";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(5, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(305, 16);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelPanel2
            // 
            this.labelPanel2.ArrowColor = System.Drawing.Color.LightGray;
            this.labelPanel2.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel2.AutoSize = true;
            this.labelPanel2.CloseColor = System.Drawing.Color.Black;
            this.labelPanel2.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel2.Collapsed = false;
            this.labelPanel2.Controls.Add(this.textBox2);
            this.labelPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPanel2.DropShadow = false;
            this.labelPanel2.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel2.FixedInlineWidth = false;
            this.labelPanel2.ForeColor = System.Drawing.Color.White;
            this.labelPanel2.Inlinelabel = false;
            this.labelPanel2.InlineWidth = 100;
            this.labelPanel2.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.labelPanel2.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel2.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelPanel2.Location = new System.Drawing.Point(0, 39);
            this.labelPanel2.Name = "labelPanel2";
            this.labelPanel2.OverrideCollapseControl = false;
            this.labelPanel2.Padding = new System.Windows.Forms.Padding(5, 18, 5, 5);
            this.labelPanel2.PanelCollapsible = false;
            this.labelPanel2.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.labelPanel2.ShowCloseButton = false;
            this.labelPanel2.Size = new System.Drawing.Size(315, 39);
            this.labelPanel2.TabIndex = 2;
            this.labelPanel2.Text = "Compare To";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(5, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(305, 16);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lstMonitor
            // 
            this.lstMonitor.AllowColumnSpanning = false;
            this.lstMonitor.AllowMouseWheel = true;
            this.lstMonitor.ColumnColor = System.Drawing.Color.LightGray;
            this.lstMonitor.ColumnForeColor = System.Drawing.Color.Black;
            this.lstMonitor.ColumnLineColor = System.Drawing.Color.DimGray;
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column1.DisplayType = ODModules.ColumnDisplayType.Text;
            column1.DropDownRight = false;
            column1.DropDownVisible = true;
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column1.Text = "Property";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 125;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.DisplayType = ODModules.ColumnDisplayType.Text;
            column2.DropDownRight = false;
            column2.DropDownVisible = true;
            column2.FixedWidth = false;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column2.Text = "Value";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 80;
            this.lstMonitor.Columns.Add(column1);
            this.lstMonitor.Columns.Add(column2);
            this.lstMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMonitor.DropDownMouseDown = System.Drawing.Color.DimGray;
            this.lstMonitor.DropDownMouseOver = System.Drawing.Color.LightGray;
            this.lstMonitor.ExternalItems = null;
            this.lstMonitor.Filter = null;
            this.lstMonitor.FilterColumn = 0;
            this.lstMonitor.ForeColor = System.Drawing.Color.White;
            this.lstMonitor.GridlineColor = System.Drawing.Color.LightGray;
            this.lstMonitor.HighlightStrength = 128;
            this.lstMonitor.HorScroll = new decimal(new int[] {
            0,
            0,
            0,
            0});
            listItem1.BackColor = System.Drawing.Color.Transparent;
            listItem1.Checked = false;
            listItem1.ForeColor = System.Drawing.Color.Black;
            listItem1.Name = "";
            listItem1.Selected = false;
            listSubItem1.BackColor = System.Drawing.Color.Transparent;
            listSubItem1.Checked = false;
            listSubItem1.ForeColor = System.Drawing.Color.Black;
            listSubItem1.Name = "";
            listSubItem1.Tag = null;
            listSubItem1.Text = "0";
            listItem1.SubItems.Add(listSubItem1);
            listItem1.Tag = null;
            listItem1.Text = "Length: Compare From";
            listItem2.BackColor = System.Drawing.Color.Transparent;
            listItem2.Checked = false;
            listItem2.ForeColor = System.Drawing.Color.Black;
            listItem2.Name = "";
            listItem2.Selected = false;
            listSubItem2.BackColor = System.Drawing.Color.Transparent;
            listSubItem2.Checked = false;
            listSubItem2.ForeColor = System.Drawing.Color.Black;
            listSubItem2.Name = "";
            listSubItem2.Tag = null;
            listSubItem2.Text = "0";
            listItem2.SubItems.Add(listSubItem2);
            listItem2.Tag = null;
            listItem2.Text = "Length: Compare To";
            listItem3.BackColor = System.Drawing.Color.Transparent;
            listItem3.Checked = false;
            listItem3.ForeColor = System.Drawing.Color.Black;
            listItem3.Name = "";
            listItem3.Selected = false;
            listSubItem3.BackColor = System.Drawing.Color.Transparent;
            listSubItem3.Checked = false;
            listSubItem3.ForeColor = System.Drawing.Color.Black;
            listSubItem3.Name = "";
            listSubItem3.Tag = null;
            listSubItem3.Text = "0";
            listItem3.SubItems.Add(listSubItem3);
            listItem3.Tag = null;
            listItem3.Text = "Length: Maximum";
            listItem4.BackColor = System.Drawing.Color.Transparent;
            listItem4.Checked = false;
            listItem4.ForeColor = System.Drawing.Color.Black;
            listItem4.Name = "";
            listItem4.Selected = false;
            listSubItem4.BackColor = System.Drawing.Color.Transparent;
            listSubItem4.Checked = false;
            listSubItem4.ForeColor = System.Drawing.Color.Black;
            listSubItem4.Name = "";
            listSubItem4.Tag = null;
            listSubItem4.Text = "-1";
            listItem4.SubItems.Add(listSubItem4);
            listItem4.Tag = null;
            listItem4.Text = "Index: First Match";
            listItem5.BackColor = System.Drawing.Color.Transparent;
            listItem5.Checked = false;
            listItem5.ForeColor = System.Drawing.Color.Black;
            listItem5.Name = "";
            listItem5.Selected = false;
            listSubItem5.BackColor = System.Drawing.Color.Transparent;
            listSubItem5.Checked = false;
            listSubItem5.ForeColor = System.Drawing.Color.Black;
            listSubItem5.Name = "";
            listSubItem5.Tag = null;
            listSubItem5.Text = "0";
            listItem5.SubItems.Add(listSubItem5);
            listItem5.Tag = null;
            listItem5.Text = "Matches";
            listItem6.BackColor = System.Drawing.Color.Transparent;
            listItem6.Checked = false;
            listItem6.ForeColor = System.Drawing.Color.Black;
            listItem6.Name = "";
            listItem6.Selected = false;
            listSubItem6.BackColor = System.Drawing.Color.Transparent;
            listSubItem6.Checked = false;
            listSubItem6.ForeColor = System.Drawing.Color.Black;
            listSubItem6.Name = "";
            listSubItem6.Tag = null;
            listSubItem6.Text = "0";
            listItem6.SubItems.Add(listSubItem6);
            listItem6.Tag = null;
            listItem6.Text = "Mismatches";
            this.lstMonitor.Items.Add(listItem1);
            this.lstMonitor.Items.Add(listItem2);
            this.lstMonitor.Items.Add(listItem3);
            this.lstMonitor.Items.Add(listItem4);
            this.lstMonitor.Items.Add(listItem5);
            this.lstMonitor.Items.Add(listItem6);
            this.lstMonitor.LineMarkerIndex = 0;
            this.lstMonitor.Location = new System.Drawing.Point(0, 147);
            this.lstMonitor.MarkerBorderColor = System.Drawing.Color.LimeGreen;
            this.lstMonitor.MarkerFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(50)))), ((int)(((byte)(205)))), ((int)(((byte)(50)))));
            this.lstMonitor.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            this.lstMonitor.Name = "lstMonitor";
            this.lstMonitor.RowColor = System.Drawing.Color.LightGray;
            this.lstMonitor.ScrollBarMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lstMonitor.ScrollBarNorth = System.Drawing.Color.DarkTurquoise;
            this.lstMonitor.ScrollBarSouth = System.Drawing.Color.DeepSkyBlue;
            this.lstMonitor.ScrollItems = 3;
            this.lstMonitor.SelectedColor = System.Drawing.Color.SkyBlue;
            this.lstMonitor.SelectionColor = System.Drawing.Color.Gray;
            this.lstMonitor.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lstMonitor.ShowGrid = false;
            this.lstMonitor.ShowMarker = false;
            this.lstMonitor.ShowRowColors = false;
            this.lstMonitor.Size = new System.Drawing.Size(315, 167);
            this.lstMonitor.SpanColumn = 0;
            this.lstMonitor.TabIndex = 3;
            this.lstMonitor.UseLocalList = true;
            this.lstMonitor.VerScroll = 0;
            // 
            // TextComparator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(315, 314);
            this.Controls.Add(this.lstMonitor);
            this.Controls.Add(this.txtComparer);
            this.Controls.Add(this.labelPanel2);
            this.Controls.Add(this.labelPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextComparator";
            this.Text = "Text Comparator";
            this.Load += new System.EventHandler(this.TextComparator_Load);
            this.labelPanel1.ResumeLayout(false);
            this.labelPanel1.PerformLayout();
            this.labelPanel2.ResumeLayout(false);
            this.labelPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ODModules.TextCompare txtComparer;
        private ODModules.LabelPanel labelPanel1;
        private TextBox textBox1;
        private ODModules.LabelPanel labelPanel2;
        private TextBox textBox2;
        private ODModules.ListControl lstMonitor;
    }
}