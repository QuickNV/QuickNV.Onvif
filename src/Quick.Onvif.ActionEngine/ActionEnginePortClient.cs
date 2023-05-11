using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.ActionEngine
{
    public partial class ActionEnginePortClient
    {
        public ActionEnginePortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(ActionEngine)))
        {
        }

        public ActionEnginePortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}