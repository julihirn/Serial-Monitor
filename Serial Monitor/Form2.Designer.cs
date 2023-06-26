namespace Serial_Monitor {
    partial class Form2 {
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
            this.navigator1 = new ODModules.Navigator();
            this.labelPanel1 = new ODModules.LabelPanel();
            this.valuePainter1 = new ODModules.ValuePainter();
            this.labelPanel2 = new ODModules.LabelPanel();
            this.labelPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigator1
            // 
            this.navigator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.navigator1.DisplayStyle = ODModules.Navigator.Style.Left;
            this.navigator1.DisplayText = "Name";
            this.navigator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.navigator1.ForeColor = System.Drawing.Color.White;
            this.navigator1.LinkedList = null;
            this.navigator1.Location = new System.Drawing.Point(350, 0);
            this.navigator1.MidColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.navigator1.Name = "navigator1";
            this.navigator1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navigator1.SelectedItem = -1;
            this.navigator1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navigator1.ShowAnimations = true;
            this.navigator1.Size = new System.Drawing.Size(60, 384);
            this.navigator1.TabIndex = 0;
            // 
            // labelPanel1
            // 
            this.labelPanel1.ArrowColor = System.Drawing.Color.Black;
            this.labelPanel1.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.labelPanel1.CloseColor = System.Drawing.Color.Black;
            this.labelPanel1.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel1.Collapsed = false;
            this.labelPanel1.Controls.Add(this.valuePainter1);
            this.labelPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelPanel1.DropShadow = false;
            this.labelPanel1.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel1.LabelBackColor = System.Drawing.Color.White;
            this.labelPanel1.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel1.LabelForeColor = System.Drawing.Color.Black;
            this.labelPanel1.Location = new System.Drawing.Point(0, 238);
            this.labelPanel1.Name = "labelPanel1";
            this.labelPanel1.OverrideCollapseControl = true;
            this.labelPanel1.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.labelPanel1.PanelCollapsible = true;
            this.labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.Top;
            this.labelPanel1.ShowCloseButton = true;
            this.labelPanel1.Size = new System.Drawing.Size(350, 146);
            this.labelPanel1.TabIndex = 1;
            this.labelPanel1.Text = "labelPanel1";
            // 
            // valuePainter1
            // 
            this.valuePainter1.BorderColor = System.Drawing.Color.DimGray;
            this.valuePainter1.CurrentPaintColor = System.Drawing.Color.LimeGreen;
            this.valuePainter1.CurrentPaintID = "";
            this.valuePainter1.CurrentPaintTag = null;
            this.valuePainter1.CurrentValueMarker = true;
            this.valuePainter1.CurrentValueMarkerColor = System.Drawing.Color.Red;
            this.valuePainter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valuePainter1.EventsOpacity = 128;
            this.valuePainter1.IsActive = true;
            this.valuePainter1.Location = new System.Drawing.Point(0, 18);
            this.valuePainter1.Mode = ODModules.ValuePainter.EditMode.Select;
            this.valuePainter1.Name = "valuePainter1";
            this.valuePainter1.PainterSelected = false;
            this.valuePainter1.SelectColor = System.Drawing.SystemColors.Highlight;
            this.valuePainter1.SelectedBorderColor = System.Drawing.Color.Empty;
            this.valuePainter1.SelectionOpacity = 128;
            this.valuePainter1.ShowAllPaintedEvents = true;
            this.valuePainter1.Size = new System.Drawing.Size(350, 128);
            this.valuePainter1.SpanEnd = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.valuePainter1.SpanStart = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valuePainter1.TabIndex = 0;
            this.valuePainter1.UseFocusSelect = true;
            this.valuePainter1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.valuePainter1.ValueMarkerColor = System.Drawing.Color.Gray;
            this.valuePainter1.ValueMarkerTextColor = System.Drawing.Color.DimGray;
            // 
            // labelPanel2
            // 
            this.labelPanel2.ArrowColor = System.Drawing.Color.Black;
            this.labelPanel2.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelPanel2.CloseColor = System.Drawing.Color.Black;
            this.labelPanel2.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel2.Collapsed = false;
            this.labelPanel2.DropShadow = false;
            this.labelPanel2.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel2.LabelBackColor = System.Drawing.Color.White;
            this.labelPanel2.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel2.LabelForeColor = System.Drawing.Color.Black;
            this.labelPanel2.Location = new System.Drawing.Point(120, 78);
            this.labelPanel2.Name = "labelPanel2";
            this.labelPanel2.OverrideCollapseControl = false;
            this.labelPanel2.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.labelPanel2.PanelCollapsible = false;
            this.labelPanel2.ResizeControl = ODModules.LabelPanel.ResizeDirection.Left;
            this.labelPanel2.ShowCloseButton = true;
            this.labelPanel2.Size = new System.Drawing.Size(129, 137);
            this.labelPanel2.TabIndex = 2;
            this.labelPanel2.Text = "labelPanel2";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(410, 384);
            this.Controls.Add(this.labelPanel2);
            this.Controls.Add(this.labelPanel1);
            this.Controls.Add(this.navigator1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.labelPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ODModules.Navigator navigator1;
        private ODModules.LabelPanel labelPanel1;
        private ODModules.LabelPanel labelPanel2;
        private ODModules.ValuePainter valuePainter1;
    }
}