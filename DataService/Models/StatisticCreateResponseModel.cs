namespace DataService.Models;

public class StatisticCreateResponse
{
    public float AmountMax { get; set; }
    public float AmountMin { get; set; }
    public float AmountAverage { get; set; }
    public float AmountSum { get; set; }
    public int AmountCount { get; set; }
    public float AmountStdDev { get; set; }
    public float AmountMedian { get; set; }
}