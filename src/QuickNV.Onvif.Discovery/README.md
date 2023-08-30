# QuickNV.Onvif.Discovery [![NuGet Version](http://img.shields.io/nuget/v/Quick.QuickNV.Discovery.svg?style=flat)](https://www.nuget.org/packages/Quick.QuickNV.Discovery/)

* [QuickNV.Onvif.Discovery] can discovery Onvif devices in local network.

## How to Use
```csharp
using Newtonsoft.Json;
using QuickNV.Onvif.Discovery;
using System.Net;

var localIpAddress = "192.168.31.72";
var controller = new DiscoveryController2(IPAddress.Parse(localIpAddress));
try
{
    Console.WriteLine("Start Discovery...");
    var devices = await controller.RunDiscovery();
    Console.WriteLine($"Find {devices.Length} devices.");
    Console.WriteLine(JsonConvert.SerializeObject(devices, Formatting.Indented));
}
catch (Exception ex)
{
    Console.WriteLine("Discovery error,reason: " + ex.Message);
}
Console.ReadLine();
```