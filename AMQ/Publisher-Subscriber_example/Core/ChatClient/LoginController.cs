﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLinfra;
using LoginFuncthionality;
using InfrastructureChat;


namespace ChatClient
{
    class LoginController
    {
        #region PRIVATE Fields\Properties
        private LoginFunc loginFunc = new LoginFunc();
        private SQLInfrastructure sqlInfra = new SQLInfrastructure(ConfigChatDll.OpenXmlConnectionString());          
        private LoginForm loginForm;
        private ChatMainForm chatMainForm;
        private RegisterNewUser regNewUserForm;
        #endregion

        //ctor
        public LoginController(LoginForm loginForm)
        {
            this.loginForm = loginForm;
            SubscribeForUIActions();
        }
        
        /// <summary>
        /// Check that user authenticated
        /// If yes - close LoginForm and open ChatMainForm
        /// If no - return exception
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        public void MakeLogin(string userName, string userPassword)
        {
            if (loginFunc.IsUserCorrect(userName, userPassword)) 
            {                
                chatMainForm = new ChatMainForm(userName);
                loginForm.Close();
                chatMainForm.Show();                
            }
            else
            {
                throw new Exception("User is not Authenticate!");
            }
        }   
        
        /// <summary>
        /// Subscribing for UI events methods.
        /// </summary>
        private void SubscribeForUIActions()
        {
            loginForm.RegisterNewUserButton.Click += RegisterNewUserButton_Click;
        }

        private void RegisterNewUserButton_Click(object sender, EventArgs e)
        {
            regNewUserForm = new RegisterNewUser();
            regNewUserForm.Show();
        }
    }
}
