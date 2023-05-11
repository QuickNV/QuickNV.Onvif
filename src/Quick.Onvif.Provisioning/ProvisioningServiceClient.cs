using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.Provisioning
{
    public partial class ProvisioningServiceClient
    {
        public ProvisioningServiceClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(Provisioning)))
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