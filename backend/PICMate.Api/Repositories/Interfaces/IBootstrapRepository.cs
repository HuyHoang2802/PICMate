namespace PICMate.Api.Repositories.Interfaces;

public interface IBootstrapRepository
{
    Task<object> GetBootstrapAsync(CancellationToken ct = default);
}
