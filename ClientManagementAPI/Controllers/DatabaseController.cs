using ClientManagementAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementAPI.Controllers;

[ApiController]
[Route("api/database")]
public class DatabaseController(ClientDbContext dbContext) : ControllerBase
{
    [HttpGet("health")]
    public async Task<IActionResult> Health(CancellationToken cancellationToken)
    {
        var canConnect = await dbContext.Database.CanConnectAsync(cancellationToken);

        return canConnect
            ? Ok(new { status = "connected", database = dbContext.Database.GetDbConnection().Database })
            : StatusCode(StatusCodes.Status503ServiceUnavailable, new { status = "unavailable" });
    }
}
