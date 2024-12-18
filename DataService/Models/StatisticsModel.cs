namespace DataService.Models;

public class StatisticsModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public float AmountMax { get; set; }
    public float AmountMin { get; set; }
    public float AmountAverage { get; set; }
    public float AmountStdDev { get; set; }
    public float AmountMedian { get; set; }
    public int AmountCount { get; set; }
    public float AmountSum { get; set; }
}