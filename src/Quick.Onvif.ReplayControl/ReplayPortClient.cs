using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.ReplayControl
{
    public partial class ReplayPortClient
    {
        public ReplayPortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(ReplayControl)))
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