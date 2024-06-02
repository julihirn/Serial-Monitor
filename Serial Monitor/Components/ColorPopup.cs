using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Handlers;
using ODModules;
using Serial_Monitor.Classes.Theming;
using Serial_Monitor.Interfaces;
namespace Serial_Monitor.Components {
    public partial class ColorPopup : TemplateContextMenu, Interfaces.ITheme {
        public TemplateContextMenuHost ?Host = null;
        public ColorPopup(bool IncludeAlphas) {
            InitializeComponent();
            CreateColours(IncludeAlphas);
            ApplyTheme();
        }
        private void CreateColours(bool IncludeAlphas) {
            btnColorGrid.Buttons.Clear();
            CreateButton(true);
            CycleGrays(255, 7);
            CycleHue(255, 12, 5);
            if (IncludeAlphas) {
                CycleHue(200, 12, 5);
                CycleHue(150, 12, 5);
                CycleHue(100, 12, 5);
                CycleHue(50, 12, 5);
                CycleHue(25, 12, 5);
            }
        }
        private void CycleHue(float S, float V) {
            for (int i = 0; i < 301; i += 5) {
                HSV Temp = new HSV((float)i, S, V);
                CreateButton(Temp.ToColor());
            }
        }
        private void CycleGrays(int Alpha, int Steps) {
            for (int i = 0; i < Steps; i ++) {
                float V = i / (float)Steps;
                HSV Temp = new HSV(Alpha, 0.0f, 0.0f, V);
                CreateButton(Temp.ToColor());
            }
            CreateButton(Color.White);
        }
        private void CycleHue(int Alpha, int HueSteps, int BrightnessSteps) {
            int FullSpan = (BrightnessSteps * 2);
            for (int i = 0; i < 301; i += HueSteps) {
                for (int j = 1; j < FullSpan; j++) {
                    float S = 0.0f;
                    float V = 0.0f;
                    if (j >= BrightnessSteps) { S = 1.0f; }
                    else { S = j/ (float)BrightnessSteps; }
                    if (j <= BrightnessSteps) { V = 1.0f; }
                    else { V = 1.0f - ((j- BrightnessSteps) / (float)BrightnessSteps); }
                    HSV Temp = new HSV(Alpha, (float)i, S, V);
                    CreateButton(Temp.ToColor());
                }
            }
        }
        private void CreateButton(bool Reset) {
            CreateButton(Color.Transparent, Reset);
        }
        private void CreateButton(Color DisplayColor, bool Reset = false) {
            GridButton GrdBtn = new GridButton();
            if (Reset == false) {
                GrdBtn.BackColorNorth = DisplayColor;
                GrdBtn.BackColorSouth = DisplayColor;
                GrdBtn.Tag = DisplayColor;
                GrdBtn.UseCustomColors = true;
            }
            else {
                GrdBtn.Tag = null;
            }
            btnColorGrid.Buttons.Add(GrdBtn);
        }
        public void ApplyTheme() {
            BackColor = Properties.Settings.Default.THM_COL_SeconaryBackColor;
            ThemeManager.ThemeControl(btnColorGrid, true);
            foreach (GridButton iGBtn in btnColorGrid.Buttons) {
                iGBtn.BorderColorNorth = Properties.Settings.Default.THM_COL_BorderColor;
                iGBtn.BorderColorSouth = Properties.Settings.Default.THM_COL_BorderColor;
            }
        }
        protected override void OnValidated(EventArgs e) {
            base.OnValidated(e);
        }

        protected override void OnValidating(CancelEventArgs e) {
            //ApplyTheme();
            base.OnValidating(e);
        }
        protected override void OnVisibleChanged(EventArgs e) {
            ApplyTheme();
            base.OnVisibleChanged(e);
        }
        bool CurrentEditorBack = true;
        bool IgnoreChanges = false;
        private void buttonGrid1_Load(object sender, EventArgs e) {

        }
        Color selectedColor = Color.White;
        public Color SelectedColor {
            get { return selectedColor; }
            set { selectedColor = value; }
        }
        bool applyColor = false;
        public bool ApplyColor {
            get { return applyColor; }
            set { applyColor = value; }
        }
        bool isValid = false;
        public bool IsValid {
            get { return isValid; }
        }
        private void btnColorGrid_ButtonClicked(object Sender, GridButton Button, Point GridLocation) {
            if (Button.Tag == null) {
                applyColor = false;
            }
            else {
                if (Button.Tag.GetType() == typeof(Color)) {
                    applyColor = true;
                    selectedColor = (Color)Button.Tag;
                }
                else {
                    applyColor = false;
                }
            }
            if (Host != null) {
                isValid = true;
                Host.Close();
            }
        }
        public void ResetState() {
            isValid = false;
            btnColorGrid.Invalidate();
        }
    }
}
