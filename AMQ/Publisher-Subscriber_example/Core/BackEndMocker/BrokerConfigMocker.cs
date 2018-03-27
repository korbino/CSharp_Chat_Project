using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMocker
{
    class BrokerConfigMocker : IBrokerConfig
    {
        public string BrokerLocation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int BrokerPortConnection
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private string brokerLocation = "localhost";
        private int brokerPortConnection = 61616;
    }
}
