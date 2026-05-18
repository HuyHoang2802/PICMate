using PICMate.Api.Domain.Dtos;
using PICMate.Api.Domain.Entities;

namespace PICMate.Api.Services.Interfaces;

public interface IAuthService
{
    Task<DemoAccount?> ValidateCredentialAsync(LoginRequest request, CancellationToken ct = default);
}
