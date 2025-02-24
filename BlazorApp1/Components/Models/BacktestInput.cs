using System.Text.Json;
using System.Text.Json.Serialization;

public class BacktestInput
{
    [JsonPropertyName("strategy")]
    public string? Strategy { get; set; }

    [JsonPropertyName("test_assets")]
    public List<string>? TestAssets { get; set; }

    public string ToJson()
    {
        var jsonObject = new { Asset = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}