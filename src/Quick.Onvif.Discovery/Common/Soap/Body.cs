using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace Quick.Onvif.Discovery.Common.Soap;

[Serializable]
[GeneratedCode("xsd", "2.0.50727.3038")]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2003/05/soap-envelope")]
[XmlRoot(Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
public class Body<T> where T : class
{
	private T element;

	private XmlElement[] anyField;

	private XmlAttribute[] anyAttrField;

	[XmlElement(ElementName = "Element")]
	public T Element
	{
		get
		{
			return element;
		}
		set
		{
			element = value;
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
[Serializable]
[GeneratedCode("xsd", "2.0.50727.3038")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2003/05/soap-envelope")]
[XmlRoot(Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
public class Body
{
	private XmlElement[] anyField;

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
