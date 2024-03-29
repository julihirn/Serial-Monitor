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
            txtComparer = new ODModules.TextCompare();
            labelPanel1 = new ODModules.LabelPanel();
            textBox1 = new ODModules.TextBox();
            labelPanel2 = new ODModules.LabelPanel();
            textBox2 = new ODModules.TextBox();
            lstMonitor = new ODModules.ListControl();
            labelPanel1.SuspendLayout();
            labelPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtComparer
            // 
            txtComparer.CompareFrom = "";
            txtComparer.CompareTo = "";
            txtComparer.DifferenceColor = Color.FromArgb(64, 0, 0);
            txtComparer.Dock = DockStyle.Top;
            txtComparer.EmptyTextColor = Color.FromArgb(16, 16, 16);
            txtComparer.Font = new Font("Segoe UI", 9.75F);
            txtComparer.ForeColor = Color.White;
            txtComparer.GridColor = Color.FromArgb(100, 100, 100);
            txtComparer.Location = new Point(0, 66);
            txtComparer.Name = "txtComparer";
            txtComparer.Padding = new Padding(5, 5, 5, 5);
            txtComparer.SameColor = Color.FromArgb(0, 64, 0);
            txtComparer.ScrollBarNorth = Color.DarkTurquoise;
            txtComparer.ScrollBarSouth = Color.DeepSkyBlue;
            txtComparer.ShowScrollBar = true;
            txtComparer.Size = new Size(315, 69);
            txtComparer.TabIndex = 0;
            txtComparer.TextPosition = 0;
            txtComparer.UseEmptyTextColor = true;
            // 
            // labelPanel1
            // 
            labelPanel1.ArrowColor = Color.LightGray;
            labelPanel1.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel1.AutoSize = true;
            labelPanel1.CloseColor = Color.Black;
            labelPanel1.CloseMouseOverColor = Color.Red;
            labelPanel1.Collapsed = false;
            labelPanel1.Controls.Add(textBox1);
            labelPanel1.Dock = DockStyle.Top;
            labelPanel1.DropShadow = false;
            labelPanel1.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel1.FixedInlineWidth = true;
            labelPanel1.ForeColor = Color.White;
            labelPanel1.Inlinelabel = true;
            labelPanel1.InlineWidth = 100;
            labelPanel1.LabelBackColor = Color.FromArgb(16, 16, 16);
            labelPanel1.LabelFont = new Font("Segoe UI", 8F);
            labelPanel1.LabelForeColor = Color.WhiteSmoke;
            labelPanel1.Location = new Point(0, 0);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = false;
            labelPanel1.Padding = new Padding(113, 5, 5, 5);
            labelPanel1.PanelCollapsible = false;
            labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel1.ShowCloseButton = false;
            labelPanel1.Size = new Size(315, 33);
            labelPanel1.TabIndex = 1;
            labelPanel1.Text = "Compare From";
            // 
            // textBox1
            // 
            textBox1.AutoCompleteMode = AutoCompleteMode.None;
            textBox1.AutoCompleteSource = AutoCompleteSource.None;
            textBox1.BackColor = SystemColors.Window;
            textBox1.BorderColor = Color.MediumSlateBlue;
            textBox1.BorderSize = 1;
            textBox1.Dock = DockStyle.Top;
            textBox1.Font = new Font("Microsoft Sans Serif", 9.5F);
            textBox1.ForeColor = Color.DimGray;
            textBox1.Location = new Point(113, 5);
            textBox1.Margin = new Padding(2, 2, 2, 2);
            textBox1.MaxLength = 32767;
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.Padding = new Padding(4, 3, 4, 3);
            textBox1.PasswordChar = '\0';
            textBox1.PlaceholderText = "";
            textBox1.ReadOnly = false;
            textBox1.SelectedBackColor = Color.LightGray;
            textBox1.SelectedBorderColor = Color.HotPink;
            textBox1.ShortcutsEnabled = true;
            textBox1.Size = new Size(197, 23);
            textBox1.TabIndex = 1;
            textBox1.TextAlign = HorizontalAlignment.Left;
            textBox1.UnderlinedStyle = false;
            textBox1.UseSystemPasswordChar = false;
            textBox1.WordWrap = true;
            textBox1._TextChanged += textBox1_TextChanged;
            // 
            // labelPanel2
            // 
            labelPanel2.ArrowColor = Color.LightGray;
            labelPanel2.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel2.AutoSize = true;
            labelPanel2.CloseColor = Color.Black;
            labelPanel2.CloseMouseOverColor = Color.Red;
            labelPanel2.Collapsed = false;
            labelPanel2.Controls.Add(textBox2);
            labelPanel2.Dock = DockStyle.Top;
            labelPanel2.DropShadow = false;
            labelPanel2.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel2.FixedInlineWidth = true;
            labelPanel2.ForeColor = Color.White;
            labelPanel2.Inlinelabel = true;
            labelPanel2.InlineWidth = 100;
            labelPanel2.LabelBackColor = Color.FromArgb(16, 16, 16);
            labelPanel2.LabelFont = new Font("Segoe UI", 8F);
            labelPanel2.LabelForeColor = Color.WhiteSmoke;
            labelPanel2.Location = new Point(0, 33);
            labelPanel2.Name = "labelPanel2";
            labelPanel2.OverrideCollapseControl = false;
            labelPanel2.Padding = new Padding(113, 5, 5, 5);
            labelPanel2.PanelCollapsible = false;
            labelPanel2.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel2.ShowCloseButton = false;
            labelPanel2.Size = new Size(315, 33);
            labelPanel2.TabIndex = 2;
            labelPanel2.Text = "Compare To";
            // 
            // textBox2
            // 
            textBox2.AutoCompleteMode = AutoCompleteMode.None;
            textBox2.AutoCompleteSource = AutoCompleteSource.None;
            textBox2.BackColor = SystemColors.Window;
            textBox2.BorderColor = Color.MediumSlateBlue;
            textBox2.BorderSize = 1;
            textBox2.Dock = DockStyle.Top;
            textBox2.Font = new Font("Microsoft Sans Serif", 9.5F);
            textBox2.ForeColor = Color.DimGray;
            textBox2.Location = new Point(113, 5);
            textBox2.Margin = new Padding(2, 2, 2, 2);
            textBox2.MaxLength = 32767;
            textBox2.Multiline = false;
            textBox2.Name = "textBox2";
            textBox2.Padding = new Padding(4, 3, 4, 3);
            textBox2.PasswordChar = '\0';
            textBox2.PlaceholderText = "";
            textBox2.ReadOnly = false;
            textBox2.SelectedBackColor = Color.LightGray;
            textBox2.SelectedBorderColor = Color.HotPink;
            textBox2.ShortcutsEnabled = true;
            textBox2.Size = new Size(197, 23);
            textBox2.TabIndex = 2;
            textBox2.TextAlign = HorizontalAlignment.Left;
            textBox2.UnderlinedStyle = false;
            textBox2.UseSystemPasswordChar = false;
            textBox2.WordWrap = true;
            textBox2._TextChanged += textBox2_TextChanged;
            // 
            // lstMonitor
            // 
            lstMonitor.AllowColumnSpanning = false;
            lstMonitor.AllowMouseWheel = true;
            lstMonitor.ColumnColor = Color.LightGray;
            lstMonitor.ColumnForeColor = Color.Black;
            lstMonitor.ColumnLineColor = Color.DimGray;
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column1.CountOffset = 0;
            column1.DataFormat = ODModules.ColumnDataFormat.None;
            column1.DisplayType = ODModules.ColumnDisplayType.Text;
            column1.DropDownRight = false;
            column1.DropDownVisible = true;
            column1.Exportable = false;
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column1.Text = "Property";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 125;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DataFormat = ODModules.ColumnDataFormat.None;
            column2.DisplayType = ODModules.ColumnDisplayType.Text;
            column2.DropDownRight = false;
            column2.DropDownVisible = true;
            column2.Exportable = false;
            column2.FixedWidth = false;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column2.Text = "Value";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 80;
            lstMonitor.Columns.Add(column1);
            lstMonitor.Columns.Add(column2);
            lstMonitor.Dock = DockStyle.Fill;
            lstMonitor.DropDownMouseDown = Color.DimGray;
            lstMonitor.DropDownMouseOver = Color.LightGray;
            lstMonitor.ExternalItems = null;
            lstMonitor.Filter = null;
            lstMonitor.FilterColumn = 0;
            lstMonitor.ForeColor = Color.White;
            lstMonitor.GridlineColor = Color.LightGray;
            lstMonitor.HighlightStrength = 128;
            lstMonitor.HorizontalScrollStep = 3;
            lstMonitor.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            listItem1.BackColor = Color.Transparent;
            listItem1.Checked = false;
            listItem1.ForeColor = Color.Black;
            listItem1.Indentation = 0U;
            listItem1.LineBackColor = Color.Transparent;
            listItem1.LineForeColor = Color.Black;
            listItem1.Name = "";
            listItem1.Selected = false;
            listSubItem1.BackColor = Color.Transparent;
            listSubItem1.Checked = false;
            listSubItem1.ForeColor = Color.Black;
            listSubItem1.Indentation = 0U;
            listSubItem1.Name = "";
            listSubItem1.Tag = null;
            listSubItem1.Text = "0";
            listSubItem1.Value = 0;
            listItem1.SubItems.Add(listSubItem1);
            listItem1.Tag = null;
            listItem1.Text = "Length: Compare From";
            listItem1.UseLineBackColor = false;
            listItem1.UseLineForeColor = false;
            listItem1.Value = 0;
            listItem2.BackColor = Color.Transparent;
            listItem2.Checked = false;
            listItem2.ForeColor = Color.Black;
            listItem2.Indentation = 0U;
            listItem2.LineBackColor = Color.Transparent;
            listItem2.LineForeColor = Color.Black;
            listItem2.Name = "";
            listItem2.Selected = false;
            listSubItem2.BackColor = Color.Transparent;
            listSubItem2.Checked = false;
            listSubItem2.ForeColor = Color.Black;
            listSubItem2.Indentation = 0U;
            listSubItem2.Name = "";
            listSubItem2.Tag = null;
            listSubItem2.Text = "0";
            listSubItem2.Value = 0;
            listItem2.SubItems.Add(listSubItem2);
            listItem2.Tag = null;
            listItem2.Text = "Length: Compare To";
            listItem2.UseLineBackColor = false;
            listItem2.UseLineForeColor = false;
            listItem2.Value = 0;
            listItem3.BackColor = Color.Transparent;
            listItem3.Checked = false;
            listItem3.ForeColor = Color.Black;
            listItem3.Indentation = 0U;
            listItem3.LineBackColor = Color.Transparent;
            listItem3.LineForeColor = Color.Black;
            listItem3.Name = "";
            listItem3.Selected = false;
            listSubItem3.BackColor = Color.Transparent;
            listSubItem3.Checked = false;
            listSubItem3.ForeColor = Color.Black;
            listSubItem3.Indentation = 0U;
            listSubItem3.Name = "";
            listSubItem3.Tag = null;
            listSubItem3.Text = "0";
            listSubItem3.Value = 0;
            listItem3.SubItems.Add(listSubItem3);
            listItem3.Tag = null;
            listItem3.Text = "Length: Maximum";
            listItem3.UseLineBackColor = false;
            listItem3.UseLineForeColor = false;
            listItem3.Value = 0;
            listItem4.BackColor = Color.Transparent;
            listItem4.Checked = false;
            listItem4.ForeColor = Color.Black;
            listItem4.Indentation = 0U;
            listItem4.LineBackColor = Color.Transparent;
            listItem4.LineForeColor = Color.Black;
            listItem4.Name = "";
            listItem4.Selected = false;
            listSubItem4.BackColor = Color.Transparent;
            listSubItem4.Checked = false;
            listSubItem4.ForeColor = Color.Black;
            listSubItem4.Indentation = 0U;
            listSubItem4.Name = "";
            listSubItem4.Tag = null;
            listSubItem4.Text = "-1";
            listSubItem4.Value = 0;
            listItem4.SubItems.Add(listSubItem4);
            listItem4.Tag = null;
            listItem4.Text = "Index: First Match";
            listItem4.UseLineBackColor = false;
            listItem4.UseLineForeColor = false;
            listItem4.Value = 0;
            listItem5.BackColor = Color.Transparent;
            listItem5.Checked = false;
            listItem5.ForeColor = Color.Black;
            listItem5.Indentation = 0U;
            listItem5.LineBackColor = Color.Transparent;
            listItem5.LineForeColor = Color.Black;
            listItem5.Name = "";
            listItem5.Selected = false;
            listSubItem5.BackColor = Color.Transparent;
            listSubItem5.Checked = false;
            listSubItem5.ForeColor = Color.Black;
            listSubItem5.Indentation = 0U;
            listSubItem5.Name = "";
            listSubItem5.Tag = null;
            listSubItem5.Text = "0";
            listSubItem5.Value = 0;
            listItem5.SubItems.Add(listSubItem5);
            listItem5.Tag = null;
            listItem5.Text = "Matches";
            listItem5.UseLineBackColor = false;
            listItem5.UseLineForeColor = false;
            listItem5.Value = 0;
            listItem6.BackColor = Color.Transparent;
            listItem6.Checked = false;
            listItem6.ForeColor = Color.Black;
            listItem6.Indentation = 0U;
            listItem6.LineBackColor = Color.Transparent;
            listItem6.LineForeColor = Color.Black;
            listItem6.Name = "";
            listItem6.Selected = false;
            listSubItem6.BackColor = Color.Transparent;
            listSubItem6.Checked = false;
            listSubItem6.ForeColor = Color.Black;
            listSubItem6.Indentation = 0U;
            listSubItem6.Name = "";
            listSubItem6.Tag = null;
            listSubItem6.Text = "0";
            listSubItem6.Value = 0;
            listItem6.SubItems.Add(listSubItem6);
            listItem6.Tag = null;
            listItem6.Text = "Mismatches";
            listItem6.UseLineBackColor = false;
            listItem6.UseLineForeColor = false;
            listItem6.Value = 0;
            lstMonitor.Items.Add(listItem1);
            lstMonitor.Items.Add(listItem2);
            lstMonitor.Items.Add(listItem3);
            lstMonitor.Items.Add(listItem4);
            lstMonitor.Items.Add(listItem5);
            lstMonitor.Items.Add(listItem6);
            lstMonitor.LineMarkerIndex = 0;
            lstMonitor.Location = new Point(0, 135);
            lstMonitor.MarkerBorderColor = Color.LimeGreen;
            lstMonitor.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstMonitor.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstMonitor.Name = "lstMonitor";
            lstMonitor.RowColor = Color.LightGray;
            lstMonitor.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstMonitor.ScrollBarNorth = Color.DarkTurquoise;
            lstMonitor.ScrollBarSouth = Color.DeepSkyBlue;
            lstMonitor.ScrollItems = 3;
            lstMonitor.SelectedColor = Color.SkyBlue;
            lstMonitor.SelectionColor = Color.Gray;
            lstMonitor.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstMonitor.ShowGrid = false;
            lstMonitor.ShowItemIndentation = false;
            lstMonitor.ShowMarker = false;
            lstMonitor.ShowRowColors = false;
            lstMonitor.Size = new Size(315, 179);
            lstMonitor.SpanColumn = 0;
            lstMonitor.TabIndex = 3;
            lstMonitor.UseLocalList = true;
            lstMonitor.VerScroll = 0;
            // 
            // TextComparator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(315, 314);
            Controls.Add(lstMonitor);
            Controls.Add(txtComparer);
            Controls.Add(labelPanel2);
            Controls.Add(labelPanel1);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TextComparator";
            Text = "Text Comparator";
            FormClosed += TextComparator_FormClosed;
            Load += TextComparator_Load;
            SizeChanged += TextComparator_SizeChanged;
            VisibleChanged += TextComparator_VisibleChanged;
            labelPanel1.ResumeLayout(false);
            labelPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.TextCompare txtComparer;
        private ODModules.LabelPanel labelPanel1;
        private ODModules.LabelPanel labelPanel2;
        private ODModules.ListControl lstMonitor;
        private ODModules.TextBox textBox1;
        private ODModules.TextBox textBox2;
    }
}