using Quick.Onvif.Factorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Onvif.Event
{
    public partial class SubscriptionManagerClient
    {
        public SubscriptionManagerClient(OnvifClient client)
                    : this(client.ClientFactory, client.Capabilities.Events.XAddr)
        {
        }

        public SubscriptionManagerClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
