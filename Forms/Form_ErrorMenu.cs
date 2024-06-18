using System;
using System.Windows.Forms;

namespace PGS
{
    internal partial class Form_ErrorMenu : Form
    {
        public Form_ErrorMenu()
        {
            InitializeComponent();
        }
        private void ErrorButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}