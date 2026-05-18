using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Domain.Responses;

namespace PICMate.Api.Repositories.Interfaces;

public interface IBookingRepository
{
    Task<PagedResponse<Booking>> GetPagedAsync(BookingQuery query, CancellationToken ct = default);
    Task<Booking> AddAsync(Booking booking, CancellationToken ct = default);
}
