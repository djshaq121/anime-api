using WebApi.Entities;

namespace WebApi;

public interface ISearchService
{

    Task<List<AnimeSearch>> SearchAnime(string searchText);
    Task<List<AnimeSearch>> SuggestAnime(string searchText);
}