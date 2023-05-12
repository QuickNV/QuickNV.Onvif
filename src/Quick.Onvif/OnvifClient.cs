using Quick.Onvif.Factorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Quick.Onvif
{
    public class OnvifClient
    {
        public OnvifClientOptions Options { get; private set; }
        public Uri DeviceServiceAddressUri { get; private set; }

        public Device.GetDeviceInformationResponse DeviceInformation { get; private set; }
        public Device.Capabilities Capabilities { get; private set; }
        public Device.DeviceClient DeviceClient { get; private set; }
        public ClientFactory ClientFactory { get; private set; }
        public OnvifClient(OnvifClientOptions options)
        {
            this.Options = options;
        }
        private string handleXAddr(string addr)
        {
            var uri = new Uri(addr);
            var newUri = new Uri(DeviceServiceAddressUri, uri.PathAndQuery);
            return newUri.ToString();
        }

        public async Task ConnectAsync()
        {
            DeviceServiceAddressUri = new Uri(Options.DeviceServiceAddress);

            ClientFactory = ClientFactory.GetClientFactory(
                DeviceServiceAddressUri.Scheme,
                Options.UserName,
                Options.Password,
                Options.ClientCredentialType);

            DeviceClient = new Device.DeviceClient(ClientFactory, Options.DeviceServiceAddress);
            //Get Device Information
            DeviceInformation = await DeviceClient.GetDeviceInformationAsync(new Device.GetDeviceInformationRequest());
            //Get Capabilities
            {
                var rep = await DeviceClient.GetCapabilitiesAsync(new Device.CapabilityCategory[]
                {
                  Device.CapabilityCategory.All
                });
                Capabilities = rep.Capabilities;
                if (!string.IsNullOrEmpty(Capabilities.Analytics?.XAddr))
                    Capabilities.Analytics.XAddr = handleXAddr(Capabilities.Analytics.XAddr);
                if (!string.IsNullOrEmpty(Capabilities.Device?.XAddr))
                    Capabilities.Device.XAddr = handleXAddr(Capabilities.Device.XAddr);
                if (!string.IsNullOrEmpty(Capabilities.Events?.XAddr))
                    Capabilities.Events.XAddr = handleXAddr(Capabilities.Events.XAddr);
                if (!string.IsNullOrEmpty(Capabilities.Imaging?.XAddr))
                    Capabilities.Imaging.XAddr = handleXAddr(Capabilities.Imaging.XAddr);
                if (!string.IsNullOrEmpty(Capabilities.Media?.XAddr))
                    Capabilities.Media.XAddr = handleXAddr(Capabilities.Media.XAddr);
                if (!string.IsNullOrEmpty(Capabilities.PTZ?.XAddr))
                    Capabilities.PTZ.XAddr = handleXAddr(Capabilities.PTZ.XAddr);

                if (!string.IsNullOrEmpty(Capabilities.Extension?.AnalyticsDevice?.XAddr))
                    Capabilities.Extension.AnalyticsDevice.XAddr = handleXAddr(Capabilities.Extension.AnalyticsDevice.XAddr);
                foreach (var element in Capabilities.Extension.Any)
                {
                    foreach (var child in element.ChildNodes)
                    {
                        XmlElement elXAddr = child as XmlElement;
                        if (elXAddr == null)
                            continue;
                        if (elXAddr.LocalName != "XAddr")
                            continue;
                        if (!string.IsNullOrEmpty(elXAddr.InnerText))
                            elXAddr.InnerText = handleXAddr(elXAddr.InnerText);
                    }
                }
            }
        }

        public string GetXAddr(string name)
        {
            if (Options == null)
                throw new ArgumentNullException(nameof(Options.GetXAddrFunc));
            return Options.GetXAddrFunc(Options, name);
        }
    }
}
