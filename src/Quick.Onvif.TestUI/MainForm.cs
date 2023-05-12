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
            odcDevice.RefreshAsyncFunc = async () => await client.DeviceClient.GetDeviceInformationAsync(new Device.GetDeviceInformationRequest());
            odcNetwork.RefreshAsyncFunc = async () => await client.DeviceClient.GetNetworkInterfacesAsync();

        }
    }
}
