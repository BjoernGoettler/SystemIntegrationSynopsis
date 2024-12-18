using System.Text.Json;

namespace DataService.JsonNamingpolicies;

public class SnakeCaseNamingPolicy: JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        var words = name.Split("_");
        for (var i = 0; i < words.Length; i++)
        {
            words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
        }
        return string.Concat(words);
    }
    
}