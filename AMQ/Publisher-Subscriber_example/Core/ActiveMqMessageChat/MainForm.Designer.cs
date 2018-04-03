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
            this.SuspendLayout();
            // 
            // clientIdLabel
            // 
            this.clientIdLabel.AutoSize = true;
            this.clientIdLabel.Location = new System.Drawing.Point(12, 12);
            this.clientIdLabel.Name = "clientIdLabel";
            this.clientIdLabel.Size = new System.Drawing.Size(47, 13);
            this.clientIdLabel.TabIndex = 0;
            this.clientIdLabel.Text = "Client ID";
            // 
            // clientIdTextBox
            // 
            this.clientIdTextBox.Location = new System.Drawing.Point(65, 12);
            this.clientIdTextBox.Name = "clientIdTextBox";
            this.clientIdTextBox.Size = new System.Drawing.Size(162, 20);
            this.clientIdTextBox.TabIndex = 1;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(246, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 20);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click_1);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(15, 77);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(306, 20);
            this.messageTextBox.TabIndex = 3;
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Location = new System.Drawing.Point(12, 46);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(78, 13);
            this.instructionLabel.TabIndex = 4;
            this.instructionLabel.Text = "Send Message";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(15, 112);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(306, 24);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click_1);
            // 
            // historyTextBox
            // 
            this.historyTextBox.Location = new System.Drawing.Point(17, 159);
            this.historyTextBox.Multiline = true;
            this.historyTextBox.Name = "historyTextBox";
            this.historyTextBox.Size = new System.Drawing.Size(303, 146);
            this.historyTextBox.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 336);
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
        private System.Windows.Forms.TextBox clientIdTextBox;
        private System.Windows.Forms.Button connectButton;
        public System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.Button submitButton;
        public System.Windows.Forms.TextBox historyTextBox;
    }
}

