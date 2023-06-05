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
[XmlRoot("Scopes", Namespace = "http://schemas.xmlsoap.org/ws/2005/04/discovery", IsNullable = false)]
public class ScopesType
{
	private string matchByField;

	private XmlAttribute[] anyAttrField;

	private string[] textField;

	[XmlAttribute(DataType = "anyURI")]
	public string MatchBy
	{
		get
		{
			return matchByField;
		}
		set
		{
			matchByField = value;
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

	[XmlText(DataType = "anyURI")]
	public string[] Text
	{
		get
		{
			return textField;
		}
		set
		{
			textField = value;
		}
	}
}
