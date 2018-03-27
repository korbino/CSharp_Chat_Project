using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apache.NMS;
using Apache.NMS.Util;
using BusinessObject;

namespace Queue
{
    public partial class Subscriber_1 : Form
    {
        public Subscriber_1()
        {
            InitializeComponent();
            reciever();
        }

        private void reciever()
        {
            IConnectionFactory factory = new NMSConnectionFactory("tcp://localhost:61616");
            IConnection connection = factory.CreateConnection();
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            IDestination destination = SessionUtil.GetDestination(session, "QueueName_01");
            IMessageConsumer reciever = session.CreateConsumer(destination);
            reciever.Listener += new MessageListener(Message_Listner);
        }

        private void Message_Listner(IMessage message)
        {
            IObjectMessage objMessage = message as IObjectMessage;
            OperatorRequestObject OperatorRequestObject = ((BusinessObject.OperatorRequestObject)(objMessage.Body));
            //MessageBox.Show(OperatorRequestObject.Shortcode);

            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { label1.Text += "\n" + OperatorRequestObject.Shortcode; });
           
        }
    }
}
