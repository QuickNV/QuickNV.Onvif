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
[XmlRoot("Bye", Namespace = "http://schemas.xmlsoap.org/ws/2005/04/discovery", IsNullable = false)]
public class ByeType
{
	private EndpointReferenceType endpointReferenceField;

	private string typesField;

	private ScopesType scopesField;

	private string xAddrsField;

	private uint metadataVersionField;

	private bool metadataVersionFieldSpecified;

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

	public string XAddrs
	{
		get
		{
			return xAddrsField;
		}
		set
		{
			xAddrsField = value;
		}
	}

	public uint MetadataVersion
	{
		get
		{
			return metadataVersionField;
		}
		set
		{
			metadataVersionField = value;
		}
	}

	[XmlIgnore]
	public bool MetadataVersionSpecified
	{
		get
		{
			return metadataVersionFieldSpecified;
		}
		set
		{
			metadataVersionFieldSpecified = value;
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
