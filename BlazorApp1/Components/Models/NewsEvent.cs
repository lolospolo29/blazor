using System.Text.Json;
using System.Text.Json.Serialization;

public class NewsEvent
{
    [JsonPropertyName("time")]
    public string? Time { get; set; } // Formatted as "hh:mm" like "07:00" or "01:12"

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("daytime")]
    public string? Daytime { get; set; }


    public string ToJson()
    {
        var jsonObject = new { NewsEvent = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}