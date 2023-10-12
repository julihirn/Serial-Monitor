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
            this.lblpnlRegisters = new ODModules.LabelPanel();
            this.lblpnlQuantity = new ODModules.LabelPanel();
            this.numtxtAddress = new ODModules.NumericTextbox();
            this.lblpnlAddress = new ODModules.LabelPanel();
            this.numtxtUnit = new ODModules.NumericTextbox();
            this.labelPanel1 = new ODModules.LabelPanel();
            this.cmbxDataSet = new ODModules.FlatComboBox();
            this.btnAccept = new ODModules.Button();
            this.btnCancel = new ODModules.Button();
            this.lblpnlValue = new ODModules.LabelPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOptOn = new ODModules.Button();
            this.btnOptOff = new ODModules.Button();
            this.lblpnlRegisters.SuspendLayout();
            this.lblpnlQuantity.SuspendLayout();
            this.lblpnlAddress.SuspendLayout();
            this.labelPanel1.SuspendLayout();
            this.lblpnlValue.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.lblpnlRegisters.Location = new System.Drawing.Point(10, 10);
            this.lblpnlRegisters.Name = "lblpnlRegisters";
            this.lblpnlRegisters.OverrideCollapseControl = false;
            this.lblpnlRegisters.Padding = new System.Windows.Forms.Padding(5, 18, 5, 5);
            this.lblpnlRegisters.PanelCollapsible = false;
            this.lblpnlRegisters.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlRegisters.ShowCloseButton = false;
            this.lblpnlRegisters.Size = new System.Drawing.Size(264, 122);
            this.lblpnlRegisters.TabIndex = 6;
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
            this.lblpnlQuantity.Location = new System.Drawing.Point(5, 84);
            this.lblpnlQuantity.Name = "lblpnlQuantity";
            this.lblpnlQuantity.OverrideCollapseControl = false;
            this.lblpnlQuantity.Padding = new System.Windows.Forms.Padding(113, 5, 5, 5);
            this.lblpnlQuantity.PanelCollapsible = false;
            this.lblpnlQuantity.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlQuantity.ShowCloseButton = false;
            this.lblpnlQuantity.Size = new System.Drawing.Size(254, 33);
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
            this.numtxtAddress.Location = new System.Drawing.Point(113, 5);
            this.numtxtAddress.Marked = false;
            this.numtxtAddress.MarkedBackColor = System.Drawing.Color.Empty;
            this.numtxtAddress.MarkedBorderColor = System.Drawing.Color.Beige;
            numericalString1.DisplayValue = "32767";
            numericalString1.Value = "32767";
            this.numtxtAddress.Maximum = numericalString1;
            numericalString2.DisplayValue = "0";
            numericalString2.Value = "0";
            this.numtxtAddress.Minimum = numericalString2;
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
            this.numtxtAddress.Size = new System.Drawing.Size(136, 23);
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
            this.lblpnlAddress.Location = new System.Drawing.Point(5, 51);
            this.lblpnlAddress.Name = "lblpnlAddress";
            this.lblpnlAddress.OverrideCollapseControl = false;
            this.lblpnlAddress.Padding = new System.Windows.Forms.Padding(113, 5, 5, 5);
            this.lblpnlAddress.PanelCollapsible = false;
            this.lblpnlAddress.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlAddress.ShowCloseButton = false;
            this.lblpnlAddress.Size = new System.Drawing.Size(254, 33);
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
            this.numtxtUnit.Location = new System.Drawing.Point(113, 5);
            this.numtxtUnit.Marked = false;
            this.numtxtUnit.MarkedBackColor = System.Drawing.Color.Empty;
            this.numtxtUnit.MarkedBorderColor = System.Drawing.Color.Beige;
            numericalString3.DisplayValue = "32767";
            numericalString3.Value = "32767";
            this.numtxtUnit.Maximum = numericalString3;
            numericalString4.DisplayValue = "0";
            numericalString4.Value = "0";
            this.numtxtUnit.Minimum = numericalString4;
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
            this.numtxtUnit.Size = new System.Drawing.Size(136, 23);
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
            this.labelPanel1.Location = new System.Drawing.Point(5, 18);
            this.labelPanel1.Name = "labelPanel1";
            this.labelPanel1.OverrideCollapseControl = false;
            this.labelPanel1.Padding = new System.Windows.Forms.Padding(113, 5, 5, 5);
            this.labelPanel1.PanelCollapsible = false;
            this.labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.labelPanel1.ShowCloseButton = false;
            this.labelPanel1.Size = new System.Drawing.Size(254, 33);
            this.labelPanel1.TabIndex = 0;
            this.labelPanel1.Text = "Data Set";
            this.labelPanel1.Visible = false;
            // 
            // cmbxDataSet
            // 
            this.cmbxDataSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbxDataSet.FormattingEnabled = true;
            this.cmbxDataSet.Location = new System.Drawing.Point(113, 5);
            this.cmbxDataSet.Name = "cmbxDataSet";
            this.cmbxDataSet.Size = new System.Drawing.Size(136, 23);
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
            this.btnAccept.Location = new System.Drawing.Point(82, 220);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.RadioButtonGroup = "";
            this.btnAccept.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAccept.SecondaryText = "";
            this.btnAccept.Size = new System.Drawing.Size(93, 28);
            this.btnAccept.Style = ODModules.ButtonStyle.Square;
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Send";
            this.btnAccept.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btnAccept.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.btnAccept.Type = ODModules.ButtonType.Button;
            this.btnAccept.ButtonClicked += new ODModules.Button.ButtonClickedHandler(this.btnAccept_ButtonClicked);
            this.btnAccept.Load += new System.EventHandler(this.btnAccept_Load);
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
            this.btnCancel.Location = new System.Drawing.Point(181, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButtonGroup = "";
            this.btnCancel.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.SecondaryText = "";
            this.btnCancel.Size = new System.Drawing.Size(93, 28);
            this.btnCancel.Style = ODModules.ButtonStyle.Square;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btnCancel.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.btnCancel.Type = ODModules.ButtonType.Button;
            this.btnCancel.ButtonClicked += new ODModules.Button.ButtonClickedHandler(this.btnCancel_ButtonClicked);
            this.btnCancel.Load += new System.EventHandler(this.btnCancel_Load);
            // 
            // lblpnlValue
            // 
            this.lblpnlValue.ArrowColor = System.Drawing.Color.LightGray;
            this.lblpnlValue.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.lblpnlValue.CloseColor = System.Drawing.Color.Black;
            this.lblpnlValue.CloseMouseOverColor = System.Drawing.Color.Red;
            this.lblpnlValue.Collapsed = false;
            this.lblpnlValue.Controls.Add(this.panel1);
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
            this.lblpnlValue.Location = new System.Drawing.Point(10, 132);
            this.lblpnlValue.Name = "lblpnlValue";
            this.lblpnlValue.OverrideCollapseControl = false;
            this.lblpnlValue.Padding = new System.Windows.Forms.Padding(5, 18, 5, 5);
            this.lblpnlValue.PanelCollapsible = false;
            this.lblpnlValue.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlValue.ShowCloseButton = false;
            this.lblpnlValue.Size = new System.Drawing.Size(264, 54);
            this.lblpnlValue.TabIndex = 9;
            this.lblpnlValue.Text = "Value";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOptOn);
            this.panel1.Controls.Add(this.btnOptOff);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 31);
            this.panel1.TabIndex = 0;
            // 
            // btnOptOn
            // 
            this.btnOptOn.AllowGroupUnchecking = false;
            this.btnOptOn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptOn.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.btnOptOn.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.btnOptOn.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.btnOptOn.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.btnOptOn.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.btnOptOn.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.btnOptOn.BackColorNorth = System.Drawing.Color.White;
            this.btnOptOn.BackColorSouth = System.Drawing.Color.White;
            this.btnOptOn.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.btnOptOn.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.btnOptOn.BorderColorDownNorth = System.Drawing.Color.Black;
            this.btnOptOn.BorderColorDownSouth = System.Drawing.Color.Black;
            this.btnOptOn.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.btnOptOn.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.btnOptOn.BorderColorNorth = System.Drawing.Color.Black;
            this.btnOptOn.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOptOn.BorderColorSouth = System.Drawing.Color.Black;
            this.btnOptOn.BorderRadius = 5;
            this.btnOptOn.Checked = true;
            this.btnOptOn.GroupMaximumChecked = 2;
            this.btnOptOn.Location = new System.Drawing.Point(91, 3);
            this.btnOptOn.Name = "btnOptOn";
            this.btnOptOn.RadioButtonGroup = "boolValue";
            this.btnOptOn.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOptOn.SecondaryText = "";
            this.btnOptOn.Size = new System.Drawing.Size(77, 25);
            this.btnOptOn.Style = ODModules.ButtonStyle.Square;
            this.btnOptOn.TabIndex = 11;
            this.btnOptOn.Text = "On";
            this.btnOptOn.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btnOptOn.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.btnOptOn.Type = ODModules.ButtonType.RadioButton;
            // 
            // btnOptOff
            // 
            this.btnOptOff.AllowGroupUnchecking = false;
            this.btnOptOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptOff.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.btnOptOff.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.btnOptOff.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.btnOptOff.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.btnOptOff.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.btnOptOff.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.btnOptOff.BackColorNorth = System.Drawing.Color.White;
            this.btnOptOff.BackColorSouth = System.Drawing.Color.White;
            this.btnOptOff.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.btnOptOff.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.btnOptOff.BorderColorDownNorth = System.Drawing.Color.Black;
            this.btnOptOff.BorderColorDownSouth = System.Drawing.Color.Black;
            this.btnOptOff.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.btnOptOff.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.btnOptOff.BorderColorNorth = System.Drawing.Color.Black;
            this.btnOptOff.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOptOff.BorderColorSouth = System.Drawing.Color.Black;
            this.btnOptOff.BorderRadius = 5;
            this.btnOptOff.Checked = false;
            this.btnOptOff.GroupMaximumChecked = 2;
            this.btnOptOff.Location = new System.Drawing.Point(172, 3);
            this.btnOptOff.Name = "btnOptOff";
            this.btnOptOff.RadioButtonGroup = "boolValue";
            this.btnOptOff.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOptOff.SecondaryText = "";
            this.btnOptOff.Size = new System.Drawing.Size(77, 25);
            this.btnOptOff.Style = ODModules.ButtonStyle.Square;
            this.btnOptOff.TabIndex = 10;
            this.btnOptOff.Text = "Off";
            this.btnOptOff.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btnOptOff.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.btnOptOff.Type = ODModules.ButtonType.RadioButton;
            // 
            // WriteCoil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblpnlValue);
            this.Controls.Add(this.lblpnlRegisters);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WriteCoil";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.Text = "Write Coil";
            this.Load += new System.EventHandler(this.WriteCoil_Load);
            this.lblpnlRegisters.ResumeLayout(false);
            this.lblpnlRegisters.PerformLayout();
            this.lblpnlQuantity.ResumeLayout(false);
            this.lblpnlAddress.ResumeLayout(false);
            this.labelPanel1.ResumeLayout(false);
            this.lblpnlValue.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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