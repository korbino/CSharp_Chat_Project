using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActiveMqMessageChat.MVC;

namespace ActiveMqMessageChat
{
    public partial class LaunchForm : Form
    {

        private Viewer view;

        public LaunchForm()
        {
            InitializeComponent();
            view = new Viewer(this);
        }

        private void launchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
 