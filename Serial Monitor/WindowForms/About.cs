using ODModules;
using Serial_Monitor.Classes.Button_Commands;
using Serial_Monitor.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor {
    public partial class About : Components.SkinnedForm, Interfaces.ITheme, Interfaces.Application.IGenerics {
        public About() {
            InitializeComponent();
        }
        private const string AllRightsReserved = ". All Rights Reserved.";
        private void About_Load(object sender, EventArgs e) {
            lblProductName.Text = Application.ProductName;
            lblCompany.Text = Application.CompanyName;
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
      
            GetLoadedAssemblies();
            RecolorAll();
            lblVersion.Text = "Version " + fvi.ProductMajorPart + "." + fvi.ProductMinorPart.ToString() + " (Build " + fvi.ProductBuildPart.ToString() + ")";
            lblCopyright.Text = fvi.LegalCopyright + AllRightsReserved;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
        public void GetLoadedAssemblies() {
            Assembly[] assemblies = Thread.GetDomain().GetAssemblies();
            string ProductNume = Application.ProductName ?? "";
            for (int i = 0; i < assemblies.Length; i++) {
                string AssemblyName = assemblies[i].GetName().Name ?? "";
                if (AssemblyName.ToLower().StartsWith("system") || AssemblyName.ToLower().StartsWith("microsoft") || AssemblyName.ToLower().StartsWith("mscor")) { }
                else if (AssemblyName.ToLower().StartsWith(ProductNume.ToLower())) { }
                else if (AssemblyName.ToLower().StartsWith("netstandard")) { }
                else {
                    try {
                        FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assemblies[i].Location);
                        Label lbl = new Label();
                        lbl.Dock = DockStyle.Top;
                        lbl.Text = assemblies[i].GetName().Name + Handlers.Constants.NewLineEnv;
                        if (assemblies[i].GetName() != null) {
                            Version? Ver = assemblies[i].GetName().Version;
                            if (Ver != null) {
                                lbl.Text += Ver.ToString() + Handlers.Constants.NewLineEnv;
                            }
                        }
                        lbl.Text += versionInfo.LegalCopyright + Handlers.Constants.NewLineEnv + " ";
                        lbl.AutoSize = true;
                        pnlLoadedAssemblies.Controls.Add(lbl);
                    }
                    catch { }
                }
            }
        }

        private void About_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void About_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void About_FormClosed(object sender, FormClosedEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }

        public void ApplyTheme() {

            RecolorAll();
        }
        private void RecolorAll() {
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            aboutBanner1.BackColor = Properties.Settings.Default.THM_COL_MenuBack;
            aboutBanner1.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            TitleBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            TitleForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            InactiveBorderColor = Properties.Settings.Default.THM_COL_MenuBack;
            ActiveBorderColor = Properties.Settings.Default.THM_COL_SelectedColor;
            foreach(Control Ctrl in panel1.Controls) {
                if (Ctrl.GetType() == typeof(Label)) {
                    ((Label)Ctrl).ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                }
            }
            foreach (Control Ctrl in pnlLoadedAssemblies.Controls) {
                if (Ctrl.GetType() == typeof(Label)) {
                    ((Label)Ctrl).ForeColor = Properties.Settings.Default.THM_COL_ForeColor;
                }
            }
        }
        bool TopMostState = false;
        public void SetTopMost(bool State) {
            TopMostState = State;
            //topMostToolStripMenuItem.Checked = TopMostState;
            this.TopMost = State;
        }
    }
}
