using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using useRSA;
using Apache.NMS.ActiveMQ;
using Core;

namespace ActiveMqMessageChat.MVC
{
    class MainViewer
    {

        private MainForm MainForm;
        bool isUserinDBbool;
        private string clientId;
        private string consumerId;
        private string consumerPassword;   //IgorSu
        //string broker;// = string.Empty;
        const string broker = "tcp://pctest:61616";
        TopicConnectionFactory connectionFactory = new TopicConnectionFactory(new ConnectionFactory(broker));
        SimpleTopicPublisher publisher;
        TopicConnection connection;
        SimpleTopicSubscriber subscriber;
        private delegate void SetTextCallback(string text);
        string TOPIC_NAME = "SampleSubscriptionTopic";

        public MainViewer(MainForm MainForm)
        {
            this.MainForm = MainForm;
            Init();
        }

        private void Init()
        {
            MainForm.connectButton.Click += connectButton_Click;
            MainForm.submitButton.Click += submitButton_Click;
            MainForm.clientPasstextBox.PasswordChar = '*';
            
        }


        private void connectButton_Click(object sender, EventArgs e)
        {
            //try
            //{

            clientId = MainForm.clientIdTextBox.Text;
            consumerId = clientId;
            //*********************igorsu*************************************************
            consumerPassword = MainForm.clientPasstextBox.Text;  //IgorSu
            LoginFunc AgentAuthentication = new LoginFunc(@"D:\C_sharp_advanced\AMQ\SourceCode\Pub-Sub_working_POC\Core\Core\ConfigFile\test.xml");
            isUserinDBbool = AgentAuthentication.IsUserCorrect(consumerId, consumerPassword);
            if (!isUserinDBbool) { MessageBox.Show("Login Failed", "Agent Authentication", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return; }
            //***************************************************************************
            //broker = provideActiveMq();
            //TopicConnectionFactory connectionFactory = new TopicConnectionFactory(new ConnectionFactory(broker));//igorsu
            //SimpleTopicPublisher publisher;
            
            

            connection = connectionFactory.CreateConnection(clientId, TOPIC_NAME);
              
            
            publisher = connection.CreateTopicPublisher();
            subscriber = connection.CreateSimpleTopicSubscriber(consumerId);
            subscriber.OnMessageReceived += new MessageRecieverDelegate(subscriber_OnMessageReceived);
            MainForm.connectButton.BackColor = System.Drawing.Color.Green;
            MainForm.clientIdLabel.Enabled = false;
            MainForm.clientIdTextBox.Enabled = false;
            MainForm.clientPasstextBox.Enabled = false;   //igorsu
            MainForm.connectButton.Enabled = false;
            MainForm.messageTextBox.Enabled = true;
            MainForm.instructionLabel.Enabled = true;
            MainForm.historyTextBox.Enabled = true;
            MainForm.submitButton.Enabled = true;


        }

        private void submitButton_Click(object sender, EventArgs e)
        {
           
            publisher.SendMessage(consumerId + " :  " + DateTime.Now.ToString());//  igorsu
            publisher.SendMessage(MainForm.messageTextBox.Text);
        }


        private string provideActiveMq()
        {
            string activeMqserver = string.Empty;
            ConfigXML ConfigDetails = new ConfigXML();   //IgorSu
            activeMqserver = ConfigDetails.ActiveMqBrokerLink();  //IgorSu

            return activeMqserver;
        }

        private void subscriber_OnMessageReceived(string message)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(message);
            SetText(builder.ToString());
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (MainForm.historyTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                MainForm.Invoke(d, new object[] { text });
            }
            else
            {
                MainForm.historyTextBox.Text = text;
            }
        }


    }
}
