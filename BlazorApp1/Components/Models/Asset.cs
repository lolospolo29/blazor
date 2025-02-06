using System.Text.Json;
using System.Text.Json.Serialization;

#pragma warning disable CA1050 // Declare types in namespaces
public class Asset
#pragma warning restore CA1050 // Declare types in namespaces
#pragma warning restore CA1050 // Declare types in namespaces
{
    [JsonPropertyName("name")]
    public string Name { get; set; } 

    [JsonPropertyName("asset_class")]
    public string AssetClass { get; set; }

    [JsonPropertyName("brokers")]
    public List<string> Brokers { get; set; }

    [JsonPropertyName("strategies")]
    public List<string> Strategies { get; set; }

    [JsonPropertyName("smt_pairs")]
    public List<SMTPair> SMTPairs { get; set; }

    [JsonPropertyName("relations")]
    public List<Relation> Relations { get; set; }
    
    public Asset(string name,string assetClass,List<string> brokers,List<string> strategies,List<SMTPair> smtPairs,List<Relation> relations)
    {
        Name = name;
        AssetClass = assetClass;
        Brokers = brokers;
        Strategies = strategies;
        SMTPairs = smtPairs;
        Relations = relations;  
    }


    public string ToJson()
    {
        var jsonObject = new { Asset = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}