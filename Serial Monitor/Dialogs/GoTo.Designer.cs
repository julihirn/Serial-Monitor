namespace Serial_Monitor.Dialogs {
    partial class GoTo {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoTo));
            this.lblpnlName = new ODModules.LabelPanel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblpnlAddress = new ODModules.LabelPanel();
            this.numtxtAddress = new ODModules.NumericTextbox();
            this.btnAccept = new ODModules.Button();
            this.btnCancel = new ODModules.Button();
            this.btnHiddenCancel = new System.Windows.Forms.Button();
            this.btnHiddenAccept = new System.Windows.Forms.Button();
            this.lblpnlName.SuspendLayout();
            this.lblpnlAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblpnlName
            // 
            this.lblpnlName.ArrowColor = System.Drawing.Color.LightGray;
            this.lblpnlName.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.lblpnlName.AutoSize = true;
            this.lblpnlName.CloseColor = System.Drawing.Color.Black;
            this.lblpnlName.CloseMouseOverColor = System.Drawing.Color.Red;
            this.lblpnlName.Collapsed = false;
            this.lblpnlName.Controls.Add(this.textBox2);
            this.lblpnlName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblpnlName.DropShadow = false;
            this.lblpnlName.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblpnlName.FixedInlineWidth = true;
            this.lblpnlName.ForeColor = System.Drawing.Color.White;
            this.lblpnlName.Inlinelabel = true;
            this.lblpnlName.InlineWidth = 100;
            this.lblpnlName.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lblpnlName.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblpnlName.LabelForeColor = System.Drawing.Color.Black;
            this.lblpnlName.Location = new System.Drawing.Point(5, 38);
            this.lblpnlName.Name = "lblpnlName";
            this.lblpnlName.OverrideCollapseControl = false;
            this.lblpnlName.Padding = new System.Windows.Forms.Padding(113, 5, 5, 5);
            this.lblpnlName.PanelCollapsible = false;
            this.lblpnlName.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlName.ShowCloseButton = false;
            this.lblpnlName.Size = new System.Drawing.Size(292, 26);
            this.lblpnlName.TabIndex = 7;
            this.lblpnlName.Text = "Go To Name";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(113, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 16);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
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
            this.lblpnlAddress.Location = new System.Drawing.Point(5, 5);
            this.lblpnlAddress.Name = "lblpnlAddress";
            this.lblpnlAddress.OverrideCollapseControl = false;
            this.lblpnlAddress.Padding = new System.Windows.Forms.Padding(113, 5, 5, 5);
            this.lblpnlAddress.PanelCollapsible = false;
            this.lblpnlAddress.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlAddress.ShowCloseButton = false;
            this.lblpnlAddress.Size = new System.Drawing.Size(292, 33);
            this.lblpnlAddress.TabIndex = 6;
            this.lblpnlAddress.Text = "Go To Address";
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
            this.numtxtAddress.Size = new System.Drawing.Size(174, 23);
            this.numtxtAddress.TabIndex = 0;
            this.numtxtAddress.Unit = "";
            this.numtxtAddress.UseFixedNumericPadding = true;
            this.numtxtAddress.Value = "0";
            this.numtxtAddress.EnterPressed += new ODModules.NumericTextbox.EnterKeyPressHandler(this.numtxtAddress_EnterPressed);
            this.numtxtAddress.EscapePressed += new ODModules.NumericTextbox.EscapeKeyPressHandler(this.numtxtAddress_EscapePressed);
            this.numtxtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numtxtAddress_KeyDown);
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
            this.btnAccept.Location = new System.Drawing.Point(105, 77);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.RadioButtonGroup = "";
            this.btnAccept.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAccept.SecondaryText = "";
            this.btnAccept.Size = new System.Drawing.Size(93, 28);
            this.btnAccept.Style = ODModules.ButtonStyle.Square;
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Ok";
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
            this.btnCancel.Location = new System.Drawing.Point(204, 77);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RadioButtonGroup = "";
            this.btnCancel.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.SecondaryText = "";
            this.btnCancel.Size = new System.Drawing.Size(93, 28);
            this.btnCancel.Style = ODModules.ButtonStyle.Square;
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btnCancel.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.btnCancel.Type = ODModules.ButtonType.Button;
            this.btnCancel.ButtonClicked += new ODModules.Button.ButtonClickedHandler(this.btnCancel_ButtonClicked);
            // 
            // btnHiddenCancel
            // 
            this.btnHiddenCancel.Location = new System.Drawing.Point(8, 77);
            this.btnHiddenCancel.Name = "btnHiddenCancel";
            this.btnHiddenCancel.Size = new System.Drawing.Size(11, 10);
            this.btnHiddenCancel.TabIndex = 11;
            this.btnHiddenCancel.Text = "Can";
            this.btnHiddenCancel.UseVisualStyleBackColor = true;
            this.btnHiddenCancel.Visible = false;
            this.btnHiddenCancel.Click += new System.EventHandler(this.btnHiddenCancel_Click);
            // 
            // btnHiddenAccept
            // 
            this.btnHiddenAccept.Location = new System.Drawing.Point(20, 77);
            this.btnHiddenAccept.Name = "btnHiddenAccept";
            this.btnHiddenAccept.Size = new System.Drawing.Size(10, 10);
            this.btnHiddenAccept.TabIndex = 10;
            this.btnHiddenAccept.Text = "Acc";
            this.btnHiddenAccept.UseVisualStyleBackColor = true;
            this.btnHiddenAccept.Visible = false;
            this.btnHiddenAccept.Click += new System.EventHandler(this.btnHiddenAccept_Click);
            // 
            // GoTo
            // 
            this.AcceptButton = this.btnHiddenAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHiddenCancel;
            this.ClientSize = new System.Drawing.Size(302, 113);
            this.Controls.Add(this.btnHiddenCancel);
            this.Controls.Add(this.btnHiddenAccept);
            this.Controls.Add(this.lblpnlName);
            this.Controls.Add(this.lblpnlAddress);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GoTo";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Go To";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GoTo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GoTo_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GoTo_KeyPress);
            this.lblpnlName.ResumeLayout(false);
            this.lblpnlName.PerformLayout();
            this.lblpnlAddress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ODModules.LabelPanel lblpnlName;
        private ODModules.LabelPanel lblpnlAddress;
        private ODModules.NumericTextbox numtxtAddress;
        private ODModules.Button btnAccept;
        private ODModules.Button btnCancel;
        private TextBox textBox2;
        private Button btnHiddenCancel;
        private Button btnHiddenAccept;
    }
}