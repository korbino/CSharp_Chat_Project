using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace useRSA
{
   public class SQL
    {
        string ConnectionString;
        string example;
        string example1;
        int param1Key;
        int number;
        int countrows=0;
        bool ConnectionResult;

        public string WriteUserToDbSummary { get; set; }

        public SQL(string ConnectionString )
        {
            this.ConnectionString = ConnectionString;
         }

        public string ReadFromTable()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                
                conn.ConnectionString = ConnectionString;
                try
                {
                    conn.Open();
                    
                }
                catch (SqlException er)
                {
                    //MessageBox.Show(er.Message, "Something with SQL server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Console.WriteLine(er);
                }

                SqlCommand command = new SqlCommand("SELECT * FROM tblusers where UserID=9", conn);
                // Add the parameters.
                command.Parameters.Add(new SqlParameter("0", 1));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        
                        example = (String.Format("{0}", reader[2]));
                        countrows++;

                    }
                    

                }
            }


                return example;
        }


//*********************************************************************************************************
        public bool WriteToTable(string loginId, string email, string password)
        {
            int idWorker;
            bool WriteStatus = false;
            bool checkUserInDb = IsloginIdInDataBAse(loginId);
                 if (checkUserInDb) { WriteUserToDbSummary = "User is already in Database"; return WriteStatus = false; }

            idWorker = IdWorkerCount();

            using (SqlConnection connWR = new SqlConnection())
            {
                connWR.ConnectionString = ConnectionString;

                connWR.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO tblLoginData (loginId, idWorker, email, password) VALUES (@0, @1, @2, @3)", connWR);

                insertCommand.Parameters.Add(new SqlParameter("0", loginId));
                insertCommand.Parameters.Add(new SqlParameter("1", ++idWorker));
                insertCommand.Parameters.Add(new SqlParameter("2", email));
                insertCommand.Parameters.Add(new SqlParameter("3", password));
                number = insertCommand.ExecuteNonQuery();
                Console.WriteLine("SQL Insert" + number);
            }
            return WriteStatus = true;
        }




        private int IdWorkerCount()
        {
            int idWorkerLastValue = 0;
            string idWorkerStr = String.Empty;

            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = ConnectionString;
                try
                {
                    conn.Open();

                }
                catch (SqlException er)
                {
                    
                    Console.WriteLine(er);
                }

                SqlCommand command = new SqlCommand("SELECT[idWorker] FROM[teamChatDb].[dbo].[tblLoginData]", conn);
                
                command.Parameters.Add(new SqlParameter("0", 1));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                       idWorkerStr = (String.Format("{0}", reader[0]));
                       
                    }
                    
                }
            }
                  if (string.IsNullOrEmpty(idWorkerStr)) { return idWorkerLastValue = 0; }
                      else { idWorkerLastValue = Convert.ToInt32(idWorkerStr); }

            return idWorkerLastValue;
        }

        public bool IsloginIdInDataBAse(string loginId)
        {
            bool loginIdInDataBAse = true;
            string loginIdInDataBAseStr = String.Empty;

            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = ConnectionString;
                try
                {
                    conn.Open();

                }
                catch (SqlException er)
                {

                    Console.WriteLine(er);
                }

                SqlCommand command = new SqlCommand("SELECT [loginid] FROM [teamChatDb].[dbo].[tblLoginData] where loginid=" + "'" + loginId + "'", conn);

                command.Parameters.Add(new SqlParameter("0", 1));

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        loginIdInDataBAseStr = (String.Format("{0}", reader[0]));

                    }

                }
            }
            if (string.IsNullOrEmpty(loginIdInDataBAseStr)) { return loginIdInDataBAse = false; }
            else { loginIdInDataBAse = true; }

            return loginIdInDataBAse;
        }

//********************************************************************************************************

        public string CipherPass(string loginId)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = ConnectionString;
                try
                {
                    conn.Open();

                }
                catch (SqlException er)
                {
                    
                    Console.WriteLine(er);
                }

                SqlCommand command = new SqlCommand("SELECT [password] FROM [teamChatDb].[dbo].[tblLoginData] where loginid=" + "'" + loginId + "'", conn);
                
                command.Parameters.Add(new SqlParameter("0", 1));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                       
                        example = (String.Format("{0}", reader[0]));
                        countrows++;

                    }
                    //param1Key =Convert.ToInt32(example);

                }
            }


            return example;
        }

       
    }
}
