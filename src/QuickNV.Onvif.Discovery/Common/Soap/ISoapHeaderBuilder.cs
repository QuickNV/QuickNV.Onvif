using System.Xml;

namespace QuickNV.Onvif.Discovery.Common.Soap;

public interface ISoapHeaderBuilder
{
	void WriteHeader(XmlWriter writer, object message);
}
