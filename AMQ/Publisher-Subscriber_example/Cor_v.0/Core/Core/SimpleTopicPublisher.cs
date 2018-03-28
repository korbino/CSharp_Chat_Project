using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ.Commands;
using Apache.NMS.ActiveMQ;

namespace Core
{
   public class SimpleTopicPublisher : IDisposable
    {
        private readonly IMessageProducer producer;
        private bool isDisposed = false;

        public SimpleTopicPublisher(IMessageProducer producer)
        {
            this.producer = producer;
        }

        public void SendMessage(string message)
        {
            if (!this.isDisposed)
            {
                ITextMessage textMessage = new ActiveMQTextMessage(message);
                this.producer.Send(textMessage);
            }
            else
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (!this.isDisposed)
            {
                this.producer.Dispose();
                this.isDisposed = true;
            }
        }

        #endregion
    }
}
