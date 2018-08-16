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
using System.Windows.Forms;

namespace ChatClient
{
    /*TODO:
    [+] Create connection to Broker
    [+] Get list of Active chats for current user
    [+] Create Class "OpenedChat" which will contain details of subscribtion\publisher and etc...
    [+] Create List <OpenedChat> and generate subsribe\publish mechanism for all of them    
    [+] Once subscribed to topic - pull all missed messages
    [+] Implement publish\send message for selectedActiveTopic
    [+] Display list of OpenedChats on relevant pannel
    [-] Highlite OpenedChats - with missed messages
    [+] After clicking on each OpenedChat element - on right pannel should be displaying conversation history
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
        private BindingSource bindingSourceForListOfActiveTopic = new BindingSource();
        private bool isItFirstRun = true;//TODO: remove in future 
        private StringBuilder sBuilder = new StringBuilder();
        private List<string> listOfHistoryMessage = new List<string>(0);
        private delegate void SetTextCallback(string text);
        private delegate void SetTextListCallback(List<string> text);
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
            InitUIListOfOpenedChats();
            SubscribeForUIActions();
            InitSubscriptionsForNewMessageEvents();

        }
       

        //for debug:
        public void PrintToLogAllMessagesForAllOpenChats()
        {
            foreach (var v in listOfOpenedChats)
            {
                v.PrintAllMessages();
            }
        }
        
        /// <summary>
        /// According to selectedActiveTopicID - send inserted message to publisher and clean text box.
        /// </summary>
        public void SendMessage()
        {            
            foreach (var v in listOfOpenedChats)
            {
                if (v.TopicID == selectedActiveTopicID)
                    {
                        v.SendMessage(chatMainForm.SendMessageTextBox.Text + "\n");
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
        
        /// <summary>
        /// According to active topic IDs - create list of openedChats object.
        /// Main focuse there: topicID.
        /// </summary>
        private void CreateOpenedChatList()
        {
            foreach (var v in listOfActiveTopiIDs)
            {
                listOfOpenedChats.Add(new OpenedChat(chatMainForm.UserName, v.ToString(), connectionFactory));
            }            
        }
        
        /// <summary>
        /// Generate openChatlist box in UI of opened conversation, according top activeTopicIDs list. 
        /// Later should be mapped to proper name (extracted from DB)
        /// </summary>
        private void InitUIListOfOpenedChats()
        {
            //TODO: there should be implemented extract from DB topic Name - according to topicID.
            bindingSourceForListOfActiveTopic.DataSource = listOfActiveTopiIDs;
            chatMainForm.OpenChatListBox.DataSource = bindingSourceForListOfActiveTopic;     
            if (isItFirstRun)
            {
                selectedActiveTopicID = chatMainForm.OpenChatListBox.SelectedValue.ToString();
                Logger.Log.Debug(this.ToString() + ": This is first run app. selectedActiveTopicID was set to: " + selectedActiveTopicID);
                DisplayConversationInMainWindow();               
                isItFirstRun = false;
            }
        }

        //TODO: change logic... bad logic... too bad logic...
        /// <summary>
        /// Display conversation for each topicID according to OpenedChat.
        /// </summary>
        private void DisplayConversationInMainWindow()
        {
            listOfHistoryMessage = new List<string>();
            Logger.Log.Debug(this.ToString() + ": Was called DisplayConversationInMainWindow() method");
            foreach (var v in listOfOpenedChats)
            {                
                if (v.TopicID == selectedActiveTopicID)
                {
                    listOfHistoryMessage = v.MessagesContainer;
                }
            }
            RefreshHistory(listOfHistoryMessage);            
        }
             
        private void InitSubscriptionsForNewMessageEvents()
        {
            foreach (var v in listOfOpenedChats)
            {
                v.RecievedNewMessage += V_RecievedNewMessage;
            }
        }

        private void V_RecievedNewMessage(object sender, RecievedMessageArgs e)
        {
            if (e.TopicID == selectedActiveTopicID)
            {
                Logger.Log.Debug(this.ToString() + ": arrived new message: " + e.Message);

                //chatMainForm.HistoryTextBox.AppendText(e.Message.ToString());
                AppendTextToHistory(e.Message);
            }
        }

        //define text in text box in form, history
        private void AppendTextToHistory(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.            
            if (chatMainForm.HistoryTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AppendTextToHistory);
                chatMainForm.Invoke(d, new object[] { text });
            }
            else
            {
                chatMainForm.HistoryTextBox.AppendText(text);
            }
        }

        private void RefreshHistory(List<string> textList)
        {
            Logger.Log.Debug(this.ToString() + ": Was called RefreshHistory method");
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.            
            if (chatMainForm.HistoryTextBox.InvokeRequired)
            {
                Logger.Log.Debug(this.ToString() + ": InvokeRequired=true");
                Logger.Log.Debug(this.ToString() + ": Going to clear History...");
                chatMainForm.HistoryTextBox.Text = String.Empty;
                SetTextListCallback d = new SetTextListCallback(RefreshHistory);
                chatMainForm.Invoke(d, new object[] { textList });
            }
            else
            {
                Logger.Log.Debug(this.ToString() + ": InvokeRequired=false");
                Logger.Log.Debug(this.ToString() + ": Going to clear History...");
                chatMainForm.HistoryTextBox.Text = String.Empty;
                foreach (string text in textList)
                {
                    chatMainForm.HistoryTextBox.AppendText(text);
                }                
            }
        }

        #endregion

        #region Subscription for UI chnages and event handlers
        /// <summary>
        /// Here will be placed all subscriptions for the UI actions\events:
        /// </summary>
        private void SubscribeForUIActions()
        {
            chatMainForm.OpenChatListBox.SelectedValueChanged += OpenChatListBox_Click;
            chatMainForm.SendMessageButton.Click += SendMessageButton_Click;
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        /// <summary>
        /// Event handler for selected active chat in UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenChatListBox_Click(object sender, EventArgs e)
        {
            selectedActiveTopicID = chatMainForm.OpenChatListBox.SelectedValue.ToString();
            Logger.Log.Debug(this.ToString() + ": selectedActiveTopicID was set to: " + selectedActiveTopicID);            
            DisplayConversationInMainWindow();
        }
        #endregion
        
    }
}
