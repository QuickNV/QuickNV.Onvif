using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.DoorControl
{
    public partial class DoorControlPortClient
    {
        public DoorControlPortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(DoorControl)))
        {
        }

        public DoorControlPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}