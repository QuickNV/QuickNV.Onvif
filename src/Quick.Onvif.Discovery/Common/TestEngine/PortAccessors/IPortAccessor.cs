using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Quick.Onvif.Discovery.Common.TestEngine.PortAccessors;

internal interface IPortAccessor
{
    IEnumerable<IPEndPoint> GetActiveEndPoints(IPGlobalProperties properties);

    bool TryGrabPort(AddressFamily type, int port);

    bool ReleasePort();
}
