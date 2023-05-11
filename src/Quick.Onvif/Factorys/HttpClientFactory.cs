using System.ServiceModel;

namespace Quick.Onvif.Factorys
{
    public class HttpClientFactory : ClientFactory
    {
        private HttpClientCredentialType clientCredentialType;

        public HttpClientFactory()
            : this(HttpClientCredentialType.Digest)
        {
        }

        public HttpClientFactory(HttpClientCredentialType clientCredentialType)
        {
            var binding = new NetHttpBinding();
            binding.MessageEncoding = NetHttpMessageEncoding.Text;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = clientCredentialType;

            InitConfig(binding);
            this.clientCredentialType = clientCredentialType;
        }

        public override void InitClient<TChannel>(ClientBase<TChannel> client, string username, string password)
        {
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
        }
    }
}