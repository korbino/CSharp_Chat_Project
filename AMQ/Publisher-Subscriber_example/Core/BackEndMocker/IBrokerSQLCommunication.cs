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
        int GetTopicID(string userOne, string userTwo);      //Updated name of method

        /// <summary>
        /// Rreturn true in case of user existing in defined topic ID, false - in vice versa.
        /// </summary>
        /// <param name="userName">user identifier</param>
        /// <param name="topicId">id of topic</param>
        /// <returns></returns>
        bool IsUserExistingInChat(string userName, int topicId);
    

        /// <summary>        
        /// Return true in case of both users existing under same topic ID. All users should be active there.
        /// </summary>
        /// <param name="userOne"></param>
        /// <param name="userTwo"></param>
        /// <returns></returns>
        bool IsUsersInSameChat(string userOne, string userTwo);

        /// <summary>
        /// Remove users from topic ID 
        /// </summary>
        /// <param name="topicId"></param>
        /// <returns></returns>
        //bool CompleteConversationByTopicID (int topicId);

        /// <summary>
        /// Return list of topic ID, where defined user exisgin and alive.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        List<int> GetAllActiveTopicIDsByUserName(string userName);
    }
}
