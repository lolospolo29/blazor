using System.Text.Json;
using System.Text.Json.Serialization;
public class SMTPair
{
    [JsonPropertyName("strategy")]
    public string Strategy { get; set; }

    [JsonPropertyName("smt_pairs")]
    public List<string> SmtPairs { get; set; }

    [JsonPropertyName("correlation")]
    public string Correlation { get; set; }

    public SMTPair(string strategy, List<string> smtPairs, string correlation)
    {
        Strategy = strategy;
        SmtPairs = smtPairs;
        Correlation = correlation;
    }

    public string ToJson()
    {
        var jsonObject = new { SMTPair = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}