using System.Text.Json;
using System.Text.Json.Serialization;

public class Category
{
    [JsonPropertyName("categoryId")]
    public int? CategoryId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    public string ToJson()
    {
        var jsonObject = new { ExpectedTimeFrame = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}