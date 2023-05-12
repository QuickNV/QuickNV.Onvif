using Newtonsoft.Json;
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
        public MainForm(OnvifClient client)
        {
            this.client = client;
            InitializeComponent();
            Text = $"{client.DeviceInformation.Manufacturer} - {client.DeviceInformation.Model} - {client.DeviceServiceAddressUri}";
            odcDeviceInformation.FirstValueAsyncFunc = () => Task.FromResult<object>(client.DeviceInformation);
            odcDeviceCapabilities.FirstValueAsyncFunc = () => Task.FromResult<object>(client.Capabilities);
            odcNetworkInterfaces.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkInterfacesAsync();
            odcNetworkProtocols.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkProtocolsAsync();
            odcNetworkDefaultGateway.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkDefaultGatewayAsync();
            odcDNS.RefreshAsyncFunc = async () => await client.DeviceClient.GetDNSAsync();
        }
    }
}
