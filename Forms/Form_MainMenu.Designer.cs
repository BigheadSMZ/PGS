using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace PGS
{
    public partial class Form_MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MainMenu));
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.Monitor02NumBox = new System.Windows.Forms.NumericUpDown();
            this.Monitor01NumBox = new System.Windows.Forms.NumericUpDown();
            this.Monitor02 = new System.Windows.Forms.Label();
            this.Monitor01 = new System.Windows.Forms.Label();
            this.GameGroupBox = new System.Windows.Forms.GroupBox();
            this.GameTextBox = new System.Windows.Forms.TextBox();
            this.GameButton = new System.Windows.Forms.Button();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.InfoButton = new System.Windows.Forms.Button();
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
            this.MainGroupBox.Controls.Add(this.Monitor02);
            this.MainGroupBox.Controls.Add(this.Monitor01);
            this.MainGroupBox.Location = new System.Drawing.Point(10, 2);
            this.MainGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Padding = new System.Windows.Forms.Padding(0);
            this.MainGroupBox.Size = new System.Drawing.Size(178, 80);
            this.MainGroupBox.TabIndex = 0;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = " Screen Identifiers ";
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
            // Monitor02
            // 
            this.Monitor02.Location = new System.Drawing.Point(6, 47);
            this.Monitor02.Name = "Monitor02";
            this.Monitor02.Size = new System.Drawing.Size(110, 18);
            this.Monitor02.TabIndex = 1;
            this.Monitor02.Text = "Secondary Monitor ID";
            // 
            // Monitor01
            // 
            this.Monitor01.Location = new System.Drawing.Point(6, 22);
            this.Monitor01.Name = "Monitor01";
            this.Monitor01.Size = new System.Drawing.Size(100, 18);
            this.Monitor01.TabIndex = 0;
            this.Monitor01.Text = "Primary Monitor ID";
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
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.Location = new System.Drawing.Point(12, 147);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(16, 17);
            this.TimerLabel.TabIndex = 3;
            this.TimerLabel.Text = "5";
            // 
            // InfoButton
            // 
            this.InfoButton.Location = new System.Drawing.Point(55, 144);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(30, 25);
            this.InfoButton.TabIndex = 4;
            this.InfoButton.Text = "?";
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
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
            this.Text = "PGS v1.2.0";
            this.MainGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Monitor02NumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Monitor01NumBox)).EndInit();
            this.GameGroupBox.ResumeLayout(false);
            this.GameGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        public GroupBox MainGroupBox;
        public Label Monitor01;
        public GroupBox GameGroupBox;
        public Button GameButton;
        public Label Monitor02;
        public TextBox GameTextBox;
        public NumericUpDown Monitor01NumBox;
        public NumericUpDown Monitor02NumBox;
        public Label TimerLabel;
        public Button InfoButton;
    }
}

