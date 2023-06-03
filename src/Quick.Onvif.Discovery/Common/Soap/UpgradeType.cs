using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Quick.Onvif.Discovery.Common.Soap;

[Serializable]
[GeneratedCode("xsd", "2.0.50727.3038")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2003/05/soap-envelope")]
[XmlRoot("Upgrade", Namespace = "http://www.w3.org/2003/05/soap-envelope", IsNullable = false)]
public class UpgradeType
{
	private SupportedEnvType[] supportedEnvelopeField;

	[XmlElement("SupportedEnvelope")]
	public SupportedEnvType[] SupportedEnvelope
	{
		get
		{
			return supportedEnvelopeField;
		}
		set
		{
			supportedEnvelopeField = value;
		}
	}
}
