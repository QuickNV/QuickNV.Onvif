using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Onvif.Factorys
{
    public abstract class ClientFactory
    {
        public Binding Binding { get; private set; }
        public HttpClientCredentialType ClientCredentialType { get; private set; }
        protected string UserName { get; private set; }
        protected string Password { get; private set; }

        protected void InitConfig(Binding binding, HttpClientCredentialType clientCredentialType, string userName, string password)
        {
            Binding = binding;
            ClientCredentialType = clientCredentialType;
            UserName = userName;
            Password = password;
        }

        public virtual void InitClient<TChannel>(ClientBase<TChannel> client)
            where TChannel : class
        {
            client.Endpoint.EndpointBehaviors.Add(new Workrounds.HttpMessageHandlerBehavior());
            switch (ClientCredentialType)
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

        public static ClientFactory GetClientFactory(string scheme, string username, string password, HttpClientCredentialType clientCredentialType)
        {
            switch (scheme)
            {
                case "http":
                    return new HttpClientFactory(username, password, clientCredentialType);
                case "https":
                    return new HttpsClientFactory(username, password, clientCredentialType);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
