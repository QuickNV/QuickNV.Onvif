using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.Media
{
    public partial class MediaClient
    {
        public MediaClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Media.XAddr)
        {
        }

        public MediaClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}