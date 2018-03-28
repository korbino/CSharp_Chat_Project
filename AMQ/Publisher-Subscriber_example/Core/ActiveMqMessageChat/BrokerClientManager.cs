using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Apache.NMS.ActiveMQ;
using BackEndMocker;

namespace ActiveMqMessageChat
{
    class BrokerClientManager
    {
        //mockers init:
        BrokerConfigMocker brConfigMocker = new BrokerConfigMocker();
        BrokerAuthenticationMocker brAuthMocker = new BrokerAuthenticationMocker();
        BrokerSQLCommunicationMocker brSQLCommunicationMocker = new BrokerSQLCommunicationMocker();
        
        //main fields definition
        public TopicConnectionFactory connectionFactory;            
        public TopicConnection connection;
        public SimpleTopicPublisher publisher;
        public SimpleTopicSubscriber subscriber;
        public string clientId;
        public string consumerId;
        public readonly StringBuilder builder = new StringBuilder();
        public string TOPIC_NAME = "TestTopicName";

        public BrokerClientManager()
        {
            string BROKER = "tcp://" + brConfigMocker.BrokerLocation + ":" + brConfigMocker.BrokerPortConnection;//localhost:61616";
            connectionFactory = new TopicConnectionFactory(new ConnectionFactory(BROKER));                        
        }               
    }
}
