using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Extensibility;
using NServiceBus.Logging;
using NServiceBus.Transports;
using ZBrad.AsyncLib;

namespace ZBrad.TransportLib
{
    internal class MessagePump : IPushMessages
    {
        Func<PushContext, Task> pipe;
        CriticalError critical;
        PushSettings settings;       

        Task IPushMessages.Init(Func<PushContext, Task> pipe, CriticalError criticalError, PushSettings settings)
        {
            this.pipe = pipe;
            this.critical = criticalError;
            this.settings = settings;
            return Util.TaskCompleted;
        }

        void IPushMessages.Start(PushRuntimeSettings limitations)
        {
            
        }

        Task IPushMessages.Stop()
        {
            throw new NotImplementedException();
        }
    }
}
