using Microsoft.EntityFrameworkCore;
using PICMate.Api.Data;
using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Domain.Responses;
using PICMate.Api.Repositories.Interfaces;

namespace PICMate.Api.Repositories.Implementations;

public class BookingRepository(AppDbContext db) : IBookingRepository
{
    public async Task<PagedResponse<Booking>> GetPagedAsync(BookingQuery query, CancellationToken ct = default)
    {
        var q = db.Bookings.AsQueryable();
        if (!string.IsNullOrWhiteSpace(query.Status)) q = q.Where(x => x.Status == query.Status);

        q = (query.SortBy?.ToLower(), query.SortDirection?.ToLower()) switch
        {
            ("date", "asc") => q.OrderBy(x => x.Date).ThenBy(x => x.Time),
            ("date", _) => q.OrderByDescending(x => x.Date).ThenByDescending(x => x.Time),
            ("total", "asc") => q.OrderBy(x => x.Total),
            ("total", _) => q.OrderByDescending(x => x.Total),
            _ => q.OrderByDescending(x => x.Date)
        };

        var total = await q.CountAsync(ct);
        var page = Math.Max(1, query.Page);
        var size = Math.Clamp(query.PageSize, 1, 100);
        var items = await q.Skip((page - 1) * size).Take(size).ToListAsync(ct);

        return new PagedResponse<Booking>
        {
            Items = items,
            Page = page,
            PageSize = size,
            TotalItems = total,
            TotalPages = (int)Math.Ceiling(total / (double)size)
        };
    }

    public async Task<Booking> AddAsync(Booking booking, CancellationToken ct = default)
    {
        db.Bookings.Add(booking);
        await db.SaveChangesAsync(ct);
        return booking;
    }
}
