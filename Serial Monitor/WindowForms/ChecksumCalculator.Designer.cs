namespace Serial_Monitor.WindowForms {
    partial class ChecksumCalculator {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChecksumCalculator));
            lblpnlDisplayName = new ODModules.LabelPanel();
            textBox1 = new ODModules.TextBox();
            labelPanel1 = new ODModules.LabelPanel();
            lblpnlDisplayName.SuspendLayout();
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
            lblpnlDisplayName.LabelFont = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblpnlDisplayName.LabelForeColor = Color.WhiteSmoke;
            lblpnlDisplayName.Location = new Point(10, 77);
            lblpnlDisplayName.Name = "lblpnlDisplayName";
            lblpnlDisplayName.OverrideCollapseControl = false;
            lblpnlDisplayName.Padding = new Padding(5, 18, 5, 5);
            lblpnlDisplayName.PanelCollapsible = false;
            lblpnlDisplayName.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlDisplayName.ShowCloseButton = false;
            lblpnlDisplayName.Size = new Size(297, 46);
            lblpnlDisplayName.TabIndex = 3;
            lblpnlDisplayName.Text = "Hexadecimal Input";
            // 
            // textBox1
            // 
            textBox1.AutoCompleteMode = AutoCompleteMode.None;
            textBox1.AutoCompleteSource = AutoCompleteSource.None;
            textBox1.BackColor = SystemColors.Window;
            textBox1.BorderColor = Color.MediumSlateBlue;
            textBox1.BorderSize = 1;
            textBox1.Dock = DockStyle.Top;
            textBox1.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.DimGray;
            textBox1.Location = new Point(5, 18);
            textBox1.Margin = new Padding(2);
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
            textBox1.Size = new Size(287, 23);
            textBox1.TabIndex = 1;
            textBox1.TextAlign = HorizontalAlignment.Left;
            textBox1.UnderlinedStyle = false;
            textBox1.UseSystemPasswordChar = false;
            textBox1.WordWrap = true;
            // 
            // labelPanel1
            // 
            labelPanel1.ArrowColor = Color.LightGray;
            labelPanel1.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel1.CloseColor = Color.Black;
            labelPanel1.CloseMouseOverColor = Color.Red;
            labelPanel1.Collapsed = false;
            labelPanel1.Dock = DockStyle.Top;
            labelPanel1.DropShadow = false;
            labelPanel1.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel1.FixedInlineWidth = false;
            labelPanel1.ForeColor = Color.White;
            labelPanel1.Inlinelabel = false;
            labelPanel1.InlineWidth = 100;
            labelPanel1.LabelBackColor = Color.FromArgb(16, 16, 16);
            labelPanel1.LabelFont = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            labelPanel1.LabelForeColor = Color.WhiteSmoke;
            labelPanel1.Location = new Point(10, 10);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = false;
            labelPanel1.Padding = new Padding(5, 18, 5, 5);
            labelPanel1.PanelCollapsible = false;
            labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel1.ShowCloseButton = false;
            labelPanel1.Size = new Size(297, 67);
            labelPanel1.TabIndex = 4;
            labelPanel1.Text = "Type";
            // 
            // ChecksumCalculator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 184);
            Controls.Add(lblpnlDisplayName);
            Controls.Add(labelPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChecksumCalculator";
            Padding = new Padding(10);
            Text = "Checksum Calculator";
            Load += ChecksumCalculator_Load;
            lblpnlDisplayName.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.LabelPanel lblpnlDisplayName;
        private ODModules.TextBox textBox1;
        private ODModules.LabelPanel labelPanel1;
    }
}