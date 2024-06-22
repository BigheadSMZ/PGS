namespace PGS
{
    partial class Form_ConfigMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ConfigMenu));
            this.ScreenConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.Monitor02NumBox = new System.Windows.Forms.NumericUpDown();
            this.Monitor01NumBox = new System.Windows.Forms.NumericUpDown();
            this.Monitor02Label = new System.Windows.Forms.Label();
            this.Monitor01Label = new System.Windows.Forms.Label();
            this.InfoButton = new System.Windows.Forms.Button();
            this.OptionsConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.DesktopIconsCheckbox = new System.Windows.Forms.CheckBox();
            this.CountdownNumBox = new System.Windows.Forms.NumericUpDown();
            this.CountdownLabel = new System.Windows.Forms.Label();
            this.NoGUICheckBox = new System.Windows.Forms.CheckBox();
            this.NoTimerCheckbox = new System.Windows.Forms.CheckBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.GlobalTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.ScreenConfigGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Monitor02NumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Monitor01NumBox)).BeginInit();
            this.OptionsConfigGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountdownNumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ScreenConfigGroupBox
            // 
            this.ScreenConfigGroupBox.Controls.Add(this.Monitor02NumBox);
            this.ScreenConfigGroupBox.Controls.Add(this.Monitor01NumBox);
            this.ScreenConfigGroupBox.Controls.Add(this.Monitor02Label);
            this.ScreenConfigGroupBox.Controls.Add(this.Monitor01Label);
            this.ScreenConfigGroupBox.Location = new System.Drawing.Point(10, 2);
            this.ScreenConfigGroupBox.Name = "ScreenConfigGroupBox";
            this.ScreenConfigGroupBox.Size = new System.Drawing.Size(178, 80);
            this.ScreenConfigGroupBox.TabIndex = 0;
            this.ScreenConfigGroupBox.TabStop = false;
            this.ScreenConfigGroupBox.Text = " Screen Identifiers ";
            this.GlobalTooltip.SetToolTip(this.ScreenConfigGroupBox, resources.GetString("ScreenConfigGroupBox.ToolTip"));
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
            this.Monitor02NumBox.TabIndex = 4;
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
            this.Monitor01NumBox.TabIndex = 3;
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
            this.Monitor02Label.TabIndex = 2;
            this.Monitor02Label.Text = "Secondary Monitor ID";
            this.GlobalTooltip.SetToolTip(this.Monitor02Label, "The monitor to show the game on.");
            // 
            // Monitor01Label
            // 
            this.Monitor01Label.Location = new System.Drawing.Point(6, 22);
            this.Monitor01Label.Name = "Monitor01Label";
            this.Monitor01Label.Size = new System.Drawing.Size(100, 18);
            this.Monitor01Label.TabIndex = 2;
            this.Monitor01Label.Text = "Primary Monitor ID";
            this.GlobalTooltip.SetToolTip(this.Monitor01Label, "The current primary monitor.");
            // 
            // InfoButton
            // 
            this.InfoButton.Image = global::PGS.Properties.Resources.monitor;
            this.InfoButton.Location = new System.Drawing.Point(10, 219);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(30, 25);
            this.InfoButton.TabIndex = 5;
            this.GlobalTooltip.SetToolTip(this.InfoButton, resources.GetString("InfoButton.ToolTip"));
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // OptionsConfigGroupBox
            // 
            this.OptionsConfigGroupBox.Controls.Add(this.DesktopIconsCheckbox);
            this.OptionsConfigGroupBox.Controls.Add(this.CountdownNumBox);
            this.OptionsConfigGroupBox.Controls.Add(this.CountdownLabel);
            this.OptionsConfigGroupBox.Controls.Add(this.NoGUICheckBox);
            this.OptionsConfigGroupBox.Controls.Add(this.NoTimerCheckbox);
            this.OptionsConfigGroupBox.Location = new System.Drawing.Point(10, 86);
            this.OptionsConfigGroupBox.Name = "OptionsConfigGroupBox";
            this.OptionsConfigGroupBox.Size = new System.Drawing.Size(178, 127);
            this.OptionsConfigGroupBox.TabIndex = 1;
            this.OptionsConfigGroupBox.TabStop = false;
            this.OptionsConfigGroupBox.Text = " Global Options ";
            this.GlobalTooltip.SetToolTip(this.OptionsConfigGroupBox, "Global options affect all games launched\r\nthrough PGS, and are not tied specifica" +
        "lly\r\nto game shortcuts. Changing any of the\r\noptions here will affect every shor" +
        "tcut.");
            // 
            // DesktopIconsCheckbox
            // 
            this.DesktopIconsCheckbox.Location = new System.Drawing.Point(6, 97);
            this.DesktopIconsCheckbox.Name = "DesktopIconsCheckbox";
            this.DesktopIconsCheckbox.Size = new System.Drawing.Size(168, 20);
            this.DesktopIconsCheckbox.TabIndex = 6;
            this.DesktopIconsCheckbox.Text = "Save/Restore Desktop Icons";
            this.GlobalTooltip.SetToolTip(this.DesktopIconsCheckbox, resources.GetString("DesktopIconsCheckbox.ToolTip"));
            this.DesktopIconsCheckbox.UseVisualStyleBackColor = true;
            this.DesktopIconsCheckbox.CheckedChanged += new System.EventHandler(this.DesktopIconsCheckbox_CheckedChanged);
            // 
            // CountdownNumBox
            // 
            this.CountdownNumBox.Location = new System.Drawing.Point(126, 20);
            this.CountdownNumBox.Margin = new System.Windows.Forms.Padding(0);
            this.CountdownNumBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.CountdownNumBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CountdownNumBox.Name = "CountdownNumBox";
            this.CountdownNumBox.Size = new System.Drawing.Size(40, 20);
            this.CountdownNumBox.TabIndex = 5;
            this.CountdownNumBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CountdownNumBox.ValueChanged += new System.EventHandler(this.CountdownNumBox_ValueChanged);
            // 
            // CountdownLabel
            // 
            this.CountdownLabel.Location = new System.Drawing.Point(6, 22);
            this.CountdownLabel.Name = "CountdownLabel";
            this.CountdownLabel.Size = new System.Drawing.Size(110, 18);
            this.CountdownLabel.TabIndex = 3;
            this.CountdownLabel.Text = "Timer Countdown";
            this.GlobalTooltip.SetToolTip(this.CountdownLabel, "The amount of time before the game\r\nautomatically starts if the timer is not\r\ndis" +
        "abled (which can be set below). ");
            // 
            // NoGUICheckBox
            // 
            this.NoGUICheckBox.Location = new System.Drawing.Point(6, 72);
            this.NoGUICheckBox.Name = "NoGUICheckBox";
            this.NoGUICheckBox.Size = new System.Drawing.Size(160, 20);
            this.NoGUICheckBox.TabIndex = 1;
            this.NoGUICheckBox.Text = "Immediately Launch Game";
            this.GlobalTooltip.SetToolTip(this.NoGUICheckBox, "Skips loading the PGS GUI and\r\nlaunches directly into the game.\r\nPGS still runs i" +
        "n the background\r\nwaiting for the game to close.");
            this.NoGUICheckBox.UseVisualStyleBackColor = true;
            this.NoGUICheckBox.CheckedChanged += new System.EventHandler(this.NoGUICheckBox_CheckedChanged);
            // 
            // NoTimerCheckbox
            // 
            this.NoTimerCheckbox.Location = new System.Drawing.Point(6, 47);
            this.NoTimerCheckbox.Name = "NoTimerCheckbox";
            this.NoTimerCheckbox.Size = new System.Drawing.Size(160, 20);
            this.NoTimerCheckbox.TabIndex = 0;
            this.NoTimerCheckbox.Text = "Disable Countdown Timer";
            this.GlobalTooltip.SetToolTip(this.NoTimerCheckbox, "Completely disable the timer. \r\nThe only way to start a game\r\n is to press the \"O" +
        "K\" button.");
            this.NoTimerCheckbox.UseVisualStyleBackColor = true;
            this.NoTimerCheckbox.CheckedChanged += new System.EventHandler(this.NoTimerCheckbox_CheckedChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(89, 219);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 25);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Form_ConfigMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 250);
            this.Controls.Add(this.InfoButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OptionsConfigGroupBox);
            this.Controls.Add(this.ScreenConfigGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(214, 289);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(214, 289);
            this.Name = "Form_ConfigMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGS Config";
            this.ScreenConfigGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Monitor02NumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Monitor01NumBox)).EndInit();
            this.OptionsConfigGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CountdownNumBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label Monitor01Label;
        public System.Windows.Forms.Label Monitor02Label;
        public System.Windows.Forms.NumericUpDown Monitor01NumBox;
        public System.Windows.Forms.NumericUpDown Monitor02NumBox;
        public System.Windows.Forms.Label CountdownLabel;
        public System.Windows.Forms.NumericUpDown CountdownNumBox;
        public System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ToolTip GlobalTooltip;
        public System.Windows.Forms.CheckBox NoGUICheckBox;
        public System.Windows.Forms.CheckBox NoTimerCheckbox;
        public System.Windows.Forms.Button InfoButton;
        public System.Windows.Forms.GroupBox OptionsConfigGroupBox;
        public System.Windows.Forms.GroupBox ScreenConfigGroupBox;
        public System.Windows.Forms.CheckBox DesktopIconsCheckbox;
    }
}