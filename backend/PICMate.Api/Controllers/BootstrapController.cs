using Microsoft.AspNetCore.Mvc;
using PICMate.Api.Services.Interfaces;

namespace PICMate.Api.Controllers;

[ApiController]
[Route("api/bootstrap")]
public class BootstrapController(IBootstrapService bootstrapService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken ct)
        => Ok(await bootstrapService.GetBootstrapAsync(ct));
}
