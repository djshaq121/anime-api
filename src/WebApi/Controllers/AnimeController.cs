using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimeController : ControllerBase
{
    private readonly AnimeRepository _animeRepository;
    private readonly ISearchService _searchService;

    public AnimeController(AnimeRepository animeRepository, ISearchService searchService)
    {
        _animeRepository = animeRepository;
        _searchService = searchService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAnime()
    {
        return Ok(await _animeRepository.QueryAsync());
    }

    [HttpGet("search/{searchText}")]
    public async Task<IActionResult> SearchAnime(string searchText, bool bUseSuggesting = true)
    {
        var results = bUseSuggesting
            ? await _searchService.SuggestAnime(searchText)
            : await _searchService.SearchAnime(searchText);
        return Ok(results);
    }
}