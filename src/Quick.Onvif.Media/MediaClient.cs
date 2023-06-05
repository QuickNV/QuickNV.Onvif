using Quick.Onvif.Factorys;
using System.Net;
using System.ServiceModel;

namespace Quick.Onvif.Media
{
    public partial class MediaClient
    {
        private OnvifClient client;

        public MediaClient(OnvifClient client)
            : this(client.ClientFactory, client.Capabilities.Media.XAddr)
        {
            this.client = client;
        }

        public MediaClient(ClientFactory factory, string url)
            : base(
                  factory.Binding,
                  new EndpointAddress(url))
        {
            factory.InitClient(this);
        }

        public async Task QuickOnvif_SnapshotAsync(string profileToken, Action<Stream> snapshotStreamHandler)
        {
            var rep = await GetSnapshotUriAsync(profileToken);
            var snapshotUri = rep.Uri;

            snapshotUri = client.CorrectUri(snapshotUri);
            //if override snapshot port 
            if (client.Options.SnapshotPort > 0)
            {
                var uriBuilder = new UriBuilder(snapshotUri);
                uriBuilder.Port = client.Options.SnapshotPort;
                snapshotUri = uriBuilder.Uri.ToString();
            }
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.UseDefaultCredentials = true;
            httpClientHandler.Credentials = new NetworkCredential(client.Options.UserName, client.Options.Password);
            using (var httpClient = new HttpClient(httpClientHandler))
            using (var snapshotStream = await httpClient.GetStreamAsync(snapshotUri))
                snapshotStreamHandler(snapshotStream);
        }

        public async Task QuickOnvif_SnapshotAsync(string profileToken, Stream stream)
        {
            await QuickOnvif_SnapshotAsync(profileToken, snapshotStream => snapshotStream.CopyTo(stream));
        }

        public async Task<byte[]> QuickOnvif_SnapshotAsync(string profileToken)
        {
            using (var ms = new MemoryStream())
            {
                await QuickOnvif_SnapshotAsync(profileToken, ms);
                return ms.ToArray();
            }
        }

        public async Task<string> QuickOnvif_GetStreamUriAsync(string profileToken, bool withCredential)
        {
            return await QuickOnvif_GetStreamUriAsync(profileToken, withCredential, StreamType.RTPUnicast, TransportProtocol.RTSP);
        }

        public async Task<string> QuickOnvif_GetStreamUriAsync(string profileToken, bool withCredential, StreamType streamType, TransportProtocol transportProtocol)
        {
            var rep = await GetStreamUriAsync(new StreamSetup()
            {
                Stream = streamType,
                Transport = new Transport()
                {
                    Protocol = transportProtocol
                }
            }, profileToken);
            var streamUri = rep.Uri;
            streamUri = client.CorrectUri(streamUri, false);
            var uriBuilder = new UriBuilder(streamUri);
            if (withCredential)
            {
                uriBuilder.UserName = client.Options.UserName;
                uriBuilder.Password = client.Options.Password;
            }
            if (client.Options.RtspPort > 0)
                uriBuilder.Port = client.Options.RtspPort;
            return uriBuilder.Uri.ToString();
        }
    }
}