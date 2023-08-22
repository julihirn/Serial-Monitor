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
            this.keypad1 = new ODModules.Keypad();
            this.SuspendLayout();
            // 
            // keypad1
            // 
            this.keypad1.AllowTextWrapping = true;
            this.keypad1.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.keypad1.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.keypad1.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.keypad1.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.keypad1.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.keypad1.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.keypad1.BackColorNorth = System.Drawing.Color.DimGray;
            this.keypad1.BackColorSouth = System.Drawing.Color.DimGray;
            this.keypad1.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.keypad1.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.keypad1.BorderColorDownNorth = System.Drawing.Color.Black;
            this.keypad1.BorderColorDownSouth = System.Drawing.Color.Black;
            this.keypad1.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.keypad1.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.keypad1.BorderColorNorth = System.Drawing.Color.Black;
            this.keypad1.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.keypad1.BorderColorSouth = System.Drawing.Color.Black;
            this.keypad1.BorderRadius = 5;
            this.keypad1.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.keypad1.Columns = 4;
            this.keypad1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad1.ExternalItems = null;
            this.keypad1.IconInline = false;
            this.keypad1.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.keypad1.ImageSize = new System.Drawing.Size(32, 32);
            this.keypad1.Location = new System.Drawing.Point(0, 0);
            this.keypad1.Name = "keypad1";
            this.keypad1.Padding = new System.Windows.Forms.Padding(10);
            this.keypad1.Rows = 5;
            this.keypad1.SecondaryFont = null;
            this.keypad1.Size = new System.Drawing.Size(302, 337);
            this.keypad1.Style = ODModules.ButtonStyle.Round;
            this.keypad1.TabIndex = 0;
            this.keypad1.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.keypad1.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.keypad1.UseLocalList = false;
            this.keypad1.ButtonClicked += new ODModules.Keypad.ButtonClickedEventHandler(this.keypad1_ButtonClicked);
            // 
            // Keypad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(302, 337);
            this.Controls.Add(this.keypad1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Keypad";
            this.Text = "Keypad";
            this.Load += new System.EventHandler(this.Keypad_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ODModules.Keypad keypad1;
    }
}