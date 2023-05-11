using Quick.Onvif.Factorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Onvif.Security
{
    public partial class Dot1XClient
    {
        public Dot1XClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(Security)))
        {
        }

        public Dot1XClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
