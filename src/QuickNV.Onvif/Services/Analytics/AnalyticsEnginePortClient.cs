using QuickNV.Onvif.Factorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace QuickNV.Onvif.Analytics
{
    public partial class AnalyticsEnginePortClient
    {
        public AnalyticsEnginePortClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Analytics.XAddr)
        {
        }

        public AnalyticsEnginePortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}
