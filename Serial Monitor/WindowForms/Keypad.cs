using Handlers;
using ODModules;
using Serial_Monitor.Classes;
using Serial_Monitor.Classes.Button_Commands;
using Serial_Monitor.Classes.Step_Programs;
using Serial_Monitor.WindowForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Serial_Monitor {
    public partial class Keypad : Form, Interfaces.ITheme, Interfaces.Application.IGenerics {
        public Keypad() {
            InitializeComponent();
            if (DesignerSetup.IsWindows10OrGreater() == true) {
                DesignerSetup.UseImmersiveDarkMode(this.Handle, true);
            }
        }

        private void Keypad_Load(object sender, EventArgs e) {
            kpCommands.ImageSize = new Size(DesignerSetup.MediumIconSize, DesignerSetup.MediumIconSize);
            kpCommands.ExternalItems = Classes.ProjectManager.Buttons;
            RecolorAll();
            ProjectManager.ButtonPropertyChanged += ProjectManager_ButtonPropertyChanged;
        }
        private void Keypad_FormClosing(object sender, FormClosingEventArgs e) {
            ProjectManager.ButtonPropertyChanged -= ProjectManager_ButtonPropertyChanged;
        }
        private void ProjectManager_ButtonPropertyChanged(KeypadButton sender) {
            kpCommands.Invalidate();
        }

        private void keypad1_ButtonClicked(object Sender, ODModules.KeypadButton Button, Point GridLocation, int Index) {
            if (Button.Tag == null) { return; }
            if (Button.Tag.GetType() == typeof(BtnCommand)) {
                BtnCommand btnCommand = (BtnCommand)Button.Tag;
                if (btnCommand.Type == Classes.Button_Commands.CommandType.SendString) {
                    SystemManager.SendString(btnCommand.Channel, btnCommand.CommandLine);
                }
                else if (btnCommand.Type == Classes.Button_Commands.CommandType.SendText) {
                    SystemManager.SendTextFile(btnCommand.Channel, btnCommand.CommandLine);
                }
                else if (btnCommand.Type == Classes.Button_Commands.CommandType.ExecuteProgram) {
                    ProgramManager.ExecuteProgram(btnCommand.CommandLine);
                }
            }
        }

        private void kpCommands_ButtonRightClicked(object Sender, ODModules.KeypadButton Button, Point GridLocation, int Index) {
            if (Button.Tag == null) { return; }
            if (Button.Tag.GetType() == typeof(BtnCommand)) {
                BtnCommand btnCommand = (BtnCommand)Button.Tag;
                //KeypadButtonProperties KpbtnProp = new KeypadButtonProperties();
                //KpbtnProp.Command = btnCommand.CommandLine;
                //KpbtnProp.ButtonName = Button.Text;
                //KpbtnProp.ShowDialog();

                //if (KpbtnProp.DialogResult == DialogResult.OK) {
                //    btnCommand.CommandLine = KpbtnProp.Command;
                //    btnCommand.Type = KpbtnProp.CommandType;
                //    Button.Text = KpbtnProp.ButtonName;
                //}

                if (pnlProperties.Visible == false) {
                    SuspendLayout();
                    int PropertyPaneWidth = pnlProperties.Width;
                    this.Width += PropertyPaneWidth;
                    pnlProperties.Show();
                    ResumeLayout();
                }
                kpCommands.MarkedIndex = Index;
                propertyGrid1.SelectedObject = btnCommand;
                kpCommands.Invalidate();
            }
        }
        public void ApplyTheme() {

            RecolorAll();
        }
        private void RecolorAll() {
            BackColor = Properties.Settings.Default.THM_COL_Editor;
            kpCommands.BackColor = Properties.Settings.Default.THM_COL_Editor;
            kpCommands.BackColorNorth = Properties.Settings.Default.THM_COL_MenuBack;
            kpCommands.BackColorSouth = Properties.Settings.Default.THM_COL_MenuBack;
            kpCommands.ForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            Classes.Theming.ThemeManager.ThemeControl(msMain);

            //kpCommands.ScrollBarNorth = Properties.Settings.Default.THM_COL_ScrollColor;
            //kpCommands.ScrollBarSouth = Properties.Settings.Default.THM_COL_ScrollColor;
            kpCommands.BorderColorNorth = Properties.Settings.Default.THM_COL_BorderColor;
            kpCommands.BorderColorSouth = Properties.Settings.Default.THM_COL_BorderColor;

            kpCommands.BackColorHoverNorth = Properties.Settings.Default.THM_COL_ButtonSelected;
            kpCommands.BackColorHoverSouth = Properties.Settings.Default.THM_COL_ButtonSelected;

            propertyGrid1.ViewBackColor = Properties.Settings.Default.THM_COL_Editor;
            propertyGrid1.LineColor = Properties.Settings.Default.THM_COL_MenuBack;
            propertyGrid1.CategoryForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            propertyGrid1.ViewForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            propertyGrid1.DisabledItemForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            propertyGrid1.CategorySplitterColor = Properties.Settings.Default.THM_COL_GridLineColor;
            propertyGrid1.ViewBorderColor = Properties.Settings.Default.THM_COL_GridLineColor;
            propertyGrid1.BackColor = Properties.Settings.Default.THM_COL_Editor;
            propertyGrid1.CommandsBackColor = Properties.Settings.Default.THM_COL_Editor;
            propertyGrid1.HelpBackColor = Properties.Settings.Default.THM_COL_Editor;
            // propertyGrid1.color = Properties.Settings.Default.THM_COL_Editor;

            propertyGrid1.SelectedItemWithFocusBackColor = Properties.Settings.Default.THM_COL_SelectedColor;
            propertyGrid1.SelectedItemWithFocusForeColor = Properties.Settings.Default.THM_COL_ForeColor;

            pnlProperties.LabelForeColor = Properties.Settings.Default.THM_COL_ForeColor;
            pnlProperties.ArrowColor = Properties.Settings.Default.THM_COL_ForeColor;
            pnlProperties.CloseColor = Properties.Settings.Default.THM_COL_ForeColor;
            pnlProperties.LabelBackColor = Properties.Settings.Default.THM_COL_MenuBack;
            pnlProperties.BackColor = Properties.Settings.Default.THM_COL_Editor;

            kpCommands.BackColorMarkedNorth = Properties.Settings.Default.THM_COL_SelectedColor;
            kpCommands.BackColorMarkedSouth = Properties.Settings.Default.THM_COL_SelectedColor;

            kpCommands.BorderColorMarkedNorth = Properties.Settings.Default.THM_COL_BorderColor;
            kpCommands.BorderColorMarkedSouth = Properties.Settings.Default.THM_COL_BorderColor;

            foreach (KeypadButton Kbtn in ProjectManager.Buttons) {
                if (Kbtn.Tag != null) {
                    if (Kbtn.Tag.GetType() == typeof(BtnCommand)) {
                        BtnCommand btnCommand = (BtnCommand)Kbtn.Tag;
                        BtnCommand.SetDisplaySymbol(btnCommand.DisplaySymbol, Kbtn);
                    }
                }
            }
        }

        private void pnlProperties_CloseButtonClicked(object sender, Point HitPoint) {
            kpCommands.MarkedIndex = -1;
            if (this.WindowState == FormWindowState.Normal) {

                SuspendLayout();
                int PropertyPaneWidth = pnlProperties.Width;
                pnlProperties.Hide();
                pnlProperties.Invalidate();
                this.Width -= PropertyPaneWidth;
                ResumeLayout();
            }
        }

        private void Keypad_KeyDown(object sender, KeyEventArgs e) {
            if (pnlProperties.Visible == false) {
                kpCommands.Focus();
            }
        }

        private void Keypad_VisibleChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void Keypad_SizeChanged(object sender, EventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }
        private void Keypad_FormClosed(object sender, FormClosedEventArgs e) {
            Classes.ApplicationManager.InvokeApplicationEvent();
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e) {
            ProjectManager.KeypadTopMost = !ProjectManager.KeypadTopMost;
        }
        bool TopMostState = false;
        public void SetTopMost(bool State) {
            TopMostState = State;
            topMostToolStripMenuItem.Checked = TopMostState;
            this.TopMost = State;
        }
    }
}
