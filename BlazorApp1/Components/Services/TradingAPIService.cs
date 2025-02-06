public class TradingAPIService
{
    private ILogger _logger;

    private readonly HttpClient _httpClient;

    public TradingAPIService(ILogger logger,HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }
    public async Task<string> GetFlaskDataAsync()
    {
        return await _httpClient.GetStringAsync("get-data");
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