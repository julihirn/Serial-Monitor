namespace Serial_Monitor {
    partial class ProgramProperties {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramProperties));
            labelPanel1 = new ODModules.LabelPanel();
            textBox1 = new TextBox();
            labelPanel2 = new ODModules.LabelPanel();
            textBox2 = new TextBox();
            labelPanel1.SuspendLayout();
            labelPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // labelPanel1
            // 
            labelPanel1.ArrowColor = Color.LightGray;
            labelPanel1.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel1.AutoSize = true;
            labelPanel1.CloseColor = Color.Black;
            labelPanel1.CloseMouseOverColor = Color.Red;
            labelPanel1.Collapsed = false;
            labelPanel1.Controls.Add(textBox1);
            labelPanel1.Dock = DockStyle.Top;
            labelPanel1.DropShadow = false;
            labelPanel1.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel1.FixedInlineWidth = false;
            labelPanel1.ForeColor = Color.White;
            labelPanel1.Inlinelabel = false;
            labelPanel1.InlineWidth = 100;
            labelPanel1.LabelBackColor = Color.FromArgb(16, 16, 16);
            labelPanel1.LabelFont = new Font("Segoe UI", 8F);
            labelPanel1.LabelForeColor = Color.WhiteSmoke;
            labelPanel1.Location = new Point(9, 11);
            labelPanel1.Margin = new Padding(6, 6, 6, 6);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = false;
            labelPanel1.Padding = new Padding(9, 41, 9, 11);
            labelPanel1.PanelCollapsible = false;
            labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel1.SeparatorColor = Color.Gray;
            labelPanel1.ShowCloseButton = false;
            labelPanel1.ShowSeparator = false;
            labelPanel1.Size = new Size(457, 81);
            labelPanel1.TabIndex = 0;
            labelPanel1.Text = "Program Name";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(50, 50, 50);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Dock = DockStyle.Top;
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(9, 41);
            textBox1.Margin = new Padding(6, 6, 6, 6);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(439, 32);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // labelPanel2
            // 
            labelPanel2.ArrowColor = Color.LightGray;
            labelPanel2.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel2.AutoSize = true;
            labelPanel2.CloseColor = Color.Black;
            labelPanel2.CloseMouseOverColor = Color.Red;
            labelPanel2.Collapsed = false;
            labelPanel2.Controls.Add(textBox2);
            labelPanel2.Dock = DockStyle.Top;
            labelPanel2.DropShadow = false;
            labelPanel2.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel2.FixedInlineWidth = false;
            labelPanel2.ForeColor = Color.White;
            labelPanel2.Inlinelabel = false;
            labelPanel2.InlineWidth = 100;
            labelPanel2.LabelBackColor = Color.FromArgb(16, 16, 16);
            labelPanel2.LabelFont = new Font("Segoe UI", 8F);
            labelPanel2.LabelForeColor = Color.WhiteSmoke;
            labelPanel2.Location = new Point(9, 92);
            labelPanel2.Margin = new Padding(6, 6, 6, 6);
            labelPanel2.Name = "labelPanel2";
            labelPanel2.OverrideCollapseControl = false;
            labelPanel2.Padding = new Padding(9, 41, 9, 11);
            labelPanel2.PanelCollapsible = false;
            labelPanel2.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel2.SeparatorColor = Color.Gray;
            labelPanel2.ShowCloseButton = false;
            labelPanel2.ShowSeparator = false;
            labelPanel2.Size = new Size(457, 84);
            labelPanel2.TabIndex = 1;
            labelPanel2.Text = "Program Command";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(50, 50, 50);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Dock = DockStyle.Top;
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(9, 41);
            textBox2.Margin = new Padding(6, 6, 6, 6);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(439, 32);
            textBox2.TabIndex = 1;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // ProgramProperties
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(475, 230);
            Controls.Add(labelPanel2);
            Controls.Add(labelPanel1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(6, 6, 6, 6);
            Name = "ProgramProperties";
            Padding = new Padding(9, 11, 9, 11);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Program Properties";
            FormClosing += ProgramProperties_FormClosing;
            Load += ProgramProperties_Load;
            SizeChanged += ProgramProperties_SizeChanged;
            VisibleChanged += ProgramProperties_VisibleChanged;
            KeyDown += ProgramProperties_KeyDown;
            KeyPress += ProgramProperties_KeyPress;
            labelPanel1.ResumeLayout(false);
            labelPanel1.PerformLayout();
            labelPanel2.ResumeLayout(false);
            labelPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.LabelPanel labelPanel1;
        private TextBox textBox1;
        private ODModules.LabelPanel labelPanel2;
        private TextBox textBox2;
    }
}