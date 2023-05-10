using Quick.Onvif.Core;

namespace Quick.Onvif.AccessControl
{
    public partial class PACSPortClient
    {
        public PACSPortClient(string url, string username, string password, ClientFactoryBase factory)
            : base(factory.Binding, new System.ServiceModel.EndpointAddress(url))
        {
            factory.InitClient(this, username, password);
        }
    }
}