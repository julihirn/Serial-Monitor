namespace Serial_Monitor.Components {
    partial class SnapshotClient {
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
            pnlClient = new Panel();
            SuspendLayout();
            // 
            // pnlClient
            // 
            pnlClient.Dock = DockStyle.Fill;
            pnlClient.Location = new Point(3, 3);
            pnlClient.Name = "pnlClient";
            pnlClient.Size = new Size(552, 446);
            pnlClient.TabIndex = 0;
            pnlClient.SizeChanged += pnlClient_SizeChanged;
            pnlClient.Paint += pnlClient_Paint;
            // 
            // SnapshotClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlClient);
            DoubleBuffered = true;
            Name = "SnapshotClient";
            Padding = new Padding(3);
            Size = new Size(558, 452);
            Load += SnapshotClient_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlClient;
    }
}
