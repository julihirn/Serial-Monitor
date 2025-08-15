namespace Serial_Monitor.Components {
    partial class AppearancePopup {
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
            Handlers.NumericalString numericalString3 = new Handlers.NumericalString();
            Handlers.NumericalString numericalString4 = new Handlers.NumericalString();
            thSettings = new ODModules.TabHeader();
            tcPages = new ODModules.HiddenTabControl();
            tabPage1 = new TabPage();
            cwMain = new ODModules.ColorWheel();
            panel1 = new Panel();
            cbxBack = new CheckBox();
            cbxFore = new CheckBox();
            label2 = new Label();
            btnBack = new ODModules.Button();
            label1 = new Label();
            btnFore = new ODModules.Button();
            lcsBrightness = new ODModules.LightnessColorSlider();
            tabPage2 = new TabPage();
            psMainScaler = new ODModules.PrefixScale();
            ntbTemplate = new ODModules.NumericTextbox();
            lblpnlUnit = new ODModules.LabelPanel();
            tbUnit = new ODModules.TextBox();
            tcPages.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            lblpnlUnit.SuspendLayout();
            SuspendLayout();
            // 
            // thSettings
            // 
            thSettings.AddHoverColor = Color.LimeGreen;
            thSettings.AllowDragReordering = false;
            thSettings.AllowTabResize = true;
            thSettings.ArrowColor = Color.Black;
            thSettings.ArrowDisabledColor = Color.Black;
            thSettings.ArrowHoverColor = Color.Black;
            thSettings.BindedTabControl = tcPages;
            thSettings.CloseHoverColor = Color.Red;
            thSettings.Dock = DockStyle.Top;
            thSettings.ForeColor = Color.Silver;
            thSettings.HeaderDownForeColor = Color.Gray;
            thSettings.HeaderForeColor = Color.Black;
            thSettings.HeaderHoverForeColor = Color.Blue;
            thSettings.Location = new Point(0, 0);
            thSettings.Margin = new Padding(2, 1, 2, 1);
            thSettings.Name = "thSettings";
            thSettings.SelectedIndex = 0;
            thSettings.ShowAddButton = false;
            thSettings.ShowHeader = false;
            thSettings.ShowTabDividers = true;
            thSettings.ShowTabs = true;
            thSettings.Size = new Size(289, 23);
            thSettings.TabBackColor = Color.Gray;
            thSettings.TabBorderColor = Color.DimGray;
            thSettings.TabClickedBackColor = Color.DarkGray;
            thSettings.TabDividerColor = Color.Gray;
            thSettings.TabHoverBackColor = Color.LightGray;
            thSettings.TabIndex = 0;
            thSettings.TabRuleColor = Color.LightGray;
            thSettings.TabSelectedBackColor = Color.LightGray;
            thSettings.TabSelectedBorderColor = Color.DimGray;
            thSettings.TabSelectedForeColor = Color.Black;
            thSettings.TabSelectedShadowColor = Color.Black;
            thSettings.TabStyle = ODModules.TabHeader.TabStyles.Underlined;
            thSettings.UseBindingTabControl = true;
            thSettings.Load += thSettings_Load;
            // 
            // tcPages
            // 
            tcPages.Controls.Add(tabPage1);
            tcPages.Controls.Add(tabPage2);
            tcPages.DebugMode = true;
            tcPages.DefaultColor1 = Color.DodgerBlue;
            tcPages.Dock = DockStyle.Fill;
            tcPages.DrawMode = TabDrawMode.OwnerDrawFixed;
            tcPages.ForeColor = Color.White;
            tcPages.ItemSize = new Size(20, 20);
            tcPages.Location = new Point(0, 23);
            tcPages.Margin = new Padding(0);
            tcPages.Multiline = true;
            tcPages.Name = "tcPages";
            tcPages.SelectedIndex = 0;
            tcPages.Size = new Size(289, 173);
            tcPages.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(cwMain);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(lcsBrightness);
            tabPage1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(2, 1, 2, 1);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2, 1, 2, 1);
            tabPage1.Size = new Size(281, 145);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Appearance";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // cwMain
            // 
            cwMain.Alpha = 1D;
            cwMain.Dock = DockStyle.Fill;
            cwMain.Location = new Point(128, 1);
            cwMain.Name = "cwMain";
            cwMain.ShowSaturationRing = true;
            cwMain.Size = new Size(126, 143);
            cwMain.TabIndex = 0;
            cwMain.ColorChanged += cwMain_ColorChanged;
            cwMain.LightnessChanged += cwMain_LightnessChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbxBack);
            panel1.Controls.Add(cbxFore);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnFore);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(2, 1);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(126, 143);
            panel1.TabIndex = 1;
            // 
            // cbxBack
            // 
            cbxBack.AutoSize = true;
            cbxBack.ForeColor = Color.Black;
            cbxBack.Location = new Point(13, 75);
            cbxBack.Name = "cbxBack";
            cbxBack.Size = new Size(105, 19);
            cbxBack.TabIndex = 5;
            cbxBack.Text = "Use Back Color";
            cbxBack.UseVisualStyleBackColor = true;
            // 
            // cbxFore
            // 
            cbxFore.AutoSize = true;
            cbxFore.ForeColor = Color.Black;
            cbxFore.Location = new Point(13, 26);
            cbxFore.Name = "cbxFore";
            cbxFore.Size = new Size(101, 19);
            cbxFore.TabIndex = 4;
            cbxFore.Text = "Use Text Color";
            cbxFore.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(43, 100);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 3;
            label2.Text = "Back Color";
            // 
            // btnBack
            // 
            btnBack.AllowGroupUnchecking = false;
            btnBack.BackColorCheckedNorth = Color.Orange;
            btnBack.BackColorCheckedSouth = Color.Orange;
            btnBack.BackColorDownNorth = Color.DimGray;
            btnBack.BackColorDownSouth = Color.DimGray;
            btnBack.BackColorHoverNorth = Color.SkyBlue;
            btnBack.BackColorHoverSouth = Color.SkyBlue;
            btnBack.BackColorNorth = Color.White;
            btnBack.BackColorSouth = Color.White;
            btnBack.BorderColorCheckedNorth = Color.Black;
            btnBack.BorderColorCheckedSouth = Color.Black;
            btnBack.BorderColorDownNorth = Color.Black;
            btnBack.BorderColorDownSouth = Color.Black;
            btnBack.BorderColorHoverNorth = Color.Black;
            btnBack.BorderColorHoverSouth = Color.Black;
            btnBack.BorderColorNorth = Color.Black;
            btnBack.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            btnBack.BorderColorSouth = Color.Black;
            btnBack.BorderRadius = 5;
            btnBack.Checked = false;
            btnBack.GroupMaximumChecked = 2;
            btnBack.Location = new Point(13, 100);
            btnBack.Name = "btnBack";
            btnBack.RadioButtonGroup = "";
            btnBack.SecondaryFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnBack.SecondaryText = "";
            btnBack.Size = new Size(24, 15);
            btnBack.Style = ODModules.ButtonStyle.Square;
            btnBack.TabIndex = 2;
            btnBack.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnBack.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnBack.Type = ODModules.ButtonType.Button;
            btnBack.ButtonClicked += btnBack_ButtonClicked;
            btnBack.Load += btnBack_Load;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(43, 48);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 1;
            label1.Text = "Text Color";
            // 
            // btnFore
            // 
            btnFore.AllowGroupUnchecking = false;
            btnFore.BackColorCheckedNorth = Color.Orange;
            btnFore.BackColorCheckedSouth = Color.Orange;
            btnFore.BackColorDownNorth = Color.DimGray;
            btnFore.BackColorDownSouth = Color.DimGray;
            btnFore.BackColorHoverNorth = Color.SkyBlue;
            btnFore.BackColorHoverSouth = Color.SkyBlue;
            btnFore.BackColorNorth = Color.Black;
            btnFore.BackColorSouth = Color.Black;
            btnFore.BorderColorCheckedNorth = Color.Black;
            btnFore.BorderColorCheckedSouth = Color.Black;
            btnFore.BorderColorDownNorth = Color.Black;
            btnFore.BorderColorDownSouth = Color.Black;
            btnFore.BorderColorHoverNorth = Color.Black;
            btnFore.BorderColorHoverSouth = Color.Black;
            btnFore.BorderColorNorth = Color.Black;
            btnFore.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            btnFore.BorderColorSouth = Color.Black;
            btnFore.BorderRadius = 5;
            btnFore.Checked = false;
            btnFore.GroupMaximumChecked = 2;
            btnFore.Location = new Point(13, 48);
            btnFore.Name = "btnFore";
            btnFore.RadioButtonGroup = "";
            btnFore.SecondaryFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnFore.SecondaryText = "";
            btnFore.Size = new Size(24, 15);
            btnFore.Style = ODModules.ButtonStyle.Square;
            btnFore.TabIndex = 0;
            btnFore.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            btnFore.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            btnFore.Type = ODModules.ButtonType.Button;
            btnFore.ButtonClicked += btnFore_ButtonClicked;
            btnFore.Load += btnFore_Load;
            // 
            // lcsBrightness
            // 
            lcsBrightness.Dock = DockStyle.Right;
            lcsBrightness.Location = new Point(254, 1);
            lcsBrightness.Name = "lcsBrightness";
            lcsBrightness.Orientation = Orientation.Vertical;
            lcsBrightness.Size = new Size(25, 143);
            lcsBrightness.TabIndex = 6;
            lcsBrightness.ValueChanged += lcsBrightness_ValueChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(psMainScaler);
            tabPage2.Controls.Add(ntbTemplate);
            tabPage2.Controls.Add(lblpnlUnit);
            tabPage2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Margin = new Padding(5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(5);
            tabPage2.Size = new Size(281, 145);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Units";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // psMainScaler
            // 
            psMainScaler.Dock = DockStyle.Fill;
            psMainScaler.DownColor = Color.FromArgb(255, 128, 0);
            psMainScaler.HoverColor = Color.FromArgb(255, 255, 192);
            psMainScaler.InactiveForecolor = Color.Gray;
            psMainScaler.LinkedNumericControl = ntbTemplate;
            psMainScaler.Location = new Point(5, 28);
            psMainScaler.Margin = new Padding(2, 1, 2, 1);
            psMainScaler.Name = "psMainScaler";
            psMainScaler.Size = new Size(271, 112);
            psMainScaler.TabIndex = 0;
            // 
            // ntbTemplate
            // 
            ntbTemplate.AllowClipboard = true;
            ntbTemplate.AllowDragValueChange = true;
            ntbTemplate.AllowFractionals = true;
            ntbTemplate.AllowMouseWheel = true;
            ntbTemplate.AllowNegatives = true;
            ntbTemplate.AllowNumberEntry = true;
            ntbTemplate.AllowTyping = true;
            ntbTemplate.ArrowKeysControlNumber = true;
            ntbTemplate.AutoSizeToText = false;
            ntbTemplate.Base = ODModules.NumericTextbox.NumberBase.Base10;
            ntbTemplate.BorderColor = Color.DimGray;
            ntbTemplate.ButtonDownColor = Color.Gray;
            ntbTemplate.ButtonHoverColor = Color.LightGray;
            ntbTemplate.FixedNumericPadding = 5;
            ntbTemplate.FormatOutput = true;
            ntbTemplate.HasUnit = true;
            ntbTemplate.IsMetric = true;
            ntbTemplate.IsSecondaryMetric = false;
            ntbTemplate.LabelFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ntbTemplate.LabelForeColor = Color.Gray;
            ntbTemplate.LabelText = "";
            ntbTemplate.Location = new Point(194, 15);
            ntbTemplate.Margin = new Padding(2, 1, 2, 1);
            ntbTemplate.Marked = false;
            ntbTemplate.MarkedBackColor = Color.Empty;
            ntbTemplate.MarkedBorderColor = Color.Beige;
            numericalString3.DisplayValue = "100";
            numericalString3.Value = "100";
            ntbTemplate.Maximum = numericalString3;
            numericalString4.DisplayValue = "0";
            numericalString4.Value = "0";
            ntbTemplate.Minimum = numericalString4;
            ntbTemplate.Name = "ntbTemplate";
            ntbTemplate.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Right;
            ntbTemplate.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            ntbTemplate.NumericalLeftRadixDigitsMaximum = 7;
            ntbTemplate.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            ntbTemplate.RangeLimited = false;
            ntbTemplate.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            ntbTemplate.SecondaryTag = null;
            ntbTemplate.SecondaryUnit = "";
            ntbTemplate.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            ntbTemplate.SelectedBackColor = Color.Empty;
            ntbTemplate.SelectedBorderColor = Color.Beige;
            ntbTemplate.ShowLabel = false;
            ntbTemplate.Size = new Size(101, 45);
            ntbTemplate.TabIndex = 1;
            ntbTemplate.Unit = "";
            ntbTemplate.UseFixedNumericPadding = true;
            ntbTemplate.Value = "0";
            ntbTemplate.Visible = false;
            // 
            // lblpnlUnit
            // 
            lblpnlUnit.ArrowColor = Color.Black;
            lblpnlUnit.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlUnit.AutoSize = true;
            lblpnlUnit.CloseColor = Color.Black;
            lblpnlUnit.CloseMouseOverColor = Color.Red;
            lblpnlUnit.Collapsed = false;
            lblpnlUnit.Controls.Add(tbUnit);
            lblpnlUnit.Dock = DockStyle.Top;
            lblpnlUnit.DropShadow = false;
            lblpnlUnit.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlUnit.FixedInlineWidth = true;
            lblpnlUnit.Inlinelabel = true;
            lblpnlUnit.InlineWidth = 100;
            lblpnlUnit.LabelBackColor = Color.White;
            lblpnlUnit.LabelFont = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            lblpnlUnit.LabelForeColor = Color.Black;
            lblpnlUnit.Location = new Point(5, 5);
            lblpnlUnit.Margin = new Padding(2, 1, 2, 1);
            lblpnlUnit.Name = "lblpnlUnit";
            lblpnlUnit.OverrideCollapseControl = false;
            lblpnlUnit.Padding = new Padding(113, 0, 0, 0);
            lblpnlUnit.PanelCollapsible = false;
            lblpnlUnit.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlUnit.ShowCloseButton = false;
            lblpnlUnit.Size = new Size(271, 23);
            lblpnlUnit.TabIndex = 3;
            lblpnlUnit.Text = "Unit";
            // 
            // tbUnit
            // 
            tbUnit.AutoCompleteMode = AutoCompleteMode.None;
            tbUnit.AutoCompleteSource = AutoCompleteSource.None;
            tbUnit.BackColor = SystemColors.Window;
            tbUnit.BorderColor = Color.MediumSlateBlue;
            tbUnit.BorderSize = 1;
            tbUnit.Dock = DockStyle.Top;
            tbUnit.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            tbUnit.ForeColor = Color.DimGray;
            tbUnit.Location = new Point(113, 0);
            tbUnit.Margin = new Padding(2);
            tbUnit.MaxLength = 15;
            tbUnit.Multiline = false;
            tbUnit.Name = "tbUnit";
            tbUnit.Padding = new Padding(4, 3, 4, 3);
            tbUnit.PasswordChar = '\0';
            tbUnit.PlaceholderText = "";
            tbUnit.ReadOnly = false;
            tbUnit.SelectedBackColor = Color.LightGray;
            tbUnit.SelectedBorderColor = Color.HotPink;
            tbUnit.ShortcutsEnabled = true;
            tbUnit.Size = new Size(158, 23);
            tbUnit.TabIndex = 2;
            tbUnit.TextAlign = HorizontalAlignment.Left;
            tbUnit.UnderlinedStyle = false;
            tbUnit.UseSystemPasswordChar = false;
            tbUnit.WordWrap = true;
            tbUnit.TextChanged += textBox1__TextChanged;
            // 
            // AppearancePopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tcPages);
            Controls.Add(thSettings);
            Margin = new Padding(2, 1, 2, 1);
            Name = "AppearancePopup";
            Size = new Size(289, 196);
            tcPages.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            lblpnlUnit.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ODModules.TabHeader thSettings;
        private ODModules.HiddenTabControl tcPages;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ODModules.PrefixScale psMainScaler;
        private ODModules.NumericTextbox ntbTemplate;
        private ODModules.TextBox tbUnit;
        private ODModules.LabelPanel lblpnlUnit;
        private ODModules.ColorWheel cwMain;
        private Panel panel1;
        private CheckBox cbxBack;
        private CheckBox cbxFore;
        private Label label2;
        private ODModules.Button btnBack;
        private Label label1;
        private ODModules.Button btnFore;
        private ODModules.LightnessColorSlider lcsBrightness;
    }
}
