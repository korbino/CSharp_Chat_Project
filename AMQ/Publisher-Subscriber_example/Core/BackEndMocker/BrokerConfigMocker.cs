using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMocker
{
    public class BrokerConfigMocker : IBrokerConfig
    {
        public string BrokerLocation
        {
            get
            {
                return "localhost";
            }
        }

        public int BrokerPortConnection
        {
            get
            {
                return 61616;
            }
        }
    }
}
