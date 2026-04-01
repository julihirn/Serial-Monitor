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
            sltbCompareFrom = new ODModules.SingleLineTextBox();
            cmTextboxOptions = new ODModules.ContextMenu();
            cmiTextBoxCut = new ToolStripMenuItem();
            cmiTextBoxCopy = new ToolStripMenuItem();
            cmiTextBoxPaste = new ToolStripMenuItem();
            cmiTextBoxDelete = new ToolStripMenuItem();
            toolStripSeparator47 = new ToolStripSeparator();
            cmiTextBoxSelectAll = new ToolStripMenuItem();
            labelPanel2 = new ODModules.LabelPanel();
            sltbCompareTo = new ODModules.SingleLineTextBox();
            lstMonitor = new ODModules.ListControl();
            msMain = new ODModules.MenuStrip();
            editToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            selectAllToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            compareFromToolStripMenuItem = new ToolStripMenuItem();
            compareToToolStripMenuItem = new ToolStripMenuItem();
            cntrlExtender = new ODModules.ControlExtensions.ControlExtender();
            tsiExtender = new ODModules.ControlExtensions.ToolStripItemExtender();
            labelPanel1.SuspendLayout();
            cmTextboxOptions.SuspendLayout();
            labelPanel2.SuspendLayout();
            msMain.SuspendLayout();
            SuspendLayout();
            // 
            // txtComparer
            // 
            txtComparer.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            txtComparer.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            txtComparer.CompareFrom = "";
            txtComparer.CompareTo = "";
            txtComparer.DifferenceColor = Color.FromArgb(64, 0, 0);
            txtComparer.Dock = DockStyle.Top;
            txtComparer.EmptyTextColor = Color.FromArgb(16, 16, 16);
            txtComparer.Font = new Font("Segoe UI", 9.75F);
            txtComparer.ForeColor = Color.White;
            txtComparer.GridColor = Color.FromArgb(100, 100, 100);
            txtComparer.Location = new Point(0, 178);
            txtComparer.Margin = new Padding(6);
            txtComparer.Name = "txtComparer";
            txtComparer.Padding = new Padding(9, 11, 9, 11);
            txtComparer.SameColor = Color.FromArgb(0, 64, 0);
            txtComparer.ScrollBarNorth = Color.DarkTurquoise;
            txtComparer.ScrollBarSouth = Color.DeepSkyBlue;
            txtComparer.ShowScrollBar = true;
            txtComparer.Size = new Size(585, 147);
            txtComparer.TabIndex = 0;
            txtComparer.TextPosition = 0;
            cntrlExtender.SetTranslationReference(txtComparer, "");
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
            labelPanel1.Controls.Add(sltbCompareFrom);
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
            labelPanel1.Location = new Point(0, 42);
            labelPanel1.Margin = new Padding(6);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = false;
            labelPanel1.Padding = new Padding(127, 11, 9, 11);
            labelPanel1.PanelCollapsible = false;
            labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel1.SeparatorColor = Color.Gray;
            labelPanel1.ShowCloseButton = false;
            labelPanel1.ShowSeparator = false;
            labelPanel1.Size = new Size(585, 68);
            labelPanel1.TabIndex = 1;
            labelPanel1.Text = "Compare From";
            cntrlExtender.SetTranslationReference(labelPanel1, "");
            // 
            // sltbCompareFrom
            // 
            sltbCompareFrom.AllowShortcuts = true;
            sltbCompareFrom.BorderColor = Color.MediumSlateBlue;
            sltbCompareFrom.BorderSize = 1;
            sltbCompareFrom.CaretColor = Color.Black;
            sltbCompareFrom.ContextMenuStrip = cmTextboxOptions;
            sltbCompareFrom.Dock = DockStyle.Top;
            sltbCompareFrom.FocusLostClearSelection = true;
            sltbCompareFrom.Location = new Point(127, 11);
            sltbCompareFrom.MaskArrowKeyEvents = true;
            sltbCompareFrom.MaxLength = 65535;
            sltbCompareFrom.Name = "sltbCompareFrom";
            sltbCompareFrom.PlaceholderForeColor = Color.DimGray;
            sltbCompareFrom.PlaceHolderText = "";
            sltbCompareFrom.SelectedBackColor = Color.LightGray;
            sltbCompareFrom.SelectedBorderColor = Color.HotPink;
            sltbCompareFrom.SelectionColor = Color.LightBlue;
            sltbCompareFrom.Size = new Size(449, 46);
            sltbCompareFrom.TabIndex = 2;
            sltbCompareFrom.TextAlign = HorizontalAlignment.Left;
            cntrlExtender.SetTranslationReference(sltbCompareFrom, "");
            sltbCompareFrom.TextChanged += sltbCompareFrom_TextChanged;
            sltbCompareFrom.Enter += sltbCompareFrom_Enter;
            // 
            // cmTextboxOptions
            // 
            cmTextboxOptions.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmTextboxOptions.BorderColor = Color.Black;
            cmTextboxOptions.DropShadowEnabled = false;
            cmTextboxOptions.ForeColor = Color.White;
            cmTextboxOptions.ImageScalingSize = new Size(32, 32);
            cmTextboxOptions.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmTextboxOptions.Items.AddRange(new ToolStripItem[] { cmiTextBoxCut, cmiTextBoxCopy, cmiTextBoxPaste, cmiTextBoxDelete, toolStripSeparator47, cmiTextBoxSelectAll });
            cmTextboxOptions.MenuBackColorNorth = Color.DodgerBlue;
            cmTextboxOptions.MenuBackColorSouth = Color.DodgerBlue;
            cmTextboxOptions.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmTextboxOptions.Name = "cmTextboxOptions";
            cmTextboxOptions.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmTextboxOptions.ShowInsetShadow = false;
            cmTextboxOptions.ShowItemInsetShadow = false;
            cmTextboxOptions.Size = new Size(187, 200);
            cntrlExtender.SetTranslationReference(cmTextboxOptions, "");
            cmTextboxOptions.Opening += cmTextboxOptions_Opening;
            // 
            // cmiTextBoxCut
            // 
            cmiTextBoxCut.ImageScaling = ToolStripItemImageScaling.None;
            cmiTextBoxCut.Name = "cmiTextBoxCut";
            cmiTextBoxCut.Size = new Size(186, 38);
            cmiTextBoxCut.Text = "C&ut";
            tsiExtender.SetTranslationReference(cmiTextBoxCut, "cut");
            cmiTextBoxCut.Click += cmiTextBoxCut_Click;
            // 
            // cmiTextBoxCopy
            // 
            cmiTextBoxCopy.ImageScaling = ToolStripItemImageScaling.None;
            cmiTextBoxCopy.Name = "cmiTextBoxCopy";
            cmiTextBoxCopy.Size = new Size(186, 38);
            cmiTextBoxCopy.Text = "&Copy";
            tsiExtender.SetTranslationReference(cmiTextBoxCopy, "copy");
            cmiTextBoxCopy.Click += cmiTextBoxCopy_Click;
            // 
            // cmiTextBoxPaste
            // 
            cmiTextBoxPaste.ImageScaling = ToolStripItemImageScaling.None;
            cmiTextBoxPaste.Name = "cmiTextBoxPaste";
            cmiTextBoxPaste.Size = new Size(186, 38);
            cmiTextBoxPaste.Text = "&Paste";
            tsiExtender.SetTranslationReference(cmiTextBoxPaste, "paste");
            cmiTextBoxPaste.Click += cmiTextBoxPaste_Click;
            // 
            // cmiTextBoxDelete
            // 
            cmiTextBoxDelete.ImageScaling = ToolStripItemImageScaling.None;
            cmiTextBoxDelete.Name = "cmiTextBoxDelete";
            cmiTextBoxDelete.Size = new Size(186, 38);
            cmiTextBoxDelete.Text = "&Delete";
            tsiExtender.SetTranslationReference(cmiTextBoxDelete, "delete");
            cmiTextBoxDelete.Click += cmiTextBoxDelete_Click;
            // 
            // toolStripSeparator47
            // 
            toolStripSeparator47.Name = "toolStripSeparator47";
            toolStripSeparator47.Size = new Size(183, 6);
            tsiExtender.SetTranslationReference(toolStripSeparator47, "");
            // 
            // cmiTextBoxSelectAll
            // 
            cmiTextBoxSelectAll.ImageScaling = ToolStripItemImageScaling.None;
            cmiTextBoxSelectAll.Name = "cmiTextBoxSelectAll";
            cmiTextBoxSelectAll.Size = new Size(186, 38);
            cmiTextBoxSelectAll.Text = "&Select All";
            tsiExtender.SetTranslationReference(cmiTextBoxSelectAll, "selectAll");
            cmiTextBoxSelectAll.Click += cmiTextBoxSelectAll_Click;
            // 
            // labelPanel2
            // 
            labelPanel2.ArrowColor = Color.LightGray;
            labelPanel2.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel2.AutoSize = true;
            labelPanel2.CloseColor = Color.Black;
            labelPanel2.CloseMouseOverColor = Color.Red;
            labelPanel2.Collapsed = false;
            labelPanel2.Controls.Add(sltbCompareTo);
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
            labelPanel2.Location = new Point(0, 110);
            labelPanel2.Margin = new Padding(6);
            labelPanel2.Name = "labelPanel2";
            labelPanel2.OverrideCollapseControl = false;
            labelPanel2.Padding = new Padding(127, 11, 9, 11);
            labelPanel2.PanelCollapsible = false;
            labelPanel2.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel2.SeparatorColor = Color.Gray;
            labelPanel2.ShowCloseButton = false;
            labelPanel2.ShowSeparator = false;
            labelPanel2.Size = new Size(585, 68);
            labelPanel2.TabIndex = 2;
            labelPanel2.Text = "Compare To";
            cntrlExtender.SetTranslationReference(labelPanel2, "");
            // 
            // sltbCompareTo
            // 
            sltbCompareTo.AllowShortcuts = true;
            sltbCompareTo.BorderColor = Color.MediumSlateBlue;
            sltbCompareTo.BorderSize = 1;
            sltbCompareTo.CaretColor = Color.Black;
            sltbCompareTo.ContextMenuStrip = cmTextboxOptions;
            sltbCompareTo.Dock = DockStyle.Top;
            sltbCompareTo.FocusLostClearSelection = true;
            sltbCompareTo.Location = new Point(127, 11);
            sltbCompareTo.MaskArrowKeyEvents = true;
            sltbCompareTo.MaxLength = 65535;
            sltbCompareTo.Name = "sltbCompareTo";
            sltbCompareTo.PlaceholderForeColor = Color.DimGray;
            sltbCompareTo.PlaceHolderText = "";
            sltbCompareTo.SelectedBackColor = Color.LightGray;
            sltbCompareTo.SelectedBorderColor = Color.HotPink;
            sltbCompareTo.SelectionColor = Color.LightBlue;
            sltbCompareTo.Size = new Size(449, 46);
            sltbCompareTo.TabIndex = 3;
            sltbCompareTo.TextAlign = HorizontalAlignment.Left;
            cntrlExtender.SetTranslationReference(sltbCompareTo, "");
            sltbCompareTo.TextChanged += sltbCompareTo_TextChanged;
            sltbCompareTo.Enter += sltbCompareTo_Enter;
            // 
            // lstMonitor
            // 
            lstMonitor.AllowArrowKeyCellSelect = false;
            lstMonitor.AllowColumnSpanning = false;
            lstMonitor.AllowMouseWheel = true;
            lstMonitor.BorderColor = Color.Gray;
            lstMonitor.Borders = ODModules.Borders.None;
            lstMonitor.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            lstMonitor.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            lstMonitor.CellPixelFit = true;
            lstMonitor.CellSelectEditableOnly = true;
            lstMonitor.CellSelectionBorderColor = Color.Blue;
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
            column1.ExportName = "";
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
            column2.ExportName = "";
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
            lstMonitor.FilterSearchType = ODModules.ListControl.FilterSearch.Contains;
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
            listItem1.MaximumValue = 0;
            listItem1.MinimumValue = 0;
            listItem1.Name = "";
            listItem1.Selected = false;
            listSubItem1.BackColor = Color.Transparent;
            listSubItem1.Checked = false;
            listSubItem1.ForeColor = Color.Black;
            listSubItem1.Indentation = 0U;
            listSubItem1.MaximumValue = 0;
            listSubItem1.MinimumValue = 0;
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
            listItem2.MaximumValue = 0;
            listItem2.MinimumValue = 0;
            listItem2.Name = "";
            listItem2.Selected = false;
            listSubItem2.BackColor = Color.Transparent;
            listSubItem2.Checked = false;
            listSubItem2.ForeColor = Color.Black;
            listSubItem2.Indentation = 0U;
            listSubItem2.MaximumValue = 0;
            listSubItem2.MinimumValue = 0;
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
            listItem3.MaximumValue = 0;
            listItem3.MinimumValue = 0;
            listItem3.Name = "";
            listItem3.Selected = false;
            listSubItem3.BackColor = Color.Transparent;
            listSubItem3.Checked = false;
            listSubItem3.ForeColor = Color.Black;
            listSubItem3.Indentation = 0U;
            listSubItem3.MaximumValue = 0;
            listSubItem3.MinimumValue = 0;
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
            listItem4.MaximumValue = 0;
            listItem4.MinimumValue = 0;
            listItem4.Name = "";
            listItem4.Selected = false;
            listSubItem4.BackColor = Color.Transparent;
            listSubItem4.Checked = false;
            listSubItem4.ForeColor = Color.Black;
            listSubItem4.Indentation = 0U;
            listSubItem4.MaximumValue = 0;
            listSubItem4.MinimumValue = 0;
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
            listItem5.MaximumValue = 0;
            listItem5.MinimumValue = 0;
            listItem5.Name = "";
            listItem5.Selected = false;
            listSubItem5.BackColor = Color.Transparent;
            listSubItem5.Checked = false;
            listSubItem5.ForeColor = Color.Black;
            listSubItem5.Indentation = 0U;
            listSubItem5.MaximumValue = 0;
            listSubItem5.MinimumValue = 0;
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
            listItem6.MaximumValue = 0;
            listItem6.MinimumValue = 0;
            listItem6.Name = "";
            listItem6.Selected = false;
            listSubItem6.BackColor = Color.Transparent;
            listSubItem6.Checked = false;
            listSubItem6.ForeColor = Color.Black;
            listSubItem6.Indentation = 0U;
            listSubItem6.MaximumValue = 0;
            listSubItem6.MinimumValue = 0;
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
            lstMonitor.Location = new Point(0, 325);
            lstMonitor.Margin = new Padding(6);
            lstMonitor.MarkerBorderColor = Color.LimeGreen;
            lstMonitor.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstMonitor.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstMonitor.MoveControlOnCellChange = true;
            lstMonitor.Name = "lstMonitor";
            lstMonitor.RowColor = Color.LightGray;
            lstMonitor.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstMonitor.ScrollBarNorth = Color.DarkTurquoise;
            lstMonitor.ScrollBarSouth = Color.DeepSkyBlue;
            lstMonitor.ScrollItems = 3;
            lstMonitor.SelectedColor = Color.SkyBlue;
            lstMonitor.SelectionColor = Color.Gray;
            lstMonitor.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstMonitor.ShowCellSelection = false;
            lstMonitor.ShowGrid = false;
            lstMonitor.ShowHeader = true;
            lstMonitor.ShowItemIndentation = false;
            lstMonitor.ShowMarker = false;
            lstMonitor.ShowRowColors = false;
            lstMonitor.Size = new Size(585, 345);
            lstMonitor.SpanColumn = 0;
            lstMonitor.TabIndex = 3;
            cntrlExtender.SetTranslationReference(lstMonitor, "");
            lstMonitor.UseLocalList = true;
            lstMonitor.VerScroll = 0;
            lstMonitor.Zoom = 100;
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
            msMain.Size = new Size(585, 42);
            msMain.StripItemSelectedBackColorNorth = Color.White;
            msMain.StripItemSelectedBackColorSouth = Color.White;
            msMain.TabIndex = 4;
            msMain.Text = "menuStrip1";
            cntrlExtender.SetTranslationReference(msMain, "edit");
            msMain.UseNorthFadeIn = false;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, deleteToolStripMenuItem, toolStripSeparator1, selectAllToolStripMenuItem, toolStripSeparator2, compareFromToolStripMenuItem, compareToToolStripMenuItem });
            editToolStripMenuItem.ForeColor = Color.Black;
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(74, 38);
            editToolStripMenuItem.Text = "&Edit";
            tsiExtender.SetTranslationReference(editToolStripMenuItem, "");
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.ForeColor = Color.Black;
            cutToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(378, 44);
            cutToolStripMenuItem.Text = "C&ut";
            tsiExtender.SetTranslationReference(cutToolStripMenuItem, "cut");
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ForeColor = Color.Black;
            copyToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(378, 44);
            copyToolStripMenuItem.Text = "&Copy";
            tsiExtender.SetTranslationReference(copyToolStripMenuItem, "copy");
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ForeColor = Color.Black;
            pasteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(378, 44);
            pasteToolStripMenuItem.Text = "&Paste";
            tsiExtender.SetTranslationReference(pasteToolStripMenuItem, "paste");
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.ForeColor = Color.Black;
            deleteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteToolStripMenuItem.Size = new Size(378, 44);
            deleteToolStripMenuItem.Text = "&Delete";
            tsiExtender.SetTranslationReference(deleteToolStripMenuItem, "delete");
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(375, 6);
            tsiExtender.SetTranslationReference(toolStripSeparator1, "");
            // 
            // selectAllToolStripMenuItem
            // 
            selectAllToolStripMenuItem.ForeColor = Color.Black;
            selectAllToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            selectAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllToolStripMenuItem.Size = new Size(378, 44);
            selectAllToolStripMenuItem.Text = "&Select All";
            tsiExtender.SetTranslationReference(selectAllToolStripMenuItem, "selectAll");
            selectAllToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(375, 6);
            tsiExtender.SetTranslationReference(toolStripSeparator2, "");
            // 
            // compareFromToolStripMenuItem
            // 
            compareFromToolStripMenuItem.Checked = true;
            compareFromToolStripMenuItem.CheckState = CheckState.Checked;
            compareFromToolStripMenuItem.ForeColor = Color.Black;
            compareFromToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            compareFromToolStripMenuItem.Name = "compareFromToolStripMenuItem";
            compareFromToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D1;
            compareFromToolStripMenuItem.Size = new Size(378, 44);
            compareFromToolStripMenuItem.Text = "Compare From";
            tsiExtender.SetTranslationReference(compareFromToolStripMenuItem, "compareFrom");
            compareFromToolStripMenuItem.Click += compareFromToolStripMenuItem_Click;
            // 
            // compareToToolStripMenuItem
            // 
            compareToToolStripMenuItem.ForeColor = Color.Black;
            compareToToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            compareToToolStripMenuItem.Name = "compareToToolStripMenuItem";
            compareToToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.D2;
            compareToToolStripMenuItem.Size = new Size(378, 44);
            compareToToolStripMenuItem.Text = "Compare To";
            tsiExtender.SetTranslationReference(compareToToolStripMenuItem, "compareTo");
            compareToToolStripMenuItem.Click += compareToToolStripMenuItem_Click;
            // 
            // TextComparator
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(585, 670);
            Controls.Add(lstMonitor);
            Controls.Add(txtComparer);
            Controls.Add(labelPanel2);
            Controls.Add(labelPanel1);
            Controls.Add(msMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msMain;
            Margin = new Padding(6);
            Name = "TextComparator";
            Text = "Text Comparator";
            FormClosed += TextComparator_FormClosed;
            Load += TextComparator_Load;
            SizeChanged += TextComparator_SizeChanged;
            VisibleChanged += TextComparator_VisibleChanged;
            labelPanel1.ResumeLayout(false);
            cmTextboxOptions.ResumeLayout(false);
            labelPanel2.ResumeLayout(false);
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.TextCompare txtComparer;
        private ODModules.LabelPanel labelPanel1;
        private ODModules.LabelPanel labelPanel2;
        private ODModules.ListControl lstMonitor;
        private ODModules.SingleLineTextBox sltbCompareFrom;
        private ODModules.SingleLineTextBox sltbCompareTo;
        private ODModules.MenuStrip msMain;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem selectAllToolStripMenuItem;
        private ODModules.ContextMenu cmTextboxOptions;
        private ToolStripMenuItem cmiTextBoxCut;
        private ToolStripMenuItem cmiTextBoxCopy;
        private ToolStripMenuItem cmiTextBoxPaste;
        private ToolStripMenuItem cmiTextBoxDelete;
        private ToolStripSeparator toolStripSeparator47;
        private ToolStripMenuItem cmiTextBoxSelectAll;
        private ODModules.ControlExtensions.ControlExtender cntrlExtender;
        private ODModules.ControlExtensions.ToolStripItemExtender tsiExtender;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem compareFromToolStripMenuItem;
        private ToolStripMenuItem compareToToolStripMenuItem;
    }
}