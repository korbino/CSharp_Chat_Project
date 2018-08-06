namespace ChatClient
{
    partial class Launcher
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
            this.CreateClientButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateClientButton
            // 
            this.CreateClientButton.Location = new System.Drawing.Point(51, 76);
            this.CreateClientButton.Name = "CreateClientButton";
            this.CreateClientButton.Size = new System.Drawing.Size(181, 82);
            this.CreateClientButton.TabIndex = 0;
            this.CreateClientButton.Text = "Create Chat Client";
            this.CreateClientButton.UseVisualStyleBackColor = true;
            this.CreateClientButton.Click += new System.EventHandler(this.CreateClientButton_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.CreateClientButton);
            this.Name = "Launcher";
            this.Text = "Launcher";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateClientButton;
    }
}

