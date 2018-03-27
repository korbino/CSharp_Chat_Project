using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Apache.NMS.ActiveMQ;

namespace ActiveMqMessageChat
{
    public partial class MainForm : Form
    {
        const string TOPIC_NAME = "SampleSubscriptionTopic";
        const string BROKER = "tcp://localhost:61616";

        private readonly TopicConnectionFactory connectionFactory = new TopicConnectionFactory(new ConnectionFactory(BROKER));
        private TopicConnection connection;
        private SimpleTopicPublisher publisher;
        private SimpleTopicSubscriber subscriber;
        private string clientId;
        private string consumerId;
        private readonly StringBuilder builder = new StringBuilder();
        private delegate void SetTextCallback(string text);

        public MainForm()
        {
            InitializeComponent();
        }

        private void subscriber_OnMessageReceived(string message)
        {
            this.builder.AppendLine(message);
            SetText(this.builder.ToString());
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.historyTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.historyTextBox.Text = text;
            }
        }


        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.publisher.Dispose();
                this.subscriber.Dispose();
                this.connection.Dispose();
            }
            catch { }
        }      

        private void connectButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.clientId = this.clientIdTextBox.Text;
                this.consumerId = this.clientId;

                this.connection = this.connectionFactory.CreateConnection(this.clientId, TOPIC_NAME);
                this.publisher = this.connection.CreateTopicPublisher();
                this.subscriber = this.connection.CreateSimpleTopicSubscriber(this.consumerId);
                this.subscriber.OnMessageReceived += new MessageRecieverDelegate(subscriber_OnMessageReceived);
                this.clientIdLabel.Enabled = false;
                this.clientIdTextBox.Enabled = false;
                this.connectButton.Enabled = false;
                this.messageTextBox.Enabled = true;
                this.instructionLabel.Enabled = true;
                this.historyTextBox.Enabled = true;
                this.submitButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }

        private void submitButton_Click_1(object sender, EventArgs e)
        {
            this.publisher.SendMessage(this.messageTextBox.Text);
        }
    }
}
