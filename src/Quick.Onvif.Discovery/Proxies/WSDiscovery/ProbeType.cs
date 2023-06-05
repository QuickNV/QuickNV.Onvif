using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace Quick.Onvif.Discovery.WSDiscovery;

[Serializable]
[GeneratedCode("xsd", "2.0.50727.3038")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://schemas.xmlsoap.org/ws/2005/04/discovery")]
[XmlRoot("Probe", Namespace = "http://schemas.xmlsoap.org/ws/2005/04/discovery", IsNullable = false)]
public class ProbeType
{
	private string typesField;

	private ScopesType scopesField;

	private XmlElement[] anyField;

	private XmlAttribute[] anyAttrField;

	public string Types
	{
		get
		{
			return typesField;
		}
		set
		{
			typesField = value;
		}
	}

	public ScopesType Scopes
	{
		get
		{
			return scopesField;
		}
		set
		{
			scopesField = value;
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
