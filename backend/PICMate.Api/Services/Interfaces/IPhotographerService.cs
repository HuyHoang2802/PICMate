using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Domain.Responses;

namespace PICMate.Api.Services.Interfaces;

public interface IPhotographerService
{
    Task<PagedResponse<Photographer>> GetPagedAsync(PhotographerQuery query, CancellationToken ct = default);
    Task<Photographer?> GetByIdAsync(int id, CancellationToken ct = default);
}
