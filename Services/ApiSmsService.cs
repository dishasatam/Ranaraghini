using System.Net.Http;

namespace Ranaraghini.Services;

public class ApiSmsService
{
    private readonly HttpClient _httpClient;

    public ApiSmsService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> SendSms(
        string phoneNumber,
        string message)
    {
        try
        {
            string apiKey =
                "QehWtOtI0QRnEYNI5b4g8ZjApudWbYFhtQEAXgW0vRIWEmbYwLwr7FDqbR30";

            _httpClient.DefaultRequestHeaders.Clear();

            _httpClient.DefaultRequestHeaders.Add(
                "authorization",
                apiKey);

            var content =
                new FormUrlEncodedContent(
                    new[]
                    {
                        new KeyValuePair<string, string>(
                            "message",
                            message),

                        new KeyValuePair<string, string>(
                            "language",
                            "english"),

                        new KeyValuePair<string, string>(
                            "route",
                            "q"),

                        new KeyValuePair<string, string>(
                            "numbers",
                            phoneNumber)
                    });

            var response =
                await _httpClient.PostAsync(
                    "https://www.fast2sms.com/dev/bulkV2",
                    content);

            // SUCCESS

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            // FAILED

            return false;
        }
        catch
        {
            return false;
        }
    }
}