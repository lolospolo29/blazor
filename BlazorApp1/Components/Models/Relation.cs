using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Relation
{
    [JsonPropertyName("asset")]
    public string Asset { get; set; }

    [JsonPropertyName("broker")]
    public string Broker { get; set; }

    [JsonPropertyName("strategy")]
    public string Strategy { get; set; }

    [JsonPropertyName("max_trades")]
    public int MaxTrades { get; set; }

    public Relation(string asset, string broker, string strategy, int maxTrades = 1)
    {
        Asset = asset;
        Broker = broker;
        Strategy = strategy;
        MaxTrades = maxTrades;
    }

    public string ToJson()
    {
        var jsonObject = new { AssetBrokerStrategyRelation = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}
