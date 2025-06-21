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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            ODModules.GridButton gridButton6 = new ODModules.GridButton();
            ODModules.GridButton gridButton7 = new ODModules.GridButton();
            ODModules.GridButton gridButton8 = new ODModules.GridButton();
            ODModules.GridButton gridButton9 = new ODModules.GridButton();
            ODModules.GridButton gridButton10 = new ODModules.GridButton();
            ODModules.Tab tab8 = new ODModules.Tab();
            ODModules.Tab tab9 = new ODModules.Tab();
            ODModules.Tab tab10 = new ODModules.Tab();
            ODModules.Tab tab11 = new ODModules.Tab();
            ODModules.Tab tab12 = new ODModules.Tab();
            ODModules.Tab tab13 = new ODModules.Tab();
            ODModules.Tab tab14 = new ODModules.Tab();
            navigator1 = new ODModules.Navigator();
            labelPanel1 = new ODModules.LabelPanel();
            valuePainter1 = new ODModules.ValuePainter();
            labelPanel2 = new ODModules.LabelPanel();
            buttonGrid1 = new ODModules.ButtonGrid();
            thPrograms = new ODModules.TabHeader();
            button1 = new Button();
            labelPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // navigator1
            // 
            navigator1.ArrowColor = Color.Black;
            navigator1.ArrowMouseOverColor = Color.DodgerBlue;
            navigator1.BackColor = Color.FromArgb(40, 40, 40);
            navigator1.BorderColor = Color.Gray;
            navigator1.Borders = ODModules.Borders.None;
            navigator1.DisplayStyle = ODModules.Navigator.Style.Left;
            navigator1.DisplayText = "Name";
            navigator1.DividerBorderColor = Color.FromArgb(0, 0, 0);
            navigator1.Dock = DockStyle.Right;
            navigator1.ForeColor = Color.White;
            navigator1.LinkedList = null;
            navigator1.Location = new Point(782, 0);
            navigator1.Margin = new Padding(6, 6, 6, 6);
            navigator1.MidColor = Color.FromArgb(20, 20, 20);
            navigator1.Name = "navigator1";
            navigator1.SelectedColor = Color.FromArgb(60, 0, 0, 0);
            navigator1.SelectedItem = -1;
            navigator1.ShadowColor = Color.FromArgb(40, 0, 0, 0);
            navigator1.ShowAnimations = true;
            navigator1.ShowBorder = true;
            navigator1.ShowStatuses = true;
            navigator1.SideShadowColor = Color.FromArgb(20, 0, 0, 0);
            navigator1.Size = new Size(150, 1111);
            navigator1.Status1 = (ODModules.StatusCondition)resources.GetObject("navigator1.Status1");
            navigator1.Status2 = (ODModules.StatusCondition)resources.GetObject("navigator1.Status2");
            navigator1.Status3 = (ODModules.StatusCondition)resources.GetObject("navigator1.Status3");
            navigator1.StatusData = "Status";
            navigator1.TabIndex = 0;
            // 
            // labelPanel1
            // 
            labelPanel1.ArrowColor = Color.Black;
            labelPanel1.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel1.BackColor = Color.FromArgb(40, 40, 40);
            labelPanel1.CloseColor = Color.Black;
            labelPanel1.CloseMouseOverColor = Color.Red;
            labelPanel1.Collapsed = false;
            labelPanel1.Controls.Add(valuePainter1);
            labelPanel1.Dock = DockStyle.Bottom;
            labelPanel1.DropShadow = false;
            labelPanel1.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel1.FixedInlineWidth = false;
            labelPanel1.Inlinelabel = false;
            labelPanel1.InlineWidth = 100;
            labelPanel1.LabelBackColor = Color.White;
            labelPanel1.LabelFont = new Font("Segoe UI", 8F);
            labelPanel1.LabelForeColor = Color.Black;
            labelPanel1.Location = new Point(0, 800);
            labelPanel1.Margin = new Padding(6, 6, 6, 6);
            labelPanel1.Name = "labelPanel1";
            labelPanel1.OverrideCollapseControl = true;
            labelPanel1.Padding = new Padding(0, 41, 0, 0);
            labelPanel1.PanelCollapsible = true;
            labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.Top;
            labelPanel1.SeparatorColor = Color.Gray;
            labelPanel1.ShowCloseButton = true;
            labelPanel1.ShowSeparator = false;
            labelPanel1.Size = new Size(782, 311);
            labelPanel1.TabIndex = 1;
            labelPanel1.Text = "labelPanel1";
            // 
            // valuePainter1
            // 
            valuePainter1.BorderColor = Color.DimGray;
            valuePainter1.CurrentPaintColor = Color.LimeGreen;
            valuePainter1.CurrentPaintID = "";
            valuePainter1.CurrentPaintTag = null;
            valuePainter1.CurrentValueMarker = true;
            valuePainter1.CurrentValueMarkerColor = Color.Red;
            valuePainter1.Dock = DockStyle.Fill;
            valuePainter1.EventsOpacity = 128;
            valuePainter1.IsActive = true;
            valuePainter1.Location = new Point(0, 41);
            valuePainter1.Margin = new Padding(6, 6, 6, 6);
            valuePainter1.Mode = ODModules.ValuePainter.EditMode.Select;
            valuePainter1.Name = "valuePainter1";
            valuePainter1.PainterSelected = false;
            valuePainter1.SelectColor = SystemColors.Highlight;
            valuePainter1.SelectedBorderColor = Color.Empty;
            valuePainter1.SelectionOpacity = 128;
            valuePainter1.ShowAllPaintedEvents = true;
            valuePainter1.Size = new Size(782, 270);
            valuePainter1.SpanEnd = new decimal(new int[] { 100, 0, 0, 0 });
            valuePainter1.SpanStart = new decimal(new int[] { 0, 0, 0, 0 });
            valuePainter1.TabIndex = 0;
            valuePainter1.UseFocusSelect = true;
            valuePainter1.Value = new decimal(new int[] { 0, 0, 0, 0 });
            valuePainter1.ValueMarkerColor = Color.Gray;
            valuePainter1.ValueMarkerTextColor = Color.DimGray;
            // 
            // labelPanel2
            // 
            labelPanel2.ArrowColor = Color.Black;
            labelPanel2.ArrowMouseOverColor = Color.DodgerBlue;
            labelPanel2.BackColor = Color.FromArgb(255, 192, 192);
            labelPanel2.CloseColor = Color.Black;
            labelPanel2.CloseMouseOverColor = Color.Red;
            labelPanel2.Collapsed = false;
            labelPanel2.DropShadow = false;
            labelPanel2.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            labelPanel2.FixedInlineWidth = false;
            labelPanel2.Inlinelabel = false;
            labelPanel2.InlineWidth = 100;
            labelPanel2.LabelBackColor = Color.White;
            labelPanel2.LabelFont = new Font("Segoe UI", 8F);
            labelPanel2.LabelForeColor = Color.Black;
            labelPanel2.Location = new Point(223, 166);
            labelPanel2.Margin = new Padding(6, 6, 6, 6);
            labelPanel2.Name = "labelPanel2";
            labelPanel2.OverrideCollapseControl = false;
            labelPanel2.Padding = new Padding(0, 41, 0, 0);
            labelPanel2.PanelCollapsible = false;
            labelPanel2.ResizeControl = ODModules.LabelPanel.ResizeDirection.Left;
            labelPanel2.SeparatorColor = Color.Gray;
            labelPanel2.ShowCloseButton = true;
            labelPanel2.ShowSeparator = false;
            labelPanel2.Size = new Size(240, 292);
            labelPanel2.TabIndex = 2;
            labelPanel2.Text = "labelPanel2";
            // 
            // buttonGrid1
            // 
            buttonGrid1.AllowTextWrapping = true;
            buttonGrid1.BackColor = Color.FromArgb(40, 40, 40);
            buttonGrid1.BackColorCheckedNorth = Color.Orange;
            buttonGrid1.BackColorCheckedSouth = Color.Orange;
            buttonGrid1.BackColorDownNorth = Color.DimGray;
            buttonGrid1.BackColorDownSouth = Color.DimGray;
            buttonGrid1.BackColorHoverNorth = Color.SkyBlue;
            buttonGrid1.BackColorHoverSouth = Color.SkyBlue;
            buttonGrid1.BackColorNorth = Color.FromArgb(10, 255, 255, 255);
            buttonGrid1.BackColorSouth = Color.FromArgb(10, 255, 255, 255);
            buttonGrid1.BorderColorCheckedNorth = Color.Black;
            buttonGrid1.BorderColorCheckedSouth = Color.Black;
            buttonGrid1.BorderColorDownNorth = Color.Black;
            buttonGrid1.BorderColorDownSouth = Color.Black;
            buttonGrid1.BorderColorHoverNorth = Color.Black;
            buttonGrid1.BorderColorHoverSouth = Color.Black;
            buttonGrid1.BorderColorNorth = Color.Black;
            buttonGrid1.BorderColorShadow = Color.FromArgb(120, 0, 0, 0);
            buttonGrid1.BorderColorSouth = Color.Black;
            buttonGrid1.BorderRadius = 5;
            buttonGrid1.ButtonPadding = new Padding(5);
            gridButton6.BackColorNorth = Color.Gray;
            gridButton6.BackColorSouth = Color.Gray;
            gridButton6.BorderColorNorth = Color.Black;
            gridButton6.BorderColorSouth = Color.Black;
            gridButton6.Checked = false;
            gridButton6.Command = "";
            gridButton6.Enabled = true;
            gridButton6.Icon = Properties.Resources.SerialMonitor;
            gridButton6.IconInline = true;
            gridButton6.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Left;
            gridButton6.Position = new Point(0, 0);
            gridButton6.RadioButtonGroup = "";
            gridButton6.SecondaryShortCutKeys = Keys.None;
            gridButton6.SecondaryText = "";
            gridButton6.ShortCutKeys = Keys.None;
            gridButton6.Tag = null;
            gridButton6.Text = "Hello World This is a test";
            gridButton6.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Left;
            gridButton6.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            gridButton6.Type = ODModules.ButtonType.Button;
            gridButton6.UseButtonFormatting = false;
            gridButton6.UseCustomColors = false;
            gridButton6.UseKeyCode = false;
            gridButton7.BackColorNorth = Color.Gray;
            gridButton7.BackColorSouth = Color.Gray;
            gridButton7.BorderColorNorth = Color.Black;
            gridButton7.BorderColorSouth = Color.Black;
            gridButton7.Checked = false;
            gridButton7.Command = "";
            gridButton7.Enabled = true;
            gridButton7.Icon = null;
            gridButton7.IconInline = false;
            gridButton7.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton7.Position = new Point(0, 0);
            gridButton7.RadioButtonGroup = "";
            gridButton7.SecondaryShortCutKeys = Keys.None;
            gridButton7.SecondaryText = "";
            gridButton7.ShortCutKeys = Keys.None;
            gridButton7.Tag = null;
            gridButton7.Text = "Test Button";
            gridButton7.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton7.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            gridButton7.Type = ODModules.ButtonType.Button;
            gridButton7.UseButtonFormatting = false;
            gridButton7.UseCustomColors = false;
            gridButton7.UseKeyCode = false;
            gridButton8.BackColorNorth = Color.Gray;
            gridButton8.BackColorSouth = Color.Gray;
            gridButton8.BorderColorNorth = Color.Black;
            gridButton8.BorderColorSouth = Color.Black;
            gridButton8.Checked = false;
            gridButton8.Command = "";
            gridButton8.Enabled = true;
            gridButton8.Icon = null;
            gridButton8.IconInline = false;
            gridButton8.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton8.Position = new Point(0, 0);
            gridButton8.RadioButtonGroup = "";
            gridButton8.SecondaryShortCutKeys = Keys.None;
            gridButton8.SecondaryText = "";
            gridButton8.ShortCutKeys = Keys.None;
            gridButton8.Tag = null;
            gridButton8.Text = "adggdagasg";
            gridButton8.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton8.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            gridButton8.Type = ODModules.ButtonType.Button;
            gridButton8.UseButtonFormatting = false;
            gridButton8.UseCustomColors = false;
            gridButton8.UseKeyCode = false;
            gridButton9.BackColorNorth = Color.Gray;
            gridButton9.BackColorSouth = Color.Gray;
            gridButton9.BorderColorNorth = Color.Black;
            gridButton9.BorderColorSouth = Color.Black;
            gridButton9.Checked = false;
            gridButton9.Command = "";
            gridButton9.Enabled = true;
            gridButton9.Icon = null;
            gridButton9.IconInline = false;
            gridButton9.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton9.Position = new Point(0, 0);
            gridButton9.RadioButtonGroup = "";
            gridButton9.SecondaryShortCutKeys = Keys.None;
            gridButton9.SecondaryText = "";
            gridButton9.ShortCutKeys = Keys.None;
            gridButton9.Tag = null;
            gridButton9.Text = "fdasfsadfg";
            gridButton9.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton9.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            gridButton9.Type = ODModules.ButtonType.Button;
            gridButton9.UseButtonFormatting = false;
            gridButton9.UseCustomColors = false;
            gridButton9.UseKeyCode = false;
            gridButton10.BackColorNorth = Color.Gray;
            gridButton10.BackColorSouth = Color.Gray;
            gridButton10.BorderColorNorth = Color.Black;
            gridButton10.BorderColorSouth = Color.Black;
            gridButton10.Checked = false;
            gridButton10.Command = "";
            gridButton10.Enabled = true;
            gridButton10.Icon = null;
            gridButton10.IconInline = false;
            gridButton10.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton10.Position = new Point(0, 0);
            gridButton10.RadioButtonGroup = "";
            gridButton10.SecondaryShortCutKeys = Keys.None;
            gridButton10.SecondaryText = "";
            gridButton10.ShortCutKeys = Keys.None;
            gridButton10.Tag = null;
            gridButton10.Text = "sdfdsfsfd";
            gridButton10.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton10.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            gridButton10.Type = ODModules.ButtonType.Button;
            gridButton10.UseButtonFormatting = false;
            gridButton10.UseCustomColors = false;
            gridButton10.UseKeyCode = false;
            buttonGrid1.Buttons.Add(gridButton6);
            buttonGrid1.Buttons.Add(gridButton7);
            buttonGrid1.Buttons.Add(gridButton8);
            buttonGrid1.Buttons.Add(gridButton9);
            buttonGrid1.Buttons.Add(gridButton10);
            buttonGrid1.ButtonSize = new Size(100, 100);
            buttonGrid1.CenterButtons = true;
            buttonGrid1.Columns = 3;
            buttonGrid1.Filter = null;
            buttonGrid1.FixedColumns = false;
            buttonGrid1.Font = new Font("Segoe UI", 11.25F);
            buttonGrid1.ForeColor = Color.White;
            buttonGrid1.IconInline = true;
            buttonGrid1.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Left;
            buttonGrid1.ImageSize = new Size(16, 16);
            buttonGrid1.Location = new Point(91, 134);
            buttonGrid1.Margin = new Padding(6, 6, 6, 6);
            buttonGrid1.Name = "buttonGrid1";
            buttonGrid1.Padding = new Padding(19, 21, 19, 21);
            buttonGrid1.ScrollBarMouseDown = Color.FromArgb(64, 0, 0, 0);
            buttonGrid1.ScrollBarNorth = Color.DarkTurquoise;
            buttonGrid1.ScrollBarSouth = Color.DeepSkyBlue;
            buttonGrid1.SecondaryFont = null;
            buttonGrid1.Size = new Size(440, 318);
            buttonGrid1.Style = ODModules.ButtonStyle.Square;
            buttonGrid1.TabIndex = 3;
            buttonGrid1.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Left;
            buttonGrid1.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            buttonGrid1.VerScroll = 0;
            // 
            // thPrograms
            // 
            thPrograms.AddHoverColor = Color.LimeGreen;
            thPrograms.AllowDragReordering = true;
            thPrograms.AllowTabResize = true;
            thPrograms.ArrowColor = Color.DarkGray;
            thPrograms.ArrowDisabledColor = Color.FromArgb(128, 0, 0, 0);
            thPrograms.ArrowHoverColor = Color.SteelBlue;
            thPrograms.BackColor = Color.FromArgb(31, 31, 31);
            thPrograms.BindedTabControl = null;
            thPrograms.BorderColor = Color.Gray;
            thPrograms.Borders = ODModules.Borders.None;
            thPrograms.CloseHoverColor = Color.Brown;
            thPrograms.Dock = DockStyle.Top;
            thPrograms.ForeColor = Color.White;
            thPrograms.HeaderDownForeColor = Color.Gray;
            thPrograms.HeaderForeColor = Color.Black;
            thPrograms.HeaderHoverForeColor = Color.Blue;
            thPrograms.Location = new Point(0, 0);
            thPrograms.Margin = new Padding(6, 6, 6, 6);
            thPrograms.Name = "thPrograms";
            thPrograms.Padding = new Padding(9, 0, 0, 0);
            thPrograms.SelectedIndex = 0;
            thPrograms.ShowAddButton = true;
            thPrograms.ShowHeader = false;
            thPrograms.ShowTabDividers = true;
            thPrograms.ShowTabs = true;
            thPrograms.Size = new Size(782, 55);
            thPrograms.TabBackColor = Color.Transparent;
            thPrograms.TabBorderColor = Color.Transparent;
            thPrograms.TabClickedBackColor = Color.DarkGray;
            thPrograms.TabDividerColor = Color.White;
            thPrograms.TabHoverBackColor = Color.LightGray;
            thPrograms.TabIndex = 4;
            thPrograms.TabRuleColor = Color.FromArgb(100, 128, 128, 128);
            tab8.Selected = true;
            tab8.Tag = null;
            tab8.Text = "Main";
            tab9.Selected = false;
            tab9.Tag = null;
            tab9.Text = "Tab1";
            tab10.Selected = false;
            tab10.Tag = null;
            tab10.Text = "";
            tab11.Selected = false;
            tab11.Tag = null;
            tab11.Text = "";
            tab12.Selected = false;
            tab12.Tag = null;
            tab12.Text = "";
            tab13.Selected = false;
            tab13.Tag = null;
            tab13.Text = "";
            tab14.Selected = false;
            tab14.Tag = null;
            tab14.Text = "";
            thPrograms.Tabs.Add(tab8);
            thPrograms.Tabs.Add(tab9);
            thPrograms.Tabs.Add(tab10);
            thPrograms.Tabs.Add(tab11);
            thPrograms.Tabs.Add(tab12);
            thPrograms.Tabs.Add(tab13);
            thPrograms.Tabs.Add(tab14);
            thPrograms.TabSelectedBackColor = Color.FromArgb(100, 128, 128, 128);
            thPrograms.TabSelectedBorderColor = Color.FromArgb(100, 128, 128, 128);
            thPrograms.TabSelectedForeColor = Color.WhiteSmoke;
            thPrograms.TabSelectedShadowColor = Color.Black;
            thPrograms.TabStyle = ODModules.TabHeader.TabStyles.Normal;
            thPrograms.UseBindingTabControl = false;
            // 
            // button1
            // 
            button1.Location = new Point(563, 296);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 5;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(932, 1111);
            Controls.Add(button1);
            Controls.Add(thPrograms);
            Controls.Add(buttonGrid1);
            Controls.Add(labelPanel2);
            Controls.Add(labelPanel1);
            Controls.Add(navigator1);
            Margin = new Padding(6, 6, 6, 6);
            Name = "Form2";
            Text = "Form2";
            labelPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ODModules.Navigator navigator1;
        private ODModules.LabelPanel labelPanel1;
        private ODModules.LabelPanel labelPanel2;
        private ODModules.ValuePainter valuePainter1;
        private ODModules.ButtonGrid buttonGrid1;
        private ODModules.TabHeader thPrograms;
        private Button button1;
    }
}