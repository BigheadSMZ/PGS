using System;
using System.Windows.Forms;

namespace PGS
{
    internal partial class Form_ShortMenu : Form
    {
        public Form_ShortMenu()
        {
            InitializeComponent();
        }
        private void ShortcutButtonClick(object sender, EventArgs e)
        {
            Functions.CreateShortcut();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ArgsToggleButton_Click(object sender, EventArgs e)
        {
            Forms.ArgumentsToggle();
        }
        private void ConfigButton_Click(object sender, EventArgs e)
        {
            Forms.ConfigDialog.ShowDialog();
        }
    }
}
