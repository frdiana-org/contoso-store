using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Books.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private static readonly string[] books = new[]
    {
        "War and Peace",
        "The Brothers Karamazov",
        "The Idiot",
        "Crime and Punishment",
    };

    private readonly ILogger _logger;

    public BooksController()
    {
        _logger = Log.ForContext<BooksController>();
    }

    [HttpGet(Name = "GetAll")]
    public IActionResult GetAll()
    {
        _logger.Information("Getting all");
        return Ok(books);
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
        return Ok();
    }
}
