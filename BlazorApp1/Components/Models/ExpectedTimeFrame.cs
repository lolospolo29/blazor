using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;

public class ExpectedTimeFrame
{
    [JsonPropertyName("timeframe")]
    public int? Timeframe { get; set; }

    [JsonPropertyName("max_Len")]
    public int? MaxLen { get; set; }

    public string ToJson()
    {
        var jsonObject = new { ExpectedTimeFrame = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}