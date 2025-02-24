using System.Text.Json;
using System.Text.Json.Serialization;

public class Result
{
    [JsonPropertyName("result_id")]
    public string? ResultId { get; set; }

    [JsonPropertyName("strategy")]
    public string? Strategy { get; set; }

    [JsonPropertyName("no_of_trades")]
    public int? NoOfTrades { get; set; }

    [JsonPropertyName("winrate")]
    public float? Winrate { get; set; }

    [JsonPropertyName("riks_ratio")]
    public float? RiskRatio { get; set; }

    [JsonPropertyName("win_count")]
    public int? WinCount { get; set; }

    [JsonPropertyName("break_even_count")]
    public int? BreakEvenCount { get; set; }

    [JsonPropertyName("loss_count")]
    public int? LossCount { get; set; }

    [JsonPropertyName("pnl_percentage")]
    public float? PnlPercentage { get; set; }

    [JsonPropertyName("average_win")]
    public float? AverageWin { get; set; }

    [JsonPropertyName("average_loss")]
    public float? AverageLoss { get; set; }

    [JsonPropertyName("average_duration")]
    public float? AverageDuration { get; set; }

    [JsonPropertyName("highest_profit")]
    public float? HighestProfit { get; set; }

    [JsonPropertyName("max_drawdown")]
    public float? MaxDrawdown { get; set; }

    public string ToJson()
    {
        var jsonObject = new { Asset = this };
        return JsonSerializer.Serialize(jsonObject, new JsonSerializerOptions { WriteIndented = true });
    }
}