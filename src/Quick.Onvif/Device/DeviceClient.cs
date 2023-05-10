using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Onvif.Device
{
    public partial class DeviceClient
    {
        public static DeviceClient Create(ClientFactoryBase factory)
        {
            return factory.Create<Quick.Onvif.Device.Device, Quick.Onvif.Device.DeviceClient>();
        }
    }
}
