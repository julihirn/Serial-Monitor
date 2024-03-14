namespace Serial_Monitor.Docks {
    partial class ModbusPollers {
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
            SuspendLayout();
            // 
            // ModbusPollers
            // 
            ActiveTitleBackColor = Color.White;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            DefaultDockArea = ODModules.Docking.DockArea.Right;
            DockText = "Modbus Pollers";
            ForeColor = Color.White;
            InactiveTitleBackColor = Color.FromArgb(16, 16, 16);
            InactiveTitleForeColor = Color.Gainsboro;
            Name = "ModbusPollers";
            SerializationKey = "ModbusPollers";
            Size = new Size(244, 303);
            Load += ModbusPollers_Load;
            ResumeLayout(false);
        }

        #endregion
    }
}
