using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class RecievedMessageArgs : EventArgs
    {
        public string TopicID { get; set; }
        public string Message { get; set; }
    }
}
