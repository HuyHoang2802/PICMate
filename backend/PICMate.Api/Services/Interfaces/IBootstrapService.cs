namespace PICMate.Api.Services.Interfaces;

public interface IBootstrapService
{
    Task<object> GetBootstrapAsync(CancellationToken ct = default);
}
