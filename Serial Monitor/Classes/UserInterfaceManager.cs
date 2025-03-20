using ODModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes {
    public static class UserInterfaceManager {
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
