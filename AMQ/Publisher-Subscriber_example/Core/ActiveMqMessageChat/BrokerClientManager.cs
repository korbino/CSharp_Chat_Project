using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Apache.NMS.ActiveMQ;
using BackEndMocker;
using System.Windows.Forms;
//our dlls:
using InfrastructureChat;
using AuthenticationDLL;
using LoginFuncthionality;
using SQLinfra;

namespace ActiveMqMessageChat
{
    class BrokerClientManager
    {
        private delegate void SetTextCallback(string text);

        //mockers init:
        //BrokerConfigMocker brConfigMocker = new BrokerConfigMocker(); // obsolete
        //BrokerAuthenticationMocker brAuthMocker = new BrokerAuthenticationMocker(); //obsolete        
        //BrokerSQLCommunicationMocker brSQLCommunicationMocker = new BrokerSQLCommunicationMocker(); //TODO: igor to change

        //Real Dll
        LoginFunc loginFunc = new LoginFunc();
        SQLInfrastructure sqlInfra = new SQLInfrastructure(ConfigChatDll.OpenXmlConnectionString());     
        
        
        //main objects              
        TopicConnectionFactory connectionFactory;            
        TopicConnection connection;
        SimpleTopicPublisher publisher;
        SimpleTopicSubscriber subscriber;
        string clientId;
        string consumerId;
        readonly StringBuilder builder = new StringBuilder();
        string TOPIC_NAME = "TestTopicName";                
        MainForm mainForm;

        public BrokerClientManager(MainForm mainForm)
        {
            this.mainForm = mainForm;
            //init connection factory:            
            //config DLL - should be deployed under: C:\XMLconf\ConfigXMLChat.xml
            string BROKER = "tcp://" + ConfigChatDll.ActiveMqBrokerLink() + ":" + ConfigChatDll.ActiveMqBrokerPort();//true DLL";
            connectionFactory = new TopicConnectionFactory(new ConnectionFactory(BROKER));                        
        }    
            
        /// <summary>
        /// Make login 
        /// </summary>             
        public void MakeLogin ()
        {        
            //if (brAuthMocker.IsUserAuthenticated(mainForm.initUserComboBox.Text, mainForm.passwordTextBox.Text)) //obsolete
            if (loginFunc.IsUserCorrect(mainForm.initUserComboBox.Text, mainForm.passwordTextBox.Text))
                {                              
                //Get client ID
                clientId = mainForm.initUserComboBox.Text;
                consumerId = clientId;

                //manage UI
                mainForm.targetUserComboBox.Enabled = true;
                mainForm.startDialogButton.Enabled = true;
                mainForm.clientIdLabel.Enabled = false;
                mainForm.initUserComboBox.Enabled = false;
                mainForm.loginButton.Enabled = false;
                mainForm.instructionLabel.Enabled = true;                
                mainForm.passwordTextBox.Enabled = false;
            }  
            else
            {
                throw new Exception("User is not Authenticate!");
            }
            
        }


        /// <summary>
        /// Create topic ID  according to selected users and init client
        /// </summary>
        public void StartDialog()
        {
            try
            {
                InitTopicName();//init according to choosed users in form
            }
            catch (Exception e)
            {
                throw new Exception("Failed to start conversation because of: " + e.Message);
            }
            
            //init self pub-subscriber section:
            connection = connectionFactory.CreateConnection(clientId, TOPIC_NAME);
            publisher = connection.CreateTopicPublisher();
            subscriber = connection.CreateSimpleTopicSubscriber(consumerId);
            subscriber.OnMessageReceived += new MessageRecieverDelegate(subscriber_OnMessageReceived);

            //manage UI
            mainForm.targetUserComboBox.Enabled = false;
            mainForm.startDialogButton.Enabled = false;
            mainForm.messageTextBox.Enabled = true;
            mainForm.submitButton.Enabled = true;
            mainForm.historyTextBox.Enabled = true;
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
            //bindSourceForTargetUser.DataSource = brSQLCommunicationMocker.GetUserListFromDB(); //mockers
            //binSourceForInitUser.DataSource = brSQLCommunicationMocker.GetUserListFromDB(); //mockers        
            bindSourceForTargetUser.DataSource = sqlInfra.GetUserListFromDB();
            binSourceForInitUser.DataSource = sqlInfra.GetUserListFromDB();
            mainForm.initUserComboBox.DataSource = binSourceForInitUser;
            mainForm.targetUserComboBox.DataSource = bindSourceForTargetUser;
        }

        #region PRIVATE METHODS:
        private void InitTopicName ()
        {
            try
            {
                //TOPIC_NAME = brSQLCommunicationMocker.CreateNewTopicID(mainForm.initUserComboBox.Text, mainForm.targetUserComboBox.Text).ToString(); //TODO: replace real get topic id instead of mocker
                TOPIC_NAME = sqlInfra.CreateNewTopicID(mainForm.initUserComboBox.Text, mainForm.targetUserComboBox.Text).ToString(); 
            }   
            catch (Exception e)
            {
                throw e;
            }
            
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
