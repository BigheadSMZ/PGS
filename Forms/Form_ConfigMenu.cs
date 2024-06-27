using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGS
{
    public partial class Form_ConfigMenu : Form
    {
        public Form_ConfigMenu()
        {
            InitializeComponent();
        }
        private void Monitor01NumBox_ValueChanged(object sender, EventArgs e)
        {
            Config.Monitor01_ID = this.Monitor01NumBox.Value.ToString();
        }
        private void Monitor02NumBox_ValueChanged(object sender, EventArgs e)
        {
            Config.Monitor02_ID = this.Monitor02NumBox.Value.ToString();
        }
        private void CountdownNumBox_ValueChanged(object sender, EventArgs e)
        {
            Config.Countdown = this.CountdownNumBox.Value.ToString();
        }
        private void NoTimerCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Config.NoTimer = this.NoTimerCheckbox.Checked;
        }
        private void NoGUICheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Config.NoGUI = this.NoGUICheckBox.Checked;
        }
        private void DesktopIconsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            Config.SaveIconPos = this.DesktopIconsCheckbox.Checked;
        }
        private void InfoButton_Click(object sender, EventArgs e)
        {
            Forms.InfoDialog.ShowDialog();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
