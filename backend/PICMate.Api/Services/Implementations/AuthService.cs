using PICMate.Api.Domain.Dtos;
using PICMate.Api.Domain.Entities;
using PICMate.Api.Repositories.Interfaces;
using PICMate.Api.Services.Interfaces;

namespace PICMate.Api.Services.Implementations;

public class AuthService(IAuthRepository authRepository) : IAuthService
{
    public Task<DemoAccount?> ValidateCredentialAsync(LoginRequest request, CancellationToken ct = default)
        => authRepository.FindByCredentialAsync(request.Email, request.Password, ct);
}
