using ODModules;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }

}
