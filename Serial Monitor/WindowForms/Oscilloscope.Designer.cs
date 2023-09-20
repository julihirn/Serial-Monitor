namespace Serial_Monitor.WindowForms {
    partial class Oscilloscope {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.CustomLabel customLabel1 = new System.Windows.Forms.DataVisualization.Charting.CustomLabel();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Oscilloscope));
            this.chartPlotter = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.msMain = new ODModules.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuClearTerminal = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom050 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom075 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom110 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom120 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom150 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMenuZoom300 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMenuTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.graphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new ODModules.ToolStrip();
            this.btnClearPlots = new System.Windows.Forms.ToolStripButton();
            this.btnTopMost = new System.Windows.Forms.ToolStripButton();
            this.tmrUpdater = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartPlotter)).BeginInit();
            this.msMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartPlotter
            // 
            this.chartPlotter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.chartPlotter.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.CustomLabels.Add(customLabel1);
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.DarkGray;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Bisque;
            chartArea1.AxisX2.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.Gainsboro;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            chartArea1.BorderColor = System.Drawing.Color.BlanchedAlmond;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowColor = System.Drawing.Color.Gray;
            this.chartPlotter.ChartAreas.Add(chartArea1);
            this.chartPlotter.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartPlotter.Legends.Add(legend1);
            this.chartPlotter.Location = new System.Drawing.Point(0, 49);
            this.chartPlotter.Name = "chartPlotter";
            this.chartPlotter.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.Points.Add(dataPoint1);
            this.chartPlotter.Series.Add(series1);
            this.chartPlotter.Size = new System.Drawing.Size(623, 327);
            this.chartPlotter.SuppressExceptions = true;
            this.chartPlotter.TabIndex = 0;
            this.chartPlotter.Text = "Oscilloscope";
            // 
            // msMain
            // 
            this.msMain.BackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.BackColorNorthFadeIn = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.BackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.ItemForeColor = System.Drawing.Color.White;
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.graphsToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.msMain.ItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.msMain.ItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.msMain.ItemSelectedForeColor = System.Drawing.Color.Black;
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.MenuBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.MenuBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.msMain.MenuBorderColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.MenuSeparatorColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.MenuSymbolColor = System.Drawing.Color.WhiteSmoke;
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(623, 24);
            this.msMain.StripItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.msMain.StripItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.msMain.TabIndex = 4;
            this.msMain.Text = "menuStrip1";
            this.msMain.UseNorthFadeIn = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMenuClearTerminal,
            this.zoomToolStripMenuItem,
            this.toolStripSeparator4,
            this.btnMenuTopMost});
            this.viewToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // btnMenuClearTerminal
            // 
            this.btnMenuClearTerminal.ForeColor = System.Drawing.Color.White;
            this.btnMenuClearTerminal.Name = "btnMenuClearTerminal";
            this.btnMenuClearTerminal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.btnMenuClearTerminal.Size = new System.Drawing.Size(177, 22);
            this.btnMenuClearTerminal.Text = "&Clear Plots";
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMenuZoom050,
            this.btnMenuZoom075,
            this.btnMenuZoom100,
            this.btnMenuZoom110,
            this.btnMenuZoom120,
            this.btnMenuZoom150,
            this.btnMenuZoom200,
            this.btnMenuZoom300});
            this.zoomToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.zoomToolStripMenuItem.Text = "&Zoom";
            // 
            // btnMenuZoom050
            // 
            this.btnMenuZoom050.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom050.Name = "btnMenuZoom050";
            this.btnMenuZoom050.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom050.Text = "50%";
            // 
            // btnMenuZoom075
            // 
            this.btnMenuZoom075.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom075.Name = "btnMenuZoom075";
            this.btnMenuZoom075.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom075.Text = "75%";
            // 
            // btnMenuZoom100
            // 
            this.btnMenuZoom100.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom100.Name = "btnMenuZoom100";
            this.btnMenuZoom100.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom100.Text = "100%";
            // 
            // btnMenuZoom110
            // 
            this.btnMenuZoom110.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom110.Name = "btnMenuZoom110";
            this.btnMenuZoom110.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom110.Text = "110%";
            // 
            // btnMenuZoom120
            // 
            this.btnMenuZoom120.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom120.Name = "btnMenuZoom120";
            this.btnMenuZoom120.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom120.Text = "120%";
            // 
            // btnMenuZoom150
            // 
            this.btnMenuZoom150.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom150.Name = "btnMenuZoom150";
            this.btnMenuZoom150.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom150.Text = "150%";
            // 
            // btnMenuZoom200
            // 
            this.btnMenuZoom200.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom200.Name = "btnMenuZoom200";
            this.btnMenuZoom200.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom200.Text = "200%";
            // 
            // btnMenuZoom300
            // 
            this.btnMenuZoom300.ForeColor = System.Drawing.Color.White;
            this.btnMenuZoom300.Name = "btnMenuZoom300";
            this.btnMenuZoom300.Size = new System.Drawing.Size(102, 22);
            this.btnMenuZoom300.Text = "300%";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(174, 6);
            // 
            // btnMenuTopMost
            // 
            this.btnMenuTopMost.ForeColor = System.Drawing.Color.White;
            this.btnMenuTopMost.Name = "btnMenuTopMost";
            this.btnMenuTopMost.Size = new System.Drawing.Size(177, 22);
            this.btnMenuTopMost.Text = "Top Most";
            // 
            // graphsToolStripMenuItem
            // 
            this.graphsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.graphsToolStripMenuItem.Name = "graphsToolStripMenuItem";
            this.graphsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.graphsToolStripMenuItem.Text = "&Graphs";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.optionsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // tsMain
            // 
            this.tsMain.BackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.BackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.ItemCheckedBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMain.ItemCheckedBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tsMain.ItemForeColor = System.Drawing.Color.White;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClearPlots,
            this.btnTopMost});
            this.tsMain.ItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.tsMain.ItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.tsMain.ItemSelectedForeColor = System.Drawing.Color.Black;
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.MenuBackColorNorth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.MenuBackColorSouth = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tsMain.MenuBorderColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.MenuSeparatorColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.MenuSymbolColor = System.Drawing.Color.WhiteSmoke;
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(623, 25);
            this.tsMain.StripItemSelectedBackColorNorth = System.Drawing.Color.White;
            this.tsMain.StripItemSelectedBackColorSouth = System.Drawing.Color.White;
            this.tsMain.TabIndex = 5;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnClearPlots
            // 
            this.btnClearPlots.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClearPlots.Image = ((System.Drawing.Image)(resources.GetObject("btnClearPlots.Image")));
            this.btnClearPlots.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClearPlots.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearPlots.Name = "btnClearPlots";
            this.btnClearPlots.Size = new System.Drawing.Size(23, 22);
            this.btnClearPlots.Text = "Clear Plots";
            // 
            // btnTopMost
            // 
            this.btnTopMost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTopMost.Image = ((System.Drawing.Image)(resources.GetObject("btnTopMost.Image")));
            this.btnTopMost.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTopMost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTopMost.Name = "btnTopMost";
            this.btnTopMost.Size = new System.Drawing.Size(23, 22);
            this.btnTopMost.Text = "Window Top Most";
            // 
            // tmrUpdater
            // 
            this.tmrUpdater.Interval = 1;
            this.tmrUpdater.Tick += new System.EventHandler(this.tmrUpdater_Tick);
            // 
            // Oscilloscope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 376);
            this.Controls.Add(this.chartPlotter);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.msMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Oscilloscope";
            this.Text = "Oscilloscope";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Oscilloscope_FormClosed);
            this.Load += new System.EventHandler(this.Oscilloscope_Load);
            this.SizeChanged += new System.EventHandler(this.Oscilloscope_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.Oscilloscope_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.chartPlotter)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPlotter;
        private ODModules.MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem btnMenuClearTerminal;
        private ToolStripMenuItem zoomToolStripMenuItem;
        private ToolStripMenuItem btnMenuZoom050;
        private ToolStripMenuItem btnMenuZoom075;
        private ToolStripMenuItem btnMenuZoom100;
        private ToolStripMenuItem btnMenuZoom110;
        private ToolStripMenuItem btnMenuZoom120;
        private ToolStripMenuItem btnMenuZoom150;
        private ToolStripMenuItem btnMenuZoom200;
        private ToolStripMenuItem btnMenuZoom300;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem btnMenuTopMost;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem graphsToolStripMenuItem;
        private ODModules.ToolStrip tsMain;
        private ToolStripButton btnClearPlots;
        private ToolStripButton btnTopMost;
        private System.Windows.Forms.Timer tmrUpdater;
    }
}