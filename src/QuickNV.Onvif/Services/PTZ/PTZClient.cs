using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.PTZ
{
    public partial class PTZClient
    {
        public PTZClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.PTZ.XAddr)
        {
        }

        public PTZClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}