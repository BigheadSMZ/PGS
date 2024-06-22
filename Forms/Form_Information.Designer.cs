namespace PGS
{
    internal partial class Form_ScreenInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ScreenInfo));
            this.InfoGroupBox = new System.Windows.Forms.GroupBox();
            this.InfoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.InfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoGroupBox
            // 
            this.InfoGroupBox.Controls.Add(this.InfoRichTextBox);
            this.InfoGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InfoGroupBox.Name = "InfoGroupBox";
            this.InfoGroupBox.Size = new System.Drawing.Size(322, 320);
            this.InfoGroupBox.TabIndex = 0;
            this.InfoGroupBox.TabStop = false;
            this.InfoGroupBox.Text = "Monitor Information";
            // 
            // InfoRichTextBox
            // 
            this.InfoRichTextBox.BackColor = System.Drawing.Color.White;
            this.InfoRichTextBox.Location = new System.Drawing.Point(6, 19);
            this.InfoRichTextBox.Name = "InfoRichTextBox";
            this.InfoRichTextBox.ReadOnly = true;
            this.InfoRichTextBox.Size = new System.Drawing.Size(310, 295);
            this.InfoRichTextBox.TabIndex = 0;
            this.InfoRichTextBox.Text = "";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(234, 338);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(100, 25);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "OK";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Form_ScreenInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 369);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.InfoGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(362, 408);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(362, 408);
            this.Name = "Form_ScreenInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGS Screen Info";
            this.InfoGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox InfoGroupBox;
        public System.Windows.Forms.Button CloseButton;
        public System.Windows.Forms.RichTextBox InfoRichTextBox;
    }
}