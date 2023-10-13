using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.DeviceIO
{
    public partial class DeviceIOPortClient
    {
        public DeviceIOPortClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Extension.DeviceIO.XAddr)
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