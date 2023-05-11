using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.RecordingSearch
{
    public partial class SearchPortClient
    {
        public SearchPortClient(string url, string username, string password, HttpClientCredentialType clientCredentialType = HttpClientCredentialType.Digest)
            : base(
                  ClientFactory.GetClientFactory(url, clientCredentialType).Binding,
                  new EndpointAddress(url))
        {
            ClientFactory.GetClientFactory(url, clientCredentialType).InitClient(this, username, password);
        }
    }
}