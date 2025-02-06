using System;
using System.Text.Json;
using System.Text.Json.Serialization;

#pragma warning disable CA1050 // Declare types in namespaces
public class NewsEvent
#pragma warning restore CA1050 // Declare types in namespaces
{
    [JsonPropertyName("time")]
    public string Time { get; set; } // Formatted as "hh:mm" like "07:00" or "01:12"

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("daytime")]
    public string Daytime { get; set; }

    public NewsEvent(DateTime time, string title, string currency, string daytime)
    {
        Time = time.ToString("hh:mm");
        Title = title;
        Currency = currency;
        Daytime = daytime;
    }

    public string ToJson()
    {
        var jsonObject = new { NewsEvent = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}