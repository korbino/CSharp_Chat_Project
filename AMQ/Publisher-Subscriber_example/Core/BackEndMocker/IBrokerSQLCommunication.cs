using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMocker
{
    interface IBrokerSQLCommunication
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
        int CreateNewTopicID(string userOne, string userTwo);      //TODO: need to change name of method to "GetTopicID". AIs: Yura, Igor.  
      
    }
}
