namespace PGS
{
    internal partial class Form_ShortMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ShortMenu));
            this.ShortcutGroupBox = new System.Windows.Forms.GroupBox();
            this.ShortcutLabel = new System.Windows.Forms.Label();
            this.ShortcutButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ArgumentsGroupBox = new System.Windows.Forms.GroupBox();
            this.ArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.ArgsToggleButton = new System.Windows.Forms.Button();
            this.GlobalToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ConfigButton = new System.Windows.Forms.Button();
            this.ShortcutGroupBox.SuspendLayout();
            this.ArgumentsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShortcutGroupBox
            // 
            this.ShortcutGroupBox.Controls.Add(this.ShortcutLabel);
            this.ShortcutGroupBox.Controls.Add(this.ShortcutButton);
            this.ShortcutGroupBox.Location = new System.Drawing.Point(10, 2);
            this.ShortcutGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.ShortcutGroupBox.Name = "ShortcutGroupBox";
            this.ShortcutGroupBox.Padding = new System.Windows.Forms.Padding(0);
            this.ShortcutGroupBox.Size = new System.Drawing.Size(178, 138);
            this.ShortcutGroupBox.TabIndex = 0;
            this.ShortcutGroupBox.TabStop = false;
            this.ShortcutGroupBox.Text = " Create Shortcut ";
            this.GlobalToolTip.SetToolTip(this.ShortcutGroupBox, "This section creates a shortcut to PGS using \r\nthe game executable as an argument" +
        ". To send\r\nadditional arguments to the game executable,\r\nclick the arrow button " +
        "and use the text box.");
            // 
            // ShortcutLabel
            // 
            this.ShortcutLabel.Location = new System.Drawing.Point(8, 22);
            this.ShortcutLabel.Name = "ShortcutLabel";
            this.ShortcutLabel.Size = new System.Drawing.Size(164, 81);
            this.ShortcutLabel.TabIndex = 1;
            this.ShortcutLabel.Text = "This program works by creating a shortcut to a game executable and then launching" +
    " that shortcut. From that menu the primary and secondary screens can be set.";
            // 
            // ShortcutButton
            // 
            this.ShortcutButton.Location = new System.Drawing.Point(26, 103);
            this.ShortcutButton.Name = "ShortcutButton";
            this.ShortcutButton.Size = new System.Drawing.Size(125, 25);
            this.ShortcutButton.TabIndex = 0;
            this.ShortcutButton.Text = "Select Executable";
            this.GlobalToolTip.SetToolTip(this.ShortcutButton, "Click to select a game executable to create\r\na shortcut for. After selection, an " +
        "additional\r\nwindow will open to set the save location of\r\nthe new shortcut (defa" +
        "ults to the Desktop).");
            this.ShortcutButton.UseVisualStyleBackColor = true;
            this.ShortcutButton.Click += new System.EventHandler(this.ShortcutButtonClick);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(89, 199);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 25);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ArgumentsGroupBox
            // 
            this.ArgumentsGroupBox.Controls.Add(this.ArgumentsTextBox);
            this.ArgumentsGroupBox.Location = new System.Drawing.Point(13, 143);
            this.ArgumentsGroupBox.Name = "ArgumentsGroupBox";
            this.ArgumentsGroupBox.Size = new System.Drawing.Size(175, 50);
            this.ArgumentsGroupBox.TabIndex = 2;
            this.ArgumentsGroupBox.TabStop = false;
            this.ArgumentsGroupBox.Text = " Game Arguments ";
            this.GlobalToolTip.SetToolTip(this.ArgumentsGroupBox, resources.GetString("ArgumentsGroupBox.ToolTip"));
            // 
            // ArgumentsTextBox
            // 
            this.ArgumentsTextBox.Location = new System.Drawing.Point(6, 19);
            this.ArgumentsTextBox.Name = "ArgumentsTextBox";
            this.ArgumentsTextBox.Size = new System.Drawing.Size(163, 20);
            this.ArgumentsTextBox.TabIndex = 0;
            // 
            // ArgsToggleButton
            // 
            this.ArgsToggleButton.Image = global::PGS.Properties.Resources.arrowup;
            this.ArgsToggleButton.Location = new System.Drawing.Point(10, 199);
            this.ArgsToggleButton.Name = "ArgsToggleButton";
            this.ArgsToggleButton.Size = new System.Drawing.Size(28, 25);
            this.ArgsToggleButton.TabIndex = 3;
            this.ArgsToggleButton.UseVisualStyleBackColor = true;
            this.ArgsToggleButton.Click += new System.EventHandler(this.ArgsToggleButton_Click);
            // 
            // GlobalToolTip
            // 
            this.GlobalToolTip.AutomaticDelay = 1000;
            this.GlobalToolTip.AutoPopDelay = 10000;
            this.GlobalToolTip.InitialDelay = 1000;
            this.GlobalToolTip.ReshowDelay = 250;
            // 
            // ConfigButton
            // 
            this.ConfigButton.Image = ((System.Drawing.Image)(resources.GetObject("ConfigButton.Image")));
            this.ConfigButton.Location = new System.Drawing.Point(40, 199);
            this.ConfigButton.Name = "ConfigButton";
            this.ConfigButton.Size = new System.Drawing.Size(30, 25);
            this.ConfigButton.TabIndex = 7;
            this.GlobalToolTip.SetToolTip(this.ConfigButton, "Open the configuration menu.");
            this.ConfigButton.UseVisualStyleBackColor = true;
            this.ConfigButton.Click += new System.EventHandler(this.ConfigButton_Click);
            // 
            // Form_ShortMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 230);
            this.Controls.Add(this.ConfigButton);
            this.Controls.Add(this.ArgsToggleButton);
            this.Controls.Add(this.ArgumentsGroupBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ShortcutGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(214, 269);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(214, 269);
            this.Name = "Form_ShortMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGS v1.4.1";
            this.ShortcutGroupBox.ResumeLayout(false);
            this.ArgumentsGroupBox.ResumeLayout(false);
            this.ArgumentsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button ShortcutButton;
        public System.Windows.Forms.Label ShortcutLabel;
        public System.Windows.Forms.GroupBox ShortcutGroupBox;
        public System.Windows.Forms.Button CloseButton;
        public System.Windows.Forms.GroupBox ArgumentsGroupBox;
        public System.Windows.Forms.TextBox ArgumentsTextBox;
        public System.Windows.Forms.Button ArgsToggleButton;
        public System.Windows.Forms.ToolTip GlobalToolTip;
        public System.Windows.Forms.Button ConfigButton;
    }
}