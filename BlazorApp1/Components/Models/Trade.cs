using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Trade
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("orders")]
    public List<string> Orders { get; set; }

    [JsonPropertyName("asset")]
    public string Asset { get; set; }

    [JsonPropertyName("broker")]
    public string Broker { get; set; }

    [JsonPropertyName("strategy")]
    public string Strategy { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }

    [JsonPropertyName("side")]
    public string Side { get; set; }

    [JsonPropertyName("tpslMode")]
    public string TpslMode { get; set; }

    [JsonPropertyName("unrealisedPnl")]
    public double UnrealisedPnl { get; set; }

    [JsonPropertyName("leverage")]
    public int Leverage { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("tradeMode")]
    public string TradeMode { get; set; }

    [JsonPropertyName("updatedTime")]
    public string UpdatedTime { get; set; }

    [JsonPropertyName("createdTime")]
    public string CreatedTime { get; set; }

    public Trade(Relation relation = null, List<Order> orders = null, string id = null, string category = null)
    {
        Orders = orders != null ? orders.ConvertAll(o => o.OrderLinkId) : new List<string>();
        Asset = relation?.Asset ?? "";
        Broker = relation?.Broker ?? "";
        Strategy = relation?.Strategy ?? "";
        Id = id ?? Guid.NewGuid().ToString();
        Category = category ?? "";
        Side = "";
        TpslMode = "";
        UnrealisedPnl = 0.0;
        Leverage = 1;
        Size = 0;
        TradeMode = "";
        UpdatedTime = "";
        CreatedTime = "";
    }

    public void AddOrder(Order order)
    {
        Orders ??= new List<string>();
        Orders.Add(order.OrderLinkId);
    }

    public void AddOrders(List<Order> orders)
    {
        Orders ??= new List<string>();
        Orders.AddRange(orders.ConvertAll(o => o.OrderLinkId));
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
            Console.WriteLine($"Mapping Error with TradeId: {Id}, Error: {e}");
            return string.Empty;
        }
    }
}