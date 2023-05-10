using Quick.Onvif.Core;

namespace Quick.Onvif.Analytics
{
    public partial class RuleEnginePortClient
    {
        public RuleEnginePortClient(string url, string username, string password, ClientFactoryBase factory)
            : base(factory.Binding, new System.ServiceModel.EndpointAddress(url))
        {
            factory.InitClient(this, username, password);
        }
    }
}