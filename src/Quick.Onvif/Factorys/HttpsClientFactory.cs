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

namespace Quick.Onvif.Factorys
{
    public class HttpsClientFactory : ClientFactory
    {
        private HttpClientCredentialType clientCredentialType;

        public HttpsClientFactory(string userName, string password,HttpClientCredentialType clientCredentialType)
        {
            var binding = new NetHttpBinding();
            binding.MessageEncoding = NetHttpMessageEncoding.Text;
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = clientCredentialType;

            InitConfig(binding, userName, password);
            this.clientCredentialType = clientCredentialType;
        }

        private class MyX509CertificateValidator : X509CertificateValidator
        {
            public static MyX509CertificateValidator Default { get; } = new MyX509CertificateValidator();
            public override void Validate(X509Certificate2 certificate)
            {
            }
        }

        public override void InitClient<TChannel>(ClientBase<TChannel> client)
        {
            client.ChannelFactory.Credentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication()
            {
                CertificateValidationMode = X509CertificateValidationMode.Custom,
                CustomCertificateValidator = MyX509CertificateValidator.Default
            };

            switch (clientCredentialType)
            {
                case HttpClientCredentialType.Digest:
                    client.ClientCredentials.HttpDigest.ClientCredential.UserName = UserName;
                    client.ClientCredentials.HttpDigest.ClientCredential.Password = Password;
                    break;
                case HttpClientCredentialType.Basic:
                    client.ClientCredentials.UserName.UserName = UserName;
                    client.ClientCredentials.UserName.Password = Password;
                    break;
                default:
                    throw new NotSupportedException("Parameter 'clientCredentialType' only support Digest and Basic.");
            }
        }
    }
}