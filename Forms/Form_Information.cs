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
    internal partial class Form_ScreenInfo : Form
    {
        public Form_ScreenInfo()
        {
            InitializeComponent();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
