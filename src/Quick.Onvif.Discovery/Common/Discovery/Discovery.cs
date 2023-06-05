#define TRACE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using TestTool.Proxies.WSDiscovery;
using Quick.Onvif.Discovery.Common.Soap;
using Quick.Onvif.Discovery.Common.TestEngine;

namespace Quick.Onvif.Discovery.Common.Discovery;

public class Discovery : IDisposable
{
	public delegate bool MessageFilterFunction(SoapMessage<object> msg);

	public delegate byte[] ProcessMessage(byte[] message);

	private const string SCOPE_MATCH_BY_URL = "http://schemas.xmlsoap.org/ws/2005/04/discovery/rfc3986";

	private IPAddress WS_DISCOVER_MULTICAST_IP4 = IPAddress.Parse("239.255.255.250");

	private IPAddress WS_DISCOVER_MULTICAST_IP6 = IPAddress.Parse("FF02::C");

	private const int WS_DISCOVER_PORT = 3702;

	public const int WS_DISCOVER_TIMEOUT = 5000;

	public MessageFilterFunction MessageFilter;

	private DiscoverySocket _socket;

	private object _socketSync = new object();

	private Thread _connectionThread;

	private IPAddress _listenAddress;

	private string _listenDevice;

	private List<string> _listenMessages = new List<string>();

	private CancellationTokenSource cts;
	private List<DiscoverySocketEventArgs> _packetsReceived = new List<DiscoverySocketEventArgs>();

	private bool _parseLater;

	private List<XmlSchema> _discoverySchemas;

	private IPEndPoint _endPointLocal;

	private ProcessMessage _processMessageMethod;

	public event EventHandler<DiscoveryMessageEventArgs> Discovered;

	public event EventHandler<DiscoveryMessageEventArgs> HelloReceived;

	public event EventHandler<DiscoveryMessageEventArgs> ByeReceived;

	public event EventHandler<DiscoveryErrorEventArgs> SoapFaultReceived;

	public event EventHandler<DiscoveryErrorEventArgs> ReceiveError;

	public event EventHandler DiscoveryFinished;

	public event EventHandler<MessageEventArgs> MessageSent;

	public Discovery(IPAddress local)
	{
		_endPointLocal = new IPEndPoint(local, 3702);
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Quick.Onvif.Discovery.Common.Discovery.Schemas.ws-discovery.xsd");
		XmlSchema item = XmlSchema.Read(manifestResourceStream, null);
		manifestResourceStream.Close();
		Stream manifestResourceStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream("Quick.Onvif.Discovery.Common.Discovery.Schemas.addressing.xsd");
		XmlSchema item2 = XmlSchema.Read(manifestResourceStream2, null);
		manifestResourceStream2.Close();
		_discoverySchemas = new List<XmlSchema> { item, item2 };
	}

	public Discovery(IPAddress local, ProcessMessage processMessageMethod)
		: this(local)
	{
		_processMessageMethod = processMessageMethod;
	}

	protected IPAddress GetDiscoveryMulticastAddress()
	{
		if (_endPointLocal.AddressFamily != AddressFamily.InterNetworkV6)
		{
			return WS_DISCOVER_MULTICAST_IP4;
		}
		return WS_DISCOVER_MULTICAST_IP6;
	}

	protected void JoinDiscoveryMutlicastGroup(DiscoverySocket socket)
	{
		IPAddress discoveryMulticastAddress = GetDiscoveryMulticastAddress();
		socket.JoinMulticastGroup(discoveryMulticastAddress);
	}

	public void Probe(DiscoveryUtils.DiscoveryType[][] types, string[] scopes)
	{
		Probe(multicast: true, null, null, 5000, types, scopes);
	}

	public void Probe(IPAddress address, DiscoveryUtils.DiscoveryType[][] types, string[] scopes)
	{
		Probe(multicast: false, address, null, 5000, types, scopes);
	}

	public void Probe(bool multicast, IPAddress address, string deviceId, DiscoveryUtils.DiscoveryType[][] types)
	{
		Probe(multicast, address, deviceId, 5000, types, null);
	}

	public void Probe(bool multicast, IPAddress address, string deviceId, int timeout, DiscoveryUtils.DiscoveryType[][] types, string[] scopes)
	{
		Probe(multicast, address, deviceId, timeout, types, scopes, null);
	}

	private void SendToLocal3702(byte[] msg)
	{
		using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		foreach (NetworkInterface networkInterface in allNetworkInterfaces)
		{
			if ((networkInterface.NetworkInterfaceType != NetworkInterfaceType.Ethernet && networkInterface.NetworkInterfaceType != NetworkInterfaceType.Wireless80211) || networkInterface.OperationalStatus != OperationalStatus.Up)
			{
				continue;
			}
			foreach (UnicastIPAddressInformation unicastAddress in networkInterface.GetIPProperties().UnicastAddresses)
			{
				if (unicastAddress.Address != null && unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
				{
					socket.SendTo(msg, new IPEndPoint(unicastAddress.Address, 3702));
				}
			}
		}
	}

	public void Probe(bool multicast, IPAddress address, string deviceId, int timeout, DiscoveryUtils.DiscoveryType[][] types, string[] scopes, string matchRule)
	{
		PortHolder portHolder = new PortHolder(PortProtocolType.Udp, ProtocolVersion.IPv4);
		portHolder.OccupyFreePort(1000);
		_socket = new DiscoverySocket(new IPEndPoint(_endPointLocal.Address, portHolder.ReleaseHoldPort()));
		_socket.MessageReceived += OnMessageReceived<ProbeMatchesType>;
		_ = string.Empty;
		try
		{
			if (multicast)
			{
				JoinDiscoveryMutlicastGroup(_socket);
			}
			IPEndPoint destination = (multicast ? new IPEndPoint(GetDiscoveryMulticastAddress(), 3702) : new IPEndPoint(address, 3702));
			List<byte[]> list = new List<byte[]>();
			List<string> list2 = new List<string>();
			if (types != null)
			{
				foreach (DiscoveryUtils.DiscoveryType[] types2 in types)
				{
					byte[] array = BuildProbeMessage(types2, scopes, matchRule);
					list2.Add(DiscoveryUtils.ExtractMessageId(array));
					list.Add((_processMessageMethod != null) ? _processMessageMethod(array) : array);
				}
			}
			else
			{
				byte[] array2 = BuildProbeMessage(null, scopes, matchRule);
				list2.Add(DiscoveryUtils.ExtractMessageId(array2));
				list.Add((_processMessageMethod != null) ? _processMessageMethod(array2) : array2);
			}
			list.Reverse();
			StartListen(timeout, address, deviceId, list2.ToArray(), parseLater: true);
			_socket.Send(destination, list);
			foreach (byte[] item in list)
			{
				SendToLocal3702(item);
			}
			foreach (byte[] item2 in list)
			{
				if (this.MessageSent != null)
				{
					string @string = Encoding.UTF8.GetString(item2);
					this.MessageSent(this, new MessageEventArgs
					{
						Message = @string
					});
				}
			}
		}
		catch (Exception)
		{
			_socket.Close();
			throw;
		}
	}

	protected void StartListen(int timeout, IPAddress address, string device, string[] messageIds, bool parseLater)
	{
		Trace.WriteLine($"{DateTime.Now} Discovery StartListen");
		Trace.Flush();
		_listenAddress = address;
		_listenDevice = device;
		_listenMessages.Clear();
		if (messageIds != null)
		{
			foreach (string text in messageIds)
			{
				if (!string.IsNullOrEmpty(text))
				{
					_listenMessages.Add(text);
				}
			}
		}
		_packetsReceived.Clear();
		_parseLater = parseLater;
		cts?.Cancel();
		cts = new CancellationTokenSource();
		_socket.Listen();
		_connectionThread = new Thread(CloseConnection);
		Trace.WriteLine($"{DateTime.Now.ToLongTimeString()} StartListen, timeout={timeout}");
		Trace.Flush();
		_connectionThread.Start(new CloseConnectionState(timeout, cts.Token));
	}

	protected void CloseConnection(object state)
	{
		var closeConnectionState = (CloseConnectionState)state;
        int timeout = closeConnectionState.Timeout;
		Trace.WriteLine($"{DateTime.Now.ToLongTimeString()} CloseConnection - started, timeout={timeout}");
		Trace.Flush();
		bool flag = false;
        var task = Task.Delay(timeout, closeConnectionState.CancellationToken);
        try
        {
            task.Wait();
            flag = true;
        }
        catch
        {
            flag = false;
        }
        Trace.WriteLine(string.Format("{0} CloseConnection - awaken {1}", DateTime.Now.ToLongTimeString(), flag ? "after timeout" : "by event"));
		Trace.Flush();
		lock (_socketSync)
		{
			if (_socket != null)
			{
				_socket.Close();
				_socket = null;
			}
		}
		foreach (DiscoverySocketEventArgs item in _packetsReceived)
		{
			ProcessIncomingPacket<ProbeMatchesType>(item, delegate
			{
			});
		}
		if (this.DiscoveryFinished != null)
		{
			this.DiscoveryFinished(this, EventArgs.Empty);
		}
	}

	protected EventHandler<DiscoveryMessageEventArgs> GetHandler(Type messageType)
	{
		EventHandler<DiscoveryMessageEventArgs> result = null;
		if (typeof(ProbeMatchesType).GUID == messageType.GUID)
		{
			result = this.Discovered;
		}
		else if (typeof(HelloType).GUID == messageType.GUID)
		{
			result = this.HelloReceived;
		}
		else if (typeof(ByeType).GUID == messageType.GUID)
		{
			result = this.ByeReceived;
		}
		return result;
	}

	protected bool IsExpectedMessageHeader(ICollection<XmlElement> header)
	{
		if (_listenMessages.Count() > 0)
		{
			string b = DiscoveryUtils.ExtractRelatesTo(header);
			foreach (string listenMessage in _listenMessages)
			{
				if (DiscoveryUtils.CompareUUID(listenMessage, b))
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	protected bool IsExpectedMessage<T>(SoapMessage<T> message) where T : class
	{
		if (!IsExpectedMessageHeader(message.Header))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(_listenDevice))
		{
			string text = string.Empty;
			if (message.Object is ProbeMatchesType)
			{
				text = DiscoveryUtils.GetDeviceId(message.Object as ProbeMatchesType);
			}
			else if (message.Object is HelloType)
			{
				text = DiscoveryUtils.GetDeviceId(message.Object as HelloType);
			}
			else if (message.Object is ByeType)
			{
				text = DiscoveryUtils.GetDeviceId(message.Object as ByeType);
			}
			if (_listenDevice != text)
			{
				return false;
			}
		}
		return true;
	}

	protected void ProcessIncomingPacket<T>(DiscoverySocketEventArgs e, Action postProcessingAction) where T : class
	{
		Func<SoapMessage<object>, bool> func = (SoapMessage<object> msg) => MessageFilter == null || MessageFilter(msg);
		if (_listenAddress != null && !DiscoveryUtils.CompareAddresses(e.Source.Address, _listenAddress))
		{
			return;
		}
		try
		{
			SoapMessage<T> soapMessage = SoapBuilder.ParseMessage<T>(e.Message, _discoverySchemas);
			if (IsExpectedMessage(soapMessage) && func(soapMessage.ToSoapMessage<object>()))
			{
				EventHandler<DiscoveryMessageEventArgs> handler = GetHandler(soapMessage.Object.GetType());
				DiscoveryMessageEventArgs e2 = new DiscoveryMessageEventArgs(soapMessage.ToSoapMessage<object>(), e.Source.Address);
				handler?.Invoke(this, e2);
				postProcessingAction();
			}
		}
		catch (SoapFaultException ex)
		{
			if (ex.Message != null && IsExpectedMessage(ex.FaultMessage) && func(ex.FaultMessage.ToSoapMessage<object>()))
			{
				if (this.SoapFaultReceived != null)
				{
					this.SoapFaultReceived(this, new DiscoveryErrorEventArgs(ex, ex.Fault));
				}
				postProcessingAction();
			}
		}
		catch (UnxpectedElementException ex2)
		{
			if (_listenMessages.Count() > 0 && IsExpectedMessageHeader(ex2.Headers))
			{
				if (this.ReceiveError != null)
				{
					this.ReceiveError(this, new DiscoveryErrorEventArgs(ex2, null));
				}
				postProcessingAction();
				throw;
			}
		}
		catch (Exception ex3)
		{
			if (this.ReceiveError != null)
			{
				this.ReceiveError(this, new DiscoveryErrorEventArgs(ex3, null));
			}
			Trace.WriteLine($"Discovery::OnMessageReceived error [{ex3.Message}]");
			Trace.Flush();
		}
	}

	protected void OnMessageReceived<T>(object sender, DiscoverySocketEventArgs e) where T : class
	{
		if (_parseLater)
		{
			DiscoverySocketEventArgs discoverySocketEventArgs = new DiscoverySocketEventArgs();
			discoverySocketEventArgs.Source = new IPEndPoint(e.Source.Address, e.Source.Port);
			discoverySocketEventArgs.Message = new byte[e.Message.Count()];
			e.Message.CopyTo(discoverySocketEventArgs.Message, 0);
			_packetsReceived.Add(discoverySocketEventArgs);
		}
		else
		{
			ProcessIncomingPacket<T>(e, delegate
			{
				cts?.Cancel();
			});
		}
	}

	protected byte[] BuildProbeMessage(DiscoveryUtils.DiscoveryType[] types, string[] scopes, string matchRule)
	{
		ProbeType probeType = new ProbeType();
		probeType.Scopes = new ScopesType();
		probeType.Scopes.MatchBy = matchRule;
		if (scopes != null)
		{
			string text = string.Empty;
			for (int i = 0; i < scopes.Length; i++)
			{
				text += scopes[i];
				if (i < scopes.Length - 1)
				{
					text += " ";
				}
			}
			probeType.Scopes.Text = new string[1] { text };
		}
		XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
		int num = 0;
		string text2 = string.Empty;
		bool flag = true;
		if (types != null)
		{
			foreach (DiscoveryUtils.DiscoveryType discoveryType in types)
			{
				string @namespace = discoveryType.Namespace;
				string type = discoveryType.Type;
				string text3;
				if (string.IsNullOrEmpty(discoveryType.Prefix))
				{
					text3 = $"ns{num}";
					num++;
				}
				else
				{
					text3 = discoveryType.Prefix;
				}
				xmlSerializerNamespaces.Add(text3, @namespace);
				if (flag)
				{
					flag = false;
				}
				else
				{
					text2 += " ";
				}
				text2 = text2 + text3 + ":" + type;
			}
		}
		probeType.Types = text2;
		return SoapBuilder.BuildMessage(probeType, Encoding.UTF8, new DiscoveryHeaderBuilder(), xmlSerializerNamespaces);
	}

	public void WaitHello(IPAddress from, string deviceId, int timeout)
	{
		WaitMessage(multicast: true, from, deviceId, timeout, new EventHandler<DiscoverySocketEventArgs>[1] { OnMessageReceived<HelloType> });
	}

	public void WaitBye(IPAddress from, string deviceId, int timeout)
	{
		WaitMessage(multicast: true, from, deviceId, timeout, new EventHandler<DiscoverySocketEventArgs>[1] { OnMessageReceived<ByeType> });
	}

	public void WaitByeOrHello(IPAddress from, string deviceId, int timeout)
	{
		WaitMessage(multicast: true, from, deviceId, timeout, new EventHandler<DiscoverySocketEventArgs>[2] { OnMessageReceived<HelloType>, OnMessageReceived<ByeType> });
	}

	protected void WaitMessage(bool multicast, IPAddress from, string deviceId, int timeout, EventHandler<DiscoverySocketEventArgs>[] callbacks)
	{
		_socket = new DiscoverySocket(_endPointLocal);
		if (multicast)
		{
			JoinDiscoveryMutlicastGroup(_socket);
		}
		foreach (EventHandler<DiscoverySocketEventArgs> value in callbacks)
		{
			_socket.MessageReceived += value;
		}
		StartListen(timeout, from, deviceId, null, parseLater: false);
	}

	public void Close()
	{
		cts?.Cancel();
		cts = null;
		lock (_socketSync)
		{
			if (_socket != null)
			{
				_socket.Close();
			}
		}
	}

	public void Dispose()
	{
		Close();
	}
}
