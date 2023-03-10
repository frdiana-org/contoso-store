using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Apps.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AppsController : ControllerBase
{
    private static readonly string[] apps = new[] { "Word", "Excel", "Powerpoint", "Visio" };

    private readonly ILogger _logger;

    public AppsController()
    {
        _logger = Log.ForContext<AppsController>();
    }

    [HttpGet(Name = "GetAll")]
    public IActionResult GetAll()
    {
        _logger.Information("Getting all apps");
        return Ok(apps);
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
        return Ok(apps);
    }
}
