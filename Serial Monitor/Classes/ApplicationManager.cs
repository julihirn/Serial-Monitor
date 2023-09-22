using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Serial_Monitor.WindowForms;
using System.Threading.Channels;

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
        public static Form? GetFormByName(string Name) {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc) {
                if (frm.Name == Name) {
                    return frm;
                }
            }
            return null;
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
        public static DialogResult OpenInternalApplicationAsDialog(Form Application, Form Parent) {
            //Application.Parent = Parent;
            Application.ShowInTaskbar = false;
            Application.StartPosition = FormStartPosition.CenterParent;
            return Application.ShowDialog();
        }
        public static void OpenInternalApplicationOnce(Form Application, bool BringToFront = true) {
            if (IsInternalApplicationOpen(Application.Name)) {
                if (BringToFront == true) { BringInternalApplicationToFront(Application.Name); }
            }
            else {
                Application.Show();
            }
        }
        public static void OpenSerialTerminal(SerialManager ?Manager, bool BringToFront = true) {
            if (Manager == null) { return; }
            string ID = "TERM_" + Manager.ID;
            if (IsInternalApplicationOpen(ID)) {
                if (BringToFront == true) { BringInternalApplicationToFront(ID); }
            }
            else {
                Terminal Term = new Terminal(Manager);
                Term.Name = ID;
                if (BringToFront == true) { Term.BringToFront(); }
                Term.Show();
            }
        }
        public static void OpenSerialProperties(SerialManager? Manager, bool NewPropetyWindow = false, bool BringToFront = true) {
            if (Manager == null) { return; }
            if (NewPropetyWindow == true) {
                string ID = "PROP_" + Manager.ID;
                if (IsInternalApplicationOpen(ID)) {
                    if (BringToFront == true) { BringInternalApplicationToFront(ID); }
                }
                else {
                    ChannelProperties ChanProp = new ChannelProperties(Manager);
                    ChanProp.Name = ID;
                    if (BringToFront == true) { ChanProp.BringToFront(); }
                    ChanProp.Show();
                }
            }
            else {
                string ID = "PROP_ALL";
                if (IsInternalApplicationOpen(ID)) {
                    Form? Temp = GetFormByName(ID);
                    if (Temp != null) {
                        if (Temp.GetType() == typeof(ChannelProperties)) {
                            ((ChannelProperties)Temp).Manager = Manager;
                        }
                    }
                    if (BringToFront == true) { BringInternalApplicationToFront(ID); }
                }
                else {
                    ChannelProperties ChanProp = new ChannelProperties(Manager);
                    ChanProp.Name = ID;
                    if (BringToFront == true) { ChanProp.BringToFront(); }
                    ChanProp.Show();
                }
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
