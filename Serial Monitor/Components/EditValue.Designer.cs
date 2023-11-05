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
            numericTextbox1 = new ODModules.NumericTextbox();
            flatComboBox1 = new ODModules.FlatComboBox();
            textBox1 = new TextBox();
            pnlDualText = new SplitContainer();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            pnlText = new Panel();
            pnlNumber = new Panel();
            pnlPoint = new Panel();
            btnGrabPoint = new ODModules.Button();
            spPnlPoint = new SplitContainer();
            numericTextbox2 = new ODModules.NumericTextbox();
            lblX = new Label();
            numericTextbox3 = new ODModules.NumericTextbox();
            lblY = new Label();
            ((System.ComponentModel.ISupportInitialize)pnlDualText).BeginInit();
            pnlDualText.Panel1.SuspendLayout();
            pnlDualText.Panel2.SuspendLayout();
            pnlDualText.SuspendLayout();
            pnlText.SuspendLayout();
            pnlNumber.SuspendLayout();
            pnlPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)spPnlPoint).BeginInit();
            spPnlPoint.Panel1.SuspendLayout();
            spPnlPoint.Panel2.SuspendLayout();
            spPnlPoint.SuspendLayout();
            SuspendLayout();
            // 
            // numericTextbox1
            // 
            numericTextbox1.AllowClipboard = true;
            numericTextbox1.AllowDragValueChange = true;
            numericTextbox1.AllowFractionals = false;
            numericTextbox1.AllowMouseWheel = true;
            numericTextbox1.AllowNegatives = false;
            numericTextbox1.AllowNumberEntry = true;
            numericTextbox1.AllowTyping = true;
            numericTextbox1.AutoSizeToText = false;
            numericTextbox1.BackColor = Color.FromArgb(16, 16, 16);
            numericTextbox1.Base = ODModules.NumericTextbox.NumberBase.Base10;
            numericTextbox1.BorderColor = Color.FromArgb(40, 40, 40);
            numericTextbox1.ButtonDownColor = Color.Gray;
            numericTextbox1.ButtonHoverColor = Color.LightGray;
            numericTextbox1.Dock = DockStyle.Fill;
            numericTextbox1.FixedNumericPadding = 0;
            numericTextbox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numericTextbox1.ForeColor = Color.White;
            numericTextbox1.FormatOutput = true;
            numericTextbox1.HasUnit = true;
            numericTextbox1.IsMetric = true;
            numericTextbox1.IsSecondaryMetric = false;
            numericTextbox1.LabelFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numericTextbox1.LabelForeColor = Color.Gray;
            numericTextbox1.LabelText = "";
            numericTextbox1.Location = new Point(0, 0);
            numericTextbox1.Marked = false;
            numericTextbox1.MarkedBackColor = Color.Empty;
            numericTextbox1.MarkedBorderColor = Color.Beige;
            numericalString1.DisplayValue = "100";
            numericalString1.Value = "100";
            numericTextbox1.Maximum = numericalString1;
            numericalString2.DisplayValue = "0";
            numericalString2.Value = "0";
            numericTextbox1.Minimum = numericalString2;
            numericTextbox1.Name = "numericTextbox1";
            numericTextbox1.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Left;
            numericTextbox1.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            numericTextbox1.NumericalLeftRadixDigitsMaximum = 7;
            numericTextbox1.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            numericTextbox1.RangeLimited = false;
            numericTextbox1.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            numericTextbox1.SecondaryTag = null;
            numericTextbox1.SecondaryUnit = "";
            numericTextbox1.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            numericTextbox1.SelectedBackColor = Color.Empty;
            numericTextbox1.SelectedBorderColor = Color.FromArgb(40, 40, 40);
            numericTextbox1.ShowLabel = true;
            numericTextbox1.Size = new Size(266, 40);
            numericTextbox1.TabIndex = 2;
            numericTextbox1.Unit = "";
            numericTextbox1.UseFixedNumericPadding = false;
            numericTextbox1.Value = "0";
            numericTextbox1.KeyDown += numericTextbox1_KeyDown;
            numericTextbox1.Leave += numericTextbox1_Leave;
            // 
            // flatComboBox1
            // 
            flatComboBox1.BackColor = Color.FromArgb(16, 16, 16);
            flatComboBox1.BorderColor = Color.FromArgb(40, 40, 40);
            flatComboBox1.ButtonColor = Color.FromArgb(64, 64, 64);
            flatComboBox1.Dock = DockStyle.Top;
            flatComboBox1.Font = new Font("Segoe UI", 8.75F, FontStyle.Regular, GraphicsUnit.Point);
            flatComboBox1.ForeColor = Color.White;
            flatComboBox1.FormattingEnabled = true;
            flatComboBox1.Location = new Point(4, 31);
            flatComboBox1.Name = "flatComboBox1";
            flatComboBox1.Size = new Size(266, 23);
            flatComboBox1.TabIndex = 3;
            flatComboBox1.Visible = false;
            flatComboBox1.KeyDown += flatComboBox1_KeyDown;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(16, 16, 16);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Dock = DockStyle.Fill;
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(0, 0);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(266, 16);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            textBox1.KeyPress += textBox1_KeyPress;
            textBox1.Leave += textBox1_Leave;
            // 
            // pnlDualText
            // 
            pnlDualText.Dock = DockStyle.Top;
            pnlDualText.Location = new Point(4, 54);
            pnlDualText.Name = "pnlDualText";
            // 
            // pnlDualText.Panel1
            // 
            pnlDualText.Panel1.Controls.Add(textBox2);
            // 
            // pnlDualText.Panel2
            // 
            pnlDualText.Panel2.Controls.Add(textBox3);
            pnlDualText.Panel2.Padding = new Padding(3, 0, 0, 0);
            pnlDualText.Size = new Size(266, 29);
            pnlDualText.SplitterDistance = 84;
            pnlDualText.TabIndex = 6;
            pnlDualText.TabStop = false;
            pnlDualText.Visible = false;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(16, 16, 16);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Dock = DockStyle.Fill;
            textBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(0, 0);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Name";
            textBox2.Size = new Size(84, 16);
            textBox2.TabIndex = 0;
            textBox2.KeyDown += textBox2_KeyDown;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(16, 16, 16);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Dock = DockStyle.Fill;
            textBox3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.ForeColor = Color.White;
            textBox3.Location = new Point(3, 0);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Assignment/Expression";
            textBox3.Size = new Size(175, 16);
            textBox3.TabIndex = 1;
            textBox3.KeyDown += textBox3_KeyDown;
            // 
            // pnlText
            // 
            pnlText.Controls.Add(textBox1);
            pnlText.Dock = DockStyle.Top;
            pnlText.Location = new Point(4, 1);
            pnlText.Name = "pnlText";
            pnlText.Size = new Size(266, 30);
            pnlText.TabIndex = 7;
            pnlText.Visible = false;
            // 
            // pnlNumber
            // 
            pnlNumber.Controls.Add(numericTextbox1);
            pnlNumber.Dock = DockStyle.Top;
            pnlNumber.Location = new Point(4, 83);
            pnlNumber.Name = "pnlNumber";
            pnlNumber.Size = new Size(266, 40);
            pnlNumber.TabIndex = 8;
            pnlNumber.Visible = false;
            // 
            // pnlPoint
            // 
            pnlPoint.Controls.Add(btnGrabPoint);
            pnlPoint.Controls.Add(spPnlPoint);
            pnlPoint.Dock = DockStyle.Top;
            pnlPoint.Location = new Point(4, 123);
            pnlPoint.Name = "pnlPoint";
            pnlPoint.Size = new Size(266, 23);
            pnlPoint.TabIndex = 9;
            pnlPoint.Visible = false;
            // 
            // btnGrabPoint
            // 
            btnGrabPoint.AllowGroupUnchecking = false;
            btnGrabPoint.BackColorCheckedNorth = Color.Orange;
            btnGrabPoint.BackColorCheckedSouth = Color.Orange;
            btnGrabPoint.BackColorDownNorth = Color.DimGray;
            btnGrabPoint.BackColorDownSouth = Color.DimGray;
            btnGrabPoint.BackColorHoverNorth = Color.SkyBlue;
            btnGrabPoint.BackColorHoverSouth = Color.SkyBlue;
            btnGrabPoint.BackColorNorth = Color.White;
            btnGrabPoint.BackColorSouth = Color.White;
            btnGrabPoint.BorderColorCheckedNorth = Color.Black;
            btnGrabPoint.BorderColorCheckedSouth = Color.Black;
            btnGrabPoint.BorderColorDownNorth = Color.Black;
            btnGrabPoint.BorderColorDownSouth = Color.Black;
            btnGrabPoint.BorderColorHoverNorth = Color.Black;
            btnGrabPoint.BorderColorHoverSouth = Color.Black;
            btnGrabPoint.BorderColorNorth = Color.Black;
            btnGrabPoint.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            btnGrabPoint.BorderColorSouth = Color.Black;
            btnGrabPoint.BorderRadius = 5;
            btnGrabPoint.Checked = false;
            btnGrabPoint.Dock = DockStyle.Right;
            btnGrabPoint.GroupMaximumChecked = 2;
            btnGrabPoint.Location = new Point(192, 0);
            btnGrabPoint.Name = "btnGrabPoint";
            btnGrabPoint.RadioButtonGroup = "";
            btnGrabPoint.SecondaryFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnGrabPoint.SecondaryText = "";
            btnGrabPoint.Size = new Size(74, 23);
            btnGrabPoint.Style = ODModules.ButtonStyle.Square;
            btnGrabPoint.TabIndex = 8;
            btnGrabPoint.Text = "Get Point";
            btnGrabPoint.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnGrabPoint.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnGrabPoint.Type = ODModules.ButtonType.Button;
            btnGrabPoint.KeyPress += btnGrabPoint_KeyPress;
            btnGrabPoint.MouseDown += btnGrabPoint_MouseDown;
            btnGrabPoint.MouseMove += btnGrabPoint_MouseMove;
            btnGrabPoint.MouseUp += btnGrabPoint_MouseUp;
            // 
            // spPnlPoint
            // 
            spPnlPoint.Dock = DockStyle.Left;
            spPnlPoint.IsSplitterFixed = true;
            spPnlPoint.Location = new Point(0, 0);
            spPnlPoint.Name = "spPnlPoint";
            // 
            // spPnlPoint.Panel1
            // 
            spPnlPoint.Panel1.Controls.Add(numericTextbox2);
            spPnlPoint.Panel1.Controls.Add(lblX);
            // 
            // spPnlPoint.Panel2
            // 
            spPnlPoint.Panel2.Controls.Add(numericTextbox3);
            spPnlPoint.Panel2.Controls.Add(lblY);
            spPnlPoint.Panel2.Padding = new Padding(3, 0, 0, 0);
            spPnlPoint.Size = new Size(132, 23);
            spPnlPoint.SplitterDistance = 63;
            spPnlPoint.TabIndex = 7;
            spPnlPoint.TabStop = false;
            // 
            // numericTextbox2
            // 
            numericTextbox2.AllowClipboard = true;
            numericTextbox2.AllowDragValueChange = true;
            numericTextbox2.AllowFractionals = false;
            numericTextbox2.AllowMouseWheel = true;
            numericTextbox2.AllowNegatives = true;
            numericTextbox2.AllowNumberEntry = true;
            numericTextbox2.AllowTyping = true;
            numericTextbox2.AutoSizeToText = false;
            numericTextbox2.BackColor = Color.FromArgb(16, 16, 16);
            numericTextbox2.Base = ODModules.NumericTextbox.NumberBase.Base10;
            numericTextbox2.BorderColor = Color.FromArgb(40, 40, 40);
            numericTextbox2.ButtonDownColor = Color.Gray;
            numericTextbox2.ButtonHoverColor = Color.LightGray;
            numericTextbox2.Dock = DockStyle.Fill;
            numericTextbox2.FixedNumericPadding = 0;
            numericTextbox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numericTextbox2.ForeColor = Color.White;
            numericTextbox2.FormatOutput = true;
            numericTextbox2.HasUnit = true;
            numericTextbox2.IsMetric = true;
            numericTextbox2.IsSecondaryMetric = false;
            numericTextbox2.LabelFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numericTextbox2.LabelForeColor = Color.Gray;
            numericTextbox2.LabelText = "";
            numericTextbox2.Location = new Point(14, 0);
            numericTextbox2.Marked = false;
            numericTextbox2.MarkedBackColor = Color.Empty;
            numericTextbox2.MarkedBorderColor = Color.Beige;
            numericalString3.DisplayValue = "100";
            numericalString3.Value = "100";
            numericTextbox2.Maximum = numericalString3;
            numericalString4.DisplayValue = "0";
            numericalString4.Value = "0";
            numericTextbox2.Minimum = numericalString4;
            numericTextbox2.Name = "numericTextbox2";
            numericTextbox2.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Left;
            numericTextbox2.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            numericTextbox2.NumericalLeftRadixDigitsMaximum = 7;
            numericTextbox2.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            numericTextbox2.RangeLimited = false;
            numericTextbox2.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            numericTextbox2.SecondaryTag = null;
            numericTextbox2.SecondaryUnit = "";
            numericTextbox2.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            numericTextbox2.SelectedBackColor = Color.Empty;
            numericTextbox2.SelectedBorderColor = Color.FromArgb(40, 40, 40);
            numericTextbox2.ShowLabel = true;
            numericTextbox2.Size = new Size(49, 23);
            numericTextbox2.TabIndex = 3;
            numericTextbox2.Unit = "";
            numericTextbox2.UseFixedNumericPadding = false;
            numericTextbox2.Value = "0";
            numericTextbox2.KeyDown += numericTextbox2_KeyDown;
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Dock = DockStyle.Left;
            lblX.Location = new Point(0, 0);
            lblX.Name = "lblX";
            lblX.Size = new Size(14, 15);
            lblX.TabIndex = 4;
            lblX.Text = "X";
            // 
            // numericTextbox3
            // 
            numericTextbox3.AllowClipboard = true;
            numericTextbox3.AllowDragValueChange = true;
            numericTextbox3.AllowFractionals = false;
            numericTextbox3.AllowMouseWheel = true;
            numericTextbox3.AllowNegatives = true;
            numericTextbox3.AllowNumberEntry = true;
            numericTextbox3.AllowTyping = true;
            numericTextbox3.AutoSizeToText = false;
            numericTextbox3.BackColor = Color.FromArgb(16, 16, 16);
            numericTextbox3.Base = ODModules.NumericTextbox.NumberBase.Base10;
            numericTextbox3.BorderColor = Color.FromArgb(40, 40, 40);
            numericTextbox3.ButtonDownColor = Color.Gray;
            numericTextbox3.ButtonHoverColor = Color.LightGray;
            numericTextbox3.Dock = DockStyle.Fill;
            numericTextbox3.FixedNumericPadding = 0;
            numericTextbox3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numericTextbox3.ForeColor = Color.White;
            numericTextbox3.FormatOutput = true;
            numericTextbox3.HasUnit = true;
            numericTextbox3.IsMetric = true;
            numericTextbox3.IsSecondaryMetric = false;
            numericTextbox3.LabelFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            numericTextbox3.LabelForeColor = Color.Gray;
            numericTextbox3.LabelText = "";
            numericTextbox3.Location = new Point(17, 0);
            numericTextbox3.Marked = false;
            numericTextbox3.MarkedBackColor = Color.Empty;
            numericTextbox3.MarkedBorderColor = Color.Beige;
            numericalString5.DisplayValue = "100";
            numericalString5.Value = "100";
            numericTextbox3.Maximum = numericalString5;
            numericalString6.DisplayValue = "0";
            numericalString6.Value = "0";
            numericTextbox3.Minimum = numericalString6;
            numericTextbox3.Name = "numericTextbox3";
            numericTextbox3.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Left;
            numericTextbox3.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            numericTextbox3.NumericalLeftRadixDigitsMaximum = 7;
            numericTextbox3.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            numericTextbox3.RangeLimited = false;
            numericTextbox3.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            numericTextbox3.SecondaryTag = null;
            numericTextbox3.SecondaryUnit = "";
            numericTextbox3.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            numericTextbox3.SelectedBackColor = Color.Empty;
            numericTextbox3.SelectedBorderColor = Color.FromArgb(40, 40, 40);
            numericTextbox3.ShowLabel = true;
            numericTextbox3.Size = new Size(48, 23);
            numericTextbox3.TabIndex = 3;
            numericTextbox3.Unit = "";
            numericTextbox3.UseFixedNumericPadding = false;
            numericTextbox3.Value = "0";
            numericTextbox3.KeyDown += numericTextbox3_KeyDown;
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Dock = DockStyle.Left;
            lblY.Location = new Point(3, 0);
            lblY.Name = "lblY";
            lblY.Size = new Size(14, 15);
            lblY.TabIndex = 5;
            lblY.Text = "Y";
            // 
            // EditValue
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlPoint);
            Controls.Add(pnlNumber);
            Controls.Add(pnlDualText);
            Controls.Add(flatComboBox1);
            Controls.Add(pnlText);
            DoubleBuffered = true;
            Name = "EditValue";
            Padding = new Padding(4, 1, 1, 1);
            Size = new Size(271, 167);
            Load += EditValue_Load;
            KeyDown += EditValue_KeyDown;
            Leave += EditValue_Leave;
            Resize += EditValue_Resize;
            Validated += EditValue_Validated;
            pnlDualText.Panel1.ResumeLayout(false);
            pnlDualText.Panel1.PerformLayout();
            pnlDualText.Panel2.ResumeLayout(false);
            pnlDualText.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlDualText).EndInit();
            pnlDualText.ResumeLayout(false);
            pnlText.ResumeLayout(false);
            pnlText.PerformLayout();
            pnlNumber.ResumeLayout(false);
            pnlPoint.ResumeLayout(false);
            spPnlPoint.Panel1.ResumeLayout(false);
            spPnlPoint.Panel1.PerformLayout();
            spPnlPoint.Panel2.ResumeLayout(false);
            spPnlPoint.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)spPnlPoint).EndInit();
            spPnlPoint.ResumeLayout(false);
            ResumeLayout(false);
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
    }
}
