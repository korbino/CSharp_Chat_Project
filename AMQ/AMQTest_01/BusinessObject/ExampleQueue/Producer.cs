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

namespace ExampleQueue
{
    public partial class Producer : Form
    {
        public Producer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            IObjectMessage objMessage;

            //init obj which will be send from producer to amq:
            OperatorRequestObject OperatorRequestObject = new OperatorRequestObject();
            OperatorRequestObject.Shortcode = textBoxSendMessage.Text.ToString();

            //creating connection factory with tcp connection to AMQ:
            IConnectionFactory factory = new NMSConnectionFactory("tcp://localhost:61616");

            //Creating connection itself using factory:
            IConnection connection = factory.CreateConnection();
            connection.Start();

            //create session using connection
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);

            //Init queue destination using session and que name. Que name 
            IDestination QueueDestination = SessionUtil.GetDestination(session, "QueueName_01");

            IMessageProducer MessageProducer = session.CreateProducer(QueueDestination);
            MessageProducer.DeliveryMode = MsgDeliveryMode.Persistent;
            objMessage = session.CreateObjectMessage(OperatorRequestObject);

            MessageProducer.Send(objMessage);
            session.Close();
            connection.Stop();

            textBoxSendMessage.Clear();
        }
    }
}
