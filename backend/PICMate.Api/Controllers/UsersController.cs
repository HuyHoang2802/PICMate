using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Services.Interfaces;

namespace PICMate.Api.Controllers;

[ApiController]
[Route("api/users")]
[Authorize(Roles = "admin")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] UserQuery query, CancellationToken ct)
        => Ok(await userService.GetPagedAsync(query, ct));
}
