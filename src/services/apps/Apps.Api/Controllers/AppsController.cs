using Microsoft.AspNetCore.Mvc;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Apps.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AppsController : ControllerBase
{
    private static readonly string[] Apps = new[] { "Word", "Excel", "Powerpoint", "Visio" };

    private readonly ILogger _logger;

    public AppsController()
    {
        _logger = Log.ForContext<AppsController>();
    }

    [HttpGet(Name = "GetApps")]
    public IActionResult GetApps()
    {
        _logger.Information("Getting all apps");
        return Ok(Apps);
    }

    // GET api/values/5
    [HttpGet("{id:int}", Name = "GetAppById")]
    public ActionResult<string> GetAppById(int id)
    {
        _logger.Information("Getting App by Id {Id}", id);
        return "app";
    }

    [HttpPatch("{id:int}", Name = "UpdateAppById")]
    public IActionResult UpdateApp(int id)
    {
        _logger.Information("Updating App by Id {Id}", id);
        return Ok();
    }

    [HttpDelete("{id:int}", Name = "DeleteAppById")]
    public IActionResult Delete(int id)
    {
        _logger.Information("Deleting App by Id {Id}", id);
        return Ok(Apps);
    }
}
