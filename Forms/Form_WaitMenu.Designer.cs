namespace PGS
{
    partial class Form_WaitMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_WaitMenu));
            this.WaitLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WaitLabel
            // 
            this.WaitLabel.Location = new System.Drawing.Point(27, 72);
            this.WaitLabel.Margin = new System.Windows.Forms.Padding(0);
            this.WaitLabel.Name = "WaitLabel";
            this.WaitLabel.Size = new System.Drawing.Size(136, 100);
            this.WaitLabel.TabIndex = 0;
            this.WaitLabel.Text = "Waiting for game to close...";
            // 
            // Form_WaitMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 175);
            this.Controls.Add(this.WaitLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_WaitMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGS v1.1.0";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label WaitLabel;
    }
}