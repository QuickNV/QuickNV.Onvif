namespace Quick.Onvif.Discovery.Common.Discovery;

public class CloseConnectionState
{
	public int Timeout { get; set; }

	public CloseConnectionState(int _timeout)
	{
		Timeout = _timeout;
	}
}
