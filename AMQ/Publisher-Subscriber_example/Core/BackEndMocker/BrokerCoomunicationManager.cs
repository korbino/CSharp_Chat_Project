using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMocker
{
    public class BrokerCoomunicationManager : IBrokerCommunicationManager
    {   
        public int CreateNewTopicID(string userOne, string userTwo)
        {
            Random rand = new Random();
            return rand.Next(1, 1000);            
        }

        public List<string> GetUserListFromDB()
        {
            List<string> usersList = new List<string>();
            usersList.Add("user_1");
            usersList.Add("user_2");
            usersList.Add("user_3");
            return usersList;
        }

        public bool IsUserAuthenticated(string userName, string userPAssword)
        {
            return true;
        }
    }
}
