namespace Serial_Monitor.Dialogs {
    partial class WriteCoils {
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
            Handlers.NumericalString numericalString5 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString6 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString7 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString8 = new Handlers.NumericalString();
            ODModules.Column column3 = new ODModules.Column();
            ODModules.Column column4 = new ODModules.Column();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteCoils));
            lblpnlRegisters = new ODModules.LabelPanel();
            lblpnlQuantity = new ODModules.LabelPanel();
            numtxtAddress = new ODModules.NumericTextbox();
            lblpnlAddress = new ODModules.LabelPanel();
            numtxtUnit = new ODModules.NumericTextbox();
            labelPanel1 = new ODModules.LabelPanel();
            cmbxDataSet = new ODModules.FlatComboBox();
            lblpnlValue = new ODModules.LabelPanel();
            lstCoils = new ODModules.ListControl();
            tsMain = new ODModules.ToolStrip();
            btnAdd = new ToolStripButton();
            btnRemove = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnMoveUp = new ToolStripButton();
            btnMoveDown = new ToolStripButton();
            btnAccept = new ODModules.Button();
            btnCancel = new ODModules.Button();
            panel2 = new Panel();
            cmMain = new ODModules.ContextMenu();
            sendToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            addToolStripMenuItem = new ToolStripMenuItem();
            removeToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            moveUpToolStripMenuItem = new ToolStripMenuItem();
            moveDownToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            lblpnlRegisters.SuspendLayout();
            lblpnlQuantity.SuspendLayout();
            lblpnlAddress.SuspendLayout();
            labelPanel1.SuspendLayout();
            lblpnlValue.SuspendLayout();
            tsMain.SuspendLayout();
            panel2.SuspendLayout();
            cmMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblpnlRegisters
            // 
            lblpnlRegisters.ArrowColor = Color.LightGray;
            lblpnlRegisters.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlRegisters.AutoSize = true;
            lblpnlRegisters.CloseColor = Color.Black;
            lblpnlRegisters.CloseMouseOverColor = Color.Red;
            lblpnlRegisters.Collapsed = false;
            lblpnlRegisters.Controls.Add(lblpnlQuantity);
            lblpnlRegisters.Controls.Add(lblpnlAddress);
            lblpnlRegisters.Controls.Add(labelPanel1);
            lblpnlRegisters.Dock = DockStyle.Top;
            lblpnlRegisters.DropShadow = false;
            lblpnlRegisters.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlRegisters.FixedInlineWidth = false;
            lblpnlRegisters.ForeColor = Color.White;
            lblpnlRegisters.Inlinelabel = false;
            lblpnlRegisters.InlineWidth = 100;
            lblpnlRegisters.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlRegisters.LabelFont = new Font("Segoe UI", 8F);
            lblpnlRegisters.LabelForeColor = Color.WhiteSmoke;
            lblpnlRegisters.Location = new Point(10, 10);
            lblpnlRegisters.Name = "lblpnlRegisters";
            lblpnlRegisters.OverrideCollapseControl = false;
            lblpnlRegisters.Padding = new Padding(5, 18, 5, 5);
            lblpnlRegisters.PanelCollapsible = false;
            lblpnlRegisters.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlRegisters.ShowCloseButton = false;
            lblpnlRegisters.Size = new Size(264, 122);
            lblpnlRegisters.TabIndex = 7;
            lblpnlRegisters.Text = "Register Selection";
            // 
            // lblpnlQuantity
            // 
            lblpnlQuantity.ArrowColor = Color.LightGray;
            lblpnlQuantity.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlQuantity.AutoSize = true;
            lblpnlQuantity.CloseColor = Color.Black;
            lblpnlQuantity.CloseMouseOverColor = Color.Red;
            lblpnlQuantity.Collapsed = false;
            lblpnlQuantity.Controls.Add(numtxtAddress);
            lblpnlQuantity.Dock = DockStyle.Top;
            lblpnlQuantity.DropShadow = false;
            lblpnlQuantity.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlQuantity.FixedInlineWidth = true;
            lblpnlQuantity.ForeColor = Color.White;
            lblpnlQuantity.Inlinelabel = true;
            lblpnlQuantity.InlineWidth = 100;
            lblpnlQuantity.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlQuantity.LabelFont = new Font("Segoe UI", 8F);
            lblpnlQuantity.LabelForeColor = Color.Black;
            lblpnlQuantity.Location = new Point(5, 84);
            lblpnlQuantity.Name = "lblpnlQuantity";
            lblpnlQuantity.OverrideCollapseControl = false;
            lblpnlQuantity.Padding = new Padding(113, 5, 0, 5);
            lblpnlQuantity.PanelCollapsible = false;
            lblpnlQuantity.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlQuantity.ShowCloseButton = false;
            lblpnlQuantity.Size = new Size(254, 33);
            lblpnlQuantity.TabIndex = 2;
            lblpnlQuantity.Text = "Address";
            // 
            // numtxtAddress
            // 
            numtxtAddress.AllowClipboard = true;
            numtxtAddress.AllowDragValueChange = true;
            numtxtAddress.AllowFractionals = false;
            numtxtAddress.AllowMouseWheel = true;
            numtxtAddress.AllowNegatives = false;
            numtxtAddress.AllowNumberEntry = true;
            numtxtAddress.AllowTyping = true;
            numtxtAddress.ArrowKeysControlNumber = true;
            numtxtAddress.AutoSizeToText = false;
            numtxtAddress.Base = ODModules.NumericTextbox.NumberBase.Base10;
            numtxtAddress.BorderColor = Color.DimGray;
            numtxtAddress.ButtonDownColor = Color.Gray;
            numtxtAddress.ButtonHoverColor = Color.LightGray;
            numtxtAddress.Dock = DockStyle.Top;
            numtxtAddress.FixedNumericPadding = 5;
            numtxtAddress.FormatOutput = true;
            numtxtAddress.HasUnit = false;
            numtxtAddress.IsMetric = false;
            numtxtAddress.IsSecondaryMetric = false;
            numtxtAddress.LabelFont = new Font("Segoe UI", 9F);
            numtxtAddress.LabelForeColor = Color.Gray;
            numtxtAddress.LabelText = "";
            numtxtAddress.Location = new Point(113, 5);
            numtxtAddress.Marked = false;
            numtxtAddress.MarkedBackColor = Color.Empty;
            numtxtAddress.MarkedBorderColor = Color.Beige;
            numericalString5.DisplayValue = "32767";
            numericalString5.Value = "32767";
            numtxtAddress.Maximum = numericalString5;
            numericalString6.DisplayValue = "0";
            numericalString6.Value = "0";
            numtxtAddress.Minimum = numericalString6;
            numtxtAddress.Name = "numtxtAddress";
            numtxtAddress.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Right;
            numtxtAddress.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            numtxtAddress.NumericalLeftRadixDigitsMaximum = 7;
            numtxtAddress.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            numtxtAddress.RangeLimited = true;
            numtxtAddress.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            numtxtAddress.SecondaryTag = null;
            numtxtAddress.SecondaryUnit = "";
            numtxtAddress.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            numtxtAddress.SelectedBackColor = Color.Empty;
            numtxtAddress.SelectedBorderColor = Color.Beige;
            numtxtAddress.ShowLabel = true;
            numtxtAddress.Size = new Size(141, 23);
            numtxtAddress.TabIndex = 0;
            numtxtAddress.Unit = "";
            numtxtAddress.UseFixedNumericPadding = true;
            numtxtAddress.Value = "1";
            numtxtAddress.ValueChanged += numtxtAddress_ValueChanged;
            // 
            // lblpnlAddress
            // 
            lblpnlAddress.ArrowColor = Color.LightGray;
            lblpnlAddress.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlAddress.AutoSize = true;
            lblpnlAddress.CloseColor = Color.Black;
            lblpnlAddress.CloseMouseOverColor = Color.Red;
            lblpnlAddress.Collapsed = false;
            lblpnlAddress.Controls.Add(numtxtUnit);
            lblpnlAddress.Dock = DockStyle.Top;
            lblpnlAddress.DropShadow = false;
            lblpnlAddress.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlAddress.FixedInlineWidth = true;
            lblpnlAddress.ForeColor = Color.White;
            lblpnlAddress.Inlinelabel = true;
            lblpnlAddress.InlineWidth = 100;
            lblpnlAddress.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlAddress.LabelFont = new Font("Segoe UI", 8F);
            lblpnlAddress.LabelForeColor = Color.Black;
            lblpnlAddress.Location = new Point(5, 51);
            lblpnlAddress.Name = "lblpnlAddress";
            lblpnlAddress.OverrideCollapseControl = false;
            lblpnlAddress.Padding = new Padding(113, 5, 0, 5);
            lblpnlAddress.PanelCollapsible = false;
            lblpnlAddress.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlAddress.ShowCloseButton = false;
            lblpnlAddress.Size = new Size(254, 33);
            lblpnlAddress.TabIndex = 1;
            lblpnlAddress.Text = "Slave";
            // 
            // numtxtUnit
            // 
            numtxtUnit.AllowClipboard = true;
            numtxtUnit.AllowDragValueChange = true;
            numtxtUnit.AllowFractionals = false;
            numtxtUnit.AllowMouseWheel = true;
            numtxtUnit.AllowNegatives = false;
            numtxtUnit.AllowNumberEntry = true;
            numtxtUnit.AllowTyping = true;
            numtxtUnit.ArrowKeysControlNumber = true;
            numtxtUnit.AutoSizeToText = false;
            numtxtUnit.Base = ODModules.NumericTextbox.NumberBase.Base10;
            numtxtUnit.BorderColor = Color.DimGray;
            numtxtUnit.ButtonDownColor = Color.Gray;
            numtxtUnit.ButtonHoverColor = Color.LightGray;
            numtxtUnit.Dock = DockStyle.Top;
            numtxtUnit.FixedNumericPadding = 5;
            numtxtUnit.FormatOutput = true;
            numtxtUnit.HasUnit = false;
            numtxtUnit.IsMetric = false;
            numtxtUnit.IsSecondaryMetric = false;
            numtxtUnit.LabelFont = new Font("Segoe UI", 9F);
            numtxtUnit.LabelForeColor = Color.Gray;
            numtxtUnit.LabelText = "";
            numtxtUnit.Location = new Point(113, 5);
            numtxtUnit.Marked = false;
            numtxtUnit.MarkedBackColor = Color.Empty;
            numtxtUnit.MarkedBorderColor = Color.Beige;
            numericalString7.DisplayValue = "32767";
            numericalString7.Value = "32767";
            numtxtUnit.Maximum = numericalString7;
            numericalString8.DisplayValue = "0";
            numericalString8.Value = "0";
            numtxtUnit.Minimum = numericalString8;
            numtxtUnit.Name = "numtxtUnit";
            numtxtUnit.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Right;
            numtxtUnit.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            numtxtUnit.NumericalLeftRadixDigitsMaximum = 7;
            numtxtUnit.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            numtxtUnit.RangeLimited = true;
            numtxtUnit.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            numtxtUnit.SecondaryTag = null;
            numtxtUnit.SecondaryUnit = "";
            numtxtUnit.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            numtxtUnit.SelectedBackColor = Color.Empty;
            numtxtUnit.SelectedBorderColor = Color.Beige;
            numtxtUnit.ShowLabel = true;
            numtxtUnit.Size = new Size(141, 23);
            numtxtUnit.TabIndex = 0;
            numtxtUnit.Unit = "";
            numtxtUnit.UseFixedNumericPadding = true;
            numtxtUnit.Value = "0";
            // 
            // labelPanel1
            // 
            labelPanel1.ArrowColor = Color.LightGray;
            labelPanel1.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel1.AutoSize = true;
            labelPanel1.CloseColor = Color.Black;
            labelPanel1.CloseMouseOverColor = Color.Red;
            labelPanel1.Collapsed = false;
            labelPanel1.Controls.Add(cmbxDataSet);
            labelPanel1.Dock = DockStyle.Top;
            labelPanel1.DropShadow = false;
            labelPanel1.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel1.FixedInlineWidth = true;
            labelPanel1.ForeColor = Color.White;
            labelPanel1.Inlinelabel = true;
            labelPanel1.InlineWidth = 100;
            labelPanel1.LabelBackColor = Color.FromArgb(16, 16, 16);
            labelPanel1.LabelFont = new Font("Segoe UI", 8F);
            labelPanel1.LabelForeColor = Color.Black;
            labelPanel1.Location = new Point(5, 18);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = false;
            labelPanel1.Padding = new Padding(113, 5, 0, 5);
            labelPanel1.PanelCollapsible = false;
            labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel1.ShowCloseButton = false;
            labelPanel1.Size = new Size(254, 33);
            labelPanel1.TabIndex = 0;
            labelPanel1.Text = "Data Set";
            labelPanel1.Visible = false;
            // 
            // cmbxDataSet
            // 
            cmbxDataSet.Dock = DockStyle.Top;
            cmbxDataSet.FormattingEnabled = true;
            cmbxDataSet.Location = new Point(113, 5);
            cmbxDataSet.Name = "cmbxDataSet";
            cmbxDataSet.Size = new Size(141, 23);
            cmbxDataSet.TabIndex = 0;
            // 
            // lblpnlValue
            // 
            lblpnlValue.ArrowColor = Color.LightGray;
            lblpnlValue.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlValue.CloseColor = Color.Black;
            lblpnlValue.CloseMouseOverColor = Color.Red;
            lblpnlValue.Collapsed = false;
            lblpnlValue.Controls.Add(lstCoils);
            lblpnlValue.Controls.Add(tsMain);
            lblpnlValue.Dock = DockStyle.Fill;
            lblpnlValue.DropShadow = false;
            lblpnlValue.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlValue.FixedInlineWidth = false;
            lblpnlValue.ForeColor = Color.White;
            lblpnlValue.Inlinelabel = false;
            lblpnlValue.InlineWidth = 100;
            lblpnlValue.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlValue.LabelFont = new Font("Segoe UI", 8F);
            lblpnlValue.LabelForeColor = Color.WhiteSmoke;
            lblpnlValue.Location = new Point(10, 132);
            lblpnlValue.Name = "lblpnlValue";
            lblpnlValue.OverrideCollapseControl = false;
            lblpnlValue.Padding = new Padding(0, 18, 0, 0);
            lblpnlValue.PanelCollapsible = false;
            lblpnlValue.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlValue.ShowCloseButton = false;
            lblpnlValue.Size = new Size(264, 219);
            lblpnlValue.TabIndex = 10;
            lblpnlValue.Text = "Value";
            // 
            // lstCoils
            // 
            lstCoils.AllowColumnSpanning = true;
            lstCoils.AllowMouseWheel = true;
            lstCoils.BorderColor = Color.Gray;
            lstCoils.Borders = ODModules.Borders.None;
            lstCoils.ColumnColor = Color.LightGray;
            lstCoils.ColumnForeColor = Color.Black;
            lstCoils.ColumnLineColor = Color.DimGray;
            column3.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column3.CountOffset = 0;
            column3.DataFormat = ODModules.ColumnDataFormat.None;
            column3.DisplayType = ODModules.ColumnDisplayType.LineCount;
            column3.DropDownRight = false;
            column3.DropDownVisible = true;
            column3.Exportable = false;
            column3.ExportName = "";
            column3.FixedWidth = false;
            column3.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column3.Text = "Coil";
            column3.UseItemBackColor = false;
            column3.UseItemForeColor = false;
            column3.Visible = true;
            column3.Width = 80;
            column4.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column4.CountOffset = 0;
            column4.DataFormat = ODModules.ColumnDataFormat.None;
            column4.DisplayType = ODModules.ColumnDisplayType.Checkbox;
            column4.DropDownRight = false;
            column4.DropDownVisible = true;
            column4.Exportable = false;
            column4.ExportName = "";
            column4.FixedWidth = true;
            column4.ItemAlignment = ODModules.ItemTextAlignment.Left;
            column4.Text = "Value";
            column4.UseItemBackColor = false;
            column4.UseItemForeColor = false;
            column4.Visible = true;
            column4.Width = 184;
            lstCoils.Columns.Add(column3);
            lstCoils.Columns.Add(column4);
            lstCoils.Dock = DockStyle.Fill;
            lstCoils.DropDownMouseDown = Color.DimGray;
            lstCoils.DropDownMouseOver = Color.LightGray;
            lstCoils.ExternalItems = null;
            lstCoils.Filter = null;
            lstCoils.FilterColumn = 0;
            lstCoils.GridlineColor = Color.LightGray;
            lstCoils.HighlightStrength = 128;
            lstCoils.HorizontalScrollStep = 3;
            lstCoils.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstCoils.LineMarkerIndex = 0;
            lstCoils.Location = new Point(0, 43);
            lstCoils.MarkerBorderColor = Color.LimeGreen;
            lstCoils.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstCoils.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstCoils.Name = "lstCoils";
            lstCoils.RowColor = Color.LightGray;
            lstCoils.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstCoils.ScrollBarNorth = Color.DarkTurquoise;
            lstCoils.ScrollBarSouth = Color.DeepSkyBlue;
            lstCoils.ScrollItems = 3;
            lstCoils.SelectedColor = Color.SkyBlue;
            lstCoils.SelectionColor = Color.Gray;
            lstCoils.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstCoils.ShowGrid = false;
            lstCoils.ShowItemIndentation = false;
            lstCoils.ShowMarker = false;
            lstCoils.ShowRowColors = false;
            lstCoils.Size = new Size(264, 176);
            lstCoils.SpanColumn = 1;
            lstCoils.TabIndex = 1;
            lstCoils.UseLocalList = true;
            lstCoils.VerScroll = 0;
            lstCoils.KeyDown += lstCoils_KeyDown;
            // 
            // tsMain
            // 
            tsMain.BackColorNorth = Color.DodgerBlue;
            tsMain.BackColorSouth = Color.DodgerBlue;
            tsMain.BorderColor = Color.WhiteSmoke;
            tsMain.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemForeColor = Color.Black;
            tsMain.Items.AddRange(new ToolStripItem[] { btnAdd, btnRemove, toolStripSeparator1, btnMoveUp, btnMoveDown });
            tsMain.ItemSelectedBackColorNorth = Color.White;
            tsMain.ItemSelectedBackColorSouth = Color.White;
            tsMain.ItemSelectedForeColor = Color.Black;
            tsMain.Location = new Point(0, 18);
            tsMain.MenuBackColorNorth = Color.DodgerBlue;
            tsMain.MenuBackColorSouth = Color.DodgerBlue;
            tsMain.MenuBorderColor = Color.WhiteSmoke;
            tsMain.MenuSeparatorColor = Color.WhiteSmoke;
            tsMain.MenuSymbolColor = Color.WhiteSmoke;
            tsMain.Name = "tsMain";
            tsMain.RoundedToolStrip = false;
            tsMain.ShowBorder = false;
            tsMain.Size = new Size(264, 25);
            tsMain.StripItemSelectedBackColorNorth = Color.White;
            tsMain.StripItemSelectedBackColorSouth = Color.White;
            tsMain.TabIndex = 0;
            tsMain.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageScaling = ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(23, 22);
            btnAdd.Text = "Add";
            btnAdd.Click += toolStripButton1_Click;
            // 
            // btnRemove
            // 
            btnRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRemove.Image = (Image)resources.GetObject("btnRemove.Image");
            btnRemove.ImageScaling = ToolStripItemImageScaling.None;
            btnRemove.ImageTransparentColor = Color.Magenta;
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(23, 22);
            btnRemove.Text = "Remove";
            btnRemove.Click += btnRemove_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // btnMoveUp
            // 
            btnMoveUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnMoveUp.Image = (Image)resources.GetObject("btnMoveUp.Image");
            btnMoveUp.ImageTransparentColor = Color.Magenta;
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(23, 22);
            btnMoveUp.Text = "Move Up";
            btnMoveUp.Click += btnMoveUp_Click;
            // 
            // btnMoveDown
            // 
            btnMoveDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnMoveDown.Image = (Image)resources.GetObject("btnMoveDown.Image");
            btnMoveDown.ImageTransparentColor = Color.Magenta;
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(23, 22);
            btnMoveDown.Text = "Move Down";
            btnMoveDown.Click += btnMoveDown_Click;
            // 
            // btnAccept
            // 
            btnAccept.AllowGroupUnchecking = false;
            btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAccept.BackColorCheckedNorth = Color.Orange;
            btnAccept.BackColorCheckedSouth = Color.Orange;
            btnAccept.BackColorDownNorth = Color.DimGray;
            btnAccept.BackColorDownSouth = Color.DimGray;
            btnAccept.BackColorHoverNorth = Color.SkyBlue;
            btnAccept.BackColorHoverSouth = Color.SkyBlue;
            btnAccept.BackColorNorth = Color.White;
            btnAccept.BackColorSouth = Color.White;
            btnAccept.BorderColorCheckedNorth = Color.Black;
            btnAccept.BorderColorCheckedSouth = Color.Black;
            btnAccept.BorderColorDownNorth = Color.Black;
            btnAccept.BorderColorDownSouth = Color.Black;
            btnAccept.BorderColorHoverNorth = Color.Black;
            btnAccept.BorderColorHoverSouth = Color.Black;
            btnAccept.BorderColorNorth = Color.Black;
            btnAccept.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            btnAccept.BorderColorSouth = Color.Black;
            btnAccept.BorderRadius = 5;
            btnAccept.Checked = false;
            btnAccept.GroupMaximumChecked = 2;
            btnAccept.Location = new Point(67, 12);
            btnAccept.Name = "btnAccept";
            btnAccept.RadioButtonGroup = "";
            btnAccept.SecondaryFont = new Font("Segoe UI", 9F);
            btnAccept.SecondaryText = "";
            btnAccept.Size = new Size(93, 28);
            btnAccept.Style = ODModules.ButtonStyle.Square;
            btnAccept.TabIndex = 11;
            btnAccept.Text = "Send";
            btnAccept.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnAccept.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnAccept.Type = ODModules.ButtonType.Button;
            btnAccept.ButtonClicked += btnAccept_ButtonClicked;
            // 
            // btnCancel
            // 
            btnCancel.AllowGroupUnchecking = false;
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColorCheckedNorth = Color.Orange;
            btnCancel.BackColorCheckedSouth = Color.Orange;
            btnCancel.BackColorDownNorth = Color.DimGray;
            btnCancel.BackColorDownSouth = Color.DimGray;
            btnCancel.BackColorHoverNorth = Color.SkyBlue;
            btnCancel.BackColorHoverSouth = Color.SkyBlue;
            btnCancel.BackColorNorth = Color.White;
            btnCancel.BackColorSouth = Color.White;
            btnCancel.BorderColorCheckedNorth = Color.Black;
            btnCancel.BorderColorCheckedSouth = Color.Black;
            btnCancel.BorderColorDownNorth = Color.Black;
            btnCancel.BorderColorDownSouth = Color.Black;
            btnCancel.BorderColorHoverNorth = Color.Black;
            btnCancel.BorderColorHoverSouth = Color.Black;
            btnCancel.BorderColorNorth = Color.Black;
            btnCancel.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            btnCancel.BorderColorSouth = Color.Black;
            btnCancel.BorderRadius = 5;
            btnCancel.Checked = false;
            btnCancel.GroupMaximumChecked = 2;
            btnCancel.Location = new Point(166, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.RadioButtonGroup = "";
            btnCancel.SecondaryFont = new Font("Segoe UI", 9F);
            btnCancel.SecondaryText = "";
            btnCancel.Size = new Size(93, 28);
            btnCancel.Style = ODModules.ButtonStyle.Square;
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnCancel.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnCancel.Type = ODModules.ButtonType.Button;
            btnCancel.ButtonClicked += btnCancel_ButtonClicked;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnAccept);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(10, 351);
            panel2.Name = "panel2";
            panel2.Size = new Size(264, 40);
            panel2.TabIndex = 13;
            // 
            // cmMain
            // 
            cmMain.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmMain.BorderColor = Color.Black;
            cmMain.DropShadowEnabled = false;
            cmMain.ForeColor = Color.White;
            cmMain.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmMain.Items.AddRange(new ToolStripItem[] { sendToolStripMenuItem, toolStripSeparator2, addToolStripMenuItem, removeToolStripMenuItem, toolStripSeparator3, moveUpToolStripMenuItem, moveDownToolStripMenuItem, toolStripSeparator4, copyToolStripMenuItem, pasteToolStripMenuItem });
            cmMain.MenuBackColorNorth = Color.DodgerBlue;
            cmMain.MenuBackColorSouth = Color.DodgerBlue;
            cmMain.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmMain.Name = "cmMain";
            cmMain.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmMain.ShowInsetShadow = false;
            cmMain.ShowItemInsetShadow = false;
            cmMain.Size = new Size(204, 176);
            // 
            // sendToolStripMenuItem
            // 
            sendToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sendToolStripMenuItem.Name = "sendToolStripMenuItem";
            sendToolStripMenuItem.Size = new Size(203, 22);
            sendToolStripMenuItem.Text = "Send";
            sendToolStripMenuItem.Click += sendToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(200, 6);
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            addToolStripMenuItem.Size = new Size(203, 22);
            addToolStripMenuItem.Text = "Add";
            addToolStripMenuItem.Click += addToolStripMenuItem_Click;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.ShortcutKeys = Keys.Delete;
            removeToolStripMenuItem.Size = new Size(203, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(200, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            moveUpToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            moveUpToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Up;
            moveUpToolStripMenuItem.Size = new Size(203, 22);
            moveUpToolStripMenuItem.Text = "Move Up";
            moveUpToolStripMenuItem.Click += moveUpToolStripMenuItem_Click;
            // 
            // moveDownToolStripMenuItem
            // 
            moveDownToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            moveDownToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Down;
            moveDownToolStripMenuItem.Size = new Size(203, 22);
            moveDownToolStripMenuItem.Text = "Move Down";
            moveDownToolStripMenuItem.Click += moveDownToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(200, 6);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(203, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(203, 22);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // WriteCoils
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 401);
            ContextMenuStrip = cmMain;
            Controls.Add(lblpnlValue);
            Controls.Add(panel2);
            Controls.Add(lblpnlRegisters);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WriteCoils";
            Padding = new Padding(10);
            ShowInTaskbar = false;
            Text = "Write Coils";
            FormClosing += WriteCoils_FormClosing;
            Load += WriteCoils_Load;
            lblpnlRegisters.ResumeLayout(false);
            lblpnlRegisters.PerformLayout();
            lblpnlQuantity.ResumeLayout(false);
            lblpnlAddress.ResumeLayout(false);
            labelPanel1.ResumeLayout(false);
            lblpnlValue.ResumeLayout(false);
            lblpnlValue.PerformLayout();
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            panel2.ResumeLayout(false);
            cmMain.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.LabelPanel lblpnlRegisters;
        private ODModules.LabelPanel lblpnlQuantity;
        private ODModules.NumericTextbox numtxtAddress;
        private ODModules.LabelPanel lblpnlAddress;
        private ODModules.NumericTextbox numtxtUnit;
        private ODModules.LabelPanel labelPanel1;
        private ODModules.FlatComboBox cmbxDataSet;
        private ODModules.LabelPanel lblpnlValue;
        private ODModules.Button btnAccept;
        private ODModules.Button btnCancel;
        private Panel panel2;
        private ODModules.ListControl lstCoils;
        private ODModules.ToolStrip tsMain;
        private ToolStripButton btnAdd;
        private ToolStripButton btnRemove;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnMoveUp;
        private ToolStripButton btnMoveDown;
        private ODModules.ContextMenu cmMain;
        private ToolStripMenuItem sendToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem moveUpToolStripMenuItem;
        private ToolStripMenuItem moveDownToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
    }
}