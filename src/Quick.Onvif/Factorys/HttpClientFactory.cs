using System.ServiceModel;

namespace Quick.Onvif.Factorys
{
    public class HttpClientFactory : ClientFactory
    {
        private HttpClientCredentialType clientCredentialType;

        public HttpClientFactory(string userName, string password, HttpClientCredentialType clientCredentialType)
        {
            var binding = new NetHttpBinding();
            binding.MessageEncoding = NetHttpMessageEncoding.Text;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = clientCredentialType;

            InitConfig(binding, userName, password);
            this.clientCredentialType = clientCredentialType;
        }

        public override void InitClient<TChannel>(ClientBase<TChannel> client)
        {
            switch (clientCredentialType)
            {
                case HttpClientCredentialType.None:
                    break;
                case HttpClientCredentialType.Digest:
                    client.ClientCredentials.HttpDigest.ClientCredential.UserName = UserName;
                    client.ClientCredentials.HttpDigest.ClientCredential.Password = Password;
                    break;
                case HttpClientCredentialType.Basic:
                    client.ClientCredentials.UserName.UserName = UserName;
                    client.ClientCredentials.UserName.Password = Password;
                    break;
                default:
                    throw new NotSupportedException("Parameter 'clientCredentialType' only support None、Digest and Basic.");
            }
        }
    }
}