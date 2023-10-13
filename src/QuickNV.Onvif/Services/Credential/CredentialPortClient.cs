using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.Credential
{
    public partial class CredentialPortClient
    {
        public CredentialPortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetExtensionXAddr(nameof(Credential)))
        {
        }

        public CredentialPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}