using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMocker
{
    interface IBrokerAuthentication
    {
        /// <summary>
        /// Check if user authenticated according to prvided details
        /// </summary>
        /// <param name="userName">login name of user</param>
        /// <param name="userPAssword">password of user</param>
        /// <returns></returns>
        bool IsUserAuthenticated(string userName, string userPAssword);
    }
}
