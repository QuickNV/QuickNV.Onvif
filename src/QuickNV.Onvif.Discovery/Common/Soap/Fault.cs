using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace QuickNV.Onvif.Discovery.Common.Soap;

[Serializable]
[GeneratedCode("xsd", "2.0.50727.3038")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2003/05/soap-envelope")]
[XmlRoot(Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
public class Fault
{
	private faultcode codeField;

	private reasontext[] reasonField;

	private string nodeField;

	private string roleField;

	private detail detailField;

	public faultcode Code
	{
		get
		{
			return codeField;
		}
		set
		{
			codeField = value;
		}
	}

	[XmlArrayItem("Text", IsNullable = false)]
	public reasontext[] Reason
	{
		get
		{
			return reasonField;
		}
		set
		{
			reasonField = value;
		}
	}

	[XmlElement(DataType = "anyURI")]
	public string Node
	{
		get
		{
			return nodeField;
		}
		set
		{
			nodeField = value;
		}
	}

	[XmlElement(DataType = "anyURI")]
	public string Role
	{
		get
		{
			return roleField;
		}
		set
		{
			roleField = value;
		}
	}

	public detail Detail
	{
		get
		{
			return detailField;
		}
		set
		{
			detailField = value;
		}
	}
}
