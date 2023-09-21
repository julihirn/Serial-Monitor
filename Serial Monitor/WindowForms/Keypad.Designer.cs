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
            this.pnlProperties = new ODModules.LabelPanel();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.pnlProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpCommands
            // 
            this.kpCommands.AllowTextWrapping = true;
            this.kpCommands.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.kpCommands.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.kpCommands.BackColorDisabledNorth = System.Drawing.Color.Black;
            this.kpCommands.BackColorDisabledSouth = System.Drawing.Color.Black;
            this.kpCommands.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.kpCommands.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.kpCommands.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.kpCommands.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.kpCommands.BackColorMarkedNorth = System.Drawing.Color.Black;
            this.kpCommands.BackColorMarkedSouth = System.Drawing.Color.Black;
            this.kpCommands.BackColorNorth = System.Drawing.Color.DimGray;
            this.kpCommands.BackColorSouth = System.Drawing.Color.DimGray;
            this.kpCommands.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorDisabledNorth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorDisabledSouth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorDownNorth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorDownSouth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorMarkedNorth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorMarkedSouth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorNorth = System.Drawing.Color.Black;
            this.kpCommands.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kpCommands.BorderColorSouth = System.Drawing.Color.Black;
            this.kpCommands.BorderRadius = 5;
            this.kpCommands.ButtonPadding = new System.Windows.Forms.Padding(0);
            this.kpCommands.Columns = 5;
            this.kpCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpCommands.ExternalItems = null;
            this.kpCommands.IconInline = false;
            this.kpCommands.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.kpCommands.ImageSize = new System.Drawing.Size(32, 32);
            this.kpCommands.Location = new System.Drawing.Point(0, 0);
            this.kpCommands.MarkedIndex = -1;
            this.kpCommands.Name = "kpCommands";
            this.kpCommands.Padding = new System.Windows.Forms.Padding(10);
            this.kpCommands.Rows = 5;
            this.kpCommands.SecondaryFont = null;
            this.kpCommands.Size = new System.Drawing.Size(75, 361);
            this.kpCommands.Style = ODModules.ButtonStyle.Round;
            this.kpCommands.TabIndex = 0;
            this.kpCommands.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            this.kpCommands.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.kpCommands.UseLocalList = false;
            this.kpCommands.ButtonRightClicked += new ODModules.Keypad.ButtonClickedEventHandler(this.kpCommands_ButtonRightClicked);
            this.kpCommands.ButtonClicked += new ODModules.Keypad.ButtonClickedEventHandler(this.keypad1_ButtonClicked);
            // 
            // pnlProperties
            // 
            this.pnlProperties.ArrowColor = System.Drawing.Color.Black;
            this.pnlProperties.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.pnlProperties.CloseColor = System.Drawing.Color.Black;
            this.pnlProperties.CloseMouseOverColor = System.Drawing.Color.Red;
            this.pnlProperties.Collapsed = false;
            this.pnlProperties.Controls.Add(this.propertyGrid1);
            this.pnlProperties.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlProperties.DropShadow = false;
            this.pnlProperties.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlProperties.FixedInlineWidth = false;
            this.pnlProperties.Inlinelabel = false;
            this.pnlProperties.InlineWidth = 100;
            this.pnlProperties.LabelBackColor = System.Drawing.Color.White;
            this.pnlProperties.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pnlProperties.LabelForeColor = System.Drawing.Color.Black;
            this.pnlProperties.Location = new System.Drawing.Point(75, 0);
            this.pnlProperties.Name = "pnlProperties";
            this.pnlProperties.OverrideCollapseControl = false;
            this.pnlProperties.Padding = new System.Windows.Forms.Padding(5, 18, 0, 0);
            this.pnlProperties.PanelCollapsible = false;
            this.pnlProperties.ResizeControl = ODModules.LabelPanel.ResizeDirection.Left;
            this.pnlProperties.ShowCloseButton = true;
            this.pnlProperties.Size = new System.Drawing.Size(259, 361);
            this.pnlProperties.TabIndex = 1;
            this.pnlProperties.Text = "Properties";
            this.pnlProperties.Visible = false;
            this.pnlProperties.CloseButtonClicked += new ODModules.LabelPanel.CloseClickedHandler(this.pnlProperties_CloseButtonClicked);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.CanShowVisualStyleGlyphs = false;
            this.propertyGrid1.CategoryForeColor = System.Drawing.Color.White;
            this.propertyGrid1.CategorySplitterColor = System.Drawing.Color.Silver;
            this.propertyGrid1.CommandsForeColor = System.Drawing.Color.White;
            this.propertyGrid1.CommandsVisibleIfAvailable = false;
            this.propertyGrid1.DisabledItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpBackColor = System.Drawing.Color.Gray;
            this.propertyGrid1.HelpBorderColor = System.Drawing.Color.Gray;
            this.propertyGrid1.HelpForeColor = System.Drawing.SystemColors.Window;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.propertyGrid1.Location = new System.Drawing.Point(5, 18);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(254, 343);
            this.propertyGrid1.TabIndex = 7;
            this.propertyGrid1.ToolbarVisible = false;
            this.propertyGrid1.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.propertyGrid1.ViewBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.propertyGrid1.ViewForeColor = System.Drawing.Color.White;
            // 
            // Keypad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(334, 361);
            this.Controls.Add(this.kpCommands);
            this.Controls.Add(this.pnlProperties);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(350, 400);
            this.Name = "Keypad";
            this.Text = "Keypad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Keypad_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Keypad_FormClosed);
            this.Load += new System.EventHandler(this.Keypad_Load);
            this.SizeChanged += new System.EventHandler(this.Keypad_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.Keypad_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Keypad_KeyDown);
            this.pnlProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

       // private ODModules.Keypad keypad1;
        private ODModules.Keypad kpCommands;
        private ODModules.LabelPanel pnlProperties;
        private PropertyGrid propertyGrid1;
    }
}