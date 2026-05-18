using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Domain.Responses;
using PICMate.Api.Repositories.Interfaces;
using PICMate.Api.Services.Interfaces;

namespace PICMate.Api.Services.Implementations;

public class PhotographerService(IPhotographerRepository photographerRepository) : IPhotographerService
{
    public Task<PagedResponse<Photographer>> GetPagedAsync(PhotographerQuery query, CancellationToken ct = default) => photographerRepository.GetPagedAsync(query, ct);

    public Task<Photographer?> GetByIdAsync(int id, CancellationToken ct = default) => photographerRepository.GetByIdAsync(id, ct);
}
