namespace Serial_Monitor.Dialogs {
    partial class NewUnit {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewUnit));
            lblpnlDisplayName = new ODModules.LabelPanel();
            textBox1 = new ODModules.TextBox();
            btnHiddenCancel = new Button();
            btnHiddenAccept = new Button();
            btnAccept = new ODModules.Button();
            btnCancel = new ODModules.Button();
            lblpnlUnitAddress = new ODModules.LabelPanel();
            cmbxUnitAddress = new ODModules.FlatComboBox();
            lblpnlDisplayName.SuspendLayout();
            lblpnlUnitAddress.SuspendLayout();
            SuspendLayout();
            // 
            // lblpnlDisplayName
            // 
            lblpnlDisplayName.ArrowColor = Color.LightGray;
            lblpnlDisplayName.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlDisplayName.AutoSize = true;
            lblpnlDisplayName.CloseColor = Color.Black;
            lblpnlDisplayName.CloseMouseOverColor = Color.Red;
            lblpnlDisplayName.Collapsed = false;
            lblpnlDisplayName.Controls.Add(textBox1);
            lblpnlDisplayName.Dock = DockStyle.Top;
            lblpnlDisplayName.DropShadow = false;
            lblpnlDisplayName.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlDisplayName.FixedInlineWidth = false;
            lblpnlDisplayName.ForeColor = Color.White;
            lblpnlDisplayName.Inlinelabel = false;
            lblpnlDisplayName.InlineWidth = 100;
            lblpnlDisplayName.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlDisplayName.LabelFont = new Font("Segoe UI", 8F);
            lblpnlDisplayName.LabelForeColor = Color.WhiteSmoke;
            lblpnlDisplayName.Location = new Point(19, 21);
            lblpnlDisplayName.Margin = new Padding(6, 6, 6, 6);
            lblpnlDisplayName.Name = "lblpnlDisplayName";
            lblpnlDisplayName.OverrideCollapseControl = false;
            lblpnlDisplayName.Padding = new Padding(9, 41, 9, 11);
            lblpnlDisplayName.PanelCollapsible = false;
            lblpnlDisplayName.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlDisplayName.SeparatorColor = Color.Gray;
            lblpnlDisplayName.ShowCloseButton = false;
            lblpnlDisplayName.ShowSeparator = false;
            lblpnlDisplayName.Size = new Size(493, 92);
            lblpnlDisplayName.TabIndex = 2;
            lblpnlDisplayName.Text = "Display Name";
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
            textBox1.Location = new Point(9, 41);
            textBox1.Margin = new Padding(4, 4, 4, 4);
            textBox1.MaxLength = 32767;
            textBox1.Multiline = false;
            textBox1.Name = "textBox1";
            textBox1.Padding = new Padding(7, 6, 7, 6);
            textBox1.PasswordChar = '\0';
            textBox1.PlaceholderText = "";
            textBox1.ReadOnly = false;
            textBox1.SelectedBackColor = Color.LightGray;
            textBox1.SelectedBorderColor = Color.HotPink;
            textBox1.ShortcutsEnabled = true;
            textBox1.Size = new Size(475, 43);
            textBox1.TabIndex = 1;
            textBox1.TextAlign = HorizontalAlignment.Left;
            textBox1.UnderlinedStyle = false;
            textBox1.UseSystemPasswordChar = false;
            textBox1.WordWrap = true;
            // 
            // btnHiddenCancel
            // 
            btnHiddenCancel.Location = new Point(87, 491);
            btnHiddenCancel.Margin = new Padding(6, 6, 6, 6);
            btnHiddenCancel.Name = "btnHiddenCancel";
            btnHiddenCancel.Size = new Size(20, 21);
            btnHiddenCancel.TabIndex = 10;
            btnHiddenCancel.Text = "Can";
            btnHiddenCancel.UseVisualStyleBackColor = true;
            btnHiddenCancel.Visible = false;
            btnHiddenCancel.Click += btnHiddenCancel_Click;
            // 
            // btnHiddenAccept
            // 
            btnHiddenAccept.Location = new Point(110, 491);
            btnHiddenAccept.Margin = new Padding(6, 6, 6, 6);
            btnHiddenAccept.Name = "btnHiddenAccept";
            btnHiddenAccept.Size = new Size(19, 21);
            btnHiddenAccept.TabIndex = 8;
            btnHiddenAccept.Text = "Acc";
            btnHiddenAccept.UseVisualStyleBackColor = true;
            btnHiddenAccept.Visible = false;
            btnHiddenAccept.Click += btnHiddenAccept_Click;
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
            btnAccept.Location = new Point(149, 247);
            btnAccept.Margin = new Padding(6, 6, 6, 6);
            btnAccept.Name = "btnAccept";
            btnAccept.RadioButtonGroup = "";
            btnAccept.SecondaryFont = new Font("Segoe UI", 9F);
            btnAccept.SecondaryText = "";
            btnAccept.Size = new Size(173, 60);
            btnAccept.Style = ODModules.ButtonStyle.Square;
            btnAccept.TabIndex = 7;
            btnAccept.Text = "Accept";
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
            btnCancel.Location = new Point(331, 247);
            btnCancel.Margin = new Padding(6, 6, 6, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.RadioButtonGroup = "";
            btnCancel.SecondaryFont = new Font("Segoe UI", 9F);
            btnCancel.SecondaryText = "";
            btnCancel.Size = new Size(173, 60);
            btnCancel.Style = ODModules.ButtonStyle.Square;
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnCancel.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnCancel.Type = ODModules.ButtonType.Button;
            btnCancel.ButtonClicked += btnCancel_ButtonClicked;
            // 
            // lblpnlUnitAddress
            // 
            lblpnlUnitAddress.ArrowColor = Color.LightGray;
            lblpnlUnitAddress.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlUnitAddress.AutoSize = true;
            lblpnlUnitAddress.CloseColor = Color.Black;
            lblpnlUnitAddress.CloseMouseOverColor = Color.Red;
            lblpnlUnitAddress.Collapsed = false;
            lblpnlUnitAddress.Controls.Add(cmbxUnitAddress);
            lblpnlUnitAddress.Dock = DockStyle.Top;
            lblpnlUnitAddress.DropShadow = false;
            lblpnlUnitAddress.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlUnitAddress.FixedInlineWidth = false;
            lblpnlUnitAddress.ForeColor = Color.White;
            lblpnlUnitAddress.Inlinelabel = false;
            lblpnlUnitAddress.InlineWidth = 100;
            lblpnlUnitAddress.LabelBackColor = Color.FromArgb(16, 16, 16);
            lblpnlUnitAddress.LabelFont = new Font("Segoe UI", 8F);
            lblpnlUnitAddress.LabelForeColor = Color.WhiteSmoke;
            lblpnlUnitAddress.Location = new Point(19, 113);
            lblpnlUnitAddress.Margin = new Padding(6, 6, 6, 6);
            lblpnlUnitAddress.Name = "lblpnlUnitAddress";
            lblpnlUnitAddress.OverrideCollapseControl = false;
            lblpnlUnitAddress.Padding = new Padding(9, 41, 9, 11);
            lblpnlUnitAddress.PanelCollapsible = false;
            lblpnlUnitAddress.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlUnitAddress.SeparatorColor = Color.Gray;
            lblpnlUnitAddress.ShowCloseButton = false;
            lblpnlUnitAddress.ShowSeparator = false;
            lblpnlUnitAddress.Size = new Size(493, 92);
            lblpnlUnitAddress.TabIndex = 11;
            lblpnlUnitAddress.Text = "Unit Address";
            // 
            // cmbxUnitAddress
            // 
            cmbxUnitAddress.DisplayMember = "DisplayText";
            cmbxUnitAddress.Dock = DockStyle.Top;
            cmbxUnitAddress.FormattingEnabled = true;
            cmbxUnitAddress.Location = new Point(9, 41);
            cmbxUnitAddress.Margin = new Padding(6, 6, 6, 6);
            cmbxUnitAddress.Name = "cmbxUnitAddress";
            cmbxUnitAddress.Size = new Size(475, 40);
            cmbxUnitAddress.TabIndex = 2;
            // 
            // NewUnit
            // 
            AcceptButton = btnHiddenAccept;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHiddenCancel;
            ClientSize = new Size(531, 335);
            Controls.Add(lblpnlUnitAddress);
            Controls.Add(btnHiddenCancel);
            Controls.Add(btnHiddenAccept);
            Controls.Add(btnAccept);
            Controls.Add(btnCancel);
            Controls.Add(lblpnlDisplayName);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4, 2, 4, 2);
            Name = "NewUnit";
            Padding = new Padding(19, 21, 19, 21);
            RightToLeft = RightToLeft.No;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Unit";
            FormClosing += NewUnit_FormClosing;
            FormClosed += NewUnit_FormClosed;
            Load += NewUnit_Load;
            lblpnlDisplayName.ResumeLayout(false);
            lblpnlUnitAddress.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.LabelPanel lblpnlDisplayName;
        private ODModules.TextBox textBox1;
        private Button btnHiddenCancel;
        private Button btnHiddenAccept;
        private ODModules.Button btnAccept;
        private ODModules.Button btnCancel;
        private ODModules.LabelPanel lblpnlUnitAddress;
        private ODModules.FlatComboBox cmbxUnitAddress;
    }
}