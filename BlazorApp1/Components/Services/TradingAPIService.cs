using System.Text.Json;
using static System.Text.Json.JsonSerializer;


public class TradingAPIService

{
    private readonly HttpClient _httpClient;

    public TradingAPIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Trade>> GetTrades()
    {
        var message = await _httpClient.GetStringAsync("get-trades");
        List<Trade>? trades = JsonSerializer.Deserialize<List<Trade>>(message);
#pragma warning disable CS8603 // Possible null reference return.
        return trades;
#pragma warning restore CS8603 // Possible null reference return.
    }
    public async Task<List<Asset>> GetAssets()
    {
        var message = await _httpClient.GetStringAsync("get-assets");
        List<Asset>? assets = JsonSerializer.Deserialize<List<Asset>>(message);
#pragma warning disable CS8603 // Possible null reference return.
        return assets;
#pragma warning restore CS8603 // Possible null reference return.
    }
    public async Task<List<Strategy>> GetStrategies()
    {
        var message = await _httpClient.GetStringAsync("get-assets");
        List<Strategy>? strategies = JsonSerializer.Deserialize<List<Strategy>>(message);
#pragma warning disable CS8603 // Possible null reference return.
        return strategies;
#pragma warning restore CS8603 // Possible null reference return.
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