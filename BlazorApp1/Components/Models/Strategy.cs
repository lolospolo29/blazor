using System;
using System.Collections.Generic;

using System.Text.Json;
using System.Text.Json.Serialization;

public class Strategy
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("timeframes")]
    public List<ExpectedTimeFrame> TimeFrames { get; set; }

    [JsonPropertyName("time_windows")]
    public List<TimeWindow> TimeWindows { get; set; }

    public Strategy(string name, List<ExpectedTimeFrame> timeFrames, List<TimeWindow> timeWindows = null)
    {
        Name = name;
        TimeFrames = timeFrames;
        TimeWindows = timeWindows ?? new List<TimeWindow>();
    }

    public List<ExpectedTimeFrame> ReturnExpectedTimeFrame()
    {
        return TimeFrames;
    }

    public string ToJson()
    {
        var jsonObject = new { Strategy = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}