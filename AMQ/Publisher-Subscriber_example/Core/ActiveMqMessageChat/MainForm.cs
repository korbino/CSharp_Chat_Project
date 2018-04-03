﻿using System;
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
        private BrokerClientManager broCliMan = new BrokerClientManager();
        BindingSource bs = new BindingSource();   //this is for combobox user list from db     

        public MainForm()
        {            
            InitializeComponent();
            //extract users list from DB: 
            bs.DataSource = broCliMan.brSQLCommunicationMocker.GetUserListFromDB();
            usersInDBComboBox.DataSource = bs;
        }             

        private void connectButton_Click_1(object sender, EventArgs e)
        {
            try
            {                               
                //create connection
                broCliMan.Connection(this.clientIdTextBox.Text, this);                                                              

                this.clientIdLabel.Enabled = false;
                this.clientIdTextBox.Enabled = false;
                this.connectButton.Enabled = false;
                this.messageTextBox.Enabled = true;
                this.instructionLabel.Enabled = true;
                this.historyTextBox.Enabled = true;
                this.submitButton.Enabled = true;
                this.usersInDBComboBox.Enabled = false;
                this.passwordTextBox.Enabled = false;            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
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

        private void instructionLabel_Click(object sender, EventArgs e)
        {

        }

    }
}
