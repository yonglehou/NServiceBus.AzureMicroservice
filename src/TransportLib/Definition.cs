using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Performance.TimeToBeReceived;
using NServiceBus.Routing;
using NServiceBus.Settings;
using NServiceBus.Transports;

namespace ZBrad.TransportLib
{
    public class Definition : TransportDefinition
    {
        public override string ExampleConnectionStringForErrorMessage
        {
            get
            {
                return "ws://mysite:port";
            }
        }

        protected override TransportInfrastructure Initialize(SettingsHolder settings, string connectionString)
        {
            return new Infrastructure();
        }
    }
}
