using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.Uplink
{
    public partial class UplinkPortClient
    {
        public UplinkPortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(Uplink)))
        {
        }

        public UplinkPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}