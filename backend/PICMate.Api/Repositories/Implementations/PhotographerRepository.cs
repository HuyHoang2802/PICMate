using Microsoft.EntityFrameworkCore;
using PICMate.Api.Data;
using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Domain.Responses;
using PICMate.Api.Repositories.Interfaces;

namespace PICMate.Api.Repositories.Implementations;

public class PhotographerRepository(AppDbContext db) : IPhotographerRepository
{
    public async Task<PagedResponse<Photographer>> GetPagedAsync(PhotographerQuery query, CancellationToken ct = default)
    {
        var q = db.Photographers.Include(x => x.Styles).Include(x => x.PortfolioImages).Include(x => x.Reviews).AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            var s = query.Search.Trim().ToLower();
            q = q.Where(x => x.Name.ToLower().Contains(s) || x.Location.ToLower().Contains(s));
        }

        if (!string.IsNullOrWhiteSpace(query.Style)) q = q.Where(x => x.Styles.Any(s => s.Name == query.Style));
        if (query.InstantOnly == true) q = q.Where(x => x.InstantBooking);

        q = (query.SortBy?.ToLower(), query.SortDirection?.ToLower()) switch
        {
            ("rating", "asc") => q.OrderBy(x => x.Rating),
            ("rating", _) => q.OrderByDescending(x => x.Rating),
            ("price", "asc") => q.OrderBy(x => x.HourlyPrice),
            ("price", _) => q.OrderByDescending(x => x.HourlyPrice),
            _ => q.OrderByDescending(x => x.Id)
        };

        var total = await q.CountAsync(ct);
        var page = Math.Max(1, query.Page);
        var size = Math.Clamp(query.PageSize, 1, 100);
        var items = await q.Skip((page - 1) * size).Take(size).ToListAsync(ct);

        return new PagedResponse<Photographer>
        {
            Items = items,
            Page = page,
            PageSize = size,
            TotalItems = total,
            TotalPages = (int)Math.Ceiling(total / (double)size)
        };
    }

    public Task<Photographer?> GetByIdAsync(int id, CancellationToken ct = default) =>
        db.Photographers
            .Include(x => x.Styles)
            .Include(x => x.PortfolioImages)
            .Include(x => x.Reviews)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
}
