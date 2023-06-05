using System;
using System.Xml;
using Quick.Onvif.Discovery.WSDiscovery;
using Quick.Onvif.Discovery.Common.Soap;

namespace Quick.Onvif.Discovery.Common.Discovery;

public class DiscoveryHeaderBuilder : ISoapHeaderBuilder
{
	private const string _wsa = "http://schemas.xmlsoap.org/ws/2004/08/addressing";

	private const string _probeAction = "http://schemas.xmlsoap.org/ws/2005/04/discovery/Probe";

	private const string _helloAction = "http://schemas.xmlsoap.org/ws/2005/04/discovery/Hello";

	public string OrigingMessageId { get; set; }

	public void WriteHeader(XmlWriter writer, object message)
	{
		writer.WriteElementString("wsa", "MessageID", "http://schemas.xmlsoap.org/ws/2004/08/addressing", "uuid:" + Guid.NewGuid().ToString());
		writer.WriteElementString("wsa", "To", "http://schemas.xmlsoap.org/ws/2004/08/addressing", "urn:schemas-xmlsoap-org:ws:2005:04:discovery");
		writer.WriteElementString("wsa", "Action", "http://schemas.xmlsoap.org/ws/2004/08/addressing", GetAction(message));
		if (!string.IsNullOrEmpty(OrigingMessageId))
		{
			writer.WriteElementString("wsa", "RelatesTo", "http://schemas.xmlsoap.org/ws/2004/08/addressing", OrigingMessageId);
		}
	}

	protected string GetAction(object message)
	{
		string result = string.Empty;
		if (message is ProbeType)
		{
			result = "http://schemas.xmlsoap.org/ws/2005/04/discovery/Probe";
		}
		else if (message is HelloType)
		{
			result = "http://schemas.xmlsoap.org/ws/2005/04/discovery/Hello";
		}
		return result;
	}
}
