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
    public partial class ChatMainForm : Form
    {
        //private:
        private ChatMainController chatMainController;

        //public:
        public string UserName { get; set; }

        //c-tor:
        public ChatMainForm(string userName)
        {
            Logger.InitLogger();                                 
            InitializeComponent();            
            Logger.Log.Debug(this.ToString() + ": was init");
            UserName = userName;
            chatMainController = new ChatMainController(this);            
        }

        private void SendMessageButton_Click(object sender, EventArgs e)
        {
            //chatMainController.PrintToLogAllMessagesForAllOpenChats();
            chatMainController.SendMessage();
        }
    } 
}
