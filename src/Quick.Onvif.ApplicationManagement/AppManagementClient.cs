using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.ApplicationManagement
{
    public partial class AppManagementClient
    {
        public AppManagementClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(ApplicationManagement)))
        {
        }

        public AppManagementClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}