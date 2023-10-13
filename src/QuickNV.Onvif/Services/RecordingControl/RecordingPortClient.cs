using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.RecordingControl
{
    public partial class RecordingPortClient
    {
        public RecordingPortClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Extension.Recording.XAddr)
        {
        }

        public RecordingPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}