using System.Collections.Generic;
using System.Xml;

namespace Quick.Onvif.Discovery.Common.Soap;

internal class UnxpectedElementException : XmlException
{
	public List<XmlElement> Headers { get; protected set; }

	public UnxpectedElementException(string message, List<XmlElement> headers)
		: base(message)
	{
		Headers = headers;
	}
}
