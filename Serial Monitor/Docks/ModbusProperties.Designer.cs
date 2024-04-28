namespace Serial_Monitor.Docks {
    partial class ModbusProperties {
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
            Handlers.NumericalString numericalString1 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString2 = new Handlers.NumericalString();
            panel1 = new Panel();
            panel2 = new Panel();
            labelPanel1 = new ODModules.LabelPanel();
            cwMain = new ODModules.ColorWheel();
            lcsBrightness = new ODModules.LightnessColorSlider();
            lblpnlUnits = new ODModules.LabelPanel();
            pfsMain = new ODModules.PrefixScale();
            ntbMain = new ODModules.NumericTextbox();
            labelPanel3 = new ODModules.LabelPanel();
            labelPanel2 = new ODModules.LabelPanel();
            tbUnit = new ODModules.TextBox();
            lblpnlFormat = new ODModules.LabelPanel();
            lblpnlEndianess = new ODModules.LabelPanel();
            ddlEndianness = new ODModules.DropDownBox();
            lblpnlSize = new ODModules.LabelPanel();
            toolStrip1 = new ODModules.ToolStrip();
            lblpnlDisplay = new ODModules.LabelPanel();
            ddlDisplay = new ODModules.DropDownBox();
            lblpnlBoolDisplay = new ODModules.LabelPanel();
            ddlBooleanDisplay = new ODModules.DropDownBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            labelPanel1.SuspendLayout();
            lblpnlUnits.SuspendLayout();
            labelPanel2.SuspendLayout();
            lblpnlFormat.SuspendLayout();
            lblpnlEndianess.SuspendLayout();
            lblpnlSize.SuspendLayout();
            lblpnlDisplay.SuspendLayout();
            lblpnlBoolDisplay.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(1, 25);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3);
            panel1.Size = new Size(249, 475);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(labelPanel1);
            panel2.Controls.Add(lblpnlUnits);
            panel2.Controls.Add(lblpnlFormat);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(243, 469);
            panel2.TabIndex = 0;
            // 
            // labelPanel1
            // 
            labelPanel1.ArrowColor = Color.Black;
            labelPanel1.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel1.CloseColor = Color.Black;
            labelPanel1.CloseMouseOverColor = Color.Red;
            labelPanel1.Collapsed = false;
            labelPanel1.Controls.Add(cwMain);
            labelPanel1.Controls.Add(lcsBrightness);
            labelPanel1.Dock = DockStyle.Top;
            labelPanel1.DropShadow = false;
            labelPanel1.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel1.FixedInlineWidth = false;
            labelPanel1.Inlinelabel = false;
            labelPanel1.InlineWidth = 100;
            labelPanel1.LabelBackColor = Color.White;
            labelPanel1.LabelFont = new Font("Segoe UI", 8F);
            labelPanel1.LabelForeColor = Color.Black;
            labelPanel1.Location = new Point(0, 305);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = true;
            labelPanel1.Padding = new Padding(0, 22, 0, 0);
            labelPanel1.PanelCollapsible = true;
            labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel1.SeparatorColor = Color.Gray;
            labelPanel1.ShowCloseButton = false;
            labelPanel1.ShowSeparator = true;
            labelPanel1.Size = new Size(243, 141);
            labelPanel1.TabIndex = 2;
            labelPanel1.Text = "Appearance";
            // 
            // cwMain
            // 
            cwMain.Alpha = 1D;
            cwMain.Dock = DockStyle.Right;
            cwMain.Location = new Point(98, 22);
            cwMain.Name = "cwMain";
            cwMain.ShowSaturationRing = true;
            cwMain.Size = new Size(126, 119);
            cwMain.TabIndex = 1;
            // 
            // lcsBrightness
            // 
            lcsBrightness.Dock = DockStyle.Right;
            lcsBrightness.Location = new Point(224, 22);
            lcsBrightness.Name = "lcsBrightness";
            lcsBrightness.Orientation = Orientation.Vertical;
            lcsBrightness.Size = new Size(19, 119);
            lcsBrightness.TabIndex = 7;
            // 
            // lblpnlUnits
            // 
            lblpnlUnits.ArrowColor = Color.Black;
            lblpnlUnits.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlUnits.CloseColor = Color.Black;
            lblpnlUnits.CloseMouseOverColor = Color.Red;
            lblpnlUnits.Collapsed = false;
            lblpnlUnits.Controls.Add(pfsMain);
            lblpnlUnits.Controls.Add(labelPanel3);
            lblpnlUnits.Controls.Add(labelPanel2);
            lblpnlUnits.Controls.Add(ntbMain);
            lblpnlUnits.Dock = DockStyle.Top;
            lblpnlUnits.DropShadow = false;
            lblpnlUnits.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlUnits.FixedInlineWidth = false;
            lblpnlUnits.Inlinelabel = false;
            lblpnlUnits.InlineWidth = 100;
            lblpnlUnits.LabelBackColor = Color.White;
            lblpnlUnits.LabelFont = new Font("Segoe UI", 8F);
            lblpnlUnits.LabelForeColor = Color.Black;
            lblpnlUnits.Location = new Point(0, 125);
            lblpnlUnits.Name = "lblpnlUnits";
            lblpnlUnits.OverrideCollapseControl = true;
            lblpnlUnits.Padding = new Padding(0, 22, 0, 0);
            lblpnlUnits.PanelCollapsible = true;
            lblpnlUnits.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlUnits.SeparatorColor = Color.Gray;
            lblpnlUnits.ShowCloseButton = false;
            lblpnlUnits.ShowSeparator = true;
            lblpnlUnits.Size = new Size(243, 180);
            lblpnlUnits.TabIndex = 1;
            lblpnlUnits.Text = "Unit of Measure";
            // 
            // pfsMain
            // 
            pfsMain.Dock = DockStyle.Top;
            pfsMain.DownColor = Color.FromArgb(255, 128, 0);
            pfsMain.HoverColor = Color.FromArgb(255, 255, 192);
            pfsMain.InactiveForecolor = Color.Gray;
            pfsMain.LinkedNumericControl = ntbMain;
            pfsMain.Location = new Point(0, 97);
            pfsMain.Name = "pfsMain";
            pfsMain.Size = new Size(243, 53);
            pfsMain.TabIndex = 0;
            // 
            // ntbMain
            // 
            ntbMain.AllowClipboard = true;
            ntbMain.AllowDragValueChange = true;
            ntbMain.AllowFractionals = true;
            ntbMain.AllowMouseWheel = true;
            ntbMain.AllowNegatives = true;
            ntbMain.AllowNumberEntry = true;
            ntbMain.AllowTyping = true;
            ntbMain.ArrowKeysControlNumber = true;
            ntbMain.AutoSizeToText = false;
            ntbMain.Base = ODModules.NumericTextbox.NumberBase.Base10;
            ntbMain.BorderColor = Color.DimGray;
            ntbMain.ButtonDownColor = Color.Gray;
            ntbMain.ButtonHoverColor = Color.LightGray;
            ntbMain.Dock = DockStyle.Top;
            ntbMain.FixedNumericPadding = 5;
            ntbMain.FormatOutput = true;
            ntbMain.HasUnit = true;
            ntbMain.IsMetric = true;
            ntbMain.IsSecondaryMetric = false;
            ntbMain.LabelFont = new Font("Segoe UI", 9F);
            ntbMain.LabelForeColor = Color.Gray;
            ntbMain.LabelText = "";
            ntbMain.Location = new Point(0, 22);
            ntbMain.Marked = false;
            ntbMain.MarkedBackColor = Color.Empty;
            ntbMain.MarkedBorderColor = Color.Beige;
            numericalString1.DisplayValue = "100";
            numericalString1.Value = "100";
            ntbMain.Maximum = numericalString1;
            numericalString2.DisplayValue = "0";
            numericalString2.Value = "0";
            ntbMain.Minimum = numericalString2;
            ntbMain.Name = "ntbMain";
            ntbMain.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Right;
            ntbMain.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            ntbMain.NumericalLeftRadixDigitsMaximum = 7;
            ntbMain.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            ntbMain.RangeLimited = false;
            ntbMain.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            ntbMain.SecondaryTag = null;
            ntbMain.SecondaryUnit = "";
            ntbMain.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            ntbMain.SelectedBackColor = Color.Empty;
            ntbMain.SelectedBorderColor = Color.Beige;
            ntbMain.ShowLabel = true;
            ntbMain.Size = new Size(243, 27);
            ntbMain.TabIndex = 1;
            ntbMain.Unit = "";
            ntbMain.UseFixedNumericPadding = true;
            ntbMain.Value = "0";
            ntbMain.Visible = false;
            ntbMain.PrefixChanged += ntbMain_PrefixChanged;
            // 
            // labelPanel3
            // 
            labelPanel3.ArrowColor = Color.Black;
            labelPanel3.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel3.CloseColor = Color.Black;
            labelPanel3.CloseMouseOverColor = Color.Red;
            labelPanel3.Collapsed = false;
            labelPanel3.Dock = DockStyle.Top;
            labelPanel3.DropShadow = false;
            labelPanel3.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel3.FixedInlineWidth = true;
            labelPanel3.Inlinelabel = true;
            labelPanel3.InlineWidth = 50;
            labelPanel3.LabelBackColor = Color.White;
            labelPanel3.LabelFont = new Font("Segoe UI", 8F);
            labelPanel3.LabelForeColor = Color.White;
            labelPanel3.Location = new Point(0, 73);
            labelPanel3.Name = "labelPanel3";
            labelPanel3.OverrideCollapseControl = false;
            labelPanel3.Padding = new Padding(63, 5, 5, 5);
            labelPanel3.PanelCollapsible = true;
            labelPanel3.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel3.SeparatorColor = Color.Gray;
            labelPanel3.ShowCloseButton = true;
            labelPanel3.ShowSeparator = false;
            labelPanel3.Size = new Size(243, 24);
            labelPanel3.TabIndex = 3;
            labelPanel3.Text = "Prefix";
            // 
            // labelPanel2
            // 
            labelPanel2.ArrowColor = Color.Black;
            labelPanel2.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel2.CloseColor = Color.Black;
            labelPanel2.CloseMouseOverColor = Color.Red;
            labelPanel2.Collapsed = false;
            labelPanel2.Controls.Add(tbUnit);
            labelPanel2.Dock = DockStyle.Top;
            labelPanel2.DropShadow = false;
            labelPanel2.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel2.FixedInlineWidth = true;
            labelPanel2.Inlinelabel = true;
            labelPanel2.InlineWidth = 80;
            labelPanel2.LabelBackColor = Color.White;
            labelPanel2.LabelFont = new Font("Segoe UI", 8F);
            labelPanel2.LabelForeColor = Color.White;
            labelPanel2.Location = new Point(0, 49);
            labelPanel2.Name = "labelPanel2";
            labelPanel2.OverrideCollapseControl = false;
            labelPanel2.Padding = new Padding(93, 0, 0, 0);
            labelPanel2.PanelCollapsible = true;
            labelPanel2.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel2.SeparatorColor = Color.Gray;
            labelPanel2.ShowCloseButton = true;
            labelPanel2.ShowSeparator = false;
            labelPanel2.Size = new Size(243, 24);
            labelPanel2.TabIndex = 2;
            labelPanel2.Text = "Unit";
            labelPanel2.Paint += labelPanel2_Paint;
            // 
            // tbUnit
            // 
            tbUnit.AutoCompleteMode = AutoCompleteMode.None;
            tbUnit.AutoCompleteSource = AutoCompleteSource.None;
            tbUnit.BackColor = SystemColors.Window;
            tbUnit.BorderColor = Color.MediumSlateBlue;
            tbUnit.BorderSize = 1;
            tbUnit.Dock = DockStyle.Fill;
            tbUnit.Font = new Font("Segoe UI", 9F);
            tbUnit.ForeColor = Color.DimGray;
            tbUnit.Location = new Point(93, 0);
            tbUnit.Margin = new Padding(4);
            tbUnit.MaxLength = 32767;
            tbUnit.Multiline = false;
            tbUnit.Name = "tbUnit";
            tbUnit.Padding = new Padding(7);
            tbUnit.PasswordChar = '\0';
            tbUnit.PlaceholderText = "";
            tbUnit.ReadOnly = false;
            tbUnit.SelectedBackColor = Color.LightGray;
            tbUnit.SelectedBorderColor = Color.HotPink;
            tbUnit.ShortcutsEnabled = true;
            tbUnit.Size = new Size(150, 30);
            tbUnit.TabIndex = 0;
            tbUnit.TextAlign = HorizontalAlignment.Left;
            tbUnit.UnderlinedStyle = false;
            tbUnit.UseSystemPasswordChar = false;
            tbUnit.WordWrap = true;
            tbUnit._TextChanged += tbUnit__TextChanged;
            // 
            // lblpnlFormat
            // 
            lblpnlFormat.ArrowColor = Color.Black;
            lblpnlFormat.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlFormat.AutoSize = true;
            lblpnlFormat.CloseColor = Color.Black;
            lblpnlFormat.CloseMouseOverColor = Color.Red;
            lblpnlFormat.Collapsed = false;
            lblpnlFormat.Controls.Add(lblpnlEndianess);
            lblpnlFormat.Controls.Add(lblpnlSize);
            lblpnlFormat.Controls.Add(lblpnlDisplay);
            lblpnlFormat.Controls.Add(lblpnlBoolDisplay);
            lblpnlFormat.Dock = DockStyle.Top;
            lblpnlFormat.DropShadow = false;
            lblpnlFormat.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlFormat.FixedInlineWidth = false;
            lblpnlFormat.Inlinelabel = false;
            lblpnlFormat.InlineWidth = 100;
            lblpnlFormat.LabelBackColor = Color.White;
            lblpnlFormat.LabelFont = new Font("Segoe UI", 8F);
            lblpnlFormat.LabelForeColor = Color.Black;
            lblpnlFormat.Location = new Point(0, 0);
            lblpnlFormat.Name = "lblpnlFormat";
            lblpnlFormat.OverrideCollapseControl = true;
            lblpnlFormat.Padding = new Padding(0, 22, 0, 5);
            lblpnlFormat.PanelCollapsible = true;
            lblpnlFormat.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlFormat.SeparatorColor = Color.Gray;
            lblpnlFormat.ShowCloseButton = false;
            lblpnlFormat.ShowSeparator = true;
            lblpnlFormat.Size = new Size(243, 125);
            lblpnlFormat.TabIndex = 0;
            lblpnlFormat.Text = "Format";
            // 
            // lblpnlEndianess
            // 
            lblpnlEndianess.ArrowColor = Color.Black;
            lblpnlEndianess.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlEndianess.CloseColor = Color.Black;
            lblpnlEndianess.CloseMouseOverColor = Color.Red;
            lblpnlEndianess.Collapsed = false;
            lblpnlEndianess.Controls.Add(ddlEndianness);
            lblpnlEndianess.Dock = DockStyle.Top;
            lblpnlEndianess.DropShadow = false;
            lblpnlEndianess.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlEndianess.FixedInlineWidth = true;
            lblpnlEndianess.Inlinelabel = true;
            lblpnlEndianess.InlineWidth = 80;
            lblpnlEndianess.LabelBackColor = Color.White;
            lblpnlEndianess.LabelFont = new Font("Segoe UI", 8F);
            lblpnlEndianess.LabelForeColor = Color.White;
            lblpnlEndianess.Location = new Point(0, 95);
            lblpnlEndianess.Name = "lblpnlEndianess";
            lblpnlEndianess.OverrideCollapseControl = false;
            lblpnlEndianess.Padding = new Padding(93, 0, 0, 0);
            lblpnlEndianess.PanelCollapsible = true;
            lblpnlEndianess.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlEndianess.SeparatorColor = Color.Gray;
            lblpnlEndianess.ShowCloseButton = true;
            lblpnlEndianess.ShowSeparator = false;
            lblpnlEndianess.Size = new Size(243, 25);
            lblpnlEndianess.TabIndex = 2;
            lblpnlEndianess.Text = "Endianness";
            // 
            // ddlEndianness
            // 
            ddlEndianness.ArrowColor = Color.Black;
            ddlEndianness.BorderColor = Color.Gray;
            ddlEndianness.Dock = DockStyle.Top;
            ddlEndianness.DrawMode = DrawMode.OwnerDrawFixed;
            ddlEndianness.FlatStyle = FlatStyle.Flat;
            ddlEndianness.FormattingEnabled = true;
            ddlEndianness.Location = new Point(93, 0);
            ddlEndianness.Name = "ddlEndianness";
            ddlEndianness.SelectedBackColor = Color.LightGray;
            ddlEndianness.SelectedBorderColor = Color.BlueViolet;
            ddlEndianness.SelectedColor = Color.SteelBlue;
            ddlEndianness.SelectedForeColor = Color.DimGray;
            ddlEndianness.Size = new Size(150, 24);
            ddlEndianness.TabIndex = 4;
            ddlEndianness.SelectedIndexChanged += ddlEndianness_SelectedIndexChanged;
            // 
            // lblpnlSize
            // 
            lblpnlSize.ArrowColor = Color.Black;
            lblpnlSize.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlSize.AutoSize = true;
            lblpnlSize.CloseColor = Color.Black;
            lblpnlSize.CloseMouseOverColor = Color.Red;
            lblpnlSize.Collapsed = false;
            lblpnlSize.Controls.Add(toolStrip1);
            lblpnlSize.Dock = DockStyle.Top;
            lblpnlSize.DropShadow = false;
            lblpnlSize.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlSize.FixedInlineWidth = true;
            lblpnlSize.Inlinelabel = true;
            lblpnlSize.InlineWidth = 80;
            lblpnlSize.LabelBackColor = Color.White;
            lblpnlSize.LabelFont = new Font("Segoe UI", 8F);
            lblpnlSize.LabelForeColor = Color.White;
            lblpnlSize.Location = new Point(0, 70);
            lblpnlSize.Name = "lblpnlSize";
            lblpnlSize.OverrideCollapseControl = false;
            lblpnlSize.Padding = new Padding(93, 0, 0, 0);
            lblpnlSize.PanelCollapsible = true;
            lblpnlSize.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlSize.SeparatorColor = Color.Gray;
            lblpnlSize.ShowCloseButton = true;
            lblpnlSize.ShowSeparator = false;
            lblpnlSize.Size = new Size(243, 25);
            lblpnlSize.TabIndex = 1;
            lblpnlSize.Text = "Size";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColorNorth = Color.DodgerBlue;
            toolStrip1.BackColorSouth = Color.DodgerBlue;
            toolStrip1.BorderColor = Color.WhiteSmoke;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            toolStrip1.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            toolStrip1.ItemForeColor = Color.Black;
            toolStrip1.ItemSelectedBackColorNorth = Color.White;
            toolStrip1.ItemSelectedBackColorSouth = Color.White;
            toolStrip1.ItemSelectedForeColor = Color.Black;
            toolStrip1.Location = new Point(93, 0);
            toolStrip1.MenuBackColorNorth = Color.DodgerBlue;
            toolStrip1.MenuBackColorSouth = Color.DodgerBlue;
            toolStrip1.MenuBorderColor = Color.WhiteSmoke;
            toolStrip1.MenuSeparatorColor = Color.WhiteSmoke;
            toolStrip1.MenuSymbolColor = Color.WhiteSmoke;
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(1, 0, 1, 0);
            toolStrip1.RoundedToolStrip = false;
            toolStrip1.ShowBorder = false;
            toolStrip1.Size = new Size(150, 25);
            toolStrip1.StripItemSelectedBackColorNorth = Color.White;
            toolStrip1.StripItemSelectedBackColorSouth = Color.White;
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // lblpnlDisplay
            // 
            lblpnlDisplay.ArrowColor = Color.Black;
            lblpnlDisplay.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlDisplay.AutoSize = true;
            lblpnlDisplay.CloseColor = Color.Black;
            lblpnlDisplay.CloseMouseOverColor = Color.Red;
            lblpnlDisplay.Collapsed = false;
            lblpnlDisplay.Controls.Add(ddlDisplay);
            lblpnlDisplay.Dock = DockStyle.Top;
            lblpnlDisplay.DropShadow = false;
            lblpnlDisplay.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlDisplay.FixedInlineWidth = true;
            lblpnlDisplay.Inlinelabel = true;
            lblpnlDisplay.InlineWidth = 80;
            lblpnlDisplay.LabelBackColor = Color.White;
            lblpnlDisplay.LabelFont = new Font("Segoe UI", 8F);
            lblpnlDisplay.LabelForeColor = Color.White;
            lblpnlDisplay.Location = new Point(0, 46);
            lblpnlDisplay.Name = "lblpnlDisplay";
            lblpnlDisplay.OverrideCollapseControl = false;
            lblpnlDisplay.Padding = new Padding(93, 0, 0, 0);
            lblpnlDisplay.PanelCollapsible = true;
            lblpnlDisplay.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlDisplay.SeparatorColor = Color.Gray;
            lblpnlDisplay.ShowCloseButton = true;
            lblpnlDisplay.ShowSeparator = false;
            lblpnlDisplay.Size = new Size(243, 24);
            lblpnlDisplay.TabIndex = 0;
            lblpnlDisplay.Text = "Display";
            // 
            // ddlDisplay
            // 
            ddlDisplay.ArrowColor = Color.Black;
            ddlDisplay.BorderColor = Color.Gray;
            ddlDisplay.Dock = DockStyle.Top;
            ddlDisplay.DrawMode = DrawMode.OwnerDrawFixed;
            ddlDisplay.FlatStyle = FlatStyle.Flat;
            ddlDisplay.FormattingEnabled = true;
            ddlDisplay.Location = new Point(93, 0);
            ddlDisplay.Name = "ddlDisplay";
            ddlDisplay.SelectedBackColor = Color.LightGray;
            ddlDisplay.SelectedBorderColor = Color.BlueViolet;
            ddlDisplay.SelectedColor = Color.SteelBlue;
            ddlDisplay.SelectedForeColor = Color.DimGray;
            ddlDisplay.Size = new Size(150, 24);
            ddlDisplay.TabIndex = 3;
            ddlDisplay.SelectedIndexChanged += ddlDisplay_SelectedIndexChanged;
            // 
            // lblpnlBoolDisplay
            // 
            lblpnlBoolDisplay.ArrowColor = Color.Black;
            lblpnlBoolDisplay.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlBoolDisplay.AutoSize = true;
            lblpnlBoolDisplay.CloseColor = Color.Black;
            lblpnlBoolDisplay.CloseMouseOverColor = Color.Red;
            lblpnlBoolDisplay.Collapsed = false;
            lblpnlBoolDisplay.Controls.Add(ddlBooleanDisplay);
            lblpnlBoolDisplay.Dock = DockStyle.Top;
            lblpnlBoolDisplay.DropShadow = false;
            lblpnlBoolDisplay.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlBoolDisplay.FixedInlineWidth = true;
            lblpnlBoolDisplay.Inlinelabel = true;
            lblpnlBoolDisplay.InlineWidth = 80;
            lblpnlBoolDisplay.LabelBackColor = Color.White;
            lblpnlBoolDisplay.LabelFont = new Font("Segoe UI", 8F);
            lblpnlBoolDisplay.LabelForeColor = Color.White;
            lblpnlBoolDisplay.Location = new Point(0, 22);
            lblpnlBoolDisplay.Name = "lblpnlBoolDisplay";
            lblpnlBoolDisplay.OverrideCollapseControl = false;
            lblpnlBoolDisplay.Padding = new Padding(93, 0, 0, 0);
            lblpnlBoolDisplay.PanelCollapsible = true;
            lblpnlBoolDisplay.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlBoolDisplay.SeparatorColor = Color.Gray;
            lblpnlBoolDisplay.ShowCloseButton = true;
            lblpnlBoolDisplay.ShowSeparator = false;
            lblpnlBoolDisplay.Size = new Size(243, 24);
            lblpnlBoolDisplay.TabIndex = 3;
            lblpnlBoolDisplay.Text = "Display";
            // 
            // ddlBooleanDisplay
            // 
            ddlBooleanDisplay.ArrowColor = Color.Black;
            ddlBooleanDisplay.BorderColor = Color.Gray;
            ddlBooleanDisplay.Dock = DockStyle.Top;
            ddlBooleanDisplay.DrawMode = DrawMode.OwnerDrawFixed;
            ddlBooleanDisplay.FlatStyle = FlatStyle.Flat;
            ddlBooleanDisplay.FormattingEnabled = true;
            ddlBooleanDisplay.Location = new Point(93, 0);
            ddlBooleanDisplay.Name = "ddlBooleanDisplay";
            ddlBooleanDisplay.SelectedBackColor = Color.LightGray;
            ddlBooleanDisplay.SelectedBorderColor = Color.BlueViolet;
            ddlBooleanDisplay.SelectedColor = Color.SteelBlue;
            ddlBooleanDisplay.SelectedForeColor = Color.DimGray;
            ddlBooleanDisplay.Size = new Size(150, 24);
            ddlBooleanDisplay.TabIndex = 3;
            ddlBooleanDisplay.SelectedIndexChanged += ddlBooleanDisplay_SelectedIndexChanged;
            // 
            // ModbusProperties
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            DefaultDockArea = ODModules.Docking.DockArea.Right;
            DockText = "Properties";
            Name = "ModbusProperties";
            Size = new Size(251, 501);
            Load += ModbusProperties_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            labelPanel1.ResumeLayout(false);
            lblpnlUnits.ResumeLayout(false);
            labelPanel2.ResumeLayout(false);
            lblpnlFormat.ResumeLayout(false);
            lblpnlFormat.PerformLayout();
            lblpnlEndianess.ResumeLayout(false);
            lblpnlSize.ResumeLayout(false);
            lblpnlSize.PerformLayout();
            lblpnlDisplay.ResumeLayout(false);
            lblpnlBoolDisplay.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private ODModules.LabelPanel lblpnlFormat;
        private ODModules.LabelPanel lblpnlUnits;
        private ODModules.PrefixScale pfsMain;
        private ODModules.NumericTextbox ntbMain;
        private ODModules.LabelPanel labelPanel1;
        private ODModules.LabelPanel lblpnlDisplay;
        private ODModules.LabelPanel lblpnlSize;
        private ODModules.ToolStrip toolStrip1;
        private ODModules.LabelPanel labelPanel2;
        private ODModules.LabelPanel lblpnlEndianess;
        private ODModules.DropDownBox ddlDisplay;
        private ODModules.DropDownBox ddlEndianness;
        private ODModules.ColorWheel cwMain;
        private ODModules.LightnessColorSlider lcsBrightness;
        private ODModules.LabelPanel labelPanel3;
        private ODModules.TextBox tbUnit;
        private ODModules.LabelPanel lblpnlBoolDisplay;
        private ODModules.DropDownBox ddlBooleanDisplay;
    }
}
