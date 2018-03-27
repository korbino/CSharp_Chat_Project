using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMocker
{
    public class BrokerAuthenticationMocker : IBrokerAuthentication
    {   
        public bool IsUserAuthenticated(string userName, string userPAssword)
        {
            return true;
        }
    }
}
