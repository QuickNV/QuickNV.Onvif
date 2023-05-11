using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.Analytics
{
    public partial class RuleEnginePortClient
    {
        public RuleEnginePortClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Analytics.XAddr)
        {
        }

        public RuleEnginePortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}