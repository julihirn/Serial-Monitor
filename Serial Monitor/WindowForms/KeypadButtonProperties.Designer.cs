namespace Serial_Monitor.WindowForms {
    partial class KeypadButtonProperties {
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
            ODModules.KeypadButton keypadButton1 = new ODModules.KeypadButton();
            ODModules.KeypadButton keypadButton2 = new ODModules.KeypadButton();
            ODModules.KeypadButton keypadButton3 = new ODModules.KeypadButton();
            ODModules.KeypadButton keypadButton4 = new ODModules.KeypadButton();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeypadButtonProperties));
            this.labelPanel1 = new ODModules.LabelPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelPanel2 = new ODModules.LabelPanel();
            this.keypad1 = new ODModules.Keypad();
            this.labelPanel3 = new ODModules.LabelPanel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelPanel1.SuspendLayout();
            this.labelPanel2.SuspendLayout();
            this.labelPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPanel1
            // 
            this.labelPanel1.ArrowColor = System.Drawing.Color.Black;
            this.labelPanel1.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel1.AutoSize = true;
            this.labelPanel1.CloseColor = System.Drawing.Color.Black;
            this.labelPanel1.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel1.Collapsed = false;
            this.labelPanel1.Controls.Add(this.textBox1);
            this.labelPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPanel1.DropShadow = false;
            this.labelPanel1.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel1.FixedInlineWidth = true;
            this.labelPanel1.Inlinelabel = true;
            this.labelPanel1.InlineWidth = 100;
            this.labelPanel1.LabelBackColor = System.Drawing.Color.White;
            this.labelPanel1.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel1.LabelForeColor = System.Drawing.Color.Black;
            this.labelPanel1.Location = new System.Drawing.Point(5, 10);
            this.labelPanel1.Name = "labelPanel1";
            this.labelPanel1.OverrideCollapseControl = false;
            this.labelPanel1.Padding = new System.Windows.Forms.Padding(113, 0, 0, 0);
            this.labelPanel1.PanelCollapsible = true;
            this.labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.labelPanel1.ShowCloseButton = false;
            this.labelPanel1.Size = new System.Drawing.Size(296, 16);
            this.labelPanel1.TabIndex = 0;
            this.labelPanel1.Text = "Button Text";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(113, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 16);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelPanel2
            // 
            this.labelPanel2.ArrowColor = System.Drawing.Color.Black;
            this.labelPanel2.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel2.CloseColor = System.Drawing.Color.Black;
            this.labelPanel2.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel2.Collapsed = false;
            this.labelPanel2.Controls.Add(this.keypad1);
            this.labelPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPanel2.DropShadow = false;
            this.labelPanel2.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel2.FixedInlineWidth = true;
            this.labelPanel2.Inlinelabel = false;
            this.labelPanel2.InlineWidth = 50;
            this.labelPanel2.LabelBackColor = System.Drawing.Color.White;
            this.labelPanel2.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel2.LabelForeColor = System.Drawing.Color.Black;
            this.labelPanel2.Location = new System.Drawing.Point(5, 26);
            this.labelPanel2.Name = "labelPanel2";
            this.labelPanel2.OverrideCollapseControl = false;
            this.labelPanel2.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.labelPanel2.PanelCollapsible = false;
            this.labelPanel2.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.labelPanel2.ShowCloseButton = false;
            this.labelPanel2.Size = new System.Drawing.Size(296, 65);
            this.labelPanel2.TabIndex = 1;
            this.labelPanel2.Text = "Command Type";
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
            this.keypad1.BackColorNorth = System.Drawing.Color.White;
            this.keypad1.BackColorSouth = System.Drawing.Color.White;
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
            this.keypad1.ButtonPadding = new System.Windows.Forms.Padding(3);
            keypadButton1.BackColorNorth = System.Drawing.Color.Gray;
            keypadButton1.BackColorSouth = System.Drawing.Color.Gray;
            keypadButton1.BorderColorNorth = System.Drawing.Color.Black;
            keypadButton1.BorderColorSouth = System.Drawing.Color.Black;
            keypadButton1.Checked = true;
            keypadButton1.Command = "0";
            keypadButton1.Enabled = true;
            keypadButton1.Icon = null;
            keypadButton1.IconInline = false;
            keypadButton1.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            keypadButton1.Position = new System.Drawing.Point(0, 0);
            keypadButton1.RadioButtonGroup = "setstate";
            keypadButton1.SecondaryShortCutKeys = System.Windows.Forms.Keys.None;
            keypadButton1.SecondaryText = "";
            keypadButton1.ShortCutKeys = System.Windows.Forms.Keys.None;
            keypadButton1.Tag = null;
            keypadButton1.Text = "None";
            keypadButton1.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            keypadButton1.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            keypadButton1.Type = ODModules.ButtonType.RadioButton;
            keypadButton1.UseButtonFormatting = false;
            keypadButton1.UseCustomColors = false;
            keypadButton1.UseKeyCode = false;
            keypadButton2.BackColorNorth = System.Drawing.Color.Gray;
            keypadButton2.BackColorSouth = System.Drawing.Color.Gray;
            keypadButton2.BorderColorNorth = System.Drawing.Color.Black;
            keypadButton2.BorderColorSouth = System.Drawing.Color.Black;
            keypadButton2.Checked = false;
            keypadButton2.Command = "1";
            keypadButton2.Enabled = true;
            keypadButton2.Icon = null;
            keypadButton2.IconInline = false;
            keypadButton2.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            keypadButton2.Position = new System.Drawing.Point(0, 0);
            keypadButton2.RadioButtonGroup = "setstate";
            keypadButton2.SecondaryShortCutKeys = System.Windows.Forms.Keys.None;
            keypadButton2.SecondaryText = "";
            keypadButton2.ShortCutKeys = System.Windows.Forms.Keys.None;
            keypadButton2.Tag = null;
            keypadButton2.Text = "Send String";
            keypadButton2.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            keypadButton2.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            keypadButton2.Type = ODModules.ButtonType.RadioButton;
            keypadButton2.UseButtonFormatting = false;
            keypadButton2.UseCustomColors = false;
            keypadButton2.UseKeyCode = false;
            keypadButton3.BackColorNorth = System.Drawing.Color.Gray;
            keypadButton3.BackColorSouth = System.Drawing.Color.Gray;
            keypadButton3.BorderColorNorth = System.Drawing.Color.Black;
            keypadButton3.BorderColorSouth = System.Drawing.Color.Black;
            keypadButton3.Checked = false;
            keypadButton3.Command = "2";
            keypadButton3.Enabled = true;
            keypadButton3.Icon = null;
            keypadButton3.IconInline = false;
            keypadButton3.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            keypadButton3.Position = new System.Drawing.Point(0, 0);
            keypadButton3.RadioButtonGroup = "setstate";
            keypadButton3.SecondaryShortCutKeys = System.Windows.Forms.Keys.None;
            keypadButton3.SecondaryText = "";
            keypadButton3.ShortCutKeys = System.Windows.Forms.Keys.None;
            keypadButton3.Tag = null;
            keypadButton3.Text = "Send Text";
            keypadButton3.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            keypadButton3.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            keypadButton3.Type = ODModules.ButtonType.RadioButton;
            keypadButton3.UseButtonFormatting = false;
            keypadButton3.UseCustomColors = false;
            keypadButton3.UseKeyCode = false;
            keypadButton4.BackColorNorth = System.Drawing.Color.Gray;
            keypadButton4.BackColorSouth = System.Drawing.Color.Gray;
            keypadButton4.BorderColorNorth = System.Drawing.Color.Black;
            keypadButton4.BorderColorSouth = System.Drawing.Color.Black;
            keypadButton4.Checked = false;
            keypadButton4.Command = "4";
            keypadButton4.Enabled = true;
            keypadButton4.Icon = null;
            keypadButton4.IconInline = false;
            keypadButton4.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            keypadButton4.Position = new System.Drawing.Point(0, 0);
            keypadButton4.RadioButtonGroup = "setstate";
            keypadButton4.SecondaryShortCutKeys = System.Windows.Forms.Keys.None;
            keypadButton4.SecondaryText = "";
            keypadButton4.ShortCutKeys = System.Windows.Forms.Keys.None;
            keypadButton4.Tag = null;
            keypadButton4.Text = "Run Program";
            keypadButton4.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            keypadButton4.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            keypadButton4.Type = ODModules.ButtonType.RadioButton;
            keypadButton4.UseButtonFormatting = false;
            keypadButton4.UseCustomColors = false;
            keypadButton4.UseKeyCode = false;
            this.keypad1.Buttons.Add(keypadButton1);
            this.keypad1.Buttons.Add(keypadButton2);
            this.keypad1.Buttons.Add(keypadButton3);
            this.keypad1.Buttons.Add(keypadButton4);
            this.keypad1.Columns = 4;
            this.keypad1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keypad1.ExternalItems = null;
            this.keypad1.IconInline = false;
            this.keypad1.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.keypad1.ImageSize = new System.Drawing.Size(32, 32);
            this.keypad1.Location = new System.Drawing.Point(0, 18);
            this.keypad1.Name = "keypad1";
            this.keypad1.Rows = 1;
            this.keypad1.SecondaryFont = null;
            this.keypad1.Size = new System.Drawing.Size(296, 47);
            this.keypad1.Style = ODModules.ButtonStyle.Square;
            this.keypad1.TabIndex = 0;
            this.keypad1.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.keypad1.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.keypad1.UseLocalList = true;
            this.keypad1.ButtonClicked += new ODModules.Keypad.ButtonClickedEventHandler(this.keypad1_ButtonClicked);
            // 
            // labelPanel3
            // 
            this.labelPanel3.ArrowColor = System.Drawing.Color.Black;
            this.labelPanel3.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel3.AutoSize = true;
            this.labelPanel3.CloseColor = System.Drawing.Color.Black;
            this.labelPanel3.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel3.Collapsed = false;
            this.labelPanel3.Controls.Add(this.textBox2);
            this.labelPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPanel3.DropShadow = false;
            this.labelPanel3.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel3.FixedInlineWidth = true;
            this.labelPanel3.Inlinelabel = true;
            this.labelPanel3.InlineWidth = 100;
            this.labelPanel3.LabelBackColor = System.Drawing.Color.White;
            this.labelPanel3.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel3.LabelForeColor = System.Drawing.Color.Black;
            this.labelPanel3.Location = new System.Drawing.Point(5, 91);
            this.labelPanel3.Name = "labelPanel3";
            this.labelPanel3.OverrideCollapseControl = false;
            this.labelPanel3.Padding = new System.Windows.Forms.Padding(113, 0, 0, 0);
            this.labelPanel3.PanelCollapsible = true;
            this.labelPanel3.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.labelPanel3.ShowCloseButton = false;
            this.labelPanel3.Size = new System.Drawing.Size(296, 16);
            this.labelPanel3.TabIndex = 2;
            this.labelPanel3.Text = "Command";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Location = new System.Drawing.Point(113, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(183, 16);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // KeypadButtonProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 263);
            this.Controls.Add(this.labelPanel3);
            this.Controls.Add(this.labelPanel2);
            this.Controls.Add(this.labelPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KeypadButtonProperties";
            this.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Button Properties";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeypadButtonProperties_FormClosing);
            this.Load += new System.EventHandler(this.KeypadButtonProperties_Load);
            this.labelPanel1.ResumeLayout(false);
            this.labelPanel1.PerformLayout();
            this.labelPanel2.ResumeLayout(false);
            this.labelPanel3.ResumeLayout(false);
            this.labelPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ODModules.LabelPanel labelPanel1;
        private TextBox textBox1;
        private ODModules.LabelPanel labelPanel2;
        private ODModules.Keypad keypad1;
        private ODModules.LabelPanel labelPanel3;
        private TextBox textBox2;
    }
}