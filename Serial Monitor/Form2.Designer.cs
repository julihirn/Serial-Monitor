﻿namespace Serial_Monitor {
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
            ODModules.GridButton gridButton1 = new ODModules.GridButton();
            ODModules.GridButton gridButton2 = new ODModules.GridButton();
            ODModules.GridButton gridButton3 = new ODModules.GridButton();
            ODModules.GridButton gridButton4 = new ODModules.GridButton();
            ODModules.GridButton gridButton5 = new ODModules.GridButton();
            ODModules.Tab tab1 = new ODModules.Tab();
            ODModules.Tab tab2 = new ODModules.Tab();
            ODModules.Tab tab3 = new ODModules.Tab();
            ODModules.Tab tab4 = new ODModules.Tab();
            ODModules.Tab tab5 = new ODModules.Tab();
            ODModules.Tab tab6 = new ODModules.Tab();
            ODModules.Tab tab7 = new ODModules.Tab();
            this.navigator1 = new ODModules.Navigator();
            this.labelPanel1 = new ODModules.LabelPanel();
            this.valuePainter1 = new ODModules.ValuePainter();
            this.labelPanel2 = new ODModules.LabelPanel();
            this.buttonGrid1 = new ODModules.ButtonGrid();
            this.thPrograms = new ODModules.TabHeader();
            this.labelPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigator1
            // 
            this.navigator1.ArrowColor = System.Drawing.Color.Black;
            this.navigator1.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.navigator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.navigator1.DisplayStyle = ODModules.Navigator.Style.Left;
            this.navigator1.DisplayText = "Name";
            this.navigator1.Dock = System.Windows.Forms.DockStyle.Right;
            this.navigator1.ForeColor = System.Drawing.Color.White;
            this.navigator1.LinkedList = null;
            this.navigator1.Location = new System.Drawing.Point(421, 0);
            this.navigator1.MidColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.navigator1.Name = "navigator1";
            this.navigator1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navigator1.SelectedItem = -1;
            this.navigator1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navigator1.ShowAnimations = true;
            this.navigator1.SideShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navigator1.Size = new System.Drawing.Size(81, 521);
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
            this.labelPanel1.FixedInlineWidth = false;
            this.labelPanel1.Inlinelabel = false;
            this.labelPanel1.InlineWidth = 100;
            this.labelPanel1.LabelBackColor = System.Drawing.Color.White;
            this.labelPanel1.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPanel1.LabelForeColor = System.Drawing.Color.Black;
            this.labelPanel1.Location = new System.Drawing.Point(0, 375);
            this.labelPanel1.Name = "labelPanel1";
            this.labelPanel1.OverrideCollapseControl = true;
            this.labelPanel1.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.labelPanel1.PanelCollapsible = true;
            this.labelPanel1.ResizeControl = ODModules.LabelPanel.ResizeDirection.Top;
            this.labelPanel1.ShowCloseButton = true;
            this.labelPanel1.Size = new System.Drawing.Size(421, 146);
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
            this.valuePainter1.Size = new System.Drawing.Size(421, 128);
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
            this.labelPanel2.FixedInlineWidth = false;
            this.labelPanel2.Inlinelabel = false;
            this.labelPanel2.InlineWidth = 100;
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
            // buttonGrid1
            // 
            this.buttonGrid1.AllowTextWrapping = true;
            this.buttonGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buttonGrid1.BackColorCheckedNorth = System.Drawing.Color.Orange;
            this.buttonGrid1.BackColorCheckedSouth = System.Drawing.Color.Orange;
            this.buttonGrid1.BackColorDownNorth = System.Drawing.Color.DimGray;
            this.buttonGrid1.BackColorDownSouth = System.Drawing.Color.DimGray;
            this.buttonGrid1.BackColorHoverNorth = System.Drawing.Color.SkyBlue;
            this.buttonGrid1.BackColorHoverSouth = System.Drawing.Color.SkyBlue;
            this.buttonGrid1.BackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonGrid1.BackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonGrid1.BorderColorCheckedNorth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorCheckedSouth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorDownNorth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorDownSouth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorHoverNorth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorHoverSouth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorNorth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderColorShadow = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonGrid1.BorderColorSouth = System.Drawing.Color.Black;
            this.buttonGrid1.BorderRadius = 5;
            this.buttonGrid1.ButtonPadding = new System.Windows.Forms.Padding(5);
            gridButton1.BackColorNorth = System.Drawing.Color.Gray;
            gridButton1.BackColorSouth = System.Drawing.Color.Gray;
            gridButton1.BorderColorNorth = System.Drawing.Color.Black;
            gridButton1.BorderColorSouth = System.Drawing.Color.Black;
            gridButton1.Checked = false;
            gridButton1.Command = "";
            gridButton1.Enabled = true;
            gridButton1.Icon = global::Serial_Monitor.Properties.Resources.SerialMonitor;
            gridButton1.IconInline = true;
            gridButton1.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Left;
            gridButton1.Position = new System.Drawing.Point(0, 0);
            gridButton1.RadioButtonGroup = "";
            gridButton1.SecondaryShortCutKeys = System.Windows.Forms.Keys.None;
            gridButton1.SecondaryText = "";
            gridButton1.ShortCutKeys = System.Windows.Forms.Keys.None;
            gridButton1.Tag = null;
            gridButton1.Text = "Hello World This is a test";
            gridButton1.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Left;
            gridButton1.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            gridButton1.Type = ODModules.ButtonType.Button;
            gridButton1.UseButtonFormatting = false;
            gridButton1.UseCustomColors = false;
            gridButton1.UseKeyCode = false;
            gridButton2.BackColorNorth = System.Drawing.Color.Gray;
            gridButton2.BackColorSouth = System.Drawing.Color.Gray;
            gridButton2.BorderColorNorth = System.Drawing.Color.Black;
            gridButton2.BorderColorSouth = System.Drawing.Color.Black;
            gridButton2.Checked = false;
            gridButton2.Command = "";
            gridButton2.Enabled = true;
            gridButton2.Icon = null;
            gridButton2.IconInline = false;
            gridButton2.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton2.Position = new System.Drawing.Point(0, 0);
            gridButton2.RadioButtonGroup = "";
            gridButton2.SecondaryShortCutKeys = System.Windows.Forms.Keys.None;
            gridButton2.SecondaryText = "";
            gridButton2.ShortCutKeys = System.Windows.Forms.Keys.None;
            gridButton2.Tag = null;
            gridButton2.Text = "Test Button";
            gridButton2.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton2.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            gridButton2.Type = ODModules.ButtonType.Button;
            gridButton2.UseButtonFormatting = false;
            gridButton2.UseCustomColors = false;
            gridButton2.UseKeyCode = false;
            gridButton3.BackColorNorth = System.Drawing.Color.Gray;
            gridButton3.BackColorSouth = System.Drawing.Color.Gray;
            gridButton3.BorderColorNorth = System.Drawing.Color.Black;
            gridButton3.BorderColorSouth = System.Drawing.Color.Black;
            gridButton3.Checked = false;
            gridButton3.Command = "";
            gridButton3.Enabled = true;
            gridButton3.Icon = null;
            gridButton3.IconInline = false;
            gridButton3.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton3.Position = new System.Drawing.Point(0, 0);
            gridButton3.RadioButtonGroup = "";
            gridButton3.SecondaryShortCutKeys = System.Windows.Forms.Keys.None;
            gridButton3.SecondaryText = "";
            gridButton3.ShortCutKeys = System.Windows.Forms.Keys.None;
            gridButton3.Tag = null;
            gridButton3.Text = "adggdagasg";
            gridButton3.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton3.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            gridButton3.Type = ODModules.ButtonType.Button;
            gridButton3.UseButtonFormatting = false;
            gridButton3.UseCustomColors = false;
            gridButton3.UseKeyCode = false;
            gridButton4.BackColorNorth = System.Drawing.Color.Gray;
            gridButton4.BackColorSouth = System.Drawing.Color.Gray;
            gridButton4.BorderColorNorth = System.Drawing.Color.Black;
            gridButton4.BorderColorSouth = System.Drawing.Color.Black;
            gridButton4.Checked = false;
            gridButton4.Command = "";
            gridButton4.Enabled = true;
            gridButton4.Icon = null;
            gridButton4.IconInline = false;
            gridButton4.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton4.Position = new System.Drawing.Point(0, 0);
            gridButton4.RadioButtonGroup = "";
            gridButton4.SecondaryShortCutKeys = System.Windows.Forms.Keys.None;
            gridButton4.SecondaryText = "";
            gridButton4.ShortCutKeys = System.Windows.Forms.Keys.None;
            gridButton4.Tag = null;
            gridButton4.Text = "fdasfsadfg";
            gridButton4.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton4.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            gridButton4.Type = ODModules.ButtonType.Button;
            gridButton4.UseButtonFormatting = false;
            gridButton4.UseCustomColors = false;
            gridButton4.UseKeyCode = false;
            gridButton5.BackColorNorth = System.Drawing.Color.Gray;
            gridButton5.BackColorSouth = System.Drawing.Color.Gray;
            gridButton5.BorderColorNorth = System.Drawing.Color.Black;
            gridButton5.BorderColorSouth = System.Drawing.Color.Black;
            gridButton5.Checked = false;
            gridButton5.Command = "";
            gridButton5.Enabled = true;
            gridButton5.Icon = null;
            gridButton5.IconInline = false;
            gridButton5.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton5.Position = new System.Drawing.Point(0, 0);
            gridButton5.RadioButtonGroup = "";
            gridButton5.SecondaryShortCutKeys = System.Windows.Forms.Keys.None;
            gridButton5.SecondaryText = "";
            gridButton5.ShortCutKeys = System.Windows.Forms.Keys.None;
            gridButton5.Tag = null;
            gridButton5.Text = "sdfdsfsfd";
            gridButton5.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Center;
            gridButton5.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            gridButton5.Type = ODModules.ButtonType.Button;
            gridButton5.UseButtonFormatting = false;
            gridButton5.UseCustomColors = false;
            gridButton5.UseKeyCode = false;
            this.buttonGrid1.Buttons.Add(gridButton1);
            this.buttonGrid1.Buttons.Add(gridButton2);
            this.buttonGrid1.Buttons.Add(gridButton3);
            this.buttonGrid1.Buttons.Add(gridButton4);
            this.buttonGrid1.Buttons.Add(gridButton5);
            this.buttonGrid1.ButtonSize = new System.Drawing.Size(100, 100);
            this.buttonGrid1.CenterButtons = true;
            this.buttonGrid1.Filter = null;
            this.buttonGrid1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGrid1.ForeColor = System.Drawing.Color.White;
            this.buttonGrid1.IconInline = true;
            this.buttonGrid1.ImageHorizontalAlignment = ODModules.ButtonTextHorizontal.Left;
            this.buttonGrid1.ImageSize = new System.Drawing.Size(16, 16);
            this.buttonGrid1.Location = new System.Drawing.Point(49, 63);
            this.buttonGrid1.Name = "buttonGrid1";
            this.buttonGrid1.Padding = new System.Windows.Forms.Padding(10);
            this.buttonGrid1.ScrollBarMouseDown = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonGrid1.ScrollBarNorth = System.Drawing.Color.DarkTurquoise;
            this.buttonGrid1.ScrollBarSouth = System.Drawing.Color.DeepSkyBlue;
            this.buttonGrid1.SecondaryFont = null;
            this.buttonGrid1.Size = new System.Drawing.Size(237, 149);
            this.buttonGrid1.Style = ODModules.ButtonStyle.Square;
            this.buttonGrid1.TabIndex = 3;
            this.buttonGrid1.TextHorizontalAlignment = ODModules.ButtonTextHorizontal.Left;
            this.buttonGrid1.TextVerticalAlignment = ODModules.ButtonTextVertical.Middle;
            this.buttonGrid1.VerScroll = 0;
            // 
            // thPrograms
            // 
            this.thPrograms.AddHoverColor = System.Drawing.Color.LimeGreen;
            this.thPrograms.AllowDragReordering = true;
            this.thPrograms.AllowTabResize = true;
            this.thPrograms.ArrowColor = System.Drawing.Color.DarkGray;
            this.thPrograms.ArrowDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.thPrograms.ArrowHoverColor = System.Drawing.Color.SteelBlue;
            this.thPrograms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.thPrograms.BindedTabControl = null;
            this.thPrograms.CloseHoverColor = System.Drawing.Color.Brown;
            this.thPrograms.Dock = System.Windows.Forms.DockStyle.Top;
            this.thPrograms.ForeColor = System.Drawing.Color.White;
            this.thPrograms.Location = new System.Drawing.Point(0, 0);
            this.thPrograms.Name = "thPrograms";
            this.thPrograms.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.thPrograms.SelectedIndex = 0;
            this.thPrograms.ShowAddButton = true;
            this.thPrograms.ShowTabDividers = true;
            this.thPrograms.Size = new System.Drawing.Size(421, 26);
            this.thPrograms.TabBackColor = System.Drawing.Color.Transparent;
            this.thPrograms.TabBorderColor = System.Drawing.Color.Transparent;
            this.thPrograms.TabClickedBackColor = System.Drawing.Color.DarkGray;
            this.thPrograms.TabDividerColor = System.Drawing.Color.White;
            this.thPrograms.TabHoverBackColor = System.Drawing.Color.LightGray;
            this.thPrograms.TabIndex = 4;
            this.thPrograms.TabRuleColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            tab1.Selected = true;
            tab1.Tag = null;
            tab1.Text = "Main";
            tab2.Selected = false;
            tab2.Tag = null;
            tab2.Text = "Tab1";
            tab3.Selected = false;
            tab3.Tag = null;
            tab3.Text = "";
            tab4.Selected = false;
            tab4.Tag = null;
            tab4.Text = "";
            tab5.Selected = false;
            tab5.Tag = null;
            tab5.Text = "";
            tab6.Selected = false;
            tab6.Tag = null;
            tab6.Text = "";
            tab7.Selected = false;
            tab7.Tag = null;
            tab7.Text = "";
            this.thPrograms.Tabs.Add(tab1);
            this.thPrograms.Tabs.Add(tab2);
            this.thPrograms.Tabs.Add(tab3);
            this.thPrograms.Tabs.Add(tab4);
            this.thPrograms.Tabs.Add(tab5);
            this.thPrograms.Tabs.Add(tab6);
            this.thPrograms.Tabs.Add(tab7);
            this.thPrograms.TabSelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.thPrograms.TabSelectedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.thPrograms.TabSelectedForeColor = System.Drawing.Color.WhiteSmoke;
            this.thPrograms.TabSelectedShadowColor = System.Drawing.Color.Black;
            this.thPrograms.TabStyle = ODModules.TabHeader.TabStyles.Normal;
            this.thPrograms.UseBindingTabControl = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(502, 521);
            this.Controls.Add(this.thPrograms);
            this.Controls.Add(this.buttonGrid1);
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
        private ODModules.ButtonGrid buttonGrid1;
        private ODModules.TabHeader thPrograms;
    }
}