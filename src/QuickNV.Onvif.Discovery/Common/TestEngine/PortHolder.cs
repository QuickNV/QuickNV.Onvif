using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using QuickNV.Onvif.Discovery.Common.TestEngine.PortAccessors;

namespace QuickNV.Onvif.Discovery.Common.TestEngine;

public sealed class PortHolder : IDisposable
{
	private readonly IPortAccessor _portAccessor;

	private readonly AddressFamily _addressFamilyInUse;

	private readonly ushort _startPortNumber;

	private int _port;

	private static Dictionary<ProtocolVersion, AddressFamily> _prototocolAddressFamily = new Dictionary<ProtocolVersion, AddressFamily>
	{
		{
			ProtocolVersion.IPv4,
			AddressFamily.InterNetwork
		},
		{
			ProtocolVersion.IPv6,
			AddressFamily.InterNetworkV6
		}
	};

	public int HoldPort => _port;

	public PortHolder(PortProtocolType type, ProtocolVersion version, int startPortNumber = 1000)
	{
		IPortAccessor portAccessor2;
		if (type != PortProtocolType.Tcp)
		{
			IPortAccessor portAccessor = new UdpPortAccessor();
			portAccessor2 = portAccessor;
		}
		else
		{
			IPortAccessor portAccessor = new TcpPortAccessor();
			portAccessor2 = portAccessor;
		}
		_portAccessor = portAccessor2;
		_addressFamilyInUse = _prototocolAddressFamily[version];
		_startPortNumber = Convert.ToUInt16(startPortNumber);
	}

	public void OccupyFreePort(int defaultPort, int step = 1)
	{
		IEnumerable<int> notAvailablePorts = GetNotAvailablePorts();
		foreach (int item in from p in new int[1] { defaultPort }.Concat(GeneratePortNumbers(step))
			where !notAvailablePorts.Contains(p)
			select p)
		{
			if (TryUsePort(item))
			{
				break;
			}
		}
	}

	private IEnumerable<int> GeneratePortNumbers(int step)
	{
		for (int i = _startPortNumber; i <= 65535; i += step)
		{
			yield return i;
		}
	}

	public int ReleaseHoldPort()
	{
		FreeHoldPort();
		return _port;
	}

	private bool TryUsePort(int port)
	{
		bool num = _portAccessor.TryGrabPort(_addressFamilyInUse, port);
		if (num)
		{
			_port = port;
		}
		return num;
	}

	private IEnumerable<int> GetNotAvailablePorts()
	{
		List<int> list = (from ep in _portAccessor.GetActiveEndPoints(IPGlobalProperties.GetIPGlobalProperties())
			where ep.AddressFamily == _addressFamilyInUse
			where ep.Port >= _startPortNumber
			select ep.Port).ToList();
		list.Sort();
		return list.Distinct();
	}

	public void Dispose()
	{
		FreeHoldPort();
	}

	private void FreeHoldPort()
	{
		_portAccessor.ReleasePort();
	}
}
