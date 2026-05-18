using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Domain.Responses;

namespace PICMate.Api.Services.Interfaces;

public interface IUserService
{
    Task<PagedResponse<AppUser>> GetPagedAsync(UserQuery query, CancellationToken ct = default);
}
