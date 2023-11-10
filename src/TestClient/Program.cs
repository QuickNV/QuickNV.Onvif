using Newtonsoft.Json;
using QuickNV.Onvif;
using QuickNV.Onvif.Discovery;
using QuickNV.Onvif.Media;

var discovery = new DiscoveryController2(TimeSpan.FromSeconds(1));
var devices = await discovery.RunDiscovery();

if(!devices.Any())
{
    Console.WriteLine("No cameras found");
    return;
}
Console.WriteLine("Found {0} cameras", devices.Length);

var device = devices.First();
var uri = new Uri(device.ServiceAddresses.First());

var client = new OnvifClient(new OnvifClientOptions
{
    Scheme = uri.Scheme,
    Host = uri.Host,
    Port = uri.Port
});


Console.WriteLine("Connecting...");
await client.ConnectAsync();
Console.WriteLine("DeviceInformation: " + JsonConvert.SerializeObject(client.DeviceInformation, Formatting.Indented));

var mediaClient = new MediaClient(client);
var profilesResponse = await mediaClient.GetProfilesAsync();

foreach (var profile in profilesResponse.Profiles)
{
    var stream = await mediaClient.QuickOnvif_GetStreamUriAsync(profile.token, true);
    var resolution = $"{profile.VideoEncoderConfiguration.Resolution.Width}x{profile.VideoEncoderConfiguration.Resolution.Height}";
    
    Console.WriteLine("Stream: {0}", new
    { 
        profile.Name, 
        StreamUrl = stream, 
        profile.VideoEncoderConfiguration.Encoding,
        resolution
    });
}


Console.ReadKey();