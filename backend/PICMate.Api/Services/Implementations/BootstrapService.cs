using PICMate.Api.Repositories.Interfaces;
using PICMate.Api.Services.Interfaces;

namespace PICMate.Api.Services.Implementations;

public class BootstrapService(IBootstrapRepository bootstrapRepository) : IBootstrapService
{
    public Task<object> GetBootstrapAsync(CancellationToken ct = default) => bootstrapRepository.GetBootstrapAsync(ct);
}
