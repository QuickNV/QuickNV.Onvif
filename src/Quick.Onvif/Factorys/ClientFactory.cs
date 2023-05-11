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
        protected string UserName { get; private set; }
        protected string Password { get; private set; }

        protected void InitConfig(Binding binding, string userName, string password)
        {
            Binding = binding;
            UserName = userName;
            Password = password;
        }

        public abstract void InitClient<TChannel>(ClientBase<TChannel> client)
            where TChannel : class;

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
