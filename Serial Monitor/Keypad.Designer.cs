namespace Serial_Monitor {
    partial class Keypad {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Keypad));
            this.buttonGrid1 = new ODModules.ButtonGrid();
            this.SuspendLayout();
            // 
            // buttonGrid1
            // 
            this.buttonGrid1.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.buttonGrid1.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.buttonGrid1.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.buttonGrid1.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.buttonGrid1.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.buttonGrid1.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.buttonGrid1.BackColorNorth = System.Drawing.Color.White;
            this.buttonGrid1.BackColorSouth = System.Drawing.Color.White;
            this.buttonGrid1.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorDownNorth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorDownSouth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorNorth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonGrid1.BorderColorSouth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderRadius = 5;
            this.buttonGrid1.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.buttonGrid1.ButtonSize = new System.Drawing.Size(120, 120);
            this.buttonGrid1.CenterButtons = true;
            this.buttonGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGrid1.Filter = null;
            this.buttonGrid1.ImageSize = new System.Drawing.Size(32, 32);
            this.buttonGrid1.Location = new System.Drawing.Point(0, 0);
            this.buttonGrid1.Name = "buttonGrid1";
            this.buttonGrid1.ScrollBarMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonGrid1.ScrollBarNorth = System.Drawing.Color.DarkTurquoise;
            this.buttonGrid1.ScrollBarSouth = System.Drawing.Color.DeepSkyBlue;
            this.buttonGrid1.SecondaryFont = null;
            this.buttonGrid1.Size = new System.Drawing.Size(302, 337);
            this.buttonGrid1.Style = ODModules.ButtonStyle.Square;
            this.buttonGrid1.TabIndex = 0;
            this.buttonGrid1.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.buttonGrid1.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.buttonGrid1.VerScroll = 0;
            // 
            // Keypad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(302, 337);
            this.Controls.Add(this.buttonGrid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Keypad";
            this.Text = "Keypad";
            this.ResumeLayout(false);

        }

        #endregion

        private ODModules.ButtonGrid buttonGrid1;
    }
}