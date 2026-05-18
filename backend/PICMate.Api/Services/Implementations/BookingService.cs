using PICMate.Api.Domain.Dtos;
using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Domain.Responses;
using PICMate.Api.Repositories.Interfaces;
using PICMate.Api.Services.Interfaces;

namespace PICMate.Api.Services.Implementations;

public class BookingService(IBookingRepository bookingRepository, IPhotographerRepository photographerRepository) : IBookingService
{
    public Task<PagedResponse<Booking>> GetPagedAsync(BookingQuery query, CancellationToken ct = default) => bookingRepository.GetPagedAsync(query, ct);

    public async Task<Booking?> CreateAsync(CreateBookingRequest request, CancellationToken ct = default)
    {
        var photographer = await photographerRepository.GetByIdAsync(request.PhotographerId, ct);
        if (photographer is null) return null;

        var booking = new Booking
        {
            Id = $"BK-{DateTime.UtcNow:yyyyMMdd}-{Random.Shared.Next(100, 999)}",
            PhotographerId = photographer.Id,
            PhotographerName = photographer.Name,
            PhotographerAvatar = photographer.Avatar,
            Service = request.Service,
            Date = request.Date,
            Time = request.Time,
            Location = request.Location,
            Status = "pending",
            Total = request.Total,
            Note = request.Note
        };

        return await bookingRepository.AddAsync(booking, ct);
    }
}
