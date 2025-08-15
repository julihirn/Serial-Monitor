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
            lblpnlName = new ODModules.LabelPanel();
            textBox1 = new ODModules.TextBox();
            lblpnlAddress = new ODModules.LabelPanel();
            numtxtAddress = new ODModules.NumericTextbox();
            btnAccept = new ODModules.Button();
            btnCancel = new ODModules.Button();
            btnHiddenCancel = new Button();
            btnHiddenAccept = new Button();
            lblpnlName.SuspendLayout();
            lblpnlAddress.SuspendLayout();
            SuspendLayout();
            // 
            // lblpnlName
            // 
            lblpnlName.ArrowColor = Color.LightGray;
            lblpnlName.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlName.AutoSize = true;
            lblpnlName.CloseColor = Color.Black;
            lblpnlName.CloseMouseOverColor = Color.Red;
            lblpnlName.Collapsed = false;
            lblpnlName.Controls.Add(textBox1);
            lblpnlName.Dock = DockStyle.Top;
            lblpnlName.DropShadow = false;
            lblpnlName.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlName.FixedInlineWidth = true;
            lblpnlName.ForeColor = Color.White;
            lblpnlName.Inlinelabel = true;
            lblpnlName.InlineWidth = 100;
            lblpnlName.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlName.LabelFont = new Font("Segoe UI", 8F);
            lblpnlName.LabelForeColor = Color.Black;
            lblpnlName.Location = new Point(5, 38);
            lblpnlName.Name = "lblpnlName";
            lblpnlName.OverrideCollapseControl = false;
            lblpnlName.Padding = new Padding(113, 5, 5, 5);
            lblpnlName.PanelCollapsible = false;
            lblpnlName.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlName.ShowCloseButton = false;
            lblpnlName.Size = new Size(292, 33);
            lblpnlName.TabIndex = 7;
            lblpnlName.Text = "Go To Name";
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
            textBox1.Location = new Point(113, 5);
            textBox1.Margin = new Padding(2, 2, 2, 2);
            textBox1.MaxLength = 32767;
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.Padding = new Padding(4, 3, 4, 3);
            textBox1.PasswordChar = '\0';
            textBox1.PlaceholderText = "";
            textBox1.ReadOnly = false;
            textBox1.SelectedBackColor = Color.LightGray;
            textBox1.SelectedBorderColor = Color.HotPink;
            textBox1.ShortcutsEnabled = true;
            textBox1.Size = new Size(174, 23);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Left;
            textBox1.UnderlinedStyle = false;
            textBox1.UseSystemPasswordChar = false;
            textBox1.WordWrap = true;
            textBox1.TextChanged += textBox2_TextChanged;
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
            lblpnlAddress.Location = new Point(5, 5);
            lblpnlAddress.Name = "lblpnlAddress";
            lblpnlAddress.OverrideCollapseControl = false;
            lblpnlAddress.Padding = new Padding(113, 5, 5, 5);
            lblpnlAddress.PanelCollapsible = false;
            lblpnlAddress.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlAddress.ShowCloseButton = false;
            lblpnlAddress.Size = new Size(292, 33);
            lblpnlAddress.TabIndex = 6;
            lblpnlAddress.Text = "Go To Address";
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
            numtxtAddress.Size = new Size(174, 23);
            numtxtAddress.TabIndex = 0;
            numtxtAddress.Unit = "";
            numtxtAddress.UseFixedNumericPadding = true;
            numtxtAddress.Value = "0";
            numtxtAddress.EnterPressed += numtxtAddress_EnterPressed;
            numtxtAddress.EscapePressed += numtxtAddress_EscapePressed;
            numtxtAddress.KeyDown += numtxtAddress_KeyDown;
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
            btnAccept.Location = new Point(100, 77);
            btnAccept.Name = "btnAccept";
            btnAccept.RadioButtonGroup = "";
            btnAccept.SecondaryFont = new Font("Segoe UI", 9F);
            btnAccept.SecondaryText = "";
            btnAccept.Size = new Size(93, 28);
            btnAccept.Style = ODModules.ButtonStyle.Square;
            btnAccept.TabIndex = 8;
            btnAccept.Text = "Ok";
            btnAccept.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnAccept.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnAccept.Type = ODModules.ButtonType.Button;
            btnAccept.ButtonClicked += btnAccept_ButtonClicked;
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
            btnCancel.Location = new Point(199, 77);
            btnCancel.Name = "btnCancel";
            btnCancel.RadioButtonGroup = "";
            btnCancel.SecondaryFont = new Font("Segoe UI", 9F);
            btnCancel.SecondaryText = "";
            btnCancel.Size = new Size(93, 28);
            btnCancel.Style = ODModules.ButtonStyle.Square;
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnCancel.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnCancel.Type = ODModules.ButtonType.Button;
            btnCancel.ButtonClicked += btnCancel_ButtonClicked;
            // 
            // btnHiddenCancel
            // 
            btnHiddenCancel.Location = new Point(8, 77);
            btnHiddenCancel.Name = "btnHiddenCancel";
            btnHiddenCancel.Size = new Size(11, 10);
            btnHiddenCancel.TabIndex = 11;
            btnHiddenCancel.Text = "Can";
            btnHiddenCancel.UseVisualStyleBackColor = true;
            btnHiddenCancel.Visible = false;
            btnHiddenCancel.Click += btnHiddenCancel_Click;
            // 
            // btnHiddenAccept
            // 
            btnHiddenAccept.Location = new Point(20, 77);
            btnHiddenAccept.Name = "btnHiddenAccept";
            btnHiddenAccept.Size = new Size(10, 10);
            btnHiddenAccept.TabIndex = 10;
            btnHiddenAccept.Text = "Acc";
            btnHiddenAccept.UseVisualStyleBackColor = true;
            btnHiddenAccept.Visible = false;
            btnHiddenAccept.Click += btnHiddenAccept_Click;
            // 
            // GoTo
            // 
            AcceptButton = btnHiddenAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHiddenCancel;
            ClientSize = new Size(302, 113);
            Controls.Add(btnHiddenCancel);
            Controls.Add(btnHiddenAccept);
            Controls.Add(lblpnlName);
            Controls.Add(lblpnlAddress);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GoTo";
            Padding = new Padding(5, 5, 5, 5);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Go To";
            TopMost = true;
            Load += GoTo_Load;
            KeyDown += GoTo_KeyDown;
            KeyPress += GoTo_KeyPress;
            lblpnlName.ResumeLayout(false);
            lblpnlAddress.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.LabelPanel lblpnlName;
        private ODModules.LabelPanel lblpnlAddress;
        private ODModules.NumericTextbox numtxtAddress;
        private ODModules.Button btnAccept;
        private ODModules.Button btnCancel;
        private Button btnHiddenCancel;
        private Button btnHiddenAccept;
        private ODModules.TextBox textBox1;
    }
}