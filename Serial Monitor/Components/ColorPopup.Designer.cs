namespace Serial_Monitor.Components {
    partial class ColorPopup {
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
            btnColorGrid = new ODModules.ButtonGrid();
            SuspendLayout();
            // 
            // btnColorGrid
            // 
            btnColorGrid.AllowTextWrapping = true;
            btnColorGrid.BackColorCheckedNorth = Color.Orange;
            btnColorGrid.BackColorCheckedSouth = Color.Orange;
            btnColorGrid.BackColorDownNorth = Color.DimGray;
            btnColorGrid.BackColorDownSouth = Color.DimGray;
            btnColorGrid.BackColorHoverNorth = Color.SkyBlue;
            btnColorGrid.BackColorHoverSouth = Color.SkyBlue;
            btnColorGrid.BackColorNorth = Color.White;
            btnColorGrid.BackColorSouth = Color.White;
            btnColorGrid.BorderColorCheckedNorth = Color.Black;
            btnColorGrid.BorderColorCheckedSouth = Color.Black;
            btnColorGrid.BorderColorDownNorth = Color.Black;
            btnColorGrid.BorderColorDownSouth = Color.Black;
            btnColorGrid.BorderColorHoverNorth = Color.Black;
            btnColorGrid.BorderColorHoverSouth = Color.Black;
            btnColorGrid.BorderColorNorth = Color.Black;
            btnColorGrid.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            btnColorGrid.BorderColorSouth = Color.Black;
            btnColorGrid.BorderRadius = 5;
            btnColorGrid.ButtonPadding = new Padding(2);
            btnColorGrid.ButtonSize = new Size(21, 21);
            btnColorGrid.CenterButtons = true;
            btnColorGrid.Columns = 9;
            btnColorGrid.Dock = DockStyle.Fill;
            btnColorGrid.Filter = "";
            btnColorGrid.FixedColumns = true;
            btnColorGrid.IconInline = false;
            btnColorGrid.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnColorGrid.ImageSize = new Size(32, 32);
            btnColorGrid.Location = new Point(0, 0);
            btnColorGrid.Name = "btnColorGrid";
            btnColorGrid.Padding = new Padding(5);
            btnColorGrid.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            btnColorGrid.ScrollBarNorth = Color.DarkTurquoise;
            btnColorGrid.ScrollBarSouth = Color.DeepSkyBlue;
            btnColorGrid.SecondaryFont = null;
            btnColorGrid.Size = new Size(215, 215);
            btnColorGrid.Style = ODModules.ButtonStyle.Square;
            btnColorGrid.TabIndex = 0;
            btnColorGrid.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnColorGrid.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnColorGrid.VerScroll = 0;
            btnColorGrid.ButtonClicked += btnColorGrid_ButtonClicked;
            btnColorGrid.Load += buttonGrid1_Load;
            // 
            // ColorPopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnColorGrid);
            Margin = new Padding(2, 1, 2, 1);
            Name = "ColorPopup";
            Size = new Size(215, 215);
            ResumeLayout(false);
        }

        #endregion

        private ODModules.ButtonGrid btnColorGrid;
    }
}
