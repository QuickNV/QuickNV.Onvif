using Quick.Onvif.Factorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Onvif.DeviceIO
{
    public partial class DeviceClient
    {
        public DeviceClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(DeviceIO)))
        {
        }

        public DeviceClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
