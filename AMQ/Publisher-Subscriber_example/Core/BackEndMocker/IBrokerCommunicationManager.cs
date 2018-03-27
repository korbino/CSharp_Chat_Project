using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMocker
{
    interface IBrokerCommunicationManager
    {
        /// <summary>
        /// Read all users from DB
        /// </summary>
        /// <returns>List of existing users</returns>
        List<string> GetUserListFromDB();

        /// <summary>
        /// Create new unique topic ID according to SQL autoincrement. In future Params will be used as arguments.
        /// </summary>
        /// <param name="userOne">init user</param>
        /// <param name="userTwo">secondary user</param>
        /// <returns>return ID from SQL</returns>
        int CreateNewTopicID(string userOne, string userTwo);

        /// <summary>
        /// Check if user authenticated according to prvided details
        /// </summary>
        /// <param name="userName">login name of user</param>
        /// <param name="userPAssword">password of user</param>
        /// <returns></returns>
        bool IsUserAuthenticated(string userName, string userPAssword);    
      
    }
}
