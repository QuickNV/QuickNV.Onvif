using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.RecordingSearch
{
    public partial class SearchPortClient
    {
        public SearchPortClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Extension.Search.XAddr)
        {
        }

        public SearchPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}