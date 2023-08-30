using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.Receiver
{
    public partial class ReceiverPortClient
    {
        public ReceiverPortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(Receiver)))
        {
        }

        public ReceiverPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}