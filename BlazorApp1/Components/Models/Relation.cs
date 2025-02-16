using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Relation
{
    [JsonPropertyName("asset")]
    public string? Asset { get; set; }

    [JsonPropertyName("broker")]
    public string? Broker { get; set; }

    [JsonPropertyName("strategy")]
    public string? Strategy { get; set; }

    [JsonPropertyName("max_trades")]
    public int? MaxTrades { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }
    public override string ToString()
    {
        return $"Asset: {Asset}, Broker: {Broker}, Strategy: {Strategy}, MaxTrades: {MaxTrades}, Id: {Id}";
    }
    public string ToJson()
    {
        var jsonObject = new { AssetBrokerStrategyRelation = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}
