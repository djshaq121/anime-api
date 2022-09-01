using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimeController : ControllerBase
{
    private readonly AnimeRepository _animeRepository;

    public AnimeController(AnimeRepository animeRepository)
    {
        _animeRepository = animeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAnime()
    {
        return Ok(await _animeRepository.QueryAsync());
    }
}