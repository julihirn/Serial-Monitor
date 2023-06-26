namespace Serial_Monitor {
    partial class InsertModbusMonitor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertModbusMonitor));
            this.labelPanel1 = new ODModules.LabelPanel();
            this.labelPanel2 = new ODModules.LabelPanel();
            this.labelPanel3 = new ODModules.LabelPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new ODModules.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPanel1
            // 
            this.labelPanel1.ArrowColor = System.Drawing.Color.DarkGray;
            this.labelPanel1.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel1.CloseColor = System.Drawing.Color.Black;
            this.labelPanel1.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel1.Collapsed = false;
            this.labelPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPanel1.DropShadow = false;
            this.labelPanel1.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel1.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labelPanel1.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel1.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelPanel1.Location = new System.Drawing.Point(5, 5);
            this.labelPanel1.Name = "labelPanel1";
            this.labelPanel1.OverrideCollapseControl = false;
            this.labelPanel1.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.labelPanel1.PanelCollapsible = true;
            this.labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.labelPanel1.ShowCloseButton = false;
            this.labelPanel1.Size = new System.Drawing.Size(258, 55);
            this.labelPanel1.TabIndex = 0;
            this.labelPanel1.Text = "Channel";
            // 
            // labelPanel2
            // 
            this.labelPanel2.ArrowColor = System.Drawing.Color.DarkGray;
            this.labelPanel2.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel2.CloseColor = System.Drawing.Color.Black;
            this.labelPanel2.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel2.Collapsed = false;
            this.labelPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPanel2.DropShadow = false;
            this.labelPanel2.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labelPanel2.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labelPanel2.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel2.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelPanel2.Location = new System.Drawing.Point(5, 60);
            this.labelPanel2.Name = "labelPanel2";
            this.labelPanel2.OverrideCollapseControl = false;
            this.labelPanel2.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.labelPanel2.PanelCollapsible = true;
            this.labelPanel2.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.labelPanel2.ShowCloseButton = false;
            this.labelPanel2.Size = new System.Drawing.Size(258, 54);
            this.labelPanel2.TabIndex = 1;
            this.labelPanel2.Text = "Register Type";
            // 
            // labelPanel3
            // 
            this.labelPanel3.ArrowColor = System.Drawing.Color.DarkGray;
            this.labelPanel3.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel3.CloseColor = System.Drawing.Color.Black;
            this.labelPanel3.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel3.Collapsed = false;
            this.labelPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPanel3.DropShadow = false;
            this.labelPanel3.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labelPanel3.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.labelPanel3.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel3.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelPanel3.Location = new System.Drawing.Point(5, 114);
            this.labelPanel3.Name = "labelPanel3";
            this.labelPanel3.OverrideCollapseControl = false;
            this.labelPanel3.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.labelPanel3.PanelCollapsible = false;
            this.labelPanel3.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.labelPanel3.ShowCloseButton = false;
            this.labelPanel3.Size = new System.Drawing.Size(258, 139);
            this.labelPanel3.TabIndex = 2;
            this.labelPanel3.Text = "Registers/Coils";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 26);
            this.panel1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.AllowGroupUnchecking = false;
            this.button1.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.button1.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.button1.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.button1.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.button1.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.button1.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.button1.BackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.button1.BackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.button1.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.button1.BorderColorDownNorth = System.Drawing.Color.Black;
            this.button1.BorderColorDownSouth = System.Drawing.Color.Black;
            this.button1.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.button1.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.button1.BorderColorNorth = System.Drawing.Color.Black;
            this.button1.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.BorderColorSouth = System.Drawing.Color.Black;
            this.button1.BorderRadius = 5;
            this.button1.Checked = false;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.GroupMaximumChecked = 2;
            this.button1.Location = new System.Drawing.Point(170, 0);
            this.button1.Name = "button1";
            this.button1.RadioButtonGroup = "";
            this.button1.SecondaryFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.SecondaryText = "";
            this.button1.Size = new System.Drawing.Size(88, 26);
            this.button1.Style = ODModules.ButtonStyle.Square;
            this.button1.TabIndex = 0;
            this.button1.Text = "Insert";
            this.button1.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.button1.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.button1.Type = ODModules.ButtonType.Button;
            // 
            // InsertModbusMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(268, 284);
            this.Controls.Add(this.labelPanel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelPanel2);
            this.Controls.Add(this.labelPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InsertModbusMonitor";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Insert Modbus Monitor";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ODModules.LabelPanel labelPanel1;
        private ODModules.LabelPanel labelPanel2;
        private ODModules.LabelPanel labelPanel3;
        private Panel panel1;
        private ODModules.Button button1;
    }
}