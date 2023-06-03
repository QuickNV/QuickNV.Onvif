using System;
using Quick.Onvif.Discovery.Common.Soap;

namespace Quick.Onvif.Discovery.Common.Discovery;

public class DiscoveryErrorEventArgs : EventArgs
{
	public Exception Exception { get; protected set; }

	public Fault Fault { get; protected set; }

	public DiscoveryErrorEventArgs(Exception exception, Fault fault)
	{
		Fault = fault;
		Exception = exception;
	}
}
