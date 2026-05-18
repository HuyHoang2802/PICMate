using PICMate.Api.Domain.Entities;

namespace PICMate.Api.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<DemoAccount?> FindByCredentialAsync(string email, string password, CancellationToken ct = default);
}
