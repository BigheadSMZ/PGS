﻿using System.Windows.Forms;

namespace PGS
{
    internal partial class Form_MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MainMenu));
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.Monitor02NumBox = new System.Windows.Forms.NumericUpDown();
            this.Monitor01NumBox = new System.Windows.Forms.NumericUpDown();
            this.Monitor02Label = new System.Windows.Forms.Label();
            this.Monitor01Label = new System.Windows.Forms.Label();
            this.GameGroupBox = new System.Windows.Forms.GroupBox();
            this.GameTextBox = new System.Windows.Forms.TextBox();
            this.GameButton = new System.Windows.Forms.Button();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.InfoButton = new System.Windows.Forms.Button();
            this.GlobalTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.MainGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Monitor02NumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Monitor01NumBox)).BeginInit();
            this.GameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.Monitor02NumBox);
            this.MainGroupBox.Controls.Add(this.Monitor01NumBox);
            this.MainGroupBox.Controls.Add(this.Monitor02Label);
            this.MainGroupBox.Controls.Add(this.Monitor01Label);
            this.MainGroupBox.Location = new System.Drawing.Point(10, 2);
            this.MainGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Padding = new System.Windows.Forms.Padding(0);
            this.MainGroupBox.Size = new System.Drawing.Size(178, 80);
            this.MainGroupBox.TabIndex = 0;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = " Screen Identifiers ";
            this.GlobalTooltip.SetToolTip(this.MainGroupBox, resources.GetString("MainGroupBox.ToolTip"));
            // 
            // Monitor02NumBox
            // 
            this.Monitor02NumBox.Location = new System.Drawing.Point(126, 45);
            this.Monitor02NumBox.Margin = new System.Windows.Forms.Padding(0);
            this.Monitor02NumBox.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Monitor02NumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Monitor02NumBox.Name = "Monitor02NumBox";
            this.Monitor02NumBox.Size = new System.Drawing.Size(40, 20);
            this.Monitor02NumBox.TabIndex = 3;
            this.Monitor02NumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Monitor02NumBox.ValueChanged += new System.EventHandler(this.Monitor02NumBox_ValueChanged);
            // 
            // Monitor01NumBox
            // 
            this.Monitor01NumBox.Location = new System.Drawing.Point(126, 20);
            this.Monitor01NumBox.Margin = new System.Windows.Forms.Padding(0);
            this.Monitor01NumBox.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Monitor01NumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Monitor01NumBox.Name = "Monitor01NumBox";
            this.Monitor01NumBox.Size = new System.Drawing.Size(40, 20);
            this.Monitor01NumBox.TabIndex = 2;
            this.Monitor01NumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Monitor01NumBox.ValueChanged += new System.EventHandler(this.Monitor01NumBox_ValueChanged);
            // 
            // Monitor02Label
            // 
            this.Monitor02Label.Location = new System.Drawing.Point(6, 47);
            this.Monitor02Label.Name = "Monitor02Label";
            this.Monitor02Label.Size = new System.Drawing.Size(110, 18);
            this.Monitor02Label.TabIndex = 1;
            this.Monitor02Label.Text = "Secondary Monitor ID";
            this.GlobalTooltip.SetToolTip(this.Monitor02Label, "The monitor to show the game on.");
            // 
            // Monitor01Label
            // 
            this.Monitor01Label.Location = new System.Drawing.Point(6, 22);
            this.Monitor01Label.Name = "Monitor01Label";
            this.Monitor01Label.Size = new System.Drawing.Size(100, 18);
            this.Monitor01Label.TabIndex = 0;
            this.Monitor01Label.Text = "Primary Monitor ID";
            this.GlobalTooltip.SetToolTip(this.Monitor01Label, "The current primary monitor.");
            // 
            // GameGroupBox
            // 
            this.GameGroupBox.Controls.Add(this.GameTextBox);
            this.GameGroupBox.Location = new System.Drawing.Point(10, 86);
            this.GameGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.GameGroupBox.Name = "GameGroupBox";
            this.GameGroupBox.Padding = new System.Windows.Forms.Padding(0);
            this.GameGroupBox.Size = new System.Drawing.Size(178, 54);
            this.GameGroupBox.TabIndex = 1;
            this.GameGroupBox.TabStop = false;
            this.GameGroupBox.Text = " Game Executable ";
            this.GlobalTooltip.SetToolTip(this.GameGroupBox, "The game executable and any arguments from\r\nthe shortcut or passed via the comman" +
        "d line.");
            // 
            // GameTextBox
            // 
            this.GameTextBox.BackColor = System.Drawing.Color.White;
            this.GameTextBox.Location = new System.Drawing.Point(10, 22);
            this.GameTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.GameTextBox.Name = "GameTextBox";
            this.GameTextBox.ReadOnly = true;
            this.GameTextBox.Size = new System.Drawing.Size(158, 20);
            this.GameTextBox.TabIndex = 0;
            // 
            // GameButton
            // 
            this.GameButton.Location = new System.Drawing.Point(89, 144);
            this.GameButton.Margin = new System.Windows.Forms.Padding(0);
            this.GameButton.Name = "GameButton";
            this.GameButton.Size = new System.Drawing.Size(100, 25);
            this.GameButton.TabIndex = 2;
            this.GameButton.Text = "OK";
            this.GameButton.UseVisualStyleBackColor = true;
            this.GameButton.Click += new System.EventHandler(this.GameButton_Click);
            // 
            // TimerLabel
            // 
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.Location = new System.Drawing.Point(54, 148);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(16, 17);
            this.TimerLabel.TabIndex = 3;
            this.TimerLabel.Text = "0";
            this.TimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GlobalTooltip.SetToolTip(this.TimerLabel, "Game is starting...");
            // 
            // InfoButton
            // 
            this.InfoButton.Image = global::PGS.Properties.Resources.monitor;
            this.InfoButton.Location = new System.Drawing.Point(10, 144);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(30, 25);
            this.InfoButton.TabIndex = 4;
            this.GlobalTooltip.SetToolTip(this.InfoButton, resources.GetString("InfoButton.ToolTip"));
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // GlobalTooltip
            // 
            this.GlobalTooltip.AutomaticDelay = 1000;
            this.GlobalTooltip.AutoPopDelay = 10000;
            this.GlobalTooltip.InitialDelay = 1000;
            this.GlobalTooltip.ReshowDelay = 250;
            // 
            // Form_MainMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(198, 175);
            this.Controls.Add(this.InfoButton);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.GameButton);
            this.Controls.Add(this.GameGroupBox);
            this.Controls.Add(this.MainGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(214, 214);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(214, 214);
            this.Name = "Form_MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGS";
            this.MainGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Monitor02NumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Monitor01NumBox)).EndInit();
            this.GameGroupBox.ResumeLayout(false);
            this.GameGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        public GroupBox MainGroupBox;
        public Label Monitor01Label;
        public GroupBox GameGroupBox;
        public Button GameButton;
        public Label Monitor02Label;
        public TextBox GameTextBox;
        public NumericUpDown Monitor01NumBox;
        public NumericUpDown Monitor02NumBox;
        public Label TimerLabel;
        public Button InfoButton;
        public ToolTip GlobalTooltip;
    }
}

