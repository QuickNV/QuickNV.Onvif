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
        public string CorrectUri(string addr)
        {
            var uriBuilder = new UriBuilder(addr);
            if (uriBuilder.Host != Options.Host)
                uriBuilder.Host = Options.Host;
            if (uriBuilder.Port != Options.Port)
                uriBuilder.Port = Options.Port;
            return uriBuilder.Uri.ToString();
        }

        public async Task ConnectAsync()
        {
            ClientFactory = ClientFactory.GetClientFactory(
                Options.Scheme,
                Options.UserName,
                Options.Password,
                Options.ClientCredentialType);
            UriBuilder deviceClientUriBuilder = new UriBuilder();
            deviceClientUriBuilder.Scheme = Options.Scheme;
            deviceClientUriBuilder.Host = Options.Host;
            deviceClientUriBuilder.Port = Options.Port;
            deviceClientUriBuilder.Path = "/onvif/device_service";
            var deviceClientUri = deviceClientUriBuilder.Uri.ToString();
            DeviceClient = new Device.DeviceClient(ClientFactory, deviceClientUri);
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
                    Capabilities.Analytics.XAddr = CorrectUri(Capabilities.Analytics.XAddr);
                if (!string.IsNullOrEmpty(Capabilities.Device?.XAddr))
                    Capabilities.Device.XAddr = CorrectUri(Capabilities.Device.XAddr);
                if (!string.IsNullOrEmpty(Capabilities.Events?.XAddr))
                    Capabilities.Events.XAddr = CorrectUri(Capabilities.Events.XAddr);
                if (!string.IsNullOrEmpty(Capabilities.Imaging?.XAddr))
                    Capabilities.Imaging.XAddr = CorrectUri(Capabilities.Imaging.XAddr);
                if (!string.IsNullOrEmpty(Capabilities.Media?.XAddr))
                    Capabilities.Media.XAddr = CorrectUri(Capabilities.Media.XAddr);
                if (!string.IsNullOrEmpty(Capabilities.PTZ?.XAddr))
                    Capabilities.PTZ.XAddr = CorrectUri(Capabilities.PTZ.XAddr);

                if (!string.IsNullOrEmpty(Capabilities.Extension?.AnalyticsDevice?.XAddr))
                    Capabilities.Extension.AnalyticsDevice.XAddr = CorrectUri(Capabilities.Extension.AnalyticsDevice.XAddr);
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
                            elXAddr.InnerText = CorrectUri(elXAddr.InnerText);
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
