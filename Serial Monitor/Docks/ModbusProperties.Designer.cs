﻿namespace Serial_Monitor.Docks {
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
            Handlers.NumericalString numericalString3 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString4 = new Handlers.NumericalString();
            panel1 = new Panel();
            panel2 = new Panel();
            lblpnlSnapshot = new ODModules.LabelPanel();
            lblpnlSnapshotName = new ODModules.LabelPanel();
            tbSnapshotName = new ODModules.TextBox();
            lblpnlAppearance = new ODModules.LabelPanel();
            labelPanel5 = new ODModules.LabelPanel();
            btnBackColor = new ODModules.Button();
            labelPanel4 = new ODModules.LabelPanel();
            btnTextColor = new ODModules.Button();
            lblpnlUnits = new ODModules.LabelPanel();
            pfsMain = new ODModules.PrefixScale();
            ntbMain = new ODModules.NumericTextbox();
            labelPanel3 = new ODModules.LabelPanel();
            labelPanel2 = new ODModules.LabelPanel();
            tbUnit = new ODModules.TextBox();
            lblpnlFormat = new ODModules.LabelPanel();
            lblpnlDecimalFormat = new ODModules.LabelPanel();
            ddlDecimalPlaces = new ODModules.DropDownBox();
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
            lblpnlSnapshot.SuspendLayout();
            lblpnlSnapshotName.SuspendLayout();
            lblpnlAppearance.SuspendLayout();
            labelPanel5.SuspendLayout();
            labelPanel4.SuspendLayout();
            lblpnlUnits.SuspendLayout();
            labelPanel2.SuspendLayout();
            lblpnlFormat.SuspendLayout();
            lblpnlDecimalFormat.SuspendLayout();
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
            panel1.Margin = new Padding(6);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(6);
            panel1.Size = new Size(481, 1629);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Controls.Add(lblpnlSnapshot);
            panel2.Controls.Add(lblpnlAppearance);
            panel2.Controls.Add(lblpnlUnits);
            panel2.Controls.Add(lblpnlFormat);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(6, 6);
            panel2.Margin = new Padding(6);
            panel2.Name = "panel2";
            panel2.Size = new Size(469, 1617);
            panel2.TabIndex = 0;
            // 
            // lblpnlSnapshot
            // 
            lblpnlSnapshot.ArrowColor = Color.Black;
            lblpnlSnapshot.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlSnapshot.AutoSize = true;
            lblpnlSnapshot.CloseColor = Color.Black;
            lblpnlSnapshot.CloseMouseOverColor = Color.Red;
            lblpnlSnapshot.Collapsed = false;
            lblpnlSnapshot.Controls.Add(lblpnlSnapshotName);
            lblpnlSnapshot.Dock = DockStyle.Top;
            lblpnlSnapshot.DropShadow = false;
            lblpnlSnapshot.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlSnapshot.FixedInlineWidth = false;
            lblpnlSnapshot.Inlinelabel = false;
            lblpnlSnapshot.InlineWidth = 100;
            lblpnlSnapshot.LabelBackColor = Color.White;
            lblpnlSnapshot.LabelFont = new Font("Segoe UI", 8F);
            lblpnlSnapshot.LabelForeColor = Color.Black;
            lblpnlSnapshot.Location = new Point(0, 740);
            lblpnlSnapshot.Margin = new Padding(6);
            lblpnlSnapshot.Name = "lblpnlSnapshot";
            lblpnlSnapshot.OverrideCollapseControl = true;
            lblpnlSnapshot.Padding = new Padding(0, 41, 0, 0);
            lblpnlSnapshot.PanelCollapsible = true;
            lblpnlSnapshot.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlSnapshot.SeparatorColor = Color.Gray;
            lblpnlSnapshot.ShowCloseButton = false;
            lblpnlSnapshot.ShowSeparator = true;
            lblpnlSnapshot.Size = new Size(469, 92);
            lblpnlSnapshot.TabIndex = 3;
            lblpnlSnapshot.Text = "Snapshot";
            // 
            // lblpnlSnapshotName
            // 
            lblpnlSnapshotName.ArrowColor = Color.Black;
            lblpnlSnapshotName.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlSnapshotName.CloseColor = Color.Black;
            lblpnlSnapshotName.CloseMouseOverColor = Color.Red;
            lblpnlSnapshotName.Collapsed = false;
            lblpnlSnapshotName.Controls.Add(tbSnapshotName);
            lblpnlSnapshotName.Dock = DockStyle.Top;
            lblpnlSnapshotName.DropShadow = false;
            lblpnlSnapshotName.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlSnapshotName.FixedInlineWidth = true;
            lblpnlSnapshotName.Inlinelabel = true;
            lblpnlSnapshotName.InlineWidth = 80;
            lblpnlSnapshotName.LabelBackColor = Color.White;
            lblpnlSnapshotName.LabelFont = new Font("Segoe UI", 8F);
            lblpnlSnapshotName.LabelForeColor = Color.White;
            lblpnlSnapshotName.Location = new Point(0, 41);
            lblpnlSnapshotName.Margin = new Padding(6);
            lblpnlSnapshotName.Name = "lblpnlSnapshotName";
            lblpnlSnapshotName.OverrideCollapseControl = false;
            lblpnlSnapshotName.Padding = new Padding(107, 0, 0, 0);
            lblpnlSnapshotName.PanelCollapsible = true;
            lblpnlSnapshotName.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlSnapshotName.SeparatorColor = Color.Gray;
            lblpnlSnapshotName.ShowCloseButton = true;
            lblpnlSnapshotName.ShowSeparator = false;
            lblpnlSnapshotName.Size = new Size(469, 51);
            lblpnlSnapshotName.TabIndex = 8;
            lblpnlSnapshotName.Text = "Name";
            // 
            // tbSnapshotName
            // 
            tbSnapshotName.AutoCompleteMode = AutoCompleteMode.None;
            tbSnapshotName.AutoCompleteSource = AutoCompleteSource.None;
            tbSnapshotName.BackColor = SystemColors.Window;
            tbSnapshotName.BorderColor = Color.MediumSlateBlue;
            tbSnapshotName.BorderSize = 1;
            tbSnapshotName.Dock = DockStyle.Fill;
            tbSnapshotName.Font = new Font("Segoe UI", 9F);
            tbSnapshotName.ForeColor = Color.DimGray;
            tbSnapshotName.Location = new Point(107, 0);
            tbSnapshotName.Margin = new Padding(7, 9, 7, 9);
            tbSnapshotName.MaxLength = 15;
            tbSnapshotName.Multiline = false;
            tbSnapshotName.Name = "tbSnapshotName";
            tbSnapshotName.Padding = new Padding(6, 9, 4, 9);
            tbSnapshotName.PasswordChar = '\0';
            tbSnapshotName.PlaceholderText = "";
            tbSnapshotName.ReadOnly = false;
            tbSnapshotName.SelectedBackColor = Color.LightGray;
            tbSnapshotName.SelectedBorderColor = Color.HotPink;
            tbSnapshotName.ShortcutsEnabled = true;
            tbSnapshotName.Size = new Size(362, 51);
            tbSnapshotName.TabIndex = 1;
            tbSnapshotName.TextAlign = HorizontalAlignment.Left;
            tbSnapshotName.UnderlinedStyle = false;
            tbSnapshotName.UseSystemPasswordChar = false;
            tbSnapshotName.WordWrap = true;
            tbSnapshotName._TextChanged += tbSnapshotName__TextChanged;
            // 
            // lblpnlAppearance
            // 
            lblpnlAppearance.ArrowColor = Color.Black;
            lblpnlAppearance.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlAppearance.CloseColor = Color.Black;
            lblpnlAppearance.CloseMouseOverColor = Color.Red;
            lblpnlAppearance.Collapsed = false;
            lblpnlAppearance.Controls.Add(labelPanel5);
            lblpnlAppearance.Controls.Add(labelPanel4);
            lblpnlAppearance.Dock = DockStyle.Top;
            lblpnlAppearance.DropShadow = false;
            lblpnlAppearance.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlAppearance.FixedInlineWidth = false;
            lblpnlAppearance.Inlinelabel = false;
            lblpnlAppearance.InlineWidth = 100;
            lblpnlAppearance.LabelBackColor = Color.White;
            lblpnlAppearance.LabelFont = new Font("Segoe UI", 8F);
            lblpnlAppearance.LabelForeColor = Color.Black;
            lblpnlAppearance.Location = new Point(0, 559);
            lblpnlAppearance.Margin = new Padding(6);
            lblpnlAppearance.Name = "lblpnlAppearance";
            lblpnlAppearance.OverrideCollapseControl = true;
            lblpnlAppearance.Padding = new Padding(0, 41, 0, 0);
            lblpnlAppearance.PanelCollapsible = true;
            lblpnlAppearance.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlAppearance.SeparatorColor = Color.Gray;
            lblpnlAppearance.ShowCloseButton = false;
            lblpnlAppearance.ShowSeparator = true;
            lblpnlAppearance.Size = new Size(469, 181);
            lblpnlAppearance.TabIndex = 2;
            lblpnlAppearance.Text = "Appearance";
            // 
            // labelPanel5
            // 
            labelPanel5.ArrowColor = Color.Black;
            labelPanel5.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel5.CloseColor = Color.Black;
            labelPanel5.CloseMouseOverColor = Color.Red;
            labelPanel5.Collapsed = false;
            labelPanel5.Controls.Add(btnBackColor);
            labelPanel5.Dock = DockStyle.Top;
            labelPanel5.DropShadow = false;
            labelPanel5.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel5.FixedInlineWidth = true;
            labelPanel5.Inlinelabel = true;
            labelPanel5.InlineWidth = 80;
            labelPanel5.LabelBackColor = Color.White;
            labelPanel5.LabelFont = new Font("Segoe UI", 8F);
            labelPanel5.LabelForeColor = Color.White;
            labelPanel5.Location = new Point(0, 92);
            labelPanel5.Margin = new Padding(6);
            labelPanel5.Name = "labelPanel5";
            labelPanel5.OverrideCollapseControl = false;
            labelPanel5.Padding = new Padding(107, 0, 0, 0);
            labelPanel5.PanelCollapsible = true;
            labelPanel5.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel5.SeparatorColor = Color.Gray;
            labelPanel5.ShowCloseButton = true;
            labelPanel5.ShowSeparator = false;
            labelPanel5.Size = new Size(469, 51);
            labelPanel5.TabIndex = 9;
            labelPanel5.Text = "Back Color";
            // 
            // btnBackColor
            // 
            btnBackColor.AllowGroupUnchecking = false;
            btnBackColor.BackColorCheckedNorth = Color.Orange;
            btnBackColor.BackColorCheckedSouth = Color.Orange;
            btnBackColor.BackColorDownNorth = Color.DimGray;
            btnBackColor.BackColorDownSouth = Color.DimGray;
            btnBackColor.BackColorHoverNorth = Color.SkyBlue;
            btnBackColor.BackColorHoverSouth = Color.SkyBlue;
            btnBackColor.BackColorNorth = Color.Transparent;
            btnBackColor.BackColorSouth = Color.Transparent;
            btnBackColor.BorderColorCheckedNorth = Color.Black;
            btnBackColor.BorderColorCheckedSouth = Color.Black;
            btnBackColor.BorderColorDownNorth = Color.Black;
            btnBackColor.BorderColorDownSouth = Color.Black;
            btnBackColor.BorderColorHoverNorth = Color.Black;
            btnBackColor.BorderColorHoverSouth = Color.Black;
            btnBackColor.BorderColorNorth = Color.White;
            btnBackColor.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            btnBackColor.BorderColorSouth = Color.White;
            btnBackColor.BorderRadius = 5;
            btnBackColor.Checked = false;
            btnBackColor.Dock = DockStyle.Left;
            btnBackColor.GroupMaximumChecked = 2;
            btnBackColor.Location = new Point(107, 0);
            btnBackColor.Margin = new Padding(6);
            btnBackColor.Name = "btnBackColor";
            btnBackColor.RadioButtonGroup = "";
            btnBackColor.SecondaryFont = new Font("Segoe UI", 9F);
            btnBackColor.SecondaryText = "";
            btnBackColor.Size = new Size(45, 51);
            btnBackColor.Style = ODModules.ButtonStyle.Square;
            btnBackColor.TabIndex = 1;
            btnBackColor.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnBackColor.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnBackColor.Type = ODModules.ButtonType.Button;
            btnBackColor.ButtonClicked += btnBackColor_ButtonClicked;
            // 
            // labelPanel4
            // 
            labelPanel4.ArrowColor = Color.Black;
            labelPanel4.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel4.CloseColor = Color.Black;
            labelPanel4.CloseMouseOverColor = Color.Red;
            labelPanel4.Collapsed = false;
            labelPanel4.Controls.Add(btnTextColor);
            labelPanel4.Dock = DockStyle.Top;
            labelPanel4.DropShadow = false;
            labelPanel4.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel4.FixedInlineWidth = true;
            labelPanel4.Inlinelabel = true;
            labelPanel4.InlineWidth = 80;
            labelPanel4.LabelBackColor = Color.White;
            labelPanel4.LabelFont = new Font("Segoe UI", 8F);
            labelPanel4.LabelForeColor = Color.White;
            labelPanel4.Location = new Point(0, 41);
            labelPanel4.Margin = new Padding(6);
            labelPanel4.Name = "labelPanel4";
            labelPanel4.OverrideCollapseControl = false;
            labelPanel4.Padding = new Padding(107, 0, 0, 0);
            labelPanel4.PanelCollapsible = true;
            labelPanel4.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel4.SeparatorColor = Color.Gray;
            labelPanel4.ShowCloseButton = true;
            labelPanel4.ShowSeparator = false;
            labelPanel4.Size = new Size(469, 51);
            labelPanel4.TabIndex = 8;
            labelPanel4.Text = "Text Color";
            // 
            // btnTextColor
            // 
            btnTextColor.AllowGroupUnchecking = false;
            btnTextColor.BackColorCheckedNorth = Color.Orange;
            btnTextColor.BackColorCheckedSouth = Color.Orange;
            btnTextColor.BackColorDownNorth = Color.DimGray;
            btnTextColor.BackColorDownSouth = Color.DimGray;
            btnTextColor.BackColorHoverNorth = Color.SkyBlue;
            btnTextColor.BackColorHoverSouth = Color.SkyBlue;
            btnTextColor.BackColorNorth = Color.Transparent;
            btnTextColor.BackColorSouth = Color.Transparent;
            btnTextColor.BorderColorCheckedNorth = Color.Black;
            btnTextColor.BorderColorCheckedSouth = Color.Black;
            btnTextColor.BorderColorDownNorth = Color.Black;
            btnTextColor.BorderColorDownSouth = Color.Black;
            btnTextColor.BorderColorHoverNorth = Color.Black;
            btnTextColor.BorderColorHoverSouth = Color.Black;
            btnTextColor.BorderColorNorth = Color.White;
            btnTextColor.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            btnTextColor.BorderColorSouth = Color.White;
            btnTextColor.BorderRadius = 5;
            btnTextColor.Checked = false;
            btnTextColor.Dock = DockStyle.Left;
            btnTextColor.GroupMaximumChecked = 2;
            btnTextColor.Location = new Point(107, 0);
            btnTextColor.Margin = new Padding(6);
            btnTextColor.Name = "btnTextColor";
            btnTextColor.RadioButtonGroup = "";
            btnTextColor.SecondaryFont = new Font("Segoe UI", 9F);
            btnTextColor.SecondaryText = "";
            btnTextColor.Size = new Size(45, 51);
            btnTextColor.Style = ODModules.ButtonStyle.Square;
            btnTextColor.TabIndex = 0;
            btnTextColor.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnTextColor.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnTextColor.Type = ODModules.ButtonType.Button;
            btnTextColor.ButtonClicked += btnTextColor_ButtonClicked;
            // 
            // lblpnlUnits
            // 
            lblpnlUnits.ArrowColor = Color.Black;
            lblpnlUnits.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlUnits.AutoScroll = true;
            lblpnlUnits.AutoSize = true;
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
            lblpnlUnits.Location = new Point(0, 261);
            lblpnlUnits.Margin = new Padding(6);
            lblpnlUnits.Name = "lblpnlUnits";
            lblpnlUnits.OverrideCollapseControl = true;
            lblpnlUnits.Padding = new Padding(0, 41, 0, 0);
            lblpnlUnits.PanelCollapsible = true;
            lblpnlUnits.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlUnits.SeparatorColor = Color.Gray;
            lblpnlUnits.ShowCloseButton = false;
            lblpnlUnits.ShowSeparator = true;
            lblpnlUnits.Size = new Size(469, 298);
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
            pfsMain.Location = new Point(0, 170);
            pfsMain.Margin = new Padding(6);
            pfsMain.MinimumSize = new Size(0, 128);
            pfsMain.Name = "pfsMain";
            pfsMain.Size = new Size(469, 128);
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
            ntbMain.Location = new Point(0, 41);
            ntbMain.Margin = new Padding(6);
            ntbMain.Marked = false;
            ntbMain.MarkedBackColor = Color.Empty;
            ntbMain.MarkedBorderColor = Color.Beige;
            numericalString3.DisplayValue = "100";
            numericalString3.Value = "100";
            ntbMain.Maximum = numericalString3;
            numericalString4.DisplayValue = "0";
            numericalString4.Value = "0";
            ntbMain.Minimum = numericalString4;
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
            ntbMain.Size = new Size(469, 27);
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
            labelPanel3.Location = new Point(0, 119);
            labelPanel3.Margin = new Padding(6);
            labelPanel3.Name = "labelPanel3";
            labelPanel3.OverrideCollapseControl = false;
            labelPanel3.Padding = new Padding(77, 11, 9, 11);
            labelPanel3.PanelCollapsible = true;
            labelPanel3.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel3.SeparatorColor = Color.Gray;
            labelPanel3.ShowCloseButton = true;
            labelPanel3.ShowSeparator = false;
            labelPanel3.Size = new Size(469, 51);
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
            labelPanel2.Location = new Point(0, 68);
            labelPanel2.Margin = new Padding(6);
            labelPanel2.Name = "labelPanel2";
            labelPanel2.OverrideCollapseControl = false;
            labelPanel2.Padding = new Padding(107, 0, 0, 0);
            labelPanel2.PanelCollapsible = true;
            labelPanel2.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel2.SeparatorColor = Color.Gray;
            labelPanel2.ShowCloseButton = true;
            labelPanel2.ShowSeparator = false;
            labelPanel2.Size = new Size(469, 51);
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
            tbUnit.Location = new Point(107, 0);
            tbUnit.Margin = new Padding(7, 9, 7, 9);
            tbUnit.MaxLength = 15;
            tbUnit.Multiline = false;
            tbUnit.Name = "tbUnit";
            tbUnit.Padding = new Padding(6, 9, 4, 9);
            tbUnit.PasswordChar = '\0';
            tbUnit.PlaceholderText = "";
            tbUnit.ReadOnly = false;
            tbUnit.SelectedBackColor = Color.LightGray;
            tbUnit.SelectedBorderColor = Color.HotPink;
            tbUnit.ShortcutsEnabled = true;
            tbUnit.Size = new Size(362, 51);
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
            lblpnlFormat.Controls.Add(lblpnlDecimalFormat);
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
            lblpnlFormat.Margin = new Padding(6);
            lblpnlFormat.Name = "lblpnlFormat";
            lblpnlFormat.OverrideCollapseControl = true;
            lblpnlFormat.Padding = new Padding(0, 41, 0, 11);
            lblpnlFormat.PanelCollapsible = true;
            lblpnlFormat.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlFormat.SeparatorColor = Color.Gray;
            lblpnlFormat.ShowCloseButton = false;
            lblpnlFormat.ShowSeparator = true;
            lblpnlFormat.Size = new Size(469, 261);
            lblpnlFormat.TabIndex = 0;
            lblpnlFormat.Text = "Format";
            // 
            // lblpnlDecimalFormat
            // 
            lblpnlDecimalFormat.ArrowColor = Color.Black;
            lblpnlDecimalFormat.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlDecimalFormat.CloseColor = Color.Black;
            lblpnlDecimalFormat.CloseMouseOverColor = Color.Red;
            lblpnlDecimalFormat.Collapsed = false;
            lblpnlDecimalFormat.Controls.Add(ddlDecimalPlaces);
            lblpnlDecimalFormat.Dock = DockStyle.Top;
            lblpnlDecimalFormat.DropShadow = false;
            lblpnlDecimalFormat.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlDecimalFormat.FixedInlineWidth = true;
            lblpnlDecimalFormat.Inlinelabel = true;
            lblpnlDecimalFormat.InlineWidth = 80;
            lblpnlDecimalFormat.LabelBackColor = Color.White;
            lblpnlDecimalFormat.LabelFont = new Font("Segoe UI", 8F);
            lblpnlDecimalFormat.LabelForeColor = Color.White;
            lblpnlDecimalFormat.Location = new Point(0, 199);
            lblpnlDecimalFormat.Margin = new Padding(6);
            lblpnlDecimalFormat.Name = "lblpnlDecimalFormat";
            lblpnlDecimalFormat.OverrideCollapseControl = false;
            lblpnlDecimalFormat.Padding = new Padding(107, 0, 0, 0);
            lblpnlDecimalFormat.PanelCollapsible = true;
            lblpnlDecimalFormat.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlDecimalFormat.SeparatorColor = Color.Gray;
            lblpnlDecimalFormat.ShowCloseButton = true;
            lblpnlDecimalFormat.ShowSeparator = false;
            lblpnlDecimalFormat.Size = new Size(469, 51);
            lblpnlDecimalFormat.TabIndex = 4;
            lblpnlDecimalFormat.Text = "Decimal Places";
            // 
            // ddlDecimalPlaces
            // 
            ddlDecimalPlaces.ArrowColor = Color.Black;
            ddlDecimalPlaces.BorderColor = Color.Gray;
            ddlDecimalPlaces.Dock = DockStyle.Top;
            ddlDecimalPlaces.DrawMode = DrawMode.OwnerDrawFixed;
            ddlDecimalPlaces.FlatStyle = FlatStyle.Flat;
            ddlDecimalPlaces.FormattingEnabled = true;
            ddlDecimalPlaces.Location = new Point(107, 0);
            ddlDecimalPlaces.Margin = new Padding(6);
            ddlDecimalPlaces.Name = "ddlDecimalPlaces";
            ddlDecimalPlaces.SelectedBackColor = Color.LightGray;
            ddlDecimalPlaces.SelectedBorderColor = Color.BlueViolet;
            ddlDecimalPlaces.SelectedColor = Color.SteelBlue;
            ddlDecimalPlaces.SelectedForeColor = Color.DimGray;
            ddlDecimalPlaces.Size = new Size(362, 40);
            ddlDecimalPlaces.TabIndex = 5;
            ddlDecimalPlaces.SelectedIndexChanged += ddlDecimalPlaces_SelectedIndexChanged;
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
            lblpnlEndianess.Location = new Point(0, 146);
            lblpnlEndianess.Margin = new Padding(6);
            lblpnlEndianess.Name = "lblpnlEndianess";
            lblpnlEndianess.OverrideCollapseControl = false;
            lblpnlEndianess.Padding = new Padding(107, 0, 0, 0);
            lblpnlEndianess.PanelCollapsible = true;
            lblpnlEndianess.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlEndianess.SeparatorColor = Color.Gray;
            lblpnlEndianess.ShowCloseButton = true;
            lblpnlEndianess.ShowSeparator = false;
            lblpnlEndianess.Size = new Size(469, 53);
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
            ddlEndianness.Location = new Point(107, 0);
            ddlEndianness.Margin = new Padding(6);
            ddlEndianness.Name = "ddlEndianness";
            ddlEndianness.SelectedBackColor = Color.LightGray;
            ddlEndianness.SelectedBorderColor = Color.BlueViolet;
            ddlEndianness.SelectedColor = Color.SteelBlue;
            ddlEndianness.SelectedForeColor = Color.DimGray;
            ddlEndianness.Size = new Size(362, 40);
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
            lblpnlSize.Location = new Point(0, 121);
            lblpnlSize.Margin = new Padding(6);
            lblpnlSize.Name = "lblpnlSize";
            lblpnlSize.OverrideCollapseControl = false;
            lblpnlSize.Padding = new Padding(107, 0, 0, 0);
            lblpnlSize.PanelCollapsible = true;
            lblpnlSize.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlSize.SeparatorColor = Color.Gray;
            lblpnlSize.ShowCloseButton = true;
            lblpnlSize.ShowSeparator = false;
            lblpnlSize.Size = new Size(469, 25);
            lblpnlSize.TabIndex = 1;
            lblpnlSize.Text = "Size";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColorNorth = Color.DodgerBlue;
            toolStrip1.BackColorSouth = Color.DodgerBlue;
            toolStrip1.BorderColor = Color.WhiteSmoke;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            toolStrip1.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            toolStrip1.ItemForeColor = Color.Black;
            toolStrip1.ItemSelectedBackColorNorth = Color.White;
            toolStrip1.ItemSelectedBackColorSouth = Color.White;
            toolStrip1.ItemSelectedForeColor = Color.Black;
            toolStrip1.Location = new Point(107, 0);
            toolStrip1.MenuBackColorNorth = Color.DodgerBlue;
            toolStrip1.MenuBackColorSouth = Color.DodgerBlue;
            toolStrip1.MenuBorderColor = Color.WhiteSmoke;
            toolStrip1.MenuSeparatorColor = Color.WhiteSmoke;
            toolStrip1.MenuSymbolColor = Color.WhiteSmoke;
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(2, 0, 2, 0);
            toolStrip1.RoundedToolStrip = false;
            toolStrip1.ShowBorder = false;
            toolStrip1.Size = new Size(362, 25);
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
            lblpnlDisplay.Location = new Point(0, 81);
            lblpnlDisplay.Margin = new Padding(6);
            lblpnlDisplay.Name = "lblpnlDisplay";
            lblpnlDisplay.OverrideCollapseControl = false;
            lblpnlDisplay.Padding = new Padding(107, 0, 0, 0);
            lblpnlDisplay.PanelCollapsible = true;
            lblpnlDisplay.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlDisplay.SeparatorColor = Color.Gray;
            lblpnlDisplay.ShowCloseButton = true;
            lblpnlDisplay.ShowSeparator = false;
            lblpnlDisplay.Size = new Size(469, 40);
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
            ddlDisplay.Location = new Point(107, 0);
            ddlDisplay.Margin = new Padding(6);
            ddlDisplay.Name = "ddlDisplay";
            ddlDisplay.SelectedBackColor = Color.LightGray;
            ddlDisplay.SelectedBorderColor = Color.BlueViolet;
            ddlDisplay.SelectedColor = Color.SteelBlue;
            ddlDisplay.SelectedForeColor = Color.DimGray;
            ddlDisplay.Size = new Size(362, 40);
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
            lblpnlBoolDisplay.Location = new Point(0, 41);
            lblpnlBoolDisplay.Margin = new Padding(6);
            lblpnlBoolDisplay.Name = "lblpnlBoolDisplay";
            lblpnlBoolDisplay.OverrideCollapseControl = false;
            lblpnlBoolDisplay.Padding = new Padding(107, 0, 0, 0);
            lblpnlBoolDisplay.PanelCollapsible = true;
            lblpnlBoolDisplay.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlBoolDisplay.SeparatorColor = Color.Gray;
            lblpnlBoolDisplay.ShowCloseButton = true;
            lblpnlBoolDisplay.ShowSeparator = false;
            lblpnlBoolDisplay.Size = new Size(469, 40);
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
            ddlBooleanDisplay.Location = new Point(107, 0);
            ddlBooleanDisplay.Margin = new Padding(6);
            ddlBooleanDisplay.Name = "ddlBooleanDisplay";
            ddlBooleanDisplay.SelectedBackColor = Color.LightGray;
            ddlBooleanDisplay.SelectedBorderColor = Color.BlueViolet;
            ddlBooleanDisplay.SelectedColor = Color.SteelBlue;
            ddlBooleanDisplay.SelectedForeColor = Color.DimGray;
            ddlBooleanDisplay.Size = new Size(362, 40);
            ddlBooleanDisplay.TabIndex = 3;
            ddlBooleanDisplay.SelectedIndexChanged += ddlBooleanDisplay_SelectedIndexChanged;
            // 
            // ModbusProperties
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            DefaultDockArea = ODModules.Docking.DockArea.Right;
            DockText = "Properties";
            Margin = new Padding(6);
            Name = "ModbusProperties";
            Size = new Size(483, 1655);
            Load += ModbusProperties_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            lblpnlSnapshot.ResumeLayout(false);
            lblpnlSnapshotName.ResumeLayout(false);
            lblpnlAppearance.ResumeLayout(false);
            labelPanel5.ResumeLayout(false);
            labelPanel4.ResumeLayout(false);
            lblpnlUnits.ResumeLayout(false);
            labelPanel2.ResumeLayout(false);
            lblpnlFormat.ResumeLayout(false);
            lblpnlFormat.PerformLayout();
            lblpnlDecimalFormat.ResumeLayout(false);
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
        private ODModules.LabelPanel lblpnlAppearance;
        private ODModules.LabelPanel lblpnlDisplay;
        private ODModules.LabelPanel lblpnlSize;
        private ODModules.ToolStrip toolStrip1;
        private ODModules.LabelPanel labelPanel2;
        private ODModules.LabelPanel lblpnlEndianess;
        private ODModules.DropDownBox ddlDisplay;
        private ODModules.DropDownBox ddlEndianness;
        private ODModules.LabelPanel labelPanel3;
        private ODModules.TextBox tbUnit;
        private ODModules.LabelPanel lblpnlBoolDisplay;
        private ODModules.DropDownBox ddlBooleanDisplay;
        private ODModules.LabelPanel lblpnlDecimalFormat;
        private ODModules.DropDownBox ddlDecimalPlaces;
        private ODModules.LabelPanel labelPanel4;
        private ODModules.LabelPanel labelPanel5;
        private ODModules.Button btnBackColor;
        private ODModules.Button btnTextColor;
        private ODModules.LabelPanel lblpnlSnapshot;
        private ODModules.LabelPanel lblpnlSnapshotName;
        private ODModules.TextBox tbSnapshotName;
    }
}
