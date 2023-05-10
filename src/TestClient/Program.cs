using Newtonsoft.Json;

// HTTPS Url Example: https://127.0.0.1/onvif/device_service
var deviceClient = new Quick.Onvif.Device.DeviceClient(
    "http://127.0.0.1/onvif/device_service",
    "admin",
    "Bs123456");
{
    Console.WriteLine("Geting Device Information...");
    var rep = await deviceClient.GetDeviceInformationAsync(new Quick.Onvif.Device.GetDeviceInformationRequest());
    Console.WriteLine("Device Info: " + JsonConvert.SerializeObject(rep, Formatting.Indented));
}
{
    Console.WriteLine("Geting WsdlUrl...");
    var rep = await deviceClient.GetWsdlUrlAsync();
    Console.WriteLine("WsdlUrl: " + JsonConvert.SerializeObject(rep, Formatting.Indented));
}
{
    Console.WriteLine("Geting SystemUris...");
    var rep = await deviceClient.GetSystemUrisAsync(new Quick.Onvif.Device.GetSystemUrisRequest());
    Console.WriteLine("SystemUris: " + JsonConvert.SerializeObject(rep, Formatting.Indented));
}
{
    Console.WriteLine("Geting Capabilities...");
    var rep = await deviceClient.GetCapabilitiesAsync(new Quick.Onvif.Device.CapabilityCategory[]
        {
             Quick.Onvif.Device.CapabilityCategory.All
        });
    Console.WriteLine("Capabilities: " + JsonConvert.SerializeObject(rep, Formatting.Indented));
}
