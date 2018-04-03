namespace ActiveMqMessageChat
{
    partial class LaunchForm
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
            this.launchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // launchButton
            // 
            this.launchButton.Location = new System.Drawing.Point(68, 71);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(142, 65);
            this.launchButton.TabIndex = 0;
            this.launchButton.Text = "Create Client";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // LaunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.launchButton);
            this.Name = "LaunchForm";
            this.Text = "LaunchForm";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button launchButton;
    }
}