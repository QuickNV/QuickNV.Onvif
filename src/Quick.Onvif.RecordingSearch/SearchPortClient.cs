using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.RecordingSearch
{
    public partial class SearchPortClient
    {
        public SearchPortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(RecordingSearch)))
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