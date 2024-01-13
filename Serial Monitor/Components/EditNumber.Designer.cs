namespace Serial_Monitor.Components {
    partial class EditNumber {
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
            Editor = new ODModules.NumericTextbox();
            SuspendLayout();
            // 
            // Editor
            // 
            Editor.AllowClipboard = true;
            Editor.AllowDragValueChange = true;
            Editor.AllowFractionals = true;
            Editor.AllowMouseWheel = true;
            Editor.AllowNegatives = true;
            Editor.AllowNumberEntry = true;
            Editor.AllowTyping = true;
            Editor.AutoSizeToText = false;
            Editor.Base = ODModules.NumericTextbox.NumberBase.Base10;
            Editor.BorderColor = Color.DimGray;
            Editor.ButtonDownColor = Color.Gray;
            Editor.ButtonHoverColor = Color.LightGray;
            Editor.Dock = DockStyle.Fill;
            Editor.FixedNumericPadding = 0;
            Editor.FormatOutput = true;
            Editor.HasUnit = true;
            Editor.IsMetric = true;
            Editor.IsSecondaryMetric = false;
            Editor.LabelFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Editor.LabelForeColor = Color.Gray;
            Editor.LabelText = "";
            Editor.Location = new Point(4, 1);
            Editor.Marked = false;
            Editor.MarkedBackColor = Color.Empty;
            Editor.MarkedBorderColor = Color.Beige;
            numericalString1.DisplayValue = "100";
            numericalString1.Value = "100";
            Editor.Maximum = numericalString1;
            numericalString2.DisplayValue = "0";
            numericalString2.Value = "0";
            Editor.Minimum = numericalString2;
            Editor.Name = "Editor";
            Editor.NumberTextAlign = ODModules.NumericTextbox.TextAlign.Right;
            Editor.NumericalFormat = ODModules.NumericTextbox.NumberFormat.Decimal;
            Editor.NumericalLeftRadixDigitsMaximum = 7;
            Editor.Prefix = ODModules.NumericTextbox.MetricPrefix.None;
            Editor.RangeLimited = false;
            Editor.SecondaryPrefix = ODModules.NumericTextbox.MetricPrefix.None;
            Editor.SecondaryTag = null;
            Editor.SecondaryUnit = "";
            Editor.SecondaryUnitDisplay = ODModules.NumericTextbox.SecondaryUnitDisplayType.NoSecondaryUnit;
            Editor.SelectedBackColor = Color.Empty;
            Editor.SelectedBorderColor = Color.Beige;
            Editor.ShowLabel = true;
            Editor.Size = new Size(217, 51);
            Editor.TabIndex = 0;
            Editor.Unit = "";
            Editor.UseFixedNumericPadding = false;
            Editor.Value = "0";
            // 
            // EditNumber
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(Editor);
            Name = "EditNumber";
            Padding = new Padding(4, 1, 1, 1);
            Size = new Size(222, 53);
            Load += EditNumber_Load;
            ResumeLayout(false);
        }

        #endregion

        public ODModules.NumericTextbox Editor;
    }
}
