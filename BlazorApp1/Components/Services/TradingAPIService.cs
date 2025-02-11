using System.Text.Json;
using static System.Text.Json.JsonSerializer;


public class TradingAPIService

{
    private readonly HttpClient _httpClient;

    public TradingAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    //             WeatherForecast? weatherForecast = 
   //            JsonSerializer.Deserialize<WeatherForecast>(jsonString);
    public async Task<string> GetFlaskDataAsync()
    {
        var message = await _httpClient.GetStringAsync("get-trades");
        List<Trade>? trades = JsonSerializer.Deserialize<List<Trade>>(message);
        return message;
    }
    public async Task SendData()
    {
        var data = new
        {
            name = "John Doe",
            message = "Hello from Blazor!"
        };

        try
        {
            // Send POST request to Flask API with JSON data
            var response = await _httpClient.PostAsJsonAsync("post-data", data);
            var responseMessage = await response.Content.ReadAsStringAsync(); // Get response message
        }
        catch (Exception ex)
        {
            var responseMessage = $"Error: {ex.Message}";
        }
    }
}