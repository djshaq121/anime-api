using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using Microsoft.Extensions.Options;
using WebApi.Entities;

namespace WebApi;

public class SearchService : ISearchService
{
    private readonly SearchClient _searchClient;
    private readonly string _suggesterName;

    public SearchService(IOptions<SearchSettings> searchOptions)
    {
        _searchClient = new SearchClient(new Uri(searchOptions.Value.EndPoint), searchOptions.Value.IndexName,
            new AzureKeyCredential(searchOptions.Value.QueryApiKey));
        _suggesterName = searchOptions.Value.SuggesterName;
    }

    public async Task<List<AnimeSearch>> SearchAnime(string searchText)
    {
        var options = new SearchOptions { IncludeTotalCount = true, QueryType = SearchQueryType.Full };
        try
        {
            var results = await _searchClient.SearchAsync<AnimeSearch>(searchText, options);
            var searchedAnime = results.Value.GetResults().ToList().Select(x => x.Document);
            return searchedAnime.ToList();
        }
        catch (Exception ex)
        {
            var error = ex;
            throw;
        }
    }

    public async Task<List<AnimeSearch>> SuggestAnime(string searchText)
    {
        var options = new SuggestOptions { UseFuzzyMatching = true, Size = 30};
        options.Select.Add("Id");
        options.Select.Add("Title");
        options.Select.Add("EnglishTitle");
        options.Select.Add("Episode");
        options.Select.Add("MediaGenre");
        options.Select.Add("Status");
        options.Select.Add("BroadcastDay");
        
        try
        {
            var results = await _searchClient.SuggestAsync<AnimeSearch>(searchText, _suggesterName, options);
            var suggestedAnime = results.Value.Results.ToList().Select(x => x.Document);
            return suggestedAnime.ToList();
        }
        catch (Exception ex)
        {
            var error = ex;
            throw;
        }
    }
}