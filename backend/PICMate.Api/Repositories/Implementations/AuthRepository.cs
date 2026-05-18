using Microsoft.EntityFrameworkCore;
using PICMate.Api.Data;
using PICMate.Api.Domain.Entities;
using PICMate.Api.Repositories.Interfaces;

namespace PICMate.Api.Repositories.Implementations;

public class AuthRepository(AppDbContext db) : IAuthRepository
{
    public Task<DemoAccount?> FindByCredentialAsync(string email, string password, CancellationToken ct = default) =>
        db.DemoAccounts.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower() && x.Password == password, ct);
}
