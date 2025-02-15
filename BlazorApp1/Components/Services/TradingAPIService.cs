using System.Text;
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
        return trades ?? [];
    }
    public async Task<List<Asset>> GetAssets()
    {
        var message = await _httpClient.GetStringAsync("get-assets");
        List<Asset>? assets = JsonSerializer.Deserialize<List<Asset>>(message);
        return assets ?? [];
    }
    public async Task<List<Strategy>> GetStrategies()
    {
        var message = await _httpClient.GetStringAsync("get-strategies");
        List<Strategy>? strategies = JsonSerializer.Deserialize<List<Strategy>>(message);
        return strategies ?? [];
    }
    public async Task CreateAsset(Asset asset)
    {
        var data = asset.ToJson();
        try
        {
            // Send POST request to Flask API with JSON data
            var jsonString = JsonSerializer.Serialize(asset);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("create-asset", content);
        }
        catch (Exception ex)
        {
            var responseMessage = $"Error: {ex.Message}";
        }
    }
    public async Task UpdateAsset(Asset asset)
    {
        var data = asset.ToJson();
        try
        {
            // Send POST request to Flask API with JSON data
            var jsonString = JsonSerializer.Serialize(asset);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("update-asset", content);
        }
        catch (Exception ex)
        {
            var responseMessage = $"Error: {ex.Message}";
        }
    }

}