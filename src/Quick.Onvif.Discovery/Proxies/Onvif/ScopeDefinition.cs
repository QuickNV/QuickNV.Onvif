using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace TestTool.Proxies.Onvif;

[Serializable]
[GeneratedCode("svcutil", "4.0.30319.18020")]
[XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
public enum ScopeDefinition
{
	Fixed,
	Configurable
}
