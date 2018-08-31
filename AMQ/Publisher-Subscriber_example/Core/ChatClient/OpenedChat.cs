using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core;
using Apache.NMS.ActiveMQ;

namespace ChatClient
{
    class OpenedChat
    {
        #region Private section
        private string topicID;                                 //+
        private string userName;
        private TopicConnectionFactory connectionFactory;       //+
        private TopicConnection connection;                     //+
        private SimpleTopicPublisher publisher;                 //+
        private SimpleTopicSubscriber subscriber;               //+
        private string clientId;                                //+
        private string consumerId;                              //+        
        private RecievedMessageArgs recievedMessageArgs = new RecievedMessageArgs();
        //private StringBuilder sBuilder = new StringBuilder();   
        private List<string> messagesContainer = new List<string>();
        #endregion

        public string TopicID {
            get
            {
                return topicID;
            }
            set
            {
                topicID = value;
            }
        }
        public List<string> MessagesContainer
        {
            get
            {
                return messagesContainer;
            }
        }        
        public event EventHandler<RecievedMessageArgs> RecievedNewMessage;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }


        //c-tor:
        public OpenedChat(string userName, string topicID, TopicConnectionFactory connectionFactory)
        {
            UserName = userName;
            this.connectionFactory = connectionFactory;
            TopicID = topicID;
            InitClientIDs(userName);
            InitConnectionToBroker();
            InitSubscriber();
            InitPublisher();
            recievedMessageArgs.TopicID = topicID;
        }

        //for debug purpose...
        public void PrintAllMessages()
        {
            Logger.Log.Debug(this.ToString() + "Print all messages for user name: [" + userName + "]:[" + topicID +"]");
            foreach (var v in messagesContainer)
            {
                Logger.Log.Debug(this.ToString() + v);
            }
            
        }

        public void SendMessage(string message)
        {
            publisher.SendMessage(userName + " (" + DateTime.Now + ") -> " + message);
        }

        public void Dispose()
        {
            Logger.Log.Debug(this.ToString() + ": Going to Dispose everything for user: " + UserName + ": with topicID: " + TopicID);
            publisher.Dispose();
            subscriber.Dispose();
            connection.Dispose();
        }

        #region Private methods
        private void InitClientIDs(string userName)
        {
            clientId = string.Format(userName + "_topic_" + topicID);
            consumerId = string.Format(userName + "_topic_" + topicID);
            Logger.Log.Debug(this.ToString() + ": inited clientId: " + clientId);
            Logger.Log.Debug(this.ToString() + ": inited consumerId: " + consumerId);
        }

        private void InitConnectionToBroker()
        {
            connection = connectionFactory.CreateConnection(clientId, topicID);
            Logger.Log.Debug(this.ToString() + ": Was performed connection using clientID: " + clientId + " and topicID: " + topicID);
        }

        private void InitSubscriber()
        {
            subscriber = connection.CreateSimpleTopicSubscriber(consumerId);
            subscriber.OnMessageReceived += new MessageRecieverDelegate(subscriber_OnMessageReceived);
            Logger.Log.Debug(this.ToString() + ": Was inited subscriber, with consumerID: " + consumerId);
        }

        private void subscriber_OnMessageReceived(string message)
        {
            messagesContainer.Add(message);
            recievedMessageArgs.Message = message;
            OnRecievedNewMessage();
            Logger.Log.Debug(this.ToString() + ": recieved new message: [" + topicID + "]:[" + userName  +"]: " + message);
        }

        private void InitPublisher()
        {
            publisher = connection.CreateTopicPublisher();
            Logger.Log.Debug(this.ToString() + ": Was inited publisher");
        }

        protected virtual void OnRecievedNewMessage()
        {
            Logger.Log.Debug(this.ToString() + ": OnRecievedNewMessage event triggered, with new message: " + recievedMessageArgs.Message);
            if (RecievedNewMessage != null)
                RecievedNewMessage(this,recievedMessageArgs);
        }
       
        #endregion

    }
}
