using System.Text.Json;
using DataService.JsonNamingpolicies;
using DataService.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DataService.WebClient;

public class Client
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _serializerOptions;
    private readonly Uri _uri = new Uri("http://127.0.0.1:8000/");
    
    public Client()
    {
        _httpClient = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
            WriteIndented = true
        };
    }
    
    public async Task<StatisticCreateResponseModel> PostFile(IFormFile file)
    {
        var content = new MultipartFormDataContent();
        content.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);
        try
        {
            var response = await _httpClient.PostAsync(_uri, content);
            var responseString = await response.Content.ReadAsStringAsync();
            var statisticCreateResponse = JsonSerializer.Deserialize<StatisticCreateResponseModel>(responseString, _serializerOptions);
            return statisticCreateResponse;
        }
        catch (HttpRequestException httpException)
        {
            Console.WriteLine(httpException.Message);
            throw;
        }
    }
    
    
}