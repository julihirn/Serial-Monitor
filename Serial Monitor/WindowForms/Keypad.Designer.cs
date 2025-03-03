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
            kpCommands = new ODModules.Keypad();
            pnlProperties = new ODModules.LabelPanel();
            propertyGrid1 = new PropertyGrid();
            msMain = new ODModules.MenuStrip();
            viewToolStripMenuItem = new ToolStripMenuItem();
            topMostToolStripMenuItem = new ToolStripMenuItem();
            pnlProperties.SuspendLayout();
            msMain.SuspendLayout();
            SuspendLayout();
            // 
            // kpCommands
            // 
            kpCommands.AllowTextWrapping = true;
            kpCommands.BackColorCheckedNorth = Color.Orange;
            kpCommands.BackColorCheckedSouth = Color.Orange;
            kpCommands.BackColorDisabledNorth = Color.Black;
            kpCommands.BackColorDisabledSouth = Color.Black;
            kpCommands.BackColorDownNorth = Color.DimGray;
            kpCommands.BackColorDownSouth = Color.DimGray;
            kpCommands.BackColorHoverNorth = Color.SkyBlue;
            kpCommands.BackColorHoverSouth = Color.SkyBlue;
            kpCommands.BackColorMarkedNorth = Color.Black;
            kpCommands.BackColorMarkedSouth = Color.Black;
            kpCommands.BackColorNorth = Color.DimGray;
            kpCommands.BackColorSouth = Color.DimGray;
            kpCommands.BorderColorCheckedNorth = Color.Black;
            kpCommands.BorderColorCheckedSouth = Color.Black;
            kpCommands.BorderColorDisabledNorth = Color.Black;
            kpCommands.BorderColorDisabledSouth = Color.Black;
            kpCommands.BorderColorDownNorth = Color.Black;
            kpCommands.BorderColorDownSouth = Color.Black;
            kpCommands.BorderColorHoverNorth = Color.Black;
            kpCommands.BorderColorHoverSouth = Color.Black;
            kpCommands.BorderColorMarkedNorth = Color.Black;
            kpCommands.BorderColorMarkedSouth = Color.Black;
            kpCommands.BorderColorNorth = Color.Black;
            kpCommands.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            kpCommands.BorderColorSouth = Color.Black;
            kpCommands.BorderRadius = 5;
            kpCommands.ButtonPadding = new Padding(0);
            kpCommands.Columns = 5;
            kpCommands.Dock = DockStyle.Fill;
            kpCommands.ExternalItems = null;
            kpCommands.IconInline = false;
            kpCommands.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            kpCommands.ImageSize = new Size(32, 32);
            kpCommands.Location = new Point(0, 44);
            kpCommands.Margin = new Padding(6, 6, 6, 6);
            kpCommands.MarkedIndex = -1;
            kpCommands.Name = "kpCommands";
            kpCommands.Padding = new Padding(19, 21, 19, 21);
            kpCommands.Rows = 5;
            kpCommands.SecondaryFont = null;
            kpCommands.Size = new Size(139, 726);
            kpCommands.Style = ODModules.ButtonStyle.Round;
            kpCommands.TabIndex = 0;
            kpCommands.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            kpCommands.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            kpCommands.UseLocalList = false;
            kpCommands.ButtonRightClicked += kpCommands_ButtonRightClicked;
            kpCommands.ButtonClicked += keypad1_ButtonClicked;
            // 
            // pnlProperties
            // 
            pnlProperties.ArrowColor = Color.Black;
            pnlProperties.ArrowMouseOverColor = Color.DodgerBlue;
            pnlProperties.CloseColor = Color.Black;
            pnlProperties.CloseMouseOverColor = Color.Red;
            pnlProperties.Collapsed = false;
            pnlProperties.Controls.Add(propertyGrid1);
            pnlProperties.Dock = DockStyle.Right;
            pnlProperties.DropShadow = false;
            pnlProperties.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            pnlProperties.FixedInlineWidth = false;
            pnlProperties.Inlinelabel = false;
            pnlProperties.InlineWidth = 100;
            pnlProperties.LabelBackColor = Color.White;
            pnlProperties.LabelFont = new Font("Segoe UI", 8F);
            pnlProperties.LabelForeColor = Color.Black;
            pnlProperties.Location = new Point(139, 44);
            pnlProperties.Margin = new Padding(6, 6, 6, 6);
            pnlProperties.Name = "pnlProperties";
            pnlProperties.OverrideCollapseControl = false;
            pnlProperties.Padding = new Padding(9, 41, 0, 0);
            pnlProperties.PanelCollapsible = false;
            pnlProperties.ResizeControl = ODModules.LabelPanel.ResizeDirection.Left;
            pnlProperties.SeparatorColor = Color.Gray;
            pnlProperties.ShowCloseButton = true;
            pnlProperties.ShowSeparator = false;
            pnlProperties.Size = new Size(481, 726);
            pnlProperties.TabIndex = 1;
            pnlProperties.Text = "Properties";
            pnlProperties.Visible = false;
            pnlProperties.CloseButtonClicked += pnlProperties_CloseButtonClicked;
            // 
            // propertyGrid1
            // 
            propertyGrid1.CanShowVisualStyleGlyphs = false;
            propertyGrid1.CategoryForeColor = Color.White;
            propertyGrid1.CategorySplitterColor = Color.Silver;
            propertyGrid1.CommandsForeColor = Color.White;
            propertyGrid1.CommandsVisibleIfAvailable = false;
            propertyGrid1.DisabledItemForeColor = Color.FromArgb(127, 255, 255, 255);
            propertyGrid1.Dock = DockStyle.Fill;
            propertyGrid1.HelpBackColor = Color.Gray;
            propertyGrid1.HelpBorderColor = Color.Gray;
            propertyGrid1.HelpForeColor = SystemColors.Window;
            propertyGrid1.HelpVisible = false;
            propertyGrid1.LineColor = Color.FromArgb(40, 40, 40);
            propertyGrid1.Location = new Point(9, 41);
            propertyGrid1.Margin = new Padding(6, 6, 6, 6);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(472, 685);
            propertyGrid1.TabIndex = 7;
            propertyGrid1.ToolbarVisible = false;
            propertyGrid1.ViewBackColor = Color.FromArgb(20, 20, 20);
            propertyGrid1.ViewBorderColor = Color.FromArgb(20, 20, 20);
            propertyGrid1.ViewForeColor = Color.White;
            // 
            // msMain
            // 
            msMain.BackColorNorth = Color.DodgerBlue;
            msMain.BackColorNorthFadeIn = Color.DodgerBlue;
            msMain.BackColorSouth = Color.DodgerBlue;
            msMain.Fade = true;
            msMain.ImageScalingSize = new Size(32, 32);
            msMain.ItemForeColor = Color.Black;
            msMain.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem });
            msMain.ItemSelectedBackColorNorth = Color.White;
            msMain.ItemSelectedBackColorSouth = Color.White;
            msMain.ItemSelectedForeColor = Color.Black;
            msMain.Location = new Point(0, 0);
            msMain.MenuBackColorNorth = Color.DodgerBlue;
            msMain.MenuBackColorSouth = Color.DodgerBlue;
            msMain.MenuBorderColor = Color.WhiteSmoke;
            msMain.MenuSeparatorColor = Color.WhiteSmoke;
            msMain.MenuSymbolColor = Color.WhiteSmoke;
            msMain.Name = "msMain";
            msMain.Padding = new Padding(11, 4, 0, 4);
            msMain.Size = new Size(620, 44);
            msMain.StripItemSelectedBackColorNorth = Color.White;
            msMain.StripItemSelectedBackColorSouth = Color.White;
            msMain.TabIndex = 2;
            msMain.Text = "Main";
            msMain.UseNorthFadeIn = false;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { topMostToolStripMenuItem });
            viewToolStripMenuItem.ForeColor = Color.Black;
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(85, 36);
            viewToolStripMenuItem.Text = "&View";
            // 
            // topMostToolStripMenuItem
            // 
            topMostToolStripMenuItem.ForeColor = Color.Black;
            topMostToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            topMostToolStripMenuItem.Size = new Size(247, 44);
            topMostToolStripMenuItem.Text = "&Top Most";
            topMostToolStripMenuItem.Click += topMostToolStripMenuItem_Click;
            // 
            // Keypad
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(16, 16, 16);
            ClientSize = new Size(620, 770);
            Controls.Add(kpCommands);
            Controls.Add(pnlProperties);
            Controls.Add(msMain);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = msMain;
            Margin = new Padding(6, 6, 6, 6);
            MinimumSize = new Size(585, 592);
            Name = "Keypad";
            Text = "Keypad";
            Load += Keypad_Load;
            pnlProperties.ResumeLayout(false);
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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