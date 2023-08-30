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
[XmlRoot("Sig", Namespace = "http://schemas.xmlsoap.org/ws/2005/04/discovery", IsNullable = false)]
public class SigType
{
	private XmlElement[] anyField;

	private string schemeField;

	private byte[] keyIdField;

	private string refsField;

	private byte[] sigField;

	private XmlAttribute[] anyAttrField;

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

	[XmlAttribute(DataType = "anyURI")]
	public string Scheme
	{
		get
		{
			return schemeField;
		}
		set
		{
			schemeField = value;
		}
	}

	[XmlAttribute(DataType = "base64Binary")]
	public byte[] KeyId
	{
		get
		{
			return keyIdField;
		}
		set
		{
			keyIdField = value;
		}
	}

	[XmlAttribute(DataType = "IDREFS")]
	public string Refs
	{
		get
		{
			return refsField;
		}
		set
		{
			refsField = value;
		}
	}

	[XmlAttribute(DataType = "base64Binary")]
	public byte[] Sig
	{
		get
		{
			return sigField;
		}
		set
		{
			sigField = value;
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
