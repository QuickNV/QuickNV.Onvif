using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Schema;
using TestTool.Proxies.WSDiscovery;
using Quick.Onvif.Discovery.Common.Soap;

namespace Quick.Onvif.Discovery.Common.Discovery;

internal class DiscoverySoapBuilder : SoapBuilder
{
	static DiscoverySoapBuilder()
	{
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Quick.Onvif.Discovery.Common.Discovery.Schemas.xml.xsd");
		XmlSchema item = XmlSchema.Read(manifestResourceStream, null);
		manifestResourceStream.Close();
		Stream manifestResourceStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream("Quick.Onvif.Discovery.Common.Discovery.Schemas.soap-envelope.xsd");
		XmlSchema item2 = XmlSchema.Read(manifestResourceStream2, null);
		manifestResourceStream2.Close();
		SoapBuilder._soapSchemas = new List<XmlSchema> { item, item2 };
		SoapBuilder.GetDeserializer<ProbeMatchesType>(SoapBuilder.GetAttributeOverrides<ProbeMatchesType>());
	}
}
