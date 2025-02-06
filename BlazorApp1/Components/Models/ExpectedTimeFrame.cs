using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;

public class ExpectedTimeFrame
{
    [JsonPropertyName("timeframe")]
    public string Timeframe { get; set; }

    [JsonPropertyName("maxLen")]
    public int MaxLen { get; set; }

    public ExpectedTimeFrame(string timeframe, int maxLen)
    {
        Timeframe = timeframe;
        MaxLen = maxLen;
    }

    public string ToJson()
    {
        var jsonObject = new { ExpectedTimeFrame = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}