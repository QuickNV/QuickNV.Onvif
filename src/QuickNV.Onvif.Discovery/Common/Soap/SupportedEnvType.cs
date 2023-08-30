using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace QuickNV.Onvif.Discovery.Common.Soap;

[Serializable]
[GeneratedCode("xsd", "2.0.50727.3038")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2003/05/soap-envelope")]
public class SupportedEnvType
{
	private XmlQualifiedName qnameField;

	[XmlAttribute]
	public XmlQualifiedName qname
	{
		get
		{
			return qnameField;
		}
		set
		{
			qnameField = value;
		}
	}
}
