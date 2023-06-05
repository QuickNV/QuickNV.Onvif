using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace Quick.Onvif.Discovery.WSDiscovery;

[Serializable]
[GeneratedCode("xsd", "2.0.50727.3038")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://schemas.xmlsoap.org/ws/2004/08/addressing")]
[XmlRoot("EndpointReference", Namespace = "http://schemas.xmlsoap.org/ws/2004/08/addressing", IsNullable = false)]
public class EndpointReferenceType
{
	private AttributedURI addressField;

	private ReferencePropertiesType referencePropertiesField;

	private ReferenceParametersType referenceParametersField;

	private AttributedQName portTypeField;

	private ServiceNameType serviceNameField;

	private XmlElement[] anyField;

	private XmlAttribute[] anyAttrField;

	public AttributedURI Address
	{
		get
		{
			return addressField;
		}
		set
		{
			addressField = value;
		}
	}

	public ReferencePropertiesType ReferenceProperties
	{
		get
		{
			return referencePropertiesField;
		}
		set
		{
			referencePropertiesField = value;
		}
	}

	public ReferenceParametersType ReferenceParameters
	{
		get
		{
			return referenceParametersField;
		}
		set
		{
			referenceParametersField = value;
		}
	}

	public AttributedQName PortType
	{
		get
		{
			return portTypeField;
		}
		set
		{
			portTypeField = value;
		}
	}

	public ServiceNameType ServiceName
	{
		get
		{
			return serviceNameField;
		}
		set
		{
			serviceNameField = value;
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
