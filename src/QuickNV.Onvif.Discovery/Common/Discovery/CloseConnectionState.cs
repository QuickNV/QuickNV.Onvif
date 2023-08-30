namespace QuickNV.Onvif.Discovery.Common.Discovery;

public class CloseConnectionState
{
	public int Timeout { get; set; }
	public CancellationToken CancellationToken { get; set; }

	public CloseConnectionState(int _timeout, CancellationToken _cancellationToken)
	{
		Timeout = _timeout;
		CancellationToken = _cancellationToken;
	}
}
