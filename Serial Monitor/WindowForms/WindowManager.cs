using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor.WindowForms {
    public partial class WindowManager : Components.SkinnedForm, Interfaces.ITheme, Interfaces.IWindowManager {
        public WindowManager() {
            InitializeComponent();
        }
        private void WindowManager_Load(object sender, EventArgs e) {
            ApplyTheme();
        }
        public void ApplyTheme() {
            //panel1.BackColor = Properties.Settings.Default.THM_COL_MenuBackColor;
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            listView1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            listView1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            Classes.Theming.ThemeManager.ThemeControl(msMain);

            TitleBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            TitleForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            InactiveBorderColor = Properties.Settings.Default.THM_COL_MenuBack;
            ActiveBorderColor = Properties.Settings.Default.THM_COL_SelectedColor;
        }
        public void UpdateWindows() {
            RefreshWindows();
        }
        private void btnWinRefresh_Click(object sender, EventArgs e) {
            RefreshWindows();
        }
        private void btnWinMinimise_Click(object sender, EventArgs e) {
            object? Frm = GetForm();
            if (Frm == null) { return; }
                ((Form)Frm).WindowState = FormWindowState.Minimized;
        }
        private void btnWinHide_Click(object sender, EventArgs e) {
            object? Frm = GetForm();
            if (Frm == null) { return; }
            //if (Frm.GetType() == typeof(Form)) {
                ((Form)Frm).Visible = !((Form)Frm).Visible;
            // }
        }
        private void btnWinClose_Click(object sender, EventArgs e) {
            try {
                if (listView1.SelectedItems.Count >= 1) {
                    foreach (ListViewItem Lsi in listView1.SelectedItems) {
                        Classes.ApplicationManager.CloseInternalApplication(Lsi.SubItems[1].Text);
                    }
                }
            }
            catch { }
        }
        private void btnWinCloseAll_Click(object sender, EventArgs e) {
            try {
                if (listView1.Items.Count >= 1) {
                    foreach (ListViewItem Lsi in listView1.Items) {
                        Classes.ApplicationManager.CloseInternalApplication(Lsi.SubItems[1].Text);
                    }
                }
            }
            catch { }
        }
        private void RefreshWindows() {
            listView1.Items.Clear();
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc) {
                //if (frm.Name == this.Name) { }
                if (frm.Name == "MainWindow") { }
                else if (frm.Name == "SplashScreen") { }
                else {
                    ListViewItem Lvi = new ListViewItem();
                    Lvi.Text = frm.Text;
                    ListViewItem.ListViewSubItem Lvsi0 = new ListViewItem.ListViewSubItem();
                    Lvsi0.Text = frm.Name;
                    Lvi.Tag = frm;
                    Lvi.SubItems.Add(Lvsi0);
                    listView1.Items.Add(Lvi);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listView1.Items.Count >= 1) {
                btnWinCloseAll.Enabled = true;
                btnWinClose.Enabled = true;
            }
            else {
                btnWinCloseAll.Enabled = false;
                btnWinClose.Enabled = false;
            }
            btnWinHide.Text = "Hide";
            if (listView1.SelectedItems.Count == 1) {
                if (listView1.SelectedItems[0].SubItems[1].Text == this.Name) {
                    btnWinHide.Enabled = false;
                    btnWinMinimise.Enabled = false;
                }
                else {
                    object? Frm = GetForm();
                    if (Frm != null) {
                        //if (Frm.GetType() == typeof(Form)) {
                        bool IsVisable = ((Form)Frm).Visible;
                        if (IsVisable) {
                            btnWinHide.Text = "Hide";
                        }
                        else {
                            btnWinHide.Text = "Show";
                        }
                        //}
                    }
                    btnWinHide.Enabled = true;
                    btnWinMinimise.Enabled = true;
                }
            }
            else {
                btnWinMinimise.Enabled = false;
                btnWinHide.Enabled = false;
            }
        }
        private object? GetForm() {
            try {
                if (listView1.SelectedItems.Count == 1) {
                    if (listView1.SelectedItems[0].SubItems[1].Text != this.Name) {
                        if (listView1.SelectedItems[0].Tag != null) {
                            object? TagData = listView1.SelectedItems[0].Tag;
                            if (TagData == null) { return null; }
                            if (TagData.GetType().BaseType == typeof(Form)) {
                                return listView1.SelectedItems[0].Tag;
                            }
                        }
                    }
                }
            }
            catch { }
            return null;
        }

        private void WindowManager_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void WindowManager_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void WindowManager_FormClosed(object sender, FormClosedEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e) {
            try {
                if (listView1.SelectedItems.Count == 1) {
                    Classes.ApplicationManager.BringInternalApplicationToFront(listView1.SelectedItems[0].SubItems[1].Text);
                }
            }
            catch { }
        }
        private void btnFileExit_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
