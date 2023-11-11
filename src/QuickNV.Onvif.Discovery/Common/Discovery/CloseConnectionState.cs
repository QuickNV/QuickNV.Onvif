namespace QuickNV.Onvif.Discovery.Common.Discovery;

public class CloseConnectionState
{
	public TimeSpan Timeout { get; set; }
	public CancellationToken CancellationToken { get; set; }

	public CloseConnectionState(TimeSpan timeout, CancellationToken _cancellationToken)
	{
		Timeout = timeout;
		CancellationToken = _cancellationToken;
	}
}
