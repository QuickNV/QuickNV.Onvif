using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Onvif
{
    public class OnvifClientOptions
    {
        public string DeviceServiceAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public HttpClientCredentialType ClientCredentialType { get; set; } = HttpClientCredentialType.Digest;
        public Func<OnvifClientOptions, string, string> GetXAddrFunc { get; set; }
        public int RtspPort { get; set; }
    }
}
