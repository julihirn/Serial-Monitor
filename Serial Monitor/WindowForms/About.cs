using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Monitor {
    public partial class About : Form {
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
            lblVersion.Text = "Version " + fvi.ProductMajorPart + "." + fvi.ProductMinorPart.ToString() + " (Build " + fvi.ProductBuildPart.ToString() + ")";
            lblCopyright.Text = fvi.LegalCopyright + AllRightsReserved;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }
        public void GetLoadedAssemblies() {
            Assembly[] assemblies = Thread.GetDomain().GetAssemblies();

            for (int i = 0; i < assemblies.Length; i++) {
                string AssemblyName = assemblies[i].GetName().Name ?? "";
                if (AssemblyName.ToLower().StartsWith("system") || AssemblyName.ToLower().StartsWith("microsoft")) { }
                else if (AssemblyName.ToLower().StartsWith(Application.ProductName.ToLower())) { }
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
    }
}
