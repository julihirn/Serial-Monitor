namespace Serial_Monitor {
    partial class Settings {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.tabctrlSettings = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblPnlTheme = new ODModules.LabelPanel();
            this.flowPnlTheme = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabctrlSettings.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.lblPnlTheme.SuspendLayout();
            this.flowPnlTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabctrlSettings
            // 
            this.tabctrlSettings.Controls.Add(this.tabPage1);
            this.tabctrlSettings.Controls.Add(this.tabPage2);
            this.tabctrlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabctrlSettings.Location = new System.Drawing.Point(5, 5);
            this.tabctrlSettings.Name = "tabctrlSettings";
            this.tabctrlSettings.SelectedIndex = 0;
            this.tabctrlSettings.Size = new System.Drawing.Size(340, 365);
            this.tabctrlSettings.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage1.Size = new System.Drawing.Size(332, 337);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tabPage2.Controls.Add(this.lblPnlTheme);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage2.Size = new System.Drawing.Size(332, 337);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Display";
            // 
            // lblPnlTheme
            // 
            this.lblPnlTheme.ArrowColor = System.Drawing.Color.Black;
            this.lblPnlTheme.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.lblPnlTheme.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPnlTheme.CloseColor = System.Drawing.Color.Black;
            this.lblPnlTheme.CloseMouseOverColor = System.Drawing.Color.Red;
            this.lblPnlTheme.Collapsed = false;
            this.lblPnlTheme.Controls.Add(this.flowPnlTheme);
            this.lblPnlTheme.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPnlTheme.DropShadow = false;
            this.lblPnlTheme.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPnlTheme.LabelBackColor = System.Drawing.Color.White;
            this.lblPnlTheme.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPnlTheme.LabelForeColor = System.Drawing.Color.Black;
            this.lblPnlTheme.Location = new System.Drawing.Point(5, 5);
            this.lblPnlTheme.Name = "lblPnlTheme";
            this.lblPnlTheme.OverrideCollapseControl = false;
            this.lblPnlTheme.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.lblPnlTheme.PanelCollapsible = true;
            this.lblPnlTheme.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblPnlTheme.ShowCloseButton = true;
            this.lblPnlTheme.Size = new System.Drawing.Size(322, 110);
            this.lblPnlTheme.TabIndex = 0;
            this.lblPnlTheme.Text = "Theme";
            // 
            // flowPnlTheme
            // 
            this.flowPnlTheme.Controls.Add(this.button1);
            this.flowPnlTheme.Controls.Add(this.button2);
            this.flowPnlTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPnlTheme.Location = new System.Drawing.Point(0, 18);
            this.flowPnlTheme.Name = "flowPnlTheme";
            this.flowPnlTheme.Size = new System.Drawing.Size(322, 92);
            this.flowPnlTheme.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatAppearance.BorderSize = 4;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button2.FlatAppearance.BorderSize = 4;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(59, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 2;
            this.button2.Text = "Aa";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(350, 375);
            this.Controls.Add(this.tabctrlSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabctrlSettings.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.lblPnlTheme.ResumeLayout(false);
            this.flowPnlTheme.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabctrlSettings;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ODModules.LabelPanel lblPnlTheme;
        private FlowLayoutPanel flowPnlTheme;
        private Button button1;
        private Button button2;
    }
}