using Quick.Onvif.Core;

namespace Quick.Onvif.ApplicationManagement
{
    public partial class AppManagementClient
    {
        public AppManagementClient(string url, string username, string password, ClientFactoryBase factory)
            : base(factory.Binding, new System.ServiceModel.EndpointAddress(url))
        {
            factory.InitClient(this, username, password);
        }
    }
}