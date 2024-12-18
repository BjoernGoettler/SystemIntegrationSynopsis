using DataService.Models;
using DataService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DataService.Controllers;


[ApiController]
public class DataServiceController: ControllerBase
{
    private readonly DataRepository _dataRepository;
    private readonly StatisticsDbContext _statisticsDbContext;

    public DataServiceController(StatisticsDbContext statisticsDbContext)
    {
        _statisticsDbContext = statisticsDbContext;
        _dataRepository = new DataRepository(statisticsDbContext);
    }
    
    [HttpPost]
    [Route("/")]
    public async Task<ActionResult<StatisticsModel>> Create(IFormFile file)
    => await _dataRepository.Create(file);
    
    [HttpGet]
    [Route("/")]
    public async Task<ActionResult<List<StatisticsModel>>> GetAll()
        => await _dataRepository.GetAll();
    
    [HttpGet]
    [Route("/{id}")]
    public async Task<ActionResult<StatisticsModel>> GetById(Guid id)
        => await _dataRepository.GetById(id);
}