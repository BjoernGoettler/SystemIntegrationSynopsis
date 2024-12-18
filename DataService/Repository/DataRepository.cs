using DataService.Models;
using DataService.WebClient;
using Microsoft.EntityFrameworkCore;

namespace DataService.Repository;

public class DataRepository
{
    private readonly StatisticsDbContext _statisticsDbContext;
    private readonly Client _client;

    public DataRepository(StatisticsDbContext statisticsDbContext)
    {
        _statisticsDbContext = statisticsDbContext;
        _client = new Client();
    }

    public async Task<StatisticsModel> Create(IFormFile file)
    {
        var response = await _client.PostFile(file);
        var statistic = ConvertResponseToModel(response);
        _statisticsDbContext.Statistics.Add(statistic);
        await _statisticsDbContext.SaveChangesAsync();
        return statistic;
    }

    public async Task<List<StatisticsModel>> GetAll()
        => await _statisticsDbContext.Statistics.ToListAsync();
    
    public async Task<StatisticsModel> GetById(Guid id)
        => await _statisticsDbContext.Statistics.FirstOrDefaultAsync(x => x.Id == id);

    private StatisticsModel ConvertResponseToModel(StatisticCreateResponseModel statisticCreateResponse)
        => new StatisticsModel
        {
            AmountMax = statisticCreateResponse.AmountMax,
            AmountMin = statisticCreateResponse.AmountMin,
            AmountAverage = statisticCreateResponse.AmountAverage,
            AmountStdDev = statisticCreateResponse.AmountStdDev,
            AmountMedian = statisticCreateResponse.AmountMedian,
            AmountCount = statisticCreateResponse.AmountCount,
            AmountSum = statisticCreateResponse.AmountSum
        };
}