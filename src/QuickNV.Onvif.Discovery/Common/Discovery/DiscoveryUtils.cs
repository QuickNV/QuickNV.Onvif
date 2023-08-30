using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using QuickNV.Onvif.Discovery.Onvif;
using QuickNV.Onvif.Discovery.WSDiscovery;
using QuickNV.Onvif.Discovery.Common.Soap;

namespace QuickNV.Onvif.Discovery.Common.Discovery;

public class DiscoveryUtils
{
	public class DiscoveryType
	{
		public string Namespace { get; set; }

		public string Type { get; set; }

		public string Prefix { get; set; }

		public DiscoveryType(string ns, string type)
			: this(ns, type, string.Empty)
		{
		}

		public DiscoveryType(string ns, string type, string prefix)
		{
			Namespace = ns;
			Type = type;
			Prefix = prefix;
		}
	}

	public const string ONVIF_DISCOVER_TYPES = "NetworkVideoTransmitter";

	public const string ONVIF_20_DEVICE_TYPE = "Device";

	public const string WS_DISCOVER_ADDRESSING_NS = "http://schemas.xmlsoap.org/ws/2004/08/addressing";

	public const string WS_DISCOVER_NS = "http://schemas.xmlsoap.org/ws/2005/04/discovery";

	public const string SOAP_ENVELOPE_NS = "http://www.w3.org/2003/05/soap-envelope";

	public const string ONVIF_NETWORK_WSDL_URL = "http://www.onvif.org/ver10/network/wsdl";

	public const string ONVIF_20_DEVICE_NS = "http://www.onvif.org/ver10/device/wsdl";

	public const string NVT_SCOPE = "onvif://www.onvif.org/type/Network_Video_Transmitter";

	private static DiscoveryType ONVIF_10_TYPE = new DiscoveryType("http://www.onvif.org/ver10/network/wsdl", "NetworkVideoTransmitter");

	private static DiscoveryType ONVIF_20_TYPE = new DiscoveryType("http://www.onvif.org/ver10/device/wsdl", "Device");

	private static string[] _mandatoryScopes = new string[2] { "onvif://www.onvif.org/hardware", "onvif://www.onvif.org/name" };

	public static string[] GetManadatoryScopes()
	{
		return _mandatoryScopes;
	}

	public static DiscoveryType[] GetOnvif10Type()
	{
		return new DiscoveryType[1]
		{
			new DiscoveryType("http://www.onvif.org/ver10/network/wsdl", "NetworkVideoTransmitter", "dn")
		};
	}

	public static DiscoveryType[] GetOnvif20Type()
	{
		return new DiscoveryType[1]
		{
			new DiscoveryType("http://www.onvif.org/ver10/device/wsdl", "Device", "tds")
		};
	}

	private static bool CheckDeviceType(byte[] message, string typesPath, ScopesType scopes, out string reason, bool mode1, bool mode2)
	{
		reason = string.Empty;
		bool flag = true;
		if (mode1)
		{
			bool flag2 = CheckDeviceType(message, typesPath, GetOnvif10Type());
			if (!flag2)
			{
				reason = string.Format("Device type is not {0} with namespace {1}", "NetworkVideoTransmitter", "http://www.onvif.org/ver10/network/wsdl");
			}
			flag = flag && flag2;
		}
		if (mode2)
		{
			bool flag3 = CheckDeviceType(message, typesPath, GetOnvif20Type());
			if (!flag3)
			{
				if (!string.IsNullOrEmpty(reason))
				{
					reason += ", ";
				}
				reason += string.Format("Device type is not {0} with namespace {1}", "Device", "http://www.onvif.org/ver10/device/wsdl");
			}
			flag = flag && flag3;
		}
		return flag;
	}

	private static bool CheckDeviceType(byte[] message, string typesPath, DiscoveryType[] requestTypes)
	{
		bool flag = true;
		MemoryStream memoryStream = new MemoryStream(message);
		try
		{
			XPathNavigator xPathNavigator = new XPathDocument(memoryStream).CreateNavigator();
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xPathNavigator.NameTable);
			xmlNamespaceManager.AddNamespace("s", "http://www.w3.org/2003/05/soap-envelope");
			xmlNamespaceManager.AddNamespace("wsd", "http://schemas.xmlsoap.org/ws/2005/04/discovery");
			Func<string, string, string, string, IDictionary<string, string>, bool> isExpectedType = delegate(string fullType, string expectedType, string defaultNamespace, string expectedNamespace, IDictionary<string, string> namespaces)
			{
				string[] source2 = fullType.Split(':');
				string text = ((1 == source2.Count()) ? string.Empty : source2.First());
				string text2 = ((1 == source2.Count()) ? source2.First() : source2.Last());
				string text3 = defaultNamespace;
				if (!string.IsNullOrEmpty(text))
				{
					text3 = (namespaces.ContainsKey(text) ? namespaces[text] : string.Empty);
				}
				return expectedNamespace == text3 && expectedType == text2;
			};
			XPathNavigator xPathNavigator2 = xPathNavigator.SelectSingleNode(typesPath, xmlNamespaceManager);
			if (xPathNavigator2 != null)
			{
				if (!string.IsNullOrEmpty(xPathNavigator2.InnerXml))
				{
					string defaultNamespace2 = xPathNavigator2.GetNamespace(string.Empty);
					IDictionary<string, string> namespaces2 = xPathNavigator2.GetNamespacesInScope(XmlNamespaceScope.All);
					string[] source = xPathNavigator2.InnerXml.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					foreach (DiscoveryType requestType in requestTypes)
					{
						_ = requestType.Type;
						_ = requestType.Namespace;
						flag = flag && source.Any((string T) => isExpectedType(T, requestType.Type, defaultNamespace2, requestType.Namespace, namespaces2));
					}
					return flag;
				}
				return flag;
			}
			return flag;
		}
		finally
		{
			memoryStream.Close();
		}
	}

	public static bool CheckDeviceMatchType(SoapMessage<ProbeMatchesType> message, int matchNumber, out string reason, bool mode1, bool mode2)
	{
		return CheckDeviceType(message.Raw, $"/s:Envelope/s:Body/wsd:ProbeMatches/wsd:ProbeMatch/wsd:Types[{matchNumber + 1}]", message.Object.ProbeMatch[matchNumber].Scopes, out reason, mode1, mode2);
	}

	public static bool CheckDeviceMatchType(SoapMessage<ProbeMatchesType> message, int matchNumber, bool mode1, bool mode2)
	{
		string reason;
		return CheckDeviceMatchType(message, matchNumber, out reason, mode1, mode2);
	}

	public static bool CheckDeviceMatchType(SoapMessage<ProbeMatchesType> message, int matchNumber, DiscoveryType[][] requestTypes)
	{
		string typesPath = $"/s:Envelope/s:Body/wsd:ProbeMatches/wsd:ProbeMatch/wsd:Types[{matchNumber + 1}]";
		return requestTypes.Any((DiscoveryType[] types) => CheckDeviceType(message.Raw, typesPath, types));
	}

	public static bool CheckDeviceMatchType(SoapMessage<ProbeMatchesType> message, params DiscoveryType[][] requestTypes)
	{
		if (message == null)
		{
			throw new ArgumentNullException("message");
		}
		if (message.Object == null || message.Object.ProbeMatch == null)
		{
			return false;
		}
		return Enumerable.Range(0, message.Object.ProbeMatch.Length).Any(delegate(int matchNumber)
		{
			string typesPath = $"/s:Envelope/s:Body/wsd:ProbeMatches/wsd:ProbeMatch/wsd:Types[{matchNumber + 1}]";
			return requestTypes.Any((DiscoveryType[] types) => CheckDeviceType(message.Raw, typesPath, types));
		});
	}

	public static bool CheckDeviceHelloType(SoapMessage<HelloType> message, out string reason, bool mode1, bool mode2)
	{
		return CheckDeviceType(message.Raw, "/s:Envelope/s:Body/wsd:Hello/wsd:Types", message.Object.Scopes, out reason, mode1, mode2);
	}

	protected static Guid ParseUUID(string uuid)
	{
		Guid result = Guid.Empty;
		if (uuid.StartsWith("uuid:") && uuid.Length > 5)
		{
			result = new Guid(uuid.Substring(5, uuid.Length - 5));
		}
		return result;
	}

	public static bool CompareUUID(string a, string b)
	{
		Guid guid = ParseUUID(a);
		Guid guid2 = ParseUUID(b);
		return guid == guid2;
	}

	public static bool CompareAddresses(System.Net.IPAddress a, System.Net.IPAddress b)
	{
		bool result = true;
		if (a == null && b == null)
		{
			return true;
		}
		if (a == null || b == null)
		{
			return false;
		}
		if (a.AddressFamily != b.AddressFamily)
		{
			return false;
		}
		if (a.AddressFamily == AddressFamily.InterNetworkV6)
		{
			byte[] addressBytes = a.GetAddressBytes();
			byte[] addressBytes2 = b.GetAddressBytes();
			for (int i = 0; i < addressBytes.Length; i++)
			{
				if (addressBytes[i] != addressBytes2[i])
				{
					return false;
				}
			}
		}
		else
		{
			result = object.Equals(a, b);
		}
		return result;
	}

	public static bool CompareUri(string uriA, string uriB)
	{
		Uri objA = new Uri(uriA);
		Uri objB = new Uri(uriB);
		return object.Equals(objA, objB);
	}

	public static string ExtractMessageId(byte[] message)
	{
		return ExtractElementValue(message, "MessageID", "http://schemas.xmlsoap.org/ws/2004/08/addressing");
	}

	public static string ExtractRelatesTo(ICollection<XmlElement> header)
	{
		string empty = string.Empty;
		foreach (XmlElement item in header)
		{
			if (item.LocalName == "RelatesTo" && CompareUri(item.NamespaceURI, "http://schemas.xmlsoap.org/ws/2004/08/addressing"))
			{
				return item.InnerText;
			}
		}
		return empty;
	}

	protected static string ExtractElementValue(byte[] xml, string element, string elementNSUri)
	{
		string result = string.Empty;
		MemoryStream memoryStream = new MemoryStream(xml);
		XPathNodeIterator xPathNodeIterator = new XPathDocument(memoryStream).CreateNavigator().SelectDescendants(element, elementNSUri, matchSelf: false);
		if (xPathNodeIterator.Count == 1)
		{
			xPathNodeIterator.MoveNext();
			result = xPathNodeIterator.Current.InnerXml;
		}
		memoryStream.Close();
		return result;
	}

	protected static bool FindScope(IEnumerable<string> scopes, string scope)
	{
		bool result = false;
		foreach (string scope2 in scopes)
		{
			if (scope2.StartsWith(scope, ignoreCase: true, CultureInfo.InvariantCulture))
			{
				return true;
			}
		}
		return result;
	}

	protected static bool FindScopeExact(IEnumerable<string> scopes, string scope)
	{
		bool result = false;
		foreach (string scope2 in scopes)
		{
			if (StringComparer.InvariantCulture.Compare(scope2, scope) == 0)
			{
				return true;
			}
		}
		return result;
	}

	public static string GetMissingMandatoryScope(Scope[] scopes)
	{
		string[] array = new string[scopes.Length];
		int num = 0;
		foreach (Scope scope in scopes)
		{
			array[num++] = scope.ScopeItem;
		}
		return GetMissingMandatoryScope(array);
	}

	public static string GetMissingMandatoryScope(string[] scopes)
	{
		return GetMissingScope(scopes, _mandatoryScopes);
	}

	public static string GetMissingScope(string[] deviceScopes, string[] scopesToCheck)
	{
		List<string> list = new List<string>();
		if (deviceScopes != null)
		{
			string[] array = deviceScopes;
			foreach (string text in array)
			{
				string[] separator = new string[2]
				{
					Environment.NewLine,
					" "
				};
				list.AddRange(text.Split(separator, StringSplitOptions.RemoveEmptyEntries));
			}
			array = scopesToCheck;
			foreach (string text2 in array)
			{
				if (!FindScope(list, text2))
				{
					return text2;
				}
			}
		}
		return string.Empty;
	}

	public static System.Net.IPAddress GetIP(string hostName, bool ipv6)
	{
		System.Net.IPAddress address = null;
		if (!string.IsNullOrEmpty(hostName))
		{
			try
			{
				if (System.Net.IPAddress.TryParse(hostName, out address))
				{
					return address;
				}
				IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
				if (hostEntry == null)
				{
					return address;
				}
				System.Net.IPAddress[] addressList = hostEntry.AddressList;
				foreach (System.Net.IPAddress iPAddress in addressList)
				{
					if ((ipv6 && iPAddress.AddressFamily == AddressFamily.InterNetworkV6) || (!ipv6 && iPAddress.AddressFamily == AddressFamily.InterNetwork))
					{
						address = iPAddress;
						return address;
					}
				}
				return address;
			}
			catch
			{
				return address;
			}
		}
		return address;
	}

	public static bool IsCorrectSoapFault(Fault fault, string code, string codeNS, string subcode, string subCodeNS, out string reason)
	{
		reason = null;
		if (fault.Code.Value.Name != code)
		{
			reason = $"Invalid fault code returned. Expected: {code} - Actual: {fault.Code.Value.Name}";
			return false;
		}
		if (!CompareUri(fault.Code.Value.Namespace, codeNS))
		{
			reason = $"Invalid fault code namespace. Expected: {codeNS} - Actual: {fault.Code.Value.Namespace}";
			return false;
		}
		if (fault.Code.Subcode.Value.Name != subcode)
		{
			reason = $"Invalid fault subcode returned. Expected: {subcode} - Actual: {fault.Code.Subcode.Value.Name}";
			return false;
		}
		if (!CompareUri(fault.Code.Subcode.Value.Namespace, subCodeNS))
		{
			reason = $"Invalid fault subcode namespace. Expected: {subCodeNS} - Actual: {fault.Code.Subcode.Value.Namespace}";
			return false;
		}
		return true;
	}

	public static string XmlToString(byte[] xml)
	{
		return Encoding.UTF8.GetString(xml);
	}

	public static List<DeviceDiscoveryData> GetDevices(SoapMessage<ProbeMatchesType> message, System.Net.IPAddress sender, DiscoveryType[][] types)
	{
		List<DeviceDiscoveryData> list = new List<DeviceDiscoveryData>();
		if (message.Object.ProbeMatch != null)
		{
			for (int i = 0; i < message.Object.ProbeMatch.Length; i++)
			{
				ProbeMatchType probeMatchType = message.Object.ProbeMatch[i];
				if (probeMatchType.XAddrs != null && ((types == null) ? CheckDeviceMatchType(message, i, mode1: true, mode2: false) : CheckDeviceMatchType(message, i, types)))
				{
					DeviceDiscoveryData deviceDiscoveryData = new DeviceDiscoveryData();
					deviceDiscoveryData.Type = probeMatchType.Types;
					deviceDiscoveryData.Scopes = probeMatchType.Scopes.Text[0];
					deviceDiscoveryData.EndPointAddress = sender.ToString();
					string[] collection = probeMatchType.XAddrs.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
					deviceDiscoveryData.ServiceAddresses.AddRange(collection);
					deviceDiscoveryData.UUID = probeMatchType.EndpointReference.Address.Value;
					deviceDiscoveryData.MetadataVersion = probeMatchType.MetadataVersion;
					list.Add(deviceDiscoveryData);
				}
			}
		}
		return list;
	}

	public static string GetDeviceId(ProbeMatchesType matches)
	{
		string result = string.Empty;
		if (matches != null && matches.ProbeMatch != null && matches.ProbeMatch.Length != 0 && matches.ProbeMatch[0].EndpointReference != null && matches.ProbeMatch[0].EndpointReference.Address != null)
		{
			result = matches.ProbeMatch[0].EndpointReference.Address.Value;
		}
		return result;
	}

	public static string GetDeviceId(HelloType hello)
	{
		string result = string.Empty;
		if (hello != null && hello.EndpointReference != null && hello.EndpointReference.Address != null)
		{
			result = hello.EndpointReference.Address.Value;
		}
		return result;
	}

	public static string GetDeviceId(ByeType bye)
	{
		string result = string.Empty;
		if (bye != null && bye.EndpointReference != null && bye.EndpointReference.Address != null)
		{
			result = bye.EndpointReference.Address.Value;
		}
		return result;
	}
}
