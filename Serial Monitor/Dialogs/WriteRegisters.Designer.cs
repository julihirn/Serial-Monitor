namespace Serial_Monitor.Dialogs {
    partial class WriteRegisters {
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
            Handlers.NumericalString numericalString1 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString2 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString3 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString4 = new Handlers.NumericalString();
            ODModules.Column column1 = new ODModules.Column();
            ODModules.Column column2 = new ODModules.Column();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteRegisters));
            panel2 = new Panel();
            btnCancel = new ODModules.Button();
            btnAccept = new ODModules.Button();
            lblpnlRegisters = new ODModules.LabelPanel();
            lblpnlQuantity = new ODModules.LabelPanel();
            numtxtAddress = new ODModules.NumericTextbox();
            lblpnlAddress = new ODModules.LabelPanel();
            numtxtUnit = new ODModules.NumericTextbox();
            labelPanel1 = new ODModules.LabelPanel();
            cmbxDataSet = new ODModules.FlatComboBox();
            lblpnlValue = new ODModules.LabelPanel();
            lstRegisters = new ODModules.ListControl();
            tsMain = new ODModules.ToolStrip();
            btnAdd = new ToolStripButton();
            btnRemove = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnMoveUp = new ToolStripButton();
            btnMoveDown = new ToolStripButton();
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
            lblpnlFormat = new ODModules.LabelPanel();
            tsFormat = new ODModules.ToolStrip();
            ddbFormat = new ToolStripDropDownButton();
            toolStripSeparator5 = new ToolStripSeparator();
            ddbSize = new ToolStripDropDownButton();
            btnSign = new ToolStripButton();
            panel2.SuspendLayout();
            lblpnlRegisters.SuspendLayout();
            lblpnlQuantity.SuspendLayout();
            lblpnlAddress.SuspendLayout();
            labelPanel1.SuspendLayout();
            lblpnlValue.SuspendLayout();
            tsMain.SuspendLayout();
            cmMain.SuspendLayout();
            lblpnlFormat.SuspendLayout();
            tsFormat.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnAccept);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(19, 749);
            panel2.Margin = new Padding(6);
            panel2.Name = "panel2";
            panel2.Size = new Size(489, 85);
            panel2.TabIndex = 15;
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
            btnCancel.Location = new Point(307, 11);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.RadioButtonGroup = "";
            btnCancel.SecondaryFont = new Font("Segoe UI", 9F);
            btnCancel.SecondaryText = "";
            btnCancel.Size = new Size(173, 60);
            btnCancel.Style = ODModules.ButtonStyle.Square;
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnCancel.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnCancel.Type = ODModules.ButtonType.Button;
            btnCancel.ButtonClicked += btnCancel_ButtonClicked;
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
            btnAccept.Location = new Point(123, 11);
            btnAccept.Margin = new Padding(6);
            btnAccept.Name = "btnAccept";
            btnAccept.RadioButtonGroup = "";
            btnAccept.SecondaryFont = new Font("Segoe UI", 9F);
            btnAccept.SecondaryText = "";
            btnAccept.Size = new Size(173, 60);
            btnAccept.Style = ODModules.ButtonStyle.Square;
            btnAccept.TabIndex = 11;
            btnAccept.Text = "Send";
            btnAccept.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnAccept.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnAccept.Type = ODModules.ButtonType.Button;
            btnAccept.ButtonClicked += btnAccept_ButtonClicked;
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
            lblpnlRegisters.Location = new Point(19, 21);
            lblpnlRegisters.Margin = new Padding(6);
            lblpnlRegisters.Name = "lblpnlRegisters";
            lblpnlRegisters.OverrideCollapseControl = false;
            lblpnlRegisters.Padding = new Padding(9, 41, 9, 11);
            lblpnlRegisters.PanelCollapsible = false;
            lblpnlRegisters.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlRegisters.SeparatorColor = Color.Gray;
            lblpnlRegisters.ShowCloseButton = false;
            lblpnlRegisters.ShowSeparator = false;
            lblpnlRegisters.Size = new Size(489, 204);
            lblpnlRegisters.TabIndex = 16;
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
            lblpnlQuantity.Location = new Point(9, 148);
            lblpnlQuantity.Margin = new Padding(6);
            lblpnlQuantity.Name = "lblpnlQuantity";
            lblpnlQuantity.OverrideCollapseControl = false;
            lblpnlQuantity.Padding = new Padding(127, 11, 0, 11);
            lblpnlQuantity.PanelCollapsible = false;
            lblpnlQuantity.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlQuantity.SeparatorColor = Color.Gray;
            lblpnlQuantity.ShowCloseButton = false;
            lblpnlQuantity.ShowSeparator = false;
            lblpnlQuantity.Size = new Size(471, 45);
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
            numtxtAddress.Location = new Point(127, 11);
            numtxtAddress.Margin = new Padding(6);
            numtxtAddress.Marked = false;
            numtxtAddress.MarkedBackColor = Color.Empty;
            numtxtAddress.MarkedBorderColor = Color.Beige;
            numericalString1.DisplayValue = "32767";
            numericalString1.Value = "32767";
            numtxtAddress.Maximum = numericalString1;
            numericalString2.DisplayValue = "0";
            numericalString2.Value = "0";
            numtxtAddress.Minimum = numericalString2;
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
            numtxtAddress.Size = new Size(344, 23);
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
            lblpnlAddress.Location = new Point(9, 103);
            lblpnlAddress.Margin = new Padding(6);
            lblpnlAddress.Name = "lblpnlAddress";
            lblpnlAddress.OverrideCollapseControl = false;
            lblpnlAddress.Padding = new Padding(127, 11, 0, 11);
            lblpnlAddress.PanelCollapsible = false;
            lblpnlAddress.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlAddress.SeparatorColor = Color.Gray;
            lblpnlAddress.ShowCloseButton = false;
            lblpnlAddress.ShowSeparator = false;
            lblpnlAddress.Size = new Size(471, 45);
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
            numtxtUnit.Location = new Point(127, 11);
            numtxtUnit.Margin = new Padding(6);
            numtxtUnit.Marked = false;
            numtxtUnit.MarkedBackColor = Color.Empty;
            numtxtUnit.MarkedBorderColor = Color.Beige;
            numericalString3.DisplayValue = "32767";
            numericalString3.Value = "32767";
            numtxtUnit.Maximum = numericalString3;
            numericalString4.DisplayValue = "0";
            numericalString4.Value = "0";
            numtxtUnit.Minimum = numericalString4;
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
            numtxtUnit.Size = new Size(344, 23);
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
            labelPanel1.Location = new Point(9, 41);
            labelPanel1.Margin = new Padding(6);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = false;
            labelPanel1.Padding = new Padding(127, 11, 0, 11);
            labelPanel1.PanelCollapsible = false;
            labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel1.SeparatorColor = Color.Gray;
            labelPanel1.ShowCloseButton = false;
            labelPanel1.ShowSeparator = false;
            labelPanel1.Size = new Size(471, 62);
            labelPanel1.TabIndex = 0;
            labelPanel1.Text = "Data Set";
            labelPanel1.Visible = false;
            // 
            // cmbxDataSet
            // 
            cmbxDataSet.Dock = DockStyle.Top;
            cmbxDataSet.FormattingEnabled = true;
            cmbxDataSet.Location = new Point(127, 11);
            cmbxDataSet.Margin = new Padding(6);
            cmbxDataSet.Name = "cmbxDataSet";
            cmbxDataSet.Size = new Size(344, 40);
            cmbxDataSet.TabIndex = 0;
            // 
            // lblpnlValue
            // 
            lblpnlValue.ArrowColor = Color.LightGray;
            lblpnlValue.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlValue.CloseColor = Color.Black;
            lblpnlValue.CloseMouseOverColor = Color.Red;
            lblpnlValue.Collapsed = false;
            lblpnlValue.Controls.Add(lstRegisters);
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
            lblpnlValue.Location = new Point(19, 319);
            lblpnlValue.Margin = new Padding(6);
            lblpnlValue.Name = "lblpnlValue";
            lblpnlValue.OverrideCollapseControl = false;
            lblpnlValue.Padding = new Padding(0, 41, 0, 0);
            lblpnlValue.PanelCollapsible = false;
            lblpnlValue.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlValue.SeparatorColor = Color.Gray;
            lblpnlValue.ShowCloseButton = false;
            lblpnlValue.ShowSeparator = false;
            lblpnlValue.Size = new Size(489, 430);
            lblpnlValue.TabIndex = 17;
            lblpnlValue.Text = "Value";
            // 
            // lstRegisters
            // 
            lstRegisters.AllowArrowKeyCellSelect = true;
            lstRegisters.AllowColumnSpanning = true;
            lstRegisters.AllowMouseWheel = true;
            lstRegisters.BorderColor = Color.Gray;
            lstRegisters.Borders = ODModules.Borders.None;
            lstRegisters.ButtonMouseDown = Color.FromArgb(100, 0, 0, 0);
            lstRegisters.ButtonMouseHover = Color.FromArgb(100, 255, 255, 255);
            lstRegisters.CellPixelFit = true;
            lstRegisters.CellSelectEditableOnly = true;
            lstRegisters.CellSelectionBorderColor = Color.Blue;
            lstRegisters.ColumnColor = Color.LightGray;
            lstRegisters.ColumnForeColor = Color.Black;
            lstRegisters.ColumnLineColor = Color.DimGray;
            column1.ColumnAlignment = ODModules.ColumnTextAlignment.Center;
            column1.CountOffset = 0;
            column1.DataFormat = ODModules.ColumnDataFormat.None;
            column1.DisplayType = ODModules.ColumnDisplayType.Text;
            column1.DropDownRight = false;
            column1.DropDownVisible = true;
            column1.Exportable = false;
            column1.ExportName = "";
            column1.FixedWidth = false;
            column1.ItemAlignment = ODModules.ItemTextAlignment.Center;
            column1.Text = "Register";
            column1.UseItemBackColor = false;
            column1.UseItemForeColor = false;
            column1.Visible = true;
            column1.Width = 80;
            column2.ColumnAlignment = ODModules.ColumnTextAlignment.Left;
            column2.CountOffset = 0;
            column2.DataFormat = ODModules.ColumnDataFormat.None;
            column2.DisplayType = ODModules.ColumnDisplayType.DropDown;
            column2.DropDownRight = false;
            column2.DropDownVisible = false;
            column2.Exportable = false;
            column2.ExportName = "";
            column2.FixedWidth = true;
            column2.ItemAlignment = ODModules.ItemTextAlignment.Right;
            column2.Text = "Value";
            column2.UseItemBackColor = false;
            column2.UseItemForeColor = false;
            column2.Visible = true;
            column2.Width = 164;
            lstRegisters.Columns.Add(column1);
            lstRegisters.Columns.Add(column2);
            lstRegisters.Dock = DockStyle.Fill;
            lstRegisters.DropDownMouseDown = Color.DimGray;
            lstRegisters.DropDownMouseOver = Color.LightGray;
            lstRegisters.ExternalItems = null;
            lstRegisters.Filter = null;
            lstRegisters.FilterColumn = 0;
            lstRegisters.FilterSearchType = ODModules.ListControl.FilterSearch.Contains;
            lstRegisters.GridlineColor = Color.LightGray;
            lstRegisters.HighlightStrength = 128;
            lstRegisters.HorizontalScrollStep = 3;
            lstRegisters.HorScroll = new decimal(new int[] { 0, 0, 0, 0 });
            lstRegisters.LineMarkerIndex = 0;
            lstRegisters.Location = new Point(0, 83);
            lstRegisters.Margin = new Padding(6);
            lstRegisters.MarkerBorderColor = Color.LimeGreen;
            lstRegisters.MarkerFillColor = Color.FromArgb(100, 50, 205, 50);
            lstRegisters.MarkerStyle = ODModules.MarkerStyleType.Highlight;
            lstRegisters.MoveControlOnCellChange = true;
            lstRegisters.Name = "lstRegisters";
            lstRegisters.RowColor = Color.LightGray;
            lstRegisters.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            lstRegisters.ScrollBarNorth = Color.DarkTurquoise;
            lstRegisters.ScrollBarSouth = Color.DeepSkyBlue;
            lstRegisters.ScrollItems = 3;
            lstRegisters.SelectedColor = Color.SkyBlue;
            lstRegisters.SelectionColor = Color.Gray;
            lstRegisters.ShadowColor = Color.FromArgb(128, 0, 0, 0);
            lstRegisters.ShowCellSelection = true;
            lstRegisters.ShowGrid = true;
            lstRegisters.ShowItemIndentation = false;
            lstRegisters.ShowMarker = false;
            lstRegisters.ShowRowColors = false;
            lstRegisters.Size = new Size(489, 347);
            lstRegisters.SpanColumn = 1;
            lstRegisters.TabIndex = 1;
            lstRegisters.UseLocalList = true;
            lstRegisters.VerScroll = 0;
            lstRegisters.Zoom = 100;
            lstRegisters.DropDownClicked += lstRegisters_DropDownClicked;
            lstRegisters.ItemClicked += lstRegisters_ItemClicked;
            lstRegisters.SelectionChanged += lstRegisters_SelectionChanged;
            lstRegisters.CellSelected += lstRegisters_CellSelected;
            lstRegisters.ValueChanged += lstRegisters_ValueChanged;
            lstRegisters.KeyPress += lstRegisters_KeyPress;
            // 
            // tsMain
            // 
            tsMain.BackColorNorth = Color.DodgerBlue;
            tsMain.BackColorSouth = Color.DodgerBlue;
            tsMain.BorderColor = Color.WhiteSmoke;
            tsMain.ImageScalingSize = new Size(32, 32);
            tsMain.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            tsMain.ItemForeColor = Color.Black;
            tsMain.Items.AddRange(new ToolStripItem[] { btnAdd, btnRemove, toolStripSeparator1, btnMoveUp, btnMoveDown });
            tsMain.ItemSelectedBackColorNorth = Color.White;
            tsMain.ItemSelectedBackColorSouth = Color.White;
            tsMain.ItemSelectedForeColor = Color.Black;
            tsMain.Location = new Point(0, 41);
            tsMain.MenuBackColorNorth = Color.DodgerBlue;
            tsMain.MenuBackColorSouth = Color.DodgerBlue;
            tsMain.MenuBorderColor = Color.WhiteSmoke;
            tsMain.MenuSeparatorColor = Color.WhiteSmoke;
            tsMain.MenuSymbolColor = Color.WhiteSmoke;
            tsMain.Name = "tsMain";
            tsMain.Padding = new Padding(0, 0, 4, 0);
            tsMain.RoundedToolStrip = false;
            tsMain.ShowBorder = false;
            tsMain.Size = new Size(489, 42);
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
            btnAdd.Size = new Size(46, 36);
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRemove.Image = (Image)resources.GetObject("btnRemove.Image");
            btnRemove.ImageScaling = ToolStripItemImageScaling.None;
            btnRemove.ImageTransparentColor = Color.Magenta;
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(46, 36);
            btnRemove.Text = "Remove";
            btnRemove.Click += btnRemove_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 42);
            // 
            // btnMoveUp
            // 
            btnMoveUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnMoveUp.Image = (Image)resources.GetObject("btnMoveUp.Image");
            btnMoveUp.ImageTransparentColor = Color.Magenta;
            btnMoveUp.Name = "btnMoveUp";
            btnMoveUp.Size = new Size(46, 36);
            btnMoveUp.Text = "Move Up";
            btnMoveUp.Click += btnMoveUp_Click;
            // 
            // btnMoveDown
            // 
            btnMoveDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnMoveDown.Image = (Image)resources.GetObject("btnMoveDown.Image");
            btnMoveDown.ImageTransparentColor = Color.Magenta;
            btnMoveDown.Name = "btnMoveDown";
            btnMoveDown.Size = new Size(46, 36);
            btnMoveDown.Text = "Move Down";
            btnMoveDown.Click += btnMoveDown_Click;
            // 
            // cmMain
            // 
            cmMain.ActionSymbolForeColor = Color.FromArgb(200, 200, 200);
            cmMain.BorderColor = Color.Black;
            cmMain.DropShadowEnabled = false;
            cmMain.ForeColor = Color.White;
            cmMain.ImageScalingSize = new Size(32, 32);
            cmMain.InsetShadowColor = Color.FromArgb(128, 0, 0, 0);
            cmMain.Items.AddRange(new ToolStripItem[] { sendToolStripMenuItem, toolStripSeparator2, addToolStripMenuItem, removeToolStripMenuItem, toolStripSeparator3, moveUpToolStripMenuItem, moveDownToolStripMenuItem, toolStripSeparator4, copyToolStripMenuItem, pasteToolStripMenuItem });
            cmMain.MenuBackColorNorth = Color.DodgerBlue;
            cmMain.MenuBackColorSouth = Color.DodgerBlue;
            cmMain.MouseOverColor = Color.FromArgb(127, 0, 0, 0);
            cmMain.Name = "cmMain";
            cmMain.SeparatorColor = Color.FromArgb(200, 200, 200);
            cmMain.ShowInsetShadow = false;
            cmMain.ShowItemInsetShadow = false;
            cmMain.Size = new Size(348, 288);
            // 
            // sendToolStripMenuItem
            // 
            sendToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            sendToolStripMenuItem.Name = "sendToolStripMenuItem";
            sendToolStripMenuItem.Size = new Size(347, 38);
            sendToolStripMenuItem.Text = "Send";
            sendToolStripMenuItem.Click += sendToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(344, 6);
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            addToolStripMenuItem.Size = new Size(347, 38);
            addToolStripMenuItem.Text = "Add";
            addToolStripMenuItem.Click += addToolStripMenuItem_Click;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.ShortcutKeys = Keys.Delete;
            removeToolStripMenuItem.Size = new Size(347, 38);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(344, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            moveUpToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            moveUpToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Up;
            moveUpToolStripMenuItem.Size = new Size(347, 38);
            moveUpToolStripMenuItem.Text = "Move Up";
            moveUpToolStripMenuItem.Click += moveUpToolStripMenuItem_Click;
            // 
            // moveDownToolStripMenuItem
            // 
            moveDownToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            moveDownToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Down;
            moveDownToolStripMenuItem.Size = new Size(347, 38);
            moveDownToolStripMenuItem.Text = "Move Down";
            moveDownToolStripMenuItem.Click += moveDownToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(344, 6);
            toolStripSeparator4.Visible = false;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(347, 38);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Visible = false;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(347, 38);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Visible = false;
            // 
            // lblpnlFormat
            // 
            lblpnlFormat.ArrowColor = Color.LightGray;
            lblpnlFormat.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlFormat.AutoSize = true;
            lblpnlFormat.CloseColor = Color.Black;
            lblpnlFormat.CloseMouseOverColor = Color.Red;
            lblpnlFormat.Collapsed = false;
            lblpnlFormat.Controls.Add(tsFormat);
            lblpnlFormat.Dock = DockStyle.Top;
            lblpnlFormat.DropShadow = false;
            lblpnlFormat.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlFormat.FixedInlineWidth = false;
            lblpnlFormat.ForeColor = Color.White;
            lblpnlFormat.Inlinelabel = false;
            lblpnlFormat.InlineWidth = 100;
            lblpnlFormat.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlFormat.LabelFont = new Font("Segoe UI", 8F);
            lblpnlFormat.LabelForeColor = Color.WhiteSmoke;
            lblpnlFormat.Location = new Point(19, 225);
            lblpnlFormat.Margin = new Padding(6);
            lblpnlFormat.Name = "lblpnlFormat";
            lblpnlFormat.OverrideCollapseControl = false;
            lblpnlFormat.Padding = new Padding(0, 41, 0, 11);
            lblpnlFormat.PanelCollapsible = false;
            lblpnlFormat.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlFormat.SeparatorColor = Color.Gray;
            lblpnlFormat.ShowCloseButton = false;
            lblpnlFormat.ShowSeparator = false;
            lblpnlFormat.Size = new Size(489, 94);
            lblpnlFormat.TabIndex = 18;
            lblpnlFormat.Text = "Format";
            // 
            // tsFormat
            // 
            tsFormat.BackColorNorth = Color.DodgerBlue;
            tsFormat.BackColorSouth = Color.DodgerBlue;
            tsFormat.BorderColor = Color.WhiteSmoke;
            tsFormat.GripStyle = ToolStripGripStyle.Hidden;
            tsFormat.ImageScalingSize = new Size(32, 32);
            tsFormat.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            tsFormat.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            tsFormat.ItemForeColor = Color.Black;
            tsFormat.Items.AddRange(new ToolStripItem[] { ddbFormat, toolStripSeparator5, ddbSize, btnSign });
            tsFormat.ItemSelectedBackColorNorth = Color.White;
            tsFormat.ItemSelectedBackColorSouth = Color.White;
            tsFormat.ItemSelectedForeColor = Color.Black;
            tsFormat.Location = new Point(0, 41);
            tsFormat.MenuBackColorNorth = Color.DodgerBlue;
            tsFormat.MenuBackColorSouth = Color.DodgerBlue;
            tsFormat.MenuBorderColor = Color.WhiteSmoke;
            tsFormat.MenuSeparatorColor = Color.WhiteSmoke;
            tsFormat.MenuSymbolColor = Color.WhiteSmoke;
            tsFormat.Name = "tsFormat";
            tsFormat.Padding = new Padding(0, 0, 4, 0);
            tsFormat.RoundedToolStrip = false;
            tsFormat.ShowBorder = false;
            tsFormat.Size = new Size(489, 42);
            tsFormat.StripItemSelectedBackColorNorth = Color.White;
            tsFormat.StripItemSelectedBackColorSouth = Color.White;
            tsFormat.TabIndex = 0;
            tsFormat.Text = "toolStrip1";
            // 
            // ddbFormat
            // 
            ddbFormat.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ddbFormat.Image = (Image)resources.GetObject("ddbFormat.Image");
            ddbFormat.ImageScaling = ToolStripItemImageScaling.None;
            ddbFormat.ImageTransparentColor = Color.Magenta;
            ddbFormat.Name = "ddbFormat";
            ddbFormat.Size = new Size(112, 36);
            ddbFormat.Text = "Integer";
            ddbFormat.ToolTipText = "Format";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 42);
            // 
            // ddbSize
            // 
            ddbSize.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ddbSize.Image = (Image)resources.GetObject("ddbSize.Image");
            ddbSize.ImageTransparentColor = Color.Magenta;
            ddbSize.Name = "ddbSize";
            ddbSize.Size = new Size(107, 36);
            ddbSize.Text = "16 Bits";
            ddbSize.ToolTipText = "Data Size";
            // 
            // btnSign
            // 
            btnSign.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSign.Image = (Image)resources.GetObject("btnSign.Image");
            btnSign.ImageTransparentColor = Color.Magenta;
            btnSign.Name = "btnSign";
            btnSign.Size = new Size(119, 36);
            btnSign.Text = "Unsigned";
            btnSign.ToolTipText = "Signed";
            btnSign.Click += btnSize_Click;
            // 
            // WriteRegisters
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 855);
            ContextMenuStrip = cmMain;
            Controls.Add(lblpnlValue);
            Controls.Add(lblpnlFormat);
            Controls.Add(lblpnlRegisters);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(0, 0);
            Margin = new Padding(6);
            Name = "WriteRegisters";
            Padding = new Padding(19, 21, 19, 21);
            ShowInTaskbar = false;
            Text = "Write Registers";
            FormClosing += WriteRegisters_FormClosing;
            Load += WriteRegisters_Load;
            panel2.ResumeLayout(false);
            lblpnlRegisters.ResumeLayout(false);
            lblpnlRegisters.PerformLayout();
            lblpnlQuantity.ResumeLayout(false);
            lblpnlAddress.ResumeLayout(false);
            labelPanel1.ResumeLayout(false);
            lblpnlValue.ResumeLayout(false);
            lblpnlValue.PerformLayout();
            tsMain.ResumeLayout(false);
            tsMain.PerformLayout();
            cmMain.ResumeLayout(false);
            lblpnlFormat.ResumeLayout(false);
            lblpnlFormat.PerformLayout();
            tsFormat.ResumeLayout(false);
            tsFormat.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel2;
        private ODModules.Button btnAccept;
        private ODModules.LabelPanel lblpnlRegisters;
        private ODModules.LabelPanel lblpnlQuantity;
        private ODModules.NumericTextbox numtxtAddress;
        private ODModules.LabelPanel lblpnlAddress;
        private ODModules.NumericTextbox numtxtUnit;
        private ODModules.LabelPanel labelPanel1;
        private ODModules.FlatComboBox cmbxDataSet;
        private ODModules.LabelPanel lblpnlValue;
        private ODModules.ListControl lstRegisters;
        private ODModules.ToolStrip tsMain;
        private ToolStripButton btnAdd;
        private ToolStripButton btnRemove;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnMoveUp;
        private ToolStripButton btnMoveDown;
        private ODModules.Button btnCancel;
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
        private ODModules.LabelPanel lblpnlFormat;
        private ODModules.ToolStrip tsFormat;
        private ToolStripDropDownButton ddbFormat;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton btnSign;
        private ToolStripDropDownButton ddbSize;
    }
}