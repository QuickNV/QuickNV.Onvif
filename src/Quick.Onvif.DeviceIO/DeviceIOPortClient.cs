using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.DeviceIO
{
    public partial class DeviceIOPortClient
    {
        public DeviceIOPortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(DeviceIO)))
        {
        }

        public DeviceIOPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}