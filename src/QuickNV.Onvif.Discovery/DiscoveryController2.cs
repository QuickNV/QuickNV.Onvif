using System.Net;
using System.Net.NetworkInformation;

namespace QuickNV.Onvif.Discovery
{
    public class DiscoveryController2
    {
        private DiscoveryController controller;
        private List<DeviceDiscoveryData> list;
        private Exception lastException;
        private Task<DeviceDiscoveryData[]> discoveryTask;

        public DiscoveryController2()
            : this(TimeSpan.FromSeconds(5))
        {
        }

        public DiscoveryController2(TimeSpan timeout)
        {
            controller = new DiscoveryController(string.Empty, timeout);
            controller.DiscoveryCompleted += Controller_DiscoveryCompleted;
            controller.DiscoveryError += Controller_DiscoveryError;
            controller.DeviceDiscovered += Controller_DeviceDiscovered;

        }
        public async Task<DeviceDiscoveryData[]> RunDiscovery()
        {
            var upInterfaces = NetworkInterface.GetAllNetworkInterfaces().Where(i =>
                 i.OperationalStatus == OperationalStatus.Up && i.NetworkInterfaceType != NetworkInterfaceType.Loopback);

            var ipAddresses = new List<IPAddress>();
            foreach (var iface in upInterfaces)
            {
                foreach (var ip in iface.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ipAddresses.Add(ip.Address);
                    }
                }
            }
            var devices = new List<DeviceDiscoveryData>();

            foreach (var ip in ipAddresses)
            {
                var result = await RunDiscovery(ip);
                devices.AddRange(result.DistinctBy(r => r.UUID));
            }
            return devices.ToArray();
        }

        public async Task<DeviceDiscoveryData[]> RunDiscovery(IPAddress ipAddress)
        {
            list = new List<DeviceDiscoveryData>();
            lastException = null;
            discoveryTask = new Task<DeviceDiscoveryData[]>(() =>
            {
                if (lastException != null)
                    throw lastException;
                return list.ToArray();
            });
            controller.RunDiscovery(ipAddress);
            return await discoveryTask;
        }


        private void Controller_DeviceDiscovered(DeviceDiscoveryData obj)
        {
            list?.Add(obj);
        }

        private void Controller_DiscoveryError(Exception exception)
        {
            lastException = exception;
        }

        private void Controller_DiscoveryCompleted()
        {
            discoveryTask?.Start();
        }
    }
}
