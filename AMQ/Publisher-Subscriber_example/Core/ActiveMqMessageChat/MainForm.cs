using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Apache.NMS.ActiveMQ;
using BackEndMocker;

namespace ActiveMqMessageChat
{
    public partial class MainForm : Form
    {
        BrokerClientManager broCliMan;
       
        public MainForm()
        {            
            InitializeComponent();
            broCliMan = new BrokerClientManager(this);
            broCliMan.InitUsersComboboxes();

            this.messageTextBox.Enabled = false;
            this.historyTextBox.Enabled = false;
            this.submitButton.Enabled = false;
            this.targetUserComboBox.Enabled = false;
            this.startDialogButton.Enabled = false;
            Logger.InitLogger();
            Logger.Log.Info("Main form is started");
        }             

        private void connectButton_Click_1(object sender, EventArgs e)
        {
            try
            {                               
                broCliMan.MakeLogin();                                     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }
        
        private void submitButton_Click_1(object sender, EventArgs e)
        {
            broCliMan.SendMessage();            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                broCliMan.Dispose();
            }
            catch { }
        }

        private void startDialogButton_Click(object sender, EventArgs e)
        {
            try
            {
                broCliMan.StartDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            
        }
    }
}
