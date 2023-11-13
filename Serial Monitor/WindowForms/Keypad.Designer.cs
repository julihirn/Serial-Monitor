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
            this.msMain = new ODModules.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlProperties.SuspendLayout();
            this.msMain.SuspendLayout();
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
            this.kpCommands.Location = new System.Drawing.Point(0, 44);
            this.kpCommands.Margin = new System.Windows.Forms.Padding(6);
            this.kpCommands.MarkedIndex = -1;
            this.kpCommands.Name = "kpCommands";
            this.kpCommands.Padding = new System.Windows.Forms.Padding(19, 21, 19, 21);
            this.kpCommands.Rows = 5;
            this.kpCommands.SecondaryFont = null;
            this.kpCommands.Size = new System.Drawing.Size(139, 726);
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
            this.pnlProperties.Location = new System.Drawing.Point(139, 44);
            this.pnlProperties.Margin = new System.Windows.Forms.Padding(6);
            this.pnlProperties.Name = "pnlProperties";
            this.pnlProperties.OverrideCollapseControl = false;
            this.pnlProperties.Padding = new System.Windows.Forms.Padding(9, 37, 0, 0);
            this.pnlProperties.PanelCollapsible = false;
            this.pnlProperties.ResizeControl = ODModules.LabelPanel.ResizeDirection.Left;
            this.pnlProperties.ShowCloseButton = true;
            this.pnlProperties.Size = new System.Drawing.Size(481, 726);
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
            this.propertyGrid1.Location = new System.Drawing.Point(9, 37);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(6);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(472, 689);
            this.propertyGrid1.TabIndex = 7;
            this.propertyGrid1.ToolbarVisible = false;
            this.propertyGrid1.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.propertyGrid1.ViewBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.propertyGrid1.ViewForeColor = System.Drawing.Color.White;
            // 
            // msMain
            // 
            this.msMain.BackColorNorth = System.Drawing.Color.DodgerBlue;
            this.msMain.BackColorNorthFadeIn = System.Drawing.Color.DodgerBlue;
            this.msMain.BackColorSouth = System.Drawing.Color.DodgerBlue;
            this.msMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.msMain.ItemForeColor = System.Drawing.Color.Black;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.msMain.ItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.msMain.ItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.msMain.ItemSelectedForeColor = System.Drawing.Color.Black;
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.MenuBackColorNorth = System.Drawing.Color.DodgerBlue;
            this.msMain.MenuBackColorSouth = System.Drawing.Color.DodgerBlue;
            this.msMain.MenuBorderColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.MenuSeparatorColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.MenuSymbolColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.msMain.Size = new System.Drawing.Size(620, 44);
            this.msMain.StripItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.msMain.StripItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.msMain.TabIndex = 2;
            this.msMain.Text = "Main";
            this.msMain.UseNorthFadeIn = false;
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMostToolStripMenuItem});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(85, 36);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // topMostToolStripMenuItem
            // 
            this.topMostToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.topMostToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            this.topMostToolStripMenuItem.Size = new System.Drawing.Size(247, 44);
            this.topMostToolStripMenuItem.Text = "&Top Most";
            this.topMostToolStripMenuItem.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
            // 
            // Keypad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(620, 770);
            this.Controls.Add(this.kpCommands);
            this.Controls.Add(this.pnlProperties);
            this.Controls.Add(this.msMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(620, 737);
            this.Name = "Keypad";
            this.Text = "Keypad";
            this.Load += new System.EventHandler(this.Keypad_Load);
            this.pnlProperties.ResumeLayout(false);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // private ODModules.Keypad keypad1;
        private ODModules.Keypad kpCommands;
        private ODModules.LabelPanel pnlProperties;
        private PropertyGrid propertyGrid1;
        private ODModules.MenuStrip msMain;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem topMostToolStripMenuItem;
    }
}