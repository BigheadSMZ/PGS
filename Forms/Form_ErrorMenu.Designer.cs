namespace PGS
{
    internal partial class Form_ErrorMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ErrorMenu));
            this.ErrorGroupBox = new System.Windows.Forms.GroupBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.ErrorButton = new System.Windows.Forms.Button();
            this.ErrorGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ErrorGroupBox
            // 
            this.ErrorGroupBox.Controls.Add(this.ErrorLabel);
            this.ErrorGroupBox.Location = new System.Drawing.Point(10, 2);
            this.ErrorGroupBox.Name = "ErrorGroupBox";
            this.ErrorGroupBox.Size = new System.Drawing.Size(178, 138);
            this.ErrorGroupBox.TabIndex = 0;
            this.ErrorGroupBox.TabStop = false;
            this.ErrorGroupBox.Text = " Error Message";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Location = new System.Drawing.Point(10, 31);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(156, 97);
            this.ErrorLabel.TabIndex = 0;
            this.ErrorLabel.Text = "The path to the game could not be resolved! Make sure the first argument is the g" +
    "ame path and that it\'s surrounded by double quotes. Close this dialog box, check" +
    " the path, and try again.";
            // 
            // ErrorButton
            // 
            this.ErrorButton.Location = new System.Drawing.Point(89, 144);
            this.ErrorButton.Name = "ErrorButton";
            this.ErrorButton.Size = new System.Drawing.Size(100, 25);
            this.ErrorButton.TabIndex = 1;
            this.ErrorButton.Text = "Close";
            this.ErrorButton.UseVisualStyleBackColor = true;
            this.ErrorButton.Click += new System.EventHandler(this.ErrorButton_Click);
            // 
            // Form_ErrorMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 175);
            this.Controls.Add(this.ErrorButton);
            this.Controls.Add(this.ErrorGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(214, 214);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(214, 214);
            this.Name = "Form_ErrorMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGS v1.4.0";
            this.ErrorGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button ErrorButton;
        public System.Windows.Forms.Label ErrorLabel;
        public System.Windows.Forms.GroupBox ErrorGroupBox;
    }
}