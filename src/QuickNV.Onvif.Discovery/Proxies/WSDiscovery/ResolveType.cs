using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace QuickNV.Onvif.Discovery.WSDiscovery;

[Serializable]
[GeneratedCode("xsd", "2.0.50727.3038")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://schemas.xmlsoap.org/ws/2005/04/discovery")]
[XmlRoot("Resolve", Namespace = "http://schemas.xmlsoap.org/ws/2005/04/discovery", IsNullable = false)]
public class ResolveType
{
	private EndpointReferenceType endpointReferenceField;

	private XmlElement[] anyField;

	private XmlAttribute[] anyAttrField;

	[XmlElement(Namespace = "http://schemas.xmlsoap.org/ws/2004/08/addressing")]
	public EndpointReferenceType EndpointReference
	{
		get
		{
			return endpointReferenceField;
		}
		set
		{
			endpointReferenceField = value;
		}
	}

	[XmlAnyElement]
	public XmlElement[] Any
	{
		get
		{
			return anyField;
		}
		set
		{
			anyField = value;
		}
	}

	[XmlAnyAttribute]
	public XmlAttribute[] AnyAttr
	{
		get
		{
			return anyAttrField;
		}
		set
		{
			anyAttrField = value;
		}
	}
}
