using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Order
{
    [JsonPropertyName("tradeId")]
    public string? TradeId { get; set; }
    
    [JsonPropertyName("entry_frame_work")]
    public FrameWork? EntryFrameWork { get; set; }
    
    [JsonPropertyName("confirmations")]
    public List<FrameWork> Confirmations { get; set; } = new List<FrameWork>();
    
    [JsonPropertyName("order_result_status")]
    public string? OrderResultStatus { get; set; }
    
    [JsonPropertyName("risk_percentage")]
    public float? RiskPercentage { get; set; }
    
    [JsonPropertyName("money_at_risk")]
    public float? MoneyAtRisk { get; set; }
    
    [JsonPropertyName("orderLinkId")]
    public string? OrderLinkId { get; set; }
    
    [JsonPropertyName("orderType")]
    public string? OrderType { get; set; }
    
    [JsonPropertyName("symbol")]
    public string? Symbol { get; set; }
    
    [JsonPropertyName("category")]
    public string? Category { get; set; }
    
    [JsonPropertyName("side")]
    public string? Side { get; set; }
    
    [JsonPropertyName("qty")]
    public string? Qty { get; set; }
    
    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }
    
    [JsonPropertyName("isLeverage")]
    public string? IsLeverage { get; set; }
    
    [JsonPropertyName("marketUnit")]
    public string? MarketUnit { get; set; }
    
    [JsonPropertyName("orderIv")]
    public string? OrderIv { get; set; }
    
    [JsonPropertyName("stopLoss")]
    public string? StopLoss { get; set; }
    
    [JsonPropertyName("takeProfit")]
    public string? TakeProfit { get; set; }
    
    [JsonPropertyName("price")]
    public string? Price { get; set; }
    
    [JsonPropertyName("timeInForce")]
    public string? TimeInForce { get; set; }
    
    [JsonPropertyName("closeOnTrigger")]
    public bool? CloseOnTrigger { get; set; }
    
    [JsonPropertyName("reduceOnly")]
    public bool? ReduceOnly { get; set; }
    
    [JsonPropertyName("triggerPrice")]
    public string? TriggerPrice { get; set; }
    
    [JsonPropertyName("triggerBy")]
    public string? TriggerBy { get; set; }
    
    [JsonPropertyName("tpTriggerBy")]
    public string? TpTriggerBy { get; set; }
    
    [JsonPropertyName("slTriggerBy")]
    public string? SlTriggerBy { get; set; }
    
    [JsonPropertyName("triggerDirection")]
    public int? TriggerDirection { get; set; }
    
    [JsonPropertyName("tpslMode")]
    public string? TpslMode { get; set; }
    
    [JsonPropertyName("tpLimitPrice")]
    public string? TpLimitPrice { get; set; }
    
    [JsonPropertyName("tpOrderType")]
    public string? TpOrderType { get; set; }
    
    [JsonPropertyName("slOrderType")]
    public string? SlOrderType { get; set; }
    
    [JsonPropertyName("slLimitPrice")]
    public string? SlLimitPrice { get; set; }
    
    [JsonPropertyName("createdTime")]
    public string? CreatedTime { get; set; }
    
    [JsonPropertyName("updatedTime")]
    public string? UpdatedTime { get; set; }
    
    [JsonPropertyName("lastPriceOnCreated")]
    public string? LastPriceOnCreated { get; set; }
    
    [JsonPropertyName("leavesQty")]
    public string? LeavesQty { get; set; }
    
    [JsonPropertyName("stopOrderType")]
    public string? StopOrderType { get; set; }
    
    [JsonPropertyName("orderStatus")]
    public string? OrderStatus { get; set; }
    
    [JsonPropertyName("leavesValue")]
    public string? LeavesValue { get; set; }
    
    public string ToJson()
    {
        try
        {
            var jsonObject = new { Order = this };
            return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
        }
        catch (Exception e)
        {
            Console.WriteLine($"Mapping Error in Order, Error: {e}");
            return string.Empty;
        }
    }
}