namespace Serial_Monitor.Dialogs {
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
            this.lblpnlDisplayName = new ODModules.LabelPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblpnlRegisters = new ODModules.LabelPanel();
            this.lblpnlQuantity = new ODModules.LabelPanel();
            this.numtxtQuantity = new ODModules.NumericTextbox();
            this.lblpnlAddress = new ODModules.LabelPanel();
            this.numtxtAddress = new ODModules.NumericTextbox();
            this.labelPanel1 = new ODModules.LabelPanel();
            this.cmbxDataSet = new ODModules.FlatComboBox();
            this.btnCancel = new ODModules.Button();
            this.btnAccept = new ODModules.Button();
            this.btnHiddenAccept = new System.Windows.Forms.Button();
            this.btnHiddenCancel = new System.Windows.Forms.Button();
            this.lblpnlChannel = new ODModules.LabelPanel();
            this.btngridChannels = new ODModules.ButtonGrid();
            this.lblpnlDisplayName.SuspendLayout();
            this.lblpnlRegisters.SuspendLayout();
            this.lblpnlQuantity.SuspendLayout();
            this.lblpnlAddress.SuspendLayout();
            this.labelPanel1.SuspendLayout();
            this.lblpnlChannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblpnlDisplayName
            // 
            this.lblpnlDisplayName.ArrowColor = System.Drawing.Color.LightGray;
            this.lblpnlDisplayName.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.lblpnlDisplayName.AutoSize = true;
            this.lblpnlDisplayName.CloseColor = System.Drawing.Color.Black;
            this.lblpnlDisplayName.CloseMouseOverColor = System.Drawing.Color.Red;
            this.lblpnlDisplayName.Collapsed = false;
            this.lblpnlDisplayName.Controls.Add(this.textBox1);
            this.lblpnlDisplayName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblpnlDisplayName.DropShadow = false;
            this.lblpnlDisplayName.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblpnlDisplayName.FixedInlineWidth = false;
            this.lblpnlDisplayName.ForeColor = System.Drawing.Color.White;
            this.lblpnlDisplayName.Inlinelabel = false;
            this.lblpnlDisplayName.InlineWidth = 100;
            this.lblpnlDisplayName.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lblpnlDisplayName.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblpnlDisplayName.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblpnlDisplayName.Location = new System.Drawing.Point(10, 10);
            this.lblpnlDisplayName.Name = "lblpnlDisplayName";
            this.lblpnlDisplayName.OverrideCollapseControl = false;
            this.lblpnlDisplayName.Padding = new System.Windows.Forms.Padding(5, 18, 5, 5);
            this.lblpnlDisplayName.PanelCollapsible = false;
            this.lblpnlDisplayName.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlDisplayName.ShowCloseButton = false;
            this.lblpnlDisplayName.Size = new System.Drawing.Size(323, 39);
            this.lblpnlDisplayName.TabIndex = 1;
            this.lblpnlDisplayName.Text = "Display Name";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(5, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(313, 16);
            this.textBox1.TabIndex = 0;
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
            this.lblpnlRegisters.Location = new System.Drawing.Point(10, 158);
            this.lblpnlRegisters.Name = "lblpnlRegisters";
            this.lblpnlRegisters.OverrideCollapseControl = false;
            this.lblpnlRegisters.Padding = new System.Windows.Forms.Padding(5, 18, 5, 5);
            this.lblpnlRegisters.PanelCollapsible = false;
            this.lblpnlRegisters.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlRegisters.ShowCloseButton = false;
            this.lblpnlRegisters.Size = new System.Drawing.Size(323, 122);
            this.lblpnlRegisters.TabIndex = 3;
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
            this.lblpnlQuantity.Controls.Add(this.numtxtQuantity);
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
            this.lblpnlQuantity.Size = new System.Drawing.Size(313, 33);
            this.lblpnlQuantity.TabIndex = 2;
            this.lblpnlQuantity.Text = "Quantity";
            // 
            // numtxtQuantity
            // 
            this.numtxtQuantity.AllowClipboard = true;
            this.numtxtQuantity.AllowDragValueChange = true;
            this.numtxtQuantity.AllowFractionals = false;
            this.numtxtQuantity.AllowMouseWheel = true;
            this.numtxtQuantity.AllowNegatives = false;
            this.numtxtQuantity.AllowNumberEntry = true;
            this.numtxtQuantity.AllowTyping = true;
            this.numtxtQuantity.AutoSizeToText = false;
            this.numtxtQuantity.Base = ODModules.NumericTextbox.NumberBase.Base10;
            this.numtxtQuantity.BorderColor = System.Drawing.Color.DimGray;
            this.numtxtQuantity.ButtonDownColor = System.Drawing.Color.Gray;
            this.numtxtQuantity.ButtonHoverColor = System.Drawing.Color.LightGray;
            this.numtxtQuantity.Dock = System.Windows.Forms.DockStyle.Top;
            this.numtxtQuantity.FormatOutput = true;
            this.numtxtQuantity.HasUnit = false;
            this.numtxtQuantity.IsMetric = false;
            this.numtxtQuantity.IsSecondaryMetric = false;
            this.numtxtQuantity.LabelFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numtxtQuantity.LabelForeColor = System.Drawing.Color.Gray;
            this.numtxtQuantity.LabelText = "";
            this.numtxtQuantity.Location = new System.Drawing.Point(113, 5);
            this.numtxtQuantity.Marked = false;
            this.numtxtQuantity.MarkedBackColor = System.Drawing.Color.Empty;
            this.numtxtQuantity.MarkedBorderColor = System.Drawing.Color.Beige;
            numericalString1.DisplayValue = "1000";
            numericalString1.Value = "1000";
            this.numtxtQuantity.Maximum = numericalString1;
            numericalString2.DisplayValue = "1";
            numericalString2.Value = "1";
            this.numtxtQuantity.Minimum = numericalString2;
            this.numtxtQuantity.Name = "numtxtQuantity";
            this.numtxtQuantity.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Right;
            this.numtxtQuantity.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            this.numtxtQuantity.NumericalLeftRadixDigitsMaximum = 7;
            this.numtxtQuantity.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numtxtQuantity.RangeLimited = true;
            this.numtxtQuantity.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numtxtQuantity.SecondaryTag = null;
            this.numtxtQuantity.SecondaryUnit = "";
            this.numtxtQuantity.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            this.numtxtQuantity.SelectedBackColor = System.Drawing.Color.Empty;
            this.numtxtQuantity.SelectedBorderColor = System.Drawing.Color.Beige;
            this.numtxtQuantity.ShowLabel = true;
            this.numtxtQuantity.Size = new System.Drawing.Size(195, 23);
            this.numtxtQuantity.TabIndex = 0;
            this.numtxtQuantity.Unit = "";
            this.numtxtQuantity.Value = "1";
            // 
            // lblpnlAddress
            // 
            this.lblpnlAddress.ArrowColor = System.Drawing.Color.LightGray;
            this.lblpnlAddress.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.lblpnlAddress.AutoSize = true;
            this.lblpnlAddress.CloseColor = System.Drawing.Color.Black;
            this.lblpnlAddress.CloseMouseOverColor = System.Drawing.Color.Red;
            this.lblpnlAddress.Collapsed = false;
            this.lblpnlAddress.Controls.Add(this.numtxtAddress);
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
            this.lblpnlAddress.Size = new System.Drawing.Size(313, 33);
            this.lblpnlAddress.TabIndex = 1;
            this.lblpnlAddress.Text = "Address";
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
            this.numtxtAddress.Size = new System.Drawing.Size(195, 23);
            this.numtxtAddress.TabIndex = 0;
            this.numtxtAddress.Unit = "";
            this.numtxtAddress.Value = "0";
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
            this.labelPanel1.Size = new System.Drawing.Size(313, 33);
            this.labelPanel1.TabIndex = 0;
            this.labelPanel1.Text = "Data Set";
            // 
            // cmbxDataSet
            // 
            this.cmbxDataSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbxDataSet.FormattingEnabled = true;
            this.cmbxDataSet.Location = new System.Drawing.Point(113, 5);
            this.cmbxDataSet.Name = "cmbxDataSet";
            this.cmbxDataSet.Size = new System.Drawing.Size(195, 23);
            this.cmbxDataSet.TabIndex = 0;
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
            this.btnCancel.Location = new System.Drawing.Point(235, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButtonGroup = "";
            this.btnCancel.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.SecondaryText = "";
            this.btnCancel.Size = new System.Drawing.Size(93, 28);
            this.btnCancel.Style = ODModules.ButtonStyle.Square;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btnCancel.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.btnCancel.Type = ODModules.ButtonType.Button;
            this.btnCancel.ButtonClicked += new ODModules.Button.ButtonClickedHandler(this.btnCancel_ButtonClicked);
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
            this.btnAccept.Location = new System.Drawing.Point(136, 320);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.RadioButtonGroup = "";
            this.btnAccept.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAccept.SecondaryText = "";
            this.btnAccept.Size = new System.Drawing.Size(93, 28);
            this.btnAccept.Style = ODModules.ButtonStyle.Square;
            this.btnAccept.TabIndex = 4;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btnAccept.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.btnAccept.Type = ODModules.ButtonType.Button;
            this.btnAccept.ButtonClicked += new ODModules.Button.ButtonClickedHandler(this.btnAccept_ButtonClicked);
            this.btnAccept.Load += new System.EventHandler(this.btnAccept_Load);
            // 
            // btnHiddenAccept
            // 
            this.btnHiddenAccept.Location = new System.Drawing.Point(317, 251);
            this.btnHiddenAccept.Name = "btnHiddenAccept";
            this.btnHiddenAccept.Size = new System.Drawing.Size(16, 15);
            this.btnHiddenAccept.TabIndex = 5;
            this.btnHiddenAccept.Text = "Acc";
            this.btnHiddenAccept.UseVisualStyleBackColor = true;
            this.btnHiddenAccept.Visible = false;
            this.btnHiddenAccept.Click += new System.EventHandler(this.btnHiddenAccept_Click);
            // 
            // btnHiddenCancel
            // 
            this.btnHiddenCancel.Location = new System.Drawing.Point(295, 251);
            this.btnHiddenCancel.Name = "btnHiddenCancel";
            this.btnHiddenCancel.Size = new System.Drawing.Size(16, 15);
            this.btnHiddenCancel.TabIndex = 6;
            this.btnHiddenCancel.Text = "Can";
            this.btnHiddenCancel.UseVisualStyleBackColor = true;
            this.btnHiddenCancel.Visible = false;
            this.btnHiddenCancel.Click += new System.EventHandler(this.btnHiddenCancel_Click);
            // 
            // lblpnlChannel
            // 
            this.lblpnlChannel.ArrowColor = System.Drawing.Color.LightGray;
            this.lblpnlChannel.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.lblpnlChannel.CloseColor = System.Drawing.Color.Black;
            this.lblpnlChannel.CloseMouseOverColor = System.Drawing.Color.Red;
            this.lblpnlChannel.Collapsed = false;
            this.lblpnlChannel.Controls.Add(this.btngridChannels);
            this.lblpnlChannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblpnlChannel.DropShadow = false;
            this.lblpnlChannel.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblpnlChannel.FixedInlineWidth = false;
            this.lblpnlChannel.ForeColor = System.Drawing.Color.White;
            this.lblpnlChannel.Inlinelabel = false;
            this.lblpnlChannel.InlineWidth = 100;
            this.lblpnlChannel.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lblpnlChannel.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblpnlChannel.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblpnlChannel.Location = new System.Drawing.Point(10, 49);
            this.lblpnlChannel.Name = "lblpnlChannel";
            this.lblpnlChannel.OverrideCollapseControl = false;
            this.lblpnlChannel.Padding = new System.Windows.Forms.Padding(5, 18, 5, 5);
            this.lblpnlChannel.PanelCollapsible = false;
            this.lblpnlChannel.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlChannel.ShowCloseButton = false;
            this.lblpnlChannel.Size = new System.Drawing.Size(323, 109);
            this.lblpnlChannel.TabIndex = 2;
            this.lblpnlChannel.Text = "Channel";
            // 
            // btngridChannels
            // 
            this.btngridChannels.AllowTextWrapping = false;
            this.btngridChannels.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.btngridChannels.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.btngridChannels.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.btngridChannels.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.btngridChannels.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.btngridChannels.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.btngridChannels.BackColorNorth = System.Drawing.Color.White;
            this.btngridChannels.BackColorSouth = System.Drawing.Color.White;
            this.btngridChannels.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.btngridChannels.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.btngridChannels.BorderColorDownNorth = System.Drawing.Color.Black;
            this.btngridChannels.BorderColorDownSouth = System.Drawing.Color.Black;
            this.btngridChannels.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.btngridChannels.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.btngridChannels.BorderColorNorth = System.Drawing.Color.Black;
            this.btngridChannels.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btngridChannels.BorderColorSouth = System.Drawing.Color.Black;
            this.btngridChannels.BorderRadius = 5;
            this.btngridChannels.ButtonPadding = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.btngridChannels.ButtonSize = new System.Drawing.Size(90, 30);
            this.btngridChannels.CenterButtons = true;
            this.btngridChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btngridChannels.Filter = "";
            this.btngridChannels.IconInline = false;
            this.btngridChannels.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btngridChannels.ImageSize = new System.Drawing.Size(32, 32);
            this.btngridChannels.Location = new System.Drawing.Point(5, 18);
            this.btngridChannels.Name = "btngridChannels";
            this.btngridChannels.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btngridChannels.ScrollBarMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btngridChannels.ScrollBarNorth = System.Drawing.Color.DarkTurquoise;
            this.btngridChannels.ScrollBarSouth = System.Drawing.Color.DeepSkyBlue;
            this.btngridChannels.SecondaryFont = null;
            this.btngridChannels.Size = new System.Drawing.Size(313, 86);
            this.btngridChannels.Style = ODModules.ButtonStyle.Square;
            this.btngridChannels.TabIndex = 0;
            this.btngridChannels.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btngridChannels.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.btngridChannels.VerScroll = 0;
            this.btngridChannels.ButtonClicked += new ODModules.ButtonGrid.ButtonClickedEventHandler(this.btngridChannels_ButtonClicked);
            // 
            // InsertModbusSnapshot
            // 
            this.AcceptButton = this.btnHiddenAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHiddenCancel;
            this.ClientSize = new System.Drawing.Size(343, 361);
            this.Controls.Add(this.lblpnlRegisters);
            this.Controls.Add(this.lblpnlChannel);
            this.Controls.Add(this.btnHiddenCancel);
            this.Controls.Add(this.btnHiddenAccept);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblpnlDisplayName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "InsertModbusSnapshot";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Modbus Snapshot";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InsertModbusSnapshot_Load);
            this.lblpnlDisplayName.ResumeLayout(false);
            this.lblpnlDisplayName.PerformLayout();
            this.lblpnlRegisters.ResumeLayout(false);
            this.lblpnlRegisters.PerformLayout();
            this.lblpnlQuantity.ResumeLayout(false);
            this.lblpnlAddress.ResumeLayout(false);
            this.labelPanel1.ResumeLayout(false);
            this.lblpnlChannel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ODModules.LabelPanel lblpnlDisplayName;
        private TextBox textBox1;
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
    }
}