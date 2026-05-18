using Microsoft.EntityFrameworkCore;
using PICMate.Api.Data;
using PICMate.Api.Domain.Entities;
using PICMate.Api.Domain.Queries;
using PICMate.Api.Domain.Responses;
using PICMate.Api.Repositories.Interfaces;

namespace PICMate.Api.Repositories.Implementations;

public class UserRepository(AppDbContext db) : IUserRepository
{
    public async Task<PagedResponse<AppUser>> GetPagedAsync(UserQuery query, CancellationToken ct = default)
    {
        var q = db.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            var s = query.Search.Trim().ToLower();
            q = q.Where(x => x.Name.ToLower().Contains(s) || x.Email.ToLower().Contains(s));
        }

        if (!string.IsNullOrWhiteSpace(query.Type)) q = q.Where(x => x.Type == query.Type);
        if (query.Active.HasValue) q = q.Where(x => x.Active == query.Active.Value);

        q = (query.SortBy?.ToLower(), query.SortDirection?.ToLower()) switch
        {
            ("name", "asc") => q.OrderBy(x => x.Name),
            ("name", _) => q.OrderByDescending(x => x.Name),
            ("joindate", "asc") => q.OrderBy(x => x.JoinDate),
            ("joindate", _) => q.OrderByDescending(x => x.JoinDate),
            _ => q.OrderByDescending(x => x.Id)
        };

        var total = await q.CountAsync(ct);
        var page = Math.Max(1, query.Page);
        var size = Math.Clamp(query.PageSize, 1, 100);
        var items = await q.Skip((page - 1) * size).Take(size).ToListAsync(ct);

        return new PagedResponse<AppUser>
        {
            Items = items,
            Page = page,
            PageSize = size,
            TotalItems = total,
            TotalPages = (int)Math.Ceiling(total / (double)size)
        };
    }
}
