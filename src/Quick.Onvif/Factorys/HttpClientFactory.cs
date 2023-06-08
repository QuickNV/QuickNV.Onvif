using System.ServiceModel;

namespace Quick.Onvif.Factorys
{
    public class HttpClientFactory : ClientFactory
    {
        public HttpClientFactory(string userName, string password, HttpClientCredentialType clientCredentialType)
        {
            var binding = new NetHttpBinding();
            binding.MessageEncoding = NetHttpMessageEncoding.Text;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = clientCredentialType;
            InitConfig(binding, clientCredentialType, userName, password);
        }
    }
}