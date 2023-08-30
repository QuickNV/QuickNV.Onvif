# QuickNV.Onvif

* [![NuGet Downloads](https://img.shields.io/nuget/dt/QuickNV.Onvif.svg)](https://www.nuget.org/packages/QuickNV.Onvif/)

* Api for Onvif.

Example
```
using Newtonsoft.Json;

var client = new QuickNV.Onvif.OnvifClient(new QuickNV.Onvif.OnvifClientOptions()
{
    // HTTPS Example: Scheme = "https"
    Host = "127.0.0.1",
    Port = 80,
    UserName = "admin",
    Password = "Bs123456"
});
Console.WriteLine("Connecting...");
await client.ConnectAsync();
Console.WriteLine("DeviceInformation: " + JsonConvert.SerializeObject(client.DeviceInformation, Formatting.Indented));

{
    var mediaClient = new QuickNV.Onvif.Media.MediaClient(client);
    var ret = await mediaClient.GetProfilesAsync();
    Console.WriteLine("Media Profiles: " + JsonConvert.SerializeObject(ret, Formatting.Indented));
}

{
    var mediaClient2 = new QuickNV.Onvif.Media2.Media2Client(client);
    var ret = mediaClient2.GetServiceCapabilitiesAsync();
    Console.WriteLine("Media2 ServiceCapabilities: " + JsonConvert.SerializeObject(ret, Formatting.Indented));
}
```
