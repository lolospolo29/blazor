using System.Text.Json;
using System.Text.Json.Serialization;

public class NewsDay
{
    [JsonPropertyName("day_iso")]
    public string? DayIso { get; set; }

    [JsonPropertyName("news_events")]
    public List<NewsEvent>? NewsEvents { get; set; }

    public string ToJson()
    {
        var jsonObject = new { NewsDay = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}