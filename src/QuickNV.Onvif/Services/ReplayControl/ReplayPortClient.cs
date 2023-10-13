using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.ReplayControl
{
    public partial class ReplayPortClient
    {
        public ReplayPortClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Extension.Replay.XAddr)
        {
        }

        public ReplayPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}