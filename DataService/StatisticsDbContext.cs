using Microsoft.EntityFrameworkCore;

namespace DataService;

public class StatisticsContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}