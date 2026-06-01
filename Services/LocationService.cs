using Microsoft.Maui.Devices.Sensors;
using System.Text.Json;

namespace Ranaraghini.Services;

public class LocationService
{
    // GET GPS LOCATION

    public async Task<Location?> GetCurrentLocation()
    {
        try
        {
            GeolocationRequest request =
                new GeolocationRequest(
                    GeolocationAccuracy.High,
                    TimeSpan.FromSeconds(10));

            return await Geolocation.Default
                .GetLocationAsync(request);
        }
        catch
        {
            return null;
        }
    }

    // GET EXACT ADDRESS

    public async Task<string> GetExactAddress(
        double latitude,
        double longitude)
    {
        try
        {
            string url =
                $"https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat={latitude}&lon={longitude}";

            using HttpClient client = new();

            client.DefaultRequestHeaders.Add(
                "User-Agent",
                "RanaraghiniApp");

            string response =
                await client.GetStringAsync(url);

            using JsonDocument json =
                JsonDocument.Parse(response);

            JsonElement root =
                json.RootElement;

            if (root.TryGetProperty(
                "display_name",
                out JsonElement address))
            {
                return address.GetString()
                    ?? "Address Not Found";
            }

            return "Address Not Found";
        }
        catch
        {
            return "Unable To Fetch Address";
        }
    }
}