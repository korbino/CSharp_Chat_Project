﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace useRSA
{
   public class LoginFunc
    {
        string xmlPath;

        


        public LoginFunc(string xmlPath)
                    {
                      this.xmlPath = xmlPath; 
                    }



        public bool WriteUserToDbWithEncr(string loginName, string plainPassword, string email)
             {
                      bool IsUserInDb=false;
               string pathToPublicKey = readPublicKeyPathfromXML(xmlPath);
               RSAEncryptDecrypt EncryptPassword = new RSAEncryptDecrypt();
               string cipherPassword=EncryptPassword.encryptRSA(plainPassword, pathToPublicKey);
               string dbConectionString = readDetailsfromXML(xmlPath);

               SQL SqlWriteUserToDatabase = new SQL(dbConectionString);

                   IsUserInDb = SqlWriteUserToDatabase.WriteToTable(loginName,email,cipherPassword);


                     return IsUserInDb;

             }

        public bool IsUserCorrect( string loginName, string passwordUser)
        {
            bool isLoginAlreadyInDb = false;

            string dbConectionString = readDetailsfromXML(xmlPath);
            SQL mySQLreadfromDBuser = new SQL(dbConectionString);
                isLoginAlreadyInDb= mySQLreadfromDBuser.IsloginIdInDataBAse(loginName);
                   if (!isLoginAlreadyInDb) { return false; }

            RSAEncryptDecrypt EncryptPassword = new RSAEncryptDecrypt();

            string cypherText = mySQLreadfromDBuser.CipherPass(loginName);
            string plainPasswordfromDB;
            if (string.IsNullOrEmpty(cypherText))
            {
                Console.WriteLine("****Login Failed********");
                return false;
            }

            plainPasswordfromDB = EncryptPassword.DecryptPassword(cypherText);
            bool dessision = plainPasswordfromDB.Equals(passwordUser);
            if (dessision == true)
            {
                Console.WriteLine("****Login succesfull********");

            }
            else
            {
                Console.WriteLine("****Login Failed*Dessision*******");
            }

            return dessision;


        }











        private string readDetailsfromXML(string xmlPath)
           {
                string dataBaseDetails;
                ConfigXML DataBaseDet = new ConfigXML();
                dataBaseDetails = DataBaseDet.OpenXmlConnectionString(xmlPath);
                    if (String.IsNullOrEmpty(dataBaseDetails))
                       {
                           Console.WriteLine("File not found");
                       }

                return dataBaseDetails;
           }
       private string readPublicKeyPathfromXML(string xmlPath)
           {

               string publicKeyPath;
               ConfigXML DataBaseDet = new ConfigXML();
               publicKeyPath = DataBaseDet.OpenXmlPublicKeyPath(xmlPath);
                   if (String.IsNullOrEmpty(publicKeyPath))
                      {
                          Console.WriteLine("File not found");
                      }

               return publicKeyPath;
          }
    }
}
