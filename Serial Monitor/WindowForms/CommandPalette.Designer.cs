namespace Serial_Monitor {
    partial class CommandPalette {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandPalette));
            this.btngridCommands = new ODModules.ButtonGrid();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btngridCommands
            // 
            this.btngridCommands.AllowTextWrapping = true;
            this.btngridCommands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.btngridCommands.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.btngridCommands.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.btngridCommands.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.btngridCommands.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.btngridCommands.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.btngridCommands.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.btngridCommands.BackColorNorth = System.Drawing.Color.White;
            this.btngridCommands.BackColorSouth = System.Drawing.Color.White;
            this.btngridCommands.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.btngridCommands.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.btngridCommands.BorderColorDownNorth = System.Drawing.Color.Black;
            this.btngridCommands.BorderColorDownSouth = System.Drawing.Color.Black;
            this.btngridCommands.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.btngridCommands.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.btngridCommands.BorderColorNorth = System.Drawing.Color.Black;
            this.btngridCommands.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btngridCommands.BorderColorSouth = System.Drawing.Color.Black;
            this.btngridCommands.BorderRadius = 5;
            this.btngridCommands.ButtonPadding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.btngridCommands.ButtonSize = new System.Drawing.Size(85, 55);
            this.btngridCommands.CenterButtons = false;
            this.btngridCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btngridCommands.Filter = null;
            this.btngridCommands.IconInline = false;
            this.btngridCommands.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.btngridCommands.ImageSize = new System.Drawing.Size(32, 32);
            this.btngridCommands.Location = new System.Drawing.Point(0, 16);
            this.btngridCommands.Name = "btngridCommands";
            this.btngridCommands.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btngridCommands.ScrollBarMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btngridCommands.ScrollBarNorth = System.Drawing.Color.DarkTurquoise;
            this.btngridCommands.ScrollBarSouth = System.Drawing.Color.DeepSkyBlue;
            this.btngridCommands.SecondaryFont = null;
            this.btngridCommands.Size = new System.Drawing.Size(274, 157);
            this.btngridCommands.Style = ODModules.ButtonStyle.Round;
            this.btngridCommands.TabIndex = 0;
            this.btngridCommands.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Left;
            this.btngridCommands.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.btngridCommands.VerScroll = 0;
            this.btngridCommands.ButtonClicked += new ODModules.ButtonGrid.ButtonClickedEventHandler(this.buttonGrid1_ButtonClicked);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "Search";
            this.textBox1.Size = new System.Drawing.Size(274, 16);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // CommandPalette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 173);
            this.Controls.Add(this.btngridCommands);
            this.Controls.Add(this.textBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "CommandPalette";
            this.ShowInTaskbar = false;
            this.Text = "Command Palette";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CommandPalette_FormClosed);
            this.Load += new System.EventHandler(this.CommandPalette_Load);
            this.SizeChanged += new System.EventHandler(this.CommandPalette_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.CommandPalette_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandPalette_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CommandPalette_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ODModules.ButtonGrid btngridCommands;
        private TextBox textBox1;
    }
}