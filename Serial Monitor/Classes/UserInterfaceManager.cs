using Microsoft.Win32;
using ODModules;
using Serial_Monitor.Classes.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes {
    public static class UserInterfaceManager {
        internal static void GetToolStripLayout(Form? frm, ToolStripContainer? Tsc) {
            if (frm == null) { return; }
            if (Tsc == null) { return; }
            List<ToolStripPosition> toolStripPositions = GetToolStripSettings();
            List<ToolStripPosition> filtered = toolStripPositions.Where(t => t.FormObject == frm.Name).ToList();
            if (filtered.Count == 0) { return; }
            List<int> indices = Enumerable.Range(0, filtered.Count - 1).ToList();
            int pnl = 0;
            foreach (Control panel in new[] { Tsc.TopToolStripPanel, Tsc.BottomToolStripPanel, Tsc.LeftToolStripPanel, Tsc.RightToolStripPanel }) {
                foreach (Control c in panel.Controls) {
                    if (c is ODModules.ToolStrip ts) {
                        for (int i = indices.Count; i >= 0; i--) {
                            if (filtered[indices[i]].ToolStripObject != c.Name) { continue; }

                        }
                    }
                }
                ++pnl;
            }
        }
        private static List<ToolStripPosition> GetToolStripSettings() {
            List<ToolStripPosition> ToolStripSettings = new List<ToolStripPosition>();
            if (Properties.Settings.Default.PRG_UI_ToolStripLayout != null) {
                int j = 1;
                for (int i = 0; i < Properties.Settings.Default.PRG_UI_ToolStripLayout.Count; i++) {
                    string? LayoutEngine = Properties.Settings.Default.PRG_UI_ToolStripLayout[i];
                    if (LayoutEngine == null) { continue; }
                    if (LayoutEngine.Trim() == "") { continue; }
                    ToolStripPosition Tsp = new ToolStripPosition();
                    if (!Tsp.Deserialise(LayoutEngine)) { continue; }
                    ToolStripSettings.Add(Tsp);
                }
            }
            return ToolStripSettings;
        }
        private static void SetToolStripLayout(ToolStripPosition Positioning) {
            if (Properties.Settings.Default.PRG_UI_ToolStripLayout == null) {
                Properties.Settings.Default.PRG_UI_ToolStripLayout = new System.Collections.Specialized.StringCollection();
            }
            int TsDataLine = -1;
            (string obj, string serial) = Positioning.GetSerialised();
            for (int i = 0; i < Properties.Settings.Default.PRG_UI_ToolStripLayout.Count; i++) {
                if (Properties.Settings.Default.PRG_UI_ToolStripLayout[i] != null) {
                    string? dataLine = Properties.Settings.Default.PRG_UI_ToolStripLayout[i];
                    if (dataLine == null) { continue; }
                    string lineObject = dataLine.Split(',')[0];
                    if (obj == lineObject) {
                        Properties.Settings.Default.PRG_UI_ToolStripLayout[i] = serial;
                        TsDataLine = i;
                        break;
                    }
                }
            }
            if (TsDataLine == -1) {
                Properties.Settings.Default.PRG_UI_ToolStripLayout.Add(serial);
            }
            Properties.Settings.Default.Save();
        }
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
                    return Args.TextArea;
                }
                else {
                    return new Rectangle(Args.TextArea.X + Args.TextOffset, Args.TextArea.Y, Args.TextArea.Width - Args.TextOffset, Args.TextArea.Height); ;
                }

            }
            return Rectangle.Empty;
        }
        public static Rectangle GetRectangleFromTab(TabClickedEventArgs Args, bool IncludeTextOffset = false) {
            if (IncludeTextOffset == false) {
                return Args.TextArea;
            }
            else {
                return new Rectangle(Args.TextArea.X + Args.TextOffset, Args.TextArea.Y, Args.TextArea.Width - Args.TextOffset, Args.TextArea.Height); ;
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
