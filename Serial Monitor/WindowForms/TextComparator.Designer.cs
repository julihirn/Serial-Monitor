namespace Serial_Monitor.WindowForms {
    partial class TextComparator {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextComparator));
            this.textCompare1 = new ODModules.TextCompare();
            this.labelPanel1 = new ODModules.LabelPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelPanel2 = new ODModules.LabelPanel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelPanel1.SuspendLayout();
            this.labelPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textCompare1
            // 
            this.textCompare1.CompareFrom = "";
            this.textCompare1.CompareTo = "";
            this.textCompare1.DifferenceColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textCompare1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textCompare1.EmptyTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.textCompare1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textCompare1.ForeColor = System.Drawing.Color.White;
            this.textCompare1.Location = new System.Drawing.Point(0, 78);
            this.textCompare1.Name = "textCompare1";
            this.textCompare1.Padding = new System.Windows.Forms.Padding(5);
            this.textCompare1.SameColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.textCompare1.Size = new System.Drawing.Size(315, 110);
            this.textCompare1.TabIndex = 0;
            this.textCompare1.TextPosition = 0;
            this.textCompare1.UseEmptyTextColor = true;
            // 
            // labelPanel1
            // 
            this.labelPanel1.ArrowColor = System.Drawing.Color.LightGray;
            this.labelPanel1.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel1.AutoSize = true;
            this.labelPanel1.CloseColor = System.Drawing.Color.Black;
            this.labelPanel1.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel1.Collapsed = false;
            this.labelPanel1.Controls.Add(this.textBox1);
            this.labelPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPanel1.DropShadow = false;
            this.labelPanel1.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel1.ForeColor = System.Drawing.Color.White;
            this.labelPanel1.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.labelPanel1.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel1.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelPanel1.Location = new System.Drawing.Point(0, 0);
            this.labelPanel1.Name = "labelPanel1";
            this.labelPanel1.OverrideCollapseControl = false;
            this.labelPanel1.Padding = new System.Windows.Forms.Padding(5, 18, 5, 5);
            this.labelPanel1.PanelCollapsible = false;
            this.labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.labelPanel1.ShowCloseButton = false;
            this.labelPanel1.Size = new System.Drawing.Size(315, 39);
            this.labelPanel1.TabIndex = 1;
            this.labelPanel1.Text = "Compare From";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(5, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(305, 16);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labelPanel2
            // 
            this.labelPanel2.ArrowColor = System.Drawing.Color.LightGray;
            this.labelPanel2.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.labelPanel2.AutoSize = true;
            this.labelPanel2.CloseColor = System.Drawing.Color.Black;
            this.labelPanel2.CloseMouseOverColor = System.Drawing.Color.Red;
            this.labelPanel2.Collapsed = false;
            this.labelPanel2.Controls.Add(this.textBox2);
            this.labelPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPanel2.DropShadow = false;
            this.labelPanel2.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPanel2.ForeColor = System.Drawing.Color.White;
            this.labelPanel2.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.labelPanel2.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel2.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelPanel2.Location = new System.Drawing.Point(0, 39);
            this.labelPanel2.Name = "labelPanel2";
            this.labelPanel2.OverrideCollapseControl = false;
            this.labelPanel2.Padding = new System.Windows.Forms.Padding(5, 18, 5, 5);
            this.labelPanel2.PanelCollapsible = false;
            this.labelPanel2.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.labelPanel2.ShowCloseButton = false;
            this.labelPanel2.Size = new System.Drawing.Size(315, 39);
            this.labelPanel2.TabIndex = 2;
            this.labelPanel2.Text = "Compare To";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(5, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(305, 16);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // TextComparator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(315, 188);
            this.Controls.Add(this.textCompare1);
            this.Controls.Add(this.labelPanel2);
            this.Controls.Add(this.labelPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextComparator";
            this.Text = "Text Comparator";
            this.Load += new System.EventHandler(this.TextComparator_Load);
            this.labelPanel1.ResumeLayout(false);
            this.labelPanel1.PerformLayout();
            this.labelPanel2.ResumeLayout(false);
            this.labelPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ODModules.TextCompare textCompare1;
        private ODModules.LabelPanel labelPanel1;
        private TextBox textBox1;
        private ODModules.LabelPanel labelPanel2;
        private TextBox textBox2;
    }
}