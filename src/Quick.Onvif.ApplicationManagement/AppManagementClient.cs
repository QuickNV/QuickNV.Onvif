using Quick.Onvif.Core;
using System.ServiceModel;

namespace Quick.Onvif.ApplicationManagement
{
    public partial class AppManagementClient
    {
        public AppManagementClient(string url, string username, string password, HttpClientCredentialType clientCredentialType = HttpClientCredentialType.Digest)
                    : base(
                          ClientFactoryBase.GetClientFactory(url, clientCredentialType).Binding,
                          new EndpointAddress(url))
        {
            ClientFactoryBase.GetClientFactory(url, clientCredentialType).InitClient(this, username, password);
        }
    }
}