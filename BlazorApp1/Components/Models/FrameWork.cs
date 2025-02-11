using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class FrameWork
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("id")]
    public string? Id { get; set; }
    [JsonPropertyName("direction")]
    public string? Direction { get; set; }
    [JsonPropertyName("orderLinkId")]
    public string? orderLinkId { get; set; }
    [JsonPropertyName("timeframe")]
    public int? TimeFrame { get; set; }
    [JsonPropertyName("fib_level")]
    public float? FibLevel { get; set; }
    [JsonPropertyName("level")]
    public float? Level { get; set; }
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    public void SetTimeFrame(int timeFrame)
    {
        TimeFrame = timeFrame;
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