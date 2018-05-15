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
            if (userOne == "harden" && userTwo == "appntau" || userOne == "appntau" && userTwo == "harden")
            {
                return 12;
            }
            //comm between 1 and 3
            else if (userOne == "harden" && userTwo == "dbntau" || userOne == "dbntau" && userTwo == "harden")
            {
                return 13;
            }
            //comm between 2 and 3
            else if (userOne == "appntau" && userTwo == "dbntau" || userOne == "dbntau" && userTwo == "appntau")
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
            usersList.Add("harden");
            usersList.Add("dbntau");
            usersList.Add("appntau");
            return usersList;
        }
    }
}
