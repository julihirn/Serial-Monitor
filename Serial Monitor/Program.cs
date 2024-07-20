using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Theming;
using System.Diagnostics;

namespace Serial_Monitor {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // SystemManager.Initialize();
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
            ThemeManager.LoadDefaultThemes();
            if (args.Length > 0){
                Application.Run(new MainWindow(args[0]));
            }
            else {
                Application.Run(new MainWindow());
            }
            //Application.Run(new Form2());
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}