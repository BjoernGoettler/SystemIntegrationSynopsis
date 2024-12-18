using DataService.Models;
using Microsoft.EntityFrameworkCore;

namespace DataService;

public class StatisticsDbContext: DbContext
{
    public StatisticsDbContext(DbContextOptions<StatisticsDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<StatisticsModel> Statistics { get; set; }
}