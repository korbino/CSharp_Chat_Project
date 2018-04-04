using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Apache.NMS.ActiveMQ;
using BackEndMocker;
using System.Windows.Forms;

namespace ActiveMqMessageChat
{
    class BrokerClientManager
    {
        private delegate void SetTextCallback(string text);

        //mockers init:
        BrokerConfigMocker brConfigMocker = new BrokerConfigMocker();
        public BrokerAuthenticationMocker brAuthMocker = new BrokerAuthenticationMocker();
        public BrokerSQLCommunicationMocker brSQLCommunicationMocker = new BrokerSQLCommunicationMocker();
        
        //public fields definition        
        public TopicConnectionFactory connectionFactory;            
        public TopicConnection connection;
        public SimpleTopicPublisher publisher;
        public SimpleTopicSubscriber subscriber;
        public string clientId;
        public string consumerId;
        public readonly StringBuilder builder = new StringBuilder();
        public string TOPIC_NAME = "TestTopicName";        

        //private fields:
        private MainForm mainForm;

        public BrokerClientManager(MainForm mainForm)
        {
            this.mainForm = mainForm;
            //init connection factory:
            string BROKER = "tcp://" + brConfigMocker.BrokerLocation + ":" + brConfigMocker.BrokerPortConnection;//localhost:61616";
            connectionFactory = new TopicConnectionFactory(new ConnectionFactory(BROKER));                        
        }    
            
        /// <summary>
        /// Creating connection with self pub\subscr in durable mode
        /// </summary>
        /// <param name="clientId">currently this is user id, which defining in form</param>        
        public void Connection ()
        {        
            if (brAuthMocker.IsUserAuthenticated(mainForm.initUserComboBox.Text, mainForm.passwordTextBox.Text))
            {               
                InitTopicName();//init according to choosed users in form

                //Get client ID
                this.clientId = mainForm.initUserComboBox.Text;
                consumerId = this.clientId;
                

                //init self pub-subscriber section:
                connection = connectionFactory.CreateConnection(clientId, TOPIC_NAME);
                publisher = connection.CreateTopicPublisher();
                subscriber = connection.CreateSimpleTopicSubscriber(consumerId);

                subscriber.OnMessageReceived += new MessageRecieverDelegate(subscriber_OnMessageReceived);
            }  
            else
            {
                throw new Exception("User is not Authenticate!");
            }
            
        }

        public void SendMessage ()
        {
            publisher.SendMessage(clientId + " (" + DateTime.Now + ") -> " + mainForm.messageTextBox.Text);
            mainForm.messageTextBox.Text = "";
        }

        /// <summary>
        /// Extract users from DB and propagate them to user's comboboxes
        /// </summary>
        public void InitUsersComboboxes ()
        {
            //extract users list from DB: 
            BindingSource bindSourceForTargetUser = new BindingSource();   //this is for combobox user list from db   
            BindingSource binSourceForInitUser = new BindingSource();  // same for init user list            
            bindSourceForTargetUser.DataSource = brSQLCommunicationMocker.GetUserListFromDB();
            binSourceForInitUser.DataSource = brSQLCommunicationMocker.GetUserListFromDB();
            mainForm.initUserComboBox.DataSource = binSourceForInitUser;
            mainForm.targetUserComboBox.DataSource = bindSourceForTargetUser;
        }

        #region PRIVATE METHODS:
        private void InitTopicName ()
        {            
            this.TOPIC_NAME = brSQLCommunicationMocker.CreateNewTopicID(mainForm.initUserComboBox.Text, mainForm.targetUserComboBox.Text).ToString();
        }

        private void subscriber_OnMessageReceived(string message)
        {
            builder.AppendLine(message);
            SetText(builder.ToString());
        }

        //define text in text box in form, history
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.            
            if (mainForm.historyTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                mainForm.Invoke(d, new object[] { text });
            }
            else
            {
                mainForm.historyTextBox.Text = text;
            }
        }

        #endregion

        //armagedon.....
        public void Dispose()
        {
            publisher.Dispose();
            subscriber.Dispose();
            connection.Dispose();
        }         
    }
}
