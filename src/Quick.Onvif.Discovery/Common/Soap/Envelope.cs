using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace Quick.Onvif.Discovery.Common.Soap;

[Serializable]
[GeneratedCode("xsd", "2.0.50727.3038")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2003/05/soap-envelope")]
[XmlRoot(ElementName = "Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
public class Envelope<T> where T : class
{
	private Header headerField;

	private Body<T> bodyField;

	private XmlAttribute[] anyAttrField;

	public Header Header
	{
		get
		{
			return headerField;
		}
		set
		{
			headerField = value;
		}
	}

	public Body<T> Body
	{
		get
		{
			return bodyField;
		}
		set
		{
			bodyField = value;
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
public class Envelope
{
	private Header headerField;

	private Body bodyField;

	private XmlAttribute[] anyAttrField;

	public Header Header
	{
		get
		{
			return headerField;
		}
		set
		{
			headerField = value;
		}
	}

	public Body Body
	{
		get
		{
			return bodyField;
		}
		set
		{
			bodyField = value;
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
