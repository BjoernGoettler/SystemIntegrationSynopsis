using System.Text.Json.Serialization;

namespace DataService.Models;

public class StatisticCreateResponseModel
{
    [JsonPropertyName("amount_max")]
    public float AmountMax { get; set; }
    [JsonPropertyName("amount_min")]
    public float AmountMin { get; set; }
    [JsonPropertyName("amount_avg")]
    public float AmountAverage { get; set; }
    [JsonPropertyName("amount_sum")]
    public float AmountSum { get; set; }
    [JsonPropertyName("amount_count")]
    public int AmountCount { get; set; }
    [JsonPropertyName("amount_std")]
    public float AmountStdDev { get; set; }
    [JsonPropertyName("amount_median")]
    public float AmountMedian { get; set; }
}