using Newtonsoft.Json;

var factory = new Quick.Onvif.Core.HttpClientFactory(
    "http://127.0.0.1/onvif/device_service",
    "admin",
    "Bs123456");
var deviceClient = new Quick.Onvif.Device.DeviceClient(factory);
Console.WriteLine("Geting Device Information...");
var rep = await deviceClient.GetDeviceInformationAsync(new Quick.Onvif.Device.GetDeviceInformationRequest());
Console.WriteLine("Device Info: " + JsonConvert.SerializeObject(rep, Formatting.Indented));
