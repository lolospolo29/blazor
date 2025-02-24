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

    public async Task RunBackest(string strategy)
    {
        try
        {
            // Send POST request to Flask API with JSON data
            var jsonString = JsonSerializer.Serialize(strategy);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("run-backtest", content);
        }
        catch (Exception ex)
        {
            var responseMessage = $"Error: {ex.Message}";
        }
    }
    public async Task<List<Result>> GetTestResults(BacktestInput input)
    {
        try
        {
            // Send POST request to Flask API with JSON data
            var jsonString = JsonSerializer.Serialize(input);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            
            // Call the Flask API
            var message = await _httpClient.PostAsync("get-test-results", content);
            
            // Check if the response is successful
            if (message.IsSuccessStatusCode)
            {
                // Deserialize the response into a List<Result>
                var responseContent = await message.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<List<Result>>(responseContent);
                return result ?? new List<Result>();  // Return empty list if result is null
            }
            else
            {
                // Log or handle the failure case
                throw new Exception($"Failed to fetch results. Status Code: {message.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            // Log the error message
            var responseMessage = $"Error: {ex.Message}";
            Console.Error.WriteLine(responseMessage);  // Or log it to a logging service
            return new List<Result>();  // Return an empty list on error
        }
    }

    public async Task<List<string>> GetAssetSelection()
    {
        var message = await _httpClient.GetStringAsync("get-asset-selection");
        List<string>? selection = JsonSerializer.Deserialize<List<string>>(message);
        return selection ?? [];
    }
    public async Task CreateSMTPair(SMTPair relation)
    {
        try
        {
            // Send POST request to Flask API with JSON data
            var jsonString = JsonSerializer.Serialize(relation);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("create-smt-pair", content);
        }
        catch (Exception ex)
        {
            var responseMessage = $"Error: {ex.Message}";
        }
    }
    public async Task<List<SMTPair>> GetSMTPairs()
    {
        var message = await _httpClient.GetStringAsync("get-smt-pairs");
        List<SMTPair>? sMTPairs = JsonSerializer.Deserialize<List<SMTPair>>(message);
        return sMTPairs ?? [];
    }

    public async Task DeleteSMTPair(SMTPair sMTPair)
    {
        try
        {
            // Send POST request to Flask API with JSON data
            var jsonString = JsonSerializer.Serialize(sMTPair);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("delete-smt-pair", content);
        }
        catch (Exception ex)
        {
            var responseMessage = $"Error: {ex.Message}";
        }
    }

    public async Task CreateRelation(Relation relation)
    {
        try
        {
            // Send POST request to Flask API with JSON data
            var jsonString = JsonSerializer.Serialize(relation);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("create-relation", content);
        }
        catch (Exception ex)
        {
            var responseMessage = $"Error: {ex.Message}";
        }
    }
    public async Task<List<NewsDay>> GetNews()
    {
        var message = await _httpClient.GetStringAsync("get-news");
        List<NewsDay>? news = JsonSerializer.Deserialize<List<NewsDay>>(message);
        return news ?? [];
    }
    public async Task<List<Relation>> GetRelations()
    {
        var message = await _httpClient.GetStringAsync("get-relations");
        List<Relation>? relations = JsonSerializer.Deserialize<List<Relation>>(message);
        return relations ?? [];
    }

        public async Task UpdateRelation(Relation relation)
    {
        try
        {
            // Send POST request to Flask API with JSON data
            var jsonString = JsonSerializer.Serialize(relation);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("update-relation", content);
        }
        catch (Exception ex)
        {
            var responseMessage = $"Error: {ex.Message}";
        }
    }
    public async Task DeleteRelation(Relation relation)
    {
        try
        {
            // Send POST request to Flask API with JSON data
            var jsonString = JsonSerializer.Serialize(relation);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("delete-relation", content);
        }
        catch (Exception ex)
        {
            var responseMessage = $"Error: {ex.Message}";
        }
    }

    public async Task<List<Broker>> GetBrokers()
    {
        var message = await _httpClient.GetStringAsync("get-brokers");
        List<Broker>? brokers = JsonSerializer.Deserialize<List<Broker>>(message);
        return brokers ?? [];
    }
    
    public async Task<List<Trade>> GetTrades()
    {
        var message = await _httpClient.GetStringAsync("get-trades");
        List<Trade>? trades = JsonSerializer.Deserialize<List<Trade>>(message);
        return trades ?? [];
    }

    public async Task<List<Strategy>> GetStrategies()
    {
        var message = await _httpClient.GetStringAsync("get-strategies");
        List<Strategy>? strategies = JsonSerializer.Deserialize<List<Strategy>>(message);
        return strategies ?? [];
    }

    public async Task CreateAsset(Asset asset)
    {
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

    public async Task<List<Asset>> GetAssets()
    {
        var message = await _httpClient.GetStringAsync("get-assets");
        List<Asset>? assets = JsonSerializer.Deserialize<List<Asset>>(message);
        return assets ?? [];
    }

    public async Task UpdateAsset(Asset asset)
    {
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
    public async Task DeleteAsset(Asset asset)
    {
        try
        {
            // Send POST request to Flask API with JSON data
            var jsonString = JsonSerializer.Serialize(asset);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("delete-asset", content);
        }
        catch (Exception ex)
        {
            var responseMessage = $"Error: {ex.Message}";
        }
    }
}