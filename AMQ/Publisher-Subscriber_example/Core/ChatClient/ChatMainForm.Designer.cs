namespace ChatClient
{
    partial class ChatMainForm
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
            this.OpenChatListBox = new System.Windows.Forms.ListBox();
            this.ChatListLable = new System.Windows.Forms.Label();
            this.SelectUserComboBox = new System.Windows.Forms.ComboBox();
            this.SelectUserForNewDialogLable = new System.Windows.Forms.Label();
            this.StartNewDialogButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HistoryTextBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SendMessageButton = new System.Windows.Forms.Button();
            this.SendMessageTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenChatListBox
            // 
            this.OpenChatListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenChatListBox.FormattingEnabled = true;
            this.OpenChatListBox.ItemHeight = 20;
            this.OpenChatListBox.Location = new System.Drawing.Point(13, 34);
            this.OpenChatListBox.Name = "OpenChatListBox";
            this.OpenChatListBox.Size = new System.Drawing.Size(144, 304);
            this.OpenChatListBox.TabIndex = 0;
            // 
            // ChatListLable
            // 
            this.ChatListLable.AutoSize = true;
            this.ChatListLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatListLable.Location = new System.Drawing.Point(13, 9);
            this.ChatListLable.Name = "ChatListLable";
            this.ChatListLable.Size = new System.Drawing.Size(116, 20);
            this.ChatListLable.TabIndex = 1;
            this.ChatListLable.Text = "Opened Chats:";
            // 
            // SelectUserComboBox
            // 
            this.SelectUserComboBox.FormattingEnabled = true;
            this.SelectUserComboBox.Location = new System.Drawing.Point(13, 417);
            this.SelectUserComboBox.Name = "SelectUserComboBox";
            this.SelectUserComboBox.Size = new System.Drawing.Size(140, 21);
            this.SelectUserComboBox.TabIndex = 2;
            // 
            // SelectUserForNewDialogLable
            // 
            this.SelectUserForNewDialogLable.AutoSize = true;
            this.SelectUserForNewDialogLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectUserForNewDialogLable.Location = new System.Drawing.Point(13, 394);
            this.SelectUserForNewDialogLable.Name = "SelectUserForNewDialogLable";
            this.SelectUserForNewDialogLable.Size = new System.Drawing.Size(96, 20);
            this.SelectUserForNewDialogLable.TabIndex = 3;
            this.SelectUserForNewDialogLable.Text = "Select User:";
            // 
            // StartNewDialogButton
            // 
            this.StartNewDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartNewDialogButton.Location = new System.Drawing.Point(13, 444);
            this.StartNewDialogButton.Name = "StartNewDialogButton";
            this.StartNewDialogButton.Size = new System.Drawing.Size(140, 26);
            this.StartNewDialogButton.TabIndex = 4;
            this.StartNewDialogButton.Text = "Start New Dialog";
            this.StartNewDialogButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.OpenChatListBox);
            this.panel1.Controls.Add(this.StartNewDialogButton);
            this.panel1.Controls.Add(this.ChatListLable);
            this.panel1.Controls.Add(this.SelectUserForNewDialogLable);
            this.panel1.Controls.Add(this.SelectUserComboBox);
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 483);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.HistoryTextBox);
            this.panel2.Location = new System.Drawing.Point(193, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(389, 414);
            this.panel2.TabIndex = 6;
            // 
            // HistoryTextBox
            // 
            this.HistoryTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HistoryTextBox.Location = new System.Drawing.Point(3, 3);
            this.HistoryTextBox.Multiline = true;
            this.HistoryTextBox.Name = "HistoryTextBox";
            this.HistoryTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.HistoryTextBox.Size = new System.Drawing.Size(381, 406);
            this.HistoryTextBox.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.SendMessageButton);
            this.panel3.Controls.Add(this.SendMessageTextBox);
            this.panel3.Location = new System.Drawing.Point(194, 427);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(387, 64);
            this.panel3.TabIndex = 7;
            // 
            // SendMessageButton
            // 
            this.SendMessageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendMessageButton.Location = new System.Drawing.Point(309, 3);
            this.SendMessageButton.Name = "SendMessageButton";
            this.SendMessageButton.Size = new System.Drawing.Size(71, 54);
            this.SendMessageButton.TabIndex = 1;
            this.SendMessageButton.Text = "Send Message";
            this.SendMessageButton.UseVisualStyleBackColor = true;
            // 
            // SendMessageTextBox
            // 
            this.SendMessageTextBox.Location = new System.Drawing.Point(3, 3);
            this.SendMessageTextBox.Multiline = true;
            this.SendMessageTextBox.Name = "SendMessageTextBox";
            this.SendMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SendMessageTextBox.Size = new System.Drawing.Size(300, 54);
            this.SendMessageTextBox.TabIndex = 0;
            this.SendMessageTextBox.Text = "   ";
            // 
            // ChatMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 514);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ChatMainForm";
            this.Text = "ChatMainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox OpenChatListBox;
        public System.Windows.Forms.Label ChatListLable;
        public System.Windows.Forms.ComboBox SelectUserComboBox;
        public System.Windows.Forms.Label SelectUserForNewDialogLable;
        public System.Windows.Forms.Button StartNewDialogButton;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox HistoryTextBox;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button SendMessageButton;
        public System.Windows.Forms.TextBox SendMessageTextBox;
    }
}