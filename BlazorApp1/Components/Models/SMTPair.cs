using System.Text.Json;
using System.Text.Json.Serialization;
public class SMTPair
{
    [JsonPropertyName("strategy")]
    public string Strategy { get; set; }

    [JsonPropertyName("asset_a")]
    public string AssetA { get; set; }

    [JsonPropertyName("asset_b")]
    public string AssetB { get; set; }

    [JsonPropertyName("correlation")]
    public string Correlation { get; set; }

    public SMTPair(string? strategy, string? correlation, string? assetA, string? assetB)
    {
        Strategy = strategy ?? string.Empty;
        Correlation = correlation ?? string.Empty;
        AssetA = assetA ?? string.Empty;
        AssetB = assetB ?? string.Empty;
    }

    public string ToJson()
    {
        var jsonObject = new { SMTPair = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}