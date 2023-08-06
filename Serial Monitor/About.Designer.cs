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
            this.aboutBanner1 = new ODModules.AboutBanner();
            this.lblProductName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLoadedAssemblies = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblBlank1 = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.pnlLoadedAssemblies = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutBanner1
            // 
            this.aboutBanner1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.aboutBanner1.BrandFont = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.aboutBanner1.BrandSecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.aboutBanner1.BrandSecondaryText = "";
            this.aboutBanner1.BrandText = "Serial Monitor";
            this.aboutBanner1.Dock = System.Windows.Forms.DockStyle.Top;
            this.aboutBanner1.ForeColor = System.Drawing.Color.White;
            this.aboutBanner1.Location = new System.Drawing.Point(0, 0);
            this.aboutBanner1.Logo = global::Serial_Monitor.Properties.Resources.SerialMonitor;
            this.aboutBanner1.Margin = new System.Windows.Forms.Padding(6);
            this.aboutBanner1.Name = "aboutBanner1";
            this.aboutBanner1.RuleColorCenter = System.Drawing.Color.Cyan;
            this.aboutBanner1.RuleColorEdge = System.Drawing.Color.DarkSlateGray;
            this.aboutBanner1.Size = new System.Drawing.Size(676, 177);
            this.aboutBanner1.TabIndex = 0;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblProductName.Location = new System.Drawing.Point(9, 11);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(0);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(263, 51);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "Product Name";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.lblLoadedAssemblies);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblCopyright);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.lblBlank1);
            this.panel1.Controls.Add(this.lblCompany);
            this.panel1.Controls.Add(this.lblProductName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 177);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.panel1.Size = new System.Drawing.Size(676, 284);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblLoadedAssemblies
            // 
            this.lblLoadedAssemblies.AutoSize = true;
            this.lblLoadedAssemblies.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLoadedAssemblies.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLoadedAssemblies.Location = new System.Drawing.Point(9, 222);
            this.lblLoadedAssemblies.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLoadedAssemblies.Name = "lblLoadedAssemblies";
            this.lblLoadedAssemblies.Size = new System.Drawing.Size(341, 51);
            this.lblLoadedAssemblies.TabIndex = 7;
            this.lblLoadedAssemblies.Text = "Loaded Assemblies";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(9, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 32);
            this.label1.TabIndex = 6;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCopyright.Location = new System.Drawing.Point(9, 158);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(119, 32);
            this.lblCopyright.TabIndex = 5;
            this.lblCopyright.Text = "Copyright";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVersion.Location = new System.Drawing.Point(9, 126);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(92, 32);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Version";
            // 
            // lblBlank1
            // 
            this.lblBlank1.AutoSize = true;
            this.lblBlank1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBlank1.Location = new System.Drawing.Point(9, 94);
            this.lblBlank1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBlank1.Name = "lblBlank1";
            this.lblBlank1.Size = new System.Drawing.Size(0, 32);
            this.lblBlank1.TabIndex = 3;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCompany.Location = new System.Drawing.Point(9, 62);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(116, 32);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.Text = "Company";
            // 
            // pnlLoadedAssemblies
            // 
            this.pnlLoadedAssemblies.AutoScroll = true;
            this.pnlLoadedAssemblies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoadedAssemblies.Location = new System.Drawing.Point(13, 0);
            this.pnlLoadedAssemblies.Margin = new System.Windows.Forms.Padding(6);
            this.pnlLoadedAssemblies.Name = "pnlLoadedAssemblies";
            this.pnlLoadedAssemblies.Size = new System.Drawing.Size(663, 266);
            this.pnlLoadedAssemblies.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlLoadedAssemblies);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 461);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.panel2.Size = new System.Drawing.Size(676, 266);
            this.panel2.TabIndex = 4;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(676, 727);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.aboutBanner1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "About";
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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