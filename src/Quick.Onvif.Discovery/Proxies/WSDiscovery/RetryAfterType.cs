using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace TestTool.Proxies.WSDiscovery;

[Serializable]
[GeneratedCode("xsd", "2.0.50727.3038")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://schemas.xmlsoap.org/ws/2004/08/addressing")]
[XmlRoot("RetryAfter", Namespace = "http://schemas.xmlsoap.org/ws/2004/08/addressing", IsNullable = false)]
public class RetryAfterType
{
	private XmlAttribute[] anyAttrField;

	private string valueField;

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

	[XmlText(DataType = "nonNegativeInteger")]
	public string Value
	{
		get
		{
			return valueField;
		}
		set
		{
			valueField = value;
		}
	}
}
