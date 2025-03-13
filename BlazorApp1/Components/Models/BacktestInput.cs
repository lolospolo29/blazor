using System.Text.Json;
using System.Text.Json.Serialization;

public class BacktestInput
{
    [JsonPropertyName("strategy")]
    public string? Strategy { get; set; } = string.Empty;

    [JsonPropertyName("test_assets")]
    public List<string>? TestAssets { get; set; } = new List<string>();

    [JsonPropertyName("trade_limit")]
    public int? TradeLimit { get; set; } = 2;

    public string ToJson()
    {
        var jsonObject = new { Asset = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}