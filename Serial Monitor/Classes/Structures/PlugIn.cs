using Serial_Monitor.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Structures {
    public class PlugIn {
        string address = "";
        public string Address {
            get { return address; }
        }
        IWindowPlugin? windowInstance = null;
        public IWindowPlugin? WindowInstance {
            get { return windowInstance; }
        }
        string name = "";
        public string Name {
            get { return name; }
        }
        public PlugIn(string Address) {
            this.address = Address;
            ReloadInstance();
        }
        public Form? LoadWindow() {
            if (windowInstance == null) { return null; }
            Form Frm = (Form)windowInstance;
            if (Frm.IsDisposed) {
                ReloadInstance();
                return LoadWindow();
            }
            else {
                return Frm;
            }
        }
        private void ReloadInstance() {
            windowInstance = null;
            if (!File.Exists(address)) { return; }
            Assembly assembly = Assembly.LoadFile(address);
            var types = assembly.GetExportedTypes();

            foreach (Type type in types) {
                try {
                    if (type.GetInterfaces().Contains(typeof(IWindowPlugin))) {
                        object? instance = Activator.CreateInstance(type);
                        if (instance != null) {
                            windowInstance = (IWindowPlugin)instance;
                            if (windowInstance != null) {
                                name = ((Form)windowInstance).Text;
                            }
                            break;
                        }
                    }
                }
                catch { }
            }
        }
    }
}
