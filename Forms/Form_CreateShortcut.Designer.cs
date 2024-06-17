namespace PGS
{
    partial class Form_ShortMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ShortMenu));
            this.ShortcutGroupBox = new System.Windows.Forms.GroupBox();
            this.ShortcutLabel = new System.Windows.Forms.Label();
            this.ShortcutButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ShortcutGroupBox.SuspendLayout();
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
            // 
            // ShortcutLabel
            // 
            this.ShortcutLabel.Location = new System.Drawing.Point(8, 20);
            this.ShortcutLabel.Name = "ShortcutLabel";
            this.ShortcutLabel.Size = new System.Drawing.Size(164, 77);
            this.ShortcutLabel.TabIndex = 1;
            this.ShortcutLabel.Text = "This program works by creating a shortcut to a game executable, then that shortcu" +
    "t is launched. From there the primary and secondary screens can be set.\r\n\r\n";
            // 
            // ShortcutButton
            // 
            this.ShortcutButton.Location = new System.Drawing.Point(29, 100);
            this.ShortcutButton.Name = "ShortcutButton";
            this.ShortcutButton.Size = new System.Drawing.Size(125, 23);
            this.ShortcutButton.TabIndex = 0;
            this.ShortcutButton.Text = "Select Executable";
            this.ShortcutButton.UseVisualStyleBackColor = true;
            this.ShortcutButton.Click += new System.EventHandler(this.ShortcutButtonClick);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(89, 144);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 25);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Form_ShortMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 175);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ShortcutGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(214, 214);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(214, 214);
            this.Name = "Form_ShortMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGS v1.2.0";
            this.ShortcutGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button ShortcutButton;
        public System.Windows.Forms.Label ShortcutLabel;
        public System.Windows.Forms.GroupBox ShortcutGroupBox;
        public System.Windows.Forms.Button CloseButton;
    }
}