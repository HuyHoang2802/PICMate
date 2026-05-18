using PICMate.Api.Domain.Dtos;
using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Domain.Responses;

namespace PICMate.Api.Services.Interfaces;

public interface IBookingService
{
    Task<PagedResponse<Booking>> GetPagedAsync(BookingQuery query, CancellationToken ct = default);
    Task<Booking?> CreateAsync(CreateBookingRequest request, CancellationToken ct = default);
}
