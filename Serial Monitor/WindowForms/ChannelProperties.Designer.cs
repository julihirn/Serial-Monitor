namespace Serial_Monitor.WindowForms {
    partial class ChannelProperties {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChannelProperties));
            propertyGrid1 = new PropertyGrid();
            SuspendLayout();
            // 
            // propertyGrid1
            // 
            propertyGrid1.CanShowVisualStyleGlyphs = false;
            propertyGrid1.CategoryForeColor = Color.White;
            propertyGrid1.CategorySplitterColor = Color.Silver;
            propertyGrid1.CommandsForeColor = Color.White;
            propertyGrid1.CommandsVisibleIfAvailable = false;
            propertyGrid1.DisabledItemForeColor = Color.FromArgb(127, 255, 255, 255);
            propertyGrid1.Dock = DockStyle.Fill;
            propertyGrid1.HelpBackColor = Color.Gray;
            propertyGrid1.HelpBorderColor = Color.Gray;
            propertyGrid1.HelpForeColor = SystemColors.Window;
            propertyGrid1.HelpVisible = false;
            propertyGrid1.LineColor = Color.FromArgb(40, 40, 40);
            propertyGrid1.Location = new Point(0, 0);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(304, 363);
            propertyGrid1.TabIndex = 6;
            propertyGrid1.ToolbarVisible = false;
            propertyGrid1.ViewBackColor = Color.FromArgb(20, 20, 20);
            propertyGrid1.ViewBorderColor = Color.FromArgb(20, 20, 20);
            propertyGrid1.ViewForeColor = Color.White;
            // 
            // ChannelProperties
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 363);
            Controls.Add(propertyGrid1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChannelProperties";
            Text = "Channel Properties";
            FormClosing += ChannelProperties_FormClosing;
            FormClosed += ChannelProperties_FormClosed;
            Load += ChannelProperties_Load;
            SizeChanged += ChannelProperties_SizeChanged;
            VisibleChanged += ChannelProperties_VisibleChanged;
            ResumeLayout(false);
        }

        #endregion

        private PropertyGrid propertyGrid1;
    }
}