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
            //communication between user 1 and 2
            if (userOne == "user_1" && userTwo == "user_2" || userOne == "user_2" && userTwo == "user_1")
            {
                return 12;
            }
            //comm between 1 and 3
            else if (userOne == "user_1" && userTwo == "user_3" || userOne == "user_3" && userTwo == "user_1")
            {
                return 13;
            }
            //comm between 2 and 3
            else if (userOne == "user_2" && userTwo == "user_3" || userOne == "user_3" && userTwo == "user_2")
            {
                return 23;
            }
            else
            {
                throw new Exception("Please select correct users!");                
            }
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
