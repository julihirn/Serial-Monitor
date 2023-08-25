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
            this.numericTextbox1 = new ODModules.NumericTextbox();
            this.flatComboBox1 = new ODModules.FlatComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.numericTextbox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.numericTextbox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextbox1.ForeColor = System.Drawing.Color.White;
            this.numericTextbox1.FormatOutput = true;
            this.numericTextbox1.HasUnit = true;
            this.numericTextbox1.IsMetric = true;
            this.numericTextbox1.IsSecondaryMetric = false;
            this.numericTextbox1.LabelFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextbox1.LabelForeColor = System.Drawing.Color.Gray;
            this.numericTextbox1.LabelText = "";
            this.numericTextbox1.Location = new System.Drawing.Point(3, 0);
            numericalString1.DisplayValue = "100";
            numericalString1.Value = "100";
            this.numericTextbox1.Maximum = numericalString1;
            numericalString2.DisplayValue = "0";
            numericalString2.Value = "0";
            this.numericTextbox1.Minimum = numericalString2;
            this.numericTextbox1.Name = "numericTextbox1";
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
            this.numericTextbox1.Size = new System.Drawing.Size(268, 29);
            this.numericTextbox1.TabIndex = 2;
            this.numericTextbox1.Unit = "";
            this.numericTextbox1.Value = "0";
            this.numericTextbox1.Visible = false;
            this.numericTextbox1.Leave += new System.EventHandler(this.numericTextbox1_Leave);
            // 
            // flatComboBox1
            // 
            this.flatComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.flatComboBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.flatComboBox1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.flatComboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flatComboBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.flatComboBox1.ForeColor = System.Drawing.Color.White;
            this.flatComboBox1.FormattingEnabled = true;
            this.flatComboBox1.Location = new System.Drawing.Point(3, 29);
            this.flatComboBox1.Name = "flatComboBox1";
            this.flatComboBox1.Size = new System.Drawing.Size(268, 21);
            this.flatComboBox1.TabIndex = 3;
            this.flatComboBox1.Visible = false;
            this.flatComboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flatComboBox1_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(3, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 18);
            this.textBox1.TabIndex = 4;
            this.textBox1.Visible = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(3, 68);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox3);
            this.splitContainer1.Size = new System.Drawing.Size(268, 29);
            this.splitContainer1.SplitterDistance = 86;
            this.splitContainer1.TabIndex = 6;
            this.splitContainer1.TabStop = false;
            this.splitContainer1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(86, 18);
            this.textBox2.TabIndex = 0;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(178, 18);
            this.textBox3.TabIndex = 1;
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            // 
            // EditValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.flatComboBox1);
            this.Controls.Add(this.numericTextbox1);
            this.DoubleBuffered = true;
            this.Name = "EditValue";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.Size = new System.Drawing.Size(271, 157);
            this.Load += new System.EventHandler(this.EditValue_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditValue_KeyDown);
            this.Leave += new System.EventHandler(this.EditValue_Leave);
            this.Validated += new System.EventHandler(this.EditValue_Validated);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ODModules.NumericTextbox numericTextbox1;
        private TextBox textBox1;
        private SplitContainer splitContainer1;
        private TextBox textBox2;
        private TextBox textBox3;
        public ODModules.FlatComboBox flatComboBox1;
    }
}
