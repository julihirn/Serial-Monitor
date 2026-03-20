using Microsoft.Win32;
using ODModules;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolStrip = ODModules.ToolStrip;

namespace Serial_Monitor.Classes {
    public static class UserInterfaceManager {
        static UserInterfaceManager() {
            _layoutSaveTimer.Tick += (s, e) => {
                _layoutSaveTimer.Stop();
                if (!ApplyingLayout) {
                    CaptureAllLayouts();
                }
            };
        }

        #region ToolStrip Layout Engine Manager
        static bool ApplyingLayout = true;
        public static void ApplyLayout(Form? frm, ToolStripContainer? tsc) {
            if (frm == null || tsc == null) { return; }
         
            List<ToolStripPosition> layouts = GetToolStripSettings().Where(l => l.FormObject == frm.Name).OrderBy(l => l.Position).OrderBy(l => -l.Order).ThenBy(l =>
                    l.Position == Enums.ToolStripPosition.Top ||
                    l.Position == Enums.ToolStripPosition.Left ? -l.Line : l.Line).ThenBy(l =>
                    l.Position == Enums.ToolStripPosition.Top ||  l.Position == Enums.ToolStripPosition.Left ? -l.Order : l.Order).ToList();

            if (layouts.Count == 0) { return; }
            ApplyingLayout = true;
            tsc.SuspendLayout();
            Dictionary<string, ToolStrip> toolStrips = BuildToolStripMap(tsc);

            ToolStripPanel[] panels = { tsc.TopToolStripPanel,tsc.BottomToolStripPanel,tsc.LeftToolStripPanel,tsc.RightToolStripPanel };
            foreach (ToolStripPanel panel in panels) {
                panel.SuspendLayout();
                panel.Controls.Clear();
            }
            Dictionary<int, int> usedSpace = new Dictionary<int, int>();
            foreach (ToolStripPosition layout in layouts) {
                Debug.Print(layout.ToString());
                ToolStrip? ts;
                if (!toolStrips.TryGetValue(layout.ToolStripObject, out ts)) {
                    continue;
                }
                ToolStripPanel? panel = GetPanel(tsc, layout.Position);
                if (panel == null) { continue; }
                ts.Dock = DockStyle.None;
                ts.Visible = layout.Visible;

                PlaceToolStripOnLine(panel, ts, layout.Line, usedSpace);
                //panel.Join(ts, layout.Line);
            }

            foreach (ToolStripPanel panel in panels) {
                panel.ResumeLayout();
            }

            tsc.ResumeLayout();
            ApplyingLayout = false;
        }
        private static void PlaceToolStripOnLine(ToolStripPanel panel, ToolStrip ts, int line, Dictionary<int, int> usedSpace) {
            // Get the panel's width (if Top/Bottom) or height (if Left/Right)
            int availableSpace = (panel.Dock == DockStyle.Top || panel.Dock == DockStyle.Bottom) ? panel.Width : panel.Height;

            // Check how much space has been used on the current line
            int usedWidth = usedSpace.ContainsKey(line) ? usedSpace[line] : 0;

            // If the ToolStrip fits within the available space on the current line, place it there
            if (usedWidth + ts.Width <= availableSpace) {
                // Set the location of the ToolStrip based on the current used space on this line
                ts.Location = new Point(usedWidth, 0); // Assuming horizontal layout (for Top/Bottom)

                // Ensure left alignment for horizontal ToolStrips (Top/Bottom)
                if (panel.Dock == DockStyle.Top || panel.Dock == DockStyle.Bottom) {
                    ts.Anchor = AnchorStyles.Left;  // Explicitly set to left alignment
                }

                // For left/right panels, align to the top of the panel
                if (panel.Dock == DockStyle.Left || panel.Dock == DockStyle.Right) {
                    ts.Anchor = AnchorStyles.Top;  // Explicitly set to top alignment
                }

                // Update the used space for the current line
                usedSpace[line] = usedWidth + ts.Width;

                // Add the ToolStrip to the panel (without Join)
                panel.Controls.Add(ts);
            }
            else {
                // If it doesn't fit, move to the next line
                PlaceToolStripOnLine(panel, ts, line + 1, usedSpace); // Recursively move to the next line
            }
        }
        public static void HookToolStrips(ToolStripContainer tsc) {
            if (tsc == null) return;
            ApplyingLayout = true;
            foreach (ToolStripPanel panel in Panels(tsc)) {
                foreach (ToolStrip ts in panel.Controls.OfType<ToolStrip>()) {
                    ts.EndDrag += Ts_EndDrag;
                }
            }
            ApplyingLayout = false;
        }

        private static void Ts_EndDrag(object? sender, EventArgs e) {
            if (sender is not ToolStrip ts) { return; }
            if (ts.Parent is not ToolStripPanel panel) { return; }
            ScheduleSave();
        }

        public static void UnhookToolStrips(ToolStripContainer tsc) {
            if (tsc == null) return;
            ApplyingLayout = true;
            foreach (ToolStripPanel panel in Panels(tsc)) {
                foreach (ToolStrip ts in panel.Controls.OfType<ToolStrip>()) {
                    ts.EndDrag -= Ts_EndDrag;
                }
            }
            ApplyingLayout = false;
        }

        #endregion

        #region ToolStrip Layout Engine Layout Capture
        private static void ToolStripMouseUp(object? sender, MouseEventArgs e) {
            if (sender is not ToolStrip ts) { return; }
            if (ts.Parent is not ToolStripPanel panel) { return; }
            ScheduleSave();
        }
        private static void ToolStripPanelChanged(object? sender, ControlEventArgs e) {
            if (e.Control is ToolStrip) {
                ScheduleSave();
            }
        }
        private static void ToolStripPanelLayoutChanged(object? sender, LayoutEventArgs e) {
            if (e.AffectedControl is ToolStrip) {
                ScheduleSave();
            }
        }
        private static readonly System.Windows.Forms.Timer _layoutSaveTimer = new System.Windows.Forms.Timer {
            Interval = 150
        };
        private static void ScheduleSave() {
            _layoutSaveTimer.Stop();
            _layoutSaveTimer.Start();
        }
        private static void CaptureAllLayouts() {
            foreach (Form frm in Application.OpenForms) {
                foreach (ToolStripContainer tsc in frm.Controls.OfType<ToolStripContainer>()) {
                    SaveContainerLayout(frm, tsc);
                }
            }
        }
        private static void SaveContainerLayout(Form frm, ToolStripContainer tsc) {
            foreach (var panel in Panels(tsc)) {
                //foreach (ToolStrip ts in panel.Controls.OfType<ToolStrip>()) {
                Enums.ToolStripPosition pos;
                switch (panel.Dock) {
                    case DockStyle.Top: pos = Enums.ToolStripPosition.Top; break;
                    case DockStyle.Bottom: pos = Enums.ToolStripPosition.Bottom; break;
                    case DockStyle.Left: pos = Enums.ToolStripPosition.Left; break;
                    case DockStyle.Right: pos = Enums.ToolStripPosition.Right; break;
                    default: continue;
                }
                int line = 0;

                foreach (ToolStripPanelRow row in panel.Rows) {
                    int order = 0;

                    foreach (ToolStrip ts in row.Controls.OfType<ToolStrip>()) {
                        decimal loc =
                            (pos == Enums.ToolStripPosition.Top || pos == Enums.ToolStripPosition.Bottom)
                                ? (decimal)ts.Left / panel.Width
                                : (decimal)ts.Top / panel.Height;

                        SaveToolStripLayout(new ToolStripPosition {
                            FormObject = frm.Name,
                            ToolStripObject = ts.Name,
                            Position = pos,
                            Line = (sbyte)line,
                            Order = (sbyte)order,
                            Location = Math.Clamp(loc, 0m, 1m),
                            Visible = ts.Visible
                        });

                        order++;
                    }

                    line++;
                }
            }
        }
        private static int GetLineIndex(ToolStripPanel panel, ToolStrip ts) {
            int line = 0;
            foreach (Control c in panel.Controls) {
                if (c == ts) { break; }
                if (c.Top != ts.Top && c.Left != ts.Left) {
                    line++;
                }
            }
            return line;
        }
        #endregion

        #region ToolStrip Layout Engine Helpers

        private static ToolStripPanel? GetPanel(ToolStripContainer tsc, Enums.ToolStripPosition pos) => pos switch {
            Enums.ToolStripPosition.Top => tsc.TopToolStripPanel,
            Enums.ToolStripPosition.Bottom => tsc.BottomToolStripPanel,
            Enums.ToolStripPosition.Left => tsc.LeftToolStripPanel,
            Enums.ToolStripPosition.Right => tsc.RightToolStripPanel,
            _ => null
        };
        private static Dictionary<string, ToolStrip> BuildToolStripMap(ToolStripContainer tsc) {
            Dictionary<string, ToolStrip> dict = new Dictionary<string, ToolStrip>(StringComparer.OrdinalIgnoreCase);
            foreach (ToolStripPanel panel in Panels(tsc)) {
                foreach (Control c in panel.Controls) {
                    if (c is ToolStrip ts && !string.IsNullOrEmpty(ts.Name)) {
                        dict[ts.Name] = ts;
                    }
                }
            }
            return dict;
        }
        private static ToolStrip? FindToolStrip(ToolStripContainer tsc, string name) {
            foreach (ToolStripPanel panel in Panels(tsc)) {
                foreach (Control c in panel.Controls) {
                    if (c is ToolStrip ts && ts.Name == name) {
                        return ts;
                    }
                }
            }
            return null;
        }
        private static ToolStrip? FindToolStrip(Form frm, string name) {
            if (frm is null) { return null; }
            FieldInfo? field = typeof(Form).GetField("components", BindingFlags.Instance | BindingFlags.NonPublic);
            if (field?.GetValue(frm) is not IContainer container) {
                return null;
            }
            foreach (IComponent comp in container.Components) {
                if (comp is ToolStrip ts && ts.Name == name) {
                    return ts;
                }
            }
            return null;
        }

        private static IEnumerable<Control> GetAllControls(Control parent) {
            foreach (Control c in parent.Controls) {
                yield return c;

                foreach (Control child in GetAllControls(c)) {
                    yield return child;
                }
            }
        }
        private static IEnumerable<ToolStripPanel> Panels(ToolStripContainer tsc) {
            yield return tsc.TopToolStripPanel;
            yield return tsc.BottomToolStripPanel;
            yield return tsc.LeftToolStripPanel;
            yield return tsc.RightToolStripPanel;
        }

        #endregion

        #region ToolStrip Layout Engine Settings IO

        private static List<ToolStripPosition> GetToolStripSettings() {
            List<ToolStripPosition> list = new List<ToolStripPosition>();
            var col = Properties.Settings.Default.PRG_UI_ToolStripLayout;
            if (col == null) return list;
            foreach (string? s in col) {
                if (string.IsNullOrWhiteSpace(s)) { continue; }
                ToolStripPosition tsp = new ToolStripPosition();
                if (tsp.Deserialise(s)) {
                    list.Add(tsp);
                }
            }
            return list;
        }

        private static void SaveToolStripLayout(ToolStripPosition pos) {
            if (Properties.Settings.Default.PRG_UI_ToolStripLayout == null) {
                Properties.Settings.Default.PRG_UI_ToolStripLayout = new System.Collections.Specialized.StringCollection();
            }
            var col = Properties.Settings.Default.PRG_UI_ToolStripLayout;
            (string, string) serial = pos.GetSerialised();
            for (int i = 0; i < col.Count; i++) {
                if (col[i]?.StartsWith(serial.Item1 + ",") == true) {
                    col[i] = serial.Item2;
                    Properties.Settings.Default.Save();
                    return;
                }
            }
            col.Add(serial.Item2);
            Properties.Settings.Default.Save();
        }

        #endregion
        internal static void HookToolStrips(ToolStripContainer? Tsc, EventHandler MveHdlr) {
            if (Tsc == null) { return; }
            foreach (Control panel in new[] { Tsc.TopToolStripPanel, Tsc.BottomToolStripPanel, Tsc.LeftToolStripPanel, Tsc.RightToolStripPanel }) {
                foreach (Control c in panel.Controls) {
                    if (c is ODModules.ToolStrip ts) {
                        ts.LocationChanged += MveHdlr;
                    }
                }
            }
        }
        internal static void UnhookToolStrips(ToolStripContainer? Tsc, EventHandler MveHdlr) {
            if (Tsc == null) { return; }
            foreach (Control panel in new[] { Tsc.TopToolStripPanel, Tsc.BottomToolStripPanel, Tsc.LeftToolStripPanel, Tsc.RightToolStripPanel }) {
                foreach (Control c in panel.Controls) {
                    if (c is ODModules.ToolStrip ts) {
                        ts.LocationChanged -= MveHdlr;
                    }
                }
            }
        }
        public static Rectangle GetRectangleFromTab(TabHeader ParentTabHeader, bool IncludeTextOffset = false) {
            if (ParentTabHeader.Tag == null) { return Rectangle.Empty; }
            if (ParentTabHeader.Tag.GetType() == typeof(TabClickedEventArgs)) {
                TabClickedEventArgs Args = (TabClickedEventArgs)ParentTabHeader.Tag;
                if (IncludeTextOffset == false) {
                    return Args.TabRectangle;
                }
                else {
                    return new Rectangle(Args.TabRectangle.X + Args.TextOffset, Args.TabRectangle.Y, Args.TabRectangle.Width - Args.TextOffset, Args.TabRectangle.Height); ;
                }

            }
            return Rectangle.Empty;
        }
        public static Rectangle GetRectangleFromTab(TabClickedEventArgs Args, bool IncludeTextOffset = false) {
            if (IncludeTextOffset == false) {
                return Args.TabRectangle;
            }
            else {
                return new Rectangle(Args.TabRectangle.X + Args.TextOffset, Args.TabRectangle.Y, Args.TabRectangle.Width - Args.TextOffset, Args.TabRectangle.Height); ;
            }
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        //Flash both the window caption and taskbar button.
        //This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags. 
        public const UInt32 FLASHW_ALL = 3;

        // Flash continuously until the window comes to the foreground. 
        public const UInt32 FLASHW_TIMERNOFG = 12;

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }

        // Do the flashing - this does not involve a raincoat.
        public static bool FlashWindowEx(Form form) {
            IntPtr hWnd = form.Handle;
            FLASHWINFO fInfo = new FLASHWINFO();

            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;
            fInfo.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG;
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;

            return FlashWindowEx(ref fInfo);
        }
    }

}
