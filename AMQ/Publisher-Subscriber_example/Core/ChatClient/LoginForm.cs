using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class LoginForm : Form
    {
        private LoginController loginController;

        public LoginForm()
        {            
            InitializeComponent();
            PasswordText.PasswordChar = '*';
            loginController = new LoginController(this);
        }

        #region Text Forms maintenance
        private void LoginName_Enter(object sender, EventArgs e)
        {
            if (LoginNameText.Text == "Login")
                LoginNameText.Text = "";

            LoginNameText.ForeColor = Color.Black;
        }

        private void LoginNameText_Leave(object sender, EventArgs e)
        {
            if (LoginNameText.Text == "")
                LoginNameText.Text = "Login";

            LoginNameText.ForeColor = Color.Gray;
        }

        private void PasswordText_Enter(object sender, EventArgs e)
        {
            if (PasswordText.Text == "Password")
                PasswordText.Text = "";

            PasswordText.ForeColor = Color.Black;
        }

        private void PasswordText_Leave(object sender, EventArgs e)
        {
            if (PasswordText.Text == "")
                PasswordText.Text = "Password";

            PasswordText.ForeColor = Color.Gray;
        }
        #endregion

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                loginController.MakeLogin(this.LoginNameText.Text, this.PasswordText.Text);
            }     
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
    }
}
