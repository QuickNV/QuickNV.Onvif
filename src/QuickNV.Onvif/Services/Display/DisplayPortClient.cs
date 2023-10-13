using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.Display
{
    public partial class DisplayPortClient
    {
        public DisplayPortClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Extension.Display.XAddr)
        {
        }

        public DisplayPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}