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
[XmlRoot("Security", Namespace = "http://schemas.xmlsoap.org/ws/2005/04/discovery", IsNullable = false)]
public class SecurityType
{
	private SigType sigField;

	private XmlAttribute[] anyAttrField;

	public SigType Sig
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
