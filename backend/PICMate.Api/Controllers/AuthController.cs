using Microsoft.AspNetCore.Mvc;
using PICMate.Api.Domain.Dtos;
using PICMate.Api.Domain.Responses;
using PICMate.Api.Services.Interfaces;

namespace PICMate.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService, ITokenService tokenService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken ct)
    {
        var account = await authService.ValidateCredentialAsync(request, ct);
        if (account is null) return BadRequest(new { message = "Email hoặc mật khẩu không đúng!" });

        return Ok(tokenService.GenerateTokenPair(account));
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request, CancellationToken ct)
    {
        var result = await tokenService.RefreshAsync(request.RefreshToken, ct);
        return result is null ? Unauthorized(new { message = "Invalid refresh token." }) : Ok(result);
    }
}
