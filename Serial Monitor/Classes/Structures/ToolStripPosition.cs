using Serial_Monitor.Classes.Modbus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serial_Monitor.Classes.Structures {
    internal class ToolStripPosition {
        public string FormObject { get; set; } = "";
        public string ToolStripObject { get; set; } = "";
        public Classes.Enums.ToolStripPosition Position { get; set; } = Classes.Enums.ToolStripPosition.Left;
        public decimal Location { get; set; } = 0.0m;
        public sbyte Line { get; set; } = 0;
        public bool Visible { get; set; } = true;
        public (string, string) GetSerialised() {
            string Locator = "";
            string SettingsLine = "";
            StringBuilder sb = new StringBuilder();
            sb.Append(FormObject);
            sb.Append(':');
            sb.Append(ToolStripObject);
            Locator = sb.ToString();
            sb.Append(',');
            sb.Append(Visible);
            sb.Append(',');
            sb.Append((byte)Position);
            sb.Append(',');
            sb.Append(Line);
            sb.Append(',');
            sb.Append(Location);
            SettingsLine = sb.ToString();
            return (Locator, SettingsLine);
        }
        public bool Deserialise(string Input) {
            Match RegMatch = Regex.Match(Input, @"(\w+):(\w+),(\w+),(\w+),(\w+),(\d+(?:\.\d+)?)");
            if (RegMatch.Success == false) { return false; }
            try {
                FormObject = RegMatch.Groups[1].Value;
                ToolStripObject = RegMatch.Groups[2].Value;
                bool vis = false;
                bool.TryParse(RegMatch.Groups[3].Value, out vis); Visible= vis;
                byte pos = 0x00;
                byte.TryParse(RegMatch.Groups[4].Value, out pos);
                if (pos >= 0x00 && pos< 0x03) { Position = (Classes.Enums.ToolStripPosition)pos; }
                sbyte lne = 0x00;
                sbyte.TryParse(RegMatch.Groups[5].Value, out lne);
                decimal dec = 0.0m;
                decimal.TryParse(RegMatch.Groups[6].Value, out dec);
                return true;
            }
            catch { return false; }
        }
    }
}
