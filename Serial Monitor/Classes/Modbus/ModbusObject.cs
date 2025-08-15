using Handlers;
using Serial_Monitor.Classes.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Modbus {
    public class ModbusObject {
        string name = "";
        public string Name {
            get { return name; }
            set { name = value; }
        }
        Color backColor = Color.White;
        Color backColorDark = Color.Black;
        public Color BackColor {
            get {
                if (ThemeManager.IsDark) {
                    return backColorDark;
                }
                return backColor;
            }
            set {
                if (ThemeManager.IsDark) {
                    backColorDark = value;
                    backColor = DesignerSetup.InvertAndRotate180(value);
                }
                else {
                    backColor = value;
                    backColorDark = DesignerSetup.InvertAndRotate180(value);
                }
            }
        }
        Color foreColor = Color.Black;
        Color foreColorDark = Color.White;
        public Color ForeColor {
            get {
                if (ThemeManager.IsDark) {
                    return foreColorDark;
                }
                return foreColor;
            }
            set {
                if (ThemeManager.IsDark) {
                    foreColorDark = value;
                    foreColor = DesignerSetup.InvertAndRotate180(value); ;
                }
                else {
                    foreColor = value;
                    foreColorDark = DesignerSetup.InvertAndRotate180(value);
                }
            }
        }
        public Color GetThemeIndependantBackColor() {
            return backColor;
        }
        public Color GetThemeIndependantForeColor() {
            return foreColor;
        }
        public void SetThemeIndependantBackColor(Color Input) {
            backColor = Input;
            backColorDark = DesignerSetup.InvertAndRotate180(Input);
        }
        public void SetThemeIndependantForeColor(Color Input) {
            foreColor = Input;
            foreColorDark = DesignerSetup.InvertAndRotate180(Input);

        }
        bool useBackColor = false;
        public bool UseBackColor {
            get { return useBackColor; }
            set { useBackColor = value; }
        }
        bool useForeColor = false;
        public bool UseForeColor {
            get { return useForeColor; }
            set { useForeColor = value; }
        }
        private DateTime lastUpdated = DateTime.MinValue;
        public DateTime LastUpdated {
            get { return lastUpdated; }
        }
        private protected void UpdateLastUpdate() {
            lastUpdated = DateTime.Now;
        }
        protected internal string GetLastUpdatedTime() {
            if (lastUpdated == DateTime.MinValue) { return "Never"; }
            return lastUpdated.ToString("yyyy/MM/dd HH:mm:ss.fff");
        }
    }
}
