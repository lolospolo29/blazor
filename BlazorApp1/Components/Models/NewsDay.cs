using System.Text.Json;
using System.Text.Json.Serialization;

#pragma warning disable CA1050 // Declare types in namespaces
public class NewsDay
#pragma warning restore CA1050 // Declare types in namespaces
{
    [JsonPropertyName("day_iso")]
    public string DayIso { get; set; }

    [JsonPropertyName("news_events")]
    public List<NewsEvent> NewsEvents { get; set; }

    public NewsDay(string dayIso, List<NewsEvent> newsEvents)
    {
        DayIso = dayIso;
        NewsEvents = newsEvents;
    }

    public string ToJson()
    {
        var jsonObject = new { NewsDay = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}