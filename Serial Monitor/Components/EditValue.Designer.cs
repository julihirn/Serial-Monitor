namespace Serial_Monitor.Components {
    partial class EditValue {
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
            Handlers.NumericalString numericalString3 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString4 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString5 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString6 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString7 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString8 = new Handlers.NumericalString();
            this.numericTextbox1 = new ODModules.NumericTextbox();
            this.flatComboBox1 = new ODModules.FlatComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlDualText = new System.Windows.Forms.SplitContainer();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.pnlText = new System.Windows.Forms.Panel();
            this.pnlNumber = new System.Windows.Forms.Panel();
            this.pnlPoint = new System.Windows.Forms.Panel();
            this.btnGrabPoint = new ODModules.Button();
            this.spPnlPoint = new System.Windows.Forms.SplitContainer();
            this.numericTextbox2 = new ODModules.NumericTextbox();
            this.lblX = new System.Windows.Forms.Label();
            this.numericTextbox3 = new ODModules.NumericTextbox();
            this.lblY = new System.Windows.Forms.Label();
            this.pnlWaitUntilReceived = new System.Windows.Forms.SplitContainer();
            this.pnlSubWaitUnitRX = new System.Windows.Forms.SplitContainer();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblChannel = new System.Windows.Forms.Label();
            this.numericTextbox4 = new ODModules.NumericTextbox();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lblWaitFor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDualText)).BeginInit();
            this.pnlDualText.Panel1.SuspendLayout();
            this.pnlDualText.Panel2.SuspendLayout();
            this.pnlDualText.SuspendLayout();
            this.pnlText.SuspendLayout();
            this.pnlNumber.SuspendLayout();
            this.pnlPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPnlPoint)).BeginInit();
            this.spPnlPoint.Panel1.SuspendLayout();
            this.spPnlPoint.Panel2.SuspendLayout();
            this.spPnlPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWaitUntilReceived)).BeginInit();
            this.pnlWaitUntilReceived.Panel1.SuspendLayout();
            this.pnlWaitUntilReceived.Panel2.SuspendLayout();
            this.pnlWaitUntilReceived.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSubWaitUnitRX)).BeginInit();
            this.pnlSubWaitUnitRX.Panel1.SuspendLayout();
            this.pnlSubWaitUnitRX.Panel2.SuspendLayout();
            this.pnlSubWaitUnitRX.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericTextbox1
            // 
            this.numericTextbox1.AllowClipboard = true;
            this.numericTextbox1.AllowDragValueChange = true;
            this.numericTextbox1.AllowFractionals = false;
            this.numericTextbox1.AllowMouseWheel = true;
            this.numericTextbox1.AllowNegatives = false;
            this.numericTextbox1.AllowNumberEntry = true;
            this.numericTextbox1.AllowTyping = true;
            this.numericTextbox1.AutoSizeToText = false;
            this.numericTextbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.numericTextbox1.Base = ODModules.NumericTextbox.NumberBase.Base10;
            this.numericTextbox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.numericTextbox1.ButtonDownColor = System.Drawing.Color.Gray;
            this.numericTextbox1.ButtonHoverColor = System.Drawing.Color.LightGray;
            this.numericTextbox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericTextbox1.FixedNumericPadding = 0;
            this.numericTextbox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextbox1.ForeColor = System.Drawing.Color.White;
            this.numericTextbox1.FormatOutput = true;
            this.numericTextbox1.HasUnit = true;
            this.numericTextbox1.IsMetric = true;
            this.numericTextbox1.IsSecondaryMetric = false;
            this.numericTextbox1.LabelFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextbox1.LabelForeColor = System.Drawing.Color.Gray;
            this.numericTextbox1.LabelText = "";
            this.numericTextbox1.Location = new System.Drawing.Point(0, 0);
            this.numericTextbox1.Margin = new System.Windows.Forms.Padding(6);
            this.numericTextbox1.Marked = false;
            this.numericTextbox1.MarkedBackColor = System.Drawing.Color.Empty;
            this.numericTextbox1.MarkedBorderColor = System.Drawing.Color.Beige;
            numericalString1.DisplayValue = "100";
            numericalString1.Value = "100";
            this.numericTextbox1.Maximum = numericalString1;
            numericalString2.DisplayValue = "0";
            numericalString2.Value = "0";
            this.numericTextbox1.Minimum = numericalString2;
            this.numericTextbox1.Name = "numericTextbox1";
            this.numericTextbox1.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Left;
            this.numericTextbox1.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            this.numericTextbox1.NumericalLeftRadixDigitsMaximum = 7;
            this.numericTextbox1.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numericTextbox1.RangeLimited = false;
            this.numericTextbox1.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numericTextbox1.SecondaryTag = null;
            this.numericTextbox1.SecondaryUnit = "";
            this.numericTextbox1.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            this.numericTextbox1.SelectedBackColor = System.Drawing.Color.Empty;
            this.numericTextbox1.SelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.numericTextbox1.ShowLabel = true;
            this.numericTextbox1.Size = new System.Drawing.Size(849, 85);
            this.numericTextbox1.TabIndex = 2;
            this.numericTextbox1.Unit = "";
            this.numericTextbox1.UseFixedNumericPadding = false;
            this.numericTextbox1.Value = "0";
            // 
            // flatComboBox1
            // 
            this.flatComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.flatComboBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.flatComboBox1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.flatComboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flatComboBox1.Font = new System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flatComboBox1.ForeColor = System.Drawing.Color.White;
            this.flatComboBox1.FormattingEnabled = true;
            this.flatComboBox1.Location = new System.Drawing.Point(7, 66);
            this.flatComboBox1.Margin = new System.Windows.Forms.Padding(6);
            this.flatComboBox1.Name = "flatComboBox1";
            this.flatComboBox1.Size = new System.Drawing.Size(849, 39);
            this.flatComboBox1.TabIndex = 3;
            this.flatComboBox1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(849, 32);
            this.textBox1.TabIndex = 4;
            // 
            // pnlDualText
            // 
            this.pnlDualText.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDualText.Location = new System.Drawing.Point(7, 105);
            this.pnlDualText.Margin = new System.Windows.Forms.Padding(6);
            this.pnlDualText.Name = "pnlDualText";
            // 
            // pnlDualText.Panel1
            // 
            this.pnlDualText.Panel1.Controls.Add(this.textBox2);
            // 
            // pnlDualText.Panel2
            // 
            this.pnlDualText.Panel2.Controls.Add(this.textBox3);
            this.pnlDualText.Panel2.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlDualText.Size = new System.Drawing.Size(849, 62);
            this.pnlDualText.SplitterDistance = 268;
            this.pnlDualText.SplitterWidth = 7;
            this.pnlDualText.TabIndex = 6;
            this.pnlDualText.TabStop = false;
            this.pnlDualText.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6);
            this.textBox2.Name = "textBox2";
            this.textBox2.PlaceholderText = "Name";
            this.textBox2.Size = new System.Drawing.Size(268, 32);
            this.textBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(6, 0);
            this.textBox3.Margin = new System.Windows.Forms.Padding(6);
            this.textBox3.Name = "textBox3";
            this.textBox3.PlaceholderText = "Assignment/Expression";
            this.textBox3.Size = new System.Drawing.Size(568, 32);
            this.textBox3.TabIndex = 1;
            // 
            // pnlText
            // 
            this.pnlText.Controls.Add(this.textBox1);
            this.pnlText.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlText.Location = new System.Drawing.Point(7, 2);
            this.pnlText.Margin = new System.Windows.Forms.Padding(6);
            this.pnlText.Name = "pnlText";
            this.pnlText.Size = new System.Drawing.Size(849, 64);
            this.pnlText.TabIndex = 7;
            this.pnlText.Visible = false;
            // 
            // pnlNumber
            // 
            this.pnlNumber.Controls.Add(this.numericTextbox1);
            this.pnlNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNumber.Location = new System.Drawing.Point(7, 167);
            this.pnlNumber.Margin = new System.Windows.Forms.Padding(6);
            this.pnlNumber.Name = "pnlNumber";
            this.pnlNumber.Size = new System.Drawing.Size(849, 85);
            this.pnlNumber.TabIndex = 8;
            this.pnlNumber.Visible = false;
            // 
            // pnlPoint
            // 
            this.pnlPoint.Controls.Add(this.btnGrabPoint);
            this.pnlPoint.Controls.Add(this.spPnlPoint);
            this.pnlPoint.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPoint.Location = new System.Drawing.Point(7, 252);
            this.pnlPoint.Margin = new System.Windows.Forms.Padding(6);
            this.pnlPoint.Name = "pnlPoint";
            this.pnlPoint.Size = new System.Drawing.Size(849, 49);
            this.pnlPoint.TabIndex = 9;
            this.pnlPoint.Visible = false;
            // 
            // btnGrabPoint
            // 
            this.btnGrabPoint.AllowGroupUnchecking = false;
            this.btnGrabPoint.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.btnGrabPoint.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.btnGrabPoint.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.btnGrabPoint.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.btnGrabPoint.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.btnGrabPoint.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.btnGrabPoint.BackColorNorth = System.Drawing.Color.White;
            this.btnGrabPoint.BackColorSouth = System.Drawing.Color.White;
            this.btnGrabPoint.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.btnGrabPoint.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.btnGrabPoint.BorderColorDownNorth = System.Drawing.Color.Black;
            this.btnGrabPoint.BorderColorDownSouth = System.Drawing.Color.Black;
            this.btnGrabPoint.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.btnGrabPoint.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.btnGrabPoint.BorderColorNorth = System.Drawing.Color.Black;
            this.btnGrabPoint.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGrabPoint.BorderColorSouth = System.Drawing.Color.Black;
            this.btnGrabPoint.BorderRadius = 5;
            this.btnGrabPoint.Checked = false;
            this.btnGrabPoint.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGrabPoint.GroupMaximumChecked = 2;
            this.btnGrabPoint.Location = new System.Drawing.Point(712, 0);
            this.btnGrabPoint.Margin = new System.Windows.Forms.Padding(6);
            this.btnGrabPoint.Name = "btnGrabPoint";
            this.btnGrabPoint.RadioButtonGroup = "";
            this.btnGrabPoint.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGrabPoint.SecondaryText = "";
            this.btnGrabPoint.Size = new System.Drawing.Size(137, 49);
            this.btnGrabPoint.Style = ODModules.ButtonStyle.Square;
            this.btnGrabPoint.TabIndex = 8;
            this.btnGrabPoint.Text = "Get Point";
            this.btnGrabPoint.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btnGrabPoint.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.btnGrabPoint.Type = ODModules.ButtonType.Button;
            // 
            // spPnlPoint
            // 
            this.spPnlPoint.Dock = System.Windows.Forms.DockStyle.Left;
            this.spPnlPoint.IsSplitterFixed = true;
            this.spPnlPoint.Location = new System.Drawing.Point(0, 0);
            this.spPnlPoint.Margin = new System.Windows.Forms.Padding(6);
            this.spPnlPoint.Name = "spPnlPoint";
            // 
            // spPnlPoint.Panel1
            // 
            this.spPnlPoint.Panel1.Controls.Add(this.numericTextbox2);
            this.spPnlPoint.Panel1.Controls.Add(this.lblX);
            // 
            // spPnlPoint.Panel2
            // 
            this.spPnlPoint.Panel2.Controls.Add(this.numericTextbox3);
            this.spPnlPoint.Panel2.Controls.Add(this.lblY);
            this.spPnlPoint.Panel2.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.spPnlPoint.Size = new System.Drawing.Size(245, 49);
            this.spPnlPoint.SplitterDistance = 109;
            this.spPnlPoint.SplitterWidth = 7;
            this.spPnlPoint.TabIndex = 7;
            this.spPnlPoint.TabStop = false;
            // 
            // numericTextbox2
            // 
            this.numericTextbox2.AllowClipboard = true;
            this.numericTextbox2.AllowDragValueChange = true;
            this.numericTextbox2.AllowFractionals = false;
            this.numericTextbox2.AllowMouseWheel = true;
            this.numericTextbox2.AllowNegatives = true;
            this.numericTextbox2.AllowNumberEntry = true;
            this.numericTextbox2.AllowTyping = true;
            this.numericTextbox2.AutoSizeToText = false;
            this.numericTextbox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.numericTextbox2.Base = ODModules.NumericTextbox.NumberBase.Base10;
            this.numericTextbox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.numericTextbox2.ButtonDownColor = System.Drawing.Color.Gray;
            this.numericTextbox2.ButtonHoverColor = System.Drawing.Color.LightGray;
            this.numericTextbox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericTextbox2.FixedNumericPadding = 0;
            this.numericTextbox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextbox2.ForeColor = System.Drawing.Color.White;
            this.numericTextbox2.FormatOutput = true;
            this.numericTextbox2.HasUnit = true;
            this.numericTextbox2.IsMetric = true;
            this.numericTextbox2.IsSecondaryMetric = false;
            this.numericTextbox2.LabelFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextbox2.LabelForeColor = System.Drawing.Color.Gray;
            this.numericTextbox2.LabelText = "";
            this.numericTextbox2.Location = new System.Drawing.Point(28, 0);
            this.numericTextbox2.Margin = new System.Windows.Forms.Padding(6);
            this.numericTextbox2.Marked = false;
            this.numericTextbox2.MarkedBackColor = System.Drawing.Color.Empty;
            this.numericTextbox2.MarkedBorderColor = System.Drawing.Color.Beige;
            numericalString3.DisplayValue = "100";
            numericalString3.Value = "100";
            this.numericTextbox2.Maximum = numericalString3;
            numericalString4.DisplayValue = "0";
            numericalString4.Value = "0";
            this.numericTextbox2.Minimum = numericalString4;
            this.numericTextbox2.Name = "numericTextbox2";
            this.numericTextbox2.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Left;
            this.numericTextbox2.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            this.numericTextbox2.NumericalLeftRadixDigitsMaximum = 7;
            this.numericTextbox2.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numericTextbox2.RangeLimited = false;
            this.numericTextbox2.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numericTextbox2.SecondaryTag = null;
            this.numericTextbox2.SecondaryUnit = "";
            this.numericTextbox2.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            this.numericTextbox2.SelectedBackColor = System.Drawing.Color.Empty;
            this.numericTextbox2.SelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.numericTextbox2.ShowLabel = true;
            this.numericTextbox2.Size = new System.Drawing.Size(81, 49);
            this.numericTextbox2.TabIndex = 3;
            this.numericTextbox2.Unit = "";
            this.numericTextbox2.UseFixedNumericPadding = false;
            this.numericTextbox2.Value = "0";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblX.Location = new System.Drawing.Point(0, 0);
            this.lblX.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(28, 32);
            this.lblX.TabIndex = 4;
            this.lblX.Text = "X";
            // 
            // numericTextbox3
            // 
            this.numericTextbox3.AllowClipboard = true;
            this.numericTextbox3.AllowDragValueChange = true;
            this.numericTextbox3.AllowFractionals = false;
            this.numericTextbox3.AllowMouseWheel = true;
            this.numericTextbox3.AllowNegatives = true;
            this.numericTextbox3.AllowNumberEntry = true;
            this.numericTextbox3.AllowTyping = true;
            this.numericTextbox3.AutoSizeToText = false;
            this.numericTextbox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.numericTextbox3.Base = ODModules.NumericTextbox.NumberBase.Base10;
            this.numericTextbox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.numericTextbox3.ButtonDownColor = System.Drawing.Color.Gray;
            this.numericTextbox3.ButtonHoverColor = System.Drawing.Color.LightGray;
            this.numericTextbox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericTextbox3.FixedNumericPadding = 0;
            this.numericTextbox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextbox3.ForeColor = System.Drawing.Color.White;
            this.numericTextbox3.FormatOutput = true;
            this.numericTextbox3.HasUnit = true;
            this.numericTextbox3.IsMetric = true;
            this.numericTextbox3.IsSecondaryMetric = false;
            this.numericTextbox3.LabelFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextbox3.LabelForeColor = System.Drawing.Color.Gray;
            this.numericTextbox3.LabelText = "";
            this.numericTextbox3.Location = new System.Drawing.Point(33, 0);
            this.numericTextbox3.Margin = new System.Windows.Forms.Padding(6);
            this.numericTextbox3.Marked = false;
            this.numericTextbox3.MarkedBackColor = System.Drawing.Color.Empty;
            this.numericTextbox3.MarkedBorderColor = System.Drawing.Color.Beige;
            numericalString5.DisplayValue = "100";
            numericalString5.Value = "100";
            this.numericTextbox3.Maximum = numericalString5;
            numericalString6.DisplayValue = "0";
            numericalString6.Value = "0";
            this.numericTextbox3.Minimum = numericalString6;
            this.numericTextbox3.Name = "numericTextbox3";
            this.numericTextbox3.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Left;
            this.numericTextbox3.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            this.numericTextbox3.NumericalLeftRadixDigitsMaximum = 7;
            this.numericTextbox3.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numericTextbox3.RangeLimited = false;
            this.numericTextbox3.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numericTextbox3.SecondaryTag = null;
            this.numericTextbox3.SecondaryUnit = "";
            this.numericTextbox3.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            this.numericTextbox3.SelectedBackColor = System.Drawing.Color.Empty;
            this.numericTextbox3.SelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.numericTextbox3.ShowLabel = true;
            this.numericTextbox3.Size = new System.Drawing.Size(96, 49);
            this.numericTextbox3.TabIndex = 3;
            this.numericTextbox3.Unit = "";
            this.numericTextbox3.UseFixedNumericPadding = false;
            this.numericTextbox3.Value = "0";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblY.Location = new System.Drawing.Point(6, 0);
            this.lblY.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(27, 32);
            this.lblY.TabIndex = 5;
            this.lblY.Text = "Y";
            // 
            // pnlWaitUntilReceived
            // 
            this.pnlWaitUntilReceived.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWaitUntilReceived.Location = new System.Drawing.Point(7, 301);
            this.pnlWaitUntilReceived.Margin = new System.Windows.Forms.Padding(6);
            this.pnlWaitUntilReceived.Name = "pnlWaitUntilReceived";
            // 
            // pnlWaitUntilReceived.Panel1
            // 
            this.pnlWaitUntilReceived.Panel1.Controls.Add(this.pnlSubWaitUnitRX);
            // 
            // pnlWaitUntilReceived.Panel2
            // 
            this.pnlWaitUntilReceived.Panel2.Controls.Add(this.textBox5);
            this.pnlWaitUntilReceived.Panel2.Controls.Add(this.lblWaitFor);
            this.pnlWaitUntilReceived.Panel2.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlWaitUntilReceived.Size = new System.Drawing.Size(849, 55);
            this.pnlWaitUntilReceived.SplitterDistance = 509;
            this.pnlWaitUntilReceived.SplitterWidth = 7;
            this.pnlWaitUntilReceived.TabIndex = 10;
            this.pnlWaitUntilReceived.TabStop = false;
            this.pnlWaitUntilReceived.Visible = false;
            // 
            // pnlSubWaitUnitRX
            // 
            this.pnlSubWaitUnitRX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubWaitUnitRX.Location = new System.Drawing.Point(0, 0);
            this.pnlSubWaitUnitRX.Margin = new System.Windows.Forms.Padding(6);
            this.pnlSubWaitUnitRX.Name = "pnlSubWaitUnitRX";
            // 
            // pnlSubWaitUnitRX.Panel1
            // 
            this.pnlSubWaitUnitRX.Panel1.Controls.Add(this.textBox4);
            this.pnlSubWaitUnitRX.Panel1.Controls.Add(this.lblChannel);
            // 
            // pnlSubWaitUnitRX.Panel2
            // 
            this.pnlSubWaitUnitRX.Panel2.Controls.Add(this.numericTextbox4);
            this.pnlSubWaitUnitRX.Panel2.Controls.Add(this.lblTimeOut);
            this.pnlSubWaitUnitRX.Panel2.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.pnlSubWaitUnitRX.Size = new System.Drawing.Size(509, 55);
            this.pnlSubWaitUnitRX.SplitterDistance = 244;
            this.pnlSubWaitUnitRX.SplitterWidth = 7;
            this.pnlSubWaitUnitRX.TabIndex = 11;
            this.pnlSubWaitUnitRX.TabStop = false;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(102, 0);
            this.textBox4.Margin = new System.Windows.Forms.Padding(6);
            this.textBox4.Name = "textBox4";
            this.textBox4.PlaceholderText = "Name";
            this.textBox4.Size = new System.Drawing.Size(142, 32);
            this.textBox4.TabIndex = 0;
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblChannel.Location = new System.Drawing.Point(0, 0);
            this.lblChannel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(102, 32);
            this.lblChannel.TabIndex = 5;
            this.lblChannel.Text = "Channel";
            // 
            // numericTextbox4
            // 
            this.numericTextbox4.AllowClipboard = true;
            this.numericTextbox4.AllowDragValueChange = true;
            this.numericTextbox4.AllowFractionals = false;
            this.numericTextbox4.AllowMouseWheel = true;
            this.numericTextbox4.AllowNegatives = false;
            this.numericTextbox4.AllowNumberEntry = true;
            this.numericTextbox4.AllowTyping = true;
            this.numericTextbox4.AutoSizeToText = false;
            this.numericTextbox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.numericTextbox4.Base = ODModules.NumericTextbox.NumberBase.Base10;
            this.numericTextbox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.numericTextbox4.ButtonDownColor = System.Drawing.Color.Gray;
            this.numericTextbox4.ButtonHoverColor = System.Drawing.Color.LightGray;
            this.numericTextbox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericTextbox4.FixedNumericPadding = 0;
            this.numericTextbox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextbox4.ForeColor = System.Drawing.Color.White;
            this.numericTextbox4.FormatOutput = true;
            this.numericTextbox4.HasUnit = true;
            this.numericTextbox4.IsMetric = true;
            this.numericTextbox4.IsSecondaryMetric = false;
            this.numericTextbox4.LabelFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextbox4.LabelForeColor = System.Drawing.Color.Gray;
            this.numericTextbox4.LabelText = "";
            this.numericTextbox4.Location = new System.Drawing.Point(120, 0);
            this.numericTextbox4.Margin = new System.Windows.Forms.Padding(6);
            this.numericTextbox4.Marked = false;
            this.numericTextbox4.MarkedBackColor = System.Drawing.Color.Empty;
            this.numericTextbox4.MarkedBorderColor = System.Drawing.Color.Beige;
            numericalString7.DisplayValue = "100000";
            numericalString7.Value = "100000";
            this.numericTextbox4.Maximum = numericalString7;
            numericalString8.DisplayValue = "1";
            numericalString8.Value = "1";
            this.numericTextbox4.Minimum = numericalString8;
            this.numericTextbox4.Name = "numericTextbox4";
            this.numericTextbox4.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Left;
            this.numericTextbox4.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            this.numericTextbox4.NumericalLeftRadixDigitsMaximum = 7;
            this.numericTextbox4.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numericTextbox4.RangeLimited = true;
            this.numericTextbox4.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            this.numericTextbox4.SecondaryTag = null;
            this.numericTextbox4.SecondaryUnit = "";
            this.numericTextbox4.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            this.numericTextbox4.SelectedBackColor = System.Drawing.Color.Empty;
            this.numericTextbox4.SelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.numericTextbox4.ShowLabel = true;
            this.numericTextbox4.Size = new System.Drawing.Size(138, 55);
            this.numericTextbox4.TabIndex = 3;
            this.numericTextbox4.Unit = "";
            this.numericTextbox4.UseFixedNumericPadding = false;
            this.numericTextbox4.Value = "0";
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTimeOut.Location = new System.Drawing.Point(6, 0);
            this.lblTimeOut.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(114, 32);
            this.lblTimeOut.TabIndex = 6;
            this.lblTimeOut.Text = "Time Out";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox5.ForeColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(108, 0);
            this.textBox5.Margin = new System.Windows.Forms.Padding(6);
            this.textBox5.Name = "textBox5";
            this.textBox5.PlaceholderText = "Assignment/Expression";
            this.textBox5.Size = new System.Drawing.Size(225, 32);
            this.textBox5.TabIndex = 1;
            // 
            // lblWaitFor
            // 
            this.lblWaitFor.AutoSize = true;
            this.lblWaitFor.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblWaitFor.Location = new System.Drawing.Point(6, 0);
            this.lblWaitFor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWaitFor.Name = "lblWaitFor";
            this.lblWaitFor.Size = new System.Drawing.Size(102, 32);
            this.lblWaitFor.TabIndex = 7;
            this.lblWaitFor.Text = "Wait For";
            // 
            // EditValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlWaitUntilReceived);
            this.Controls.Add(this.pnlPoint);
            this.Controls.Add(this.pnlNumber);
            this.Controls.Add(this.pnlDualText);
            this.Controls.Add(this.flatComboBox1);
            this.Controls.Add(this.pnlText);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EditValue";
            this.Padding = new System.Windows.Forms.Padding(7, 2, 2, 2);
            this.Size = new System.Drawing.Size(858, 498);
            this.pnlDualText.Panel1.ResumeLayout(false);
            this.pnlDualText.Panel1.PerformLayout();
            this.pnlDualText.Panel2.ResumeLayout(false);
            this.pnlDualText.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDualText)).EndInit();
            this.pnlDualText.ResumeLayout(false);
            this.pnlText.ResumeLayout(false);
            this.pnlText.PerformLayout();
            this.pnlNumber.ResumeLayout(false);
            this.pnlPoint.ResumeLayout(false);
            this.spPnlPoint.Panel1.ResumeLayout(false);
            this.spPnlPoint.Panel1.PerformLayout();
            this.spPnlPoint.Panel2.ResumeLayout(false);
            this.spPnlPoint.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spPnlPoint)).EndInit();
            this.spPnlPoint.ResumeLayout(false);
            this.pnlWaitUntilReceived.Panel1.ResumeLayout(false);
            this.pnlWaitUntilReceived.Panel2.ResumeLayout(false);
            this.pnlWaitUntilReceived.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlWaitUntilReceived)).EndInit();
            this.pnlWaitUntilReceived.ResumeLayout(false);
            this.pnlSubWaitUnitRX.Panel1.ResumeLayout(false);
            this.pnlSubWaitUnitRX.Panel1.PerformLayout();
            this.pnlSubWaitUnitRX.Panel2.ResumeLayout(false);
            this.pnlSubWaitUnitRX.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSubWaitUnitRX)).EndInit();
            this.pnlSubWaitUnitRX.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ODModules.NumericTextbox numericTextbox1;
        private TextBox textBox1;
        private SplitContainer pnlDualText;
        private TextBox textBox2;
        private TextBox textBox3;
        public ODModules.FlatComboBox flatComboBox1;
        private Panel pnlText;
        private Panel pnlNumber;
        private Panel pnlPoint;
        private SplitContainer spPnlPoint;
        private ODModules.NumericTextbox numericTextbox2;
        private Label lblX;
        private ODModules.NumericTextbox numericTextbox3;
        private Label lblY;
        private ODModules.Button btnGrabPoint;
        private SplitContainer pnlWaitUntilReceived;
        private SplitContainer pnlSubWaitUnitRX;
        private TextBox textBox4;
        private Label lblChannel;
        private ODModules.NumericTextbox numericTextbox4;
        private Label lblTimeOut;
        private TextBox textBox5;
        private Label lblWaitFor;
    }
}
