using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.Thermal
{
    public partial class ThermalPortClient
    {
        public ThermalPortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(Thermal)))
        {
        }

        public ThermalPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}