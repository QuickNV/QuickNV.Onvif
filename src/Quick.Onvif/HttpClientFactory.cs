using System.ServiceModel;

namespace Quick.Onvif
{
    public class HttpClientFactory : ClientFactoryBase
    {
        private string username;
        private string password;
        private HttpClientCredentialType clientCredentialType;

        public HttpClientFactory(string url, string username, string password)
            : this(url, username, password, HttpClientCredentialType.Digest)
        {
        }

        public HttpClientFactory(string url, string username, string password, HttpClientCredentialType clientCredentialType)
        {
            var binding = new NetHttpBinding();
            binding.MessageEncoding = NetHttpMessageEncoding.Text;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = clientCredentialType;

            var endpoint = new EndpointAddress(url);
            Init(binding, endpoint);

            this.username = username;
            this.password = password;
            this.clientCredentialType = clientCredentialType;
        }

        public override TClient Create<TChannel, TClient>()
        {
            var client = base.Create<TChannel, TClient>();
            switch (clientCredentialType)
            {
                case HttpClientCredentialType.Digest:
                    client.ClientCredentials.HttpDigest.ClientCredential.UserName = username;
                    client.ClientCredentials.HttpDigest.ClientCredential.Password = password;
                    break;
                case HttpClientCredentialType.Basic:
                    client.ClientCredentials.UserName.UserName = username;
                    client.ClientCredentials.UserName.Password = password;
                    break;
                default:
                    throw new NotSupportedException("Parameter 'clientCredentialType' only support Digest and Basic.");
            }
            return client;
        }
    }
}