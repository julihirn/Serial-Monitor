namespace Serial_Monitor.Docks {
    partial class ModbusProperties {
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
            Handlers.NumericalString numericalString1 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString2 = new Handlers.NumericalString();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModbusProperties));
            panel1 = new Panel();
            panel2 = new Panel();
            labelPanel1 = new ODModules.LabelPanel();
            lblpnlUnits = new ODModules.LabelPanel();
            pfsMain = new ODModules.PrefixScale();
            ntbMain = new ODModules.NumericTextbox();
            lblpnlFormat = new ODModules.LabelPanel();
            lblpnlSize = new ODModules.LabelPanel();
            toolStrip1 = new ODModules.ToolStrip();
            lblpnlDisplay = new ODModules.LabelPanel();
            toolStrip2 = new ODModules.ToolStrip();
            ddbFormat = new ToolStripDropDownButton();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            lblpnlUnits.SuspendLayout();
            lblpnlFormat.SuspendLayout();
            lblpnlSize.SuspendLayout();
            lblpnlDisplay.SuspendLayout();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(1, 25);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3);
            panel1.Size = new Size(249, 475);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(labelPanel1);
            panel2.Controls.Add(lblpnlUnits);
            panel2.Controls.Add(lblpnlFormat);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(243, 469);
            panel2.TabIndex = 0;
            // 
            // labelPanel1
            // 
            labelPanel1.ArrowColor = Color.Black;
            labelPanel1.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel1.CloseColor = Color.Black;
            labelPanel1.CloseMouseOverColor = Color.Red;
            labelPanel1.Collapsed = false;
            labelPanel1.Dock = DockStyle.Top;
            labelPanel1.DropShadow = false;
            labelPanel1.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel1.FixedInlineWidth = false;
            labelPanel1.Inlinelabel = false;
            labelPanel1.InlineWidth = 100;
            labelPanel1.LabelBackColor = Color.White;
            labelPanel1.LabelFont = new Font("Segoe UI", 8F);
            labelPanel1.LabelForeColor = Color.Black;
            labelPanel1.Location = new Point(0, 290);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = true;
            labelPanel1.Padding = new Padding(0, 18, 0, 0);
            labelPanel1.PanelCollapsible = true;
            labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            labelPanel1.ShowCloseButton = false;
            labelPanel1.Size = new Size(243, 145);
            labelPanel1.TabIndex = 2;
            labelPanel1.Text = "Appearance";
            // 
            // lblpnlUnits
            // 
            lblpnlUnits.ArrowColor = Color.Black;
            lblpnlUnits.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlUnits.CloseColor = Color.Black;
            lblpnlUnits.CloseMouseOverColor = Color.Red;
            lblpnlUnits.Collapsed = false;
            lblpnlUnits.Controls.Add(pfsMain);
            lblpnlUnits.Controls.Add(ntbMain);
            lblpnlUnits.Dock = DockStyle.Top;
            lblpnlUnits.DropShadow = false;
            lblpnlUnits.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlUnits.FixedInlineWidth = false;
            lblpnlUnits.Inlinelabel = false;
            lblpnlUnits.InlineWidth = 100;
            lblpnlUnits.LabelBackColor = Color.White;
            lblpnlUnits.LabelFont = new Font("Segoe UI", 8F);
            lblpnlUnits.LabelForeColor = Color.Black;
            lblpnlUnits.Location = new Point(0, 145);
            lblpnlUnits.Name = "lblpnlUnits";
            lblpnlUnits.OverrideCollapseControl = true;
            lblpnlUnits.Padding = new Padding(0, 18, 0, 0);
            lblpnlUnits.PanelCollapsible = true;
            lblpnlUnits.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlUnits.ShowCloseButton = false;
            lblpnlUnits.Size = new Size(243, 145);
            lblpnlUnits.TabIndex = 1;
            lblpnlUnits.Text = "Unit";
            // 
            // pfsMain
            // 
            pfsMain.Dock = DockStyle.Top;
            pfsMain.DownColor = Color.FromArgb(255, 128, 0);
            pfsMain.HoverColor = Color.FromArgb(255, 255, 192);
            pfsMain.InactiveForecolor = Color.Gray;
            pfsMain.LinkedNumericControl = ntbMain;
            pfsMain.Location = new Point(0, 45);
            pfsMain.Name = "pfsMain";
            pfsMain.Size = new Size(243, 66);
            pfsMain.TabIndex = 0;
            // 
            // ntbMain
            // 
            ntbMain.AllowClipboard = true;
            ntbMain.AllowDragValueChange = true;
            ntbMain.AllowFractionals = true;
            ntbMain.AllowMouseWheel = true;
            ntbMain.AllowNegatives = true;
            ntbMain.AllowNumberEntry = true;
            ntbMain.AllowTyping = true;
            ntbMain.ArrowKeysControlNumber = true;
            ntbMain.AutoSizeToText = false;
            ntbMain.Base = ODModules.NumericTextbox.NumberBase.Base10;
            ntbMain.BorderColor = Color.DimGray;
            ntbMain.ButtonDownColor = Color.Gray;
            ntbMain.ButtonHoverColor = Color.LightGray;
            ntbMain.Dock = DockStyle.Top;
            ntbMain.FixedNumericPadding = 5;
            ntbMain.FormatOutput = true;
            ntbMain.HasUnit = true;
            ntbMain.IsMetric = true;
            ntbMain.IsSecondaryMetric = false;
            ntbMain.LabelFont = new Font("Segoe UI", 9F);
            ntbMain.LabelForeColor = Color.Gray;
            ntbMain.LabelText = "";
            ntbMain.Location = new Point(0, 18);
            ntbMain.Marked = false;
            ntbMain.MarkedBackColor = Color.Empty;
            ntbMain.MarkedBorderColor = Color.Beige;
            numericalString1.DisplayValue = "100";
            numericalString1.Value = "100";
            ntbMain.Maximum = numericalString1;
            numericalString2.DisplayValue = "0";
            numericalString2.Value = "0";
            ntbMain.Minimum = numericalString2;
            ntbMain.Name = "ntbMain";
            ntbMain.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Right;
            ntbMain.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            ntbMain.NumericalLeftRadixDigitsMaximum = 7;
            ntbMain.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            ntbMain.RangeLimited = false;
            ntbMain.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            ntbMain.SecondaryTag = null;
            ntbMain.SecondaryUnit = "";
            ntbMain.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            ntbMain.SelectedBackColor = Color.Empty;
            ntbMain.SelectedBorderColor = Color.Beige;
            ntbMain.ShowLabel = true;
            ntbMain.Size = new Size(243, 27);
            ntbMain.TabIndex = 1;
            ntbMain.Unit = "";
            ntbMain.UseFixedNumericPadding = true;
            ntbMain.Value = "0";
            ntbMain.Visible = false;
            ntbMain.PrefixChanged += ntbMain_PrefixChanged;
            // 
            // lblpnlFormat
            // 
            lblpnlFormat.ArrowColor = Color.Black;
            lblpnlFormat.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlFormat.CloseColor = Color.Black;
            lblpnlFormat.CloseMouseOverColor = Color.Red;
            lblpnlFormat.Collapsed = false;
            lblpnlFormat.Controls.Add(lblpnlSize);
            lblpnlFormat.Controls.Add(lblpnlDisplay);
            lblpnlFormat.Dock = DockStyle.Top;
            lblpnlFormat.DropShadow = false;
            lblpnlFormat.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlFormat.FixedInlineWidth = false;
            lblpnlFormat.Inlinelabel = false;
            lblpnlFormat.InlineWidth = 100;
            lblpnlFormat.LabelBackColor = Color.White;
            lblpnlFormat.LabelFont = new Font("Segoe UI", 8F);
            lblpnlFormat.LabelForeColor = Color.Black;
            lblpnlFormat.Location = new Point(0, 0);
            lblpnlFormat.Name = "lblpnlFormat";
            lblpnlFormat.OverrideCollapseControl = true;
            lblpnlFormat.Padding = new Padding(5, 18, 0, 0);
            lblpnlFormat.PanelCollapsible = true;
            lblpnlFormat.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlFormat.ShowCloseButton = false;
            lblpnlFormat.Size = new Size(243, 145);
            lblpnlFormat.TabIndex = 0;
            lblpnlFormat.Text = "Format";
            // 
            // lblpnlSize
            // 
            lblpnlSize.ArrowColor = Color.Black;
            lblpnlSize.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlSize.AutoSize = true;
            lblpnlSize.CloseColor = Color.Black;
            lblpnlSize.CloseMouseOverColor = Color.Red;
            lblpnlSize.Collapsed = false;
            lblpnlSize.Controls.Add(toolStrip1);
            lblpnlSize.Dock = DockStyle.Top;
            lblpnlSize.DropShadow = false;
            lblpnlSize.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlSize.FixedInlineWidth = true;
            lblpnlSize.Inlinelabel = true;
            lblpnlSize.InlineWidth = 50;
            lblpnlSize.LabelBackColor = Color.White;
            lblpnlSize.LabelFont = new Font("Segoe UI", 8F);
            lblpnlSize.LabelForeColor = Color.White;
            lblpnlSize.Location = new Point(5, 53);
            lblpnlSize.Name = "lblpnlSize";
            lblpnlSize.OverrideCollapseControl = false;
            lblpnlSize.Padding = new Padding(63, 5, 5, 5);
            lblpnlSize.PanelCollapsible = true;
            lblpnlSize.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlSize.ShowCloseButton = true;
            lblpnlSize.Size = new Size(238, 35);
            lblpnlSize.TabIndex = 1;
            lblpnlSize.Text = "Size";
            // 
            // toolStrip1
            // 
            toolStrip1.BackColorNorth = Color.DodgerBlue;
            toolStrip1.BackColorSouth = Color.DodgerBlue;
            toolStrip1.BorderColor = Color.WhiteSmoke;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            toolStrip1.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            toolStrip1.ItemForeColor = Color.Black;
            toolStrip1.ItemSelectedBackColorNorth = Color.White;
            toolStrip1.ItemSelectedBackColorSouth = Color.White;
            toolStrip1.ItemSelectedForeColor = Color.Black;
            toolStrip1.Location = new Point(63, 5);
            toolStrip1.MenuBackColorNorth = Color.DodgerBlue;
            toolStrip1.MenuBackColorSouth = Color.DodgerBlue;
            toolStrip1.MenuBorderColor = Color.WhiteSmoke;
            toolStrip1.MenuSeparatorColor = Color.WhiteSmoke;
            toolStrip1.MenuSymbolColor = Color.WhiteSmoke;
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(1, 0, 1, 0);
            toolStrip1.RoundedToolStrip = false;
            toolStrip1.ShowBorder = true;
            toolStrip1.Size = new Size(170, 25);
            toolStrip1.StripItemSelectedBackColorNorth = Color.White;
            toolStrip1.StripItemSelectedBackColorSouth = Color.White;
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // lblpnlDisplay
            // 
            lblpnlDisplay.ArrowColor = Color.Black;
            lblpnlDisplay.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlDisplay.AutoSize = true;
            lblpnlDisplay.CloseColor = Color.Black;
            lblpnlDisplay.CloseMouseOverColor = Color.Red;
            lblpnlDisplay.Collapsed = false;
            lblpnlDisplay.Controls.Add(toolStrip2);
            lblpnlDisplay.Dock = DockStyle.Top;
            lblpnlDisplay.DropShadow = false;
            lblpnlDisplay.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlDisplay.FixedInlineWidth = true;
            lblpnlDisplay.Inlinelabel = true;
            lblpnlDisplay.InlineWidth = 50;
            lblpnlDisplay.LabelBackColor = Color.White;
            lblpnlDisplay.LabelFont = new Font("Segoe UI", 8F);
            lblpnlDisplay.LabelForeColor = Color.White;
            lblpnlDisplay.Location = new Point(5, 18);
            lblpnlDisplay.Name = "lblpnlDisplay";
            lblpnlDisplay.OverrideCollapseControl = false;
            lblpnlDisplay.Padding = new Padding(63, 5, 5, 5);
            lblpnlDisplay.PanelCollapsible = true;
            lblpnlDisplay.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlDisplay.ShowCloseButton = true;
            lblpnlDisplay.Size = new Size(238, 35);
            lblpnlDisplay.TabIndex = 0;
            lblpnlDisplay.Text = "Display";
            // 
            // toolStrip2
            // 
            toolStrip2.BackColorNorth = Color.DodgerBlue;
            toolStrip2.BackColorSouth = Color.DodgerBlue;
            toolStrip2.BorderColor = Color.WhiteSmoke;
            toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip2.ItemCheckedBackColorNorth = Color.FromArgb(128, 128, 128, 128);
            toolStrip2.ItemCheckedBackColorSouth = Color.FromArgb(128, 128, 128, 128);
            toolStrip2.ItemForeColor = Color.Black;
            toolStrip2.Items.AddRange(new ToolStripItem[] { ddbFormat });
            toolStrip2.ItemSelectedBackColorNorth = Color.White;
            toolStrip2.ItemSelectedBackColorSouth = Color.White;
            toolStrip2.ItemSelectedForeColor = Color.Black;
            toolStrip2.Location = new Point(63, 5);
            toolStrip2.MenuBackColorNorth = Color.DodgerBlue;
            toolStrip2.MenuBackColorSouth = Color.DodgerBlue;
            toolStrip2.MenuBorderColor = Color.WhiteSmoke;
            toolStrip2.MenuSeparatorColor = Color.WhiteSmoke;
            toolStrip2.MenuSymbolColor = Color.WhiteSmoke;
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Padding = new Padding(1, 0, 1, 0);
            toolStrip2.RoundedToolStrip = false;
            toolStrip2.ShowBorder = true;
            toolStrip2.Size = new Size(170, 25);
            toolStrip2.StripItemSelectedBackColorNorth = Color.White;
            toolStrip2.StripItemSelectedBackColorSouth = Color.White;
            toolStrip2.TabIndex = 1;
            toolStrip2.Text = "toolStrip2";
            // 
            // ddbFormat
            // 
            ddbFormat.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ddbFormat.Image = (Image)resources.GetObject("ddbFormat.Image");
            ddbFormat.ImageScaling = ToolStripItemImageScaling.None;
            ddbFormat.ImageTransparentColor = Color.Magenta;
            ddbFormat.Name = "ddbFormat";
            ddbFormat.Size = new Size(58, 22);
            ddbFormat.Text = "Format";
            // 
            // ModbusProperties
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            DefaultDockArea = ODModules.Docking.DockArea.Right;
            DockText = "Properties";
            Name = "ModbusProperties";
            Size = new Size(251, 501);
            Load += ModbusProperties_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            lblpnlUnits.ResumeLayout(false);
            lblpnlFormat.ResumeLayout(false);
            lblpnlFormat.PerformLayout();
            lblpnlSize.ResumeLayout(false);
            lblpnlSize.PerformLayout();
            lblpnlDisplay.ResumeLayout(false);
            lblpnlDisplay.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private ODModules.LabelPanel lblpnlFormat;
        private ODModules.LabelPanel lblpnlUnits;
        private ODModules.PrefixScale pfsMain;
        private ODModules.NumericTextbox ntbMain;
        private ODModules.LabelPanel labelPanel1;
        private ODModules.LabelPanel lblpnlDisplay;
        private ODModules.LabelPanel lblpnlSize;
        private ODModules.ToolStrip toolStrip1;
        private ODModules.ToolStrip toolStrip2;
        private ToolStripDropDownButton ddbFormat;
    }
}
