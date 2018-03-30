using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndMocker
{
    interface IBrokerConfig
    {
        /// <summary>
        /// return hostname e.g. "localhost" only
        /// </summary>
        string BrokerLocation { get; }

        /// <summary>
        /// Return communication broker's port//
        /// </summary>
        int BrokerPortConnection { get; }
    }
}
