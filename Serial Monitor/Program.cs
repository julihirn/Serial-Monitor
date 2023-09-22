using Serial_Monitor.Classes.Theming;

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
            ThemeManager.LoadDefaultThemes();
            if (args.Length > 0){
                Application.Run(new MainWindow(args[0]));
            }
            else {
                Application.Run(new MainWindow());
            }
            //Application.Run(new Form2());
        }
    }
}