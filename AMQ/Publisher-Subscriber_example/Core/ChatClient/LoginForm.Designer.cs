namespace ChatClient
{
    partial class LoginForm
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
            this.LoginNameText = new System.Windows.Forms.TextBox();
            this.PasswordText = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterNewUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginNameText
            // 
            this.LoginNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginNameText.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.LoginNameText.Location = new System.Drawing.Point(12, 30);
            this.LoginNameText.Name = "LoginNameText";
            this.LoginNameText.Size = new System.Drawing.Size(198, 27);
            this.LoginNameText.TabIndex = 0;
            this.LoginNameText.Text = "Login";
            this.LoginNameText.Enter += new System.EventHandler(this.LoginName_Enter);
            this.LoginNameText.Leave += new System.EventHandler(this.LoginNameText_Leave);
            // 
            // PasswordText
            // 
            this.PasswordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordText.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.PasswordText.Location = new System.Drawing.Point(12, 63);
            this.PasswordText.Name = "PasswordText";
            this.PasswordText.Size = new System.Drawing.Size(198, 27);
            this.PasswordText.TabIndex = 1;
            this.PasswordText.Text = "Password";
            this.PasswordText.Enter += new System.EventHandler(this.PasswordText_Enter);
            this.PasswordText.Leave += new System.EventHandler(this.PasswordText_Leave);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(12, 107);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(198, 23);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegisterNewUserButton
            // 
            this.RegisterNewUserButton.Location = new System.Drawing.Point(12, 169);
            this.RegisterNewUserButton.Name = "RegisterNewUserButton";
            this.RegisterNewUserButton.Size = new System.Drawing.Size(198, 23);
            this.RegisterNewUserButton.TabIndex = 3;
            this.RegisterNewUserButton.Text = "Register New User";
            this.RegisterNewUserButton.UseVisualStyleBackColor = true;
            //this.RegisterNewUserButton.Click += new System.EventHandler(this.RegisterNewUserButton_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 204);
            this.Controls.Add(this.RegisterNewUserButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordText);
            this.Controls.Add(this.LoginNameText);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LoginNameText;
        private System.Windows.Forms.TextBox PasswordText;
        public System.Windows.Forms.Button LoginButton;
        public System.Windows.Forms.Button RegisterNewUserButton;
    }
}