using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Globalization;

namespace Serial_Monitor.Classes {
    public static class LocalisationManager {
        public static ResourceManager Language = new ResourceManager(GetCurrentNamespace() + ".Languages." + System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName + "_local", Assembly.GetExecutingAssembly());
        public static void GetLanguage(System.Globalization.CultureInfo Culture) {
            try {
                Language = new ResourceManager(GetCurrentNamespace() + ".Languages." + Culture.TwoLetterISOLanguageName + "_local", Assembly.GetExecutingAssembly());
            }
            catch { }
        }
        public static string GetCurrentNamespace() {
            MethodInfo? MethInfo = System.Reflection.Assembly.GetExecutingAssembly().EntryPoint;
            if (MethInfo == null) { return ""; }
            Type? DecType = MethInfo.DeclaringType;
            if (DecType == null) { return ""; }
            return DecType.Namespace ?? "";
        }
        private const string NoLocalText = "$NLT";
        public static string GetLocalisedText(string LookUp, string FallBackText) {
            string LocalText = Language.GetString(LookUp) ?? NoLocalText;
            if (LocalText == NoLocalText) { return FallBackText; }
            return LocalText;
        }
        public static void ApplyText(object Ctrl, string LookUp, StringApplication ApplicationFlags = StringApplication.Labels) {
            string LocalText = Language.GetString(LookUp) ?? NoLocalText;
            if (LocalText == NoLocalText) { return; }
            try {
                Type T = Ctrl.GetType();
                if (T == typeof(ToolStripMenuItem)) {
                    ToolStripMenuItem TSMI = (ToolStripMenuItem)Ctrl;
                    TSMI.Text = LocalText;
                }
                else if (T == typeof(ToolStripButton)) {
                    ToolStripButton TSMI = (ToolStripButton)Ctrl;
                    TSMI.Text = LocalText;
                    TSMI.ToolTipText = LocalText;
                }
                else if (T == typeof(ToolStripDropDownButton)) {
                    ToolStripDropDownButton TSMI = (ToolStripDropDownButton)Ctrl;
                    if (((int)ApplicationFlags & 0x01) == 0x01) {
                        TSMI.Text = LocalText;
                    }
                    if (((int)ApplicationFlags & 0x02) == 0x02) {
                        TSMI.ToolTipText = LocalText;
                    }
                }
            }
            catch { }
        }


        public enum StringApplication {
            None = 0,
            Labels = 0x01,
            ToolTips = 0x02
        }
    }
}
