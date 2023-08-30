using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.AccessControl
{
    public partial class PACSPortClient
    {
        public PACSPortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(AccessControl)))
        {
        }

        public PACSPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}