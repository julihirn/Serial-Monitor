namespace Serial_Monitor {
    partial class About {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            aboutBanner1 = new ODModules.AboutBanner();
            lblProductName = new Label();
            panel1 = new Panel();
            lblLoadedAssemblies = new Label();
            label1 = new Label();
            lblCopyright = new Label();
            lblVersion = new Label();
            lblBlank1 = new Label();
            lblCompany = new Label();
            pnlLoadedAssemblies = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // aboutBanner1
            // 
            aboutBanner1.BackColor = Color.FromArgb(16, 16, 16);
            aboutBanner1.BrandFont = new Font("Segoe UI Semilight", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            aboutBanner1.BrandSecondaryFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            aboutBanner1.BrandSecondaryText = "";
            aboutBanner1.BrandText = "Serial Monitor";
            aboutBanner1.Dock = DockStyle.Top;
            aboutBanner1.ForeColor = Color.White;
            aboutBanner1.Location = new Point(0, 0);
            aboutBanner1.Logo = Properties.Resources.SerialMonitor;
            aboutBanner1.Name = "aboutBanner1";
            aboutBanner1.RuleColorCenter = Color.SeaGreen;
            aboutBanner1.RuleColorEdge = Color.DarkSlateGray;
            aboutBanner1.Size = new Size(364, 83);
            aboutBanner1.TabIndex = 0;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Dock = DockStyle.Top;
            lblProductName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblProductName.Location = new Point(5, 5);
            lblProductName.Margin = new Padding(0);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(133, 25);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(lblLoadedAssemblies);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblCopyright);
            panel1.Controls.Add(lblVersion);
            panel1.Controls.Add(lblBlank1);
            panel1.Controls.Add(lblCompany);
            panel1.Controls.Add(lblProductName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 83);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(364, 135);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // lblLoadedAssemblies
            // 
            lblLoadedAssemblies.AutoSize = true;
            lblLoadedAssemblies.Dock = DockStyle.Top;
            lblLoadedAssemblies.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblLoadedAssemblies.Location = new Point(5, 105);
            lblLoadedAssemblies.Name = "lblLoadedAssemblies";
            lblLoadedAssemblies.Size = new Size(172, 25);
            lblLoadedAssemblies.TabIndex = 7;
            lblLoadedAssemblies.Text = "Loaded Assemblies";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(5, 90);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 6;
            // 
            // lblCopyright
            // 
            lblCopyright.AutoSize = true;
            lblCopyright.Dock = DockStyle.Top;
            lblCopyright.Location = new Point(5, 75);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(60, 15);
            lblCopyright.TabIndex = 5;
            lblCopyright.Text = "Copyright";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Dock = DockStyle.Top;
            lblVersion.Location = new Point(5, 60);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(45, 15);
            lblVersion.TabIndex = 4;
            lblVersion.Text = "Version";
            // 
            // lblBlank1
            // 
            lblBlank1.AutoSize = true;
            lblBlank1.Dock = DockStyle.Top;
            lblBlank1.Location = new Point(5, 45);
            lblBlank1.Name = "lblBlank1";
            lblBlank1.Size = new Size(0, 15);
            lblBlank1.TabIndex = 3;
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.Dock = DockStyle.Top;
            lblCompany.Location = new Point(5, 30);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new Size(59, 15);
            lblCompany.TabIndex = 2;
            lblCompany.Text = "Company";
            // 
            // pnlLoadedAssemblies
            // 
            pnlLoadedAssemblies.AutoScroll = true;
            pnlLoadedAssemblies.Dock = DockStyle.Fill;
            pnlLoadedAssemblies.Location = new Point(7, 0);
            pnlLoadedAssemblies.Name = "pnlLoadedAssemblies";
            pnlLoadedAssemblies.Size = new Size(357, 123);
            pnlLoadedAssemblies.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(pnlLoadedAssemblies);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 218);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(7, 0, 0, 0);
            panel2.Size = new Size(364, 123);
            panel2.TabIndex = 4;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(364, 341);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(aboutBanner1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "About";
            Text = "About";
            FormClosed += About_FormClosed;
            Load += About_Load;
            SizeChanged += About_SizeChanged;
            VisibleChanged += About_VisibleChanged;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ODModules.AboutBanner aboutBanner1;
        private Label lblProductName;
        private Panel panel1;
        private Label lblCopyright;
        private Label lblVersion;
        private Label lblBlank1;
        private Label lblCompany;
        private Label lblLoadedAssemblies;
        private Label label1;
        private Panel pnlLoadedAssemblies;
        private Panel panel2;
    }
}