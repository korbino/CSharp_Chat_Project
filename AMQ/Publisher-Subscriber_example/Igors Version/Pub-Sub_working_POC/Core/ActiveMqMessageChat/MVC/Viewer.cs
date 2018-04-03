using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Apache.NMS.ActiveMQ;
using useRSA;
using System.Windows.Forms;

namespace ActiveMqMessageChat.MVC
{
    class Viewer
    {
        private LaunchForm LaunchForm;
        private MainForm MainForm;
        //******************************
       // bool isUserinDBbool;
       // private string clientId;
       // private string consumerId;
       // private string consumerPassword;   //IgorSu
       // string broker = string.Empty;
        //private delegate void SetTextCallback(string text);


        public Viewer(LaunchForm LaunchForm)
        {
            
            this.LaunchForm = LaunchForm;
            LaunchForm.launchButton.Click += launchButton_Click;

        }


        private void launchButton_Click(object sender, EventArgs e)
        {
            
            InitConfigForm();
        }

        /* private void InitConfigForm()
         {
             MainForm = new MainForm();
             MainForm.connectButton.Click += connectButton_Click;
             MainForm.submitButton.Click += submitButton_Click;
             MainForm.clientPasstextBox.PasswordChar = '*';
             MainForm.Show();

         }   */

        private void InitConfigForm()
        {
            MainForm = new MainForm();
            MainViewer mainViewer = new MainViewer(MainForm);

            MainForm.Show();

        }



    }
}
