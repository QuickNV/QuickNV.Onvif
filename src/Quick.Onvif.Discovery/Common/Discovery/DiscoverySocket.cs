#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Quick.Onvif.Discovery.Common.Discovery;

public class DiscoverySocket : IDisposable
{
	private IPEndPoint _endpoint;

	public UdpClient Socket { get; protected set; }

	public event EventHandler<DiscoverySocketEventArgs> MessageReceived;

	public DiscoverySocket(IPEndPoint endpoint)
	{
		_endpoint = new IPEndPoint(endpoint.Address, endpoint.Port);
		Trace.WriteLine($"Socket {GetHashCode()} C-tor");
		Trace.Flush();
		Socket = new UdpClient(endpoint.AddressFamily);
		Socket.Client.ReceiveBufferSize = 4096;
		Socket.Client.SendBufferSize = 4096;
		Socket.Ttl = 10;
		Socket.MulticastLoopback = false;
		Socket.Client.ReceiveBufferSize = 50000;
		if (!object.Equals(endpoint.Address, IPAddress.Any) && !object.Equals(endpoint.Address, IPAddress.IPv6Any))
		{
			Socket.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, optionValue: true);
			Socket.Client.Bind(endpoint);
		}
	}

	public void JoinMulticastGroup(IPAddress group)
	{
		Trace.WriteLine($"Socket {GetHashCode()} JoinMulticastGroup");
		Trace.Flush();
		bool num = group.AddressFamily == AddressFamily.InterNetworkV6;
		SocketOptionLevel optionLevel = (num ? SocketOptionLevel.IPv6 : SocketOptionLevel.IP);
		object obj = null;
		obj = ((!num) ? ((object)new MulticastOption(group, _endpoint.Address)) : ((object)new IPv6MulticastOption(group)));
		if (Socket != null)
		{
			lock (Socket)
			{
				Socket.Client.SetSocketOption(optionLevel, SocketOptionName.AddMembership, obj);
			}
		}
	}

	public void Listen()
	{
		Trace.WriteLine($"Socket {GetHashCode()} Listen");
		Trace.Flush();
		if (Socket != null)
		{
			lock (Socket)
			{
				Socket.BeginReceive(ReceiveCallback, null);
			}
		}
	}

	public void Send(IPEndPoint destination, byte[] sendBytes, bool bSilent = false)
	{
		if (!bSilent)
		{
			Trace.WriteLine($"Socket {GetHashCode()} Send");
			Trace.Flush();
		}
		if (Socket != null)
		{
			lock (Socket)
			{
				Socket.Send(sendBytes, sendBytes.Length, destination);
			}
		}
	}

	public void Send(IPEndPoint destination, List<byte[]> sendBytes)
	{
		Trace.WriteLine($"Socket {GetHashCode()} Send");
		Trace.Flush();
		if (Socket == null)
		{
			return;
		}
		lock (Socket)
		{
			foreach (byte[] sendByte in sendBytes)
			{
				Send(destination, sendByte, bSilent: true);
			}
		}
	}

	private void ReceiveCallback(IAsyncResult result)
	{
		Trace.WriteLine($"Socket {GetHashCode()} ReceiveCallback");
		try
		{
			lock (Socket)
			{
				if (Socket != null && Socket.Client != null)
				{
					IPEndPoint remoteEP = null;
					Trace.WriteLine(string.Format("{0} DiscoverySocket::ReceiveCallback entry point", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss:fff")));
					byte[] array = Socket.EndReceive(result, ref remoteEP);
					Trace.WriteLine(string.Format("{0} DiscoverySocket::ReceiveCallback from[{1}] message[{2}]", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss:fff"), remoteEP.ToString(), Encoding.UTF8.GetString(array)));
					DiscoverySocketEventArgs discoverySocketEventArgs = new DiscoverySocketEventArgs();
					discoverySocketEventArgs.Message = array;
					discoverySocketEventArgs.Source = remoteEP;
					this.MessageReceived(this, discoverySocketEventArgs);
					Trace.WriteLine(string.Format("{0} DiscoverySocket::ReceiveCallback begin receive", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss:fff")));
					Trace.Flush();
					Socket.BeginReceive(ReceiveCallback, null);
				}
			}
		}
		catch (Exception ex)
		{
			Trace.WriteLine(string.Format("{0} DiscoverySocket::ReceiveCallback error [{1}]", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss:fff"), ex.Message));
			Trace.Flush();
		}
	}

	public void Dispose()
	{
		Trace.WriteLine($"Socket {GetHashCode()} Dispose");
		Trace.Flush();
		Close();
	}

	public void Close()
	{
		Trace.WriteLine($"Socket {GetHashCode()} Close");
		Trace.Flush();
		if (Socket != null)
		{
			lock (Socket)
			{
				Socket.Close();
			}
		}
	}
}
