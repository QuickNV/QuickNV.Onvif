using System;
using System.Collections.Generic;
using System.Xml;

namespace Quick.Onvif.Discovery.Common.Soap;

public class SoapMessage<T> : ICloneable where T : class
{
	public List<XmlElement> Header { get; protected set; }

	public T Object { get; protected set; }

	public byte[] Raw { get; protected set; }

	public SoapMessage(List<XmlElement> header, T obj, byte[] raw)
	{
		Header = new List<XmlElement>();
		Header.AddRange(header);
		Object = obj;
		Raw = raw.Clone() as byte[];
	}

	public SoapMessage<U> ToSoapMessage<U>() where U : class
	{
		return new SoapMessage<U>(Header, Object as U, Raw);
	}

	public object Clone()
	{
		return new SoapMessage<T>(Header, Object, Raw);
	}
}
