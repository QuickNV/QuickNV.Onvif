using System.Net;
using QuickNV.Onvif.Discovery.WSDiscovery;
using QuickNV.Onvif.Discovery.Common.Discovery;

namespace QuickNV.Onvif.Discovery
{
    public class DiscoveryController
    {
        private int _queriesRunning;
        private string searchScopes;
        public event Action<DeviceDiscoveryData> DeviceDiscovered;
        public event Action DiscoveryStarted;
        public event Action<Exception> DiscoveryError;
        public event Action DiscoveryCompleted;

        public DiscoveryController() { }

        public DiscoveryController(string searchScopes)
        {
            this.searchScopes = searchScopes;
        }

        protected void OnDeviceDiscovered(object sender, DiscoveryMessageEventArgs e, List<DeviceDiscoveryData> allDevices, List<DiscoveryErrorEventArgs> errors, DiscoveryUtils.DiscoveryType[][] types)
        {
            if (this.DeviceDiscovered == null)
            {
                return;
            }
            List<DeviceDiscoveryData> devices = DiscoveryUtils.GetDevices(e.Message.ToSoapMessage<ProbeMatchesType>(), e.Sender, types);
            allDevices.AddRange(devices);
            foreach (DeviceDiscoveryData item in devices)
            {
                this.DeviceDiscovered(item);
            }
        }

        protected void OnDiscoveryError(object sender, DiscoveryErrorEventArgs e, List<DiscoveryErrorEventArgs> errors)
        {
            if (errors != null)
            {
                errors.Add(e);
            }
            else if (this.DiscoveryError != null)
            {
                this.DiscoveryError(e.Exception);
            }
        }


        protected void OnDiscoveryFinished(object sender, EventArgs e, List<DeviceDiscoveryData> allDevices, List<DiscoveryErrorEventArgs> errors)
        {
            _queriesRunning--;
            if (_queriesRunning != 0)
            {
                return;
            }
            if (errors.Count > 0)
            {
                if (this.DiscoveryError != null)
                {
                    this.DiscoveryError(errors[0].Exception);
                }
            }
            else if (allDevices.Count == 0 && this.DiscoveryError != null)
            {
                Exception obj = new Exception(string.Format("Device did not respond or device type is not {0} ", "NetworkVideoTransmitter"));
                this.DiscoveryError(obj);
            }
            if (this.DiscoveryCompleted != null)
            {
                this.DiscoveryCompleted();
            }
        }


        protected void ProbeInternal(IPAddress local, IPAddress remote)
        {
            List<DiscoveryErrorEventArgs> errors = new List<DiscoveryErrorEventArgs>();
            List<DeviceDiscoveryData> devices = new List<DeviceDiscoveryData>();
            DiscoveryUtils.DiscoveryType[][] types = new DiscoveryUtils.DiscoveryType[2][]
            {
        DiscoveryUtils.GetOnvif10Type(),
        DiscoveryUtils.GetOnvif20Type()
            };
            Common.Discovery.Discovery discovery = new Common.Discovery.Discovery(local);
            discovery.Discovered += delegate (object s, DiscoveryMessageEventArgs e)
            {
                OnDeviceDiscovered(s, e, devices, errors, types);
            };
            discovery.DiscoveryFinished += delegate (object s, EventArgs e)
            {
                OnDiscoveryFinished(s, e, devices, errors);
            };
            discovery.ReceiveError += delegate (object s, DiscoveryErrorEventArgs e)
            {
                OnDiscoveryError(s, e, errors);
            };
            string[] scopes = null;
            if (!string.IsNullOrEmpty(searchScopes))
            {
                searchScopes = searchScopes.Replace(Environment.NewLine, " ");
                scopes = searchScopes.Split(' ');
                List<string> list = new List<string>();
                string[] array = scopes;
                foreach (string text in array)
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        list.Add(text);
                    }
                }
                scopes = list.ToArray();
            }
            _queriesRunning = 1;
            if (remote != IPAddress.None)
            {
                discovery.Probe(remote, types, scopes);
            }
            else
            {
                discovery.Probe(types, scopes);
            }
            if (this.DiscoveryStarted != null)
            {
                this.DiscoveryStarted();
            }
        }

        public void RunDiscovery(IPAddress networkInterface)
        {
            ProbeInternal(networkInterface, IPAddress.None);
        }
    }
}
