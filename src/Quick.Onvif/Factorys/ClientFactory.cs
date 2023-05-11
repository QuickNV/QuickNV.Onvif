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

        protected void InitConfig(Binding binding)
        {
            this.Binding = binding;
        }

        public abstract void InitClient<TChannel>(ClientBase<TChannel> client, string username, string password)
            where TChannel : class;


        private static Dictionary<string, ClientFactory> clientFactoryDict = new Dictionary<string, ClientFactory>();
        public static ClientFactory GetClientFactory(string url, HttpClientCredentialType clientCredentialType)
        {
            var uri = new Uri(url);
            var key = $"{uri.Scheme}_{clientCredentialType}";
            if (clientFactoryDict.TryGetValue(key, out ClientFactory clientFactory))
                return clientFactory;

            switch (uri.Scheme)
            {
                case "http":
                    clientFactory = new HttpClientFactory(clientCredentialType);
                    break;
                case "https":
                    clientFactory = new HttpsClientFactory(clientCredentialType);
                    break;
                default:
                    throw new NotSupportedException();
            }
            clientFactoryDict[key] = clientFactory;
            return clientFactory;
        }
    }
}
