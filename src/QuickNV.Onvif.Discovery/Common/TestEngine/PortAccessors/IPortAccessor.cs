using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace QuickNV.Onvif.Discovery.Common.TestEngine.PortAccessors;

internal interface IPortAccessor
{
    IEnumerable<IPEndPoint> GetActiveEndPoints(IPGlobalProperties properties);

    bool TryGrabPort(AddressFamily type, int port);

    bool ReleasePort();
}
