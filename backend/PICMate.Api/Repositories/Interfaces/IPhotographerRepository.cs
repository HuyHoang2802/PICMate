using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Domain.Responses;

namespace PICMate.Api.Repositories.Interfaces;

public interface IPhotographerRepository
{
    Task<PagedResponse<Photographer>> GetPagedAsync(PhotographerQuery query, CancellationToken ct = default);
    Task<Photographer?> GetByIdAsync(int id, CancellationToken ct = default);
}
