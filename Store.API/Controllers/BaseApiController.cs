using Microsoft.AspNetCore.Mvc;

namespace Store.API.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class BaseApiController : ControllerBase
{
    protected readonly ILogger Logger;

    protected BaseApiController(ILogger logger)
    {
        Logger = logger;
    }
}