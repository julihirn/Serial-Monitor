namespace Serial_Monitor.Dialogs {
    partial class WriteCoil {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteCoil));
            lblpnlRegisters = new ODModules.LabelPanel();
            lblpnlQuantity = new ODModules.LabelPanel();
            numtxtAddress = new ODModules.NumericTextbox();
            lblpnlAddress = new ODModules.LabelPanel();
            numtxtUnit = new ODModules.NumericTextbox();
            labelPanel1 = new ODModules.LabelPanel();
            cmbxDataSet = new ODModules.FlatComboBox();
            btnAccept = new ODModules.Button();
            btnCancel = new ODModules.Button();
            lblpnlValue = new ODModules.LabelPanel();
            panel1 = new Panel();
            btnOptOn = new ODModules.Button();
            btnOptOff = new ODModules.Button();
            lblpnlRegisters.SuspendLayout();
            lblpnlQuantity.SuspendLayout();
            lblpnlAddress.SuspendLayout();
            labelPanel1.SuspendLayout();
            lblpnlValue.SuspendLayout();
            panel1.SuspendLayout();
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
            lblpnlRegisters.LabelFont = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblpnlRegisters.LabelForeColor = Color.WhiteSmoke;
            lblpnlRegisters.Location = new Point(19, 21);
            lblpnlRegisters.Margin = new Padding(6);
            lblpnlRegisters.Name = "lblpnlRegisters";
            lblpnlRegisters.OverrideCollapseControl = false;
            lblpnlRegisters.Padding = new Padding(9, 37, 9, 11);
            lblpnlRegisters.PanelCollapsible = false;
            lblpnlRegisters.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlRegisters.ShowCloseButton = false;
            lblpnlRegisters.Size = new Size(489, 200);
            lblpnlRegisters.TabIndex = 6;
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
            lblpnlQuantity.LabelFont = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblpnlQuantity.LabelForeColor = Color.Black;
            lblpnlQuantity.Location = new Point(9, 144);
            lblpnlQuantity.Margin = new Padding(6);
            lblpnlQuantity.Name = "lblpnlQuantity";
            lblpnlQuantity.OverrideCollapseControl = false;
            lblpnlQuantity.Padding = new Padding(127, 11, 9, 11);
            lblpnlQuantity.PanelCollapsible = false;
            lblpnlQuantity.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlQuantity.ShowCloseButton = false;
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
            numtxtAddress.LabelFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
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
            numtxtAddress.Size = new Size(335, 23);
            numtxtAddress.TabIndex = 0;
            numtxtAddress.Unit = "";
            numtxtAddress.UseFixedNumericPadding = true;
            numtxtAddress.Value = "1";
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
            lblpnlAddress.LabelFont = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblpnlAddress.LabelForeColor = Color.Black;
            lblpnlAddress.Location = new Point(9, 99);
            lblpnlAddress.Margin = new Padding(6);
            lblpnlAddress.Name = "lblpnlAddress";
            lblpnlAddress.OverrideCollapseControl = false;
            lblpnlAddress.Padding = new Padding(127, 11, 9, 11);
            lblpnlAddress.PanelCollapsible = false;
            lblpnlAddress.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlAddress.ShowCloseButton = false;
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
            numtxtUnit.LabelFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
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
            numtxtUnit.Size = new Size(335, 23);
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
            labelPanel1.LabelFont = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            labelPanel1.LabelForeColor = Color.Black;
            labelPanel1.Location = new Point(9, 37);
            labelPanel1.Margin = new Padding(6);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = false;
            labelPanel1.Padding = new Padding(127, 11, 9, 11);
            labelPanel1.PanelCollapsible = false;
            labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel1.ShowCloseButton = false;
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
            cmbxDataSet.Size = new Size(335, 40);
            cmbxDataSet.TabIndex = 0;
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
            btnAccept.Location = new Point(132, 469);
            btnAccept.Margin = new Padding(6);
            btnAccept.Name = "btnAccept";
            btnAccept.RadioButtonGroup = "";
            btnAccept.SecondaryFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAccept.SecondaryText = "";
            btnAccept.Size = new Size(173, 60);
            btnAccept.Style = ODModules.ButtonStyle.Square;
            btnAccept.TabIndex = 7;
            btnAccept.Text = "Send";
            btnAccept.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnAccept.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnAccept.Type = ODModules.ButtonType.Button;
            btnAccept.ButtonClicked += btnAccept_ButtonClicked;
            btnAccept.Load += btnAccept_Load;
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
            btnCancel.Location = new Point(317, 469);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.RadioButtonGroup = "";
            btnCancel.SecondaryFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.SecondaryText = "";
            btnCancel.Size = new Size(173, 60);
            btnCancel.Style = ODModules.ButtonStyle.Square;
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnCancel.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnCancel.Type = ODModules.ButtonType.Button;
            btnCancel.ButtonClicked += btnCancel_ButtonClicked;
            btnCancel.Load += btnCancel_Load;
            // 
            // lblpnlValue
            // 
            lblpnlValue.ArrowColor = Color.LightGray;
            lblpnlValue.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlValue.CloseColor = Color.Black;
            lblpnlValue.CloseMouseOverColor = Color.Red;
            lblpnlValue.Collapsed = false;
            lblpnlValue.Controls.Add(panel1);
            lblpnlValue.Dock = DockStyle.Top;
            lblpnlValue.DropShadow = false;
            lblpnlValue.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlValue.FixedInlineWidth = false;
            lblpnlValue.ForeColor = Color.White;
            lblpnlValue.Inlinelabel = false;
            lblpnlValue.InlineWidth = 100;
            lblpnlValue.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlValue.LabelFont = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblpnlValue.LabelForeColor = Color.WhiteSmoke;
            lblpnlValue.Location = new Point(19, 221);
            lblpnlValue.Margin = new Padding(6);
            lblpnlValue.Name = "lblpnlValue";
            lblpnlValue.OverrideCollapseControl = false;
            lblpnlValue.Padding = new Padding(9, 37, 9, 11);
            lblpnlValue.PanelCollapsible = false;
            lblpnlValue.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlValue.ShowCloseButton = false;
            lblpnlValue.Size = new Size(489, 115);
            lblpnlValue.TabIndex = 9;
            lblpnlValue.Text = "Value";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnOptOn);
            panel1.Controls.Add(btnOptOff);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(9, 37);
            panel1.Margin = new Padding(6);
            panel1.Name = "panel1";
            panel1.Size = new Size(471, 67);
            panel1.TabIndex = 0;
            // 
            // btnOptOn
            // 
            btnOptOn.AllowGroupUnchecking = false;
            btnOptOn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOptOn.BackColorCheckedNorth = Color.Orange;
            btnOptOn.BackColorCheckedSouth = Color.Orange;
            btnOptOn.BackColorDownNorth = Color.DimGray;
            btnOptOn.BackColorDownSouth = Color.DimGray;
            btnOptOn.BackColorHoverNorth = Color.SkyBlue;
            btnOptOn.BackColorHoverSouth = Color.SkyBlue;
            btnOptOn.BackColorNorth = Color.White;
            btnOptOn.BackColorSouth = Color.White;
            btnOptOn.BorderColorCheckedNorth = Color.Black;
            btnOptOn.BorderColorCheckedSouth = Color.Black;
            btnOptOn.BorderColorDownNorth = Color.Black;
            btnOptOn.BorderColorDownSouth = Color.Black;
            btnOptOn.BorderColorHoverNorth = Color.Black;
            btnOptOn.BorderColorHoverSouth = Color.Black;
            btnOptOn.BorderColorNorth = Color.Black;
            btnOptOn.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            btnOptOn.BorderColorSouth = Color.Black;
            btnOptOn.BorderRadius = 5;
            btnOptOn.Checked = true;
            btnOptOn.GroupMaximumChecked = 2;
            btnOptOn.Location = new Point(166, 6);
            btnOptOn.Margin = new Padding(6);
            btnOptOn.Name = "btnOptOn";
            btnOptOn.RadioButtonGroup = "boolValue";
            btnOptOn.SecondaryFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnOptOn.SecondaryText = "";
            btnOptOn.Size = new Size(143, 53);
            btnOptOn.Style = ODModules.ButtonStyle.Square;
            btnOptOn.TabIndex = 11;
            btnOptOn.Text = "On";
            btnOptOn.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnOptOn.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnOptOn.Type = ODModules.ButtonType.RadioButton;
            // 
            // btnOptOff
            // 
            btnOptOff.AllowGroupUnchecking = false;
            btnOptOff.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOptOff.BackColorCheckedNorth = Color.Orange;
            btnOptOff.BackColorCheckedSouth = Color.Orange;
            btnOptOff.BackColorDownNorth = Color.DimGray;
            btnOptOff.BackColorDownSouth = Color.DimGray;
            btnOptOff.BackColorHoverNorth = Color.SkyBlue;
            btnOptOff.BackColorHoverSouth = Color.SkyBlue;
            btnOptOff.BackColorNorth = Color.White;
            btnOptOff.BackColorSouth = Color.White;
            btnOptOff.BorderColorCheckedNorth = Color.Black;
            btnOptOff.BorderColorCheckedSouth = Color.Black;
            btnOptOff.BorderColorDownNorth = Color.Black;
            btnOptOff.BorderColorDownSouth = Color.Black;
            btnOptOff.BorderColorHoverNorth = Color.Black;
            btnOptOff.BorderColorHoverSouth = Color.Black;
            btnOptOff.BorderColorNorth = Color.Black;
            btnOptOff.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            btnOptOff.BorderColorSouth = Color.Black;
            btnOptOff.BorderRadius = 5;
            btnOptOff.Checked = false;
            btnOptOff.GroupMaximumChecked = 2;
            btnOptOff.Location = new Point(317, 6);
            btnOptOff.Margin = new Padding(6);
            btnOptOff.Name = "btnOptOff";
            btnOptOff.RadioButtonGroup = "boolValue";
            btnOptOff.SecondaryFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnOptOff.SecondaryText = "";
            btnOptOff.Size = new Size(143, 53);
            btnOptOff.Style = ODModules.ButtonStyle.Square;
            btnOptOff.TabIndex = 10;
            btnOptOff.Text = "Off";
            btnOptOff.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnOptOff.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnOptOff.Type = ODModules.ButtonType.RadioButton;
            // 
            // WriteCoil
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 557);
            Controls.Add(lblpnlValue);
            Controls.Add(lblpnlRegisters);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6);
            Name = "WriteCoil";
            Padding = new Padding(19, 21, 19, 21);
            ShowInTaskbar = false;
            Text = "Write Coil";
            Load += WriteCoil_Load;
            lblpnlRegisters.ResumeLayout(false);
            lblpnlRegisters.PerformLayout();
            lblpnlQuantity.ResumeLayout(false);
            lblpnlAddress.ResumeLayout(false);
            labelPanel1.ResumeLayout(false);
            lblpnlValue.ResumeLayout(false);
            panel1.ResumeLayout(false);
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
        private ODModules.Button btnAccept;
        private ODModules.Button btnCancel;
        private ODModules.LabelPanel lblpnlValue;
        private Panel panel1;
        private ODModules.Button btnOptOn;
        private ODModules.Button btnOptOff;
    }
}