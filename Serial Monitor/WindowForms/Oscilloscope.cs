using Serial_Monitor.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Serial_Monitor.WindowForms {
    public partial class Oscilloscope : Form, Interfaces.ITheme {
        const int MaxItems = 1000;
        public Oscilloscope() {
            InitializeComponent();
        }
        public void ApplyTheme() {
            RecolorAll();
            AddIcons();
        }
        private void Oscilloscope_Load(object sender, EventArgs e) {
            ApplyTheme();
            chartPlotter.Series.Clear();
           chartPlotter.ChartAreas[0].AxisX.CustomLabels.Clear();

            chartPlotter.ChartAreas[0].AxisX.LabelStyle.Format = "m.ss.fff";
            //  chartPlotter.ChartAreas.Clear();
            tmrUpdater.Enabled = true;
            InitaliseDataSet();
        }
        private void InitaliseDataSet() {
            DateTime MarkedNow = DateTime.UtcNow;
            Series DataSet = new Series();
            DataSet.XValueType = ChartValueType.Time;
           DataSet.ChartType = SeriesChartType.Line;
            DataSet.MarkerColor = Color.Red;
            // DataSet.ChartArea = 
            for (int i = MaxItems; i > 0; i--) {
                DateTime CurrentDate = MarkedNow.AddMilliseconds(i);
                DataSet.Points.AddXY(CurrentDate, 0.0m);
            }
            chartPlotter.Series.Add(DataSet);
        }
        private void AddIcons() {
            DesignerSetup.LinkSVGtoControl(Properties.Resources.ClearWindowContent, btnMenuClearTerminal, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.ClearWindowContent, btnClearTerminal, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.BringForward, btnTopMost, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, btnStartLogging, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.Run_16x, btnStartLog, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, btnStopLog, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.Stop_16x, btnStopLogging, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.Save_16x, btnSaveLog, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
            //DesignerSetup.LinkSVGtoControl(Properties.Resources.OpenFile_16x, btnOpenLog, DesignerSetup.GetSize(DesignerSetup.IconSize.Small));
        }
        private void RecolorAll() {
            this.SuspendLayout();
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            chartPlotter.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            chartPlotter.BackColor = Properties.Settings.Default.THM_COL_Editor;
            foreach(ChartArea ChartAr in chartPlotter.ChartAreas) {
                ChartAr.BackColor = Properties.Settings.Default.THM_COL_Editor;
              
                foreach (Axis Ax in ChartAr.Axes) {
                    Ax.LineColor = Properties.Settings.Default.THM_COL_SeperatorColor;
                    Ax.MajorGrid.LineColor = Properties.Settings.Default.THM_COL_SeperatorColor;
                    Ax.MinorGrid.LineColor = Properties.Settings.Default.THM_COL_SeperatorColor;
                    Ax.MinorTickMark.LineColor = Properties.Settings.Default.THM_COL_SeperatorColor;
                    Ax.MajorTickMark.LineColor = Properties.Settings.Default.THM_COL_SeperatorColor;
                    Ax.LabelStyle.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                    Ax.TitleForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                }
            }
           // chartPlotter. = Properties.Settings.Default.THM_COL_Editor;
          
            //Output.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
            //Output.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;

            tsMain.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.MenuBackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.MenuBackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            tsMain.ItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            tsMain.ItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            tsMain.StripItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            tsMain.StripItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            tsMain.MenuBorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            tsMain.MenuSeparatorColor = Properties.Settings.Default.THM_COL_SeperatorColor;
            tsMain.MenuSymbolColor = Properties.Settings.Default.THM_COL_SymbolColor;

            tsMain.ItemCheckedBackColorNorth = Properties.Settings.Default.THM_COL_SymbolColor;
            tsMain.ItemCheckedBackColorSouth = Properties.Settings.Default.THM_COL_SymbolColor;

            tsMain.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            tsMain.ItemForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            tsMain.ItemSelectedForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            msMain.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            msMain.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            msMain.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            msMain.MenuBackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            msMain.MenuBackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            msMain.ItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            msMain.ItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            msMain.StripItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            msMain.StripItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            msMain.MenuBorderColor = Properties.Settings.Default.THM_COL_BorderColor;
            msMain.MenuSeparatorColor = Properties.Settings.Default.THM_COL_SeperatorColor;
            msMain.MenuSymbolColor = Properties.Settings.Default.THM_COL_SymbolColor;
            msMain.ItemForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            msMain.ItemSelectedForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            foreach (ToolStripItem Itm in tsMain.Items) {
                Itm.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            }
            this.ResumeLayout();
        }
        private void Oscilloscope_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void Oscilloscope_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void Oscilloscope_FormClosed(object sender, FormClosedEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void PushValue(int Index, decimal Value) {
            if (chartPlotter.Series.Count == 0) { return; }
            if ((Index >=0) && (Index < chartPlotter.Series.Count)){
                if (chartPlotter.Series[Index].Points.Count >= MaxItems) {
                    //2 
                    int Overflow = (chartPlotter.Series[Index].Points.Count - MaxItems) + 1;
                    for (int i = Overflow; i >= 0; i--) {
                        chartPlotter.Series[Index].Points.RemoveAt(i);
                    }
                    //chartPlotter.Series[Index].Points.RemoveAt(0);
                    //if (Overflow >= 1) {
                        Debug.Print(DateTime.UtcNow.ToString("m.ss.fff") + " " + Value.ToString() + "  " + chartPlotter.Series[Index].Points.Count.ToString());
                   // }
                }
                chartPlotter.Series[Index].Points.AddXY(DateTime.UtcNow, Value);
            }
        }
        DateTime LastUpdate = DateTime.UtcNow;
        Random Rand = new Random();
        decimal Val = 0;
        private void tmrUpdater_Tick(object sender, EventArgs e) {
         
            if (Handlers.ConversionHandler.DateIntervalDifference(LastUpdate, DateTime.UtcNow, Handlers.ConversionHandler.Interval.Millisecond) >= 10) {
                PushValue(0, Val);
                Val = (decimal)Rand.Next(0, 100) / 50.0m;
            }
        }
    }
}
