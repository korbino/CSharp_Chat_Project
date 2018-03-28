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
using BackEndMocker;

namespace ActiveMqMessageChat
{
    public partial class MainForm : Form
    {
        private delegate void SetTextCallback(string text);
        private BrokerClientManager broCliMan = new BrokerClientManager();
        private string selfName;

        public MainForm()
        {            
            InitializeComponent();
        }

        private void subscriber_OnMessageReceived(string message)
        {
            broCliMan.builder.AppendLine(message);
            SetText(broCliMan.builder.ToString());
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
                broCliMan.publisher.Dispose();
                broCliMan.subscriber.Dispose();
                broCliMan.connection.Dispose();
            }
            catch { }
        }      

        private void connectButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Get client ID
                broCliMan.clientId = this.clientIdTextBox.Text;
                broCliMan.consumerId = broCliMan.clientId;
                selfName = broCliMan.clientId;               

                //init self pub-subscriber section:
                broCliMan.connection = broCliMan.connectionFactory.CreateConnection(broCliMan.clientId, broCliMan.TOPIC_NAME);                
                broCliMan.publisher = broCliMan.connection.CreateTopicPublisher();               
                broCliMan.subscriber = broCliMan.connection.CreateSimpleTopicSubscriber(broCliMan.consumerId);

                broCliMan.subscriber.OnMessageReceived += new MessageRecieverDelegate(subscriber_OnMessageReceived);

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
            broCliMan.publisher.SendMessage(this.selfName + "::::   " + this.messageTextBox.Text);
        }
    }
}
