using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Domain.Responses;
using PICMate.Api.Repositories.Interfaces;
using PICMate.Api.Services.Interfaces;

namespace PICMate.Api.Services.Implementations;

public class UserService(IUserRepository userRepository) : IUserService
{
    public Task<PagedResponse<AppUser>> GetPagedAsync(UserQuery query, CancellationToken ct = default) => userRepository.GetPagedAsync(query, ct);
}
