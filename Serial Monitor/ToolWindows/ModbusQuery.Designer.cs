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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModbusQuery));
            fctxtEditor = new FastColoredTextBoxNS.FastColoredTextBox();
            lblpnlResults = new ODModules.LabelPanel();
            dmapEditor = new FastColoredTextBoxNS.DocumentMap();
            ((System.ComponentModel.ISupportInitialize)fctxtEditor).BeginInit();
            SuspendLayout();
            // 
            // fctxtEditor
            // 
            fctxtEditor.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            fctxtEditor.AutoIndentCharsPatterns = "^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:]*(?<range>:)\\s*(?<range>[^;]+);";
            fctxtEditor.AutoScrollMinSize = new Size(27, 14);
            fctxtEditor.BackBrush = null;
            fctxtEditor.CharHeight = 14;
            fctxtEditor.CharWidth = 8;
            fctxtEditor.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fctxtEditor.Dock = DockStyle.Fill;
            fctxtEditor.Font = new Font("Courier New", 9.75F);
            fctxtEditor.Hotkeys = resources.GetString("fctxtEditor.Hotkeys");
            fctxtEditor.IsReplaceMode = false;
            fctxtEditor.Location = new Point(5, 18);
            fctxtEditor.Margin = new Padding(2, 1, 2, 1);
            fctxtEditor.Name = "fctxtEditor";
            fctxtEditor.Paddings = new Padding(0);
            fctxtEditor.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            fctxtEditor.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("fctxtEditor.ServiceColors");
            fctxtEditor.ShowScrollBars = false;
            fctxtEditor.Size = new Size(310, 202);
            fctxtEditor.TabIndex = 0;
            fctxtEditor.Zoom = 100;
            // 
            // lblpnlResults
            // 
            lblpnlResults.ArrowColor = Color.Black;
            lblpnlResults.ArrowMouseOverColor = Color.DodgerBlue;
            lblpnlResults.CloseColor = Color.Black;
            lblpnlResults.CloseMouseOverColor = Color.Red;
            lblpnlResults.Collapsed = false;
            lblpnlResults.Dock = DockStyle.Bottom;
            lblpnlResults.DropShadow = false;
            lblpnlResults.DropShadowColor = Color.FromArgb(128, 0, 0, 0);
            lblpnlResults.FixedInlineWidth = false;
            lblpnlResults.Inlinelabel = false;
            lblpnlResults.InlineWidth = 100;
            lblpnlResults.LabelBackColor = Color.White;
            lblpnlResults.LabelFont = new Font("Segoe UI", 8F);
            lblpnlResults.LabelForeColor = Color.Black;
            lblpnlResults.Location = new Point(5, 220);
            lblpnlResults.Margin = new Padding(2, 1, 2, 1);
            lblpnlResults.Name = "lblpnlResults";
            lblpnlResults.OverrideCollapseControl = false;
            lblpnlResults.Padding = new Padding(0, 18, 0, 0);
            lblpnlResults.PanelCollapsible = true;
            lblpnlResults.ResizeControl = ODModules.LabelPanel.ResizeDirection.None;
            lblpnlResults.ShowCloseButton = true;
            lblpnlResults.Size = new Size(417, 161);
            lblpnlResults.TabIndex = 1;
            lblpnlResults.Text = "Results";
            // 
            // dmapEditor
            // 
            dmapEditor.Dock = DockStyle.Right;
            dmapEditor.ForeColor = Color.Maroon;
            dmapEditor.Location = new Point(315, 18);
            dmapEditor.Margin = new Padding(2, 1, 2, 1);
            dmapEditor.Name = "dmapEditor";
            dmapEditor.Size = new Size(107, 202);
            dmapEditor.TabIndex = 2;
            dmapEditor.Target = fctxtEditor;
            dmapEditor.Text = "documentMap1";
            // 
            // ModbusQuery
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(427, 386);
            Controls.Add(fctxtEditor);
            Controls.Add(dmapEditor);
            Controls.Add(lblpnlResults);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2, 1, 2, 1);
            Name = "ModbusQuery";
            Padding = new Padding(5, 18, 5, 5);
            Text = "Modbus Query";
            ((System.ComponentModel.ISupportInitialize)fctxtEditor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctxtEditor;
        private ODModules.LabelPanel lblpnlResults;
        private FastColoredTextBoxNS.DocumentMap dmapEditor;
    }
}