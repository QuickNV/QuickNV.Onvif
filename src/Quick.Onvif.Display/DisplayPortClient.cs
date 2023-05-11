using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.Display
{
    public partial class DisplayPortClient
    {
        public DisplayPortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(Display)))
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