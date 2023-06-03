using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Quick.Onvif.Discovery.Common.TestEngine.PortAccessors;

internal sealed class TcpPortAccessor : IPortAccessor
{
    private TcpListener _listener;

    public IEnumerable<IPEndPoint> GetActiveEndPoints(IPGlobalProperties properties)
    {
        return (from c in properties.GetActiveTcpConnections()
                select c.LocalEndPoint).Concat(properties.GetActiveTcpListeners());
    }

    public bool TryGrabPort(AddressFamily type, int port)
    {
        AssertRange(type, new AddressFamily[2]
        {
            AddressFamily.InterNetwork,
            AddressFamily.InterNetworkV6
        }, "type");
        ReleasePort();
        bool result = false;
        try
        {
            TcpListener tcpListener = new TcpListener(type == AddressFamily.InterNetwork ? IPAddress.Loopback : IPAddress.IPv6Loopback, port);
            tcpListener.Start();
            _listener = tcpListener;
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
        bool result = _listener != null;
        _listener?.Stop();
        _listener = null;
        return result;
    }

    private void AssertRange(AddressFamily type, AddressFamily[] addressFamily, string name)
    {
        if (!addressFamily.Any((af) => af == type))
        {
            throw new ArgumentOutOfRangeException(name);
        }
    }
}
