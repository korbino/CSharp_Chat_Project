using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace Core
{
   public class TopicConnectionFactory
    {
        private readonly IConnectionFactory connectionFactory;

        public TopicConnectionFactory(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public TopicConnection CreateConnection(string clientId, string topicName)
        {
            return new TopicConnection(this.connectionFactory, clientId, topicName);
        }
    }
}
