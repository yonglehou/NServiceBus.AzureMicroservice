using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NServiceBus.Transports;

namespace ZBrad.TransportLib
{
    internal class QueueCreator : ICreateQueues
    {
        Task ICreateQueues.CreateQueueIfNecessary(QueueBindings queueBindings, string identity)
        {
            throw new NotImplementedException();
        }
    }
}
