namespace WebApi;

public class SearchSettings
{
    public string IndexName { get; set; } = string.Empty;
    public string EndPoint { get; set; } = string.Empty;
    public string QueryApiKey { get; set; } = string.Empty;
    
    public string SuggesterName { get; set; } = string.Empty;
}