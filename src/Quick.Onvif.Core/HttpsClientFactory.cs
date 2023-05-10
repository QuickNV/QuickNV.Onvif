using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Onvif.Core
{
    public class HttpsClientFactory : ClientFactoryBase
    {
        private HttpClientCredentialType clientCredentialType;
        public static HttpsClientFactory Default { get; } = new HttpsClientFactory();

        public HttpsClientFactory()
            : this(HttpClientCredentialType.Digest)
        {
        }

        public HttpsClientFactory(HttpClientCredentialType clientCredentialType)
        {
            var binding = new NetHttpBinding();
            binding.MessageEncoding = NetHttpMessageEncoding.Text;
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = clientCredentialType;
            
            InitConfig(binding);
            this.clientCredentialType = clientCredentialType;
        }

        private class MyX509CertificateValidator : X509CertificateValidator
        {
            public static MyX509CertificateValidator Default { get; } = new MyX509CertificateValidator();
            public override void Validate(X509Certificate2 certificate)
            {
            }
        }

        public override void InitClient<TChannel>(ClientBase<TChannel> client, string username, string password)
        {
            client.ChannelFactory.Credentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication()
            {
                CertificateValidationMode = X509CertificateValidationMode.Custom,
                CustomCertificateValidator = MyX509CertificateValidator.Default
            };

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