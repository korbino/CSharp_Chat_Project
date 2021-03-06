﻿using System;
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
        BrokerConfigMocker brConfigMocker = new BrokerConfigMocker(); // obsolete
        BrokerAuthenticationMocker brAuthMocker = new BrokerAuthenticationMocker(); //obsolete        
        BrokerSQLCommunicationMocker brSQLCommunicationMocker = new BrokerSQLCommunicationMocker(); 

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
        string topicID;                
        MainForm mainForm;
        bool isUsersAlreadyInChat = false;
        //tmp
        //bool isThereIsNewMessages = false;
        //readonly StringBuilder builderTest = new StringBuilder();

        //   

        public BrokerClientManager(MainForm mainForm)
        {
            this.mainForm = mainForm;
            //init connection factory:            
            //config DLL - should be deployed under: C:\XMLconf\ConfigXMLChat.xml
            string brokerDestination = "tcp://" + ConfigChatDll.ActiveMqBrokerLink() + ":" + ConfigChatDll.ActiveMqBrokerPort();//true DLL";
            connectionFactory = new TopicConnectionFactory(new ConnectionFactory(brokerDestination));            
        }    
            
        /// <summary>
        /// Make login 
        /// </summary>             
        public void MakeLogin ()
        {    
            //if (brAuthMocker.IsUserAuthenticated(mainForm.initUserComboBox.Text, mainForm.passwordTextBox.Text)) //mock
           if (loginFunc.IsUserCorrect(mainForm.initUserComboBox.Text, mainForm.passwordTextBox.Text)) // REAL
                {               
                //check for new messages right after login:
                ShowNewMessage(mainForm.initUserComboBox.Text);

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

            //Get Client ID\ConsumerID
            clientId = string.Format(mainForm.initUserComboBox.Text + "_topic_" + topicID);
            consumerId = string.Format(mainForm.initUserComboBox.Text + "_topic_" + topicID);

            //init self pub-subscriber section:
            connection = connectionFactory.CreateConnection(clientId, topicID);
            publisher = connection.CreateTopicPublisher();
            subscriber = connection.CreateSimpleTopicSubscriber(consumerId);
            subscriber.OnMessageReceived += new MessageRecieverDelegate(subscriber_OnMessageReceived);

            //checking  in case of both users are not in same chat -then user2(target user) will be sbscribbed to defined topic
            //in case of users are in same chat - do nothing with second user.
            Logger.Log.Debug(string.Format("{0} - checking  in case of both users are not in same chat. For users: {1}, {2}", this.ToString(), mainForm.initUserComboBox.Text, mainForm.targetUserComboBox.Text));
            if (!isUsersAlreadyInChat)
            {
                Logger.Log.Debug(string.Format("{0} - users are not existing in same chat", this.ToString()));
                SubscribeUserToTopic(string.Format(mainForm.targetUserComboBox.Text + "_topic_" + topicID), topicID);
            }
            else
                Logger.Log.Debug(string.Format("{0} - users are already existing in topicID: {1}", this.ToString(), topicID));

            //manage UI
            mainForm.targetUserComboBox.Enabled = false;
            mainForm.startDialogButton.Enabled = false;
            mainForm.messageTextBox.Enabled = true;
            mainForm.submitButton.Enabled = true;
            mainForm.historyTextBox.Enabled = true;
            mainForm.Text = "TheTopicID: " + topicID;
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
            try
            {
                //extract users list from DB: 
                BindingSource bindSourceForTargetUser = new BindingSource();   //this is for combobox user list from db   
                BindingSource binSourceForInitUser = new BindingSource();  // same for init user list            
                //bindSourceForTargetUser.DataSource = brSQLCommunicationMocker.GetUserListFromDB(); //mock
                //binSourceForInitUser.DataSource = brSQLCommunicationMocker.GetUserListFromDB(); //mock        
                bindSourceForTargetUser.DataSource = sqlInfra.GetUserListFromDB(); // REAL
                binSourceForInitUser.DataSource = sqlInfra.GetUserListFromDB(); // REAL
                mainForm.initUserComboBox.DataSource = binSourceForInitUser;
                mainForm.targetUserComboBox.DataSource = bindSourceForTargetUser;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Happened!");
            }
        }

        #region PRIVATE METHODS:
        //TODO: need to show popup window in case of new message for defined topics
        private void ShowNewMessage(string userName)
        {
            Logger.Log.Info(this.ToString() + " - Extract from DB all topics, where user: [" + userName + "] is active.");
            //TODO: need to check with igor below method if exists?
            List<int> listOfTopicsByUserName = brSQLCommunicationMocker.GetAllActiveTopicIDsByUserName(userName); //1009,1010 for harden, for app - 1009, for db - 1010
            Logger.Log.Debug(this.ToString() + " - The list of topicIDs are:");
            foreach (int i in listOfTopicsByUserName)
            {
                Logger.Log.Debug(i);
            }

            //going thrue the list of topics -> make connection -> in case of topic includes not read message - show it.
            foreach (int topicName in listOfTopicsByUserName)
            {
                Logger.Log.Debug(string.Format("{0} - going thrue the list of topics. Try topicName: {1}", this.ToString(), topicName));
                TopicConnection tmpConnection;
                SimpleTopicSubscriber tmpSubscriber;

                //Get tmp ClientID\ConsumerID
                string tmpClientId = string.Format(userName + "_topic_" + topicName);
                string tmpConsumerId = string.Format(userName + "_topic_" + topicName);

                tmpConnection = connectionFactory.CreateConnection(tmpClientId, topicName.ToString());                
                tmpSubscriber = tmpConnection.CreateSimpleTopicSubscriber(tmpConsumerId);
                tmpSubscriber.OnMessageReceived += new MessageRecieverDelegate(subscriber_OnMessageReceived_TEST);                               

                //dispose connection   TODO: this is problem place, that's why it is reading only first message???                     
                tmpConnection.Dispose();                
                tmpSubscriber.Dispose();                
            }
        }

        private void SubscribeUserToTopic(string userName, string topicName)
        {
            TopicConnection tmpConnection;
            SimpleTopicSubscriber tmpSubscriber;
            SimpleTopicPublisher tmpPublisher;

            tmpConnection = connectionFactory.CreateConnection(userName, topicName);
            tmpPublisher = tmpConnection.CreateTopicPublisher();
            tmpSubscriber = tmpConnection.CreateSimpleTopicSubscriber(userName);

            //dispose connection                        
            tmpConnection.Dispose();
            tmpPublisher.Dispose();
            tmpSubscriber.Dispose();
            //---------------------
        }

        private void InitTopicName ()
        {
            try
            {
                //isUsersAlreadyInChat = brSQLCommunicationMocker.IsUsersInSameChat(mainForm.initUserComboBox.Text, mainForm.targetUserComboBox.Text); //mock
                //topicID = brSQLCommunicationMocker.GetTopicID(mainForm.initUserComboBox.Text, mainForm.targetUserComboBox.Text).ToString(); //mock, TODO: replace real get topic id instead of mocker
               isUsersAlreadyInChat = sqlInfra.IsUsersInSameChat(mainForm.initUserComboBox.Text, mainForm.targetUserComboBox.Text); //REAL 
               topicID = sqlInfra.GetTopicID(mainForm.initUserComboBox.Text, mainForm.targetUserComboBox.Text).ToString(); //REAL          
            }   
            catch (Exception e)
            {
                throw e;
            }
            
        }

        private void subscriber_OnMessageReceived_TEST(string message)
        {
            //builderTest.AppendLine(message);
            Logger.Log.Debug(this.ToString() + " - Messegae in queue is: \n" + message);
            //MessageBox.Show(builderTest.ToString());
            MessageBox.Show(message);
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
