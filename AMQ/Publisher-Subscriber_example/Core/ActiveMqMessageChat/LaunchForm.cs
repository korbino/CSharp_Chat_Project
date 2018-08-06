using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiveMqMessageChat
{
    public partial class LaunchForm : Form
    {
        public LaunchForm()
        {
            InitializeComponent();
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            //Application.Run(new MainForm());
            MainForm mainForm = new MainForm();
            mainForm.Show();    
            
                 
        }
    }
}
 