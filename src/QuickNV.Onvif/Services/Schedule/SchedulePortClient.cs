using QuickNV.Onvif.Factorys;
using System.ServiceModel;

namespace QuickNV.Onvif.Schedule
{
    public partial class SchedulePortClient
    {
        public SchedulePortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(Schedule)))
        {
        }

        public SchedulePortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}