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
        public HttpsClientFactory(string userName, string password, HttpClientCredentialType clientCredentialType)
        {
            var binding = new NetHttpBinding();
            binding.UseDefaultWebProxy = false;
            binding.MessageEncoding = NetHttpMessageEncoding.Text;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = clientCredentialType;

            InitConfig(binding, clientCredentialType, userName, password);
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
            base.InitClient(client);
        }
    }
}