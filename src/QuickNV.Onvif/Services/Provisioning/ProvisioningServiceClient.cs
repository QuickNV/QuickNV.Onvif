using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.Provisioning
{
    public partial class ProvisioningServiceClient
    {
        public ProvisioningServiceClient(OnvifClient client)
            : this(client.ClientFactory, client.GetExtensionXAddr(nameof(Provisioning)))
        {
        }

        public ProvisioningServiceClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}