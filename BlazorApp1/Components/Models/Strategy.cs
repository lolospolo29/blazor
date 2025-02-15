using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;

public class Strategy
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("timeframes")]
    public List<ExpectedTimeFrame>? TimeFrames { get; set; }

    [JsonPropertyName("time_windows")]
    public List<TimeWindow>? TimeWindows { get; set; }


    public string ToJson()
    {
        var jsonObject = new { Strategy = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}