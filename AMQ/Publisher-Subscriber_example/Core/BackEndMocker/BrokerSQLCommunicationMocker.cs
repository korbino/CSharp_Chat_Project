using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMocker
{
   public class BrokerSQLCommunicationMocker : IBrokerSQLCommunication
    {
        public int CreateNewTopicID(string userOne, string userTwo)
        {
            return 300;
        }

        public List<string> GetUserListFromDB()
        {
            List<string> usersList = new List<string>();
            usersList.Add("user_1");
            usersList.Add("user_2");
            usersList.Add("user_3");
            return usersList;
        }
    }
}
