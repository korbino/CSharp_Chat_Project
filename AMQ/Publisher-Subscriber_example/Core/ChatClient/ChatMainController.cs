using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using InfrastructureChat;
using BackEndMocker;

namespace ChatClient
{
    /*TODO:
    [+] Create connection to Broker
    [+] Get list of Active chats for current user
    [+] Create Class "OpenedChat" which will contain details of subscribtion\publisher and etc...
    [+] Create List <OpenedChat> and generate subsribe\publish mechanism for all of them    
    [+] Once subscribed to topic - pull all missed messages
    [-] Implement publish\send message for selectedActiveTopic
    [-] Display list of OpenedChats on relevant pannel
    [-] Highlite OpenedChats - with missed messages
    [-] After clicking on each OpenedChat element - on right pannel should be displaying conversation history
    [-] Implement StartNew dialog
    [-] In UI should be easy to understand - which dialog curently is Active.
  
    */

    class ChatMainController
    {
        #region Private Fields\Properties
        private ChatMainForm chatMainForm;

        private TopicConnectionFactory connectionFactory; 
        private string brokerDestination;
        private List<int> listOfActiveTopiIDs = new List<int>();
        private List<OpenedChat> listOfOpenedChats = new List<OpenedChat>();
        private string selectedActiveTopicID;
        //mockers:
        BrokerSQLCommunicationMocker mockBrockerSQLCommunication = new BrokerSQLCommunicationMocker();
        #endregion

        //c-tor
        public ChatMainController(ChatMainForm chatMainForm)
        {            
            this.chatMainForm = chatMainForm;            
            MakeConnectionToBroker();
            InitListOfActiveTopiIDs();
            CreateOpenedChatList();
        }
       

        //for debug:
        public void PrintToLogAllMessagesForAllOpenChats()
        {
            foreach (var v in listOfOpenedChats)
            {
                v.PrintAllMessages();
            }
        }
        
        public void SendMessage()
        {
            //tmp solution:
            selectedActiveTopicID = "1009";
            foreach (var v in listOfOpenedChats)
            {
                if (v.TopicID == selectedActiveTopicID)
                    {
                        v.SendMessage(chatMainForm.SendMessageTextBox.Text);
                        chatMainForm.SendMessageTextBox.Text = "";
                    }                    
            }
        }

        #region Private Methods:        
        /// <summary>
        /// Make Connection to AMQ with predefined user name
        /// </summary>
        private void MakeConnectionToBroker()
        {
            brokerDestination = "tcp://" + ConfigChatDll.ActiveMqBrokerLink() + ":" + ConfigChatDll.ActiveMqBrokerPort();    
            connectionFactory = new TopicConnectionFactory(new ConnectionFactory(brokerDestination));
            Logger.Log.Debug(this.ToString() + ": Connection to broker was made with next destination: " + brokerDestination);
            
        }
        
        /// <summary>
        /// Get list of topic IDs, where current user is active and init local list
        /// </summary>
        private void InitListOfActiveTopiIDs ()
        {
            listOfActiveTopiIDs = mockBrockerSQLCommunication.GetAllActiveTopicIDsByUserName(chatMainForm.UserName);
            Logger.Log.Debug(this.ToString() + ": Reading active topicIDs for username: " + chatMainForm.UserName);
            foreach (int v in listOfActiveTopiIDs)
            {
                Logger.Log.Debug(this.ToString() +": " + v);
            }
        }
        
        private void CreateOpenedChatList()
        {
            foreach (var v in listOfActiveTopiIDs)
            {
                listOfOpenedChats.Add(new OpenedChat(chatMainForm.UserName, v.ToString(), connectionFactory));
            }            
        }
        
        #endregion
    }
}
