namespace ActiveMqMessageChat
{
    partial class MainForm
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
            this.clientIdLabel = new System.Windows.Forms.Label();
            this.clientIdTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.historyTextBox = new System.Windows.Forms.TextBox();
            this.userPassLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.usersInDBComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // clientIdLabel
            // 
            this.clientIdLabel.AutoSize = true;
            this.clientIdLabel.Location = new System.Drawing.Point(12, 12);
            this.clientIdLabel.Name = "clientIdLabel";
            this.clientIdLabel.Size = new System.Drawing.Size(63, 13);
            this.clientIdLabel.TabIndex = 0;
            this.clientIdLabel.Text = "User Name:";
            // 
            // clientIdTextBox
            // 
            this.clientIdTextBox.Location = new System.Drawing.Point(78, 9);
            this.clientIdTextBox.Name = "clientIdTextBox";
            this.clientIdTextBox.Size = new System.Drawing.Size(162, 20);
            this.clientIdTextBox.TabIndex = 1;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(262, 9);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 56);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click_1);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(12, 167);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(325, 20);
            this.messageTextBox.TabIndex = 3;
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Location = new System.Drawing.Point(12, 151);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(78, 13);
            this.instructionLabel.TabIndex = 4;
            this.instructionLabel.Text = "Send Message";
            this.instructionLabel.Click += new System.EventHandler(this.instructionLabel_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 193);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(325, 24);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click_1);
            // 
            // historyTextBox
            // 
            this.historyTextBox.Location = new System.Drawing.Point(12, 223);
            this.historyTextBox.Multiline = true;
            this.historyTextBox.Name = "historyTextBox";
            this.historyTextBox.Size = new System.Drawing.Size(325, 222);
            this.historyTextBox.TabIndex = 6;
            // 
            // userPassLabel
            // 
            this.userPassLabel.AutoSize = true;
            this.userPassLabel.Location = new System.Drawing.Point(12, 44);
            this.userPassLabel.Name = "userPassLabel";
            this.userPassLabel.Size = new System.Drawing.Size(58, 13);
            this.userPassLabel.TabIndex = 7;
            this.userPassLabel.Text = "User Pass:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(78, 44);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(162, 20);
            this.passwordTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select User To Speak:";
            // 
            // usersInDBComboBox
            // 
            this.usersInDBComboBox.FormattingEnabled = true;
            this.usersInDBComboBox.Location = new System.Drawing.Point(78, 100);
            this.usersInDBComboBox.Name = "usersInDBComboBox";
            this.usersInDBComboBox.Size = new System.Drawing.Size(121, 21);
            this.usersInDBComboBox.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 457);
            this.Controls.Add(this.usersInDBComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userPassLabel);
            this.Controls.Add(this.historyTextBox);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.clientIdTextBox);
            this.Controls.Add(this.clientIdLabel);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clientIdLabel;
        public System.Windows.Forms.TextBox clientIdTextBox;
        private System.Windows.Forms.Button connectButton;
        public System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.Button submitButton;
        public System.Windows.Forms.TextBox historyTextBox;
        private System.Windows.Forms.Label userPassLabel;
        public System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox usersInDBComboBox;
    }
}

