﻿using System;
using System.Windows.Forms;

namespace PGS
{
    public partial class Form_MainMenu : Form
    {
        public Form_MainMenu()
        {
            InitializeComponent();
        }
        private void GameButton_Click(object sender, EventArgs e)
        {
            Functions.SetPrimaryAndLaunch();
        }
        private void Monitor01NumBox_ValueChanged(object sender, EventArgs e)
        {
            Globals.Monitor01_ID = this.Monitor01NumBox.Value.ToString();
        }
        private void Monitor02NumBox_ValueChanged(object sender, EventArgs e)
        {
            Globals.Monitor02_ID = this.Monitor02NumBox.Value.ToString();
        }
    }
}