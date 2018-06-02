using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMocker
{
    public class BrokerSQLCommunicationMocker : IBrokerSQLCommunication
    {
        public List<int> GetAllTopicIDsByUserName(string userName)
        {
            return new List<int> { 29};
        }

        public int GetTopicID(string userOne, string userTwo)
        {
            //communication between user 1 and 2
            if (userOne == "harden" && userTwo == "appntau" || userOne == "appntau" && userTwo == "harden")
            {
                UsersDB.hardenAppntau = "12";
                UsersDB.appntauHarden = "12";
                return 12;
            }
            //comm between 1 and 3
            else if (userOne == "harden" && userTwo == "dbntau" || userOne == "dbntau" && userTwo == "harden")
            {
                UsersDB.hardenDbntau = "13";
                UsersDB.dbntauHarden = "13";
                return 13;
            }
            //comm between 2 and 3
            else if (userOne == "appntau" && userTwo == "dbntau" || userOne == "dbntau" && userTwo == "appntau")
            {
                UsersDB.appntauDbntau = "23";
                UsersDB.dbntauAppntau = "23";
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


        //TODO: not completed mock method
        public bool IsUserExistingInChat(string userName, int topicId)
        {
            return true;

        }

        public bool IsUsersInSameChat(string userOne, string userTwo)
        {
            if (userOne == "harden" && userTwo == "appntau" || userOne == "appntau" && userTwo == "harden")
            {
                if (UsersDB.hardenAppntau != null && UsersDB.appntauHarden != null)
                    return true;
                else
                    return false;
            }
            else if (userOne == "harden" && userTwo == "dbntau" || userOne == "dbntau" && userTwo == "harden")
            {
                if (UsersDB.hardenDbntau != null && UsersDB.dbntauHarden != null)
                    return true;
                else
                    return false;
            }
            else if (userOne == "dbntau" && userTwo == "appntau" || userOne == "appntau" && userTwo == "dbntau")
            {
                if (UsersDB.dbntauAppntau != null && UsersDB.appntauDbntau != null)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }

   static class UsersDB
    {
       static public string hardenAppntau = null;
       static public string appntauHarden = null;
       static public string hardenDbntau = null;
       static public string dbntauHarden = null;
       static public string appntauDbntau = null;
       static public string dbntauAppntau = null;
    }

}
