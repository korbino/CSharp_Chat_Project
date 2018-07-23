using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;
using Apache.NMS;

namespace Core
{
    public delegate void MessageRecieverDelegate(string message);

    public class SimpleTopicSubscriber : IDisposable
    {
        private readonly IMessageConsumer consumer;
        private bool isDisposed = false;
        public event MessageRecieverDelegate OnMessageReceived;

        public SimpleTopicSubscriber(IMessageConsumer consumer)
        {
            this.consumer = consumer;
            this.consumer.Listener += new MessageListener(OnMessage);//TODO: - ???            
        }

        public void OnMessage(IMessage message)
        {
            ITextMessage textMessage = message as ITextMessage;
            if (this.OnMessageReceived != null)
            {
                this.OnMessageReceived(textMessage.Text);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (!this.isDisposed)
            {
                this.consumer.Dispose();
                this.isDisposed = true;
            }
        }

        #endregion
    }
}
