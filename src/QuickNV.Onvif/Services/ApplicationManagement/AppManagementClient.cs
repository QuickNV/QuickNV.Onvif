using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.ApplicationManagement
{
    public partial class AppManagementClient
    {
        public AppManagementClient(OnvifClient client)
            : this(client.ClientFactory, client.GetExtensionXAddr(nameof(ApplicationManagement)))
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