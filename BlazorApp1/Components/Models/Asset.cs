using System.Text.Json;
using System.Text.Json.Serialization;

public class Asset
{
    [JsonPropertyName("asset_id")]
    public int? AssetId { get; set; } 

    [JsonPropertyName("name")]
    public string? Name { get; set; } 

    [JsonPropertyName("asset_class")]
    public string? AssetClass { get; set; }

    [JsonPropertyName("smt_pairs")]
    public List<SMTPair>? SMTPairs { get; set; }

    [JsonPropertyName("relations")]
    public List<Relation>? Relations { get; set; }

    public string ToJson()
    {
        var jsonObject = new { Asset = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}