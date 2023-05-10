using Quick.Onvif.Core;

namespace Quick.Onvif.ActionEngine
{
    public partial class ActionEnginePortClient
    {
        public ActionEnginePortClient(string url, string username, string password, ClientFactoryBase factory)
            : base(factory.Binding, new System.ServiceModel.EndpointAddress(url))
        {
            factory.InitClient(this, username, password);
        }
    }
}