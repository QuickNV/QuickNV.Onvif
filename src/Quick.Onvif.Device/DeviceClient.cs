using Quick.Onvif.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Onvif.Device
{
    public partial class DeviceClient
    {
        public DeviceClient(ClientFactoryBase factory)
            : base(factory.Binding, factory.RemoteAddress)
        {
            factory.InitClient(this);
        }
    }
}
