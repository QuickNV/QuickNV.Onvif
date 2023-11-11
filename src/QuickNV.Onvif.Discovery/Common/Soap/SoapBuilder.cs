using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace QuickNV.Onvif.Discovery.Common.Soap;

public class SoapBuilder
{
	private static Uri _soapEnvelopeNS;

	protected static List<XmlSchema> _soapSchemas;

	private static Dictionary<Guid, XmlSerializer> _serializersCache;

	public static string SoapEnvelopeUri => _soapEnvelopeNS.ToString();

	static SoapBuilder()
	{
		_soapEnvelopeNS = new Uri("http://www.w3.org/2003/05/soap-envelope");
		_serializersCache = new Dictionary<Guid, XmlSerializer>();
		Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("QuickNV.Onvif.Discovery.Common.Discovery.Schemas.xml.xsd");
		XmlSchema item = XmlSchema.Read(manifestResourceStream, null);
		manifestResourceStream.Close();
		Stream manifestResourceStream2 = Assembly.GetExecutingAssembly().GetManifestResourceStream("QuickNV.Onvif.Discovery.Common.Discovery.Schemas.soap-envelope.xsd");
		XmlSchema item2 = XmlSchema.Read(manifestResourceStream2, null);
		manifestResourceStream2.Close();
		_soapSchemas = new List<XmlSchema> { item, item2 };
	}

	protected static XmlSerializer GetDeserializer<T>(XmlAttributeOverrides overrides) where T : class
	{
		XmlSerializer xmlSerializer = null;
		Type typeFromHandle = typeof(T);
		if (_serializersCache.ContainsKey(typeFromHandle.GUID))
		{
			xmlSerializer = _serializersCache[typeFromHandle.GUID];
		}
		else
		{
			xmlSerializer = new XmlSerializer(typeof(Envelope<T>), overrides);
			_serializersCache[typeFromHandle.GUID] = xmlSerializer;
		}
		return xmlSerializer;
	}

	protected static byte[] ToXml(object obj, Encoding encoding, XmlSerializerNamespaces namespaces)
	{
		MemoryStream memoryStream = new MemoryStream();
		XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding);
		if (namespaces != null)
		{
			xmlSerializer.Serialize(xmlTextWriter, obj, namespaces);
		}
		else
		{
			xmlSerializer.Serialize(xmlTextWriter, obj);
		}
		xmlTextWriter.Flush();
		byte[] array = new byte[3];
		memoryStream.Seek(0L, SeekOrigin.Begin);
		memoryStream.Read(array, 0, 3);
		if (array[0] != 239 || array[1] != 187 || array[2] != 191)
		{
			memoryStream.Seek(0L, SeekOrigin.Begin);
		}
		byte[] array2 = new byte[memoryStream.Length - memoryStream.Position];
		memoryStream.Read(array2, 0, array2.Length);
		xmlTextWriter.Close();
		return array2;
	}

	public static byte[] BuildMessage(object obj, Encoding encoding, ISoapHeaderBuilder header, XmlSerializerNamespaces namespaces)
	{
		XmlDocument xmlDocument = new XmlDocument();
		MemoryStream memoryStream = new MemoryStream(ToXml(obj, encoding, null));
		xmlDocument.Load(memoryStream);
		memoryStream.Close();
		Envelope envelope = new Envelope();
		envelope.Body = new Body();
		envelope.Body.Any = new XmlElement[1] { xmlDocument.DocumentElement };
		if (header != null)
		{
			MemoryStream memoryStream2 = new MemoryStream();
			XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream2, Encoding.UTF8);
			xmlTextWriter.WriteStartDocument();
			xmlTextWriter.WriteStartElement("Header");
			header.WriteHeader(xmlTextWriter, obj);
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.WriteEndDocument();
			xmlTextWriter.Flush();
			memoryStream2.Seek(0L, SeekOrigin.Begin);
			XmlDocument xmlDocument2 = new XmlDocument();
			xmlDocument2.Load(memoryStream2);
			memoryStream2.Close();
			envelope.Header = new Header();
			List<XmlElement> list = new List<XmlElement>();
			foreach (XmlElement childNode in xmlDocument2.DocumentElement.ChildNodes)
			{
				list.Add(childNode);
			}
			envelope.Header.Any = list.ToArray();
		}
		return ToXml(envelope, encoding, namespaces);
	}

	protected static XmlReader GetValidatingReader(Stream stream, ICollection<XmlSchema> validateSchemas)
	{
		List<XmlSchema> list = new List<XmlSchema>();
		list.AddRange(_soapSchemas);
		if (validateSchemas != null)
		{
			list.AddRange(validateSchemas);
		}
		XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
		xmlReaderSettings.ValidationType = ValidationType.Schema;
		xmlReaderSettings.Schemas.XmlResolver = null;
		foreach (XmlSchema item in list)
		{
			xmlReaderSettings.Schemas.Add(item);
		}
		xmlReaderSettings.Schemas.CompilationSettings.EnableUpaCheck = false;
		return XmlReader.Create(stream, xmlReaderSettings);
	}

	private static string GetTypeElementName(Type type)
	{
		string text = string.Empty;
		if (type.GetCustomAttributes(typeof(XmlRootAttribute), inherit: false) is XmlRootAttribute[] array && array.Length != 0)
		{
			text = array[0].ElementName;
		}
		if (string.IsNullOrEmpty(text))
		{
			return type.Name;
		}
		return text;
	}

	private static string GetTypeNamespace(Type type)
	{
		string result = string.Empty;
		if (type.GetCustomAttributes(typeof(XmlTypeAttribute), inherit: false) is XmlTypeAttribute[] array && array.Length != 0)
		{
			result = array[0].Namespace;
		}
		return result;
	}

	protected static XmlAttributeOverrides GetAttributeOverrides<T>() where T : class
	{
		XmlElementAttribute xmlElementAttribute = new XmlElementAttribute();
		xmlElementAttribute.ElementName = GetTypeElementName(typeof(T));
		xmlElementAttribute.Namespace = GetTypeNamespace(typeof(T));
		XmlAttributes xmlAttributes = new XmlAttributes();
		xmlAttributes.XmlElements.Add(xmlElementAttribute);
		XmlAttributeOverrides xmlAttributeOverrides = new XmlAttributeOverrides();
		xmlAttributeOverrides.Add(typeof(Body<T>), "Element", xmlAttributes);
		return xmlAttributeOverrides;
	}

	private static Envelope<T> ParseEnvelope<T>(XmlReader reader) where T : class
	{
		return (Envelope<T>)GetDeserializer<T>(GetAttributeOverrides<T>()).Deserialize(reader);
	}

	public static SoapMessage<T> ParseMessage<T>(byte[] message, ICollection<XmlSchema> validateSchemas) where T : class
	{
		MemoryStream memoryStream = new MemoryStream(message);
		XmlReader validatingReader = GetValidatingReader(memoryStream, validateSchemas);
		Envelope<T> envelope = null;
		try
		{
			envelope = ParseEnvelope<T>(validatingReader);
		}
		finally
		{
			memoryStream.Close();
		}
		List<XmlElement> list = new List<XmlElement>();
		if (envelope.Header != null && envelope.Header.Any != null)
		{
			XmlElement[] any = envelope.Header.Any;
			foreach (XmlElement item in any)
			{
				list.Add(item);
			}
		}
		if (envelope.Body.Element == null)
		{
			if (envelope.Body.Any != null && envelope.Body.Any.Length == 1)
			{
				XmlElement xmlElement = envelope.Body.Any[0];
				Uri objB = ((!string.IsNullOrEmpty(xmlElement.NamespaceURI)) ? new Uri(xmlElement.NamespaceURI) : null);
				if (xmlElement.LocalName == "Fault" && object.Equals(_soapEnvelopeNS, objB))
				{
					throw new SoapFaultException(ParseMessage<Fault>(message, null));
				}
			}
			throw new UnxpectedElementException($"Element <{GetTypeElementName(typeof(T))}> not found", list);
		}
		return new SoapMessage<T>(list, envelope.Body.Element, message);
	}
}
