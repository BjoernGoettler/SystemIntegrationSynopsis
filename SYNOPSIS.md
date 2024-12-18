# System Integration Synopsis

### Content

- Motivation
- Theory
- Practice
- Conclusion

## Motivation

Python has a large adoption amongst data scientist, and offers a toolbox ready to use for crunching numbers.
Over time, it has become easyer to source skilled labour, regarding the development of computational software.
In this solution the surface is barely scratched, but if it was to be extended with additional functionality, it would be a rather trivial task to just hook into code, written by people who are better at math than myself.

Dotnet is available on most platforms these days, and offers a toolset that makes it easy to develop a lot of functionality, within a limited time frame. It is also rather performant (especially compared to python), and for trivial tasks like this, it is easy to find skilled enough engineers

## Theory

### FastAPI

FastAPI is a popular (and fast) web framework for Python. It uses Python type annotation which makes it easy to work with in modern software IDE's.
When communicating data back and forth it uses Pydantic models, which name might insinuate that it is quite pedantic. What seems like limitations in the freedom of how you can code python, gives us the desired speed

### Pandas

Pandas is a library used for data-analysis and manipulation. Underneath the hood it is build in C, which makes it quite fast.

In this project I make use if DataFrames and Series.
The entire CSV-file is converted into a DataFrame, and each column is a Series

### C#
After releasing dotnetcore, C# has been available on most platforms. The integrated tooling makes it very fast to develop in, and with its frequent relase cycle, optimizations hits the end users fast. 


### Applied theory
#### async/await
All methods communicate asynchronously with each other, to reduce response time.

#### Dependency injection
Where needed, dependencies are injected

## Practice

### Shared models
When working with 2 languages, we need to come up with a common understanding for how data is to be presented. There a 2 quite simular "Data Transfer Objects" (here after DTO's)
In python we extend Pydantics BaseModel

```python
class StatisticsReturnModel(BaseModel):
    amount_max: float
    amount_min: float
    amount_avg: float
    amount_sum: float
    amount_count: int
    amount_std: float
    amount_median: float
```

In C# it's just an object, with getters and setters, but with attributes that says what the corresponding key is called in the remote system

```csharp
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
```

### File as HTTP payload

Both API's takes a file as input. 
In C# the controller simply takes the IFormFile interface as an input, so it can be directly relayed to the repository, where it is passed on to the web-client

```csharp
public async Task<StatisticsModel> Create(IFormFile file)
    {
        var response = await _client.PostFile(file);
        var statistic = ConvertResponseToModel(response);
        _statisticsDbContext.Statistics.Add(statistic);
        await _statisticsDbContext.SaveChangesAsync();
        return statistic;
    }
```

Pandas can read CSV-files, but only from disk or a http (and we are sort of coming in the other way), so we have to grap the incomming file, read it, and pass in the content as a string, that we then have to make look as a file with StringIO:
```python
df = pd.read_csv(StringIO(file), sep=";")
```

### Pandas

Once the file is converted to a Dataframe, we can benefit from pandas build in computational functions
```python
    beloeb_i_alt: Series = df.beloeb_i_alt

    amount_max: float = beloeb_i_alt.max()
    amount_min: float = beloeb_i_alt.min()
    amount_avg: float = beloeb_i_alt.mean()
    amount_sum: float = beloeb_i_alt.sum()
    amount_count: int = beloeb_i_alt.count()
    amount_std: float = beloeb_i_alt.std()
    amount_median: float = beloeb_i_alt.median()
```

Now it's just a matter of returning, answering and persisting the data. The heavy lifting is done

### Database and dependency injection
The database context is injected into the constructors, through the Web-API:
```csharp
builder.Services.AddDbContext<StatisticsDbContext>(options => options.UseInMemoryDatabase("Statistics"));
```
EntityFramework offers us an In-memory database that we use for this project. Because of the dependency injection, we can configure this how we want it. If the project gets some traction in real life, it's easy for us to just change the database on the fly, or due to changes in the environment

## Conlusion

The project showed a way of connecting two services, written in each their language.
For one service we used C# to give us a simple API, and for the other service we used Python for computations.
One should think before juggling languages around like this, it introduces a lot of overhead when it comes to development skills, since you will have to maintain two languages. On the other hand, if you can agree on the DTO's it make out-sourcing simpler, because you could just specify what data you havem and what you expect to get back,
and then let the implementers decide on what technology to solve it with

When interfacing microservices with each other we can benefit from them being agnostic to who uses them, and this project demonstrates that.
It would, however, not take much effort to do the exact same computation in plain C#, and when asked how much power Python uses compared to dotnet, we would have to answer that the difference is significant
