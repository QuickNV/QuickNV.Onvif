using Newtonsoft.Json;
using Quick.Onvif.PTZ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick.Onvif.TestUI
{
    public partial class MainForm : Form
    {
        private OnvifClient client;
        private Media.MediaClient mediaClient;
        private PTZ.PTZClient ptzClient;
        public MainForm(OnvifClient client)
        {
            this.client = client;
            mediaClient = new Media.MediaClient(client);
            ptzClient = new PTZ.PTZClient(client);
            InitializeComponent();

            Text = $"{client.DeviceInformation.Manufacturer} - {client.DeviceInformation.Model} - {client.DeviceServiceAddressUri}";
            odcDeviceInformation.FirstValueAsyncFunc = () => Task.FromResult<object>(client.DeviceInformation);
            odcDeviceCapabilities.FirstValueAsyncFunc = () => Task.FromResult<object>(client.Capabilities);
            odcNetworkInterfaces.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkInterfacesAsync();
            odcNetworkProtocols.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkProtocolsAsync();
            odcNetworkDefaultGateway.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkDefaultGatewayAsync();
            odcDNS.RefreshAsyncFunc = async () => await client.DeviceClient.GetDNSAsync();
            odcMediaProfiles.RefreshAsyncFunc = async () => await mediaClient.GetProfilesAsync();
            odcMediaVideoSources.RefreshAsyncFunc = async () => await mediaClient.GetVideoSourcesAsync();

            var configToken = mediaClient.GetVideoSourceConfigurationsAsync().Result.Configurations[0].token;
            var ret = mediaClient.GetOSDsAsync(configToken).Result.OSDs;
        }
    }
}
