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
            this.kpCommands = new ODModules.Keypad();
            this.SuspendLayout();
            // 
            // kpCommands
            // 
            this.kpCommands.AllowTextWrapping = true;
            this.kpCommands.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.kpCommands.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.kpCommands.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.kpCommands.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.kpCommands.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.kpCommands.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.kpCommands.BackColorNorth = System.Drawing.Color.DimGray;
            this.kpCommands.BackColorSouth = System.Drawing.Color.DimGray;
            this.kpCommands.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorDownNorth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorDownSouth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorNorth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kpCommands.BorderColorSouth = System.Drawing.Color.Black;
            this.kpCommands.BorderRadius = 5;
            this.kpCommands.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.kpCommands.Columns = 4;
            this.kpCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpCommands.ExternalItems = null;
            this.kpCommands.IconInline = false;
            this.kpCommands.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.kpCommands.ImageSize = new System.Drawing.Size(32, 32);
            this.kpCommands.Location = new System.Drawing.Point(0, 0);
            this.kpCommands.Name = "kpCommands";
            this.kpCommands.Padding = new System.Windows.Forms.Padding(10);
            this.kpCommands.Rows = 5;
            this.kpCommands.SecondaryFont = null;
            this.kpCommands.Size = new System.Drawing.Size(302, 337);
            this.kpCommands.Style = ODModules.ButtonStyle.Round;
            this.kpCommands.TabIndex = 0;
            this.kpCommands.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.kpCommands.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.kpCommands.UseLocalList = false;
            this.kpCommands.ButtonClicked += new ODModules.Keypad.ButtonClickedEventHandler(this.keypad1_ButtonClicked);
            // 
            // Keypad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(302, 337);
            this.Controls.Add(this.kpCommands);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Keypad";
            this.Text = "Keypad";
            this.Load += new System.EventHandler(this.Keypad_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ODModules.Keypad keypad1;
        private ODModules.Keypad kpCommands;
    }
}