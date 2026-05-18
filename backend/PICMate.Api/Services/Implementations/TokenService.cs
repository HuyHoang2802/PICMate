using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PICMate.Api.Common.Auth;
using PICMate.Api.Data;
using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Responses;
using PICMate.Api.Services.Interfaces;

namespace PICMate.Api.Services.Implementations;

public class TokenService(AppDbContext db, IOptions<JwtOptions> jwtOptions) : ITokenService
{
    private readonly JwtOptions _jwt = jwtOptions.Value;

    public LoginResultResponse GenerateTokenPair(DemoAccount account)
    {
        var now = DateTime.UtcNow;
        var accessExp = now.AddMinutes(_jwt.AccessTokenMinutes);

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwt.SecretKey);
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.Name),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, account.Role)
            ]),
            Expires = accessExp,
            Issuer = _jwt.Issuer,
            Audience = _jwt.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(descriptor);
        var accessToken = tokenHandler.WriteToken(token);
        var refreshToken = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");

        db.RefreshTokens.Add(new RefreshToken
        {
            DemoAccountId = account.Id,
            Token = refreshToken,
            CreatedAtUtc = now,
            ExpiresAtUtc = now.AddDays(_jwt.RefreshTokenDays),
            Revoked = false
        });
        db.SaveChanges();

        return new LoginResultResponse(accessToken, refreshToken, accessExp, "Bearer", account.Redirect, account.Role, account.Name, account.Email, account.Avatar);
    }

    public async Task<RefreshResponse?> RefreshAsync(string refreshToken, CancellationToken ct = default)
    {
        var found = await db.RefreshTokens.Include(x => x.DemoAccount)
            .FirstOrDefaultAsync(x => x.Token == refreshToken && !x.Revoked, ct);

        if (found is null || found.ExpiresAtUtc < DateTime.UtcNow || found.DemoAccount is null)
        {
            return null;
        }

        found.Revoked = true;
        var pair = GenerateTokenPair(found.DemoAccount);
        await db.SaveChangesAsync(ct);
        return new RefreshResponse(pair.AccessToken, pair.RefreshToken, pair.AccessTokenExpiresAtUtc, pair.TokenType);
    }
}
