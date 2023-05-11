using Quick.Onvif.Factorys;
using System.ServiceModel;

namespace Quick.Onvif.AuthenticationBehavior
{
    public partial class AuthenticationBehaviorPortClient
    {
        public AuthenticationBehaviorPortClient(OnvifClient client)
            : this(client.ClientFactory, client.GetXAddr(nameof(AuthenticationBehavior)))
        {
        }

        public AuthenticationBehaviorPortClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }
    }
}