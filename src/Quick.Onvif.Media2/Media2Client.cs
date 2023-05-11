using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.Media2
{
    public partial class Media2Client
    {
        public Media2Client(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Media.XAddr)
        {
        }

        public Media2Client(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}