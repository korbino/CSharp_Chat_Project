using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LoginFuncthionality;
using System.Windows.Forms;

namespace ChatClient
{
    class RegisterNewUserController
    {
        //TODO:
        //[+] fix issue with comparing of password
        //[+] fix issue with recording user to db

        #region private boject:
        private LoginFunc loginFunc = new LoginFunc();
        private RegisterNewUser regNewUserForm;        
        #endregion

        //c-tor:
        public RegisterNewUserController (RegisterNewUser regNewUserForm)
        {
            this.regNewUserForm = regNewUserForm;
            SubscribeForUiActions();

        }


        private void SubscribeForUiActions()
        {
            regNewUserForm.RegisterButton.Click += RegisterButton_Click;
        }
        
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            regNewUserForm.StatusLabel.Text = "";

            if (IsEnteredPasswordsAreSame())
            {
                RegisterNewUserInDB();
            }
            else
            {
                regNewUserForm.StatusLabel.ForeColor = System.Drawing.Color.Red;
                regNewUserForm.StatusLabel.Text = "Entered passwords are not the same!";
            }
        }
        
        private bool IsEnteredPasswordsAreSame()
        {
            if (regNewUserForm.EnterPasswordText.Text == regNewUserForm.EneterPasswordRepeatText.Text)
                return true;
            else
                return false;
        }
        
        private void RegisterNewUserInDB()
        {
            if (loginFunc.WriteUserToDbWithEncr(
                regNewUserForm.EnterLoginNameText.Text,
                regNewUserForm.EnterPasswordText.Text,
                regNewUserForm.EnterEmailText.Text                
                ))
            {
                MessageBox.Show("User Was Successfully Registered");
                regNewUserForm.Close();
            }
            else
            {
                regNewUserForm.StatusLabel.ForeColor = System.Drawing.Color.Red;
                regNewUserForm.StatusLabel.Text = "User wasn't registered in DB";
            }
        }
    }
}
