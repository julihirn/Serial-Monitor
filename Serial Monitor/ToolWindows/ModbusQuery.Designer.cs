namespace Serial_Monitor.ToolWindows {
    partial class ModbusQuery {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModbusQuery));
            this.fctxtEditor = new FastColoredTextBoxNS.FastColoredTextBox();
            this.lblpnlResults = new ODModules.LabelPanel();
            this.dmapEditor = new FastColoredTextBoxNS.DocumentMap();
            ((System.ComponentModel.ISupportInitialize)(this.fctxtEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // fctxtEditor
            // 
            this.fctxtEditor.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctxtEditor.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*" +
    "(?<range>:)\\s*(?<range>[^;]+);";
            this.fctxtEditor.AutoScrollMinSize = new System.Drawing.Size(43, 29);
            this.fctxtEditor.BackBrush = null;
            this.fctxtEditor.CharHeight = 29;
            this.fctxtEditor.CharWidth = 16;
            this.fctxtEditor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctxtEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctxtEditor.IsReplaceMode = false;
            this.fctxtEditor.Location = new System.Drawing.Point(9, 37);
            this.fctxtEditor.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.fctxtEditor.Name = "fctxtEditor";
            this.fctxtEditor.Paddings = new System.Windows.Forms.Padding(0);
            this.fctxtEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctxtEditor.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctxtEditor.ServiceColors")));
            this.fctxtEditor.ShowScrollBars = false;
            this.fctxtEditor.Size = new System.Drawing.Size(576, 432);
            this.fctxtEditor.TabIndex = 0;
            this.fctxtEditor.Zoom = 100;
            // 
            // lblpnlResults
            // 
            this.lblpnlResults.ArrowColor = System.Drawing.Color.Black;
            this.lblpnlResults.ArrowMouseOverColor = System.Drawing.Color.DodgerBlue;
            this.lblpnlResults.CloseColor = System.Drawing.Color.Black;
            this.lblpnlResults.CloseMouseOverColor = System.Drawing.Color.Red;
            this.lblpnlResults.Collapsed = false;
            this.lblpnlResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblpnlResults.DropShadow = false;
            this.lblpnlResults.DropShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblpnlResults.FixedInlineWidth = false;
            this.lblpnlResults.Inlinelabel = false;
            this.lblpnlResults.InlineWidth = 100;
            this.lblpnlResults.LabelBackColor = System.Drawing.Color.White;
            this.lblpnlResults.LabelFont = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblpnlResults.LabelForeColor = System.Drawing.Color.Black;
            this.lblpnlResults.Location = new System.Drawing.Point(9, 469);
            this.lblpnlResults.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.lblpnlResults.Name = "lblpnlResults";
            this.lblpnlResults.OverrideCollapseControl = false;
            this.lblpnlResults.Padding = new System.Windows.Forms.Padding(0, 37, 0, 0);
            this.lblpnlResults.PanelCollapsible = true;
            this.lblpnlResults.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            this.lblpnlResults.ShowCloseButton = true;
            this.lblpnlResults.Size = new System.Drawing.Size(775, 343);
            this.lblpnlResults.TabIndex = 1;
            this.lblpnlResults.Text = "Results";
            // 
            // dmapEditor
            // 
            this.dmapEditor.Dock = System.Windows.Forms.DockStyle.Right;
            this.dmapEditor.ForeColor = System.Drawing.Color.Maroon;
            this.dmapEditor.Location = new System.Drawing.Point(585, 37);
            this.dmapEditor.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dmapEditor.Name = "dmapEditor";
            this.dmapEditor.Size = new System.Drawing.Size(199, 432);
            this.dmapEditor.TabIndex = 2;
            this.dmapEditor.Target = this.fctxtEditor;
            this.dmapEditor.Text = "documentMap1";
            // 
            // ModbusQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 823);
            this.Controls.Add(this.fctxtEditor);
            this.Controls.Add(this.dmapEditor);
            this.Controls.Add(this.lblpnlResults);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "ModbusQuery";
            this.Padding = new System.Windows.Forms.Padding(9, 37, 9, 11);
            this.Text = "Modbus Query";
            ((System.ComponentModel.ISupportInitialize)(this.fctxtEditor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctxtEditor;
        private ODModules.LabelPanel lblpnlResults;
        private FastColoredTextBoxNS.DocumentMap dmapEditor;
    }
}