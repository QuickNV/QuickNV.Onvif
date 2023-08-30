using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace QuickNV.Onvif.Discovery
{
    public class DiscoveryController2
    {
        private IPAddress networkInterface;
        private DiscoveryController controller;
        private List<DeviceDiscoveryData> list;
        private Exception lastException;
        private Task<DeviceDiscoveryData[]> discoveryTask;

        public DiscoveryController2(IPAddress networkInterface)
        {
            this.networkInterface = networkInterface;
            controller = new DiscoveryController();
            controller.DiscoveryCompleted += Controller_DiscoveryCompleted;
            controller.DiscoveryError += Controller_DiscoveryError;
            controller.DeviceDiscovered += Controller_DeviceDiscovered;

        }

        public async Task<DeviceDiscoveryData[]> RunDiscovery()
        {
            list = new List<DeviceDiscoveryData>();
            lastException = null;
            discoveryTask = new Task<DeviceDiscoveryData[]>(() =>
            {
                if (lastException != null)
                    throw lastException;
                return list.ToArray();
            });
            controller.RunDiscovery(networkInterface);
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
