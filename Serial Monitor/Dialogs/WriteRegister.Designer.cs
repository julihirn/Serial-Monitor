namespace Serial_Monitor.Dialogs {
    partial class WriteRegister {
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
            Handlers.NumericalString numericalString5 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString6 = new Handlers.NumericalString();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteRegister));
            this.lblpnlValue = new ODModules.LabelPanel();
            this.numtxtValue = new ODModules.NumericTextbox();
            this.lblpnlRegisters = new ODModules.LabelPanel();
            this.lblpnlQuantity = new ODModules.LabelPanel();
            this.numtxtAddress = new ODModules.NumericTextbox();
            this.lblpnlAddress = new ODModules.LabelPanel();
            this.numtxtUnit = new ODModules.NumericTextbox();
            this.labelPanel1 = new ODModules.LabelPanel();
            this.cmbxDataSet = new ODModules.FlatComboBox();
            this.btnAccept = new ODModules.Button();
            this.btnCancel = new ODModules.Button();
            this.lblpnlValue.SuspendLayout();
            this.lblpnlRegisters.SuspendLayout();
            this.lblpnlQuantity.SuspendLayout();
            this.lblpnlAddress.SuspendLayout();
            this.labelPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblpnlValue
            // 
            this.lblpnlValue.ArrowColor = System.Drawing.Color.LightGray;
            this.lblpnlValue.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.lblpnlValue.AutoSize = true;
            this.lblpnlValue.CloseColor = System.Drawing.Color.Black;
            this.lblpnlValue.CloseMouseOverColor = System.Drawing.Color.Red;
            this.lblpnlValue.Collapsed = false;
            this.lblpnlValue.Controls.Add(this.numtxtValue);
            this.lblpnlValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblpnlValue.DropShadow = false;
            this.lblpnlValue.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblpnlValue.FixedInlineWidth = false;
            this.lblpnlValue.ForeColor = System.Drawing.Color.White;
            this.lblpnlValue.Inlinelabel = false;
            this.lblpnlValue.InlineWidth = 100;
            this.lblpnlValue.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lblpnlValue.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblpnlValue.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblpnlValue.Location = new System.Drawing.Point(19, 221);
            this.lblpnlValue.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblpnlValue.Name = "lblpnlValue";
            this.lblpnlValue.OverrideCollapseControl = false;
            this.lblpnlValue.Padding = new System.Windows.Forms.Padding(9, 37, 9, 11);
            this.lblpnlValue.PanelCollapsible = false;
            this.lblpnlValue.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlValue.ShowCloseButton = false;
            this.lblpnlValue.Size = new System.Drawing.Size(489, 71);
            this.lblpnlValue.TabIndex = 13;
            this.lblpnlValue.Text = "Value";
            // 
            // numtxtValue
            // 
            this.numtxtValue.AllowClipboard = true;
            this.numtxtValue.AllowDragValueChange = true;
            this.numtxtValue.AllowFractionals = false;
            this.numtxtValue.AllowMouseWheel = true;
            this.numtxtValue.AllowNegatives = false;
            this.numtxtValue.AllowNumberEntry = true;
            this.numtxtValue.AllowTyping = true;
            this.numtxtValue.AutoSizeToText = false;
            this.numtxtValue.Base = ODModules.NumericTextbox.NumberBase.Base10;
            this.numtxtValue.BorderColor = System.Drawing.Color.DimGray;
            this.numtxtValue.ButtonDownColor = System.Drawing.Color.Gray;
            this.numtxtValue.ButtonHoverColor = System.Drawing.Color.LightGray;
            this.numtxtValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.numtxtValue.FixedNumericPadding = 5;
            this.numtxtValue.FormatOutput = true;
            this.numtxtValue.HasUnit = false;
            this.numtxtValue.IsMetric = false;
            this.numtxtValue.IsSecondaryMetric = false;
            this.numtxtValue.LabelFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numtxtValue.LabelForeColor = System.Drawing.Color.Gray;
            this.numtxtValue.LabelText = "";
            this.numtxtValue.Location = new System.Drawing.Point(9, 37);
            this.numtxtValue.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numtxtValue.Marked = false;
            this.numtxtValue.MarkedBackColor = System.Drawing.Color.Empty;
            this.numtxtValue.MarkedBorderColor = System.Drawing.Color.Beige;
            numericalString1.DisplayValue = "32767";
            numericalString1.Value = "32767";
            this.numtxtValue.Maximum = numericalString1;
            numericalString2.DisplayValue = "0";
            numericalString2.Value = "0";
            this.numtxtValue.Minimum = numericalString2;
            this.numtxtValue.Name = "numtxtValue";
            this.numtxtValue.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Right;
            this.numtxtValue.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            this.numtxtValue.NumericalLeftRadixDigitsMaximum = 7;
            this.numtxtValue.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numtxtValue.RangeLimited = true;
            this.numtxtValue.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numtxtValue.SecondaryTag = null;
            this.numtxtValue.SecondaryUnit = "";
            this.numtxtValue.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            this.numtxtValue.SelectedBackColor = System.Drawing.Color.Empty;
            this.numtxtValue.SelectedBorderColor = System.Drawing.Color.Beige;
            this.numtxtValue.ShowLabel = true;
            this.numtxtValue.Size = new System.Drawing.Size(471, 23);
            this.numtxtValue.TabIndex = 1;
            this.numtxtValue.Unit = "";
            this.numtxtValue.UseFixedNumericPadding = true;
            this.numtxtValue.Value = "1";
            // 
            // lblpnlRegisters
            // 
            this.lblpnlRegisters.ArrowColor = System.Drawing.Color.LightGray;
            this.lblpnlRegisters.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.lblpnlRegisters.AutoSize = true;
            this.lblpnlRegisters.CloseColor = System.Drawing.Color.Black;
            this.lblpnlRegisters.CloseMouseOverColor = System.Drawing.Color.Red;
            this.lblpnlRegisters.Collapsed = false;
            this.lblpnlRegisters.Controls.Add(this.lblpnlQuantity);
            this.lblpnlRegisters.Controls.Add(this.lblpnlAddress);
            this.lblpnlRegisters.Controls.Add(this.labelPanel1);
            this.lblpnlRegisters.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblpnlRegisters.DropShadow = false;
            this.lblpnlRegisters.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblpnlRegisters.FixedInlineWidth = false;
            this.lblpnlRegisters.ForeColor = System.Drawing.Color.White;
            this.lblpnlRegisters.Inlinelabel = false;
            this.lblpnlRegisters.InlineWidth = 100;
            this.lblpnlRegisters.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lblpnlRegisters.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblpnlRegisters.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblpnlRegisters.Location = new System.Drawing.Point(19, 21);
            this.lblpnlRegisters.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblpnlRegisters.Name = "lblpnlRegisters";
            this.lblpnlRegisters.OverrideCollapseControl = false;
            this.lblpnlRegisters.Padding = new System.Windows.Forms.Padding(9, 37, 9, 11);
            this.lblpnlRegisters.PanelCollapsible = false;
            this.lblpnlRegisters.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlRegisters.ShowCloseButton = false;
            this.lblpnlRegisters.Size = new System.Drawing.Size(489, 200);
            this.lblpnlRegisters.TabIndex = 10;
            this.lblpnlRegisters.Text = "Register Selection";
            // 
            // lblpnlQuantity
            // 
            this.lblpnlQuantity.ArrowColor = System.Drawing.Color.LightGray;
            this.lblpnlQuantity.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.lblpnlQuantity.AutoSize = true;
            this.lblpnlQuantity.CloseColor = System.Drawing.Color.Black;
            this.lblpnlQuantity.CloseMouseOverColor = System.Drawing.Color.Red;
            this.lblpnlQuantity.Collapsed = false;
            this.lblpnlQuantity.Controls.Add(this.numtxtAddress);
            this.lblpnlQuantity.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblpnlQuantity.DropShadow = false;
            this.lblpnlQuantity.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblpnlQuantity.FixedInlineWidth = true;
            this.lblpnlQuantity.ForeColor = System.Drawing.Color.White;
            this.lblpnlQuantity.Inlinelabel = true;
            this.lblpnlQuantity.InlineWidth = 100;
            this.lblpnlQuantity.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lblpnlQuantity.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblpnlQuantity.LabelForeColor = System.Drawing.Color.Black;
            this.lblpnlQuantity.Location = new System.Drawing.Point(9, 144);
            this.lblpnlQuantity.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblpnlQuantity.Name = "lblpnlQuantity";
            this.lblpnlQuantity.OverrideCollapseControl = false;
            this.lblpnlQuantity.Padding = new System.Windows.Forms.Padding(127, 11, 9, 11);
            this.lblpnlQuantity.PanelCollapsible = false;
            this.lblpnlQuantity.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlQuantity.ShowCloseButton = false;
            this.lblpnlQuantity.Size = new System.Drawing.Size(471, 45);
            this.lblpnlQuantity.TabIndex = 2;
            this.lblpnlQuantity.Text = "Address";
            // 
            // numtxtAddress
            // 
            this.numtxtAddress.AllowClipboard = true;
            this.numtxtAddress.AllowDragValueChange = true;
            this.numtxtAddress.AllowFractionals = false;
            this.numtxtAddress.AllowMouseWheel = true;
            this.numtxtAddress.AllowNegatives = false;
            this.numtxtAddress.AllowNumberEntry = true;
            this.numtxtAddress.AllowTyping = true;
            this.numtxtAddress.AutoSizeToText = false;
            this.numtxtAddress.Base = ODModules.NumericTextbox.NumberBase.Base10;
            this.numtxtAddress.BorderColor = System.Drawing.Color.DimGray;
            this.numtxtAddress.ButtonDownColor = System.Drawing.Color.Gray;
            this.numtxtAddress.ButtonHoverColor = System.Drawing.Color.LightGray;
            this.numtxtAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.numtxtAddress.FixedNumericPadding = 5;
            this.numtxtAddress.FormatOutput = true;
            this.numtxtAddress.HasUnit = false;
            this.numtxtAddress.IsMetric = false;
            this.numtxtAddress.IsSecondaryMetric = false;
            this.numtxtAddress.LabelFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numtxtAddress.LabelForeColor = System.Drawing.Color.Gray;
            this.numtxtAddress.LabelText = "";
            this.numtxtAddress.Location = new System.Drawing.Point(127, 11);
            this.numtxtAddress.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numtxtAddress.Marked = false;
            this.numtxtAddress.MarkedBackColor = System.Drawing.Color.Empty;
            this.numtxtAddress.MarkedBorderColor = System.Drawing.Color.Beige;
            numericalString3.DisplayValue = "32767";
            numericalString3.Value = "32767";
            this.numtxtAddress.Maximum = numericalString3;
            numericalString4.DisplayValue = "0";
            numericalString4.Value = "0";
            this.numtxtAddress.Minimum = numericalString4;
            this.numtxtAddress.Name = "numtxtAddress";
            this.numtxtAddress.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Right;
            this.numtxtAddress.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            this.numtxtAddress.NumericalLeftRadixDigitsMaximum = 7;
            this.numtxtAddress.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numtxtAddress.RangeLimited = true;
            this.numtxtAddress.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numtxtAddress.SecondaryTag = null;
            this.numtxtAddress.SecondaryUnit = "";
            this.numtxtAddress.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            this.numtxtAddress.SelectedBackColor = System.Drawing.Color.Empty;
            this.numtxtAddress.SelectedBorderColor = System.Drawing.Color.Beige;
            this.numtxtAddress.ShowLabel = true;
            this.numtxtAddress.Size = new System.Drawing.Size(335, 23);
            this.numtxtAddress.TabIndex = 0;
            this.numtxtAddress.Unit = "";
            this.numtxtAddress.UseFixedNumericPadding = true;
            this.numtxtAddress.Value = "1";
            // 
            // lblpnlAddress
            // 
            this.lblpnlAddress.ArrowColor = System.Drawing.Color.LightGray;
            this.lblpnlAddress.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.lblpnlAddress.AutoSize = true;
            this.lblpnlAddress.CloseColor = System.Drawing.Color.Black;
            this.lblpnlAddress.CloseMouseOverColor = System.Drawing.Color.Red;
            this.lblpnlAddress.Collapsed = false;
            this.lblpnlAddress.Controls.Add(this.numtxtUnit);
            this.lblpnlAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblpnlAddress.DropShadow = false;
            this.lblpnlAddress.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblpnlAddress.FixedInlineWidth = true;
            this.lblpnlAddress.ForeColor = System.Drawing.Color.White;
            this.lblpnlAddress.Inlinelabel = true;
            this.lblpnlAddress.InlineWidth = 100;
            this.lblpnlAddress.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lblpnlAddress.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblpnlAddress.LabelForeColor = System.Drawing.Color.Black;
            this.lblpnlAddress.Location = new System.Drawing.Point(9, 99);
            this.lblpnlAddress.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lblpnlAddress.Name = "lblpnlAddress";
            this.lblpnlAddress.OverrideCollapseControl = false;
            this.lblpnlAddress.Padding = new System.Windows.Forms.Padding(127, 11, 9, 11);
            this.lblpnlAddress.PanelCollapsible = false;
            this.lblpnlAddress.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlAddress.ShowCloseButton = false;
            this.lblpnlAddress.Size = new System.Drawing.Size(471, 45);
            this.lblpnlAddress.TabIndex = 1;
            this.lblpnlAddress.Text = "Slave";
            // 
            // numtxtUnit
            // 
            this.numtxtUnit.AllowClipboard = true;
            this.numtxtUnit.AllowDragValueChange = true;
            this.numtxtUnit.AllowFractionals = false;
            this.numtxtUnit.AllowMouseWheel = true;
            this.numtxtUnit.AllowNegatives = false;
            this.numtxtUnit.AllowNumberEntry = true;
            this.numtxtUnit.AllowTyping = true;
            this.numtxtUnit.AutoSizeToText = false;
            this.numtxtUnit.Base = ODModules.NumericTextbox.NumberBase.Base10;
            this.numtxtUnit.BorderColor = System.Drawing.Color.DimGray;
            this.numtxtUnit.ButtonDownColor = System.Drawing.Color.Gray;
            this.numtxtUnit.ButtonHoverColor = System.Drawing.Color.LightGray;
            this.numtxtUnit.Dock = System.Windows.Forms.DockStyle.Top;
            this.numtxtUnit.FixedNumericPadding = 5;
            this.numtxtUnit.FormatOutput = true;
            this.numtxtUnit.HasUnit = false;
            this.numtxtUnit.IsMetric = false;
            this.numtxtUnit.IsSecondaryMetric = false;
            this.numtxtUnit.LabelFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numtxtUnit.LabelForeColor = System.Drawing.Color.Gray;
            this.numtxtUnit.LabelText = "";
            this.numtxtUnit.Location = new System.Drawing.Point(127, 11);
            this.numtxtUnit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numtxtUnit.Marked = false;
            this.numtxtUnit.MarkedBackColor = System.Drawing.Color.Empty;
            this.numtxtUnit.MarkedBorderColor = System.Drawing.Color.Beige;
            numericalString5.DisplayValue = "32767";
            numericalString5.Value = "32767";
            this.numtxtUnit.Maximum = numericalString5;
            numericalString6.DisplayValue = "0";
            numericalString6.Value = "0";
            this.numtxtUnit.Minimum = numericalString6;
            this.numtxtUnit.Name = "numtxtUnit";
            this.numtxtUnit.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Right;
            this.numtxtUnit.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            this.numtxtUnit.NumericalLeftRadixDigitsMaximum = 7;
            this.numtxtUnit.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numtxtUnit.RangeLimited = true;
            this.numtxtUnit.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numtxtUnit.SecondaryTag = null;
            this.numtxtUnit.SecondaryUnit = "";
            this.numtxtUnit.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            this.numtxtUnit.SelectedBackColor = System.Drawing.Color.Empty;
            this.numtxtUnit.SelectedBorderColor = System.Drawing.Color.Beige;
            this.numtxtUnit.ShowLabel = true;
            this.numtxtUnit.Size = new System.Drawing.Size(335, 23);
            this.numtxtUnit.TabIndex = 0;
            this.numtxtUnit.Unit = "";
            this.numtxtUnit.UseFixedNumericPadding = true;
            this.numtxtUnit.Value = "0";
            // 
            // labelPanel1
            // 
            this.labelPanel1.ArrowColor = System.Drawing.Color.LightGray;
            this.labelPanel1.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel1.AutoSize = true;
            this.labelPanel1.CloseColor = System.Drawing.Color.Black;
            this.labelPanel1.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel1.Collapsed = false;
            this.labelPanel1.Controls.Add(this.cmbxDataSet);
            this.labelPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPanel1.DropShadow = false;
            this.labelPanel1.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel1.FixedInlineWidth = true;
            this.labelPanel1.ForeColor = System.Drawing.Color.White;
            this.labelPanel1.Inlinelabel = true;
            this.labelPanel1.InlineWidth = 100;
            this.labelPanel1.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.labelPanel1.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel1.LabelForeColor = System.Drawing.Color.Black;
            this.labelPanel1.Location = new System.Drawing.Point(9, 37);
            this.labelPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.labelPanel1.Name = "labelPanel1";
            this.labelPanel1.OverrideCollapseControl = false;
            this.labelPanel1.Padding = new System.Windows.Forms.Padding(127, 11, 9, 11);
            this.labelPanel1.PanelCollapsible = false;
            this.labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.labelPanel1.ShowCloseButton = false;
            this.labelPanel1.Size = new System.Drawing.Size(471, 62);
            this.labelPanel1.TabIndex = 0;
            this.labelPanel1.Text = "Data Set";
            this.labelPanel1.Visible = false;
            // 
            // cmbxDataSet
            // 
            this.cmbxDataSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbxDataSet.FormattingEnabled = true;
            this.cmbxDataSet.Location = new System.Drawing.Point(127, 11);
            this.cmbxDataSet.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cmbxDataSet.Name = "cmbxDataSet";
            this.cmbxDataSet.Size = new System.Drawing.Size(335, 40);
            this.cmbxDataSet.TabIndex = 0;
            // 
            // btnAccept
            // 
            this.btnAccept.AllowGroupUnchecking = false;
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.btnAccept.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.btnAccept.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.btnAccept.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.btnAccept.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.btnAccept.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.btnAccept.BackColorNorth = System.Drawing.Color.White;
            this.btnAccept.BackColorSouth = System.Drawing.Color.White;
            this.btnAccept.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.btnAccept.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.btnAccept.BorderColorDownNorth = System.Drawing.Color.Black;
            this.btnAccept.BorderColorDownSouth = System.Drawing.Color.Black;
            this.btnAccept.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.btnAccept.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.btnAccept.BorderColorNorth = System.Drawing.Color.Black;
            this.btnAccept.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAccept.BorderColorSouth = System.Drawing.Color.Black;
            this.btnAccept.BorderRadius = 5;
            this.btnAccept.Checked = false;
            this.btnAccept.GroupMaximumChecked = 2;
            this.btnAccept.Location = new System.Drawing.Point(152, 469);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.RadioButtonGroup = "";
            this.btnAccept.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAccept.SecondaryText = "";
            this.btnAccept.Size = new System.Drawing.Size(173, 60);
            this.btnAccept.Style = ODModules.ButtonStyle.Square;
            this.btnAccept.TabIndex = 11;
            this.btnAccept.Text = "Send";
            this.btnAccept.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btnAccept.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.btnAccept.Type = ODModules.ButtonType.Button;
            this.btnAccept.ButtonClicked += new ODModules.Button.ButtonClickedHandler(this.btnAccept_ButtonClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.AllowGroupUnchecking = false;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.btnCancel.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.btnCancel.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.btnCancel.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.btnCancel.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.btnCancel.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.btnCancel.BackColorNorth = System.Drawing.Color.White;
            this.btnCancel.BackColorSouth = System.Drawing.Color.White;
            this.btnCancel.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.btnCancel.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.btnCancel.BorderColorDownNorth = System.Drawing.Color.Black;
            this.btnCancel.BorderColorDownSouth = System.Drawing.Color.Black;
            this.btnCancel.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.btnCancel.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.btnCancel.BorderColorNorth = System.Drawing.Color.Black;
            this.btnCancel.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.BorderColorSouth = System.Drawing.Color.Black;
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.Checked = false;
            this.btnCancel.GroupMaximumChecked = 2;
            this.btnCancel.Location = new System.Drawing.Point(336, 469);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButtonGroup = "";
            this.btnCancel.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.SecondaryText = "";
            this.btnCancel.Size = new System.Drawing.Size(173, 60);
            this.btnCancel.Style = ODModules.ButtonStyle.Square;
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btnCancel.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.btnCancel.Type = ODModules.ButtonType.Button;
            this.btnCancel.ButtonClicked += new ODModules.Button.ButtonClickedHandler(this.btnCancel_ButtonClicked);
            // 
            // WriteRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 557);
            this.Controls.Add(this.lblpnlValue);
            this.Controls.Add(this.lblpnlRegisters);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "WriteRegister";
            this.Padding = new System.Windows.Forms.Padding(19, 21, 19, 21);
            this.ShowInTaskbar = false;
            this.Text = "Write Register";
            this.Load += new System.EventHandler(this.WriteRegister_Load);
            this.lblpnlValue.ResumeLayout(false);
            this.lblpnlRegisters.ResumeLayout(false);
            this.lblpnlRegisters.PerformLayout();
            this.lblpnlQuantity.ResumeLayout(false);
            this.lblpnlAddress.ResumeLayout(false);
            this.labelPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ODModules.LabelPanel lblpnlValue;
        private ODModules.LabelPanel lblpnlRegisters;
        private ODModules.LabelPanel lblpnlQuantity;
        private ODModules.NumericTextbox numtxtAddress;
        private ODModules.LabelPanel lblpnlAddress;
        private ODModules.NumericTextbox numtxtUnit;
        private ODModules.LabelPanel labelPanel1;
        private ODModules.FlatComboBox cmbxDataSet;
        private ODModules.Button btnAccept;
        private ODModules.Button btnCancel;
        private ODModules.NumericTextbox numtxtValue;
    }
}