namespace Serial_Monitor.Dialogs {
    partial class WriteMask {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteMask));
            lblpnlRegisters = new ODModules.LabelPanel();
            lblpnlQuantity = new ODModules.LabelPanel();
            numtxtAddress = new ODModules.NumericTextbox();
            lblpnlAddress = new ODModules.LabelPanel();
            numtxtUnit = new ODModules.NumericTextbox();
            labelPanel1 = new ODModules.LabelPanel();
            cmbxDataSet = new ODModules.FlatComboBox();
            panel2 = new Panel();
            btnCancel = new ODModules.Button();
            btnAccept = new ODModules.Button();
            lblpnlAndMask = new ODModules.LabelPanel();
            btAnd = new ODModules.BitToggle();
            lblpnlOrMask = new ODModules.LabelPanel();
            btOr = new ODModules.BitToggle();
            splitContainer1 = new SplitContainer();
            lblpnlRegisters.SuspendLayout();
            lblpnlQuantity.SuspendLayout();
            lblpnlAddress.SuspendLayout();
            labelPanel1.SuspendLayout();
            panel2.SuspendLayout();
            lblpnlAndMask.SuspendLayout();
            lblpnlOrMask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            lblpnlRegisters.Location = new Point(10, 10);
            lblpnlRegisters.Name = "lblpnlRegisters";
            lblpnlRegisters.OverrideCollapseControl = false;
            lblpnlRegisters.Padding = new Padding(5, 18, 5, 5);
            lblpnlRegisters.PanelCollapsible = false;
            lblpnlRegisters.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlRegisters.ShowCloseButton = false;
            lblpnlRegisters.Size = new Size(264, 122);
            lblpnlRegisters.TabIndex = 8;
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
            lblpnlQuantity.Location = new Point(5, 84);
            lblpnlQuantity.Name = "lblpnlQuantity";
            lblpnlQuantity.OverrideCollapseControl = false;
            lblpnlQuantity.Padding = new Padding(113, 5, 5, 5);
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
            numtxtAddress.Location = new Point(113, 5);
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
            numtxtAddress.Size = new Size(136, 23);
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
            lblpnlAddress.Location = new Point(5, 51);
            lblpnlAddress.Name = "lblpnlAddress";
            lblpnlAddress.OverrideCollapseControl = false;
            lblpnlAddress.Padding = new Padding(113, 5, 5, 5);
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
            numtxtUnit.Location = new Point(113, 5);
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
            numtxtUnit.Size = new Size(136, 23);
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
            labelPanel1.Location = new Point(5, 18);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = false;
            labelPanel1.Padding = new Padding(113, 5, 5, 5);
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
            cmbxDataSet.Size = new Size(136, 23);
            cmbxDataSet.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnCancel);
            panel2.Controls.Add(btnAccept);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(10, 351);
            panel2.Name = "panel2";
            panel2.Size = new Size(264, 40);
            panel2.TabIndex = 14;
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
            btnCancel.Location = new Point(154, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.RadioButtonGroup = "";
            btnCancel.SecondaryFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.SecondaryText = "";
            btnCancel.Size = new Size(93, 28);
            btnCancel.Style = ODModules.ButtonStyle.Square;
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnCancel.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnCancel.Type = ODModules.ButtonType.Button;
            btnCancel.ButtonClicked += btnCancel_ButtonClicked;
            btnCancel.Load += btnCancel_Load;
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
            btnAccept.Location = new Point(55, 12);
            btnAccept.Name = "btnAccept";
            btnAccept.RadioButtonGroup = "";
            btnAccept.SecondaryFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnAccept.SecondaryText = "";
            btnAccept.Size = new Size(93, 28);
            btnAccept.Style = ODModules.ButtonStyle.Square;
            btnAccept.TabIndex = 11;
            btnAccept.Text = "Send";
            btnAccept.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnAccept.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnAccept.Type = ODModules.ButtonType.Button;
            btnAccept.Load += btnAccept_Load;
            btnAccept.MouseClick += btnAccept_MouseClick;
            // 
            // lblpnlAndMask
            // 
            lblpnlAndMask.ArrowColor = Color.LightGray;
            lblpnlAndMask.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlAndMask.CloseColor = Color.Black;
            lblpnlAndMask.CloseMouseOverColor = Color.Red;
            lblpnlAndMask.Collapsed = false;
            lblpnlAndMask.Controls.Add(btAnd);
            lblpnlAndMask.Dock = DockStyle.Fill;
            lblpnlAndMask.DropShadow = false;
            lblpnlAndMask.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlAndMask.FixedInlineWidth = false;
            lblpnlAndMask.ForeColor = Color.White;
            lblpnlAndMask.Inlinelabel = false;
            lblpnlAndMask.InlineWidth = 100;
            lblpnlAndMask.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlAndMask.LabelFont = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblpnlAndMask.LabelForeColor = Color.WhiteSmoke;
            lblpnlAndMask.Location = new Point(0, 0);
            lblpnlAndMask.Name = "lblpnlAndMask";
            lblpnlAndMask.OverrideCollapseControl = false;
            lblpnlAndMask.Padding = new Padding(5, 18, 5, 5);
            lblpnlAndMask.PanelCollapsible = false;
            lblpnlAndMask.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlAndMask.ShowCloseButton = false;
            lblpnlAndMask.Size = new Size(264, 108);
            lblpnlAndMask.TabIndex = 15;
            lblpnlAndMask.Text = "AND Mask";
            // 
            // btAnd
            // 
            btAnd.ActiveToggleForeColor = Color.Black;
            btAnd.Bits = 32;
            btAnd.Dock = DockStyle.Fill;
            btAnd.InactiveToggleForeColor = Color.Gray;
            btAnd.Location = new Point(5, 18);
            btAnd.MouseDownForeColor = Color.WhiteSmoke;
            btAnd.MouseOverForeColor = Color.Blue;
            btAnd.Name = "btAnd";
            btAnd.Size = new Size(254, 85);
            btAnd.TabIndex = 1;
            btAnd.TogglerSize = ODModules.BitToggle.WordSize.Word;
            btAnd.Value = "0";
            // 
            // lblpnlOrMask
            // 
            lblpnlOrMask.ArrowColor = Color.LightGray;
            lblpnlOrMask.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlOrMask.CloseColor = Color.Black;
            lblpnlOrMask.CloseMouseOverColor = Color.Red;
            lblpnlOrMask.Collapsed = false;
            lblpnlOrMask.Controls.Add(btOr);
            lblpnlOrMask.Dock = DockStyle.Fill;
            lblpnlOrMask.DropShadow = false;
            lblpnlOrMask.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlOrMask.FixedInlineWidth = false;
            lblpnlOrMask.ForeColor = Color.White;
            lblpnlOrMask.Inlinelabel = false;
            lblpnlOrMask.InlineWidth = 100;
            lblpnlOrMask.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlOrMask.LabelFont = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblpnlOrMask.LabelForeColor = Color.WhiteSmoke;
            lblpnlOrMask.Location = new Point(0, 0);
            lblpnlOrMask.Name = "lblpnlOrMask";
            lblpnlOrMask.OverrideCollapseControl = false;
            lblpnlOrMask.Padding = new Padding(5, 18, 5, 5);
            lblpnlOrMask.PanelCollapsible = false;
            lblpnlOrMask.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlOrMask.ShowCloseButton = false;
            lblpnlOrMask.Size = new Size(264, 107);
            lblpnlOrMask.TabIndex = 16;
            lblpnlOrMask.Text = "OR Mask";
            // 
            // btOr
            // 
            btOr.ActiveToggleForeColor = Color.Black;
            btOr.Bits = 32;
            btOr.Dock = DockStyle.Fill;
            btOr.InactiveToggleForeColor = Color.Gray;
            btOr.Location = new Point(5, 18);
            btOr.MouseDownForeColor = Color.WhiteSmoke;
            btOr.MouseOverForeColor = Color.Blue;
            btOr.Name = "btOr";
            btOr.Size = new Size(254, 84);
            btOr.TabIndex = 2;
            btOr.TogglerSize = ODModules.BitToggle.WordSize.Word;
            btOr.Value = "0";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(10, 132);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lblpnlAndMask);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lblpnlOrMask);
            splitContainer1.Size = new Size(264, 219);
            splitContainer1.SplitterDistance = 108;
            splitContainer1.TabIndex = 17;
            // 
            // WriteMask
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 401);
            Controls.Add(splitContainer1);
            Controls.Add(panel2);
            Controls.Add(lblpnlRegisters);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WriteMask";
            Padding = new Padding(10);
            ShowInTaskbar = false;
            Text = "Write Mask";
            Load += WriteMask_Load;
            lblpnlRegisters.ResumeLayout(false);
            lblpnlRegisters.PerformLayout();
            lblpnlQuantity.ResumeLayout(false);
            lblpnlAddress.ResumeLayout(false);
            labelPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            lblpnlAndMask.ResumeLayout(false);
            lblpnlOrMask.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
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
        private Panel panel2;
        private ODModules.Button btnCancel;
        private ODModules.Button btnAccept;
        private ODModules.LabelPanel lblpnlAndMask;
        private ODModules.LabelPanel lblpnlOrMask;
        private ODModules.BitToggle btAnd;
        private ODModules.BitToggle btOr;
        private SplitContainer splitContainer1;
    }
}