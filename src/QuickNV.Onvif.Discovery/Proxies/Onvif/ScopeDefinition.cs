using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace QuickNV.Onvif.Discovery.Onvif;

[Serializable]
[GeneratedCode("svcutil", "4.0.30319.18020")]
[XmlType(Namespace = "http://www.onvif.org/ver10/schema")]
public enum ScopeDefinition
{
	Fixed,
	Configurable
}
