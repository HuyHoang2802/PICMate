using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Responses;

namespace PICMate.Api.Services.Interfaces;

public interface ITokenService
{
    LoginResultResponse GenerateTokenPair(DemoAccount account);
    Task<RefreshResponse?> RefreshAsync(string refreshToken, CancellationToken ct = default);
}
