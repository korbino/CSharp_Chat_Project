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
    public partial class RegisterNewUser : Form
    {
        #region private objects   
        private RegisterNewUserController regNewUserContr;
        #endregion

        public RegisterNewUser()
        {
            InitializeComponent();
            regNewUserContr = new RegisterNewUserController(this);
        }

        private void RegisterNewUser_Load(object sender, EventArgs e)
        {            
        }
    }
}
