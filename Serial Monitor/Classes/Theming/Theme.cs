using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Theming {
    public class Theme {
        #region Properties
        private Color shadowColor = Color.Black;
        public Color ShadowColor {
            get { return shadowColor; }
            set { shadowColor = value; }
        }
        private Color menuBackColor = Color.FromArgb(31, 31, 31);
        public Color MenuBackColor {
            get { return menuBackColor; }
            set { menuBackColor = value; }
        }
        private Color buttonSelectedColor = Color.FromArgb(64, 64, 64);
        public Color ButtonSelectedColor {
            get { return buttonSelectedColor; }
            set { buttonSelectedColor = value; }
        }
        private Color buttonCheckedColor = Color.FromArgb(70, 70, 70);
        public Color ButtonCheckedColor {
            get { return buttonCheckedColor; }
            set { buttonCheckedColor = value; }
        }
        private Color editorColor = Color.FromArgb(16, 16, 16);
        public Color EditorColor {
            get { return editorColor; }
            set { editorColor = value; }
        }
        private Color foreColor = Color.White;
        public Color ForeColor {
            get { return foreColor; }
            set { foreColor = value; }
        }
        private Color secondaryForeColor = Color.Silver;
        public Color SecondaryForeColor {
            get { return secondaryForeColor; }
            set { secondaryForeColor = value; }
        }
        private Color mouseOverForeColor = Color.LightGray;
        public Color MouseOverForeColor {
            get { return mouseOverForeColor; }
            set { mouseOverForeColor = value; }
        }
        private Color mouseDownForeColor = Color.DimGray;
        public Color MouseDownForeColor {
            get { return mouseDownForeColor; }
            set { mouseDownForeColor = value; }
        }
        private Color borderColor = Color.DimGray;
        public Color BorderColor {
            get { return borderColor; }
            set { borderColor = value; }
        }
        private Color seperatorColor = Color.FromArgb(55, 55, 55);
        public Color SeperatorColor {
            get { return seperatorColor; }
            set { seperatorColor = value; }
        }
        private Color selectedColor = Color.SteelBlue;
        public Color SelectedColor {
            get { return selectedColor; }
            set { selectedColor = value; }
        }
        private Color scrollColor = Color.FromArgb(64, 64, 64);
        public Color ScrollColor {
            get { return scrollColor; }
            set { scrollColor = value; }
        }
        private Color symbolColor = Color.DarkGray;
        public Color SymbolColor {
            get { return symbolColor; }
            set { symbolColor = value; }
        }
        private Color stopColor = Color.DarkGray;
        public Color StopColor {
            get { return stopColor; }
            set { stopColor = value; }
        }
        private Color seconaryBackColor = Color.FromArgb(40, 40, 40);
        public Color SeconaryBackColor {
            get { return seconaryBackColor; }
            set { seconaryBackColor = value; }
        }
        private Color terminalForeColor = Color.FromArgb(255, 255, 192);
        public Color TerminalForeColor {
            get { return terminalForeColor; }
            set { terminalForeColor = value; }
        }
        private Color columnSeperatorColor = Color.FromArgb(64, 64, 64);
        public Color ColumnSeperatorColor {
            get { return columnSeperatorColor; }
            set { columnSeperatorColor = value; }
        }
        private Color rowColor = Color.FromArgb(23, 23, 23);
        public Color RowColor {
            get { return rowColor; }
            set { rowColor = value; }
        }
        private Color gridLineColor = Color.FromArgb(30, 30, 30);
        public Color GridLineColor {
            get { return gridLineColor; }
            set { gridLineColor = value; }
        }
        private Color tabSelectedBorderColor = Color.FromArgb(100, 128, 128, 128);
        public Color TabSelectedBorderColor {
            get { return tabSelectedBorderColor; }
            set { tabSelectedBorderColor = value; }
        }
        private Color itemInactiveColor = Color.FromArgb(100, 128, 128, 128);
        public Color ItemInactiveColor {
            get { return itemInactiveColor; }
            set { itemInactiveColor = value; }
        }
        private Color tabSelectedColor = Color.FromArgb(100, 128, 128, 128);
        public Color TabSelectedColor{
            get { return tabSelectedColor; }
            set { tabSelectedColor = value; }
        }
        private Color tabSelectedForeColor = Color.White;
        public Color TabSelectedForeColor {
            get { return tabSelectedForeColor; }
            set { tabSelectedForeColor = value; }
        }
        private Color matchColor = Color.FromArgb(0, 64, 0);
        public Color MatchColor {
            get { return matchColor; }
            set { matchColor = value; }
        }
        private Color mismatchedColor = Color.FromArgb(64, 0, 0);
        public Color MismatchedColor {
            get { return mismatchedColor; }
            set { mismatchedColor = value; }
        }
        private Color syntaxHighlightComments = Color.FromArgb(78, 162, 68);
        public Color SyntaxHighlightComments {
            get { return syntaxHighlightComments; }
            set { syntaxHighlightComments = value; }
        }
        private Color syntaxHighlightControlFlow = Color.FromArgb(78, 156, 206);
        public Color SyntaxHighlightControlFlow {
            get { return syntaxHighlightControlFlow; }
            set { syntaxHighlightControlFlow = value; }
        }
        private Color syntaxHighlightCalls = Color.FromArgb(187, 155, 211);
        public Color SyntaxHighlightCalls {
            get { return syntaxHighlightCalls; }
            set { syntaxHighlightCalls = value; }
        }
        private Color syntaxHighlightDeclarations = Color.FromArgb(156, 220, 254);
        public Color SyntaxHighlightDeclarations {
            get { return syntaxHighlightDeclarations; }
            set { syntaxHighlightDeclarations = value; }
        }
        private Color syntaxxHighlightFunctions = Color.FromArgb(156, 220, 254);
        public Color SyntaxHighlightFunctions {
            get { return syntaxxHighlightFunctions; }
            set { syntaxxHighlightFunctions = value; }
        }

        private bool isDarkTheme = true;
        public bool IsDarkTheme {
            get { return isDarkTheme; }
            set { isDarkTheme = value; }
        }
        private string name = "";
        public string Name {
            get { return name; }
            set { name = value; }
        }
        #endregion
        public void Apply() {
            Properties.Settings.Default.THM_COL_SelectedShadowColor = shadowColor;
            Properties.Settings.Default.THM_COL_MenuBack = menuBackColor;
            Properties.Settings.Default.THM_COL_ButtonSelected = buttonSelectedColor;
            Properties.Settings.Default.THM_COL_ButtonChecked = buttonCheckedColor;
            Properties.Settings.Default.THM_COL_Editor = editorColor;
            Properties.Settings.Default.THM_COL_ForeColor = foreColor;
            Properties.Settings.Default.THM_COL_SecondaryForeColor = secondaryForeColor;
            Properties.Settings.Default.THM_COL_BorderColor = borderColor;
            Properties.Settings.Default.THM_COL_SeperatorColor = seperatorColor;
            Properties.Settings.Default.THM_COL_SelectedColor = selectedColor;
            Properties.Settings.Default.THM_COL_ScrollColor = scrollColor;
            Properties.Settings.Default.THM_COL_SymbolColor = symbolColor;
            Properties.Settings.Default.THM_COL_StopColor = stopColor;
            Properties.Settings.Default.THM_COL_SeconaryBackColor = seconaryBackColor;
            Properties.Settings.Default.THM_COL_TerminalForeColor = terminalForeColor;

            Properties.Settings.Default.THM_COL_ColumnSeperatorColor = columnSeperatorColor;

            Properties.Settings.Default.THM_COL_RowColor = rowColor;
            Properties.Settings.Default.THM_COL_GridLineColor = gridLineColor;

            Properties.Settings.Default.THM_COL_TabSelectedBorderColor = tabSelectedBorderColor;
            Properties.Settings.Default.THM_COL_TabSelectedColor = tabSelectedColor;
            Properties.Settings.Default.THM_COL_TabSelectedForeColor = tabSelectedForeColor;

            Properties.Settings.Default.THM_COL_Match = matchColor; 
            Properties.Settings.Default.THM_COL_Mismatched = mismatchedColor;

            Properties.Settings.Default.THM_COL_MouseDownForeColor = mouseDownForeColor;
            Properties.Settings.Default.THM_COL_MouseOverForeColor = mouseOverForeColor;

            Properties.Settings.Default.THM_COL_CommentColor = syntaxHighlightComments;
            Properties.Settings.Default.THM_COL_ReturnsAndCalls = syntaxHighlightCalls;
            Properties.Settings.Default.THM_COL_VariablesColor = syntaxHighlightDeclarations;
            Properties.Settings.Default.THM_COL_KeyWordColor= syntaxHighlightControlFlow;
            Properties.Settings.Default.THM_COL_Function = syntaxxHighlightFunctions;

            Properties.Settings.Default.THM_COL_ItemInactiveForeColor = itemInactiveColor;

          Properties.Settings.Default.THM_SET_IsDark = isDarkTheme;
            Classes.ApplicationManager.ReapplyThemeToAll();
            Properties.Settings.Default.Save();
        }
    }
}
