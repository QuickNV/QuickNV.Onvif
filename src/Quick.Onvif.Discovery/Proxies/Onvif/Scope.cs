using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quick.Onvif.Discovery.Onvif;

[Serializable]
[GeneratedCode("svcutil", "4.0.30319.18020")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
public class Scope
{
	private ScopeDefinition scopeDefField;

	private string scopeItemField;

	[XmlElement(Order = 0)]
	public ScopeDefinition ScopeDef
	{
		get
		{
			return scopeDefField;
		}
		set
		{
			scopeDefField = value;
		}
	}

	[XmlElement(DataType = "anyURI", Order = 1)]
	public string ScopeItem
	{
		get
		{
			return scopeItemField;
		}
		set
		{
			scopeItemField = value;
		}
	}
}
