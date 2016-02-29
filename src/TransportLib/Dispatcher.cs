using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NServiceBus.Extensibility;
using NServiceBus.Transports;

namespace ZBrad.TransportLib
{
    internal class Dispatcher : IDispatchMessages
    {
        Task IDispatchMessages.Dispatch(TransportOperations outgoingMessages, ContextBag context)
        {
            throw new NotImplementedException();
        }
    }
}
