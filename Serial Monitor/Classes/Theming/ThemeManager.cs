using ODModules;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Theming {
    public static class ThemeManager {
        public static List<Theme> Themes = new List<Theme>();
        #region Control Theming
        public static void ThemeControl(object ControlObject) {
            if (ControlObject.GetType() == typeof(ODModules.ToolStrip)) {
                ODModules.ToolStrip Ts = (ODModules.ToolStrip)ControlObject;
                Ts.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
                Ts.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
                Ts.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
                Ts.MenuBackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
                Ts.MenuBackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
                Ts.ItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
                Ts.ItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
                Ts.StripItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
                Ts.StripItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
                Ts.MenuBorderColor = Properties.Settings.Default.THM_COL_BorderColor;
                Ts.MenuSeparatorColor = Properties.Settings.Default.THM_COL_SeperatorColor;
                Ts.MenuSymbolColor = Properties.Settings.Default.THM_COL_SymbolColor;
                Ts.ItemCheckedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonChecked;
                Ts.ItemCheckedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonChecked;
                Ts.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                Ts.ItemForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                Ts.ItemSelectedForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                foreach (object obj in Ts.Items) {
                    if (obj.GetType() == typeof(ToolStripSplitButton)) {
                        ((ToolStripSplitButton)obj).ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                    }
                    else if (obj.GetType() == typeof(ToolStripButton)) {
                        ((ToolStripButton)obj).ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                    }
                    else if (obj.GetType() == typeof(ToolStripDropDownButton)) {
                        ((ToolStripDropDownButton)obj).ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                    }
                    else if (obj.GetType() == typeof(ToolStripLabel)) {
                        ((ToolStripLabel)obj).ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                    }
                }
            }
            else if (ControlObject.GetType() == typeof(ODModules.MenuStrip)) {
                ODModules.MenuStrip Ms = (ODModules.MenuStrip)ControlObject;
                Ms.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
                Ms.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
                Ms.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
                Ms.MenuBackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
                Ms.MenuBackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
                Ms.ItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
                Ms.ItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
                Ms.StripItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
                Ms.StripItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
                Ms.MenuBorderColor = Properties.Settings.Default.THM_COL_BorderColor;
                Ms.MenuSeparatorColor = Properties.Settings.Default.THM_COL_SeperatorColor;
                Ms.MenuSymbolColor = Properties.Settings.Default.THM_COL_SymbolColor;
                Ms.ItemForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                Ms.ItemSelectedForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            }
            else if (ControlObject.GetType() == typeof(ODModules.StatusMenu)) {
                ODModules.StatusMenu Sm = (ODModules.StatusMenu)ControlObject;
                Sm.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
                Sm.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
                Sm.MenuBackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
                Sm.MenuBackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
                Sm.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
                Sm.ItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
                Sm.ItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
                Sm.StripItemSelectedBackColorNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
                Sm.StripItemSelectedBackColorSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
                Sm.MenuBorderColor = Properties.Settings.Default.THM_COL_BorderColor;
                Sm.MenuSeparatorColor = Properties.Settings.Default.THM_COL_SeperatorColor;
                Sm.MenuSymbolColor = Properties.Settings.Default.THM_COL_SymbolColor;
                Sm.ItemForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                Sm.ItemSelectedForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            }
            else if (ControlObject.GetType() == typeof(ODModules.ContextMenu)) {
                ODModules.ContextMenu Cm = (ODModules.ContextMenu)ControlObject;
                Cm.MenuBackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
                Cm.MenuBackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
                Cm.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                Cm.MouseOverColor = Properties.Settings.Default.THM_COL_ButtonSelected;
                Cm.BorderColor = Properties.Settings.Default.THM_COL_BorderColor;
                Cm.SeparatorColor = Properties.Settings.Default.THM_COL_SeperatorColor;
                Cm.ActionSymbolForeColor = Properties.Settings.Default.THM_COL_SymbolColor;
                foreach (ToolStripItem CmI in Cm.Items) {
                    CmI.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                }
            }
            else if (ControlObject.GetType() == typeof(ODModules.ListControl)) {
                ODModules.ListControl LstCtrl = (ODModules.ListControl)ControlObject;
                LstCtrl.ColumnForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                LstCtrl.BackColor = Properties.Settings.Default.THM_COL_Editor;
                LstCtrl.SelectedColor = Properties.Settings.Default.THM_COL_SelectedColor;
                LstCtrl.RowColor = Properties.Settings.Default.THM_COL_RowColor;
                LstCtrl.GridlineColor = Properties.Settings.Default.THM_COL_GridLineColor;
                LstCtrl.ColumnColor = Properties.Settings.Default.THM_COL_MenuBack;
                LstCtrl.ColumnLineColor = Properties.Settings.Default.THM_COL_ColumnSeperatorColor;
                LstCtrl.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
                LstCtrl.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;
                LstCtrl.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

                LstCtrl.DropDownMouseDown = Properties.Settings.Default.THM_COL_MouseDownForeColor;
                LstCtrl.DropDownMouseOver = Properties.Settings.Default.THM_COL_MouseOverForeColor;
            }
            else if (ControlObject.GetType() == typeof(ODModules.Navigator)) {
                ODModules.Navigator Nav = (ODModules.Navigator)ControlObject;
                Nav.ArrowColor = Properties.Settings.Default.THM_COL_ForeColor;
                Nav.BackColor = Properties.Settings.Default.THM_COL_SeconaryBackColor;
                Nav.MidColor = Properties.Settings.Default.THM_COL_Editor;
                Nav.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                Nav.ArrowColor = Properties.Settings.Default.THM_COL_ForeColor;
                if (ApplicationManager.IsDark == true) {
                    Color Temp = Properties.Settings.Default.THM_COL_SelectedShadowColor;
                    Nav.ShadowColor = Color.FromArgb(40, Temp.R, Temp.G, Temp.B);
                    Nav.SelectedColor = Color.FromArgb(60, 0, 0, 0);
                    Nav.SideShadowColor = Color.FromArgb(60, Temp.R, Temp.G, Temp.B);
                }
                else {
                    Color Temp = Properties.Settings.Default.THM_COL_SelectedShadowColor;
                    Nav.ShadowColor = Color.FromArgb(40, Temp.R, Temp.G, Temp.B);
                    Nav.SelectedColor = Color.FromArgb(20, 0, 0, 0);
                    Nav.SideShadowColor = Color.FromArgb(20, Temp.R, Temp.G, Temp.B);
                }
            }
            else if (ControlObject.GetType() == typeof(ODModules.TabHeader)) {
                ODModules.TabHeader TbHdr = (ODModules.TabHeader)ControlObject;
                TbHdr.TabHoverBackColor = Properties.Settings.Default.THM_COL_ButtonSelected;
                TbHdr.TabDividerColor = Properties.Settings.Default.THM_COL_SeperatorColor;
                TbHdr.ArrowColor = Properties.Settings.Default.THM_COL_ForeColor;
                TbHdr.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                TbHdr.TabSelectedForeColor = Properties.Settings.Default.THM_COL_TabSelectedForeColor;
                TbHdr.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
                TbHdr.TabSelectedBorderColor = Properties.Settings.Default.THM_COL_TabSelectedBorderColor;
                TbHdr.TabSelectedBackColor = Properties.Settings.Default.THM_COL_TabSelectedColor;
                if (ApplicationManager.IsDark == true) {
                    TbHdr.TabSelectedShadowColor = Color.FromArgb(255, 0, 0, 0);
                }
                else {
                    TbHdr.TabSelectedShadowColor = Color.FromArgb(125, 0, 0, 0);
                }
            }
            else if (ControlObject.GetType() == typeof(ODModules.ConsoleInterface)) {
                ODModules.ConsoleInterface Cons = (ODModules.ConsoleInterface)ControlObject;
                Cons.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
                Cons.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;
                Cons.ForeColor = Properties.Settings.Default.THM_COL_TerminalForeColor;
                Cons.BackColor = Properties.Settings.Default.THM_COL_Editor;
            }
            else if (ControlObject.GetType() == typeof(ODModules.HiddenTabControl)) {
                ODModules.HiddenTabControl tCtrl = (ODModules.HiddenTabControl)ControlObject;
                tCtrl.DefaultColor1 = Properties.Settings.Default.THM_COL_Editor;
                foreach (TabPage tab in tCtrl.TabPages) {
                    tab.BackColor = Properties.Settings.Default.THM_COL_Editor;
                    tab.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                }
            }
            else if (ControlObject.GetType() == typeof(ODModules.LabelPanel)) {
                ODModules.LabelPanel lblPnl = (ODModules.LabelPanel)ControlObject;
                lblPnl.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                lblPnl.LabelBackColor = Properties.Settings.Default.THM_COL_Editor;
                lblPnl.BackColor = Properties.Settings.Default.THM_COL_Editor;
            }
            else if (ControlObject.GetType() == typeof(ODModules.ButtonGrid)) {
                ODModules.ButtonGrid btnGrid = (ODModules.ButtonGrid)ControlObject;
                btnGrid.BackColor = Properties.Settings.Default.THM_COL_Editor;
                btnGrid.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
                btnGrid.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
                btnGrid.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

                btnGrid.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
                btnGrid.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;
                btnGrid.BorderColorNorth = Properties.Settings.Default.THM_COL_BorderColor;
                btnGrid.BorderColorSouth = Properties.Settings.Default.THM_COL_BorderColor;

                btnGrid.BackColorHoverNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
                btnGrid.BackColorHoverSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
            }
            else if (ControlObject.GetType() == typeof(ODModules.NumericTextbox)) {
                ODModules.NumericTextbox numTxt = (ODModules.NumericTextbox)ControlObject;
                numTxt.BackColor = Properties.Settings.Default.THM_COL_Editor;
                numTxt.BorderColor = Properties.Settings.Default.THM_COL_BorderColor;
                numTxt.SelectedBorderColor = Properties.Settings.Default.THM_COL_BorderColor;
                numTxt.SelectedBackColor = Properties.Settings.Default.THM_COL_Editor;
                numTxt.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            }
            else if (ControlObject.GetType() == typeof(ODModules.Button)) {
                ODModules.Button btn = (ODModules.Button)ControlObject;
                btn.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                btn.BackColorNorth = Properties.Settings.Default.THM_COL_SeconaryBackColor;
                btn.BackColorSouth = Properties.Settings.Default.THM_COL_SeconaryBackColor;
                btn.BackColorDownNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
                btn.BackColorDownSouth = Properties.Settings.Default.THM_COL_ButtonSelected;
                btn.BorderColorNorth = Properties.Settings.Default.THM_COL_BorderColor;
                btn.BorderColorSouth = Properties.Settings.Default.THM_COL_BorderColor;
                btn.BorderColorDownNorth = Properties.Settings.Default.THM_COL_BorderColor;
                btn.BorderColorDownSouth = Properties.Settings.Default.THM_COL_BorderColor;
            }
        }
        #endregion
        public static Image DrawIcon(Theme Thm, Font ParentFont) {
            var bmp = new Bitmap(DesignerSetup.LargeIconSize, DesignerSetup.LargeIconSize);
            Graphics g = Graphics.FromImage(bmp);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            Rectangle TextBounds = new Rectangle(0, 0, DesignerSetup.LargeIconSize, DesignerSetup.LargeIconSize);
            using (SolidBrush BckBr = new SolidBrush(Thm.EditorColor)) {
                g.FillRectangle(BckBr, TextBounds);
            }
            using (StringFormat sf = new StringFormat()) {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                using (SolidBrush txtbr = new SolidBrush(Thm.ForeColor)) {
                    g.DrawString("Aa", ParentFont, txtbr, TextBounds, sf);
                }
            }
            using (SolidBrush BrdBr = new SolidBrush(Thm.ButtonSelectedColor)) {
                using (Pen BrdPn = new Pen(BrdBr, 5)) {
                    g.DrawRectangle(BrdPn, TextBounds);
                }
            }
            g.Dispose();
            return bmp;
        }
        public static void LoadDefaultThemes() {
            Themes.Add(Theme_ClassicLight());
            Themes.Add(Theme_ClassicDark());
            Themes.Add(Theme_PastelBlue());
            Themes.Add(Theme_MidnightBlue());
            Themes.Add(Theme_HighContrastConsole());
        }
        private static Theme Theme_ClassicDark() {
            Theme Thm_Dark1 = new Theme();
            Thm_Dark1.ShadowColor = Color.Black;
            Thm_Dark1.MenuBackColor = Color.FromArgb(31, 31, 31);
            Thm_Dark1.ButtonSelectedColor = Color.FromArgb(64, 64, 64);
            Thm_Dark1.ButtonCheckedColor = Color.FromArgb(70, 70, 70);
            Thm_Dark1.EditorColor = Color.FromArgb(16, 16, 16);
            Thm_Dark1.ForeColor = Color.White;
            Thm_Dark1.SecondaryForeColor = Color.Silver;
            Thm_Dark1.BorderColor = Color.DimGray;
            Thm_Dark1.SeperatorColor = Color.FromArgb(55, 55, 55);
            Thm_Dark1.SelectedColor = Color.SteelBlue;
            Thm_Dark1.ScrollColor = Color.FromArgb(64, 64, 64);
            Thm_Dark1.SymbolColor = Color.DarkGray;
            Thm_Dark1.StopColor = Color.Brown;
            Thm_Dark1.SeconaryBackColor = Color.FromArgb(40, 40, 40);
            Thm_Dark1.TerminalForeColor = Color.FromArgb(255, 255, 192);

            Thm_Dark1.MouseDownForeColor = Color.DimGray;
            Thm_Dark1.MouseOverForeColor = Color.LightGray;

            Thm_Dark1.ColumnSeperatorColor = Color.FromArgb(64, 64, 64);

            Thm_Dark1.RowColor = Color.FromArgb(23, 23, 23);
            Thm_Dark1.GridLineColor = Color.FromArgb(30, 30, 30);

            Thm_Dark1.TabSelectedBorderColor = Color.FromArgb(100, 128, 128, 128);
            Thm_Dark1.TabSelectedColor = Color.FromArgb(100, 128, 128, 128);
            Thm_Dark1.TabSelectedForeColor = Color.White;

            Thm_Dark1.MatchColor = Color.FromArgb(0, 64, 0);
            Thm_Dark1.MismatchedColor = Color.FromArgb(64, 0, 0);

            Thm_Dark1.IsDarkTheme = true;
            return Thm_Dark1;
        }
        private static Theme Theme_ClassicLight() {
            Theme Thm_Light1 = new Theme();

            Thm_Light1.ShadowColor = Color.Black;
            Thm_Light1.MenuBackColor = Color.FromArgb(224, 224, 224);
            Thm_Light1.ButtonSelectedColor = Color.FromArgb(191, 191, 191);
            Thm_Light1.ButtonCheckedColor = Color.FromArgb(185, 185, 185);
            Thm_Light1.EditorColor = Color.FromArgb(245, 245, 245);
            Thm_Light1.ForeColor = Color.Black;
            Thm_Light1.SecondaryForeColor = Color.DimGray;
            Thm_Light1.BorderColor = Color.FromArgb(150, 150, 150);
            Thm_Light1.SeperatorColor = Color.FromArgb(200, 200, 200);
            Thm_Light1.SelectedColor = Color.LightSteelBlue;
            Thm_Light1.ScrollColor = Color.FromArgb(200, 200, 200);
            Thm_Light1.SymbolColor = Color.DimGray;
            Thm_Light1.StopColor = Color.Brown;
            Thm_Light1.SeconaryBackColor = Color.FromArgb(215, 215, 215);
            Thm_Light1.TerminalForeColor = Color.FromArgb(0, 0, 63);

            Thm_Light1.MouseOverForeColor = Color.DimGray;
            Thm_Light1.MouseDownForeColor = Color.LightGray;

            Thm_Light1.ColumnSeperatorColor = Color.FromArgb(180, 180, 180);

            Thm_Light1.TabSelectedBorderColor = Color.FromArgb(100, 128, 128, 128);
            Thm_Light1.TabSelectedColor = Color.FromArgb(100, 128, 128, 128);
            Thm_Light1.TabSelectedForeColor = Color.Black;

            Thm_Light1.RowColor = Color.FromArgb(232, 232, 232);
            Thm_Light1.GridLineColor = Color.FromArgb(225, 225, 225);

            Thm_Light1.MatchColor = Color.FromArgb(191, 255, 191);
            Thm_Light1.MismatchedColor = Color.FromArgb(255, 191, 191);

            Thm_Light1.IsDarkTheme = false;
            return Thm_Light1;
        }
        private static Theme Theme_PastelBlue() {
            Theme Thm_Light2 = new Theme();

            Thm_Light2.ShadowColor = Color.FromArgb(44, 61, 91);
            Thm_Light2.MenuBackColor = Color.FromArgb(214, 219, 233);
            Thm_Light2.ButtonSelectedColor = Color.FromArgb(189, 194, 208);
            Thm_Light2.ButtonCheckedColor = Color.FromArgb(155, 167, 183);
            Thm_Light2.EditorColor = Color.FromArgb(245, 245, 245);
            Thm_Light2.ForeColor = Color.Black;
            Thm_Light2.SecondaryForeColor = Color.FromArgb(48, 67, 98);
            Thm_Light2.BorderColor = Color.FromArgb(142, 135, 188);
            Thm_Light2.SeperatorColor = Color.FromArgb(142, 155, 188);
            Thm_Light2.SelectedColor = Color.FromArgb(204, 206, 219);
            Thm_Light2.ScrollColor = Color.FromArgb(200, 200, 200);
            Thm_Light2.SymbolColor = Color.FromArgb(41, 27, 85);
            Thm_Light2.StopColor = Color.Brown;
            Thm_Light2.SeconaryBackColor = Color.FromArgb(207, 214, 229);
            Thm_Light2.TerminalForeColor = Color.FromArgb(0, 0, 63);

            Thm_Light2.MouseDownForeColor = Color.FromArgb(88, 107, 138);
            Thm_Light2.MouseOverForeColor = Color.FromArgb(48, 67, 98);

            Thm_Light2.ColumnSeperatorColor = Color.FromArgb(204, 206, 219);

            Thm_Light2.TabSelectedBorderColor = Color.FromArgb(142, 155, 188);
            Thm_Light2.TabSelectedColor = Color.FromArgb(77, 96, 130);
            Thm_Light2.TabSelectedForeColor = Color.White;

            Thm_Light2.RowColor = Color.FromArgb(228, 232, 247);
            Thm_Light2.GridLineColor = Color.FromArgb(225, 225, 225);

            Thm_Light2.MatchColor = Color.FromArgb(191, 255, 191);
            Thm_Light2.MismatchedColor = Color.FromArgb(255, 191, 191);

            Thm_Light2.IsDarkTheme = false;
            return Thm_Light2;
        }
        private static Theme Theme_MidnightBlue() {
            Theme Thm_Dark2 = new Theme();

            Thm_Dark2.ShadowColor = Color.Black;
            Thm_Dark2.MenuBackColor = Color.FromArgb(22, 27, 41);
            Thm_Dark2.ButtonSelectedColor = Color.FromArgb(47, 52, 66);
            Thm_Dark2.ButtonCheckedColor = Color.FromArgb(70, 70, 70);
            Thm_Dark2.EditorColor = Color.FromArgb(16, 16, 16);
            Thm_Dark2.ForeColor = Color.White;
            Thm_Dark2.SecondaryForeColor = Color.Silver;
            Thm_Dark2.BorderColor = Color.FromArgb(74, 67, 120);
            Thm_Dark2.SeperatorColor = Color.FromArgb(67, 80, 113);
            Thm_Dark2.SelectedColor = Color.SteelBlue;
            Thm_Dark2.ScrollColor = Color.FromArgb(64, 64, 64);
            Thm_Dark2.SymbolColor = Color.DarkGray;
            Thm_Dark2.StopColor = Color.Brown;
            Thm_Dark2.SeconaryBackColor = Color.FromArgb(26, 33, 48);
            Thm_Dark2.TerminalForeColor = Color.FromArgb(255, 255, 192);

            Thm_Dark2.MouseDownForeColor = Color.DimGray;
            Thm_Dark2.MouseOverForeColor = Color.LightGray;

            Thm_Dark2.ColumnSeperatorColor = Color.FromArgb(64, 64, 64);

            Thm_Dark2.RowColor = Color.FromArgb(23, 23, 23);
            Thm_Dark2.GridLineColor = Color.FromArgb(30, 30, 30);

            Thm_Dark2.TabSelectedBorderColor = Color.FromArgb(67, 80, 113);
            Thm_Dark2.TabSelectedColor = Color.FromArgb(125, 144, 178);
            Thm_Dark2.TabSelectedForeColor = Color.White;

            Thm_Dark2.MatchColor = Color.FromArgb(0, 64, 0);
            Thm_Dark2.MismatchedColor = Color.FromArgb(64, 0, 0);

            Thm_Dark2.IsDarkTheme = true;
            return Thm_Dark2;
        }
        private static Theme Theme_HighContrastConsole() {
            Theme Thm_Dark2 = new Theme();

            Thm_Dark2.ShadowColor = Color.Black;
            Thm_Dark2.MenuBackColor = Color.Black;
            Thm_Dark2.ButtonSelectedColor = Color.FromArgb(156, 30, 165);
            Thm_Dark2.ButtonCheckedColor = Color.FromArgb(154, 30, 20);
            Thm_Dark2.EditorColor = Color.Black;
            Thm_Dark2.ForeColor = Color.White;
            Thm_Dark2.SecondaryForeColor = Color.Silver;
            Thm_Dark2.BorderColor = Color.Yellow;
            Thm_Dark2.SeperatorColor = Color.Yellow;
            Thm_Dark2.SelectedColor = Color.FromArgb(1,0,164);
            Thm_Dark2.ScrollColor = Color.FromArgb(64, 64, 64);
            Thm_Dark2.SymbolColor = Color.FromArgb(137, 251, 252);
            Thm_Dark2.StopColor = Color.Red;
            Thm_Dark2.SeconaryBackColor = Color.FromArgb(82, 82, 82);
            Thm_Dark2.TerminalForeColor = Color.White;

            Thm_Dark2.MouseDownForeColor = Color.DimGray;
            Thm_Dark2.MouseOverForeColor = Color.LightGray;

            Thm_Dark2.ColumnSeperatorColor = Color.FromArgb(64, 64, 64);

            Thm_Dark2.RowColor = Color.FromArgb(0, 0, 0);
            Thm_Dark2.GridLineColor = Color.FromArgb(85, 85, 85);

            Thm_Dark2.TabSelectedBorderColor = Color.FromArgb(156, 30, 165);
            Thm_Dark2.TabSelectedColor = Color.FromArgb(156, 30, 165);
            Thm_Dark2.TabSelectedForeColor = Color.White;

            Thm_Dark2.MatchColor = Color.FromArgb(0, 64, 0);
            Thm_Dark2.MismatchedColor = Color.FromArgb(64, 0, 0);

            Thm_Dark2.IsDarkTheme = true;
            return Thm_Dark2;
        }
    }
}
