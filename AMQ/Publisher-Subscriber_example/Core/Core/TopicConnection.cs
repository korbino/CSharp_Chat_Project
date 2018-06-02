using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace Core
{
   public class TopicConnection : IDisposable
    {
        private readonly IConnection connection;
        private readonly ISession session;
        private readonly ITopic topic;
        private bool isDisposed = false;

        /// <summary>
        /// Coonection class, using for: 
        /// - creating "Topic Publihser"
        /// - creating "Topic Subscriber"
        /// </summary>
        /// <param name="connectionFactory">Connection factory created according to broker location</param>
        /// <param name="clientId">The ID, which will identity each agent, should be unique. 
        /// Will be displaying in broker under "Subscriber" menu</param>
        /// <param name="topicName">Unique name, that will be used by broker.</param>
        public TopicConnection(IConnectionFactory connectionFactory, string clientId, string topicName)
        {
            this.connection = connectionFactory.CreateConnection();
            this.connection.ClientId = clientId;
            this.connection.Start();
            this.session = this.connection.CreateSession();
            this.topic = new ActiveMQTopic(topicName);
        }

        public SimpleTopicPublisher CreateTopicPublisher()
        {
            IMessageProducer producer = this.session.CreateProducer(this.topic);
            return new SimpleTopicPublisher(producer);
        }

        public SimpleTopicSubscriber CreateSimpleTopicSubscriber(string consumerId)
        {
            IMessageConsumer consumer = this.session.CreateDurableConsumer(this.topic, consumerId, "20 > 10", false);
            return new SimpleTopicSubscriber(consumer);
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (!this.isDisposed)
            {
                this.session.Dispose();
                this.connection.Dispose();
                this.isDisposed = true;
            }
        }

        #endregion
    }
}
