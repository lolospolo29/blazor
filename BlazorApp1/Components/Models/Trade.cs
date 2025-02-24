using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Trade
{
    [JsonPropertyName("tradeId")]
    public string? TradeId { get; set; }

    [JsonPropertyName("orders")]
    public List<Order>? Orders { get; set; }

    [JsonPropertyName("relation")]
    public Relation? Relation{ get; set; }
    public string? Strategy { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("side")]
    public string? Side { get; set; }

    [JsonPropertyName("unrealisedPnl")]
    public string? UnrealisedPnl { get; set; }

    [JsonPropertyName("leverage")]
    public string? Leverage { get; set; }

    [JsonPropertyName("size")]
    public string? Size { get; set; }

    [JsonPropertyName("tradeMode")]
    public int?TradeMode { get; set; }

    [JsonPropertyName("updatedTime")]
    public string? UpdatedTime { get; set; }

    [JsonPropertyName("createdTime")]
    public string? CreatedTime { get; set; }

    public void AddOrder(Order order)
    {
        Orders ??= new List<Order>();
        Orders.Add(order);
    }

    public void AddOrders(List<Order> orders)
    {
        Orders ??= new List<Order>();
        Orders.AddRange(orders);
    }

    public string ToJson()
    {
        try
        {
            var jsonObject = new { Trade = this };
            return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
        }
        catch (Exception e)
        {
            Console.WriteLine($"Mapping Error with TradeId: {TradeId}, Error: {e}");
            return string.Empty;
        }
    }
}