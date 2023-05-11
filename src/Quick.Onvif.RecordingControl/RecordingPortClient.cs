using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.RecordingControl
{
    public partial class RecordingPortClient
    {
        public RecordingPortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(RecordingControl)))
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