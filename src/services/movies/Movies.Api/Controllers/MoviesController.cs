using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Movies.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private static readonly string[] movies = new[]
    {
        "Forrest Gump",
        "The Godfather",
        "Interstellar",
        "Avatar"
    };

    private readonly ILogger _logger;

    public MoviesController()
    {
        _logger = Log.ForContext<MoviesController>();
    }

    [HttpGet(Name = "GetAll")]
    public IActionResult GetAll()
    {
        _logger.Information("Getting all");
        return Ok(movies);
    }

    // GET api/values/5
    [HttpGet("{id:int}", Name = "GetById")]
    public ActionResult<string> GetById(int id)
    {
        _logger.Information("Getting App by Id {Id}", id);
        return "app";
    }

    [HttpPatch("{id:int}", Name = "UpdateById")]
    public IActionResult UpdateById(int id)
    {
        _logger.Information("Updating App by Id {Id}", id);
        return Ok();
    }

    [HttpDelete("{id:int}", Name = "DeleteById")]
    public IActionResult DeleteById(int id)
    {
        _logger.Information("Deleting App by Id {Id}", id);
        return Ok(movies);
    }
}
