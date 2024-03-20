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
            panel1 = new Panel();
            panel2 = new Panel();
            labelPanel1 = new ODModules.LabelPanel();
            lblpnlUnits = new ODModules.LabelPanel();
            pfsMain = new ODModules.PrefixScale();
            ntbMain = new ODModules.NumericTextbox();
            lblpnlFormat = new ODModules.LabelPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            lblpnlUnits.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(1, 25);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3);
            panel1.Size = new Size(301, 475);
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
            panel2.Size = new Size(295, 469);
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
            labelPanel1.Size = new Size(295, 145);
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
            lblpnlUnits.Size = new Size(295, 145);
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
            pfsMain.Size = new Size(295, 66);
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
            ntbMain.Size = new Size(295, 27);
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
            lblpnlFormat.Size = new Size(295, 145);
            lblpnlFormat.TabIndex = 0;
            lblpnlFormat.Text = "Format";
            // 
            // ModbusProperties
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            DefaultDockArea = ODModules.Docking.DockArea.Right;
            DockText = "Properties";
            Name = "ModbusProperties";
            Size = new Size(303, 501);
            Load += ModbusProperties_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            lblpnlUnits.ResumeLayout(false);
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
    }
}
