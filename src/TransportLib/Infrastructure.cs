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
    public class Infrastructure : TransportInfrastructure
    {
        public override IEnumerable<Type> DeliveryConstraints
        {
            get { yield return typeof(DiscardIfNotReceivedBefore); }
        }

        public override OutboundRoutingPolicy OutboundRoutingPolicy => new OutboundRoutingPolicy(OutboundRoutingType.Unicast, OutboundRoutingType.Unicast, OutboundRoutingType.Unicast);

        public override TransportTransactionMode TransactionMode => TransportTransactionMode.SendsAtomicWithReceive;

        public override EndpointInstance BindToLocalEndpoint(EndpointInstance instance)
        {
            return instance;
        }

        public override TransportReceiveInfrastructure ConfigureReceiveInfrastructure()
        {
            return new TransportReceiveInfrastructure(
                () => new MessagePump(),
                () => new QueueCreator(),
                () => Task.FromResult(StartupCheckResult.Success)
                );
        }

        public override TransportSendInfrastructure ConfigureSendInfrastructure()
        {
            return new TransportSendInfrastructure(() => new Dispatcher(), () => Task.FromResult(StartupCheckResult.Success));
        }

        public override TransportSubscriptionInfrastructure ConfigureSubscriptionInfrastructure()
        {
            throw new NotImplementedException();
        }

        public override string ToTransportAddress(LogicalAddress logicalAddress)
        {
            return Path.Combine(logicalAddress.EndpointInstance.Endpoint.ToString(),
                        logicalAddress.EndpointInstance.Discriminator ?? "",
                        logicalAddress.Qualifier ?? "");
        }
    }
}
