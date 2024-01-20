namespace Serial_Monitor.Components {
    partial class BitTogglerPopup {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btToggler = new ODModules.BitToggle();
            SuspendLayout();
            // 
            // btToggler
            // 
            btToggler.ActiveToggleForeColor = Color.Black;
            btToggler.Bits = 32;
            btToggler.Dock = DockStyle.Fill;
            btToggler.InactiveToggleForeColor = Color.Gray;
            btToggler.Location = new Point(0, 0);
            btToggler.MouseDownForeColor = Color.WhiteSmoke;
            btToggler.MouseOverForeColor = Color.Blue;
            btToggler.Name = "btToggler";
            btToggler.Size = new Size(300, 300);
            btToggler.TabIndex = 0;
            btToggler.TogglerSize = ODModules.BitToggle.WordSize.QWord;
            btToggler.Value = "0";
            btToggler.BitToggled += btToggler_BitToggled;
            // 
            // BitTogglerPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btToggler);
            Margin = new Padding(2, 1, 2, 1);
            Name = "BitTogglerPopup";
            Size = new Size(300, 300);
            ResumeLayout(false);
        }

        #endregion

        private ODModules.BitToggle btToggler;
    }
}
