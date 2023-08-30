using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace QuickNV.Onvif.Discovery.Common.TestEngine.PortAccessors;

internal sealed class UdpPortAccessor : IPortAccessor
{
    private UdpClient _client;

    public IEnumerable<IPEndPoint> GetActiveEndPoints(IPGlobalProperties properties)
    {
        return properties.GetActiveUdpListeners();
    }

    public bool TryGrabPort(AddressFamily type, int port)
    {
        ReleasePort();
        bool result = false;
        try
        {
            _client = new UdpClient(port, type);
            result = true;
            return result;
        }
        catch (SocketException)
        {
            return result;
        }
    }

    public bool ReleasePort()
    {
        bool result = _client != null;
        _client?.Close();
        _client = null;
        return result;
    }
}
