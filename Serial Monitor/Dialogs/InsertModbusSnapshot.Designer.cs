﻿namespace Serial_Monitor.Dialogs {
    partial class InsertModbusSnapshot {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertModbusSnapshot));
            lblpnlDisplayName = new ODModules.LabelPanel();
            textBox1 = new ODModules.TextBox();
            lblpnlRegisters = new ODModules.LabelPanel();
            lblpnlQuantity = new ODModules.LabelPanel();
            numtxtQuantity = new ODModules.NumericTextbox();
            lblpnlAddress = new ODModules.LabelPanel();
            numtxtAddress = new ODModules.NumericTextbox();
            labelPanel1 = new ODModules.LabelPanel();
            cmbxDataSet = new ODModules.FlatComboBox();
            btnCancel = new ODModules.Button();
            btnAccept = new ODModules.Button();
            btnHiddenAccept = new Button();
            btnHiddenCancel = new Button();
            lblpnlChannel = new ODModules.LabelPanel();
            btngridChannels = new ODModules.ButtonGrid();
            lblpnlDisplayName.SuspendLayout();
            lblpnlRegisters.SuspendLayout();
            lblpnlQuantity.SuspendLayout();
            lblpnlAddress.SuspendLayout();
            labelPanel1.SuspendLayout();
            lblpnlChannel.SuspendLayout();
            SuspendLayout();
            // 
            // lblpnlDisplayName
            // 
            lblpnlDisplayName.ArrowColor = Color.LightGray;
            lblpnlDisplayName.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlDisplayName.AutoSize = true;
            lblpnlDisplayName.CloseColor = Color.Black;
            lblpnlDisplayName.CloseMouseOverColor = Color.Red;
            lblpnlDisplayName.Collapsed = false;
            lblpnlDisplayName.Controls.Add(textBox1);
            lblpnlDisplayName.Dock = DockStyle.Top;
            lblpnlDisplayName.DropShadow = false;
            lblpnlDisplayName.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlDisplayName.FixedInlineWidth = false;
            lblpnlDisplayName.ForeColor = Color.White;
            lblpnlDisplayName.Inlinelabel = false;
            lblpnlDisplayName.InlineWidth = 100;
            lblpnlDisplayName.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlDisplayName.LabelFont = new Font("Segoe UI", 8F);
            lblpnlDisplayName.LabelForeColor = Color.WhiteSmoke;
            lblpnlDisplayName.Location = new Point(19, 21);
            lblpnlDisplayName.Margin = new Padding(6, 6, 6, 6);
            lblpnlDisplayName.Name = "lblpnlDisplayName";
            lblpnlDisplayName.OverrideCollapseControl = false;
            lblpnlDisplayName.Padding = new Padding(9, 41, 9, 11);
            lblpnlDisplayName.PanelCollapsible = false;
            lblpnlDisplayName.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlDisplayName.SeparatorColor = Color.Gray;
            lblpnlDisplayName.ShowCloseButton = false;
            lblpnlDisplayName.ShowSeparator = false;
            lblpnlDisplayName.Size = new Size(599, 92);
            lblpnlDisplayName.TabIndex = 1;
            lblpnlDisplayName.Text = "Display Name";
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
            textBox1.Location = new Point(9, 41);
            textBox1.Margin = new Padding(4, 4, 4, 4);
            textBox1.MaxLength = 32767;
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.Padding = new Padding(7, 6, 7, 6);
            textBox1.PasswordChar = '\0';
            textBox1.PlaceholderText = "";
            textBox1.ReadOnly = false;
            textBox1.SelectedBackColor = Color.LightGray;
            textBox1.SelectedBorderColor = Color.HotPink;
            textBox1.ShortcutsEnabled = true;
            textBox1.Size = new Size(581, 43);
            textBox1.TabIndex = 1;
            textBox1.TextAlign = HorizontalAlignment.Left;
            textBox1.UnderlinedStyle = false;
            textBox1.UseSystemPasswordChar = false;
            textBox1.WordWrap = true;
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
            lblpnlRegisters.Location = new Point(19, 346);
            lblpnlRegisters.Margin = new Padding(6, 6, 6, 6);
            lblpnlRegisters.Name = "lblpnlRegisters";
            lblpnlRegisters.OverrideCollapseControl = false;
            lblpnlRegisters.Padding = new Padding(9, 41, 9, 11);
            lblpnlRegisters.PanelCollapsible = false;
            lblpnlRegisters.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlRegisters.SeparatorColor = Color.Gray;
            lblpnlRegisters.ShowCloseButton = false;
            lblpnlRegisters.ShowSeparator = false;
            lblpnlRegisters.Size = new Size(599, 204);
            lblpnlRegisters.TabIndex = 3;
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
            lblpnlQuantity.Controls.Add(numtxtQuantity);
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
            lblpnlQuantity.Margin = new Padding(6, 6, 6, 6);
            lblpnlQuantity.Name = "lblpnlQuantity";
            lblpnlQuantity.OverrideCollapseControl = false;
            lblpnlQuantity.Padding = new Padding(127, 11, 9, 11);
            lblpnlQuantity.PanelCollapsible = false;
            lblpnlQuantity.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlQuantity.SeparatorColor = Color.Gray;
            lblpnlQuantity.ShowCloseButton = false;
            lblpnlQuantity.ShowSeparator = false;
            lblpnlQuantity.Size = new Size(581, 45);
            lblpnlQuantity.TabIndex = 2;
            lblpnlQuantity.Text = "Quantity";
            // 
            // numtxtQuantity
            // 
            numtxtQuantity.AllowClipboard = true;
            numtxtQuantity.AllowDragValueChange = true;
            numtxtQuantity.AllowFractionals = false;
            numtxtQuantity.AllowMouseWheel = true;
            numtxtQuantity.AllowNegatives = false;
            numtxtQuantity.AllowNumberEntry = true;
            numtxtQuantity.AllowTyping = true;
            numtxtQuantity.ArrowKeysControlNumber = true;
            numtxtQuantity.AutoSizeToText = false;
            numtxtQuantity.Base = ODModules.NumericTextbox.NumberBase.Base10;
            numtxtQuantity.BorderColor = Color.DimGray;
            numtxtQuantity.ButtonDownColor = Color.Gray;
            numtxtQuantity.ButtonHoverColor = Color.LightGray;
            numtxtQuantity.Dock = DockStyle.Top;
            numtxtQuantity.FixedNumericPadding = 5;
            numtxtQuantity.FormatOutput = true;
            numtxtQuantity.HasUnit = false;
            numtxtQuantity.IsMetric = false;
            numtxtQuantity.IsSecondaryMetric = false;
            numtxtQuantity.LabelFont = new Font("Segoe UI", 9F);
            numtxtQuantity.LabelForeColor = Color.Gray;
            numtxtQuantity.LabelText = "";
            numtxtQuantity.Location = new Point(127, 11);
            numtxtQuantity.Margin = new Padding(6, 6, 6, 6);
            numtxtQuantity.Marked = false;
            numtxtQuantity.MarkedBackColor = Color.Empty;
            numtxtQuantity.MarkedBorderColor = Color.Beige;
            numericalString1.DisplayValue = "1000";
            numericalString1.Value = "1000";
            numtxtQuantity.Maximum = numericalString1;
            numericalString2.DisplayValue = "1";
            numericalString2.Value = "1";
            numtxtQuantity.Minimum = numericalString2;
            numtxtQuantity.Name = "numtxtQuantity";
            numtxtQuantity.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Right;
            numtxtQuantity.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            numtxtQuantity.NumericalLeftRadixDigitsMaximum = 7;
            numtxtQuantity.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            numtxtQuantity.RangeLimited = true;
            numtxtQuantity.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            numtxtQuantity.SecondaryTag = null;
            numtxtQuantity.SecondaryUnit = "";
            numtxtQuantity.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            numtxtQuantity.SelectedBackColor = Color.Empty;
            numtxtQuantity.SelectedBorderColor = Color.Beige;
            numtxtQuantity.ShowLabel = true;
            numtxtQuantity.Size = new Size(445, 23);
            numtxtQuantity.TabIndex = 0;
            numtxtQuantity.Unit = "";
            numtxtQuantity.UseFixedNumericPadding = true;
            numtxtQuantity.Value = "1";
            // 
            // lblpnlAddress
            // 
            lblpnlAddress.ArrowColor = Color.LightGray;
            lblpnlAddress.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlAddress.AutoSize = true;
            lblpnlAddress.CloseColor = Color.Black;
            lblpnlAddress.CloseMouseOverColor = Color.Red;
            lblpnlAddress.Collapsed = false;
            lblpnlAddress.Controls.Add(numtxtAddress);
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
            lblpnlAddress.Margin = new Padding(6, 6, 6, 6);
            lblpnlAddress.Name = "lblpnlAddress";
            lblpnlAddress.OverrideCollapseControl = false;
            lblpnlAddress.Padding = new Padding(127, 11, 9, 11);
            lblpnlAddress.PanelCollapsible = false;
            lblpnlAddress.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlAddress.SeparatorColor = Color.Gray;
            lblpnlAddress.ShowCloseButton = false;
            lblpnlAddress.ShowSeparator = false;
            lblpnlAddress.Size = new Size(581, 45);
            lblpnlAddress.TabIndex = 1;
            lblpnlAddress.Text = "Address";
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
            numtxtAddress.Margin = new Padding(6, 6, 6, 6);
            numtxtAddress.Marked = false;
            numtxtAddress.MarkedBackColor = Color.Empty;
            numtxtAddress.MarkedBorderColor = Color.Beige;
            numericalString3.DisplayValue = "32767";
            numericalString3.Value = "32767";
            numtxtAddress.Maximum = numericalString3;
            numericalString4.DisplayValue = "0";
            numericalString4.Value = "0";
            numtxtAddress.Minimum = numericalString4;
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
            numtxtAddress.Size = new Size(445, 23);
            numtxtAddress.TabIndex = 0;
            numtxtAddress.Unit = "";
            numtxtAddress.UseFixedNumericPadding = true;
            numtxtAddress.Value = "0";
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
            labelPanel1.Margin = new Padding(6, 6, 6, 6);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = false;
            labelPanel1.Padding = new Padding(127, 11, 9, 11);
            labelPanel1.PanelCollapsible = false;
            labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel1.SeparatorColor = Color.Gray;
            labelPanel1.ShowCloseButton = false;
            labelPanel1.ShowSeparator = false;
            labelPanel1.Size = new Size(581, 62);
            labelPanel1.TabIndex = 0;
            labelPanel1.Text = "Data Set";
            // 
            // cmbxDataSet
            // 
            cmbxDataSet.Dock = DockStyle.Top;
            cmbxDataSet.FormattingEnabled = true;
            cmbxDataSet.Location = new Point(127, 11);
            cmbxDataSet.Margin = new Padding(6, 6, 6, 6);
            cmbxDataSet.Name = "cmbxDataSet";
            cmbxDataSet.Size = new Size(445, 40);
            cmbxDataSet.TabIndex = 0;
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
            btnCancel.Location = new Point(436, 683);
            btnCancel.Margin = new Padding(6, 6, 6, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.RadioButtonGroup = "";
            btnCancel.SecondaryFont = new Font("Segoe UI", 9F);
            btnCancel.SecondaryText = "";
            btnCancel.Size = new Size(173, 60);
            btnCancel.Style = ODModules.ButtonStyle.Square;
            btnCancel.TabIndex = 5;
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
            btnAccept.Location = new Point(253, 683);
            btnAccept.Margin = new Padding(6, 6, 6, 6);
            btnAccept.Name = "btnAccept";
            btnAccept.RadioButtonGroup = "";
            btnAccept.SecondaryFont = new Font("Segoe UI", 9F);
            btnAccept.SecondaryText = "";
            btnAccept.Size = new Size(173, 60);
            btnAccept.Style = ODModules.ButtonStyle.Square;
            btnAccept.TabIndex = 4;
            btnAccept.Text = "Accept";
            btnAccept.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnAccept.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnAccept.Type = ODModules.ButtonType.Button;
            btnAccept.ButtonClicked += btnAccept_ButtonClicked;
            btnAccept.Load += btnAccept_Load;
            // 
            // btnHiddenAccept
            // 
            btnHiddenAccept.Location = new Point(189, 700);
            btnHiddenAccept.Margin = new Padding(6, 6, 6, 6);
            btnHiddenAccept.Name = "btnHiddenAccept";
            btnHiddenAccept.Size = new Size(19, 21);
            btnHiddenAccept.TabIndex = 5;
            btnHiddenAccept.Text = "Acc";
            btnHiddenAccept.UseVisualStyleBackColor = true;
            btnHiddenAccept.Visible = false;
            btnHiddenAccept.Click += btnHiddenAccept_Click;
            // 
            // btnHiddenCancel
            // 
            btnHiddenCancel.Location = new Point(167, 700);
            btnHiddenCancel.Margin = new Padding(6, 6, 6, 6);
            btnHiddenCancel.Name = "btnHiddenCancel";
            btnHiddenCancel.Size = new Size(20, 21);
            btnHiddenCancel.TabIndex = 6;
            btnHiddenCancel.Text = "Can";
            btnHiddenCancel.UseVisualStyleBackColor = true;
            btnHiddenCancel.Visible = false;
            btnHiddenCancel.Click += btnHiddenCancel_Click;
            // 
            // lblpnlChannel
            // 
            lblpnlChannel.ArrowColor = Color.LightGray;
            lblpnlChannel.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlChannel.CloseColor = Color.Black;
            lblpnlChannel.CloseMouseOverColor = Color.Red;
            lblpnlChannel.Collapsed = false;
            lblpnlChannel.Controls.Add(btngridChannels);
            lblpnlChannel.Dock = DockStyle.Top;
            lblpnlChannel.DropShadow = false;
            lblpnlChannel.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlChannel.FixedInlineWidth = false;
            lblpnlChannel.ForeColor = Color.White;
            lblpnlChannel.Inlinelabel = false;
            lblpnlChannel.InlineWidth = 100;
            lblpnlChannel.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlChannel.LabelFont = new Font("Segoe UI", 8F);
            lblpnlChannel.LabelForeColor = Color.WhiteSmoke;
            lblpnlChannel.Location = new Point(19, 113);
            lblpnlChannel.Margin = new Padding(6, 6, 6, 6);
            lblpnlChannel.Name = "lblpnlChannel";
            lblpnlChannel.OverrideCollapseControl = false;
            lblpnlChannel.Padding = new Padding(9, 41, 9, 11);
            lblpnlChannel.PanelCollapsible = false;
            lblpnlChannel.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlChannel.SeparatorColor = Color.Gray;
            lblpnlChannel.ShowCloseButton = false;
            lblpnlChannel.ShowSeparator = false;
            lblpnlChannel.Size = new Size(599, 233);
            lblpnlChannel.TabIndex = 2;
            lblpnlChannel.Text = "Channel";
            // 
            // btngridChannels
            // 
            btngridChannels.AllowTextWrapping = false;
            btngridChannels.BackColorCheckedNorth = Color.Orange;
            btngridChannels.BackColorCheckedSouth = Color.Orange;
            btngridChannels.BackColorDownNorth = Color.DimGray;
            btngridChannels.BackColorDownSouth = Color.DimGray;
            btngridChannels.BackColorHoverNorth = Color.SkyBlue;
            btngridChannels.BackColorHoverSouth = Color.SkyBlue;
            btngridChannels.BackColorNorth = Color.White;
            btngridChannels.BackColorSouth = Color.White;
            btngridChannels.BorderColorCheckedNorth = Color.Black;
            btngridChannels.BorderColorCheckedSouth = Color.Black;
            btngridChannels.BorderColorDownNorth = Color.Black;
            btngridChannels.BorderColorDownSouth = Color.Black;
            btngridChannels.BorderColorHoverNorth = Color.Black;
            btngridChannels.BorderColorHoverSouth = Color.Black;
            btngridChannels.BorderColorNorth = Color.Black;
            btngridChannels.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            btngridChannels.BorderColorSouth = Color.Black;
            btngridChannels.BorderRadius = 5;
            btngridChannels.ButtonPadding = new Padding(0, 0, 5, 5);
            btngridChannels.ButtonSize = new Size(90, 60);
            btngridChannels.CenterButtons = true;
            btngridChannels.Columns = 6;
            btngridChannels.Dock = DockStyle.Fill;
            btngridChannels.Filter = "";
            btngridChannels.FixedColumns = false;
            btngridChannels.IconInline = false;
            btngridChannels.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btngridChannels.ImageSize = new Size(32, 32);
            btngridChannels.Location = new Point(9, 41);
            btngridChannels.Margin = new Padding(6, 6, 6, 6);
            btngridChannels.Name = "btngridChannels";
            btngridChannels.Padding = new Padding(0, 11, 0, 0);
            btngridChannels.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            btngridChannels.ScrollBarNorth = Color.DarkTurquoise;
            btngridChannels.ScrollBarSouth = Color.DeepSkyBlue;
            btngridChannels.SecondaryFont = null;
            btngridChannels.Size = new Size(581, 181);
            btngridChannels.Style = ODModules.ButtonStyle.Square;
            btngridChannels.TabIndex = 0;
            btngridChannels.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btngridChannels.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btngridChannels.VerScroll = 0;
            btngridChannels.ButtonClicked += btngridChannels_ButtonClicked;
            // 
            // InsertModbusSnapshot
            // 
            AcceptButton = btnHiddenAccept;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            CancelButton = btnHiddenCancel;
            ClientSize = new Size(637, 770);
            Controls.Add(lblpnlRegisters);
            Controls.Add(lblpnlChannel);
            Controls.Add(btnHiddenCancel);
            Controls.Add(btnHiddenAccept);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(lblpnlDisplayName);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(6, 6, 6, 6);
            Name = "InsertModbusSnapshot";
            Padding = new Padding(19, 21, 19, 21);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Insert Modbus Snapshot";
            TopMost = true;
            Load += InsertModbusSnapshot_Load;
            lblpnlDisplayName.ResumeLayout(false);
            lblpnlRegisters.ResumeLayout(false);
            lblpnlRegisters.PerformLayout();
            lblpnlQuantity.ResumeLayout(false);
            lblpnlAddress.ResumeLayout(false);
            labelPanel1.ResumeLayout(false);
            lblpnlChannel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.LabelPanel lblpnlDisplayName;
        private ODModules.LabelPanel lblpnlRegisters;
        private ODModules.LabelPanel lblpnlQuantity;
        private ODModules.NumericTextbox numtxtQuantity;
        private ODModules.LabelPanel lblpnlAddress;
        private ODModules.NumericTextbox numtxtAddress;
        private ODModules.Button btnCancel;
        private ODModules.Button btnAccept;
        private Button btnHiddenAccept;
        private Button btnHiddenCancel;
        private ODModules.LabelPanel lblpnlChannel;
        private ODModules.ButtonGrid btngridChannels;
        private ODModules.LabelPanel labelPanel1;
        private ODModules.FlatComboBox cmbxDataSet;
        private ODModules.TextBox textBox1;
    }
}