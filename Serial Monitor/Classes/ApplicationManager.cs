using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Serial_Monitor.Classes {
    public class ApplicationManager {

        public static bool IsDark = true;
        public static bool IsInternalApplicationOpen(string Name) {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc) {
                if (frm.Name == Name) {
                    return true;
                }
            }
            return false;
        }
        public static void CloseInternalApplication(string Name) {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc) {
                if (frm.Name == Name) {
                    frm.Close();
                    break;
                }
            }
        }
        public static void BringInternalApplicationToFront(string Name) {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc) {
                if (frm.Name == Name) {
                    frm.BringToFront();
                    break;
                }
            }
        }
        public static void OpenInternalApplicationOnce(Form Application, bool BringToFront = true) {
            if (IsInternalApplicationOpen(Application.Name)) {
                if (BringToFront == true) { BringInternalApplicationToFront(Application.Name); }
            }
            else {
                Application.Show();
            }
        }
        public static void ReapplyThemeToAll() {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc) {
                if (typeof(Interfaces.ITheme).IsAssignableFrom(frm.GetType())) {
                    ((Interfaces.ITheme)frm).ApplyTheme();
                }
            }
        }
        public static void InvokeApplicationEvent() {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc) {
                if (typeof(Interfaces.IWindowManager).IsAssignableFrom(frm.GetType())) {
                    ((Interfaces.IWindowManager)frm).UpdateWindows();
                    break;
                }
            }
        }
    }
}
